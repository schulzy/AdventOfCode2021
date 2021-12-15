namespace Schulteisz.AdventOfCode2021.Day11
{
    internal class OctopusField
    {
        private long _flashCount = 0;
        private Dictionary<Point, Octopus> _octopusDict = new Dictionary<Point, Octopus>();  
        private List<Octopus> _octopusList = new List<Octopus>();
        public OctopusField(List<string> list)
        {
            IFlashManager flashManager = new FlashManager();
            foreach (var line in list)
            {
                foreach (var energy in line)
                {
                    int.Parse(energy.ToString());
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    char energy = list[i][j];
                    var octopus = new Octopus(j, i, int.Parse(energy.ToString()), this);
                    _octopusDict.Add(octopus.Point, octopus);
                    _octopusList.Add(octopus);
                }
            }

            foreach (var octopus in _octopusList)
            {
                octopus.SetNeighbours();
            }
        }

        public long SyncFlash()
        {
            long counter = 0;
            while(true)
            {
                bool allFlashed = true;
                _octopusList.ForEach(octopus => octopus.Energy++);
                _octopusList.ForEach(octopus => allFlashed &= octopus.Flashed);
                _octopusList.ForEach(octopus => octopus.SetNextStep());
                counter++;
                if (allFlashed)
                    return counter;
            }

        }

        public long FlashCount()
        {
            for (int i = 0; i < 100; i++)
            {
                _octopusList.ForEach(octopus => octopus.Energy++);
                _octopusList.ForEach(octopus => octopus.SetNextStep());
            }

            return _flashCount;
        }

        public void SetFlash()
        {
            _flashCount++;
        }

        internal Octopus GetOctopus(int x, int y)
        {
            var point = new Point(x,y);
            _octopusDict.TryGetValue(point, out Octopus octopus);
            return octopus;
        }
    }
}
