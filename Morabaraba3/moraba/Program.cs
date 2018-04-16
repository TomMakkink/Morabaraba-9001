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
            PlayGame();
            Board.printBoard();
            string[] cowsToPlace = new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" };
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(Board.Placing(cowsToPlace[i], player2) == true);
                //Assert.That(b.mainNodeList[i].Cow.Team == Team.DarkCow);
            }


            Console.Read();
        }

        static void PlayGame()
        {
            Umpire.play(player1, player2);
        }
        static void makePlayer ()
        {
            player1 = new Player("hi", Team.DarkCow);
            player2 = new Player("P2", Team.LightCow);
        }

      

      
    }
}
