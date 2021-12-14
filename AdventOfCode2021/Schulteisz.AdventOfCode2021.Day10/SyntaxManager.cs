namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class SyntaxManager
    {
        private IList<string> _list;
        private IList<SyntaxLine> _syntaxLine = new List<SyntaxLine>();
        public SyntaxManager(IList<string> list)
        {
            _list = list;
            CreateSyntaxLines();
        }

        public void CreateSyntaxLines()
        {
            foreach (var line in _list)
            {
                _syntaxLine.Add(new SyntaxLine(line));
            }
        }

        public long GetCorruptedScore()
        {
            long score = 0;

            foreach (var item in _syntaxLine)
            {
                if(item.Corrupted)
                    score+=item.GetScore();
            }

            return score;
        }
        public long GetIncompleteScore()
        {
            long score = 0;
            List<long> scores = new List<long>();

            foreach (var item in _syntaxLine)
            {
                if (item.Incomplete)
                    scores.Add(item.GetScore());
            }

            var ordered = scores.OrderBy(x => x).ToList();
            return ordered[(ordered.Count - 1) / 2];
        }

    }
}
