using System;

class Order
{
    public int OrderId;
    public string CustomerName;
    public double TotalPrice;

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }
}

class Program
{
    static void BubbleSort(Order[] orders)
    {
        for (int i = 0; i < orders.Length - 1; i++)
        {
            for (int j = 0; j < orders.Length - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    Order temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

   
    static void QuickSort(Order[] orders, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(orders, low, high);
            QuickSort(orders, low, pivotIndex - 1);
            QuickSort(orders, pivotIndex + 1, high);
        }
    }

    static int Partition(Order[] orders, int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice <= pivot)
            {
                i++;
                Order temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        Order t = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = t;

        return i + 1;
    }

    static void PrintOrders(Order[] orders)
    {
        foreach (Order order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Total Price: {order.TotalPrice}");
        }
    }

    static void Main(string[] args)
    {
        Order[] orders =
        {
            new Order(101, "Alice", 4500),
            new Order(102, "Bob", 2500),
            new Order(103, "Charlie", 7000),
            new Order(104, "David", 3000),
            new Order(105, "Eva", 1500)
        };

        Console.WriteLine("Original Orders:");
        PrintOrders(orders);

        BubbleSort(orders);
        Console.WriteLine("\n Bubble Sort:");
        PrintOrders(orders);

        Order[] orders2 =
        {
            new Order(101, "Alice", 4500),
            new Order(102, "Bob", 2500),
            new Order(103, "Charlie", 7000),
            new Order(104, "David", 3000),
            new Order(105, "Eva", 1500)
        };

        QuickSort(orders2, 0, orders2.Length - 1);
        Console.WriteLine("\n Quick Sort:");
        PrintOrders(orders2);
    }
}