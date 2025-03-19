using HW6_GarbageCollector.Shop_Task2.Enums;
using System.Linq;

namespace HW6_GarbageCollector.Shop_Task2
{
    public class Shop
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ShopType ShopType { get; set; }

        public Shop(string name, string address, ShopType shopType)
        {
            Name = name;
            Address = address;
            ShopType = shopType;
        }

        public void ShowShopInfo() => Console.WriteLine(ToString());
        public override string ToString() => $"Shop: {Name}, Address: {Address}, Type: {ShopType}";

    }
}
