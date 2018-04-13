using System;
using NUnit.Framework;
using System.Linq;
using NSubstitute;
using moraba;
namespace moraba.Test
{
    [TestFixture]
    public class Class1
    {
        
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
    }
}
