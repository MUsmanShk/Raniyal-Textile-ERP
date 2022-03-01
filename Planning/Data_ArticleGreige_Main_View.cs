using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Planning
{
    public partial class Data_ArticleGreige_Main_View : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        public Data_ArticleGreige_Main_View()
        {
            InitializeComponent();
        }

        private void Data_Article_Main_View_Load(object sender, EventArgs e)
        {

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            Load_Articles(string.Empty);
        }
        public  void Load_Articles(string query)
        {
            if (query == "")
                query = "select ArticleNumber,ArticleShortName,EPI,PPI,Width,ArticleWeave,InsertionType,ArticleSelvage from PP_Article";
            DataSet ds = new DataSet();
            this.gridView1.Columns.Clear();
            this.gridControl1.DataSource = null;

            ds = WS.svc.Get_DataSet(query);
           
       
            if (ds != null)
            {
                this.gridControl1.DataSource = ds.Tables[0];
                this.gridView1.Columns["ArticleNumber"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["ArticleShortName"].Width = this.gridControl1.Width * 60 / 100;
                this.gridView1.Columns["EPI"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["PPI"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["Width"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["ArticleWeave"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["InsertionType"].Width = this.gridControl1.Width * 5 / 100;
                this.gridView1.Columns["ArticleSelvage"].Width = this.gridControl1.Width * 5 / 100;
                try
                {
                    //this.gridView1.Columns["SellingUnit"].Visible = false;
                    //this.gridView1.Columns["SellingRate"].Visible = false;
                }
                catch
                {
                }
            }
            //for (int x = 5; x < this.gridView1.Columns.Count; x++)
            //    this.gridView1.Columns[x].Visible = false;
        }

        private void Data_Article_Main_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false)
            {
                e.Cancel = true; this.Hide();
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
       
        private void btn_Close_Click(object sender, EventArgs e)
        {
            
            SelectedRow.Status = ParameterStatus.Cancelled;
            SelectedRow.PrimaryString = "";
            SelectedRow.PrimeryID = "";
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void Data_Article_Main_View_KeyDown(object sender, KeyEventArgs e)
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
                MachineEyes.Program.ss.Machines.PresentationData.init_Articles();
                this.Load_Articles("");
                this.gridControl1.Refresh();
                this.gridView1.RefreshData();
                
                this.gridControl1.Visible = true;
               
            }
        }

        private void Data_Article_Main_View_Activated(object sender, EventArgs e)
        {
            this.gridControl1.Refresh();
            this.gridView1.RefreshData();
            this.gridControl1.Visible = true;
        }

      
    }
}