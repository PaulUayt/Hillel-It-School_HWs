//Створiть та опишiть клас «Кредитна картка».

//Додайте до вже створеного класу інформацію про суму грошей на картці.

//Виконайте перевантаження

//+ (для збільшення суми грошей на вказану кількість),

//– (для зменшення суми грошей на вказану кількість),

//== та != (перевірка на рівність/не рiвнiсть CVC коду),

//< і > (перевірка на меншу чи більшу кількість суми грошей),

//Використовуйте механізм властивостей полів класу.

namespace HW4_OperatorOverloading.Classes
{
    class CreditCard
    {
        public double Money { get; set; } = 0; // може бути від'ємним (як борг)
        private int _cvc = 0;
        public int CVC
        {
            get => _cvc;
            set
            {
                if (value < 100 || value > 999)
                {
                    throw new Exception("CVC must be 3 digits");
                }
                _cvc = value;
            }
        }

        public static CreditCard operator +(CreditCard a, double amount)
        {
            return new CreditCard { Money = a.Money + amount, CVC = a.CVC };
        }

        public static CreditCard operator -(CreditCard a, double amount)
        {
            return a.Money < amount ? new CreditCard { Money = 0, CVC = a.CVC } : new CreditCard { Money = a.Money - amount, CVC = a.CVC };
        }

        public static bool operator ==(CreditCard a, CreditCard b) => a.CVC == b.CVC;
        public static bool operator !=(CreditCard a, CreditCard b) => a.CVC != b.CVC;
        public static bool operator >(CreditCard a, CreditCard b) => a.Money > b.Money;
        public static bool operator <(CreditCard a, CreditCard b) => a.Money < b.Money;
        public static bool operator >=(CreditCard a, CreditCard b) => a.Money >= b.Money;
        public static bool operator <=(CreditCard a, CreditCard b) => a.Money <= b.Money;
        public override string ToString() => $"Money: {Money}, CVC: {CVC}";
        public override bool Equals(object? obj) => obj is CreditCard creditCard && Money == creditCard.Money;
        public override int GetHashCode() => Money.GetHashCode();
    }
}
