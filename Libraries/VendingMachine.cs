using System;
using System.Collections.Generic;

namespace Libraries
{
    public class VendingMachine
    {
        private const string InsertCoins = "INSERT COINS";
        private const string FloatPrecision = "n2";
        private const string Cola = "COLA";
        private const string Chips = "CHIPS";
        private const string Candy = "CANDY";

        private string displayMessage;
        private string productDispensed;

        private int returnedCoins;
        private int totalCoinsAccepted;
        private int priceOfProduct;

        private Dictionary<String, int> coin;
        private Dictionary<String, int> productPrice;
        private Dictionary<String, int> numberOfProductInMachine;

        public string Display
        {
            get
            {
                string currentMessage = displayMessage;

                // CQRS being violated here, however it appears to be part of the acceptance criteria
                if (totalCoinsAccepted == 0)
                {
                    displayMessage = InsertCoins;
                }
                else
                {
                    displayMessage = convertIntToString(totalCoinsAccepted);
                }

                return currentMessage;
            }
        }

        public int ReturnedCoins
        {
            get
            {
                return returnedCoins;
            }
        }

        public string ProductDispensed
        {
            get
            {
                string currentProduct = productDispensed;

                // CQRS being violated, this is not explicitly demanded by the acceptance criteria
                // however I still feel the object that is dispensed should not show up twice
                productDispensed = string.Empty;

                return currentProduct;
            }
        }

        public VendingMachine()
        {
            displayMessage = InsertCoins;
            returnedCoins = 0;
            totalCoinsAccepted = 0;
            productDispensed = string.Empty;

            coin = new Dictionary<string, int>
            {
                { "NICKEL", 5 },
                { "DIME", 10 },
                { "QUARTER", 25 }
            };

            productPrice = new Dictionary<string, int>
            {
                { Cola , 100 },
                { Chips, 50 },
                { Candy, 65 }
            };

            numberOfProductInMachine = new Dictionary<string, int>
            {
                { Cola, 0 },
                { Chips, 0 },
                { Candy, 0 }
            };
        }

        public void InsertCoin(string coinName)
        {
            if(String.IsNullOrWhiteSpace(coinName))
            {
                throw new InvalidCoinNameVendingMachineException(coinName);
            }

            int coinValue = convertCoinNameToCoinValue(coinName);

            if (coinValue == 0)
            {
                returnedCoins = 1;
            }

            totalCoinsAccepted += coinValue;

            if(totalCoinsAccepted > 0)
            {
                displayMessage = convertIntToString(totalCoinsAccepted);
            }
        }

        private int convertCoinNameToCoinValue(string coinName)
        {
            int value;

            coin.TryGetValue(coinName, out value);

            return value;
        }

        public void SelectProduct(string productName)
        {
            int value;

            if(!productPrice.TryGetValue(productName, out value))
            {
                throw new InvalidProductNameVendingMachineException(productName);
            }

            priceOfProduct = value;

            int numberInMachine = numberOfProductInMachine[productName];

            if (numberInMachine > 0)
            {
                if(priceOfProduct <= totalCoinsAccepted)
                {
                    displayMessage = "THANK YOU";

                    productDispensed = productName;

                    returnedCoins = totalCoinsAccepted - priceOfProduct;

                    totalCoinsAccepted = 0;
                }
                else
                {
                    displayMessage = convertIntToString(priceOfProduct);
                }
            }
            else
            {
                displayMessage = "SOLD OUT";
            }
        }

        private string convertIntToString(int value)
        {
            float floatValue = value / 100.0f;

            return floatValue.ToString(FloatPrecision);
        }

        public void SelectReturnCoins()
        {
            returnedCoins = totalCoinsAccepted;

            totalCoinsAccepted = 0;

            displayMessage = InsertCoins;
        }

        public void AddProductToMachine(string productName)
        {
            numberOfProductInMachine[productName]++;
        }
    }
}
