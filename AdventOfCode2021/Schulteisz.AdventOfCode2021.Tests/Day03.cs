using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day03;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day03
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            BinaryDiagnostic sut = new BinaryDiagnostic(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2648450, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            BinaryDiagnosticHard sut = new BinaryDiagnosticHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2845944, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            BinaryDiagnosticHard sut = new BinaryDiagnosticHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(230, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "00100",
                    "11110",
                    "10110",
                    "10111",
                    "10101",
                    "01111",
                    "00111",
                    "11100",
                    "10000",
                    "11001",
                    "00010",
                    "01010"
                };
            }
        }
    }
}
