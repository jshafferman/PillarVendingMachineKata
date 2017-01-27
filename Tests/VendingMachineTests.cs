using System;
using Libraries;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class VendingMachineTests
    {
        private const string InsertCoins = "INSERT COINS";
        private const string ThankYou = "THANK YOU";
        private const string SoldOut = "SOLD OUT";

        private const string Penny = "PENNY";
        private const string Nickel = "NICKEL";
        private const string Dime = "DIME";
        private const string Quarter = "QUARTER";

        private const string Cola = "COLA";
        private const string Chips = "CHIPS";
        private const string Candy = "CANDY";

        private const string NickelDisplayAmount = "0.05";
        private const string DimeDisplayAmount = "0.10";
        private const string QuarterDisplayAmount = "0.25";

        private const string ColaDisplayAmount = "1.00";
        private const string ChipsDisplayAmount = "0.50";
        private const string CandyDisplayAmount = "0.65";

        private VendingMachine sut;

        [SetUp]
        public void Init()
        {
            sut = new VendingMachine();

            var message = sut.Display;
            var returnTray = sut.ReturnedCoins;
            var productDispenser = sut.ProductDispensed;

            Assert.AreEqual(InsertCoins, message);
            Assert.AreEqual(0, returnTray);
            Assert.AreEqual(string.Empty, productDispenser);
        }

        [Test]
        public void WhenCoinValueIsNullThenTheVendingMachineThrowsInvalidCoinNameException()
        {
            Assert.Throws<InvalidCoinNameVendingMachineException>(new TestDelegate(NullCoinNameInsertCoin));
        }

        private void NullCoinNameInsertCoin()
        {
            sut.InsertCoin(null);
        }

        [Test]
        public void WhenCoinValueIsEmptyThenTheVendingMachineInvalidCoinNameException()
        {
            Assert.Throws<InvalidCoinNameVendingMachineException>(new TestDelegate(EmptyCoinNameInsertCoin));
        }

        private void EmptyCoinNameInsertCoin()
        {
            sut.InsertCoin(string.Empty);
        }

        [Test]
        public void WhenANickelIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Nickel);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(NickelDisplayAmount, message);
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
            Assert.AreEqual(DimeDisplayAmount, message);
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
            Assert.AreEqual(NickelDisplayAmount, message);
        }

        [Test]
        public void WhenADimeIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Dime);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(DimeDisplayAmount, message);
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
            Assert.AreEqual(DimeDisplayAmount, message);
        }

        [Test]
        public void WhenAQuarterIsInsertedIntoTheVendingMachineThenVendingMachineDisplayShowsTotalValue()
        {
            // Arrange
            sut.InsertCoin(Quarter);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(QuarterDisplayAmount, message);
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
            Assert.AreEqual(QuarterDisplayAmount, message);
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
            int returnTrayValue = sut.ReturnedCoins;

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
        public void GivenAProductHasBeenSelectedWhenProductNameIsInvalidThenInvalidProductNameExceptionIsThrown()
        {
            Assert.Throws<InvalidProductNameVendingMachineException>(new TestDelegate(InvalidProductNameSelected));
        }

        private void InvalidProductNameSelected()
        {
            sut.SelectProduct("");
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenColaProductIsSelectedThenPriceOfColaIsDisplayed()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ColaDisplayAmount, message);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenColaProductIsSelectedThenPriceOfColaIsDisplayed()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ColaDisplayAmount, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenColaProductIsSelectedThenProductIsDispensed()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

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
        public void GivenEnoughMoneyHasBeenInsertedWhenProductHasAlreadyBeenDispensedThenProductDispensedShouldBeEmpty()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);
            string productDispensed = sut.ProductDispensed;

            // Act
            string productInDispenser = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(string.Empty, productInDispenser);
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
        public void GivenEnoughMoneyHasBeenInsertedWhenColaProductHasBeenSelectedThenDisplayShowsThankYou()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ThankYou, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedForColaWhenDisplayHasAlreadyShownThankYouThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

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
            Assert.AreEqual(QuarterDisplayAmount, message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenChipsProductHasBeenSelectedThenDisplayShowsPriceOfChips()
        {
            // Arrange
            sut.AddProductToMachine(Chips);

            sut.SelectProduct(Chips);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ChipsDisplayAmount, message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenChipPriceHasAlreadyBeenDisplayedThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.SelectProduct(Chips);
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
            sut.SelectProduct(Chips);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(DimeDisplayAmount, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenChipProductHasBeenSelectedThenDisplayShowsThankYou()
        {
            // Arrange
            sut.AddProductToMachine(Chips);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Chips);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ThankYou, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedForChipsWhenDisplayHasAlreadyShownThankYouThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.AddProductToMachine(Chips);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Chips);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenChipProductIsSelectedThenProductIsDispensed()
        {
            // Arrange
            sut.AddProductToMachine(Chips);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.SelectProduct(Chips);

            // Act
            string productInDispenser = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(Chips, productInDispenser);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenChipProductHasAlreadyBeenDispensedThenProductInDispenserIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.SelectProduct(Chips);
            string productDispesned = sut.ProductDispensed;

            // Act
            string productInDispenser = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(string.Empty, productInDispenser);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenCandyProductHasBeenSelectedThenDisplayShowsPriceOfCandy()
        {
            // Arrange
            sut.AddProductToMachine(Candy);

            sut.SelectProduct(Candy);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(CandyDisplayAmount, message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenCandyPriceHasAlreadyBeenDisplayedThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.SelectProduct(Candy);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenNotEnoughMoneyHasBeenInsertedWhenCandyProductPriceHasAlreadyBeenDisplayedThenDisplayShowsTotalAcceptedCoins()
        {
            // Arrange
            sut.InsertCoin(Nickel);
            sut.SelectProduct(Candy);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(NickelDisplayAmount, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenCandyProductHasBeenSelectedThenDisplayShowsThankYou()
        {
            // Arrange
            sut.AddProductToMachine(Candy);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Dime);
            sut.InsertCoin(Nickel);

            sut.SelectProduct(Candy);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ThankYou, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedForCandyWhenDisplayHasAlreadyShownThankYouThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.AddProductToMachine(Candy);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Dime);
            sut.InsertCoin(Nickel);

            sut.SelectProduct(Candy);
            string firstMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenCandyProductIsSelectedThenProductIsDispensed()
        {
            // Arrange
            sut.AddProductToMachine(Candy);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Dime);
            sut.InsertCoin(Nickel);

            sut.SelectProduct(Candy);

            // Act
            string productInDispenser = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(Candy, productInDispenser);
        }

        [Test]
        public void GivenEnoughMoneyHasBeenInsertedWhenCandyProductHasAlreadyBeenDispensedThenProductInDispenserIsEmpty()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Dime);
            sut.InsertCoin(Nickel);

            sut.SelectProduct(Candy);

            string productDispesned = sut.ProductDispensed;

            // Act
            string productInDispenser = sut.ProductDispensed;

            // Assert
            Assert.AreEqual(string.Empty, productInDispenser);
        }

        [Test]
        public void GivenAProductHasBeenSelectedWhenAmountInVendingMachineIsHigherThanProdectThenCorrectChangeIsPlacedInCoinReturn()
        {
            // Arrange
            sut.AddProductToMachine(Candy);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectProduct(Candy);

            // Act
            int change = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(35, change);
        }

        [Test]
        public void GivenCoinsHaveBeenInsertedWhenReturnCoinsButtonIsPressedThenAmountOfCoinsIsInReturnTray()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectReturnCoins();

            // Act
            int value = sut.ReturnedCoins;

            // Assert
            Assert.AreEqual(100, value);
        }

        [Test]
        public void GivenCoinsHaveBeenInsertedWhenReturnCoinsButtonIsPressedThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectReturnCoins();

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }

        [Test]
        public void GivenCoinsHaveBeenReturnedWhenProductIsSelectedThenDisplayShowsProductAmount()
        {
            // Arrange
            sut.AddProductToMachine(Cola);

            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);
            sut.InsertCoin(Quarter);

            sut.SelectReturnCoins();
            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(ColaDisplayAmount, message);
        }

        [Test]
        public void GivenVendingMachineIsSoldOutOfProductWhenProductIsSelectedThenDisplayShowsSoldOutMessage()
        {
            // Arrange
            sut.SelectProduct(Cola);

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(SoldOut, message);
        }

        [Test]
        public void GivenNoMoneyHasBeenInsertedWhenDisplayHasAlreadyShownSoldOutThenDisplayShowsInsertCoins()
        {
            // Arrange
            sut.SelectProduct(Cola);

            string soldOutMessage = sut.Display;

            // Act
            string message = sut.Display;

            // Assert
            Assert.AreEqual(InsertCoins, message);
        }
    }
}
