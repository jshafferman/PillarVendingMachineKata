namespace Libraries
{
    public class VendingMachine
    {
        private string displayMessage;
        private float returnedCoins;

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
        }

        public void InsertCoin(string coinName)
        {
            if(coinName == "NICKEL")
            {
                displayMessage = "0.05";
            }
            else if(coinName == "DIME")
            {
                displayMessage = "0.10";
            }
            else if(coinName == "QUARTER")
            {
                displayMessage = "0.25";
            }
            else
            {
                returnedCoins = 1;
            }
        }
    }
}
