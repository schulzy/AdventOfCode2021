using System;
using System.Linq;
namespace Schulteisz.AdventOfCode2021.Day12
{
	internal class Cave
	{
        public Cave(string name)
		{
            Name = name;
			if (name.All(c => char.IsUpper(c)))
                CaveSize = CaveSize.Large;
			else
                CaveSize = CaveSize.Small;

			switch (name)
			{
				case "start":
                    Location = Location.Start;
					CaveSize = CaveSize.Special;
                    break;
				case "end":
                    Location = Location.End;
                    CaveSize = CaveSize.Special;
                    break;
				default:
                    Location = Location.Middle;
					break;
			}
		}

		public string Name { get; }
		public CaveSize CaveSize { get; }
		public Location Location { get; }
		public bool Deactivated
		{
			get
			{
				if(Neighbours.Count == 1 && Neighbours.First().CaveSize == CaveSize.Small)
					return true;
				return false;
			}
		}
        public bool Discovered { get; set; } = false;
        public HashSet<Cave> Neighbours { get; set; } = new HashSet<Cave>();

        public void AddNeighbours(Cave cave)
		{
			if(!Neighbours.Contains(cave))
			{
				Neighbours.Add(cave);
				cave.AddNeighbours(this);
			}
		}
    }

	internal enum Location
	{
		Start,
		Middle,
		End
	}

	internal enum CaveSize
	{
		Large,
		Small,
		Special
	}
}

