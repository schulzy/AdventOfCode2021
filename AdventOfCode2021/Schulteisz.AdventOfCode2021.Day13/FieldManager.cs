using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulteisz.AdventOfCode2021.Day13
{
    internal class FieldManager
    {
        private readonly List<(int x, int y)> _list;
        private readonly Queue<(char axis, int index)> _instruction;
        private int _xMax = 0;
        private int _yMax = 0;
        private char[,] _field;

        public FieldManager(List<string> lines)
        {
            _list = new List<(int, int)>();
            _instruction = new Queue<(char,int)>();
            bool secondPart = false;
            foreach (var item in lines)
            {
                if (string.IsNullOrEmpty(item))
                {
                    secondPart = true;
                    continue;
                }

                if (!secondPart)
                {
                    var numbers = item.Split(',');
                    int x = int.Parse(numbers[0]);
                    if (x > _xMax)
                        _xMax = x;
                    
                    int y = int.Parse(numbers[1]);
                    if(y > _yMax)
                        _yMax = y;

                    _list.Add((x, y));
                }
                else
                {
                    var value = item.Split("=");
                    _instruction.Enqueue((value[0].Last(), int.Parse(value[1])));
                }
            }
            SetInitField();
        }

        internal long PrintResult()
        {
            for (int x = 0; x < _field.GetLength(0); x++)
            {
                for (int y = 0; y < _field.GetLength(1); y++)
                {
                    Debug.Write(_field[x,y]);
                }
                Debug.WriteLine("");
            }
            return 0;
        }

        internal long GetPointCount()
        {
            long counter = 0;
            for (int x = 0; x < _field.GetLength(0); x++)
            {
                for (int y = 0; y < _field.GetLength(1); y++)
                {
                    if (_field[x, y] == '#')
                        counter++;
                }
            }
            return counter;
        }

        public bool Fold()
        {
            if (!_instruction.TryDequeue(out (char axis, int index) instuction))
                return false;

            switch (instuction.axis)
            {
                case 'x':
                    FoldX(instuction.index);
                    break;
                case 'y':
                    FoldY(instuction.index);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("This axis does not exist");
            }

            return true;
        }

        private void FoldY(int index)
        {
            char[,] foldedField = new char[_field.GetLength(0), index];
            for (int x = 0; x < _field.GetLength(0); x++)
            {
                for (int y = 0; y < index; y++)
                {
                    foldedField[x, y] = GetPointValue(_field[x, y], _field[x, _field.GetLength(1)- 1 - y]);
                }
            }
            _field = foldedField;
        }

        private char GetPointValue(char v1, char v2)
        {
            if (v1 == '#' || v2 == '#')
                return '#';

            return '.';
        }

        private void FoldX(int index)
        {
            char[,] foldedField = new char[index, _field.GetLength(1)];
            for (int x = 0; x <  index; x++)
            {
                for (int y = 0; y < _field.GetLength(1); y++)
                {
                    foldedField[x, y] = GetPointValue(_field[x, y], _field[_field.GetLength(0) - 1 - x, y]);
                }
            }
            _field = foldedField;
        }

        private void SetInitField()
        {
            _field = new char[_xMax + 1, _yMax + 1];
            for (int x = 0; x < _xMax; x++)
            {
                for (int y = 0; y < _yMax; y++)
                {
                    _field[x, y] = '.';
                }
            }
            
            _list.ForEach(item => _field[item.x, item.y] = '#');
        }
    }
}
