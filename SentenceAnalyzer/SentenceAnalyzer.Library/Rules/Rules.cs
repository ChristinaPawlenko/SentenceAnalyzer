using System;
namespace SentenceAnalyzer.Library.Rules
{
    public static class Rules
    {
        public static readonly SimplePresent SimplePresent = new SimplePresent();
        public static readonly PresentContinuous PresentContinuous = new PresentContinuous();
        public static readonly PresentPerfect PresentPerfect = new PresentPerfect();
        public static readonly PresentPerfectContinuous PresentPerfectContinuous = new PresentPerfectContinuous();
        public static readonly SimplePast SimplePast = new SimplePast();
        public static readonly PastContinuous PastContinuous = new PastContinuous();
        public static readonly PastPerfect PastPerfect = new PastPerfect();
        public static readonly PastPerfectContinuous PastPerfectContinuous = new PastPerfectContinuous();
        public static readonly SimpleFuture SimpleFuture = new SimpleFuture();
        public static readonly FutureContinuous FutureContinuous = new FutureContinuous();
        public static readonly FuturePerfect FuturePerfect = new FuturePerfect();
        public static readonly FuturePerfectContinuous FuturePerfectContinuous = new FuturePerfectContinuous();

        public static BaseRule FindRule(Sentence sentence)
        {
            if (SimplePresent.Verify(sentence)) return SimplePresent;
            if (PresentContinuous.Verify(sentence)) return PresentContinuous;
            if (PresentPerfect.Verify(sentence)) return PresentPerfect;
            if (PresentPerfectContinuous.Verify(sentence)) return PresentPerfectContinuous;
            if (SimplePast.Verify(sentence)) return SimplePast;
            if (PastContinuous.Verify(sentence)) return PastContinuous;
            if (PastPerfect.Verify(sentence)) return PastPerfect;
            if (PastPerfectContinuous.Verify(sentence)) return PastPerfectContinuous;
            if (SimpleFuture.Verify(sentence)) return SimpleFuture;
            if (FutureContinuous.Verify(sentence)) return FutureContinuous;
            if (FuturePerfect.Verify(sentence)) return FuturePerfect;
            if (FuturePerfectContinuous.Verify(sentence)) return FuturePerfectContinuous;

            throw new ArgumentException("There are no any suitable rules");
        }
    }
}
