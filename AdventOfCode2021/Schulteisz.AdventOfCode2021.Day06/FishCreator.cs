namespace Schulteisz.AdventOfCode2021.Day06
{
    internal class FishCreator : IFishCreator
    {
        private IFishTank _fishTank;

        public FishCreator(IFishTank fishTank)
        {
            _fishTank = fishTank;
        }

        public void Create(int reproductionCounter)
        {
            _fishTank.AddNewFish(new Fish(reproductionCounter, this));
        }
    }
}
