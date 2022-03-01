using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.Windows;
using System.Windows.Forms;
using System.Data;
namespace MachineEyes.Classes
{
    public class PurchaseType
    {
        public string purchaseTypeID;
        public string GSTRate;
        public string WHTDeduction;
    }
    
    public class SalesType
    {
        public string salesTypeID;
        public string salesTypeName;
        public string GSTRate;
        public string DefaultAccountID;
    }
    public class Account
    {
        public string AccountID_V;
        public string AccountName_V;
        public string AccountID_IV;
        public string AccountName_IV;
        public string AccountID_III;
        public string AccountName_III;
        public string AccountID_II;
        public string AccountName_II;
        public string AccountID_I;
        public string AccountName_I;

    }
    public class MappedAccount
    {
        public string MappedAccountID;
        public string MappedAccountName;
    }
    public class FinancialYear
    {
        public int fYear;
        public DateTime StartDate;
        public DateTime EndDate;
        public string YearFormat;
    }
    public class RegisteredAccount
    {
        private string _FinancialYear;
        public DateTime sFinancialPeriod;
        public DateTime eFinancialPeriod;
        public string CompanyAccountID;
        public string Cash_IV;
        public string Bank_IV;
        public string GSTRATE;
        public string GSTACCOUNT;
        public string WHTRATE;
        public string EXTRATAXRATE;
        public string EXTRATAXACCOUNT;

        public string WHTACCOUNT;
        public string ITAXRATE;
        public string FinancialYear
        {
            get
            {
                return _FinancialYear;
            }
            set
            {
               _FinancialYear = value;
               string sFinPeriod = "01-July-" + value;
               string eFinPeriod = "30-June-" + Convert.ToString(Convert.ToInt32(value) + 1) + " 11:59:59 PM";
               sFinancialPeriod = Convert.ToDateTime(sFinPeriod,System.Globalization.CultureInfo.CurrentCulture);
               eFinancialPeriod = Convert.ToDateTime(eFinPeriod, System.Globalization.CultureInfo.CurrentCulture);
            }
        }
    }
    public class easyVoucherCalculations
    {
        public Control controls_MultiTotal;
        public Control controls_Difference;
        public Control controls_SingleTotal;
        public Control controls_AmountExTax;
        public Control controls_AmountInTax;
        public Control controls_AmountSalesTax;
        public bool isNType = false;
        private int _multiTotal;
        private int _singleTotal;
        private int _difference;
        private int _salestax;
        private int _amountExTax;
        private int _moreCreditTotal;

        public int difference
        {
                 get
            {
                return _difference;
            }
           
        }
        public int  multiTotal
        {
            get
            {
                return _multiTotal;
            }
            set
            {
               _multiTotal = value;
               _difference =( _singleTotal+_moreCreditTotal) - _multiTotal;
                if (controls_MultiTotal != null)
                {
                    controls_MultiTotal.Text = _multiTotal.ToString();
                    if (controls_SingleTotal != null && controls_Difference != null)
                    {
                        controls_Difference.Tag = _difference.ToString();
                        controls_Difference.Text = _difference.ToString();

                    }
                }
            }
        }
        public int moreCreditTotal
        {
            set
            {
                _moreCreditTotal = value;
                controls_SingleTotal.Text = (_singleTotal + _moreCreditTotal).ToString();
                controls_SingleTotal.Tag = (_singleTotal + _moreCreditTotal).ToString();
            }
        }
        public int singleTotal
        {
            get
            {
                return _singleTotal;
            }
            set
            {
                _singleTotal = value;
                controls_SingleTotal.Text = (_singleTotal + _moreCreditTotal).ToString();
                controls_SingleTotal.Tag = (_singleTotal + _moreCreditTotal).ToString();
                if (controls_MultiTotal != null)
                {
                    controls_MultiTotal.Text = _multiTotal.ToString();
                    _difference = (_singleTotal+_moreCreditTotal) - _multiTotal;
                    if (controls_SingleTotal != null && controls_Difference != null)
                    {
                        controls_Difference.Tag = _difference.ToString();
                        controls_Difference.Text = _difference.ToString();

                    }
                }
            }
        }

        public int salestax
        {
            get
            {
                return _salestax;
            }
            set
            {
                _salestax = value;
                if (controls_AmountSalesTax != null)
                {
                    controls_AmountSalesTax.Tag = _salestax.ToString();
                    controls_AmountSalesTax.Text = _salestax.ToString();
                }
               
            }
        }
        public int amountExTax
        {
            get
            {
                return _amountExTax;
            }
            set
            {
                _amountExTax = value;
                if (controls_AmountExTax != null)
                {
                    controls_AmountExTax.Tag = _amountExTax.ToString();
                    controls_AmountExTax.Text = _amountExTax.ToString();

                }
                if (controls_AmountInTax != null)
                {
                    int aTotal = _salestax + _amountExTax;
                    controls_AmountInTax.Tag = aTotal.ToString();
                    controls_AmountInTax.Text = aTotal.ToString();
                }

            }
        }
    }
    public class easyPurchasesCalculations
    {
        public Control controls_PurchaseItemsAmountTotal;
        public Control controls_Difference;
        public Control controls_SellerAccountAmountTotal;
        public Control controls_AmountExTax;
        public Control controls_AmountInTax;
        public Control controls_AmountSalesTax;
        public bool isNType = false;
        private int _purchaseitemsamounttotal;
        private int _selleraccountamounttotal;
        private int _difference;
        private int _salestax;
        private int _amountExTax;


