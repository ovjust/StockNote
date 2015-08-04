using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model.Xpo
{
    public class StockInfo:XPObject
    {
        [Size(10)]
        public string Code { set; get; }
        [Size(10)]
        public string Name { set; get; }

    }
}
