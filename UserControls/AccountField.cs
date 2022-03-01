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
    public partial class AccountField : DevExpress.XtraEditors.XtraUserControl
    {
        public MachineEyes.Classes.easyVoucherCalculations eVC;
        public AccountField()
        {
            InitializeComponent();
        }
       
        private void Browse_Account_Click(object sender, EventArgs e)
        {
            Program.MainWindow.AccountsList.ShowDialog();
            if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
            {
                this.AccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                this.AccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
               
            }
        }

       

        private void TakeAction(KeyEventArgs e)
        {
            if (e.Control == false) return;
            if (e.KeyCode == Keys.Delete)
            {
                if(this.Parent.Controls.Count>1)
                this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert )
            {
                AccountField nAccount=new AccountField();
                nAccount.eVC = this.eVC;
                nAccount.Particulars.Text = this.Particulars.Text;
                this.Parent.Controls.Add(nAccount);
                nAccount.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.I && e.Control==true)
            {
                AccountField nAccount = new AccountField();
                nAccount.Particulars.Text = this.Particulars.Text;
                nAccount.eVC = this.eVC;
                this.Parent.Controls.Add(nAccount);
                nAccount.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.D && e.Control==true)
            {
                this.InvoiceNumber.EditValue = null;
                this.InvoiceNumber.Tag = null;
            }
           
        }
        private void AccountField_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control==true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                }
            }
            else if (e.KeyCode == Keys.F1 && this.AccountID.EditValue!=null)
            {
               
                        Accounts.Account_info info = new Accounts.Account_info();
                        info.FillAccount(this.AccountID.Text);
                        info.ShowDialog();
            

            }
            else
                TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
            }
            else if (e.KeyCode == Keys.Up)
            {
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.Particulars.Focus();
            }
        }

        //private void AccountName_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter && e.Control ==true)
        //    {
        //        Program.MainWindow.AccountsList.ShowDialog();
        //        if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
        //        {
        //            this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
        //            this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
        //            this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
        //        }
        //    }
        //    else if (e.KeyCode == Keys.F1)
        //    {
        //        if (AccountName.Tag != null)
        //        {
        //            if (AccountName.Tag.ToString() != "")
        //            {
        //                Accounts.Account_info info = new Accounts.Account_info();
        //                info.FillAccount(this.AccountID.Text);
        //                info.ShowDialog();
        //            }
        //        }

        //    }
            
        //    else
        //    TakeAction(e);
        //}

        private void Amount_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Right)
            {
                this.DeliveryChallanNumber.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.Particulars.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
               
            }
            
            TakeAction(e);
        }

        private void InvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.AccountID.EditValue == null) return;
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select iNumber,iDate,ValExTax,ValTax,ValInTax from AC_Sales_Main where BuyerID='" + this.AccountID.EditValue.ToString() + "'";
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
            else if (e.KeyCode == Keys.Delete && e.Control == false)
            {
                this.InvoiceNumber.EditValue = null;
                this.InvoiceNumber.Tag = null;
            }
            else if (e.KeyCode == Keys.Enter && e.Shift == true)
            {
                try
                {
                    if (this.AccountID.EditValue == null) return;
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    string query = "Select SupplierInvoiceNumber,iDate,ValExTax,ValTax,ValInTax from AC_Purchases_Main where SupplierID='" + this.AccountID.EditValue.ToString() + "'";
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
            TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.Particulars.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.ChequeNumber.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.BillNumber.Focus();
            }
        }

        private void Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.Amount.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.AccountID.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
               
            }
        }

        private void ChequeNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.InvoiceNumber.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.DeliveryChallanNumber.Focus();
            }
        }

        private void DeliveryChallanNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.BillNumber.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.Amount.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.ChequeNumber.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                
            }
        }

        private void BillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
            if (e.KeyCode == Keys.Right)
            {
                this.DeliveryChallanNumber.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.DeliveryChallanNumber.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.InvoiceNumber.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                
            }
        }

        private void Amount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
        }
        public void CalculateAmount()
        {
            int Total = 0;
            foreach (Control C in this.Parent.Controls)
            {

                UserControls.AccountField Af = (UserControls.AccountField)C;
                try
                {
                    int afAmount = 0;
                    if(Af.Amount.EditValue!=null)
                    Int32.TryParse(Af.Amount.EditValue.ToString(), out afAmount);
                    Total += afAmount;
                }
                catch
                {
                }
            }
            if (eVC != null)
                eVC.multiTotal = Total;
        }

        private void Amount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void AccountID_EditValueChanged(object sender, EventArgs e)
        {
            this.InvoiceNumber.EditValue = null;
            this.InvoiceNumber.Tag = null;
            if (this.AccountID.EditValue != null)
            {
                this.AccountName.EditValue = this.AccountID.EditValue;
               

            }
            else
                this.AccountName.EditValue = null;
        }

        private void AccountName_EditValueChanged(object sender, EventArgs e)
        {
            this.AccountID.EditValue = this.AccountName.EditValue;
        }

        private void AccountField_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.Accounts_V(ref this.AccountName);
        }

        private void AccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                this.AccountName.Focus();
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.AccountID.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.ChequeNumber.Focus();
            }
        }

        private void DeliveryChallanNumber_EditValueChanged(object sender, EventArgs e)
        {

        }

      
    }
}
