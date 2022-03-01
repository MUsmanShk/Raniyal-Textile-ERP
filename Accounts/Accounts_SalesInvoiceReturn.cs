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
    public partial class Accounts_SalesInvoiceReturn : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private easyVoucherCalculations vCalc = new easyVoucherCalculations();
        Accounts.Accounts_AppendGeneral AppendedJournal = new Accounts_AppendGeneral();
        private string G_Number;
        private string N_Number;
        private string G_Invoice;
        private string N_Invoice;
        public Accounts_SalesInvoiceReturn()
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
                    vNumber = WS.svc.Get_MaxNumber(query);
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
        private void PrintCreditNote(string InvoiceNumber)
        {
            try
            {
                DataSet ds_AC_Sales_Main = WS.svc.Get_DataSet("select * from Accounts_Sales_MAIN where iNumber='" + InvoiceNumber + "'");
                if (ds_AC_Sales_Main == null) return;
                if (ds_AC_Sales_Main.Tables[0].Rows.Count <= 0)
                    return;


                string subquery = "   SELECT      iIndex, iNumber, AccountID, Rate, Qty, GSTRate, PackingListNumber, DeliveryChallanNumber, GatePassNumber, ArticleNumber, ArticleName, Unit, AccountName_V, ValExTax, ValTax, ValInTax,substring( RefInvoiceNumber,"+(Settings.InvoiceStartIndex+1)+","+Settings.InvoiceLength+") as RefInvoiceNumber, RefInvoiceDate FROM         Accounts_Sales_Sub where iNumber='" + InvoiceNumber + "'";

                DataSet ds_AC_Sales_Sub_T = WS.svc.Get_DataSet(subquery);

                if (ds_AC_Sales_Sub_T == null) return;
                if (ds_AC_Sales_Sub_T.Tables[0].Rows.Count <= 0)
                    return;


                Reports.Accounts_SalesReturn rpInvoice = new Reports.Accounts_SalesReturn();
                rpInvoice.BeginInit();
                rpInvoice.vBarcode.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["iNumber"].ToString();
                try
                {
                    rpInvoice.InvoiceDate.Text = Convert.ToDateTime(ds_AC_Sales_Main.Tables[0].Rows[0]["iDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");

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
                rpInvoice.BuyerName.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AccountName"].ToString();
                rpInvoice.BuyerAddress.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["MailingAddress"].ToString();
                rpInvoice.BuyerEmail.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["email"].ToString();
                rpInvoice.BuyerGSTNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["GST"].ToString();
                rpInvoice.BuyerNTNNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["NTN"].ToString();
                rpInvoice.BuyerPhone.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["Phone1"].ToString() + ", " + ds_AC_Sales_Main.Tables[0].Rows[0]["Phone2"].ToString();
                rpInvoice.xr_AttachedVoucherNumber.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
                rpInvoice.InvoiceDeliveryChallanNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["DeliveryChallanNumber"].ToString();
                rpInvoice.InvoiceGatePassNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["GatePassNumber"].ToString();
                rpInvoice.InvoicePackingListNumber.Text = ds_AC_Sales_Sub_T.Tables[0].Rows[0]["PackingListNumber"].ToString();
                rpInvoice.BuyerFax.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["Fax"].ToString();
                rpInvoice.STWHLabel.Text = "S.T.W.H @ " + ds_AC_Sales_Main.Tables[0].Rows[0]["WHTRate"].ToString() + "%";
                rpInvoice.TypeofSales.Text = ds_AC_Sales_Main.Tables[0].Rows[0]["salesTypeName"].ToString() + " Return";
                string QColumn = "Quantity";
                QColumn += ds_AC_Sales_Sub_T.Tables[0].Rows[0]["Unit"].ToString() == "" ? "" : "(" + ds_AC_Sales_Sub_T.Tables[0].Rows[0]["Unit"].ToString() + ")";
                rpInvoice.QuantityColumnName.Text = QColumn;
                double stwht=0;
                double.TryParse( ds_AC_Sales_Main.Tables[0].Rows[0]["WHTAMOUNT"].ToString(),out stwht);
                rpInvoice.STWH.Text = stwht.ToString("#,##");
                rpInvoice.vNTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
                rpInvoice.vGST.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
                rpInvoice.vEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
                rpInvoice.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

                rpInvoice.vAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress + " Ph: " + Program.ss.Machines.PresentationData.CPInfo.cpPhone + " Fax: " + Program.ss.Machines.PresentationData.CPInfo.cpFAX;

                rpInvoice.DataSource = ds_AC_Sales_Sub_T;
                rpInvoice.EndInit();
                rpInvoice.ShowPreview();
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
                    query = "select max(Convert(numeric(18),SubString(iNumber,8,6)))+1 as MaxNumber  from AC_Sales_Main where iYear='" + this.SalesInvoiceFinancialYear.Text + "' and iType='" + this.SalesInvoicePrefix.Text + "' and iCat='" + this.NG.Tag + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.SalesInvoiceSuffix.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.SalesInvoiceSuffix.Text = iNumber;
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
                    Clone.Enabled = false;
                    Add.Enabled = false;
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
        private void SetAutoRemarks()
        {

            string inum = this.SalesInvoicePrefix.Text + this.SalesInvoiceFinancialYear.Text + this.SalesInvoiceSuffix.Text;

            if (AutoRemarks.Checked == true)
                this.Remarks.Text = "Credite Note # " + inum;
            string PackingList = ""; string GatePass = ""; string DebitNoteNumber = ""; string ContractNumber = ""; string InvoiceNumber = "";
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

                    if (AutoRemarks.Checked == true) this.Remarks.Text += " , D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {

                    if (PackingList != AField.PackingListNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " , Packing List # " + AField.PackingListNumber.Text;
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
                            this.Remarks.Text += " , G.P # " + AField.GatePassNumber.Text;
                            GatePass = AField.GatePassNumber.Text;
                        }
                    }
                }

                if (AField.RefInv.Text != "")
                {

                    if (InvoiceNumber != AField.RefInv.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " , Ref Invoice # " + AField.GatePassNumber.Text;
                            InvoiceNumber = AField.RefInv.Text;
                        }
                    }
                }
                if (AField.RefDebiteNoteNumber.Text != "")
                {

                    if (DebitNoteNumber != AField.RefDebiteNoteNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " , Ref Debit Note # " + AField.RefDebiteNoteNumber.Text;
                            DebitNoteNumber = AField.RefDebiteNoteNumber.Text;
                        }
                    }
                }
                if (AField.ContractNumber.Text != "")
                {

                    if (ContractNumber != AField.ContractNumber.Text)
                    {
                        if (AutoRemarks.Checked == true)
                        {
                            this.Remarks.Text += " , Contract # " + AField.ContractNumber.Text;
                            ContractNumber = AField.ContractNumber.Text;
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
            if (this.SalesInvoiceFinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid credit note series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid credit note number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            double WHTAmount = 0;
            double GSTAmount = 0;
            double.TryParse(this.Amount_Tax.Tag.ToString(), out GSTAmount);
            WHTAmount = GSTAmount * Convert.ToDouble(Accounting.RegAccounts.WHTRATE) / 100;
            WHTAmount = Math.Round(WHTAmount, 0);
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
            if (this.Amount_Net.Text != "")
                queries[0] += "," + this.Amount_Net.Tag.ToString() + "";
            else
                queries[0] += ",0";
            queries[0] += ",0,0";
            if (inum != "")
                queries[0] += ",'" + inum + "'";
            else
                queries[0] += ",null";
            queries[0] += ")";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Sales_Main (iNumber,iSalesTypeID,iPaymentTerms,iType,iCat,iYear,iDate,DueDate,iStatus,iRemarks,iGSTRate,iDiscountPercent,iDiscountAmount,iAuthorized,iClosed,AttachedVoucherNumber,BuyerID,BuyerMappedID,ValExTax,ValTax,ValIntax,WHTRate,WHTAmount) Values (";
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
            if (this.Amount_ExTax.Tag.ToString() != "")
                queries[queries.Length - 1] += "," + this.Amount_ExTax.Tag.ToString() + "";
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
            if (this.radioGroup_WHT.EditValue.ToString()=="1")
                queries[queries.Length - 1] += "," + Accounting.RegAccounts.WHTRATE + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.radioGroup_WHT.EditValue.ToString() == "1")
                queries[queries.Length - 1] += "," + WHTAmount.ToString() + "";
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
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,vRefCreditNoteNumber,VDebitAmount,VCreditAmount,isHead) Values (";
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

            queries[queries.Length - 1] += ",0";
            if (this.Amount_Net.Text != "")
                queries[queries.Length - 1] += "," + this.Amount_Net.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",1)";
            if (AutoRemarks.Checked == true)
                SetAutoRemarks();
           
            foreach (Control C in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales AField = (UserControls.Account_SalesInvoice_FabricSales)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,vRefDeliveryChallanNumber,vRefPackingListNumber,vRefGatePassNumber,vRefCreditNoteNumber,vRefContractNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AutoRemarks.Checked == true)
                    SetAutoRemarks();
                string particulars = " Credit Note # " + inum + " Article  " + AField.Item.Text + " returned Quantity " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text + " per " + AField.SellingUnit.EditValue.ToString();
                if (AField.DeliveryChallanNumber.Text != "")
                {
                    particulars += " D.C # " + AField.DeliveryChallanNumber.Text;
                    if (AutoRemarks.Checked == true) this.Remarks.Text += " D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {
                    particulars += " Packing List # " + AField.PackingListNumber.Text;
                   
                }

                if (AField.GatePassNumber.Text != "")
                {
                    particulars += " Gate Pass # " + AField.GatePassNumber.Text;
                   
                }
                if (AField.RefInv.Text != "")
                {
                    particulars += " Ref Inv # " + AField.RefInv.Text;
                   
                }
                if (AField.ContractNumber.Text != "")
                {
                    particulars += " Ref Contract # " + AField.ContractNumber.Text;
                    
                }
                if (AField.RefDebiteNoteNumber.Text != "")
                {
                    particulars += " Ref Debit Note # " + AField.ContractNumber.Text;

                }

                if (particulars != "")
                    queries[queries.Length - 1] += ",'" + particulars + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.RefInv.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.RefInv.Text + "'";
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
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

              
                if (AField.AmountExcludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";

                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Sales_Sub (iNumber,AccountID,Rate,Qty,GSTRate,PackingListNumber,GatePassNumber,DeliveryChallanNumber,ContractNumber,RefDebitNoteNumber,RefCreditNoteNumber,ArticleNumber,ArticleName,Unit,ValExtax,ValTax,ValInTax,RefInvoiceNumber,RefInvoiceDate) values(";
                queries[queries.Length - 1] += "'" + inum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Rate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Rate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Quantity.EditValue != null)
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

                if (AField.RefDebiteNoteNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.RefDebiteNoteNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum!= "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
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
                    queries[queries.Length - 1] += ",'" + AField.AmountExcludingTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountTax.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.AmountTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountIncludingTax.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.AmountIncludingTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.RefInv.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.RefInv.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                DateTime refInvoiceDate = DateTime.Now;
                if (AField.RefInv.Tag != null)
                {
                    DateTime.TryParse(AField.RefInv.Tag.ToString(), out refInvoiceDate);
                }
                try
                {

                }
                catch
                {
                }
                if (AField.RefInv.Tag != null)
                    queries[queries.Length - 1] += ",'" + refInvoiceDate.ToString(Accounting.culture) + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";


















            }
            if (NG.Checked == false)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VrefCreditNoteNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GSTAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.GSTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularstax = " Credit Note # " + inum + " fabric returned from M/S  " + this.BuyersAccountName.Text + " sales tax  adjusted  @ " + this.GSTRate.Text + "%  amount excluding sales tax was " + this.Amount_ExTax.Text;


                if (particularstax != "")
                    queries[queries.Length - 1] += ",'" + particularstax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if ( inum!= "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";

               



                if (this.Amount_Tax.Text != "")
                    queries[queries.Length - 1] += "," + this.Amount_Tax.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";


                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (radioGroup_WHT.EditValue.ToString() == "1")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (Accounting.RegAccounts.WHTACCOUNT != "")
                        queries[queries.Length - 1] += ",'" + Accounting.RegAccounts.WHTACCOUNT + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    string particularsWHT = " Invoice # " + inum + " returned from M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + Accounting.RegAccounts.WHTRATE + "%";


                    if (particularstax != "")
                        queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (inum != "")
                        queries[queries.Length - 1] += ",'" + inum + "'";
                    else
                        queries[queries.Length - 1] += ",null";



                    queries[queries.Length - 1] += ",0";
                    if (WHTAmount != 0)
                        queries[queries.Length - 1] += "," + WHTAmount.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";

                    queries[queries.Length - 1] += ",0)";



                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (this.BuyersAccountID.Text != "")
                        queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    string particularsWHTParty = " Invoice # " + inum + " returned from M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + Accounting.RegAccounts.WHTRATE + "%";


                    if (particularstax != "")
                        queries[queries.Length - 1] += ",'" + particularsWHTParty + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (inum != "")
                        queries[queries.Length - 1] += ",'" + inum + "'";
                    else
                        queries[queries.Length - 1] += ",null";




                    if (WHTAmount != 0)
                        queries[queries.Length - 1] += "," + WHTAmount.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    queries[queries.Length - 1] += ",0";
                    queries[queries.Length - 1] += ",0)";


                }
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
                    this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
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
                    UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
                    vCalc.controls_AmountExTax = Amount_ExTax;
                    vCalc.controls_AmountInTax = Amount_IncTax;
                    vCalc.controls_AmountSalesTax = Amount_Tax;
                    nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
                    this.GSTRate.Text = nAS.GSTRate.Text;
                    nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
                    nAS.eVC = vCalc;
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
        private void Update_InvoiceandVoucher()
        {
            string Number_InvoicetoEdit = "";
            string Number_VouchertoEdit = "";
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
            if (this.vSuffix.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vFinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                vSuffix.Focus();
                return;
            }
            if (this.vFinancialYear.Text != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.vFinancialYear.Tag.ToString() != Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (this.SalesInvoiceFinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoicePrefix.Tag == null)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.SalesInvoiceSuffix.Tag == null)
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
            double WHTAmount = 0;
            double GSTAmount = 0;
            double.TryParse(this.Amount_Tax.Tag.ToString(), out GSTAmount);
            WHTAmount = GSTAmount * Convert.ToDouble(Accounting.RegAccounts.WHTRATE) / 100;
            WHTAmount = Math.Round(WHTAmount, 0);
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
            if (this.Amount_Net.Text != "")
                queries[0] += ",vAmount=" + this.Amount_Net.Tag.ToString() + "";
            else
                queries[0] += ",vAmount=0";

            if (inum != "")
                queries[0] += ",AttachedInvoiceNumber='" + inum + "'";
            else
                queries[0] += ",AttachedInvoiceNumber=null";
            queries[0] += ",EUserID='" +MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(Accounting.culture) + "' where vNumber='" + Number_VouchertoEdit + "'";
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
            if (this.radioGroup_WHT.EditValue.ToString() == "1")
                queries[queries.Length - 1] += ",WHTRATE=" + Accounting.RegAccounts.WHTRATE + "";
            else
                queries[queries.Length - 1] += ",WHTRATE=0";
            if (this.radioGroup_WHT.EditValue.ToString() == "1")
                queries[queries.Length - 1] += ",WHTAmount=" + WHTAmount.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTAmount=0";
            queries[queries.Length - 1] += " where iNumber='" + Number_InvoicetoEdit + "'";


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Voucher_Sub where vNumber='" + Number_VouchertoEdit + "'";
            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "delete from AC_Sales_Sub where iNumber='" + Number_InvoicetoEdit + "'";

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
            queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,vRefCreditNoteNumber,VDebitAmount,VCreditAmount,isHead) Values (";
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

            queries[queries.Length - 1] += ",0";
            if (this.Amount_Net.Text != "")
                queries[queries.Length - 1] += "," + this.Amount_Net.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",1)";
            if (AutoRemarks.Checked == true)
                SetAutoRemarks();

            foreach (Control C in this.tableLayoutPanel_Payment.Controls)
            {
                UserControls.Account_SalesInvoice_FabricSales AField = (UserControls.Account_SalesInvoice_FabricSales)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,vRefDeliveryChallanNumber,vRefPackingListNumber,vRefGatePassNumber,vRefCreditNoteNumber,vRefContractNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AutoRemarks.Checked == true)
                    SetAutoRemarks();
                string particulars = " Credit Note # " + inum + " Article  " + AField.Item.Text + " returned Quantity " + AField.Quantity.Text + " " + AField.SellingUnit.EditValue.ToString() + " @Rs.  " + AField.Rate.Text + " per " + AField.SellingUnit.EditValue.ToString();
                if (AField.DeliveryChallanNumber.Text != "")
                {
                    particulars += " D.C # " + AField.DeliveryChallanNumber.Text;
                    if (AutoRemarks.Checked == true) this.Remarks.Text += " D.C # " + AField.DeliveryChallanNumber.Text;
                }
                if (AField.PackingListNumber.Text != "")
                {
                    particulars += " Packing List # " + AField.PackingListNumber.Text;

                }

                if (AField.GatePassNumber.Text != "")
                {
                    particulars += " Gate Pass # " + AField.GatePassNumber.Text;

                }
                if (AField.RefInv.Text != "")
                {
                    particulars += " Ref Inv # " + AField.RefInv.Text;

                }
                if (AField.ContractNumber.Text != "")
                {
                    particulars += " Ref Contract # " + AField.ContractNumber.Text;

                }
                if (AField.RefDebiteNoteNumber.Text != "")
                {
                    particulars += " Ref Debit Note # " + AField.ContractNumber.Text;

                }

                if (particulars != "")
                    queries[queries.Length - 1] += ",'" + particulars + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.RefInv.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.RefInv.Text + "'";
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
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ContractNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.ContractNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";


                if (AField.AmountExcludingTax.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.AmountExcludingTax.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";

                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into AC_Sales_Sub (iNumber,AccountID,Rate,Qty,GSTRate,PackingListNumber,GatePassNumber,DeliveryChallanNumber,ContractNumber,RefDebitNoteNumber,RefCreditNoteNumber,ArticleNumber,ArticleName,Unit,ValExTax,ValTax,ValInTax,RefInvoiceNumber,RefInvoiceDate) values(";
                queries[queries.Length - 1] += "'" + inum + "'";
                if (AField.AccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.AccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Rate.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Rate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.Quantity.EditValue != null)
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

                if (AField.RefDebiteNoteNumber.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.RefDebiteNoteNumber.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
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
                    queries[queries.Length - 1] += ",'" + AField.AmountExcludingTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountTax.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.AmountTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.AmountIncludingTax.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.AmountIncludingTax.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.RefInv.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.RefInv.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                DateTime refInvoiceDate = DateTime.Now;
                if (AField.RefInv.Tag != null)
                {
                    DateTime.TryParse(AField.RefInv.Tag.ToString(), out refInvoiceDate);
                }
                try
                {

                }
                catch
                {
                }
                if (AField.RefInv.Tag != null)
                    queries[queries.Length - 1] += ",'" + refInvoiceDate.ToString(Accounting.culture) + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";


















            }
            if (NG.Checked == false)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VrefCreditNoteNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GSTAccountID.Text != "")
                    queries[queries.Length - 1] += ",'" + this.GSTAccountID.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                string particularstax = " Credit Note # " + inum + " fabric returned from M/S  " + this.BuyersAccountName.Text + " sales tax  adjusted  @ " + this.GSTRate.Text + "%  amount excluding sales tax was " + this.Amount_ExTax.Text;


                if (particularstax != "")
                    queries[queries.Length - 1] += ",'" + particularstax + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (inum != "")
                    queries[queries.Length - 1] += ",'" + inum + "'";
                else
                    queries[queries.Length - 1] += ",null";





                if (this.Amount_Tax.Text != "")
                    queries[queries.Length - 1] += "," + this.Amount_Tax.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0)";


                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (radioGroup_WHT.EditValue.ToString() == "1")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (Accounting.RegAccounts.WHTACCOUNT != "")
                        queries[queries.Length - 1] += ",'" + Accounting.RegAccounts.WHTACCOUNT + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    string particularsWHT = " Invoice # " + inum + " returned from M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + Accounting.RegAccounts.WHTRATE + "%";


                    if (particularstax != "")
                        queries[queries.Length - 1] += ",'" + particularsWHT + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (inum != "")
                        queries[queries.Length - 1] += ",'" + inum + "'";
                    else
                        queries[queries.Length - 1] += ",null";



                    queries[queries.Length - 1] += ",0";
                    if (WHTAmount != 0)
                        queries[queries.Length - 1] += "," + WHTAmount.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";

                    queries[queries.Length - 1] += ",0)";



                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into AC_Voucher_Sub (VNumber,AccountID_V,VParticulars,VRefInvoiceNumber,VDebitAmount,vCreditAmount,isHead) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (this.BuyersAccountID.Text != "")
                        queries[queries.Length - 1] += ",'" + this.BuyersAccountID.Text + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    string particularsWHTParty = " Invoice # " + inum + " returned from M/S  " + this.BuyersAccountName.Text + " sales tax  deducted  @ " + this.GSTRate.Text + "%  is " + this.Amount_Tax.Tag.ToString() + " tax with held at source deducted @ " + Accounting.RegAccounts.WHTRATE + "%";


                    if (particularstax != "")
                        queries[queries.Length - 1] += ",'" + particularsWHTParty + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (inum != "")
                        queries[queries.Length - 1] += ",'" + inum + "'";
                    else
                        queries[queries.Length - 1] += ",null";




                    if (WHTAmount != 0)
                        queries[queries.Length - 1] += "," + WHTAmount.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    queries[queries.Length - 1] += ",0";
                    queries[queries.Length - 1] += ",0)";

                }

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
                    this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
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
                    UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
                    vCalc.controls_AmountExTax = Amount_ExTax;
                    vCalc.controls_AmountInTax = Amount_IncTax;
                    vCalc.controls_AmountSalesTax = Amount_Tax;
                    nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
                    this.GSTRate.Text = nAS.GSTRate.Text;
                    nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
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
                    Payment.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(Payment.salesTypeID);
                    this.GSTRate.Text = Payment.GSTRate.Text;
                    Payment.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(Payment.salesTypeID);
                    Payment.eVC = vCalc;
                    this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
                    this.tableLayoutPanel_Payment.Controls.Add(Payment);
                    this.View.Tag = "";
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
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString();
            this.PrintVoucher.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
            this.SalesInvoiceSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            this.SalesInvoiceSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(7, 6);
            this.SalesInvoicePrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(0, 3);
            this.SalesInvoicePrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(0, 3);
            this.SalesInvoiceFinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(3, 4);
            this.SalesInvoiceFinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["iNumber"].ToString().Substring(3, 4);
            this.typeOfSales.Tag = ds_VoucherMain.Tables[0].Rows[0]["iSalesTypeID"].ToString();
            SalesType stype = Accounting.Get_SalesType_BySalesTypeID(this.typeOfSales.Tag.ToString());
            if (stype != null)
            {
                this.typeOfSales.Text = stype.salesTypeName;
            }
            else
            {
                this.typeOfSales.Text = "";
                this.typeOfSales.Tag = "";
            }
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
            this.vSuffix.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(7, 6);
            this.vSuffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(7, 6);
            this.vPrefix.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(0, 3);
            this.vPrefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(0, 3);
            this.vFinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(3, 4);
            this.vFinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString().Substring(3, 4);
            string vNumber = "";
            vNumber = ds_VoucherMain.Tables[0].Rows[0]["AttachedVoucherNumber"].ToString();
            this.BuyersAccountID.Text = ds_VoucherMain.Tables[0].Rows[0]["BuyerID"].ToString();
           
            try
            {
                this.SalesDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["iDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                this.DueDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["DueDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
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
                Payment.BuyerID = this.BuyersAccountID.Text;
                Payment.salesTypeID = this.typeOfSales.Tag.ToString();
                this.tableLayoutPanel_Payment.Controls.Add(Payment);
                Payment.AccountID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();
                Payment.AccountID.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["AccountID"].ToString();

                Payment.Rate.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Rate"].ToString();
                Payment.Quantity.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Qty"].ToString();
                Payment.GSTRate.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["GSTRate"].ToString();
                Payment.PackingListNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["PackingListNumber"].ToString();
                Payment.DeliveryChallanNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["DeliveryChallanNumber"].ToString();
                Payment.GatePassNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["GatePassNumber"].ToString();
                Payment.ContractNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["ContractNumber"].ToString();
                Payment.RefDebiteNoteNumber.Text = ds_VoucherSub_T.Tables[0].Rows[x]["RefDebitNoteNumber"].ToString();
                Payment.RefInv.Text = ds_VoucherSub_T.Tables[0].Rows[x]["RefInvoiceNumber"].ToString();
                Payment.ItemID.Text = ds_VoucherSub_T.Tables[0].Rows[x]["ArticleNumber"].ToString();
                Payment.Item.Text = ds_VoucherSub_T.Tables[0].Rows[x]["ArticleName"].ToString();
                Payment.SellingUnit.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Unit"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[x]["RefInvoiceNumber"].ToString() != "")
                    Payment.RefInv.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["RefInvoiceNumber"].ToString();
                else
                    Payment.RefInv.EditValue = null;
                if (ds_VoucherSub_T.Tables[0].Rows[x]["RefInvoiceDate"].ToString() != "")
                    Payment.RefInv.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["RefInvoiceDate"].ToString();
                else
                    Payment.RefInv.Tag = null;
                Payment.Calculations();
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
                        UserControls.AccountGeneral AG = AppendedJournal.AddControl();


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

        private void Browse_BuyersAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.BuyersAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    foreach (Control c in this.tableLayoutPanel_Payment.Controls)
                    {
                        UserControls.Account_SalesInvoice_FabricSales uc = (UserControls.Account_SalesInvoice_FabricSales)c;
                        uc.BuyerID = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    }
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



                        try
                        {
                            
                               
                                foreach (Control c in this.tableLayoutPanel_Payment.Controls)
                                {
                                    UserControls.Account_SalesInvoice_FabricSales uc = (UserControls.Account_SalesInvoice_FabricSales)c;
                                    uc.BuyerID = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                                }
                                this.MappedAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString();
                            
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.BuyersAccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        
                        if (Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString() != "")
                            this.MappedAccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString();
                        else
                            this.MappedAccountID.EditValue = null;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
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
            this.tableLayoutPanel_Payment.Controls.Clear();
            this.BuyersAccountID.Text = "";
            this.Remarks.Text = "";

            this.vSuffix.Text = "";
            this.SalesInvoiceSuffix.Text = "";
            this.SalesDiscountPercent.Text = "0";
            this.SalesDiscountAmount.Text = "0";
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
            UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
            vCalc.controls_AmountExTax = Amount_ExTax;
            vCalc.controls_AmountInTax = Amount_IncTax;
            vCalc.controls_AmountSalesTax = Amount_Tax;
            nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
            this.GSTRate.Text = nAS.GSTRate.Text;
            nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
            nAS.eVC = vCalc;
            this.tableLayoutPanel_Payment.Controls.Add(nAS);

            bool rRes = GetNextVoucherNumber();
            if (rRes != false)
            {
                rRes = GetNextInvoiceNumber();
                if (rRes != false)
                    SetButtonStates(UserInputMode.Add);
            }
            AppendedJournal.tableLayoutPanel_Detail.Controls.Clear();
            AppendedJournal.AddControl();
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
            if (this.vFinancialYear.Tag.ToString() == "" || this.vFinancialYear.Tag.ToString().Length != 4)
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
            if (this.DocumentStatus.Tag.ToString() == "P")
            {
                XtraMessageBox.Show("Invoice has been posted ....can not edit / delete posted voucher", "Error", MessageBoxButtons.OK);
                return;
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

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();



            if (this.typeOfSales.Tag == null)
            {
                XtraMessageBox.Show("Select Type of sales made", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.typeOfSales.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Select Type of sales made", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            strFilterQuery = "SELECT iNumber,iDate,AccountName,ValExTax,ValTax,ValInTax   FROM Accounts_Sales_Main  ";
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

                if (aField.Filter_AccountID.Checked == true || aField.Filter_Item.Checked == true)
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

        private void Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
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

            PrintCreditNote(this.Print.Tag.ToString());
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
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

            Accounting.Print_GeneralVoucher(this.PrintVoucher.Tag.ToString(), "Sales Return Voucher",this.RadioPageSetting.EditValue.ToString());
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";
                vCalc.isNType = true;
                this.radioGroup_WHT.EditValue = "0";
                this.vPrefix.Text = N_Number;
                this.SalesInvoicePrefix.Text = N_Invoice;
                if (uiMode == UserInputMode.Add || uiMode == UserInputMode.Edit)
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

        private void GSTAccountID_TextChanged(object sender, EventArgs e)
        {
            this.GSTAccountName.Text = Accounting.Get_AccountName_ByAccountID_V(this.GSTAccountID.Text);
        }

        private void Amount_IncTax_TextChanged(object sender, EventArgs e)
        {
            CalcNetAmount();
        }

        private void SalesDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            CalcNetAmount();
        }

        private void SalesDiscountAmount_TextChanged(object sender, EventArgs e)
        {
            CalcNetAmount();
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
        
       

        private void Accounts_SalesInvoiceReturn_Load(object sender, EventArgs e)
        {
           
            this.SalesInvoicePrefix.Text = "902";
            this.vPrefix.Text = "802";
            G_Number = "802";
            N_Number = "812";
            G_Invoice = "902";
            N_Invoice = "912";
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
            this.SalesInvoiceFinancialYear.Text = Accounting.RegAccounts.FinancialYear;
            this.vFinancialYear.Text = Accounting.RegAccounts.FinancialYear;
            this.GSTAccountID.Text = Accounting.RegAccounts.GSTACCOUNT;
            
            UserControls.Account_SalesInvoice_FabricSales nAS = new UserControls.Account_SalesInvoice_FabricSales();
            nAS.salesTypeID = this.typeOfSales.Tag.ToString();
            nAS.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(nAS.salesTypeID);
            nAS.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(nAS.salesTypeID);
            this.GSTRate.Text = nAS.GSTRate.Text;
            vCalc.controls_AmountExTax = Amount_ExTax;
            vCalc.controls_AmountInTax = Amount_IncTax;
            vCalc.controls_AmountSalesTax = Amount_Tax;
            this.DueDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            this.SalesDate.DateTime = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " 12:00:00 AM", System.Globalization.CultureInfo.CurrentCulture);
            vCalc.isNType = false;
            nAS.eVC = vCalc;
            this.tableLayoutPanel_Payment.Controls.Add(nAS);
            AppendedJournal.Text = "Sales Return Additional Journal";
        }

        private void typeOfSales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                    this.SalesInvoicePrefix.Text = sRow.SelectedDataRow["G_InvoiceTypeReturn"].ToString();

                    this.vPrefix.Text = sRow.SelectedDataRow["G_VoucherTypeReturn"].ToString();
                    G_Number = sRow.SelectedDataRow["G_VoucherTypeReturn"].ToString();
                    N_Number = sRow.SelectedDataRow["N_VoucherTypeReturn"].ToString();
                    G_Invoice = sRow.SelectedDataRow["G_InvoiceTypeReturn"].ToString();
                    N_Invoice = sRow.SelectedDataRow["N_InvoiceTypeReturn"].ToString();
                    this.NG.Checked = false;
                    foreach (Control c in this.tableLayoutPanel_Payment.Controls)
                    {
                        UserControls.Account_SalesInvoice_FabricSales ao = (UserControls.Account_SalesInvoice_FabricSales)c;
                        ao.salesTypeID = this.typeOfSales.Tag.ToString();
                        ao.AccountID.Text = Accounting.Get_DefaultAccount_BySalesTypeID(ao.salesTypeID);
                        ao.GSTRate.Text = Accounting.Get_GSTRate_BySalesTypeID(ao.salesTypeID);
                        this.GSTRate.Text = ao.GSTRate.Text;
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
           
            this.vSuffix.Text = "";
            this.SalesInvoiceSuffix.Text = "";
            
            this.DocumentState.Image = Accounting.ReturnDocStateImage(Accounting.ReturnDocState("U"));
           

            bool rRes = GetNextVoucherNumber();
            if (rRes != false)
            {
                rRes = GetNextInvoiceNumber();
                if (rRes != false)
                    SetButtonStates(UserInputMode.Add);
            }
           
        }
    }
}