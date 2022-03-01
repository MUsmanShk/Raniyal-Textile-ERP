using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Store_ItemBinCard : DevExpress.XtraReports.UI.XtraReport
    {
        public double RunningBalance = 0;
        int indexnumber = 0;
        public Store_ItemBinCard()
        {
            InitializeComponent();
        }
        public void SetBalance(double Opening)
        {
            RunningBalance = Opening;
        }
        private void ItemIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexnumber++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexnumber.ToString();

        }

        private void Inward_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void Balance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (Inward.Tag != null)
                RunningBalance = RunningBalance + Convert.ToDouble(Inward.Tag.ToString());
            if (Outward.Tag != null)
                RunningBalance = RunningBalance - Convert.ToDouble(Outward.Tag.ToString());

            XRLabel xr = (XRLabel)sender;
            if (RunningBalance != 0)
            {

                xr.Text = RunningBalance.ToString("#,##0.00;(#,##0.00)");
            }
            else
                xr.Text = "0.00";
        }

    }
}
