﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day07;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day07
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            TheTreacheryOfWhales sut = new TheTreacheryOfWhales(contentParser);
            long result = sut.Run();
            Assert.AreEqual(349812, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            TheTreacheryOfWhalesHard sut = new TheTreacheryOfWhalesHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(99763899, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            TheTreacheryOfWhales sut = new TheTreacheryOfWhales(contentParser);
            long result = sut.Run();
            Assert.AreEqual(37, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            TheTreacheryOfWhalesHard sut = new TheTreacheryOfWhalesHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(168, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "16,1,2,0,4,2,7,1,2,14"
                };
            }
        }
    }
}
