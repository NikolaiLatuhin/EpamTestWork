using System;
using System.Collections.Generic;

namespace Searcher.Core
{

    public class ReportFileInfo
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public long Size { get; set; }

        public DateTime EditDateTime { get; set; }

        public IEnumerable<string> ContainingString { get; set; }

        public int NumberOccurrences { get; set; }

    }
}
