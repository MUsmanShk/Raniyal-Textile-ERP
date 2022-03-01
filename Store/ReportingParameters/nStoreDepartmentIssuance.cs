using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Store.ReportingParameters
{
    public partial class nStoreDepartmentIssuance: DevExpress.XtraEditors.XtraUserControl
    {
        public nStoreDepartmentIssuance()
        {
            InitializeComponent();
        }

        private void nYarnDepartmentStock_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.Departments_Sub(ref this.Department);
            fc.ItemTypes(ref this.lookUpEditAccount);
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
           




          

           
            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.FromDate.Focus();
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }

            SelectedDate.Date = this.FromDate.DateTime;
            SelectedDate.upTo = this.ToDate.DateTime;

            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select PRNO,Dated,ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,MinusRate,MinusQty,MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 ";

            if (this.lookUpEditAccount.EditValue != null)
            {
                query += " and IssueTypeID='" + this.lookUpEditAccount.EditValue.ToString() + "'";
            }

            if (this.Department.EditValue != null)
            {
                query += " and SubDepartmentID='" + this.Department.EditValue.ToString() + "'";
            }
            if (this.LoomName.EditValue != null)
            {
                query += " and LoomName='" + this.LoomName.EditValue.ToString() + "'";
            }
            query += " order by Dated,PRNO,DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            if (this.lookUpEditAccount.EditValue == null)
                MonthlyIssuance.IssueType.Text = " All Accounts ";
            else
                MonthlyIssuance.IssueType.Text = this.lookUpEditAccount.Text + " Account";
            
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();

           
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            MachineEyes.Reports.Parameters.ReportsMDI  mr = (MachineEyes.Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }

        private void lookUpEditAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                lookUpEditAccount.EditValue = null;
                
            }
        }

        private void Department_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                Department.EditValue = null;
        }

        private void LoomWise_Click(object sender, EventArgs e)
        {

            if (this.FromDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.FromDate.Focus();
                return;
            }
            if (this.ToDate.DateTime == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.FromDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }
            if (this.ToDate.EditValue == null)
            {
                XtraMessageBox.Show("invalid date, please enter valid date for stock ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.ToDate.Focus();
                return;
            }

            SelectedDate.Date = this.FromDate.DateTime;
            SelectedDate.upTo = this.ToDate.DateTime;

            Reports.Store_MonthlyLoomPartsConsumption MonthlyIssuance = new Reports.Store_MonthlyLoomPartsConsumption();
            string query = "select PRNO,Dated,ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,MinusRate,MinusQty,MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 ";

            if (this.lookUpEditAccount.EditValue != null)
            {
                query += " and IssueTypeID='" + this.lookUpEditAccount.EditValue.ToString() + "'";
            }

            if (this.Department.EditValue != null)
            {
                query += " and SubDepartmentID='" + this.Department.EditValue.ToString() + "'";
            }
            
            query += " order by Dated,PRNO,DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            if (this.lookUpEditAccount.EditValue == null)
                MonthlyIssuance.IssueType.Text = " All Accounts ";
            else
                MonthlyIssuance.IssueType.Text = this.lookUpEditAccount.Text + " Account";

            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }
    }
}
