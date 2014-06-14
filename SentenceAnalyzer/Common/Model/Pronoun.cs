using System;
using System.Linq;
using Common.Model.Enum;

namespace Common.Model
{
    public class Pronoun : Word
    {
        private readonly WordType _wordType;

        public Pronoun(string text, WordType wordType) : base(text)
        {
            _wordType = wordType;
        }

        public override string Key(string form)
        {
            switch (_wordType)
            {
                case WordType.PronounRelative: return KEY_RELETIVE;
                default:
                {
                    return form.Equals(Forms.First(), StringComparison.InvariantCultureIgnoreCase) ? KEY1 : KEY2;
                }
            }
        }

        public override WordType WordType
        {
            get { return _wordType; }
        }

        public QuantityType QuantityType { get; set; }

        public const string KEY1 = @"P1";
        public const string KEY2 = @"P2";
        public const string KEY_RELETIVE = @"PR";
    }
}