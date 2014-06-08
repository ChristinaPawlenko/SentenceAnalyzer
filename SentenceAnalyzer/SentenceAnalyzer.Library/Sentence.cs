using System;
using Common.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace SentenceAnalyzer.Library
{
    public class Sentence
    {
        private List<Word[]> _parts = new List<Word[]>();
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
                _parts.Add(wordSpecification.Find(word));
            }
        }

        public SentenceInfo Analyze()
        {
            throw new NotSupportedException();
        }

        public int WordsCount { get { return _parts.Count; } }
        public Word[] this[int pos] { get { return _parts[pos]; } }
    }
}
