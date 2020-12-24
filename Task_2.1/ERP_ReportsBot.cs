using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Reflection;
using Task_2._1.Model;
using Task_2._1.ProgramException;
namespace Task_2._1
{
    class ERP_ReportsBot
    {
        static List<Inventory> inventories;
        static List<Product> products;
        static List<Tag> tags;
        public static  void Start()
        {
            inventories = ReadFromFile<Inventory>("Inventory");
            products = ReadFromFile<Product>("Products");
            tags = ReadFromFile<Tag>("Tags");
            Level0();
            
        }
        static void Level0()
        {
            while (true)
            {

                Console.WriteLine("1.Exit");
                Console.WriteLine("2.Merchandise");
                Console.WriteLine("3.Rest");
                Console.Write("Enter:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return;
                    case "2":
                        Level1();
                        break;
                    case "3":
                        Level2();
                        break;
                    default:
                        Console.WriteLine("Command isn't finding");
                        break;
                }

            }
        }

        private static void Level2()
        {
            while (true)
            {
                Console.WriteLine("1.Exit to main Menu");
                Console.WriteLine("2.Missing Items");
                Console.WriteLine("3.Balances - Ascending");
                Console.WriteLine("4.Balances - Descending");
                Console.WriteLine("5.Balances by item ID");
                Console.Write("Enter:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return;
                    case "2":
                        MissingItems();
                        break;
                    case "3":
                        BalancesAscending();
                        break;
                    case "4":
                        BalancesDescending();
                        break;
                    case "5":
                        BalancesByItemID();
                        break;
                    default:
                        Console.WriteLine("Command isn't finding");
                        break;
                }
            }
        }

        private static void BalancesByItemID()
        {
            Console.Write("Enter Id item: ");
            string input = Console.ReadLine();
            var invent = inventories.Where(i => i.ProductId.Equals(input,StringComparison.OrdinalIgnoreCase));
            if (invent.Any())
                invent.OrderByDescending(i => i.Balance).ToList().ForEach(t => ConsoleWriteInventory(t));
            else
                Console.WriteLine("Product not found");
        }

        private static void BalancesDescending()
        {
            Dictionary<Product, decimal> pairs = new Dictionary<Product, decimal>();
            inventories.GroupBy(i => i.ProductId).ToList().ForEach(s => pairs.Add(products.Find(p => p.Id == s.Key), s.Sum(y => y.Balance)));
            if(pairs.Any())
                pairs.OrderByDescending(p => p.Value).ToList().ForEach(l => ConsoleWriteProductWithBalance(l.Key, l.Value));
            else 
                Console.WriteLine("Product not found");
        }

        private static void BalancesAscending()
        {
            Dictionary<Product, decimal> pairs = new Dictionary<Product, decimal>();
            inventories.GroupBy(i => i.ProductId).ToList().ForEach(s => pairs.Add(products.Find(p => p.Id == s.Key), s.Sum(y => y.Balance)));
            if (pairs.Any())
                pairs.OrderBy(p => p.Value).ToList().ForEach(l => ConsoleWriteProductWithBalance(l.Key,l.Value));
            else 
                Console.WriteLine("Product not found");
        }

        private static void MissingItems()
        {
            var missing = products.Where(p => (!inventories.Any(i => i.ProductId == p.Id)) 
            || (inventories.Any(i => i.ProductId == p.Id)&&inventories.All(i=>i.Balance == 0)));
            if(missing.Any())
                missing.ToList().ForEach(m=> ConsoleWriteProduct(m)); 
            else              
                Console.WriteLine("Product not found");
        }

        static void Level1()
        {
            while (true)
            {
                Console.WriteLine("1.Exit to main Menu");
                Console.WriteLine("2.Product search");
                Console.WriteLine("3.List of All Products - prices ascending");
                Console.WriteLine("4.List of All Products - prices in descending order");
                Console.Write("Enter:");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        return;
                    case "2":
                        ProductSearch();
                        break;
                    case "3":
                        PricesAscending();
                        break;
                    case "4":
                        PricesInDescendingOrder();
                        break;
                    default:
                        Console.WriteLine("Command isn't finding");
                        break;
                }
            }
        }

        private static void PricesInDescendingOrder()
        {
            if(products.Any())
                products.OrderByDescending(p => decimal.Parse(p.Price)).ToList().ForEach(p => ConsoleWriteProduct(p));
            else
                Console.WriteLine("Product not found");
        }

        private static void PricesAscending()
        {
            if (products.Any())
                products.OrderBy(p => decimal.Parse(p.Price)).ToList().ForEach(p => ConsoleWriteProduct(p));
            else
                Console.WriteLine("Product not found");
        }

        private static void ProductSearch()
        {
            Console.Write("Enter string:");
            string input = Console.ReadLine();
            var productsfindId = products.Where(p => p.Id.Contains(input)).ToList();
            var productsfindModelOrBrand = products.Where(p => p.Model.Contains(input)||p.Brand.Contains(input)).ToList();

            var tagsfind =tags.Where(t => t.Value.Contains(input)).ToList();
            var tagsProduct = products.Where(p => tagsfind.Any(t => t.ProductId == p.Id));
            var allFindProducts = productsfindId.Concat(productsfindModelOrBrand).Concat(tagsProduct).Distinct().ToList();
            if (allFindProducts.Any())
                allFindProducts.ForEach(p => ConsoleWriteProduct(p));
            else
                Console.WriteLine("Product not found");
        }
        static void ConsoleWriteProduct(Product product)
        {
            StringBuilder tagsProduct = new StringBuilder("");
            tags.Where(t => t.ProductId == product.Id).ToList().ForEach(t=>tagsProduct.Append(" "+t.Value+","));
            if (tagsProduct.Length != 0)
            {
                tagsProduct.Remove(0,1);
                tagsProduct.Remove(tagsProduct.Length - 1, 1);
            }
            Console.WriteLine($"#{product.Id} {product.Brand}-{product.Model}-${product.Price} [{tagsProduct}]");
        }
        static void ConsoleWriteProductWithBalance(Product product,decimal balance)
        {
            StringBuilder tagsProduct = new StringBuilder("");
            tags.Where(t => t.ProductId == product.Id).ToList().ForEach(t => tagsProduct.Append(" " + t.Value + ","));
            if (tagsProduct.Length != 0)
            {
                tagsProduct.Remove(0, 1);
                tagsProduct.Remove(tagsProduct.Length - 1, 1);
            }
            Console.WriteLine($"#{product.Id} {product.Brand}-{product.Model}-${product.Price} [{tagsProduct}] Balance: {balance}");
        }
        static void ConsoleWriteInventory(Inventory inventory)
        {
            
            Console.WriteLine($"Location: {inventory.Location}\t Balance: {inventory.Balance}");
        }
        static List<T> ReadFromFile<T>(string nameFile)
        {
            
            string path = Environment.CurrentDirectory +"\\"+ nameFile +".csv";
            List<string> array = new List<string>();
            try
            {
                array = File.ReadLines(path).Skip(1).ToList();
            }
            catch (Exception ex)
            {
                throw new FileReadException( ex);
            }
            ConstructorInfo constructor = typeof(T).GetConstructors()[0];
            List<T> listT = new List<T>();
            array.ForEach(p => listT.Add((T)constructor.Invoke(p.Split(";"))));
            return listT;
        }
    }
}
