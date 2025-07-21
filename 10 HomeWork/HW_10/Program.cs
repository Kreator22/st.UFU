// See https://aka.ms/new-console-template for more information
using HW_10;

Game game = new Game();    // создаётся объект типа Game;
game.SelectPlayers();      // запрашиваем тип и имя игроков у пользователя;
game.Play();               // играем игру;
//game.AnnounceWinner();     // объявляем победителя;	
Console.ReadKey();