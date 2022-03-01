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
    public partial class Data_Emp_View : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow sRow=null;
        bool Selected;
        public Data_Emp_View()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_Emp_View_Load(object sender, EventArgs e)
        {
           
        }

        public void LoadEmployees(string SubDepartmentID)
        {
            try
            {
                this.gridControl1.DataSource = null;
                string query = "select * from QP_Employees where SubDepartmentID='"+SubDepartmentID+"' order by Convert(numeric(18),EmployeeID)";
                DataSet ds = WS.svc.Get_DataSet(query);
                this.gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        public void LoadEmployees_OnQuery(string Query)
        {
            try
            {
                this.gridControl1.DataSource = null;
                
                DataSet ds = WS.svc.Get_DataSet(Query);
                this.gridControl1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
        private void Data_Emp_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Selected == false)
                sRow.Status = ParameterStatus.Cancelled;
        }

       

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void bandedGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Selected = true;
                sRow.SelectedDataRow = this.bandedGridView1.GetDataRow(this.bandedGridView1.FocusedRowHandle);
                if (sRow.SelectedDataRow != null)
                {
                    sRow.PrimeryID = sRow.SelectedDataRow[0].ToString();
                    sRow.PrimaryString = sRow.SelectedDataRow[1].ToString();
                }

                sRow.Status = ParameterStatus.Selected;
                this.Close();

            }
        }

        private void bandedGridView1_DoubleClick(object sender, EventArgs e)
        {
            Selected = true;
            sRow.SelectedDataRow = this.bandedGridView1.GetDataRow(this.bandedGridView1.FocusedRowHandle);
            if (sRow.SelectedDataRow != null)
            {
                sRow.PrimeryID = sRow.SelectedDataRow[0].ToString();
                sRow.PrimaryString = sRow.SelectedDataRow[1].ToString();
            }

            sRow.Status = ParameterStatus.Selected;
            this.Close();
        }

      

      

    }
}