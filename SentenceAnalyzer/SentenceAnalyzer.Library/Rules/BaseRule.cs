using Common.Model;
using SentenceAnalyzer.Library.Rules.Enums;
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
        protected static readonly string PR = WrapKey(Pronoun.KEY_RELETIVE);
        protected static readonly string C = WrapKey(Conjunction.KEY);
        protected static readonly string N = WrapKey(Noun.KEY);
        protected static readonly string B = WrapKey(Verb.KEYB);
        protected static readonly string V1 = WrapKey(Verb.KEY1);
        protected static readonly string V2 = WrapKey(Verb.KEY2);
        protected static readonly string V3 = WrapKey(Verb.KEY3);
        protected static readonly string V4 = WrapKey(Verb.KEY4);
        protected static readonly string I = WrapKey(Interjection.KEY);
        protected static readonly string MV = WrapKey(ModalVerb.KEY);
        protected static readonly string Pr = WrapKey(Preposition.KEY);
        #endregion

        public abstract string Name { get; }

        protected static string WrapKey(string key)
        {
            return string.Format(@"\{{(\w+\|)*{0}(\|\w+)*\}}", key);
        }

        //todo: make abstract
        protected virtual string AffirmativeSubjectTemplate
        {
            get
            {
                return "";
            }
        }

        internal static string SubjectTemplate
        {
            get
            {
                return string.Format(@"(((({0}\W)?({1}\W))|({0}\W)?({2}\W)?({3}\W({0}\W)?)*{4}))", C, P1, A, Adj, N);
                //return string.Format(@"({0}\W)", P1);
            }
        }

        protected abstract string AffirmativeTemplate { get; }
        protected abstract string NegativeTemplate { get; }
        protected abstract string InterrogativeTemplate { get; }

        public bool Verify(Sentence sentence)
        {
            var transformedSentence = sentence.Transform();
            return VerifyInner(sentence).HasValue;
        }

        private SentenceDirection? VerifyInner(Sentence sentence)
        {
            var transformedSentence = sentence.Transform();
            if (Regex.IsMatch(transformedSentence, InterrogativeTemplate))
            {
                return SentenceDirection.Interrogative;
            }
            else if (Regex.IsMatch(transformedSentence, NegativeTemplate))
            {
                return SentenceDirection.Negative;
            }
            else if (Regex.IsMatch(transformedSentence, AffirmativeTemplate))
            {
                return SentenceDirection.Affirmative;
            }
            return null;
        }

        public SentenceInfo Explain(Sentence sentence)
        {
            var direction = VerifyInner(sentence);
            if (direction == null) return null;

            var transformedSentence = sentence.Transform();

            var s = Regex.Replace(transformedSentence, AffirmativeTemplate, string.Format("$1{0}$6{1}$29", LEFT_SUBJECT, RIGHT_SUBJECT));

            var s2 = Regex.Replace(s, @"({(\w+\|)*(V)(\|\w+)*})", string.Format("{0}$1{1}", LEFT_PREDICAT, RIGHT_PREDICAT));

            var q = Regex.Match(transformedSentence, AffirmativeTemplate).Groups;

            var test = Regex.Replace(transformedSentence, AffirmativeTemplate, "!$6!");

            var subject = Regex.Match(transformedSentence, BaseRule.SubjectTemplate).Value;
            var str = transformedSentence.Replace(subject, LEFT_SUBJECT + subject + RIGHT_SUBJECT);

            var text = sentence.TransformBack(str);

            var l = text.IndexOf(LEFT_SUBJECT);
            var r = text.IndexOf(RIGHT_SUBJECT) - 2;

            switch (direction.Value)
            {
                case SentenceDirection.Affirmative:
                    {
                        foreach (var pr in Regex.Matches(transformedSentence, V1))
                        {

                        }
                        break;
                    }
            }

            return new SentenceInfo
            {
                Direction = direction.ToString(),
                Tense = Name,
                Subject = new Chunk(l, r, sentence.Text.Substring(l, r - l))
                //Predicate = 
            };
        }
    }
}