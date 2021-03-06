﻿using System;
using System.IO;
using System.Xml.Serialization;
using Searcher.Core;

namespace Searcher.CUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            Console.WriteLine("Введите подстроку");
            var substring = Console.ReadLine(); // Пример island

            var collectionWithFilesContainSubstring = SearcherFiles.FindFilesContainSubstring(path, substring, out var reports);

            Console.WriteLine("Done");

            foreach (var fileName in collectionWithFilesContainSubstring)
            {
                Console.WriteLine($"Файл {fileName} содержит подстроку");
            }

            foreach (var report in reports)
            {
                ReportFileInfoToXml(report);
            }

        }

        private static void ReportFileInfoToXml(ReportFileInfo report)
        {
            var formatter = new XmlSerializer(typeof(ReportFileInfo));

            using (var fs = new FileStream("report.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, report);
            }
        }

        private static ReportFileInfo XmlToReportFileInfo(string path)
        {
            using (var fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
            {
                var formatter = new XmlSerializer(typeof(ReportFileInfo));
                var report = (ReportFileInfo)formatter.Deserialize(fs);
                return report;
            }
        }
    }
}
