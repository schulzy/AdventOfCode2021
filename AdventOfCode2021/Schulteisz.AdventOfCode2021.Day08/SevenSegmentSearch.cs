using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day08
{
    public class SevenSegmentSearch : IDailyTask  
    {
        private IContentParser _contentParser;

        public SevenSegmentSearch(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Seven Segment Search";

        public long Run()
        {
            SegmentDisplayManager segmentDisplayManager = new SegmentDisplayManager(_contentParser.GetLines("Task.txt"));
            return segmentDisplayManager.GetEasyNumbers();
        }
    }
}
