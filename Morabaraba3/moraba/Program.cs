using System;
using System.Windows;
using System.Collections.Generic;

namespace moraba
{
    class Program
    {
        public static Board Board = new Board();
        public static Umpire Umpire = new Umpire();
        public static Player player1;
        public static Player player2;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            makePlayer();
            PlayGame();



           
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

        static List<List<string>> getMillOptions(int index)
        {
            string caseSwitch = Board.getMainNodeList()[index].Position;

            switch (caseSwitch)
            {
                case "a0":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a0", "d0", "g0" }, new List<string> { "a0", "b1", "c2" } };
                case "a3":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a3", "b3", "c3" } };
                case "a6":
                    return new List<List<string>> { new List<string> { "a0", "a3", "a6" }, new List<string> { "a6", "g6", "d6" }, new List<string> { "a6", "b5", "c4" } };
                case "b1":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "a0", "b1", "c2" }, new List<string> { "b1", "d1", "f1" } };
                case "b3":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "a3", "b3", "c3" } };
                case "b5":
                    return new List<List<string>> { new List<string> { "b1", "b3", "b5" }, new List<string> { "b5", "a6", "c4" }, new List<string> { "b5", "f5", "d5" } };
                case "c2":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "c2", "d2", "e2" }, new List<string> { "a0", "b1", "c2" } };
                case "c3":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "a3", "b3", "c3" } };
                case "c4":
                    return new List<List<string>> { new List<string> { "c2", "c3", "c4" }, new List<string> { "c4", "d4", "e4" }, new List<string> { "c4", "b5", "a6" } };
                case "d0":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "a0", "d0", "g0" } };
                case "d1":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "b1", "d1", "f1" } };
                case "d2":
                    return new List<List<string>> { new List<string> { "d0", "d1", "d2" }, new List<string> { "d2", "e2", "c2" } };
                case "d4":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "d4", "c4", "e4" } };
                case "d5":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "d5", "b5", "f5" } };
                case "d6":
                    return new List<List<string>> { new List<string> { "d4", "d5", "d6" }, new List<string> { "a6", "d6", "g6" } };
                case "e2":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e2", "f1", "g0" }, new List<string> { "e2", "d2", "c2" } };
                case "e3":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e3", "f3", "g3" } };
                case "e4":
                    return new List<List<string>> { new List<string> { "e2", "e3", "e4" }, new List<string> { "e4", "f5", "g6" }, new List<string> { "e4", "d4", "c4" } };
                case "f1":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "f1", "e2", "g0" }, new List<string> { "f1", "d1", "b1" } };
                case "f3":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "g3", "e3", "f3" } };
                case "f5":
                    return new List<List<string>> { new List<string> { "f1", "f3", "f5" }, new List<string> { "f5", "e4", "g6" }, new List<string> { "f5", "d5", "b5" } };
                case "g0":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g0", "f1", "e2" }, new List<string> { "g0", "a0", "d0" } };
                case "g3":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g3", "f3", "e3" } };
                case "g6":
                    return new List<List<string>> { new List<string> { "g0", "g3", "g6" }, new List<string> { "g6", "d6", "a6" }, new List<string> { "g6", "f5", "e4" } };


            }
            return new List<List<string>> { };
        }

        public bool canFormMill()
        {
            // to form a bool need to have the list of mill options and then we will take those options and see if any or some/all of them can be formed into a bool if they can be
            // than we will add those mills to the mill list of the player

            return false;
        }
    }
}
