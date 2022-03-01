using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Store
{
    
    public partial class Store_RequestApproval : DevExpress.XtraEditors.XtraForm
    {
        public Store_RequestApproval()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.StoreRequestStatus(ref this.RequestStatusLookup,"0");
            fc.Departments_Sub(ref this.R_Departments);
            this.R_FromDate.DateTime = DateTime.Now;
            this.R_UptoDate.DateTime = DateTime.Now;
            fc.Departments_Sub(ref this.DepartmentReq);
            Load_Requests();
        }
        private void Load_Requests()
        {
            string filterquery = "Select * from RST_DepartmentStoreRequisition  where RequisitionStatusID='0'";
            DataSet dsf = WS.svc.Get_DataSet(filterquery);
            this.gridControl_Selection.DataSource = dsf.Tables[0];
            DevExpress.XtraGrid.StyleFormatCondition cn;
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.gridView_Selection.Columns["RequisitionStatusID"], null, "0");
            cn.Appearance.BackColor = Color.White;
            cn.Appearance.ForeColor = Color.Black;
            cn.ApplyToRow = true;
            this.gridView_Selection.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.gridView_Selection.Columns["RequisitionStatusID"], null, "1");
            cn.Appearance.BackColor = Color.White;
            cn.Appearance.ForeColor = Color.DarkGreen;
            cn.ApplyToRow = true;
            this.gridView_Selection.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.gridView_Selection.Columns["RequisitionStatusID"], null, "2");
            cn.Appearance.BackColor = Color.White;
            cn.Appearance.ForeColor = Color.OrangeRed;
            cn.ApplyToRow = true;
            this.gridView_Selection.FormatConditions.Add(cn);
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, this.gridView_Selection.Columns["RequisitionStatusID"], null, "5");
            cn.Appearance.BackColor = Color.Yellow;
            cn.Appearance.ForeColor = Color.Blue;
            cn.ApplyToRow = true;
            this.gridView_Selection.FormatConditions.Add(cn);
        }

        private void RequestStatusLookup_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lk=(DevExpress.XtraEditors.LookUpEdit)sender;
            DataRow ItemAccountRow = this.gridView_Selection.GetDataRow(this.gridView_Selection.FocusedRowHandle);
            if (lk.EditValue != null && ItemAccountRow!=null)
            {
                string query = "Update ST_DepartmentStoreRequisition Set RequisitionStatusID='" + lk.EditValue.ToString() + "',QtyApproved=" + ItemAccountRow["QTYAPPROVED"].ToString() + " where RequisitionNumber='" + ItemAccountRow["RequisitionNumber"].ToString() + "'";
               string s= WS.svc.Execute_Query(query);
               if (s != "**SUCCESS##")
               {
                   XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
               }
               try
               {
                   if (lk.EditValue.ToString() == "5")
                       WS.svc.Set_DesktopAlert("Req. Need Discussion " , "Store Requsition # " + ItemAccountRow["RequisitionNumber"] + " Item " + ItemAccountRow["ItemAccountName"] + " Raised by " + ItemAccountRow["DepartmentName"] + " need to discuss with Approval Authority.....", 1, 5);
                   else if (lk.EditValue.ToString() == "1")
                       WS.svc.Set_DesktopAlert("Requisition Approved" , "Store Requsition # " + ItemAccountRow["RequisitionNumber"] + " Item " + ItemAccountRow["ItemAccountName"] + " Raised by " + ItemAccountRow["DepartmentName"] + " has been approved by authority.....", 0, 1);
                   else if (lk.EditValue.ToString() == "2")
                       WS.svc.Set_DesktopAlert("Requisition Rejected", "Store Requsition # " + ItemAccountRow["RequisitionNumber"] + " Item " + ItemAccountRow["ItemAccountName"] + " Raised by " + ItemAccountRow["DepartmentName"] + " has been rejected by authority.....", 2, 2);
               }
               catch
               {
               }
            }

        }

        private void GetRecords_Click(object sender, EventArgs e)
        {
            string filterquery = "Select * from RST_DepartmentStoreRequisition  where RequisitionStatusID in("+this.Filter_RequisitionStatus.EditValue.ToString()+") ";
            string addFilter = "";
            if (this.Filter_Date.EditValue != null)
            {
                if (this.Filter_Date.EditValue.ToString() == "1")
                {
                    addFilter += " and Dated='" + this.DateReq.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
                }
            }

            if (this.Filter_Department.EditValue.ToString() =="1")
            {
                if (this.DepartmentReq.EditValue!=null)
                {
                    addFilter += " and DepartmentID='" + this.DepartmentReq.EditValue.ToString() + "'";
                }
            }
            if (this.Filter_Stock.EditValue!=null)
            {
                if (this.Filter_Stock.EditValue.ToString() == "0")
                    addFilter += " and StockAtTime>0";
                else if (this.Filter_Stock.EditValue.ToString() == "1")
                    addFilter += " and StockAtTime=0 or StockAtTime is null";
                
                
            }
            DataSet dsf = WS.svc.Get_DataSet(filterquery + addFilter);
            this.gridControl_Selection.DataSource = dsf.Tables[0];
        }

        private void Filter_Stock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void R_GetRequisitions_Click(object sender, EventArgs e)
        {
            if (this.R_Departments.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Department ! Please select valid department", "Invalid Department!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.R_Departments.Focus();
                return;
            }
            if (this.R_FromDate.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Date ! Please select valid Date", "Invalid Date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.R_FromDate.Focus();
                return;
            }
            if (this.R_UptoDate.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Date ! Please select valid Date", "Invalid Date!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.R_UptoDate.Focus();
                return;
            }
            string query = "";
            query = "Select * from RST_DepartmentStoreRequisition where DepartmentID='" + this.R_Departments.EditValue.ToString() + "' and Dated>='" + this.R_FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.R_UptoDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            string inquery = "";
            if (this.R_Status_Approved.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_Approved.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_Approved.Tag.ToString() + "'";

            if (this.R_Status_Discuss.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_Discuss.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_Discuss.Tag.ToString() + "'";

            if (this.R_Status_PORaised.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_PORaised.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_PORaised.Tag.ToString() + "'";
            if (this.R_Status_Rejected.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_Rejected.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_Rejected.Tag.ToString() + "'";
            if (this.R_Status_Requested.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_Requested.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_Requested.Tag.ToString() + "'";
            if (this.R_Status_Served.Checked == true)
                if (inquery == "") inquery += "'" + this.R_Status_Served.Tag.ToString() + "'";
                else inquery += "," + "'" + this.R_Status_Served.Tag.ToString() + "'";
            if (inquery != "")
                query += " and RequisitionStatusID in(" + inquery + ")";

            DataSet ds = WS.svc.Get_DataSet(query);

            Reports.Store_RequisitionSummary ReqSummary = new Reports.Store_RequisitionSummary();
            ReqSummary.BeginInit();
            ReqSummary.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ReqSummary.From.Text = this.R_FromDate.DateTime.ToString("dd-MMM-yyyy");
            ReqSummary.Upto.Text = this.R_UptoDate.DateTime.ToString("dd-MMM-yyyy");
            ReqSummary.DepartmentName.Text = this.R_Departments.Text;
            ReqSummary.DataSource = ds.Tables[0];
            ReqSummary.EndInit();
            ReqSummary.ShowPreview();
        }
    }
}