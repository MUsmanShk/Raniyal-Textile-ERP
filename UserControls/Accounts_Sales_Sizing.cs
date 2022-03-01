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
    public partial class Accounts_Sales_Sizing : DevExpress.XtraEditors.XtraUserControl
    {
        public MachineEyes.Classes.easyVoucherCalculations eVC;
        public string salesTypeID;
        public Accounts_Sales_Sizing()
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
            else if (e.KeyCode == Keys.Insert)
            {
                Accounts_Sales_Sizing nAccount = new Accounts_Sales_Sizing();
                nAccount.eVC = this.eVC;
                nAccount.GSTRate.Text = MachineEyes.Classes.Accounting.Get_GSTRate_BySalesTypeID(this.salesTypeID);
                nAccount.AccountID.Text = MachineEyes.Classes.Accounting.Get_DefaultAccount_BySalesTypeID(this.salesTypeID);
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
            dValueExTax = dRate * dQty;
            dValueTax = (dRate * dQty) * dGSTRate / 100;
            dValueExTax = Math.Round(dValueExTax, 0);
            dValueTax = Math.Round(dValueTax, 0);
            dValueInTax = dValueExTax + dValueTax;

            this.AmountExcludingTax.EditValue = dValueExTax.ToString();
            this.AmountIncludingTax.EditValue = dValueInTax.ToString();
            this.AmountExcludingTax.EditValue = dValueExTax.ToString();

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

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            TextEdit te = (TextEdit)sender;
            this.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
            this.AccountName.Tag = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
        }
    }
}
