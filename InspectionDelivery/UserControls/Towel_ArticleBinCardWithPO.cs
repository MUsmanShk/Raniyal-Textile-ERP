using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.InspectionDelivery.UserControls
{
    public partial class Towel_ArticleBinCardWithPO : DevExpress.XtraEditors.XtraUserControl
    {
        public Towel_ArticleBinCardWithPO()
        {
            InitializeComponent();
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ArticleTowelView == null) Program.MainWindow.ArticleTowelView = new Planning.Data_ArticleTowel_Main_View();
                Program.MainWindow.ArticleTowelView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleTowelView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.ArticleNumber.EditValue = Program.MainWindow.ArticleTowelView.SelectedRow.PrimeryID;
                        this.ArticleShortName.EditValue = Program.MainWindow.ArticleTowelView.SelectedRow.PrimaryString;
                        this.WAA.EditValue = Program.MainWindow.ArticleTowelView.SelectedRow.SelectedDataRow["WAA"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (this.ArticleNumber.EditValue != null)
                {
                    string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS from RFC_PO where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and POStatusID=0";
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    FrmView.Load_View(query, "PONO", "BuyerID");
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.PONO.EditValue = sRow.PrimeryID;
                        this.PartyID.EditValue = sRow.PrimaryString;

                        try
                        {
                            this.PartyName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();

                        }
                        catch
                        {
                        }

                    }
                }
                else
                {
                    string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS from RFC_PO where POStatusID=0";
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    FrmView.Load_View(query, "PONO", "BuyerID");
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.PONO.EditValue = sRow.PrimeryID;
                        this.PartyID.EditValue = sRow.PrimaryString;

                        try
                        {
                            this.PartyName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                            this.ArticleNumber.EditValue = sRow.SelectedDataRow["ArticleNumber"].ToString();
                            this.ArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();

                        }
                        catch
                        {
                        }

                    }
                }
            }
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.ArticleNumber.EditValue == null || this.ArticleShortName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Article", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.PartyID.EditValue == null || this.PartyName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.PONO.EditValue == null )
            {
                XtraMessageBox.Show("Invalid PO", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reports.Inspection_Towel_ArticleBinCardWithPO TowelArticleBinCard = new Reports.Inspection_Towel_ArticleBinCardWithPO();
            TowelArticleBinCard.BeginInit();
            TowelArticleBinCard.From.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            TowelArticleBinCard.Upto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TowelArticleBinCard.ArticleNumber.Text = this.ArticleNumber.EditValue.ToString();
            TowelArticleBinCard.ArticleShortName.Text = this.ArticleShortName.EditValue.ToString();
            TowelArticleBinCard.PONO.Text = this.PONO.EditValue.ToString();
            TowelArticleBinCard.BuyerName.Text = this.PartyName.EditValue.ToString();
            string query = "";
            double dWAA = 0;
            double.TryParse(this.WAA.Text, out dWAA);
            query = "Select Sum(Inward_P_A)-Sum(outward_P_A) as Opening_P_A,Sum(Inward_P_B)-Sum(outward_P_B) as Opening_P_B,Sum(Inward_P_T)-Sum(outward_P_T) as Opening_P_T,sum(Inward_Kg)-Sum(OutWard_Kg) as Opening_Kg,Sum(Inward_Lbs)-Sum(OutWard_Lbs) as Opening_Lbs from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and PONO='"+this.PONO.EditValue.ToString()+"' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID<>1";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {

                TowelArticleBinCard.Opening_P_A.Text = ds.Tables[0].Rows[0]["Opening_P_A"].ToString();
                TowelArticleBinCard.Opening_P_B.Text = ds.Tables[0].Rows[0]["Opening_P_B"].ToString();
                TowelArticleBinCard.Opening_P_T.Text = ds.Tables[0].Rows[0]["Opening_P_T"].ToString();
                TowelArticleBinCard.Opening_Kg.Text = ds.Tables[0].Rows[0]["Opening_Kg"].ToString();
                TowelArticleBinCard.Opening_Lbs.Text = ds.Tables[0].Rows[0]["Opening_Lbs"].ToString();
                TowelArticleBinCard.Opening_WAA.Text = this.WAA.Text;
                double dOpeningKg = 0; double dOpeningPT = 0; double dOpeningWPP = 0;
               
                double.TryParse(ds.Tables[0].Rows[0]["Opening_Kg"].ToString(), out dOpeningKg);
                double.TryParse(ds.Tables[0].Rows[0]["Opening_P_T"].ToString(), out dOpeningPT);
                if (dOpeningPT > 0)
                {
                    dOpeningWPP = dOpeningKg / dOpeningPT * 1000;
                    TowelArticleBinCard.Opening_WPP.Text = dOpeningWPP.ToString("#,##0.00");
                   

                }
            }

            //query = "Select Sum(Inward_P_A)-Sum(outward_P_A) as Closing_P_A,Sum(Inward_P_B)-Sum(outward_P_B) as Closing_P_B,Sum(Inward_P_T)-Sum(outward_P_T) as Closing_P_T,sum(Inward_Kg)-Sum(OutWard_Kg) as Closing_Kg,Sum(Inward_Lbs)-Sum(OutWard_Lbs) as Closing_Lbs from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID<>1";
            //ds = WS.svc.Get_DataSet(query);
            //if (ds != null)
            //{
            //    TowelArticleBinCard.Closing_P_A.Text = ds.Tables[0].Rows[0]["Closing_P_A"].ToString();
            //    TowelArticleBinCard.Closing_P_B.Text = ds.Tables[0].Rows[0]["Closing_P_B"].ToString();
            //    TowelArticleBinCard.Closing_P_T.Text = ds.Tables[0].Rows[0]["Closing_P_T"].ToString();
            //    TowelArticleBinCard.Closing_Kg.Text = ds.Tables[0].Rows[0]["Closing_Kg"].ToString();
            //    TowelArticleBinCard.Closing_Lbs.Text = ds.Tables[0].Rows[0]["Closing_Lbs"].ToString();
            //    double dClosingKg = 0; double dClosingPT = 0; double dClosingWPP = 0; double dClosingES;
            //    double.TryParse(ds.Tables[0].Rows[0]["Closing_Kg"].ToString(), out dClosingKg);
            //    double.TryParse(ds.Tables[0].Rows[0]["Closing_P_T"].ToString(), out dClosingPT);
            //    if (dClosingPT > 0)
            //    {
            //        dClosingWPP = dClosingKg / dClosingPT * 1000;
            //        TowelArticleBinCard.Closing_WPP.Text = dClosingWPP.ToString("#,##0.00");
            //        if (dWAA > 0)
            //        {
            //            dClosingES = dClosingWPP - dWAA;
            //            TowelArticleBinCard.Closing_ES.Text = dClosingES.ToString("#,##0.00");
            //        }

            //    }

            //}

            query = "Select * from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and PONO='"+this.PONO.EditValue.ToString()+"' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                TowelArticleBinCard.DataSource = ds.Tables[0];
            else
                TowelArticleBinCard.DataSource = null;
            TowelArticleBinCard.EndInit();
            TowelArticleBinCard.ShowPreview();
        }
    }
}
