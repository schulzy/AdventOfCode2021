using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day06
{
    public class Lanternfish : IDailyTask
    {
        private IContentParser _contentParser;

        public Lanternfish(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Lanternfish";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
