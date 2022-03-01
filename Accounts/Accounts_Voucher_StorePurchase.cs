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
    public partial class Accounts_Voucher_StorePurchase : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private easyVoucherCalculations vCalc = new easyVoucherCalculations();
        private string G_Number;
        private string N_Number;
        public Accounts_Voucher_StorePurchase()
        {
            InitializeComponent();
            this.VPrefix.Text = "620";
            G_Number = "620";
            N_Number = "621";
            vCalc.controls_Difference = this.TotalDiff;
            vCalc.controls_MultiTotal = this.TotalDebitSide;
            vCalc.controls_SingleTotal = this.TotalCreditSide;

            UserControls.AccountGeneral General = new UserControls.AccountGeneral();
            General.eVC = vCalc;
            this.tableLayoutPanel_Detail.Controls.Add(General);
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
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StorePR set iStatus='U' where PRNO='"+this.RefPRNO.EditValue.ToString()+"'";
        
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
                    UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                    General.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(General);
                    this.View.Tag = "";
                    ButtonStates(UserInputMode.View);
                   
                    
                
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
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
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
           
         
           
            
            if (vCalc.difference != 0)
            {
                XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }

            foreach (Control c in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountGeneral Ac = (UserControls.AccountGeneral)c;


                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag == null)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.Debit.EditValue == null)
                {
                    XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Debit.Focus();
                    return;
                }
                if (Ac.Credit.EditValue == null)
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Credit.Focus();
                    return;
                }

            }
            double cCreditHead = 0;
            if (this.AutoCreditAmount.EditValue != null)
                double.TryParse(this.AutoCreditAmount.EditValue.ToString(), out cCreditHead);

            if (cCreditHead <= 0)
            {
                XtraMessageBox.Show("Credit head account amount is not valid.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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


           
                queries[0] += ",vRemarks=null";
          
                queries[0] += ",vAmount=" + vCalc.singleTotal.ToString() + "";
          
            queries[0] += " where vNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where vNumber='" + veditNum + "'";


            string vParticulars = "Ref Purchase Register # " + this.RefPRNO.EditValue.ToString();
            if (this.RefPONO.EditValue != null) vParticulars += " PO # " + this.RefPONO.EditValue.ToString();
            vParticulars += " Purchases ";
            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountGeneral AField = (UserControls.AccountGeneral)C;
                Array.Resize(ref queries, queries.Length + 1);
                double dAmount = 0;
                if (AField.Debit.EditValue != null)
                    double.TryParse(AField.Debit.EditValue.ToString(), out dAmount);
                vParticulars += AField.AccountName.Text + " of Amount Rs. " + dAmount.ToString("#,##");
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VDebitAmount,vCreditAmount,isHead) Values (";
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
                if (AField.Debit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Debit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",0";

                if (AField.Credit.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Credit.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";

                queries[queries.Length - 1] += ",0)";
            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VDebitAmount,vCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (vParticulars != "")
                queries[queries.Length - 1] += ",'" + vParticulars + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null";


            queries[queries.Length - 1] += ",null";
            if (this.RefPRNO.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPRNO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",0";

            if (this.AutoCreditAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.AutoCreditAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            queries[queries.Length - 1] += ",1)";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StorePR set iStatus='P',pUserID='" + MachineEyes.Classes.Security.User.UserID + "',pUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "' where PRNO='" + this.RefPRNO.EditValue.ToString() + "'";

      
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
                    UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                    General.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(General);
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    ButtonStates(UserInputMode.View);
                  
                   
                 
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
            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Account ID", "Error");
                return;
            }
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
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
           
          
            if (vCalc.difference != 0)
            {
                XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }
            
          
            foreach (Control c in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountGeneral Ac = (UserControls.AccountGeneral)c;
                
               
                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag == null)
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Credited Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.Debit.EditValue == null)
                {
                    XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Debit.Focus();
                    return;
                }
                if (Ac.Credit.EditValue == null)
                {
                    XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.Credit.Focus();
                    return;
                }
           
            }
            double cCreditHead = 0;
            if(this.AutoCreditAmount.EditValue!=null)
            double.TryParse(this.AutoCreditAmount.EditValue.ToString(), out cCreditHead);
           
            if (cCreditHead<=0)
            {
                XtraMessageBox.Show("Credit head account amount is not valid.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
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
            queries[0] = "insert into AC_Voucher_Main (VNumber,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,PRNO,PONO,VAmount,vAuthorized,vClosed,CUserID,CUserTime) Values (";
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
          
                queries[0] += ",'To Record Store Purchases'";
                queries[0] += ",'"+this.RefPRNO.EditValue.ToString()+"'";
                if (this.RefPONO.EditValue != null)
                    queries[0] += "," + this.RefPONO.EditValue.ToString() + "";
                else
                    queries[0] += ",null";
                queries[0] += "," + vCalc.multiTotal + "";
           
            queries[0] += ",0,0";
            queries[0] += ",'" +MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[0] += ")";


            string vParticulars = "Ref Purchase Register # " + this.RefPRNO.EditValue.ToString();
            if (this.RefPONO.EditValue != null) vParticulars += " PO # " + this.RefPONO.EditValue.ToString();
            vParticulars+=" Purchases ";
            foreach (Control C in this.tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountGeneral AField = (UserControls.AccountGeneral)C;
                Array.Resize(ref queries, queries.Length + 1);
                double dAmount = 0;
                if(AField.Debit.EditValue!=null)
                double.TryParse(AField.Debit.EditValue.ToString(), out dAmount);
                vParticulars +=  AField.AccountName.Text + " of Amount Rs. " + dAmount.ToString("#,##");
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VDebitAmount,vCreditAmount,isHead) Values (";
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
                if (AField.Debit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Debit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",0";

                if (AField.Credit.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Credit.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";

                queries[queries.Length - 1] += ",0)";
            }

             Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefBillNumber,VDebitAmount,vCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (this.AccountID.EditValue!=null)
                queries[queries.Length - 1] += ",'" +AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
          
            if (vParticulars != "")
                queries[queries.Length - 1] += ",'" + vParticulars + "'";
            else
                queries[queries.Length - 1] += ",null";
            
                queries[queries.Length - 1] += ",null";

           
                queries[queries.Length - 1] += ",null";
                if (this.RefPRNO.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.RefPRNO.EditValue.ToString() + "'";
                else
                queries[queries.Length - 1] += ",null";
          
                queries[queries.Length - 1] += ",0";

            if (this.AutoCreditAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.AutoCreditAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            queries[queries.Length - 1] += ",1)";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StorePR set iStatus='P',pUserID='" + MachineEyes.Classes.Security.User.UserID + "',pUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "' where PRNO='"+this.RefPRNO.EditValue.ToString()+"'";

          
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
                    this.RefPRNO.EditValue = null;
                    this.RefPONO.EditValue = null;
                    this.AutoCreditAmount.EditValue =null;                    
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                    General.eVC = vCalc;
                    this.tableLayoutPanel_Detail.Controls.Add(General);
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    this.TotalCreditSide.EditValue = 0;
                    this.TotalDebitSide.EditValue = 0;
                    this.TotalDiff.EditValue = 0;
                    this.AutoCreditAmount.EditValue = null;
                    ButtonStates(UserInputMode.View);
                 
                 
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
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
                if (this.RefPRNO.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Reference Purchase Register #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

           
           
          
           
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
                UserControls.AccountGeneral aField = (UserControls.AccountGeneral)C;
                if (aField.Filter_AccountID.Checked == true || aField.Filter_Credit.Checked == true || aField.Filter_BillNumber.Checked == true  || aField.Filter_DeliveryChallanNumber.Checked == true || aField.Filter_InvoiceNumber.Checked == true)
                {

                    if (aField.Filter_AccountID.Checked == true)
                    {
                        if (aField.AccountName.Tag == null)
                        {
                            XtraMessageBox.Show("Either uncheck the Account ID filter or enter valid Account ID", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.AccountID.Focus();
                            return;
                        }
                        if (aField.AccountName.Tag.ToString() == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Account ID filter or enter valid Account ID", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.AccountID.Focus();
                            return;
                        }

                    }
                    if (aField.Filter_Credit.Checked == true)
                    {
                        if (aField.Credit.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Credit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Filter_Credit.Focus();
                            return;
                        }
                    }
                    if (aField.Filter_Debit.Checked == true)
                    {
                        if (aField.Debit.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.Filter_Debit.Focus();
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
                  
                   
                    if (aField.Filter_DeliveryChallanNumber.Checked == true)
                    {
                        if (aField.Filter_DeliveryChallanNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Delivery challan Filter or enter valid Delivery Challan Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                           
                            return;
                        }
                    }
                    if (aField.Filter_InvoiceNumber.Checked == true)
                    {
                        if (aField.Filter_InvoiceNumber.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Invoice Number Filter or enter valid invoice", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                          
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

          

            if (this.Filter_VoucherNumber.Checked == true)
            {

                strFilterQuery += " and vNumber like '%" + this.VSuffix.Text + "%'";

            }
          
            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in tableLayoutPanel_Detail.Controls)
            {
                UserControls.AccountGeneral aField = (UserControls.AccountGeneral)C;

                if (aField.Filter_AccountID.Checked == true || aField.Filter_Credit.Checked == true || aField.Filter_Debit.Checked == true || aField.Filter_BillNumber.Checked == true  || aField.Filter_DeliveryChallanNumber.Checked == true || aField.Filter_InvoiceNumber.Checked == true)
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
                    if (aField.Filter_Debit.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vDebitAmount=" + aField.Debit.Text + "";
                        Appendand = true;
                    }
                    if (aField.Filter_Credit.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vCreditAmount=" + aField.Credit.Text + "";
                        Appendand = true;
                    }
                    if (aField.Filter_BillNumber.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vRefBillNumber='" + aField.BillNumber.Text + "'";
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            ButtonStates(UserInputMode.View);
        }
        private void ClearAll()
        {
           
            this.VSuffix.Text = "";
            this.VSuffix.Tag = "";
            this.AutoCreditAmount.EditValue  = null;
             this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
            this.tableLayoutPanel_Detail.Controls.Clear();
            UserControls.AccountGeneral Payment = new UserControls.AccountGeneral();
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
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            this.RefPRNO.EditValue = ds_VoucherMain.Tables[0].Rows[0]["PRNO"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["PONO"].ToString() != "")
                this.RefPONO.EditValue = ds_VoucherMain.Tables[0].Rows[0]["PONO"].ToString();
            else
                this.RefPONO.EditValue = null;
            this.VSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VPrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.VPrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            this.FinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);

            DataSet ds_VoucherSub_H = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + VNumber + "' and isHead=1");
            if (ds_VoucherSub_H == null) return;
            this.AccountID.EditValue = ds_VoucherSub_H.Tables[0].Rows[0]["AccountID_V"].ToString();
            this.AutoCreditAmount.EditValue = ds_VoucherSub_H.Tables[0].Rows[0]["vCreditAmount"].ToString();
            int moreCreditTotal=0;
            int.TryParse(this.AutoCreditAmount.EditValue.ToString(),out moreCreditTotal);
            vCalc.moreCreditTotal = moreCreditTotal;

            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + VNumber + "' and isHead=0");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_Detail.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                General.eVC = vCalc;
                this.tableLayoutPanel_Detail.Controls.Add(General);
                General.AccountID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID_V"].ToString();
                General.Credit.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["VCreditAmount"].ToString();
                General.Debit.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["VDebitAmount"].ToString();
                General.Particulars.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VParticulars"].ToString();
                General.InvoiceNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefInvoiceNumber"].ToString();
                General.DeliveryChallanNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefDeliveryChallanNumber"].ToString();
                General.BillNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["VrefBillNumber"].ToString();
                
                General.CalculateCreditTotal();
                General.CalculateDebitTotal();
            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }
        private void CalculateTotal()
        {

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

            Accounting.Print_GeneralVoucher(this.Print.Tag.ToString(),"Journal Voucher",this.RadioPageSetting.EditValue.ToString());

        }

        private void ChangeState_Click(object sender, EventArgs e)
        {

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

        private void RefPRNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                double DebitAmount = 0;
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select PRNO as PurchaseRegisterNo,PONO as PurchaseOrderNumber,Dated,AccountID,AccountName,AutoItemsDesc from RST_StorePR where iStatus='U' and PRTypeID=0 and ICAT='"+this.NG.Tag.ToString()+"'", "PurchaseRegisterNo", "AccountID");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.RefPRNO.EditValue = sRow.PrimeryID;
                    this.AccountID.EditValue = sRow.PrimaryString;
                    this.RefPONO.EditValue = sRow.SelectedDataRow["PurchaseOrderNumber"].ToString();
                    string sql = "Select ItemTypeID,ControlAccountID,ControlAccountName,MappedAccountID,AssetsMappedAccountID,AutoItemsDesc,sum(PRDAmount) as DebitAmount from RST_StoreDetails where PRNO='" + sRow.PrimeryID + "' group by ControlAccountID,ControlAccountName,MappedAccountID,AssetsMappedAccountID,ItemTypeID,AutoItemsDesc";
                    DataSet ds = WS.svc.Get_DataSet(sql);
                    if (ds == null) return;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                        General.eVC = vCalc;
                        this.tableLayoutPanel_Detail.Controls.Add(General);
                        if(ds.Tables[0].Rows[x]["ItemTypeID"].ToString()=="1")
                        General.AccountID.EditValue = ds.Tables[0].Rows[x]["MappedAccountID"].ToString();
                        else
                            General.AccountID.EditValue = ds.Tables[0].Rows[x]["AssetsMappedAccountID"].ToString();
                        string cid = ds.Tables[0].Rows[x]["MappedAccountID"].ToString();
                        string sid = ds.Tables[0].Rows[x]["AssetsMappedAccountID"].ToString();

                        General.AccountID.Tag = ds.Tables[0].Rows[x]["ControlAccountID"].ToString();
                        General.AccountName.Tag = ds.Tables[0].Rows[x]["ControlAccountName"].ToString();
                        General.Credit.EditValue = "0";
                        General.Debit.EditValue = ds.Tables[0].Rows[x]["DebitAmount"].ToString();
                        double tDebit = 0;
                        double.TryParse(ds.Tables[0].Rows[x]["DebitAmount"].ToString(), out tDebit);
                        DebitAmount += tDebit;
                        string vParticulars = "";
                        vParticulars+= "Purchase Invoice # " + this.RefPRNO.EditValue.ToString();
                        if (this.RefPONO.EditValue != null) vParticulars += " PO # " + this.RefPONO.EditValue.ToString();
                        vParticulars += " Purchases " + ds.Tables[0].Rows[x]["ControlAccountName"].ToString() + "  " + ds.Tables[0].Rows[x]["AutoItemsDesc"].ToString();
                        General.Particulars.Text = vParticulars;
                        General.InvoiceNumber.Text = "";
                        General.DeliveryChallanNumber.Text = "";
                        General.BillNumber.EditValue = this.RefPRNO.EditValue;
                        
                        General.CalculateCreditTotal();
                        General.CalculateDebitTotal();
                    }
                    this.AutoCreditAmount.EditValue  = DebitAmount.ToString();
                    vCalc.moreCreditTotal=(int)DebitAmount;
                    vCalc.multiTotal = (int)DebitAmount;
                }
            }
            else if (e.KeyCode == Keys.Enter && e.Shift == true)
            {
                double DebitAmount = 0;
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select PRNO as PurchaseRegisterNo,PONO as PurchaseOrderNumber,Dated,AccountID,AccountName,AutoItemsDesc from RST_StorePR where PRNO not in(Select PRNO from AC_Voucher_Main where PRNO is not null) and PRTypeID=0 and ICAT='" + this.NG.Tag.ToString() + "'", "PurchaseRegisterNo", "AccountID");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.RefPRNO.EditValue = sRow.PrimeryID;
                    this.AccountID.EditValue = sRow.PrimaryString;
                    this.RefPONO.EditValue = sRow.SelectedDataRow["PurchaseOrderNumber"].ToString();
                    string sql = "Select ControlAccountID,ControlAccountName,MappedAccountID,sum(PRDAmount) as DebitAmount from RST_StoreDetails where PRNO='" + sRow.PrimeryID + "' group by ControlAccountID,ControlAccountName,MappedAccountID";
                    DataSet ds = WS.svc.Get_DataSet(sql);
                    if (ds == null) return;
                    this.tableLayoutPanel_Detail.Controls.Clear();
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        UserControls.AccountGeneral General = new UserControls.AccountGeneral();
                        General.eVC = vCalc;
                        this.tableLayoutPanel_Detail.Controls.Add(General);
                        if (ds.Tables[0].Rows[x]["ItemTypeID"].ToString() == "1")
                            General.AccountID.EditValue = ds.Tables[0].Rows[x]["MappedAccountID"].ToString();
                        else
                            General.AccountID.EditValue = ds.Tables[0].Rows[x]["AssetsMappedAccountID"].ToString();
                        string cid = ds.Tables[0].Rows[x]["MappedAccountID"].ToString();
                        string sid = ds.Tables[0].Rows[x]["AssetsMappedAccountID"].ToString();

                        General.AccountID.Tag = ds.Tables[0].Rows[x]["ControlAccountID"].ToString();
                        General.AccountName.Tag = ds.Tables[0].Rows[x]["ControlAccountName"].ToString();
                        General.Credit.EditValue = "0";
                        General.Debit.EditValue = ds.Tables[0].Rows[x]["DebitAmount"].ToString();
                        double tDebit = 0;
                        double.TryParse(ds.Tables[0].Rows[x]["DebitAmount"].ToString(), out tDebit);
                        DebitAmount += tDebit;
                        string vParticulars = "";
                        vParticulars += "Purchase Invoice # " + this.RefPRNO.EditValue.ToString();
                        if (this.RefPONO.EditValue != null) vParticulars += " PO # " + this.RefPONO.EditValue.ToString();
                        vParticulars += " Purchases " + ds.Tables[0].Rows[x]["ControlAccountName"].ToString() + "  " + ds.Tables[0].Rows[x]["AutoItemsDesc"].ToString();
                        General.Particulars.Text = vParticulars;
                        General.InvoiceNumber.Text = "";
                        General.DeliveryChallanNumber.Text = "";
                        General.BillNumber.EditValue = this.RefPRNO.EditValue;

                        General.CalculateCreditTotal();
                        General.CalculateDebitTotal();
                    }
                    this.AutoCreditAmount.EditValue = DebitAmount.ToString();
                    vCalc.moreCreditTotal = (int)DebitAmount;
                    vCalc.multiTotal = (int)DebitAmount;
                }
            }
        }

        private void VPrefix_Click(object sender, EventArgs e)
        {

        }

        private void AccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.AccountID.EditValue != null)
            {
                string sAccountName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AccountID.EditValue.ToString());
                if (sAccountName != "")
                    this.AccountName.EditValue = sAccountName;
                else
                    this.AccountName.EditValue = null;
            }
            else
            {
                this.AccountName.EditValue = null;
            }
        }

        private void Accounts_Voucher_StorePurchase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dailyShift_Summary1.RP_DailyShiftSummary' table. You can move, or remove it, as needed.
           // this.rP_DailyShiftSummaryTableAdapter.Fill(this.dailyShift_Summary1.RP_DailyShiftSummary);

        }
    }
}