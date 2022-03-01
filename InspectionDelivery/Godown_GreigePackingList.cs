using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.InspectionDelivery
{
    public partial class Godown_GreigePackingList : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePO;
        int SelectedPackingListRowHandle;
        private string G_Invoice;
        private string N_Invoice;

        public Godown_GreigePackingList()
        {
            InitializeComponent();
           
            G_Invoice = "104";
            N_Invoice = "114";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
          
        }

      
       
    
     
        private void SetButtonStates(UserInputMode uim)
        {
            uiModePO = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    PO_Execute.Enabled = false;
                    PO_Cancel.Enabled = false;
                    PO_Add.Enabled = true;

                    PO_View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            PO_Edit.Enabled = true;
                            PO_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            PO_Edit.Enabled = false;
                            PO_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        PO_Edit.Enabled = false;
                        PO_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";

                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_View.Enabled = false;
                    PO_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_Delete.Enabled = false;
                    PO_View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_Delete.Enabled = false;
                    PO_View.Enabled = false;

                    break;
                default:
                    break;
            }
        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(GodownEntryCode,8,6)))+1 as MaxNumber  from IP_Inspection_Greige where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0' and GodownEntryTypeID='1'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Suffix.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.Suffix.Text = iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Suffix.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.Suffix.Text = "";
                return false;
            }
        }
        private string PODGetNextNumber(string GodownEntryCode)
        {
            string iNumber; string query;
            try
            {
                try
                {

                    query = "select max(Convert(numeric(18),SubString(GDRNO,14,7)))+1 as MaxNumber  from IP_Godown_Greige_Details where GodownEntryCode='" + GodownEntryCode + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       
                        return "";
                    }
                    iNumber = iNumber.PadLeft(7, '0');
                    iNumber= GodownEntryCode +  iNumber;
                    return iNumber;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return "";
                }

              



            }
            catch
            {
              
                return "";
            }
        }
        private void Fill_TakenRecords(string GodownEntryNumber)
        {
           
          
            string query = "Select PONO,LoomName,BuyerName,ArticleShortName,OUT_A,OUT_B,OUT_C,OUT_SP,OUT_CP,GDRNO,GodownEntryCode,ArticleNumber,BuyerID,ShedID,Remarks,LoomID,Code,InspectorID,FrameNo,State,Shifted,Taken,RefGDRNO,SelvageID,SelvageName from RIP_Godown_Greige_Details where GodownEntryCode='" + GodownEntryNumber + "'";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                this.gridControl_PackingList.DataSource = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PackingList;
                }
                else
                {
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PackingList;
                }
            }

           
        }
        private void Fill_PackingListGeneralInfo(string GodownEntryNumber)
        {


            string query = "Select * from RIP_Godown_Greige where GodownEntryCode='" + GodownEntryNumber + "'";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {

                  try
                {
                    this.Dated.DateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                }
             
              


               
                this.FinancialYear.EditValue = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.Prefix.EditValue = ds.Tables[0].Rows[0]["iType"].ToString();
                this.Prefix.Tag = ds.Tables[0].Rows[0]["iType"].ToString();
                this.FinancialYear.Tag = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.DocumentState.Tag = ds.Tables[0].Rows[0]["iStatus"].ToString();
                this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
              
                    this.Suffix.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString().Substring(7, 6);

                               
                this.PO_Print.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                this.PO_View.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                if (ds.Tables[0].Rows[0]["Driver"].ToString() != "")
               
                    this.Driver.EditValue =ds.Tables[0].Rows[0]["Driver"].ToString();
                else
                    this.Driver.EditValue =null;
                if (ds.Tables[0].Rows[0]["VRN"].ToString() != "")

                    this.VRN.EditValue = ds.Tables[0].Rows[0]["VRN"].ToString();
                else
                    this.VRN.EditValue = null;
                if (ds.Tables[0].Rows[0]["Remarks"].ToString() != "")

                    this.Remarks.EditValue = ds.Tables[0].Rows[0]["Remarks"].ToString();
                else
                    this.Remarks.EditValue = null;
                if (ds.Tables[0].Rows[0]["AccountID"].ToString() != "")

                    this.AccountID.EditValue = ds.Tables[0].Rows[0]["AccountID"].ToString();
                else
                    this.AccountID.EditValue = null;
                if (ds.Tables[0].Rows[0]["AccountName"].ToString() != "")

                    this.AccountName.EditValue = ds.Tables[0].Rows[0]["AccountName"].ToString();
                else
                    this.AccountName.EditValue = null;
            }


        }
        private void Fill_InspectedRecords(string GodownEntryNumber)
        {


            string query = "Select PONO,LoomName,BuyerName,ArticleShortName,IN_A,IN_B,IN_C,IN_SP,IN_CP,GDRNO,GodownEntryCode,ArticleNumber,BuyerID,ShedID,Remarks,LoomID,Code,InspectorID,FrameNo,State,Shifted,Taken,SelvageID,SelvageName from RIP_Godown_Greige_Details where GodownEntryCode='" + GodownEntryNumber + "'";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                this.gridControl_Godown.DataSource = ds.Tables[0];
               

            }


        }
        private void SaveNew()
        {
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }

            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }


            string[] queries = new string[0];
            string vnum = "";
           
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
           

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
           
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Purchase Order list  code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into IP_Godown_Greige (NumberType,GodownEntryTypeID,AsInward,GodownEntryCode,iType,iCat,iYear,iStatus,Dated,VRN,Driver,AccountID,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'0',1,0,'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            

            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.VRN.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.VRN.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Driver.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Driver.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";




        
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
                    
                    this.PO_Print.Tag = vnum;
                    this.Remarks.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                    this.VRN.EditValue = null;
                    this.Driver.EditValue = null;
                    Fill_TakenRecords(vnum);     
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
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("invalid series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            



            string[] queries = new string[0];
            string vnum = "";
            string CodeToUpdate = "";

           
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
                CodeToUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
          

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
          
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("inspection code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
           



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update IP_Godown_Greige set ";
            queries[queries.Length - 1] += " NumberType='0',GodownEntryCode='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "',iStatus='U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

            if (this.VRN.EditValue != null)
                queries[queries.Length - 1] += ",VRN='" + this.VRN.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",VRN=null";
            if (this.Driver.EditValue != null)
                queries[queries.Length - 1] += ",Driver='" + this.Driver.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Driver=null";
            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",AccountID='" + this.AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AccountID=null";

            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
          

            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where GodownEntryCode='" + CodeToUpdate + "'";

        
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
                    
                    this.PO_Print.Tag = vnum;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.Driver.EditValue = null;
                    this.VRN.EditValue = null;
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                    this.Remarks.EditValue = null;
                    
                    SetButtonStates(UserInputMode.View);
                    this.PO_Add.Focus();
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
            string GRNtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Godown Entry Code  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  IP_Godown_Greige_Details where GodownEntryCode='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from IP_Godown_Greige where GodownEntryCode='" + GRNtoUpdate + "'";
        


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

                    
                    this.PO_Print.Tag = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.Remarks.EditValue = null;
                    Fill_TakenRecords("XXXXX");
                    this.ArticleNumber.EditValue = null;
                    this.ArticleShortName.EditValue = null;
                    this.PONO.EditValue = null;
                    this.PartyID.EditValue = null;
                    this.PartyName.EditValue = null;
                    
                    this.Shed.EditValue = null;
                    this.ShedName.EditValue = null;
                    this.Driver.EditValue = null;
                    this.VRN.EditValue = null;
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                    this.Meters_A.EditValue = null;
                    this.Meters_B.EditValue = null;
                    this.Meters_C.EditValue = null;
                    this.Meters_CP.EditValue = null;
                    this.Meters_SP.EditValue = null;
                 
                    SetButtonStates(UserInputMode.View);
                    this.PO_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PO_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePO == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiModePO == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiModePO == UserInputMode.Delete)
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

        private void NG_CheckedChanged(object sender, EventArgs e)
        {

            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "N";


                this.Prefix.Text = N_Invoice;
                if (uiModePO == UserInputMode.Add || uiModePO == UserInputMode.Edit)
                {
                   
                        GetNextInvoiceNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Invoice;
                if (uiModePO == UserInputMode.Add)
                {
                    
                        GetNextInvoiceNumber();
                }
            }
        }

        private void PO_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void PO_Delete_Click(object sender, EventArgs e)
        {
            if (this.Suffix.Tag == null || this.Prefix.Tag == null || this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Suffix.Tag.ToString() == "" || this.Prefix.Tag.ToString() == "" || this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SetButtonStates(UserInputMode.Delete);
        }

      
    
      

    


  

    

        private void PO_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();
            




            strFilterQuery = "SELECT GodownEntryCode,Dated,Remarks  FROM IP_Godown_Greige  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "'";


            if (this.Filter_OnArticle.Checked == true)
            {
                if (this.FilterArticleName.EditValue == null || this.FilterArticleName.Text == "")
                {
                    XtraMessageBox.Show("invalid Article for filter!", "Error", MessageBoxButtons.OK);
                    return;
                }

                if (this.FilterArticleName.EditValue == null || this.FilterArticleName.Text == "")
                {
                    XtraMessageBox.Show("invalid Article for filter!", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FilterArticleName.Tag == null )
                {
                    XtraMessageBox.Show("invalid Article for filter!", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FilterArticleName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid Article for filter!", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and GodownEntryCode in (Select GodownEntryCode from IP_Godown_Greige_Details where ArticleNumber='" + this.FilterArticleName.Tag.ToString() + "')";
            }

            if (this.FilterCheckNottakenToGodown.Checked == true)
            {
                strFilterQuery += " and GodownEntryCode in (Select GodownEntryCode from IP_Godown_Greige_Details where Taken=0 and Shifted=0)";
            }


            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "GodownEntryCode", "GodownEntryCode");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.PO_Print.Tag = sRow.PrimeryID;
                this.PO_View.Tag = sRow.PrimeryID;
                Fill_PackingListGeneralInfo(sRow.PrimeryID);
                Fill_TakenRecords(sRow.PrimeryID);

            }
        }
      

       

        private void PODShedID_EditValueChanged(object sender, EventArgs e)
        {

            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = shedindex.ToString();
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
                this.Shed.EditValue = null;
            }
        }

        

        
        

        private void PO_Print_Click(object sender, EventArgs e)
        {
            if (this.PO_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid packing list #", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.PO_Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid packing list #", "Error", MessageBoxButtons.OK);
                return;
            }
            MachineEyes.Classes.Printing.Print_IP_GreigePackingList(this.PO_Print.Tag.ToString());
        }

        private void POD_Print_Click(object sender, EventArgs e)
        {
            if (this.PO_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

          

        private void Shed_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = this.Shed.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
            }
        }

     

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ArticleGreigeView == null) Program.MainWindow.ArticleGreigeView = new Planning.Data_ArticleGreige_Main_View();
                Program.MainWindow.ArticleGreigeView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.ArticleNumber.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                        this.ArticleShortName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.Shift == true && e.KeyCode == Keys.Enter)
            {
                string query = "SELECT Distinct ArticleNumber,ArticleShortName,SetNo,BeamNo,WeightGrams from RP_DailyShiftSummary";
       
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "ArticleNumber", "ArticleShortName");

                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.ArticleNumber.Tag = sRow.PrimeryID;
                    this.ArticleNumber.EditValue = sRow.PrimeryID;
                    this.ArticleShortName.Text = sRow.PrimaryString;
                   

                }
            }
            
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PartyID.Focus();



            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.Shed.Focus();

            else
                return;
        }

    
    

        private void BrowsePO(KeyEventArgs e)
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
        private void PartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up)
                this.ArticleNumber.Focus();

           else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down)
                this.PONO.Focus();
            BrowsePO(e);
        }

        private void PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
               
                string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS from RFC_PO where POStatusID=0";
                if (this.ArticleNumber.EditValue != null && this.ArticleShortName.EditValue!=null)
                {
                    query += " and ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
                    
                }
                if (this.PartyName.EditValue != null && this.PartyID.EditValue != null)
                {
                    
                        query += " and ";
                  
                    query += " BuyerID='" + this.PartyID.EditValue.ToString() + "'";
                }
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
          

         
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.PartyID.Focus();
           
        }

        private void Shed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.ArticleNumber.Focus();
                
                
           
           

        }

        private void LoomNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.ArticleNumber.Focus();


            else if (e.KeyCode == Keys.Left)
                this.Shed.Focus();
          
            
        }

      

      

        private void RollThanNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.Meters_A.Focus();


            
        }

        private void Pieces_A_KeyDown(object sender, KeyEventArgs e)
        {
          


             if (e.KeyCode == Keys.Right)
                this.Meters_B.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_B_KeyDown(object sender, KeyEventArgs e)
        {
            

             if (e.KeyCode == Keys.Right)
                this.Meters_C.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Meters_A.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_C_KeyDown(object sender, KeyEventArgs e)
        {
           

             if (e.KeyCode == Keys.Right)
                this.Meters_SP.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Meters_B.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_SP_KeyDown(object sender, KeyEventArgs e)
        {
           

             if (e.KeyCode == Keys.Right)
                this.Meters_CP.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Meters_C.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_CP_KeyDown(object sender, KeyEventArgs e)
        {
           

            
             if (e.KeyCode == Keys.Left)
                this.Meters_SP.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Weight_Kg_KeyDown(object sender, KeyEventArgs e)
        {
           

            
            if (e.KeyCode == Keys.Left)
                this.Meters_CP.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        

       

      


        private void ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (ArticleNumber.EditValue != null)
            {
               article f = Program.ss.Machines.PresentationData.Return_Article(ArticleNumber.EditValue.ToString());
               if (f != null)
               {
                   this.ArticleShortName.EditValue = f.ArticleName;
                  
               }
               else
               {
                   this.ArticleShortName.EditValue = null;
                  
               }
            }
            else
                this.ArticleShortName.EditValue = null;
        }

        private void PartyID_EditValueChanged(object sender, EventArgs e)
        {
            if (PartyID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.PartyID.EditValue.ToString());
                if (mAcID != "")
                    this.PartyName.EditValue = mAcID;
                else
                    this.PartyName.EditValue = null;
            }
            else
            {
                PartyName.EditValue = null;
            }
        }

       

       

       

       

        private void FilterArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (Program.MainWindow.ArticleGreigeView == null) Program.MainWindow.ArticleGreigeView = new Planning.Data_ArticleGreige_Main_View();
                Program.MainWindow.ArticleGreigeView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.FilterArticleName.Tag = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                        this.FilterArticleName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Godown_GreigeInspection_Load(object sender, EventArgs e)
        {
            Fill_TakenRecords("XXXXXX");
        }

        private void TakeToGodownCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.gridView_Godown.FocusedRowHandle != -1)
            {

                try
                {
                    DataRow SelectedDataRow = this.gridView_Godown.GetDataRow(this.gridView_Godown.FocusedRowHandle);
                    string indexno = SelectedDataRow["GDRNO"].ToString();
                    if (indexno != "")
                    {
                        string res = "";
                        bool ischecked = (bool)TakeToGodownCheck.ValueChecked;
                        if (ischecked == true)
                            res = WS.svc.Execute_Query("update IP_Godown_Greige_Details set Taken=1 where GDRNO=" + indexno + "");
                        else
                            res = WS.svc.Execute_Query("update IP_Godown_Greige_Details set Taken=0 where GDRNO=" + indexno + "");
                        if (res != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (ischecked == true)
                                TakeToGodownCheck.ValueChecked = false;
                            else if (ischecked == false)
                                TakeToGodownCheck.ValueChecked = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bool ischecked = (bool)TakeToGodownCheck.ValueChecked;
                    if (ischecked == true)
                        TakeToGodownCheck.ValueChecked = false;
                    else if (ischecked == false)
                        TakeToGodownCheck.ValueChecked = true;
                }


            }
        }

        private void PO_Add_Click(object sender, EventArgs e)
        {
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.Prefix.Text == "" || this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }



            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState("U"));
            this.Suffix.Text = "";
            this.Suffix.Tag = null;
            this.Suffix.EditValue = null;
            this.Remarks.EditValue = null;
            this.Remarks.EditValue = null;






            bool rRes = GetNextInvoiceNumber();


            SetButtonStates(UserInputMode.Add);
        }

        private void PO_Edit_Click(object sender, EventArgs e)
        {
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.Prefix.Text == "" || this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.Suffix.Tag == null || this.Prefix.Tag == null || this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Suffix.Tag.ToString() == "" || this.Prefix.Tag.ToString() == "" || this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SetButtonStates(UserInputMode.Edit);
        }

        private void PO_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetRecordsFromInspection_Click(object sender, EventArgs e)
        {
          
           
        }

        private void TakeToGodown_Click(object sender, EventArgs e)
        {
           
        }

        private void TakeBackToInspection_Click(object sender, EventArgs e)
        {
            if (PO_Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PO_Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PO_Print.Tag.ToString().Length != 13)
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to take back selected fabric rolls/thans/pieces to inspection?", "Confirmation", MessageBoxButtons.YesNo);
            if (dg != DialogResult.Yes) return;

            string[] queries = new string[0];

            DataTable dt = (DataTable)this.gridControl_PackingList.DataSource;
           
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (dt.Rows[x].RowState != DataRowState.Deleted)
                {
                    
                    if (dt.Rows[x]["Taken"].ToString() == "True" && dt.Rows[x]["Shifted"].ToString() == "False" )
                    {
                        Array.Resize(ref queries, queries.Length + 1);
                        queries[queries.Length - 1] = "delete from IP_Godown_Greige_Details where GDRNO='" + dt.Rows[x]["GDRNO"].ToString() + "'";
                        Array.Resize(ref queries, queries.Length + 1);
                        queries[queries.Length - 1] += "update IP_Inspection_Greige_Details set taken=0,shifted=0,refgdrno=null where GDRNO='" + dt.Rows[x]["REFGDRNO"].ToString() + "'";

                    }
                }
            }




            if (queries.Length <= 0) return;


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
                    DataTable dtDel = (DataTable)this.gridControl_PackingList.DataSource;

                    for (int x = 0; x < dtDel.Rows.Count; x++)
                    {
                        if (dtDel.Rows[x].RowState != DataRowState.Deleted)
                        {
                            if (dtDel.Rows[x]["Taken"].ToString() == "True")
                            {
                                dtDel.Rows[x].Delete();

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetGodownRecords_Click(object sender, EventArgs e)
        {
            string filterquery = "Select PONO,GDRNO,LoomName,ArticleShortName,IN_A,IN_B,IN_C,IN_SP,IN_CP,Taken,DepartmentID,ShedID,LoomID,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,RollNo,Remarks,State,Shifted,Code,BuyerID,SelvageID,SelvageName from RIP_Godown_Greige_Details  where Shifted=0 and asInward=1";

            if (this.Filter_ArticleNumber.Checked == false && this.ArticleNumber.EditValue != null)
            {
                filterquery += " and ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
            }



            if (this.PartyID.EditValue != null && this.Filter_PartyID.Checked == true)
            {
                filterquery += " and BuyerID='" + this.PartyID.EditValue.ToString() + "'";
            }
            if (this.Shed.EditValue != null && this.Filter_ShedID.Checked == true)
            {
                filterquery += " and ShedID=" + this.Shed.EditValue.ToString() + "";
            }

            if (this.PONO.EditValue != null && this.Filter_PONO.Checked == true)
            {
                filterquery += " and PONO='" + this.PONO.EditValue.ToString() + "'";
            }

            if (this.Meters_A.EditValue != null && this.Filter_Meters.Checked == true)
            {
                filterquery += " and IN_A=" + this.Meters_A.EditValue.ToString() + "";
            }
            if (this.Meters_B.EditValue != null && this.Filter_Meters.Checked == true)
            {
                filterquery += " and IN_B=" + this.Meters_B.EditValue.ToString() + "";
            }
            if (this.Meters_C.EditValue != null && this.Filter_Meters.Checked == true)
            {
                filterquery += " and IN_C=" + this.Meters_C.EditValue.ToString() + "";
            }
            if (this.Meters_CP.EditValue != null && this.Filter_Meters.Checked == true)
            {
                filterquery += " and IN_CP=" + this.Meters_CP.EditValue.ToString() + "";
            }
            if (this.Meters_SP.EditValue != null && this.Filter_Meters.Checked == true)
            {
                filterquery += " and IN_SP=" + this.Meters_SP.EditValue.ToString() + "";
            }

            DataSet ds = WS.svc.Get_DataSet(filterquery);


            if (ds != null)
            {
                gridControl_Godown.DataSource = ds.Tables[0];
            }
        }

        private void PackingList_Click(object sender, EventArgs e)
        {
            if (PO_Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PO_Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (PO_Print.Tag.ToString().Length != 13)
            {
                XtraMessageBox.Show("Invalid Entry Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to take all selected fabric rolls/thans/pieces to packing list?", "Confirmation", MessageBoxButtons.YesNo);
            if (dg != DialogResult.Yes) return;

            string[] queries = new string[0];

            DataTable dt = (DataTable)gridControl_Godown.DataSource;
            string GDRNO = PODGetNextNumber(this.PO_Print.Tag.ToString());
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (dt.Rows[x]["Taken"].ToString() == "True")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into IP_Godown_Greige_Details (GodownEntryCode,state,GDRNO,DepartmentID,ShedID,SelvageID,LoomID,LoomName,PONO,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,RollNo,Code,Remarks,OUT_A,OUT_B,OUT_C,OUT_SP,OUT_CP,RefGDRNO) Values (";
                    queries[queries.Length - 1] += "'" + this.PO_Print.Tag.ToString() + "',0,'" + GDRNO + "'";
                    if (Departments.Towel_Godown != "")
                        queries[queries.Length - 1] += ",'" + Departments.Towel_Godown + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["ShedID"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["ShedID"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["SelvageID"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["SelvageID"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["LoomID"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["LoomID"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["LoomName"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["LoomName"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["PONO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["PONO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["ArticleNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["ArticleNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["SetNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["SetNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["BeamNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["BeamNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["FrameNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["FrameNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["InspectorID"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["InspectorID"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Rollno"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["RollNO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Code"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["Code"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Remarks"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["Remarks"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["IN_A"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["IN_A"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["IN_B"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["IN_B"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["IN_C"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["IN_C"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["IN_SP"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["IN_SP"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["IN_CP"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["IN_CP"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";

                    if (dt.Rows[x]["GDRNO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["GDRNO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    queries[queries.Length - 1] += ")";

                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update IP_Godown_Greige_Details set Shifted=1,State=1,REFGDRNO='" + GDRNO + "' where GDRNO='" + dt.Rows[x]["GDRNO"].ToString() + "'";

                    GDRNO = this.PO_Print.Tag.ToString() + Convert.ToString(Convert.ToInt64(GDRNO.Substring(13, 7)) + 1).PadLeft(7, '0');

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
                    DataTable dtDel = (DataTable)gridControl_Godown.DataSource;

                    for (int x = 0; x < dtDel.Rows.Count; x++)
                    {
                        if (dtDel.Rows[x].RowState != DataRowState.Deleted)
                        {
                            if (dtDel.Rows[x]["Taken"].ToString() == "True")
                            {
                                dtDel.Rows[x].Delete();

                            }
                        }

                    }
                    Fill_TakenRecords(this.PO_Print.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Weight_Kg_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select AccountID,AccountName,MailingAddress from PP_Accounts order by AccountName", "AccountID", "AccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.AccountID.EditValue  = sRow.PrimeryID;
                    this.AccountName.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void gridView_PackingList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
               
                    SelectedPackingListRowHandle = e.FocusedRowHandle;
            }
            catch
            {
            }
        }

        private void gridView_PackingList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control == true && SelectedPackingListRowHandle >=0)
            {
                DataRow SelectedPackingListRow=this.gridView_PackingList.GetDataRow(SelectedPackingListRowHandle);
                if (SelectedPackingListRow == null) return;
                DialogResult dg = XtraMessageBox.Show("Are you sure to delete the selected data ? ..", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dg != DialogResult.Yes) return;
                string[] queries = new string[0];
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "delete from IP_Godown_Greige_Details where GDRNO='" + SelectedPackingListRow["GDRNO"].ToString() + "'";
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] += "update IP_Godown_Greige_Details set taken=0,shifted=0,refgdrno=null where GDRNO='" + SelectedPackingListRow["REFGDRNO"].ToString() + "'";
                string res = WS.svc.Execute_Transaction(queries);
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    gridView_PackingList.DeleteRow(SelectedPackingListRowHandle);
                }
            }
        }

       
    }
}