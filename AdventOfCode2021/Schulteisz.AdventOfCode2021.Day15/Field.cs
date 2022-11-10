using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    internal class Field : IField
    {
        private CavernPoint _actualPoint;
        Dictionary<(int, int), CavernPoint> _cavernPoints = new Dictionary<(int, int), CavernPoint>();
        public CavernPoint StartPoint { get; private set; }
        public CavernPoint FinshedPoint { get; private set; }
        public void GeneratePoints(IList<string> lines)
        {
            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    _cavernPoints.Add((x, y), new CavernPoint(x, y, int.Parse(lines[y][x].ToString()), this));
                }
            }

            SetStart(0, 0);
            
            
            _cavernPoints[(lines[0].Length - 1, lines.Count - 1)].State = State.Finish;
            foreach (var (point, item) in _cavernPoints)
            {
                item.SetNeighbours();
            }
        }

        private void SetStart(int x, int y)
        {
            StartPoint = _cavernPoints[(x, y)];
            StartPoint.State = State.Start;
        }

        private void SetFinished(int x, int y)
        {
            FinshedPoint = _cavernPoints[(x, y)];
            FinshedPoint.State = State.Finish;
        }

        public void FindExit()
        {
            //if (registerManager.Actual.CavernPointsHash.Contains((X, Y)))
            //    return;
            //if (registerManager.Append(this))
            //{
            //    if (Up is not null)
            //        Up.FindExit(registerManager);

            //    if (Down is not null)
            //        Down.FindExit(registerManager);

            //    if (Left is not null)
            //        Left.FindExit(registerManager);

            //    if (Right is not null)
            //        Right.FindExit(registerManager);

            //}
            //registerManager.Remove();
        }

        public CavernPoint GetPoint(int x, int y)
        {
            return _cavernPoints.GetValueOrDefault((x, y));
        }
    }
}
