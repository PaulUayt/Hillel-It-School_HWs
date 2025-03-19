using HW6_GarbageCollector.Action_Task1;
using HW6_GarbageCollector.Action_Task1.Logger;
using HW6_GarbageCollector.Shop_Task2;
using HW6_GarbageCollector.Shop_Task2.Enums;
using HW6_GarbageCollector.Shop_Task2.Repository;

public class Program
{
    static void Main(string[] args)
    {
        // ActionClass testing
        using (ILogger logger = new Logger("D:\\Hillel_C#_HWs\\HW6_GarbageCollector\\HW6_GarbageCollector\\Action_Task1\\Logger\\Actions_log.txt"))
        {
            ActionClass action = new ActionClass("The Matrix", "Wachowski", "Drama", 1999, 82, logger);
            action.GetActionInfo();
            Console.WriteLine();
            action.StartAction();
            action.PauseAction();
            action.StopAction();
            Console.WriteLine();

            ActionClass action2 = new ActionClass("Natalka Poltavka", "M.Kocubinskyi", "Melodrama", 2003, 60, logger);
            action2.GetActionInfo();
            Console.WriteLine();
            action2.StartAction();
            action2.PauseAction();
            action2.StopAction();
        }
        Console.WriteLine("------------------------------------------------------------------------------");

        // Shop testing
        string filePath = "D:\\Hillel_C#_HWs\\HW6_GarbageCollector\\HW6_GarbageCollector\\Shop_Task2\\ShopList.txt";
        ShopRepository shopRepository = new ShopRepository(filePath);

        Shop shop1 = new Shop("ATB", "Kyiv, pr.Beresteyskyi 101", ShopType.Food);
        Shop shop2 = new Shop("Zara", "Kyiv, pr.Beresteyskyi 200", ShopType.Clothes);
        Shop shop3 = new Shop("Eldorado", "Kyiv, pr.Beresteyskyi 300", ShopType.Electronics);

        shop1.ShowShopInfo();
        shop2.ShowShopInfo();
        shop3.ShowShopInfo();
        Console.WriteLine();

        shopRepository.AddShop(shop1);
        shopRepository.AddShop(shop2);
        shopRepository.AddShop(shop3);
        Console.WriteLine();

        shopRepository.DeleteShop("Zara");
        shopRepository.UpdateShop("ATB", new Shop("Fora", "Kyiv, pr.Beresteyskyi 101", ShopType.Food));

        List<Shop> shops = shopRepository.GetAllShops();

        foreach (Shop shop in shops)
        {
            shop3.ShowShopInfo();
        }








    }
}
