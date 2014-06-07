using System;
using System.Collections.Generic;
using System.Linq;
using Common.Model.Enum;

namespace Common.Model
{
    public abstract class Word
    {
        private readonly string _name;

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

        public virtual bool MatchTo(string word)
        {
            return Forms.Any(x => string.Compare(x, word, StringComparison.InvariantCultureIgnoreCase) == 0);
        }

        public override string ToString()
        {
            var forms = string.Join(",", Forms).Trim(',');
            return string.Format("{1} ({2}) ({0})", WordType, _name, forms);
        }
    }
}
