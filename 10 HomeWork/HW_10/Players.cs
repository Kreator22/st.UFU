using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    abstract class Player
    {
        public string Name { get; internal set; }
        public Piece Piece { get; }

        protected Player(string name, Piece piece)
        {
            Name = name;
            Piece = piece;
        }

        public abstract void MakeMove(Board board);
    }

    class HumanPlayer(string name, Piece piece) : Player(name, piece)
    {
        public override void MakeMove(Board board)
        {
            if (board.IsFull())
                return;

            int cell;
            string? s;
            do
                s = Console.ReadLine();
            while (!(int.TryParse(s, out cell) && cell >= 0 && cell < 9 && board.IsLegal(cell)));

            board.MakeMove(Piece, cell);
        }
    }

    abstract class ComputerPlayer(Piece piece) : Player("Computer", piece) { }

    class RandomPlayer(Piece piece) : ComputerPlayer(piece)
    {
        public override void MakeMove(Board board)
        {
            if (board.IsFull())
                return;

            int[] emptyCells = board.GetEmptyCells();
            int move = emptyCells[Random.Shared.Next(emptyCells.Length)];
            Thread.Sleep(0);
            board.MakeMove(Piece, move);
        }
    }

    class AdvancedComputerPlayer : RandomPlayer
    {
        public AdvancedComputerPlayer(Piece piece) : base(piece)
        {
            Name = "AdvancedComputer";
        }

        public override void MakeMove(Board board)
        {
            if (board.IsFull())
                return;

            int[] emptyCells = board.GetEmptyCells();
            HashSet<int> filledCells = board.GetFilledCells(Piece).ToHashSet();
            int winMove = -1;

            foreach(int cell in emptyCells)
            {
                filledCells.Add(cell);
                foreach(var combination in board.combinations)
                    if (combination.IsSubsetOf(filledCells))
                    {
                        winMove = cell;
                        break;
                    }
                
                if (winMove != -1)
                {
                    board.MakeMove(Piece, winMove);
                    break;
                }
                    
                filledCells.Remove(cell);
            }

            if(winMove == -1)
            {
                int move = emptyCells[Random.Shared.Next(emptyCells.Length)];
                Thread.Sleep(0);
                board.MakeMove(Piece, move);
            }
        }
    }
}
