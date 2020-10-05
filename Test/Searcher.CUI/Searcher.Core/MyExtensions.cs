using System.Collections.Generic;
using System.Linq;

namespace Searcher.Core
{
    public static class MyExtensions
    {
        public static IEnumerable<string> ExctractSubstrings(this string inputString, string subString)
        {
            var sentences = inputString.Split('.', '!' , ',' , '?');
            var substringSentences = sentences.Where(s => s.Contains(subString));
            return substringSentences;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null) return true;
            return !source.Any();
        }
    }
}
