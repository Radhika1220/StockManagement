using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement2
{
    class StockMange
    {
        public List<StocksRecords> Stocks { get; set; }

        public class StocksRecords
        {
            public string Name { get; set; }
            public int NumOfShares { get; set; }

            public int SharePrice { get; set; }

        }
    }
}