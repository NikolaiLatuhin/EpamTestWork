using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Searcher.Core
{
    public class SerializationHelper
    {
        public static void ReportFileInfoToXml(string path, ReportFileInfo report)
        {
            var uniquePath = GetFilePathWithoutCollision(path);

            var formatter = new XmlSerializer(typeof(ReportFileInfo));

            using (var fs = new FileStream(uniquePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, report);
            }
        }

        public static string GetFilePathWithoutCollision(string filePath)
        {
            if (!File.Exists(filePath)) return filePath;
            var folderPath = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var fileExtension = Path.GetExtension(filePath);
            var number = 1;

            var regex = Regex.Match(fileName, @"^(.+) \((\d+)\)$");

            if (regex.Success)
            {
                fileName = regex.Groups[1].Value;
                number = int.Parse(regex.Groups[2].Value);
            }

            do
            {
                number++;
                var newFileName = $"{fileName} ({number}){fileExtension}";
                filePath = Path.Combine(folderPath, newFileName);
            }
            while (File.Exists(filePath));

            return filePath;
        }
    }
}
