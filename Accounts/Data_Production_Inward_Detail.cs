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
    public partial class Data_Production_Inward_Detail : DevExpress.XtraEditors.XtraForm
    {
        public SelectRowProductionInward sRow = null;


        public Data_Production_Inward_Detail()
        {
            InitializeComponent();
           
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_Production_Inward_View_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "";
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;
                query = "Select  Distinct I.PONumber, A.AccountName,P.ArticleShortName " +
                        "FROM FC_PO_Production_Inward I  "+
                        "LEFT JOIN FC_PO_Production_Dispatched D   "+
                        "ON D.FC_PO_Production_Inward_Id = I.ID   "+
                        "INNER JOIN [dbo].[FC_PO_Main]M   "+
                        "ON M.PONumber = I.PONumber  "+
                        "INNER JOIN PP_Article P "+
						"ON I.ArticleNumber = P.ArticleNumber "+
                        "INNER JOIN [dbo].[PP_Accounts] A   "+
                        "ON M.BuyerID = A.AccountID   " +
						"where I.R_Work = 0 and D.FC_PO_Production_Inward_Id IS NULL";
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
                    sRow.ArticleShortName = sRow.SelectedDataRow["ArticleShortName"].ToString();
                    sRow.AccountName = sRow.SelectedDataRow["AccountName"].ToString();

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
                        sRow.PONumber = sRow.SelectedDataRow["PONumber"].ToString();
                        sRow.ArticleShortName = sRow.SelectedDataRow["ArticleShortName"].ToString();
                        sRow.AccountName = sRow.SelectedDataRow["AccountName"].ToString();
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