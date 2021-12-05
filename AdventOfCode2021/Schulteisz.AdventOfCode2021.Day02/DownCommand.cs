namespace Schulteisz.AdventOfCode2021.Day02
{
    internal class DownCommand : Command
    {
        private readonly int _value;

        public DownCommand(int value, bool useAim = false) : base(Direction.down, value)
        {
            _value = value;
            UseAim = useAim;
        }

        public override void SetLocation(Point point)
        {
            if(!UseAim)
                point.Depth += _value;
            point.Aim += _value;
        }
    }
}
