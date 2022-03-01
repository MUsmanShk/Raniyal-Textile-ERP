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
    public partial class xu_AuditTrail : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_AuditTrail()
        {
            InitializeComponent();
            this.Dated.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.Upto.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AuditTrail AuditTrail = new Reports.Accounts_AuditTrail();


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Dated.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Upto.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedDate.Date = this.Dated.DateTime;
            SelectedDate.upTo = this.Upto.DateTime;
            string query = "select * from Accounts_Vouchers where vDate>='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.Upto.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            DataSet ds = WS.svc.Get_DataSet(query);


            if (ds == null)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            //Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            //Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            //Ledger.xr_Accountof.Text = this.AccountID.Text;
            // Ledger.xr_AccountofName.Text = this.AccountName.Text;
            //ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString("s") + "' and vDate<='" + ToDate.DateTime.ToString("s") + "' ");
            AuditTrail.BeginInit();
            AuditTrail.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AuditTrail.repH_Dated.Text = this.Dated.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DatedUpto.Text = this.Upto.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DataSource = ds;
            AuditTrail.EndInit();
            AuditTrail.ShowPreview();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void UserWiseAuditTrail_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AuditTrail_UserWise AuditTrail = new Reports.Accounts_AuditTrail_UserWise();


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Dated.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Upto.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedDate.Date = this.Dated.DateTime;
            SelectedDate.upTo = this.Upto.DateTime;
            string query = "select * from Accounts_Vouchers where vDate>='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.Upto.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            DataSet ds = WS.svc.Get_DataSet(query);


            if (ds == null)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No records found", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
         
            AuditTrail.BeginInit();
            AuditTrail.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AuditTrail.repH_Dated.Text = this.Dated.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DatedUpto.Text = this.Upto.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DataSource = ds;
            AuditTrail.EndInit();
            AuditTrail.ShowPreview();
        }

        private void xu_AuditTrail_Load(object sender, EventArgs e)
        {

        }
    }
}
