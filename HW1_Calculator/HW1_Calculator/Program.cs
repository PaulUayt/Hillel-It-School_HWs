public class Program
{
    public static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();

            try
            {
                Console.WriteLine("----CALCULATOR----\n\nList of operations with numbers A and B:\n1. Add\n2. Substract\n3. Multiply\n4. Divide\n" +
                    "5. Modulo\n6. Number A to the power of B\n7. Average of numbers A and B\n" +
                    "8. Calculates the root of the power B of number A.\n0. Exit\n");

                byte operation = GetOperation("Enter operation: ");

                if (operation == 0)
                {
                    isRunning = false;
                    break;
                }

                double num1 = GetNumber("\nEnter number A: ");
                double num2 = GetNumber("Enter number B: ");

                double result = PerformOperation(operation, num1, num2);
                Console.WriteLine($"\nResult: {result}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private static double GetNumber(string prompt)
    {
        double num;
        Console.WriteLine(prompt);
        while (!double.TryParse(Console.ReadLine(), out num))
        {
            Console.WriteLine("Invalid input. Please enter a number:");
        }
        return num;
    }

    private static byte GetOperation(string prompt)
    {
        byte operation;
        Console.Write(prompt);
        while (!byte.TryParse(Console.ReadLine(), out operation) || operation < 0 || operation > 8)
        {
            Console.WriteLine("Invalid operation. Please enter a number between 0 and 8:");
        }
        return operation;
    }

    private static double PerformOperation(byte operation, double num1, double num2)
    {
        return operation switch
        {
            1 => Calculator.Add(num1, num2),
            2 => Calculator.Subtract(num1, num2),
            3 => Calculator.Multiply(num1, num2),
            4 => Calculator.Divide(num1, num2),
            5 => Calculator.Modulo(num1, num2),
            6 => Calculator.Power(num1, num2),
            7 => Calculator.Average(num1, num2),
            8 => Calculator.Root(num1, num2),
            _ => throw new InvalidOperationException("Unknown operation.")
        };
    }

}