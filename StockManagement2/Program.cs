using Newtonsoft.Json;
using StockManagement2;
using System;
using System.IO;

namespace StockManagment2
{
    class StockCall
    {
        static void Main(string[] args)
        {
            //Object For StockManager
            Stock stockManager = new Stock();
            
         //getting path of json file
            string filePath = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\JsonReport.json";
            string acc = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\AccountReport.json";

            //Deserialize  the Json file
            StockManage stockUtility = JsonConvert.DeserializeObject<StockManage>(File.ReadAllText(filePath));
            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));

            Console.WriteLine("Enter 1 to display stocks");
            var s = stockUtility.stocksList;
    
            switch (Console.ReadLine())
            {
             
                    case "1":
                    stockManager.DisplayStocks(s);
                    break;
            }
           
            Console.WriteLine("--------------------Opeartions Performing in stock--------------------");

            string flag = "Y";
            while (flag == "Y")
            {
                Console.WriteLine("Please Enter :\n1-Display user account\n2-To buy a share\n3-To sell a share\n4-To Display Account report");
                int ch = Convert.ToInt32(Console.ReadLine());
                var u = accountUtility.AccountList;
                switch (ch)
                {
                    case 1:
                        stockManager.StockAccount(acc);
                        break;
                    case 2:
                        Console.WriteLine("Enter amount: ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter company name in which you want to buy share: ");
                        string companyname = Console.ReadLine();
                        stockManager.Buy(amount, companyname);
                        File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
                        break;
                    case 3:
                        Console.WriteLine("Enter amount: ");
                        int amount1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter company name in which you want to sell share: ");
                        string companyname1 = Console.ReadLine();
                        stockManager.Sell(amount1, companyname1);
                        File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
                        break;
                    case 4:
                        stockManager.StockPurchased();
                        stockManager.StockSold();
                        stockManager.DateAndTime();
                        break;
                    default:
                        Console.WriteLine("Enter a valid option!!!");
                        break;


                }
                Console.WriteLine("\nDo you want to continue?(Y/N)");
                Console.ReadLine();
            }


        }
    }
}
