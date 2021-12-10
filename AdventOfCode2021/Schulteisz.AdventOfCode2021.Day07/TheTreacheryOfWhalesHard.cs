using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day07
{
    public class TheTreacheryOfWhalesHard : IDailyTask
    {
        private IContentParser _contentParser;

        public TheTreacheryOfWhalesHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "The Treachery of Whales Hard";

        public long Run()
        {
            FuelCounter fuelCounter = new FuelCounter();
            _contentParser
                ?.GetLines("Task.txt")
                ?.FirstOrDefault()
                ?.Split(",")
                .ToList()
                .ForEach(x => fuelCounter.AddPositon(int.Parse(x)));

            fuelCounter.ProcessFuelHard();
            return fuelCounter.IdealFuelConsumtion;
        }
    }
}
