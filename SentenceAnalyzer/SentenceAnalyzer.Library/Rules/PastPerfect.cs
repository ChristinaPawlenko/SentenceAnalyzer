namespace SentenceAnalyzer.Library.Rules
{
    public class PastPerfect : BaseRule
    {
        public override string Name
        {
            get { return @"Past Perfect"; }
        }

        public override bool Verify(Sentence sentence)
        {
            throw new System.NotImplementedException();
        }
    }
}
