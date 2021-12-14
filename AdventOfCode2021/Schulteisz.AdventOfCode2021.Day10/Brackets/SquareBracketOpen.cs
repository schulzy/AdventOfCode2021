namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class SquareBracketOpen : IOpenSymbol
    {
        public Type PairType => typeof(SquareBracketClose);
        public int IncompleteScore => 2;

    }
}
