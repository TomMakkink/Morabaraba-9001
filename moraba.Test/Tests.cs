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

        // When the game starts, the board is empty
        [Test]
        public void AboardHas24EmptyNodes()
        {
            Board b = new Board();
            foreach (INode x in b.getMainNodeList())
            {
                Assert.That(x.getOccupied() == false);
            }
        }
        //the player with the dark cow goes first
        [Test]
        public void PlayerWithTheDarkCowsGoFirst()
        {
            IBoard board = Substitute.For<IBoard>();
            IPlayer player1 = Substitute.For<IPlayer>();
            IPlayer player2 = Substitute.For<IPlayer>();
            Umpire imp = new Umpire(player1, player2);
            Assert.That(imp.getCurrentPlayer().Team == Team.DarkCow && imp.getTurns() == 1);
        }


        static object[] cowsToPlace =
        {
                    new object[] { new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}},
                    //new object[] { false,
                    //    new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, true}
                };
        //Cows can only be placed on empty spaces
        [Test]
        [TestCaseSource(nameof(cowsToPlace))]
        public void cowsCanOnlyBePlacedOnEmptySpaces(string[] cowsToPlace)
        {
            ICow cow = Substitute.For<ICow>();
            IBoard board = Substitute.For<IBoard>();
            IPlayer player1 = Substitute.For<Player>("1", Team.DarkCow, board);
            IPlayer player2 = Substitute.For<Player>("2", Team.LightCow, board);
            List<INode> mainNodeList = new List<INode> { };
            mainNodeList.Add(new Node("a0", new List<string> { "a3", "d0", "b1" }));
            mainNodeList.Add(new Node("a3", new List<string> { "a0", "b3", "a6" }));
            mainNodeList.Add(new Node("a6", new List<string> { "a3", "d6", "b5" }));
            mainNodeList.Add(new Node("b1", new List<string> { "a0", "c2", "d1", "b3" }));
            mainNodeList.Add(new Node("b3", new List<string> { "a3", "c3", "b1", "b5" }));
            mainNodeList.Add(new Node("b5", new List<string> { "a6", "c4", "b3", "d5" }));
            mainNodeList.Add(new Node("c2", new List<string> { "b1", "c3", "d2" }));
            mainNodeList.Add(new Node("c3", new List<string> { "c2", "c4", "b3" }));
            mainNodeList.Add(new Node("c4", new List<string> { "c3", "b5", "d4" }));
            mainNodeList.Add(new Node("d0", new List<string> { "d1", "a0", "g0" }));
            mainNodeList.Add(new Node("d1", new List<string> { "d0", "b1", "d2", "f1" }));
            mainNodeList.Add(new Node("d2", new List<string> { "d1", "c2", "e2" }));
            mainNodeList.Add(new Node("d4", new List<string> { "d5", "c4", "e4" }));
            mainNodeList.Add(new Node("d5", new List<string> { "d4", "d6", "b5", "f5" }));
            mainNodeList.Add(new Node("d6", new List<string> { "d5", "a6", "g6" }));
            mainNodeList.Add(new Node("e2", new List<string> { "f1", "e3", "d2" }));
            mainNodeList.Add(new Node("e3", new List<string> { "e2", "e4", "f3" }));
            mainNodeList.Add(new Node("e4", new List<string> { "e3", "f5", "d4" }));
            mainNodeList.Add(new Node("f1", new List<string> { "d1", "f3", "e2", "g0" }));
            mainNodeList.Add(new Node("f3", new List<string> { "f1", "e3", "g3", "f5" }));
            mainNodeList.Add(new Node("f5", new List<string> { "g6", "d5", "e4" }));
            mainNodeList.Add(new Node("g0", new List<string> { "g3", "f1", "d0" }));
            mainNodeList.Add(new Node("g3", new List<string> { "g0", "g6", "f3" }));
            mainNodeList.Add(new Node("g6", new List<string> { "g3", "f5", "d6" }));
            board.getMainNodeList().Returns(mainNodeList);


            Umpire umpire = new Umpire(player1, player2);
            foreach (Node n in mainNodeList)
            {
                board.checkNodeExists(n.Position).Returns(true);

                board.checkNodeIsOccupied(n).Returns(false);
                Assert.That(umpire.validatePlacing(n) == true);

                board.checkNodeIsOccupied(n).Returns(true);
                Assert.That(umpire.validatePlacing(n) == false);
            }
        }

        #region original_test
        //      static object[] cowsToPlace =
        //{
        //                  new object[] {true, new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"},false},
        //                  new object[] { false,
        //                     new string[] {"a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, true}
        //              };
        //      [Test]
        //      [TestCaseSource(nameof(cowsToPlace))]
        //      public void cowsCanOnlyBePlacedOnEmptySpaces(bool indexOfCowsToPlace,string[] cowsToPlace,bool expected )
        //      {
        //          IBoard b = new Board();
        //          IPlayer p = new Player("Darth Grazer II", Team.DarkCow,b);
        //          IPlayer p2 = new Player("Rebel Scum 1", Team.LightCow,b);
        //          IPlayer p3 = new Player("Darth Grazer II", Team.DarkCow,b);
        //          IPlayer p4 = new Player("Rebel Scum 1", Team.LightCow,b);
        //          // Place all the cows on the board for the first player
        //          if (indexOfCowsToPlace)
        //          {
        //              for (int i = 0; i < 12; i++)
        //              {
        //                  b.getMainNodeList()[i].addCow(p.getCowsAlive()[i]);
        //              }
        //              // Place all the cows on the board for the second player
        //              for (int i = 12, k = 0; i < 24; i++, k++)
        //              {
        //                  b.getMainNodeList()[i].addCow(p2.getCowsAlive()[k]);
        //              }
        //          }
        //          // Try place cows anywhere on the board 
        //          for (int i = 0; i < 12; i++)
        //          {
        //              Assert.That(p3.Placing(cowsToPlace[i]) == expected);
        //              //Assert.That(b.mainNodeList[i].Cow.Team == Team.DarkCow);
        //          }
        //          for (int i = 12; i < 24; i++)
        //          {
        //              Assert.That(p4.Placing(cowsToPlace[i]) == expected);
        //          }
        //          
        //      }
        #endregion

        #region  max12CowsPerPLayerCanBePlaced
        //max of 12 placements per player are allowed

        [Test]

        public void max12CowsPerPLayerCanBePlaced()
        {
            IBoard board = Substitute.For<Board>();
            IPlayer player1 = new Player("H", Team.DarkCow, board);
            IPlayer player2 = Substitute.For<IPlayer>();
            Umpire U = new Umpire(player1, player2);
            Assert.That(U.validatePlacing("a0") == true && player1.numCowsToPlace() == 12); // this is to test the amount of cows that have still to placed and that the placeing still works
            while (player1.numCowsToPlace() != 1)
                player1.removePlacedCow();
            Assert.That(U.validatePlacing("a0") == true && player1.numCowsToPlace() == 1); // this is to show when there are still cows to place than we can place 
            player1.removePlacedCow();
            Assert.That(U.validatePlacing("a0") == false && player1.numCowsToPlace() == 0); // when there are no cows to place than you cannot place anymore.
        }
        #endregion


        #region  Cows cannot be moved during placement
        [Test]
        public void cowscantMoveDuringPlacingPhase()
        {
            IBoard b = Substitute.For<Board>();
            List<INode> temp = b.getMainNodeList();
            IPlayer player1 = new Player("p1", Team.DarkCow, b); // new player has yet to place
            IPlayer player2 = Substitute.For<IPlayer>();      //   player1.makeCowsToPlace(player1.Team);
            Umpire U = new Umpire(player1, player2);

            Assert.That(player1.numCowsToPlace() == 12); // show that its new player
            int cowsToPlace = 12;
            for (int i = 0; i < 6; i++) // to place alot of cows but not all so that placing is still going
            {                        // it also places them in order so we know what nodes are empty
                Assert.That(player1.numCowsToPlace() == cowsToPlace - i);
                player1.Placing(temp[i].Position);
            }
            Assert.That(U.validateMove("b5 c4") == false);
            Assert.That(U.validateMove("b5 d5") == false);
            Assert.That(U.validateMove("b3 c3") == false);
            Assert.That(U.validateMove("b1 c2") == false);
            Assert.That(U.validateMove("b1 d1") == false);
            Assert.That(U.validateMove("a0 d0") == false);
        }
        #endregion

        #region Cow can only move to a connected space
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

        #region  Cows cannot be moved during placement
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void cowscantMoveDuringPlacingPhase(int index, string inputNode, string[] neighbours)
        {
            IBoard b = Substitute.For<Board>();
            List<INode> temp = b.getMainNodeList();
            IPlayer player1 = new Player("p1", Team.DarkCow, b); // new player has yet to place
            IPlayer player2 = Substitute.For<IPlayer>();      //   player1.makeCowsToPlace(player1.Team);
            Umpire U = new Umpire(player1, player2);

            Assert.That(player1.numCowsToPlace() == 12); // show that its new player
            int cowsToPlace = 12;
            for (int i = 0; i < 6; i++) // to place alot of cows but not all so that placing is still going
            {                        // it also places them in order so we know what nodes are empty
                Assert.That(player1.numCowsToPlace() == cowsToPlace - i);
                player1.Placing(temp[i].Position);
            }
            foreach (string s in neighbours)
            {
                string move = String.Format("{0} {1}", inputNode, s);
                Assert.That(U.validateMove(move) == false);
            }
        }
        #endregion

        #region Cow can only move to a connected space


        //Cow can only move to a connected space
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void cowsCanMoveToAConnectedSpace(int index, string cowName, string[] neighbours)
        {
            IBoard b = Substitute.For<Board>();
            IPlayer player1 = new Player("hello", Team.DarkCow, b);
            player1.Placing(cowName);
            IPlayer player2 = Substitute.For<IPlayer>();      //   player1.makeCowsToPlace(player1.Team);
            Umpire U = new Umpire(player1, player2);

            while (player1.numCowsToPlace() != 0)
            {
                player1.removePlacedCow();
            }
            foreach (string s in neighbours)
            {
                string input = String.Format("{0} {1}", cowName, s);
                Assert.That(U.validateMove(input) == true); // will show wheather it is possible to place a cow in a neighbouring node.

            }
        }


        //Cow can only move to a connected space part 2

        static object[] cowNonNeightbours =
       {
                     new object[] {0, "a0", new string[] { "a0", "a6", "b3", "b5", "c2", "c3", "c4", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {1, "a3", new string[] { "a3", "b1", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {2, "a6", new string[] { "a0", "a6", "b1", "b3", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {3, "b1", new string[] { "a3", "a6", "b1", "b5", "c3", "c4", "d0", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {4, "b3", new string[] { "a0", "a6", "b3", "c2", "c4", "d0", "d1", "d2", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {5, "b5", new string[] { "a0", "a3", "b1", "b5", "c2", "c3", "d0", "d1", "d2", "d4", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {6, "c2", new string[] { "a0", "a3", "a6", "b3", "b5", "c2", "c4", "d0", "d1", "d4", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
                     new object[] {7, "c3", new string[] { "a0", "a3", "a6", "b1",  "d0", "d1", "d2", "d5", "d6", "e2", "e3", "e4", "f1", "f3", "f5", "g0", "g3", "g6" } },
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

        [Test]
        [TestCaseSource(nameof(cowNonNeightbours))]
        public void cowsCanOnlyMoveToAConnectedSpace(int index, string cowName, string[] notNeighbours)
        {
            IBoard b = Substitute.For<Board>();
            IPlayer player1 = new Player("hello", Team.DarkCow, b);
            player1.Placing(cowName);
            IPlayer player2 = Substitute.For<IPlayer>();      //   player1.makeCowsToPlace(player1.Team);
            Umpire U = new Umpire(player1, player2);

            while (player1.numCowsToPlace() != 0)
            {
                player1.removePlacedCow();
            }
            foreach (string s in notNeighbours)
            {
                string input = String.Format("{0} {1}", cowName, s);
                Assert.That(U.validateMove(input) == false); // will show wheather it is possible to place a cow in a neighbouring node.

            }
        }
        #endregion

        #region cow can only move to an empty space
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void cowCanOnlyMoveToEmptySpace(int index, string cowName, string[] neighbours)
        {
            IBoard b = new Board();
            IPlayer player = new Player("te", Team.DarkCow, b);
            IPlayer player2 = Substitute.For<IPlayer>();
            Umpire U = new Umpire(player, player2);
            player.Placing(cowName);
            // Place cows in all neighbouring nodes
            foreach (string s in neighbours)
            {
                player.Placing(s);
            }
            // Attempt to move into neighbouring nodes
            foreach (string s in neighbours)
            {
                string input = String.Format("{0} {1}", cowName, s);
                Assert.That(U.validateMove(input) == false);
            }
        }
        #endregion

        #region moving does not increase or decrease the number of cows on the field
        static object[] moveCows =
        {
                    new object[] { new string[] { "a0", "a3", "a6", "b1", "b3", "b5" }, "b5 c4", 6},
                    new object[] {new string[] { "a0", "a3", "a6", "b1", "b3", "b5" }, "a0 d0", 6},
                    new object[] { new string[] { "a0", "a3", "a6", "b1", "b3", "b5" }, "b1 d1", 6},
                    new object[] { new string[] { "a0", "a3", "a6", "b1", "b3", "b5" }, "b1 c2", 6},
                    new object[] { new string[] { "a0", "a3", "a6", "b1", "b3", "b5" }, "b5 d5", 6},
                    new object[] { new string[] { "d1", "d2", "d0", "d4", "d5", "d6" }, "d2 c2", 6},
                    new object[] { new string[] { "f1", "f3", "f5", "g0", "g3", "g6" }, "f3 e3", 6},
                     new object[] { new string[] { "f1", "f3", "f5", "g0", "g3", "g6" }, "f5 d5", 6}
                };
        [Test]
        [TestCaseSource(nameof(cowNeightbours))]
        public void MovingDoesNotIncrOrDecrNumOfCowOnTheField(int index, string cowName, string[] neighbours)
        {
            IBoard b = new Board();
            IPlayer player = new Player("te", Team.DarkCow, b);
            player.Placing(cowName);
            int numCowsOnFieldBeforeMove = b.numOfCowsOntheField();
            foreach (string s in neighbours)
            {
                INode startNode = b.getNodeFromString(cowName);
                INode endNode = b.getNodeFromString(s);
                Assert.That(player.moveCow(startNode, endNode) == true && b.numOfCowsOntheField() == numCowsOnFieldBeforeMove);
                // Move the cow back to its original position
                player.moveCow(endNode, startNode);
            }
        }
        #endregion

        #region Cows can move to any empty space if only three cows of that team remain
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

        // 
        [Test]
        [TestCaseSource(nameof(allPossiblePlaces))]
        public void CowsMoveToAnyEmptySpaceWhenFlying(int index, string cowName, string[] possibleMoves)
        {
            IBoard b = new Board();
            IPlayer player = new Player("te", Team.DarkCow, b);
            IPlayer player2 = Substitute.For<IPlayer>();
            Umpire U = new Umpire(player, player2);
            // int AmountOfAliveCows = 12;
            while (player.numCowsAlive() != 3)
            {
                player.Placing(cowName);
                b.RemoveCow(index, player);
            }
            while (player.numCowsToPlace() != 1)
                player.removePlacedCow();
            player.Placing(cowName);
            foreach (string s in possibleMoves)
            {
                string input = string.Format("{0} {1}", cowName, s);
                Assert.That(U.validateFlying(input) == true);
            }

        }
        #endregion

        #endregion

        //#region Cows can move to any empty space if only three cows of that team remain

        //[Test]
        //public void winOccursIfOpponentHasTwoOrFewerCows ()
        //{
        //    IBoard b = Substitute.For<Board>();
        //    List<INode> temp = b.getMainNodeList();
        //    IPlayer player1 = Substitute.For<IPlayer>();
        //    IPlayer player2 = Substitute.For<IPlayer>();     
        //    Umpire U = new Umpire(player1, player2);
        //    player2.numCowsAlive().Returns(2);
        //    Assert.That(U.win()== true); 
        //}

        //#endregion


        #region Mill formed by three cows in a row

        static object[] millCheck =
            {
                        new object[] {"a0","a3","a6",true},
                        new object[] {"d0","d1","d2", true},
                        new object[] {"d1","d2","d4", false },
                        new object[] {"a0","b1","c2",true},
                        new object[] {"g3","f3","e3", true},
                        new object[] {"g6","g3","f3", false},
                        new object[] {"g0","f1","e2", true},
                        new object[] {"f1","f3","f5", true},
                        new object[] {"b5","d0","a6", false}
                    };

        [Test]
        [TestCaseSource(nameof(millCheck))]
        public void testMillFormedByThreeCowsInALine(string num1, string num2, string num3, bool expect)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer II", Team.DarkCow, b);
            IPlayer p2 = new Player("tehe", Team.LightCow, b);
            Umpire U = new Umpire(p, p2);
            p.Placing(num1);
            p.Placing(num2);
            p.Placing(num3);
            Assert.That(U.millFormed(p.getLastNode()) == expect);

        }
        #endregion

        #region cows for a mill only when in a line
        static object[] MillsWithTwoTeamsAndNotInStraightLine = {
                    new object[] {"a0","a3","a6",true },
                    new object[] {"a0","c2","d1",false},
                    new object[] {"d0","d1","f3",false},
                    new object[] {"g6","g3","f3",false }

                    };


        [Test]
        [TestCaseSource(nameof(MillsWithTwoTeamsAndNotInStraightLine))]
        public void CowsCanNotFormMillWhenNotInLineAndNotOnTheSameTeam(string num1, string num2, string num3, bool expect)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer II", Team.DarkCow, b);
            IPlayer p2 = new Player("tehe", Team.LightCow, b);
            Umpire pulpotine = new Umpire(p, p2);
            p.Placing(num1);
            p.Placing(num2);
            p.Placing(num3);
            Assert.That(pulpotine.millFormed(p.getLastNode()) == expect);


        }
        #endregion

        #region check mills with cows of a diff teams in them don't form
        static object[] CowsOfDiffTeamsInRowsOf3 = {
                    new object[] {"a0","a3","a6",false },
                    new object[] {"a0","d0","g0",false},
                    new object[] {"a0","b1","c2",false},
                    new object[] {"b1","b3","b5",false},
                    new object[] {"a3","b3","c3",false },
                    new object[] {"a6","b5","c4",false},
                    new object[] {"c2","c3","c4",false},
                    new object[] {"d0","d1","d2",false},
                    new object[] {"b1","d1","f1",false},
                    new object[] {"c2","d2","e2",false},
                    new object[] {"e2","f1","g0",false},
                    new object[] {"c4","d4","e4",false},
                    new object[] {"d4","d5","d6",false},
                    new object[] {"e2","e4","e3",false},
                    new object[] {"e4","f5","g6",false},
                    new object[] {"b5","d5","f5",false},
                    new object[] {"a6","d6","g6",false},
                    new object[] {"f1","f3","f5",false},
                    new object[] {"e3","f3","g3",false},
                    new object[] {"g6","g3","g0",false}
                };
        [Test]
        [TestCaseSource(nameof(CowsOfDiffTeamsInRowsOf3))]
        public void CheckMillsWithCowsOfDiffTeamsInThem(string num1, string num2, string num3, bool expect)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer II", Team.DarkCow, b);
            IPlayer p2 = new Player("tehe", Team.LightCow, b);
            Umpire pulpotine = new Umpire(p, p2);
            p.Placing(num1);
            p2.Placing(num2);
            p.Placing(num3);
            Assert.That(pulpotine.millFormed(p.getLastNode()) == expect);
        }
        #endregion





        #region shoot Occurs when a mill occurs
        static object[] CowsInMIllCanShoot = {

                    new object[] { new string[]{ "c2","c4","d4"}, new string[] {"a0","a3","a6" },"c4",false },
                    new object[] { new string[]{ "a0","g6","d6"}, new string[] {"c2","c3","c4" },"g6",false },
                    new object[] { new string[]{ "b5","d4","d6"}, new string[] { "f1","f3","f5"},"d4",false },
                    new object[] { new string[]{ "a3","a6","b3"}, new string[] {"e4","f5","g6" },"a6",false },
                    new object[] { new string[]{ "f1","g3","f5"}, new string[] {"c2","d2","e2" },"g3",false },
                    new object[] { new string[]{ "b1","d1","d2"}, new string[] {"b3","b5","d6" },"d1",true },
                    new object[] { new string[]{ "a0","c3","c4"}, new string[] { "g0","b3","a6"},"c3",true },
                    new object[] { new string[]{ "a0","f1","g6"}, new string[] { "c2","d0","d2"},"f1",true }
                };

        [Test]
        [TestCaseSource(nameof(CowsInMIllCanShoot))]
        public void ShootOccursWhenMillOccurs(string[] enemyCows, string[] currentPlayerCows, string chosenCow, bool expected)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer II", Team.DarkCow, b);
            IPlayer p2 = new Player("tehe", Team.LightCow, b);
            Umpire U = new Umpire(p, p2);
            p.Placing(currentPlayerCows[0]);
            p.Placing(currentPlayerCows[1]);
            p.Placing(currentPlayerCows[2]);
            p2.Placing(enemyCows[0]);
            p2.Placing(enemyCows[1]);
            p2.Placing(enemyCows[2]);
            U.millFormed(p.getLastNode()); // this will make the mill be checked 
            U.shoot(chosenCow); // this will shoot the cow given as a parameter
            Assert.That(p.getBoard().getNodeFromString(enemyCows[1]).getOccupied() == expected); // this will check that the node shoot at is empty and show that the cow choosen was 
            U.millFormed(p.getLastNode()); // again calls to see if a mill will be formed even if it is the same mill
            U.shoot(enemyCows[0]); // this will check that a mill will not fire after it has already fired
            INode tempCheck = p2.getBoard().getNodeFromString(enemyCows[0]);
            Assert.That(tempCheck.getOccupied() == true);
        }
        #endregion

        #region Cow in mill cannot be shot if other cows exist
        // the test sources bellow are in the following format
        // int[] all moves made during a game|| int[] all shots made during a game || the expected value of each shot 
        // note that the number in the arrays refer to the node index in the mainNodeList used for the board
        static object[] cowsInMillThatCantBeShot =
        {
                    new object[] { new string[] { "a3", "b1", "a0", "b3", "g0", "a6"}, new string[] { "a3", "b3"}, new string[] {"c2","c3","c4" },new bool[] { false, true } },
                    new object[] { new string[] { "a0","b1","a3","b3","a6"}, new string[] { "a3"}, new string[] { "c2", "c4", "c3" }, new bool[] { false } },
                    new object[] { new string[] { "d0","d2","a0","b1","a3","b3","a6","b5"}, new string[] {"d2", "a0"}, new string[] { "c2", "c3", "c4" }, new bool[] {true, false}},
                    new object[] { new string[] { "g0","c2","f1","d1","e2","d4","d2"}, new string[] {"d1","f1","d4"}, new string[] { "a0","a3","a6"}, new bool[] {true,false,true}},
                    new object[] { new string[] { "g0","c2","f1","d1","e2","e3","d2","d4","a0","d5","a3","d6"}, new string[] {"d1","f1","d4","a0"}, new string[] { "b1", "b5", "b3" }, new bool[] {true,false,false,true}},
                    new object[] { new string[] { "a0","a6","d0","d6","g6","g0","b1","b5","c2"}, new string[] {"g0"}, new string[] { "e2", "e3", "e4" }, new bool[] { false } }
                };

        [Test]
        [TestCaseSource(nameof(cowsInMillThatCantBeShot))]
        public void CowInMillCannotBeshotIfNonMillCowsExists(string[] moves, string[] shotsAtNodesTaken,string[] P2Moves, bool[] expected)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer III", Team.DarkCow,b);
            IPlayer p2 = new Player("Rebel Scum 2", Team.LightCow,b);
            Umpire U = new Umpire(p,p2);
            foreach(string x in moves)
            {
                p.Placing(x);
                U.millFormed(p.getLastNode());
            }
            U.changePlayers();
            foreach(string x in P2Moves)
            {
                p2.Placing(x);
            }
            Assert.That(U.millFormed(p2.getLastNode()) == true);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.That(U.nodeChecks(p.getBoard().getNodeFromString(shotsAtNodesTaken[i]))==expected[i]);

            }
            

        }
        #endregion

        #region testing shooting empty spaces
        //static object[] testCasesForShootingEmptyNode =
        //{
        //            //new object[] {new int[] {0,1,2}, new int[] {21,22,23},new string[] { "a0","a3","a6" }, true},
        //            //new object[] {new int[] {0,1,2}, new int[] {21,22,23},new string[] { "b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {3,4,5}, new int[] {21,22,23},new string[] { "b1","b3","b5" }, true},
        //            //new object[] {new int[] {3,4,5}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {6,7,8}, new int[] {21,22,23},new string[] { "c2","c3","c4" }, true},
        //            //new object[] {new int[] {6,7,8}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {9,10,11}, new int[] {21,22,23},new string[] { "d0", "d1", "d2" }, true},
        //            //new object[] {new int[] {9,10,11}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {12,13,14}, new int[] {21,22,23},new string[] {  "d4","d5","d6" }, true},
        //            //new object[] {new int[] {12,13,14}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2","e2","e3","e4","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {15,16,17}, new int[] {21,22,23},new string[] { "e2", "e3", "e4" }, true},
        //            //new object[] {new int[] {15,16,17}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4","d5","d6","f1","f3","f5","g0","g3","g6" }, false},
        //            //new object[] {new int[] {18,19,20}, new int[] {21,22,23},new string[] { "f1", "f3", "f5" }, true},
        //            //new object[] {new int[] {18,19,20}, new int[] {21,22,23},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6","e2","e3","e4","g0","g3","g6" }, false},
        //            //new object[] {new int[] {21,22,23}, new int[] {0,1,2},new string[] { "g0", "g3", "g6" }, true},
        //            //new object[] {new int[] {21,22,23}, new int[] {0,1,2},new string[] { "a0", "a3", "a6", "b1", "b3", "b5", "c2", "c3", "c4", "d0", "d1", "d2", "d4", "d5", "d6","e2","e3","e4", "f1", "f3", "f5" }, false},
        //            ////horizantal mills done
        //            //new object[] {new int[] {0,9,21}, new int[] {2,14,23},new string[] { "a0","d0","g0" }, true},
        //            //new object[] {new int[] {0,9,21}, new int[] {2,14,23}, new string[] {"b1","d1","f1","c2","d2","e2","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {3,10,18}, new int[] {2,14,23},new string[] { "b1", "d1", "f1" }, true},
        //            //new object[] {new int[] {3,10,18}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0","c2","d2","e2","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {6,11,15}, new int[] {2,14,23},new string[] { "c2", "d2", "e2" }, true},
        //            //new object[] {new int[] {6,11,15}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1","a3","b3","c3","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {1,4,7}, new int[] {2,14,23},new string[] { "a3", "b3", "c3" }, true},
        //            //new object[] {new int[] {1,4,7}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2","e3","f3","g3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {16,19,22}, new int[] {2,14,23},new string[] { "e3", "f3", "g3" }, true},
        //            //new object[] {new int[] {16,19,22}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3","c4","d4","e4","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {8,12,17}, new int[] {2,14,23},new string[] { "c4", "d4", "e4" }, true},
        //            //new object[] {new int[] {8,12,17}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3","b5","d5","f5","a6","d6","g6"}, false },
        //            //new object[] {new int[] {5,13,20}, new int[] {2,14,23},new string[] { "b5", "d5", "f5" }, true},
        //            //new object[] {new int[] {5,13,20}, new int[] {2,14,23}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3", "c4", "d4", "e4","a6","d6","g6"}, false },
        //            //new object[] {new int[] {2,14,23}, new int[] {0,9,21},new string[] { "a6", "d6", "g6" }, true},
        //            //new object[] {new int[] {2,14,23}, new int[] {0,9,21}, new string[] { "a0", "d0", "g0", "b1", "d1", "f1", "c2", "d2", "e2", "a3", "b3", "c3", "e3", "f3", "g3", "c4", "d4", "e4", "b5", "d5", "f5"}, false },
        //            //// vertical mills done
        //            //new object [] { new int[] { 0, 3, 6 }, new int[] { 2, 5, 8 }, new string[] { "a0","b1","c2"}, true },
        //            //new object [] { new int[] {0,3,6}, new int[] { 2,5,8}, new string[] { "a3","a6","b3","b5","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, false},
        //            //new object [] { new int[] { 21, 18, 15 }, new int[] { 2, 5, 8 }, new string[] { "g0","f1","e2"}, true },
        //            //new object [] { new int[] { 21, 18, 15 }, new int[] { 2,5,8}, new string[] { "a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e3","e4","f3","f5","g3","g6"}, false},
        //            //new object [] { new int[] { 17, 20, 23 }, new int[] { 2, 5, 8 }, new string[] { "e4","f5","g6"}, true },
        //            //new object [] { new int[] { 17, 20, 23 }, new int[] { 2,5,8}, new string[] { "a0","a3","a6","b1","b3","b5","c2","c3","c4","d0","d1","d2","d4","d5","d6","e2","e3","f1","f3","g0","g3"}, false},
        //            //new object [] { new int[] { 2,5,8 }, new int[] { 17,20,23 }, new string[] { "a6","b5","c4"}, true },
        //            //new object [] { new int[] { 2,5,8 }, new int[] { 17,20,23 }, new string[] { "a0","a3","b1","b3","c2","c3","d0","d1","d2","d4","d5","d6","e2","e3","e4","f1","f3","f5","g0","g3","g6"}, false}
        //            //// diagonal mills checks


        //        };


        //[Test]
        //[TestCaseSource(nameof(testCasesForShootingEmptyNode))]
        //public void CantShootEmptyNode(int[] enemyCows, string[] currentPlayerCows, string[] targetCows, bool expected)
        //{
        //    IBoard b = new Board();
        //    IPlayer p = new Player("Darth Grazer II", Team.DarkCow,b);
        //    IPlayer p2 = Substitute.For<IPlayer>();
        //    p.Placing(currentPlayerCows[0]);
        //    p.Placing(currentPlayerCows[1]);
        //    p.Placing(currentPlayerCows[2]);
        //    Umpire U = new Umpire(p,p2);
        //    for (int i = 0; i < targetCows.Length; i++)
        //    {
        //        Assert.That(U.nodeChecks(p.getBoard().getNodeFromString(targetCows[i])) == false);
        //        //U.play(p, p2);
        //        //U.millFormed(b.mainNodeList[currentPlayerCows[1]]); // this will make the mill be checked
        //        //Node n = b.getNodeFromString(targetCows[i]);// gets the target node
        //        //bool canShoot = U.nodeChecks(n);// checks if the node is empty || return fals if node is empty
        //        //Assert.That(canShoot == expected);
        //    }

        //}

        #endregion
        #region cannot Shoot Cows In Own Mill
        static object[] CowsInMills = {
                    new object[] { "a0","a3","a6"},
                    new object[] { "a0","d0","g0"},
                    new object[] { "a0","b1","c2"},
                    new object[] { "a3","b3","c3"},
                    new object[] { "a6","b5","c4"},
                    new object[] { "a6","d6","g6"},
                    new object[] { "b1","b3","b5"},
                    new object[] { "b1","d1","f1"},
                    new object[] { "b5","d5","f5"},
                    new object[] { "c2","c3","c4"},
                    new object[] { "c2","d2","e2"},
                    new object[] { "c4","d4","e4"},
                    new object[] { "d0","d1","d2"},
                    new object[] { "d4","d5","d6"},
                    new object[] { "e2","f1","g0"},
                    new object[] { "e2","e3","e4"},
                    new object[] { "e3","f3","g3"},
                    new object[] { "e4","f5","g6"},
                    new object[] { "f1","f3","f5"},
                    new object[] { "g0","g3","g6"}
                };

        [Test]
        [TestCaseSource(nameof(CowsInMills))]
        public void cannotShootCowsInOwnMill( string cow1, string cow2, string cow3)
        {
            IBoard b = new Board();
            IPlayer p = new Player("Darth Grazer II", Team.DarkCow,b);
            IPlayer p2 = new Player("Darth", Team.LightCow, b);
            Umpire U = new Umpire(p,p2);
            //Place cows on the board to form a mill
            p.Placing(cow1);
            p.Placing(cow2);
            p.Placing(cow3);
            U.millFormed(p.getLastNode());
            //Attempt to shoot those cows 
            U.millFormed(p.getLastNode()); // this will make the mill be checked 
            Assert.That(U.nodeChecks(p.getBoard().getNodeFromString(cow1)) == false);
            Assert.That(U.nodeChecks(p.getBoard().getNodeFromString(cow2)) == false);
            Assert.That(U.nodeChecks(p.getBoard().getNodeFromString(cow3)) == false);

        }
        #endregion

        #region Shot are removed from board
        static object[] ShotCowsAreRemovedFromBoardObjects =
        {
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "e4", "f5" }, "f5", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "e4", "f5" }, "e4", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "b1", "b5" }, "b5", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "b1", "b5" }, "b1", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "e2", "b3" }, "b3", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "e2", "b3" }, "e2", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d1", "e3" }, "e3", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d0", "e3" }, "d0", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d2", "d1" }, "d2", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d2", "d1" }, "d1", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d4", "d5" }, "d4", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "d4", "d5" }, "d5", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "f1", "d6" }, "d6", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "f1", "d6" }, "f1", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "f3", "g0" }, "f3", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "f3", "g0" }, "g0", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "g3", "g6" }, "g3", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "g3", "g6" }, "g6", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "c4", "c3" }, "c3", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "c4", "c3" }, "c4", 4 },
                    new object[] { new string[] { "a0", "a3", "a6" }, new string[] { "c2", "c3" }, "c2", 4 }

                };
        [Test]
        [TestCaseSource(nameof(ShotCowsAreRemovedFromBoardObjects))]
        public void ShotCowsAreRemovedFromBoard(string[] nodesInMill, string[] enemyCowsNotInMills, string EnemyToShoot, int expected)
        {
            IBoard b = new Board();
            IPlayer p1 = new Player("Darth Grazer V", Team.DarkCow,b);
            IPlayer p2 = new Player("Player 2", Team.LightCow,b);
            Umpire U = new Umpire(p1, p2);
            p1.Placing(nodesInMill[0]);
            p1.Placing(nodesInMill[1]);
            p1.Placing(nodesInMill[2]);
            p2.Placing(enemyCowsNotInMills[0]);
            p2.Placing(enemyCowsNotInMills[1]);
            Assert.That(p2.getBoard().numOfCowsOntheField() == expected + 1); // this asserts the number of cows are on the board before the mill is formed
            U.millFormed(p1.getLastNode());// this asserts the number of cows on the board goes down by one when a cow is shot.
            U.shoot(EnemyToShoot);
            Assert.That(p2.getBoard().numOfCowsOntheField() == expected); // this will show that the enemy cow got removed from the bored.

        }
        #endregion
    }

}


