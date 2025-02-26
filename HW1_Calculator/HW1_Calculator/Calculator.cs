using System;

public class Calculator
{
    public static double Add(double num1, double num2) => num1 + num2;
    public static double Subtract(double num1, double num2) => num1 - num2;
    public static double Multiply(double num1, double num2) => num1 * num2;
    public static double Divide(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return num1 / num2;
    }
    public static double Modulo(double num1, double num2)
    {
        if (num2 == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return num1 % num2;
    }
    public static double Power(double num1, double num2) => Math.Pow(num1, num2);
    public static double Average(double a, double b) => (a + b) / 2;
    public static double Root(double a, double b)
    {
        if (a < 0 && b % 2 == 0)
        {
            throw new ArithmeticException("Cannot calculate root of a negative number.");
        }
        return Math.Pow(a, 1.0 / b);
    }
}

