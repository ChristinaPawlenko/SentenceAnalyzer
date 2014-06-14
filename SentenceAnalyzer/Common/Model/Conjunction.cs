using Common.Model.Enum;

namespace Common.Model
{
    public class Conjunction : Word
    {
        public Conjunction(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Conjunction; }
        }

        public const string KEY = @"C";
    }
}