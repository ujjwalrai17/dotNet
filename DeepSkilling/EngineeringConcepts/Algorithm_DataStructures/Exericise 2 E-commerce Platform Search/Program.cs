using System;

namespace Exercise_2_E_commerce_Platform_Search
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Setup a mock product catalog (unsorted)
            Product[] products = new Product[]
            {
                new Product(105, "Wireless Mouse", "Electronics"),
                new Product(101, "Mechanical Keyboard", "Electronics"),
                new Product(104, "Running Shoes", "Apparel"),
                new Product(102, "Coffee Mug", "Kitchenware"),
                new Product(103, "Desk Lamp", "Furniture")
            };

            int targetId = 104;

            
            Console.WriteLine("---  Linear Search ---");
            Product linearResult = LinearSearch(products, targetId);
            DisplayResult(linearResult, targetId);

            
            for (int i = 0; i < products.Length - 1; i++)
            {
                for (int j = 0; j < products.Length - i - 1; j++)
                {
                    if (products[j].ProductId > products[j + 1].ProductId)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\n---  Binary Search ---");
            Product binaryResult = BinarySearch(products, targetId);
            DisplayResult(binaryResult, targetId);
        }

        
        public static Product LinearSearch(Product[] array, int targetId)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].ProductId == targetId)
                {
                    return array[i]; 
                }
            }
            return null; 
        }

        
        public static Product BinarySearch(Product[] array, int targetId)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid].ProductId == targetId)
                {
                    return array[mid]; 
                }

                if (array[mid].ProductId < targetId)
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1; 
                }
            }
            return null; 
        }

        
        private static void DisplayResult(Product result, int targetId)
        {
            if (result != null)
            {
                Console.WriteLine($"Found: [ID: {result.ProductId}] {result.ProductName} ({result.Category})");
            }
            else
            {
                Console.WriteLine($"Product with ID {targetId} not found.");
            }
        }
    }
}