using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn
{
    public partial class Yarn_InwardOpening : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        private string CurrentGodownDepartmentID="";
        public Yarn_InwardOpening()
        {
            InitializeComponent();
            this.Prefix.Text = "100";
            G_Invoice = "100";
            N_Invoice = "110";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.Prefix.EditValue = G_Invoice;
            this.Dated.DateTime = DateTime.Now;
            this.tableLayoutPanel_Detail.Controls.Clear();
            UserControls.dxYarn dxNewYarn = new UserControls.dxYarn();
            if (this.GodownID.EditValue != null)
                dxNewYarn.GodownID = this.GodownID.EditValue.ToString();
            if (this.PONO.EditValue != null)
                dxNewYarn.PONO = this.PONO.EditValue.ToString();
            this.tableLayoutPanel_Detail.Controls.Add(dxNewYarn);
            FillCombos fc = new FillCombos();
            fc.YarnGodowns(ref this.GodownID);
          
        }
        private void FillYarnInfoFromPO(string PONO, YarnSelectionMode SelectionMode)
        {
            if (Settings.FillYarnInfoFromPO == false) return;
            try
            {
                string query = "";

                query = "SELECT * from FC_PO_YarnRequired where PONO='" + PONO + "'";
                DataSet ds = WS.svc.Get_DataSet(query);
                if (ds == null) return;
                if (ds.Tables[0] == null) return;

                if (ds.Tables[0].HasErrors == true) return;

                foreach (Control C in this.tableLayoutPanel_Detail.Controls)
                {
                    UserControls.dxYarn yarncontrol = (UserControls.dxYarn)C;
                    yarncontrol.BagsType.EditValue = "Fresh";
                    yarncontrol.ConesPerBag.EditValue = "24";
                    if (SelectionMode == YarnSelectionMode.WarpYarn)
                    {
                        yarncontrol.Counts.EditValue = ds.Tables[0].Rows[0]["WarpYarnCount_0"].ToString();
                        yarncontrol.Blends.EditValue = ds.Tables[0].Rows[0]["WarpYarnBlend_0"].ToString();
                        yarncontrol.Ply.EditValue = ds.Tables[0].Rows[0]["WarpYarnPly_0"].ToString();
                        yarncontrol.LbsPerBag.EditValue = ds.Tables[0].Rows[0]["WarpYarnLbsPerBag_0"].ToString();
                        yarncontrol.Desc.EditValue = ds.Tables[0].Rows[0]["WarpYarnDesc_0"].ToString();
                        yarncontrol.Color.EditValue = ds.Tables[0].Rows[0]["WarpYarnColor_0"].ToString();
                    }
                    else if (SelectionMode == YarnSelectionMode.WeftYarn)
                    {
                        yarncontrol.Counts.EditValue = ds.Tables[0].Rows[0]["WeftYarnCount_0"].ToString();
                        yarncontrol.Blends.EditValue = ds.Tables[0].Rows[0]["WeftYarnBlend_0"].ToString();
                        yarncontrol.Ply.EditValue = ds.Tables[0].Rows[0]["WeftYarnPly_0"].ToString();
                        yarncontrol.LbsPerBag.EditValue = ds.Tables[0].Rows[0]["WeftYarnLbsPerBag_0"].ToString();
                        yarncontrol.Desc.EditValue = ds.Tables[0].Rows[0]["WeftYarnDesc_0"].ToString();
                        yarncontrol.Color.EditValue = ds.Tables[0].Rows[0]["WeftYarnColor_0"].ToString();
                    }
                    else if (SelectionMode == YarnSelectionMode.PileYarn)
                    {
                        yarncontrol.Counts.EditValue = ds.Tables[0].Rows[0]["PileYarnCount_0"].ToString();
                        yarncontrol.Blends.EditValue = ds.Tables[0].Rows[0]["PileYarnBlend_0"].ToString();
                        yarncontrol.Ply.EditValue = ds.Tables[0].Rows[0]["PileYarnPly_0"].ToString();
                        yarncontrol.LbsPerBag.EditValue = ds.Tables[0].Rows[0]["PileYarnLbsPerBag_0"].ToString();
                        yarncontrol.Desc.EditValue = ds.Tables[0].Rows[0]["PileYarnDesc_0"].ToString();
                        yarncontrol.Color.EditValue = ds.Tables[0].Rows[0]["PileYarnColor_0"].ToString();
                    }
                    else if (SelectionMode == YarnSelectionMode.Fancy)
                    {
                        yarncontrol.Counts.EditValue = ds.Tables[0].Rows[0]["FancyYarnCount_0"].ToString();
                        yarncontrol.Blends.EditValue = ds.Tables[0].Rows[0]["FancyYarnBlend_0"].ToString();
                        yarncontrol.Ply.EditValue = ds.Tables[0].Rows[0]["FancyYarnPly_0"].ToString();
                        yarncontrol.LbsPerBag.EditValue = ds.Tables[0].Rows[0]["FancyYarnLbsPerBag_0"].ToString();
                        yarncontrol.Desc.EditValue = ds.Tables[0].Rows[0]["FancyYarnDesc_0"].ToString();
                        yarncontrol.Color.EditValue = ds.Tables[0].Rows[0]["FancyYarnColor_0"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(GRNGIN,8,6)))+1 as MaxNumber  from YN_Yarn where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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
        private void SetButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute.Enabled = false;
                    Cancel.Enabled = false;
                    Add.Enabled = true;

                    View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            Edit.Enabled = true;
                            Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit.Enabled = false;
                            Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit.Enabled = false;
                        Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";

                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    View.Enabled = false;
                    Delete.Enabled = false;
                   

                    break;
                case UserInputMode.Edit:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        private void Add_Click(object sender, EventArgs e)
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

            this.tableLayoutPanel_Detail.Controls.Clear();
            UserControls.dxYarn dxNewYarn = new UserControls.dxYarn();
            if (this.GodownID.EditValue != null)
                dxNewYarn.GodownID = this.GodownID.EditValue.ToString();
            if (this.PONO.EditValue != null)
                dxNewYarn.PONO = this.PONO.EditValue.ToString();
            this.tableLayoutPanel_Detail.Controls.Add(dxNewYarn);
                     
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState("U"));
            this.Suffix.Text = "";
            this.Suffix.Text = "";
           

            
         
         

           
                bool rRes = GetNextInvoiceNumber();
                if (rRes != false)
                    SetButtonStates(UserInputMode.Add);

                this.GodownID.Focus();
           

        }

        private void Edit_Click(object sender, EventArgs e)
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

            if (this.Suffix.Tag == null || this.Prefix.Tag ==null || this.FinancialYear.Tag ==null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Suffix.Tag.ToString()=="" || this.Prefix.Tag.ToString()=="" || this.FinancialYear.Tag.ToString()=="")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
           
          
            SetButtonStates(UserInputMode.Edit);
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
            if (this.Suffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.Suffix.Text, out suffix) == false)
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
            if (this.Suffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                XtraMessageBox.Show("invalid party account!", "Error", MessageBoxButtons.OK);
                this.AccountID.Focus();
                return;
            }


          
               string[] queries = new string[0];
               string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
              
               char vCat = 'G';
               if (NG.Checked == true)
                   vCat = 'N';
               else
                   vCat = 'G';
               if (vnum.Length != 13)
               {
                   XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                   return;
               }
                 foreach (Control C in this.tableLayoutPanel_Detail.Controls)
               {
                   UserControls.dxYarn AField = (UserControls.dxYarn)C;
                   
                  if(AField.BagsType.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Sub Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.BagsType.Focus();
                     return;
                  }
                   
                     if(AField.Counts.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.Counts.Focus();
                     return;
                  }

                if(AField.Ply.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Sub Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.Ply.Focus();
                     return;
                  }

                    if(AField.Blends.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Yarn Blend ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.Blends.Focus();
                     return;
                  }
                    if(AField.Brand.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Yarn Brand ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.Brand.Focus();
                     return;
                  }

                    if(AField.Desc.EditValue==null)
                  {
                       XtraMessageBox.Show("Invalid Yarn Desc ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     AField.Desc.Focus();
                     return;
                  }
                  
               }
              
               Array.Resize(ref queries, queries.Length + 1);
               queries[queries.Length - 1] = "insert into YN_Yarn (GRNGIN,iType,iCat,iYear,iStatus,Dated,GateEntryNumber,SenderGatePassNumber,Driver,TruckregistrationNumber,DeliveryChallanNumber,Remarks,CUserID,CUserTime) Values (";
               queries[queries.Length - 1] += "'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
               if (this.Dated.EditValue != null)
                   queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
               else
                   queries[queries.Length - 1] += ",null";

               
              
                   queries[queries.Length - 1] += ",null";
              
             
                   queries[queries.Length - 1] += ",null";

              
                   queries[queries.Length - 1] += ",null";
              
                   queries[queries.Length - 1] += ",null";
            
              
                   queries[queries.Length - 1] += ",null";
              
               
             
            
             
         
               if (this.Remarks.Text!="")
                   queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
               else
                   queries[queries.Length - 1] += ",null";
               queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
               queries[queries.Length - 1] += ")";


              
               foreach (Control C in this.tableLayoutPanel_Detail.Controls)
               {
                   UserControls.dxYarn AField = (UserControls.dxYarn)C;
                   Array.Resize(ref queries, queries.Length + 1);

                   queries[queries.Length - 1] = "insert into YN_YarnDetail (GRNGIN,GodownID,LotNo,YCC,PONO,DEPTID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,YarnColor,BagsInward,LbsInward,ConesInward) Values (";
                   queries[queries.Length - 1] += "'" + vnum + "'";
                   if (this.GodownID.EditValue != null)
                       queries[queries.Length - 1] += ",'" + this.GodownID.EditValue.ToString() + "'";
                   else
                       queries[queries.Length - 1] += ",null";
                   if (this.LotNumber.EditValue != null)
                   queries[queries.Length - 1] += ",'" + this.LotNumber.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                   if (this.YarnContract.EditValue != null)
                       queries[queries.Length - 1] += ",'" + this.YarnContract.EditValue.ToString() + "'";
                   else
                       queries[queries.Length - 1] += ",null";
                   if (this.PONO.EditValue != null)
                   queries[queries.Length - 1] += ",'" + this.PONO.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";

                   if (CurrentGodownDepartmentID!="")
                          queries[queries.Length - 1] += ",'" + CurrentGodownDepartmentID + "'";
                      else
                          queries[queries.Length - 1] += ",null";

                        if (AField.BagsType.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.BagsType.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                     if (AField.ConesPerBag.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.ConesPerBag.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";

                        if (AField.LbsPerBag.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.LbsPerBag.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                         if (AField.Counts.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Counts.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                          if (AField.Ply.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Ply.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                          if (AField.Blends.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Blends.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                          if (AField.Brand.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Brand.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                          if (AField.Desc.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Desc.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",null";
                          if (AField.Color.EditValue != null)
                              queries[queries.Length - 1] += ",'" + AField.Color.EditValue.ToString() + "'";
                     else
                              queries[queries.Length - 1] += ",null";
                          if (AField.Bags.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Bags.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",0";
                              if (AField.Lbs.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Lbs.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",0";
                              if (AField.Cones.EditValue != null)
                   queries[queries.Length - 1] += ",'" + AField.Cones.EditValue.ToString() + "'";
                     else
                   queries[queries.Length - 1] += ",0";
                     queries[queries.Length - 1] += ")";

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
                       this.Suffix.Text ="";
                       this.AccountID.EditValue =null;
                       this.AccountName.EditValue =null;
                      
                       this.LotNumber.EditValue = null;
                       this.Remarks.EditValue = null;
                      
                       this.PONO.EditValue = null;
                       this.ArticleShortName.EditValue = null;
                       this.ArticleShortName.EditValue = null;
                       this.tableLayoutPanel_Detail.Controls.Clear();
                       UserControls.dxYarn dxNewYarn = new UserControls.dxYarn();
                       if (this.GodownID.EditValue != null)
                           dxNewYarn.GodownID = this.GodownID.EditValue.ToString();
                       if (this.PONO.EditValue != null)
                           dxNewYarn.PONO = this.PONO.EditValue.ToString();
                       this.tableLayoutPanel_Detail.Controls.Add(dxNewYarn);
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
            if (this.Suffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.Suffix.Text, out suffix) == false)
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
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.PONO.EditValue == null)
            {
                XtraMessageBox.Show("invalid PO #", "Error", MessageBoxButtons.OK);
                this.PONO.Focus();
                return;
            }
            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Party Account", "Error", MessageBoxButtons.OK);
                this.AccountID.Focus();
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
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            string GRNtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (vnum.Length != 13)
            {
                XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn AField = (UserControls.dxYarn)C;

                if (AField.BagsType.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Sub Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.BagsType.Focus();
                    return;
                }

                if (AField.Counts.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Counts.Focus();
                    return;
                }

                if (AField.Ply.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Sub Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Ply.Focus();
                    return;
                }

                if (AField.Blends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Blend ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Blends.Focus();
                    return;
                }
                if (AField.Brand.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Brand ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Brand.Focus();
                    return;
                }

                if (AField.Desc.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Desc ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Desc.Focus();
                    return;
                }

            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update YN_Yarn  set ";
            queries[queries.Length - 1] += "GRNGIN='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

          
                queries[queries.Length - 1] += ",Driver=null";
           
                queries[queries.Length - 1] += ",TruckRegistrationNumber=null";

            
                queries[queries.Length - 1] += ",DeliveryChallanNumber=null";
           
                queries[queries.Length - 1] += ",SenderGatePassNumber=null";
           
                queries[queries.Length - 1] += ",GateEntryNumber=null";

           
           
                   
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where GRNGIN='"+GRNtoUpdate+"'";

            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from YN_YarnDetail where GRNGIN='"+GRNtoUpdate+"'";

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn AField = (UserControls.dxYarn)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into YN_YarnDetail (GRNGIN,GodownID,LotNo,YCC,PONO,DEPTID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,YarnColor,BagsInward,LbsInward,ConesInward) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GodownID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.GodownID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.LotNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.LotNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.YarnContract.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.YarnContract.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (this.PONO.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.PONO.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (CurrentGodownDepartmentID != "")
                    queries[queries.Length - 1] += ",'" + CurrentGodownDepartmentID + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.BagsType.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.BagsType.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ConesPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.ConesPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.LbsPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.LbsPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Counts.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Counts.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Ply.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Ply.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Blends.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Blends.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Brand.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Brand.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Desc.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Desc.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Color.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Color.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Bags.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Bags.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Lbs.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Lbs.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Cones.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Cones.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ")";

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
                    this.Suffix.Text = "";
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                   
                    this.LotNumber.EditValue = null;
                    this.Remarks.EditValue = null;
               
                    this.ArticleShortName.EditValue = null;
                    this.PONO.EditValue = null;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.dxYarn dxNewYarn = new UserControls.dxYarn();
                    if (this.GodownID.EditValue != null)
                        dxNewYarn.GodownID = this.GodownID.EditValue.ToString();
                    if (this.PONO.EditValue != null)
                        dxNewYarn.PONO = this.PONO.EditValue.ToString();
                    this.tableLayoutPanel_Detail.Controls.Add(dxNewYarn);
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
            string GRNtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete GRN # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
          

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_YarnDetail where GRNGIN='"+GRNtoUpdate+"'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_Yarn where GRNGIN='" + GRNtoUpdate + "'";
            

           
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
                    this.Print.Tag = "";
                    this.Suffix.Text = "";
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                  
                    this.LotNumber.EditValue = null;
                    this.Remarks.EditValue = null;
                  
                    this.PONO.EditValue = null;
                    this.ArticleShortName.EditValue = null;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.dxYarn dxNewYarn = new UserControls.dxYarn();
                    if (this.GodownID.EditValue != null)
                        dxNewYarn.GodownID = this.GodownID.EditValue.ToString();
                    if (this.PONO.EditValue != null)
                        dxNewYarn.PONO = this.PONO.EditValue.ToString();
                    this.tableLayoutPanel_Detail.Controls.Add(dxNewYarn);
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Yarn_GRN_Load(object sender, EventArgs e)
        {
            
            
        }

        private void typeOfGRNID_KeyDown(object sender, KeyEventArgs e)
        {

           
        }

        private void subTypeofGRNID_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void InoutDeptID_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";
               
               
                this.Prefix.Text = N_Invoice;
                if (uiMode == UserInputMode.Add || uiMode == UserInputMode.Edit)
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
                if (uiMode == UserInputMode.Add)
                {
                  
                    GetNextInvoiceNumber();
                }
            }
        }






        private void AccountID_KeyDown_1(object sender, KeyEventArgs e)
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
                    this.PONO.EditValue = null;
                    this.ArticleShortName.EditValue = null;
                    this.AccountID.Tag = sRow.PrimeryID;
                    this.AccountID.Text = sRow.PrimeryID;
                    this.AccountName.Text = sRow.PrimaryString;
                    foreach (Control c in this.tableLayoutPanel_Detail.Controls)
                    {
                        UserControls.dxYarn y = (UserControls.dxYarn)c;
                        y.AccountID = sRow.PrimeryID;
                       
                    }

                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void Delete_Click(object sender, EventArgs e)
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

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();


           
           

            if (this.Filter_Dated.Checked == true)
            {
                if (this.Dated.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_Dated.Checked == true)
            {
                if (this.Dated.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_GRNGIN.Checked == true)
            {
                if (this.Suffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the GRN filter or enter valid GRN", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
           
            if (this.Filter_Account.Checked == true)
            {
                if (this.AccountID.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Account filter or enter valid Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.AccountID.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the GRN Account filter or enter valid GRN Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn aField = (UserControls.dxYarn)C;
                if (aField.Filter_Bags.Checked == true )
                {

                    if(aField.Bags.EditValue==null)
                    {
                        XtraMessageBox.Show("Either unselect the Bags Filter or enter valid bags quantity","Filter Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Bags.EditValue.ToString()=="")
                    {
                        XtraMessageBox.Show("Either unselect the Bags Filter or enter valid bags quantity", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
              
                }
                 if (aField.Filter_Blend.Checked == true )
                {

                    if(aField.Blends.EditValue==null)
                    {
                        XtraMessageBox.Show("Either unselect the Blend Filter or enter valid Blend","Filter Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString()=="")
                    {
                        XtraMessageBox.Show("Either unselect the Blend Filter or enter valid Blend", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
              
                }
                 if (aField.Filter_Brand.Checked == true )
                {

                    if(aField.Brand.EditValue==null)
                    {
                        XtraMessageBox.Show("Either unselect the Brand Filter or enter valid Brand","Filter Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Brand.EditValue.ToString()=="")
                    {
                        XtraMessageBox.Show("Either unselect the Brand Filter or enter valid Brand", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

              
                }
                 if (aField.Filter_Count.Checked == true )
                {

                    if(aField.Blends.EditValue==null)
                    {
                        XtraMessageBox.Show("Either unselect the Count Filter or enter valid Count","Filter Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString()=="")
                    {
                        XtraMessageBox.Show("Either unselect the Count Filter or enter valid Count", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
              
                }
                 if (aField.Filter_Desc.Checked == true )
                {

                    if(aField.Blends.EditValue==null)
                    {
                        XtraMessageBox.Show("Either unselect the Description Filter or enter valid Description","Filter Validation",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString()=="")
                    {
                        XtraMessageBox.Show("Either unselect the Description Filter or enter valid Description", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
              
                }

                }
            


            strFilterQuery = "SELECT PONO,GRNGIN,Dated,BuyerID,BuyerName,TruckRegistrationNumber,DeliveryChallanNumber,GateEntryNumber,SenderGatePassNumber,Remarks  FROM YNQ_Yarn  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' ";



            if (this.Filter_Dated.Checked == true)
            {

                strFilterQuery += " and iDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.Filter_Account.Checked == true)
            {

                strFilterQuery += " and BuyerID='" + this.AccountID.EditValue.ToString() + "'";
              
            }
            if (this.Filter_GRNGIN.Checked == true)
            {

                strFilterQuery += " and GRNGIN like '%" + this.Suffix.Text + "%'";

            }

            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn aField = (UserControls.dxYarn)C;

                if ( this.Filter_Account.Checked ==true ||  aField.Filter_Bags.Checked == true || aField.Filter_Blend.Checked == true || aField.Filter_Brand.Checked ==true || aField.Filter_Count.Checked ==true || aField.Filter_Desc.Checked ==true )
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and GRNGIN in(select GRNGIN from YN_YarnDetail where ";
                    }
                    if (aField.Filter_Bags.Checked == true)
                    {
                        SubFilter += " BagsInward=" + aField.Bags.EditValue.ToString() + "";
                        Appendand = true;
                    }
                    if (aField.Filter_Blend.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " YarnBlend='" + aField.Blends.EditValue.ToString() + "'";
                        Appendand = true;
                    }
                   
                    if (aField.Filter_Brand.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " YarnBrand='" + aField.Brand.EditValue.ToString() + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_Count.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " YarnCount='" + aField.Counts.EditValue.ToString() + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_Desc.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " YarnDesc='" + aField.Desc.EditValue.ToString() + "'";
                        Appendand = true;
                    }

                }
            }
            if (SubFilter != "")
                SubFilter += ")";
            strFilterQuery += SubFilter;
            strFilterQuery += " ORDER BY Convert(numeric(18),GRNGIN) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "GRNGIN", "GRNGIN");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_GRN(sRow.PrimeryID);

            }
        }
        private void Fill_GRN(string iNumber)
        {

            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from YNQ_Yarn where GRNGIN='" + iNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;

            if (ds_VoucherMain.Tables[0].Rows[0]["iCat"].ToString() == "G")
            {
                this.NG.Checked = false;
                
            }
            else
            {
              
                this.NG.Checked = true;
            }
            
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString();
             this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(7, 6);
             this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(7, 6); ;
             this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iType"].ToString();
             this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iYear"].ToString();
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(0, 3);
                        this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
           
          
           
         
            
            try
            {
                this.Dated.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            if (ds_VoucherMain.Tables[0].Rows[0]["DeliveryChallanNumber"].ToString() != "")
            {
               
            }
            if (ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString() != "")
            {
                this.AccountID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString();
                this.AccountName.EditValue = ds_VoucherMain.Tables[0].Rows[0]["BuyerName"].ToString();
            }
            else
            {
                this.AccountID.EditValue = null;
                this.AccountName.EditValue = null;
            }
            if (ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString() != "")
            {
                this.ArticleShortName.EditValue = ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString();
               
            }
            else
            {
                this.ArticleShortName.EditValue = null;
                
            }
           
            if (ds_VoucherMain.Tables[0].Rows[0]["GodownID"].ToString() != "")
                this.GodownID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["GodownID"].ToString();
            else
                this.GodownID.EditValue = null;
           this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();


            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from YN_YarnDetail where GRNGIN='" + iNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_Detail.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.dxYarn ysub = new UserControls.dxYarn();
               
                this.tableLayoutPanel_Detail.Controls.Add(ysub);
                if (this.PONO.EditValue != null)
                    ysub.PONO = this.PONO.EditValue.ToString();
                if (this.GodownID.EditValue != null)
                    ysub.GodownID = this.GodownID.EditValue.ToString();
                ysub.BagsType.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBagsType"].ToString();
                ysub.Counts.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnCount"].ToString();
                ysub.Blends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBlend"].ToString();
                ysub.Ply.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnPly"].ToString();
                ysub.Desc.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnDesc"].ToString();
                ysub.Brand.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBrand"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[x]["YarnColor"].ToString() != "")
                    ysub.Color.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnColor"].ToString();
                else
                    ysub.Color.EditValue = null;
                this.PONO.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["PONO"].ToString();
                //this.ArticleShortName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["ArticleShortName"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[x]["YCC"].ToString() != "")
                    this.YarnContract.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YCC"].ToString();
                else
                    this.YarnContract.EditValue = null;


               ysub.LbsPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnLbsperBag"].ToString();
               ysub.ConesPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnConesPerBag"].ToString();
               ysub.Bags.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BagsInward"].ToString();
               ysub.Lbs.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["LbsInward"].ToString();

               ysub.Cones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["ConesInward"].ToString();


            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }

        private void YarnContract_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control == true & e.KeyCode == Keys.Enter)
                {
                    string strFilterQuery = "SELECT YarnContractNumber,ContractDate,YarnSupplierName,YarnSpecs,QtyBags,WeightLbs,BagsReceived,LbsReceived  FROM qYN_YarnContracts   ";
                    strFilterQuery += "  where cType='001' ";



                    selectedrow sRow = new selectedrow();
                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.Load_View(strFilterQuery, "YarnContractNumber", "YarnSupplierName");
                    FrmView.sRow = sRow;
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;




                        FillYarnContract(sRow.PrimeryID);


                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillYarnContract(string ContractNumber)
        {
            try
            {
                
                DataSet ds = WS.svc.Get_DataSet("Select * from qYN_YarnContracts where YarnContractNumber='" + ContractNumber + "'");
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;

                this.YarnContract.EditValue = ContractNumber;
                this.YCC_YarnSpecs.Text = ds.Tables[0].Rows[0]["YarnSpecs"].ToString();
               
                this.YCC_YarnSupplier.Text = ds.Tables[0].Rows[0]["YarnSupplierName"].ToString();
                
                this.tableLayoutPanel_Detail.Controls.Clear();
                UserControls.dxYarn nYarn = new UserControls.dxYarn();
                this.tableLayoutPanel_Detail.Controls.Add(nYarn);
                if (this.PONO.EditValue != null)
                    nYarn.PONO = this.PONO.EditValue.ToString();
                if (this.GodownID.EditValue != null)
                    nYarn.GodownID = this.GodownID.EditValue.ToString();
                nYarn.LbsPerBag.EditValue = ds.Tables[0].Rows[0]["YarnLbsPerBag"].ToString();
                nYarn.ConesPerBag.EditValue = ds.Tables[0].Rows[0]["YarnConesPerBag"].ToString();
                nYarn.Counts.EditValue = ds.Tables[0].Rows[0]["YarnCount"].ToString();
                nYarn.Brand.EditValue = ds.Tables[0].Rows[0]["YarnBrand"].ToString();
                nYarn.Ply.EditValue = ds.Tables[0].Rows[0]["Ply"].ToString();
                nYarn.Blends.EditValue = ds.Tables[0].Rows[0]["YarnBlend"].ToString();
                nYarn.Desc.EditValue = ds.Tables[0].Rows[0]["YarnDescription"].ToString();
                nYarn.BagsType.EditValue = "Fresh";
                nYarn.CanChangeSpecs = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        private void Print_Click(object sender, EventArgs e)
        {
            if (Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid GRN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid GRN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataSet ds = WS.svc.Get_DataSet("Select * from qp_Yarn where GRNGIN='" + this.Print.Tag.ToString() + "'");
            Reports.YarnGRN PrintGRN = new Reports.YarnGRN();
            PrintGRN.BeginInit();
            if (RadioPageSetting.EditValue.ToString() == "H")
            {

                PrintGRN.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                PrintGRN.PageHeight = PrintGRN.PageHeight / 2;
               
            }
            PrintGRN.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null)
                PrintGRN.DataSource = ds;
            else
                PrintGRN.DataSource = null;
            PrintGRN.EndInit();
            PrintGRN.ShowPreview();

        }

        private void ClearYCC_Click(object sender, EventArgs e)
        {
            this.YarnContract.Text = "";
            this.YarnContract.Tag = "";
           
            this.YCC_YarnSpecs.Text = "";
            this.YCC_YarnSupplier.Text = "";
        }

        private void NG_CheckedChanged_1(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";


                this.Prefix.Text = N_Invoice;
                if (uiMode == UserInputMode.Add || uiMode == UserInputMode.Edit)
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
                if (uiMode == UserInputMode.Add)
                {

                    GetNextInvoiceNumber();
                }
            }
        }

        
        private void PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                string query="";
                if(this.AccountID.EditValue!=null)
                query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS from RFC_PO where POStatusID=0 and BuyerID='"+this.AccountID.EditValue.ToString()+"'";
                else
                    query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS from RFC_PO where POStatusID=0 ";
               
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
                    this.AccountID.EditValue = sRow.PrimaryString;

                    try
                    {
                        this.AccountName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                        this.ArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();
                      

                    }
                    catch
                    {
                    }

                }



            }
        }

        private void AccountID_EditValueChanged(object sender, EventArgs e)
        {
            //if (AccountID.EditValue != null)
            //{
            //    string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.AccountID.EditValue.ToString());
            //    if (mAcID != "")
            //    {

            //        this.AccountID.EditValue = mAcID;
            //        this.PONO.EditValue = null;
            //        this.ArticleShortName.EditValue = null;
            //    }
            //    else
            //    {
            //        this.AccountID.EditValue = null;
            //        this.PONO.EditValue = null;
            //        this.ArticleShortName.EditValue = null;
            //    }
            //}
            //else
            //{
            //    this.PONO.EditValue = null;
            //    this.ArticleShortName.EditValue = null;
            //}
        }

        private void YarnSelectionGroup_EditValueChanged(object sender, EventArgs e)
        {
            if (PONO.EditValue == null) return;
            FillYarnInfoFromPO(this.PONO.EditValue.ToString(), (YarnSelectionMode)Convert.ToInt32(this.YarnSelectionGroup.EditValue.ToString()));
        }

        private void GodownID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.GodownID.EditValue == null) return;
            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn yarncontrol = (UserControls.dxYarn)C;
                yarncontrol.GodownID = this.GodownID.EditValue.ToString();
            }
        }

        private void PONO_EditValueChanged(object sender, EventArgs e)
        {
            if (this.PONO.EditValue == null) return;
            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn yarncontrol = (UserControls.dxYarn)C;
                yarncontrol.PONO = this.PONO.EditValue.ToString();
            }
        }
    }
}