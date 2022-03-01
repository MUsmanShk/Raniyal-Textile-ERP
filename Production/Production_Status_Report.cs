using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Production
{
    public partial class Production_Status_Report : DevExpress.XtraEditors.XtraForm
    {

        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        string TotalProductionInward;
        public Production_Status_Report()
        {
            InitializeComponent();
            dgridStatusReport.AllowUserToAddRows = false;
        }

        private void StatusReport()
        {
            DataSet ds = new DataSet();
            string query = "Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SRNo, A.AccountName,I.PONumber,Convert(varchar,(M.Dated),106) as Dated, " +
                           "Convert(varchar,(M.ExpiryDate),106)ExpiryDate,P.WarpYarnCount_0 as Warp,P.WeftYarnCount_0 as Weft " +
                            " ,P.EPI as Ends,P.PPI as Picks,P.Width as Width,y.POQTYMTRS " +
                            " ,isnull(Sum(I.Grade_A),0) as IGradeA " +
                            " ,isnull(Sum(I.Grade_B),0)as IGradeB " +
                            " ,isnull(Sum(I.Grade_C_40Up),0) as IGrade40up " +
                            " ,isnull(Sum(I.Grade_C_10UP),0) as IGrade10up " +
                            " ,isnull(Sum(I.Grade_C_1to9),0) as IGrade1to9 " +
                            " ,isnull(Sum(I.R_Work),0) as IRWork, " +
                            "y.POQTYMTRS - ((isnull(Sum(I.Grade_A),0))+(isnull(Sum(I.Grade_B),0))+ " +
                            "(isnull(Sum(I.Grade_C_40Up),0))+(isnull(Sum(I.Grade_C_10UP),0))+ " +
                            "(isnull(Sum(I.Grade_C_1to9),0))+(isnull(Sum(I.R_Work),0))) as WeavingBalance, " +
                            " DGradeA = (SELECT isnull(Sum(I.Grade_A),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' ) , " +
                            " DGradeB = (SELECT isnull(Sum(I.Grade_B),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' ) , " +
                            " DGradeC40up = (SELECT isnull(Sum(I.Grade_C_40Up),0)  FROM FC_PO_Production_Dispatched D " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            " DGradeC10up = (SELECT isnull(Sum(I.Grade_C_10UP),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            " DGradeC1to9 = (SELECT isnull(Sum(I.Grade_C_1to9),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            "BalanceContract = (SELECT (y.POQTYMTRS - ((isnull(Sum(I.Grade_A),0)) " +
                            "+(isnull(Sum(I.Grade_B),0))+(isnull(Sum(I.Grade_C_40Up),0))+ " +
                            " (isnull(Sum(I.Grade_C_10UP),0))+(isnull(Sum(I.Grade_C_1to9),0)))) " +
                            "FROM FC_PO_Production_Dispatched D    " +
                            "INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id   " +
                            "INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber     " +
                            "INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO   " +
                            "INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            "INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID " +
                            "where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "')  " +
                            "and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "')  " +
                            "and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' group by y.POQTYMTRS)  " +
                            " from FC_PO_Production_Inward I " +
                            " INNER JOIN [dbo].[FC_PO_Main]M    " +
                            " ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y " +
                            " ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P " +
                            " on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A    " +
                            " ON M.BuyerID = A.AccountID  " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and ('' = '" + partyName.Text + "' or A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate  between  '" + FromDate.Text + "' and  '" + ToDate.Text + "'   " +
                            " group by I.PONumber,A.AccountName,M.Dated,M.ExpiryDate, " +
                            " P.WarpYarnCount_0,P.WeftYarnCount_0,P.WeftYarnCount_0,P.EPI,P.PPI,P.Width,y.POQTYMTRS";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0].Copy();
                if (dt.Rows.Count > 0)
                {
                    for (var i = 1; i < ds.Tables.Count; i++)
                    {
                        dt.Merge(ds.Tables[i]);
                    }
                    dgridStatusReport.AutoGenerateColumns = true;
                    dgridStatusReport.DataSource = dt;
                }
            }

        }



        private void SaleContract_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                SelectRowProductionStatusReport sRow = new SelectRowProductionStatusReport();
                Data.Data_Production_Status_Report AView = new Data.Data_Production_Status_Report();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.SaleContract.Text = sRow.PONumber;
                        this.partyName.Text = sRow.AccountName;


                    }
                }
            }

        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (this.SaleContract.Text == "")
            {
                XtraMessageBox.Show("Enter SaleContract name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FromDate.Text == "")
            {
                XtraMessageBox.Show("Enter Both Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.ToDate.Text == "")
            {
                XtraMessageBox.Show("Enter Both Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDateTime(FromDate.Text) > Convert.ToDateTime(ToDate.Text))
            {
                XtraMessageBox.Show("Enter Proper Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                StatusReport();
            }

        }

        private void SaleContract_TextChanged(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.SaleContract.Text == "")
            {
                XtraMessageBox.Show("Enter SaleContract name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FromDate.Text == "")
            {
                XtraMessageBox.Show("Enter Both Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.ToDate.Text == "")
            {
                XtraMessageBox.Show("Enter Both Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Convert.ToDateTime(FromDate.Text) > Convert.ToDateTime(ToDate.Text))
            {
                XtraMessageBox.Show("Enter Proper Dates", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                Reports.FC_PO_Status_Report sReport = new Reports.FC_PO_Status_Report();
                DataSet ds = new DataSet();
               string query = "Select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS SRNo, A.AccountName,I.PONumber,Convert(varchar,(M.Dated),106) as Dated, " +
                           "Convert(varchar,(M.ExpiryDate),106)ExpiryDate,P.WarpYarnCount_0 as Warp,P.WeftYarnCount_0 as Weft " +
                            " ,P.EPI as Ends,P.PPI as Picks,P.Width as Width,y.POQTYMTRS " +
                            " ,isnull(Sum(I.Grade_A),0) as IGradeA " +
                            " ,isnull(Sum(I.Grade_B),0)as IGradeB " +
                            " ,isnull(Sum(I.Grade_C_40Up),0) as IGrade40up " +
                            " ,isnull(Sum(I.Grade_C_10UP),0) as IGrade10up " +
                            " ,isnull(Sum(I.Grade_C_1to9),0) as IGrade1to9 " +
                            " ,isnull(Sum(I.R_Work),0) as IRWork, " +
                            "y.POQTYMTRS -( (isnull(Sum(I.Grade_A),0))+(isnull(Sum(I.Grade_B),0))+ " +
                            "(isnull(Sum(I.Grade_C_40Up),0))+(isnull(Sum(I.Grade_C_10UP),0))+ " +
                            "(isnull(Sum(I.Grade_C_1to9),0))+(isnull(Sum(I.R_Work),0))) as WeavingBalance, " +
                            " DGradeA = (SELECT isnull(Sum(I.Grade_A),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' ) , " +
                            " DGradeB = (SELECT isnull(Sum(I.Grade_B),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' ) , " +
                            " DGradeC40up = (SELECT isnull(Sum(I.Grade_C_40Up),0)  FROM FC_PO_Production_Dispatched D " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            " DGradeC10up = (SELECT isnull(Sum(I.Grade_C_10UP),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            " DGradeC1to9 = (SELECT isnull(Sum(I.Grade_C_1to9),0)  FROM FC_PO_Production_Dispatched D  " +
                            " INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id " +
                            " INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID   " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "'  ), " +
                            "BalanceContract = (SELECT (y.POQTYMTRS - ((isnull(Sum(I.Grade_A),0)) " +
                            "+(isnull(Sum(I.Grade_B),0))+(isnull(Sum(I.Grade_C_40Up),0))+ " +
                            " (isnull(Sum(I.Grade_C_10UP),0))+(isnull(Sum(I.Grade_C_1to9),0)))) " +
                            "FROM FC_PO_Production_Dispatched D    " +
                            "INNER join FC_PO_Production_Inward I on I.ID = D.FC_PO_Production_Inward_Id   " +
                            "INNER JOIN [dbo].[FC_PO_Main]M ON M.PONumber = I.PONumber     " +
                            "INNER JOIN FC_PO_YarnRequired y ON M.PONumber = y.PONO   " +
                            "INNER JOIN PP_Article P on I.ArticleNumber = p.ArticleNumber " +
                            "INNER JOIN [dbo].[PP_Accounts] A   ON M.BuyerID = A.AccountID " +
                            "where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "')  " +
                            "and (A.AccountName = '" + partyName.Text + "')  " +
                            "and  I.ProductionDate between  '" + FromDate.Text + "' and '" + ToDate.Text + "' group by y.POQTYMTRS)  " +
                            " from FC_PO_Production_Inward I " +
                            " INNER JOIN [dbo].[FC_PO_Main]M    " +
                            " ON M.PONumber = I.PONumber   " +
                            " INNER JOIN FC_PO_YarnRequired y " +
                            " ON M.PONumber = y.PONO " +
                            " INNER JOIN PP_Article P " +
                            " on I.ArticleNumber = p.ArticleNumber " +
                            " INNER JOIN [dbo].[PP_Accounts] A    " +
                            " ON M.BuyerID = A.AccountID  " +
                            " where ('' = '" + SaleContract.Text + "' or I.PONumber = '" + SaleContract.Text + "') " +
                            " and (A.AccountName = '" + partyName.Text + "') " +
                            " and  I.ProductionDate between  '" + FromDate.Text + "' and  '" + ToDate.Text + "'   " +
                            " group by I.PONumber,A.AccountName,M.Dated,M.ExpiryDate, " +
                            " P.WarpYarnCount_0,P.WeftYarnCount_0,P.WeftYarnCount_0,P.EPI,P.PPI,P.Width,y.POQTYMTRS";
               DataSet ds_sub = WS.svc.Get_DataSet(query);
                sReport.BeginInit();
                //if (ds_sub != null)
                //{
                //   MachineEyes.DataTables.StatusReport dt = new DataTables.StatusReport();

                //    DataView dv_Main = ds_sub.Tables[0].DefaultView;

                //    //dv_Main.Sort = "  ArticleName,LoomName";

                //   // dt = (StatusReport)dv_Main.ToTable();

                //    sReport.DataSource = dAB;
                //}

                //else
                //{

                //}
                Reports.FC_PO_Status_Report statusReport = new Reports.FC_PO_Status_Report();
                //statusReport.det
                statusReport.BeginInit();
                for (int i = 0; i < ds_sub.Tables[0].Rows.Count; i++)
                {
                    statusReport.SRNo.Text = ds_sub.Tables[0].Rows[i]["SRNo"].ToString();
                    statusReport.AccountName.Text = ds_sub.Tables[0].Rows[i]["AccountName"].ToString();
                    statusReport.SalesContractNo.Text = ds_sub.Tables[0].Rows[i]["PONumber"].ToString();
                    statusReport.OrderDate.Text = ds_sub.Tables[0].Rows[i]["Dated"].ToString();
                    statusReport.CompleteDate.Text = ds_sub.Tables[0].Rows[i]["ExpiryDate"].ToString();
                    statusReport.warp.Text = ds_sub.Tables[0].Rows[i]["Warp"].ToString();
                    statusReport.weft.Text = ds_sub.Tables[0].Rows[i]["weft"].ToString();
                    statusReport.Read.Text = ds_sub.Tables[0].Rows[i]["Ends"].ToString();
                    statusReport.pick.Text = ds_sub.Tables[0].Rows[i]["Picks"].ToString();
                    statusReport.width.Text = ds_sub.Tables[0].Rows[i]["Width"].ToString();
                    statusReport.totalQuantity.Text = ds_sub.Tables[0].Rows[i]["POQTYMTRS"].ToString();
                    statusReport.IgradeA.Text = ds_sub.Tables[0].Rows[i]["IgradeA"].ToString();
                    statusReport.IgradeB.Text = ds_sub.Tables[0].Rows[i]["IgradeB"].ToString();
                    statusReport.IgradeC40up.Text = ds_sub.Tables[0].Rows[i]["Igrade40up"].ToString();
                    statusReport.IgradeC10up.Text = ds_sub.Tables[0].Rows[i]["Igrade10up"].ToString();
                    statusReport.IgradeC1to9.Text = ds_sub.Tables[0].Rows[i]["Igrade1to9"].ToString();
                    statusReport.Rwork.Text = ds_sub.Tables[0].Rows[i]["IRWork"].ToString();
                    statusReport.WeavingBalance.Text = ds_sub.Tables[0].Rows[i]["WeavingBalance"].ToString();
                    statusReport.DgradeA.Text = ds_sub.Tables[0].Rows[i]["DgradeA"].ToString();
                    statusReport.DgradeB.Text = ds_sub.Tables[0].Rows[i]["DgradeB"].ToString();
                    statusReport.DgradeC40up.Text = ds_sub.Tables[0].Rows[i]["DgradeC40up"].ToString();
                    statusReport.DgradeC10up.Text = ds_sub.Tables[0].Rows[i]["DgradeC10up"].ToString();
                    statusReport.DgradeC1to9.Text = ds_sub.Tables[0].Rows[i]["DgradeC1to9"].ToString();
                    statusReport.BalanceContract.Text = ds_sub.Tables[0].Rows[i]["BalanceContract"].ToString();
                    //statusReport.SRNO.Text = ds_sub.Tables[0].Rows[0]["SRNo"].ToString();
                    //statusReport.PartyName.Text = ds_sub.Tables[0].Rows[0]["AccountName"].ToString();
                    //statusReport.SalesContractNo.Text = ds_sub.Tables[0].Rows[0]["PONumber"].ToString();
                    //statusReport.OrderDate.Text = ds_sub.Tables[0].Rows[0]["Dated"].ToString();
                    //statusReport.CompleteDate.Text = ds_sub.Tables[0].Rows[0]["ExpiryDate"].ToString();
                    //statusReport.warp.Text = ds_sub.Tables[0].Rows[0]["Warp"].ToString();
                    //statusReport.weft.Text = ds_sub.Tables[0].Rows[0]["weft"].ToString();
                    //statusReport.Read.Text = ds_sub.Tables[0].Rows[0]["Ends"].ToString();
                    //statusReport.pick.Text = ds_sub.Tables[0].Rows[0]["Picks"].ToString();
                    //statusReport.width.Text = ds_sub.Tables[0].Rows[0]["Width"].ToString();
                    //statusReport.totalQuantity.Text = ds_sub.Tables[0].Rows[0]["POQTYMTRS"].ToString();
                    //statusReport.IgradeA.Text = ds_sub.Tables[0].Rows[0]["IgradeA"].ToString();
                    //statusReport.IgradeB.Text = ds_sub.Tables[0].Rows[0]["IgradeB"].ToString();
                    //statusReport.IgradeC40up.Text = ds_sub.Tables[0].Rows[0]["Igrade40up"].ToString();
                    //statusReport.IgradeC10up.Text = ds_sub.Tables[0].Rows[0]["Igrade10up"].ToString();
                    //statusReport.IgradeC1to9.Text = ds_sub.Tables[0].Rows[0]["Igrade1to9"].ToString();
                    //statusReport.Rwork.Text = ds_sub.Tables[0].Rows[0]["IRWork"].ToString();
                    //statusReport.WeavingBalance.Text = ds_sub.Tables[0].Rows[0]["WeavingBalance"].ToString();
                    //statusReport.DgradeA.Text = ds_sub.Tables[0].Rows[0]["DgradeA"].ToString();
                    //statusReport.DgradeB.Text = ds_sub.Tables[0].Rows[0]["DgradeB"].ToString();
                    //statusReport.DgradeC40up.Text = ds_sub.Tables[0].Rows[0]["DgradeC40up"].ToString();
                    //statusReport.DgradeC10up.Text = ds_sub.Tables[0].Rows[0]["DgradeC10up"].ToString();
                    //statusReport.DgradeC1to9.Text = ds_sub.Tables[0].Rows[0]["DgradeC1to9"].ToString();
                    //statusReport.BalanceContract.Text = ds_sub.Tables[0].Rows[0]["BalanceContract"].ToString();

                  
                }
                statusReport.DataSource = ds_sub;
                statusReport.DataMember = ds_sub.Tables[0].ToString();
                statusReport.EndInit();
                statusReport.ShowPreview();
            }
        }
    }
}
    

    


    