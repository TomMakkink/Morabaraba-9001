using System;
using NUnit.Framework;
using System.Linq;
using NSubstitute;
using System.Collections.Generic;
namespace moraba.Test
{
    [TestFixture]
    public class Class1
    {
        static object[] inMill =
        {
            new object[] {}
        };
        // When the game starts, the board is empty
        [Test]
        public void AboardHas24EmptyNodes()
        {
            Board b = new Board();
            List<Node> temp = b.getMainNodeList();
            int numOfNodes = b.getMainNodeList().Count();
            Assert.That(numOfNodes == 24);
            foreach (Node x in temp)
            {
                Assert.That(x.occupied == false);
            }
        }
        // the player with the dark cow goes first
        [Test]
        public void PlayerWithTheDarkCowsGoFirst()
        {
            Player player1 = new Player("p1", Team.DarkCow);
            Player player2 = new Player("P2", Team.LightCow);
            Umpire imp = new Umpire(new Board());
            imp.play(player1, player2);
            Assert.That(imp.currentPlayer.Team == Team.DarkCow && imp.turns == 1);
        }


        static object[] cowsToPlace =
        {
            new object[] { true,
                new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, false},
            new object[] { false,
                new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, true}
        };
        //Cows can only be placed on empty spaces
        [Test]
        [TestCaseSource(nameof(cowsToPlace))]
        public void cowsCanOnlyBePlacedOnEmptySpaces(bool indexOfCowsToPlace, string [] cowsToPlace, bool expected)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);
            Player p3 = new Player("Darth Grazer II", Team.DarkCow);
            Player p4 = new Player("Rebel Scum 1", Team.LightCow);
            // Place all the cows on the board for the first player
            if (indexOfCowsToPlace)
            {
                for (int i = 0; i < 12; i++)
                {
                    b.mainNodeList[i].addCow(p.CowsAlive[i]);
                }
                // Place all the cows on the board for the second player
                for (int i = 12, k = 0; i < 24; i++, k++)
                {
                    b.mainNodeList[i].addCow(p2.CowsAlive[k]);
                }
            }
            // Try place cows anywhere on the board 
            for (int i = 0; i < 12; i++)
            {
                Assert.That(b.Placing(cowsToPlace[i], p3) == expected);
                //Assert.That(b.mainNodeList[i].Cow.Team == Team.DarkCow);
            }
            for (int i = 12; i < 24; i++)
            {
                Assert.That(b.Placing(cowsToPlace[i], p4) == expected);
            }

        }


        // max of 12 placements per player are allowed
        [Test]
        public void max12CowsPerPLayerCanBePlaced()
        {
            Player player = new Player("P1", Team.DarkCow);
            //player.makeCowsToPlace(player.Team);
            Assert.That(player.numCowsToPlace() == 12);
            Board b = new Board();
            b.Placing(b.mainNodeList[2].Position, player);
            Assert.That(player.numCowsToPlace() == 11);
            // this shows that there can only be 12 cows placed per player.
        }



        // Cows cannot be moved during placement
        [Test]
        public void cowscantMoveDuringPlacingPhase()
        {
            Board b = new Board();
            List<Node> temp = b.getMainNodeList();
            Player player1 = new Player("p1", Team.DarkCow); // new player has yet to place
         //   player1.makeCowsToPlace(player1.Team);
            Assert.That(player1.numCowsToPlace() == 12); // show that its new player
            int cowsToPlace = 12;
            for (int i = 0; i < 6; i++) // to place alot of cows but not all so that placing is still going
            {                        // it also places them in order so we know what nodes are empty
                Assert.That(player1.numCowsToPlace() == cowsToPlace - i);
                b.Placing(b.mainNodeList[i].Position, player1);
            }
            Assert.That(b.Moving("b5 c4", player1) == false);
            Assert.That(b.Moving("b5 d5", player1) == false);
            Assert.That(b.Moving("b3 c3", player1) == false);
            Assert.That(b.Moving("b1 c2", player1) == false);
            Assert.That(b.Moving("b1 d1", player1) == false);
            Assert.That(b.Moving("a0 d0", player1) == false);
        }

        static object[] cowNeightbours =
        {
            new object[] {0, "a0", new string[] { "a3", "d0", "b1" } },
            new object[] {1, "a3", new string[] { "a0", "b3", "a6" } },
            new object[] {2, "a6", new string[] { "a3", "d6", "b5" } },
            new object[] {3, "b1", new string[] { "a0", "c2", "d1", "b3" } },
            new object[] {4, "b3", new string[] { "a3", "c3", "b1", "b5" } },
            new object[] {5, "b5", new string[] { "a6", "c4", "b3", "d5" } },
            new object[] {6, "c2", new string[] { "b1", "c3", "d2" } },
            new object[] {7, "c3", new string[] { "c2", "c4", "b3" } },
            new object[] {8, "c4", new string[] { "c3", "b5", "d4" } },
            new object[] {9, "d0", new string[] { "d1", "a0", "g0" } },
            new object[] {10, "d1", new string[] { "d0", "b1", "d2", "f1" } },
            new object[] {11, "d2", new string[] { "d1", "c2", "e2" } },
            new object[] {12, "d4", new string[] { "d5", "c4", "e4" } },
            new object[] {13, "d5", new string[] { "d4", "d6", "b5", "f5" } },
            new object[] {14, "d6", new string[] { "d5", "a6", "g6" } },
            new object[] {15, "e2", new string[] { "f1", "e3", "d2" } },
            new object[] {16, "e3", new string[] { "e2", "e4", "f3" } },
            new object[] {17, "e4", new string[] { "e3", "f5", "d4" } },
            new object[] {18, "f1", new string[] { "d1", "f3", "e2", "g0" } },
            new object[] {19, "f3", new string[] { "f1", "e3", "g3", "f5"} },
            new object[] {20, "f5", new string[] { "g6", "d5", "e4" } },
            new object[] {21, "g0", new string[] { "g3", "f1", "d0" } },
            new object[] {22, "g3", new string[] {"g0", "g6", "f3" } },
            new object[] {23, "g6", new string[] { "g3", "f5", "d6" } }
        };

        static object[] cowNonNeightbours =
       {
            new object[] {0, "a0", new string[] { "a0", "a6", "b3", "b5", "c2", "c3", "c4", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {1, "a3", new string[] { "a3", "b1", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {2, "a6", new string[] { "a0", "a6", "b1", "b3", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {3, "b1", new string[] { "a3", "a6", "b1", "b5", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {4, "b3", new string[] { "a0", "a6", "b3", "c2", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {5, "b5", new string[] { "a0", "a3", "b1", "b5", "c2", "c3", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {6, "c2", new string[] { "a0", "a3", "a6", "b3", "b5", "c2", "c4", "d0", "d1", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {7, "c3", new string[] { "a0", "a3", "a6", "b1", "b3", "c2", "c4", "d0", "d1", "d2", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {8, "c4", new string[] { "a0", "a3", "a6", "b1", "b3", "c2", "c4", "d0", "d1", "d2", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {9, "d0", new string[] { "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g3", "g6" } },
            new object[] {10, "d1", new string[] { "a0", "a3", "a6", "b3", "b5", "c2", "c3", "c4", "d1", "d4", "d5", "d6", "e2", "e3", "e4", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {11, "d2", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {12, "d4", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {13, "d5", new string[] { "a0", "a3", "a6", "b1", "b3", "c2", "c3", "c4", "d0", "d1", "d2", "d5", "e2", "e3", "e4", "f1", "f3", "g0", "g3", "g6" } },
            new object[] {14, "d6", new string[] { "a0", "a3", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3" } },
            new object[] {15, "e2", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d4", "d5", "d6", "e2", "e4", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {16, "e3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e3", "f1", "f5", "g0", "g3", "g6" } },
            new object[] {17, "e4", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d5", "d6", "e2", "e4", "f1", "f3", "g0", "g3", "g6" } },
            new object[] {18, "f1", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e3", "e4", "f1", "f5", "g3", "g6" } },
            new object[] {19, "f3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e4", "f3", "g0", "g6" } },
            new object[] {20, "f5", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "f1", "f5", "g0", "g3"} },
            new object[] {21, "g0", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f3", "f5", "g0", "g6" } },
            new object[] {22, "g3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f5", "g3"} },
            new object[] {23, "g6", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "e2", "e3", "e4", "f1", "f3", "g0", "g6" } }
        };


        //Cow can only move to a connected space
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void cowsCanMoveToAConnectedSpace(int index, string cowName, string [] neighbours)
        {
            Board b = new Board();
            Player player = new Player("hello", Team.DarkCow);
            b.mainNodeList[index].addCow(player.CowsAlive[0]);
            while(player.numCowsToPlace() !=0)
            {
                player.placedCow();
            }
            foreach (string s in neighbours)
            {
                string input = String.Format("{0} {1}", b.mainNodeList[index].Position, s);
                Assert.That(b.Moving(input, player) == true);
                string moveBack = String.Format("{1} {0}", b.mainNodeList[index].Position, s);
                b.Moving(moveBack, player);
            }
        }

        //Cow can only move to a connected space
        [Test]
        [TestCaseSource(nameof(cowNonNeightbours))]
        public void cowsCanOnlyMoveToAConnectedSpace(int index, string cowName, string[] notNeighbours)
        {
            Board b = new Board();
            Player player = new Player("hello", Team.DarkCow);
            b.mainNodeList[index].addCow(player.CowsAlive[0]);
            while (player.numCowsToPlace() != 0)
            {
                player.placedCow();
            }
            foreach (string s in notNeighbours)
            {
                string input = String.Format("{0} {1}", b.mainNodeList[index], s);
                Assert.That(b.Moving(input, player) == false);
            }
        }


        //cow can only move to an empty space
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void cowCanOnlyMoveToEmptySpace(int index, string cowName, string[] neighbours)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            b.mainNodeList[index].addCow(player.CowsAlive[0]);
            // Place cows in all neighbouring nodes
            foreach (string s in neighbours)
            {
                Node n = b.getNodeFromString(s);
                int i = b.mainNodeList.FindIndex(x => x.Position == s);
                b.mainNodeList[i].addCow(n.Cow);
            }
            // Attempt to move into neighbouring nodes
            foreach (string s in neighbours)
            {
                string input = String.Format("{0} {1}", b.mainNodeList[index].Position, s);
                Assert.That(b.Moving(input, player) == false);
            }


        }

        // moving does not increase or decrease the number of cows on the field
        static object[] moveCows =
        {
            new object[] { new int[] { 0, 1, 2, 3, 4, 5 }, "b5 c4", 6},
            new object[] {new int[] { 0, 1, 2, 3, 4, 5}, "a0 d0", 6},
            new object[] { new int[] { 0, 1, 2, 3, 4, 5 }, "b1 d1", 6},
            new object[] { new int[] { 0, 1, 2, 3, 4, 5 }, "b1 c2", 6},
            new object[] { new int[] { 0, 1, 2, 3, 4, 5 }, "b5 d5", 6},
            new object[] { new int[] { 10, 11, 12, 13, 14, 15 }, "e2 f1", 6},
            new object[] { new int[] { 18, 19, 20, 21, 22, 23 }, "f3 e3", 6},
             new object[] { new int[] { 18, 19, 20, 21, 22, 23 }, "f5 d5", 6}
        };
        [Test]
        [TestCaseSource(nameof(moveCows))]
        public void MovingDoesNotIncrOrDecrNumOfCowOnTheField(int[] cows, string move, int total)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            while (player.numCowsToPlace() != 0)
            {
                player.placedCow();
            }
            b.mainNodeList[cows[0]].addCow(player.CowsAlive[0]);
            b.mainNodeList[cows[1]].addCow(player.CowsAlive[1]);
            b.mainNodeList[cows[2]].addCow(player.CowsAlive[2]);
            b.mainNodeList[cows[3]].addCow(player.CowsAlive[3]);
            b.mainNodeList[cows[4]].addCow(player.CowsAlive[4]);
            b.mainNodeList[cows[5]].addCow(player.CowsAlive[5]);
            Assert.That(b.Moving(move, player) == true && b.numOfCowsOntheField() == total); // this is to show that the cow was moved out of the node
        }

        static object[] allPossiblePlaces =
    {
            new object[] {0, "a0", new string[] { "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {1, "a3", new string[] { "a0", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {2, "a6", new string[] { "a0", "a3", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {3, "b1", new string[] { "a0", "a3", "a6", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {4, "b3", new string[] { "a0", "a3", "a6", "b1", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {5, "b5", new string[] { "a0", "a3", "a6", "b1", "b3", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {6, "c2", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {7, "c3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {8, "c4", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {9, "d0", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {10, "d1", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {11, "d2", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {12, "d4", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {13, "d5", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {14, "d6", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {15, "e2", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {16, "e3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {17, "e4", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "f1", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {18, "f1", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f3", "f5", "g0", "g3", "g6" } },
            new object[] {19, "f3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f5", "g0", "g3", "g6" } },
            new object[] {20, "f5", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "g0", "g3", "g6" } },
            new object[] {21, "g0", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g3", "g6" } },
            new object[] {22, "g3", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g6" } },
            new object[] {23, "g6", new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3" } }
        };

        // Cows can move to any empty space if only three cows of that team remain
        [Test]
        [TestCaseSource(nameof(allPossiblePlaces))]
        public void CowsMoveToAnyEmptySpaceWhenFlying(int index, string cowName, string[] possibleMoves)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            int AmountOfAliveCows = 12;
            while (AmountOfAliveCows > 3)
            {
                player.killCow("a0");
                AmountOfAliveCows--;
            }
            foreach (string s in possibleMoves)
            {

            }

        }

        static object[] millCheck =
        {
            new object[] {0,1,2,true},
            new object[] {9,10,11, true},
            new object[] {10,11,12, false },
            new object[] {0,3,6,true},
            new object[] {23,20,17, true},
            new object[] {17,6,3, false},
            new object[] {3,10,18, true},
            new object[] {8,12,17, true},
            new object[] {9,10,3, false}
        };

        [Test]
        [TestCaseSource(nameof(millCheck))]
        public void testMillFormedByThreeCowsInALine(int num1, int num2, int num3, bool expect)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);

            b.mainNodeList[num1].addCow(p.CowsAlive[0]);
            b.mainNodeList[num2].addCow(p.CowsAlive[1]);
            b.mainNodeList[num3].addCow(p.CowsAlive[2]);
            Umpire pulpotine = new Umpire(b);
            pulpotine.play(p, p2);
            Assert.That(pulpotine.millFormed(b.mainNodeList[num2]) == expect);

        }
        static object[] MillsWithTwoTeamsAndNotInStraightLine = {
            new object[] {0,1,2,true },
            new object[] {0,6,11,false},
            new object[] {4,7,8,false},
            new object[] {23,22,19,false }

            };


        [Test]
        [TestCaseSource(nameof(MillsWithTwoTeamsAndNotInStraightLine))]
        public void CowsCanNotFormMillWhenNotInLineAndNotOnTheSameTeam(int num1, int num2, int num3, bool expect)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);

            b.mainNodeList[num1].addCow(p.CowsAlive[0]);
            b.mainNodeList[num2].addCow(p.CowsAlive[1]);
            b.mainNodeList[num3].addCow(p.CowsAlive[2]);
            Umpire pulpotine = new Umpire(b);
            pulpotine.play(p, p2);
            Assert.That(pulpotine.millFormed(b.mainNodeList[num2]) == expect);


        }

        static object[] CowsOfDiffTeamsInRowsOf3 = {
            new object[] {0,1,2,false },
            new object[] {0,9,21,false},
            new object[] {0,3,6,false},
            new object[] {23,22,19,false},
            new object[] {23,22,21,false}
        };
        [Test]
        [TestCaseSource(nameof(CowsOfDiffTeamsInRowsOf3))]
        public void CheckMillsWithCowsOfDiffTeamsInThem(int num1, int num2, int num3, bool expect)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);
            b.mainNodeList[num1].addCow(p.CowsAlive[0]);
            b.mainNodeList[num2].addCow(p2.CowsAlive[1]);
            b.mainNodeList[num3].addCow(p.CowsAlive[2]);
            Umpire pulpotine = new Umpire(b);
            pulpotine.play(p, p2);
            Assert.That(pulpotine.millFormed(b.mainNodeList[num2]) == expect);
        }

        static object[] CowsInMIllCanShoot = {

            new object[] { new int[]{ 6,8,12}, new int[] {0,1,2 },"e4",false },
            new object[] { new int[]{ 0,23,14}, new int[] {6,7,8 },"g6",false },
            new object[] { new int[]{ 5,12,14}, new int[] { 18,19,20},"d4",false },
            new object[] { new int[]{ 1,2,4}, new int[] {17,20,23 },"a3",false },
            new object[] { new int[]{ 18,22,20}, new int[] {6,11,15 },"g3",false },
            new object[] { new int[]{ 3,10,11}, new int[] {4,5,14 },"d1",true },
            new object[] { new int[]{ 0,5,8}, new int[] { 21,4,2},"c3",true },
            new object[] { new int[]{ 0,20,23}, new int[] { 6,9,11},"f1",true }
        };

        [Test]
        [TestCaseSource(nameof(CowsInMIllCanShoot))]
        public void ShootOccursWhenMillOccurs(int[] enemyCows , int[] currentPlayerCows,string chosenCow, bool expected)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);
            b.mainNodeList[enemyCows[0]].addCow(p2.CowsAlive[0]); // this will put three of the P2 cows on the board for us to shoot
            b.mainNodeList[enemyCows[1]].addCow(p2.CowsAlive[1]);
            b.mainNodeList[enemyCows[2]].addCow(p2.CowsAlive[2]);
            b.mainNodeList[currentPlayerCows[0]].addCow(p.CowsAlive[0]); // this will place 3 p cows on the board for us to form a mill and shoot
            b.mainNodeList[currentPlayerCows[1]].addCow(p.CowsAlive[1]);
            b.mainNodeList[currentPlayerCows[2]].addCow(p.CowsAlive[2]);
            Umpire U = new Umpire(b);
            U.play(p, p2);
            U.millFormed(b.mainNodeList[currentPlayerCows[1]]); // this will make the mill be checked 
            U.shoot(b.mainNodeList[enemyCows[2]].Position); // this will shoot the cow given as a parameter
            Assert.That(U.board.mainNodeList[enemyCows[2]].occupied == expected); // this will check that the node shoot at is empty and show that the cow choosen was 
                                                                                  // removed
            U.turns+=2; // skips 2 player p next turn
            U.play(p, p2); 
            U.millFormed(b.mainNodeList[currentPlayerCows[1]]); // again calls to see if a mill will be formed even if it is the same mill
            U.shoot(b.mainNodeList[enemyCows[1]].Position); // this will check that a mill will not fire after it has already fired
            Assert.That(U.board.mainNodeList[enemyCows[1]].occupied == true);
        }
        #region jeffs test
        // the test sources bellow are in the following format
        // int[] all moves made during a game|| int[] all shats made during a game || the expected value of each shot 
        // note that the number in the arrays refer to the node index in the mainNodeList used for the board
        static object[] cowsInMillThatCantBeShot =
        {
            new object[] { new int[] { 1, 3, 0, 4, 23, 5, 2}, new int[] { 23, 4}, new bool[] { true, true } },
            new object[] { new int[] { 0,3,1,4,2}, new int[] { 3}, new bool[] { true } },
            new object[] { new int[] { 9,11,0,3,1,4,2,5}, new int[] {11, 0}, new bool[] {true, false}}
        };

        [Test]
        [TestCaseSource(nameof(cowsInMillThatCantBeShot))]
        public void CowInMillCannotBeshotIfNonMillCowsExists(int[] moves, int[] shotsAtNodesTaken, bool[] expected)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer III", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 2", Team.LightCow);
            Umpire palpetine = new Umpire(b);

            palpetine.play(p, p2);

            int p1AliveCowIndex = 0;
            int p2AliveCowIndex = 0;
            int shotfiredIndex = 0;
            int expectedIndex = 0;

            for (int i = 0; i < moves.Length; i++)
            {
                if ((i+1) % 2 == 1)// players 1s turn
                {
                    palpetine.play(p, p2);
                    b.mainNodeList[moves[i]].addCow(p.CowsAlive[p1AliveCowIndex]);
                    p1AliveCowIndex++;
                    if (palpetine.millFormed(b.mainNodeList[moves[i]]))
                    {
                        bool canShoot = palpetine.nodeChecks(b.mainNodeList[shotsAtNodesTaken[shotfiredIndex]]);
                        Assert.That(canShoot == expected[expectedIndex]);
                        shotfiredIndex++;
                        expectedIndex++;
                    }
                }
                else // player 2 turn
                {
                    palpetine.play(p2, p);
                    b.mainNodeList[moves[i]].addCow(p2.CowsAlive[p2AliveCowIndex]);
                    p2AliveCowIndex++;
                    if (palpetine.millFormed(b.mainNodeList[moves[i]]))
                    {
                        bool canShoot = palpetine.nodeChecks(b.mainNodeList[shotsAtNodesTaken[shotfiredIndex]]);
                        Assert.That(canShoot == expected[expectedIndex]);
                        shotfiredIndex++;
                        expectedIndex++;
                    }
                }
            }

        }
        #endregion

        #region testing shooting empty spaces
        static object[] testCasesForShootingEmptyNode =
        {
            new object[] {new int[] {0,1,2}, new int[] {21,22,23},new string[] { "a0","a3","a6" }, true},
            new object[] {new int[] {0,1,2}, new int[] {21,22,23},new string[] { "b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {3,4,5}, new int[] {21,22,23},new string[] { "b1","b3","b5" }, true},
            new object[] {new int[] {3,4,5}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {6,7,8}, new int[] {21,22,23},new string[] { "c2","c3","c4" }, true},
            new object[] {new int[] {6,7,8}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {9,10,11}, new int[] {21,22,23},new string[] { "d0", "d1", "d2" }, true},
            new object[] {new int[] {9,10,11}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {12,13,14}, new int[] {21,22,23},new string[] {  "d4","d5","d6" }, true},
            new object[] {new int[] {12,13,14}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {15,16,17}, new int[] {21,22,23},new string[] { "e2", "e3", "e4" }, true},
            new object[] {new int[] {15,16,17}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4","d5","d6","f1","f3","f5","g0","g3","g6" }, false},
            new object[] {new int[] {18,19,20}, new int[] {21,22,23},new string[] { "f1", "f3", "f5" }, true},
            new object[] {new int[] {18,19,20}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6","e2","e3","e4","g0","g3","g6" }, false},
            new object[] {new int[] {21,22,23}, new int[] {0,1,2},new string[] { "g0", "g3", "g6" }, true},
            new object[] {new int[] {21,22,23}, new int[] {0,1,2},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6","e2","e3","e4", "f1", "f3", "f5" }, false},
            //horizantal mills done
            new object[] {new int[] {0,9,21}, new int[] {2,14,23},new string[] { "a0","d0","g0" }, true},
            new object[] {new int[] {0,9,21}, new int[] {2,14,23}, new string[] {"b1","d1","f1","c2","d2","e2","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {3,10,18}, new int[] {2,14,23},new string[] { "b1", "d1", "f1" }, true},
            new object[] {new int[] {3,10,18}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0","c2","d2","e2","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {6,11,15}, new int[] {2,14,23},new string[] { "c2", "d2", "e2" }, true},
            new object[] {new int[] {6,11,15}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {1,4,7}, new int[] {2,14,23},new string[] { "a3", "b3", "c3" }, true},
            new object[] {new int[] {1,4,7}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {16,19,22}, new int[] {2,14,23},new string[] { "e3", "f3", "g3" }, true},
            new object[] {new int[] {16,19,22}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {8,12,17}, new int[] {2,14,23},new string[] { "c4", "d4", "e4" }, true},
            new object[] {new int[] {8,12,17}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3","b5","d5","f5","a6","d6","g6"}, false },
            new object[] {new int[] {5,13,20}, new int[] {2,14,23},new string[] { "b5", "d5", "f5" }, true},
            new object[] {new int[] {5,13,20}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3", "c4", "d4", "e4","a6","d6","g6"}, false },
            new object[] {new int[] {2,14,23}, new int[] {0,9,21},new string[] { "a6", "d6", "g6" }, true},
            new object[] {new int[] {2,14,23}, new int[] {0,9,21}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3", "c4", "d4", "e4", "b5", "d5", "f5"}, false },
            // vertical mills done
            new object [] { new int[] { 0, 3, 6 }, new int[] { 2, 5, 8 }, new string[] { "a0","b1","c2"}, true },
            new object [] { new int[] {0,3,6}, new int[] { 2,5,8}, new string[] { "a3","a6","b3","b5","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, false},
            new object [] { new int[] { 21, 18, 15 }, new int[] { 2, 5, 8 }, new string[] { "g0","f1","e2"}, true },
            new object [] { new int[] { 21, 18, 15 }, new int[] { 2,5,8}, new string[] { "a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e3","e4","f3","f5","g3","g6"}, false},
            new object [] { new int[] { 17, 20, 23 }, new int[] { 2, 5, 8 }, new string[] { "e4","f5","g6"}, true },
            new object [] { new int[] { 17, 20, 23 }, new int[] { 2,5,8}, new string[] { "a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","f1","f3","g0","g3"}, false},
            new object [] { new int[] { 2,5,8 }, new int[] { 17,20,23 }, new string[] { "a6","b5","c4"}, true },
            new object [] { new int[] { 2,5,8 }, new int[] { 17,20,23 }, new string[] { "a0","a3","b1","b3","c2","c3","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, false}
            // diagonal mills checks

        };
        #endregion

        static object[] CowsInMills = {
            new object[] { new int[] {0,1,2}, "a0","a3","a6"},
            new object[] { new int[] {0,9,21}, "a0","d0","g0"},
            new object[] { new int[] {0,3,6}, "a0","b1","c2"},
            new object[] { new int[] {1,4,7}, "a3","b3","c3"},
            new object[] { new int[] {2,5,8}, "a6","b5","c4"},
            new object[] { new int[] {2,14,23}, "a6","d6","g6"},
            new object[] { new int[] {3,4,5}, "b1","b3","b5"},
            new object[] { new int[] {3,10,18}, "b1","d1","f1"},
            new object[] { new int[] {5,13,20}, "b5","d5","f5"},
            new object[] { new int[] {6,7,8}, "c2","c3","c4"},
            new object[] { new int[] {6,11,15}, "c2","d2","e2"},
            new object[] { new int[] {8,12,17}, "c4","d4","e4"},
            new object[] { new int[] {9,10,11}, "d0","d1","d2"},
            new object[] { new int[] {12,13,14}, "d4","d5","d6"},
            new object[] { new int[] {15,18,21}, "e2","f1","g0"},
            new object[] { new int[] {15,16,17}, "e2","e3","e4"},
            new object[] { new int[] {16,19,22}, "e3","f3","g3"},
            new object[] { new int[] {17,20,23}, "e4","f5","g6"},
            new object[] { new int[] {18,19,20}, "f1","f3","f5"},
            new object[] { new int[] {21,22,23}, "g0","g3","g6"}
        };

        [Test]
        [TestCaseSource(nameof(CowsInMills))]

        public void cannotShootCowsInOwnMill(int [] currentPlayerCows, string cow1, string cow2, string cow3)
        {
            Board b = new Board();
            Player p = new Player("Darth Grazer II", Team.DarkCow);
            Player p2 = new Player("Rebel Scum 1", Team.LightCow);
            //Place cows on the board to form a mill
            b.mainNodeList[currentPlayerCows[0]].addCow(p.CowsAlive[0]); 
            b.mainNodeList[currentPlayerCows[1]].addCow(p.CowsAlive[1]);
            b.mainNodeList[currentPlayerCows[2]].addCow(p.CowsAlive[2]);
            //Attempt to shoot those cows 
            Umpire U = new Umpire(b);
            U.play(p, p2);
            U.millFormed(b.mainNodeList[1]); // this will make the mill be checked 
            U.shoot(cow1);
            U.shoot(cow2);
            U.shoot(cow3);
            Assert.That(U.board.mainNodeList[currentPlayerCows[0]].occupied = true);
            Assert.That(U.board.mainNodeList[currentPlayerCows[1]].occupied = true);
            Assert.That(U.board.mainNodeList[currentPlayerCows[2]].occupied = true);
        }

    }
}
