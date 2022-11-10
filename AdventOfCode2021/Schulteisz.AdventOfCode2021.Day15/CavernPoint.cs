using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    internal class CavernPoint
    {
        private IField _field;
        private int _hash = 0;

        public State State { get; set; } = State.Middle;
        public int X { get; }
        public int Y { get; }

        public int RiskLevel { get; }

        public CavernPoint Up { get; private set; }
        public CavernPoint Down { get; private set; }
        public CavernPoint Left { get; private set; }
        public CavernPoint Right { get; private set; }
        public CavernPoint(int x, int y, int risklevel, IField field)
        {
            X = x;
            Y = y;
            RiskLevel = risklevel;
            _field = field;
        }

        public void SetNeighbours()
        {
            Up = _field.GetPoint(X, Y - 1);
            Down = _field.GetPoint(X, Y + 1);
            Left = _field.GetPoint(X - 1, Y);
            Right = _field.GetPoint(X + 1, Y);
        }

        public override int GetHashCode()
        {
            if (_hash != 0)
                return _hash;
            _hash = 103;
            _hash = (_hash * 127) + X.GetHashCode();
            _hash = (_hash * 127) + Y.GetHashCode();
            if (_hash < 0)
                ;
            return _hash;
        }

        public void FindExit(RegisterManager registerManager)
        {
            if (registerManager.Actual.CavernPointsHash.Contains((X,Y)))
                return;
            if (registerManager.Append(this))
            {
                if (Up is not null)
                    Up.FindExit(registerManager);

                if (Down is not null)
                    Down.FindExit(registerManager);

                if (Left is not null)
                    Left.FindExit(registerManager);

                if (Right is not null)
                    Right.FindExit(registerManager);

            }
            registerManager.Remove();
        }

        public override bool Equals(object? obj)
        {
            return obj?.GetHashCode() == GetHashCode();
        }
    }
}
