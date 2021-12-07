using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day04;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day04
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            GiantSquid sut = new GiantSquid(contentParser);
            long result = sut.Run();
            Assert.AreEqual(31424, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            GiantSquidHard sut = new GiantSquidHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(23042, result);
        }

        [TestMethod]
        public void Task1PreDifined()
        {
            IContentParser contentParser = new LocalContentParser();

            GiantSquid sut = new GiantSquid(contentParser);
            long result = sut.Run();
            Assert.AreEqual(4512, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                    "",
"22 13 17 11  0",
" 8  2 23  4 24",
"21  9 14 16  7",
" 6 10  3 18  5",
" 1 12 20 15 19",
"",
" 3 15  0  2 22",
" 9 18 13 17  5",
"19  8  7 25 23",
"20 11 10 24  4",
"14 21 16 12  6",
"",
"14 21 17 24  4",
"10 16 15  9 19",
"18  8 23 26 20",
"22 11 13  6  5",
" 2  0 12  3  7"
                };
            }
        }
    }
}
