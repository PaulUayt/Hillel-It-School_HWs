using HW2_OOP_Principle.Task_1;

namespace HW2_OOP_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // Task 1: class Money and class Product
            // ------------------------------------------------------------
            Product product1 = new Product("Iphone 7s", 10, 56);
            product1.ShowProduct();

            Console.WriteLine();
            product1.ProductName = "Iphone X";
            product1.SetAmount(15, 99);
            product1.ShowProduct();

            Console.WriteLine();
            product1.DecreaseAmount(7);
            product1.ShowProduct();

            Console.WriteLine();
            Product product2 = new Product("Xiaomi", 5, 25);
            product2.ShowProduct();

            Console.WriteLine();
            product2.ProductName = "Xiaomi 10";
            product2.DecreaseAmount(4.5m);
            product2.ShowProduct();

            // Checking on exepction
            //product2.SetAmount(6, 101);
            //product2.SetAmount(-3, 89);

            // ------------------------------------------------------------
            // Task 2: 
            // ------------------------------------------------------------



            // ------------------------------------------------------------
            // Task 3: 
            // ------------------------------------------------------------

        }
    }
}