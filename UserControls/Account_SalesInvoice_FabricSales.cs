using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.UserControls
{
    public partial class Account_SalesInvoice_FabricSales : DevExpress.XtraEditors.XtraUserControl
    {
        public MachineEyes.Classes.easyVoucherCalculations eVC;

        public string salesTypeID = "";
        public string BuyerID="";
        public Account_SalesInvoice_FabricSales()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.MeasurementUnits(ref this.SellingUnit);

        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                    this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (AccountName.Tag != null)
                {
                    if (AccountName.Tag.ToString() != "")
                    {
                        Accounts.Account_info info = new Accounts.Account_info();
                        info.FillAccount(this.AccountID.Text);
                        info.ShowDialog();
                    }
                }

            }
            else
                TakeAction(e);
        }
        private void TakeAction(KeyEventArgs e)
        {
            if (e.Control == false) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (this.Parent.Controls.Count > 1)
                {
                    this.Rate.EditValue = null;
                    this.Quantity.EditValue = null;
                    this.GSTRate.EditValue = null;
                    Calculations();
                    this.Parent.Controls.Remove(this);
                }
            }
            else if (e.KeyCode == Keys.Insert )
            {
                Account_SalesInvoice_FabricSales nAccount = new Account_SalesInvoice_FabricSales();
                nAccount.eVC = this.eVC;
                nAccount.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(this.salesTypeID);
                nAccount.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(this.salesTypeID);
                nAccount.BuyerID = this.BuyerID;
                this.Parent.Controls.Add(nAccount);

            }
                
           
            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                {
                    this.Rate.EditValue = null;
                    this.Quantity.EditValue = null;
                    this.GSTRate.EditValue = null;
                    Calculations();
                    this.Parent.Controls.Remove(this);
                }
            }

        }
        public void Calculations()
        {
            double dRate=0;
            double dQty=0;
            double dGSTRate=0;
            double dValueExTax=0;
            double dValueInTax=0;
            double dValueTax=0;
            if (this.Rate.EditValue == null) this.Rate.EditValue = "0";
            if (this.Quantity.EditValue == null) this.Quantity.EditValue = "0";
            if (this.GSTRate.EditValue == null) this.GSTRate.EditValue = "0";

            double.TryParse(this.Rate.EditValue.ToString(), out dRate);
            double.TryParse(this.Quantity.EditValue.ToString(), out dQty);
            if (eVC != null)
            {
                if (eVC.isNType == true)
                {
                    this.GSTRate.EditValue = "0";
                    dGSTRate = 0;
                }
                else
                {

                    if (this.GSTRate.EditValue != null)
                        double.TryParse(this.GSTRate.EditValue.ToString(), out dGSTRate);
                    else
                        double.TryParse(MachineEyes.Classes.Accounting.RegAccounts.GSTRATE, out dGSTRate);
                }
            }

            if (this.checkRateQty.Checked == false)
            {
                dValueExTax = dRate * dQty;
            }
            else
            {
                if (this.AmountExcludingTax.EditValue != null)
                    double.TryParse(this.AmountExcludingTax.EditValue.ToString(), out dValueExTax);
                else
                    dValueExTax = 0;
            }
            if (checkTax.Checked == false)
                dValueTax = dValueExTax * dGSTRate / 100;
            else
            {
                if (AmountTax.EditValue != null)
                {
                    double.TryParse(AmountTax.EditValue.ToString(), out dValueTax);
                }
            }
            dValueExTax = Math.Round(dValueExTax, 0);
            dValueTax = Math.Round(dValueTax, 0);
            dValueInTax = dValueExTax + dValueTax;
            if (this.checkRateQty.Checked == false)
                this.AmountExcludingTax.EditValue = dValueExTax.ToString();

            this.AmountIncludingTax.EditValue = dValueInTax.ToString();


            if (this.checkTax.Checked == false)
                this.AmountTax.EditValue = dValueTax.ToString();
          
          
           
           
           
            double totalAmountExTax = 0;
            double totalAmountTax = 0;
            if (this.Parent != null)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    Account_SalesInvoice_FabricSales te = (Account_SalesInvoice_FabricSales)c;
                    if (te.AmountExcludingTax.EditValue != null)
                    {
                        double aExTax = 0;
                        double.TryParse(te.AmountExcludingTax.EditValue.ToString(), out aExTax);
                        totalAmountExTax += aExTax;
                    }


                    if (te.AmountTax.EditValue != null)
                    {
                        double atax = 0;
                        double.TryParse(te.AmountTax.EditValue.ToString(), out atax);
                        totalAmountTax += atax;
                    }

                }
                eVC.amountExTax = Convert.ToInt32(totalAmountExTax);
                eVC.salestax = Convert.ToInt32(totalAmountTax);
            }
           


        }
        private void ItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.ItemID.Text = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                        this.Item.Text = Program.MainWindow.ArticleView.SelectedRow.PrimaryString;
                        this.SellingUnit.EditValue = Program.MainWindow.ArticleView.SelectedRow.SelectedDataRow["SellingUnit"].ToString();
                        this.Rate.Text = Program.MainWindow.ArticleView.SelectedRow.SelectedDataRow["SellingRate"].ToString();
                        this.ItemID.Tag = "1";

                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

            }else
                TakeAction(e);



        }

        private void Rate_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void Rate_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

        private void Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

        private void Rate_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void GSTRate_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            TextEdit te=(TextEdit)sender;
            this.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
            this.AccountName.Tag = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
        }

        private void AccountName_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Item_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void SellingUnit_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit l = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Delete)
                l.EditValue = null;
        }

        private void Quantity_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void GSTRate_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void Rate_KeyDown(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

        private void RefInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter )
            {
                try
                {
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query="Select iNumber,iDate,ValExTax,ValTax,ValInTax from AC_Sales_Main where BuyerID='" + BuyerID + "'";
                    FrmView.Load_View(query, "iNumber", "iDate");

                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.RefInv.EditValue = sRow.PrimeryID;
                        this.RefInv.Tag = sRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void ContractNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select POType,PONO,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS,Price,Currency,WPP from RFC_PO_YarnRequired where BuyerID='" + BuyerID + "'";
                    FrmView.Load_View(query, "PONO", "PONO");

                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.ContractNumber.EditValue = sRow.PrimeryID;
                        this.ContractNumber.Tag = sRow.PrimaryString;
                        try
                        {
                            this.ItemID.EditValue = sRow.SelectedDataRow["ArticleNumber"].ToString();
                            this.Item.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();
                            this.Rate.EditValue = sRow.SelectedDataRow["Price"].ToString();

                        }
                        catch
                        {
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

        private void checkRateQty_CheckedChanged(object sender, EventArgs e)
        {

            if (this.checkRateQty.Checked == false)
            {
                checkRateQty.Text = "=Qty*Rate";
                Rate.Enabled = true;
                Quantity.Enabled = true;
                Rate.EditValue = "";
                Quantity.EditValue = "";
                AmountExcludingTax.Enabled = false;

            }
            else if (this.checkRateQty.Checked == true)
            {
                checkRateQty.Text = "=Value";
                Rate.Enabled = false;
                Quantity.Enabled = false;
                Rate.EditValue = null;
                Quantity.EditValue = null;
                AmountExcludingTax.Enabled = true;
            }
        }

        private void checkTax_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTax.Checked == false)
            {
                checkTax.Text = "@Tax Rate";
                AmountTax.Enabled = false;
                GSTRate.Enabled = true;

                GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_ByPurchaseTypeID(this.salesTypeID);

            }
            else if (checkTax.Checked == true)
            {
                checkTax.Text = "@Tax Amnt";
                AmountTax.Enabled = true;
                GSTRate.Enabled = false;
                GSTRate.EditValue = null;
            }
        }

     
     
  
       
    }
}
