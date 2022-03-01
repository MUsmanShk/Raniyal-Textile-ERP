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
    public partial class Data_Assign_ArticleOnLoom : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        public Data_Assign_ArticleOnLoom()
        {
            InitializeComponent();
        }

        private void Data_Assign_ArticleOnLoom_Load(object sender, EventArgs e)
        {
            if (CurrentSelection.LoomIndex == -1) return;
            this.ArticleChangeSheetNumber.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.ACSNumber;
            this.ArticleDesignNumber.Text = "";
            this.ArticleName.Text = Program.ss.Machines.PresentationData.Articles[Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.ArticleNumber].ArticleName;
            this.ArticleNumber.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.ArticleNumber;
           
        }

        private void BrowseArticleNumbers_Click(object sender, EventArgs e)
        {
            
            string query = "select ACSNumber,ArticleNumber,ArticleName from QP_ArticleChangeSheet where ACSNumber in (Select ACSNumber from PP_ArticleChangeSheet_Looms where LoomID="+CurrentSelection.LoomIndex.ToString()+" and Assigned is null)";
           

          
         
        
         
           

            Data.Data_View View = new Data_View();
            View.sRow = SelectedRow;
            View.Load_View(query, "ACSNumber", "AcsNumber");
            View.ShowDialog(this);
            if (SelectedRow.Status != ParameterStatus.Selected)
                return;
            if (this.SelectedRow.SelectedDataRow == null)
                return;
        
            this.ArticleChangeSheetNumber.Text = this.SelectedRow.PrimeryID;
            this.ArticleChangeSheetNumber.Tag = this.SelectedRow.PrimeryID;

            this.AssignTime.Text = "";
            this.ArticleNumber.Text =this.SelectedRow.SelectedDataRow["ArticleNumber"].ToString();
            this.ArticleName.Text  = this.SelectedRow.SelectedDataRow["ArticleName"].ToString();
           
        
        }

        private void BrowseTime_Click(object sender, EventArgs e)
        {
            Data.Data_View View = new Data_View();
            string Table="dbo.LoomLog_" + CurrentSelection.LoomIndex.ToString();
            DateTime timeFrom=DateTime.Now.Subtract(TimeSpan.FromDays(5));
            //string query = "SELECT     Shift, ShiftDated,sDated,eDated, DATEDIFF(mi, sDated, eDated) " +
            //          "AS ElapsedMinutes, Cause, CauseName, SetNo, BeamNo,ArticleNumber, RPM FROM  " + Table + " INNER JOIN " +
            //           "dbo.MT_Cause ON " + Table + ".Cause = dbo.MT_Cause.Cause" +
            //           " where datepart(DAY, ShiftDated)=" + timeFrom.Date.Day + " and datepart(MONTH, ShiftDated)=" + timeFrom.Date.Month + " and datepart(YEAR, ShiftDated)=" + timeFrom.Date.Year + "";
           string query = "SELECT     Shift, ShiftDated,Convert(varchar(50),sDated) as StartTime ,Convert(varchar(50),eDated) as EndTime, DATEDIFF(mi, sDated, eDated) " +
                       "AS ElapsedMinutes, Cause,  SetNo, BeamNo,ArticleNumber, RPM FROM  " + Table + "" +
                        " where datepart(DAY, ShiftDated)=" + timeFrom.Date.Day + " and datepart(MONTH, ShiftDated)=" + timeFrom.Date.Month + " and datepart(YEAR, ShiftDated)=" + timeFrom.Date.Year + " and Cause>5";
            View.sRow = SelectedRow;
            View.Load_View(query, "StartTime", "StartTime");
            View.ShowDialog();
            if (SelectedRow.Status == ParameterStatus.Selected)
            {
                this.AssignTime.Text = SelectedRow.PrimeryID;
            }

        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeArticle_Click(object sender, EventArgs e)
        {
           
            DateTime AssignedTime = DateTime.Now;

            if (ArticleChangeSheetNumber.Text == "")
            {
                XtraMessageBox.Show("Invalid Article Change Sheet Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.ArticleNumber.Text == "")
            {
                XtraMessageBox.Show("Invalid Article Number ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.AssignTime.Text != "")
            {
                AssignedTime = Convert.ToDateTime(this.AssignTime.Text);

            }
            string qres=WS.svc.UpdateLoomArticleChangeOnLoom(CurrentSelection.LoomIndex, this.ArticleNumber.Text, this.ArticleChangeSheetNumber.Text,AssignedTime);
            if (qres == "**SUCCESS##")
            {
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.ACSNumber = this.ArticleChangeSheetNumber.Text;
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.ArticleNumber = this.ArticleNumber.Text;
            }
            else
            {
                XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();

        }

        private void AssignTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                int dDay = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0)).Day;
                int yYear = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0)).Year;
                int mMonth = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0)).Month;
                string LogName = "LoomLog_" + CurrentSelection.LoomIndex.ToString();
                string query = "SELECT dbo." + LogName + ".Shift,CONVERT(nvarchar(30), dbo." + LogName + ".sDated, 0) as [SessionStartTime],CONVERT(nvarchar(30), dbo." + LogName + ".eDated, 0) as [SessionEndTime],datediff(n,dbo." + LogName + ".sDated,dbo." + LogName + ".eDated) as [TimeElapsed],Round(dbo." + LogName + ".RPM,0) as RPM,MT_Cause.CauseName as [Stop Cause], dbo." + LogName + ".SetNo, dbo." + LogName + ".BeamNo FROM " + LogName + " LEFT OUTER JOIN dbo.MT_Cause ON dbo." + LogName + ".Cause = dbo.MT_Cause.Cause where dbo." + LogName + ".Cause>5 and datepart(dd, dbo." + LogName + ".shiftdated)>=" + dDay.ToString() + " and  datepart(mm, dbo." + LogName + ".shiftdated)=" + mMonth.ToString() + " and datepart(yy, dbo." + LogName + ".shiftdated)=" + yYear.ToString() + " ";
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "SessionStartTime", "SessionStartTime");

                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.AssignTime.Text = sRow.PrimeryID;

                }
            }
            else if (e.KeyCode == Keys.Insert && e.Control == true)
            {
                this.AssignTime.Text = DateTime.Now.ToString();
            }
        }
    }
}