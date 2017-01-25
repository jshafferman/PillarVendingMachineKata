namespace Libraries
{
    public class VendingMachine
    {
        private string displayMessage;

        public string Display
        {
            get
            {
                return displayMessage;
            }
        }

        public VendingMachine()
        {
            displayMessage = "INSERT COINS";
        }

        public void InsertCoin(string coinName)
        {
            displayMessage = "0.05";
        }
    }
}
