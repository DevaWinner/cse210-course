using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("789 Pine St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("321 Maple St", "Vancouver", "BC", "Canada");

        // Create customers
        Customer customer1 = new Customer("Alex Johnson", address1);
        Customer customer2 = new Customer("Emma Williams", address2);

        // Create products
        Product product1 = new Product("Smartphone", "P2001", 799.99, 1);
        Product product2 = new Product("Headphones", "P2002", 199.99, 2);
        Product product3 = new Product("Charger", "P2003", 29.99, 1);
        Product product4 = new Product("Tablet", "P2004", 399.99, 1);
        Product product5 = new Product("Stylus Pen", "P2005", 49.99, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Clear the console and display order details
        Console.Clear();
        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
        Console.WriteLine();
    }
}
