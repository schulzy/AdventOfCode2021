using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day02;
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

            Assert.Fail();
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            Assert.Fail();
        }

        [TestMethod]
        public void Task1PreDifined()
        {
            IContentParser contentParser = new LocalContentParser();

            Assert.Fail();
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
