using DevExpress.Xpo;
using Ovjust.DbXpoProvider;
using Ovjust.StockNote.Model;
using Ovjust.StockNote.Model.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNet_Utilities;

namespace Ovjust.StockNote
{
    public partial class Form1 : Form
    {
        Session sess= SessionInit.Sess;

        XPQuery<StockInfo> stockInfos;
        XPQuery<StockHolding> stockHoldings;
        XPQuery<StockFlow> stockFlows;
        XPQuery<DailyCount> dailyCounts;
        XPQuery<MoneyFlow> moneyFlows;
        MoneyHolding moneyHolding;

        public Form1()
        {
            InitializeComponent();

            string dgvDailyCols="Date,日期;MoneyInput,总投资;MoneyFree,可用现金;StockValue,股票市值;StockEarnings,持仓盈亏;MoneyTotal,总资产;TotalEarnings,总盈亏;DailyEarnings,日盈亏;DailyEarningsRate,日盈率;GrailPoint,上证指数;GrailIncrease,上证涨幅;";
            AddColumns(dgvDaily, dgvDailyCols);
            string dgvOperateCols = "Time,时间;Type,买卖;Stock.Code,股票代码;Stock.Name,股票名称;StockAmount,数量;Price,交易价格;MoneyChange,资金变化;Fees,手续费;Earnings,盈亏;EarningsRate,盈率;";
            AddColumns(dgvOperate, dgvOperateCols);
            string dgvMoneyCols = "Time,时间;MoneyChange,变化量;MoneyBalence,结余;";
            AddColumns(dgvMoney, dgvMoneyCols);
            string dgvHoldingCols = "Stock.Code,股票代码;Stock.Name,股票名称;BuyPrice,成本价;CurrentPrice,当前价;StockAmount,持股数量;Earnings,盈亏;EarningsRate,盈亏比率;CurrentValue,当前市值;TodayHighPrice,今日最高价;TodayLowPrice,今日最低价;";
            AddColumns(dgvHolding, dgvHoldingCols);
        }

        void AddColumns(DataGridView dgv, string cols)
        {
            var colPairs = cols.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in colPairs)
            {
                var fields = s.Split(',');
                //var col = new DataGridViewColumn();
                //col.DataPropertyName = fields[0];
                //col.HeaderText = fields[1];
                //col.ValueType =typeof( DataGridViewTextBoxColumn);
                dgv.Columns.Add(fields[0], fields[1]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             stockInfos = new XPQuery<StockInfo>(sess);
             stockHoldings = new XPQuery<StockHolding>(sess);
             stockFlows = new XPQuery<StockFlow>(sess);
             dailyCounts = new XPQuery<DailyCount>(sess);
             DailyCount todayCount;
             moneyFlows = new XPQuery<MoneyFlow>(sess);
             moneyHolding = new XPQuery<MoneyHolding>(sess).SingleOrDefault();
             if (moneyHolding == null)
             {
                 moneyHolding = new MoneyHolding();
                 moneyHolding.Save();
             }
             if (stockHoldings.Count() > 0&&! new DayOfWeek[]{DayOfWeek.Sunday,DayOfWeek.Saturday}.Contains( DateTime.Today.DayOfWeek))
             {
               todayCount=  dailyCounts.SingleOrDefault(p => p.Date.Date == DateTime.Today);
               if (todayCount == null)
               {
                   todayCount = new DailyCount() { Date = DateTime.Now };
                   todayCount.Save();
                   dailyCounts = new XPQuery<DailyCount>(sess);
               }
             }

             dgvDaily.DataSource = dailyCounts.ToList() ;

             comboBox1.DisplayMember = "Text";
             comboBox1.ValueMember = "Value";
             comboBox1.DataSource =EnumHelper.GetItems< StockTradeType>();
          
        }
    }
}
