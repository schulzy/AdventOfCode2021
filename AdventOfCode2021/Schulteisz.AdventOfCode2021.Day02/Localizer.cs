namespace Schulteisz.AdventOfCode2021.Day02
{
    internal class Localizer
    {
        private readonly IList<Command> _commands = new List<Command>();
        private readonly Point _point = new Point();

        public int Depth { get { return _point.Depth; } }
        public int X { get { return _point.X; } }

        public Localizer(IList<Command> commands)
        {
            _commands = commands;
        }

        public void SetFinalLocalization()
        {
            foreach (var command in _commands)
            {
                command.SetLocation(_point);
            }
        }
    }
}
