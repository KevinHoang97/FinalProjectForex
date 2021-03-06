using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Model
{
    public class Trade
    {
        public string currentUnits { get; set; }
        public string financing { get; set; }
        public string id { get; set; }
        public string initialUnits { get; set; }
        public string instrument { get; set; }
        public string openTime { get; set; }
        public string price { get; set; }
        public string realizedPL { get; set; }
        public string state { get; set; }
        public string unrealizedPL { get; set; }
    }

    public class RootTrade
    {
        public string lastTransactionID { get; set; }
        public List<Trade> trades { get; set; }
    }


}
