namespace Schulteisz.AdventOfCode2021.Day10
{
    internal interface ISymbol
    {
        Type PairType { get; }
    }

    internal interface IOpenSymbol : ISymbol
    {
        int IncompleteScore { get; }

    }

    internal interface ICloseSymbol : ISymbol
    {
        int CorruptedScore { get; }
    }
}
