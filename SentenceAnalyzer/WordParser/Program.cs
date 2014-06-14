using Common.Model;
using Common.Model.Enum;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace WordParser
{
    class Program
    {
        private static string _dictionaryPath;
        private static string _dictionaryTxtPath;
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
                    var items = Parse(html, fileInfo.Name.Replace(fileInfo.Extension, string.Empty));
                    var newWords = items
                        .Where(x => x != null)
                        .Where(x => words.All(w => !w.Equals(x)))
                        .ToList();
                    words.AddRange(newWords);
                }
                Console.WriteLine("{0:P}:\t{1}", (i + 1) / count, fileInfo.Name);
            }

            // write to txt file
            File.WriteAllLines(_dictionaryTxtPath, words.Select(x => x.ToString()));

            // write to xml file
            var doc = new XDocument(new XElement("words"));
            foreach (var parts in words.OrderBy(x => x.Name).ThenBy(x => x.WordType).GroupBy(x => x.Name))
            {
                var wordElement = new XElement("word", new XAttribute("name", parts.Key), new XElement("parts"));
                doc.Root.Add(wordElement);
                foreach (var part in parts)
                {
                    var partElement = new XElement("part", new XAttribute("name", part.WordType), new XElement("forms"));
                    (wordElement.FirstNode as XElement).Add(partElement);
                    if (part.WordType == WordType.Verb)
                    {
                        var verb = (Verb)part;
                        foreach (var form in verb.GetForms(VerbType.Infinitive))
                            (partElement.FirstNode as XElement).Add(new XElement("form", new XAttribute("level", (int)VerbType.Infinitive), form));
                        foreach (var form in verb.GetForms(VerbType.Past))
                            (partElement.FirstNode as XElement).Add(new XElement("form", new XAttribute("level", (int)VerbType.Past), form));
                        foreach (var form in verb.GetForms(VerbType.PastParticiple))
                            (partElement.FirstNode as XElement).Add(new XElement("form", new XAttribute("level", (int)VerbType.PastParticiple), form));
                        foreach (var form in verb.GetForms(VerbType.PresentParticiple))
                            (partElement.FirstNode as XElement).Add(new XElement("form", new XAttribute("level", (int)VerbType.PresentParticiple), form));
                    }
                    else
                    {
                        foreach (var form in part.GetForms()) (partElement.FirstNode as XElement).Add(new XElement("form", form));
                    }
                }
            }
            doc.Save(_dictionaryPath);
        }

        private static void ReadArgs(string[] args)
        {
            _dictionaryPath = args[0];
            _dictionaryTxtPath = args[1];
            _wordsInfoDir = args[2];
        }

        private static IEnumerable<Word> Parse(HtmlDocument html, string wordName)
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
                Word word;
                string[] forms;
                #region switch
                switch (type)
                {
                    case "(Article)":
                        forms = ParseSimple(item, html);
                        word = new Article(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Verb)":
                    case "(Defective verb)":
                        string[] v1, v2, v3, v4;
                        var name = ParseVerb(item, html, out v1, out v2, out v3, out v4);
                        var verb = new Verb(name);
                        verb.AddForms(v1, 1);
                        verb.AddForms(v2, 2);
                        verb.AddForms(v3, 3);
                        verb.AddForms(v4, 4);
                        word = verb;
                        break;
                    case "(Modal verb)":
                        forms = ParseSimple(item, html);
                        word = new ModalVerb(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Noun)":
                    case "(Feminine noun)":
                    case "(Masculine noun)":
                        forms = ParseNoun(item, html);
                        word = new Noun(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Plural noun)":
                        forms = ParseSimple(item, html);
                        word = new Noun(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Adjective)":
                    case "(Uninflected adjective)":
                        forms = ParseSimple(item, html);
                        word = new Adjective(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Preposition)":
                        forms = ParseSimple(item, html);
                        word = new Preposition(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Adverb)":
                    case "(Uninflected adverb)":
                        forms = ParseSimple(item, html);
                        word = new Adverb(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Conjunction)":
                        forms = ParseSimple(item, html);
                        word = new Conjunction(forms[0]);
                        word.AddForms(forms);
                        break;
                    case "(Interjection)":
                        forms = ParseSimple(item, html);
                        word = new Interjection(forms[0]);
                        word.AddForm(forms[0]);
                        break;
                    case "(Pronoun)":
                    case "(Quantitative plural pronoun)":
                    case "(Uninflected interrogative pronoun)":
                    case "(Demonstrative pronoun)":
                    case "(Plural pronoun)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.Pronoun);
                        word.AddForms(forms);
                        break;
                    case "(Quantitative pronoun)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.QuantitativePronoun);
                        word.AddForms(forms);
                        break;
                    case "(Indefinite pronoun)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounIndefinite);
                        word.AddForms(forms);
                        break;
                    case "(Uninflected pronoun)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounUninflected);
                        word.AddForms(forms);
                        break;
                    case "(Relative pronoun)":
                    case "(Relative pronoun 2)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounRelative);
                        word.AddForms(forms);
                        break;
                    case "(1st person singular pronoun)":
                    case "()":  // (1st person plural pronoun )
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounPerson1);
                        word.AddForms(forms);
                        break;
                    case "(2nd person singular pronoun)":
                    case "(2nd person plural pronoun )":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounPerson2);
                        word.AddForms(forms);
                        break;
                    case "(3rd person masculine singular pronoun)":
                    case "(3rd person feminine singular pronoun )":
                    case "(3rd person plural pronoun)":
                    case "(3rd person neuter singular pronoun)":
                        forms = ParseSimple(item, html);
                        word = new Pronoun(forms[0], WordType.PronounPerson2);
                        word.AddForms(forms);
                        break;
                    default:
                        throw new NotSupportedException(string.Format("The type {0} is not defined", type));
                }
                #endregion
                words.Add(word);
            }
            return words;
        }

        private static string[] ParseSimple(HtmlNode item, HtmlDocument html)
        {
            var centerDiv = html.GetElementbyId("center");
            var childNodes = centerDiv.ChildNodes;
            var startPosition = childNodes.IndexOf(item);
            var nextBlok = childNodes.Skip(startPosition + 1).First(x => x.Name == "hr" || x.Name == "span");
            var endPosition = childNodes.IndexOf(nextBlok);
            var list = new List<string>();
            for (var i = startPosition + 1; i < endPosition; ++i)
            {
                var el = childNodes[i].InnerText.Trim('\n', '-');
                if (!string.IsNullOrWhiteSpace(el)) list.AddRange(el.Split(',').Select(x => x.Trim()));
            }
            return list.Distinct().ToArray();
        }

        private static string[] ParseNoun(HtmlNode item, HtmlDocument html)
        {
            var centerDiv = html.GetElementbyId("center");
            var childNodes = centerDiv.ChildNodes;
            var startPosition = childNodes.IndexOf(item);
            var table = childNodes.Skip(startPosition + 1).First(x => x.Name == "table");
            var list = new List<string>();
            foreach (var tr in table.ChildNodes.Where(x => x.Name == "tr"))
            {
                var el = tr.ChildNodes.LastOrDefault(x => x.Name == "td" && x.Attributes.All(y => y.Name != "colspan"));
                if (el != null)
                {
                    var text = el.InnerText.Trim('\n', '-');
                    if (!string.IsNullOrWhiteSpace(text)) list.AddRange(text.Split(',').Select(x => x.Trim()));
                }
            }
            return list.Distinct().ToArray();
        }

        private static string ParseVerb(HtmlNode item, HtmlDocument html, out string[] v1, out string[] v2, out string[] v3, out string[] v4)
        {
            var list1 = new List<string>();
            var list2 = new List<string>();
            var list3 = new List<string>();
            var list4 = new List<string>();

            var centerDiv = html.GetElementbyId("center");
            var childNodes = centerDiv.ChildNodes;
            var startPosition = childNodes.IndexOf(item);
            var table = childNodes.Skip(startPosition + 1).First(x => x.Name == "table");
            foreach (var tr in table.ChildNodes.Where(x => x.Name == "tr"))
            {
                var el1 = tr.ChildNodes.FirstOrDefault(x => x.Name == "td" && x.Attributes.All(y => y.Name != "colspan"));
                if (el1 != null)
                {
                    var el = tr.ChildNodes.LastOrDefault(x => x.Name == "td" && x.Attributes.All(y => y.Name != "colspan"));
                    List<string> list;
                    switch (el1.InnerText.Trim('\n', '-', ' '))
                    {
                        case "Past": list = list2; break;
                        case "Present Participle": list = list4; break;
                        case "Past Participle": list = list3; break;
                        default: list = list1; break;
                    }
                    var text = el.InnerText.Trim('\n', '-');
                    if (!string.IsNullOrWhiteSpace(text)) list.AddRange(text.Split(',').Select(x => x.Trim()));
                }
            }

            v1 = list1.Distinct().ToArray();
            v2 = list2.Distinct().ToArray();
            v3 = list3.Distinct().ToArray();
            v4 = list4.Distinct().ToArray();

            return list1.First();
        }
    }
}
