using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day11
{
    public class DumboOctopusHard : IDailyTask
    {
        private IContentParser _contentParser;

        public DumboOctopusHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Dumbo Octopus Hard";

        public long Run()
        {
            OctopusField field = new OctopusField(_contentParser.GetLines("Task.txt"));
            return field.SyncFlash();
        }
    }
}
