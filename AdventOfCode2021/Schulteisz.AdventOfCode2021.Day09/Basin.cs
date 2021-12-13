namespace Schulteisz.AdventOfCode2021.Day09
{
    internal class Basin
    {
        private readonly Point _basePoint;
        private readonly HashSet<Point> _points;

        public Basin(Point basePoint)
        {
            _basePoint = basePoint;
            _points = new HashSet<Point>();
            _points.Add(basePoint);
        }

        public void AddBasin(Point point)
        {
            _points.Add(point);
        }

        public int Count()
        {
            return _points.Count;
        }
    }
}
