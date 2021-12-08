using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day05;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day05
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            HydrothermalVenture sut = new HydrothermalVenture(contentParser);
            long result = sut.Run();
            Assert.AreEqual(4826, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            HydrothermalVentureHard sut = new HydrothermalVentureHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(16793, result);
        }

        [TestMethod]
        public void Task1PreDifined()
        {
            IContentParser contentParser = new LocalContentParser();

            HydrothermalVenture sut = new HydrothermalVenture(contentParser);
            long result = sut.Run();
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Task2PreDifined()
        {
            IContentParser contentParser = new LocalContentParser();

            HydrothermalVentureHard sut = new HydrothermalVentureHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(12, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "0,9 -> 5,9",
"8,0 -> 0,8",
"9,4 -> 3,4",
"2,2 -> 2,1",
"7,0 -> 7,4",
"6,4 -> 2,0",
"0,9 -> 2,9",
"3,4 -> 1,4",
"0,0 -> 8,8",
"5,5 -> 8,2"
                };
            }
        }
    }
}