        public int difference
        {
            get
            {
                return _difference;
            }

        }
        public int purchaseitemsamounttotal
        {
            get
            {
                return _purchaseitemsamounttotal;
            }
            set
            {
                _purchaseitemsamounttotal = value;
                _difference = _selleraccountamounttotal - _purchaseitemsamounttotal;
                if (controls_PurchaseItemsAmountTotal != null)
                {
                    controls_PurchaseItemsAmountTotal.Text = _purchaseitemsamounttotal.ToString("#,##");
                    if (controls_SellerAccountAmountTotal != null && controls_Difference != null)
                    {
                        controls_Difference.Tag = _difference.ToString();
                        controls_Difference.Text = _difference.ToString("#,##");

                    }
                }
            }
        }
        public int selleraccountamounttotal
        {
            get
            {
                return _selleraccountamounttotal;
            }
            set
            {
                _selleraccountamounttotal = value;
                if (controls_PurchaseItemsAmountTotal != null)
                {
                    controls_PurchaseItemsAmountTotal.Text = _purchaseitemsamounttotal.ToString("#,##");
                    _difference = _selleraccountamounttotal - _purchaseitemsamounttotal;
                    if (controls_SellerAccountAmountTotal != null && controls_Difference != null)
                    {
                        controls_Difference.Tag = _difference.ToString();
                        controls_Difference.Text = _difference.ToString("#,##");

                    }
                }
            }
        }
        public int salestax
        {
            get
            {
                return _salestax;
            }
            set
            {
                _salestax = value;
                if (controls_AmountSalesTax != null)
                {
                    controls_AmountSalesTax.Tag = _salestax.ToString();
                    controls_AmountSalesTax.Text = _salestax.ToString("#,##");
                }

            }
        }
        public int amountExTax
        {
            get
            {
                return _amountExTax;
            }
            set
            {
                _amountExTax = value;
                if (controls_AmountExTax != null)
                {
                    controls_AmountExTax.Tag = _amountExTax.ToString();
                    controls_AmountExTax.Text = _amountExTax.ToString("#,##");

                }
                if (controls_AmountInTax != null)
                {
                    int aTotal = _salestax + _amountExTax;
                    controls_AmountInTax.Tag = aTotal.ToString();
                    controls_AmountInTax.Text = aTotal.ToString("#,##");
                }

            }
        }
    }
    public static class Accounting    
    {
        public static System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
        public static Account[] Accounts = new Account[0];
        public static MappedAccount[] MappedAccounts = new MappedAccount[0];
        public static string[] Years = new string[0];
        public static PurchaseType[] PurchaseTypes = new PurchaseType[0];
        public static SalesType[] SalesTypes = new SalesType[0];
        
        public static FinancialYear[] FinancialYears = new FinancialYear[0];
        public static RegisteredAccount RegAccounts = new RegisteredAccount();
        public static Account Get_Account_ByAccountID_V(string AccountID)
        {
            for (int x = 0; x < Accounts.Length; x++)
            {
                if (AccountID == Accounts[x].AccountID_V)
                    return Accounts[x];
            }
            return null; 
        }
        
