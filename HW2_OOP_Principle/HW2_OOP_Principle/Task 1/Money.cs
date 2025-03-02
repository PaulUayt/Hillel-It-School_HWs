namespace HW2_OOP_Principle.Task_1
{
    public class Money
    {
        private int integralPartAmount;
        private int fractionalPartAmount;

        public Money()
        {
            integralPartAmount = 0;
            fractionalPartAmount = 0;
        }
        public Money(int integralPartAmount, int fractionalPartAmount)
        {
            this.integralPartAmount = integralPartAmount;
            this.fractionalPartAmount = fractionalPartAmount;
        }

        public int IntegralPartAmount
        {
            get => integralPartAmount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Integral part shouldn't be negative");
                }
                integralPartAmount = value;
            }
        }

        public int FractionalPartAmount
        {
            get => fractionalPartAmount; 
            set 
            { 
                if (value < 0 || value > 99)
                {
                    throw new ArgumentOutOfRangeException("Fractional part must be in range [0, 99]");
                }
                fractionalPartAmount = value; 
            }
        }

        public decimal GetAmount()
        {
            return integralPartAmount + fractionalPartAmount/100m;
        }

        public void ShowPrice()
        {
            Console.WriteLine($"Price: " + GetAmount());
        }

        public void SetAmount(int integralPartAmount, int fractionalPartAmount)
        {
            IntegralPartAmount = integralPartAmount;
            FractionalPartAmount = fractionalPartAmount;
        }
    }
}
