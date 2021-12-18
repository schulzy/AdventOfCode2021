using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day14
{
    public class ExtendedPolymerizationHard : IDailyTask
    {
        private IContentParser _contentParser;

        public ExtendedPolymerizationHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Extended Polymerization Hard";

        public long Run()
        {
            PolimerParser parser = new PolimerParser(_contentParser.GetLines("Task.txt"));
            parser.CreatePolimer(40);
            return parser.GetMaxMinDiff();
        }
    }
}
