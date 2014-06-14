namespace SentenceAnalyzer.Library
{
    public class SentenceInfo
    {
        /// <summary>
        /// Present/Past/Future, Simple/Continuous/Perfect/Perfect Continuous
        /// </summary>
        public string Tense { get; internal set; }

        /// <summary>
        /// Affirmative/Negative/Interrogative
        /// </summary>
        public string Direction { get; internal set; }

        /// <summary>
        /// All chunks of subject in a sentence
        /// </summary>
        public Chunk Subject { get; internal set; }

        /// <summary>
        /// All chunks of predicate in a sentence
        /// </summary>
        public Chunk[] Predicate { get; internal set; }
    }
}
