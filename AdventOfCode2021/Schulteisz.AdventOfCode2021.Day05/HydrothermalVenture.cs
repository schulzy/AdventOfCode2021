using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day05
{
    public class HydrothermalVenture : IDailyTask
    {
        private readonly IContentParser _contentParser;

        public string Name => "Hydrothermal Venture";

        public HydrothermalVenture(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
