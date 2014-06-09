namespace SentenceAnalyzer.Library.Rules
{
    public class SimpleFuture : BaseRule
    {
        public override string Name
        {
            get { return @"Simple Future"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
