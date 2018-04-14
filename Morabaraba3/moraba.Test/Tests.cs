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

        // Cows can only be placed on empty spaces
        [Test]
        public void cowsCanOnlyBePlacedOnEmptySpaces()
        {
            Board b = new Board();
            List<Node> temp = b.getMainNodeList();
            Player player1 = new Player("p1", Team.DarkCow);
            player1.makeCowsToPlace(player1.Team);
            Cow cow = new Cow(Team.LightCow);
            b.mainNodeList[2].addCow(cow); // added cows to nodes to show they are occupied
            b.Placing(b.mainNodeList[2].Position, player1); // tried to add a cow to an occupied node
            b.Placing(b.mainNodeList[10].Position, player1); // tried to add a cow to an empty node
            Assert.That(b.mainNodeList[2].Cow.Team == Team.LightCow); // this means that the new cow was not added to this node
            Assert.That(b.mainNodeList[10].Cow.Team == Team.DarkCow); // this shows that the new cow was added to the empty node
        }


        // max of 12 placements per player are allowed
        [Test]
        public void max12CowsPerPLayerCanBePlaced()
        {
            Player player = new Player("P1", Team.DarkCow);
            player.makeCowsToPlace(player.Team);
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
            player1.makeCowsToPlace(player1.Team);
            Assert.That(player1.numCowsToPlace() == 12); // show that its new player
            int cowsToPlace = 12;
            for (int i = 0; i < 6; i++) // to place alot of cows but not all so that placing is still going
            {                        // it also places them in order so we know what nodes are empty
                Assert.That(player1.numCowsToPlace() == cowsToPlace - i);
                b.Placing(b.mainNodeList[i].Position, player1);
            }
            Assert.That(b.Moving("b5 c4", player1) == false);

        }

        static object[] movingCowsConnectedSpace =
      {
            new object[] {0, "a0 b1",true},
            new object[] {5, "b5 c3", false},
            new object[] {5,"b5 c4",true },
            new object[] {9,"d0 a0",true },
            new object[] {22,"g3 g6", true },
            new object[] {14,"d6 a6",true},
            new object[] {21,"g0 d0", true },
            new object[] {23,"g6 a0",false},
            new object[] {23,"g6 a3",false }
        };
        //Cow can only move to a connected space
        [Test]
        [TestCaseSource(nameof(movingCowsConnectedSpace))]
        public void cowsCanOnlyMoveToAConnectedSpace(int place, string movingFrom, bool expected)
        {
            Board b = new Board();
            Player player = new Player("hello", Team.DarkCow);
            b.mainNodeList[place].addCow(player.CowsAlive[0]);
            Assert.That(b.Moving(movingFrom, player) == expected); // this is to show that the cow was moved out of the node
        }


        //cow can only move to an empty space
        static object[] cowsMoveToEmptySpace =
        {
            new object[] {0, 1, "a0 b1", true},
            new object[] {1, 0, "a3 a6", true},
            new object[] {2, 0, "a6 b5", true},
            new object[] {0, 3, "b1 a0", false},
            new object[] {4, 1, "b3 a3", false},
            new object[] {2, 2, "g5 a6", false},
            new object[] {6, 0, "c2 d2", true},
            new object[] {10, 11, "c3 c3", false},
            new object[] {8, 5, "c4 b5", false},
            new object[] {9, 0, "d0 g0", true},
            new object[] {10, 20, "d1 f1",true}
        };
        [Test]
        [TestCaseSource(nameof(cowsMoveToEmptySpace))]
        public void cowCanOnlyMoveToEmptySpace(int firstCow, int secondCow, string move, bool expected)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            b.mainNodeList[firstCow].addCow(player.CowsAlive[0]);
            b.mainNodeList[secondCow].addCow(player.CowsAlive[1]);
            Assert.That(b.Moving(move, player) == expected); // this is to show that the cow was moved out of the node
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
             new object[] { new int[] { 18, 19, 20, 21, 22, 23 }, "f5 d5", 6},
        };
        [Test]
        [TestCaseSource(nameof(moveCows))]
        public void MovingDoesNotIncrOrDecrNumOfCowOnTheField(int[] cows, string move, int total)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            b.mainNodeList[cows[0]].addCow(player.CowsAlive[0]);
            b.mainNodeList[cows[1]].addCow(player.CowsAlive[1]);
            b.mainNodeList[cows[2]].addCow(player.CowsAlive[2]);
            b.mainNodeList[cows[3]].addCow(player.CowsAlive[3]);
            b.mainNodeList[cows[4]].addCow(player.CowsAlive[4]);
            b.mainNodeList[cows[5]].addCow(player.CowsAlive[5]);
            Assert.That(b.Moving(move, player) == true && b.numOfCowsOntheField() == total); // this is to show that the cow was moved out of the node
        }

        static object[] FlyingcowsMoveToEmptySpace =
    {
            new object[] {9,0, 1, "a0 g6", true},
            new object[] {9,1, 0, "a3 g6", true},
            new object[] {9,2, 0, "a6 f5", true},
            new object[] {7,0, 3, "a0 g0", false},
            new object[] {6,4, 1, "b3 e3", false},
            new object[] {9,8, 2, "c4 a6", false},
            new object[] {9,6, 0, "c2 d2", true},
            new object[] {5,4, 11, "b3 b3", false},
            new object[] {7,2, 5, "a6 f5", false},
            new object[] {9,9, 0, "d0 g3", true},
            new object[] {9,10, 20, "d1 f1",true}
        };

        [Test]
        [TestCaseSource(nameof(FlyingcowsMoveToEmptySpace))]
        public void CowsMoveToAnyEmptySpaceWhenFlying(int AmountOfAliveCows, int firstCow, int secondCow, string move, bool expecte)
        {
            Board b = new Board();
            Player player = new Player("te", Team.DarkCow);
            while(AmountOfAliveCows!=0)
            {
                player.killCow("a0");
                AmountOfAliveCows--;
            }
            b.mainNodeList[firstCow].addCow(player.CowsAlive[0]);
            b.mainNodeList[secondCow].addCow(player.CowsAlive[1]);
            Assert.That(b.Flying(move, player) == expecte); // this is to show that the cow was moved out of the node

        }

 
        //[Test]
        //[TestCaseSource(nameof(inMill))]
        //public void testcanShootMethodTrue (List<Node> tryMill ,bool expected)
        //{

        //}


    }
}
