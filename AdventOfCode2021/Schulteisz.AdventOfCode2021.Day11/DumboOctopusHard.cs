using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day11
{
    public class DumboOctopusHard : IDailyTask
    {
        private IContentParser contentParser;

        public DumboOctopusHard(IContentParser contentParser)
        {
            this.contentParser = contentParser;
        }

        public string Name => "Dumbo Octopus Hard";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
