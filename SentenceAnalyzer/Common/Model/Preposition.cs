using Common.Model.Enum;

namespace Common.Model
{
    public class Preposition : Word
    {
        public Preposition(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Preposition; }
        }

        public const string KEY = @"Pr";
        public override string Key { get { return KEY; } }
    }
}