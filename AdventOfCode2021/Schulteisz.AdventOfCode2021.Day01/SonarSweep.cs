using Schulteisz.AdventOfCode2021.Interfaces;
using System.Linq;

namespace Schulteisz.AdventOfCode2021.Day01
{
    public class SonarSweep : IDailyTask
    {
        IList<int> _deep = new List<int>();
        public string Name => "Sonar sweep";

        public IContentParser _contentParser;

        public SonarSweep(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            _contentParser.GetLines("Task.txt").ForEach(line => _deep.Add(int.Parse(line)));

            return CountIncrease();
        }

        private int CountIncrease()
        {
            int previous = int.MaxValue;
            int count = 0;
            foreach (var item in _deep)
            {
                if (previous < item)
                {
                    count++;
                }
                previous = item;
            }

            return count;
        }
    }
}
