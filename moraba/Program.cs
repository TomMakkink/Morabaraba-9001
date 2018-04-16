using System;
using System.Windows;
using System.Collections.Generic;


namespace moraba
{
    class Program
    {
        public static Board Board = new Board();
        public static Umpire Umpire = new Umpire(Board);
        public static Player player1;
        public static Player player2;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            makePlayer();
            Umpire.currentPlayer = player1;
            Umpire.enemy = player2;
            PlayGame();
            Board.printBoard();

            Console.Read();
        }

        static void PlayGame()
        {
            bool isWin = false;
            while (!isWin)
            {
                player1 = Umpire.currentPlayer;
                player2 = Umpire.enemy;
                if (Umpire.turns <= 24)
                {
                    placeCow(player1);
                    Console.WriteLine("turns = " + Umpire.turns);
                    Console.WriteLine(player1.Name);
                }
                Umpire.turns++;
                Umpire.play(player1, player2);
            }

        }

        static void placeCow(Player currentPlayer)
        {
            Console.WriteLine("where do you want to place a cow? give the node coordinate eg: a0");
            string place = Console.ReadLine();
            bool flag = Board.Placing(place, currentPlayer);
            while (!flag)
            {
                Console.WriteLine("where do you want to place a cow? give the node coordinate eg: a0");
                place = Console.ReadLine();
                flag = Board.Placing(place, currentPlayer);
            }
        }
        static void makePlayer ()
        {
            player1 = new Player("hi", Team.DarkCow);
            player2 = new Player("P2", Team.LightCow);
        }

      

      
    }
}
