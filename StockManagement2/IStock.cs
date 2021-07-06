using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement2
{
    interface IStock
    {
        public void StockManagement();
        public void CalculateForEachValue();
        public void CalculateForTotalValue();
    }
}
