namespace Schulteisz.AdventOfCode2021.Day08
{
    internal class SegmentDisplayManager
    {
        private List<SegmentDisplay> _displays = new List<SegmentDisplay>();

        public SegmentDisplayManager(List<string> lines)
        {
            foreach (var line in lines)
            {
                _displays.Add(new SegmentDisplay(line));
            }

        }

        internal long GetEasyNumbers()
        {
            long count = 0;
            _displays.ForEach(display => count += display.FindOutput_1_4_7_8());
            return count;
        }

        internal long GetOutputSum()
        {
            long count = 0;
            _displays.ForEach(display => count += display.GetOutput());
            return count;
        }
    }
}
