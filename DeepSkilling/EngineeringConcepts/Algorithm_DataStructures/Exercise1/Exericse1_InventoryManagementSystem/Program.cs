using System;
using System.Collections.Generic;

namespace Exericse1_InventoryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Inventory warehouse = new Inventory();

            warehouse.AddProduct(new Product("p001", "Keyboard", 15, 89.99));
            warehouse.AddProduct(new Product("p002", "Mouse", 40, 49.99));
            warehouse.DisplayInventory();

            Console.WriteLine("\nRemoving p002 from warehouse database...");
            warehouse.DeleteProduct("p002");
            warehouse.DisplayInventory();
        }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product(string productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }
    }

    public class Inventory
    {
        private readonly Dictionary<string, Product> productDict = new();

        public bool AddProduct(Product product)
        {
            if (product == null || productDict.ContainsKey(product.ProductId))
            {
                return false;
            }
            productDict.Add(product.ProductId, product);
            return true;
        }

        public bool UpdateProduct(string productId, int newQuantity, double newPrice)
        {
            if (productDict.TryGetValue(productId, out Product product))
            {
                product.Quantity = newQuantity;
                product.Price = newPrice;
                return true;
            }
            return false;
        }

        public bool DeleteProduct(string productId)
        {
            return productDict.Remove(productId);
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n--- Current Warehouse Inventory ---");

            foreach (var kvp in productDict)
            {
                Product p = kvp.Value;
                Console.WriteLine($"ID: {p.ProductId} | Name: {p.ProductName} | Stock: {p.Quantity} | Price: ${p.Price}");
            }
        }
    }
}