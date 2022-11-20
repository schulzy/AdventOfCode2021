using System;
using System.Text;
using Schulteisz.AdventOfCode2021.Common;
using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day12
{
	internal class CaveSystem
	{
        Dictionary<string,Cave> _caves = new Dictionary<string, Cave>();
        Dictionary<Cave, HashSet<string>> _paths= new Dictionary<Cave, HashSet<string>>();
        public CaveSystem(IList<string> lines)
		{
            foreach (var line in lines)
			{
				string[] caves = line.Split("-");

				Cave firstCave;
                if (!_caves.TryGetValue(caves[0], out firstCave))
				{
					firstCave = new Cave(caves[0]);
                    _caves.Add(firstCave.Name, firstCave);
				}

                Cave secondCave;
                if (!_caves.TryGetValue(caves[1], out secondCave))
                {
                    secondCave = new Cave(caves[1]);
                    _caves.Add(secondCave.Name, secondCave);
                }
				secondCave.AddNeighbours(firstCave);
            }
		}

        public int GetPathCount()
        {
            return GetPathCount(_caves["start"]);
        }

        private int GetPathCount(Cave start)
        {
            int pathCount = 0;
            foreach (var cave in start.Neighbours)
            {
                if (cave.Location == Location.Start)
                    continue;
                if (cave.Location == Location.End)
                {
                    pathCount++;
                    continue;
                }
                if (cave.CaveSize == CaveSize.Large)
                {
                    pathCount += GetPathCount(cave);
                    continue;
                }
                pathCount += _paths.ContainsKey(cave) ? _paths[cave].Count : 0;
            }
            return pathCount;
        }

        public void Initialize(Predicate<(Cave cave, List<Cave> caveList)> predicate)
        {
            foreach (var cave in _caves.Values.Where(cave => cave.CaveSize == CaveSize.Small && !cave.Deactivated))
            {
                BuildSmallTree(cave, new List<Cave>(), predicate);
                cave.Discovered = true;
            }
        }

        private void BuildSmallTree(Cave cave, List<Cave> caveList, Predicate<(Cave cave, List<Cave> caveList)> predicate)
        {
            if (cave.Location == Location.Start)
                return;
            caveList.Add(cave);
            foreach (var neighbour in cave.Neighbours)
            {
                if(neighbour.Location == Location.End)
                {
                    caveList.Add(neighbour);
                    StoreCavePath(caveList);
                    caveList.RemoveAt(caveList.Count-1);
                    continue;
                }
                if(neighbour.CaveSize == CaveSize.Small && predicate((neighbour,caveList)))
                {
                    continue;
                }
                BuildSmallTree(neighbour, caveList, predicate);
            }
            caveList.RemoveAt(caveList.Count - 1);
        }

        private void StoreCavePath(List<Cave> caveList)
        {
            var firstCave = caveList.First();
            string list = string.Join(",", caveList.Select(cave => cave.Name));
            if (_paths.ContainsKey(firstCave))
            {
                _paths[firstCave].Add(list);
            }
            else
                _paths.Add(firstCave, new HashSet<string>() { list });
        }
    }
}

