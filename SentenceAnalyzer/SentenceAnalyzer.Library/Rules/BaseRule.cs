using Common.Model;
using SentenceAnalyzer.Library.Rules.Enums;
using System;
using System.Text.RegularExpressions;
namespace SentenceAnalyzer.Library.Rules
{
    public abstract class BaseRule
    {
        #region Keys
        protected readonly string A = WrapKey(Article.KEY);
        protected readonly string Adv = WrapKey(Adverb.KEY);
        protected readonly string Adj = WrapKey(Adjective.KEY);
        protected readonly string P = WrapKey(Pronoun.KEY);
        protected readonly string PR = WrapKey(Pronoun.KEY_RELETIVE);
        protected readonly string C = WrapKey(Conjunction.KEY);
        protected readonly string N = WrapKey(Noun.KEY);
        protected readonly string V = WrapKey(Verb.KEY);
        protected readonly string I = WrapKey(Interjection.KEY);
        protected readonly string MV = WrapKey(ModalVerb.KEY);
        protected readonly string Pr = WrapKey(Preposition.KEY);
        protected readonly string NOT = @"{not}";
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

        
        protected abstract string AffirmativeTemplate { get; }
        protected abstract string NegativeTemplate { get; }
        protected abstract string InterrogativeTemplate { get; }

        public bool Verify(Sentence sentence)
        {
            var transformedSentence = sentence.Transform();
            if (Regex.IsMatch(transformedSentence, InterrogativeTemplate))
            {
                return true;
            }
            else if (Regex.IsMatch(transformedSentence, NegativeTemplate))
            {
                return true;
            }
            else if (Regex.IsMatch(transformedSentence, AffirmativeTemplate))
            {
                return true;
            }
            return false;
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
            switch (direction.Value)
            {
                case SentenceDirection.Affirmative:
                    {
                        var mm = Regex.Matches(transformedSentence, AffirmativeSubjectTemplate);
                        //todo get chunks
                        break;
                    }
            }

            return new SentenceInfo
            {
                Direction = direction.Value.ToString(),
                Tense = Name,
                //Predicate = 
            };
        }
    }
}