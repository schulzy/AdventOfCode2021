using System.Text;

namespace Schulteisz.AdventOfCode2021.Day03
{
    internal class BinaryCodeAnalyzer
    {
        private int _gammaRate = int.MinValue;
        private int _epsilonRate = int.MinValue;    
        private List<List<int>> _columns = new List<List<int>>();
        public List<string> Codes { get; } = new List<string>();
        public void AddCode(string code)
        {
            Codes.Add(code);
            int counter = 0;
            foreach (var bit in code)
            {
                if (_columns.Count <= counter)
                    _columns.Add(new List<int>());
                _columns[counter].Add(int.Parse(bit.ToString()));
                counter++;
            }
        }

        internal int GetCo2Rate()
        {
            List<List<int>> tempColumns = CreateDeepCopyFromColumns();

            foreach (var item in tempColumns)
            {
                int count = item.Count;
                int half = count / 2;
                int result = count - item.FindAll(x => x == 1).Count <= half ? 1 : 0;
                int lastIndex = item.FindLastIndex(x => x == result);
                while (lastIndex >= 0)
                {
                    foreach (var subItems in tempColumns)
                    {
                        subItems.RemoveAt(lastIndex);
                    }
                    lastIndex = item.FindLastIndex(x => x == result);
                    if (item.Count == 1)
                        return CalculateDecimalValue(tempColumns);
                }
            }

            return 0;
        }

        public int GetOxygenRate()
        {
            List<List<int>> tempColumns = CreateDeepCopyFromColumns();

            foreach (var item in tempColumns)
            {
                int count = item.Count;
                int half = count / 2;
                int result = count - item.FindAll(x => x == 1).Count <= half ? 0 : 1;
                int lastIndex = item.FindLastIndex(x => x == result);
                while (lastIndex >= 0)
                {
                    foreach (var subItems in tempColumns)
                    {
                        subItems.RemoveAt(lastIndex);
                    }
                    lastIndex = item.FindLastIndex(x => x == result);
                    if (item.Count == 1)
                        return CalculateDecimalValue(tempColumns);
                } 
            }

            return 0;
        }
        
        public int GetGammaRate()
        {
            if (_gammaRate != int.MinValue)
                return _gammaRate;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in _columns)
            {
                int count = item.Count;
                int half = count / 2;
                stringBuilder.Append( count - item.FindAll(x => x == 1).Count < half ? "1" : "0");
            }
            _gammaRate = Convert.ToInt32(stringBuilder.ToString(), 2);
            return _gammaRate;
        }

        public int GetEpsilonRate()
        {
            if (_epsilonRate != int.MinValue)
                return _epsilonRate;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in _columns)
            {
                int count = item.Count;
                int half = count / 2;
                stringBuilder.Append(count - item.FindAll(x => x == 1).Count < half ? "0" : "1");
            }
            _epsilonRate = Convert.ToInt32(stringBuilder.ToString(), 2);
            return _epsilonRate;
        }

        private int CalculateDecimalValue(List<List<int>> tempColumns)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in tempColumns)
            {
                stringBuilder.Append(item.First());
            }

            return Convert.ToInt32(stringBuilder.ToString(), 2);
        }

        private List<List<int>> CreateDeepCopyFromColumns()
        {
            var tempColumns = new List<List<int>>();
            foreach (var item in _columns)
            {
                tempColumns.Add(new List<int>(item));
            }
            return tempColumns;
        }
    }
}
