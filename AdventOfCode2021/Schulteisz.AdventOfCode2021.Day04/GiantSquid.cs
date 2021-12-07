using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day04
{
    public class GiantSquid : IDailyTask
    {
        private readonly IContentParser _contentParser;

        public string Name => "Giant Squid";

        public GiantSquid(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            BingoManager bingoManager = new BingoManager(_contentParser.GetLines("Task.txt"));
            return bingoManager.GetResult().First();
        }
    }
}
