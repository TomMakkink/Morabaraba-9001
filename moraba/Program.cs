using System;
using System.Windows;
using System.Collections.Generic;


namespace moraba
{
    class Program
    {
        public static Board Board = new Board();
        public static Umpire Umpire = new Umpire(Board);
        public static Player player1 = new Player ("test",Team.DarkCow);
        public static Player player2 = new Player("test2", Team.LightCow);

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            makePlayer();
            PlayGame();
            Board.printBoard();

            
           



            Console.Read();
        }

        static void PlayGame()
        {
            Umpire.play(player1, player2);
        }
        static void makePlayer ()
        {
            //Console.WriteLine("Good day to the new generals that are about to partak in this glorious battle. May we have your names.");
            //Console.WriteLine();
            //Console.WriteLine("General one your name please:   ");
            //string name1 =Console.ReadLine();
            //Console.WriteLine();
            //Console.WriteLine("General two your name please:   ");
            //string name2 = Console.ReadLine();
            //player1 = new Player(name1, Team.DarkCow);
            //player2 = new Player(name2, Team.LightCow);
            //Console.WriteLine("We will now start the battle prepare thyne selves.");

        }

      

      
    }
}
