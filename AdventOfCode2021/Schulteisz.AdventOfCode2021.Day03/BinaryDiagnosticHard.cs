using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day03
{
    public class BinaryDiagnosticHard : IDailyTask
    {
        private IContentParser _contentParser;

        public string Name => "Binary Diagnostic";

        public BinaryDiagnosticHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            BinaryCodeAnalyzer binaryCodeAnalyzer = new BinaryCodeAnalyzer();
            _contentParser.GetLines("Task.txt").ForEach(line => binaryCodeAnalyzer.AddCode(line));
            var oxigenRate = binaryCodeAnalyzer.GetOxygenRate();
            var Co2Rate = binaryCodeAnalyzer.GetCo2Rate();
            return oxigenRate * Co2Rate;
        }
    }
}
