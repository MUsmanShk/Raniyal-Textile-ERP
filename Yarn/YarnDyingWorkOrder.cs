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
    public partial class YarnDyingWorkOrder: DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        public YarnDyingWorkOrder()
        {
            InitializeComponent();
            
            G_Invoice = "007";
            N_Invoice = "017";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;

            this.ProgramDate.DateTime = DateTime.Now;
            this.RequiredDate.DateTime = DateTime.Now;
            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());
            FillCombos fc = new FillCombos();
            fc.Departments_Sub(ref this.Department);

        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(YDWNO,8,6)))+1 as MaxNumber  from FC_PO_YarnDyingWorkOrder where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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

            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());

            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState("U"));
            this.Suffix.Text = "";
            this.Suffix.Text = "";







            bool rRes = GetNextInvoiceNumber();
            if (rRes != false)
                SetButtonStates(UserInputMode.Add);
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


            if (this.ProgramDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }
            if (this.ProgramDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }
            if (this.ProgramDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }

            if (this.Party.Tag == null)
            {
                XtraMessageBox.Show("invalid party", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.REFPONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Referenced PO", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.REFPONO.Focus();
                return;
            }
            if (this.YarnDyingCompanyID.EditValue == null || this.YarnDyingCompanyID.Tag == null)
            {
                XtraMessageBox.Show("invalid sizing company", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.YarnDyingCompanyID.Focus();
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
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;

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
                if (AField.Ends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Ends ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Desc.Focus();
                    return;
                }
            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into FC_PO_Main (NumberType,POTypeID,PONumber,iType,iCat,iYear,iStatus,Dated,BuyerID,cUserId,cUserTime) Values (";
            queries[queries.Length - 1] += "0,'14','" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
            if (this.ProgramDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.YarnDyingCompanyID.EditValue != null && this.YarnDyingCompanyID.Tag!=null)
                queries[queries.Length - 1] += ",'" + this.YarnDyingCompanyID.Tag.ToString()+ "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into FC_PO_YarnDyingWorkOrder (YDWNO,iType,iCat,iYear,iStatus,ProgramDate,RefPONO,RequiredDate,AttentionTo,RequiredColor,DeptID,Remarks,cUserId,cUserTime) Values (";
            queries[queries.Length - 1] += "'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
            if (this.ProgramDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.REFPONO.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.REFPONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RequiredDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.RequiredDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
          
            if (this.Attention.Text != "")
                queries[queries.Length - 1] += ",'" + this.Attention.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
           
            if (this.RequiredColor.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RequiredColor.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
           
            if (this.Department.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Department.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
          
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into FC_PO_YarnDyingWorkOrder_Sub (YDWNO,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,Bags,Lbs,Cones,Ends,Remarks) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";


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
                if (AField.Bags.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Bags.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Lbs.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Lbs.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Cones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Cones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Ends.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Ends.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
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
                    this.REFPONO.EditValue = null;
                    this.RefArticleShortName.EditValue = null; 
                    this.Remarks.Text = "";
                    this.YarnDyingCompanyID.Tag = null;
                    this.YarnDyingCompanyID.EditValue = null;
                    this.RequiredColor.EditValue = null;
                    
                   
                    this.Department.EditValue = null;
                  

                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());
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
            int esuffix = 0;
            if (Int32.TryParse(this.Suffix.Text, out esuffix) == false)
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


            if (this.ProgramDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }
            if (this.ProgramDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }
            if (this.ProgramDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ProgramDate.Focus();
                return;
            }
            if (this.Party.Tag == null)
            {
                XtraMessageBox.Show("invalid party", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.REFPONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Referenced PO", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.REFPONO.Focus();
                return;
            }
            if (this.YarnDyingCompanyID.EditValue == null || this.YarnDyingCompanyID.Tag == null)
            {
                XtraMessageBox.Show("invalid sizing company", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.YarnDyingCompanyID.Focus();
                return;
            }



            string[] queries = new string[0];
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            string vnumtoupdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
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
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;

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
                if (AField.Ends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Ends ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Desc.Focus();
                    return;
                }
            }


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update FC_PO_Main  set ";
            queries[queries.Length - 1] += "PONumber='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.ProgramDate.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";
            if (this.YarnDyingCompanyID.EditValue != null && this.YarnDyingCompanyID.Tag!=null)
                queries[queries.Length - 1] += ",BuyerID='" + this.YarnDyingCompanyID.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",BuyerID=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PONumber='" + vnumtoupdate + "'";
           

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update FC_PO_YarnDyingWorkOrder  set ";
            queries[queries.Length - 1] += "YDWNO='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.ProgramDate.EditValue != null)
                queries[queries.Length - 1] += ",ProgramDate='" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",ProgramDate=null";
            if (this.REFPONO.EditValue != null)
                queries[queries.Length - 1] += ",REFPONO='" + this.REFPONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",REFPONO=null";
            if (this.RequiredDate.EditValue != null)
                queries[queries.Length - 1] += ",RequiredDate='" + this.RequiredDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",RequiredDate=null";

         
            if (this.RequiredColor.EditValue != null)
                queries[queries.Length - 1] += ",requiredColor='" + this.RequiredColor.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",requiredColor=null";
          
           
           
            if (this.Department.EditValue != null)
                queries[queries.Length - 1] += ",DeptID='" + this.Department.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",DeptID=null";
          
            if (this.Attention.Text != "")
                queries[queries.Length - 1] += ",AttentionTo='" + this.Attention.Text + "'";
            else
                queries[queries.Length - 1] += ",AttentionTo=null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where SWONO='" + vnumtoupdate + "'";

            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from FC_PO_YarnDyingWorkOrder_Sub where YDWNO='" + vnumtoupdate + "'";
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into FC_PO_YarnDyingWorkOrder_Sub (YDWNO,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,Bags,Lbs,Cones,Ends,Remarks) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";


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
                if (AField.Bags.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Bags.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Lbs.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Lbs.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Cones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Cones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Ends.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Ends.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
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
                    this.REFPONO.EditValue = null;
                    this.RefArticleShortName.EditValue = null;
                    this.Remarks.Text = "";
                  
                    this.YarnDyingCompanyID.Tag = null;
                    this.YarnDyingCompanyID.EditValue = null;
                    this.RequiredColor.EditValue = null;
                   
                    this.Attention.Text = "";
                  
                    this.Department.EditValue = null;
      
                
                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());
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
            string ProgNumber = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Program Number # " + ProgNumber + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_YarnDyingWorkOrder_Sub where YDWNO='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_YarnDyingWorkOrder where YDWNO='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_Main where PONumber='" + ProgNumber + "'";


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

                    this.Suffix.Text = "";

                    this.Print.Tag = "";
                    this.Suffix.Tag = "";
                    this.Prefix.Tag = "";
                    this.FinancialYear.Tag = "";
                    this.Suffix.Text = "";
                    this.RefArticleShortName.EditValue = null;
                    this.Remarks.Text = "";
                    this.REFPONO.EditValue = null;
                    this.YarnDyingCompanyID.Tag = null;
                    this.YarnDyingCompanyID.EditValue = null;
                    this.RequiredColor.EditValue = null;
          
                    this.Attention.Text = "";
                    this.Department.EditValue = null;
        
                  
                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
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

       

      
       
      

       

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.FilterProgDate.Checked == true)
            {
                if (this.ProgramDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.FilterRequiredDate.Checked == true)
            {
                if (this.RequiredDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.FilterProgNumber.Checked == true)
            {
                if (this.Suffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Program Number filter or enter valid Program Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            
           
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping aField = (UserControls.dxYarnWarping)C;
                if (aField.Filter_Bags.Checked == true)
                {

                    if (aField.Bags.EditValue == null)
                    {
                        XtraMessageBox.Show("Either unselect the Bags Filter or enter valid bags quantity", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Bags.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Either unselect the Bags Filter or enter valid bags quantity", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                if (aField.Filter_Blend.Checked == true)
                {

                    if (aField.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("Either unselect the Blend Filter or enter valid Blend", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Either unselect the Blend Filter or enter valid Blend", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                if (aField.Filter_Brand.Checked == true)
                {

                    if (aField.Brand.EditValue == null)
                    {
                        XtraMessageBox.Show("Either unselect the Brand Filter or enter valid Brand", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Brand.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Either unselect the Brand Filter or enter valid Brand", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                }
                if (aField.Filter_Count.Checked == true)
                {

                    if (aField.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("Either unselect the Count Filter or enter valid Count", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Either unselect the Count Filter or enter valid Count", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                if (aField.Filter_Desc.Checked == true)
                {

                    if (aField.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("Either unselect the Description Filter or enter valid Description", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (aField.Blends.EditValue.ToString() == "")
                    {
                        XtraMessageBox.Show("Either unselect the Description Filter or enter valid Description", "Filter Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

            }



            strFilterQuery = "SELECT PONumber,Dated,BuyerName  FROM RFC_PO_Main  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' and iStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' ";



            if (this.FilterProgDate.Checked == true)
            {

                strFilterQuery += " and Dated='" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }
           
           

           
          
            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping aField = (UserControls.dxYarnWarping)C;

                if (aField.Filter_Bags.Checked == true || aField.Filter_Blend.Checked == true || aField.Filter_Brand.Checked == true || aField.Filter_Count.Checked == true || aField.Filter_Desc.Checked == true || aField.FilterEnds.Checked == true)
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and PONumber in(select YDWNO from FC_PO_YarnDyingWorkOrder_Sub where ";
                    }
                    if (aField.Filter_Bags.Checked == true)
                    {
                        SubFilter += " Bags=" + aField.Bags.EditValue.ToString() + "";
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
                    if (aField.FilterEnds.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " Ends=" + aField.Ends.EditValue.ToString() + "";
                        Appendand = true;
                    }
                }
            }
            if (SubFilter != "")
                SubFilter += ")";
            strFilterQuery += SubFilter;
            strFilterQuery += " ORDER BY Convert(numeric(18),PONumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "PONumber", "PONumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
               Fill_ProgramSheet(sRow.PrimeryID);

            }
        }
        private void Fill_ProgramSheet(string WarpProgNumber)
        {
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from RFC_PO_YarnDyingWorkOrder where YDWNO='" + WarpProgNumber + "'");
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
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["YDWNO"].ToString();
            this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["YDWNO"].ToString().Substring(7, 6);
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["YDWNO"].ToString().Substring(7, 6); ;
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iType"].ToString();
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iYear"].ToString();
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["YDWNO"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["YDWNO"].ToString().Substring(0, 3);
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
         
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            this.Attention.Text = ds_VoucherMain.Tables[0].Rows[0]["AttentionTo"].ToString();
            this.REFPONO.EditValue = ds_VoucherMain.Tables[0].Rows[0]["REFPONO"].ToString();
            this.RefArticleShortName.Text = ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString();
            this.Party.Text = ds_VoucherMain.Tables[0].Rows[0]["POPartyName"].ToString();
            this.Party.Tag = ds_VoucherMain.Tables[0].Rows[0]["POPartyID"].ToString();
           
            this.RequiredColor.EditValue = ds_VoucherMain.Tables[0].Rows[0]["RequiredColor"].ToString();
         


            if (ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString() != "")
            {
                this.YarnDyingCompanyID.Tag = ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString();
                this.YarnDyingCompanyID.Text = MachineEyes.Classes.Accounting.Get_MappedAccount(this.YarnDyingCompanyID.Tag.ToString());
            }
            else
            {
                this.YarnDyingCompanyID.Tag = null;
                this.YarnDyingCompanyID.EditValue = null;
            }

          


            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
            
         
           if (ds_VoucherMain.Tables[0].Rows[0]["DeptID"].ToString() != "")
               this.Department.EditValue = ds_VoucherMain.Tables[0].Rows[0]["DeptID"].ToString();
           else
               this.Department.EditValue  = null;
          
            try
            {
                this.ProgramDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["ProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

            try
            {
                this.RequiredDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["RequiredDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }




            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from FC_PO_YarnDyingWorkOrder_Sub where YDWNO='" + WarpProgNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.dxYarnWarping ysub = new UserControls.dxYarnWarping();

                this.tableLayoutPanel_YarnInfo.Controls.Add(ysub);
                ysub.BagsType.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBagsType"].ToString();
                ysub.Counts.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnCount"].ToString();
                ysub.Blends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBlend"].ToString();
                ysub.Ply.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnPly"].ToString();
                ysub.Desc.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnDesc"].ToString();
                ysub.Brand.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBrand"].ToString();
                ysub.LbsPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnLbsperBag"].ToString();
                ysub.ConesPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnConesPerBag"].ToString();
                ysub.Bags.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Bags"].ToString();
                ysub.Lbs.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Lbs"].ToString();
                ysub.Cones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Cones"].ToString();
                ysub.Ends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Ends"].ToString();
                ysub.Remarks.Text = ds_VoucherSub_T.Tables[0].Rows[x]["Remarks"].ToString();

            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
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
            MachineEyes.Classes.Printing.Print_FC_PO_YarnDyingWorkOrder(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

       

      



        private void SizingCompanyID_KeyDown(object sender, KeyEventArgs e)
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
                    this.YarnDyingCompanyID.Tag = sRow.PrimeryID;
                    this.YarnDyingCompanyID.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void Party_KeyDown(object sender, KeyEventArgs e)
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
                    this.Party.Tag = sRow.PrimeryID;
                    this.Party.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void REFPONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                string query = "";
                if (this.Party.EditValue != null && this.Party.Tag!=null)
                    query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS from RFC_PO where POStatusID=0 and BuyerID='" + this.Party.Tag.ToString() + "'";
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
                    this.REFPONO.EditValue = sRow.PrimeryID;
                    
                    this.Party.Tag  = sRow.PrimaryString;

                    try
                    {
                        this.Party.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                        this.RefArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();


                    }
                    catch
                    {
                    }

                }



            }
        }
    }
}