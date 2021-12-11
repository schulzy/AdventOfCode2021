using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day08;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day08
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            SevenSegmentSearch sut = new SevenSegmentSearch(contentParser);
            long result = sut.Run();
            Assert.AreEqual(488, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            SevenSegmentSearchHard sut = new SevenSegmentSearchHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(1040429, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SevenSegmentSearch sut = new SevenSegmentSearch(contentParser);
            long result = sut.Run();
            Assert.AreEqual(26, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SevenSegmentSearchHard sut = new SevenSegmentSearchHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(61229, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
"edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
"fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
"fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
"aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
"fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
"dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
"bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
"egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
"gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
                };
            }
        }
    }
}
