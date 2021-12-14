using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day11;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day11
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            DumboOctopus sut = new DumboOctopus(contentParser);
            long result = sut.Run();
            Assert.AreEqual(369105, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            DumboOctopusHard sut = new DumboOctopusHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(3999363569, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            DumboOctopus sut = new DumboOctopus(contentParser);
            long result = sut.Run();
            Assert.AreEqual(26397, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            DumboOctopusHard sut = new DumboOctopusHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(288957, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "5483143223",
"2745854711",
"5264556173",
"6141336146",
"6357385478",
"4167524645",
"2176841721",
"6882881134",
"4846848554",
"5283751526"
                };
            }
        }
    }
}
