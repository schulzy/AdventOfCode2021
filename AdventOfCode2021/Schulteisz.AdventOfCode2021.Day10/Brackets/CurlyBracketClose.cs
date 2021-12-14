namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class CurlyBracketClose : ICloseSymbol
    {
        public Type PairType => typeof(CurlyBracketOpen);

        public int CorruptedScore => 1197;

    }
}
