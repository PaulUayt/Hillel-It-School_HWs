namespace HW2_OOP_Principle.Task_1
{
    public class Money
    {
        private decimal integralPartAmount;
        private decimal fractionalPartAmount;

        public Money()
        {
            integralPartAmount = 0.0m;
            fractionalPartAmount = 0.0m;
        }
        public Money(decimal integralPartAmount, decimal fractionalPartAmount)
        {
            this.integralPartAmount = integralPartAmount;
            this.fractionalPartAmount = fractionalPartAmount;
        }

        public decimal IntegralPartAmount
        {
            get => integralPartAmount;
            set { integralPartAmount = value; }
        }

        public decimal FractionalPartAmount
        {
            get => fractionalPartAmount; 
            set 
            { 
                if (value < 0.0m || value >= 1.0m)
                {
                    throw new ArgumentOutOfRangeException("Fractional part must be in range [0, 1)");
                }
                fractionalPartAmount = value; 
            }
        }

        public decimal GetAmount()
        {
            return integralPartAmount + fractionalPartAmount;
        }

        public void ShowAmount()
        {
            Console.WriteLine("Amount: " + GetAmount());
        }

        public void SetAmount(decimal integralPartAmount, decimal fractionalPartAmount)
        {
            IntegralPartAmount = integralPartAmount;
            FractionalPartAmount = fractionalPartAmount;
        }
    }
}
