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

        private bool isProductSelected;

        public string Display
        {
            get
            {
                if(isProductSelected)
                {
                    if(totalCoinsAccepted >= priceOfProduct)
                    {
                        displayMessage = "THANK YOU";

                        totalCoinsAccepted = 0;
                    }
                    else
                    {
                        displayMessage = priceOfProduct.ToString(FloatPrecision);
                    }

                    isProductSelected = false;
                }
                else
                {
                    if(totalCoinsAccepted == 0)
                    {
                        displayMessage = InsertCoins;
                    }
                    else
                    {
                        displayMessage = totalCoinsAccepted.ToString(FloatPrecision);
                    }
                }

                return displayMessage;
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
                return "COLA";
            }
        }

        public VendingMachine()
        {
            displayMessage = InsertCoins;
            returnedCoins = 0;
            totalCoinsAccepted = 0;
            isProductSelected = false;

            coin = new Dictionary<string, float>
            {
                { "NICKEL", 0.05f },
                { "DIME", 0.10f },
                { "QUARTER", 0.25f }
            };
        }

        public void InsertCoin(string coinName)
        {
            if(String.IsNullOrWhiteSpace(coinName))
            {
                throw new InvalidCoinNameException(coinName);
            }

            float coinValue = convertCoinNameToCoinValue(coinName);

            if (coinValue == 0)
            {
                returnedCoins = 1;
            }

            totalCoinsAccepted += coinValue;
        }

        private float convertCoinNameToCoinValue(string coinName)
        {
            float value;

            coin.TryGetValue(coinName, out value);

            return value;
        }

        public void SelectProduct(string productName)
        {
            if(productName == "COLA")
            {
                priceOfProduct = 1.00f;
            }
            else
            {
                priceOfProduct = 0.50f;
            }

            isProductSelected = true;
        }
    }
}
