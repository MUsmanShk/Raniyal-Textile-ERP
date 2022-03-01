using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class YarnContract : DevExpress.XtraReports.UI.XtraReport
    {
        public YarnContract()
        {
            InitializeComponent();
        }

        private void TotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void AmountinWords_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                XRLabel xr = (XRLabel)sender;
                double amounttotal = 0;
                double.TryParse(xr.Tag.ToString(), out amounttotal);
                AmountinWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            }
            catch
            {
            }
        }

    }
}
