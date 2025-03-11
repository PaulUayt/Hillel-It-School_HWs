//Створiть та опишiть клас «Місто».

//Виконайте перевантаження

//+ (для  збільшення кількості жителів на вказану кількість),

//– (для зменшення кількості жителів на вказану кількість),

//== та != (перевірка на рівність/не рiвнiсть двох міст за кількістю жителів),

//< і > (перевірка на меншу чи більшу кількість мешканців),

//Використовуйте механізм властивостей полів класу.


namespace HW4_OperatorOverloading.Classes
{
    class City
    {
        private int _population = 0;
        public int Population
        {
            get => _population;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Population must be positive");
                }
                _population = value;
            }
        }

        public static City operator +(City a, int amount)
        {
            return new City { Population = a.Population + amount };
        }

        public static City operator -(City a, int amount)
        {
            return a.Population < amount ? new City { Population = 0 } : new City { Population = a.Population - amount };
        }

        public static bool operator ==(City a, City b) => a.Population == b.Population;
        public static bool operator !=(City a, City b) => a.Population != b.Population;
        public static bool operator >(City a, City b) => a.Population > b.Population;
        public static bool operator <(City a, City b) => a.Population < b.Population;
        public static bool operator >=(City a, City b) => a.Population >= b.Population;
        public static bool operator <=(City a, City b) => a.Population <= b.Population;
        public override string ToString() => $"Population: {Population}";
        public override bool Equals(object? obj) => obj is City city && Population == city.Population;
        public override int GetHashCode() => Population.GetHashCode();
    }
}
