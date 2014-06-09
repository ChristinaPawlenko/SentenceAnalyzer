using Common.Model.Enum;

namespace Common.Model
{
    public class ModalVerb : Word
    {
        public ModalVerb(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.ModalVerb; }
        }

        public const string KEY = @"MV";
        public override string Key { get { return KEY; } }
    }
}