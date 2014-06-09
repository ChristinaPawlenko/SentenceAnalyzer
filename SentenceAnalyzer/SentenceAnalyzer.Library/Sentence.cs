using System;
using Common.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace SentenceAnalyzer.Library
{
    public class Sentence
    {
        private List<WordWrapper[]> _parts = new List<WordWrapper[]>();
        public readonly string Text;

        public Sentence(string text)
        {
            Text = text;
        }

        public void SplitByWords(WordCollection wordSpecification)
        {
            // split string by words
            var punctuation = Text.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = Text.Split().Select(x => x.Trim(punctuation)).ToList();

            // find appropriate word specification
            foreach (var word in words)
            {
                var appropriateWords = wordSpecification.Find(word);
                _parts.Add(appropriateWords.Select(x => new WordWrapper(x, word)).ToArray());
            }
        }

        internal string Transform()
        {
            var sb = new StringBuilder(Text);
            foreach (var part in _parts)
            {
                if (!part.Any()) continue;
                var text = part.First().ActiveForm;
                var block = string.Format("{{{0}}}", string.Join("|", part.Select(x => x.Word.Key)).Trim('|'));
                var startIndex = sb.ToString().IndexOf(text);
                sb.Replace(text, block, startIndex, text.Length);
            }

            return sb.ToString();
        }

        public SentenceInfo Analyze()
        {
            throw new NotSupportedException();
        }

        public int WordsCount { get { return _parts.Count; } }
        public WordWrapper[] this[int pos] { get { return _parts[pos]; } }
    }
}
