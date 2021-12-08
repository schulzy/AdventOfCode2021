namespace Schulteisz.AdventOfCode2021.Day05
{
    internal class VentsFinder
    {
        private List<string> _rawData;
        private List<VentsLocation> _locations = new List<VentsLocation>();
        Dictionary<Point, int> _field = new Dictionary<Point, int>();

        public VentsFinder(List<string> rawData)
        {
            _rawData = rawData;
            foreach (var item in _rawData)
            {
                VentsLocation location = new VentsLocation(item);
                _locations.Add(location);
            }
        }

        public int GetDangerousPointCount(bool onlyPerpendicular)
        {
            foreach (var item in _locations)
            {
                foreach (var point in item.GetMiddlePoints(onlyPerpendicular))
                {
                    //System.Diagnostics.Debug.WriteLine($"X:{point.X}, Y:{point.Y}");
                    if (_field.ContainsKey(point))
                        _field[point]++;
                    else
                        _field.Add(point, 1);
                } 
            }

            int count = 0;
            foreach (var point in _field)
            {
                if (point.Value >= 2)
                    count++;
            }

            return count;
        }
    }
}
