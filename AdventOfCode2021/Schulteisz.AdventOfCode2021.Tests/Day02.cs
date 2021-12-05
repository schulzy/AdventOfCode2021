using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day02;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day02
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            Dive sut = new Dive(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1815044, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            DiveHard sut = new DiveHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1739283308, result);
        }

        [TestMethod]
        public void Task2PreDifined()
        {
            IContentParser contentParser = new LocalContentParser();

            DiveHard sut = new DiveHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(900, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "forward 5",
                    "down 5",
                    "forward 8",
                    "up 3",
                    "down 8",
                    "forward 2"
                };
            }
        }
    }
}
