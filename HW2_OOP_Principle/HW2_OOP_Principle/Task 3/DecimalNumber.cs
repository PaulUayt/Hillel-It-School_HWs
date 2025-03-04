namespace HW2_OOP_Principle.Task_3
{
    struct DecimalNumber(decimal number)
    {
        public string ConvertToSystem(int baseValue)
        {
            int integerPart = (int)number;
            decimal fractionalPart = number - integerPart;

            string integerResult = Convert.ToString(integerPart, baseValue).ToUpper();

            string fractionalResult = "";
            int precision = 6;

            for (int i = 0; i < precision; i++)
            {
                fractionalPart *= baseValue;
                int digit = (int)fractionalPart;
                fractionalResult += digit.ToString("X");
                fractionalPart -= digit;

                if (fractionalPart == 0)
                    break;
            }
            return fractionalResult.Length > 0 ? $"{integerResult}.{fractionalResult}" : integerResult;
        }
    }
}
