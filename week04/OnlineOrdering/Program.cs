// https://www.dotnetperls.com/sum
using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (from USA)
        Address usaAddress = new("123 Main Street, Apt 4B", "Springfield", "IL", "USA");
        Customer usaCustomer = new("John Doe", usaAddress);
        Order usaOrder = new(usaCustomer);

        usaOrder.AddProduct(new("Pencil Sharpener", "PS22", 0.99m, 6));
        usaOrder.AddProduct(new("Sticky Notes", "SN36", 1.25m, 3));
        usaOrder.AddProduct(new("Hole Puncher", "HP87", 4.72m, 1));

        // Order 2 (International)
        Address intAddress = new("27A Street, N° 16-20", "Maracaibo", "Zulia", "Venezuela");
        Customer intCustomer = new("Ronald Diaz", intAddress);
        Order intOrder = new(intCustomer);

        intOrder.AddProduct(new("Adhesive Tape", "AT01", 0.80m, 36));
        intOrder.AddProduct(new("Paper Clip", "PC99", 0.02m, 1000));
        intOrder.AddProduct(new("Sketch Pad", "SP25", 1.20m, 120));

        DisplayOrderDetails("Order 1", usaOrder);
        DisplayOrderDetails("Order 2", intOrder);

        static void DisplayOrderDetails(string orderName, Order order)
        {
            Console.WriteLine($"---------------- {orderName} ----------------");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(order.DisplayShippingCost());
            Console.WriteLine($"Total Cost: ${order.CalculateTotalCost()}");
            Console.WriteLine("------------------------------------------\n");
        }        
    }
}