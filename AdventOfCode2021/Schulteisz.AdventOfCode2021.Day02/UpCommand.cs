namespace Schulteisz.AdventOfCode2021.Day02
{
    internal class UpCommand : Command
    {
        private readonly int _value;

        public UpCommand(int value, bool useAim = false) : base(Direction.up,value)
        {
            _value = value;
            UseAim = useAim;
        }

        public override void SetLocation(Point point)
        {
            if (!UseAim)
                point.Depth -= _value;

            if (point.Depth < 0)
                throw new ArgumentOutOfRangeException("Depth cannot be negative");
            point.Aim -= _value;
        }
    }
}
