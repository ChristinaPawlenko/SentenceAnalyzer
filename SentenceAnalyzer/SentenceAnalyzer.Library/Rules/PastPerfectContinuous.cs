namespace SentenceAnalyzer.Library.Rules
{
    public class PastPerfectContinuous : BaseRule
    {
        public override string Name
        {
            get { return @"Past Perfect Continuous"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
