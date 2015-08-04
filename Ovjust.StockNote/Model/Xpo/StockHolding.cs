using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class StockHolding:XPObject
    {
        public StockInfo Stock { set; get; }
        public decimal BuyPrice { set; get; }
        public int StockAmount { set; get; }

        [NonPersistent]
        public decimal CurrentPrice { set; get; }
        [NonPersistent]
        public decimal Earnings { set; get; }
        [NonPersistent]
        public decimal EarningsRate { set; get; }
        [NonPersistent]
        public decimal TodayHighPrice { set; get; }
        [NonPersistent]
        public decimal TodayLowPrice { set; get; }
        [NonPersistent]
        public decimal CurrentValue { set; get; }
    }
}