        public static string Get_AccountName_ByAccountID_V(string AccountID)
        {
            for (int x = 0; x < Accounts.Length; x++)
            {
                if (AccountID == Accounts[x].AccountID_V)
                    return Accounts[x].AccountName_V;
            }
            return "";
        }
        public static string Get_GSTRate_ByPurchaseTypeID(string purchaseTypeID)
        {
            for (int x = 0; x < PurchaseTypes.Length; x++)
            {
                if (purchaseTypeID == PurchaseTypes[x].purchaseTypeID)
                    return PurchaseTypes[x].GSTRate;
            }
            return "";
        }
        public static string Get_WHTDeduction_ByPurchaseTypeID(string purchaseTypeID)
        {
            for (int x = 0; x < PurchaseTypes.Length; x++)
            {
                if (purchaseTypeID == PurchaseTypes[x].purchaseTypeID)
                    return PurchaseTypes[x].WHTDeduction;
            }
            return "";
        }
        public static string Get_GSTRate_BySalesTypeID(string salesTypeID)
        {
            for (int x = 0; x < SalesTypes.Length; x++)
            {
                if (salesTypeID == SalesTypes[x].salesTypeID)
                    return SalesTypes[x].GSTRate;
            }
            return "";
        }
        public static SalesType Get_SalesType_BySalesTypeID(string salesTypeID)
        {
            for (int x = 0; x < SalesTypes.Length; x++)
            {
                if (salesTypeID == SalesTypes[x].salesTypeID)
                    return SalesTypes[x];
            }
            return null;
        }
        public static string Get_DefaultAccount_BySalesTypeID(string salesTypeID)
        {
            for (int x = 0; x < SalesTypes.Length; x++)
            {
                if (salesTypeID == SalesTypes[x].salesTypeID)
                    return SalesTypes[x].DefaultAccountID;
            }
            return "";
        }
        public static int  Get_AccountIndex_ByAccountID_V(string AccountID)
        {
            for (int x = 0; x < Accounts.Length; x++)
            {
                if (AccountID == Accounts[x].AccountID_V)
                    return x;
            }
            return -1;
        }
        public static void Load_Accounts()
        {
            try
            {
                culture.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy";
                DataSet ds = WS.svc.Get_DataSet("Select * from Accounts_ChartofAccounts");
                if (ds == null) return;
                Array.Resize(ref Accounts, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    Accounts[x] = new Account();
                    Accounts[x].AccountID_I = ds.Tables[0].Rows[x]["AccountID_I"].ToString();
                    Accounts[x].AccountID_II = ds.Tables[0].Rows[x]["AccountID_II"].ToString();
                    Accounts[x].AccountID_III = ds.Tables[0].Rows[x]["AccountID_III"].ToString();
                    Accounts[x].AccountID_IV = ds.Tables[0].Rows[x]["AccountID_IV"].ToString();
                    Accounts[x].AccountID_V = ds.Tables[0].Rows[x]["AccountID_V"].ToString();
                    Accounts[x].AccountName_I = ds.Tables[0].Rows[x]["AccountName_I"].ToString();
                    Accounts[x].AccountName_II = ds.Tables[0].Rows[x]["AccountName_II"].ToString();
                    Accounts[x].AccountName_III = ds.Tables[0].Rows[x]["AccountName_III"].ToString();
                    Accounts[x].AccountName_IV = ds.Tables[0].Rows[x]["AccountName_IV"].ToString();
                    Accounts[x].AccountName_V = ds.Tables[0].Rows[x]["AccountName_V"].ToString();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void Load_MappedAccounts()
        {
            try
            {
               
                DataSet ds = WS.svc.Get_DataSet("Select * from PP_Accounts");
                if (ds == null) return;
                Array.Resize(ref MappedAccounts, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    MappedAccounts[x] = new MappedAccount();
                    MappedAccounts[x].MappedAccountID = ds.Tables[0].Rows[x]["AccountID"].ToString();
                    MappedAccounts[x].MappedAccountName = ds.Tables[0].Rows[x]["AccountName"].ToString();
                   
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static string Get_MappedAccount(string MappedAccountID)
        {
            for (int x = 0; x < MappedAccounts.Length; x++)
            {
                if (MappedAccounts[x].MappedAccountID == MappedAccountID)
                    return MappedAccounts[x].MappedAccountName;
            }
            return "";
        }
        public static void Load_PurchaseTypes()
        {
            try
            {
                
                DataSet ds = WS.svc.Get_DataSet("Select * from AC_PurchasesTypes");
                if (ds == null) return;
                Array.Resize(ref PurchaseTypes, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    PurchaseTypes[x] = new PurchaseType();
                    PurchaseTypes[x].purchaseTypeID = ds.Tables[0].Rows[x]["purchaseTypeID"].ToString();
                    PurchaseTypes[x].GSTRate = ds.Tables[0].Rows[x]["GSTRate"].ToString();
                    PurchaseTypes[x].WHTDeduction = ds.Tables[0].Rows[x]["WHTDeduction"].ToString();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_PurchaseTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void Load_SalesTypes()
        {
            try
            {

                DataSet ds = WS.svc.Get_DataSet("Select * from AC_SalesTypes");
                if (ds == null) return;
                Array.Resize(ref SalesTypes, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    SalesTypes[x] = new SalesType();
                    SalesTypes[x].salesTypeID = ds.Tables[0].Rows[x]["SalesTypeID"].ToString();
                    SalesTypes[x].salesTypeName = ds.Tables[0].Rows[x]["SalesTypeName"].ToString();
                    SalesTypes[x].GSTRate = ds.Tables[0].Rows[x]["GSTRate"].ToString();
                    SalesTypes[x].DefaultAccountID = ds.Tables[0].Rows[x]["DefaultAccountID"].ToString();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_SalesTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void Load_FinancialYears()
        {
            try
            {

                DataSet ds = WS.svc.Get_DataSet("Select * from AC_FinancialYears");
                if (ds == null) return;
                Array.Resize(ref FinancialYears, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    FinancialYears[x] = new FinancialYear();
                    FinancialYears[x].fYear = Convert.ToInt32(ds.Tables[0].Rows[x]["FinancialYear"].ToString());

                    string sFinPeriod = "01-July-" + FinancialYears[x].fYear.ToString();
                    string eFinPeriod = "30-June-" + Convert.ToString(FinancialYears[x].fYear + 1) + " 11:59:59 PM";
                    FinancialYears[x].StartDate = Convert.ToDateTime(sFinPeriod, System.Globalization.CultureInfo.CurrentCulture);
                    FinancialYears[x].EndDate = Convert.ToDateTime(eFinPeriod, System.Globalization.CultureInfo.CurrentCulture);
                    FinancialYears[x].YearFormat = ds.Tables[0].Rows[x]["YearFormat"].ToString();
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_SalesTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static string Return_FinancialYear(DateTime Date)
        {
            for (int x = 0; x < FinancialYears.Length; x++)
            {
                if (Date >= FinancialYears[x].StartDate && Date <= FinancialYears[x].EndDate)
                {
                    return FinancialYears[x].fYear.ToString();
                }
            }
            return "";
        }
        public static int Return_FinancialYear(string  fYear)
        {
            for (int x = 0; x < FinancialYears.Length; x++)
            {
                if (fYear == FinancialYears[x].fYear.ToString())
                    return x;
            }
            return -1;
        }
        public static void Load_RegisteredAccounts()
        {
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select * from AC_GetSet");
                if (ds == null) return;
               
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    switch (ds.Tables[0].Rows[x]["GetValue"].ToString())
                    {
                        case "CPACCOUNTID":
                            RegAccounts.CompanyAccountID = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "CASH_IV":
                            RegAccounts.Cash_IV = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "BANK_IV":
                            RegAccounts.Bank_IV = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "GSTRATE":
                            RegAccounts.GSTRATE = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "GSTACCOUNT":
                            RegAccounts.GSTACCOUNT = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "WHTRATE":
                            RegAccounts.WHTRATE = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "EXTRATAXRATE":
                            RegAccounts.EXTRATAXRATE = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "EXTRATAXACCOUNT":
                            RegAccounts.EXTRATAXACCOUNT = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "ITAXRATE":
                            RegAccounts.ITAXRATE = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "WHTACCOUNT":
                            RegAccounts.WHTACCOUNT = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                     
                        case "DEPTWEAVING":
                            Departments.Weaving = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "TOWEL_GODOWN":
                            Departments.Towel_Godown = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "TOWEL_FOLDING":
                            Departments.Towel_Folding = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "DEPTSIZING":
                            Departments.Sizing = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "INOUTDEPTID_SIZING":
                            Departments.InOutDeptID_Sizing = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "INOUTDEPTID_WEAVING":
                            Departments.InOutDeptID_Weaving = ds.Tables[0].Rows[x]["SetValue"].ToString();

                            break;
                        case "WEAVERS_DESIGNATIONID":
                            Settings.WeaversDesignationID = ds.Tables[0].Rows[x]["SetValue"].ToString();
                            break;
                        case "INVSTARTINDEX":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() != "")
                                Settings.InvoiceStartIndex = Convert.ToInt32(ds.Tables[0].Rows[x]["SetValue"].ToString());
                            break;
                        case "INVLENGTH":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() != "")
                                Settings.InvoiceLength = Convert.ToInt32(ds.Tables[0].Rows[x]["SetValue"].ToString());
                            break;
                        case "BOUNDSALESWITHPO":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() == "1")
                                Settings.BoundInvoiceWithPO = true;
                            else
                                Settings.BoundInvoiceWithPO = false;
                            break;
                        case "FILLYARNINFOFROMPO":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() == "1")
                                Settings.FillYarnInfoFromPO = true;
                            else
                                Settings.FillYarnInfoFromPO = false;
                            break;
                        case "BOUNDSTOREISSUENOTE":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() == "1")
                                Settings.Store_BoundIssueNoteWithApproval = true;
                            else
                                Settings.Store_BoundIssueNoteWithApproval = false;
                            break;
                        case "BOUNDSTOREPURCHASEORDER":
                            if (ds.Tables[0].Rows[x]["SetValue"].ToString() == "1")
                                Settings.Store_BoundPurcahseOrderWithApproval = true;
                            else
                                Settings.Store_BoundPurcahseOrderWithApproval = false;
                            break;
                        default :
                            break;
                    }
                   
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_Accounts", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static void Print_BankReceiptVoucher(string VoucherNumber,string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from VAC_Voucher_Main where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_H = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=1");
            if (ds_AC_Voucher_Sub_H == null) return;
            if (ds_AC_Voucher_Sub_H.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" +VoucherNumber + "' and isHead=0");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;
           

            Reports.Accounts_BankReceiptVoucher rpVoucher = new Reports.Accounts_BankReceiptVoucher();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VStatus"].ToString();
            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vVoucherNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vHeaderAccountID.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountID_V"].ToString();
            rpVoucher.vHeaderAccountName.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountName_V"].ToString();
            rpVoucher.vHeaderRemarks.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["vParticulars"].ToString();
            rpVoucher.vUser.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EmployeeName"].ToString();
            rpVoucher.vUserInputDateTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["cUserTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy hh:mm tt");

           
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
                
                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
                
            }
            else
            {
               
                rpVoucher.vCompany.Text = "";
                
                
            }
            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }
            
           
            rpVoucher.DataSource = ds_AC_Voucher_Sub_T;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_CashPaymentVoucher(string VoucherNumber,string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from VAC_Voucher_Main where VNumber='" +VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_H = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=1");
            if (ds_AC_Voucher_Sub_H == null) return;
            if (ds_AC_Voucher_Sub_H.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=0");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;
          

            Reports.Accounts_CashPaymentVoucher pCashPaymentVoucher = new Reports.Accounts_CashPaymentVoucher();
            pCashPaymentVoucher.BeginInit();
            if (PageSize == "H")
            {
                pCashPaymentVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                pCashPaymentVoucher.PageHeight = pCashPaymentVoucher.PageHeight / 2;
            }
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                pCashPaymentVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                pCashPaymentVoucher.vCompany.Text = "";


            }
            pCashPaymentVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            pCashPaymentVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            pCashPaymentVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VStatus"].ToString();
            pCashPaymentVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            pCashPaymentVoucher.vVoucherNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            pCashPaymentVoucher.vHeaderAccountID.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountID_V"].ToString();
            pCashPaymentVoucher.vHeaderAccountName.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountName_V"].ToString();
            pCashPaymentVoucher.vHeaderRemarks.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["vParticulars"].ToString();
            pCashPaymentVoucher.vUser.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EmployeeName"].ToString();
            pCashPaymentVoucher.vUserInputDateTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["cUserTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy hh:mm tt");

            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
                
                pCashPaymentVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
              
            }
            else
            {
               
                pCashPaymentVoucher.vCompany.Text = "";
               
                pCashPaymentVoucher.vCompany.Visible = false;
               
            }
            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                pCashPaymentVoucher.xr_AmountInWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }
            
           
            pCashPaymentVoucher.DataSource = ds_AC_Voucher_Sub_T;

            pCashPaymentVoucher.EndInit();
            pCashPaymentVoucher.ShowPreview();
        }
        public static void Print_CashReceiptVoucher(string VoucherNumber,string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from VAC_Voucher_Main where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_H = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=1");
            if (ds_AC_Voucher_Sub_H == null) return;
            if (ds_AC_Voucher_Sub_H.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=0");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;
           

            Reports.Accounts_CashReceiptVoucher rpVoucher = new Reports.Accounts_CashReceiptVoucher();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                rpVoucher.vCompany.Text = "";


            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VStatus"].ToString();
            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vVoucherNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vHeaderAccountID.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountID_V"].ToString();
            rpVoucher.vHeaderAccountName.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountName_V"].ToString();
            rpVoucher.vHeaderRemarks.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["vParticulars"].ToString();
            rpVoucher.vUser.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EmployeeName"].ToString();
            rpVoucher.vUserInputDateTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["cUserTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy hh:mm tt");

            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
               
                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
               
            }
            else
            {
               
                rpVoucher.vCompany.Text = "";
               
                rpVoucher.vCompany.Visible = false;
              
            }
            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }
            
           
            rpVoucher.DataSource = ds_AC_Voucher_Sub_T;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_GeneralVoucher(string VoucherNumber,string VoucherType,string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from VAC_Voucher_Main where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;
           

            Reports.Accounts_GeneralVoucher rpVoucher = new Reports.Accounts_GeneralVoucher();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                rpVoucher.vCompany.Text = "";


            }
            rpVoucher.repH_VoucherType.Text = VoucherType;
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            rpVoucher.vUser.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["EmployeeName"].ToString();
            rpVoucher.vUserInputDateTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["cUserTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy hh:mm tt");

            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vVoucherNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
          
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
               
                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
               
            }
            else
            {
               
                rpVoucher.vCompany.Text = "";
                
                rpVoucher.vCompany.Visible = false;
                
            }
          
            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }
            
          
            rpVoucher.DataSource = ds_AC_Voucher_Sub_T;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_VoucherMDC(string VoucherNumber, string VoucherType, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from AC_Voucher_Main where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;

            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;


            Reports.Accounts_Voucher_MDC rpVoucher = new Reports.Accounts_Voucher_MDC();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                rpVoucher.vCompany.Text = "";


            }
            rpVoucher.VoucherType.Text = VoucherType;
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy");

            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
           
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                rpVoucher.vCompany.Text = "";

                rpVoucher.vCompany.Visible = false;

            }

            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }
            rpVoucher.DataSource = ds_AC_Voucher_Sub_T;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_BankPaymentVoucher(string VoucherNumber,string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from VAC_Voucher_Main where VNumber='" +VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_H = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=1");
            if (ds_AC_Voucher_Sub_H == null) return;
            if (ds_AC_Voucher_Sub_H.Tables[0].Rows.Count <= 0)
                return;
            DataSet ds_AC_Voucher_Sub_T = WS.svc.Get_DataSet("select * from Accounts_Vouchers where VNumber='" + VoucherNumber + "' and isHead=0");
            if (ds_AC_Voucher_Sub_T == null) return;
            if (ds_AC_Voucher_Sub_T.Tables[0].Rows.Count <= 0)
                return;
           

            Reports.Accounts_BankPaymentVoucher rpVoucher = new Reports.Accounts_BankPaymentVoucher();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {

                rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            }
            else
            {

                rpVoucher.vCompany.Text = "";


            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDate.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VStatus"].ToString();
            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vUser.Text  =  ds_AC_Voucher_Main.Tables[0].Rows[0]["EmployeeName"].ToString();
            rpVoucher.vUserInputDateTime.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["cUserTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToString("dd-MMM-yyyy hh:mm tt");
            rpVoucher.vHeaderAccountID.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountID_V"].ToString();
            rpVoucher.vHeaderAccountName.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["AccountName_V"].ToString();
            rpVoucher.vHeaderRemarks.Text = ds_AC_Voucher_Sub_H.Tables[0].Rows[0]["vParticulars"].ToString();
            
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
                //rpVoucher.vNTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
                //rpVoucher.vGST.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
                //rpVoucher.vEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
                //rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
                //rpVoucher.vAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress + " Ph: " + Program.ss.Machines.PresentationData.CPInfo.cpPhone + " Fax: " + Program.ss.Machines.PresentationData.CPInfo.cpFAX;
            }
            else
            {
                //rpVoucher.vNTN.Text = "";
                //rpVoucher.vGST.Text = "";
                //rpVoucher.vEmail.Text = "";
                //rpVoucher.vCompany.Text = "";
                //rpVoucher.vAddress.Text = "";
                //rpVoucher.vNTN.Visible = false;
                //rpVoucher.vGST.Visible = false;
                //rpVoucher.vEmail.Visible = false;
                //rpVoucher.vCompany.Visible = false;
                //rpVoucher.vAddress.Visible = false;
                //rpVoucher.VNTN_LABEL.Visible = false;
                //rpVoucher.VGST_LABEL.Visible = false;
                //rpVoucher.VEMAIL_LABEL.Visible = false;
            }

            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.xr_TotalAmountWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
            }
            catch
            {
            }

           
            rpVoucher.DataSource = ds_AC_Voucher_Sub_T;
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static void Print_DetectVoucherType(string VoucherNumber)
        {
            if (VoucherNumber.Substring(0, 3) == "501" || VoucherNumber.Substring(0, 3) == "511")
                Print_CashPaymentVoucher(VoucherNumber, "");
            else if (VoucherNumber.Substring(0, 3) == "502" || VoucherNumber.Substring(0, 3) == "512")
                Print_BankPaymentVoucher(VoucherNumber, "");
            else if (VoucherNumber.Substring(0, 3) == "503" || VoucherNumber.Substring(0, 3) == "513")
                Print_CashReceiptVoucher(VoucherNumber, "");
            else if (VoucherNumber.Substring(0, 3) == "504" || VoucherNumber.Substring(0, 3) == "514")
                Print_BankReceiptVoucher(VoucherNumber, "");
            else if (VoucherNumber.Substring(0, 3) == "505" || VoucherNumber.Substring(0, 3) == "515")
                Print_GeneralVoucher(VoucherNumber,"General Voucher", "");
            else if (VoucherNumber.Substring(0, 3) == "601" || VoucherNumber.Substring(0, 3) == "611")
                Print_GeneralVoucher(VoucherNumber, "Purchase Voucher", "");
            else if (VoucherNumber.Substring(0, 3) == "602" || VoucherNumber.Substring(0, 3) == "612")
                Print_GeneralVoucher(VoucherNumber, "Purchase Return Voucher", "");
            else if (VoucherNumber.Substring(0, 3) == "801" || VoucherNumber.Substring(0, 3) == "811")
                Print_GeneralVoucher(VoucherNumber, "Sales Voucher", "");
            else if (VoucherNumber.Substring(0, 3) == "802" || VoucherNumber.Substring(0, 3) == "812")
                Print_GeneralVoucher(VoucherNumber, "Sales Return Voucher", "");

        }
        public static void Print_PaymentAdvice(string VoucherNumber, string PageSize)
        {
            DataSet ds_AC_Voucher_Main = WS.svc.Get_DataSet("select * from QAC_PaymentAdvice where VNumber='" + VoucherNumber + "'");
            if (ds_AC_Voucher_Main == null) return;
            if (ds_AC_Voucher_Main.Tables[0].Rows.Count <= 0)
                return;
            
           

            Reports.Accounts_PaymentAdvice rpVoucher = new Reports.Accounts_PaymentAdvice();
            rpVoucher.BeginInit();
            if (PageSize == "H")
            {
                rpVoucher.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                rpVoucher.PageHeight = rpVoucher.PageHeight / 2;
            }
            rpVoucher.vBarcode.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.vDated.Text = Convert.ToDateTime(ds_AC_Voucher_Main.Tables[0].Rows[0]["VDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture).ToLongDateString();
            rpVoucher.vStatus.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VStatus"].ToString();
            rpVoucher.vDocumentNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            // rpVoucher.vVoucherNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VNumber"].ToString();
            rpVoucher.AccountID_V.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountID_V"].ToString();
            rpVoucher.AccountName_V.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["AccountName_V"].ToString();
            rpVoucher.Particulars.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["vParticulars"].ToString();
           
            rpVoucher.RefDebitNoteNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VRefDebitNoteNumber"].ToString();
            rpVoucher.RefInvoiceNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VRefInvoiceNumber"].ToString();
            rpVoucher.RefDCNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VRefDeliveryChallanNumber"].ToString();
            rpVoucher.RefPurchaseContractNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["PurchaseContractNumber"].ToString();
            rpVoucher.RefCreditNoteNumber.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["VRefCreditNoteNumber"].ToString();
            rpVoucher.Item.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["item"].ToString();
            rpVoucher.Unit.Text = ds_AC_Voucher_Main.Tables[0].Rows[0]["itemunit"].ToString();
            double itemrate, itemqty, itemamount, gstamount, whtamount, itaxamount;
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["itemrate"].ToString(), out itemrate);
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["itemqty"].ToString(), out itemqty);
            if (itemrate <= 0)
            {
                rpVoucher.Rate.Visible = false;
                rpVoucher.Unit.Visible = false;
                rpVoucher.Quantity.Visible = false;
                rpVoucher.AttheRateLabel.Visible = false;
                rpVoucher.QtyLabel.Visible = false;
            }
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["itemamount"].ToString(), out itemamount);
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["gst_amount"].ToString(), out gstamount);
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["wht_amount"].ToString(), out whtamount);
            double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["itax_amount"].ToString(), out itaxamount);

            rpVoucher.Rate.Text = itemrate.ToString("#,##0.00");
            rpVoucher.Rate.Tag = itemrate.ToString();
            rpVoucher.Quantity.Text = itemqty.ToString("#,##0.00");
            rpVoucher.QtyRateAmount.Text = itemamount.ToString("#,##");
            rpVoucher.GSTLabel.Text = "Add: GST @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["gst_rate"].ToString() + "%";
            rpVoucher.GSTAmount.Text = gstamount.ToString("#,##");
             rpVoucher.WHTLabel.Text = "Less: WHT @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["wht_rate"].ToString() + "%";
             rpVoucher.WHTAmount.Text = whtamount.ToString("#,##");
            rpVoucher.IncomeTaxLabel.Text = "Income tax @ " + ds_AC_Voucher_Main.Tables[0].Rows[0]["itax_Rate"].ToString() + "%";
            rpVoucher.AmountafterGST.Text = (gstamount + itemamount).ToString("#,##;(#,##)");
            rpVoucher.IncomeTaxAmount.Text = itaxamount.ToString("#,##");
            if (ds_AC_Voucher_Main.Tables[0].Rows[0]["VCAT"].ToString() == "G")
            {
                //rpVoucher.vNTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
                //rpVoucher.vGST.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
                //rpVoucher.vEmail.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
                //rpVoucher.vCompany.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
                //rpVoucher.vAddress.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress + " Ph: " + Program.ss.Machines.PresentationData.CPInfo.cpPhone + " Fax: " + Program.ss.Machines.PresentationData.CPInfo.cpFAX;
            }
            else
            {
                //rpVoucher.vNTN.Text = "";
                //rpVoucher.vGST.Text = "";
                //rpVoucher.vEmail.Text = "";
                //rpVoucher.vCompany.Text = "";
                //rpVoucher.vAddress.Text = "";
                //rpVoucher.vNTN.Visible = false;
                //rpVoucher.vGST.Visible = false;
                //rpVoucher.vEmail.Visible = false;
                //rpVoucher.vCompany.Visible = false;
                //rpVoucher.vAddress.Visible = false;
                //rpVoucher.VNTN_LABEL.Visible = false;
                //rpVoucher.VGST_LABEL.Visible = false;
                //rpVoucher.VEMAIL_LABEL.Visible = false;
            }

            try
            {
                double TotalAmount = 0;
                double.TryParse(ds_AC_Voucher_Main.Tables[0].Rows[0]["VAmount"].ToString(), out TotalAmount);
                rpVoucher.AmountinWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(TotalAmount);
                rpVoucher.Amount.Text = TotalAmount.ToString("#,##;(#,##)");
            }
            catch
            {
            }

           
            rpVoucher.EndInit();
            rpVoucher.ShowPreview();
        }
        public static string ReturnAmountInWords(double dblValue)
        {
           
                string[] ones=new string[0];
                string[] teens=new string[0];
                string[] tens=new string[0];
                string[] thousands=new string[0];
             Array.Resize(ref ones,10);
             Array.Resize(ref teens,10);
             Array.Resize(ref tens,10);
             Array.Resize(ref thousands,5);
            

    ones[0] = "Zero";
    ones[1] = "One";
    ones[2] = "Two";
    ones[3] = "Three";
    ones[4] = "Four";
    ones[5] = "Five";
    ones[6] = "Six";
    ones[7] = "Seven";
    ones[8] = "Eight";
    ones[9] = "Nine";

    teens[0] = "Ten";
    teens[1] = "Eleven";
    teens[2] = "Twelve";
    teens[3] = "Thirteen";
    teens[4] = "Fourteen";
    teens[5] = "Fifteen";
    teens[6] = "Sixteen";
    teens[7] = "Seventeen";
    teens[8] = "Eighteen";
    teens[9] = "Nineteen";

    tens[0] = "";
    tens[1] = "Ten";
    tens[2] = "Twenty";
    tens[3] = "Thirty";
    tens[4] = "Forty";
    tens[5] = "Fifty";
    tens[6] = "Sixty";
    tens[7] = "Seventy";
    tens[8] = "Eighty";
    tens[9] = "Ninty";

    thousands[0] = "";
    thousands[1] = "Thousand";
    thousands[2] = "Million";
    thousands[3] = "Billion";
    thousands[4] = "Trillion";

    try
    {

        int nPosition = 0;
        int nDigit = 0; bool bAllZeros = false;
        string strResult = "", strTemp = "";
        string tmpBuff = "";
        strTemp = Math.Round(dblValue).ToString();
        for (int i = strTemp.Length; i >= 1; i--)
        {





            nDigit = Convert.ToInt16(strTemp.Substring(i-1, 1));
            //'Get column position
            nPosition = (strTemp.Length - i) + 1;
            int Mod = nPosition % 3;
            switch (Mod)
            {
                case 1:

                    //Select Case (nPosition Mod 3)
                    //Case 1://  '1's position
                    //     break;

                    bAllZeros = false;
                    if (i == 1)
                        tmpBuff = ones[nDigit] + " ";
                    else if (strTemp.Substring(i - 2, 1) == "1")
                    {
                        tmpBuff = teens[nDigit] + " ";
                        i = i - 1;   //Skip tens position
                    }
                    else if (nDigit > 0)
                        tmpBuff = ones[nDigit] + " ";
                    else
                    {

                        bAllZeros = true;
                        if (i > 1)
                            if (strTemp.Substring(i - 2, 1) != "0")
                                bAllZeros = false;


                        if (i > 2)
                            if (strTemp.Substring(i - 3, 1) != "0")
                                bAllZeros = false;

                        tmpBuff = "";
                    }
                    if (bAllZeros == false && nPosition > 1)
                        tmpBuff = tmpBuff + thousands[nPosition / 3] + " ";

                    strResult = tmpBuff + strResult;
                    break;
                case 2:
                    if (nDigit > 0)
                        strResult = tens[nDigit] + " " + strResult;
                    break;
                case 0:
                    if (nDigit > 0)
                        strResult = ones[nDigit] + " Hundred " + strResult;

                    break;
                default:
                    break;
            }
        }
        strResult += " Rupee(s) Only";
        if (strResult.Length > 0)
            strResult = strResult.Substring(0, 1).ToUpper() + strResult.Substring(1, strResult.Length - 1);




        return strResult;

    }
    catch (Exception ex)
    {
        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return "";
    }

        }
        public static docState ReturnDocState(string DocTag)
        {
            if (DocTag == "U")
                return docState.Open;
            else if (DocTag == "P")
                return docState.Closed;
            else if (DocTag == "C")
                return docState.Cancelled;
            else if (DocTag == "A")
                return docState.Authorized;
            else if (DocTag == "O")
                return docState.Open;
            else if (DocTag == "S")
                return docState.Closed;
            else if(DocTag =="0")
                return docState.Open;
            else if(DocTag =="1")
                return docState.Closed;
            else if(DocTag=="2")
                return docState.Authorized;
            else if(DocTag =="3")
                return docState.Cancelled;
           
            else return docState.NotDefined;
        }
        public static System.Drawing.Image ReturnDocStateImage(docState dc)
        {
            if (dc == docState.Open)
                return MachineEyes.Properties.Resources.DocState_Open;
            else if (dc == docState.Closed)
                return MachineEyes.Properties.Resources.DocState_Closed;
            else if (dc == docState.Cancelled)
                return MachineEyes.Properties.Resources.DocState_Cancelled;
            else if (dc == docState.Authorized)
                return MachineEyes.Properties.Resources.DocState_Authorized;
            else return MachineEyes.Properties.Resources.DocState_UnDefined;
        }
    }
   
   
}
