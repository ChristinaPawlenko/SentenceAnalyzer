using Common.Model.Enum;

namespace Common.Model
{
    public class Article : Word
    {
        public Article(string text) : base(text)
        { }

        public override WordType WordType
        {
            get { return WordType.Article; }
        }
    }
}