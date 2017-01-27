using System;
using System.Collections.Generic;

namespace Libraries
{
    public class VendingMachine
    {
        private const string InsertCoins = "INSERT COINS";
        private const string ExactChange = "EXACT CHANGE ONLY";
        private const string FloatPrecision = "n2";
        private const string Cola = "COLA";
        private const string Chips = "CHIPS";
        private const string Candy = "CANDY";
        private const string Nickel = "NICKEL";
        private const string Dime = "DIME";
        private const string Quarter = "QUARTER";

        private string displayMessage;
        private string productDispensed;

        private int returnedCoins;
        private int totalCoinsAccepted;
        private int priceOfProduct;
        private int totalCoinValueInMachine;

        private Dictionary<String, int> coinValues;
        private Dictionary<String, int> coinInMachine;
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
                    if(totalCoinValueInMachine == 0)
                    {
                        displayMessage = ExactChange;
                    }
                    else
                    {
                        displayMessage = InsertCoins;
                    }
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

        // I am making an assumption that when a vending machine is created
        // that you will need to specify the amount of nickels, dimes, and quarters
        // that will be initially in the machine
        public VendingMachine(int numberOfNickels, int numberOfDimes, int numberOfQuarters)
        {
            returnedCoins = 0;
            totalCoinsAccepted = 0;
            productDispensed = string.Empty;

            coinValues = new Dictionary<string, int>
            {
                { Nickel, 5 },
                { Dime, 10 },
                { Quarter, 25 }
            };

            coinInMachine = new Dictionary<string, int>
            {
                { Nickel, numberOfNickels },
                { Dime, numberOfDimes },
                { Quarter, numberOfQuarters }
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

            totalCoinValueInMachine = calculateTotalInMachine();

            displayMessage = determineDisplayMessage();
        }

        private string determineDisplayMessage()
        {
            // Not the most efficient way to solve this issue, however it does give us
            // the correct default message and can be adjusted now that tests are in place
            foreach(var price in productPrice.Values)
            {
                var productPrice = price;

               foreach(var coin in coinValues)
                {
                    var coinValue = coin.Value;
                    var coinName = coin.Key;

                    int numberOfCoins = productPrice / coinValue;

                    if(numberOfCoins > 0 && numberOfCoins <= coinInMachine[coinName])
                    {
                        productPrice = productPrice - (numberOfCoins * coinValue);
                    }

                    if(productPrice == 0)
                    {
                        return InsertCoins;
                    }
                }
            }

            return ExactChange;
        }

        private int calculateTotalInMachine()
        {
            int total = coinInMachine[Nickel] * 5 + coinInMachine[Dime] * 10 + coinInMachine[Quarter] * 25;

            return total;
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

            totalCoinValueInMachine += totalCoinsAccepted;
        }

        private int convertCoinNameToCoinValue(string coinName)
        {
            int value;

            coinValues.TryGetValue(coinName, out value);

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

            totalCoinValueInMachine -= totalCoinsAccepted;

            totalCoinsAccepted = 0;

            
            displayMessage = InsertCoins;
        }

        public void AddProductToMachine(string productName)
        {
            numberOfProductInMachine[productName]++;
        }
    }
}
