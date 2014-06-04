using System;
using System.IO;
using System.Linq;

namespace WordInfoLoader
{
    class Program
    {
        private static string _wordsPath;
        private static string _outputDir;
        private static string _url;
        private static string _urlReferer;

        static void Main(string[] args)
        {
            ReadArgs(args);

            var words = File.ReadAllLines(_wordsPath).Select(x => x.Trim()).ToList();
            for (var i = 0; i < words.Count(); i++)
            {
                var word = words[i];
                var responseText = HttpLoader.LoadData(_url, _urlReferer, word);
                File.AppendAllText(Path.Combine(_outputDir, word + ".html"), responseText);
            }
        }

        private static void ReadArgs(string[] args)
        {
            _wordsPath = args[0];
            _outputDir = args[1];
            _url = args[2];
            _urlReferer = args[3];
        }
    }
}
