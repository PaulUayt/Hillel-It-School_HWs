using HW2_OOP_Principle.Task_1;
using HW2_OOP_Principle.Task_2.Musical_Instruments;

namespace HW2_OOP_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------------------------------------
            // Task 1: class Money and class Product
            // ------------------------------------------------------------
            //Product product1 = new Product("Iphone 7s", 10, 56);
            //product1.ShowProduct();

            //Console.WriteLine();
            //product1.ProductName = "Iphone X";
            //product1.SetAmount(15, 99);
            //product1.ShowProduct();

            //Console.WriteLine();
            //product1.DecreaseAmount(7);
            //product1.ShowProduct();

            //Console.WriteLine();
            //Product product2 = new Product("Xiaomi", 5, 25);
            //product2.ShowProduct();

            //Console.WriteLine();
            //product2.ProductName = "Xiaomi 10";
            //product2.DecreaseAmount(4.5m);
            //product2.ShowProduct();

            //// Checking on exepction
            ////product2.SetAmount(6, 101);
            ////product2.SetAmount(-3, 89);

            // ------------------------------------------------------------
            // Task 2: 
            // ------------------------------------------------------------
            Skripka skripka = new Skripka("Medium", "2.5 kg", "Wood", "Skripka", 
                "Sound Skripka", "Desc Skripka", "History Skripka");
            skripka.Show();

            Trombon trombon = new Trombon("Brass", "1.5 m", "0.3 m", "Trombon", 
                "Sound Trombon", "Desc Trombon", "History Trombon");
            trombon.Sound();

            Ukulele ukulele = new Ukulele("Small", "4", "Wood", "Ukulele",
                "Sound Ukulele", "Desc Ukulele", "History Ukulele");
            ukulele.Desc();

            Violenchel violenchel = new Violenchel("Big", "Wood", "Bow", "Violenchel",
                "Sound Violenchel", "Desc Violenchel", "History Violenchel");
            violenchel.History();

            Console.WriteLine("\n---- INFO about instruments ----");
            skripka.ShowInfo();
            trombon.ShowInfo();
            ukulele.ShowInfo();
            violenchel.ShowInfo();

            // ------------------------------------------------------------
            // Task 3: 
            // ------------------------------------------------------------

        }
    }
}