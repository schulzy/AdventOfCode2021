namespace Schulteisz.AdventOfCode2021.Day05
{
    internal class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(string points)
        {
            var separatedPoints = points.Split(",");
            X = int.Parse(separatedPoints[0]);
            Y = int.Parse(separatedPoints[1]);
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            int hash = 7907;
            hash = (hash * 5737) + X.GetHashCode();
            hash = (hash * 5737) + Y.GetHashCode();
            return hash;
        }

        public override bool Equals(object? obj)
        {
            return obj?.GetHashCode() == GetHashCode();
        }
    }
}
