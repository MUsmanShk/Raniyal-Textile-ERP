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
    public partial class Accounts_PaymentAdvice : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Number;
        private string N_Number;
        public Accounts_PaymentAdvice()
        {
            InitializeComponent();

            this.VPrefix.Text = "532";
            G_Number = "532";
            N_Number = "542";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.vDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            FillCombos fc = new FillCombos();
            fc.MeasurementUnits(ref this.Unit);
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
        private void GetNextVoucherNumber()
        {
            try
            {
                string vNum =  ReturnMaxNumber("select max(Convert(numeric(18),SubString(VNumber,8,6)))+1 as MaxNumber  from AC_PaymentAdvice_Main where VYear='" + this.FinancialYear.Text + "' and VType='" + this.VPrefix.Text + "' and VCat='" + this.NG.Tag + "'");
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

        private void Add_Click(object sender, EventArgs e)
        {
            ButtonStates(UserInputMode.Add);
            GetNextVoucherNumber();
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
            if (this.AccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
                return;
            }
            if (this.AccountID.Tag == null)
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
                return;
            }
            if (this.AccountName.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountName.Focus();
                return;
            }
            if (this.Amount.EditValue == null)
            {
                XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }
            int cAmount = 0;
            if (Int32.TryParse(this.Amount.EditValue.ToString(), out cAmount) == false)
            {
                XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }
            if (cAmount <= 0)
            {
                XtraMessageBox.Show("Bank Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }

            if (Check_Item.Checked == true)
            {
                if (this.Item.Text == "")
                {
                    XtraMessageBox.Show("item seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Item.Focus();
                    return;
                }
                if (this.Quantity.EditValue == null)
                {
                    XtraMessageBox.Show("item quantity seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Quantity.Focus();
                    return;
                }
                if (this.ItemRate.EditValue == null)
                {
                    XtraMessageBox.Show("item rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ItemRate.Focus();
                    return;
                }
                if (this.Unit.EditValue == null)
                {
                    XtraMessageBox.Show("item unit seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Unit.Focus();
                    return;
                }
                double itemamount = 0;
                double.TryParse(this.Item_Amount.EditValue.ToString(), out itemamount);
                if (itemamount <= 0)
                {
                    XtraMessageBox.Show("item amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Item_Amount.Focus();
                    return;
                }
                //double.TryParse(this.ItemRate.EditValue.ToString(), out rate);
                //if (rate <= 0)
                //{
                //    XtraMessageBox.Show("item rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.ItemRate.Focus();
                //    return;
                //}
                //if (this.Item.Text == "")
                //{
                //    XtraMessageBox.Show("item seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.Item.Focus();
                //    return;
                //}
               

            }
            if (this.GST_Check.Checked == true)
            {
               
                if (this.GST_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("gst rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Rate.Focus();
                    return;
                }
                if (this.GST_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("gst amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Amount.Focus();
                    return;
                }
                double gstamount = 0;
                //double.TryParse(this.GST_Rate.EditValue.ToString(), out gstrate);
                //if (gstrate <= 0)
                //{
                //    XtraMessageBox.Show("gst rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    this.GST_Rate.Focus();
                //    return;
                //}
                double.TryParse(this.GST_Amount.EditValue.ToString(), out gstamount);
                if (gstamount <= 0)
                {
                    XtraMessageBox.Show("gst amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Amount.Focus();
                    return;
                }
               

            }

            if (this.ITAX_Check.Checked == true)
            {

                if (this.ITAX_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("income tax rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Rate.Focus();
                    return;
                }
                if (this.ITAX_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("income tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }
                double itaxamount = 0;
              
                double.TryParse(this.ITAX_Amount.EditValue.ToString(), out itaxamount);
                if (itaxamount <= 0)
                {
                    XtraMessageBox.Show("income tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }


            }
            if (this.WHT_Check.Checked == true)
            {

                if (this.WHT_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("with holding tax rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.WHT_Rate.Focus();
                    return;
                }
                if (this.WHT_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("with holding tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }
                double  whtamount = 0;
              
              
                double.TryParse(this.WHT_Amount.EditValue.ToString(), out whtamount);
                if (whtamount <= 0)
                {
                    XtraMessageBox.Show("with holding tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.WHT_Amount.Focus();
                    return;
                }


            }
            int GIW = 0;
            if (this.Check_Item.Checked == true || GST_Check.Checked == true || WHT_Check.Checked == true || ITAX_Check.Checked == true)
            {
                GIW = 1;
            }
            else
                GIW = 0;
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
                XtraMessageBox.Show("number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            queries[0] = "insert into AC_PaymentAdvice_Main (VNumber,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,VAmount,GIW,CUserID,CUserTime) Values (";
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
            if (this.Particulars.Text != "")
                queries[0] += ",'" + this.Particulars.Text + "'";
            else
                queries[0] += ",null";
            if (this.Amount.EditValue!=null)
                queries[0] += "," + this.Amount.EditValue.ToString() + "";
            else
                queries[0] += ",0";
            if (GIW ==1)
                queries[0] += ",1";
            else
                queries[0] += ",0";
            queries[0] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[0] += ")";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_PaymentAdvice_Sub (VNumber,AccountID_V,VParticulars,PurchaseContractNumber,VRefInvoiceNumber,VRefDeliveryChallanNumber,VRefDebitNoteNumber,vRefCreditNoteNumber,VCreditAmount,item,itemrate,itemqty,itemamount,itemunit,gst_rate,gst_Amount,itax_rate,itax_Amount,wht_rate,wht_amount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (this.AccountID.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountID.Text  + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Particulars.Text != "")
                queries[queries.Length - 1] += ",'" + this.Particulars.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PurchaseContractNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.PurchaseContractNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.InvoiceNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.InvoiceNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.DeliveryChallanNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.DeliveryChallanNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.DebiteNoteNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.DebiteNoteNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.CreditNoteNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.CreditNoteNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Amount.EditValue != null)
                queries[queries.Length - 1] += "," + this.Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Check_Item.Checked ==true)
                queries[queries.Length - 1] += ",'" + this.Item.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += "," + this.ItemRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += "," + this.Quantity.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += "," + this.Item_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",'" + this.Unit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.GST_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.GST_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.GST_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.GST_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ITAX_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.ITAX_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ITAX_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.ITAX_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.WHT_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.WHT_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.WHT_Check.Checked == true)
                queries[queries.Length - 1] += "," + this.WHT_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",1)";

          
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
                  
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    ButtonStates(UserInputMode.View);
                    this.Particulars.Text = "";
                    this.InvoiceNumber.Text = "";
                    this.DeliveryChallanNumber.Text = "";
                    this.DebiteNoteNumber.Text = "";
                    this.CreditNoteNumber.Text = "";
                    this.PurchaseContractNumber.Text = "";
                    this.Amount.EditValue = null;
                    this.AccountID.Text = "";
                    this.AccountID.Tag = "";
                    this.AccountName.Text = "";
                    this.AccountName.Tag = "";
                    this.GST_Check.Checked = false;
                    this.WHT_Check.Checked = false;
                    this.ITAX_Check.Checked = false;
                    this.Check_Item.Checked = false;
                    this.WHT_Rate.EditValue = 0;
                    this.WHT_Amount.EditValue  = 0;
                    this.GST_Rate.EditValue = 0;
                    this.GST_Amount.EditValue = 0;
                    this.Quantity.EditValue = 0;
                    this.ItemRate.EditValue = 0;

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Voucher()
        {
            string veditNum = this.VPrefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.VSuffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Payment Advice # " + veditNum, "Delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            queries[0] = "delete from  AC_PaymentAdvice_Sub where  VNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_PaymentAdvice_Main where  VNumber='" + veditNum + "'";
           
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
                    
                    this.View.Tag = "";
                    ButtonStates(UserInputMode.View);
                    
                    this.VPrefix.Tag = "";
                    this.VSuffix.Tag = "";
                    this.VSuffix.Text = "";
                    this.AccountID.Tag = "";
                    this.AccountID.Text = "";
                    this.AccountName.Text = "";
                    this.AccountName.Tag = "";
                    this.Amount.EditValue = null;
                    this.Particulars.Text = "";
                    this.InvoiceNumber.Text = "";
                    this.PurchaseContractNumber.Text = "";
                    this.DeliveryChallanNumber.Text = "";
                    this.GST_Check.Checked = false;
                    this.WHT_Check.Checked = false;
                    this.ITAX_Check.Checked = false;
                    this.Check_Item.Checked = false;
                    this.WHT_Rate.EditValue = 0;
                    this.WHT_Amount.EditValue = 0;
                    this.GST_Rate.EditValue = 0;
                    this.GST_Amount.EditValue = 0;
                    this.Quantity.EditValue = 0;
                    this.ItemRate.EditValue = 0;
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
            if (this.AccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
                return;
            }
            if (this.AccountName.Tag == null)
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountName.Focus();
                return;
            }
            if (this.AccountName.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountName.Focus();
                return;
            }
            if (this.Amount.EditValue == null)
            {
                XtraMessageBox.Show("Cash Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }
            int cAmount = 0;
            if (Int32.TryParse(this.Amount.EditValue.ToString(), out cAmount) == false)
            {
                XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }
            if (cAmount <= 0)
            {
                XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Amount.Focus();
                return;
            }


            if (Check_Item.Checked == true)
            {
                if (this.Item.Text == "")
                {
                    XtraMessageBox.Show("item seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Item.Focus();
                    return;
                }
                if (this.Quantity.EditValue == null)
                {
                    XtraMessageBox.Show("item quantity seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Quantity.Focus();
                    return;
                }
                if (this.ItemRate.EditValue == null)
                {
                    XtraMessageBox.Show("item rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ItemRate.Focus();
                    return;
                }
                if (this.Unit.EditValue == null)
                {
                    XtraMessageBox.Show("item unit seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Unit.Focus();
                    return;
                }
                double itemamount = 0;
                double.TryParse(this.Item_Amount.EditValue.ToString(), out itemamount);
                if (itemamount <= 0)
                {
                    XtraMessageBox.Show("item amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Item_Amount.Focus();
                    return;
                }
               
               


            }
            if (this.GST_Check.Checked == true)
            {

                if (this.GST_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("gst rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Rate.Focus();
                    return;
                }
                if (this.GST_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("gst amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Amount.Focus();
                    return;
                }
                double gstamount = 0;
               
                double.TryParse(this.GST_Amount.EditValue.ToString(), out gstamount);
                if (gstamount <= 0)
                {
                    XtraMessageBox.Show("gst amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.GST_Amount.Focus();
                    return;
                }


            }

            if (this.ITAX_Check.Checked == true)
            {

                if (this.ITAX_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("income tax rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Rate.Focus();
                    return;
                }
                if (this.ITAX_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("income tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }
                double itaxamount = 0;
               
                double.TryParse(this.ITAX_Amount.EditValue.ToString(), out itaxamount);
                if (itaxamount <= 0)
                {
                    XtraMessageBox.Show("income tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }


            }
            if (this.WHT_Check.Checked == true)
            {

                if (this.WHT_Rate.EditValue == null)
                {
                    XtraMessageBox.Show("with holding tax rate seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.WHT_Rate.Focus();
                    return;
                }
                if (this.WHT_Amount.EditValue == null)
                {
                    XtraMessageBox.Show("with holding tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ITAX_Amount.Focus();
                    return;
                }
                double whtamount = 0;
               
                double.TryParse(this.WHT_Amount.EditValue.ToString(), out whtamount);
                if (whtamount <= 0)
                {
                    XtraMessageBox.Show("with holding tax amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.WHT_Amount.Focus();
                    return;
                }


            }
            int GIW = 0;
            if (this.Check_Item.Checked == true || GST_Check.Checked == true || WHT_Check.Checked == true || ITAX_Check.Checked == true)
            {
                GIW = 1;
            }
            else
                GIW = 0;
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
                XtraMessageBox.Show("number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            queries[0] = "update AC_PaymentAdvice_Main set VNumber='" + vnum + "',VType='" + VPrefix.Text + "',VCat='" + vCat + "',VYear='" + FinancialYear.Text + "',eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";

            if (this.vDate.EditValue != null)
                queries[0] += ",vDate='" + this.vDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",vDate=null";
            if (this.vDate.DateTime != null)
                queries[0] += ",vTime='" + this.vDate.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",vTime=null";


            if (this.Particulars.Text != "")
                queries[0] += ",vRemarks='" + this.Particulars.Text + "'";
            else
                queries[0] += ",vRemarks=null";
            if (this.Amount.EditValue.ToString()!= "")
                queries[0] += ",vAmount=" + this.Amount.EditValue.ToString() + "";
            else
                queries[0] += ",vAmount=0";
            queries[queries.Length - 1] += ",GIW=" + GIW.ToString() + "";
            queries[0] += " where vNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_PaymentAdvice_Sub set VNumber='" + vnum + "'";
            if (this.AccountID.Text != "")
                queries[queries.Length - 1] += ",AccountID_V='" + this.AccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountID_V=null";
            if (this.Particulars.Text != "")
                queries[queries.Length - 1] += ",vParticulars='" + this.Particulars.Text + "'";
            else
                queries[queries.Length - 1] += ",vParticulars=null";
            if (this.InvoiceNumber.Text  != "")
                queries[queries.Length - 1] += ",vRefInvoiceNumber='" + InvoiceNumber.Text  + "'";
            else
                queries[queries.Length - 1] += ",VRefInvoiceNumber=null";
            if (this.PurchaseContractNumber.Text != "")
                queries[queries.Length - 1] += ",PurchaseContractNumber='" + this.PurchaseContractNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",PurchaseContractNumber=null";
            if (this.DeliveryChallanNumber.Text != "")
                queries[queries.Length - 1] += ",vRefDeliveryChallanNumber='" + this.DeliveryChallanNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",VRefDeliveryChallanNumber=null";
            if (this.DebiteNoteNumber.Text != "")
                queries[queries.Length - 1] += ",vRefDebitNoteNumber='" + this.DebiteNoteNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",VRefDebitNoteNumber=null";
            if (this.CreditNoteNumber.Text != "")
                queries[queries.Length - 1] += ",vRefCreditNoteNumber='" + this.CreditNoteNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",VRefCreditNoteNumber=null";
            if (this.Amount.EditValue.ToString() != "")
                queries[queries.Length - 1] += ",VCreditAmount=" + this.Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",VCreditAmount=0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",Item='" + this.Item.Text + "'";
            else
                queries[queries.Length - 1] += ",Item=null";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",ItemRate=" + this.ItemRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",itemrate=0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",itemamount=" + this.Item_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",itemamount=0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",itemqty=" + this.Quantity.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",itemqty=0";
            if (this.Check_Item.Checked == true)
                queries[queries.Length - 1] += ",itemunit='" + this.Unit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",itemunit=null";
            if (this.GST_Check.Checked == true)
                queries[queries.Length - 1] += ",gst_rate=" + this.GST_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",gst_rate=0";
            if (this.GST_Check.Checked == true)
                queries[queries.Length - 1] += ",gst_amount=" + this.GST_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",gst_amount=0";
            if (this.ITAX_Check.Checked == true)
                queries[queries.Length - 1] += ",itax_rate=" + this.ITAX_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",itax_rate=0";
            if (this.ITAX_Check.Checked == true)
                queries[queries.Length - 1] += ",itax_amount=" + this.ITAX_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",itax_amount=0";
            if (this.WHT_Check.Checked == true)
                queries[queries.Length - 1] += ",wht_rate=" + this.WHT_Rate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",wht_rate=0";
            if (this.WHT_Check.Checked == true)
                queries[queries.Length - 1] += ",wht_amount=" + this.WHT_Amount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",wht_amount=0";
            queries[queries.Length - 1] += " where vNumber='" + veditNum + "'";


           
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
                    
                    this.View.Tag = vnum;
                    this.Print.Tag = vnum;
                    ButtonStates(UserInputMode.View);
                    this.AccountID.Text = "";
                    this.AccountID.Tag = "";
                    this.Amount.Text = "";
                    this.Particulars.Text = "";
                    this.AccountName.Text = "";
                    this.AccountName.Tag = "";
                    this.VPrefix.Tag = "";
                    this.VSuffix.Tag = "";
                    this.VSuffix.Text = "";
                    this.DeliveryChallanNumber.Text = "";
                    this.PurchaseContractNumber.Text = "";
                    this.InvoiceNumber.Text = "";
                    this.DebiteNoteNumber.Text = "";
                    this.CreditNoteNumber.Text = "";
                    this.GST_Check.Checked = false;
                    this.WHT_Check.Checked = false;
                    this.ITAX_Check.Checked = false;
                    this.Check_Item.Checked = false;
                    this.WHT_Rate.EditValue = 0;
                    this.WHT_Amount.EditValue = 0;
                    this.GST_Rate.EditValue = 0;
                    this.GST_Amount.EditValue = 0;
                    this.Quantity.EditValue = 0;
                    this.ItemRate.EditValue = 0;
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void CalculateTaxes()
        {
            double Qty=0,Rate=0,RateGST = 0, AmountQtyRate=0,RateITAX = 0, RateWHT = 0, AmountGST = 0, AmountITAX = 0, AmountWHT = 0, AmountPayable = 0, AmountWithTax = 0;
            double.TryParse(this.ItemRate.EditValue.ToString(), out Rate);
            double.TryParse(this.Quantity.EditValue.ToString(), out Qty);
            if (this.checkRateQty.Checked == true)
            {
                AmountQtyRate = Rate * Qty;
            }
            else
                double.TryParse(this.Item_Amount.EditValue.ToString(), out AmountQtyRate);
            if (GST_Check.Checked == true)
            {
                double.TryParse(this.GST_Rate.EditValue.ToString(), out RateGST);
              
                AmountGST = Math.Round(AmountQtyRate,0) * RateGST / 100;
                AmountGST = Math.Round(AmountGST, 0);
            }
            else
            {
                AmountGST = 0;
                RateGST = 0;
            }

            AmountWithTax = Math.Round(AmountQtyRate, 0) + Math.Round(AmountGST,0);
            AmountWithTax = Math.Round(AmountWithTax, 0);
            if (this.ITAX_Check.Checked == true)
            {
                double.TryParse(this.ITAX_Rate.EditValue.ToString(), out RateITAX);
                AmountITAX = AmountWithTax * RateITAX / 100;
                AmountITAX = Math.Round(AmountITAX);
            }
            else
            {
                AmountITAX = 0;
                RateITAX = 0;
            }

            if (this.WHT_Check.Checked == true)
            {
                double.TryParse(this.WHT_Rate.EditValue.ToString(), out RateWHT);
                AmountWHT = AmountGST * RateWHT / 100;
                AmountWHT = Math.Round(AmountWHT, 0);
            }
            else
            {
                AmountWHT = 0;
                RateWHT = 0;
            }
            AmountPayable = AmountWithTax - AmountWHT - AmountITAX;
            this.Item_Amount.EditValue = AmountQtyRate.ToString();
            this.Amount_AfterGST.EditValue = AmountWithTax.ToString();
            this.GST_Amount.EditValue = AmountGST.ToString();
            this.ITAX_Amount.EditValue = AmountITAX.ToString();
            this.WHT_Amount.EditValue = AmountWHT.ToString();
            this.Amount.EditValue = AmountPayable.ToString();
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

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();

            if (this.Filter_Account.Checked == true)
            {
                if (this.AccountID.Tag == null)
                {
                    XtraMessageBox.Show("Either uncheck the Account filter or select a Account", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


           
              
                if (Filter_Account.Checked == true || Filter_Amount.Checked == true)
                {

                    if (Filter_Account.Checked == true)
                    {
                        if (AccountName.Tag == null)
                        {
                            XtraMessageBox.Show("Either uncheck the Account ID filter or enter valid Account ID", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            AccountID.Focus();
                            return;
                        }
                        if (AccountName.Tag.ToString() == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Account ID filter or enter valid Account ID", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            AccountID.Focus();
                            return;
                        }

                    }
                    if (Filter_Amount.Checked == true)
                    {
                        if (Amount.EditValue == null)
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Amount.Focus();
                            return;
                        }
                        if (Amount.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Debit Amount Filter or enter valid amount", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Amount.Focus();
                            return;
                        }
                    }
                    
                  
                  
                  
                  
                }
            


            strFilterQuery = "SELECT VNumber,vDate,vRemarks,vAmount,VType,VCat,VYear,VStatus FROM AC_PaymentAdvice_Main ";
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
          
               

                if (Filter_Account.Checked == true || Filter_Amount.Checked == true)
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and vNumber in(select vNumber from AC_PaymentAdvice_Sub where ";
                    }
                    if (Filter_Account.Checked == true)
                    {
                        SubFilter += " AccountID_V='" + AccountID.Text + "'";
                        Appendand = true;
                    }
                    if (Filter_Amount.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " vCreditAmount=" + Amount.EditValue.ToString() + "";
                        Appendand = true;
                    }
                    
                  
                  
                }
            
            if (SubFilter != "")
                SubFilter += ")";
            strFilterQuery += SubFilter;
            strFilterQuery += " ORDER BY Convert(numeric(18),vNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "VNumber", "VAmount");
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

        private void Fill_Voucher(string VNumber)
        {
            this.Amount.EditValue = null;
            this.DebiteNoteNumber.Text = "";
            this.CreditNoteNumber.Text = "";
            this.InvoiceNumber.Text = "";
            this.DeliveryChallanNumber.Text = "";
            this.PurchaseContractNumber.Text = "";
            this.Particulars.Text = "";
            this.AccountID.Text = "";
            this.AccountName.Text = "";
            this.AccountName.Tag = "";
            this.AccountID.Tag = null;
            this.GST_Check.Checked = false;
            this.WHT_Check.Checked = false;
            this.ITAX_Check.Checked = false;
            this.Check_Item.Checked = false;
            this.WHT_Rate.EditValue = 0;
            this.WHT_Amount.EditValue = 0;
            this.GST_Rate.EditValue = 0;
            this.GST_Amount.EditValue = 0;
            this.Quantity.EditValue = 0;
            this.ItemRate.EditValue = 0;
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from AC_PaymentAdvice_Main where vNumber='" + VNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;
            this.vDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            this.Amount.EditValue = ds_VoucherMain.Tables[0].Rows[0]["VAmount"].ToString();
            int cAmount = 0;
            int.TryParse(ds_VoucherMain.Tables[0].Rows[0]["VAmount"].ToString(), out cAmount);
           
            if (ds_VoucherMain.Tables[0].Rows[0]["VCat"].ToString() == "G")
            {
                this.NG.Checked = false;

            }
            else
            {

                this.NG.Checked = true;
            }

            if (ds_VoucherMain.Tables[0].Rows[0]["GIW"].ToString() == "1")
            {
               
            }

            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["VStatus"].ToString();
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));


            this.VSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(7, 6);
            this.VPrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.VPrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(0, 3);
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            this.FinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["VNumber"].ToString().Substring(3, 4);
            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from AC_PaymentAdvice_Sub where vNumber='" + VNumber + "' and isHead=1");
            if (ds_VoucherSub_T == null) return;
            if (ds_VoucherSub_T.Tables[0].Rows.Count <= 0) return;

            this.AccountID.Text = ds_VoucherSub_T.Tables[0].Rows[0]["AccountID_V"].ToString();
            
            this.Particulars.Text = ds_VoucherSub_T.Tables[0].Rows[0]["VParticulars"].ToString();
            
               
                Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["VCreditAmount"].ToString();
               
                InvoiceNumber.Text = ds_VoucherSub_T.Tables[0].Rows[0]["VrefInvoiceNumber"].ToString();
                DeliveryChallanNumber.Text = ds_VoucherSub_T.Tables[0].Rows[0]["VrefDeliveryChallanNumber"].ToString();
                this.PurchaseContractNumber.Text = ds_VoucherSub_T.Tables[0].Rows[0]["PurchaseContractNumber"].ToString();
                this.DebiteNoteNumber.Text = ds_VoucherSub_T.Tables[0].Rows[0]["vRefDebitNoteNumber"].ToString();
                this.CreditNoteNumber.Text = ds_VoucherSub_T.Tables[0].Rows[0]["vRefCreditNoteNumber"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[0]["item"].ToString() != "")
                {
                    this.Item.Text = ds_VoucherSub_T.Tables[0].Rows[0]["item"].ToString();
                    this.ItemRate.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itemrate"].ToString();
                    this.Quantity.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itemqty"].ToString();
                    double ItemRates = 0;
                    double.TryParse(ds_VoucherSub_T.Tables[0].Rows[0]["itemrate"].ToString(), out ItemRates);
                    if (ItemRates<=0)
                        this.checkRateQty.Checked = false;
                    else
                        this.checkRateQty.Checked = true;
                    this.Check_Item.Checked = true;
                    this.Unit.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itemunit"].ToString();
                    this.Item_Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itemamount"].ToString();

                }
                if (ds_VoucherSub_T.Tables[0].Rows[0]["gst_amount"].ToString() != "0")
                {
                    this.GST_Check.Checked = true;
                    this.GST_Rate.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["gst_rate"].ToString();
                    
                    this.GST_Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["gst_amount"].ToString();

                }
                if (ds_VoucherSub_T.Tables[0].Rows[0]["wht_amount"].ToString() != "0")
                {
                    this.WHT_Check.Checked = true;
                    this.WHT_Rate.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["wht_rate"].ToString();

                    this.WHT_Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["wht_amount"].ToString();

                }
                if (ds_VoucherSub_T.Tables[0].Rows[0]["itax_amount"].ToString() != "0")
                {
                    this.ITAX_Check.Checked = true;
                    this.ITAX_Rate.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itax_rate"].ToString();

                    this.ITAX_Amount.EditValue = ds_VoucherSub_T.Tables[0].Rows[0]["itax_amount"].ToString();

                }
            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountID.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                    this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                }
            }
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            if (this.AccountID.Text.Length == 13)
            {
                string hName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AccountID.Text);
                this.AccountName.Text = hName;
                this.AccountName.Tag = hName;
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag != null)
            {
                if (this.Print.Tag.ToString() != "")
                {
                    Accounting.Print_PaymentAdvice(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            ButtonStates(UserInputMode.View);
        }

        private void CalculationChanged_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTaxes();
        }

        private void GST_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (GST_Check.Checked == true)
            {
                if (this.GST_Rate.EditValue == null)
                {
                    this.GST_Rate.EditValue = Accounting.RegAccounts.GSTRATE;
                    return;
                }
                if (this.GST_Rate.EditValue.ToString() == "0")
                {
                    this.GST_Rate.EditValue = Accounting.RegAccounts.GSTRATE;
                    return;
                }
            }
            else
            {
                GST_Rate.EditValue = 0;
                GST_Amount.EditValue = 0;
            }
        }

        private void ITAX_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ITAX_Check.Checked == true)
            {
                if (this.ITAX_Rate.EditValue == null)
                {
                    this.ITAX_Rate.EditValue = Accounting.RegAccounts.ITAXRATE;
                    return;
                }
                if (this.ITAX_Rate.EditValue.ToString() == "0")
                {
                    this.ITAX_Rate.EditValue = Accounting.RegAccounts.ITAXRATE;
                    return;
                }
            }
            else
            {
                ITAX_Amount.EditValue = 0;
                ITAX_Rate.EditValue = 0;
            }
        }

        private void WHT_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (this.WHT_Check.Checked == true)
            {
                if (this.WHT_Rate.EditValue == null)
                {
                    this.WHT_Rate.EditValue = Accounting.RegAccounts.WHTRATE;
                    return;
                }
                if (this.WHT_Rate.EditValue.ToString() == "0")
                {
                    this.WHT_Rate.EditValue = Accounting.RegAccounts.WHTRATE;
                    return;
                }
            }
            else
            {
                WHT_Rate.EditValue = 0;
                WHT_Amount.EditValue = 0;
            }
        }

        private void Check_Item_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxes();
        }

        private void checkRateQty_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxes();
        }

        private void Item_Amount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateTaxes();
        }

        private void Amount_AfterGST_EditValueChanged(object sender, EventArgs e)
        {

        }
       
    }
}