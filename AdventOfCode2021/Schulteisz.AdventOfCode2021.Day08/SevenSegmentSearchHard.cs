using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day08
{
    public class SevenSegmentSearchHard : IDailyTask
    {
        private IContentParser _contentParser;

        public SevenSegmentSearchHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Seven Segment Search Hard";

        public long Run()
        {
            SegmentDisplayManager segmentDisplayManager = new SegmentDisplayManager(_contentParser.GetLines("Task.txt"));
            return segmentDisplayManager.GetOutputSum();
        }
    }
}
