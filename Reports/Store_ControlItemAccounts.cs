using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_ControlItemAccounts : DevExpress.XtraReports.UI.XtraReport
    {
        int indexnumber = 0;
        public Store_ControlItemAccounts()
        {
            InitializeComponent();
        }

        private void ItemIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexnumber++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexnumber.ToString();
        }

    }
}
