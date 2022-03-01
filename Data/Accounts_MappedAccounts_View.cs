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
    public partial class Accounts_MappedAccounts_View : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow sRow = null;
        

        public Accounts_MappedAccounts_View()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_Accounts_View_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;
                ////query = "Select AccountID as ID, AccountName as [Account Name], FactoryAddress as [Factory Address], Mobile1 as [Mobile 1], Mobile2 as [Mobile 2], Phone1 as [Phone 1], Phone2 as [Phone 2], MailingAddress as [Mailing Address], ConcernedPerson1 as [Concerned Person 1], ConcernedPerson2 as [Concerned Person 2] from PP_Accounts order by AccountID";
                query = "Select AccountID, AccountName,MailingAddress from PP_Accounts order by AccountName";
                ds = WS.svc.Get_DataSet(query);

                if (ds != null)
                {
                    this.gridControl1.DataSource = ds.Tables[0];
                   

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                if (sRow.SelectedDataRow != null)
                {
                    sRow.PrimeryID = sRow.SelectedDataRow["AccountID"].ToString();
                    sRow.PrimaryString = sRow.SelectedDataRow["AccountName"].ToString();
                }
                sRow.Status = ParameterStatus.Selected;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    sRow.SelectedDataRow = this.gridView1.GetDataRow(this.gridView1.FocusedRowHandle);
                    if (sRow.SelectedDataRow != null)
                    {
                        sRow.PrimeryID = sRow.SelectedDataRow["AccountID"].ToString();
                        sRow.PrimaryString = sRow.SelectedDataRow["AccountName"].ToString();
                    }
                    sRow.Status = ParameterStatus.Selected;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Data_Accounts_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;
                this.Close();
            }
        }
    }
}