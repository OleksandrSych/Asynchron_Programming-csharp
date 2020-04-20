using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                Name = "Customer1",
                Address = "Street 1",
                Phone = "1-11-111"
            };
            Customer customer2 = new Customer
            {
                Name = "Customer2",
                Address = "Street 2",
                Phone = "2-22-222"
            };
            Shop employe = new Shop();
            employe.MakeAnOrder(customer1, new Product { Name = "iphone 11", Quantity = 1 });
            employe.MakeAnOrder(customer1, new Product { Name = "iphone 12", Quantity = 1 });
            employe.MakeAnOrder(customer1, new Product { Name = "iphone 11", Quantity = 3 });

            employe.MakeAnOrder(customer2, new Product { Name = "iphone SE", Quantity = 1 });
            employe.MakeAnOrder(customer2, new Product { Name = "iphone 12", Quantity = 1 });
            employe.MakeAnOrder(customer2, new Product { Name = "iphone 11", Quantity = 1 });

            employe.ProcessOrders();
            Console.ReadLine();
        }
        internal class Shop
        {
            ConcurrentDictionary<string, Order> customersOrders = new ConcurrentDictionary<string, Order>();
           public  void MakeAnOrder(Customer customer, Product product)
            {
                var customerOrder = customersOrders.GetOrAdd(customer.Name, new Order() { Customer = customer, Products = new List<Product>() });
                foreach (var productInOrder in customerOrder.Products)
                {
                    if (productInOrder.Name == product.Name)
                    {
                        productInOrder.Quantity += product.Quantity;
                        return;
                    }
                }
                customerOrder.Products.Add(product);
            }
            public void ProcessOrders()
            {
                while (true)
                {
                    if (customersOrders.Count == 0)
                        return;
                    var customer = customersOrders.FirstOrDefault().Key;
                    if (customersOrders.TryRemove(customer, out Order order))
                    {
                        Console.WriteLine($"Customer: {customer}; Orders: {string.Join(", ", order.Products.Select(y => $"{y.Name } - {y.Quantity}"))}");
                    }
                }
            }
        }
        internal class Product
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
        }

        internal class Customer
        {
            public string Name { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
        }
        internal class Order
        {
            public Customer Customer { get; set; }
            public List<Product> Products { get; set; }
        }
    }
}
