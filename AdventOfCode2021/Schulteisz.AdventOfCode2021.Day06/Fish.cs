namespace Schulteisz.AdventOfCode2021.Day06
{
    internal class Fish
    {
        private int _reproductionCounter;
        private readonly IFishCreator _fishCreator;

        public int Age { get; set; } = 0;

        public Fish(IFishCreator fishCreator)
        {
            _reproductionCounter = 9;
            _fishCreator = fishCreator;
        }

        public Fish(int reproductionCounter, IFishCreator fishCreator)
        {
            _reproductionCounter = reproductionCounter;
            _fishCreator = fishCreator;
        }

        public void NextDay()
        {
            if (_reproductionCounter == 0)
            {
                _fishCreator.Create(8);
                _reproductionCounter = 6;
            }
            else
                _reproductionCounter--;
            Age++;
        }
    }
}
