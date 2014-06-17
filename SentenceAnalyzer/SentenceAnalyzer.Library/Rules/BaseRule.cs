using Common.Model;
using SentenceAnalyzer.Library.Rules.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace SentenceAnalyzer.Library.Rules
{
    public abstract class BaseRule
    {
        private const string LEFT_SUBJECT = "<&";
        private const string RIGHT_SUBJECT = "&>";

        private const string LEFT_PREDICAT = "<%";
        private const string RIGHT_PREDICAT = "%>";

        #region Keys
        protected static readonly string A = WrapKey(Article.KEY);
        protected static readonly string Adv = WrapKey(Adverb.KEY);
        protected static readonly string Adj = WrapKey(Adjective.KEY);
        protected static readonly string P1 = WrapKey(Pronoun.KEY1);
        protected static readonly string P2 = WrapKey(Pronoun.KEY2);
        protected static readonly string Prel = WrapKey(Pronoun.KEY_RELETIVE);
        protected static readonly string C = WrapKey(Conjunction.KEY);
        protected static readonly string N = WrapKey(Noun.KEY);
        protected static readonly string B = WrapKey(Verb.KEYB);
        protected static readonly string V1 = WrapKey(Verb.KEY1);
        protected static readonly string V2 = WrapKey(Verb.KEY2);
        protected static readonly string V3 = WrapKey(Verb.KEY3);
        protected static readonly string V4 = WrapKey(Verb.KEY4);
        protected static readonly string I = WrapKey(Interjection.KEY);
        protected static readonly string Mv = WrapKey(ModalVerb.KEY);
        protected static readonly string Pr = WrapKey(Preposition.KEY);
        #endregion

        public abstract string Name { get; }

        protected static string WrapKey(string key)
        {
            return string.Format(@"\{{(\w+\|)*{0}(\|\w+)*\}}", key);
        }

        protected readonly string SubjectTemplate = string.Format(@"(({0}\W+)?({1}\W+)?|((({2}\W+)|({3}\W+))?({4}\W+)*({5}\W+)))", C, P1, A, P2, Adj, N); 

        protected abstract string AffirmativeTemplate { get; }
        protected abstract string NegativeTemplate { get; }
        protected abstract string InterrogativeTemplate { get; }

        public bool Verify(Sentence sentence)
        {
            return VerifyInner(sentence).HasValue;
        }

        private SentenceDirection? VerifyInner(Sentence sentence)
        {
            var transformedSentence = sentence.Transform();
            if (Regex.IsMatch(transformedSentence, InterrogativeTemplate))
            {
                return SentenceDirection.Interrogative;
            }
            if (Regex.IsMatch(transformedSentence, NegativeTemplate))
            {
                return SentenceDirection.Negative;
            }
            if (Regex.IsMatch(transformedSentence, AffirmativeTemplate))
            {
                return SentenceDirection.Affirmative;
            }
            return null;
        }

        protected abstract string AffirmativeMask { get; }
        protected abstract string NegativeMask { get; }
        protected abstract string InterrogativeMask { get; }

        public SentenceInfo Explain(Sentence sentence)
        {
            var direction = VerifyInner(sentence);
            if (direction == null) return null;

            var transformedSentence = sentence.Transform();

            string format;
            string template;
            switch (direction.Value)
            {
                case SentenceDirection.Affirmative:
                    format = string.Format(AffirmativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    template = AffirmativeTemplate;
                    break;
                case SentenceDirection.Negative:
                    format = string.Format(NegativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    template = NegativeTemplate;

                    var m1 = Regex.Match(transformedSentence, template).Groups[18].Value;
                    if (!m1.Contains("MV") && !m1.Contains("B")) format = format.Replace("<%$18%>", "$18");

                    break;
                case SentenceDirection.Interrogative:
                    format = string.Format(InterrogativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    template = InterrogativeTemplate;

                    var m2 = Regex.Match(transformedSentence, template).Groups[9].Value;
                    if (!m2.Contains("MV") && !m2.Contains("B")) format = format.Replace("<%$9%>", "$9");

                    break;
                default: throw new NotSupportedException(direction.Value.ToString());
            }

            var replace = Regex.Replace(transformedSentence, template, format);
            var text = sentence.TransformBack(replace);

            var redundantSymbolsCount = 0;
            var l = Math.Min(text.IndexOf(LEFT_SUBJECT, StringComparison.Ordinal), text.IndexOf(LEFT_PREDICAT, StringComparison.Ordinal));
            var r = Math.Min(text.IndexOf(RIGHT_SUBJECT, StringComparison.Ordinal), text.IndexOf(RIGHT_PREDICAT, StringComparison.Ordinal)) - 2;
            
            Chunk subjectChunk = null;
            var predicateChuncks = new List<Chunk>();
            while (l > -1)
            {
                if (text.Substring(l + redundantSymbolsCount, 2) == LEFT_SUBJECT)
                {
                    subjectChunk = new Chunk(l, r, sentence.Text.Substring(l, r - l));
                }
                else
                {
                    predicateChuncks.Add(new Chunk(l, r, sentence.Text.Substring(l, r - l)));
                }

                redundantSymbolsCount += 4;
                var ls = text.IndexOf(LEFT_SUBJECT, r + redundantSymbolsCount, StringComparison.Ordinal);
                var lp = text.IndexOf(LEFT_PREDICAT, r + redundantSymbolsCount, StringComparison.Ordinal);
                l = ls < 0 || lp < 0 ? Math.Max(ls, lp) - redundantSymbolsCount : Math.Min(ls, lp) - redundantSymbolsCount;
                
                if (l <= -1) continue;
                var rs = text.IndexOf(RIGHT_SUBJECT, l + redundantSymbolsCount, StringComparison.Ordinal);
                var rp = text.IndexOf(RIGHT_PREDICAT, l + redundantSymbolsCount, StringComparison.Ordinal);
                r = rs < 0 || rp < 0 ? Math.Max(rs, rp) - 2 - redundantSymbolsCount : Math.Min(rs, rp) - 2 - redundantSymbolsCount;
            }

            return new SentenceInfo
            {
                Direction = direction.ToString(),
                Tense = Name,
                Subject = subjectChunk,
                Predicate = predicateChuncks.ToArray()
            };
        }
    }
}