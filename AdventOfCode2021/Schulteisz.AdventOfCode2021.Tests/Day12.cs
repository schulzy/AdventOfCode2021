using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day12;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day12
	{
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            PassagePathing sut = new PassagePathing(contentParser);
            long result = sut.Run();
            Assert.AreEqual(5252, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            PassagePathingHard sut = new PassagePathingHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(147784, result);
        }

        [TestMethod]
        public void Task1PredefinedEasy()
        {
            IContentParser contentParser = new LocalContentParserEasy();

            PassagePathing sut = new PassagePathing(contentParser);
            long result = sut.Run();
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Task1PredefinedMedium()
        {
            IContentParser contentParser = new LocalContentParserMedium();

            PassagePathing sut = new PassagePathing(contentParser);
            long result = sut.Run();
            Assert.AreEqual(19, result);
        }

        [TestMethod]
        public void Task1PredefinedHard()
        {
            IContentParser contentParser = new LocalContentParserHard();

            PassagePathing sut = new PassagePathing(contentParser);
            long result = sut.Run();
            Assert.AreEqual(226, result);
        }

        [TestMethod]
        public void Task2PredefinedEasy()
        {
            IContentParser contentParser = new LocalContentParserEasy();

            PassagePathingHard sut = new PassagePathingHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(36, result);
        }

        [TestMethod]
        public void Task2PredefinedMedium()
        {
            IContentParser contentParser = new LocalContentParserMedium();

            PassagePathingHard sut = new PassagePathingHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(103, result);
        }

        [TestMethod]
        public void Task2PredefinedHard()
        {
            IContentParser contentParser = new LocalContentParserHard();

            PassagePathingHard sut = new PassagePathingHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(3509, result);
        }

        internal class LocalContentParserMedium : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                        {
                            "dc-end",
                            "HN-start",
                            "start-kj",
                            "dc-start",
                            "dc-HN",
                            "LN-dc",
                            "HN-end",
                            "kj-sa",
                            "kj-HN",
                            "kj-dc"
                        };
            }
        }

        internal class LocalContentParserHard : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                        {
                            "fs-end",
                            "he-DX",
                            "fs-he",
                            "start-DX",
                            "pj-DX",
                            "end-zg",
                            "zg-sl",
                            "zg-pj",
                            "pj-he",
                            "RW-he",
                            "fs-DX",
                            "pj-RW",
                            "zg-RW",
                            "start-pj",
                            "he-WI",
                            "zg-he",
                            "pj-fs",
                            "start-RW",
                        };
            }
        }

        internal class LocalContentParserEasy : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                        {
                            "start-A",
                            "start-b",
                            "A-c",
                            "A-b",
                            "b-d",
                            "A-end",
                            "b-end"
                        };
                
            }
        }
    }
}