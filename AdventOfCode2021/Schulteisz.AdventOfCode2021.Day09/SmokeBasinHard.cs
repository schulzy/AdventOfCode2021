using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day09
{
    public class SmokeBasinHard : IDailyTask
    {
        private IContentParser _contentParser;

        public SmokeBasinHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Smoke Basin Hard";

        public long Run()
        {
            CaveCreator creator = new CaveCreator(_contentParser.GetLines("Task.txt"));
            creator.InitializePoints();

            return creator.Find3BiggestBasin();
        }
    }
}
