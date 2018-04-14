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
            Player player = new Player("hello",Team.DarkCow);
            b.mainNodeList[place].addCow(player.CowsAlive[0]);
            Assert.That(b.Moving(movingFrom, player) == expected); // this is to show that the cow was moved out of the node
        }


        // cow can only move to an empty space

  //      static object[] cowsMoveInEmptySpace =
  //{
  //          new object[] {}
  //      };
  //      [Test]
  //      [TestCaseSource(nameof(cowCanOnlyMoveToEmptySpace))]
  //      public void cowCanOnlyMoveToEmptySpace(int FirstNode, int SecondNode, bool PLaceCowInSecNode, bool expected)
  //      {
  //          Board b = new Board();
  //          Player player = new Player("te",Team.DarkCow);
  //          if (PLaceCowInSecNode)
  //          {
  //              b.mainNodeList[FirstNode].addCow(player.CowsAlive[0]);
  //              b.mainNodeList[SecondNode].addCow(player.CowsAlive[1]);
  //              b.Moving(b.mainNodeList[FirstNode].Position, b.mainNodeList[SecondNode].Position, player); 
  //              Assert.That((b.mainNodeList[FirstNode].Cow.Position != b.mainNodeList[SecondNode].Cow.Position)==expected);
  //          }
  //          else
  //          {
  //              b.mainNodeList[FirstNode].addCow(player.CowsAlive[0]);
  //              b.Moving(b.mainNodeList[FirstNode].Position, b.mainNodeList[SecondNode].Position, player);
  //              Assert.That(b.mainNodeList[FirstNode].occupied == !expected);
  //              Assert.That(b.mainNodeList[SecondNode].occupied == !expected);
  //          }
  //      }
        // moving does not increas or decrease the number of cows on the field

        [Test]

        public void MovingDoesNotIncrOrDecrNumOfCowOnTheField()
        {

        }


        [Test]
        public void MillsFormWhen3CowsAreInARowAndOnTheSameTeam(int[] nodeIndex,bool expected)
        {
            Board b = new Board();


        }

        //[Test]
        //[TestCaseSource(nameof(inMill))]
        //public void testcanShootMethodTrue (List<Node> tryMill ,bool expected)
        //{

        //}


    }
}
