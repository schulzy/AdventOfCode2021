namespace Schulteisz.AdventOfCode2021.Day02
{
    internal abstract class Command
    {
        public Direction Direction { get; set; }
        public int Value { get; set; }
        protected bool UseAim { get; set; } = false;

        public Command(Direction direction, int value)
        {
            Direction = direction;
            Value = value;
        }

        public abstract void SetLocation(Point point);
    }
}
