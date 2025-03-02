namespace HW2_OOP_Principle.Task_1
{
    public class Product: Money
    {
        private string productName;

        public Product(string productName, decimal integralPartAmount, decimal fractionalPartAmount) : 
            base(integralPartAmount, fractionalPartAmount)
        {
            this.productName = productName;
            IntegralPartAmount = integralPartAmount;
            FractionalPartAmount = fractionalPartAmount;
        }
        public string ProductName
        {
            get => productName;
            set { productName = value; }

        }

        public void DecreaseAmount(decimal amount)
        {
            decimal currentAmount = GetAmount();
            if (currentAmount < amount)
            {
                throw new ArgumentOutOfRangeException("Amount is not enough");
            }
            decimal newAmount = currentAmount - amount;
            IntegralPartAmount = Math.Floor(newAmount);
            FractionalPartAmount = newAmount - Math.Floor(newAmount);
        }

        public void ShowProduct()
        {
            Console.WriteLine("Product: " + productName);
            ShowAmount();
        }
    }
}
