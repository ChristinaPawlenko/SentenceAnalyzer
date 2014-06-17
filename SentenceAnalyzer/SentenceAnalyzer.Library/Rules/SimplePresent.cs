namespace SentenceAnalyzer.Library.Rules
{
    public class SimplePresent : BaseRule
    {
        protected override string AffirmativeMask { get { return "$1{0}$5{1}$27{2}$31{3}$52"; } }
        // todo: change
        protected override string NegativeMask { get { return "$1{0}$4{1}{2}$18{3}{2}$21{3}$24{2}$25$28$31{3}$34"; } }
        protected override string InterrogativeMask { get { return "$3{2}$9{3}{0}$22{1}$45{2}$49{3}$59"; } }

        protected override string AffirmativeTemplate
        {
            get { return string.Format(@"(^({1}\W)?)({0}+)({1}\W)?((({2}\W?)|(({3}\W?)(to {3}\W?)?({4}\W?)?)|(({5}\W)({3}\W?)))(.*((\.)|(!))$))", SubjectTemplate, Adv, B, V1, V4, Mv); }
        }

        protected override string NegativeTemplate
        {
            get { return string.Format(@"^({1}\W)?({0}+)({3}\W)?({5}\W)?(not )({3}\W?)(to {3}\W?)?({4}\W?)?(.*((\.)|(!))$)", string.Format(@"(({1}\W+)?({3}\W+)?({2}\W+)?({5}\W+)?)", C, P1, A, P2, Adj, N), Adv, B, V1, V4, Mv); }
        }

        protected override string InterrogativeTemplate
        {
            get { return string.Format(@"(^(({1}\W)|({6}\W))?((({3}\W)?)|(({2}\W)?)|(({5}\W)?))({0}+)(({1}\W)?((({3}\W?)(to {3}\W?)?({4}\W?)?))(.*\?$)))", SubjectTemplate, Adv, B, V1, V4, Mv, C); }
        }

        public override string Name { get { return @"Present Simple"; } }
    }
}
