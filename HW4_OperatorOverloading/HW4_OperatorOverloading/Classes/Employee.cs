//Створiть та опишiть клас «Співробітник».

//Додайте до вже створеного класу інформацію про заробітну плату працівника.

//Виконайте перевантаження

//+ (для збільшення зарплати на вказану кількість),

//– (для зменшення зарплати на вказану кількість),

//== та != (перевірка на рівність/не рiвнiсть зарплат працівників),

//< і > (перевірка на меншу чи більшу кількість зарплат працівників),

//Використовуйте механізм властивостей полів класу.

namespace HW4_OperatorOverloading.Classes
{
    public class Employee
    {
        private double _salary = 0.0;
        public double Salary
        {
            get => _salary;
            set
            {
                if (value < 0.0)
                {
                    throw new Exception("Salary must be positive");
                }
                _salary = value;
            }
        }

        public static Employee operator +(Employee a, double amount)
        {
            return new Employee { Salary = a.Salary + amount };
        }

        public static Employee operator -(Employee a, double amount)
        {
            return a.Salary < amount ? new Employee { Salary = 0 } : new Employee { Salary = a.Salary - amount };
        }

        public static bool operator ==(Employee a, Employee b) => a.Salary == b.Salary;
        public static bool operator !=(Employee a, Employee b) => a.Salary != b.Salary;
        public static bool operator >(Employee a, Employee b) => a.Salary > b.Salary;
        public static bool operator <(Employee a, Employee b) => a.Salary < b.Salary;
        public static bool operator >=(Employee a, Employee b) => a.Salary >= b.Salary;
        public static bool operator <=(Employee a, Employee b) => a.Salary <= b.Salary;
        public override string ToString() => $"Salary: {Salary}";
        public override bool Equals(object? obj) => obj is Employee employee && Salary == employee.Salary;
        public override int GetHashCode() => Salary.GetHashCode();

    }
}
