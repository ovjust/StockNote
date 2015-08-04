using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class DailyCount:XPObject
    {
        public DateTime Date { set; get; }
        public decimal MoneyInput { set; get; }
        public decimal MoneyFree { set; get; }
        public decimal StockValue { set; get; }
        public decimal StockEarnings { set; get; }
        public decimal MoneyTotal { set; get; }
        public decimal GrailPoint { set; get; }
        public decimal GrailIncrease { set; get; }

        [NonPersistent]
        public decimal TotalEarnings { set; get; }
        [NonPersistent]
        public decimal DailyEarnings { set; get; }
        //[NonPersistent]
        //public decimal TotalEarningsRate { set; get; }
        [NonPersistent]
        public decimal DailyEarningsRate { set; get; }
    }
}
