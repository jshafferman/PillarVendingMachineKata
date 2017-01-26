using System;
using System.Collections.Generic;

namespace Libraries
{
    public class VendingMachine
    {
        private string displayMessage;
        private float returnedCoins;
        private float totalCoinsAccepted;
        private Dictionary<String, float> coin;

        public string Display
        {
            get
            {
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

        public VendingMachine()
        {
            displayMessage = "INSERT COINS";
            returnedCoins = 0;
            totalCoinsAccepted = 0;

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

            if(totalCoinsAccepted > 0)
            {
                displayMessage = totalCoinsAccepted.ToString("n2");
            }
        }

        private float convertCoinNameToCoinValue(string coinName)
        {
            float value;

            coin.TryGetValue(coinName, out value);

            return value;
        }
    }
}
