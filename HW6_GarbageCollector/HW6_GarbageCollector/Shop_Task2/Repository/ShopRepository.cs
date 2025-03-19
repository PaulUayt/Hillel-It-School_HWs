using HW6_GarbageCollector.Shop_Task2.Enums;
using HW6_GarbageCollector.Shop_Task2.Interfaces;

namespace HW6_GarbageCollector.Shop_Task2.Repository
{
    class ShopRepository : IDisposable, IShopRepository
    {
        private bool disposed = false;
        private StreamWriter fileWriter;
        private string filePath;

        public ShopRepository(string filePath)
        {
            this.filePath = filePath;
            fileWriter = new StreamWriter(filePath, append: true);
        }

        public void AddShop(Shop shop)
        {
            fileWriter.WriteLine(shop.ToString());
            fileWriter.Flush();
            Console.WriteLine($"Shop {shop.Name} added to file");
        }

        public void DeleteShop(string shopName)
        {
            fileWriter?.Close();
            var linesList = File.ReadAllLines(filePath).Where(line => !line.Contains(shopName)).ToList();
            File.WriteAllLines(filePath, linesList);
            fileWriter = new StreamWriter(filePath, append: true);
            Console.WriteLine($"Shop {shopName} deleted from file");
        }

        public void UpdateShop(string shopName, Shop shop)
        {
            fileWriter?.Close();
            var linesList = File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < linesList.Count; i++)
            {
                if (linesList[i].Contains(shopName))
                {
                    linesList[i] = shop.ToString();
                }
            }

            File.WriteAllLines(filePath, linesList);
            fileWriter = new StreamWriter(filePath, append: true);
            Console.WriteLine($"Shop {shopName} updated in file");
        }

        public List<Shop> GetAllShops()
        {
            fileWriter?.Close();
            var shops = new List<Shop>();
            var lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var shopInfo = line.Split(", ");
                if (shopInfo.Length == 3)
                {
                    var name = shopInfo[0].Split(": ")[1];
                    var address = shopInfo[1].Split(": ")[1];
                    var type = (ShopType)Enum.Parse(typeof(ShopType), shopInfo[2].Split(": ")[1]);
                    shops.Add(new Shop(name, address, type));
                }
            }

            fileWriter = new StreamWriter(filePath, append: true);
            return shops;

        }

        ~ShopRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) fileWriter?.Dispose();
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
