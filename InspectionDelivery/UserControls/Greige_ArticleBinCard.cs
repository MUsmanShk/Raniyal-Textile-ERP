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
    public partial class Greige_ArticleBinCard : DevExpress.XtraEditors.XtraUserControl
    {
        public Greige_ArticleBinCard()
        {
            InitializeComponent();
        }

        private void Greige_ArticleBinCard_Load(object sender, EventArgs e)
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

                 Program.MainWindow.ArticleGreigeView.ShowDialog();
                 if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.Article.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;
                  
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
            Reports.Inspection_Greige_ArticleBinCard GreigeArticleBinCard = new Reports.Inspection_Greige_ArticleBinCard();
            GreigeArticleBinCard.BeginInit();
            GreigeArticleBinCard.From.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            GreigeArticleBinCard.Upto.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            GreigeArticleBinCard.ArticleNumber.Text = this.ArticleNumber.EditValue.ToString();
            GreigeArticleBinCard.ArticleShortName.Text = this.Article.EditValue.ToString();
            string query = "";

            query = "Select Sum(IN_A)-Sum(OUT_A) as Opening_A,Sum(IN_B)-Sum(OUT_B) as Opening_B,Sum(IN_C)-Sum(OUT_C) as Opening_C,Sum(IN_SP)-Sum(OUT_SP) as Opening_SP,Sum(IN_CP)-Sum(OUT_CP) as Opening_CP from RIP_Godown_Greige_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {

                GreigeArticleBinCard.OPENING_A.Text = ds.Tables[0].Rows[0]["Opening_A"].ToString();
                GreigeArticleBinCard.OPENING_B.Text = ds.Tables[0].Rows[0]["Opening_B"].ToString();
                GreigeArticleBinCard.OPENING_C.Text = ds.Tables[0].Rows[0]["Opening_C"].ToString();
                GreigeArticleBinCard.OPENING_SP.Text = ds.Tables[0].Rows[0]["Opening_SP"].ToString();
                GreigeArticleBinCard.OPENING_CP.Text = ds.Tables[0].Rows[0]["Opening_CP"].ToString();
  
              
                
            }

            query = "Select Sum(IN_A)-Sum(OUT_A) as Closing_A,Sum(IN_B)-Sum(OUT_B) as Closing_B,Sum(IN_C)-Sum(OUT_C) as Closing_C,Sum(IN_SP)-Sum(OUT_SP) as Closing_SP,Sum(IN_CP)-Sum(OUT_CP) as Closing_CP   from RIP_Godown_Greige_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                GreigeArticleBinCard.CLOSING_A.Text = ds.Tables[0].Rows[0]["Closing_A"].ToString();
                GreigeArticleBinCard.CLOSING_B.Text = ds.Tables[0].Rows[0]["Closing_B"].ToString();
                GreigeArticleBinCard.CLOSING_C.Text = ds.Tables[0].Rows[0]["Closing_C"].ToString();
                GreigeArticleBinCard.CLOSING_SP.Text = ds.Tables[0].Rows[0]["Closing_SP"].ToString();
                GreigeArticleBinCard.CLOSING_CP.Text = ds.Tables[0].Rows[0]["Closing_CP"].ToString();
                

            }

            query = "Select * from RIP_Godown_Greige_Details where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and Dated>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                GreigeArticleBinCard.DataSource = ds.Tables[0];
            else
                GreigeArticleBinCard.DataSource = null;
            GreigeArticleBinCard.EndInit();
            GreigeArticleBinCard.ShowPreview();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }
      
}
        
    
}
