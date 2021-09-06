using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForex.Client.Model
{
    public class Trade
    {
        public string id { get; set; }
        public string instrument { get; set; }
        public string price { get; set; }
        public string openTime { get; set; }
        public string initialUnits { get; set; }
        public string initialMarginRequired { get; set; }
        public string state { get; set; }
        public string currentUnits { get; set; }
        public string realizedPL { get; set; }
        public string financing { get; set; }
        public string dividendAdjustment { get; set; }
        public string unrealizedPL { get; set; }
        public string marginUsed { get; set; }
        public List<string> closingTransactionIDs { get; set; }
        public string averageClosePrice { get; set; }
    }

    public class Long
    {
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public string units { get; set; }
        public string unrealizedPL { get; set; }
    }

    public class Short
    {
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public string units { get; set; }
        public string unrealizedPL { get; set; }
    }

    public class Position
    {
        public string instrument { get; set; }
        public Long @long { get; set; }
        public string pl { get; set; }
        public string resettablePL { get; set; }
        public Short @short { get; set; }
        public string unrealizedPL { get; set; }
    }

    public class Account
    {
        public string NAV { get; set; }
        public string alias { get; set; }
        public string balance { get; set; }
        public int createdByUserID { get; set; }
        public string createdTime { get; set; }
        public string currency { get; set; }
        public bool hedgingEnabled { get; set; }
        public string id { get; set; }
        public string lastTransactionID { get; set; }
        public string marginAvailable { get; set; }
        public string marginCloseoutMarginUsed { get; set; }
        public string marginCloseoutNAV { get; set; }
        public string marginCloseoutPercent { get; set; }
        public string marginCloseoutPositionValue { get; set; }
        public string marginCloseoutUnrealizedPL { get; set; }
        public string marginRate { get; set; }
        public string marginUsed { get; set; }
        public int openPositionCount { get; set; }
        public int openTradeCount { get; set; }
        public List<object> orders { get; set; }
        public int pendingOrderCount { get; set; }
        public string pl { get; set; }
        public string positionValue { get; set; }
        public List<Position> positions { get; set; }
        public string resettablePL { get; set; }
        public List<object> trades { get; set; }
        public string unrealizedPL { get; set; }
        public string withdrawalLimit { get; set; }
    }

    public class StopLossOnFill
    {
        public string price { get; set; }
        public string timeInForce { get; set; }
    }

    public class Orders
    {
        public string createTime { get; set; }
        public string id { get; set; }
        public string instrument { get; set; }
        public string partialFill { get; set; }
        public string positionFill { get; set; }
        public string price { get; set; }
        public string state { get; set; }
        public StopLossOnFill stopLossOnFill { get; set; }
        public string timeInForce { get; set; }
        public string triggerCondition { get; set; }
        public string type { get; set; }
        public string units { get; set; }
    }

    public class Root
    {
        public List<Trade> trades { get; set; }
        public Account account { get; set; }
        public Orders order { get; set; }
        public string lastTransactionID { get; set; }
    }
}
