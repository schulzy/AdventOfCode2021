using System.Text;

namespace Schulteisz.AdventOfCode2021.Day14
{
    internal class PolimerParser
    {
        StringBuilder _template = new StringBuilder();
        Dictionary<string, string> _codes = new Dictionary<string,string>();
        Dictionary<string, long> _moleculaCount = new Dictionary<string, long>();
        public PolimerParser(IList<string> list)
        {
            _template.Append(list.First());

            foreach (string item in list.Skip(2))
            {
                var pairs = item.Split("->");
                string initPair = pairs[0].Trim();
                _codes.Add(initPair, pairs[1].Trim());
                
            }
            for (int i = 1; i < _template.Length; i++)
            {
                if (_moleculaCount.ContainsKey($"{_template[i - 1]}{_template[i]}"))
                    _moleculaCount[$"{_template[i - 1]}{_template[i]}"]++;
                else
                    _moleculaCount.Add($"{_template[i - 1]}{_template[i]}", 1);
            }
        }

        public void CreatePolimer(int maxIterations)
        {
            Dictionary<string, long> localMolecula;
            for (int iter = 0; iter < maxIterations; iter++)
            {
                localMolecula = new Dictionary<string, long>(_moleculaCount);
                _moleculaCount.Clear();
                foreach (var (molecula, count) in localMolecula)
                {
                    var letter = _codes.GetValueOrDefault(molecula);
                    AddDictionary(localMolecula, $"{molecula[0]}{letter}", count);
                    AddDictionary(localMolecula, $"{letter}{molecula[1]}", count);
                }
                
            }
        }

        private void AddDictionary(Dictionary<string, long> localMolecula, string molecula, long count)
        {
            if (_moleculaCount.ContainsKey(molecula))
                _moleculaCount[molecula] += count;
            else
                _moleculaCount.Add(molecula, count);

        }

        public long GetMaxMinDiff()
        {
            var tempDict = new Dictionary <char, long>();
            foreach (var (molecula, count) in _moleculaCount)
            {
                if (tempDict.ContainsKey(molecula[0]))
                    tempDict[molecula[0]] += count;
                else
                    tempDict.Add(molecula[0], count);
            }
            tempDict[_template.ToString().Last()]++;

            long max = long.MinValue;
            long min = long.MaxValue;

            foreach (var item in tempDict.Values)
            {
                if (max < item)
                    max = item;
                if (min > item)
                    min = item;

            }

            return max - min;
        }
    }
}
