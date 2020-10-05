using System;
using System.Collections.Generic;

namespace Searcher.Core
{
    [Serializable]
    public class ReportFileInfo
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public long Size { get; set; }

        public DateTime EditDateTime { get; set; }

        public List<string> ContainingString { get; set; }

        public int NumberOccurrences { get; set; }

        public ReportFileInfo() {}
    }
}
