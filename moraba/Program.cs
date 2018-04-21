using System;
using System.Windows;
using System.Collections.Generic;


namespace moraba
{
    class Program
    {



        static void Main(string[] args)
        {
            IBoard Board = new Board();
            IPlayer player1;
            IPlayer player2;
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
            Umpire Umpire = new Umpire(player1,player2);
            ICow cow = new Cow(Team.DarkCow);
            player1.getBoard().getMainNodeList()[0].addCow(cow);
            Board.printBoard();

            Umpire.play();




            Console.Read();
        }

        
        

      

      
    }
}
