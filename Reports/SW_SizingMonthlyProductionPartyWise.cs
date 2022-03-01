using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class SW_SizingMonthlyProductionPartyWise: DevExpress.XtraReports.UI.XtraReport
    {
        public SW_SizingMonthlyProductionPartyWise()
        {
            InitializeComponent();
        }

        private void BottomMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
