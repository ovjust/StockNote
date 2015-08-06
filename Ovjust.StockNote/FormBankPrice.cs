using BaiduApi.BaseApi;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using Ovjust.StockNote.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ovjust.StockNote
{
    public partial class FormBankPrice : Form
    {
        public FormBankPrice()
        {
            InitializeComponent();
        }

        List<BankPrice> listStockCode = new List<BankPrice>();
        BackgroundWorker bgw = new BackgroundWorker();
        //decimal rateHC = 0.8011m;


        private void FormBankPrice_Load(object sender, EventArgs e)
        {
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerCompleted += bgw_RunWorkerCompleted;
            //var sr= File.OpenText("");
            string[] arrStockCode = File.ReadAllLines("BankStockCodes.txt");
            foreach (string row in arrStockCode)
            {
                var strs = row.Split(' ');
                var model = new BankPrice() { Code = strs[0], HkCode = strs[1], ValueCny =Convert.ToDecimal( strs[2]) };
                model.ValueHk =model.ValueCny / BankPrice.RateHk;
                listStockCode.Add(model);
            }
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (waitForm != null)
                waitForm.Close();
            gridControl1.DataSource = listStockCode;
            //dataGridView1.Columns[""].
            ColumnFormatNumber(gridView1, "ValueHk", "N2");
            ColumnFormatNumber(gridView1, "ValueCnyRate", "P0");
            ColumnFormatNumber(gridView1, "ValueHkRate", "P0");
            ColumnFormatNumber(gridView1, "PriceHkRate", "P0");
        }

        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 0; i < listStockCode.Count; i++)
            {
                var model = listStockCode[i];
                //var jsonHs = JuheStock.GetResult(model.Code);
                //var jsonHk = JuheStock.GetResult(model.HkCode);
                //if (jsonHk != null)
                //{
                //    model.PriceHk = jsonHk["result"][0]["data"].Value<decimal>("lastestpri");
                //    model.ValueHkRate = model.PriceHk / model.ValueHk - 1;
                //}
                //if (jsonHs != null)
                //{
                //    model.Name = jsonHs["result"][0]["data"].Value<string>("name");
                //    model.PriceCny = jsonHs["result"][0]["data"].Value<decimal>("nowPri");
                //    model.ValueCnyRate = model.PriceCny / model.ValueCny - 1;
                //    model.PriceHkRate = model.PriceHk * BankPrice.RateHk / model.PriceCny - 1;
                //}
                var jsonHs = BaiduStock.GetResult(model.Code);
                var jsonHk = BaiduStock.GetResult(model.HkCode);
                if (jsonHk != null)
                {
                    model.PriceHk = jsonHk["retData"]["stockinfo"].Value<decimal>("currentPrice");
                    model.ValueHkRate = model.PriceHk / model.ValueHk - 1;
                }
                if (jsonHs != null)
                {
                    model.Name = jsonHs["retData"]["stockinfo"].Value<string>("name");
                    model.PriceCny = jsonHs["retData"]["stockinfo"].Value<decimal>("currentPrice");
                    model.ValueCnyRate = model.PriceCny / model.ValueCny - 1;
                    model.PriceHkRate = model.PriceHk * BankPrice.RateHk / model.PriceCny - 1;
                }
            }
        }
        WaitDialogForm waitForm = null;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!bgw.IsBusy)
            {
                waitForm = new WaitDialogForm();
                bgw.RunWorkerAsync(); 
            }
        }

        void ColumnFormatNumber(GridView grid, string fieldName, string format)
        {
            grid.Columns[fieldName].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            grid.Columns[fieldName].DisplayFormat.FormatString = format;
        }
    }
}
