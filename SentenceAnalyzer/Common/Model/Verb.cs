using System;
using System.Collections.Generic;
using Common.Model.Enum;

namespace Common.Model
{
    public class Verb : Word
    {
        public Verb(string text) : base(text)
        { }

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

        public const string KEY = @"V";
        public override string Key { get { return KEY; } }
    }
}