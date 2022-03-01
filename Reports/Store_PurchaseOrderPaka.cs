using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_PurchaseOrderPaka: DevExpress.XtraReports.UI.XtraReport
    {
        int index;
        public Store_PurchaseOrderPaka()
        {
            InitializeComponent();
        }

        private void indexnumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel l = (XRLabel)sender;
            l.Text = index.ToString();
        }

        private void xr_SumValInTax_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void xr_SumValInTax_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
            try
            {
                XRLabel xr = (XRLabel)sender;
                double amounttotal = 0;
                double.TryParse(e.Value.ToString(), out amounttotal);
               // this.xr_AmountinWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            }
            catch
            {
            }
        }

       

     

    }
}
