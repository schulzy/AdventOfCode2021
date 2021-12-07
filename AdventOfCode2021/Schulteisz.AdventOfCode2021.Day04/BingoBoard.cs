namespace Schulteisz.AdventOfCode2021.Day04
{
    internal class BingoBoard
    {
        private readonly List<int> _numbers;
        private readonly List<bool> _marked;
        private int _square = 0;

        public bool IsValid { get; set; } = true;
        public BingoBoard(List<int> numbers)
        {
            _numbers = numbers;
            for(int i=1; i<=10; i++)
            {
                if(_numbers.Count / i == i)
                {
                    _square = i;
                    break;
                }
            }
            _marked = new List<bool>(new bool[_numbers.Count]);
            if (_square == 0)
                throw new ArgumentException($"{nameof(numbers)} property has not been initialized");
        }

        public bool Draw(int number)
        {
            int index = _numbers.IndexOf(number);
            if (index < 0)
                return false;

            _marked[index] = true;
            return CheckWins();
        }

        public int NotMarkedSum()
        {
            int sum = 0;
            for (int i = 0; i < _marked.Count; i++)
            {
                if (_marked[i] == false)
                    sum += _numbers[i];
            }

            return sum;
        }

        private bool CheckWins()
        {
            bool isWinner;
            for (int i = 0; i < _square; i++)
            {
                isWinner = true;
                for (int j = 0; j < _square; j++)
                {
                    var index = i + (j * _square);
                    isWinner &= _marked[index];
                }
                if (isWinner)
                    return true;
            }

            for (int i = 0; i < _square; i++)
            {
                isWinner = true;
                for (int j = 0; j < _square; j++)
                {
                    var index = (i * _square) + j;
                    isWinner &= _marked[index];
                }
                if (isWinner)
                    return true;
            }

            return false;
        }
    }
}
