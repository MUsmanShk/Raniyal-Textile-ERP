using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MachineEyes.Classes;
namespace MachineEyes.Accounts
{
    public partial class Accounts_Voucher_BankReceipt : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private easyVoucherCalculations vCalc = new easyVoucherCalculations();
        private string G_Number;
        private string N_Number;
        public Accounts_Voucher_BankReceipt()
        {
            InitializeComponent();
            this.VPrefix.Text = "504";
            G_Number = "504";
            N_Number = "514";
            vCalc.controls_Difference = this.Difference;
            vCalc.controls_MultiTotal = this.PaymentTotal;
            vCalc.controls_SingleTotal = this.H_Amount;

            UserControls.AccountField Receipt = new UserControls.AccountField();
            Receipt.eVC = vCalc;
            this.tableLayoutPanel_Detail.Controls.Add(Receipt);
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.vDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
        }
        private void ButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute.Enabled = false;
                    Cancel.Enabled = false;
                    Add.Enabled = true;
                    CloseForm.Enabled = true;
                    View.Enabled = true;


                    if (VSuffix.Tag != null)
                    {
                        if (VSuffix.Tag.ToString() != "")
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
                    VSuffix.Tag = "";

                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                    CloseForm.Enabled = true;
                    View.Enabled = false;
                    Delete.Enabled = false;
                  

                    break;
                case UserInputMode.Edit:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                    CloseForm.Enabled = true;
                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                    CloseForm.Enabled = true;
                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                default:
                    break;
            }
        }
        private void GetNextVoucherNumber()
        {
            try
            {
                string vNum = ReturnMaxNumber("select max(Convert(numeric(18),SubString(VNumber,8,6)))+1 as MaxNumber  from AC_Voucher_Main where VYear='" + this.FinancialYear.Text + "' and VType='" + this.VPrefix.Text + "' and VCat='" + this.NG.Tag + "'");
                vNum = vNum.PadLeft(6, '0');
                this.VSuffix.Text = vNum;


            }
            catch
            {
            }
        }
        private string ReturnMaxNumber(string Query)
        {
            try
            {
                return WS.svc.Get_MaxNumber(Query);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private void Delete_Voucher()
        {
            string veditNum = this.VPrefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.VSuffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete voucher # " + veditNum, "Delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            queries[0] = "delete from  AC_Voucher_Sub where  VNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Main where  VNumber='" + veditNum + "'";
           
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
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.AccountField Payment = new UserControls.AccountField();
                    Payment.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(Payment);
                    this.View.Tag = "";
                    ButtonStates(UserInputMode.View);
                    this.H_AccountID.Text = "";
                    this.H_AccountID.Tag = "";
                    this.H_Amount.Text = "";
                    this.H_Remarks.Text = "";
                    this.H_AccountName.Text = "";
                    this.H_AccountName.Tag = "";
                    this.VPrefix.Tag = "";
                    this.VSuffix.Tag = "";
                    this.VSuffix.Text = "";

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Edit_Voucher()
        {
            if (this.VPrefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.VSuffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
                return;
            }
            if (this.VSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.VSuffix.Text, out suffix) == false)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
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
            if (this.FinancialYear.Text != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (vDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (vDate.DateTime < Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (vDate.DateTime > Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (this.H_AccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
            if (this.H_AccountName.Tag == null)
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
            if (this.H_AccountName.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
           
           
            int cDifference = 0;
            if (vCalc.difference != 0)
            {
                XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_Amount.Focus();
                return;
            }
            if (this.Difference.Text != "")
            {
                if (Int32.TryParse(this.Difference.Text, out cDifference) == false)
                {
                    XtraMessageBox.Show("There should not be difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.H_Amount.Focus();
                    return;
                }
            }
            if (cDifference != 0)
            {
                XtraMessageBox.Show("There should not be difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_Amount.Focus();
                return;
            }
            int cCreditSide = 0;
            foreach (Control c in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField Ac = (UserControls.AccountField)c;

                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                
                if (Ac.Amount.EditValue == null)
                {
                    XtraMessageBox.Show("invalid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Ac.Amount.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (Int32.TryParse(Ac.Amount.EditValue.ToString(), out cCreditSide) == false)
                {
                    XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }
                if (cCreditSide <= 0)
                {
                    XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }

            }

            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.VPrefix.Text + this.FinancialYear.Text + this.VSuffix.Text;
            string veditNum = this.VPrefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.VSuffix.Tag.ToString();
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
            queries[0] = "update AC_Voucher_Main set VNumber='" + vnum + "',VType='" + VPrefix.Text + "',VCat='" + vCat + "',VYear='" + FinancialYear.Text + "',eUserID='" +MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";

            if (this.vDate.EditValue != null)
                queries[0] += ",vDate='" + this.vDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",vDate=null";
            if (this.vDate.DateTime != null)
                queries[0] += ",vTime='" + this.vDate.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",vTime=null";


            if (this.H_Remarks.Text != "")
                queries[0] += ",vRemarks='" + this.H_Remarks.Text + "'";
            else
                queries[0] += ",vRemarks=null";
            if (this.H_Amount.EditValue != null)
                queries[0] += ",vAmount=" + this.H_Amount.EditValue.ToString() + "";
            else
                queries[0] += ",vAmount=0";
            queries[0] += " where vNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where vNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VRefChequeNumber,VDebitAmount,VCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (Convert.ToString(this.H_AccountID_IV.Text + this.H_AccountID.Text) != "")
                queries[queries.Length - 1] += ",'" + this.H_AccountID_IV.Text + this.H_AccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.H_Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.H_Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null,null,null,null";
            if (this.H_Amount.EditValue != null)
                queries[queries.Length - 1] += "," + H_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",0,1)";

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField AField = (UserControls.AccountField)C;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VRefChequeNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Particulars.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Particulars.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.InvoiceNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.InvoiceNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.BillNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.BillNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ChequeNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ChequeNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",0";
                if (AField.Amount.EditValue.ToString() != "")
                    queries[queries.Length - 1] += "," + AField.Amount.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";

                queries[queries.Length - 1] += ",0)";
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
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.AccountField Payment = new UserControls.AccountField();
                    Payment.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(Payment);
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    ButtonStates(UserInputMode.View);
                    this.H_AccountID.Text = "";
                    this.H_AccountID.Tag = "";
                    this.H_Amount.EditValue = null;
                    this.H_Remarks.Text = "";
                    this.H_AccountName.Text = "";
                    this.H_AccountName.Tag = "";
                    this.VPrefix.Tag = "";
                    this.VSuffix.Tag = "";
                    this.VSuffix.Text = "";
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_NewVoucher()
        {

            if (this.VPrefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.VSuffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
                return;
            }
            if (this.VSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.VSuffix.Text, out suffix) == false)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                VSuffix.Focus();
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
            if (this.FinancialYear.Text != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (vDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (vDate.DateTime < Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (vDate.DateTime > Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.vDate.Focus();
                return;
            }
            if (this.H_AccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
            if (this.H_AccountName.Tag == null)
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
            if (this.H_AccountName.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Bank Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_AccountID.Focus();
                return;
            }
           
            int cDifference = 0;
            if (vCalc.difference != 0)
            {
                XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_Amount.Focus();
                return;
            }
            if (this.Difference.Text != "")
            {
                if (Int32.TryParse(this.Difference.Text, out cDifference) == false)
                {
                    XtraMessageBox.Show("There should not be difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.H_Amount.Focus();
                    return;
                }
            }
            if (cDifference != 0)
            {
                XtraMessageBox.Show("There should not be difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.H_Amount.Focus();
                return;
            }
            int cCreditSide = 0;
            foreach (Control c in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField Ac = (UserControls.AccountField)c;

                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountID.EditValue == null)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
               
                if (Ac.Amount.EditValue == null)
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }
                if (Ac.Amount.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }
                if (Int32.TryParse(Ac.Amount.EditValue.ToString(), out cCreditSide) == false)
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }
                if (cCreditSide <= 0)
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Amount.Focus();
                    return;
                }

            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.VPrefix.Text + this.FinancialYear.Text + this.VSuffix.Text;
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
            queries[0] = "insert into AC_Voucher_Main (VNumber,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,VAmount,vAuthorized,vClosed,CUserID,CUserTime) Values (";
            queries[0] += "'" + vnum + "','" + VPrefix.Text + "','" + vCat + "','" + FinancialYear.Text + "'";
            if (this.vDate.EditValue != null)
                queries[0] += ",'" + this.vDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",null";
            if (this.vDate.DateTime != null)
                queries[0] += ",'" + this.vDate.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",null";

            queries[0] += ",'U'";
            if (this.H_Remarks.Text != "")
                queries[0] += ",'" + this.H_Remarks.Text + "'";
            else
                queries[0] += ",null";
            if (this.H_Amount.EditValue != null)
                queries[0] += "," + this.H_Amount.EditValue.ToString() + "";
            else
                queries[0] += ",0";
            queries[0] += ",0,0";
            queries[0] += ",'" +MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[0] += ")";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VRefChequeNumber,VDebitAmount,VCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (Convert.ToString(this.H_AccountID_IV.Text + this.H_AccountID.Text) != "")
                queries[queries.Length - 1] += ",'" + this.H_AccountID_IV.Text + this.H_AccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.H_Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.H_Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null,null,null,null";
            if (this.H_Amount.EditValue != null)
                queries[queries.Length - 1] += "," + H_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",0,1)";

            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField AField = (UserControls.AccountField)C;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VRefChequeNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Particulars.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Particulars.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.InvoiceNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.InvoiceNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.BillNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.BillNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ChequeNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ChequeNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Amount.EditValue.ToString() != "")
                    queries[queries.Length - 1] += ",0," + AField.Amount.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0,0";

                queries[queries.Length - 1] += ",0)";
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
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.AccountField Payment = new UserControls.AccountField();
                    Payment.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(Payment);
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    ButtonStates(UserInputMode.View);
                    this.H_AccountID.Text = "";
                    this.H_AccountID.Tag = "";
                    this.H_Amount.EditValue = null;
                    this.H_Remarks.Text = "";
                    this.H_AccountName.Text = "";
                    this.H_AccountName.Tag = "";
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void H_AccountID_TextChanged(object sender, EventArgs e)
        {
            if (H_AccountID.Text.Length == 3)
            {
                string BankName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.H_AccountID_IV.Text + this.H_AccountID.Text);
                H_AccountName.Text = BankName;
                H_AccountName.Tag = BankName;
            }
            else
            {
                H_AccountName.Text = "";
                H_AccountName.Tag = "";
            }
        }

        private void H_AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.H_AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID.Substring(10, 3);

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void H_Amount_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";
                this.VPrefix.Text = N_Number;
                if (uiMode == UserInputMode.Add)
                {
                    GetNextVoucherNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;
                this.VPrefix.Text = G_Number;
                if (uiMode == UserInputMode.Add)
                {
                    GetNextVoucherNumber();
                }
            }
        }

        private void Accounts_Voucher_BankReceipt_Load(object sender, EventArgs e)
        {
            H_AccountID_IV.Text = MachineEyes.Classes.Accounting.RegAccounts.Bank_IV;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ButtonStates(UserInputMode.Add);
            GetNextVoucherNumber();
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
                Save_NewVoucher();
            }
            else if (uiMode == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Edit_Voucher();
            }
            else if (uiMode == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Voucher();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (this.VPrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VPrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VSuffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
          
           
            ButtonStates(UserInputMode.Edit);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.VPrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VPrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VSuffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.VSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
          
           
            ButtonStates(UserInputMode.Delete);
        }
        private void ClearAll()
        {
            this.H_AccountID.Text = "";
            this.H_Remarks.Text = "";
            this.H_Amount.Text = "";
            this.VSuffix.Text = "";
            this.VSuffix.Tag = "";
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
            this.tableLayoutPanel_Detail.Controls.Clear();
            UserControls.AccountField Payment = new UserControls.AccountField();
            Payment.eVC = vCalc;
            this.tableLayoutPanel_Detail.Controls.Add(Payment);
        }
        private void Fill_Voucher(string VNumber)
        {
            ClearAll();
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from AC_Voucher_Main where vNumber='" + VNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;
            this.vDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["VDate"].ToString(),System.Globalization.CultureInfo.CurrentCulture);
            this.H_Amount.Text = ds_VoucherMain.Tables[0].Rows[0]["VAmount"].ToString();
            int cAmount = 0;
            int.TryParse(ds_VoucherMain.Tables[0].Rows[0]["VAmount"].ToString(), out cAmount);
            vCalc.singleTotal = cAmount;
            if (ds_VoucherMain.Tables[0].Rows[0]["VCat"].ToString() == "G")
            {
                this.NG.Checked = false;
              
            }
            else
            {
               
                this.NG.Checked = true;
            }
           
          
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["VStatus"].ToString();
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
           

            this.VSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VPrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.VPrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            this.FinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            DataSet ds_VoucherSub_H = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + VNumber + "' and isHead=1");
            if (ds_VoucherSub_H == null) return;
            if (ds_VoucherSub_H.Tables[0].Rows.Count <= 0) return;
           
            this.H_AccountID.Text = ds_VoucherSub_H.Tables[0].Rows[0]["AccountID_V"].ToString().Substring(10, 3);
            this.H_AccountID_IV.Text = ds_VoucherSub_H.Tables[0].Rows[0]["AccountID_V"].ToString().Substring(0, 10);
            this.H_Remarks.Text = ds_VoucherSub_H.Tables[0].Rows[0]["VParticulars"].ToString();
            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + VNumber + "' and isHead=0");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_Detail.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.AccountField Payment = new UserControls.AccountField();
                Payment.eVC = vCalc;
                this.tableLayoutPanel_Detail.Controls.Add(Payment);
                Payment.AccountID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID_V"].ToString();
                Payment.Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["VCreditAmount"].ToString();
                Payment.Particulars.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VParticulars"].ToString();
                Payment.InvoiceNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefInvoiceNumber"].ToString();
                Payment.DeliveryChallanNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefDeliveryChallanNumber"].ToString();
                Payment.ChequeNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefChequeNumber"].ToString();
                Payment.BillNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefBillNumber"].ToString();
                Payment.CalculateAmount();
            }
            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }
        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

            if (this.Filter_HAccountID.Checked == true)
            {
                if (this.H_AccountName.Tag == null)
                {
                    XtraMessageBox.Show("Either uncheck the Cash Account filter or select a Cash Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_HAccountID.Checked == true)
            {
                if (this.H_AccountName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Cash Account filter or select a Cash Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_HAccountID.Checked == true)
            {
                if (this.H_AccountID.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Cash Account filter or select a Cash Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_HAmount.Checked == true)
            {
                if (this.H_Amount.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Credited Amount filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_Dated.Checked == true)
            {
                if (this.vDate.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_Dated.Checked == true)
            {
                if (this.vDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_VoucherNumber.Checked == true)
            {
                if (this.VSuffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Voucher filter or enter valid voucher", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }


            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField aField = (UserControls.AccountField)C;
                if (aField.Filter_AccountID.Checked == true || aField.Filter_Amount.Checked == true || aField.Filter_BillNumber.Checked == true || aField.Filter_ChequeNumber.Checked == true || aField.Filter_DeliveryChallanNumber.Checked == true || aField.Filter_InvoiceNumber.Checked == true)
                {

                    if (aField.Filter_AccountID.Checked == true)
                    {
                        if (aField.AccountID.EditValue == null)
                        {
                            XtraMessageBox.Show("Either uncheck the Account ID filter or enter valid Account ID", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.AccountID.Focus();
                            return;
                        }
                       

                    }
                    if (aField.Filter_Amount.Checked == true)
                    {
                        if (aField.Amount.EditValue==null)
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                        if (aField.Amount.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_BillNumber.Checked == true)
                    {
                        if (aField.BillNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Bill Number Filter or enter valid Bill Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.BillNumber.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_Amount.Checked == true)
                    {
                        if (aField.Amount.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_ChequeNumber.Checked == true)
                    {
                        if (aField.Filter_ChequeNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Cheque Number Filter or enter valid Cheque Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_DeliveryChallanNumber.Checked == true)
                    {
                        if (aField.Filter_DeliveryChallanNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Delivery challan Filter or enter valid Delivery Challan Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_InvoiceNumber.Checked == true)
                    {
                        if (aField.Filter_InvoiceNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Invoice Number Filter or enter valid invoice", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Amount.Focus();
                            return;
                        }
                    }
                }
            }


            strFilterQuery = "SELECT VNumber,vDate,AccountID_V,AccountName_V,vDebitAmount,vCreditAmount FROM Accounts_Vouchers ";
            strFilterQuery += "  where VType='" + this.VPrefix.Text + "' and VYear='" + this.FinancialYear.Text + "' ";



            if (Filter_Dated.Checked == true)
            {

                strFilterQuery += " and vDate='" + vDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.Filter_HAmount.Checked == true)
            {

                strFilterQuery += " and vAmount=" + this.H_Amount.Text + "";

            }

            if (this.Filter_VoucherNumber.Checked == true)
            {

                strFilterQuery += " and vNumber like '%" + this.VSuffix.Text + "%'";

            }
            if (this.Filter_HAccountID.Checked == true)
            {

                strFilterQuery += " and vNumber in(select vNumber from AC_Voucher_Sub where AccountID_V='" + this.H_AccountID_IV.Text + this.H_AccountID.Text + "')";

            }
            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountField aField = (UserControls.AccountField)C;

                if (aField.Filter_AccountID.Checked == true || aField.Filter_Amount.Checked == true || aField.Filter_BillNumber.Checked == true || aField.Filter_ChequeNumber.Checked == true || aField.Filter_DeliveryChallanNumber.Checked == true || aField.Filter_InvoiceNumber.Checked == true)
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and vNumber in(select vNumber from AC_Voucher_Sub where ";
                    }
                    if (aField.Filter_AccountID.Checked == true)
                    {
                        SubFilter += " AccountID_V='" + aField.AccountID.Text + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_Amount.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vDebitAmount=" + aField.Amount.EditValue.ToString() + "";
                        Appendand = true;
                    }
                    if (aField.Filter_BillNumber.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vRefBillNumber='" + aField.BillNumber.Text + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_ChequeNumber.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vRefChequeNumber='" + aField.ChequeNumber.Text + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_DeliveryChallanNumber.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vRefDeliveryChallanNumber='" + aField.DeliveryChallanNumber.Text + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_InvoiceNumber.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vRefInvoiceNumber='" + aField.InvoiceNumber.Text + "'";
                        Appendand = true;
                    }
                }
            }
            if (SubFilter != "")
                SubFilter += ")";
            strFilterQuery += SubFilter;
            strFilterQuery += " ORDER BY Convert(numeric(18),vNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "VNumber", "VNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_Voucher(sRow.PrimeryID);

            }
        }

        private void Browse_Account_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.H_AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID.Substring(10, 3);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ButtonStates(UserInputMode.View);
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid Voucher ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Voucher ", "Error", MessageBoxButtons.OK);
                return;
            }

            Accounting.Print_BankReceiptVoucher(this.Print.Tag.ToString(),this.RadioPageSetting.EditValue.ToString());
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string DocNumber = VPrefix.Text + FinancialYear.Text + VSuffix.Text;
                Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
                Accounts.ReportingParameters.xu_ChangeStatus cs = new Accounts.ReportingParameters.xu_ChangeStatus();
                cs.CurrentStatus.Text = this.DocumentState.Tag.ToString();
                cs.DocumentNumber.Text = DocNumber;
                Report.Size = cs.Size;
                Report.reportControlParent.Controls.Add(cs);
                Report.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void H_Amount_EditValueChanged(object sender, EventArgs e)
        {
            int cAmount = 0;
            if(H_Amount.EditValue!=null)
            Int32.TryParse(H_Amount.EditValue.ToString(), out cAmount);
            vCalc.singleTotal = cAmount;
            this.AmountinWords.Text = Accounting.ReturnAmountInWords(cAmount);
        }

        private void H_Remarks_EditValueChanged(object sender, EventArgs e)
        {
            if (this.tableLayoutPanel_Detail.Controls.Count == 1)
            {
                Control c = this.tableLayoutPanel_Detail.Controls[0];
                UserControls.AccountField Payment = (UserControls.AccountField)c;
                Payment.Particulars.Text = H_Remarks.Text;
            }
        }
    }
}