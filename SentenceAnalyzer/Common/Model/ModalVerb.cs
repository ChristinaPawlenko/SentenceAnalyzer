using Common.Model.Enum;

namespace Common.Model
{
    public class ModalVerb : Word
    {
        public ModalVerb(string text) : base(text)
        { }

        public override string Key(string form)
        {
            return KEY;
        }

        public override WordType WordType
        {
            get { return WordType.ModalVerb; }
        }

        public const string KEY = @"MV";
    }
}