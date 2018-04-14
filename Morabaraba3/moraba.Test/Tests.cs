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
            Umpire imp = new Umpire();
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
            Player player = new Player("P1",Team.DarkCow);
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
            Assert.That(b.mainNodeList[5].occupied == true && b.mainNodeList[5].Position == "b5"); // this to show that node has a cow and what the node is
            Assert.That(b.mainNodeList[8].occupied == false && b.mainNodeList[8].Position == "c4");//this line is to show that there is no cow in node c4 and we know that c4 is linked to b5 so cows can move between them
            b.Moving(b.mainNodeList[5].Position, b.mainNodeList[8].Position, player1); //
            Assert.That(b.mainNodeList[8].occupied == false); // to show that the Move method never moved the cow to the node c4

        }

        static object[] movingCowsConnectedSpace =
      {
            new object[] {1,2,true},
            new object[] {0,3, false},
            new object[] {1,4,true },
            new object[] {4,5,true },
            new object[] {22,23, true },
            new object[] {14,2,true},
            new object[] {21,9, true },
            new object[] {23,8,false},
            new object[] {15,4,false }
        };
        //Cow can only move to a connected space
        [Test]
        [TestCaseSource(nameof(movingCowsConnectedSpace))]
        public void cowsCanOnlyMoveToAConnectedSpace(int movingFrom, int movingTo, bool expected)
        {
            Board b = new Board();
            Player player = new Player("hello",Team.DarkCow);
            b.mainNodeList[movingFrom].addCow(player.CowsAlive[0]);
            b.Moving(b.mainNodeList[movingFrom].Position, b.mainNodeList[movingTo].Position, player);
            Assert.That(b.mainNodeList[movingFrom].occupied == !expected); // this is to show that the cow was moved out of the node
            Assert.That(b.mainNodeList[movingTo].occupied == expected); // this shows that the cow was moved 
            Assert.That((b.mainNodeList[movingFrom].neighbours.Contains(b.mainNodeList[movingTo].Position)) == expected); // this shows if the cows are connected together and through this we can see the corelation
        }


        // cow can only move to an empty space

        static object[] cowsMoveInEmptySpace =
  {
            new object[] {}
        };
        [Test]
        [TestCaseSource(nameof(cowCanOnlyMoveToEmptySpace))]
        public void cowCanOnlyMoveToEmptySpace(int FirstNode, int SecondNode, bool PLaceCowInSecNode, bool expected)
        {
            Board b = new Board();
            Player player = new Player("te",Team.DarkCow);
            if (PLaceCowInSecNode)
            {
                b.mainNodeList[FirstNode].addCow(player.CowsAlive[0]);
                b.mainNodeList[SecondNode].addCow(player.CowsAlive[1]);
                b.Moving(b.mainNodeList[FirstNode].Position, b.mainNodeList[SecondNode].Position, player); 
                Assert.That((b.mainNodeList[FirstNode].Cow.Position != b.mainNodeList[SecondNode].Cow.Position)==expected);
            }
            else
            {
                b.mainNodeList[FirstNode].addCow(player.CowsAlive[0]);
                b.Moving(b.mainNodeList[FirstNode].Position, b.mainNodeList[SecondNode].Position, player);
                Assert.That(b.mainNodeList[FirstNode].occupied == !expected);
                Assert.That(b.mainNodeList[SecondNode].occupied == !expected);
            }
        }
        // moving does not increas or decrease the number of cows on the field

        [Test]

        public void MovingDoesNotIncrOrDecrNumOfCowOnTheField()
        {

        }


        //[Test]
        //[TestCaseSource(nameof(inMill))]
        //public void testcanShootMethodTrue (List<Node> tryMill ,bool expected)
        //{

        //}


    }
}
