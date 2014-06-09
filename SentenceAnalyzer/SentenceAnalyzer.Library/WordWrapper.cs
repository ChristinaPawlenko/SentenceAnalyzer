using Common.Model;

namespace SentenceAnalyzer.Library
{
    public class WordWrapper
    {
        public readonly Word Word;
        public readonly string ActiveForm;

        public WordWrapper(Word word, string activeForm)
        {
            Word = word;
            ActiveForm = activeForm;
        }

        public override string ToString()
        {
            return Word.ToString() + " active form: " + ActiveForm;
        }
    }
}
