using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Searcher.Core
{
    public static class SearcherFiles
    {
        public static IEnumerable<string> FindFilesContainSubstring(string folderPath,string substring)
        {
            return (from file in Directory.EnumerateFiles(folderPath, "*.txt") 
                let contents = File.ReadAllText(file) 
                let sentencesWithSubstring = contents.ExctractSubstrings(substring) 
                let fileName = Path.GetFileName(file) 
                where !sentencesWithSubstring.IsNullOrEmpty() select fileName)
                .ToList();
        }
    }
}
