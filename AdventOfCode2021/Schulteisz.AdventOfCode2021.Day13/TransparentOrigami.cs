using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day13
{
    public class TransparentOrigami : IDailyTask
    {
        private IContentParser _contentParser;

        public TransparentOrigami(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Transparent Origami";

        public long Run()
        {
            FieldManager manager = new FieldManager(_contentParser.GetLines("Task.txt"));
            manager.Fold();
            return manager.GetPointCount();
        }
    }
}
