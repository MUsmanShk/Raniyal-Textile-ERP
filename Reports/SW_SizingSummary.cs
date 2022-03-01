using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class SW_SizingSummary : DevExpress.XtraReports.UI.XtraReport
    {
       
        public SW_SizingSummary()
        {
            InitializeComponent();
        }

        private void IndexNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
        }

    }
}
