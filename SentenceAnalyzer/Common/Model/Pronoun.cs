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
    }
}