using System;

namespace StockManagement2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Console.WriteLine("***Welcome To Stock Inventory System***");
            Console.WriteLine("1.Display the all stock details");
            Console.WriteLine("2.Calculating each share value");
            Console.WriteLine("3.Calculating Total share value");
            Console.WriteLine("Enter the Option!!!!");
            switch (Console.ReadLine())
            {
                case "1":
                    stock.StockManagement();
                    break;
                case "2":
                    stock.CalculateForEachValue();
                    break;
                case "3":
                    stock.CalculateForTotalValue();
                    break;
                default:
                    Console.WriteLine("Enter the valid option");
                    break;
            }
        }
    }
}
