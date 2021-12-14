namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class CurlyBracketOpen : IOpenSymbol
    {
        public Type PairType => typeof(CurlyBracketClose);
        public int IncompleteScore => 3;

    }
}
