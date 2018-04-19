using System;
using System.Windows;
using System.Collections.Generic;


namespace moraba
{
    class Program
    {



        static void Main(string[] args)
        {
            Board Board = new Board();
            Umpire Umpire = new Umpire(Board);
            Player player1;
            Player player2;
            Console.WriteLine("Good day to the new generals that are about to partak in this glorious battle. May we have your names.");
            Console.WriteLine();
            Console.WriteLine("General one your name please:   ");
            string name1 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("General two your name please:   ");
            string name2 = Console.ReadLine();
            player1 = new Player(name1, Team.DarkCow, Board);
            player2 = new Player(name2, Team.LightCow, Board);
            Console.WriteLine("We will now start the battle prepare thyne selves.");
           
            
            Board.printBoard();

            Umpire.play(player1, player2);




            Console.Read();
        }

        
        

      

      
    }
}
