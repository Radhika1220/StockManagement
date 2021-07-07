using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement2
{
    interface IStock
    {
        public void DisplayStock();
        //   public void CalculateForEachValue();
        // public void CalculateForTotalValue();
        public void StockAccount(string fileName);
        public void Sell(int amount, string company);
        public void Buy(int amount, string company);
        public void SellStockAccount(List<AccountManage.Account> accountlist, string company, int amount);
        public void AddStockAccount(List<AccountManage.Account> accountlist, string company, int amount);
        public void DateAndTime();
    }

}
