using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Data_Assign_Weaver : DevExpress.XtraEditors.XtraForm
    {
        public Data_Assign_Weaver()
        {
            InitializeComponent();
        }

       
        private void UtoA_Click(object sender, EventArgs e)
        {
            //int[] SelectedRowsHandles=this.gridView_U.GetSelectedRows();
            //string qres = "";
            //for (int x = 0; x < SelectedRowsHandles.Length; x++)
            //{
            //    DataRow dr = this.gridView_U.GetDataRow(SelectedRowsHandles[x]);
            //  qres=
            //}
        }

        private void simpleButton_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton_Assign_Click(object sender, EventArgs e)
        {
            try
            {
                int GroupNumber = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].GroupNumber;
                string query = "update  MT_Looms set WeaverID_A=";
                query += this.lookUpEdit_A.EditValue == null ? "null" : "'" + this.lookUpEdit_A.EditValue.ToString() +"'";

                query += ",WeaverID_B=";
                query += this.lookUpEdit_B.EditValue == null ? "null" : "'" + this.lookUpEdit_B.EditValue.ToString() + "'";
                query += ",WeaverID_C=";
                query += this.lookUpEdit_C.EditValue == null ? "null" : this.lookUpEdit_C.EditValue.ToString() + "'";
                query+=" where GroupNumber=" + GroupNumber.ToString() + "";
                string qres = WS.svc.Execute_Query(query);
                if (qres != "**SUCCESS##")
                {
                    XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (this.lookUpEdit_A.EditValue != null)
                    {
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_A = this.lookUpEdit_A.GetColumnValue("EmployeeID").ToString();
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_A = this.lookUpEdit_A.GetColumnValue("EmployeeName").ToString();
                    }
                    if (this.lookUpEdit_B.EditValue != null)
                    {
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_B = this.lookUpEdit_B.GetColumnValue("EmployeeID").ToString();
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_B = this.lookUpEdit_B.GetColumnValue("EmployeeName").ToString();
                    }
                    if (this.lookUpEdit_C.EditValue != null)
                    {
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_C = this.lookUpEdit_C.GetColumnValue("EmployeeID").ToString();
                        Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverName_C = this.lookUpEdit_C.GetColumnValue("EmployeeName").ToString();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Data_Assign_Weaver_Load(object sender, EventArgs e)
        {
            if (Settings.CurrentSettings.NoofShifts != 3)
            {
                this.simpleButton_C.Visible = false;
                this.lookUpEdit_C.Visible = false;
            }
            this.Text = "Assign Weaver to Group # " + Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].GroupName.ToString();
            string sqlquery = "Select EmployeeID,EmployeeName from PP_Employees where SubDepartmentID in(select SubDepartmentID from PP_DepartmentsSub where DepartmentID='" + Departments.Weaving+ "') and DesignationID='" + Settings.WeaversDesignationID + "' order by EmployeeName";
            DataSet ds = WS.svc.Get_DataSet(sqlquery);
            this.lookUpEdit_A.Properties.DataSource = ds.Tables[0];
            this.lookUpEdit_A.Properties.DisplayMember = "EmployeeName";
            this.lookUpEdit_A.Properties.ValueMember = "EmployeeID";
            this.lookUpEdit_B.Properties.DataSource = ds.Tables[0];
            this.lookUpEdit_B.Properties.DisplayMember = "EmployeeName";
            this.lookUpEdit_B.Properties.ValueMember = "EmployeeID";
            this.lookUpEdit_C.Properties.DataSource = ds.Tables[0];
            this.lookUpEdit_C.Properties.DisplayMember = "EmployeeName";
            this.lookUpEdit_C.Properties.ValueMember = "EmployeeID";
            if (Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_A != "")
                this.lookUpEdit_A.EditValue = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_A;
            else
                this.lookUpEdit_A.EditValue = null;

            if (Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_B != "")
                this.lookUpEdit_B.EditValue = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_B;
            else
                this.lookUpEdit_B.EditValue = null;

            if (Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_C != "")
                this.lookUpEdit_C.EditValue = Program.ss.Machines.PresentationData.Sheds[CurrentSelection.ShedIndex].LoomGroups[CurrentSelection.CurrentGroupIndex].Weavers.WeaverID_C;
            else
                this.lookUpEdit_C.EditValue = null;
        }
        
    }
}