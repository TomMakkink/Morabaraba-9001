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

            int[] enemyCows = new int[] { 0, 1, 2 };
            int[] currentPlayerCows = new int[] { 21, 22, 23 };
            string targetCow = "c4";
            bool expected = false;

            Board.mainNodeList[enemyCows[0]].addCow(player2.CowsAlive[0]); // this will put three of the P2 cows on the board for us to shoot
            Board.mainNodeList[enemyCows[1]].addCow(player2.CowsAlive[1]);
            Board.mainNodeList[enemyCows[2]].addCow(player2.CowsAlive[2]);
            Board.mainNodeList[currentPlayerCows[0]].addCow(player1.CowsAlive[0]); // this will place 3 p cows on the board for us to form a mill and shoot
            Board.mainNodeList[currentPlayerCows[1]].addCow(player1.CowsAlive[1]);
            Board.mainNodeList[currentPlayerCows[2]].addCow(player1.CowsAlive[2]);
            Umpire U = new Umpire(Board);
            U.play(player1, player2);
            U.millFormed(Board.mainNodeList[currentPlayerCows[1]]); // this will make the mill be checked
            Node n = Board.getNodeFromString(targetCow);
            bool canShoot = U.nodeChecks(n);
            Console.WriteLine(n.occupied == expected);
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
