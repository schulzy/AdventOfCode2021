namespace Schulteisz.AdventOfCode2021.Day09
{
    internal class CaveCreator
    {
        public IList<string> _list;
        int[,] _points;
        List<Point> Points { get; set; } = new List<Point>();

        public CaveCreator(IList<string> list)
        {
            _list = list;
            _points = new int[list.First().Length, list.Count];

        }

        public void InitializePoints()
        {
            for (int i = 0; i < _points.GetLength(0); i++)
            {
                for (int j = 0; j < _points.GetLength(1); j++)
                {
                    _points[i, j] = int.Parse(_list.ElementAt(j).ToList().ElementAt(i).ToString());
                    Points.Add(new Point(i, j, _points[i, j], this));
                }
            }

            foreach (var point in Points)
            {
                point.SetNeighbours();
            }
        }

        internal long Find3BiggestBasin() 
        {
            long product = 1;
            List<int> basinCount = new List<int>();
            foreach (var point in Points)
            {
                if (point.IsLowest)
                {
                    basinCount.Add(point.BasinCount());
                }
            }
            var orderedList = basinCount.OrderByDescending(x => x);
            foreach (var item in orderedList.Take(3))
            {
                product *= item;
            }

            
            return product;
        }

        internal long FindLowestPoints()
        {
            long count = 0;
            foreach (var point in Points)
            {
                if (point.IsLowest)
                    count += point.Value + 1;
            }
            return count;
        }

        public Point GetPoint(int x, int y)
        {
            if (x >= 0 && x < _points.GetLength(0) && y >= 0 && y < _points.GetLength(1))
                return Points.First(item => item.X == x && item.Y == y);
            return null;
        }
    }
}
