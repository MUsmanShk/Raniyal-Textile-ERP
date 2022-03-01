using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts.ReportingParameters
{
    public partial class xu_SalesSummary : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_SalesSummary()
        {
            InitializeComponent();
        }

        private void Closeit_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void xu_SalesSummary_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);
        }

        private void PrintLedger_Click(object sender, EventArgs e)
        {
            Reports.Accounts_SalesSummary Ledger = new Reports.Accounts_SalesSummary();

            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see ledger records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective To Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            string VCat = "";
            if (this.radioGroup1.EditValue.ToString() == "G")
                VCat = "'G'";
            else if (this.radioGroup1.EditValue.ToString() == "N")
                VCat = "'N'";
            else if (this.radioGroup1.EditValue.ToString() == "B")
                VCat = "'G','N'";
           

            string query = "";
            Ledger.BeginInit();
            query = "SELECT     iType,AccountID, BuyerMappedID, AccountName, AccountName_V, ROUND(SUM(Qty), 2) AS tQTY, SUM(ValExTax) AS tValExTax, SUM(ValTax) AS tValTax, SUM(ValInTax) " +
                  "    AS tValInTax, SUM(ValWHT) AS tValWHT FROM         dbo.Accounts_SalesSummary_IstStage where iDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iCat in(" + VCat + ") GROUP BY iType,AccountID, BuyerMappedID, AccountName, AccountName_V ";
               
          
            DataSet ds = WS.svc.Get_DataSet(query);


            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Ledger.repH_Type.Text = this.radioGroup1.EditValue.ToString();
            Ledger.repH_Dated_From.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            Ledger.repH_Dated_Upto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
          


            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Ledger.DataSource = ds;


                }
                else
                    Ledger.DataSource = null;
            }
            else
                Ledger.DataSource = null;
            Ledger.EndInit();
            Ledger.ShowPreview();
        }
    }
}
