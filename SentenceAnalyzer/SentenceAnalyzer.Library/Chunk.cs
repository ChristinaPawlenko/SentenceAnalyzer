namespace SentenceAnalyzer.Library
{
    public class Chunk
    {
        public readonly int StartPosition;
        public readonly int EndPosition;
        public readonly string Substring;

        public Chunk(int startPosition, int endPosition, string substring)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            Substring = substring;
        }

        public int Length { get { return EndPosition - StartPosition; } }

        public override string ToString()
        {
            return Substring;
        }
    }
}
