using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    class Game
    {
        private int movesMade = 1;
        private Board board;
        private Player player1;
        private Player player2;

        /// <summary>
        /// инициализирует board новым объектом типа Board;
        /// </summary>
        public Game()
        {
            board = new Board();
        }

        /// <summary>
        /// возвращает истину, если поле не заполнено и победителя нет.
        /// </summary>
        private bool IsRunning() =>
            !board.IsFull() && !board.IsWinner(Piece.Zero) && !board.IsWinner(Piece.Cross);

        /// <summary>
        /// метод содержит всего две команды - вызов selectPlayer для player1 и player2;
        /// </summary>
        public void SelectPlayers()
        {
            player1 = SelectPlayer(Piece.Cross);
            player2 = SelectPlayer(Piece.Zero);

            if(player1.GetType() == typeof(RandomPlayer) && 
                player2.GetType() == typeof(RandomPlayer))
                    player2 = new AdvancedComputerPlayer(Piece.Zero);  
        }

        /// <summary>
        /// запрашивает с пользователя тип игрока и его имя (если выбран HumanPlayer);
        /// </summary>
        private Player SelectPlayer(Piece piece)
        {
            Console.WriteLine($"Игра фигурой {piece}");
            Console.WriteLine("Введите имя игрока или нажмите Enter для создания игрока-компьютера");
            string? s = Console.ReadLine();

            Player player = string.IsNullOrEmpty(s) ? new RandomPlayer(piece) : new HumanPlayer(s, piece);

            Console.WriteLine($"Игрок {player.Name} играет фигурой {player.Piece}" + Environment.NewLine);
            return player;
        }

        /// <summary>
        /// возвращает игрока, ход которого - следующий;
        /// </summary>
        Player NextPlayer() =>
            movesMade % 2 == 0 ? player1 : player2;


        /// <summary>
        /// пока IsRunning() возвращает true, метод вызывает метод MakeMove() для очередного игрока 
        /// которого возвратил NextPlayer()) и отображает игровое поле,
        /// movesMade на каждом шаге увеличивается на единицу;
        /// </summary>
        public void Play()
        {
            Console.WriteLine("Номера клеток:");
            Console.WriteLine(board.GetBoardWithCellNombers());

            Player player;
            while (IsRunning())
            {
                player = NextPlayer();
                Console.WriteLine($"Ходит игрок {player.Name} фигурой {player.Piece}:");
                player.MakeMove(board);
                
                Console.WriteLine(Environment.NewLine + board);

                if (board.IsWinner(player.Piece))
                {
                    AnnounceWinner();
                    break;
                }

                if (board.IsFull())
                {
                    Console.WriteLine("Ничья");
                    break;
                }
                    
                movesMade++;
            } 
        }

        /// <summary>
        /// объявляет победителя 
        /// </summary>
        public void AnnounceWinner()
        {
            Player player = NextPlayer();
            Console.WriteLine($"Побеждает игрок {player.Name} фигурами {player.Piece}");
        }
    }
}
