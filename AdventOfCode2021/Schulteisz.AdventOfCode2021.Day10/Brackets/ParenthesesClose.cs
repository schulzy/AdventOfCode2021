namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class ParenthesesClose : ICloseSymbol
    {
        public Type PairType => typeof(ParenthesesOpen);

        public int CorruptedScore => 3;

    }
}
