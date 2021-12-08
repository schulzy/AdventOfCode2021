namespace Schulteisz.AdventOfCode2021.Day05
{
    internal class VentsLocation
    {
        private bool _isPerpedicular;

        public Point StartPoint { get;}
        public Point FinishPoint { get; }

        public VentsLocation(string vents)
        {
            string[] positions = vents.Split("->");
            StartPoint = new Point(positions[0]);
            FinishPoint = new Point(positions[1]);
            if (StartPoint.X == FinishPoint.X || StartPoint.Y == FinishPoint.Y)
                _isPerpedicular = true;
        }

        public IList<Point> GetMiddlePoints(bool onlyPerpendicular)
        {
            IList<Point> points = new List<Point>();
            if (onlyPerpendicular && !_isPerpedicular)
                return points;
            int xDiff = FinishPoint.X - StartPoint.X;
            int yDiff = FinishPoint.Y - StartPoint.Y;
            CalculatePerpenducular(points, xDiff, yDiff);

            return points;
        }

        private void CalculatePerpenducular(IList<Point> points, int xDiff, int yDiff)
        {
            var diff = Math.Abs(xDiff) > Math.Abs(yDiff) ? xDiff : yDiff;
            diff = Math.Abs(diff);
            int xIncrement = xDiff / (xDiff != 0 ? Math.Abs(xDiff) : 1);
            int yIncrement = yDiff / (yDiff != 0 ? Math.Abs(yDiff) : 1);

            for (int i = 0; i <= diff; i++)
            {
                points.Add(new(StartPoint.X + (i * xIncrement), StartPoint.Y + (i * yIncrement)));
            }
            if (points.First().X != StartPoint.X && points.First().Y != StartPoint.Y)
                throw new Exception("Start issue");
            if (points.Last().X != FinishPoint.X && points.Last().Y != FinishPoint.Y)
                throw new Exception("Finish isse");
        }
    }
}
