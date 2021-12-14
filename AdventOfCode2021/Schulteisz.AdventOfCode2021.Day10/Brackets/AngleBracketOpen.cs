namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class AngleBracketOpen : IOpenSymbol
    {
        public Type PairType => typeof(AngleBracketClose);
        public int IncompleteScore => 4;
    }
}
