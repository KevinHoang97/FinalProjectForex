using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Model
{
    public class OrderCreateTransaction
    {
        public string id { get; set; }
        public string accountID { get; set; }
        public int userID { get; set; }
        public string batchID { get; set; }
        public string requestID { get; set; }
        public string time { get; set; }
        public string type { get; set; }
        public string instrument { get; set; }
        public string units { get; set; }
        public string timeInForce { get; set; }
        public string positionFill { get; set; }
        public string reason { get; set; }
    }

    public class OrderCancelTransaction
    {
        public string id { get; set; }
        public string accountID { get; set; }
        public int userID { get; set; }
        public string batchID { get; set; }
        public string requestID { get; set; }
        public string time { get; set; }
        public string type { get; set; }
        public string orderID { get; set; }
        public string reason { get; set; }
    }

    public class RootMarket
    {
        public OrderCreateTransaction orderCreateTransaction { get; set; }
        public OrderCancelTransaction orderCancelTransaction { get; set; }
        public List<string> relatedTransactionIDs { get; set; }
        public string lastTransactionID { get; set; }
    }
}
