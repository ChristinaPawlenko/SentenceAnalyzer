using System;
namespace SentenceAnalyzer.Library.Rules
{
    public class FuturePerfectContinuous : BaseRule
    {
        protected override string AffirmativeTemplate
        {
            get { return "not_supported"; }
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
            get { return @"Future Perfect Continuous"; }
        }
    }
}
