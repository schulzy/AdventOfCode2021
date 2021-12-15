namespace Schulteisz.AdventOfCode2021.Day11
{
    internal class Octopus
    {
        private int _energy;
        private bool _flashed = false;
        private readonly OctopusField _octopusField;
        private List<Octopus> _activeNeighbours = new List<Octopus>();

        private int X { get { return Point.X; } }
        private int Y { get { return Point.Y; } }

        public Octopus Up { get; private set; }
        public Octopus Down { get; private set; }
        public Octopus Left { get; private set; }
        public Octopus Right { get; private set; }
        public Octopus UpLeft { get; private set; }
        public Octopus UpRight { get; private set; }
        public Octopus DownLeft { get; private set; }
        public Octopus DownRight { get; private set; }
        public bool Flashed { get { return _flashed; } }

        public Point Point { get; }

        public int Energy
        {
            get { return _energy; }
            set 
            {
                _energy = value;
                if (!_flashed && _energy >= 10)
                    CallFlash();
                
            }
        }

        public Octopus(int x, int y, int startEnergy, OctopusField octopusField)
        {
            Point = new Point(x, y);
            
            Energy = startEnergy;
            _octopusField = octopusField;
        }

        public void SetNeighbours()
        {
            UpLeft = _octopusField.GetOctopus(X - 1, Y - 1);
            if (UpLeft != null)
                _activeNeighbours.Add(UpLeft);

            Up = _octopusField.GetOctopus(X, Y - 1);
            if (Up != null)
                _activeNeighbours.Add(Up);

            UpRight = _octopusField.GetOctopus(X + 1, Y - 1);
            if (UpRight != null)
                _activeNeighbours.Add(UpRight);

            Left = _octopusField.GetOctopus(X - 1, Y);
            if (Left != null)
                _activeNeighbours.Add(Left);

            Right = _octopusField.GetOctopus(X + 1, Y);
            if (Right != null)
                _activeNeighbours.Add(Right);

            DownLeft = _octopusField.GetOctopus(X - 1, Y + 1);
            if (DownLeft != null)
                _activeNeighbours.Add(DownLeft);

            Down = _octopusField.GetOctopus(X, Y + 1);
            if (Down != null)
                _activeNeighbours.Add(Down);

            DownRight = _octopusField.GetOctopus(X+1, Y + 1);
            if (DownRight != null)
                _activeNeighbours.Add(DownRight);
        }

        public void SetNextStep()
        {
            _flashed = false;
            if(_energy >= 10)
                _energy = 0;
        }

        private void CallFlash()
        {
            _flashed = true;
            _octopusField.SetFlash();
            foreach (var item in _activeNeighbours)
            {
                item.Energy++;
            }
        }
    }
}
