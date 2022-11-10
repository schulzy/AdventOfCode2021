using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day15;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day15
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            Chiton sut = new Chiton(contentParser);
            try
            {
                long result = sut.Run();
                Assert.AreEqual(40, result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            ChitonHard sut = new ChitonHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2399822193707, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            Chiton sut = new Chiton(contentParser);
            try
            {
                long result = sut.Run();
                Assert.AreEqual(40, result);
            }
            catch (System.Exception)
            {

                throw;
            }
            
           
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            ChitonHard sut = new ChitonHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(2188189693529, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "1163751742",
"1381373672",
"2136511328",
"3694931569",
"7463417111",
"1319128137",
"1359912421",
"3125421639",
"1293138521",
"2311944581"
                };
            }
        }
    }
}
