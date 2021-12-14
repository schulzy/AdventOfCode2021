using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Day09;
using Schulteisz.AdventOfCode2021.Day10;
using Schulteisz.AdventOfCode2021.Interfaces;
using System.Collections.Generic;

namespace Schulteisz.AdventOfCode2021.Tests
{
    [TestClass]
    public class Day10
    {
        [TestMethod]
        public void Task1()
        {
            IContentParser contentParser = new ContentParser();

            SyntaxScoring sut = new SyntaxScoring(contentParser);
            long result = sut.Run();
            Assert.AreEqual(369105, result);
        }

        [TestMethod]
        public void Task2()
        {
            IContentParser contentParser = new ContentParser();

            SyntaxScoringHard sut = new SyntaxScoringHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(3999363569, result);
        }

        [TestMethod]
        public void Task1Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SyntaxScoring sut = new SyntaxScoring(contentParser);
            long result = sut.Run();
            Assert.AreEqual(26397, result);
        }

        [TestMethod]
        public void Task2Predefined()
        {
            IContentParser contentParser = new LocalContentParser();

            SyntaxScoringHard sut = new SyntaxScoringHard(contentParser);
            long result = sut.Run();
            Assert.AreEqual(288957, result);
        }

        internal class LocalContentParser : IContentParser
        {
            public List<string> GetLines(string manifestName)
            {
                return new List<string>
                {
                    "[({(<(())[]>[[{[]{<()<>>",
"[(()[<>])]({[<{<<[]>>(",
"{([(<{}[<>[]}>{[]{[(<()>",
"(((({<>}<{<{<>}{[]{[]{}",
"[[<[([]))<([[{}[[()]]]",
"[{[{({}]{}}([{[{{{}}([]",
"{<[[]]>}<{[{[{[]{()[[[]",
"[<(<(<(<{}))><([]([]()",
"<{([([[(<>()){}]>(<<{{",
"<{([{{}}[<[[[<>{}]]]>[]]"
                };
            }
        }
    }
}
