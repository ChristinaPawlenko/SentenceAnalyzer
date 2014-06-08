namespace SentenceAnalyzer.Library.Rules
{
    public abstract class BaseRule
    {
        public abstract bool Verify(Sentence sentence);
    }
}
