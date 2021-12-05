using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day01;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day01
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            SonarSweep sut = new SonarSweep(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1266, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            SonarSweepHard sut = new SonarSweepHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1217, result);
        }
    }
}