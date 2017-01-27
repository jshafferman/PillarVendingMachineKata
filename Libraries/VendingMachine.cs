using System;
using System.Collections.Generic;

namespace Libraries
{
    public class VendingMachine
    {
        private const string InsertCoins = "INSERT COINS";
        private const string FloatPrecision = "n2";

        private string displayMessage;
        private string productDispensed;

        private int returnedCoins;
        private int totalCoinsAccepted;
        private int priceOfProduct;

        private Dictionary<String, int> coin;
        private Dictionary<String, int> productPrice;

        public string Display
        {
            get
            {
                string currentMessage = displayMessage;

                // Note to self, state change in getter method is not a good idea
                if(totalCoinsAccepted == 0)
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

                // Again not a fan of state change in a getter method
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
                { "COLA", 100 },
                { "CHIPS", 50 },
                { "CANDY", 65 }
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

            if (priceOfProduct <= totalCoinsAccepted)
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

        public void SelectReturnCoins()
        {
            returnedCoins = totalCoinsAccepted;
        }

        private string convertIntToString(int value)
        {
            float floatValue = value / 100.0f;

            return floatValue.ToString(FloatPrecision);
        }
    }
}
