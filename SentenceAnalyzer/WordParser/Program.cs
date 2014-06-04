using Common.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordParser
{
    class Program
    {
        private static string _dictionaryPath;
        private static string _wordsInfoDir;

        static void Main(string[] args)
        {
            ReadArgs(args);

            var words = new List<Word>();

            var files = Directory.GetFiles(_wordsInfoDir);
            var count = (double)files.Length;
            for (var i = 0; i < files.Length; ++i)
            {
                var fileInfo = new FileInfo(files[i]);
                var html = new HtmlDocument();
                using (var reader = fileInfo.OpenText())
                {
                    html.LoadHtml(reader.ReadToEnd());
                    words.AddRange(Parse(html));
                }

                Console.WriteLine("{0:P}:\t{1}", (i + 1) / count, fileInfo.Name);
            }
        }

        private static void ReadArgs(string[] args)
        {
            _dictionaryPath = args[0];
            _wordsInfoDir = args[1];
        }

        private static List<Word> Parse(HtmlDocument html)
        {
            var centerDiv = html.GetElementbyId("center");
            var nodes = centerDiv.ChildNodes
                .Where(x => x.Name == "span")
                .Where(x => x.Attributes.Any(a => a.Name == "style" && a.Value == "color:black;background-color:#FFCCCC"))
                .ToList();

            var words = new List<Word>();

            foreach (var item in nodes)
            {
                // item can be:

                //()   todo: make stub for (we,our,us) 

                //(Article)
                //(Verb)
                //(Noun)
                //(Adjective)
                //(Preposition)
                //(Uninflected adverb)
                //(Uninflected adjective)
                //(Conjunction)
                //(Interjection)
                //(Feminine noun)
                //(Quantitative pronoun)
                //(Pronoun)
                //(Indefinite pronoun)
                //(Uninflected pronoun)
                //(Masculine noun)
                //(Adverb)
                //(Defective verb)
                //(Quantitative plural pronoun)
                //(Plural noun)
                //(Modal verb)
                //(1st person singular pronoun)
                //(2nd person singular pronoun)
                //(3rd person masculine singular pronoun)
                //(3rd person feminine singular pronoun )
                //(3rd person neuter singular pronoun)
                //(2nd person plural pronoun )
                //(3rd person plural pronoun)
                //(Plural pronoun)
                //(Demonstrative pronoun)
                //(Relative pronoun)
                //(Relative pronoun 2)
                //(Uninflected interrogative pronoun)
            }

            return words;
        }
    }
}
