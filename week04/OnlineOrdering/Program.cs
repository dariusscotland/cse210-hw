using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        // Set currency culture for clean output
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

        // --- Order 1: Domestic Customer (USA Shipping) ---
        Console.WriteLine("=======================================");
        Console.WriteLine("ORDER 1: DOMESTIC (USA)");
        Console.WriteLine("=======================================");

        // 1. Setup Customer and Address
        Address address1 = new Address("789 Pine Lane", "Springfield", "MO", "USA");
        Customer customer1 = new Customer("Marge Simpson", address1);

        // 2. Setup Products
        Product p1 = new Product("Duff Beer 6-Pack", "DB6", 12.50m, 2); // $25.00
        Product p2 = new Product("Pink Donut Box", "PD12", 5.00m, 1);  // $5.00

        // 3. Create Order
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        // 4. Display Results
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        // Shipping cost should be $5.00
        Console.WriteLine($"TOTAL ORDER COST: {order1.CalculateTotalCost():C2}\n"); // Output: $25.00 + $5.00 + $5.00 = $35.00

        // --- Order 2: International Customer (Non-USA Shipping) ---
        Console.WriteLine("=======================================");
        Console.WriteLine("ORDER 2: INTERNATIONAL (FRANCE)");
        Console.WriteLine("=======================================");
        
        // 1. Setup Customer and Address
        Address address2 = new Address("45 Rue de Lille", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Marie Dubois", address2);

        // 2. Setup Products
        Product p3 = new Product("Eiffel Tower Poster", "ETP01", 15.00m, 4); // $60.00
        Product p4 = new Product("French Coffee Press", "FCP02", 45.00m, 1); // $45.00
        Product p5 = new Product("Baguette Holder", "BH10", 8.00m, 3); // $24.00

        // 3. Create Order
        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        // 4. Display Results
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        // Shipping cost should be $35.00
        Console.WriteLine($"TOTAL ORDER COST: {order2.CalculateTotalCost():C2}");
    }
}