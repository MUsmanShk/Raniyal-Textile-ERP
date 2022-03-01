using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MachineEyes.Reports
{
    public partial class Accounts_PaymentAdvice : DevExpress.XtraReports.UI.XtraReport
    {
        public Accounts_PaymentAdvice()
        {
            InitializeComponent();
        }

        private void xrUserID_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel l = (XRLabel)sender;
            l.Text = MachineEyes.Classes.Security.User.SCodes.UserID;
        }

        private void Item_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            if (xr.Text == "")
            {
                QtyLabel.Visible = false;
                GrossAmountLabel.Visible = false;
                Itemlabel.Visible = false;
                AmountafterGSTLabel.Visible = false;
                AttheRateLabel.Visible = false;
                IncomeTaxLabel.Visible = false;
                WHTLabel.Visible = false;
                GSTLabel.Visible = false;
                Rate.Visible = false;
                Quantity.Visible = false;
                QtyRateAmount.Visible = false;
               
            }
        }

        private void Rate_AfterPrint(object sender, EventArgs e)
        {
            XRLabel xr = (XRLabel)sender;
            double val = 0;
            double.TryParse(xr.Tag.ToString(), out val);
            if (val <= 0)
            {
                this.Rate.Visible = false;
                this.AttheRateLabel.Visible = false;
                this.QtyLabel.Visible = false;
                this.Quantity.Visible = false;
            }
        }

        private void FinancialYear_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int findex = MachineEyes.Classes.Accounting.Return_FinancialYear(MachineEyes.Classes.Accounting.RegAccounts.FinancialYear);
            if (findex != -1)
                FinancialYear.Text = MachineEyes.Classes.Accounting.FinancialYears[findex].YearFormat;
            else
                FinancialYear.Text = "Invalid";
        }

    }
}
