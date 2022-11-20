using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day16;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day16
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            PacketDecoder sut = new PacketDecoder(contentParser);
            long result = sut.Run();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            PacketDecoderHard sut = new PacketDecoderHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {

        }

        [TestMethod]
        public void Task2Predefined()
        {

        }
    }
}

