using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.WarpingSizing
{
    public partial class SW_OutSideSizing : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public SW_OutSideSizing()
        {
            InitializeComponent();
            this.SizingDate.DateTime = DateTime.Now;
        }
        private void SetButtonStates(UserInputMode input)
        {
            uiMode = input;
            switch (input)
            {
                case UserInputMode.View:
                    this.Add.Enabled = true;
                    this.CancelThis.Enabled = false;
                    this.CloseThis.Enabled = true;
                    if (this.SetNo.Tag != null)
                    {
                        if (this.SetNo.Tag.ToString() != "")
                        {
                            this.Delete.Enabled = true;
                            this.Edit.Enabled = true;
                        }
                        else
                        {
                            this.Delete.Enabled = false;
                            this.Edit.Enabled = false;
                        }
                    }
                    else
                    {
                        this.Delete.Enabled = false;
                        this.Edit.Enabled = false;
                    }
                    this.Execute.Enabled = false;
                    this.View.Enabled = true;

                    break;
                case UserInputMode.Add:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                case UserInputMode.Edit:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                case UserInputMode.Delete:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState("U"));
         

            this.Remarks.Text = "";
          
            this.SetNo.EditValue = null;

            SetButtonStates(UserInputMode.View);

            this.tableLayoutPanel_SizingDetails.Controls.Clear();
          

           
                SetButtonStates(UserInputMode.Add);
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiMode == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiMode == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DeleteExisting();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {

      
                if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
            


            SetButtonStates(UserInputMode.Edit);
        }

        private void Delete_Click(object sender, EventArgs e)
        {

             if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }


            

            SetButtonStates(UserInputMode.Delete);
        }

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.FilterSizingDate.Checked == true)
            {
                if (this.SizingDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }


            if (this.FilterSetNo.Checked == true)
            {

                    if (this.SetNo.EditValue == null)
                    {
                        XtraMessageBox.Show("Either uncheck the Set number filter or enter valid set # ", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;


                    }
                    if (this.SetNo.EditValue.ToString() == null)
                    {
                        XtraMessageBox.Show("Either uncheck the Set number filter or enter valid set # ", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;


                    }


                

            }
           





            strFilterQuery = "SELECT  SETNO,WarpingProgramNumber,SizingDate,TotalSizedBeams,SizingMachineID from SW_Sizing ";
            strFilterQuery += "  where iType='000'  and iCAT='O' and SizingTypeID='0' ";



            if (this.FilterSizingDate.Checked == true)
            {

                strFilterQuery += " and SizingDate='" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.FilterSetNo.Checked == true)
            {
               
                    strFilterQuery += " and Setno like '%" + this.SetNo.EditValue.ToString() + "%'";

            }

           



           // strFilterQuery += " ORDER BY Convert(numeric(18),SetNo) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "SetNO", "SetNO");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_SizingSheet(sRow.PrimeryID);

            }
        }
        private void Fill_SizingSheet(string SetNo)
        {
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from SW_Sizing where SetNO='" + SetNo + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;

           

            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNo"].ToString();
           
            
                this.SetNo.EditValue = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString();
                this.SetNo.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString();
  
            
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            try
            {
                this.SizingDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["SizingDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            }
            catch
            {
            }
           


           

          
            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
            this.TotalSizedBeams.EditValue = ds_VoucherMain.Tables[0].Rows[0]["TotalSizedBeams"].ToString();
            this.TotalSizedBeams.Tag = ds_VoucherMain.Tables[0].Rows[0]["TotalSizedBeams"].ToString();
            this.Ends.EditValue = ds_VoucherMain.Tables[0].Rows[0]["Ends"].ToString();



            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SWQ_Sizing_Details where Setno='" + SetNo + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_SizingDetails.Controls.Clear();

            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                dxSizingDetail ysub = new dxSizingDetail();
                this.tableLayoutPanel_SizingDetails.Controls.Add(ysub);

                ysub.Tag = SetNo;
                ysub.GrossWeight.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["GWeight"].ToString();
                ysub.BeamLength.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BeamLength"].ToString();
                ysub.BeamSpeed.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Speed"].ToString();
                ysub.Pressure.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Pressure"].ToString();
                ysub.Remarks.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Remarks"].ToString();
               
                ysub.BeamNumber.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Beamnumber"].ToString();
                ysub.BeamNumber.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["Beamnumber"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[x]["SizerID"].ToString() != "")
                {
                    ysub.Sizer.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["SizerID"].ToString();
                    ysub.Sizer.Text = ds_VoucherSub_T.Tables[0].Rows[x]["SizerName"].ToString();
                }
                else
                {
                    ysub.Sizer.Tag = null;
                    ysub.Sizer.Text = "";
                    ysub.Sizer.EditValue = null;
                }

                ysub.Shift.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Shift"].ToString();

            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }

        private void CancelThis_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void CloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveNew()
        {

                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
            

            if (this.SizingDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.TotalSizedBeams.EditValue == null)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            int NoofBeams = 0;
            int.TryParse(this.TotalSizedBeams.EditValue.ToString(), out NoofBeams);
            if (NoofBeams <= 0 || NoofBeams > 20)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

          
            string[] queries = new string[0];

            string vnum = "";
            vnum = this.SetNo.EditValue.ToString();
           
          
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.BeamLength.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Length", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


               

             


            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into SW_Sizing (SizingTypeID,SetNo,iType,iCat,iYear,iStatus,WarpingProgramNumber,SizingMachineID,Breakages,SizingDate,TotalSizedBeams,Ends,Starttime,EndTime,Remarks,cUserId,CuserTime) Values (";
            queries[queries.Length - 1] += "'0','" + vnum + "','000','O','" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "','U'";


           
                queries[queries.Length - 1] += ",null";
            
                queries[queries.Length - 1] += ",null";
            
                queries[queries.Length - 1] += ",0";

            if (this.SizingDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.TotalSizedBeams.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalSizedBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Ends.EditValue != null)
                queries[queries.Length - 1] += "," + this.Ends.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",null";
            
                queries[queries.Length - 1] += ",null";

            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";

            

            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Sizing_Details (SetNo,BeamNumber,BeamLength,Speed,Pressure,SizerID,Shift,GWeight,Remarks,BeamStatus) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";

                if (AField.BeamNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.BeamNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.BeamLength.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BeamLength.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BeamSpeed.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BeamSpeed.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Pressure.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Pressure.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Sizer.Tag != null)
                    queries[queries.Length - 1] += ",'" + AField.Sizer.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Shift.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Shift.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                    queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",1)";

            }



     
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.Print.Tag = vnum;
                    
                    this.Remarks.Text = "";
                    this.Ends.EditValue = null;
                    this.SetNo.EditValue = null;
                 
                    this.TotalSizedBeams.EditValue = 0;
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                  
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void UpdateExisting()
        {

                if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
            

            if (this.SizingDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.TotalSizedBeams.EditValue == null)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            int NoofBeams = 0;
            int.TryParse(this.TotalSizedBeams.EditValue.ToString(), out NoofBeams);
            if (NoofBeams <= 0 || NoofBeams > 20)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

         
            string[] queries = new string[0];
            string vnum = "";
            string vnumtoupdate = "";
           
                vnum = this.SetNo.EditValue.ToString();
                vnumtoupdate = this.SetNo.Tag.ToString();
   
            char vCat = 'O';
           
         
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.BeamLength.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Length", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


              


              


            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update SW_Sizing set ";
            queries[queries.Length - 1] += "SetNo='" + vnum + "',iType='000',iCat='" + vCat + "',iYear='" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "' ";


                queries[queries.Length - 1] += ",WarpingProgramNumber=null";
           
                queries[queries.Length - 1] += ",SizingMachineID=null";
           
                queries[queries.Length - 1] += ",Breakages=0";

            if (this.SizingDate.EditValue != null)
                queries[queries.Length - 1] += ",SizingDate='" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",SizingDate=null";
            if (this.TotalSizedBeams.EditValue != null)
                queries[queries.Length - 1] += ",TotalSizedBeams=" + this.TotalSizedBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",TotalSizedBeams=0";
            if (this.Ends.EditValue != null)
                queries[queries.Length - 1] += ",Ends=" + this.Ends.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Ends=0";
                queries[queries.Length - 1] += ",StartTime=null";
           
                queries[queries.Length - 1] += ",EndTime=null";

            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";

            queries[queries.Length - 1] += ",euserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime ='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where Setno='" + vnumtoupdate + "'";
          
           
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.Tag == null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into SW_Sizing_Details (SetNo,BeamNumber,BeamLength,Speed,Pressure,SizerID,Shift,GWeight,Remarks) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (AField.BeamNumber.EditValue != null)
                        queries[queries.Length - 1] += ",'" + AField.BeamNumber.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.BeamLength.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.BeamLength.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.BeamSpeed.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.BeamSpeed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Pressure.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.Pressure.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Sizer.Tag != null)
                        if (AField.Sizer.ToString() != "")
                            queries[queries.Length - 1] += ",'" + AField.Sizer.Tag.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.Shift.EditValue != null)
                        queries[queries.Length - 1] += ",'" + AField.Shift.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                        queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Remarks.Text != "")
                        queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    queries[queries.Length - 1] += ")";
                }
                else
                {

                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_Sizing_Details set ";
                   
                    if (AField.BeamNumber.EditValue != null)
                        queries[queries.Length - 1] += "BeamNumber='" + AField.BeamNumber.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += "BeamNumber=null";
                    if (AField.BeamLength.EditValue != null)
                        queries[queries.Length - 1] += ",BeamLength=" + AField.BeamLength.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",BeamLength=0";
                    if (AField.BeamSpeed.EditValue != null)
                        queries[queries.Length - 1] += ",Speed=" + AField.BeamSpeed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",Speed=0";
                    if (AField.Pressure.EditValue != null)
                        queries[queries.Length - 1] += ",Pressure=" + AField.Pressure.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",Pressure=0";
                    if (AField.Sizer.Tag != null)
                        if (AField.Sizer.ToString() != "")
                            queries[queries.Length - 1] += ",SizerID='" + AField.Sizer.Tag.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",SizerID=null";
                    else
                        queries[queries.Length - 1] += ",SizerID=null";
                    if (AField.Shift.EditValue != null)
                        queries[queries.Length - 1] += ",Shift='" + AField.Shift.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",Shift=null";
                    if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                        queries[queries.Length - 1] += ",GWeight=" + AField.GrossWeight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",GWeight=0";
                    if (AField.Remarks.Text != "")
                        queries[queries.Length - 1] += ",Remarks='" + AField.Remarks.Text + "'";
                    else
                        queries[queries.Length - 1] += ",Remarks=null";
                    queries[queries.Length - 1] += " where SetNo ='" + vnumtoupdate + "' and beamNumber='"+AField.BeamNumber.Tag.ToString()+"'";

                }

            }

         
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.SetNo.EditValue = null;
                    this.SetNo.Tag = null;
                    this.Print.Tag = vnum;
                   
                    this.Remarks.Text = "";
                   
                    this.TotalSizedBeams.EditValue = 0;
                    this.TotalSizedBeams.Tag = "0";
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                   
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteExisting()
        {






            string[] queries = new string[0];
            string ProgNumber = "";
         
                ProgNumber = this.SetNo.Tag.ToString();

            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Sizing Program Number # " + ProgNumber + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_Details where SetNo='" + ProgNumber + "'";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_ChemicalsConsumption where SetNO='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing where SetNO='" + ProgNumber + "'";
           
          

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.SetNo.Tag = null;
                    this.SetNo.EditValue = null;
                    this.Print.Tag = "";
                   
                    this.Remarks.Text = "";
                   
                    this.TotalSizedBeams.EditValue = 0;
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                
                    SetButtonStates(UserInputMode.View);

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TotalSizedBeams_EditValueChanged(object sender, EventArgs e)
        {
            int totalbeams = 0;
            int.TryParse(TotalSizedBeams.EditValue.ToString(), out totalbeams);
            if (totalbeams <= 20)
                LoadSizedBeams(totalbeams);
        }
        private void LoadSizedBeams(int totalbeams)
        {
            if (uiMode == UserInputMode.Edit)
            {
                int TotalSizedBeamsBeforeEditing = 0;
                if (this.TotalSizedBeams.Tag == null)
                {
                    XtraMessageBox.Show("invalid number of beams before editing", "Error", MessageBoxButtons.OK); return;

                }
                int.TryParse(this.TotalSizedBeams.Tag.ToString(), out TotalSizedBeamsBeforeEditing);
            DeleteBeams:
                foreach (Control c in this.tableLayoutPanel_SizingDetails.Controls)
                {
                    dxSizingDetail dxs = (dxSizingDetail)c;
                    if (dxs.BeamNumber.Tag == null)
                        this.tableLayoutPanel_SizingDetails.Controls.Remove(c);
                }
            if (this.tableLayoutPanel_SizingDetails.Controls.Count > TotalSizedBeamsBeforeEditing) goto DeleteBeams;
                for (int x = TotalSizedBeamsBeforeEditing ; x < totalbeams; x++)
                {
                    dxSizingDetail dxs = new dxSizingDetail();
                    this.tableLayoutPanel_SizingDetails.Controls.Add(dxs);
                }
            }
            else
            {
                this.tableLayoutPanel_SizingDetails.Controls.Clear();
                for (int x = 0; x < totalbeams; x++)
                {
                    dxSizingDetail dxs = new dxSizingDetail();
                    this.tableLayoutPanel_SizingDetails.Controls.Add(dxs);
                }
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            MachineEyes.Classes.Printing.Print_SW_SizingSheetSelf(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }
    }
}