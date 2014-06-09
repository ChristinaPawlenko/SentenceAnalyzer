using System;

namespace SentenceAnalyzer.Library.Rules
{
    public class SimplePresent : BaseRule
    {
        public override string Name
        {
            get { return @"Present Simple"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new NotImplementedException();
        }
    }
}
