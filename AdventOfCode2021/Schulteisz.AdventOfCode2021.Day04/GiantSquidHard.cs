using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day04
{
    public class GiantSquidHard : IDailyTask
    {
        private readonly IContentParser _contentParser;

        public string Name => "Giant Squid Hard";
        public GiantSquidHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            BingoManager bingoManager = new BingoManager(_contentParser.GetLines("Task.txt"));
            return bingoManager.GetResult().Last();
        }
    }
}
