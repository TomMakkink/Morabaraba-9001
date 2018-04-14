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
            Assert.That(player1.numCowsToPlace() == 12); // show that its new player
            int cowsToPlace = 12;
            for (int i = 0; i < 6; i++) // to place alot of cows but not all so that placing is still going
            {                        // it also places them in order so we know what nodes are empty
                Assert.That(player1.numCowsToPlace() == cowsToPlace - i);
                b.Placing(b.mainNodeList[i].Position, player1);
            }
            Assert.That(b.mainNodeList[5].occupied == true && b.mainNodeList[5].Position == "b5");
            // the above is to show that node has a cow and what the node is
            Assert.That(b.mainNodeList[8].occupied == false && b.mainNodeList[8].Position == "c4");
            // the above line is to show that there is no cow in node c4 and we know that c4 is linked to b5 so cows can move between them
            b.Moving(b.mainNodeList[5].Position, b.mainNodeList[8].Position, player1); //
            Assert.That(b.mainNodeList[8].occupied == false); // to show that the Move method never moved the cow to the node c4

        }

        //[Test]
        //[TestCaseSource(nameof(inMill))]
        //public void testcanShootMethodTrue (List<Node> tryMill ,bool expected)
        //{

        //}


    }
}
