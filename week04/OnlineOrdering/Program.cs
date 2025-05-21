using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First customer and order
        Address address1 = new Address("123 Apple St", "New York", "NY", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A123", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "B456", 25.50m, 2));

        // Second customer and order
        Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emily Zhang", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Desk Lamp", "C789", 40.00m, 1));
        order2.AddProduct(new Product("Notebook", "D012", 5.25m, 5));

        // Display results
        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine("=== Packing Label ===");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("=== Shipping Label ===");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalCost():F2}");
            Console.WriteLine();
        }
    }
}