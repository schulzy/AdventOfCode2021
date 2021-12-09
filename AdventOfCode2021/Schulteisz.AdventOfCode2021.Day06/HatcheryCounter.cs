namespace Schulteisz.AdventOfCode2021.Day06
{
    internal class HatcheryCounter
    {
        Dictionary<int, long> _counter = new Dictionary<int, long>()
        {
            { 8,0 },
            { 7,0 },
            { 6,0 },
            { 5,0 },
            { 4,0 },
            { 3,0 },
            { 2,0 },
            { 1,0 },
            { 0,0 },
        };

        public long FishCount { 
            get 
            {
                long count = 0;
                foreach (var item in _counter)
                {
                    count += item.Value;
                }

                return count;
            } 
        }

        public void AddFish(int day)
        {
            if (_counter.ContainsKey(day))
                _counter[day]++;
            else
                _counter.Add(day, 1);
        }

        public void NextDay()
        {
            long newFish = _counter[0];
            for (int i = 0; i <= 8; i++)
            {
                if (i < 8)
                    _counter[i] = _counter[i + 1]; 
            }
            _counter[8]= newFish;
            _counter[6] += newFish;
        }


    }
}
