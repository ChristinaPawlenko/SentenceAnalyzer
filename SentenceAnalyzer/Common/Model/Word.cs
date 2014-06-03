using System;
using System.Collections.Generic;
using System.Linq;
using Common.Model.Enum;

namespace Common.Model
{
    public abstract class Word
    {
        private readonly string _text;

        protected Word(string text)
        {
            _text = text;
        }

        public abstract WordType WordType { get; }
        public string Text { get { return _text; } }
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

        public virtual bool MatchTo(string word)
        {
            return Forms.Any(x => string.Compare(x, word, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}
