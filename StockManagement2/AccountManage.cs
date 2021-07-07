using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement2
{
    class AccountManage
    {

        public List<Account> AccountList { get; set; }

        public class Account
        {
            public string holderName { get; set; }
            public string stockName { get; set; }
            public int shares { get; set; }
            public int price { get; set; }
        }
    }


}
