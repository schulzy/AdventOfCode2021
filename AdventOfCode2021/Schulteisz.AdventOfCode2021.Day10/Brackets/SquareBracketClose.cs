namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class SquareBracketClose : ICloseSymbol
    {
        public Type PairType => typeof(SquareBracketOpen);

        public int CorruptedScore => 57;

    }
}
