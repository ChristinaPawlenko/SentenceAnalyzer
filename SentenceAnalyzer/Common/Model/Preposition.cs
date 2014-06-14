using Common.Model.Enum;

namespace Common.Model
{
    public class Preposition : Word
    {
        public Preposition(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.Preposition; }
        }

        public const string KEY = @"Pr";
    }
}