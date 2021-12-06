using Schulteisz.AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day03
{
    public class BinaryDiagnostic : IDailyTask
    {
        private IContentParser _contentParser;

        public string Name => "Binary Diagnostic";

        public BinaryDiagnostic(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            BinaryCodeAnalyzer binaryCodeAnalyzer = new BinaryCodeAnalyzer();
            _contentParser.GetLines("Task.txt").ForEach(line => binaryCodeAnalyzer.AddCode(line));
            var epsilon = binaryCodeAnalyzer.GetEpsilonRate();
            var gamma = binaryCodeAnalyzer.GetGammaRate();
            return epsilon * gamma;
        }
    }
}
