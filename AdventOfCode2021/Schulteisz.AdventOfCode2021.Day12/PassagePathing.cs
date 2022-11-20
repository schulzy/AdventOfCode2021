using System;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day12
{
	public class PassagePathing : IDailyTask
	{
        private IContentParser _contentParser;

        public PassagePathing(IContentParser contentParser)
		{
            _contentParser = contentParser;
		}

        public string Name => "Passage Pathing";

        public long Run()
        {
            CaveSystem caveSystem = new CaveSystem(_contentParser.GetLines("Task.txt"));
            Console.WriteLine(caveSystem.ToString());

            Predicate<(Cave cave, List<Cave> caveList)> predicate =
                (tuple) =>
                {
                    return tuple.caveList.Contains(tuple.cave);
                };
            caveSystem.Initialize(predicate);
            return caveSystem.GetPathCount();
        }
    }
}

