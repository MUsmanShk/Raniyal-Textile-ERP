using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts
{
    public partial class AccountsList : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        public AccountsList()
        {
            InitializeComponent();
        }
        public void Load_Accounts(string query)
        {
            if (query == "")
                query = "select * from Accounts_ChartofAccounts order by AccountName_V,AccountID_V";
            DataSet ds = new DataSet();
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = null;

            ds = WS.svc.Get_DataSet(query);


            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
                this.gridView1.Columns["AccountID_V"].Width = this.gridControl1.Width * 10 / 100;
                this.gridView1.Columns["AccountName_V"].Width = this.gridControl1.Width * 30 / 100;
                this.gridView1.Columns["AccountID_IV"].Width = this.gridControl1.Width * 7 / 100;
                this.gridView1.Columns["AccountName_IV"].Width = this.gridControl1.Width * 25 / 100;
                this.gridView1.Columns["AccountID_III"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["AccountName_III"].Width = this.gridControl1.Width * 25 / 100;
                this.gridView1.Columns["AccountID_II"].Width = this.gridControl1.Width * 3 / 100;
                this.gridView1.Columns["AccountName_II"].Width = this.gridControl1.Width * 20 / 100;
                this.gridView1.Columns["AccountID_I"].Visible = false;
                this.gridView1.Columns["AccountName_I"].Visible = false;
            }
        }

        private void AccountsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false)
            {
                e.Cancel = true; this.Hide();
            }
        }

        private void AccountsList_KeyDown(object sender, KeyEventArgs e)
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
                this.Load_Accounts("");
                this.gridControl1.Refresh();
                this.gridView1.RefreshData();

                this.gridControl1.Visible = true;

            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            SelectedRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
            if (SelectedRow.SelectedDataRow != null)
            {
                SelectedRow.PrimeryID = SelectedRow.SelectedDataRow[0].ToString();
                SelectedRow.PrimaryString = SelectedRow.SelectedDataRow[1].ToString();
            }

            SelectedRow.Status = ParameterStatus.Selected;
            this.Hide(); 
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (SelectedRow.SelectedDataRow != null)
                {
                    SelectedRow.PrimeryID = SelectedRow.SelectedDataRow[0].ToString();
                    SelectedRow.PrimaryString = SelectedRow.SelectedDataRow[1].ToString();
                }

                SelectedRow.Status = ParameterStatus.Selected;
                this.Hide();
            }
        }

        private void AccountsList_Activated(object sender, EventArgs e)
        {
            this.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            
        }
    }
}