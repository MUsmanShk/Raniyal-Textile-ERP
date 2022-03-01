using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{

    public partial class Store_PurchaseOrder : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Store_PurchaseOrder()
        {
            InitializeComponent();
        }

        private void TotalAmount_SummaryCalculated(object sender, TextFormatEventArgs e)
        {
           // XRLabel xr = (XRLabel)sender;
            
           // double.TryParse(e.Value.ToString(), out amounttotal);

        }

        private void xr_TotalAmountWords_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
        }

        private void TotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          
        }

        private void xrUserID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text = MachineEyes.Classes.Security.User.SCodes.UserID;
        }

        private void POIndexNumber_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

    }
}
