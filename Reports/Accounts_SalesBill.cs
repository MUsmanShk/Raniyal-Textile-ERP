using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_SalesBill : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_SalesBill()
        {
            InitializeComponent();
        }

        private void xrLabel43_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            try
            {
                XRLabel xr = (XRLabel)sender;
                double amounttotal = 0;
                double.TryParse(e.Value.ToString(), out amounttotal);
                Words.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            }
            catch
            {
            }
        }

        private void indexnumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel l = (XRLabel)sender;
            l.Text = index.ToString();
        }

       

    }
}
