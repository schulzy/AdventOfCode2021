namespace Schulteisz.AdventOfCode2021.Day04
{
    internal class BingoManager
    {
        private List<int> _drawnList = new List<int>();
        private List<BingoBoard> _boardList = new List<BingoBoard>();
        public BingoManager(List<string> lines)
        {
            if(lines == null)
                throw new ArgumentNullException(nameof(lines));

            CreateDrawnList(lines.First());
            CreateTables(lines.Skip(2));
        }

        public IEnumerable<long> GetResult()
        {
            long result = -1;
            foreach (int drawn in _drawnList)
            {
                foreach (var board in _boardList)
                {
                    if (board.Draw(drawn) && board.IsValid)
                    {
                        board.IsValid = false;
                        result = board.NotMarkedSum() * drawn;
                        yield return result;
                    }
                }
            }

            yield return result;
        }

        private void CreateTables(IEnumerable<string> boards)
        {
            List<int> board = new List<int>();
            foreach (var item in boards)
            {
                
                if(string.IsNullOrEmpty(item))
                {
                    _boardList.Add(new BingoBoard(board));
                    board = new List<int>();
                }
                System.Text.RegularExpressions.Regex.Split(item, @" +").ToList().
                    ForEach(x =>
                    {
                        if (!string.IsNullOrEmpty(x))
                            board.Add(int.Parse(x));
                    });
            }

            _boardList.Add(new BingoBoard(board));
        }

        private void CreateDrawnList(string drawnNumbers)
        {
            drawnNumbers.Split(",").ToList().ForEach(x => _drawnList.Add(int.Parse(x)));
        }
    }
}
