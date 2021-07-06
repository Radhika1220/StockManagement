
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement2
{
    class Stock : IStock

    { 
      
        StockMange utility = JsonConvert.DeserializeObject<StockMange>(File.ReadAllText(@"C:\Users\Radhika\source\repos\StockManagement1\StockManagement1\JsonReport.json"));
        public void DisplayStock()
        {
            

            foreach (StockMange.StocksRecords s in utility.Stocks)
            {
                Console.WriteLine( "\nName of the stock :" + s.Name + "\nTotal stocks of company : " + s.NumOfShares + "\nStock price : " + s.SharePrice);
            }
        }
     
        public void CalculateForEachValue()
        {
            double val = 0, price = 0;
            int share = 0;
            for (int i = 0; i < utility.Stocks.Count; i++)
            {
                var jsonObj = utility.Stocks[i];
                price = jsonObj.SharePrice;
                share = jsonObj.NumOfShares;
                val = price * share;
                Console.WriteLine("Value of the particular stock " + jsonObj.Name + " is " + val + "\n");
            }
        }
        public void CalculateForTotalValue()
        {
            double val = 0, price = 0, totalVal = 0;
            int share = 0;
            for (int i = 0; i < utility.Stocks.Count; i++)
            {
                var jsonObj = utility.Stocks[i];
                price = jsonObj.SharePrice;
                share = jsonObj.NumOfShares;
                val = price * share;
                totalVal += val;

            }
            Console.WriteLine("Total stock value is : " + totalVal);

        }
       public void StockAccount(string fileName)
        {
            utility=JsonConvert.DeserializeObject<StockMange>(File.ReadAllText(@"C:\Users\Radhika\source\repos\StockManagement1\StockManagement1\JsonReport.json"));
            DisplayStock();
        }
    }
}
