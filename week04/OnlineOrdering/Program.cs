// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("=====================\n");

        // Create addresses
        Address usAddress = new Address("123 Main Street", "New York", "NY", "USA", "10001");
        Address internationalAddress = new Address("456 Maple Avenue", "Toronto", "Ontario", "Canada", "M9C 3J5");

        // Create customers
        Customer usCustomer = new Customer("John Smith", usAddress);
        Customer internationalCustomer = new Customer("Emma Johnson", internationalAddress);

        // Create products
        Product laptop = new Product("Laptop", "TECH001", 899.99m, 1);
        Product headphones = new Product("Wireless Headphones", "TECH002", 149.99m, 2);
        Product keyboard = new Product("Mechanical Keyboard", "TECH003", 79.99m, 1);
        Product mouse = new Product("Gaming Mouse", "TECH004", 49.99m, 1);
        Product phoneCase = new Product("Phone Case", "ACC001", 19.99m, 3);

        // Create first order (US Customer)
        Order order1 = new Order(usCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        order1.AddProduct(keyboard);

        // Create second order (International Customer)
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(mouse);
        order2.AddProduct(phoneCase);
        order2.AddProduct(headphones);

        // Display Order 1 details
        Console.WriteLine("ORDER #1");
        Console.WriteLine("--------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        // Display Order 2 details
        Console.WriteLine("ORDER #2");
        Console.WriteLine("--------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}\n");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}