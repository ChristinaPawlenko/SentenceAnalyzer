using Common.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    var items = Parse(html);
                    words.AddRange(items.Where(x => x != null).ToList());
                }

                Console.WriteLine("{0:P}:\t{1}", (i + 1) / count, fileInfo.Name);
            }
        }

        private static void ReadArgs(string[] args)
        {
            _dictionaryPath = args[0];
            _wordsInfoDir = args[1];
        }

        private static IEnumerable<Word> Parse(HtmlDocument html)
        {
            var centerDiv = html.GetElementbyId("center");
            var nodes = centerDiv.ChildNodes
                .Where(x => x.Name == "span")
                .Where(x => x.Attributes.Any(a => a.Name == "style" && a.Value == "color:black;background-color:#FFCCCC"))
                .ToList();

            var words = new List<Word>();

            foreach (var item in nodes)
            {
                var type = item.InnerText;
                switch (type)
                {
                    case "(Article)":
                        words.Add(ParseArticle(item, html));
                        break;
                    case "(Verb)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Noun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Adjective)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Preposition)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Uninflected adverb)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Uninflected adjective)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Conjunction)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Interjection)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Feminine noun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Quantitative pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Indefinite pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Uninflected pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Masculine noun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Adverb)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Defective verb)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Quantitative plural pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Plural noun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Modal verb)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(1st person singular pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(2nd person singular pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(3rd person masculine singular pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(3rd person feminine singular pronoun )":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(3rd person neuter singular pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(2nd person plural pronoun )":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(3rd person plural pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Plural pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Demonstrative pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Relative pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Relative pronoun 2)":
                        words.Add(ParseXXXX(item, html));
                        break;
                    case "(Uninflected interrogative pronoun)":
                        words.Add(ParseXXXX(item, html));
                        break;
                }


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

        private static Word ParseXXXX(HtmlNode item, HtmlDocument html)
        {
            //Console.WriteLine("-> {0}", item.InnerText);
            return null;
        }

        private static Word ParseArticle(HtmlNode item, HtmlDocument html)
        {
            var centerDiv = html.GetElementbyId("center");
            var childNodes = centerDiv.ChildNodes;
            var pos = childNodes.IndexOf(item);
            var element = childNodes[pos + 2];
            var name = element.InnerText.Replace("(", "").Replace(")", "").Replace("\n", "");
            var word = new Article(name);
            word.AddForm(name);

            return word;
        }
    }
}
