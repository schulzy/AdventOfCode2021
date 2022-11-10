using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day13
{
    public class TransparentOrigamiHard : IDailyTask
    {
        private IContentParser _contentParser;

        public TransparentOrigamiHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Transparent Origami Hard";

        public long Run()
        {
            FieldManager manager = new FieldManager(_contentParser.GetLines("Task.txt"));
            while (manager.Fold()) ;
            return manager.PrintResult();
        }
    }
}
