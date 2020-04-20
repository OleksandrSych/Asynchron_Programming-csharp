using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Shop shop = new Shop();
            var customer1 = Task.Run(() =>
            {
                shop.MakeAnOrder("Product1.1", 10);
                shop.MakeAnOrder("Product1.2", 2);
                shop.MakeAnOrder("Product1.3", 10);
                shop.MakeAnOrder("Product1.4", 4);
                shop.MakeAnOrder("Product1.5", 10);
            });
            var customer2 = Task.Run(() =>
            {
                shop.MakeAnOrder("Product2.1", 10);
                shop.MakeAnOrder("Product2.2", 2);
                shop.MakeAnOrder("Product2.3", 10);
                shop.MakeAnOrder("Product2.4", 4);
                shop.MakeAnOrder("Product2.5", 10);
            });
             
            var employee = Task.Run(() => shop.ProcessOrders());
            Task.WaitAll(customer1, customer2);
            shop.OffMakeNewOrders();
            await employee;

            customer1.Dispose();
            customer2.Dispose();
            employee.Dispose();

            Console.WriteLine("End");
            Console.ReadLine();

        }
        internal class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }

        internal class Shop
        {
            BlockingCollection<Product> Products = new BlockingCollection<Product>();
            public void MakeAnOrder(string name, int quantity)
            {
                Products.Add(new Product { Name = name, Quantity = quantity });
                Thread.Sleep(500);
            }
            public void ProcessOrders()
            {
                while (!Products.IsCompleted)
                    if (Products.TryTake(out Product product))
                        Console.WriteLine($"Product Name: {product.Name} \nProduct Quantity: {product.Quantity} \n");
            }
            public void OffMakeNewOrders()
            {
                Products.CompleteAdding();
            }

        }
    }
}
