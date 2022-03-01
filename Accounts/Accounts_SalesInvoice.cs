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
    public partial class Accounts_SalesInvoice : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private easyVoucherCalculations vCalc = new easyVoucherCalculations();
        Accounts.Accounts_AppendGeneral AppendedJournal = new Accounts_AppendGeneral();
        private string G_Number;
        private string N_Number;
        private string G_Invoice;
        private string N_Invoice;
        public Accounts_SalesInvoice()
        {
            InitializeComponent();
           
        }
        
        private bool GetNextVoucherNumber()
        {
            string vNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(VNumber,8,6)))+1 as MaxNumber  from AC_Voucher_Main where VYear='" + this.vFinancialYear.Text + "' and VType='" + this.vPrefix.Text + "' and VCat='" + this.NG.Tag + "'";
                    vNumber= WS.svc.Get_MaxNumber(query);
                    if (vNumber.Length > 6)
                    {
                        XtraMessageBox.Show(vNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.vSuffix.Text = "";
                        return false;
                    }
                    vNumber = vNumber.PadLeft(6, '0');
                    this.vSuffix.Text = vNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');
               


            }
            catch
            {
                return false;
            }
        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(iNumber,8,6)))+1 as MaxNumber  from AC_Sales_Main where iYear='" + this.SalesInvoiceFinancialYear.Text + "' and iType='" + this.SalesInvoicePrefix.Text + "' and iCat='" + this.NG.Tag + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.SalesInvoiceSuffix.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.SalesInvoiceSuffix.Text= iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.SalesInvoiceSuffix.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.SalesInvoiceSuffix.Text = "";
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
                    Clone.Enabled = true;
                    View.Enabled = true;


                    if (vSuffix.Tag != null)
                    {
                        if (vSuffix.Tag.ToString() != "")
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
                    vSuffix.Tag = "";

                    Add.Enabled = false;
                    Clone.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                  
                    View.Enabled = false;
                    Delete.Enabled = false;
                    DocumentStatus.Image = MachineEyes.Properties.Resources.unposted;
                    DocumentStatus.Checked = false;

                    break;
                case UserInputMode.Edit:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                    Clone.Enabled = false;
                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Add.Enabled = false;
                    Cancel.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;
                    Clone.Enabled = false;
                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                default:
                    break;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (this.SalesInvoiceFinancialYear.Text.Length!=4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.vFinancialYear.Text.Length!=4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.vPrefix.Text == "" || this.vPrefix.Text.Length!=3)
            {
                XtraMessageBox.Show("invalid voucher series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.SalesInvoicePrefix.Text == "" || this.SalesInvoicePrefix.Text.Length!=3)
            {
                XtraMessageBox.Show("invalid invoice series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            this.tableLayoutPanel_Payment.Controls.Clear();
            this.BuyersAccountID.Text = "";
            this.Remarks.Text = "";
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
            this.vSuffix.Text = "";
            this.SalesInvoiceSuffix.Text = "";
            this.SalesDiscountPercent.Text = "0";
            this.SalesDiscountAmount.Text = "0";
            
            UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
            nAS.salesTypeID = this.typeOfSales.Tag.ToString();
            nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
            this.GSTRate.Text = nAS.GSTRate.Text;
            nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
            vCalc.controls_AmountExTax = Amount_ExTax;
            vCalc.controls_AmountInTax = Amount_IncTax;
            vCalc.controls_AmountSalesTax = Amount_Tax;
           
            nAS.eVC = vCalc;
            this.tableLayoutPanel_Payment.Controls.Add(nAS);
          
            bool rRes = GetNextVoucherNumber();
            if (rRes != false)
            {
                rRes = GetNextInvoiceNumber();
                if(rRes!=false)
                SetButtonStates(UserInputMode.Add);
            }
            AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
            AppendedJournal.AddControl();

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (this.vPrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vPrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vSuffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vFinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vFinancialYear.Tag.ToString() == "" || this.vFinancialYear.Tag.ToString().Length!=4)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentStatus.Tag.ToString() == "P")
            {
                XtraMessageBox.Show("Voucher has been posted ....can not edit / delete posted voucher", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentAuthorized.Checked == true)
            {
                XtraMessageBox.Show("Voucher has been signed by authorized person ....can not edit / delete Authorized voucher", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentClosed.Checked == true)
            {
                XtraMessageBox.Show("Voucher has been closed  ....can not edit / delete Closed voucher", "Error", MessageBoxButtons.OK);
                return;
            }
            SetButtonStates(UserInputMode.Edit);
        }

     
        private void SetAutoRemarks()
        {

            string inum = this.SalesInvoicePrefix.Text + this.SalesInvoiceFinancialYear.Text + this.SalesInvoiceSuffix.Text;
           
            if(AutoRemarks.Checked==true)
            this.Remarks.Text  = "Invoice # " + inum;
            string PackingList = ""; string GatePass = "";
            foreach (Control C in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales AField = (UserControls.Account_SalesInvoice_FabricSales)C;

                string Unit = "";
                if (AField.SellingUnit.EditValue != null)
                    Unit = AField.SellingUnit.EditValue.ToString();
                else
                    Unit = "Meters";


                //if (AutoRemarks.Checked == true)
                //    this.Remarks.Text += " Article  " + AField.Item.Text + " Qty " + AField.Quantity.Text + " " + Unit + " @Rs.  " + AField.Rate.Text;

                if (AField.DeliveryChallanNumber.Text != "")
                {

                    if (AutoRemarks.Checked == true) this.Remarks.Text += " D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {

                    if (PackingList != AField.PackingListNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " Packing List # " + AField.PackingListNumber.Text;
                            PackingList = AField.PackingListNumber.Text;
                        }
                    }
                }

                if (AField.GatePassNumber.Text != "")
                {

                    if (GatePass != AField.GatePassNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " G.P # " + AField.GatePassNumber.Text;
                            GatePass = AField.GatePassNumber.Text;
                        }
                    }
                }



            }

        }
        private void Save_NewInvoiceandVoucher()
        {
           
            if (this.vPrefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vSuffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.vSuffix.Text, out suffix) == false)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vPrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }
            if (this.vFinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vFinancialYear.Text != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.SalesInvoiceFinancialYear.Text != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.SalesInvoiceFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfSales.Tag ==null)
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfSales.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }
            if (this.SalesDate.DateTime < Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }
            if (this.SalesDate.DateTime > Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }
            if (this.BuyersAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (this.MappedAccountID.Text =="")
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (this.BuyersAccountName.Text == "")
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (doExtraTax.Checked == true)
            {
                if (ExtraTaxAccountID.Text == "" || ExtraTaxAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid extra Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.ExtraTaxAccountName.Text == "" )
                {
                    XtraMessageBox.Show("invalid extra Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.ExtraTaxRate.EditValue == null)
                {
                      XtraMessageBox.Show("invalid extra Tax rate", "Error", MessageBoxButtons.OK);
                        return;
                    
                }
            }
            if (this.doWHT.Checked == true)
            {
                if (this.WHTAccountID.Text == "" || this.WHTAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid WHT Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.WHTAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid WHT Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.WHTRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid WHT Tax rate", "Error", MessageBoxButtons.OK);
                    return;

                }
            }
            if (this.doFreight.Checked == true)
            {
                if (this.FreightAccountID.EditValue == null || this.FreightAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid freight Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FreightAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid frieght Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FreightAmount.EditValue == null)
                {
                    XtraMessageBox.Show("invalid extra Tax rate", "Error", MessageBoxButtons.OK);
                    return;

                }
               
            }
            if (NG.Tag.ToString() == "G")
            {
                if (this.GSTAccountID.Text == "" || this.GSTAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid Sales Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }

                if (this.GSTAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid Sales Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SalesDiscountAmount.Text != "0")
                {
                    if (this.SalesDiscountID.Text == "")
                    {
                        XtraMessageBox.Show("invalid sales discount ID", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    if (this.SalesDiscountName.Text == "")
                    {
                        XtraMessageBox.Show("invalid sales discount ID", "error", MessageBoxButtons.OK);
                        return;
                    }

                }
            }
           
            
        
            foreach (Control c in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales Ac = (UserControls.Account_SalesInvoice_FabricSales)c;
                if (Ac.SellingUnit.EditValue == null)
                {
                    XtraMessageBox.Show("invalid selling unit", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.SellingUnit.Focus();
                    return;
                }

                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag == null)
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.Quantity.EditValue == null)
                {
                    XtraMessageBox.Show("invalid quantity", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.Rate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid rate", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.GSTRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid GST Rate", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (Ac.ContractNumber.EditValue == null && Settings.BoundInvoiceWithPO==true)
                {
                    XtraMessageBox.Show("invalid Contract / PO / W.O #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.ContractNumber.EditValue != null)
                {
                    if (Ac.ContractNumber.EditValue.ToString() == "" && Settings.BoundInvoiceWithPO == true)
                    {
                        XtraMessageBox.Show("invalid Contract / PO / W.O #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            if (radio_AppendedJournal.EditValue != null)
            {
                if (radio_AppendedJournal.EditValue.ToString() == "1")
                {
                    if (AppendedJournal == null)
                    {
                        XtraMessageBox.Show("invalid appended journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (AppendedJournal.tableLayoutPanel_Detail.Controls.Count < 2)
                    {
                        XtraMessageBox.Show("atleast one debit and one credit entry is required in appended journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int cCreditSide = 0;
                    int cDebitSide = 0;
                    foreach (Control c in AppendedJournal.tableLayoutPanel_Detail.Controls)
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
                        if (Ac.Credit.EditValue == null)
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Ac.Credit.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Int32.TryParse(Ac.Credit.EditValue.ToString(), out cCreditSide) == false)
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Ac.Debit.EditValue == null)
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (Ac.Debit.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (Int32.TryParse(Ac.Debit.EditValue.ToString(), out cDebitSide) == false)
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (cDebitSide <= 0 && cCreditSide <= 0)
                        {
                            XtraMessageBox.Show("amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }


                    }
                    if (AppendedJournal.vCalc.singleTotal <= 0)
                    {
                        XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        return;
                    }

                    if (AppendedJournal.vCalc.difference != 0)
                    {
                        XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                }
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.vPrefix.Text + this.vFinancialYear.Text + this.vSuffix.Text;
            string inum = this.SalesInvoicePrefix.Text + this.SalesInvoiceFinancialYear.Text + this.SalesInvoiceSuffix.Text;
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

          

           
            double dExtraTaxAmount = 0;
            double dSalesTaxAmount = 0;
            double dAmountIncTaxBeforeOtherTaxes = 0;
            double dAmountIncTaxAfterAllTaxes = 0;
            double dExtraTaxRate = 0;
            double dAmountExTax = 0;
            double dFreightAmount = 0;
            double dWHTAmount = 0;
            double dWHTRate = 0;

            if (this.doWHT.Checked ==true && WHTRate.EditValue == null)
            {
                XtraMessageBox.Show("Invalid WHT Rate!", "Error");
                return;
            }
          
            try
            {
                double.TryParse(this.Amount_Tax.Tag.ToString(), out dSalesTaxAmount);
            }
            catch
            {
                XtraMessageBox.Show("invalid sales tax amount!", "Error");
                return;
            }
            try
            {
                double.TryParse(this.Amount_IncTax.Tag.ToString(), out dAmountIncTaxBeforeOtherTaxes);
            }
            catch
            {
                XtraMessageBox.Show("invalid Amount including tax in label tag!", "Error");
                return;
            }
            dAmountIncTaxAfterAllTaxes = dAmountIncTaxBeforeOtherTaxes;
            if (this.doExtraTax.Checked == true)
            {
                double.TryParse(this.ExtraTaxRate.EditValue.ToString(), out dExtraTaxRate);
                if (this.Amount_ExTax.Tag.ToString() != "")
                    double.TryParse(this.Amount_ExTax.Tag.ToString(), out dAmountExTax);

                dExtraTaxAmount = dAmountExTax * dExtraTaxRate / 100;
                dExtraTaxAmount = Math.Round(dExtraTaxAmount, 0);
                dAmountIncTaxAfterAllTaxes+= dExtraTaxAmount;
            }

            if (this.doFreight.Checked == true)
            {

                double.TryParse(this.FreightAmount.EditValue.ToString(), out dFreightAmount);
                dFreightAmount = Math.Round(dFreightAmount, 0);
                dAmountIncTaxAfterAllTaxes += dFreightAmount;
            }

            if (this.doWHT.Checked == true)
            {
                double.TryParse(this.WHTRate.EditValue.ToString(), out dWHTRate);
                dWHTAmount = dSalesTaxAmount * dWHTRate / 100;
                dWHTAmount = Math.Round(dWHTAmount, 0);
            }

            queries[0] = "insert into AC_Voucher_Main (VNumber,VType,VCat,VYear,VDate,VTime,VStatus,VRemarks,VAmount,vAuthorized,vClosed,AttachedInvoiceNumber) Values (";
            queries[0] += "'" + vnum + "','" + vPrefix.Text + "','" + vCat + "','" + vFinancialYear.Text + "'";
            if (this.SalesDate.EditValue != null)
                queries[0] += ",'" + this.SalesDate.DateTime.ToString(Accounting.culture) + "'";
            else
                queries[0] += ",null";
            if (this.SalesDate.DateTime != null)
                queries[0] += ",'" + this.SalesDate.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",null";

            queries[0] += ",'U'";
            if (this.Remarks.Text != "")
                queries[0] += ",'" + this.Remarks.Text + "'";
            else
                queries[0] += ",null";
            if (dAmountIncTaxAfterAllTaxes>0)
                queries[0] += "," + dAmountIncTaxAfterAllTaxes + "";
            else
                queries[0] += ",0";
            queries[0] += ",0,0";
            if (inum != "")
                queries[0] += ",'" +inum + "'";
            else
                queries[0] += ",null";
            queries[0] += ")";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length -1] = "insert into AC_Sales_Main (iNumber,iSalesTypeID,iPaymentTerms,iType,iCat,iYear,iDate,DueDate,iStatus,iRemarks,iGSTRate,iDiscountPercent,iDiscountAmount,iAuthorized,iClosed,AttachedVoucherNumber,BuyerID,BuyerMappedID,ValExTax,ValTax,ValInTax,doExtraTax,ExtraTaxAccountID,ExtraTaxRate,ExtraTaxAmount,doFreight,FreightAccountID,FreightAmount,FreightParticulars,doWHT,WHTAccountID,WHTRate,WHTAmount) Values (";
            queries[queries.Length - 1] += "'" + inum + "','"+this.typeOfSales.Tag.ToString()+"','" + this.Paymentterms.EditValue.ToString() + "','" + this.SalesInvoicePrefix.Text + "','" + vCat + "','" + this.SalesInvoiceFinancialYear.Text + "'";
            if (this.SalesDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.SalesDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.DueDate.DateTime != null)
                queries[queries.Length - 1] += ",'" + this.DueDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'U'";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += "," + this.GSTRate.Text + "";
           
            if (this.SalesDiscountPercent.Text != "0")
                queries[queries.Length - 1] += "," + this.SalesDiscountPercent.Text + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.SalesDiscountAmount.Text != "0")
                queries[queries.Length - 1] += "," + this.SalesDiscountAmount.Text + "";
            else
                queries[queries.Length - 1] += ",0";

            queries[queries.Length - 1] += ",0,0";
            if (vnum != "")
                queries[queries.Length - 1] += ",'" + vnum + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.BuyersAccountID.Text != "")
                queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.MappedAccountID.Text != "")
                queries[queries.Length - 1] += ",'" + this.MappedAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Amount_ExTax.Tag.ToString() !="")
                queries[queries.Length - 1] += "," + this.Amount_ExTax.Tag.ToString()+ "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Amount_Tax.Tag.ToString() != "")
                queries[queries.Length - 1] += "," + this.Amount_Tax.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Amount_IncTax.Tag.ToString() != "")
                queries[queries.Length - 1] += "," + this.Amount_IncTax.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
           
               
            if (this.doExtraTax.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ExtraTaxAccountID.EditValue!=null && doExtraTax.Checked==true)
                queries[queries.Length - 1] += ",'" + ExtraTaxAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ExtraTaxRate.EditValue!=null && doExtraTax.Checked==true)
                queries[queries.Length - 1] += "," + ExtraTaxRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ExtraTaxRate.EditValue!=null && doExtraTax.Checked==true)
                queries[queries.Length - 1] += "," + dExtraTaxAmount + "";
            else
                queries[queries.Length - 1] += ",0";



            if (this.doFreight.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.FreightAccountID.EditValue != null && this.doFreight.Checked == true)
                queries[queries.Length - 1] += ",'" + this.FreightAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.FreightAmount.EditValue != null && this.doFreight.Checked == true)
                queries[queries.Length - 1] += "," +dFreightAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.FreightParticulars.EditValue != null && this.doFreight.Checked == true)
                queries[queries.Length - 1] += ",'" + this.FreightParticulars.Text + "'";
            else
                queries[queries.Length - 1] += ",null";


            if (this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.WHTAccountID.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",'" + this.WHTAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.WHTRate.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += "," + this.WHTRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.WHTRate.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += "," + dWHTAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ")";

            if (radio_AppendedJournal.EditValue != null)
            {
                if (radio_AppendedJournal.EditValue.ToString() == "1")
                {
                    foreach (Control C in AppendedJournal.tableLayoutPanel_Detail.Controls)
                    {
                        UserControls.AccountGeneral AField = (UserControls.AccountGeneral)C;
                        Array.Resize(ref queries, queries.Length + 1);
                        queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                        queries[queries.Length - 1] += "'" + vnum + "'";
                        if (AField.AccountID.Text != "")
                            queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                        if (AField.Particulars.Text != "")
                            queries[queries.Length - 1] += ",'" + AField.Particulars.Text + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                        if (inum != "")
                            queries[queries.Length - 1] += ",'" + inum + "'";
                        else
                            queries[queries.Length - 1] += ",null";

                        if (AField.Debit.EditValue.ToString() != "")
                            queries[queries.Length - 1] += ",'" + AField.Debit.EditValue.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",0";

                        if (AField.Credit.EditValue.ToString() != "")
                            queries[queries.Length - 1] += "," + AField.Credit.EditValue.ToString() + "";
                        else
                            queries[queries.Length - 1] += ",0";

                        queries[queries.Length - 1] += ",2)";
                    }
                }
            }
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,vRefGatePassNumber,vRefPackingListNumber,vRefContractNumber,VDebitAmount,VCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (this.BuyersAccountID.Text != "" && this.BuyersAccountID.Text.Length==13)
                queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'"+inum+"'";

            queries[queries.Length - 1] += ",null,null,null,null";
            if (dAmountIncTaxAfterAllTaxes>0)
                queries[queries.Length - 1] += "," + dAmountIncTaxAfterAllTaxes.ToString()+ "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",0,1)";
            if(AutoRemarks.Checked==true)
            this.Remarks.Text  = "Invoice # " + inum;
            string PackingList = ""; string GatePass = "";
            foreach (Control C in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales AField = (UserControls.Account_SalesInvoice_FabricSales)C;
                Array.Resize(ref queries, queries.Length + 1);
               
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,vRefDeliveryChallanNumber,vRefPackingListNumber,vRefGatePassNumber,vRefContractNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AutoRemarks.Checked == true) 
                this.Remarks.Text += " Article  " + AField.Item.Text + " Qty " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text;
                string particulars = " Invoice # " + inum +" Article  " + AField.Item.Text + " Quantity " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text + " per " + AField.SellingUnit.EditValue.ToString();
                if (AField.DeliveryChallanNumber.Text != "")
                {
                    particulars += " D.C # " + AField.DeliveryChallanNumber.Text;
                    if (AutoRemarks.Checked == true) this.Remarks.Text += " D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {
                    particulars += " Packing List # " + AField.PackingListNumber.Text;
                    if (PackingList != AField.PackingListNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " Packing List # " + AField.PackingListNumber.Text;
                            PackingList = AField.PackingListNumber.Text;
                        }
                    }
                }

                if (AField.GatePassNumber.Text != "")
                {
                    particulars += " Gate Pass # " + AField.GatePassNumber.Text;
                    if (GatePass != AField.GatePassNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " G.P # " + AField.GatePassNumber.Text;
                            GatePass = AField.GatePassNumber.Text;
                        }
                    }
                }

                if (particulars != "")
                    queries[queries.Length - 1] += ",'" + particulars + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.PackingListNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.PackingListNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.GatePassNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.GatePassNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text!="")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",0";
                if (AField.AmountExcludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";





                if (AField.SellingUnit.EditValue != null && AField.ItemID.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);

                    queries[queries.Length - 1] = "update PP_Article set SellingUnit='" + AField.SellingUnit.EditValue.ToString() + "' , SellingRate=" + AField.Rate.Text + " where ArticleNumber='" + AField.ItemID.Text + "'";
                }

                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Sales_Sub (iNumber,AccountID,Rate,Qty,GSTRate,PackingListNumber,GatePassNumber,DeliveryChallanNumber,ContractNumber,ArticleNumber,ArticleName,Unit,ValExTax,ValTax,ValInTax) values(";
                queries[queries.Length - 1] += "'" + inum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Rate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Rate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Quantity.EditValue !=null)
                    queries[queries.Length - 1] += "," + AField.Quantity.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.GSTRate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.GSTRate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.PackingListNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.PackingListNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.GatePassNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.GatePassNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ItemID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ItemID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Item.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Item.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.SellingUnit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.SellingUnit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountExcludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountIncludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountIncludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";


















            }
            if (NG.Checked == false && dSalesTaxAmount>0)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GSTAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.GSTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularstax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  amount excluding sales tax is " + this.Amount_ExTax.Text;


                if (particularstax != "")
                    queries[queries.Length - 1] += ",'" + particularstax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";

                queries[queries.Length - 1] += ",0";



                if (this.Amount_Tax.Text != "")
                    queries[queries.Length - 1] += "," + this.Amount_Tax.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";








            }


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (this.doExtraTax.Checked ==true )
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.ExtraTaxAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.ExtraTaxAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsExtraTax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " extra / additional tax  deducted  @ " + this.ExtraTaxRate.Text + "%  is " + dExtraTaxAmount.ToString("#,##") + " ";


                if (particularsExtraTax != "")
                    queries[queries.Length - 1] += ",'" + particularsExtraTax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";



                queries[queries.Length - 1] += ",0";//debit
                queries[queries.Length - 1] += "," + dExtraTaxAmount.ToString() + "";//credit
                queries[queries.Length - 1] += ",0)";





            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (this.doFreight.Checked == true)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.FreightAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.FreightAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsExtraTax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " freight deducted " + this.FreightParticulars.Text;


                if (particularsExtraTax != "")
                    queries[queries.Length - 1] += ",'" + particularsExtraTax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";



                queries[queries.Length - 1] += ",0";//debit
                queries[queries.Length - 1] += "," + dFreightAmount.ToString() + "";//credit
                queries[queries.Length - 1] += ",0)";





            }

            if (this.doWHT.Checked ==true)
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.WHTAccountID.Text!="")
                    queries[queries.Length - 1] += ",'" + this.WHTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsWHT = " Invoice # " + inum + " invoiced to M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + this.WHTRate.Text + "%";


                if (particularsWHT != "")
                    queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum!="")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";



               
                if (dWHTAmount != 0)
                    queries[queries.Length - 1] += "," + dWHTAmount.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";



                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.BuyersAccountID.Text!="")
                    queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
               


                if (particularsWHT != "")
                    queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";


                queries[queries.Length - 1] += ",0";

                if (dWHTAmount != 0)
                    queries[queries.Length - 1] += "," + dWHTAmount.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
               
                queries[queries.Length - 1] += ",0)";



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
                    this.tableLayoutPanel_Payment.Controls.Clear();
                    this.BuyersAccountID.Text = "";
                    this.Remarks.Text = "";
                    this.doExtraTax.Checked = false;
                    this.ExtraTaxRate.EditValue = Accounting.RegAccounts.EXTRATAXRATE;
                    this.ExtraTaxAccountID.EditValue = Accounting.RegAccounts.EXTRATAXACCOUNT;

                    this.doWHT.Checked = false;
                    this.WHTRate.Text = Accounting.RegAccounts.WHTRATE;
                    this.WHTAccountID.Text = Accounting.RegAccounts.WHTACCOUNT;


                    this.doFreight.Checked = false;
                    this.FreightParticulars.EditValue = null;
                    this.FreightAmount.EditValue = null;
                    this.FreightAccountID.EditValue = null;
                    this.FreightAccountName.Text = "";

                    this.vSuffix.Tag = this.vSuffix.Text;
                    this.vFinancialYear.Tag = this.vFinancialYear.Text;
                    this.vPrefix.Tag = this.vPrefix.Text;
                    this.SalesInvoiceFinancialYear.Tag = this.SalesInvoiceFinancialYear.Text;
                    this.SalesInvoicePrefix.Tag = this.SalesInvoicePrefix.Text;
                    this.SalesInvoiceSuffix.Tag = this.SalesInvoiceSuffix.Text;
                    this.vSuffix.Text = "";
                    this.SalesInvoiceSuffix.Text = "";
                    this.SalesDiscountPercent.Text = "0";
                    this.SalesDiscountAmount.Text = "0";
                    this.View.Tag = inum;
                    this.Print.Tag = inum;
                    this.PrintVoucher.Tag = vnum;
                    this.doExtraTax.Checked = false;
                    this.ExtraTaxRate.EditValue = Accounting.RegAccounts.EXTRATAXRATE;
                    this.ExtraTaxAccountID.EditValue = Accounting.RegAccounts.EXTRATAXACCOUNT;
                    UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();

                    vCalc.controls_AmountExTax = Amount_ExTax;
                    vCalc.controls_AmountInTax = Amount_IncTax;
                    vCalc.controls_AmountSalesTax = Amount_Tax;
                    nAS.salesTypeID = this.typeOfSales.Tag.ToString();
                    nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
                    nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
                    nAS.eVC = vCalc;
                    this.GSTRate.Text = nAS.GSTRate.Text;
                    this.tableLayoutPanel_Payment.Controls.Add(nAS);
                    if (radio_AppendedJournal.EditValue.ToString() == "1")
                    {
                        if (AppendedJournal != null)
                        {
                            AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
                            AppendedJournal.AddControl();
                        }
                    }
                    SetButtonStates(UserInputMode.View);
                  
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Update_InvoiceandVoucher()
        {
            string Number_InvoicetoEdit="";
            string Number_VouchertoEdit="";
            if (this.vPrefix.Tag == null)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vSuffix.Tag == null)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vFinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vPrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vSuffix.Tag.ToString()=="")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vFinancialYear.Tag.ToString()=="")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vPrefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vSuffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            int suffix = 0;
            if (Int32.TryParse(this.vSuffix.Text, out suffix) == false)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vPrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.vFinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.vFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SalesInvoiceFinancialYear.Tag ==null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Tag ==null)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Tag ==null)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.SalesInvoiceFinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfSales.Tag  ==null)
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.typeOfSales.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales invoice type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }





            Number_InvoicetoEdit = this.SalesInvoicePrefix.Tag.ToString() + this.SalesInvoiceFinancialYear.Tag.ToString() + this.SalesInvoiceSuffix.Tag.ToString();
            Number_VouchertoEdit = this.vPrefix.Tag.ToString() + this.vFinancialYear.Tag.ToString() + this.vSuffix.Tag.ToString();
            if (Number_VouchertoEdit.Length != 13)
            {
                XtraMessageBox.Show("invalid voucher for editing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Number_InvoicetoEdit.Length != 13)
            {
                XtraMessageBox.Show("invalid invoice for editing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.SalesDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }
            if (this.SalesDate.DateTime < Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }

            if (this.SalesDate.DateTime > Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SalesDate.Focus();
                return;
            }
            if (this.BuyersAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (this.MappedAccountID.Text == "")
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (this.BuyersAccountName.Text == "")
            {
                XtraMessageBox.Show("invalid buyer's Account", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.BuyersAccountID.Focus();
                return;
            }
            if (NG.Tag.ToString() == "G")
            {
                if (this.GSTAccountID.Text == "" || this.GSTAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid Sales Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }

                if (this.GSTAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid Sales Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }

                if (this.SalesDiscountAmount.Text != "0")
                {
                    if (this.SalesDiscountID.Text == "")
                    {
                        XtraMessageBox.Show("invalid sales discount ID", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    if (this.SalesDiscountName.Text == "")
                    {
                        XtraMessageBox.Show("invalid sales discount ID", "error", MessageBoxButtons.OK);
                        return;
                    }

                }
            }

            if (doExtraTax.Checked == true)
            {
                if (ExtraTaxAccountID.Text == "" || ExtraTaxAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid extra Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.ExtraTaxAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid extra Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.ExtraTaxRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid extra Tax rate", "Error", MessageBoxButtons.OK);
                    return;

                }
            }
            if (this.doFreight.Checked == true)
            {
                if (this.FreightAccountID.EditValue == null || this.FreightAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid freight Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FreightAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid frieght Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.FreightAmount.EditValue == null)
                {
                    XtraMessageBox.Show("invalid extra Tax rate", "Error", MessageBoxButtons.OK);
                    return;

                }

            }
            if (this.doWHT.Checked == true)
            {
                if (this.WHTAccountID.Text == "" || this.WHTAccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("invalid WHT Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.WHTAccountName.Text == "")
                {
                    XtraMessageBox.Show("invalid WHT Tax Account", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.WHTRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid WHT Tax rate", "Error", MessageBoxButtons.OK);
                    return;

                }
            }
            foreach (Control c in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales Ac = (UserControls.Account_SalesInvoice_FabricSales)c;
                if (Ac.SellingUnit.EditValue == null)
                {
                    XtraMessageBox.Show("invalid selling unit", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.SellingUnit.Focus();
                    return;
                }
                if (Ac.AccountID.Text.Length != 13)
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag == null)
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.AccountName.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Sales Account seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Ac.AccountID.Focus();
                    return;
                }
                if (Ac.Quantity.EditValue == null)
                {
                    XtraMessageBox.Show("invalid quantity", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.Rate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid rate", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.GSTRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid GST Rate", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.ContractNumber.EditValue == null && Settings.BoundInvoiceWithPO == true)
                {
                    XtraMessageBox.Show("invalid Contract / PO / W.O #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Ac.ContractNumber.EditValue != null)
                {
                    if (Ac.ContractNumber.EditValue.ToString() == "" && Settings.BoundInvoiceWithPO == true)
                    {
                        XtraMessageBox.Show("invalid Contract / PO / W.O #", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

            }

            if (radio_AppendedJournal.EditValue != null)
            {
                if (radio_AppendedJournal.EditValue.ToString() == "1")
                {
                    if (AppendedJournal == null)
                    {
                        XtraMessageBox.Show("invalid appended journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (AppendedJournal.tableLayoutPanel_Detail.Controls.Count < 2)
                    {
                        XtraMessageBox.Show("atleast one debit and one credit entry is required in appended journal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    int cCreditSide = 0;
                    int cDebitSide = 0;
                    foreach (Control c in AppendedJournal.tableLayoutPanel_Detail.Controls)
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
                        if (Ac.Credit.EditValue == null)
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Ac.Credit.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Int32.TryParse(Ac.Credit.EditValue.ToString(), out cCreditSide) == false)
                        {
                            XtraMessageBox.Show("Credited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Credit.Focus();
                            return;
                        }
                        if (Ac.Debit.EditValue == null)
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (Ac.Debit.EditValue.ToString() == "")
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (Int32.TryParse(Ac.Debit.EditValue.ToString(), out cDebitSide) == false)
                        {
                            XtraMessageBox.Show("Debited amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }
                        if (cDebitSide <= 0 && cCreditSide <= 0)
                        {
                            XtraMessageBox.Show("amount is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Ac.Debit.Focus();
                            return;
                        }


                    }
                    if (AppendedJournal.vCalc.singleTotal <= 0)
                    {
                        XtraMessageBox.Show("Amount seems to be invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }

                    if (AppendedJournal.vCalc.difference != 0)
                    {
                        XtraMessageBox.Show("There should not be any difference in amount between debit and credit side of voucher ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        return;
                    }
                }
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.vPrefix.Text + this.vFinancialYear.Text + this.vSuffix.Text;
            string inum = this.SalesInvoicePrefix.Text + this.SalesInvoiceFinancialYear.Text + this.SalesInvoiceSuffix.Text;
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

            double dExtraTaxAmount = 0;
            double dSalesTaxAmount = 0;
            double dAmountIncTaxBeforeOtherTaxes = 0;
            double dAmountIncTaxAfterAllTaxes = 0;
            double dExtraTaxRate = 0;
            double dAmountExTax = 0;
            double dFreightAmount = 0;
            double dWHTAmount = 0;
            double dWHTRate = 0;

            if (this.doWHT.Checked == true && WHTRate.EditValue == null)
            {
                XtraMessageBox.Show("Invalid WHT Rate!", "Error");
                return;
            }
          
            try
            {
                double.TryParse(this.Amount_Tax.Tag.ToString(), out dSalesTaxAmount);
            }
            catch
            {
                XtraMessageBox.Show("invalid sales tax amount!", "Error");
                return;
            }
            try
            {
                double.TryParse(this.Amount_IncTax.Tag.ToString(), out dAmountIncTaxBeforeOtherTaxes);
            }
            catch
            {
                XtraMessageBox.Show("invalid Amount including tax in label tag!", "Error");
                return;
            }
            dAmountIncTaxAfterAllTaxes = dAmountIncTaxBeforeOtherTaxes;
            if (this.doExtraTax.Checked == true)
            {
                double.TryParse(this.ExtraTaxRate.EditValue.ToString(), out dExtraTaxRate);
                if (this.Amount_ExTax.Tag.ToString() != "")
                    double.TryParse(this.Amount_ExTax.Tag.ToString(), out dAmountExTax);

                dExtraTaxAmount = dAmountExTax * dExtraTaxRate / 100;
                dExtraTaxAmount = Math.Round(dExtraTaxAmount, 0);
                dAmountIncTaxAfterAllTaxes += dExtraTaxAmount;
            }

            if (this.doFreight.Checked == true)
            {

                double.TryParse(this.FreightAmount.EditValue.ToString(), out dFreightAmount);
                dFreightAmount = Math.Round(dFreightAmount, 0);
                dAmountIncTaxAfterAllTaxes += dFreightAmount;
            }
            if (this.doWHT.Checked == true)
            {
                double.TryParse(this.WHTRate.EditValue.ToString(), out dWHTRate);
                dWHTAmount = dSalesTaxAmount * dWHTRate / 100;
                dWHTAmount = Math.Round(dWHTAmount, 0);
            }

            queries[0] = "update AC_Voucher_Main set ";
            queries[0] += "VNumber='" + vnum + "',VType='" + vPrefix.Text + "',VCat='" + vCat + "',VYear='" + vFinancialYear.Text + "'";
            if (this.SalesDate.EditValue != null)
                queries[0] += ",VDate='" + this.SalesDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",VDate=null";
            if (this.SalesDate.DateTime != null)
                queries[0] += ",vTime='" + this.SalesDate.DateTime.ToShortTimeString() + "'";
            else
                queries[0] += ",vTime=null";

            queries[0] += ",VStatus='U'";
            if (this.Remarks.Text != "")
                queries[0] += ",VRemarks='" + this.Remarks.Text + "'";
            else
                queries[0] += ",vRemarks=null";
            if (dAmountIncTaxAfterAllTaxes>0)
                queries[0] += ",vAmount=" + dAmountIncTaxAfterAllTaxes.ToString() + "";
            else
                queries[0] += ",vAmount=0";
           
            if (inum != "")
                queries[0] += ",AttachedInvoiceNumber='" + inum + "'";
            else
                queries[0] += ",AttachedInvoiceNumber=null";
            queries[0] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(Accounting.culture) + "' where vNumber='" + Number_VouchertoEdit + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Sales_Main set  ";
            queries[queries.Length - 1] += "iNumber='" + inum + "',iSalesTypeID='"+this.typeOfSales.Tag.ToString()+"',iPaymentTerms='" + this.Paymentterms.EditValue.ToString() + "',iType='" + this.SalesInvoicePrefix.Text + "',iCat='" + vCat + "',iYear='" + this.SalesInvoiceFinancialYear.Text + "'";
            if (this.SalesDate.EditValue != null)
                queries[queries.Length - 1] += ",iDate='" + this.SalesDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",iDate=null";
            if (this.DueDate.DateTime != null)
                queries[queries.Length - 1] += ",DueDate='" + this.DueDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",DueDate=null";

            
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",iRemarks='" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",iRemarks=null";

            queries[queries.Length - 1] += ",iGSTRate=" + this.GSTRate.Text + "";

            if (this.SalesDiscountPercent.Text != "0")
                queries[queries.Length - 1] += ",iDiscountPercent=" + this.SalesDiscountPercent.Text + "";
            else
                queries[queries.Length - 1] += ",iDiscountPercent=0";
            if (this.SalesDiscountAmount.Text != "0")
                queries[queries.Length - 1] += ",iDiscountAmount=" + this.SalesDiscountAmount.Text + "";
            else
                queries[queries.Length - 1] += ",iDiscountAmount=0";

            
            if (vnum != "")
                queries[queries.Length - 1] += ",AttachedVoucherNumber='" + vnum + "'";
            else
                queries[queries.Length - 1] += ",AttachedVoucherNumber=null";

            if (this.BuyersAccountID.Text != "")
                queries[queries.Length - 1] += ",BuyerID='" + this.BuyersAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",BuyerID=null";

            if (this.MappedAccountID.Text != "")
                queries[queries.Length - 1] += ",BuyerMappedID='" + this.MappedAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",BuyerMappedID=null";

            if (this.Amount_ExTax.Tag.ToString() != "")
                queries[queries.Length - 1] += ",ValExTax=" + this.Amount_ExTax.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",ValExTax=0";
            if (this.Amount_Tax.Tag.ToString() != "")
                queries[queries.Length - 1] += ",ValTax=" + this.Amount_Tax.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",ValTax=0";
            if (this.Amount_IncTax.Tag.ToString() != "")
                queries[queries.Length - 1] += ",ValInTax=" + this.Amount_IncTax.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",ValInTax=0";
           
            if (this.doExtraTax.Checked ==true)
                queries[queries.Length - 1] += ",doExtraTax=1";
            else
                queries[queries.Length - 1] += ",doExtraTax=0";
            if (this.doExtraTax.Checked == true && this.ExtraTaxAccountID.Text!="")
                queries[queries.Length - 1] += ",ExtraTaxAccountID='"+this.ExtraTaxAccountID.Text+"'";
            else
                queries[queries.Length - 1] += ",ExtraTaxAccountID=null";
            if (this.doExtraTax.Checked == true && this.ExtraTaxRate.EditValue != null)
                queries[queries.Length - 1] += ",ExtraTaxRate=" + this.ExtraTaxRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ExtraTaxRate=0";
            if (this.doExtraTax.Checked == true && this.ExtraTaxRate.EditValue != null)
                queries[queries.Length - 1] += ",ExtraTaxAmount=" + dExtraTaxAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",ExtraTaxAmount=0";

            if (this.doFreight.Checked == true)
                queries[queries.Length - 1] += ",doFreight=1";
            else
                queries[queries.Length - 1] += ",doFreight=0";
            if (this.doFreight.Checked == true && this.FreightAccountID.Text != "")
                queries[queries.Length - 1] += ",FreightAccountID='" + this.FreightAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",FreightAccountID=null";
            if (this.doFreight.Checked == true && this.FreightAmount.EditValue != null)
                queries[queries.Length - 1] += ",FreightAmount=" + dFreightAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",FreightAmount=0";
            if (this.doFreight.Checked == true && this.FreightParticulars.EditValue != null)
                queries[queries.Length - 1] += ",FreightParticulars='" + FreightParticulars.Text + "'";
            else
                queries[queries.Length - 1] += ",FreightParticulars=null";

            if (this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",doWHT=1";
            else
                queries[queries.Length - 1] += ",doWHT=0";
            if (this.WHTAccountID.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",WHTAccountID='" + this.WHTAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",WHTAccountID=null";
            if (this.WHTRate.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",WHTRate=" + this.WHTRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTRate=0";
            if (this.WHTRate.EditValue != null && this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",WHTAmount=" + dWHTAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTAmount=0";



            queries[queries.Length - 1] += " where iNumber='"+Number_InvoicetoEdit+"'";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where vNumber='"+Number_VouchertoEdit+"'";
            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from AC_Sales_Sub where iNumber='"+Number_InvoicetoEdit+"'";

            if (radio_AppendedJournal.EditValue != null)
            {
                if (radio_AppendedJournal.EditValue.ToString() == "1")
                {
                    foreach (Control C in AppendedJournal.tableLayoutPanel_Detail.Controls)
                    {
                        UserControls.AccountGeneral AField = (UserControls.AccountGeneral)C;
                        Array.Resize(ref queries, queries.Length + 1);
                        queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                        queries[queries.Length - 1] += "'" + vnum + "'";
                        if (AField.AccountID.Text != "")
                            queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                        if (AField.Particulars.Text != "")
                            queries[queries.Length - 1] += ",'" + AField.Particulars.Text + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                        if (inum != "")
                            queries[queries.Length - 1] += ",'" + inum + "'";
                        else
                            queries[queries.Length - 1] += ",null";

                        if (AField.Debit.EditValue.ToString() != "")
                            queries[queries.Length - 1] += ",'" + AField.Debit.EditValue.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",0";

                        if (AField.Credit.EditValue.ToString() != "")
                            queries[queries.Length - 1] += "," + AField.Credit.EditValue.ToString() + "";
                        else
                            queries[queries.Length - 1] += ",0";

                        queries[queries.Length - 1] += ",2)";
                    }
                }
            }
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VRefDeliveryChallanNumber,vRefGatePassNumber,vRefPackingListNumber,VDebitAmount,VCreditAmount,isHead) Values (";
            queries[queries.Length - 1] += "'" + vnum + "'";
            if (this.BuyersAccountID.Text != "" && this.BuyersAccountID.Text.Length == 13)
                queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + inum + "'";

            queries[queries.Length - 1] += ",null,null,null";
            if (dAmountIncTaxAfterAllTaxes>0)
                queries[queries.Length - 1] += "," + dAmountIncTaxAfterAllTaxes.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",0,1)";
            if (AutoRemarks.Checked == true)
                this.Remarks.Text = "Invoice # " + inum;
            string PackingList = ""; string GatePass = "";
            foreach (Control C in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales AField = (UserControls.Account_SalesInvoice_FabricSales)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,vRefDeliveryChallanNumber,vRefPackingListNumber,vRefGatePassNumber,vrefContractNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AutoRemarks.Checked == true)
                    this.Remarks.Text += " Article  " + AField.Item.Text + " Qty " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text;
                string particulars = " Invoice # " + inum + " Article  " + AField.Item.Text + " Quantity " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text + " per " + AField.SellingUnit.EditValue.ToString();
                if (AField.DeliveryChallanNumber.Text != "")
                {
                    particulars += " D.C # " + AField.DeliveryChallanNumber.Text;
                    if (AutoRemarks.Checked == true) this.Remarks.Text += " D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {
                    particulars += " Packing List # " + AField.PackingListNumber.Text;
                    if (PackingList != AField.PackingListNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " Packing List # " + AField.PackingListNumber.Text;
                            PackingList = AField.PackingListNumber.Text;
                        }
                    }
                }

                if (AField.GatePassNumber.Text != "")
                {
                    particulars += " Gate Pass # " + AField.GatePassNumber.Text;
                    if (GatePass != AField.GatePassNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " G.P # " + AField.GatePassNumber.Text;
                            GatePass = AField.GatePassNumber.Text;
                        }
                    }
                }

                if (particulars != "")
                    queries[queries.Length - 1] += ",'" + particulars + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.PackingListNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.PackingListNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.GatePassNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.GatePassNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",0";
                if (AField.AmountExcludingTax.EditValue !=null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";





                if (AField.SellingUnit.EditValue != null && AField.ItemID.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);

                    queries[queries.Length - 1] = "update PP_Article set SellingUnit='" + AField.SellingUnit.EditValue.ToString() + "' , SellingRate=" + AField.Rate.Text + " where ArticleNumber='" + AField.ItemID.Text + "'";
                }
              


                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Sales_Sub (iNumber,AccountID,Rate,Qty,GSTRate,PackingListNumber,GatePassNumber,DeliveryChallanNumber,ContractNumber,ArticleNumber,ArticleName,Unit,ValExTax,ValTax,ValInTax) values(";
                queries[queries.Length - 1] += "'" + inum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Rate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Rate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Quantity.EditValue !=null)
                    queries[queries.Length - 1] += "," + AField.Quantity.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.GSTRate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.GSTRate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.PackingListNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.PackingListNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.GatePassNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.GatePassNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.DeliveryChallanNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.DeliveryChallanNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ItemID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ItemID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Item.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Item.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.SellingUnit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.SellingUnit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountExcludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountIncludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountIncludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";


















            }
            if (NG.Checked == false && dSalesTaxAmount>0)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GSTAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.GSTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularstax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  amount excluding sales tax is " + this.Amount_ExTax.Text +"%";


                if (particularstax != "")
                    queries[queries.Length - 1] += ",'" + particularstax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";

                queries[queries.Length - 1] += ",0";



                if (this.Amount_Tax.Text != "")
                    queries[queries.Length - 1] += "," + this.Amount_Tax.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (this.doExtraTax.Checked == true)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.ExtraTaxAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.ExtraTaxAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsExtraTax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " extra / additional tax  deducted  @ " + this.ExtraTaxRate.Text + "%  is " + dExtraTaxAmount.ToString("#,##") + " ";


                if (particularsExtraTax != "")
                    queries[queries.Length - 1] += ",'" + particularsExtraTax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";



                queries[queries.Length - 1] += ",0";//debit
                queries[queries.Length - 1] += "," + dExtraTaxAmount.ToString() + "";//credit
                queries[queries.Length - 1] += ",0)";





            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (this.doFreight.Checked == true)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.FreightAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.FreightAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsExtraTax = " Invoice # " + inum + " sold to M/S  " + this.BuyersAccountName.Text + " freight deducted " + this.FreightParticulars.Text;


                if (particularsExtraTax != "")
                    queries[queries.Length - 1] += ",'" + particularsExtraTax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";



                queries[queries.Length - 1] += ",0";//debit
                queries[queries.Length - 1] += "," + dFreightAmount.ToString() + "";//credit
                queries[queries.Length - 1] += ",0)";





            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (this.doWHT.Checked == true)
            {
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.WHTAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.WHTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularsWHT = " Invoice # " + inum + " invoiced to M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + this.WHTRate.Text + "%";


                if (particularsWHT != "")
                    queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";




                if (dWHTAmount != 0)
                    queries[queries.Length - 1] += "," + dWHTAmount.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";



                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.BuyersAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";



                if (particularsWHT != "")
                    queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";


                queries[queries.Length - 1] += ",0";

                if (dWHTAmount != 0)
                    queries[queries.Length - 1] += "," + dWHTAmount.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";

                queries[queries.Length - 1] += ",0)";



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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


                    this.tableLayoutPanel_Payment.Controls.Clear();
                    this.BuyersAccountID.Text = "";
                    this.Remarks.Text = "";
                    this.doExtraTax.Checked = false;
                    this.ExtraTaxRate.EditValue = Accounting.RegAccounts.EXTRATAXRATE;
                    this.ExtraTaxAccountID.EditValue = Accounting.RegAccounts.EXTRATAXACCOUNT;

                    this.doFreight.Checked = false;
                    this.FreightParticulars.EditValue = null;
                    this.FreightAmount.EditValue = null;
                    this.FreightAccountID.EditValue = null;
                    this.FreightAccountName.Text = "";
                    this.doWHT.Checked = false;
                    this.WHTRate.Text = Accounting.RegAccounts.WHTRATE;
                    this.WHTAccountID.Text = Accounting.RegAccounts.WHTACCOUNT;
                    this.vSuffix.Tag = this.vSuffix.Text;
                    this.vFinancialYear.Tag = this.vFinancialYear.Text;
                    this.vPrefix.Tag = this.vPrefix.Text;
                    this.SalesInvoiceFinancialYear.Tag = this.SalesInvoiceFinancialYear.Text;
                    this.SalesInvoicePrefix.Tag = this.SalesInvoicePrefix.Text;
                    this.SalesInvoiceSuffix.Tag = this.SalesInvoiceSuffix.Text;
                    this.vSuffix.Text = "";
                    this.SalesInvoiceSuffix.Text = "";
                    this.SalesDiscountPercent.Text = "0";
                    this.SalesDiscountAmount.Text = "0";
                    this.View.Tag = inum;
                    this.Print.Tag = inum;
                    this.PrintVoucher.Tag = vnum;
                    this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
                    UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
                    nAS.salesTypeID = this.typeOfSales.Tag.ToString();
                    nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
                    this.GSTRate.Text = nAS.GSTRate.Text;
                    nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
                    vCalc.controls_AmountExTax = Amount_ExTax;
                    vCalc.controls_AmountInTax = Amount_IncTax;
                    vCalc.controls_AmountSalesTax = Amount_Tax;
                    

                    nAS.eVC = vCalc;
                    this.tableLayoutPanel_Payment.Controls.Add(nAS);
                    if (radio_AppendedJournal.EditValue.ToString() == "1")
                    {
                        if (AppendedJournal != null)
                        {
                            AppendedJournal.Controls.Clear();
                            AppendedJournal.AddControl();
                        }
                    }
                    SetButtonStates(UserInputMode.View);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.vPrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vPrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vSuffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vFinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.vFinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid voucher selected", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.SalesInvoicePrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.SalesInvoicePrefix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.SalesInvoiceSuffix.Tag == null)
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.SalesInvoiceSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.SalesInvoiceFinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.SalesInvoiceFinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid invoice selected", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentStatus.Tag != null)
            {
                if (this.DocumentStatus.Tag.ToString() == "P")
                {
                    XtraMessageBox.Show("Invoice has been posted ....can not edit / delete posted voucher", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            if (this.DocumentAuthorized.Checked == true)
            {
                XtraMessageBox.Show("Invoice has been signed by authorized person ....can not edit / delete Authorized voucher", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentClosed.Checked == true)
            {
                XtraMessageBox.Show("Invoice has been closed  ....can not edit / delete Closed voucher", "Error", MessageBoxButtons.OK);
                return;
            }
            SetButtonStates(UserInputMode.Delete);
        }

      

        private void GSTAccountID_TextChanged(object sender, EventArgs e)
        {
            this.GSTAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.GSTAccountID.Text);
        }

        private void SalesDiscountID_TextChanged(object sender, EventArgs e)
        {
            this.SalesDiscountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.SalesDiscountID.Text);
        }

        private void Browse_BuyersAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.BuyersAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.MappedAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void BuyersAccountID_TextChanged(object sender, EventArgs e)
        {
            this.BuyersAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(BuyersAccountID.Text);
        }

        private void BuyersAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            SetAutoRemarks();
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.BuyersAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        if (Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString() != "")
                            this.MappedAccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString();
                        else
                            this.MappedAccountID.EditValue = null;
                        foreach (Control c in this.tableLayoutPanel_Payment.Controls)
                        {
                            UserControls.Account_SalesInvoice_FabricSales Ac = (UserControls.Account_SalesInvoice_FabricSales)c;
                            Ac.BuyerID = this.MappedAccountID.Text; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BrowseSalesDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                   this.SalesDiscountID.Text= Program.MainWindow.AccountsList.SelectedRow.PrimeryID;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Amount_IncTax_TextChanged(object sender, EventArgs e)
        {
            CalcNetAmount();
        }
        private void CalcNetAmount()
        {
            try
            {
                int discount = 0;
                Int32.TryParse(this.SalesDiscountAmount.Text, out discount);
                Amount_Net.Text = Convert.ToInt32(Convert.ToInt32(Amount_IncTax.Tag.ToString()) - discount).ToString("#,##");
                Amount_Net.Tag = Convert.ToInt32(Convert.ToInt32(Amount_IncTax.Tag.ToString()) - discount).ToString();
            }
            catch
            {
            }
        }

        private void SalesDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            CalcNetAmount();
        }

        private void Execute_Click(object sender, EventArgs e)
        {

            SetAutoRemarks();


            if (uiMode == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                 Save_NewInvoiceandVoucher();
            }
            else if (uiMode == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                 Update_InvoiceandVoucher();
            }
            else if (uiMode == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Invoice();
            }
           
               
        }
        private void Delete_Invoice()
        {
            string veditNum = this.vPrefix.Tag.ToString() + this.vFinancialYear.Tag.ToString() + this.vSuffix.Tag.ToString();
            string ieditNum = this.SalesInvoicePrefix.Tag.ToString() + this.SalesInvoiceFinancialYear.Tag.ToString() + this.SalesInvoiceSuffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete invoice # " + ieditNum, "Delete ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where  VNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Main where  VNumber='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Sales_Sub where  iNumber='" + ieditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Sales_Main where  iNumber='" + ieditNum + "'";
            
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
                    this.tableLayoutPanel_Payment.Controls.Clear();
                    UserControls.Account_SalesInvoice_FabricSales Payment = new UserControls.Account_SalesInvoice_FabricSales();
                    Payment.eVC = vCalc;
                    Payment.salesTypeID = this.typeOfSales.Tag.ToString();
                    Payment.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(Payment.salesTypeID);
                    this.GSTRate.Text = Payment.GSTRate.Text;
                    Payment.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(Payment.salesTypeID);
                    this.tableLayoutPanel_Payment.Controls.Add(Payment);
                    this.View.Tag = "";
                    this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
                    SetButtonStates(UserInputMode.View);
                    this.BuyersAccountID.Text = "";
                    this.BuyersAccountName.Text = "";
                    this.vPrefix.Tag = "";
                    this.vSuffix.Tag = "";
                    this.vSuffix.Text = "";
                    this.SalesInvoiceFinancialYear.Tag = "";
                    this.SalesInvoicePrefix.Tag = "";
                    this.SalesInvoiceSuffix.Tag = "";
                    this.SalesInvoiceSuffix.Text = "";
                    this.vSuffix.Text = "";
                    if (radio_AppendedJournal.EditValue.ToString() == "1")
                    {
                        if (AppendedJournal != null)
                        {
                            AppendedJournal.Controls.Clear();
                            AppendedJournal.AddControl();
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AutoRemarks_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoRemarks.Checked == true)
                this.Remarks.Properties.ReadOnly = true;
            else
                this.Remarks.Properties.ReadOnly = false;
        }
        private void PrintSalesTaxInvoice(string InvoiceNumber)
        {

            DataSet ds_AC_Sales_Main = WS.svc.Get_DataSet("select * from Accounts_Sales_MAIN where iNumber='" + InvoiceNumber + "'");
            if (ds_AC_Sales_Main == null) return;
            if (ds_AC_Sales_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_AC_Sales_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Sales_Sub where iNumber='" + InvoiceNumber + "'");
            if (ds_AC_Sales_Sub_T == null) return;
            if (ds_AC_Sales_Sub_T.Tables[0].Rows.Count <= 0)
                return;


            Reports.Accounts_SalesInvoice rpInvoice = new Reports.Accounts_SalesInvoice();
            rpInvoice.BeginInit();
            rpInvoice.vBarcode.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString();
            try
            {
                rpInvoice.xrGSTRATELabel.Text = "Sales Tax @" + ds_AC_Sales_Main.Tables[0].Rows[0]["iGSTRate"].ToString() + "%";
                rpInvoice.InvoiceDate.Text = Convert.ToDateTime(ds_AC_Sales_Main.Tables[0].Rows[0]["iDate"].ToString(),System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");
                rpInvoice.InvoiceDueDate.Text = Convert.ToDateTime(ds_AC_Sales_Main.Tables[0].Rows[0]["DueDate"].ToString(),System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");
                rpInvoice.xrTypeofSales.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["salesTypeName"].ToString();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Date / Due Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (this.radioGroup_CopyType.EditValue.ToString() == "Office")
                rpInvoice.xrCopyType.Text = "Office Copy";
            else if (this.radioGroup_CopyType.EditValue.ToString() == "Customer")
                rpInvoice.xrCopyType.Text = "Customer Copy";
           
                rpInvoice.vDocumentNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString().Substring(Settings.InvoiceStartIndex, Settings.InvoiceLength);
            

            rpInvoice.InvoiceDeliveryChallanNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["DeliveryChallanNumber"].ToString();
            rpInvoice.InvoiceGatePassNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["GatePassNumber"].ToString();
            rpInvoice.InvoicePackingListNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["PackingListNumber"].ToString();
            string QColumn = "Quantity";
            QColumn += ds_AC_Sales_Sub_T.Tables[0].Rows[0]["Unit"].ToString() == "" ? "" : "(" + ds_AC_Sales_Sub_T.Tables[0].Rows[0]["Unit"].ToString() + ")";
            rpInvoice.QuantityColumnName.Text = QColumn;
            rpInvoice.BuyerName.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AccountName"].ToString();
            rpInvoice.BuyerAddress.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["MailingAddress"].ToString();
            rpInvoice.BuyerEmail.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["email"].ToString();
            rpInvoice.BuyerGSTNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["GST"].ToString();
            rpInvoice.BuyerNTNNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["NTN"].ToString();
            rpInvoice.BuyerPhone.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["Phone1"].ToString() + ", " + ds_AC_Sales_Main.Tables[0].Rows[0]["Phone2"].ToString();
            rpInvoice.xr_AttachedVoucherNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
            rpInvoice.BuyerFax.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["Fax"].ToString();
            rpInvoice.InvoicePaymentTerms.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iPaymentTerms"].ToString();
            rpInvoice.vNTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
            rpInvoice.vGST.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
            rpInvoice.vEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
            rpInvoice.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            rpInvoice.vAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress + " Ph: " + Program.ss.Machines.PresentationData.CPInfo.cpPhone + " Fax: " + Program.ss.Machines.PresentationData.CPInfo.cpFAX;

            rpInvoice.DataSource = ds_AC_Sales_Sub_T;
            rpInvoice.EndInit();
            rpInvoice.ShowPreview();
        }
        private void Print_Click(object sender, EventArgs e)
        {
            
            if (this.Print.Tag == null)
            {
                XtraMessageBox.Show("Invalid Invoice ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Invoice ", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.Print.Tag.ToString().Substring(0, 2) == "90")
                PrintSalesTaxInvoice(this.Print.Tag.ToString());
            else if (this.Print.Tag.ToString().Substring(0, 2) == "91")
                PrintSalesBill(this.Print.Tag.ToString());
        }
        private void PrintSalesBill(string InvoiceNumber)
        {
            DataSet ds_AC_Sales_Main = WS.svc.Get_DataSet("select * from Accounts_Sales_MAIN where iNumber='" + InvoiceNumber + "'");
            if (ds_AC_Sales_Main == null) return;
            if (ds_AC_Sales_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_AC_Sales_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Sales_Sub where iNumber='" + InvoiceNumber + "'");
            if (ds_AC_Sales_Sub_T == null) return;
            if (ds_AC_Sales_Sub_T.Tables[0].Rows.Count <= 0)
                return;


            Reports.Accounts_SalesBill rpInvoice = new Reports.Accounts_SalesBill();
            rpInvoice.BeginInit();
            rpInvoice.vBarcode.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString();
            rpInvoice.TypeofSales.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["salesTypeName"].ToString();

            try
            {
                rpInvoice.InvoiceDate.Text = Convert.ToDateTime(ds_AC_Sales_Main.Tables[0].Rows[0]["iDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");
                rpInvoice.InvoiceDueDate.Text = Convert.ToDateTime(ds_AC_Sales_Main.Tables[0].Rows[0]["DueDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Date / Due Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            //if (this.radioGroup_CopyType.EditValue.ToString() == "Office")
            //    rpInvoice.xrCopyType.Text = "Office Copy";
            //else if (this.radioGroup_CopyType.EditValue.ToString() == "Customer")
            //    rpInvoice.xrCopyType.Text = "Customer Copy";

            //rpInvoice.vDocumentNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            //rpInvoice.vDocumentNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            rpInvoice.BuyerName.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AccountName"].ToString();
            rpInvoice.xr_AttachedVoucherNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
            rpInvoice.InvoicePaymentTerms.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iPaymentTerms"].ToString();
            rpInvoice.DataSource = ds_AC_Sales_Sub_T;
            rpInvoice.EndInit();
            rpInvoice.ShowPreview();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }
        private void Fill_Invoice(string iNumber)
        {
            
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from AC_Sales_Main where iNumber='" + iNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;
           
            if (ds_VoucherMain.Tables[0].Rows[0]["iCat"].ToString() == "G")
            {
                this.NG.Checked = false;
                this.DocumentCategory.Checked = false;
            }
            else
            {
                this.DocumentCategory.Checked = true;
                this.NG.Checked = true;
            }
            string a = ds_VoucherMain.Tables[0].Rows[0]["iAuthorized"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["iAuthorized"].ToString() == "False")
            {
                this.DocumentAuthorized.Checked = false;

            }
            else
            {
                this.DocumentAuthorized.Checked = true;
            }
            this.DocumentStatus.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString() == "U")
            {
                this.DocumentStatus.Checked = false;

            }
            else
            {
                this.DocumentStatus.Checked = true;

            }

            if (ds_VoucherMain.Tables[0].Rows[0]["doExtraTax"].ToString() == "1")
            {
                this.doExtraTax.Checked = true;
                this.ExtraTaxAccountID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["ExtraTaxAccountID"].ToString();
                this.ExtraTaxRate.EditValue = ds_VoucherMain.Tables[0].Rows[0]["ExtraTaxRate"].ToString();
               

            }
            else
            {
                this.doExtraTax.Checked = false;
               
                this.ExtraTaxRate.EditValue = Accounting.RegAccounts.EXTRATAXRATE;
                this.ExtraTaxAccountID.EditValue = Accounting.RegAccounts.EXTRATAXACCOUNT;

            }

            if (ds_VoucherMain.Tables[0].Rows[0]["doWHT"].ToString() == "1")
            {
                this.doWHT.Checked = true;
                this.WHTAccountID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["WHTAccountID"].ToString();
                this.WHTRate.EditValue = ds_VoucherMain.Tables[0].Rows[0]["WHTRate"].ToString();


            }
            else
            {
                this.doWHT.Checked = false;

                this.WHTRate.EditValue = Accounting.RegAccounts.WHTRATE;
                this.WHTAccountID.EditValue = Accounting.RegAccounts.WHTACCOUNT;

            }


            if (ds_VoucherMain.Tables[0].Rows[0]["doFreight"].ToString() == "1")
            {
                this.doFreight.Checked = true;
                this.FreightAccountID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["FreightAccountID"].ToString();
                this.FreightAmount.EditValue = ds_VoucherMain.Tables[0].Rows[0]["FreightAmount"].ToString();
                this.FreightParticulars.Text = ds_VoucherMain.Tables[0].Rows[0]["FreightParticulars"].ToString();


            }
            else
            {
                this.doFreight.Checked = false;

                this.FreightAmount.EditValue = null;
                this.FreightAccountID.EditValue = null;
                this.FreightParticulars.EditValue = null;
            }
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString();
            this.PrintVoucher.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
            this.SalesInvoiceSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            this.SalesInvoiceSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            this.SalesInvoicePrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(0, 3);
            this.SalesInvoicePrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(0, 3);
            this.SalesInvoiceFinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(3, 4);
            this.SalesInvoiceFinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(3, 4);
            
            this.vSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(7, 6);
            this.vSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(7, 6);
            this.vPrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(0, 3);
            this.vPrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(0, 3);
            this.vFinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(3, 4);
            this.vFinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(3, 4);
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
            string vNumber = "";
            vNumber = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();

            this.BuyersAccountID.Text = ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString();
            try
            {
                this.SalesDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["iDate"].ToString(),System.Globalization.CultureInfo.CurrentCulture);
                this.DueDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["DueDate"].ToString(),System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               
            }
            this.GSTRate.Text = ds_VoucherMain.Tables[0].Rows[0]["iGSTRate"].ToString();
            this.MappedAccountID.Text = ds_VoucherMain.Tables[0].Rows[0]["BuyerMappedID"].ToString();
            this.Amount_Discount.Text = ds_VoucherMain.Tables[0].Rows[0]["iDiscountAmount"].ToString();
            this.SalesDiscountPercent.Text = ds_VoucherMain.Tables[0].Rows[0]["iDiscountPercent"].ToString();
            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["iRemarks"].ToString();

            
            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from AC_Sales_Sub where iNumber='" + iNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_Payment.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.Account_SalesInvoice_FabricSales Payment = new UserControls.Account_SalesInvoice_FabricSales();
                Payment.eVC = vCalc;
                this.tableLayoutPanel_Payment.Controls.Add(Payment);
                Payment.AccountID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();
                Payment.AccountID.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();
                Payment.Rate.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Rate"].ToString();
                Payment.Quantity.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Qty"].ToString();
                Payment.salesTypeID = this.typeOfSales.Tag.ToString();
                Payment.BuyerID = this.MappedAccountID.Text;
                Payment.GSTRate.Text = ds_VoucherSub_T.Tables[0].Rows[x]["GSTRate"].ToString();
                Payment.PackingListNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["PackingListNumber"].ToString();
                Payment.DeliveryChallanNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["DeliveryChallanNumber"].ToString();
                Payment.ContractNumber.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["ContractNumber"].ToString();
                Payment.GatePassNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["GatePassNumber"].ToString();
                Payment.ItemID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["ArticleNumber"].ToString();
                Payment.Item.Text = ds_VoucherSub_T.Tables[0].Rows[x]["ArticleName"].ToString();
                Payment.SellingUnit.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Unit"].ToString();


            }

            DataSet ds_VoucherSub_A = WS.svc.Get_DataSet("select * from AC_Voucher_Sub where vNumber='" + vNumber + "' and isHead=2");
            if (ds_VoucherSub_A != null)
            {
                if (ds_VoucherSub_A.Tables[0].Rows.Count > 0)
                {
                    if (AppendedJournal == null)
                        AppendedJournal = new Accounts_AppendGeneral();
                    this.radio_AppendedJournal.EditValue = "1";
                    AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
                    for (int x = 0; x < ds_VoucherSub_A.Tables[0].Rows.Count; x++)
                    {
                        UserControls.AccountGeneral AG=AppendedJournal.AddControl();
                        
                       
                        AG.AccountID.Text = ds_VoucherSub_A.Tables[0].Rows[x]["AccountID_V"].ToString();
                        AG.AccountID.Tag = ds_VoucherSub_A.Tables[0].Rows[x]["AccountID_V"].ToString();
                        AG.Particulars.Text = ds_VoucherSub_A.Tables[0].Rows[x]["VParticulars"].ToString();
                        AG.Debit.EditValue = ds_VoucherSub_A.Tables[0].Rows[x]["VDebitAmount"].ToString();
                        AG.Credit.EditValue = ds_VoucherSub_A.Tables[0].Rows[x]["VCreditAmount"].ToString();

                    }
                }
                else
                {
                    this.radio_AppendedJournal.EditValue = "0";
                    if (AppendedJournal != null)
                    {
                        AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
                        AppendedJournal.AddControl();
                    }
                }
            }
            else
            {
                this.radio_AppendedJournal.EditValue = "0";
                if (AppendedJournal != null)
                {
                    AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
                    AppendedJournal.AddControl();
                }

            }
            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }
        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();


            if (this.typeOfSales.Tag  == null)
            {
                XtraMessageBox.Show("invalid sales type ...select type of sales first", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.typeOfSales.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid sales type ...select type of sales first", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
         
            if (this.FilterDated.Checked == true)
            {
                if (this.SalesDate.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.FilterDated.Checked == true)
            {
                if (this.SalesDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Filter_InvoiceNumber.Checked == true)
            {
                if (this.SalesInvoiceSuffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Voucher filter or enter valid voucher", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }


            foreach (Control C in tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales aField = (UserControls.Account_SalesInvoice_FabricSales)C;
                if (aField.Filter_AccountID.Checked == true || aField.Filter_Item.Checked == true)
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
                    if (aField.Filter_Item.Checked == true)
                    {
                        if (aField.ItemID.Text == "")
                        {
                            XtraMessageBox.Show("Either uncheck the Item Filter or enter valid Item", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            aField.ItemID.Focus();
                            return;
                        }
                    }
                  
                 
                   
                   
                }
            }


            strFilterQuery = "SELECT iNumber,iDate,AccountName,ValExTax,ValTax,ValInTax  FROM Accounts_Sales_Main  ";
            strFilterQuery += "  where iType='" + this.SalesInvoicePrefix.Text + "' and iYear='" + this.SalesInvoiceFinancialYear.Text + "' and iSalesTypeID='"+this.typeOfSales.Tag.ToString()+"' ";

            

            if (this.FilterDated.Checked == true)
            {

                strFilterQuery += " and iDate='" + this.SalesDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.FilterBuyerID.Checked == true)
            {

                strFilterQuery += " and BuyerID=" + this.BuyersAccountID.Text + "";

            }

            if (this.Filter_InvoiceNumber.Checked == true)
            {

                strFilterQuery += " and iNumber like '%" + this.SalesInvoiceSuffix.Text + "%'";

            }
           
            string SubFilter = "";
            bool Appendand = false;
            foreach (Control C in tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales aField = (UserControls.Account_SalesInvoice_FabricSales)C;

                if (aField.Filter_AccountID.Checked == true || aField.Filter_Item.Checked == true )
                {
                    if (SubFilter == "")
                    {

                        SubFilter = " and iNumber in(select iNumber from AC_Sales_Sub where ";
                    }
                    if (aField.Filter_AccountID.Checked == true)
                    {
                        SubFilter += " AccountID='" + aField.AccountID.Text + "'";
                        Appendand = true;
                    }
                    if (aField.Filter_Item.Checked == true)
                    {
                        if (Appendand == true)
                            SubFilter += " and ";
                        SubFilter += " ArticleNumber='" + aField.ItemID.Text + "'";
                        Appendand = true;
                    }
                    
                   
                   
                    
                }
            }
            if (SubFilter != "")
                SubFilter += ")";
            strFilterQuery += SubFilter;
            strFilterQuery += " ORDER BY Convert(numeric(18),iNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "iNumber", "iNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_Invoice(sRow.PrimeryID);

            }
        }

        private void Accounts_SalesInvoice_Load(object sender, EventArgs e)
        {
            
            this.SalesInvoicePrefix.Text = "901";
            this.vPrefix.Text = "801";
            G_Number = "801";
            N_Number = "811";
            G_Invoice = "901";
            N_Invoice = "911";
            this.SalesInvoiceFinancialYear.Text = Accounting.RegAccounts.FinancialYear;
            this.vFinancialYear.Text = Accounting.RegAccounts.FinancialYear;
            this.GSTAccountID.Text = Accounting.RegAccounts.GSTACCOUNT;
            this.ExtraTaxAccountID.Text = Accounting.RegAccounts.EXTRATAXACCOUNT;
            this.ExtraTaxRate.Text = Accounting.RegAccounts.EXTRATAXRATE;
            this.WHTAccountID.Text = Accounting.RegAccounts.WHTACCOUNT;
            this.WHTRate.Text = Accounting.RegAccounts.WHTRATE;
            
            this.typeOfSales.Tag = "G";
            SalesType sType = Accounting.Get_SalesType_BySalesTypeID("G");
            if (sType != null)
            {
                this.typeOfSales.Text = sType.salesTypeName;
                this.typeOfSales.Tag = sType.salesTypeID;
            }
            else
            {
                this.typeOfSales.Text = "";
                this.typeOfSales.Tag = "";
            }
            UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
            nAS.salesTypeID = this.typeOfSales.Tag.ToString();
            nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
            this.GSTRate.Text = nAS.GSTRate.Text;
            nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
            vCalc.controls_AmountExTax = Amount_ExTax;
            vCalc.controls_AmountInTax = Amount_IncTax;
            vCalc.controls_AmountSalesTax = Amount_Tax;
            this.DueDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.SalesDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            vCalc.isNType = false;
            nAS.eVC = vCalc;
            this.tableLayoutPanel_Payment.Controls.Add(nAS);
            AppendedJournal.Text = "Sales Invoice [Additional Journal]";
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";
                               vCalc.isNType = true;
                this.vPrefix.Text = N_Number;
                this.SalesInvoicePrefix.Text = N_Invoice;
                this.doWHT.Checked = false;
                this.doExtraTax.Checked = false;
                
                if (uiMode == UserInputMode.Add || uiMode==UserInputMode.Edit)
                {
                    GetNextVoucherNumber();
                    GetNextInvoiceNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;
                vCalc.isNType = false;
                this.vPrefix.Text = G_Number;
                this.SalesInvoicePrefix.Text = G_Invoice;
                if (uiMode == UserInputMode.Add)
                {
                    GetNextVoucherNumber();
                    GetNextInvoiceNumber();
                }
            }
        }

        private void PrintVoucher_Click(object sender, EventArgs e)
        {
            if (this.PrintVoucher.Tag == null)
            {
                XtraMessageBox.Show("Invalid Voucher ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.PrintVoucher.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Voucher ", "Error", MessageBoxButtons.OK);
                return;
            }

            Accounting.Print_GeneralVoucher(this.PrintVoucher.Tag.ToString(), "Sales Voucher",this.RadioPageSetting.EditValue.ToString());
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BrowseAppendedJournal_Click(object sender, EventArgs e)
        {
            if (radio_AppendedJournal.EditValue == null) return;
            if (radio_AppendedJournal.EditValue.ToString() == "0") return;
            AppendedJournal.Show();
            AppendedJournal.BringToFront();

        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                string DocNumber = vPrefix.Text + vFinancialYear.Text + vSuffix.Text;
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

        private void salesTypeLookup_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void salesTypeLookup_EditValueChanged_1(object sender, EventArgs e)
        {
           
        }

      
        private void typeOfSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control ==true )
            {
                if (uiMode != UserInputMode.View)
                    return;
                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select * from AC_SalesTypes order by SalesTypeID", "salesTypeID", "SalesTypeName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.typeOfSales.Tag = sRow.PrimeryID;
                    this.typeOfSales.Text = sRow.PrimaryString;
                    this.SalesInvoicePrefix.Text = sRow.SelectedDataRow["G_InvoiceType"].ToString();
                    this.vPrefix.Text = sRow.SelectedDataRow["G_VoucherType"].ToString();
                    G_Number = sRow.SelectedDataRow["G_VoucherType"].ToString();
                    N_Number = sRow.SelectedDataRow["N_VoucherType"].ToString();
                    G_Invoice = sRow.SelectedDataRow["G_InvoiceType"].ToString();
                    N_Invoice = sRow.SelectedDataRow["N_InvoiceType"].ToString();
                    this.NG.Checked = false;
                    foreach (Control c in this.tableLayoutPanel_Payment.Controls)
                    {
                        UserControls.Account_SalesInvoice_FabricSales ao = (UserControls.Account_SalesInvoice_FabricSales)c;
                        ao.salesTypeID = this.typeOfSales.Tag.ToString();
                        ao.GSTRate.Text = Accounting.Get_GSTRate_BySalesTypeID(ao.salesTypeID);
                        this.GSTRate.Text = ao.GSTRate.Text;
                        if (uiMode == UserInputMode.Add)
                            ao.AccountID.Text = Accounting.Get_DefaultAccount_BySalesTypeID(ao.salesTypeID);

                    }
                }
            }
        }

        private void ChangeState_Click(object sender, EventArgs e)
        {

        }

        private void Clone_Click(object sender, EventArgs e)
        {
            if (this.SalesInvoiceFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.vFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.vPrefix.Text == "" || this.vPrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid voucher series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.SalesInvoicePrefix.Text == "" || this.SalesInvoicePrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid invoice series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
            this.vSuffix.Text = "";
            this.SalesInvoiceSuffix.Text = "";
          

            bool rRes = GetNextVoucherNumber();
            if (rRes != false)
            {
                rRes = GetNextInvoiceNumber();
                if (rRes != false)
                    SetButtonStates(UserInputMode.Add);
            }
            
        }

        private void ExtraTaxAccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.ExtraTaxAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.ExtraTaxAccountID.Text);
        }

        private void ExtraTaxAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.ExtraTaxAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        this.ExtraTaxAccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ExtraTaxAccountName_Click(object sender, EventArgs e)
        {

        }

       
        private void FreightAccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.FreightAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.FreightAccountID.Text);
        }

        

        private void FreightAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.FreightAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        this.FreightAccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void SalesDiscountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.SalesDiscountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        this.SalesDiscountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GSTAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.GSTAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        this.GSTAccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void GSTAccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.GSTAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.GSTAccountID.Text);
        }

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void WHTAccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.WHTAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.WHTAccountID.Text);
        }

        private void WHTAccountID_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.WHTAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        this.WHTAccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void tableLayoutPanel_Payment_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}