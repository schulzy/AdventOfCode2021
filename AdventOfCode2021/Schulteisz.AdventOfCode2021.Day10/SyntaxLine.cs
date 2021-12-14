namespace Schulteisz.AdventOfCode2021.Day10
{
    internal class SyntaxLine
    {
        private IList<ISymbol> _symbols = new List<ISymbol>();
        private bool? _corrupted;
        private bool? _incomplete;
        private int _corruptedScore = 0;
        private long _incompleteScore = 0;
        public bool Corrupted
        { 
            get 
            {
                if (_corrupted != null)
                    return _corrupted.Value;

                Validation();
                return _corrupted.HasValue ? _corrupted.Value : throw new Exception("Init failed");
            }
        }

        public bool Incomplete
        {
            get
            {
                if(_incomplete!=null)
                    return _incomplete.Value;

                IncompleteCheck();
                return _incomplete.HasValue ? _incomplete.Value : throw new Exception("Incomplete validation fail");
            }
        }

        private void IncompleteCheck()
        {
            Stack<ISymbol> stack = new Stack<ISymbol>();
            foreach (ISymbol symbol in _symbols)
            {
                if (symbol is IOpenSymbol)
                    stack.Push(symbol);
                else if (symbol is ICloseSymbol)
                {
                    var pair = stack.Pop();
                    if (pair.PairType != symbol.GetType())
                    {
                        _corrupted = true;
                        _incomplete = false;
                        return;
                    }
                }
            }

            if(stack.Count>0)
            {
                _incomplete = true;
                while (stack.TryPop(out var symbol))
                {
                    if (symbol is not IOpenSymbol)
                        throw new ArgumentException("Not open symbol has come");
                    _incompleteScore = (_incompleteScore * 5) + ((symbol as IOpenSymbol).IncompleteScore);
                }

                return;
            }

            _incomplete = false;
        }

        internal long GetScore()
        {
            if (Corrupted)
                return _corruptedScore;

            if (Incomplete)
                return _incompleteScore;

            return 0;
        }

        private void Validation()
        {
            Stack<ISymbol> stack = new Stack<ISymbol>();
            foreach (ISymbol symbol in _symbols)
            {
                if (symbol is IOpenSymbol)
                    stack.Push(symbol);
                else if (symbol is ICloseSymbol)
                {
                    var pair = stack.Pop();
                    if(pair.PairType != symbol.GetType())
                    {
                        _corrupted = true;
                        _corruptedScore = (symbol as ICloseSymbol).CorruptedScore;
                        return;
                    }
                }
            }

            _corrupted = false;
        }

        public SyntaxLine(string symbols)
        {
            ParseSymbols(symbols);
        }

        

        private void ParseSymbols(string symbols)
        {
            foreach (var symbol in symbols)
            {
                switch (symbol)
                {
                    case '{':
                        _symbols.Add(new CurlyBracketOpen());
                        break;
                    case '}':
                        _symbols.Add(new CurlyBracketClose());
                        break;
                    case '(':
                        _symbols.Add(new ParenthesesOpen());
                        break;
                    case ')':
                        _symbols.Add(new ParenthesesClose());
                        break;
                    case '<':
                        _symbols.Add(new AngleBracketOpen());
                        break;
                    case '>':
                        _symbols.Add(new AngleBracketClose());
                        break;
                    case '[':
                        _symbols.Add(new SquareBracketOpen());
                        break;
                    case ']':
                        _symbols.Add(new SquareBracketClose());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Symbol is unknown: {symbol}");
                }
            }
        }
    }
    
    
}
