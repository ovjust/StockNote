using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class MoneyFlow : XPObject
    {
        public DateTime Time { set; get; }
        public decimal MoneyChange { set; get; }
        public decimal MoneyBelance { set; get; }
    }
}
