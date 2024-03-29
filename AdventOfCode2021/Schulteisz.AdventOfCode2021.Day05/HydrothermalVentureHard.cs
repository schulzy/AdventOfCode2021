﻿using Schulteisz.AdventOfCode2021.Interfaces;

namespace Schulteisz.AdventOfCode2021.Day05
{
    public class HydrothermalVentureHard : IDailyTask
    {
        private readonly IContentParser _contentParser;

        public string Name => "Hydrothermal Venture hard";

        public HydrothermalVentureHard(IContentParser contentParser)
        {
            _contentParser = contentParser;
        }

        public long Run()
        {
            VentsFinder ventsFinder = new VentsFinder(_contentParser.GetLines("Task.txt"));
            return ventsFinder.GetDangerousPointCount(false);
        }
    }
}
