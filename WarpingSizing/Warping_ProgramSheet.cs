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
    public partial class Warping_ProgramSheet : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        public Warping_ProgramSheet()
        {
            InitializeComponent();
            this.Prefix.Text = "101";
            G_Invoice = "101";
            N_Invoice = "111";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;

            this.ProgramDate.DateTime = DateTime.Now;
            this.RequiredDate.DateTime = DateTime.Now;
            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarping());
        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(WarpProgNumber,8,6)))+1 as MaxNumber  from SW_ProgramSheet where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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

            if (this.PONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PO / Work Order #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.PONO.Focus();
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
            queries[queries.Length - 1] = "insert into SW_ProgramSheet (WarpTypeID,WarpProgNumber,iType,iCat,iYear,iStatus,ProgramDate,RequiredDate,WarpingCompany,AttentionTo,BeamType,BeamSpace,BeamLength,FledgeDia,NoOfBeams,PartyID,PONO,ArticleNumber,DeptWarpedFor,Remarks,FCC,cUserId,cUserTime) Values (";
            queries[queries.Length - 1] += "'"+this.RadioWarpType.EditValue.ToString()+"','" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
            if (this.ProgramDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.RequiredDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.RequiredDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.WarpingCompany.Tag != null)
                queries[queries.Length - 1] += ",'" + this.WarpingCompany.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Attention.Text != "")
                queries[queries.Length - 1] += ",'" + this.Attention.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.BeamType.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.BeamType.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.BeamSpace.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.BeamSpace.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.BeamLength.EditValue != null)
                queries[queries.Length - 1] += "," + this.BeamLength.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.FledgeDia.EditValue != null)
                queries[queries.Length - 1] += "," + this.FledgeDia.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.BeamsTotal.EditValue != null)
                queries[queries.Length - 1] += "," + this.BeamsTotal.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PartyID.Tag != null)
                queries[queries.Length - 1] += ",'" + this.PartyID.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PONO.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ArticleNumber.Tag != null)
                queries[queries.Length - 1] += ",'" + this.ArticleNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.DepartmentWarpedFor.Tag != null)
                queries[queries.Length - 1] += ",'" + this.DepartmentWarpedFor.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.FabricContractNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.FabricContractNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_ProgramSheet_Sub (WarpProgNumber,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,Bags,Lbs,Cones,Ends,Remarks) Values (";
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
                    this.FabricContractNumber.EditValue = null;
                    this.Remarks.Text = "";
                    this.WarpingCompany.EditValue = null;
                    this.WarpingCompany.Tag = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.BeamsTotal.EditValue = null;
                    this.BeamSpace.EditValue = null;
                    this.BeamLength.EditValue = null;
                    this.BeamType.EditValue = null;
                    this.Attention.Text = "";
                    this.FledgeDia.EditValue = null;
                    this.ArticleNumber.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.DepartmentWarpedFor.EditValue = null;
                    this.DepartmentWarpedFor.Tag = null;

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

            if (this.PONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PO / Work Order #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.PONO.Focus();
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
            queries[queries.Length - 1] = "update SW_ProgramSheet  set ";
            queries[queries.Length - 1] += " WarpTypeID='" + this.RadioWarpType.EditValue.ToString() + "',WarpProgNumber='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.ProgramDate.EditValue != null)
                queries[queries.Length - 1] += ",ProgramDate='" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",ProgramDate=null";
            if (this.RequiredDate.EditValue != null)
                queries[queries.Length - 1] += ",RequiredDate='" + this.RequiredDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",RequiredDate=null";

            if (this.BeamLength.EditValue  != null)
                queries[queries.Length - 1] += ",BeamLength=" + this.BeamLength.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",BeamLength=null";
            if (this.BeamSpace.EditValue != null)
                queries[queries.Length - 1] += ",BeamSpace='" + this.BeamSpace.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",BeamSpace=null";
            if (this.BeamType.EditValue != null)
                queries[queries.Length - 1] += ",BeamType='" + this.BeamType.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",BeamType=null";
            if (this.BeamsTotal.EditValue != null)
                queries[queries.Length - 1] += ",NoofBeams=" + this.BeamsTotal.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",NoofBeams=null";
            if (this.FledgeDia.EditValue != null)
                queries[queries.Length - 1] += ",FledgeDia=" + this.FledgeDia.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",FledgeDia=null";
            if (this.WarpingCompany.Tag != null)
                queries[queries.Length - 1] += ",WarpingCompany='" + this.WarpingCompany.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",WarpingCompany=null";
            if (this.PartyID.Tag != null)
                queries[queries.Length - 1] += ",PartyID='" + this.PartyID.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PartyID=null";
            if (this.PONO.EditValue != null)
                queries[queries.Length - 1] += ",PONO='" + this.PONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO=null";
            if (this.ArticleNumber.Tag != null)
                queries[queries.Length - 1] += ",ArticleNumber='" + this.ArticleNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ArticleNumber=null";
            if (this.DepartmentWarpedFor.Tag != null)
                queries[queries.Length - 1] += ",DeptWarpedFor='" + this.DepartmentWarpedFor.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",DeptWarpedFor=null";
            if (this.FabricContractNumber.EditValue != null)
                queries[queries.Length - 1] += ",FCC='" + this.FabricContractNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",FCC=null";
            if (this.Attention.Text != "")
                queries[queries.Length - 1] += ",AttentionTo='" + this.Attention.Text + "'";
            else
                queries[queries.Length - 1] += ",AttentionTo=null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where WarpProgNumber='" + vnumtoupdate + "'";

            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from SW_ProgramSheet_Sub where WarpProgNumber='" + vnumtoupdate + "'";
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarping AField = (UserControls.dxYarnWarping)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_ProgramSheet_Sub (WarpProgNumber,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,Bags,Lbs,Cones,Ends,Remarks) Values (";
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
                    this.FabricContractNumber.EditValue = null;
                    this.Remarks.Text = "";
                    this.WarpingCompany.EditValue = null;
                    this.WarpingCompany.Tag = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.BeamsTotal.EditValue = null;
                    this.BeamSpace.EditValue = null;
                    this.BeamLength.EditValue = null;
                    this.BeamType.EditValue = null;
                    this.Attention.Text = "";
                    this.ArticleNumber.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.DepartmentWarpedFor.EditValue = null;
                    this.DepartmentWarpedFor.Tag = null;
                    this.FledgeDia.EditValue = null;
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
            queries[queries.Length - 1] = "delete from SW_ProgramSheet_Sub where WarpProgNumber='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_ProgramSheet where WarpProgNumber='" + ProgNumber + "'";
            


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
                    this.FabricContractNumber.EditValue = null;
                    this.Remarks.Text = "";
                    this.WarpingCompany.EditValue = null;
                    this.WarpingCompany.Tag = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.BeamsTotal.EditValue = null;
                    this.BeamSpace.EditValue = null;
                    this.BeamLength.EditValue = null;
                    this.BeamType.EditValue = null;
                    this.Attention.Text = "";
                    this.ArticleNumber.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.DepartmentWarpedFor.EditValue = null;
                    this.DepartmentWarpedFor.Tag = null;
                    this.FledgeDia.EditValue = null;
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

        private void WarpingCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select DAccountID,DAccountName from YN_InoutDAccounts  Where InoutDeptID='"+Departments.InOutDeptID_Sizing+"' order by DAccountName", "DAccountID", "DAccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.WarpingCompany.Tag = sRow.PrimeryID;
                    this.WarpingCompany.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void BeamType_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select BeamType from SW_BeamTypes ", "BeamType", "BeamType");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.BeamType.Tag = sRow.PrimeryID;
                    this.BeamType.EditValue = sRow.PrimeryID;


                }
            }
        }

        private void PartyID_KeyDown(object sender, KeyEventArgs e)
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
                    this.PartyID.Tag = sRow.PrimeryID;
                    this.PartyID.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ArticleView == null) Program.MainWindow.ArticleView = new Data_Article_Main_View();
                Program.MainWindow.ArticleView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.ArticleNumber.Tag = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                        this.ArticleNumber.EditValue = Program.MainWindow.ArticleView.SelectedRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DepartmentWarpedFor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select DAccountID,DAccountName from YN_InoutDAccounts  Where InoutDeptID='" + Departments.InOutDeptID_Weaving + "' order by DAccountName", "DAccountID", "DAccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.DepartmentWarpedFor.Tag = sRow.PrimeryID;
                    this.DepartmentWarpedFor.EditValue = sRow.PrimaryString;

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
            if (this.FilterArticleNumber.Checked == true)
            {
                if (this.ArticleNumber.Tag == null)
                {
                    XtraMessageBox.Show("Either uncheck the Article Number filter or enter valid Article", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.ArticleNumber.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Article Number filter or enter valid Article Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (this.FilterWarpAccountFor.Checked == true)
            {
                if (this.PartyID.Tag  == null)
                {
                    XtraMessageBox.Show("Either uncheck the Party filter or enter valid party Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.PartyID.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Party Account filter or enter valid Party Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (this.FilterWarpingCompany.Checked == true)
            {
                if (this.WarpingCompany.Tag == null)
                {
                    XtraMessageBox.Show("Either uncheck the Warping Company filter or enter valid Warping Company", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.WarpingCompany.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Warping Company filter or enter valid Warping Company", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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



            strFilterQuery = "SELECT WarpProgNumber,ProgramDate,AccountName,ArticleShortName,FCC  FROM SWQ_ProgramSheet  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' and iStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' and WarpTypeID='"+this.RadioWarpType.EditValue.ToString()+"' ";



            if (this.FilterProgDate.Checked == true)
            {

                strFilterQuery += " and ProgramDate='" + this.ProgramDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }
            if (this.FilterRequiredDate.Checked == true)
            {

                strFilterQuery += " and RequiredDate='" + this.RequiredDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }
            if (this.FilterProgNumber.Checked == true)
            {

                strFilterQuery += " and WarpProgNumber like '%" + this.Suffix.Text + "'%";

            }

            if (this.FilterArticleNumber.Checked == true)
            {

                strFilterQuery += " and ArticleNumber='" + this.ArticleNumber.Tag.ToString() + "'";

            }
            if (this.FilterWarpAccountFor.Checked == true)
            {

                strFilterQuery += " and PartyID='" + this.PartyID.Tag.ToString() + "'";

            }
            if (this.FilterWarpAccountFor.Checked == true)
            {

                strFilterQuery += " and PartyID='" + this.PartyID.Tag.ToString() + "'";

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

                        SubFilter = " and WarpProgNumber in(select WarpProgNumber from SW_ProgramSheet_Sub where ";
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
            strFilterQuery += " ORDER BY Convert(numeric(18),WarpProgNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "WarpProgNumber", "WarpProgNumber");
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
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from SWQ_ProgramSheet where WarpProgNumber='" + WarpProgNumber + "'");
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
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpProgNumber"].ToString();
            this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpProgNumber"].ToString().Substring(7, 6);
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpProgNumber"].ToString().Substring(7, 6); ;
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iType"].ToString();
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iYear"].ToString();
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpProgNumber"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpProgNumber"].ToString().Substring(0, 3);
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            this.Attention.Text = ds_VoucherMain.Tables[0].Rows[0]["AttentionTo"].ToString();
            this.RadioWarpType.EditValue = ds_VoucherMain.Tables[0].Rows[0]["WarpTypeID"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString() != "")
                this.ArticleNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString();
            else
                this.ArticleNumber.Tag = null;
            this.ArticleNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString();
            this.BeamType.Text = ds_VoucherMain.Tables[0].Rows[0]["BeamType"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["BeamType"].ToString() != "")
                this.BeamType.Tag = ds_VoucherMain.Tables[0].Rows[0]["BeamType"].ToString();
            else
                this.BeamType.Tag = null;
            this.BeamSpace.EditValue = ds_VoucherMain.Tables[0].Rows[0]["BeamSpace"].ToString();
            this.BeamsTotal.EditValue = ds_VoucherMain.Tables[0].Rows[0]["NoOfBeams"].ToString();
            this.BeamLength.EditValue = ds_VoucherMain.Tables[0].Rows[0]["BeamLength"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["PartyID"].ToString() != "")
                this.PartyID.Tag = ds_VoucherMain.Tables[0].Rows[0]["PartyID"].ToString();
            else
                this.PartyID.Tag = null;
            if (ds_VoucherMain.Tables[0].Rows[0]["PONO"].ToString() != "")
                this.PONO.EditValue= ds_VoucherMain.Tables[0].Rows[0]["PONO"].ToString();
            else
                this.PONO.EditValue= null;
            this.PartyID.Text = ds_VoucherMain.Tables[0].Rows[0]["AccountName"].ToString();
            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["WarpingCompany"].ToString() != "")
                this.WarpingCompany.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingCompany"].ToString();
            else
                this.WarpingCompany.Tag = null;
           this.WarpingCompany.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpingCompanyName"].ToString();
           if (ds_VoucherMain.Tables[0].Rows[0]["DeptWarpedFor"].ToString() != "")
               this.DepartmentWarpedFor.Tag = ds_VoucherMain.Tables[0].Rows[0]["DeptWarpedFor"].ToString();
           else
               this.DepartmentWarpedFor.Tag = null;
           this.DepartmentWarpedFor.Text = ds_VoucherMain.Tables[0].Rows[0]["DeptWarpedForName"].ToString();
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

           


            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SW_ProgramSheet_Sub where WarpProgNumber='" + WarpProgNumber + "'");
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
            MachineEyes.Classes.Printing.Print_SW_ProgramSheet(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void FledgeDia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select FledgeDia from SW_BeamFledgeDia ", "FledgeDia", "FledgeDia");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.FledgeDia.Tag = sRow.PrimeryID;
                    this.FledgeDia.EditValue = sRow.PrimeryID;


                }
            }
        }

        private void PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter && RadioWarpType.EditValue.ToString()=="0" )
            {

                string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS from RFC_PO where POStatusID=0";

                if (this.PartyID.EditValue != null && this.PartyID.Tag != null)
                {

                    query += " and ";

                    query += " BuyerID='" + this.PartyID.Tag.ToString() + "'";
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


                    try
                    {
                        this.PartyID.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                        this.ArticleNumber.Tag = sRow.SelectedDataRow["ArticleNumber"].ToString();
                        this.ArticleNumber.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();
                        // this.PartyID.Tag = sRow.SelectedDataRow["ArticleNumber"].ToString();
                        // this.ArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();
                    }
                    catch
                    {
                    }

                }



            }
            else if (e.Control == true && e.KeyCode == Keys.Enter && this.RadioWarpType.EditValue.ToString() == "1")
            {
                string query = "";
                if (this.PartyID.EditValue != null && this.PartyID.Tag != null)
                    query = "SELECT Distinct PONumber as PONO,BUYERID ,BuyerName from RFC_PO_Main where POStatusID=0 and POTYPEID in('12','13') and BuyerID='" + this.PartyID.Tag.ToString() + "'";
                else
                    query = "SELECT Distinct PONumber as PONO,BUYERID ,BuyerName from RFC_PO_Main where POStatusID=0 and POTYPEID in('12','13')";

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



                }



            }
        }
    }
}