using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ovjust.StockNote.Model
{
    public class BankPrice
    {
        public static decimal RateHk = 0.8011m;
       //已知信息
        /// <summary>
        /// 股票代码
        /// </summary>
        [DisplayName("A股代码")]
        public string Code { set; get; }
        /// <summary>
        /// 港股代码
        /// </summary>
        [DisplayName("港股代码")]
        public string HkCode { set; get; }
        [DisplayName("每股净资产Cny")]
        public decimal ValueCny { set; get; }

        [DisplayName("股票名称")]
        public string Name { set; get; }
        [DisplayName("每股净资产Hk")]
        public decimal ValueHk { set; get; }
      [DisplayName("股价Cny")]
        public decimal PriceCny { set; get; }
        [DisplayName("溢价Cny")]
        public decimal ValueCnyRate { set; get; }
        [DisplayName("股价Hk")]
        public decimal PriceHk { set; get; }
        [DisplayName("溢价Hk")]
        public decimal ValueHkRate { set; get; }
        [DisplayName("港对A溢价")]
        public decimal PriceHkRate { set; get; }
    }
}
