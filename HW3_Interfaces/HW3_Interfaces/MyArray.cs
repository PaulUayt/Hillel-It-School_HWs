using HW3_Interfaces.Interfaces;

namespace HW3_Interfaces
{
    class MyArray(int[] array) : IOutput, IMath, ISort
    {
        public void Show()
        {
            foreach (var item in array)
                Console.Write(item + " ");
            Console.WriteLine();
        }
        public void Show(string info)
        {
            Console.WriteLine(info + ": ");
            Show();
        }

        public float Avg() => (float)array.Average();
        public int Max() => array.Max();
        public int Min() => array.Min();
        public int Sum() => array.Sum();
        public bool Search(int valueToSearch) => array.Contains(valueToSearch);
        public void SortAsc() => Array.Sort(array);

        public void SortDesc()
        {
            Array.Sort(array);
            Array.Reverse(array);
        }

        public void SortByParametr(bool isAsk) => (isAsk ? (Action)SortAsc : SortDesc)();
    }
}
