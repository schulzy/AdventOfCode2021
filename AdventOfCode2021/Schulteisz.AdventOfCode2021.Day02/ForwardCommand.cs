namespace Schulteisz.AdventOfCode2021.Day02
{
    internal class ForwardCommand : Command
    {
        private readonly int _value;

        public ForwardCommand(int value, bool useAim = false) : base(Direction.forward, value)
        {
            _value = value;
            UseAim = useAim;
        }

        public override void SetLocation(Point point)
        {
            point.X = point.X + _value;
            if(point.Aim != 0 && UseAim)
            {
                point.Depth += point.Aim * _value;
            }
        }
    }
}
