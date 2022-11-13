using Schulteisz.AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    public class ChitonHard : IDailyTask
    {
        private IContentParser _contentParser;

        public ChitonHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Chiton Hard";

        public long Run()
        {
            IField field = new Field();
            field.GeneratePoints(_contentParser.GetLines("Task.txt"));
            field.ExtendField(5);
            PathFinder pathFinder = new PathFinder(field);
            
            return pathFinder.CountLowestRisk();
        }
    }
}
