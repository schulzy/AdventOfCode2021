using Schulteisz.AdventOfCode2021.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day15
{
    public class Chiton : IDailyTask
    {
        private IContentParser _contentParser;

        public Chiton(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public string Name => "Chiton";

        public long Run()
        {
            IField field = new Field();
            field.GeneratePoints(_contentParser.GetLines("Task.txt"));
            PathFinder pathFinder = new PathFinder(field);


            return pathFinder.CountLowestRisk();
        }
    }
}
