using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Searcher.Core
{
    public static class SearcherFiles
    {
        public static IEnumerable<string> FindFilesContainSubstring(string folderPath,string substring, out List<ReportFileInfo> reports)
        {
            var listWithSubstring = new List<string>();
            var listReportFileInfo = new List<ReportFileInfo>();


            foreach (var file in Directory.EnumerateFiles(folderPath, "*.txt"))
            {
                var contents = File.ReadAllText(file);
                var sentencesWithSubstring = contents.ExctractSubstrings(substring);
                var fileName = Path.GetFileName(file);

                if (sentencesWithSubstring.IsNullOrEmpty()) continue;
                listWithSubstring.Add(fileName);
                var location = Path.GetFullPath(fileName);
                var size = new FileInfo(fileName).Length;
                var editDateTime = File.GetLastWriteTime(fileName);
                var numberOccurrences = sentencesWithSubstring.Count();

                var report = new ReportFileInfo
                {
                    Name = fileName, Location = location, Size = size,
                    EditDateTime = editDateTime, NumberOccurrences = numberOccurrences,
                    ContainingString = sentencesWithSubstring
                };

                listReportFileInfo.Add(report);
            }

            var sortedReports = SortDescendingReports(listReportFileInfo);

            reports = sortedReports.ToList();

            return listWithSubstring;

        }

        private static IEnumerable<ReportFileInfo> SortDescendingReports(IEnumerable<ReportFileInfo> listReportFileInfo)
        {
            var sortedReports = from r in listReportFileInfo
                orderby r.NumberOccurrences descending
                select r;
            return sortedReports;
        }
    }
}
