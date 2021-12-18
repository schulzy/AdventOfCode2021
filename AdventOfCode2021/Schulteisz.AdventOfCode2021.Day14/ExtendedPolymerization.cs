using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day14
{
    public class ExtendedPolymerization : IDailyTask
    {
        private IContentParser _contentParser;

        public ExtendedPolymerization(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Extended Polymerization";

        public long Run()
        {
            PolimerParser parser = new PolimerParser(_contentParser.GetLines("Task.txt"));
            parser.CreatePolimer(10);
            return parser.GetMaxMinDiff();
        }
    }
}
