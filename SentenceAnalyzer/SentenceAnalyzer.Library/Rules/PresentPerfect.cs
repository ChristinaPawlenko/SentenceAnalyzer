namespace SentenceAnalyzer.Library.Rules
{
    public class PresentPerfect : BaseRule
    {
        public override string Name
        {
            get { return @"Present Perfect"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
