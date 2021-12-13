using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day09;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day09
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            SmokeBasin sut = new SmokeBasin(contentParser);
            long result = sut.Run();
            Assert.AreEqual(478, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            SmokeBasinHard sut = new SmokeBasinHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1327014, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SmokeBasin sut = new SmokeBasin(contentParser);
            long result = sut.Run();
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SmokeBasinHard sut = new SmokeBasinHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1134, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "2199943210",
"3987894921",
"9856789892",
"8767896789",
"9899965678"
                };
            }
        }
    }
}
