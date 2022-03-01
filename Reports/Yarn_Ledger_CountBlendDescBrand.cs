using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Yarn_Ledger_CountBlendDescBrand : DevExpress.XtraReports.UI.XtraReport
    {
        double Bags_Opening = 0, Lbs_Opening = 0, Bags_Running = 0, Lbs_Running = 0;
        int indexno = 0;
        public Yarn_Ledger_CountBlendDescBrand()
        {
            InitializeComponent();
        }
        public void SetYarnOpeningBalance(string Bags, string Lbs)
        {
            double.TryParse(Bags, out Bags_Opening);
            double.TryParse(Lbs, out Lbs_Opening);
            Bags_Running = Bags_Opening;
            Lbs_Running = Lbs_Opening;
        }

        private void OpeningBags_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            xr.Text = Bags_Opening.ToString("#,##;(#,##)");
        }

        private void OpeningLbs_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            xr.Text = Lbs_Opening.ToString("#,##0.00;(#,##0.00)");
        }

        private void BagsBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double bagsbalancewithoutopening = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out bagsbalancewithoutopening);
            }
            else
                bagsbalancewithoutopening = 0;
            Bags_Running += bagsbalancewithoutopening;
            xr.Text = Bags_Running.ToString("#,##;(#,##)");
        }

        private void LbsBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double lbsbalancewithoutopening = 0;
            if (xr.Tag != null)
            {
                double.TryParse(xr.Tag.ToString(), out lbsbalancewithoutopening);
            }
            else
                lbsbalancewithoutopening = 0;
            Lbs_Running += lbsbalancewithoutopening;
            xr.Text = Lbs_Running.ToString("#,##0.00;(#,##0.00)");
        }

        private void TotalBagsBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            xr.Text = Bags_Running.ToString("#,##;(#,##)");
        }

        private void TotalLbsBalance_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel xr = (XRLabel)sender;

            xr.Text = Lbs_Running.ToString("#,##0.00;(#,##0.00)");
        }

        private void xrIndex_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            indexno++;
            XRLabel xr = (XRLabel)sender;
            xr.Text = indexno.ToString();
        }

    }
}
