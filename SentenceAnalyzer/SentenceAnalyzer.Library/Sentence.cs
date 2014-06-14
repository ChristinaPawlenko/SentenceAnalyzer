using System;
using Common.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using SentenceAnalyzer.Library.Rules.Enums;
using SentenceAnalyzer.Library.Rules;

namespace SentenceAnalyzer.Library
{
    public class Sentence
    {
        protected static string[] _stopWords = new[] { "not", "to" };

        private List<WordWrapper[]> _parts = new List<WordWrapper[]>();
        private List<KeyValuePair<string,string>> _pairs = new List<KeyValuePair<string,string>>();
        
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
            _pairs.Clear();
            var sb = new StringBuilder(Text);
            foreach (var part in _parts)
            {
                if (!part.Any()) continue;
                var text = part.First().ActiveForm;

                var block = _stopWords.Any(x => x.Equals(text))
                    ? text
                    : string.Format("{{{0}}}", string.Join("|", part.Select(x => x.Key)).Trim('|'));
                
                var startIndex = sb.ToString().IndexOf(text, StringComparison.Ordinal);
                sb.Replace(text, block, startIndex, text.Length);
                _pairs.Add(new KeyValuePair<string, string>(block, text));
            }

            return sb.ToString();
        }

        internal string TransformBack(string transformedSentence) 
        {
            var sb = new StringBuilder(transformedSentence);
            foreach (var pair in _pairs)
            {
                var startIndex = sb.ToString().IndexOf(pair.Key, StringComparison.Ordinal);
                sb.Replace(pair.Key, pair.Value, startIndex, pair.Key.Length);
            }
            return sb.ToString(); 
        }

        public int WordsCount { get { return _parts.Count; } }
        public WordWrapper[] this[int pos] { get { return _parts[pos]; } }

        public override string ToString()
        {
            return Text;
        }
    }
}
