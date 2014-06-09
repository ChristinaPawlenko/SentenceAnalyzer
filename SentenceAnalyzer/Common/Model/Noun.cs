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

        public const string KEY = @"N";
        public override string Key { get { return KEY; } }
    }
}