using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day07
{
    public class TheTreacheryOfWhales : IDailyTask
    {
        private IContentParser _contentParser;

        public TheTreacheryOfWhales(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "The Treachery of Whales";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
