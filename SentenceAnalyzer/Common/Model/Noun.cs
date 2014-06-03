using Common.Model.Enum;

namespace Common.Model
{
    public class Noun : Word
    {
        public Noun(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Noun; }
        }
    }
}