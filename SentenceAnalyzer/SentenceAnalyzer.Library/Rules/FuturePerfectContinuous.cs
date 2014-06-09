namespace SentenceAnalyzer.Library.Rules
{
    public class FuturePerfectContinuous : BaseRule
    {
        public override string Name
        {
            get { return @"Future Perfect Continuous"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
