using Libraries;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        private const string InsertCoins = "INSERT COINS";
        private const string Penny = "PENNY";
        private const string Nickel = "NICKEL";
        private const string Dime = "DIME";
        private const string Quarter = "QUARTER";

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
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void WhenCoinValueIsNullThenTheVendingMachineThrowsNullArgumentError()
        {
            Assert.Throws<InvalidCoinNameException>(new TestDelegate(NullCoinNameInsertCoin));
        }

        private void NullCoinNameInsertCoin()
        {
            sut.InsertCoin(null);
        }

        [Test]
        public void WhenCoinValueIsEmptyThenTheVendingMachineThrowsArugmentError()
        {
            Assert.Throws<InvalidCoinNameException>(new TestDelegate(EmptyCoinNameInsertCoin));
        }

        private void EmptyCoinNameInsertCoin()
        {
            sut.InsertCoin("");
        }

        [Test]
        public void WhenANickelIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.05", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenAnotherNickelIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);
            sut.InsertCoin(Nickel);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenDimeIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);
            sut.InsertCoin(Dime);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.15", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenQuarterIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);
            sut.InsertCoin(Quarter);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.30", message);
        }

        [Test]
        public void GivenANickelHasAlreadyBeenInsertedWhenAPennyIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);
            sut.InsertCoin(Penny);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.05", message);
        }

        [Test]
        public void WhenADimeIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void GivenADimelHasAlreadyBeenInsertedWhenAnotherDimeIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);
            sut.InsertCoin(Dime);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.20", message);
        }

        [Test]
        public void GivenADimeHasAlreadyBeenInsertedWhenNickelsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);
            sut.InsertCoin(Nickel);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.15", message);
        }

        [Test]
        public void GivenADimeHasAlreadyBeenInsertedWhenQuarterIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);
            sut.InsertCoin(Quarter);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.35", message);
        }

        [Test]
        public void GivenADimeHasAlreadyBeenInsertedWhenAPennyIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);
            sut.InsertCoin(Penny);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void WhenAQuarterIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.25", message);
        }

        [Test]
        public void GivenAQuarterlHasAlreadyBeenInsertedWhenAnotherQuarterIsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.50", message);
        }

        [Test]
        public void GivenAQuarterHasAlreadyBeenInsertedWhenNickelsInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Nickel);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.30", message);
        }

        [Test]
        public void GivenAQuarterHasAlreadyBeenInsertedWhenDimeInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Dime);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.35", message);
        }

        [Test]
        public void GivenAQuarterHasAlreadyBeenInsertedWhenAPennyInsertedThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Penny);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.25", message);
        }

        [Test]
        public void WhenAPennyIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsInsertCoinsMessage()
        {
            // Arrange
            sut.InsertCoin(Penny);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void WhenAPennyIsInsertedIntoTheVendingMachineThenVendingMachineReturnsPenny()
        {
            // Arrange
            sut.InsertCoin(Penny);

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(1, returnTrayValue);
        }

        [Test]
        public void WhenANickelIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Nickel);

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }

        [Test]
        public void WhenADimeIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Dime);

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }

        [Test]
        public void WhenAQuarterIsIsInsertedIntoVendingMachineThenReturnTrayIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Quarter);

            // Act
            float returnTrayValue = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(0, returnTrayValue);
        }
    }
}
