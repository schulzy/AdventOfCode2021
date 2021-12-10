using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day06;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day06
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            Lanternfish sut = new Lanternfish(contentParser);
            long result = sut.Run();
            Assert.AreEqual(346063, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            LanternfishHard sut = new LanternfishHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1572358335990, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            Lanternfish sut = new Lanternfish(contentParser);
            long result = sut.Run();
            Assert.AreEqual(5934, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            LanternfishHard sut = new LanternfishHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(26984457539, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "3,4,3,1,2"
                };
            }
        }
    }
}
