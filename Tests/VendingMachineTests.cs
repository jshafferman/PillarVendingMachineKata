﻿using Libraries;
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
    }
}
