namespace SentenceAnalyzer.Library.Rules
{
    public class SimplePast : BaseRule
    {
        public override string Name
        {
            get { return @"Simple Past"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
