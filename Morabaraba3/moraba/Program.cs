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


            
            int p1AliveCowIndex = 0;
            int p2AliveCowIndex = 0;
            int shotfiredIndex = 0;
            int expectedIndex = 0;
            int[] moves = new int[] { 1, 3, 0, 4, 23, 5, 2 };
            int[] shotsAtNodesTaken = new int[] { 23, 4 };
            bool[] expected = new bool[] { true, true };

            for (int i = 0; i < moves.Length; i++)
            {
                //Umpire.play(player1, player2);
                if ((i+1) % 2 == 1)// players 1s turn
                {
                    Umpire.play(player1, player2);
                    Board.mainNodeList[moves[i]].addCow(player1.CowsAlive[p1AliveCowIndex]);
                    p1AliveCowIndex++;
                    bool test = Umpire.millFormed(Umpire.board.mainNodeList[moves[i]]);
                    if (Umpire.millFormed(Umpire.board.mainNodeList[moves[i]]))
                    {
                        bool canShoot = Umpire.nodeChecks(Board.mainNodeList[shotsAtNodesTaken[shotfiredIndex]]);
                        Console.WriteLine(canShoot == expected[expectedIndex]);
                        shotfiredIndex++;
                        expectedIndex++;
                    }
                }
                else // player 2 turn
                {
                    Umpire.play(player2, player1);
                    Board.mainNodeList[moves[i]].addCow(player2.CowsAlive[p2AliveCowIndex]);
                    p2AliveCowIndex++;
                    Umpire.millFormed(Umpire.board.mainNodeList[moves[i]]);
                    if (Umpire.millFormed(Umpire.board.mainNodeList[moves[i]]))
                    {
                        bool canShoot = Umpire.nodeChecks(Board.mainNodeList[shotsAtNodesTaken[shotfiredIndex]]);
                        Console.WriteLine(canShoot == expected[expectedIndex]);
                        shotfiredIndex++;
                        expectedIndex++;
                    }
                }
                
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
