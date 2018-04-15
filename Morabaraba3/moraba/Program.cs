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

            Board b = new Board();
            Player player = new Player("hello", Team.DarkCow);
            List<string> neigthbours = new List<string> { };
            List<string> notNeigthbours = new List<string> { };
            for (int i = 0; i < b.mainNodeList.Count; i++)
            {
                neigthbours = new List<string> { };
                notNeigthbours = new List<string> { };
                Board c = new Board();
                c.mainNodeList[i].addCow(player.CowsAlive[0]);
                foreach (string s in c.mainNodeList[i].neighbours)
                {
                    neigthbours.Add(s);
                }
                foreach (Node n in c.mainNodeList)
                {
                    if (!neigthbours.Contains(n.Position) && n.Position != c.mainNodeList[i].Position)
                        notNeigthbours.Add(n.Position);
                }
                foreach (string s in neigthbours)
                {
                    string input = String.Format("{0} {1}", c.mainNodeList[i].Position, s);
                    Console.WriteLine(c.Moving(input, player) == true);
                    string moveBack = String.Format("{1} {0}", c.mainNodeList[i].Position, s);
                    c.Moving(moveBack, player);
                }
                foreach (string s in notNeigthbours)
                {
                    string input = String.Format("{0} {1}", c.mainNodeList[i], s);
                    Console.WriteLine(c.Moving(input, player) == false);
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
