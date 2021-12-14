using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day10
{
    public class SyntaxScoring : IDailyTask
    {
        private IContentParser _contentParser;

        public SyntaxScoring(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Syntax Scoring";

        public long Run()
        {
            SyntaxManager manager = new SyntaxManager(_contentParser.GetLines("Task.txt"));
            return manager.GetCorruptedScore();
        }
    }
}
