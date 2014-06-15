using System;
using Common.Model;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Linq;
using Common.Model.Enum;

namespace SentenceAnalyzer.Library
{
    public class WordCollection : ReadOnlyCollection<Word>
    {
        protected WordCollection(IList<Word> words)
            : base(words)
        { }

        public WordCollection() : this(new List<Word>())
        { }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <param name="filePath">Path for XML file</param>
        public void Load(string filePath)
        {
            Load(XDocument.Load(filePath));
        }

        /// <summary>
        /// Load data from TextReader
        /// </summary>
        /// <param name="textReader">TextReader for XML file</param>
        public void Load(TextReader textReader)
        {
            Load(XDocument.Load(textReader));
        }

        /// <summary>
        /// Load data from XDocument
        /// </summary>
        /// <param name="xml">XDocument with words declaration</param>
        public void Load(XDocument xml)
        {
            foreach (var wordElement in xml.Descendants("word"))
            {
                var name = wordElement.Attribute("name").Value;
                foreach (var partElement in wordElement.Descendants("part"))
                {
                    var wordType = (WordType)Enum.Parse(typeof(WordType), partElement.Attribute("name").Value, true);
                    var word = Word.Create(wordType, name);
                    if (wordType == WordType.Verb)
                    {
                        var verb = (Verb)word;
                        verb.AddForms(partElement.Descendants("form").Where(x=>x.Attribute("level").Value == ((int)VerbType.Infinitive).ToString()).Select(x => x.Value), VerbType.Infinitive);
                        verb.AddForms(partElement.Descendants("form").Where(x=>x.Attribute("level").Value == ((int)VerbType.Past).ToString()).Select(x => x.Value), VerbType.Past);
                        verb.AddForms(partElement.Descendants("form").Where(x=>x.Attribute("level").Value == ((int)VerbType.PastParticiple).ToString()).Select(x => x.Value), VerbType.PastParticiple);
                        verb.AddForms(partElement.Descendants("form").Where(x=>x.Attribute("level").Value == ((int)VerbType.PresentParticiple).ToString()).Select(x => x.Value), VerbType.PresentParticiple);
                    }
                    else
                    {
                        word.AddForms(partElement.Descendants("form").Select(x => x.Value));
                    }
                    Items.Add(word);
                }
            }
        }

        public Word[] Find(string wordName, bool ignoreCase = true)
        {
            return Items.Where(x => x.MatchTo(wordName, ignoreCase)).ToArray();
        }
    }
}
