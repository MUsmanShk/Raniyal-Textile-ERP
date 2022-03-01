using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts
{
    public partial class Accounts_VouchersAll: DevExpress.XtraEditors.XtraForm
    {
        
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModeVoucher;
        UserInputMode uiModeDetail;
        enVoucherType VoucherType;
        private string G_Number;
        private string N_Number;
        DataRow GridAccountRow;
        long gDebitSide = 0;
        long gCreditSide = 0;
        
        public Accounts_VouchersAll()
        {
            InitializeComponent();
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
            fc.Accounts_V(ref this.GeneralAccountName);

        }
        public void SetVoucherType(enVoucherType vType)
        {
            VoucherType = vType;
            FillCombos fc = new FillCombos();
            if (VoucherType == enVoucherType.BankPaymentVoucher)
            {
               
                G_Number = "502";
                N_Number = "512";
                this.VoucherTypeName.Text = "Bank Payment";
                this.VoucherTypeName.ForeColor = Color.Red;
                this.HeadDebitCreditLabel.Text = "Bank Payment(s)";
                H_AccountID_IV.Text = MachineEyes.Classes.Accounting.RegAccounts.Bank_IV;
                CashBankAccountLabel.Text = "Bank A/C";
                fc.CustomFill(ref this.HeadAccountName, "Select AccountID_V,AccountName_V from AC_Level_V where AccountID_IV='" + MachineEyes.Classes.Accounting.RegAccounts.Bank_IV + "'", "AccountName_V", "AccountID_V");
            }
            else if (VoucherType == enVoucherType.BankReceiptVoucher)
            {
                G_Number = "504";
                N_Number = "514";
                this.VoucherTypeName.Text = "Bank Receipt";
                this.VoucherTypeName.ForeColor = Color.White;
                this.HeadDebitCreditLabel.Text = "Bank Receipt(s)";
                CashBankAccountLabel.Text = "Bank A/C";
                H_AccountID_IV.Text = MachineEyes.Classes.Accounting.RegAccounts.Bank_IV;
                fc.CustomFill(ref this.HeadAccountName, "Select AccountID_V,AccountName_V from AC_Level_V where AccountID_IV='" + MachineEyes.Classes.Accounting.RegAccounts.Bank_IV + "'", "AccountName_V", "AccountID_V");
            }
            else if (VoucherType == enVoucherType.CashPaymentVoucher)
            {
                G_Number = "501";
                N_Number = "511";
                this.VoucherTypeName.Text = "Cash Payment";
                this.VoucherTypeName.ForeColor = Color.Orange;
                this.CHQLabel.Visible = false;
                this.ChequeNumber.Visible = false;
                this.HeadDebitCreditLabel.Text = "Cash Payment(s)";
                CashBankAccountLabel.Text = "Cash A/C";
                H_AccountID_IV.Text = MachineEyes.Classes.Accounting.RegAccounts.Cash_IV;
                fc.CustomFill(ref this.HeadAccountName, "Select AccountID_V,AccountName_V from AC_Level_V where AccountID_IV='" + MachineEyes.Classes.Accounting.RegAccounts.Cash_IV + "'", "AccountName_V", "AccountID_V");
            }
            else if (VoucherType == enVoucherType.CashReceiptVoucher)
            {
                G_Number = "503";
                N_Number = "513";
                this.VoucherTypeName.Text = "Cash Receipt";
                this.VoucherTypeName.ForeColor = Color.Green;
                this.CHQLabel.Visible = false;
                this.ChequeNumber.Visible = false;
                this.HeadDebitCreditLabel.Text = "Cash Receipt(s)";
                CashBankAccountLabel.Text = "Cash A/C";
                H_AccountID_IV.Text = MachineEyes.Classes.Accounting.RegAccounts.Cash_IV;
                fc.CustomFill(ref this.HeadAccountName, "Select AccountID_V,AccountName_V from AC_Level_V where AccountID_IV='" + MachineEyes.Classes.Accounting.RegAccounts.Cash_IV + "'", "AccountName_V", "AccountID_V");
            }
            else if (VoucherType == enVoucherType.GeneralVoucher)
            {
                G_Number = "505";
                N_Number = "515";
                this.VoucherTypeName.Text = "Journal Voucher";
                this.VoucherTypeName.ForeColor = Color.Yellow;
                this.panelControl_CashBank.Visible = false;
                this.HeadCreditSide.Visible = false;
                this.HeadDebitSide.Visible = false;
                this.HeadDebitCreditLabel.Visible = false;
            }

            this.Prefix.Text = G_Number;
            FetchGridDataSet("XXXXXXXX");
        }
        private void AddToGridValues()
        {
            if (uiModeVoucher != UserInputMode.Add && uiModeVoucher != UserInputMode.Edit && uiModeVoucher != UserInputMode.Delete)
            {
                XtraMessageBox.Show("can not add while voucher is not in add , edit or delete mode!", "Error");
                return;
            }
           
            if (this.GeneralAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                this.GeneralAccountName.Focus();
                return;
            }
            if (this.GeneralAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid ACCOUNT ID ...length must be 13 Characters", "Error");
                this.GeneralAccountName.Focus();
                return;
            }
            if (this.GeneralAccountName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account", "Error");
                this.GeneralAccountName.Focus();
                return;
            }
            if (this.GeneralDebit.EditValue == null && this.GeneralCredit.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Amount", "Error");
                this.GeneralDebit.Focus();
                return;
            }
            if (this.Particulars.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Particulars", "Error");
                this.Particulars.Focus();
                return;
            }
            string[] queries = new string[0];
           



            try
            {



                 

                    DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["AccountID_V"] = this.GeneralAccountID.EditValue.ToString();
                    
                    if (this.GeneralAccountName.EditValue != null) _ravi["AccountName_V"] = this.GeneralAccountName.Text;
                    if (this.GeneralDebit.EditValue != null) _ravi["VDebitAmount"] = this.GeneralDebit.EditValue.ToString();
                    if (this.GeneralCredit.EditValue != null) _ravi["VCreditAmount"] = this.GeneralCredit.EditValue.ToString();
                    if (this.InvoiceNumber.EditValue != null) _ravi["VRefInvoiceNumber"] = this.InvoiceNumber.EditValue.ToString();
                    if (this.ChequeNumber.EditValue != null) _ravi["VRefChequeNumber"] = this.ChequeNumber.EditValue.ToString();
                    if (this.DeliveryChallanNumber.EditValue != null) _ravi["VRefDeliveryChallanNumber"] = this.DeliveryChallanNumber.EditValue.ToString();
                    if (this.Particulars.EditValue != null) _ravi["VParticulars"] = this.Particulars.EditValue.ToString();
                    
                    gdt.Rows.Add(_ravi);
                    long tgDebit = 0; long tgCredit = 0;
                    if (this.GeneralDebit.EditValue != null)
                        long.TryParse(this.GeneralDebit.EditValue.ToString(), out tgDebit);
                    else
                        tgDebit = 0;
                    if (this.GeneralCredit.EditValue != null)
                        long.TryParse(this.GeneralCredit.EditValue.ToString(), out tgCredit);
                    gDebitSide += tgDebit;
                    gCreditSide += tgCredit;
                  
                    
                  
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountName.EditValue = null;
                    this.DeliveryChallanNumber.EditValue = null;
                    this.InvoiceNumber.EditValue = null;
                    this.GeneralDebit.EditValue = null;
                    this.GeneralCredit.EditValue = null;
                    SetButtonStates_Detail(UserInputMode.View);
                    GridAccountRow = null;
                    CalculateTotal();
                    this.Add_Detail.Focus();
                


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void UpdateGridValues()
        {
          
            if (this.GeneralAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Item ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GeneralAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Item ID is invalid ...must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GeneralAccountName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account", "Error");
                this.GeneralAccountName.Focus();
                return;
            }
            if (this.GeneralDebit.EditValue == null && this.GeneralCredit.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Amount", "Error");
                this.GeneralDebit.Focus();
                return;
            }
            if (this.Particulars.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Particulars", "Error");
                this.Particulars.Focus();
                return;
            }

           



          


            
            try
            {

                DataRow _ravi = GridAccountRow;
                long pgDebit = 0; long pgCredit = 0;
                if (_ravi["VDebitAmount"].ToString() != "")
                    long.TryParse(_ravi["VDebitAmount"].ToString(), out pgDebit);
                if (_ravi["VCreditAmount"].ToString() != "")
                    long.TryParse(_ravi["VCreditAmount"].ToString(), out pgCredit);
                _ravi["AccountID_V"] = this.GeneralAccountID.EditValue.ToString();
                if (this.GeneralAccountName.EditValue != null) _ravi["AccountName_V"] = this.GeneralAccountName.Text;
                if (this.GeneralDebit.EditValue != null) _ravi["VDebitAmount"] = this.GeneralDebit.EditValue.ToString();
                else
                    _ravi["VDebitAmount"] = DBNull.Value;
                if (this.GeneralCredit.EditValue != null) _ravi["VCreditAmount"] = this.GeneralCredit.EditValue.ToString();
                else
                    _ravi["VCreditAmount"] = DBNull.Value;
                if (this.InvoiceNumber.EditValue != null) _ravi["VRefInvoiceNumber"] = this.InvoiceNumber.EditValue.ToString();
                else
                    _ravi["VRefInvoiceNumber"] = DBNull.Value;
                if (this.ChequeNumber.EditValue != null) _ravi["VRefChequeNumber"] = this.ChequeNumber.EditValue.ToString();
                else
                    _ravi["VRefChequeNumber"] = DBNull.Value;
                if (this.DeliveryChallanNumber.EditValue != null) _ravi["VRefDeliveryChallanNumber"] = this.DeliveryChallanNumber.EditValue.ToString();
                else _ravi["VRefDeliveryChallanNumber"] = DBNull.Value;
                if (this.Particulars.EditValue != null) _ravi["VParticulars"] = this.Particulars.EditValue.ToString();
                else
                    _ravi["VParticulars"] = DBNull.Value;

                long tgDebit = 0; long tgCredit = 0;
                if (this.GeneralDebit.EditValue != null)
                    long.TryParse(this.GeneralDebit.EditValue.ToString(), out tgDebit);
                else
                    tgDebit = 0;
                if (this.GeneralCredit.EditValue != null)
                    long.TryParse(this.GeneralCredit.EditValue.ToString(), out tgCredit);
                gDebitSide -= pgDebit;
                gCreditSide -= pgCredit;
                gDebitSide += tgDebit;
                gCreditSide += tgCredit;
               
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountName.EditValue = null;
                    this.DeliveryChallanNumber.EditValue = null;
                    this.InvoiceNumber.EditValue = null;
                    this.GeneralDebit.EditValue = null;
                    this.GeneralCredit.EditValue = null;
                    SetButtonStates_Detail(UserInputMode.View);
                    GridAccountRow = null;
                    CalculateTotal();
                    this.Add_Detail.Focus();

                  
            


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteGridValues()
        {





          


           
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete  ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


           

            try
            {
                DataRow _ravi = GridAccountRow;
                long pgDebit = 0; long pgCredit = 0;
                if (_ravi["VDebitAmount"].ToString() != "")
                    long.TryParse(_ravi["VDebitAmount"].ToString(), out pgDebit);
                if (_ravi["VCreditAmount"].ToString() != "")
                    long.TryParse(_ravi["VCreditAmount"].ToString(), out pgCredit);
                    this.GridVew_GeneralAccounts.DeleteRow(this.GridVew_GeneralAccounts.FocusedRowHandle);
                    gDebitSide -= pgDebit;
                    gCreditSide -= pgCredit;
                    
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountName.EditValue = null;
                    this.DeliveryChallanNumber.EditValue = null;
                    this.InvoiceNumber.EditValue = null;
                    this.GeneralDebit.EditValue = null;
                    this.GeneralCredit.EditValue = null;
                    GridAccountRow = null;
                    SetButtonStates_Detail(UserInputMode.View);
                    CalculateTotal();
                    this.Add_Detail.Focus();
               


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetButtonStates_Detail(UserInputMode uim)
        {
            uiModeDetail = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.Execute_Detail.Enabled = false;
                    this.Cancel_Detail.Enabled = true;
                    this.Add_Detail.Enabled = true;
                    this.GridControl_GeneralAccounts.Enabled = true;
                    if (GridAccountRow != null)
                    {
                        this.Delete_Detail.Enabled = true;
                        this.Edit_Detail.Enabled = true;
                    }

                    break;
                case UserInputMode.Add:
                    
                    this.Add_Detail.Enabled = false;
                    this.Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    Delete_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = true;

                    break;
                case UserInputMode.Edit:
                    Add_Detail.Enabled = false;
                    Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = false;
                    Delete_Detail.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_Detail.Enabled = false;
                    Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    Delete_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = false;

                    break;
                default:
                    break;
            }
        }
        
      
        private void SetButtonStates(UserInputMode uim)
        {
            uiModeVoucher = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Voucher_Execute.Enabled = false;
                    Voucher_Cancel.Enabled = false;
                    Voucher_Add.Enabled = true;
                    Clone.Enabled = true;
                    Voucher_View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            Voucher_Edit.Enabled = true;
                            Voucher_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            Voucher_Edit.Enabled = false;
                            Voucher_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Voucher_Edit.Enabled = false;
                        Voucher_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";
                    Clone.Enabled = false;
                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_View.Enabled = false;
                    Voucher_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Clone.Enabled = false;
                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_Delete.Enabled = false;
                    Voucher_View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Clone.Enabled = false;
                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_Delete.Enabled = false;
                    Voucher_View.Enabled = false;

                    break;
                default:
                    break;
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
        private bool GetNextVoucherNumber()
        {

            try
            {
                string vNum = ReturnMaxNumber("select max(Convert(numeric(18),SubString(VNumber,8,6)))+1 as MaxNumber  from AC_Voucher_Main where VYear='" + this.FinancialYear.Text + "' and VType='" + this.Prefix.Text + "' and VCat='" + this.NG.Tag + "'");
                vNum = vNum.PadLeft(6, '0');
                this.Suffix.Text = vNum;

                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FetchGridDataSet(string vNumber)
        {
            DataSet ds = WS.svc.Get_DataSet("select * from Accounts_Voucher_Sub where vNumber='" + vNumber + "' and isHead=0");
            if (ds != null)
                GridControl_GeneralAccounts.DataSource = ds.Tables[0];
            if (ds != null)
            {
                long tempDebit = 0; long tempCredit = 0;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for(int x=0;x<ds.Tables[0].Rows.Count;x++)
                    {
                        long.TryParse(ds.Tables[0].Rows[x]["VDebitAmount"].ToString(), out tempDebit);
                        long.TryParse(ds.Tables[0].Rows[x]["VCreditAmount"].ToString(), out tempCredit);
                        gDebitSide += tempDebit;
                        gCreditSide += tempCredit;
                        CalculateTotal();
                    }
                }
            }
        }
        private bool isDebitCreditEqual()
        {

            double HeadDebitCreditAmount = 0;
            double DebitSide=0;
            double CreditSide=0;
            if(this.HeadAmount.EditValue!=null)
             double.TryParse(this.HeadAmount.EditValue.ToString(), out HeadDebitCreditAmount);
            if (VoucherType == enVoucherType.CashReceiptVoucher)
                DebitSide = HeadDebitCreditAmount;
            else if (VoucherType == enVoucherType.CashPaymentVoucher)
                CreditSide = HeadDebitCreditAmount;
            else if (VoucherType == enVoucherType.BankReceiptVoucher)
                DebitSide = HeadDebitCreditAmount;
            else if (VoucherType == enVoucherType.BankPaymentVoucher)
                CreditSide = HeadDebitCreditAmount;
            else
            {
                DebitSide = 0;
                CreditSide = 0;
            }

            DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
            DataTable gdt = gdv.Table;
            if (gdt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Invalid Number of Rows for Debit / Credit Account....double entry voilation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            for (int x = 0; x < gdt.Rows.Count; x++)
            {

                double TempDebit = 0; double TempCredit = 0;
                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {

                    if (gdt.Rows[x]["VDebitAmount"].ToString() != "")
                        double.TryParse(gdt.Rows[x]["VDebitAmount"].ToString(), out TempDebit);
                    if (gdt.Rows[x]["VCreditAmount"].ToString() != "")
                        double.TryParse(gdt.Rows[x]["VCreditAmount"].ToString(), out TempCredit);

                    DebitSide += TempDebit;
                    CreditSide += TempCredit;
                }
            }
            if (DebitSide != CreditSide)
            {
                XtraMessageBox.Show("Invalid Debit and Credit Side ...can not proceed for voucher ...Debit side is " + DebitSide + " and Credit Side total is " + CreditSide + "", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;


            }
            if (DebitSide <= 0 || CreditSide <= 0)
            {
                XtraMessageBox.Show("Invalid Debit or Credit Side ...can not proceed for voucher ...Debit side is " + DebitSide + " and Credit Side total is " + CreditSide + "", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
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
            if (VoucherType != enVoucherType.GeneralVoucher)
            {
                if (HeadAmount.EditValue == null)
                {
                    XtraMessageBox.Show("invalid amount in cash/ bank debit/credit ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                long tempamount = 0;
                long.TryParse(this.HeadAmount.EditValue.ToString(), out tempamount);
                if (tempamount <= 0)
                {
                    XtraMessageBox.Show("invalid amount in cash/ bank debit/credit ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (DebitCreditDifference.Tag == null)
                {
                   
                        XtraMessageBox.Show("invalid voucher amount ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                   
                }
                if (DebitCreditDifference.Tag.ToString() == "")
                {

                    XtraMessageBox.Show("invalid voucher amount ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                long.TryParse(this.DebitCreditDifference.Tag.ToString(), out tempamount);
                if (tempamount != 0)
                {
                    XtraMessageBox.Show("invalid voucher amount debit and credit side must be equal ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.HeadAccountName.EditValue == null)
                {
                    XtraMessageBox.Show("invalid voucher Head A/C....enter cash account for cash voucher and bank account for bank voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.H_AccountID.EditValue == null)
                {
                    XtraMessageBox.Show("invalid head account ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
               

            }
            DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
            DataTable gdt = gdv.Table;
            if (gdt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Invalid Number of Rows for Debit / Credit Account....double entry voilation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int x = 0; x < gdt.Rows.Count; x++)
            {
                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {

                    if (gdt.Rows[x]["AccountID_V"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Account in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["VDebitAmount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Debit Side in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["VCreditAmount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Credit Side  in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
            bool isEqual = isDebitCreditEqual();
            if (isEqual == false) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
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
            queries[0] = "insert into AC_Voucher_Main (VNumber,isMDC,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,VAmount,vAuthorized,vClosed,CUserID,CUserTime) Values (";
            queries[0] += "'" + vnum + "',1,'" + Prefix.Text + "','" + vCat + "','" + FinancialYear.Text + "'";
            if (this.Dated.DateTime != null)
                queries[0] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[0] += ",null";
            if (this.Dated.DateTime != null)
                queries[0] += ",'" + this.Dated.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",null";

            queries[0] += ",'U'";
            if (this.Remarks.EditValue != null)
                queries[0] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.TotalDebitSide.EditValue != null)
                queries[0] += "," + this.TotalDebitSide.EditValue.ToString() + "";
            else
                queries[0] += ",0";
            queries[0] += ",0,0";
            queries[0] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[0] += ")";
            

            if (VoucherType != enVoucherType.GeneralVoucher)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefChequeNumber,VDebitAmount,VCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.HeadAccountName.EditValue!=null)
                    queries[queries.Length - 1] += ",'" + this.HeadAccountName.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.Remarks.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if(this.InvoiceNumber.EditValue!=null)
                    queries[queries.Length - 1] += ",'" + this.InvoiceNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.DeliveryChallanNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.DeliveryChallanNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.ChequeNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.ChequeNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (VoucherType == enVoucherType.BankPaymentVoucher || VoucherType == enVoucherType.CashPaymentVoucher)
                    queries[queries.Length - 1] += ",0";
                else
                    queries[queries.Length - 1] += "," + this.HeadAmount.EditValue.ToString() + "";
                if (VoucherType == enVoucherType.BankReceiptVoucher || VoucherType == enVoucherType.CashReceiptVoucher)
                     queries[queries.Length - 1] += ",0";
                    
                else
                    queries[queries.Length - 1] += "," + this.HeadAmount.EditValue.ToString() + "";
                queries[queries.Length - 1] += ",1)";
            }
        
            for (int x = 0; x < gdt.Rows.Count;x++ )
            {
                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefChequeNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (gdt.Rows[x]["AccountID_V"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["AccountID_V"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["VParticulars"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VParticulars"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["VRefInvoiceNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefInvoiceNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VRefDeliveryChallanNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefDeliveryChallanNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VRefChequeNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefChequeNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VDebitAmount"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["VDebitAmount"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (gdt.Rows[x]["VCreditAmount"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["VCreditAmount"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";

                    queries[queries.Length - 1] += ",0)";
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
                    this.Remarks.EditValue = null;
                    this.HeadAccountName.EditValue = null;
                    this.HeadAmount.EditValue = null;
                    this.Particulars.EditValue = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountName.EditValue = null;
                    this.GeneralCredit.EditValue = null;
                    this.GeneralDebit.EditValue = null;
                    this.Voucher_Print.Tag = vnum;
                    this.Voucher_View.Tag = vnum;
                    this.ChequeNumber.EditValue = null;
                    this.InvoiceNumber.EditValue = null;
                    this.DeliveryChallanNumber.EditValue = null;
                    this.Suffix.EditValue = null;
                    gDebitSide = 0;
                    gCreditSide = 0;
                    FetchGridDataSet("XXXXXXX");
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
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.Suffix.Tag.ToString()=="")
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
            if (this.FinancialYear.Tag==null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Type of voucher not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (VoucherType != enVoucherType.GeneralVoucher)
            {
                if (HeadAmount.EditValue == null)
                {
                    XtraMessageBox.Show("invalid amount in cash/ bank debit/credit ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                long tempamount = 0;
                long.TryParse(this.HeadAmount.EditValue.ToString(), out tempamount);
                if (tempamount <= 0)
                {
                    XtraMessageBox.Show("invalid amount in cash/ bank debit/credit ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (DebitCreditDifference.Tag == null)
                {

                    XtraMessageBox.Show("invalid voucher amount ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (DebitCreditDifference.Tag.ToString() == "")
                {

                    XtraMessageBox.Show("invalid voucher amount ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                long.TryParse(this.DebitCreditDifference.Tag.ToString(), out tempamount);
                if (tempamount != 0)
                {
                    XtraMessageBox.Show("invalid voucher amount debit and credit side must be equal ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.HeadAccountName.EditValue == null)
                {
                    XtraMessageBox.Show("invalid voucher Head A/C....enter cash account for cash voucher and bank account for bank voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (this.H_AccountID.EditValue == null)
                {
                    XtraMessageBox.Show("invalid head account ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



            }
            DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
            DataTable gdt = gdv.Table;
            if (gdt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Invalid Number of Rows for Debit / Credit Account....double entry voilation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int x = 0; x < gdt.Rows.Count; x++)
            {

                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {
                    if (gdt.Rows[x]["AccountID_V"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Account in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["VDebitAmount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Debit Side in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["VCreditAmount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Credit Side  in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }

            }
            bool isEqual = isDebitCreditEqual();
            if (isEqual == false) return;
            string[] queries = new string[0];
            
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            string veditNum = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
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
            Array.Resize(ref queries, 1);
           
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where vNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Voucher_Main set VNumber='" + vnum + "',VType='" + Prefix.Text + "',VCat='" + vCat + "',VYear='" + FinancialYear.Text + "',eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";

            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",vDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",vDate=null";
            if (this.Dated.DateTime != null)
                queries[queries.Length - 1] += ",vTime='" + this.Dated.DateTime.ToShortTimeString() + "'";
            else
                queries[queries.Length - 1] += ",vTime=null";


            if(this.Remarks.EditValue!=null)
                queries[queries.Length - 1] += ",vRemarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",vRemarks=null";

            queries[queries.Length - 1] += ",vAmount=" + this.TotalDebitSide.EditValue.ToString() + "";

            queries[queries.Length - 1] += " where vNumber='" + veditNum + "'";
           
           
           

            if (VoucherType != enVoucherType.GeneralVoucher)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefChequeNumber,VDebitAmount,VCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.HeadAccountName.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.HeadAccountName.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.Remarks.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.InvoiceNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.InvoiceNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.DeliveryChallanNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.DeliveryChallanNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (this.ChequeNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.ChequeNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (VoucherType == enVoucherType.BankPaymentVoucher || VoucherType == enVoucherType.CashPaymentVoucher)
                    queries[queries.Length - 1] += ",0";
                else
                    queries[queries.Length - 1] += "," + this.HeadAmount.EditValue.ToString() + "";
                if (VoucherType == enVoucherType.BankReceiptVoucher || VoucherType == enVoucherType.CashReceiptVoucher)
                    queries[queries.Length - 1] += ",0";

                else
                    queries[queries.Length - 1] += "," + this.HeadAmount.EditValue.ToString() + "";
                queries[queries.Length - 1] += ",1)";
            }

            for (int x = 0; x < gdt.Rows.Count; x++)
            {
                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefChequeNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (gdt.Rows[x]["AccountID_V"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["AccountID_V"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["VParticulars"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VParticulars"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["VRefInvoiceNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefInvoiceNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VRefDeliveryChallanNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefDeliveryChallanNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VRefChequeNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["VRefChequeNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["VDebitAmount"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["VDebitAmount"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (gdt.Rows[x]["VCreditAmount"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["VCreditAmount"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";

                    queries[queries.Length - 1] += ",0)";
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
                    this.Remarks.EditValue = null;
                    this.HeadAccountName.EditValue = null;
                    this.HeadAmount.EditValue = null;
                    this.Particulars.EditValue = null;
                    this.GeneralAccountID.EditValue = null;
                    this.GeneralAccountName.EditValue = null;
                    this.GeneralCredit.EditValue = null;
                    this.GeneralDebit.EditValue = null;
                    this.Voucher_Print.Tag = vnum;
                    this.Voucher_View.Tag = vnum;
                    this.ChequeNumber.EditValue = null;
                    this.InvoiceNumber.EditValue = null;
                    this.DeliveryChallanNumber.EditValue = null;
                    this.Suffix.EditValue = null;
                    gDebitSide = 0;
                    gCreditSide = 0;
                    FetchGridDataSet("XXXXXXX");
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




            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            string[] queries = new string[0];
            string vNumbertoDel = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete   # " + vNumbertoDel + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  AC_Voucher_Sub where VNumber='" + vNumbertoDel + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Main where VNumber='" + vNumbertoDel + "'";
          


            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    ClearAll();
                    this.Suffix.Tag = null;
                    this.Prefix.Tag = null;
                    this.FinancialYear.Tag = null;
                    this.Voucher_Print.Tag = null;
                    this.Voucher_View.Tag = null;
                    SetButtonStates(UserInputMode.View);
                    this.Voucher_Add.Focus();
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
                VtypeCap.Text = "N";


                this.Prefix.Text = N_Number;
                if (uiModeVoucher== UserInputMode.Add || uiModeVoucher == UserInputMode.Edit)
                {

                    GetNextVoucherNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Number;
                if (uiModeVoucher== UserInputMode.Add)
                {

                    GetNextVoucherNumber();
                }
            }
        }

       
        

       
        private void SelectGeneralAccountsFromGrid()
        {
            try
            {
            if (this.GridVew_GeneralAccounts.FocusedRowHandle != -1)
            {
               GridAccountRow = this.GridVew_GeneralAccounts.GetDataRow(this.GridVew_GeneralAccounts.FocusedRowHandle);
                if (GridAccountRow != null)
                {
                    this.GeneralAccountID.EditValue = GridAccountRow["AccountID_V"].ToString();

                    this.GeneralAccountID.Tag = GridAccountRow["AccountID_V"].ToString();
                    this.GeneralAccountName.EditValue = GridAccountRow["AccountID_V"].ToString();
                    if (GridAccountRow["VParticulars"].ToString() != "")
                        this.Particulars.EditValue = GridAccountRow["VParticulars"].ToString();
                    else
                        this.Particulars.EditValue = null;
                    if (GridAccountRow["VRefInvoiceNumber"].ToString() != "")
                        this.InvoiceNumber.EditValue = GridAccountRow["VRefInvoiceNumber"].ToString();
                    else
                        this.InvoiceNumber.EditValue = null;
                    if (GridAccountRow["VRefDeliveryChallanNumber"].ToString() != "")
                        this.DeliveryChallanNumber.EditValue = GridAccountRow["VRefDeliveryChallanNumber"].ToString();
                    else
                        this.DeliveryChallanNumber.EditValue = null;
                    string temp = GridAccountRow["VDebitAmount"].ToString();
                    if (temp != "")
                        this.GeneralDebit.EditValue = temp;
                    else
                        this.GeneralDebit.EditValue = null;
                    temp = "";
                    temp = GridAccountRow["VCreditAmount"].ToString();
                    if (temp != "")
                        this.GeneralCredit.EditValue = temp;
                    else
                        this.GeneralCredit.EditValue = null;
                    SetButtonStates_Detail(UserInputMode.View);
                }
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:SelectGeneralAccountsFromGrid", MessageBoxButtons.OK);
            }
            
            CalculateTotal();
        }
      

       

       

     

       

        
        

       


       
        private void POD_Print_Click(object sender, EventArgs e)
        {
            if (this.Voucher_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PO #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

        private void HeadAmount_EditValueChanged(object sender, EventArgs e)
        {
            if (VoucherType == enVoucherType.BankPaymentVoucher)
            {
                this.HeadDebitSide.EditValue = 0;
                this.HeadCreditSide.EditValue = HeadAmount.EditValue;
            }
            else if (VoucherType == enVoucherType.BankReceiptVoucher)
            {
                this.HeadDebitSide.EditValue = HeadAmount.EditValue;
                this.HeadCreditSide.EditValue = 0;
            }
            else if (VoucherType == enVoucherType.CashPaymentVoucher)
            {
                this.HeadDebitSide.EditValue = 0;
                this.HeadCreditSide.EditValue = HeadAmount.EditValue;
            }
            else if (VoucherType == enVoucherType.CashReceiptVoucher)
            {
                this.HeadDebitSide.EditValue = this.HeadAmount.EditValue;
                this.HeadCreditSide.EditValue = 0;
            }
            else if (VoucherType == enVoucherType.GeneralVoucher)
            {
                this.HeadDebitSide.EditValue = 0;
                this.HeadCreditSide.EditValue = 0;
            }
            CalculateTotal();
        }

        private void Voucher_Add_Click(object sender, EventArgs e)
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
            this.Remarks.EditValue = null;
            this.HeadAccountName.EditValue = null;
            this.HeadAmount.EditValue = null;
            this.Particulars.EditValue = null;
            this.GeneralAccountID.EditValue = null;
            this.GeneralAccountName.EditValue = null;
            this.GeneralCredit.EditValue = null;
            this.GeneralDebit.EditValue = null;
            this.Voucher_Print.Tag = null;
            this.Voucher_View.Tag = null;
            this.ChequeNumber.EditValue = null;
            this.InvoiceNumber.EditValue = null;
            this.DeliveryChallanNumber.EditValue = null;
            this.Suffix.EditValue = null;
          
            gDebitSide = 0;
            gCreditSide = 0;
            FetchGridDataSet("XXXXXXX");
            bool rRes = GetNextVoucherNumber();

            SetButtonStates(UserInputMode.Add);

            this.Dated.Focus();
        }

        private void Voucher_Edit_Click(object sender, EventArgs e)
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

        private void Voucher_Delete_Click(object sender, EventArgs e)
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

        private void Voucher_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void Voucher_Execute_Click(object sender, EventArgs e)
        {
            if (uiModeVoucher == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiModeVoucher == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiModeVoucher == UserInputMode.Delete)
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

        private void Voucher_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HeadAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.Accounts_V(ref this.HeadAccountName);
            }
        }

        private void H_AccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (H_AccountID.Text.Length == 3)
            {
                string CashName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.H_AccountID_IV.Text + this.H_AccountID.Text);
                if (CashName != "")
                {
                    this.HeadAccountName.EditValue = this.H_AccountID_IV.Text + this.H_AccountID.Text;
                }
                
            }
            else
            {
                this.HeadAccountName.EditValue = null;
            }
        }

        private void HeadAccountName_EditValueChanged(object sender, EventArgs e)
        {
            if (HeadAccountName.EditValue != null)
            {
                if (HeadAccountName.EditValue.ToString() != "")
                {
                    this.H_AccountID.EditValue = HeadAccountName.EditValue.ToString().Substring(10, 3);
                }
                else
                    this.H_AccountID.EditValue = null;
            }
            else
                this.H_AccountID.EditValue = null;
        }

        private void GeneralDebit_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void GeneralDebit_KeyUp(object sender, KeyEventArgs e)
        {

            if (GeneralDebit.EditValue != null)
            {
                if (GeneralDebit.EditValue.ToString() != "")
                {
                    long dvalue = 0;
                    long.TryParse(this.GeneralDebit.EditValue.ToString(), out dvalue);
                    if (dvalue != 0)
                        GeneralCredit.EditValue = 0;
                }
            }
        }

        private void GeneralCredit_KeyUp(object sender, KeyEventArgs e)
        {
            if (GeneralCredit.EditValue != null)
            {
                if (GeneralCredit.EditValue.ToString() != "")
                {
                    long dvalue = 0;
                    long.TryParse(this.GeneralCredit.EditValue.ToString(), out dvalue);
                    if (dvalue != 0)
                        this.GeneralDebit.EditValue = 0;
                }
            }
        }

        private void GeneralAccountName_EditValueChanged(object sender, EventArgs e)
        {
            this.GeneralAccountID.EditValue = this.GeneralAccountName.EditValue;
        }

        private void Remarks_EditValueChanged(object sender, EventArgs e)
        {
           
            this.Particulars.EditValue = Remarks.EditValue;
        }
        private void CalculateTotal()
        {
           long thisdebit=0;
            long thiscredit=0;
            long headdebit = 0;
            long headcredit = 0;
            long nowGridDebit = 0;
            long nowGridCredit = 0;
           


                if (this.GeneralDebit.EditValue != null)
                    long.TryParse(this.GeneralDebit.EditValue.ToString(), out thisdebit);
                if (this.GeneralCredit.EditValue != null)
                    long.TryParse(this.GeneralCredit.EditValue.ToString(), out thiscredit);
    
           
            if (this.GridAccountRow != null && uiModeDetail!=UserInputMode.Add)
            {
                  long vDebitAmount = 0;
                    long vCreditAmount = 0;
                    long.TryParse(GridAccountRow["vDebitAmount"].ToString(), out vDebitAmount);
                    long.TryParse(GridAccountRow["vCreditAmount"].ToString(), out vCreditAmount);
                    nowGridDebit = gDebitSide - vDebitAmount;
                    nowGridCredit = gCreditSide - vCreditAmount;
                
            }
            else if (this.GridAccountRow == null && uiModeDetail == UserInputMode.View)
            {
                long vDebitAmount = 0;
                long vCreditAmount = 0;
                if(this.GeneralDebit.EditValue!=null)
                long.TryParse(this.GeneralDebit.EditValue.ToString(), out vDebitAmount);
                if(this.GeneralCredit.EditValue!=null)
                long.TryParse(this.GeneralCredit.EditValue.ToString(), out vCreditAmount);
                nowGridDebit = gDebitSide - vDebitAmount;
                nowGridCredit = gCreditSide - vCreditAmount;
            }
            else
            {
                nowGridDebit = gDebitSide;
                nowGridCredit = gCreditSide;
            }
            if (this.HeadDebitSide.EditValue != null)
                long.TryParse(this.HeadDebitSide.EditValue.ToString(), out headdebit);
            if (this.HeadCreditSide.EditValue != null)
                long.TryParse(this.HeadCreditSide.EditValue.ToString(), out headcredit);

            

            this.GeneralDebitSide.EditValue =  thisdebit;
            this.GeneralCreditSide.EditValue =  thiscredit;
            this.GridDebitSide.EditValue = nowGridDebit;
            this.GridCreditSide.EditValue = nowGridCredit;
            this.TotalDebitSide.EditValue = nowGridDebit + thisdebit + headdebit;
            this.TotalCreditSide.EditValue = nowGridCredit + thiscredit + headcredit;
            long Difference = (nowGridDebit + thisdebit + headdebit) - (nowGridCredit + thiscredit + headcredit);
            if (Difference == 0)
            {
                this.DebitCreditDifference.ForeColor = Color.Black;
                this.DebitCreditDifference.Text = "0";
                this.DebitCreditDifference.Tag = "0";
            }
            else if (Difference > 0)
            {
                this.DebitCreditDifference.ForeColor = Color.Blue;
                this.DebitCreditDifference.Text = Difference.ToString("#,##");
                this.DebitCreditDifference.Tag = Difference.ToString();
            }
            else if (Difference < 0)
            {
                this.DebitCreditDifference.ForeColor = Color.Red;
                Difference = (nowGridCredit + thiscredit + headcredit) - (nowGridDebit + thisdebit + headdebit);
                this.DebitCreditDifference.Text = Difference.ToString("#,##");
                this.DebitCreditDifference.Tag = Difference.ToString();

            }


        }
        private void GeneralAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.GeneralAccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.GeneralAccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                }
            }
            else if (e.KeyCode == Keys.F1 && this.GeneralAccountID.EditValue != null)
            {
                if (this.GeneralAccountID.EditValue.ToString() != "")
                {
                    Accounts.Account_info info = new Accounts.Account_info();
                    info.FillAccount(this.GeneralAccountID.EditValue.ToString());
                    info.ShowDialog();
                }

            }
        }

        private void GeneralCredit_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void GridVew_GeneralAccounts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectGeneralAccountsFromGrid();
        }

        private void Add_Detail_Click(object sender, EventArgs e)
        {
            this.GeneralAccountID.Tag = null;
            this.GeneralAccountID.EditValue = null;
            this.GeneralAccountName.EditValue = null;
            this.GeneralDebit.EditValue = null;
            this.GeneralCredit.EditValue = null;
            
            SetButtonStates_Detail(UserInputMode.Add);
            CalculateTotal();
        }

        private void Execute_Detail_Click(object sender, EventArgs e)
        {
            if (uiModeDetail == UserInputMode.Add)
            {
                AddToGridValues();
            }
            else if (uiModeDetail == UserInputMode.Edit)
            {
               
                UpdateGridValues();
            }
            else if (uiModeDetail == UserInputMode.Delete)
            {
              
                DeleteGridValues();
            }
        }

        private void Edit_Detail_Click(object sender, EventArgs e)
        {

            //if (this.PODNumber.EditValue == null)
            //{
            //    XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            SetButtonStates_Detail(UserInputMode.Edit);
            CalculateTotal();
        }

        private void Delete_Detail_Click(object sender, EventArgs e)
        {
            //if (this.PODNumber.EditValue == null)
            //{
            //    XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            SetButtonStates_Detail(UserInputMode.Delete);
        }

        private void Cancel_Detail_Click(object sender, EventArgs e)
        {
            SetButtonStates_Detail(UserInputMode.View);
        }

        private void GeneralDebit_Leave(object sender, EventArgs e)
        {
            if (GeneralDebit.EditValue != null)
            {
                if (GeneralDebit.EditValue.ToString() != "")
                {
                    long dvalue = 0;
                    long.TryParse(this.GeneralDebit.EditValue.ToString(), out dvalue);
                    if (dvalue != 0)
                        GeneralCredit.EditValue = 0;
                }
            }
        }

        private void GeneralCredit_Leave(object sender, EventArgs e)
        {
            if (GeneralCredit.EditValue != null)
            {
                if (GeneralCredit.EditValue.ToString() != "")
                {
                    long dvalue = 0;
                    long.TryParse(this.GeneralCredit.EditValue.ToString(), out dvalue);
                    if (dvalue != 0)
                        this.GeneralDebit.EditValue = 0;
                }
            }
        }

        private void DebitCreditDifference_Click(object sender, EventArgs e)
        {
            if (DebitCreditDifference.Tag != null)
            {
                if (DebitCreditDifference.ForeColor == Color.Blue)
                    this.GeneralCredit.EditValue = DebitCreditDifference.Tag.ToString();
                else if (DebitCreditDifference.ForeColor == Color.Red)
                    this.GeneralDebit.EditValue = DebitCreditDifference.Tag.ToString();
            }
        }

        private void Voucher_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.F_Dated.Checked == true)
            {
                if (this.Dated.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.Dated.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            if (this.F_VNumber.Checked == true)
            {
                if (this.Suffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Voucher filter or enter valid voucher", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }



            strFilterQuery = "SELECT VNumber,vDate,AccountID_V,AccountName_V,vDebitAmount,vCreditAmount FROM Accounts_Vouchers ";
            strFilterQuery += "  where VType='" + this.Prefix.Text + "' and VYear='" + this.FinancialYear.Text + "' and vStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' ";



            if (F_Dated.Checked == true)
            {

                strFilterQuery += " and vDate='" + Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }



            if (this.F_VNumber.Checked == true)
            {

                strFilterQuery += " and vNumber like '%" + this.Suffix.Text + "%'";

            }


         
            strFilterQuery += " ORDER BY Convert(numeric(18),vNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "VNumber", "VNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
               
                Fill_Voucher(sRow.PrimeryID);

            }
        }
        private void ClearAll()
        {
            this.Remarks.EditValue = null;
            this.HeadAccountName.EditValue = null;
            this.HeadAmount.EditValue = null;
            this.Particulars.EditValue = null;
            this.GeneralAccountID.EditValue = null;
            this.GeneralAccountName.EditValue = null;
            this.GeneralCredit.EditValue = null;
            this.GeneralDebit.EditValue = null;
            this.ChequeNumber.EditValue = null;
            this.InvoiceNumber.EditValue = null;
            this.DeliveryChallanNumber.EditValue = null;
            this.Suffix.EditValue = null;
            gDebitSide = 0;
            gCreditSide = 0;
            FetchGridDataSet("XXXXXXX");
            SetButtonStates(UserInputMode.View);
        }
        private void Fill_Voucher(string vNumber)
        {
            ClearAll();
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from AC_Voucher_Main where vNumber='" + vNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;
            this.Dated.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            if (ds_VoucherMain.Tables[0].Rows[0]["VCat"].ToString() == "G")
            {
                this.NG.Checked = false;

            }
            else
            {

                this.NG.Checked = true;
            }
            string a = ds_VoucherMain.Tables[0].Rows[0]["VAuthorized"].ToString();


            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["VStatus"].ToString();
            this.Remarks.EditValue = ds_VoucherMain.Tables[0].Rows[0]["VRemarks"].ToString();
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            if (VoucherType != enVoucherType.GeneralVoucher)
            {
                DataSet ds_VoucherHead = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + vNumber + "' and isHead=1");
                if (ds_VoucherHead == null) return;
                if (ds_VoucherHead.Tables[0].Rows.Count <= 0) return;
                if (ds_VoucherHead.Tables[0].Rows[0]["VRefChequeNumber"].ToString() != "")
                    this.ChequeNumber.EditValue = ds_VoucherHead.Tables[0].Rows[0]["VRefChequeNumber"].ToString();
                else
                    this.ChequeNumber.EditValue = null;
                if(VoucherType==enVoucherType.BankPaymentVoucher || VoucherType==enVoucherType.CashPaymentVoucher)
                    this.HeadAmount.EditValue = ds_VoucherHead.Tables[0].Rows[0]["VCreditAmount"].ToString();
                else if(VoucherType==enVoucherType.BankReceiptVoucher || VoucherType==enVoucherType.CashReceiptVoucher)
                    this.HeadAmount.EditValue = ds_VoucherHead.Tables[0].Rows[0]["VDebitAmount"].ToString();
                this.HeadAccountName.EditValue = ds_VoucherHead.Tables[0].Rows[0]["AccountID_V"].ToString();
            }
            //DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from AC_Voucher_Main where vNumber='" + vNumber + "'");
            //if (ds_VoucherMain == null) return;
            //if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;

            this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            this.FinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            this.Voucher_Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString();
            this.Voucher_View.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString();
            this.FindVoucher.EditValue = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            FetchGridDataSet(vNumber);
            SetButtonStates(UserInputMode.View);
          
        }

        private void Voucher_Print_Click(object sender, EventArgs e)
        {
            //if(VoucherType==enVoucherType.GeneralVoucher)
            //MachineEyes.Classes.Accounting.Print_GeneralVoucher(this.Voucher_Print.Tag.ToString(), "Journal Voucher", this.RadioPageSetting.EditValue.ToString());
            //else if(VoucherType==enVoucherType.BankPaymentVoucher)
            //    MachineEyes.Classes.Accounting.Print_BankPaymentVoucher(this.Voucher_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
            //else if (VoucherType == enVoucherType.CashPaymentVoucher)
            //    MachineEyes.Classes.Accounting.Print_CashPaymentVoucher(this.Voucher_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
            //else if (VoucherType == enVoucherType.BankReceiptVoucher)
            //    MachineEyes.Classes.Accounting.Print_BankReceiptVoucher(this.Voucher_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
            //else if (VoucherType == enVoucherType.CashReceiptVoucher)
            //    MachineEyes.Classes.Accounting.Print_CashReceiptVoucher(this.Voucher_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());


            if (VoucherType == enVoucherType.GeneralVoucher)
                MachineEyes.Classes.Accounting.Print_VoucherMDC(this.Voucher_Print.Tag.ToString(), "Journal Voucher", this.RadioPageSetting.EditValue.ToString());
            else if (VoucherType == enVoucherType.BankPaymentVoucher)
                MachineEyes.Classes.Accounting.Print_VoucherMDC(this.Voucher_Print.Tag.ToString(), "Bank Payment Voucher", this.RadioPageSetting.EditValue.ToString());
            else if (VoucherType == enVoucherType.CashPaymentVoucher)
                MachineEyes.Classes.Accounting.Print_VoucherMDC(this.Voucher_Print.Tag.ToString(), "Cash Payment Voucher", this.RadioPageSetting.EditValue.ToString());
            else if (VoucherType == enVoucherType.BankReceiptVoucher)
                MachineEyes.Classes.Accounting.Print_VoucherMDC(this.Voucher_Print.Tag.ToString(), "Bank Receipt Voucher", this.RadioPageSetting.EditValue.ToString());
            else if (VoucherType == enVoucherType.CashReceiptVoucher)
                MachineEyes.Classes.Accounting.Print_VoucherMDC(this.Voucher_Print.Tag.ToString(), "Cash Receipt Voucher", this.RadioPageSetting.EditValue.ToString());
        }

        private void Clone_Click(object sender, EventArgs e)
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
            bool rRes = GetNextVoucherNumber();
            SetButtonStates(UserInputMode.Add);
            this.Dated.Focus();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            ClearAll();
            if (FindVoucher.EditValue == null) return;
            if (FindVoucher.EditValue.ToString().Length != 6) return;
            string vNumber= this.Prefix.EditValue.ToString() + this.FinancialYear.EditValue.ToString() + FindVoucher.EditValue.ToString();
         
            Fill_Voucher(vNumber);
        }

        private void FindVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClearAll();
                if (FindVoucher.EditValue == null) return;
                if (FindVoucher.EditValue.ToString().Length != 6) return;
                string vNumber = this.Prefix.EditValue.ToString() + this.FinancialYear.EditValue.ToString() + FindVoucher.EditValue.ToString();
             
                Fill_Voucher(vNumber);
            }
        }

        private void InvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.GeneralAccountID.EditValue == null) return;
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select iNumber,iDate,ValExTax,ValTax,ValInTax from AC_Sales_Main where BuyerID='" + this.GeneralAccountID.EditValue.ToString() + "'";
                    FrmView.Load_View(query, "iNumber", "iNumber");

                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.InvoiceNumber.EditValue = sRow.PrimeryID;
                        this.InvoiceNumber.Tag = sRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (e.KeyCode == Keys.Enter && e.Shift == true)
            {
                try
                {
                    if (this.GeneralAccountID.EditValue == null) return;
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select SupplierInvoiceNumber,iDate,ValExTax,ValTax,ValInTax from AC_Purchases_Main where SupplierID='" + this.GeneralAccountID.EditValue.ToString() + "'";
                    FrmView.Load_View(query, "SupplierInvoiceNumber", "SupplierInvoiceNumber");

                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.InvoiceNumber.EditValue = sRow.PrimeryID;
                        this.InvoiceNumber.Tag = sRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Control == false)
                this.InvoiceNumber.EditValue = null;
        }

        private void GeneralAccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.InvoiceNumber.EditValue = null;
        }

       
    }
}