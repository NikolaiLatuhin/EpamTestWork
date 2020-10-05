using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Searcher.Core.Tests
{
    [TestClass]
    public class SearcherTests
    {
        string path = Directory.GetCurrentDirectory();
        [TestMethod]
        public void Should_ReturnFileNameContainSubstring_WhenInputRightFile()
        {
            var collection = SearcherFiles.FindFilesContainSubstring(path, "island", out var reports);
            var expected = "testTwo.txt";

            // act
            var actual = collection.ElementAt(1);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Should_ReturnStringContainSubstring_WhenInputRightFile()
        {
            var collection = SearcherFiles.FindFilesContainSubstring(path, "island", out var reports);
            var expected = "\r\nand go back to the time when my father kept the Admiral Benbow inn island";
            var s = reports[1].ContainingString;

            // act
            var actual = reports[1].ContainingString[1];

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
