using System;
namespace SentenceAnalyzer.Library.Rules
{
    public class FutureContinuous : BaseRule
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

        protected override string AffirmativeMask
        {
            get { throw new NotImplementedException(); }
        }

        protected override string NegativeMask
        {
            get { throw new NotImplementedException(); }
        }

        protected override string InterrogativeMask
        {
            get { throw new NotImplementedException(); }
        }

        public override string Name
        {
            get { return @"Future Continuous"; }
        }
    }
}
