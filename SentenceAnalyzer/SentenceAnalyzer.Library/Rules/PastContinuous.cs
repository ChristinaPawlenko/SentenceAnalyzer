namespace SentenceAnalyzer.Library.Rules
{
    public class PastContinuous : BaseRule
    {
        public override string Name
        {
            get { return @"Past Continuous"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
