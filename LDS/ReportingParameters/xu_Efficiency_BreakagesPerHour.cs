using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.LDS.ReportingParameters
{
    public partial class xu_Efficiency_BreakagesPerHour : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_Efficiency_BreakagesPerHour()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
        }

        private void ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (ArticleNumber.EditValue != null)
            {
                article f = Program.ss.Machines.PresentationData.Return_Article(ArticleNumber.EditValue.ToString());
                if (f != null)
                {
                    this.ArticleName.EditValue = f.ArticleName;

                }
                else
                {
                    this.ArticleName.EditValue = null;
                }
            }
            else
                this.ArticleName.EditValue = null;
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
                    this.ArticleName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.ArticleName.EditValue = null;
                this.ArticleNumber.EditValue = null;
            }
        }

        private void ArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleGreigeView.ShowDialog();
                if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.ArticleName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.ArticleName.EditValue = null;
                this.ArticleNumber.EditValue = null;
            }
        }

        private void ShedID_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.ShedID.Text);
            if (shedindex != -1)
            {
                this.ShedID.Tag = this.ShedID.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.ShedID.Tag = null;
                this.ShedName.Text = "";
            }
        }

        private void LoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ShedID.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.ShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.LoomNumber.ForeColor = Color.Black;
                this.LoomNumber.BackColor = Color.White;
                this.LoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
            }
        }

        private void xu_Efficiency_BreakagesPerHour_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            Reports.Efficiency_AvgBreakagesPerHour ABC = new Reports.Efficiency_AvgBreakagesPerHour();

            //AB.ShedIndex = ShedIndex;

            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.UptoDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.BeginInit();
            string dsstring = "select LoomID,LoomName, ArticleNumber,ArticleShortName,T_WarpStops,T_RPM,T_WeftStops,T_Warpperhour,T_Weftperhour,ShiftDate,T_Eff from RP_DailyShiftSummary where ShiftDate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ShiftDate<='" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' ";
            if (this.LoomNumber.EditValue != null && this.LoomNumber.Tag != null)
            {
                dsstring += " and LoomID=" + this.LoomNumber.Tag.ToString() + "";
                ABC.LoomNumberFilter.Text = this.LoomNumber.EditValue.ToString();
            }

           

            DataSet ds = WS.svc.Get_DataSet(dsstring);


            if (ds != null)
            {

                if (this.ArticleName.EditValue != null && this.ArticleNumber.EditValue != null)
                {
                    ds.Tables[0].DefaultView.RowFilter = "ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
                    ABC.ArticleFilter.Text = this.ArticleName.EditValue.ToString();
                }

                ABC.DataSource = ds.Tables[0];
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
    }
}
