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
    public partial class Data_Sale_Contract_Detail : DevExpress.XtraEditors.XtraForm
    {
        public SelectRowSaleContract sRow = null;


        public Data_Sale_Contract_Detail()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Data_Sale_Contract_View_Load(object sender, EventArgs e)
        {
            try
            {
                string query; //query1 = "";
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;
                ////query = "Select AccountID as ID, AccountName as [Account Name], FactoryAddress as [Factory Address], Mobile1 as [Mobile 1], Mobile2 as [Mobile 2], Phone1 as [Phone 1], Phone2 as [Phone 2], MailingAddress as [Mailing Address], ConcernedPerson1 as [Concerned Person 1], ConcernedPerson2 as [Concerned Person 2] from PP_Accounts order by AccountID";
                query = "select  M.PONumber,Ac.AccountName,a.ArticleShortName as ArticleName , D.SubDepartment,Y.POQTYMtrs from[dbo] .[FC_PO_YarnRequired] Y inner join [dbo].[FC_PO_Main]M on Y.PONO = M.PONumber inner join [dbo].[PP_Article] A on A.ArticleNumber = y.ArticleNumber inner join [dbo].[PP_Accounts] Ac on M.BuyerID = Ac.AccountID inner join [dbo].[PP_DepartmentsSub]D on D.SubDepartmentID = M.DeptID";
                ds = WS.svc.Get_DataSet(query);
               // ds = WS.svc.Get_DataSet(query1);

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
                    //sRow.PONO = sRow.SelectedDataRow["PONO"].ToString();
                    sRow.AccountName = sRow.SelectedDataRow["AccountName"].ToString();
                    sRow.ArticleName = sRow.SelectedDataRow["ArticleName"].ToString();
                    sRow.SubDepartment = sRow.SelectedDataRow["SubDepartment"].ToString();
                    sRow.POQTYMtrs = sRow.SelectedDataRow["POQTYMtrs"].ToString();

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
                       // sRow.PONO = sRow.SelectedDataRow["PONO"].ToString();
                        sRow.AccountName = sRow.SelectedDataRow["AccountName"].ToString();
                        sRow.ArticleName = sRow.SelectedDataRow["ArticleName"].ToString();
                        sRow.SubDepartment = sRow.SelectedDataRow["SubDepartment"].ToString();
                        sRow.POQTYMtrs = sRow.SelectedDataRow["POQTYMtrs"].ToString();
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

        private void Data_Sale_Contract_View_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sRow.Status = ParameterStatus.Cancelled;
                this.Close();
            }
        }
    }
}