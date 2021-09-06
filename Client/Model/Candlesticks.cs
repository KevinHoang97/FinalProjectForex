using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Model
{
    public class Mid
    {
     
        public string o { get; set; }
        public string h { get; set; }
        public string l { get; set; }
        public string c { get; set; }
    }

    public class Candle
    {
        public bool complete { get; set; }
        public int volume { get; set; }
        public string time { get; set; }
        public Mid mid { get; set; }
    }

    public class RootCandle
    {
        public string instrument { get; set; }
        public string granularity { get; set; }
        public List<Candle> candles { get; set; }
    }

    class Order
    {
        public int units { get; set; }
        public string instrument { get; set; }
        public string timeInForce { get; set; }
        public string type { get; set; }
        public string positionFill { get; set; }
    }

    class TradeInfo
    {
        public Order order { get; set; }
    }
}


