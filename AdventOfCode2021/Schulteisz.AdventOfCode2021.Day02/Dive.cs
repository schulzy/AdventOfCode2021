using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day02
{
    public class Dive : IDailyTask
    {
        private IContentParser _contentParser;
        private IList<Command> _commands= new List<Command>();

        public string Name => "Dive!";

        public Dive(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            CommandParser parser = new CommandParser();
            _contentParser.GetLines("Task.txt").ForEach(line => _commands.Add(parser.Create(line)));
            Localizer localizer = new Localizer(_commands);
            localizer.SetFinalLocalization();
            return localizer.Depth * localizer.X;
        }
    }
}
