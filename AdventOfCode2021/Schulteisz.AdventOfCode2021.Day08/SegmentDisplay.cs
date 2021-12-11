using System.Text;

namespace Schulteisz.AdventOfCode2021.Day08
{
    internal class SegmentDisplay
    {
        List<string> _input = new List<string>();
        List<string> _output = new List<string>();
        List<char> _segmentNames = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
        Dictionary<int, string> _segmentMap = new Dictionary<int, string>()
        {
            {1,"" },
            {2,"" },
            {3,"" },
            {4,"" },
            {5,"" },
            {6,"" },
            {7,"" },
        };


        Dictionary<int, string> _numbersMap = new Dictionary<int, string>();
        public SegmentDisplay(string line)
        {
            string[] digits = line.Split("|");
            _input = digits[0].Split(" ").ToList();
            _output = digits[1].Split(" ").ToList();
        }

        public int GetOutput()
        {
            SolveCableIssue();

            return FindOutput();
        }

        private int FindOutput()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var number in _output)
            {
                foreach (var map in _numbersMap)
                {
                    bool isEq =string.Equals(string.Concat(number.OrderBy(c=>c)), string.Concat(map.Value.OrderBy(c => c)));
                    if (isEq)
                        sb.Append(map.Key);
                }
            }
            return int.Parse(sb.ToString());
        }

        private void SolveCableIssue()
        {
            var digits = new List<string>(); 
            digits.AddRange(_input);
            digits.AddRange(_output);
            SetEasyDigits(digits);
            FindSegment_2_3(digits);
            FindSegment_1(digits);
            Find_3_Segment_4_7(digits);
            CheckSegmentMap();
            FillNumberMap();
        }

        private void FillNumberMap()
        {
            _numbersMap[0] = _segmentMap[1] + _segmentMap[2] + _segmentMap[3] + _segmentMap[4] + _segmentMap[5] + _segmentMap[6];
            _numbersMap[2] = _segmentMap[1] + _segmentMap[2] + _segmentMap[7] + _segmentMap[5] + _segmentMap[4];
            _numbersMap[5] = _segmentMap[1] + _segmentMap[6] + _segmentMap[7] + _segmentMap[3] + _segmentMap[4];
            _numbersMap[6] = _segmentMap[1] + _segmentMap[3] + _segmentMap[4] + _segmentMap[5] + _segmentMap[6] + _segmentMap[7];
            _numbersMap[9] = _segmentMap[1] + _segmentMap[2] + _segmentMap[3] + _segmentMap[4] + _segmentMap[6] + _segmentMap[7];
        }

        private void CheckSegmentMap()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _segmentMap)
            {
                if (string.IsNullOrEmpty(item.Value))
                    throw new Exception("Segmentmap is not properly initialized");

                sb.Append(item.Value);

            }


            if (sb.ToString().Distinct().ToList().Count != 7)
            {
                throw new Exception("Missing segment");
            }

        }

        private void Find_3_Segment_4_7(List<string> digits)
        {
            HashSet<string> uniqDigits = new HashSet<string>();
            digits.Where(x => x.Length == 5).ToList().ForEach(x =>
            {
                uniqDigits.Add(string.Concat(x.OrderBy(c => c)));
            });

            foreach (var item in uniqDigits)
            {
                if(item.Contains(_segmentMap[2]) && item.Contains(_segmentMap[3]))
                {
                    _numbersMap[3] = item;
                }
            }

            if (!string.IsNullOrEmpty(_numbersMap[3]))
            {
                var intersect_3_4 = _numbersMap[3].Intersect(_numbersMap[4]).ToList();
                intersect_3_4.Remove((_segmentMap[2])[0]);
                intersect_3_4.Remove((_segmentMap[3])[0]);
                _segmentMap[7] = intersect_3_4.First().ToString();
                foreach (var number4 in _numbersMap[4])
                {
                    if (!_segmentMap.ContainsValue(number4.ToString()))
                    {
                        _segmentMap[6] = number4.ToString();
                    }
                }

                foreach (var number3 in _numbersMap[3])
                {
                    if (!_segmentMap.ContainsValue(number3.ToString()))
                    {
                        _segmentMap[4] = number3.ToString();
                    }
                }
                int count = 0;
                foreach (var item in _segmentMap)
                {
                    if (string.IsNullOrEmpty(item.Value))
                        count++;
                }
                if (count > 1)
                    throw new Exception("Too many missing number");

                foreach (var item in _segmentNames)
                {
                    if(!_segmentMap.ContainsValue(item.ToString()))
                        _segmentMap[5] = item.ToString();
                }
               
            }
        }

        private void SetEasyDigits(List<string> digits)
        {
            _numbersMap[1] = string.Concat(digits.Where(x => x.Length == 2)?.FirstOrDefault().OrderBy(x => x));
            _numbersMap[7] = string.Concat(digits.Where(x => x.Length == 3)?.FirstOrDefault().OrderBy(x=>x));
            _numbersMap[4] = string.Concat(digits.Where(x => x.Length == 4)?.FirstOrDefault().OrderBy(x=>x));
            _numbersMap[8] = string.Concat(digits.Where(x => x.Length == 7)?.FirstOrDefault().OrderBy(x=>x));
        }

        private void FindSegment_1(List<string> digits)
        {
            HashSet<string> uniqDigits = new HashSet<string>();
            digits.Where(x => x.Length == 3).ToList().ForEach(x =>
            {
                foreach (char item in x)
                {
                    uniqDigits.Add(item.ToString());
                }
            });
            if (uniqDigits.Count != 3)
                throw new Exception("Issue with segment 1");

            uniqDigits.Remove(_segmentMap[2]);
            uniqDigits.Remove(_segmentMap[3]);
            _segmentMap[1] = uniqDigits.First();
        }

        private void FindSegment_2_3(List<string> digits)
        {
            HashSet<string> uniqDigits = new HashSet<string>();
            digits.Where(x => x.Length == 2).ToList().ForEach(x =>
            {
                foreach (char item in x)
                {
                    uniqDigits.Add(item.ToString());
                }
            });
            if (uniqDigits.Count != 2)
                throw new Exception("Issue with segment 2 and 3");

            var sixDigitlength = digits.Where(x => x.Length == 6);
            var number6 = sixDigitlength.FirstOrDefault(x => !x.Contains(uniqDigits.First()) || !x.Contains(uniqDigits.Last()));

            if (number6.Contains(uniqDigits.First()))
            {
                _segmentMap[2] = uniqDigits.Last();
                _segmentMap[3] = uniqDigits.First();
            }
            else
            {
                _segmentMap[2] = uniqDigits.First();
                _segmentMap[3] = uniqDigits.Last();
            }
        }

        public long FindOutput_1_4_7_8()
        {
            long count = 0;
            foreach (var item in _output)
            {
                int length = item.Length;
                if (length == 2 || length == 3 || length == 4 || length == 7)
                    count++;
            }
            return count;
        }
    }
}
