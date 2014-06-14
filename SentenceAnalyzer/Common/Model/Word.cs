using System;
using System.Collections.Generic;
using System.Linq;
using Common.Model.Enum;

namespace Common.Model
{
    public abstract class Word : IEquatable<Word>
    {
        private readonly string _name;

        public abstract string Key(string form);

        protected Word(string text)
        {
            _name = text;
        }

        public abstract WordType WordType { get; }
        public string Name { get { return _name; } }
        protected List<string> Forms = new List<string>();

        public void AddForm(string form)
        {
            Forms.Add(form);
        }

        public void AddForms(IEnumerable<string> forms)
        {
            Forms.AddRange(forms);
        }

        public virtual string[] GetForms()
        {
            return Forms.ToArray();
        }

        public virtual bool MatchTo(string word, bool ignoreCase = true)
        {
            return Forms.Any(x => x.Equals(word, ignoreCase ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture));
        }

        public override string ToString()
        {
            var forms = string.Join(",", Forms).Trim(',');
            return string.Format("{1} ({2}) ({0})", WordType, _name, forms);
        }

        public static Word Create(WordType wordType, string name)
        {
            switch (wordType)
            {

                case WordType.Article: 
                    return new Article(name);
                case WordType.Noun: 
                    return new Noun(name);
                case WordType.Verb: 
                    return new Verb(name);
                case WordType.Adverb: 
                    return new Adverb(name);
                case WordType.Adjective: 
                    return new Adjective(name);
                case WordType.PronounIndefinite:
                case WordType.PronounUninflected:
                case WordType.PronounPerson1:
                case WordType.PronounPerson2:
                case WordType.PronounPerson3:
                case WordType.QuantitativePronoun:
                case WordType.PronounRelative:
                case WordType.Pronoun: 
                return new Pronoun(name, wordType);
                case WordType.Conjunction: 
                    return new Conjunction(name);
                case WordType.Preposition: 
                    return new Preposition(name);
                case WordType.Numeral: 
                    return new Numeral(name);
                case WordType.ModalVerb: 
                    return new ModalVerb(name);
                case WordType.Interjection: 
                    return new Interjection(name);
                default: 
                    throw new NotSupportedException(string.Format("The type {0} is not defined", wordType));
            }
        }

        public int GetHashCode(Word obj)
        {
            return obj.Name.GetHashCode() + obj.WordType.GetHashCode();
        }

        public bool Equals(Word other)
        {
            return WordType == other.WordType && Name.Equals(other.Name, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
