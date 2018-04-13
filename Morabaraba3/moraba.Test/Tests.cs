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




        [Test]
        public void AboardHas24Nodes()
        {
            Board b = new Board();
            int numOfNodes = b.getMainNodeList().Count();
            Assert.That(numOfNodes == 24);
        }

        [Test]
        public void PlayerWithTheDarkCowsGoFirst()
        {

        }

        [Test]
        [TestCaseSource(nameof(inMill))]
        public void testcanShootMethodTrue (List<Node> tryMill ,bool expected)
        {
          
        }
    }
}
