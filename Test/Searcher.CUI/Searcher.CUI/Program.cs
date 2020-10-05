using System;
using Searcher.Core;

namespace Searcher.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"C:\TestWork\EpamTestWork\Test\Searcher.CUI\Searcher.CUI\bin\Debug";

            var collection = SearcherFiles.FindFilesContainSubstring(path, "island");

            Console.WriteLine("Done");
        }
    }
}
