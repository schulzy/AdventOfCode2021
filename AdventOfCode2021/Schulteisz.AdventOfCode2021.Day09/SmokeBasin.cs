using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day09
{
    public class SmokeBasin : IDailyTask
    {
        private IContentParser _contentParser;

        public SmokeBasin(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Smoke Basin";

        public long Run()
        {
            CaveCreator creator = new CaveCreator(_contentParser.GetLines("Task.txt"));
            creator.InitializePoints();
            

            return creator.FindLowestPoints();
        }
    }
}
