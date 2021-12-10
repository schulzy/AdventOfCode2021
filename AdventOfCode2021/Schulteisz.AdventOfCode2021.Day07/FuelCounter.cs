namespace Schulteisz.AdventOfCode2021.Day07
{
    internal class FuelCounter
    {
        private Dictionary<int, CrabSubmarine> _counter = new Dictionary<int, CrabSubmarine>();
        private Dictionary<int, CrabSubmarine> _counterExtra = new Dictionary<int, CrabSubmarine>();
        private Dictionary<int, int> _consumption = new Dictionary<int, int>();
        private int _maxPosition;

        public long IdealFuelConsumtion 
        {
            get
            {
                long minFuel = long.MaxValue;
                Dictionary<int, CrabSubmarine> localCounter = _counterExtra.Count > 0 ? _counterExtra : _counter;
                foreach (var counter in localCounter)
                {
                    if (counter.Value.Fuel < minFuel)
                        minFuel = counter.Value.Fuel;
                }

                return minFuel;
            }
        }

        public void AddPositon(int location)
        {
            _maxPosition = int.MinValue;
            if (location > _maxPosition)
                _maxPosition = location;

            if (_counter.ContainsKey(location))
                _counter[location].Count++;
            else
                _counter.Add(location, new CrabSubmarine());
        }

        internal void ProcessFuelHard()
        {
            for (int i = 0; i < _maxPosition; i++)
            {

                long fuel = 0;
                foreach (var crabSubMarine in _counter)
                {
                    if (i == crabSubMarine.Key)
                        continue;
                    fuel += CalculateComplexConsumption(i, crabSubMarine.Key) * crabSubMarine.Value.Count;
                }
                _counterExtra.Add(i, new CrabSubmarine() { Fuel = fuel });
            }
        }

        private int CalculateComplexConsumption(int actualCrabSubMarine, int crabSubMarine)
        {
            var diff = Math.Abs(actualCrabSubMarine - crabSubMarine);
            if (_consumption.ContainsKey(diff))
                return _consumption[diff];
            else
            {
                int sum = 0;
                for (int i = 1; i <= diff; i++)
                {
                    sum += i;
                }
                _consumption.Add(diff, sum);
                return sum;
            }
        }

        internal void ProcessFuel()
        {
            foreach (var actualCrabSubMarine in _counter)
            {
                long fuel = 0;
                foreach (var crabSubMarine in _counter)
                {
                    if (actualCrabSubMarine.Key == crabSubMarine.Key)
                        continue;
                    fuel += Math.Abs(actualCrabSubMarine.Key - crabSubMarine.Key) * crabSubMarine.Value.Count;
                }
                actualCrabSubMarine.Value.Fuel = fuel;
            }
        }
    }

    internal class CrabSubmarine
    {
        public int Count { get; set; } = 1;
        public long Fuel { get; set; } = 0;
    }
}
