namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class AngleBracketClose : ICloseSymbol
    {
        public Type PairType => typeof(AngleBracketOpen);

        public int CorruptedScore => 25137;

        
    }
}
