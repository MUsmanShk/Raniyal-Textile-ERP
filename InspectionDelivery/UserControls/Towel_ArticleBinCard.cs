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
    public partial class Towel_ArticleBinCard : DevExpress.XtraEditors.XtraUserControl
    {
        public Towel_ArticleBinCard()
        {
            InitializeComponent();
        }

        private void Towel_ArticleBinCard_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now;
            this.ToDate.DateTime = DateTime.Now;

        }

        private void ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (ArticleNumber.EditValue != null)
            {
                article f = Program.ss.Machines.PresentationData.Return_Article(ArticleNumber.EditValue.ToString());
                if (f != null)
                {
                    this.Article.EditValue = f.ArticleName;
                    this.WAA.Text = f.WeightGrams;
                }
                else
                {
                    this.Article.EditValue = null;
                }
            }
            else
                this.Article.EditValue = null;
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                 if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                 Program.MainWindow.ArticleView.ShowDialog();
                 if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.EditValue = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                    this.Article.EditValue = Program.MainWindow.ArticleView.SelectedRow.PrimaryString;
                  
                }
                }
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.Article.EditValue == null || this.ArticleNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Article", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Reports.Inspection_Towel_ArticleBinCard TowelArticleBinCard = new Reports.Inspection_Towel_ArticleBinCard();
            TowelArticleBinCard.BeginInit();
            TowelArticleBinCard.From.Text= this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            TowelArticleBinCard.Upto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            TowelArticleBinCard.ArticleNumber.Text = this.ArticleNumber.EditValue.ToString();
            TowelArticleBinCard.ArticleShortName.Text = this.Article.EditValue.ToString();
            string query = "";
            double dWAA = 0;
            double.TryParse(this.WAA.Text, out dWAA);
            query = "Select Sum(Inward_P_A)-Sum(outward_P_A) as Opening_P_A,Sum(Inward_P_B)-Sum(outward_P_B) as Opening_P_B,Sum(Inward_P_T)-Sum(outward_P_T) as Opening_P_T,sum(Inward_Kg)-Sum(OutWard_Kg) as Opening_Kg,Sum(Inward_Lbs)-Sum(OutWard_Lbs) as Opening_Lbs from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID<>1";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {

                TowelArticleBinCard.Opening_P_A.Text = ds.Tables[0].Rows[0]["Opening_P_A"].ToString();
                TowelArticleBinCard.Opening_P_B.Text = ds.Tables[0].Rows[0]["Opening_P_B"].ToString();
                TowelArticleBinCard.Opening_P_T.Text= ds.Tables[0].Rows[0]["Opening_P_T"].ToString();
                TowelArticleBinCard.Opening_Kg.Text = ds.Tables[0].Rows[0]["Opening_Kg"].ToString();
                TowelArticleBinCard.Opening_Lbs.Text = ds.Tables[0].Rows[0]["Opening_Lbs"].ToString();
                TowelArticleBinCard.Opening_WAA.Text = this.WAA.Text;
                double dOpeningKg = 0; double dOpeningPT = 0;double dOpeningWPP=0;
                double dOpeningES = 0;
                double.TryParse(ds.Tables[0].Rows[0]["Opening_Kg"].ToString(), out dOpeningKg);
                double.TryParse(ds.Tables[0].Rows[0]["Opening_P_T"].ToString(), out dOpeningPT);
                if (dOpeningPT > 0)
                {
                    dOpeningWPP = dOpeningKg / dOpeningPT * 1000;
                    TowelArticleBinCard.Opening_WPP.Text = dOpeningWPP.ToString("#,##0.00");
                    if (dWAA > 0)
                    {
                        dOpeningES = dOpeningWPP - dWAA;
                        TowelArticleBinCard.Opening_ES.Text = dOpeningES.ToString("#,##0.00");
                    }

                }
            }

            query = "Select Sum(Inward_P_A)-Sum(outward_P_A) as Closing_P_A,Sum(Inward_P_B)-Sum(outward_P_B) as Closing_P_B,Sum(Inward_P_T)-Sum(outward_P_T) as Closing_P_T,sum(Inward_Kg)-Sum(OutWard_Kg) as Closing_Kg,Sum(Inward_Lbs)-Sum(OutWard_Lbs) as Closing_Lbs from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID<>1";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                TowelArticleBinCard.Closing_P_A.Text = ds.Tables[0].Rows[0]["Closing_P_A"].ToString();
                TowelArticleBinCard.Closing_P_B.Text = ds.Tables[0].Rows[0]["Closing_P_B"].ToString();
                TowelArticleBinCard.Closing_P_T.Text = ds.Tables[0].Rows[0]["Closing_P_T"].ToString();
                TowelArticleBinCard.Closing_Kg.Text = ds.Tables[0].Rows[0]["Closing_Kg"].ToString();
                TowelArticleBinCard.Closing_Lbs.Text = ds.Tables[0].Rows[0]["Closing_Lbs"].ToString();
                double dClosingKg = 0; double dClosingPT = 0; double dClosingWPP = 0; double dClosingES;
                double.TryParse(ds.Tables[0].Rows[0]["Closing_Kg"].ToString(), out dClosingKg);
                double.TryParse(ds.Tables[0].Rows[0]["Closing_P_T"].ToString(), out dClosingPT);
                if (dClosingPT > 0)
                {
                    dClosingWPP = dClosingKg / dClosingPT * 1000;
                    TowelArticleBinCard.Closing_WPP.Text = dClosingWPP.ToString("#,##0.00");
                    if (dWAA > 0)
                    {
                        dClosingES = dClosingWPP -dWAA ;
                        TowelArticleBinCard.Closing_ES.Text = dClosingES.ToString("#,##0.00");
                    }

                }

            }

            query = "Select * from RIP_Godown_Towel_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and GodownEntryTypeID<>1";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                TowelArticleBinCard.DataSource = ds.Tables[0];
            else
                TowelArticleBinCard.DataSource = null;
            TowelArticleBinCard.EndInit();
            TowelArticleBinCard.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }
      
}
        
    
}
