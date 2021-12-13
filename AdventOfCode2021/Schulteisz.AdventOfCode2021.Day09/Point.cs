namespace Schulteisz.AdventOfCode2021.Day09
{
    internal class Point
    {
        private CaveCreator _caveCreator;
        private bool? _isLowest = null;
        private bool _checkedBasin = false;
        private Basin _basin;
        public int X { get; set; }
        public int Y { get; set; }
        public int Value { get; set; }

        public Point Up { get; set; }
        public Point Down { get; set; }
        public Point Left { get; set; }
        public Point Right { get; set; }
        public bool IsLowest 
        { 
            get
            {
                if (_isLowest != null)
                    return _isLowest.Value;

                bool isLowest = true;
                if (Up is not null)
                    isLowest &= Value < Up?.Value;

                if (Down is not null)
                    isLowest &= Value < Down?.Value;

                if(Left is not null)
                    isLowest &= Value < Left?.Value;

                if (Right is not null)
                    isLowest &= Value < Right?.Value;

                _isLowest = isLowest;
                if (isLowest)
                {
                    _basin = new Basin(this);
                    FindBasin(_basin);
                }

                return isLowest;
            } 
        }

        private void FindBasin(Basin basin)
        {
            if (Value < 9 && !_checkedBasin)
            {
                _checkedBasin = true;
                basin.AddBasin(this);
                Up?.FindBasin(basin);
                Down?.FindBasin(basin);
                Left?.FindBasin(basin);
                Right?.FindBasin(basin);
            }
            _checkedBasin = true;
        }

        internal int BasinCount()
        {
            return _basin.Count();
        }

        public Point(int x, int y, int value, CaveCreator caveCreator)
        {
            X = x;
            Y = y;
            Value = value;
            _caveCreator = caveCreator;
        }

        public void SetNeighbours()
        {
            SetUpNeighbour();
            SetDownNeighbour();
            SetLeftNeighbour();
            SetRightNeighbours();
        }

        private void SetRightNeighbours()
        {
            if (Right is null)
            {
                Right = _caveCreator.GetPoint(X + 1, Y);
                if (Right is not null)
                    Right.SetLeftNeighbour(this);
            }
        }

        private void SetLeftNeighbour()
        {
            if (Left is null)
            {
                Left = _caveCreator.GetPoint(X - 1, Y);
                if (Left is not null)
                    Left.SetRightNeighbour(this);
            }
        }

        private void SetDownNeighbour()
        {
            if (Down is null)
            {
                Down = _caveCreator.GetPoint(X, Y + 1);
                if (Down is not null)
                    Down.SetUpNeighbour(this);
            }
        }

        private void SetUpNeighbour()
        {
            if (Up is null)
            {
                Up = _caveCreator.GetPoint(X, Y - 1);
                if(Up is not null)
                    Up.SetDownNeighbour(this);
            }
        }

        internal void SetLeftNeighbour(Point point)
        {
            if (Left is null)
                Left = point;
            else if (Left != point)
                throw new Exception("Not equals points");
        }

        internal void SetRightNeighbour(Point point)
        {
            if (Right is null)
                Right = point;
            else if (Right != point)
                throw new Exception("Not equals points");
        }

        internal void SetUpNeighbour(Point point)
        {
            if (Up is null)
                Up = point;
            else if (Up != point)
                throw new Exception("Not equals points");
        }

        internal void SetDownNeighbour(Point point)
        {
            if (Down is null)
                Down = point;
            else if (Down != point)
                throw new Exception("Not equals points");
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