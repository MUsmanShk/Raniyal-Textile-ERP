using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_AnnexC : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Accounts_AnnexC()
        {
            InitializeComponent();
        }

        private void xr_Index_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = index.ToString();
        }

        private void xrDocumentType_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Tag.ToString() == "901")
                xr.Text = "SI";

        }

   
    }
}
