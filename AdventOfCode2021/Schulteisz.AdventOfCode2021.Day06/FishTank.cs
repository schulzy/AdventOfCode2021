namespace Schulteisz.AdventOfCode2021.Day06
{
    internal class FishTank : IFishTank
    {
        private List<Fish> _tank = new List<Fish>();
        private List<Fish> _fishHatchery = new List<Fish>();
        public int FishCount { get { return _tank.Count; } }
        public int Day { get; private set; } = 0;

        public void AddNewFish(Fish fish)
        {
            _fishHatchery.Add(fish);
        }

        public void NextDay()
        {
            _tank.ForEach(x=>x.NextDay());
            _tank.AddRange(_fishHatchery);
            _fishHatchery.Clear();
            
        }
    }
}
