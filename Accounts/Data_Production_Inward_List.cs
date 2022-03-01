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
    public partial class Data_Production_Inward_List : DevExpress.XtraEditors.XtraForm
    {
        public ProductionInwardList sRow = null;


        public Data_Production_Inward_List()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_Production_Inward_List_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;
                query = "select Distinct P.PONumber,Ac.AccountName,a.ArticleShortName as ArticleName "+
                        " from FC_PO_Production_Inward P "+
                        " inner join PP_Article A on "+
                        " P.ArticleNumber = A.ArticleNumber "+
                        " inner join [FC_PO_YarnRequired] Y  on P.PoNumber = Y.PONO  "+
                        " inner join [dbo].[FC_PO_Main]M on Y.PONO = M.PONumber  "+
                        " inner join [dbo].[PP_Accounts] Ac on M.BuyerID = Ac.AccountID  ";
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
                    sRow.PONumber = sRow.SelectedDataRow["PONumber"].ToString();
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
                        sRow.PONumber = sRow.SelectedDataRow["PONumber"].ToString();
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

        private void Data_Production_Inward_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;
                this.Close();
            }
        }
    }
}