using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static StockManagement2.AccountManage;
using static StockManagement2.StockManage;

namespace StockManagement2
{
    class Stock
    {
        //Local variables
        LinkedList<string> stockPurchased = new LinkedList<string>();
        LinkedList<string> stockSold = new LinkedList<string>();
        List<string> transactionTime = new List<string>();
        string filePath = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\JsonReport.json";


        //Display Stock Details
        public void DisplayStocks(LinkedList<StockManage.Stocks> stocksList)
        {
            int totalShare = 0, temporaryVal;
            Console.WriteLine("-------DISPLAYING STOCK DETAILS----------");
            foreach (var s in stocksList)
            {
                Console.WriteLine("Stock name is: {0} \nStock share is: {1} \nStock Price is: {2}", s.StockName, s.numOfShares, s.sharePrice);
                temporaryVal = s.numOfShares * s.sharePrice;
                totalShare += temporaryVal;
                Console.WriteLine("Total stock price for {0} is : {1}", s.StockName, temporaryVal);
            }
            Console.WriteLine("Total store is : " + totalShare);

        }
        //Display Account Details
        public void DisplayAccount(List<AccountManage.Account> AccountList)
        {
            int totalShare = 0, temporaryVal;
            Console.WriteLine("----------------DISPLAYING ACCOUNT DETAILS------------------");
            foreach (var a in AccountList)
            {

                Console.WriteLine("Stock holder {0}", a.holderName);
                Console.WriteLine("Stock name is: {0} \nStock share is: {1} \nStock Price is: {2}", a.stockName, a.shares, a.price);
                temporaryVal = a.shares * a.price;
                totalShare += temporaryVal;
                Console.WriteLine("Total stock price for {0} is : {1}", a.stockName, temporaryVal);
            }
            Console.WriteLine("Total share is : " + totalShare);

        }
        //Creating a account for user
        public void StockAccount(String acc)
        {

            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            DisplayAccount(u);

        }
        //Buy a stock
        public void Buy(int amount, string company)
        {
            string acc = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\AccountReport.json";
            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            AddStockAccount(u, company, amount);
            File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
            stockPurchased.AddLast("Company: " + company + " Amount: " + amount);
            DisplayAccount(u);
        }
        //Sell a stock
        public void Sell(int amount, string company)
        {
            string acc = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\AccountReport.json";
            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));
            var u = accountUtility.AccountList;
            SellStockAccount(u, company, amount);
            File.WriteAllText(acc, JsonConvert.SerializeObject(accountUtility));
            stockSold.AddLast("Company: " + company + " Amount: " + amount);
            DisplayAccount(u);
        }
        //SellStockAccount Method
        public void SellStockAccount(List<AccountManage.Account> accountlist, string company, int amount)
        {
            string filePath = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\JsonReport.json";
            string acc = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\AccountReport.json";
            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));
            StockManage stockUtility = JsonConvert.DeserializeObject<StockManage>(File.ReadAllText(filePath));
            var s = stockUtility.stocksList;

            foreach (var stockavail in s)
            {
                if (stockavail.StockName == company && stockavail.numOfShares >= 0)
                {
                    foreach (var member in accountlist)
                    {

                        Account account1 = new Account();

                        if (member.stockName == company)
                        {

                            Console.WriteLine("\nEnter the stock holder: ");
                            account1.holderName = Console.ReadLine();
                            account1.stockName = company;
                            account1.shares = member.shares - 1;
                            account1.price = amount;
                            accountlist.Remove(member);
                            stockavail.numOfShares += 1;
                            accountlist.Add(account1);
                            File.WriteAllText(filePath, JsonConvert.SerializeObject(stockUtility));
                            DateTime time = DateTime.Now;
                            Console.WriteLine("Sold the Share at: " + time);
                            transactionTime.Add("Sold compant " + company + " at time " + Convert.ToString(time));

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Stocks not available");
                        }
                    }
                }
            }

        }
        //AddStockAccount Method
        public void AddStockAccount(List<AccountManage.Account> accountlist, string company, int amount)
        {
            string filePath = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\JsonReport.json";
            string acc = @"C:\Users\Radhika\source\repos\StockManagement2\StockManagement2\AccountReport.json";
            AccountManage accountUtility = JsonConvert.DeserializeObject<AccountManage>(File.ReadAllText(acc));
            StockManage stockUtility = JsonConvert.DeserializeObject<StockManage>(File.ReadAllText(filePath));
            var s = stockUtility.stocksList;

            foreach (var stockavail in s)
            {
                if (stockavail.StockName == company && stockavail.numOfShares >= 1)
                {
                    foreach (var member in accountlist.ToList())
                    {

                        Account account1 = new Account();

                        if (member.stockName == company)
                        {

                            Console.WriteLine("\nEnter the stock holder: ");
                            account1.holderName = Console.ReadLine();
                            account1.stockName = company;
                            account1.shares = member.shares + 1;
                            account1.price = amount;
                            accountlist.Remove(member);
                            stockavail.numOfShares -= 1;
                            accountlist.Add(account1);
                            File.WriteAllText(filePath, JsonConvert.SerializeObject(stockUtility));
                            DateTime time = DateTime.Now;
                            Console.WriteLine("Bought the Share at: " + time);
                            transactionTime.Add("Bought company " + company + " at time " + Convert.ToString(time));

                        }
                    }
                }
            }
        }
    
                            //date and time of transaction using list
         public void DateAndTime()
        {
            Console.WriteLine("---------------The Date and Time of transactions occured-----------------");
            foreach (var t in transactionTime)
            {
                Console.WriteLine(t);
            }
        }

        public void StockPurchased()
        {
            Console.WriteLine("\n**List of stock purchased**\n");
            foreach (var t in stockPurchased)
            {
                Console.WriteLine(t);
            }
        }
        public void StockSold()
        {
            Console.WriteLine("\n***List of stock sold***\n");
            foreach (var t in stockSold)
            {
                Console.WriteLine(t);
            }
        }
    }
}
