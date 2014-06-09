namespace SentenceAnalyzer.Library.Rules
{
    public class FuturePerfect : BaseRule
    {
        public override string Name
        {
            get { return @"Future Perfect"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
