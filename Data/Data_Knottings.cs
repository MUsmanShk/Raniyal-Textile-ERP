using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Data_Knottings : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        enum NewInput { Nothing = 0, ArticleChanged = 1, BeamChanged = 2 }
      
        public Data_Knottings()
        {
            InitializeComponent();
           
           
        }

      
       
        private string CheckValidation_Delete()
        {

            return "**SUCCESS##";
        }
       
       
        
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }

        private void Data_Knotting_chartControl1_Click(object sender, EventArgs e)
        {

        }


        private void BeamDisplay_1()
        {
            string dsstring = "select  LoomID, LoomName, Current_RPM, ShedID,ExpectedCrimp,Current_PPI, SetNo, BeamNumber,BeamLength, ArticleNumber, ArticleShortName ,0.0 as ProductionMeters,0.0 as RemainingLength,'01/01/2014 8:00:00 AM' as CommingKnotting,'25 days 5 hours' as DaysRemaining from MTQ_Looms where  LoomID=" + CurrentSelection.LoomIndex.ToString() + " order by Convert(numeric(9),LoomName)";
           
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                     string LoomLogTable = "LoomLog_" + ds.Tables[0].Rows[0]["LoomID"].ToString();
                        if (ds.Tables[0].Rows[0]["SetNo"].ToString() != "" && ds.Tables[0].Rows[0]["BeamNumber"].ToString() != "")
                        {
                            string lengthquery = "Select ArticleNumber,Sum(Picks) as TotalPicks from " + LoomLogTable + " where SetNo='" + ds.Tables[0].Rows[0]["SetNo"].ToString() + "' and BeamNo='" + ds.Tables[0].Rows[0]["BeamNumber"].ToString() + "' group by ArticleNumber";
                            DataSet dsl = WS.svc.Get_DataSet(lengthquery);
                            if (dsl != null)
                            {
                                if (dsl.Tables[0].Rows.Count > 0)
                                {
                                    double TotalMetersProduced = 0; double tCrimpMeters = 0; double BeamLength = 0; double RemainingLength = 0; double EC = 0; double EC_Meters = 0; double Current_RPM = 250; double Current_PPI = 30;
                                    for (int l = 0; l < dsl.Tables[0].Rows.Count; l++)
                                    {
                                        double tpicks; double tMeters = 0; 
                                        double.TryParse(dsl.Tables[0].Rows[l]["TotalPicks"].ToString(), out tpicks);
                                        article nArticle = Program.ss.Machines.PresentationData.Return_Article(dsl.Tables[0].Rows[l]["ArticleNumber"].ToString());
                                        if (nArticle != null)
                                        {
                                            tMeters = tpicks * 0.0254 / nArticle.PPI;
                                        }
                                        else
                                            tMeters = tpicks * 0.0254 / 30;
                                        if (nArticle != null)
                                        {
                                            if (nArticle.ExpectedCrimp != 0)
                                                tCrimpMeters += (tMeters * nArticle.ExpectedCrimp / 100);
                                            else
                                                tCrimpMeters += (tMeters * 8 / 100);
                                        }
                                        else
                                        {
                                            tCrimpMeters += (tMeters * 8 / 100);
                                        }
                                        
                                        
                                        TotalMetersProduced += tMeters;
                                    }
                                    DataRow d = ds.Tables[0].Rows[0];
                                    try
                                    {
                                        double.TryParse(d["BeamLength"].ToString(), out BeamLength);
                                        this.Current_Length1.Text = d["BeamLength"].ToString();
                                        this.Current_Length2.Text = d["BeamLength"].ToString();
                                        this.Current_Beam1.Text = d["BeamNumber"].ToString();
                                        this.Current_Set1.Text = d["SetNo"].ToString();
                                        this.Current_Weaved1.Text = TotalMetersProduced.ToString("#,##");
                                        this.Current_WeavedPercent1.Text = (TotalMetersProduced / BeamLength * 100).ToString("#,##0.00");
                                        this.Current_Weaved2.Text = TotalMetersProduced.ToString("#,##");
                                        this.Current_WeavedPercent2.Text = (TotalMetersProduced / BeamLength * 100).ToString("#,##0.00");
                                        RemainingLength = BeamLength - TotalMetersProduced-tCrimpMeters;
                                        this.Current_Remaining1.Text = RemainingLength.ToString("#,##");
                                        this.Current_RemainingPercent1.Text = (RemainingLength / BeamLength * 100).ToString("#,##0.00");
                                        this.Current_Remaining2.Text = RemainingLength.ToString("#,##");
                                        this.Current_RemainingPercent2.Text = (RemainingLength / BeamLength * 100).ToString("#,##0.00");
                                        this.chartControl1.Series["Series0"].Points[0].Values[0] = Math.Round(RemainingLength / BeamLength * 100, 2);

                                        this.chartControl1.Series["Series0"].Points[1].Values[0] = Math.Round(100 - (RemainingLength / BeamLength * 100), 2); 
                                        //this.chartControl1.Series["Series0"].Points[2].Values[0] = (RemainingLength / BeamLength * 100);
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        
                                        EC_Meters = BeamLength * EC / 100;
                                       
                                        double RemainingMinutes = ((RemainingLength - EC_Meters) * Current_PPI / 0.0254) / Current_RPM;

                                        TimeSpan ts = new TimeSpan(0, Convert.ToInt32(RemainingMinutes), 0);
                                        DateTime E_K = DateTime.Now.Add(ts);

                                      
                                        this.Current_Time1.Text = ts.Days.ToString() + "  Day(s) " + ts.Hours.ToString() + "  hour(s)";
                                        this.Current_Time2.Text = ts.Days.ToString() + "  Day(s) " + ts.Hours.ToString() + "  hour(s)";
                                    }
                                    catch
                                    {
                                    }

                                }
                            }
                        }

                    
                }
            }
           


         
        }

        
        private void Data_Knottings_Load(object sender, EventArgs e)
        {
            this.LoomNumber.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName;
            this.LoomNumber.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomID;
           
            if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.LoadBeamPile == false)
            {
                this.xtraTabPage_CurrentBeamPile.PageVisible = false;
                this.xtraTabPage_NewBeamPile.PageVisible = false;
            }
            this.Current_Beam1.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.BeamNo;
            this.Current_Set1.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.SetNo;
            this.Current_Beam2.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.BeamNo2;
            this.Current_Set2.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams.SetNo2;
            BeamDisplay_1();
        }

        private void KnottingBeam1_Click(object sender, EventArgs e)
        {
            selectedrow sRow = new selectedrow();
            string strFilterQuery = " select SetNo,Ends,BeamNumber,BeamLength,Remarks from SWQ_Sizing_Details where BeamStatus=1 or beamstatus is null  or beamStatus=3";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "SetNo", "BeamNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.KnottingBeam1.Text = sRow.PrimaryString;
                this.KnottingSet1.Text = sRow.PrimeryID;
                try
                {
                    this.KnottingLength1.Text = sRow.SelectedDataRow["BeamLength"].ToString();
                }
                catch
                {
                }
                try
                {
                    this.SetEnds.Text = sRow.SelectedDataRow["Ends"].ToString();
                }
                catch
                {
                }

            }
        }

        private void KnottingDateTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                int  dDay = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0)).Day;
                int yYear = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0, 0)).Year;
                int mMonth = DateTime.Now.Subtract(new TimeSpan(5,0,0,0,0)).Month;
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
                    this.KnottingDateTime1.Text = sRow.PrimeryID;
                   
                }
            }
            else if (e.KeyCode == Keys.Insert && e.Control == true)
            {
                this.KnottingDateTime1.Text = DateTime.Now.ToString();
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupControl7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KnottingExecute1_Click(object sender, EventArgs e)
        {
            
            if (this.KnottingDateTime1.Text == "")
            {
                XtraMessageBox.Show("invalid time", "Error", MessageBoxButtons.OK);
                this.KnottingDateTime1.Focus();
                return;
            }
            if (this.KnottingBeam1.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }
            if (this.KnottingBeam1.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }

            if (this.KnottingSet1.Text == "")
            {
                XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }

           

            DialogResult dg = XtraMessageBox.Show("Are you sure to install new knotting on this loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;
          
            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo;
            string OldBeamNo = assigned.BeamNo;
            string OldSetEnds = assigned.SetEnds;
            if (OldSetNo != "" || OldBeamNo != "")
            {
                XtraMessageBox.Show("Beam is already running on this loom , it should be taken off or finished....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
               string LoomLog="LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo = this.KnottingSet1.Text;
                assigned.BeamNo = this.KnottingBeam1.Text;
                assigned.SetEnds = this.SetEnds.Text;
                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 2);
                    DateTime KnottingDateTime = Convert.ToDateTime(this.KnottingDateTime1.Text);
                    query[0] = "Update " + LoomLog + " set BeamNo='" + assigned.BeamNo + "' , SetNo='" + assigned.SetNo + "' where sDated>='" + KnottingDateTime.ToString("s") + "'";
                    query[1] = "Update SW_Sizing_Details  set BeamStatus=2,LoomID="+CurrentSelection.LoomIndex.ToString()+" where BeamNumber='" + assigned.BeamNo + "' and SetNo='" + assigned.SetNo + "'";

                    
                    string res2 = WS.svc.Execute_Transaction(query);
                    if(res2=="**SUCCESS##")
                    this.Close();
                    else
                    XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo = OldSetNo;
                    assigned.BeamNo = OldBeamNo;
                    assigned.SetEnds = OldSetEnds;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo = OldSetNo;
                assigned.BeamNo = OldBeamNo;
                assigned.SetEnds = OldSetEnds;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

       

        private void KnottingBeam2_Click(object sender, EventArgs e)
        {
            selectedrow sRow = new selectedrow();
            string strFilterQuery = " select SetNo,Ends,BeamNumber,BeamLength,Remarks from SWQ_Sizing_Details where BeamStatus=1 or beamstatus is null or beamstatus=3 ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "SetNo", "BeamNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.KnottingBeam2.Text = sRow.PrimaryString;
                this.KnottingSet2.Text = sRow.PrimeryID;
                try
                {
                    this.KnottingBeamLength2.Text = sRow.SelectedDataRow["BeamLength"].ToString();
                }
                catch
                {
                }
                try
                {
                    this.Set2Ends.Text = sRow.SelectedDataRow["Ends"].ToString();
                }
                catch
                {
                }

            }
        }

        private void KnottingDateTime2_KeyDown(object sender, KeyEventArgs e)
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
                    this.KnottingDateTime2.Text = sRow.PrimeryID;

                }
            }
            else if (e.KeyCode == Keys.Insert && e.Control == true)
            {
                this.KnottingDateTime2.Text = DateTime.Now.ToString();
            }
        }

        private void UnInstallBeam_Click(object sender, EventArgs e)
        {
            if (this.KnottingDateTime1.Text == "")
            {
                XtraMessageBox.Show("invalid time", "Error", MessageBoxButtons.OK);
                this.KnottingDateTime1.Focus();
                return;
            }
            if (this.KnottingBeam1.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }
            if (this.KnottingBeam1.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }

            if (this.KnottingSet1.Text == "")
            {
                XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to un-install this beam from the loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo;
            string OldBeamNo = assigned.BeamNo;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo = "";
                assigned.BeamNo = "";
                assigned.SetEnds = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 2);
                    query[0] = "Update " + LoomLog + " BeamNo=null , SetNo=null where sDateTime>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[1] = "Update SW_Sizing_Details set BeamStatus=1 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo = OldSetNo;
                    assigned.BeamNo = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo = OldSetNo;
                assigned.BeamNo = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void KnottingExecute2_Click(object sender, EventArgs e)
        {
            if (this.KnottingDateTime2.Text == "")
            {
                XtraMessageBox.Show("invalid time", "Error", MessageBoxButtons.OK);
                this.KnottingDateTime1.Focus();
                return;
            }
            if (this.KnottingBeam2.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam2.Focus();
                return;
            }
            if (this.KnottingBeam2.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam2.Focus();
                return;
            }

            if (this.KnottingSet2.Text == "")
            {
                XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                this.KnottingBeam1.Focus();
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to install new knotting on this loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo2;
            string OldBeamNo = assigned.BeamNo2;
            string OldSetEnds = assigned.Set2Ends;
            if (OldSetNo != "" || OldBeamNo != "")
            {
                XtraMessageBox.Show("Beam is already running on this loom , it should be taken off or finished....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo2 = this.KnottingSet2.Text;
                assigned.BeamNo2 = this.KnottingBeam2.Text;
                assigned.Set2Ends = this.Set2Ends.Text;
                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    string gquery = "Select shiftdated,shift,ArticleNumber,ACSNumber,Sum(Picks) as TotalPicks,sum(datediff(s,sDated,eDated)) as TotalSeconds,avg(case when State=1 and RPM>0 then RPM else null end) as AvgRPM,sum(case when State=0 and Cause=1 then 1 else 0 end) TotalWarpStops,avg(case when State=0 and Cause=1 then datediff(s,sDated,eDated) else null end) as WarpAvgTime,sum(case when State=0 and Cause=1 then datediff(s,sDated,eDated) else 0 end) as WarpETime,sum(case when State<>1  then datediff(s,sDated,eDated) else 0 end) as TotalETime from " + LoomLog + " where sDated>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "' and indexno not in(select indexno from " + LoomLog + " where datepart(dd,shiftdated)=" + Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.Day.ToString() + " and datepart(mm,shiftdated)=" + Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.Month.ToString() + " and datepart(dd,shiftdated)=" + Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.Year.ToString() + " and Shift='" + Program.ss.Machines.PresentationData.CurrentShift.WShift + "') GROUP BY ShiftDated, Shift, ArticleNumber, ACSNumber";

                   
                   

                   

                    Array.Resize(ref query, 2);
                    int qnum = 0;
                    DateTime KnottingDateTime = Convert.ToDateTime(this.KnottingDateTime2.Text);
                    query[qnum] = "Update " + LoomLog + " set BeamNo2='" + assigned.BeamNo2 + "' , SetNO2='" + assigned.SetNo2 + "' where sDated>='" + KnottingDateTime.ToString("s") + "'";

                    query[++qnum] = "Update SW_Sizing_Details set BeamStatus=2,LoomID=" + CurrentSelection.LoomIndex.ToString() + " where SetNO='" + assigned.SetNo2 + "' and beamnumber='" + assigned.BeamNo2 + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo2 = OldSetNo;
                    assigned.BeamNo2 = OldBeamNo;
                    assigned.Set2Ends = OldSetEnds;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo2 = OldSetNo;
                assigned.BeamNo2 = OldBeamNo;
                assigned.Set2Ends = OldSetEnds;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FinishBeam_1_Click(object sender, EventArgs e)
        {
            if (CurrentBeam_1.Text == "")
            {
                XtraMessageBox.Show("Invalid Beam!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to finish this beam from the loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo;
            string OldBeamNo = assigned.BeamNo;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo = "";
                assigned.BeamNo = "";
                assigned.SetEnds = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 1);
                   // query[0] = "Update " + LoomLog + " BeamNo=null , SetNo=null where sDateTime>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[0] = "Update SW_Sizing_Details set BeamStatus=0 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo = OldSetNo;
                    assigned.BeamNo = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo = OldSetNo;
                assigned.BeamNo = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TakeOffBeam_1_Click(object sender, EventArgs e)
        {
            if (CurrentBeam_1.Text == "")
            {
                XtraMessageBox.Show("Invalid Beam!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to take off beam for re-knotting at other time to other loom...?", "Take Off beam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo;
            string OldBeamNo = assigned.BeamNo;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo = "";
                assigned.BeamNo = "";
                assigned.SetEnds = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 1);
                    // query[0] = "Update " + LoomLog + " BeamNo=null , SetNo=null where sDateTime>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[0] = "Update SW_Sizing_Details set BeamStatus=3 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo = OldSetNo;
                    assigned.BeamNo = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo = OldSetNo;
                assigned.BeamNo = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UnInstallBeam_2_Click(object sender, EventArgs e)
        {
            if (this.KnottingDateTime2.Text == "")
            {
                XtraMessageBox.Show("invalid time", "Error", MessageBoxButtons.OK);
                this.KnottingDateTime1.Focus();
                return;
            }
            if (this.KnottingBeam2.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam2.Focus();
                return;
            }
            if (this.KnottingBeam2.Text == "")
            {
                XtraMessageBox.Show("invalid beam", "Error", MessageBoxButtons.OK);
                this.KnottingBeam2.Focus();
                return;
            }

            if (this.KnottingSet2.Text == "")
            {
                XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                this.KnottingBeam2.Focus();
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to un-install this beam from the loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo2;
            string OldBeamNo = assigned.BeamNo2;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo2 = "";
                assigned.BeamNo2 = "";
                assigned.Set2Ends = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 2);
                    query[0] = "Update " + LoomLog + " BeamNo2=null , SetNo2=null where sDateTime>='" + this.KnottingDateTime2.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[1] = "Update SW_Sizing_Details set BeamStatus=1 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo2 = OldSetNo;
                    assigned.BeamNo2 = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo2 = OldSetNo;
                assigned.BeamNo2 = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FinishBeam_2_Click(object sender, EventArgs e)
        {
            if (Current_Beam2.Text == "")
            {
                XtraMessageBox.Show("Invalid Beam!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to finish this beam from the loom...?", "Knotting", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo2;
            string OldBeamNo = assigned.BeamNo2;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo2 = "";
                assigned.BeamNo2 = "";
                assigned.Set2Ends = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 2);
                    // query[0] = "Update " + LoomLog + " BeamNo=null , SetNo=null where sDateTime>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[0] = "Update SW_Sizing_Details set BeamStatus=0 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo2 = OldSetNo;
                    assigned.BeamNo2 = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo2 = OldSetNo;
                assigned.BeamNo2 = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void TakeOffBeam_2_Click(object sender, EventArgs e)
        {
            if (Current_Beam2.Text == "")
            {
                XtraMessageBox.Show("Invalid Beam!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to take off beam for re-knotting at other time to other loom...?", "Take Off beam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            MachineService.loomcurrentassignedparams assigned = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentAssignedParams;
            string OldSetNo = assigned.SetNo2;
            string OldBeamNo = assigned.BeamNo2;

            try
            {
                string LoomLog = "LoomLog_" + CurrentSelection.LoomIndex.ToString();

                assigned.SetNo2 = "";
                assigned.BeamNo2 = "";
                assigned.Set2Ends = "";

                string res = WS.svc.UpdateLoomCurrentAssignedParams(CurrentSelection.LoomIndex, assigned);

                if (res == "**SUCCESS##")
                {
                    string[] query = new string[0];
                    Array.Resize(ref query, 2);
                    // query[0] = "Update " + LoomLog + " BeamNo=null , SetNo=null where sDateTime>='" + this.KnottingDateTime1.Text.ToString(MachineEyes.Classes.Accounting.culture) + "'";
                    query[0] = "Update SW_Sizing_Details set BeamStatus=3 where SetNo='" + OldSetNo + "' and beamnumber='" + OldBeamNo + "'";
                    string res2 = WS.svc.Execute_Transaction(query);
                    if (res2 == "**SUCCESS##")
                        this.Close();
                    else
                        XtraMessageBox.Show(res2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    assigned.SetNo2 = OldSetNo;
                    assigned.BeamNo2 = OldBeamNo;
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                assigned.SetNo2 = OldSetNo;
                assigned.BeamNo2 = OldBeamNo;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

     

        
    }
}