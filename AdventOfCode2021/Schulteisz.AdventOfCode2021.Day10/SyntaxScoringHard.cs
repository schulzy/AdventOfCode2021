using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day10
{
    public class SyntaxScoringHard : IDailyTask
    {
        private IContentParser _contentParser;

        public SyntaxScoringHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Syntax Scoring Hard";

        public long Run()
        {
            SyntaxManager manager = new SyntaxManager(_contentParser.GetLines("Task.txt"));
            return manager.GetIncompleteScore();
        }
    }
}
