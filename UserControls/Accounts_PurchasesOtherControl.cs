using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MachineEyes.UserControls
{
    public partial class Accounts_PurchasesOtherControl : UserControl
    {
        public string PurchaseTypeID = "";
        public MachineEyes.Classes.easyPurchasesCalculations eVC;
        public string SupplierID = "";
        public Accounts_PurchasesOtherControl()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.MeasurementUnits(ref this.SellingUnit);
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
            else if (e.KeyCode == Keys.Insert)
            {
                Accounts_PurchasesOtherControl nAccount = new Accounts_PurchasesOtherControl();
                nAccount.eVC = this.eVC;
                nAccount.SupplierID = this.SupplierID;
                nAccount.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_ByPurchaseTypeID(this.PurchaseTypeID);
                this.Parent.Controls.Add(nAccount);

            }


          

        }
        public void Calculations()
        {
            double dRate = 0;
            double dQty = 0;
            double dGSTRate = 0;
            double dValueExTax = 0;
            double dValueInTax = 0;
            double dValueTax = 0;
            double.TryParse(this.Rate.Text, out dRate);
            double.TryParse(this.Quantity.Text, out dQty);
            if (eVC != null)
            {
                if (eVC.isNType == true)
                {
                    this.GSTRate.Text = "0";
                    dGSTRate = 0;
                }
                else
                {

                    if (this.GSTRate.Text != "")
                        double.TryParse(this.GSTRate.Text, out dGSTRate);
                    else
                        dGSTRate = 0;
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
                
                this.AmountIncludingTax.EditValue  = dValueInTax.ToString();

               
                if(this.checkTax.Checked==false)
                this.AmountTax.EditValue = dValueTax.ToString();
              
            
            double totalAmountExTax = 0;
            double totalAmountTax = 0;
            if (this.Parent != null)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    Accounts_PurchasesOtherControl te = (Accounts_PurchasesOtherControl)c;
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
                eVC.salestax = Convert.ToInt32(totalAmountTax);
                eVC.amountExTax = Convert.ToInt32(totalAmountExTax);

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
              
                GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_ByPurchaseTypeID(this.PurchaseTypeID);
               
            }
            else if (checkTax.Checked == true)
            {
                checkTax.Text = "@Tax Amnt";
                AmountTax.Enabled = true;
                GSTRate.Enabled = false;
                GSTRate.EditValue = null;
            }

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

        private void Rate_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
        }

        private void Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
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

        private void AmountTax_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void GSTRate_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
        }

        private void AmountExcludingTax_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void AmountExcludingTax_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
        }

        private void AmountTax_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void AmountExcludingTax_Properties_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void AmountIncludingTax_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
          
            this.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(AccountID.Text );
            this.AccountName.Tag = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(AccountID.Text);
        }

        private void AccountID_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void AccountName_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Item_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void AmountExcludingTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control != false)
                TakeAction(e);
        }

        private void AmountIncludingTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control != false)
                TakeAction(e);
        }

        private void AmountTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control != false)
                TakeAction(e);
        }

        private void RefInv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select iNumber,SupplierInvoiceNumber,iDate,ValExTax,ValTax,ValInTax from AC_Purchases_Main where SupplierID='" + SupplierID + "'";
                    FrmView.Load_View(query, "SupplierInvoiceNumber", "iDate");

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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
