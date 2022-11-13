namespace Schulteisz.AdventOfCode2021.Day15
{
    internal interface IField
    {
        CavernPoint GetPoint(int x, int y);
        void GeneratePoints(IList<string> lines);
        void ExtendField(int multiplier);
        CavernPoint StartPoint { get; }
        CavernPoint FinishPoint { get; }
    }
}