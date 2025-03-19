namespace HW6_GarbageCollector.Shop_Task2.Interfaces
{
    public interface IShopRepository
    {
        void AddShop(Shop shop);
        void DeleteShop(string shopName);
        void UpdateShop(string shopName, Shop shop);
        List<Shop> GetAllShops();
    }
}
