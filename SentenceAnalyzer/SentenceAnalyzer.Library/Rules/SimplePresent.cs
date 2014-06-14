namespace SentenceAnalyzer.Library.Rules
{
    public class SimplePresent : BaseRule
    {
        protected override string AffirmativeTemplate
        {
            get
            {
                return string.Format(@"^({1}\W)?{0}+(.*{2}.*)+\.$", SubjectTemplate, Adv, V);
            }
        }

        protected override string NegativeTemplate
        {
            get
            {
                return string.Format(@"^({3}\W)?((({0}\W)?({1}\W))|({0}\W)?({2}\W)?({4}\W({0}\W)?)*{5})+({6}\s{7})(.*{6}.*)*\.$", C, P1, A, Adv, Adj, N, V, NOT);
            }
        }

        protected override string InterrogativeTemplate
        {
            get
            {
                return string.Format(@"^({3}\W)?({6}\W)((({0}\W)?({1}\W))|({0}\W)?({2}\W)?({4}\W({0}\W)?)*{5})+({6}\W?).*\?$|^({7}\W)({6}\W).*\?$", C, P1, A, Adv, Adj, N, V, PR);
            }
        }

        public override string Name
        {
            get { return @"Present Simple"; }
        }
    }
}
