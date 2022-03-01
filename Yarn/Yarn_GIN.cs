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
    public partial class Yarn_GIN : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        public Yarn_GIN()
        {
            InitializeComponent();
            this.Prefix.Text = "102";
            G_Invoice = "102";
            N_Invoice = "112";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.typeOfGRNID.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            this.tableLayoutPanel_Detail.Controls.Clear();
            this.tableLayoutPanel_Detail.Controls.Add(new UserControls.dxYarn());
        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(GRNGIN,8,6)))+1 as MaxNumber  from YN_YarnStock where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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
            this.tableLayoutPanel_Detail.Controls.Add(new UserControls.dxYarn());

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
            if (this.typeOfGRNID.Tag == null)
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfGRNID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (this.typeOfGRNID.Text == "" || this.typeofGRNName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.subTypeofGRNID.Text == "" || this.subTypeofGRNName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.fromDeptID.Text == "" || this.fromDeptName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Dept", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.fromAccountID.Text == "" || this.fromAccountName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Account from where you are going to issue yarn", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }
            if (this.toDeptID.Text == "" || this.toDeptName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Dept into where you are going to issue", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.toAccountID.Text == "" || this.toAccountName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Account to whom you are going to issue yarn", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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
            bool check = UpdateAvailableStock();
            if (check == false) return;
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into YN_YarnStock (GRNGIN,iType,iCat,iYear,iStatus,Dated,Driver,TruckregistrationNumber,DeliveryChallanNumber,InoutTypeID,YCC,FCC,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Driver.Text != "")
                queries[queries.Length - 1] += ",'" + this.Driver.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.TruckRegistrationNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.TruckRegistrationNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.DeliveryChallanNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.DeliveryChallanNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.typeOfGRNID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.typeOfGRNID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

           
          
                queries[queries.Length - 1] += ",null";
            if (this.FabricContract.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.FabricContract.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn AField = (UserControls.dxYarn)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into YN_YarnStockDetail (GRNGIN,InOutSubTypeID,InOutDeptID,AccountID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsIn,LbsIn,ConesIn,Bagsout,LbsOut,ConesOut) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.subTypeofGRNID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.subTypeofGRNID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.fromDeptID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.fromDeptID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.fromAccountID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.fromAccountID.EditValue.ToString() + "'";
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
                queries[queries.Length - 1] += ",0,0,0";

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
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into YN_YarnStockDetail (GRNGIN,InOutSubTypeID,InOutDeptID,DAccountID,AccountID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsIn,LbsIn,ConesIn,Bagsout,LbsOut,ConesOut) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.subTypeofGRNID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.subTypeofGRNID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.toDeptID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.toDeptID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.DAccountID.Tag  != null)
                    queries[queries.Length - 1] += ",'" + this.DAccountID.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.toAccountID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.toAccountID.EditValue.ToString() + "'";
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
                queries[queries.Length - 1] += ",0,0,0)";
            }



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + vnum + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','A')";
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
                    this.typeOfGRNID.EditValue = null;
                    this.typeofGRNName.EditValue = null;
                    this.subTypeofGRNID.EditValue = null;
                    this.subTypeofGRNName.EditValue = null;
                    this.fromAccountID.EditValue = null;
                    this.fromAccountName.EditValue = null;
                    this.fromDeptID.EditValue = null;
                    this.fromDeptName.EditValue = null;
                    this.toAccountID.EditValue = null;
                    this.toAccountName.EditValue = null;
                    this.toDeptID.EditValue = null;
                    this.toDeptName.EditValue = null;
                    this.DAccountID.Tag = null;
                    this.DAccountID.Text = "";
                    this.DAccountName.Text = "";
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    this.tableLayoutPanel_Detail.Controls.Add(new UserControls.dxYarn());
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
            if (this.typeOfGRNID.Tag == null)
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfGRNID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (this.typeOfGRNID.Text == "" || this.typeofGRNName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.subTypeofGRNID.Text == "" || this.subTypeofGRNName.Text == "")
            {
                XtraMessageBox.Show("Invalid Sub GIN Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.subTypeofGRNID.Focus();
                return;
            }
            if (this.fromDeptID.Text == "" || this.fromDeptName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Dept", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                return;
            }
            if (this.fromAccountID.Text == "" || this.fromAccountName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                return;
            }

            if (this.toDeptID.Text == "" || this.toDeptName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Dept", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.toAccountID.Text == "" || this.toAccountName.Text == "")
            {
                XtraMessageBox.Show("Invalid GIN Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            bool check = UpdateAvailableStock();
            if (check == false) return;

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
            queries[queries.Length - 1] = "update YN_YarnStock  set ";
            queries[queries.Length - 1] += "GRNGIN='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

            if (this.Driver.Text != "")
                queries[queries.Length - 1] += ",Driver='" + this.Driver.Text + "'";
            else
                queries[queries.Length - 1] += ",Driver=null";
            if (this.TruckRegistrationNumber.Text != "")
                queries[queries.Length - 1] += ",TruckRegistrationNumber='" + this.TruckRegistrationNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",TruckRegistrationNumber=null";

            if (this.DeliveryChallanNumber.Text != "")
                queries[queries.Length - 1] += ",DeliveryChallanNumber='" + this.DeliveryChallanNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",DeliveryChallanNumber=null";

            if (this.typeOfGRNID.EditValue != null)
                queries[queries.Length - 1] += ",InOutTypeID='" + this.typeOfGRNID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",InOutTypeID=null";

           
            queries[queries.Length - 1] += ",YCC=null";
            if (this.FabricContract.EditValue != null)
                queries[queries.Length - 1] += ",FCC='" + this.FabricContract.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",FCC=null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where GRNGIN='" + GRNtoUpdate + "'";

            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from YN_YarnStockDetail where GRNGIN='" + GRNtoUpdate + "'";

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn AField = (UserControls.dxYarn)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into YN_YarnStockDetail (GRNGIN,InOutSubTypeID,InOutDeptID,AccountID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsIn,LbsIn,ConesIn,Bagsout,LbsOut,ConesOut) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.subTypeofGRNID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.subTypeofGRNID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.fromDeptID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.fromDeptID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.fromAccountID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.fromAccountID.EditValue.ToString() + "'";
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
                queries[queries.Length - 1] += ",0,0,0";

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
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into YN_YarnStockDetail (GRNGIN,InOutSubTypeID,InOutDeptID,DAccountID,AccountID,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsIn,LbsIn,ConesIn,Bagsout,LbsOut,ConesOut) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.subTypeofGRNID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.subTypeofGRNID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.toDeptID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.toDeptID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.DAccountID.Tag != null)
                    queries[queries.Length - 1] += ",'" + this.DAccountID.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.toAccountID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.toAccountID.EditValue.ToString() + "'";
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
                queries[queries.Length - 1] += ",0,0,0)";
            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + GRNtoUpdate + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','E')";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + vnum + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','A')";
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
                    this.typeOfGRNID.EditValue = null;
                    this.typeofGRNName.EditValue = null;
                    this.subTypeofGRNID.EditValue = null;
                    this.subTypeofGRNName.EditValue = null;
                    this.fromAccountID.EditValue = null;
                    this.fromAccountName.EditValue = null;
                    this.fromDeptID.EditValue = null;
                    this.fromDeptName.EditValue = null;
                    this.toAccountID.EditValue = null;
                    this.toAccountName.EditValue = null;
                    this.toDeptID.EditValue = null;
                    this.toDeptName.EditValue = null;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    this.tableLayoutPanel_Detail.Controls.Add(new UserControls.dxYarn());
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
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete GIN # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_YarnStockDetail where GRNGIN='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_YarnStock where GRNGIN='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + GRNtoUpdate + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','D')";


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
                    this.typeOfGRNID.EditValue = null;
                    this.typeofGRNName.EditValue = null;
                    this.subTypeofGRNID.EditValue = null;
                    this.subTypeofGRNName.EditValue = null;
                    this.DAccountID.Tag = null;
                    this.DAccountID.Text = "";
                    this.DAccountName.Text = "";
                    this.fromAccountID.EditValue = null;
                    this.fromAccountName.EditValue = null;
                    this.fromDeptID.EditValue = null;
                    this.fromDeptName.EditValue = null;
                    this.toAccountID.EditValue = null;
                    this.toAccountName.EditValue = null;
                    this.toDeptID.EditValue = null;
                    this.toDeptName.EditValue = null;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    this.tableLayoutPanel_Detail.Controls.Add(new UserControls.dxYarn());
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void typeOfGRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select * from YN_InOutTypes order by InOutTypesID", "InOutTypesID", "InOutTypesName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.typeOfGRNID.Tag = sRow.PrimeryID;
                    this.typeOfGRNID.Text = sRow.PrimeryID;
                    this.typeofGRNName.Text = sRow.PrimaryString;


                }
            }
        }

        private void subTypeofGRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select * from YN_InOutSubTypes order by InOutSubTypesID", "InOutSubTypesID", "InOutSubTypesName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.subTypeofGRNID.Tag = sRow.PrimeryID;
                    this.subTypeofGRNID.Text = sRow.PrimeryID;
                    this.subTypeofGRNName.Text = sRow.PrimaryString;


                }
            }
        }

        private void fromDeptID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select * from YN_InOutDeptTypes where InOnly=1 order by InOutDeptTypesID", "InOutDeptTypesID", "InOutDeptTypesName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.fromDeptID.Tag = sRow.PrimeryID;
                    this.fromDeptID.Text = sRow.PrimeryID;
                    this.fromDeptName.Text = sRow.PrimaryString;
                    foreach ( Control c in this.tableLayoutPanel_Detail.Controls )
                    {
                        UserControls.dxYarn y = (UserControls.dxYarn)c;
                        y.DeptID = sRow.PrimeryID;
                        y.CalcBalance();
                    }

                }
            }
        }

        private void fromAccountID_KeyDown(object sender, KeyEventArgs e)
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
                    this.fromAccountID.Tag = sRow.PrimeryID;
                    this.fromAccountID.Text = sRow.PrimeryID;
                    this.fromAccountName.Text = sRow.PrimaryString;

                    foreach (Control c in this.tableLayoutPanel_Detail.Controls)
                    {
                        UserControls.dxYarn y = (UserControls.dxYarn)c;
                        y.AccountID = sRow.PrimeryID;
                        y.CalcBalance();
                    }
                }
            }
        }

        private void toAccountID_KeyDown(object sender, KeyEventArgs e)
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
                    this.toAccountID.Tag = sRow.PrimeryID;
                    this.toAccountID.Text = sRow.PrimeryID;
                    this.toAccountName.Text = sRow.PrimaryString;


                }
            }
        }

        private void toDeptID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select * from YN_InOutDeptTypes where InOnly=0 order by InOutDeptTypesID", "InOutDeptTypesID", "InOutDeptTypesName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.toDeptID.Tag = sRow.PrimeryID;
                    this.toDeptID.Text = sRow.PrimeryID;
                    this.toDeptName.Text = sRow.PrimaryString;
                    this.DAccountID.Tag = null;
                    this.DAccountID.Text = "";
                    this.DAccountName.Text = "";

                }
            }
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
                    XtraMessageBox.Show("Either uncheck the GIN filter or enter valid GIN", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_Type.Checked == true)
            {
                if (this.typeOfGRNID.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the GIN Type filter or enter valid GIN Type", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.typeOfGRNID.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the GIN Type filter or enter valid GIN Type", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (this.Filter_Account.Checked == true)
            {
                if (this.fromAccountID.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the GIN Account filter or enter valid GIN Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.fromAccountID.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the GIN Account filter or enter valid GIN Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            if (this.Filter_Dept.Checked == true)
            {
                if (this.fromDeptID.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the GIN Department filter or enter valid GIN Department", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.fromDeptID.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the GIN Department filter or enter valid GIN Department", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn aField = (UserControls.dxYarn)C;
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



            strFilterQuery = "SELECT *  FROM YN_YarnStock  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' ";



            if (this.Filter_Dated.Checked == true)
            {

                strFilterQuery += " and iDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.Filter_Type.Checked == true)
            {

                strFilterQuery += " and InoutTypeID='" + this.typeOfGRNID.EditValue.ToString() + "'";

            }
            //if (this.Filter_Account.Checked == true)
            //{

            //    strFilterQuery += " and AccountID='" + this.fromAccountID.EditValue.ToString() + "'";

            //}
            if (this.Filter_GRNGIN.Checked == true)
            {

                strFilterQuery += " and GRNGIN like '%" + this.Suffix.Text + "%'";

            }

            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn aField = (UserControls.dxYarn)C;

                if (aField.Filter_Bags.Checked == true || aField.Filter_Blend.Checked == true || aField.Filter_Brand.Checked == true || aField.Filter_Count.Checked == true || aField.Filter_Desc.Checked == true)
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and GRNGIN in(select GRNGIN from YN_YarnStockDetail where ";
                    }
                    if (aField.Filter_Bags.Checked == true)
                    {
                        SubFilter += " BagsIn=" + aField.Bags.EditValue.ToString() + "";
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
            FrmView.Load_View(strFilterQuery, "GRNGIN", "InOutTypeID");
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }
        private void Fill_GRN(string iNumber)
        {

            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from qYN_YarnStock where GRNGIN='" + iNumber + "'");
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
          
            this.typeOfGRNID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["InOutTypeID"].ToString();
            this.typeofGRNName.EditValue = ds_VoucherMain.Tables[0].Rows[0]["InOutTypesName"].ToString();
            this.Driver.Text = ds_VoucherMain.Tables[0].Rows[0]["Driver"].ToString();
            this.TruckRegistrationNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["TruckRegistrationNumber"].ToString();
            this.DeliveryChallanNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["DeliveryChallanNumber"].ToString();

            try
            {
                this.Dated.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }


            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();


            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from qYN_YarnStockDetail where GRNGIN='" + iNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_Detail.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                if (Convert.ToDouble(ds_VoucherSub_T.Tables[0].Rows[x]["LbsIn"].ToString())>0 && Convert.ToDouble(ds_VoucherSub_T.Tables[0].Rows[x]["LbsOut"].ToString())<=0)
                {
                    UserControls.dxYarn ysub = new UserControls.dxYarn();

                    this.tableLayoutPanel_Detail.Controls.Add(ysub);
                    ysub.BagsType.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBagsType"].ToString();
                    ysub.Counts.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnCount"].ToString();
                    ysub.Blends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBlend"].ToString();
                    ysub.Ply.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnPly"].ToString();
                    ysub.Desc.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnDesc"].ToString();
                    ysub.Brand.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBrand"].ToString();
                   


                    this.toDeptID.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InoutDeptID"].ToString();
                    this.toDeptName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InoutDeptTypesName"].ToString();
                    this.toAccountID.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();
                    this.toAccountName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["AccountName"].ToString();
                    this.DAccountID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["DAccountID"].ToString();
                    this.DAccountName.Text = ds_VoucherSub_T.Tables[0].Rows[x]["DAccountName"].ToString();
                    this.DAccountID.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["DAccountID"].ToString();
                    ysub.LbsPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnLbsperBag"].ToString();
                    ysub.ConesPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnConesPerBag"].ToString();
                    ysub.Bags.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BagsIn"].ToString();
                    ysub.Lbs.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["LbsIn"].ToString();
                    ysub.Cones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["ConesIn"].ToString();
                }
                else
                {
                    this.subTypeofGRNID.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InoutSubTypeID"].ToString();
                    this.subTypeofGRNName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InOutSubTypesName"].ToString();
                    this.fromDeptID.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InoutDeptID"].ToString();
                    this.fromDeptName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["InoutDeptTypesName"].ToString();
                    this.fromAccountID.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();
                    this.fromAccountName.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["AccountName"].ToString();
                }

            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid GIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid GIN", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataSet ds = WS.svc.Get_DataSet("Select * from qp_YarnStock where GRNGIN='" + this.Print.Tag.ToString() + "'");
            Reports.Yarn_GIN PrintGIN = new Reports.Yarn_GIN();
            PrintGIN.BeginInit();
            if (RadioPageSetting.EditValue.ToString() == "H")
            {

                PrintGIN.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                PrintGIN.PageHeight = PrintGIN.PageHeight / 2;

            }
            PrintGIN.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null)
                PrintGIN.DataSource = ds;
            else
                PrintGIN.DataSource = null;
            PrintGIN.EndInit();
            PrintGIN.ShowPreview();
        }

        private void DAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select DAccountID,DAccountName from YN_InOutDAccounts where InoutDeptID='"+this.toDeptID.Text +"' order by DAccountName", "DAccountID", "DAccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.DAccountID.Tag = sRow.PrimeryID;
                    this.DAccountID.Text = sRow.PrimeryID;
                    this.DAccountName.Text = sRow.PrimaryString;


                }
            }
        }

        private void  CheckStock_Click(object sender, EventArgs e)
        {

            bool check=UpdateAvailableStock();
           
        }
        private bool  UpdateAvailableStock()
        {
           if(this.fromAccountID.EditValue==null)
           {
               XtraMessageBox.Show("Account is not valid","Error");
               return false;
           }
           if(this.fromDeptID.EditValue ==null)
           {
               XtraMessageBox.Show("Dept. is not valid","Error");
               return false;
           }
            if(this.subTypeofGRNID.EditValue==null)
            {
                XtraMessageBox.Show("SID is not valid","Error");
                return false;
            }
            if(this.typeOfGRNID.EditValue ==null)
            {
                XtraMessageBox.Show("TID is not valid","Error");
                return false;
            }

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn AField = (UserControls.dxYarn)C;

                if (AField.BagsType.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Sub Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.BagsType.Focus();
                    return false;
                }

                if (AField.Counts.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Counts.Focus();
                    return false;
                }

                if (AField.Ply.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Sub Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Ply.Focus();
                    return false;
                }

                if (AField.Blends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Blend ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Blends.Focus();
                    return false;
                }
                if (AField.Brand.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Brand ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Brand.Focus();
                    return false;
                }

                if (AField.Desc.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Desc ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Desc.Focus();
                    return false;
                }

            }
              

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.dxYarn yarncontrol = (UserControls.dxYarn)C;

                string query = "Select sum(LbsIn-LbsOut+LbsAdj) as BalanceLbs,Sum(BagsIn-BagsOut+BagsAdj) as BalanceBags,Sum(ConesIn-ConesOut+ConesAdj) as BalanceCones  from QP_YarnStock where  YarnBagsType='" + yarncontrol.BagsType.EditValue.ToString() + "' and YarnCount='"+yarncontrol.Counts.EditValue.ToString()+"' and YarnPly='"+yarncontrol.Ply.EditValue.ToString()+"' and YarnBlend='"+yarncontrol.Blends.EditValue.ToString()+"' and YarnBrand='"+yarncontrol.Brand.EditValue.ToString()+"' and YarnDesc='"+yarncontrol.Desc.EditValue.ToString()+"' AND AccountID='"+this.fromAccountID.EditValue.ToString()+"' and InOutDeptID='"+this.fromDeptID.EditValue.ToString()+"' and InOutSubTypeID='"+this.subTypeofGRNID.EditValue.ToString()+"' and GRNGIN in(select GRNGIN from YN_YarnStock where InOutTypeID='"+this.typeOfGRNID.EditValue.ToString()+"')";
                DataSet ds = WS.svc.Get_DataSet(query);
                if (ds != null)
                {
                    yarncontrol.AvlBags.EditValue = ds.Tables[0].Rows[0]["BalanceBags"].ToString();
                    yarncontrol.AvlCones.EditValue = ds.Tables[0].Rows[0]["BalanceCones"].ToString();
                    yarncontrol.AvlLbs.EditValue = ds.Tables[0].Rows[0]["BalanceLbs"].ToString();
                }
                if (yarncontrol.AvlBags.EditValue == null)
                {
                    XtraMessageBox.Show("invalid available bags", "Error");
                    return false;
                }
                if (yarncontrol.AvlCones.EditValue == null)
                {
                    XtraMessageBox.Show("invalid available cones", "Error");
                    return false;
                }
                if (yarncontrol.AvlLbs.EditValue == null)
                {
                    XtraMessageBox.Show("invalid available lbs", "Error");
                    return false;
                }
                if (yarncontrol.Bags.EditValue == null)
                {
                    XtraMessageBox.Show("invalid issued bags", "Error");
                    return false;
                }
                if (yarncontrol.Cones.EditValue == null)
                {
                    XtraMessageBox.Show("invalid issued cones", "Error");
                    return false;
                }
                if (yarncontrol.Lbs.EditValue == null)
                {
                    XtraMessageBox.Show("invalid issued lbs", "Error");
                    return false;
                }
                double ABags = 0, ACones = 0, ALbs = 0;
                double IBags = 0, ICones = 0, ILbs = 0;


                double.TryParse(yarncontrol.AvlBags.EditValue.ToString(), out ABags);
                double.TryParse(yarncontrol.AvlCones.EditValue.ToString(), out ACones);
                double.TryParse(yarncontrol.AvlLbs.EditValue.ToString(), out ALbs);

                double.TryParse(yarncontrol.Bags.EditValue.ToString(), out IBags);
                double.TryParse(yarncontrol.Cones.EditValue.ToString(), out ICones);
                double.TryParse(yarncontrol.Lbs.EditValue.ToString(), out ILbs);
                if (ABags - IBags < 0)
                {
                    XtraMessageBox.Show("Not enough available bags", "Error");
                    return false;
                }
                if (ACones - ICones < 0)
                {
                    XtraMessageBox.Show("Not enough available cones", "Error");
                    return false;
                }
                if (ALbs - ILbs < 0)
                {
                    XtraMessageBox.Show("Not enough available lbs", "Error");
                    return false;
                }

            }
            return true;
        }

        private void TempAccount_Click(object sender, EventArgs e)
        {
            string str = WS.svc.Execute_Query("Update YN_YarnStock Set inouttypeid='" + this.typeOfGRNID.EditValue.ToString() + "' where GRNGIN in(select GRNGIN from YN_YarnStockDetail where AccountID='" + this.fromAccountID.EditValue.ToString() + "')");
            if (str == "**SUCCESS##")
                XtraMessageBox.Show("Successfully updated table!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("Error Updating table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void TempYarn_Click(object sender, EventArgs e)
        {
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
             UserControls.dxYarn yarn = (UserControls.dxYarn)tableLayoutPanel_Detail.Controls[0];
            string str = WS.svc.Execute_Query("Update YN_YarnStock Set inouttypeid='" + this.typeOfGRNID.EditValue.ToString() + "' where GRNGIN in(select GRNGIN from YN_YarnStockDetail where AccountID='" + this.fromAccountID.EditValue.ToString() + "' and YarnCount='"+yarn.Counts.EditValue.ToString()+"' and YarnBlend='"+yarn.Blends.EditValue.ToString()+"' and YarnBrand='"+yarn.Brand.EditValue.ToString()+"' and YarnPly='"+yarn.Ply.EditValue.ToString()+"' and YarnBagsType='"+yarn.BagsType.EditValue.ToString()+"')");
            if (str == "**SUCCESS##")
                XtraMessageBox.Show("Successfully updated table!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("Error Updating table!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}