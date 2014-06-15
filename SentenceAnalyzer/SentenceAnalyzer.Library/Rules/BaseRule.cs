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

        //protected readonly string SubjectTemplate = string.Format(@"(((({0}\W)?({1}\W))|({0}\W)?({2}\W)?({3}\W({0}\W)?)*{4}))", C, P1, A, Adj, N);
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
            switch (direction.Value)
            {
                case SentenceDirection.Affirmative:
                    format = string.Format(AffirmativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    break;
                case SentenceDirection.Negative:
                    format = string.Format(NegativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    break;
                case SentenceDirection.Interrogative:
                    format = string.Format(InterrogativeMask, LEFT_SUBJECT, RIGHT_SUBJECT, LEFT_PREDICAT, RIGHT_PREDICAT);
                    break;
                default: throw new NotSupportedException(direction.Value.ToString());
            }

            var replace = Regex.Replace(transformedSentence, AffirmativeTemplate, format);
            var text = sentence.TransformBack(replace);

            // Subject Chunck
            var l = text.IndexOf(LEFT_SUBJECT, StringComparison.Ordinal);
            var r = text.IndexOf(RIGHT_SUBJECT, StringComparison.Ordinal) - 2;
            var subjectChunk = new Chunk(l, r, sentence.Text.Substring(l, r - l));
            var redundantSymbolsCount = LEFT_SUBJECT.Length + RIGHT_SUBJECT.Length;

            // Predicate Chuncks
            var predicateChuncks = new List<Chunk>();
            l = text.IndexOf(LEFT_PREDICAT, StringComparison.Ordinal) - redundantSymbolsCount;
            r = text.IndexOf(RIGHT_PREDICAT, StringComparison.Ordinal) - 2 - redundantSymbolsCount;

            while (l > -1)
            {
                redundantSymbolsCount += LEFT_PREDICAT.Length + RIGHT_PREDICAT.Length;
                predicateChuncks.Add(new Chunk(l, r, sentence.Text.Substring(l, r - l)));

                l = text.IndexOf(LEFT_PREDICAT, r + redundantSymbolsCount, StringComparison.Ordinal) - redundantSymbolsCount;
                if (l > -1) r = text.IndexOf(RIGHT_PREDICAT, l + redundantSymbolsCount, StringComparison.Ordinal) - 2 - redundantSymbolsCount;
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