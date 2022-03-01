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
    public partial class Account_SalesInvoice_VAT : DevExpress.XtraEditors.XtraUserControl
    {
        public MachineEyes.Classes.easyVoucherCalculations eVC;
        public Account_SalesInvoice_VAT()
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
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                Account_SalesInvoice_FabricSales nAccount = new Account_SalesInvoice_FabricSales();
                nAccount.eVC = this.eVC;
               // nAccount.GSTRate.Text = this.GSTRate.Text;
                this.Parent.Controls.Add(nAccount);

            }


            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
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
                   // this.GSTRate.Text = "0";
                    dGSTRate = 0;
                }
                else
                {

                    //if (this.GSTRate.Text != "")
                    //    double.TryParse(this.GSTRate.Text, out dGSTRate);
                    //else
                        double.TryParse(MachineEyes.Classes.Accounting.RegAccounts.GSTRATE, out dGSTRate);
                }
            }
            dValueExTax = dRate * dQty;
            dValueTax = (dRate * dQty) * dGSTRate / 100;
            dValueExTax = Math.Round(dValueExTax, 0);
            dValueTax = Math.Round(dValueTax, 0);
            dValueInTax = dValueExTax + dValueTax;

            this.AmountExcludingTax.Text = dValueExTax.ToString("#,##");
            //this.AmountIncludingTax.Text = dValueInTax.ToString("#,##");
            //this.AmountExcludingTax.Tag = dValueExTax.ToString();
            //this.AmountIncludingTax.Tag = dValueInTax.ToString();
            //this.AmountTax.Text = dValueTax.ToString("#,##");
            //this.AmountTax.Tag = dValueTax.ToString();
            double totalAmountExTax = 0;
            double totalAmountTax = 0;
            if (this.Parent != null)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    Account_SalesInvoice_FabricSales te = (Account_SalesInvoice_FabricSales)c;
                    if (te.AmountExcludingTax.Tag != null)
                    {
                        double aExTax = 0;
                        double.TryParse(te.AmountExcludingTax.Tag.ToString(), out aExTax);
                        totalAmountExTax += aExTax;
                    }


                    if (te.AmountTax.Tag != null)
                    {
                        double atax = 0;
                        double.TryParse(te.AmountTax.Tag.ToString(), out atax);
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

            }
            else
                TakeAction(e);
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            TextEdit te = (TextEdit)sender;
            this.AccountName.Text = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
            this.AccountName.Tag = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(te.Text);
        }

        private void SellingUnit_KeyUp(object sender, KeyEventArgs e)
        {
            LookUpEdit l = (LookUpEdit)sender;
            if (e.KeyCode == Keys.Delete)
                l.EditValue = null;
        }

        private void Quantity_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

        private void Rate_Properties_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

        private void Rate_KeyUp(object sender, KeyEventArgs e)
        {
            Calculations();
            TakeAction(e);
        }

    }
}
