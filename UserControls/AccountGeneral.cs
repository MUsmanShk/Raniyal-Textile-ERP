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
    public partial class AccountGeneral : DevExpress.XtraEditors.XtraUserControl
    {
        public MachineEyes.Classes.easyVoucherCalculations eVC;
        public AccountGeneral()
        {
            InitializeComponent();
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
                AccountGeneral nAccount = new AccountGeneral();
                nAccount.eVC = this.eVC;
                nAccount.Particulars.Text = this.Particulars.Text;
                this.Parent.Controls.Add(nAccount);
            }
          
            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
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

        private void AccountName_KeyDown(object sender, KeyEventArgs e)
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

        private void Browse_Account_Click(object sender, EventArgs e)
        {
            Program.MainWindow.AccountsList.ShowDialog();
            if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
            {
                this.AccountID.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                this.AccountName.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                this.AccountName.Tag = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
            }
        }

        private void AccountID_TextChanged(object sender, EventArgs e)
        {
            if (this.AccountID.Text.Length == 13)
            {
                string sAccountName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AccountID.Text);
                this.AccountName.Text = sAccountName;
                AccountName.Tag = sAccountName;
            }
            else
            {
                AccountName.Text = "";
                AccountName.Tag = "";
            }
        }
        public void CalculateDebitTotal()
        {

            int Total = 0;

            foreach (Control C in this.Parent.Controls)
            {

                UserControls.AccountGeneral Af = (UserControls.AccountGeneral)C;
                try
                {
                    int afAmount = 0;
                   if(Af.Debit.EditValue!=null)
                    Int32.TryParse(Af.Debit.EditValue.ToString(), out afAmount);
                    Total += afAmount;
                }
                catch
                {
                }
            }
            if (eVC != null)
                eVC.multiTotal = Total;
        }
        private void Debit_TextChanged(object sender, EventArgs e)
        {
            CalculateDebitTotal();
        }
        public void CalculateCreditTotal()
        {
            int Total = 0;
            foreach (Control C in this.Parent.Controls)
            {

                UserControls.AccountGeneral Af = (UserControls.AccountGeneral)C;
                try
                {
                    int afAmount = 0;
                    if(Af.Credit.EditValue!=null)
                    Int32.TryParse(Af.Credit.EditValue.ToString(), out afAmount);
                    Total += afAmount;
                }
                catch
                {
                }
            }
            if (eVC != null)
                eVC.singleTotal = Total;
        }
        private void Credit_TextChanged(object sender, EventArgs e)
        {
            CalculateCreditTotal();
        }

        private void Debit_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        private void Credit_KeyUp(object sender, KeyEventArgs e)
        {
          
               
        }

        private void Particulars_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Debit_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Credit_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void InvoiceNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void BillNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void DeliveryChallanNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Credit_EditValueChanged(object sender, EventArgs e)
        {
            if (Debit.EditValue != null)
            {
                if (Credit.EditValue != null)
                {
                    if (Debit.EditValue.ToString() != "0")
                        Credit.EditValue = "0";
                }
            }
        }

        private void Debit_EditValueChanged(object sender, EventArgs e)
        {
            if (Credit.EditValue != null)
            {
                if (Debit.EditValue != null)
                {
                    if (Credit.EditValue.ToString() != "0")
                        Debit.EditValue = "0";
                }
            }
        }

        
    }
}
