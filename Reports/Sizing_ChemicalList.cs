using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Sizing_ChemicalList : DevExpress.XtraReports.UI.XtraReport
    {
        int index = 0;
        public Sizing_ChemicalList()
        {
            InitializeComponent();
        }

        private void xrIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            index++;
            XRLabel s = (XRLabel)sender;
            s.Text = index.ToString();
        }

    }
}
