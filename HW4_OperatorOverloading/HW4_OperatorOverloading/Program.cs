using HW4_OperatorOverloading.Classes;

public class Program
{
    public static void Main(string[] args)
    {
        // Task 1
        Console.WriteLine("---------Task 1---------");
        Employee a = new Employee { Salary = 1000 };
        Employee b = new Employee { Salary = 1200 };
        //Employee c = new Employee { Salary = -200 }; // exception

        a = a + 100;
        b = b - 100;

        Console.WriteLine("Salary 'a' : " + a.Salary);
        Console.WriteLine("Salary 'b' : " + b.Salary);
        Console.WriteLine(a == b);
        Console.WriteLine(a != b);
        Console.WriteLine(a > b);
        Console.WriteLine(a >= b);
        a = a - 100;
        Console.WriteLine(a < b);
        Console.WriteLine(a <= b);

        Console.WriteLine(a.Equals(b));
        Console.WriteLine(a.ToString());
        Console.WriteLine(a.GetHashCode());

        // Task 2
        Console.WriteLine("\n\n---------Task 2---------");
        City city = new City { Population = 10000 };
        City city2 = new City { Population = 20000 };
        //City city3 = new City { Population = -1 }; // exception

        city = city + 1000;
        city2 = city2 - 1000;

        Console.WriteLine("Population 'city' : " + city.Population);
        Console.WriteLine("Population 'city2' : " + city2.Population);
        Console.WriteLine(city == city2);
        Console.WriteLine(city != city2);
        Console.WriteLine(city > city2);
        Console.WriteLine(city >= city2);
        Console.WriteLine(city < city2);
        Console.WriteLine(city <= city2);

        Console.WriteLine(city.Equals(city2));
        Console.WriteLine(city.ToString());
        Console.WriteLine(city.GetHashCode());

        // Task 3
        Console.WriteLine("\n\n---------Task 3---------");
        CreditCard creditCard = new CreditCard { Money = 1000, CVC = 123 };
        CreditCard creditCard2 = new CreditCard { Money = 2000, CVC = 123 };
        //CreditCard creditCard3 = new CreditCard { Money = 2000, CVC = 1234 }; // exception

        creditCard = creditCard + 1000;
        creditCard2 = creditCard2 - 1000;

        Console.WriteLine("Money 'creditCard' : " + creditCard.Money);
        Console.WriteLine("Money 'creditCard2' : " + creditCard2.Money);
        Console.WriteLine(creditCard == creditCard2);
        Console.WriteLine(creditCard != creditCard2);
        Console.WriteLine(creditCard > creditCard2);
        Console.WriteLine(creditCard < creditCard2);
        Console.WriteLine(creditCard >= creditCard2);
        Console.WriteLine(creditCard <= creditCard2);

        Console.WriteLine(creditCard.Equals(creditCard2));
        Console.WriteLine(creditCard.ToString());
        Console.WriteLine(creditCard.GetHashCode());

        // Task 4
        Console.WriteLine("\n\n---------Task 4---------");
        double[,] predefinedMatrix = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };


        Matrix matrix = new(predefinedMatrix);
        Matrix matrix1 = new(predefinedMatrix);
        matrix.PrintMatrix();

        matrix += matrix;
        matrix.PrintMatrix();

        matrix *= matrix;
        matrix.PrintMatrix();

        matrix *= 10;
        matrix.PrintMatrix();

        matrix -= matrix;
        matrix.PrintMatrix();

        matrix1.PrintMatrix();

        Console.WriteLine(matrix == matrix1);
        Console.WriteLine(matrix != matrix1);


    }
}
