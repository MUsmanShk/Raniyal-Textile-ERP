using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
namespace MachineEyes.View
{
    public partial class Dashboard_ArticleEfficiency_ScrollView : DevExpress.XtraEditors.XtraForm
    {
        public bool Enable_Scroll;
        public MachineService.paramsStatus FetchedParamStatus = new MachineService.paramsStatus();
        public DateTime LastStatusFetched = DateTime.Now;
        public Dashboard_ArticleEfficiency_ScrollView()
        {
            InitializeComponent();
            Load_Articles();
        }

        public void Load_Articles()
        {

            DataSet dsArticles = new DataSet();
            this.scrollArticles.Controls.Clear();
            dsArticles = WS.svc.Get_DataSet("Select articlenumber,count(LoomID) as TotalLooms from MT_looms group by ArticleNumber order by ArticleNumber");
            if (dsArticles != null)
            {


                for (int x = 0; x < dsArticles.Tables[0].Rows.Count; x++)
                {
                    try
                    {
                        MachineEyes.UserControls.dxArticleEfficiency ArticlesCtr = new UserControls.dxArticleEfficiency();
                        this.scrollArticles.Controls.Add(ArticlesCtr);
                        ArticlesCtr.Tag = dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString() == "" ? "-1" : dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString();
                        ArticlesCtr.IndexNumber.Text = Convert.ToString(x + 1);
                        ArticlesCtr.ArticleName.Text = Program.ss.Machines.PresentationData.Articles[ArticlesCtr.Tag.ToString()].ArticleName;
                        ArticlesCtr.ArticleNumber.Text = ArticlesCtr.Tag.ToString();
                        ArticlesCtr.NoOfLooms.Text = dsArticles.Tables[0].Rows[x]["TotalLooms"].ToString() == "" ? "0" : dsArticles.Tables[0].Rows[x]["TotalLooms"].ToString();
                        ArticlesCtr.Efficiency.Tag = "0";
                        ArticlesCtr.RPM.Tag = "0";
                        if (x > 0) ArticlesCtr.Top = this.scrollArticles.Controls[x - 1].Top + this.scrollArticles.Controls[x - 1].Height;
                        if (ArticlesCtr.Top >= this.Height) Enable_Scroll = true;
                    }
                    catch 
                    {
                    }
                }
            }
          
        }
        private void ChangeTops()
        {

           
           

         
            for (int x = 0; x < this.scrollArticles.Controls.Count; x++)
            {
                try
                {
                    MachineEyes.UserControls.dxArticleEfficiency ArticlesEff = (MachineEyes.UserControls.dxArticleEfficiency)this.scrollArticles.Controls[x];


                    if (Convert.ToDouble(ArticlesEff.RPM.Tag.ToString()) != Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm)
                    {
                        ArticlesEff.RPM.Tag = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm;
                        ArticlesEff.RPM.Text = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].rpm.ToString("#,##");
                    }

                    if (Convert.ToDouble(ArticlesEff.Efficiency.Tag.ToString()) != Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff)
                    {
                        ArticlesEff.Efficiency.Tag = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff;
                        ArticlesEff.Efficiency.Text = Program.ss.Machines.PresentationData.Articles[ArticlesEff.Tag.ToString()].eff.ToString("#,##0.0") + "%";
                    }
                    if (this.Enable_Scroll == true)
                    {
                        this.scrollArticles.Controls[x].Top = this.scrollArticles.Controls[x].Top - 1;
                        if (this.scrollArticles.Controls[x].Top < (this.scrollArticles.Controls[x].Height - (this.scrollArticles.Controls[x].Height * 2)))
                            this.scrollArticles.Controls[x].Top = this.scrollArticles.Controls[x == 0 ? this.scrollArticles.Controls.Count - 1 : x - 1].Top + this.scrollArticles.Controls[0].Height;
                    }
                }
                catch 
                {
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ChangeTops();

            if (DateTime.Now.Subtract(LastStatusFetched).TotalMinutes > 1)
            {
                LastStatusFetched = DateTime.Now;
                try
                {
                    MachineService.paramsStatus ps = WS.svc.Get_ParamStatus();
                    if (ps.LoomsCurrentAssignedParamNumber != FetchedParamStatus.LoomsCurrentAssignedParamNumber)
                    {
                        Load_Articles();
                        Program.ss.init_AssignLooms_Articles();
                        FetchedParamStatus.LoomsCurrentAssignedParamNumber = ps.LoomsCurrentAssignedParamNumber;
                    }
                }
                catch
                {
                }
            }
        }

        private void Dashboard_ArticleEfficiency_ScrollView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }
    }
}