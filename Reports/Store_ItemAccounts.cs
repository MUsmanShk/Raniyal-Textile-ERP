using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_ItemAccounts : DevExpress.XtraReports.UI.XtraReport
    {
        int indexno = 0;
        public Store_ItemAccounts()
        {
            InitializeComponent();
        }

        private void GroupAccountID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno = 0;
        }

        private void ItemIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

    }
}
