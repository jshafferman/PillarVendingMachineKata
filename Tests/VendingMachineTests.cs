using Libraries;
using NUnit.Framework;

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
        private const string Cola = "COLA";

        private VendingMachine sut;

        [SetUp]
        public void Init()
        {
            sut = new VendingMachine();

            var message = sut.Display;
            var returnTray = sut.ReturnedCoins;

            Assert.AreEqual(InsertCoins, message);
            Assert.AreEqual(0, returnTray);
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

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenColaProductIsSelectedThenPriceOfColaIsDisplayed()
        {
            // Arrange
            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("1.00", message);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenColaProductIsSelectedThenPriceOfColaIsDisplayed()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("1.00", message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenColaProductIsSelectedThenProductIsDispensed()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);

            // Act
            string product = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(Cola, product);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenColaProductIsSelectedThenDispenseProductIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);

            // Act
            string product = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(string.Empty, product);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenColaProductHasBeenDispensedThenDisplayShowsThankYou()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("THANK YOU", message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenDisplayHasAlreadyShownThankYouThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenColaProductPriceHasAlreadyBeenShownThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.SelectProduct(Cola);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenColaProductPriceHasAlreadyBeenShownThenDisplayShowsTotalAcceptedCoins()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.SelectProduct(Cola);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.25", message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenChipsProductHasBeenSelectedThenDisplayShowsPriceOfChips()
        {
            // Arrange
            sut.SelectProduct("CHIPS");

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.50", message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenChipPriceHasAlreadyBeenDisplayedThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.SelectProduct("CHIPS");
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenChipProductPriceHasAlreadyBeenDisplayedThenDisplayShowsTotalAcceptedCoins()
        {
            // Arrange
            sut.InsertCoin(Dime);
            sut.SelectProduct("CHIPS");
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual("0.10", message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenChipProductIsSelectedThenProductIsDispensed()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.SelectProduct("CHIPS");

            // Act
            string product = sut.ProductDispensed;

            // Assert
            Assert.AreEqual("CHIPS", product);
        }
    }
}
