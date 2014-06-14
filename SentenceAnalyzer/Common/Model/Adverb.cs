using Common.Model.Enum;

namespace Common.Model
{
    public class Adverb : Word
    {
        public Adverb(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Adverb; }
        }

        public const string KEY = @"Adv";
    }
}