using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day11
{
    public class DumboOctopus : IDailyTask
    {
        private IContentParser contentParser;

        public DumboOctopus(IContentParser contentParser)
        {
            this.contentParser = contentParser;
        }

        public string Name => "Dumbo Octopus";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
