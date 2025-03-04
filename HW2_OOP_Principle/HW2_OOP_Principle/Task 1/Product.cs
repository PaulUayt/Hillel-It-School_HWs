namespace HW2_OOP_Principle.Task_1
{
    public class Product: Money
    {
        private string productName;

        public Product(string productName, int integralPartAmount, int fractionalPartAmount) : 
            base(integralPartAmount, fractionalPartAmount)
        {
            this.productName = productName;
        }
        public string ProductName { get; set; }
        public void DecreaseAmount(decimal amount)
        {
            decimal currentAmount = GetAmount();
            if (currentAmount < amount)
            {
                throw new ArgumentOutOfRangeException("Amount is not enough");
            }
            decimal newAmount = currentAmount - amount;
            IntegralPartAmount = (int)newAmount;
            FractionalPartAmount = (int)((newAmount - IntegralPartAmount)*100);
        }

        public void ShowProduct()
        {
            Console.WriteLine("Product: " + productName);
            ShowPrice();
        }
    }
}
