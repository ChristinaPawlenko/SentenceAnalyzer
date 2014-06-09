using System;
namespace SentenceAnalyzer.Library.Rules
{
    public abstract class BaseRule
    {
        public abstract string Name { get; } 
        public abstract bool Verify(Sentence sentence);
        public SentenceInfo Explain()
        {
            throw new NotSupportedException();
        }
    }
}