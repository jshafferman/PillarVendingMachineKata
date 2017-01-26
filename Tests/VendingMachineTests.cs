using Libraries;
using NUnit.Framework;
using System;

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
        public void WhenCoinValueIsNullThenTheVendingMachineThrowsNullArgumentError()
        {
            Assert.Throws<ArgumentNullException>(new TestDelegate(NullCoinNameInsertCoin));
        }

        private void NullCoinNameInsertCoin()
        {
            sut.InsertCoin(null);
        }

        [Test]
        public void WhenCoinValueIsEmptyThenTheVendingMachineThrowsArugmentError()
        {
            Assert.Throws<ArgumentException>(new TestDelegate(EmptyCoinNameInsertCoin));
        }

        private void EmptyCoinNameInsertCoin()
        {
            sut.InsertCoin("");
        }

        [Test]
        public void WhenANickelIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("NICKEL");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.05", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenAnotherNickelIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("NICKEL");
            sut.InsertCoin("NICKEL");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenDimeIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("NICKEL");
            sut.InsertCoin("DIME");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.15", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenQuarterIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("NICKEL");
            sut.InsertCoin("QUARTER");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.30", message);
        }

        [Test]
        public void WhenADimeIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("DIME");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void WhenAQuarterIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin("QUARTER");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.25", message);
        }

        [Test]
        public void WhenAPennyIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsInsertCoinsMessage()
        {
            // Arrange
            sut.InsertCoin("PENNY");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("INSERT COINS", message);
        }

        [Test]
        public void WhenAPennyIsInsertedIntoTheVendingMachineThenVendingMachineReturnsPenny()
        {
            // Arrange
            sut.InsertCoin("PENNY");

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(1, returnTrayValue);
        }

        [Test]
        public void WhenANickelIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin("NICKEL");

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }

        [Test]
        public void WhenADimeIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin("DIME");

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }

        [Test]
        public void WhenAQuarterIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin("QUARTER");

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }
    }
}
