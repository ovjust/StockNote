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

        List<string> listStockCode = new List<string>();
        string[] arrStockCode;
        decimal rateHC = 0.8011m;


        private void FormBankPrice_Load(object sender, EventArgs e)
        {
            //var sr= File.OpenText("");
           arrStockCode=  File.ReadAllLines("BankStockCodes.txt");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
