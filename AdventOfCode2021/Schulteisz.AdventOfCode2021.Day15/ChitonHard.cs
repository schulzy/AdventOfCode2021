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
        private IContentParser contentParser;

        public ChitonHard(IContentParser contentParser)
        {
            this.contentParser = contentParser;
        }

        public string Name => "Chiton Hard";

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
