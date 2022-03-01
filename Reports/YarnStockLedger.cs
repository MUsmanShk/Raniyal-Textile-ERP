using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class YarnStockLedger : DevExpress.XtraReports.UI.XtraReport
    {
        public YarnStockLedger()
        {
            InitializeComponent();
        }

        private void xr_AdditionalInfo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

         
        }

    }
}
