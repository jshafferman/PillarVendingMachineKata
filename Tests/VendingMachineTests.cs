using Libraries;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        private VendingMachine sut;

        [SetUp]
        public void Init()
        {
            sut = new VendingMachine();
        }

        [Test]
        public void WhenNoCoinsHaveBeenAddedToTheVendingMachineThenVendingMachineDisplaysInsertCoinsMessage()
        {
            // Arrange

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("INSERT COINS", message);
        }

        [Test]
        public void GivenANickelIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("NICKEL");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.05", message);
        }

        [Test]
        public void GivenADimeIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("DIME");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }
    }
}
