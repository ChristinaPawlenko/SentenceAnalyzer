using Common.Model;
using System;

namespace SentenceAnalyzer.Library.Rules
{
    public class SimplePresent : BaseRule
    {
        protected override string AffirmativeTemplate
        {
            get
            {
                return string.Format(@"^({3}\W)?((({0}\W)?({1}\W))|({0}\W)?({2}\W)?({4}\W({0}\W)?)*{5})+(.*{6}.*)+\.$", 
                    C, P, A, Adv, Adj, N, V);
            }
        }

        protected override string NegativeTemplate
        {
            get { return "not_supported"; }
        }

        protected override string InterrogativeTemplate
        {
            get { return "not_supported"; }
        }

        public override string Name
        {
            get { return @"Present Simple"; }
        }
    }
}
