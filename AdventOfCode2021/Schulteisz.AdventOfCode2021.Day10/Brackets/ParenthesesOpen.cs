namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class ParenthesesOpen : IOpenSymbol
    {
        public Type PairType => typeof(ParenthesesClose);
        public int IncompleteScore => 1;

    }
}
