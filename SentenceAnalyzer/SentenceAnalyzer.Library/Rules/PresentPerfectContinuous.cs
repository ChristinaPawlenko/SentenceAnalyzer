namespace SentenceAnalyzer.Library.Rules
{
    public class PresentPerfectContinuous : BaseRule
    {
        public override string Name
        {
            get { return @"Present Perfect Continuous"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
