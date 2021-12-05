using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day01
{
    public class SonarSweepHard : IDailyTask
    {
        public IContentParser _contentParser;
        IList<int> _deep = new List<int>();
        public string Name => "Sonar sweep hard";

        public SonarSweepHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            _contentParser.GetLines("Task.txt").ForEach(line => _deep.Add(int.Parse(line)));
            return CountGroupDeep();
        }

        private long CountGroupDeep()
        {
            int previous = int.MaxValue;
            int count = 0;
            for (int i = 0; i < _deep.Count-2; i++)
            {
                int sum = _deep[i] + _deep[i + 1] + _deep[i + 2];
                if (previous < sum)
                {
                    count++;
                }
                previous = sum;
            }

            return count;
        }
    }
}
