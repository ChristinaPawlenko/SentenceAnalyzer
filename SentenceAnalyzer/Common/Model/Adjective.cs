using Common.Model.Enum;

namespace Common.Model
{
    public class Adjective : Word
    {
        public Adjective(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Adjective; }
        }

        public const string KEY = @"Adj";
    }
}