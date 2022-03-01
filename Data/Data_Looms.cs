using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Data
{
    public partial class Data_Looms : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        public bool LoomsLoaded = false;
        public Data_Looms()
        {
            InitializeComponent();
        }
        public void LoadLooms()
        {
            DataSet ds = new DataSet();
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = null;

            ds = WS.svc.Get_DataSet("select * from SS_Looms order by ShedID,LoomID " );


            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
                this.gridView1.Columns["ShedName"].Caption = "Shed";
                this.gridView1.Columns["LoomName"].Caption = "Loom / Machine #";
                this.gridView1.Columns["TypeName"].Caption = "Model / Make";
                this.gridView1.Columns["MAC"].Caption = "MAC Address";
                this.gridView1.Columns["Current_RPM"].Caption = "Current RPM";
                this.gridView1.Columns["ArticleNumber"].Caption = "Current Article ";
                this.gridView1.Columns["LoomID"].Caption = "Index";
                this.gridView1.Columns["ShedID"].Caption = "Shed Index";


             

               
            }
            LoomsLoaded = true;
        }

        private void Data_Looms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedRow.Status = ParameterStatus.Cancelled;
                SelectedRow.PrimaryString = "";
                SelectedRow.PrimeryID = "";
                this.Hide();
            }
            else if (e.KeyCode == Keys.F5)
            {
                gridControl1.Refresh();
                gridView1.RefreshData();
                gridControl1.Visible = true;
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (SelectedRow.SelectedDataRow != null)
                {
                    SelectedRow.PrimeryID = SelectedRow.SelectedDataRow["LoomID"].ToString();
                    SelectedRow.PrimaryString = SelectedRow.SelectedDataRow["LoomName"].ToString();
                }

                SelectedRow.Status = ParameterStatus.Selected;
                this.Hide();
            }
          
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            SelectedRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (SelectedRow.SelectedDataRow != null)
            {
                SelectedRow.PrimeryID = SelectedRow.SelectedDataRow["LoomID"].ToString();
                SelectedRow.PrimaryString = SelectedRow.SelectedDataRow["LoomName"].ToString();
            }

            SelectedRow.Status = ParameterStatus.Selected;
            this.Hide(); 
        }

        private void Data_Looms_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void Data_Looms_Activated(object sender, EventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridView1.RefreshData();
            this.gridControl1.Visible = true;
        }
    }
}