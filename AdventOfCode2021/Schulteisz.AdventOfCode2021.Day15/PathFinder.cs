using System;
using System.Xml.Linq;

namespace Schulteisz.AdventOfCode2021.Day15
{
	internal class PathFinder
	{
		private IField _field;
		private int[,] _helpMap;
		private Queue<(int, int)> Coordinate = new Queue<(int, int)>();
        public PathFinder(IField field)
		{
			_field = field;
			_helpMap = new int[_field.FinishPoint.X + 1, _field.FinishPoint.Y + 1];
			for (int i = 0; i <= _field.FinishPoint.X; i++)
			{
				for (int j = 0; j <= _field.FinishPoint.Y; j++)
				{
					_helpMap[i, j] = int.MaxValue;
					Coordinate.Enqueue((i, j));
                }
			}
        }

        public int CountLowestRisk()
		{
			_helpMap[_field.StartPoint.X, _field.StartPoint.Y] = _field.StartPoint.RiskLevel;
			while(Coordinate.TryDequeue(out (int x,int y) result))
			{
				var actualPoint = _field.GetPoint(result.x, result.y);
				
                PreparePoint(actualPoint, actualPoint.Up);
                PreparePoint(actualPoint, actualPoint.Right);
                PreparePoint(actualPoint, actualPoint.Down);
                PreparePoint(actualPoint, actualPoint.Left);
            }
            return _helpMap[_field.FinishPoint.X, _field.FinishPoint.Y] - _field.StartPoint.RiskLevel;
        }

		private void PreparePoint(CavernPoint actualPoint, CavernPoint next)
		{
			if (next is null)
				return;

			int sumPoints = _helpMap[actualPoint.X, actualPoint.Y] + next.RiskLevel;
			if (_helpMap[next.X, next.Y] > sumPoints)
			{
				_helpMap[next.X, next.Y] = sumPoints;
				Coordinate.Enqueue((next.X, next.Y));
			}
		}
	}
}

