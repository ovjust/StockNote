using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class StockFlow:XPObject
    {
        public DateTime Time { set; get; }
        public int Type { set; get; }
        public decimal MoneyChange { set; get; }
        //public decimal MoneyBalance { set; get; }
        public StockInfo Stock { set; get; }
        public decimal Price { set; get; }
        public int StockAmount { set; get; }
        public decimal Earnings { set; get; }
        public decimal EarningsRate { set; get; }
        public decimal Fees { set; get; }
    }
}
