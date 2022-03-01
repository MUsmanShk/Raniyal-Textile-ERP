using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Inspection_Greige_PackingList : DevExpress.XtraReports.UI.XtraReport
    {
        int IndexNumber = 0;
        public Inspection_Greige_PackingList()
        {
            InitializeComponent();
        }

        private void IndexNo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IndexNumber++;
            XRLabel indexlabel = (XRLabel)sender;
            indexlabel.Text = IndexNumber.ToString("#,##");
        }

        private void GroupCountPieces_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IndexNumber = 0;
        }

    }
}
