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
    public partial class xu_PostedUnpostedVouchers : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_PostedUnpostedVouchers()
        {
            InitializeComponent();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AuditTrail AuditTrail = new Reports.Accounts_AuditTrail();


            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string VCat = "";
            if (this.radioGroup1.EditValue.ToString() == "G")
                VCat = "'G'";
            else if (this.radioGroup1.EditValue.ToString() == "N")
                VCat = "'N'";
            else if (this.radioGroup1.EditValue.ToString() == "B")
                VCat = "'G','N'";
            SelectedDate.Date = this.FromDate.DateTime;
            SelectedDate.upTo = this.ToDate.DateTime;
            string query = "select * from Accounts_Vouchers where vDate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VCat in(" + VCat + ") and VStatus='"+this.radioGroup_VoucherState.EditValue.ToString()+"' ";
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
            AuditTrail.repH_Dated.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DatedUpto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.VoucherState.Text = this.radioGroup_VoucherState.EditValue.ToString();
            AuditTrail.VoucherType.Text = VCat;
            AuditTrail.DataSource = ds;
            AuditTrail.EndInit();
            AuditTrail.ShowPreview();
        }

        private void Closeit_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void xu_PostedUnpostedVouchers_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
        }

        private void UserWiseAuditTrail_Click(object sender, EventArgs e)
        {
            Reports.Accounts_AuditTrail_UserWise AuditTrail = new Reports.Accounts_AuditTrail_UserWise();


            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date from which you want to see records", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("Select Valid Effective Date", "Validation Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string VCat = "";
            if (this.radioGroup1.EditValue.ToString() == "G")
                VCat = "'G'";
            else if (this.radioGroup1.EditValue.ToString() == "N")
                VCat = "'N'";
            else if (this.radioGroup1.EditValue.ToString() == "B")
                VCat = "'G','N'";
            SelectedDate.Date = this.FromDate.DateTime;
            SelectedDate.upTo = this.ToDate.DateTime;
            string query = "select * from Accounts_Vouchers where vDate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and VCat in(" + VCat + ") and VStatus='" + this.radioGroup_VoucherState.EditValue.ToString() + "' ";
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
            AuditTrail.repH_Dated.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.DatedUpto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            AuditTrail.VoucherState.Text = this.radioGroup_VoucherState.EditValue.ToString();
            AuditTrail.VoucherType.Text = VCat;
            AuditTrail.DataSource = ds;
            AuditTrail.EndInit();
            AuditTrail.ShowPreview();
        }
    }
}
