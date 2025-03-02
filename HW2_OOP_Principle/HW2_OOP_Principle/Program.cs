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
            Product product1 = new Product("Iphone 7s", 10, 0.5m);
            product1.ShowProduct();

            Console.WriteLine();
            product1.ProductName = "Iphone X";
            product1.SetAmount(15, 0.8m);
            product1.ShowProduct();

            Console.WriteLine();
            product1.DecreaseAmount(7);
            product1.ShowProduct();

            Console.WriteLine();
            Product product2 = new Product("Xiaomi", 5, 0.34567m);
            product2.ShowProduct();

            Console.WriteLine();
            product2.ProductName = "Xiaomi 10";
            product2.DecreaseAmount(0.4567m);
            product2.ShowProduct();

            // Checking on exepction
            //product2.SetAmount(6, 1.1m);

            // ------------------------------------------------------------
            // Task 2: 
            // ------------------------------------------------------------

        }
    }
}