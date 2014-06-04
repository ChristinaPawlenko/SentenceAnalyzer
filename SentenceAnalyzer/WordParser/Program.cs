using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordParser
{
    class Program
    {
        private static string _dictionaryPath;
        private static string _outputDir;

        static void Main(string[] args)
        {
            ReadArgs(args);


        }

        private static void ReadArgs(string[] args)
        {
            _dictionaryPath = args[0];
            _outputDir = args[1];
        }
    }
}
