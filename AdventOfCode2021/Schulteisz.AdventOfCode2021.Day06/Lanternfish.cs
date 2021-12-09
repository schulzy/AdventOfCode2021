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
            IFishTank fishTank = new FishTank();
            IFishCreator fishCreator = new FishCreator(fishTank);
            _contentParser
                ?.GetLines("Task.txt")
                ?.FirstOrDefault()
                ?.Split(",")
                .ToList()
                .ForEach(x => fishCreator.Create(int.Parse(x)));

            for (int i = 0; i < 81; i++)
            {
                fishTank.NextDay();
            }

            return fishTank.FishCount;
        }
    }
}
