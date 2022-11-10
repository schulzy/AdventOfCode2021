using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    internal class Register
    {
        long _pointsum = 0;
        public Stack<CavernPoint> CavernPoints { get; set; } = new Stack<CavernPoint>();
        public HashSet<(int, int)> CavernPointsHash { get; set; } = new HashSet<(int, int)>();
        public long PointsSum
        {
            get
            {
                return _pointsum;
               
            } 
        }

        public void Add(CavernPoint point)
        {
            CavernPoints.Push(point);
            CavernPointsHash.Add((point.X, point.Y));
            _pointsum += point.RiskLevel;
        }

        public void RemoveLast()
        {
            var element = CavernPoints.Pop();
            CavernPointsHash.Remove((element.X, element.Y));
            _pointsum -= element.RiskLevel;
        }

        public void Clear()
        {
            CavernPoints.Clear();
            CavernPointsHash.Clear();
            _pointsum = 0;
        }
    }
}
