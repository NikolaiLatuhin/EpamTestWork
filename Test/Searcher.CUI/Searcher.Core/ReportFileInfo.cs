using System;

namespace Searcher.Core
{
    public class ReportFileInfo
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public int Size { get; set; }

        public DateTime EditDateTime { get; set; }

        public string ContainingString { get; set; }

        public int NumberOccurrences { get; set; }

    }
}
