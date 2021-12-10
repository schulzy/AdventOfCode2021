using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day08
{
    public class SevenSegmentSearch : IDailyTask  
    {
        private IContentParser contentParser;

        public SevenSegmentSearch(IContentParser contentParser)
        {
            this.contentParser = contentParser;
        }

        public string Name => "Seven Segment Search";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
