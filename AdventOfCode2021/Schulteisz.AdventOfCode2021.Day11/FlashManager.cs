namespace Schulteisz.AdventOfCode2021.Day11
{
    internal class FlashManager : IFlashManager
    {
        private long _flashCount = 0;

        public void SetFlash()
        {
            _flashCount++;
        }
    }

    internal interface IFlashManager
    {
        void SetFlash();
    }
}
