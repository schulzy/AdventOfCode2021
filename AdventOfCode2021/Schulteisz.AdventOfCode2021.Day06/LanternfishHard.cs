using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day06
{
    public class LanternfishHard : IDailyTask
    {
        private IContentParser _contentParser;

        public LanternfishHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Lanternfish hard";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
