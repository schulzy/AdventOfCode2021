namespace Schulteisz.AdventOfCode2021.Day06
{
    internal interface IFishTank
    {
        void AddNewFish(Fish fish);
        void NextDay();
        int FishCount { get; }
    }
}