using Common.Model.Enum;

namespace Common.Model
{
    public class Conjunction : Word
    {
        public Conjunction(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Conjunction; }
        }
    }
}