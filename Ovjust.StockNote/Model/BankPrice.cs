using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model
{
    public class BankPrice
    {
        public static decimal rateHC = 0.8011m;
        /// <summary>
        /// 溢价￥
        /// </summary>
        public string Code { set; get; }
        public string Name { set; get; }
        public decimal ValueCny { set; get; }

        public decimal ValueHc { get { return ValueCny / rateHC; } }
     
        public decimal PriceCny { set; get; }
        public decimal ValueCnyRate { set; get; }
        public decimal PriceHc { set; get; }
        public decimal ValueHcRate { set; get; }

        public decimal PriceHcRate { set; get; }
    }
}
