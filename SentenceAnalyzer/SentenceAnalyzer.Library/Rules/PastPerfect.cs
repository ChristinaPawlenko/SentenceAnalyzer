﻿using System;
namespace SentenceAnalyzer.Library.Rules
{
    public class PastPerfect : BaseRule
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
            get { return @"Past Perfect"; }
        }
    }
}
