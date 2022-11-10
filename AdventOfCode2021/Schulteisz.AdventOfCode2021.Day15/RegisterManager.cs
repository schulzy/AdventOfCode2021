using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    internal class RegisterManager
    {
        public Register Actual { get; set; } = new Register();
        public Register BestRoute { get; set; } = new Register();
        public bool Append(CavernPoint point)
        {
            Actual.Add(point);

            if (point.State == State.Finish)
            {
                CalculateRoute();
                return false;
            }
            long bestPointsum = BestRoute.PointsSum;
            if (Actual.PointsSum > bestPointsum && bestPointsum > 0) 
                return false;
            return true;
        }

        public void Remove()
        {
            Actual.RemoveLast();
        }

        private void CalculateRoute()
        {
            if (BestRoute.PointsSum == 0 || BestRoute.PointsSum > Actual.PointsSum)
            {
                BestRoute.Clear();
                foreach (var item in Actual.CavernPoints)
                {
                    BestRoute.Add(item);
                }
            }
        }
        
    }
}
