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

        public override WordType WordType
        {
            get { return _wordType; }
        }

        public QuantityType QuantityType { get; set; }

        public const string KEY = @"P";
        public const string KEY_RELETIVE = @"PR";
        public override string Key
        {
            get
            {
                switch (_wordType)
                {
                    case Enum.WordType.PronounRelative: return KEY_RELETIVE;
                    default : return KEY;
                }
            }
        }
    }
}