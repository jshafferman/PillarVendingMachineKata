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

        private float returnedCoins;
        private float totalCoinsAccepted;
        private float priceOfProduct;

        private Dictionary<String, float> coin;
        private Dictionary<String, float> productPrice;

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
                    displayMessage = totalCoinsAccepted.ToString(FloatPrecision);
                }

                return currentMessage;
            }
        }

        public float ReturnedCoins
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

            coin = new Dictionary<string, float>
            {
                { "NICKEL", 0.05f },
                { "DIME", 0.10f },
                { "QUARTER", 0.25f }
            };

            productPrice = new Dictionary<string, float>
            {
                { "COLA", 1.00f },
                { "CHIPS", 0.50f },
                { "CANDY", 0.65f }
            };
        }

        public void InsertCoin(string coinName)
        {
            if(String.IsNullOrWhiteSpace(coinName))
            {
                throw new InvalidCoinNameVendingMachineException(coinName);
            }

            float coinValue = convertCoinNameToCoinValue(coinName);

            if (coinValue == 0)
            {
                returnedCoins = 1;
            }

            totalCoinsAccepted += coinValue;

            if(totalCoinsAccepted > 0)
            {
                displayMessage = totalCoinsAccepted.ToString(FloatPrecision);
            }
        }

        private float convertCoinNameToCoinValue(string coinName)
        {
            float value;

            coin.TryGetValue(coinName, out value);

            return value;
        }

        public void SelectProduct(string productName)
        {
            float value;

            if(!productPrice.TryGetValue(productName, out value))
            {
                throw new InvalidProductNameVendingMachineException(productName);
            }

            priceOfProduct = value;

            if (priceOfProduct <= totalCoinsAccepted)
            {
                displayMessage = "THANK YOU";

                productDispensed = productName;

                totalCoinsAccepted = 0;
            }
            else
            {
                displayMessage = priceOfProduct.ToString(FloatPrecision);
            }
        }
    }
}
