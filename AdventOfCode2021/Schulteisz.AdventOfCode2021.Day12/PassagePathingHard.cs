using System;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day12
{
	public class PassagePathingHard : IDailyTask
    {
        private IContentParser _contentParser;

        public PassagePathingHard(IContentParser contentParser)
		{
            _contentParser = contentParser;
        }

        public string Name => "Passage Pathing Hard";

        public long Run()
        {
            CaveSystem caveSystem = new CaveSystem(_contentParser.GetLines("Task.txt"));
            Console.WriteLine(caveSystem.ToString());

            Predicate<(Cave cave, List<Cave> caveList)> predicate =
                (tuple) =>
                {
                    //return tuple.caveList.Contains(tuple.cave) && tuple.caveList.Count(cave => cave == tuple.cave) >= 2;
                    return tuple.caveList.Contains(tuple.cave) &&
                    tuple.caveList.Any(
                        cave =>
                            cave.CaveSize == CaveSize.Small &&
                            tuple.caveList.Count(item => item == cave) >= 2
                            );
                };
            caveSystem.Initialize(predicate);
            return caveSystem.GetPathCount();
        }
    }
}

