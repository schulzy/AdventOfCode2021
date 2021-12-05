namespace Schulteisz.AdventOfCode2021.Day02
{
    internal class CommandParser
    {
        public Command Create(string line, bool useAim = false)
        {
            string[] chunks = line.Split(new char[] { ' ' });
            if (!Enum.TryParse(chunks[0], out Direction direction))
                throw new ArgumentException("Enum parse failed");
            if (!int.TryParse(chunks[1], out int value))
                throw new ArgumentException("Value parse failed");

            switch (direction)
            {
                case Direction.forward:
                    return new ForwardCommand(value, useAim);
                case Direction.down:
                    return new DownCommand(value, useAim); ;
                case Direction.up:
                    return new UpCommand(value, useAim);
                default:
                    throw new ArgumentOutOfRangeException("Not valid enum value");
            }
        }
    }
}
