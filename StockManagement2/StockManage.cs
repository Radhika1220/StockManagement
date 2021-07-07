using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement2
{
    class StockManage
    {
        public LinkedList<Stocks> stocksList { get; set; }

        public class Stocks
        {
            public string StockName { get; set; }
            public int numOfShares { get; set; }
            public int sharePrice { get; set; }
        }
    }


}