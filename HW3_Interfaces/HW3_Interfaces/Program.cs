namespace HW3_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            MyArray myArray = new MyArray(new int[] { 1, -5, 34, 0, 5, 345, -2345 });
            myArray.Show();
            myArray.Show("Array from 1 to 5");

            // Task 2
            Console.WriteLine();
            Console.WriteLine("Avg: " + myArray.Avg());
            Console.WriteLine("Max: " + myArray.Max());
            Console.WriteLine("Min: " + myArray.Min());
            Console.WriteLine("Sum: " + myArray.Sum());
            Console.WriteLine("Search 5: " + myArray.Search(5));
            Console.WriteLine("Search 3: " + myArray.Search(3));

            // Task 3
            Console.WriteLine();
            myArray.SortAsc();
            myArray.Show("Sorted Asc");
            myArray.SortDesc();
            myArray.Show("Sorted Desc");
        }
    }
}