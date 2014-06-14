using Common.Model.Enum;

namespace Common.Model
{
    public class Numeral : Word
    {
        public Numeral(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Numeral; }
        }

        public const string KEY = @"Num";
    }
}