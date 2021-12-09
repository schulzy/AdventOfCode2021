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
            HatcheryCounter fishCreator = new HatcheryCounter();
            _contentParser
                ?.GetLines("Task.txt")
                ?.FirstOrDefault()
                ?.Split(",")
                .ToList()
                .ForEach(x => fishCreator.AddFish(int.Parse(x)));

            for (int i = 0; i < 256; i++)
            {
                fishCreator.NextDay();
            }

            return fishCreator.FishCount;
        }
    }
}
