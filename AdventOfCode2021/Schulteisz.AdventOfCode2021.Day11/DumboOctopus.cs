using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day11
{
    public class DumboOctopus : IDailyTask
    {
        private IContentParser _contentParser;

        public DumboOctopus(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Dumbo Octopus";

        public long Run()
        {
            OctopusField field = new OctopusField(_contentParser.GetLines("Task.txt"));
            return field.FlashCount();
        }
    }
}
