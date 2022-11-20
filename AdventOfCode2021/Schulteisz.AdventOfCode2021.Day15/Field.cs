using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    internal class Field : IField
    {
        Dictionary<(int, int), CavernPoint> _cavernPoints = new Dictionary<(int, int), CavernPoint>();
        public CavernPoint StartPoint { get; private set; }
        public CavernPoint FinishPoint { get; private set; }
        public int [,] SimpleMap { get; private set; }
        public void GeneratePoints(IList<string> lines)
        {
            int yMax = lines.Count;
            int xMax = lines[0].Length;
            SimpleMap = new int[xMax, yMax];
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    int riskLevel = int.Parse(lines[y][x].ToString());
                    SimpleMap[x, y] = riskLevel;
                    _cavernPoints.Add((x, y), new CavernPoint(x, y, riskLevel, this));
                }
            }

            SetStart(0, 0);
            SetFinished(xMax - 1, yMax - 1);
            
            _cavernPoints[(lines[0].Length - 1, lines.Count - 1)].State = State.Finish;
            foreach (var (point, item) in _cavernPoints)
            {
                item.SetNeighbours();
            }
        }

        public void ExtendField(int multiplier)
        {
            int xMax = SimpleMap.GetLength(0) * multiplier;
            int yMax = SimpleMap.GetLength(1) * multiplier;
            int[,] extendedMap = new int[xMax, yMax];
            _cavernPoints.Clear();
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    int riskLevel = GetRiskLevel(x, y);
                    extendedMap[x, y] = riskLevel;
                    _cavernPoints.Add((x, y), new CavernPoint(x, y, riskLevel, this));
                }
            }

            SetStart(0, 0);
            SetFinished(xMax - 1, yMax - 1);

            foreach (var (point, item) in _cavernPoints)
            {
                item.SetNeighbours();
            }
        }

        private int GetRiskLevel(int x, int y)
        {
            int xMax = SimpleMap.GetLength(0);
            int yMax = SimpleMap.GetLength(1);
            int tempX = x;
            int tempY = y;
            if (x < xMax && y < yMax)
                return SimpleMap[x, y];

            if (x >= xMax)
                return GetNextValue(_cavernPoints[(x - xMax, y)].RiskLevel);

            if (y >= yMax)
                return GetNextValue(_cavernPoints[(x, y-yMax)].RiskLevel);

            throw new ArgumentException("Something is wrong with the values");
        }

        private int GetNextValue(int riskLevel)
        {
            if (riskLevel == 9)
                return 1;

            return ++riskLevel;
        }

        public CavernPoint GetPoint(int x, int y)
        {
            return _cavernPoints.GetValueOrDefault((x, y));
        }

        private void SetStart(int x, int y)
        {
            StartPoint = _cavernPoints[(x, y)];
            StartPoint.State = State.Start;
        }

        private void SetFinished(int x, int y)
        {
            FinishPoint = _cavernPoints[(x, y)];
            FinishPoint.State = State.Finish;
        }
    }
}
