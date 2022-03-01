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
    public partial class xu_SalesRegister_FilterParty : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_SalesRegister_FilterParty()
        {
            InitializeComponent();
        }

        private void BrowseAccountof_Click(object sender, EventArgs e)
        {
            Program.MainWindow.AccountsList.ShowDialog();
            if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
            {
                this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
            }
        }

        private void xu_SalesRegister_FilterParty_Load(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);
            this.ToDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.FromDate.DateTime = this.ToDate.DateTime.Subtract(ts);
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_SalesLedger_FilterParty Ledger = new Reports.Accounts_SalesLedger_FilterParty();

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
           
            string VCat = "'N'";
           
            string query = "Select * from Accounts_SalesTaxRegister_FilterParty where BuyerID='" + this.AccountID.Text + "' and iCat in(" + VCat + ") and iDate>='" + FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iDate<='" + ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18,0),iNumber)  ";
            DataSet ds = WS.svc.Get_DataSet(query);
            Ledger.BeginInit();
           
            Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yy");
            Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yy");
            Ledger.xr_Accountof.Text = this.AccountID.Text;
            Ledger.xr_AccountofName.Text = this.AccountName.Text;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Ledger.DataSource = ds;
                else
                    Ledger.DataSource = null;
            }
            else
                Ledger.DataSource = null;
            Ledger.EndInit();
            Ledger.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
