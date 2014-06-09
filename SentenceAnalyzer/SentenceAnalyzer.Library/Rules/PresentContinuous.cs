namespace SentenceAnalyzer.Library.Rules
{
    public class PresentContinuous : BaseRule
    {
        public override string Name
        {
            get { return @"Present Continuous"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
