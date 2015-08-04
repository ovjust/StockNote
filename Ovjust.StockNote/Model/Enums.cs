using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model
{
    public enum StockTradeType
    {
        [Description("买")]
        Buy = 1,
        [Description("卖")]
        Sell
    }
}
