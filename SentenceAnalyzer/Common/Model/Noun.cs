using Common.Model.Enum;

namespace Common.Model
{
    public class Noun : Word
    {
        public Noun(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Noun; }
        }

        public const string KEY = @"N";
    }
}