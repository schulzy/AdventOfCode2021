using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day14;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day14
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            ExtendedPolymerization sut = new ExtendedPolymerization(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2321, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            ExtendedPolymerizationHard sut = new ExtendedPolymerizationHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2399822193707, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            ExtendedPolymerization sut = new ExtendedPolymerization(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1588, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            ExtendedPolymerizationHard sut = new ExtendedPolymerizationHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2188189693529, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "NNCB",
"",
"CH -> B",
"HH -> N",
"CB -> H",
"NH -> C",
"HB -> C",
"HC -> B",
"HN -> C",
"NN -> C",
"BH -> H",
"NC -> B",
"NB -> B",
"BN -> B",
"BB -> N",
"BC -> B",
"CC -> N",
"CN -> C"
                };
            }
        }
    }
}
