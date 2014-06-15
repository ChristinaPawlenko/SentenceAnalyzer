using System;
using System.Collections.Generic;
using Common.Model.Enum;
using System.Linq;

namespace Common.Model
{
    public class Verb : Word
    {
        public Verb(string text) : base(text)
        { }

        public override string Key(string form)
        {
            if (Forms.Any(x => x.Equals("be", StringComparison.InvariantCultureIgnoreCase))) return KEYB;
            if (_formInfinitiveList.Any(x => x.Equals(form, StringComparison.InvariantCultureIgnoreCase))) return KEY1;
            if (_formPastList.Any(x => x.Equals(form, StringComparison.InvariantCultureIgnoreCase))) return KEY2;
            if (_formPastParticipleList.Any(x => x.Equals(form, StringComparison.InvariantCultureIgnoreCase))) return KEY3;
            if (_formPresentParticipleList.Any(x => x.Equals(form, StringComparison.InvariantCultureIgnoreCase))) return KEY4;

            throw new NotSupportedException();
        }

        public override WordType WordType
        {
            get { return WordType.Verb; }
        }

        private readonly List<string> _formInfinitiveList = new List<string>();
        private readonly List<string> _formPastList = new List<string>();
        private readonly List<string> _formPresentParticipleList = new List<string>();
        private readonly List<string> _formPastParticipleList = new List<string>();

        public string[] GetForms(VerbType verbType)
        {
            List<string> formsList;
            switch (verbType)
            {
                case VerbType.Infinitive:
                    formsList = _formInfinitiveList;
                    break;
                case VerbType.Past:
                    formsList = _formPastList;
                    break;
                case VerbType.PresentParticiple:
                    formsList = _formPresentParticipleList;
                    break;
                case VerbType.PastParticiple:
                    formsList = _formPastParticipleList;
                    break;
                default:
                    throw new Exception(verbType + " is not supported");
            }

            return formsList.ToArray();
        }

        public void AddForms(IEnumerable<string> forms, VerbType verbType)
        {
            switch (verbType)
            {
                case VerbType.Infinitive: _formInfinitiveList.AddRange(forms); break;
                case VerbType.Past: _formPastList.AddRange(forms); break;
                case VerbType.PastParticiple: _formPastParticipleList.AddRange(forms); break;
                case VerbType.PresentParticiple: _formPresentParticipleList.AddRange(forms); break;
            }

            Forms.AddRange(forms.Where(x => Forms.All(y => !y.Equals(x, StringComparison.InvariantCultureIgnoreCase))));
        }

        public const string KEYB = @"B";
        public const string KEY1 = @"V1";
        public const string KEY2 = @"V2";
        public const string KEY3 = @"V3";
        public const string KEY4 = @"V4";
    }
}