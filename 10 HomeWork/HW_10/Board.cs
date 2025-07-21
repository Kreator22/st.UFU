using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    enum Piece
    {
        Empty,
        Cross,
        Zero
    }

    class Board
    {
        private readonly Piece[] _squares;
        //Выигрышные комбинации
        public readonly HashSet<int>[] combinations;

        //отводит место в памяти для массива _squares и вызывает метод Clear();
        public Board()
        {
            _squares = new Piece[9];
            Clear();

            combinations = new HashSet<int>[8];
            combinations[0] = [0, 1, 2];
            combinations[1] = [3, 4, 5];
            combinations[2] = [6, 7, 8];
            combinations[3] = [0, 3, 6];
            combinations[4] = [1, 4, 7];
            combinations[5] = [2, 5, 8];
            combinations[6] = [0, 4, 8];
            combinations[7] = [2, 4, 6];
        }
        /// <summary>
        /// очищает доску, помещает во все клетки Piece.Empty;
        /// </summary>
        private void Clear()
        {
            Array.Fill(_squares, Piece.Empty);
        }

        /// <summary>
        /// возвращает истину, если клетка свободна
        /// </summary>
        public bool IsLegal(int cell) =>
            _squares[cell] == Piece.Empty;

        /// <summary>
        /// возвращает истину, если поле заполнено
        /// </summary>
        public bool IsFull() =>
            !_squares.Contains(Piece.Empty);

        /// <summary>
        /// помещает фигуру в клетку
        /// </summary>
        public void MakeMove(Piece piece, int cell) =>
            _squares[cell] = piece;

        /// <summary>
        /// очищает клетку
        /// </summary>
        public void UndoMove(int cell) =>
            _squares[cell] = Piece.Empty;

        /// <summary>
        /// Возвращает массив с номерами пустых полей
        /// </summary>
        public int[] GetEmptyCells() =>
            GetFilledCells(Piece.Empty);

        /// <summary>
        /// Возвращает массив с номерами полей заполненных piece
        /// </summary>
        public int[] GetFilledCells(Piece piece) =>
            _squares
            .Select((p, n) => (p, n))
            .Where(pair => pair.p == piece)
            .Select(pair => pair.n)
            .ToArray();

        /// <summary>
        /// возвращает истину, если игрок, использующий фигуру piece, выиграл
        /// </summary>
        public bool IsWinner(Piece piece)
        {
            HashSet<int> moves = new();
            for (int i = 0; i <= 8; i++)
                if (_squares[i] == piece)
                    moves.Add(i);

            if (moves.Count < 3)
                return false;

            foreach (var combination in combinations)
                if (combination.IsSubsetOf(moves))
                    return true;

            return false;
        }

        string upCellBoder =        "┌───┬───┬───┐";
        string middleCellBoder =    "├───┼───┼───┤";
        string downCellBoder =      "└───┴───┴───┘";
        /// <summary>
        /// используется для отображения доски на консоли
        /// </summary>
        public override string ToString() =>
            BoardFiller(i => ShowPiece(_squares[i]));

        /// <summary>
        /// Доска с номерами клеток
        /// </summary>
        public string GetBoardWithCellNombers() =>
            BoardFiller(i => char.Parse(i.ToString()));

        string BoardFiller(Func<int, char> func)
        {
            StringBuilder sb = new();
            sb.AppendLine(upCellBoder);
            sb.AppendLine(GetGameLine(0));
            sb.AppendLine(middleCellBoder);
            sb.AppendLine(GetGameLine(1));
            sb.AppendLine(middleCellBoder);
            sb.AppendLine(GetGameLine(2));
            sb.AppendLine(downCellBoder);

            string GetGameLine(int line = 0)
            {
                StringBuilder _sb = new();
                for (int i = line * 3; i < line * 3 + 3; i++)
                    _sb.Append("│ " + func(i) + " ");
                _sb.Append("│");
                return _sb.ToString();
            }

            return sb.ToString();
        }

        /// <summary>
        /// Возвращает символ элемента
        /// </summary>
        static private char ShowPiece(Piece piece)
        {
            switch (piece)
            {
                case Piece.Empty:
                    return ' ';

                case Piece.Zero:
                    return 'O';

                case Piece.Cross:
                    return 'X';

                default:
                    return '*';
            }
        }
    }
}
