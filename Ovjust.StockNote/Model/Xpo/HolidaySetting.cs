using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class HolidaySetting:XPObject
    {
        public bool IsEveryYear { set; get; }
        public DateTime Date { set; get; }
    }
}
