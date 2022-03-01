using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Data
{
    public partial class Data_Accounts : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;

        public Data_Accounts()
        {
            InitializeComponent();
            Get_AccountType();
        }
        public void Get_AccountType()
        {
            
        }

        private void Data_Accounts_Load(object sender, EventArgs e)
        {
            set_ButtonStates(UserInputMode.View);
            RefreshAndClear();
        }
        private void set_ButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.btn_Save.Enabled = false;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Add.Enabled = true;
                    this.btn_Close.Enabled = true;
                    this.btn_View.Enabled = true;
                    set_ReadOnly(true);

                    if (this.AccountID_textEdit.Tag != null)
                    {
                        if (this.AccountID_textEdit.Tag.ToString() != "")
                        {

                            this.btn_Edit.Enabled = true;
                            this.btn_Del.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.btn_Edit.Enabled = false;
                            this.btn_Del.Enabled = false;
                        }
                    }
                    else
                    {
                        this.btn_Edit.Enabled = false;
                        this.btn_Del.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:

                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_View.Enabled = false;
                    this.btn_Del.Enabled = false;
                    set_ReadOnly(false);
                    break;
                case UserInputMode.Edit:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                    set_ReadOnly(false);
                    break;
                case UserInputMode.Delete:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                    set_ReadOnly(false);
                    break;
                default:
                    break;
            }
        }
        private void RefreshAndClear()
        {
            this.AccountID_textEdit.Tag = "";
            this.AccountID_textEdit.EditValue=null;;
            this.AccountName_textEdit1.EditValue = null;
            this.FactoryAddress_textEdit1.EditValue = null;
            this.Mobile1_textEdit1.EditValue = null;
            this.Mobile2_textEdit1.EditValue = null;
            this.Phone1_textEdit1.EditValue = null;
            this.Phone2_textEdit1.EditValue = null;
            this.MailingAddress_textEdit1.EditValue = null;
            this.NTN_textEdit1.EditValue = null;
            this.GST_textEdit1.EditValue = null;
            this.ConcernedPerson1_textEdit1.EditValue = null;
            this.CP1Mobile1_textEdit1.EditValue = null;
            this.CP1Mobile2_textEdit1.EditValue = null;
            this.ConcernedPerson2_textEdit1.EditValue = null;
            this.CP2Mobile1_textEdit1.EditValue = null;
            this.CP2Mobile2_textEdit1.EditValue = null;
            set_ButtonStates(UserInputMode.View);
        }
        private void set_ReadOnly(bool val)
        {
            this.AccountID_textEdit.Properties.ReadOnly = val;
            this.AccountName_textEdit1.Properties.ReadOnly = val;
            this.FactoryAddress_textEdit1.Properties.ReadOnly = val;
            this.Mobile1_textEdit1.Properties.ReadOnly = val;
            this.Mobile2_textEdit1.Properties.ReadOnly = val;
            this.Phone1_textEdit1.Properties.ReadOnly = val;
            this.Phone2_textEdit1.Properties.ReadOnly = val;
            this.MailingAddress_textEdit1.Properties.ReadOnly = val;
            this.NTN_textEdit1.Properties.ReadOnly = val;
            this.GST_textEdit1.Properties.ReadOnly = val;
            this.ConcernedPerson1_textEdit1.Properties.ReadOnly = val;
            this.CP1Mobile1_textEdit1.Properties.ReadOnly = val;
            this.CP1Mobile2_textEdit1.Properties.ReadOnly = val;
            this.ConcernedPerson2_textEdit1.Properties.ReadOnly = val;
            this.CP2Mobile1_textEdit1.Properties.ReadOnly = val;
            this.CP2Mobile2_textEdit1.Properties.ReadOnly = val;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            DataSet ds = WS.svc.Get_DataSet("select isnull(Max(Convert(numeric,AccountID)),0) +1 as AccountID from PP_Accounts ");
            try
            {
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        int MaxID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        this.AccountID_textEdit.Text = MaxID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            set_ButtonStates(UserInputMode.Add);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (AccountID_textEdit.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (AccountID_textEdit.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
            set_ButtonStates(UserInputMode.Edit);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {

            set_ButtonStates(UserInputMode.Delete);
            
        }
        private void DeleteExisting()
        {
            if (AccountID_textEdit.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (AccountID_textEdit.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string query = "";
           query= "Delete from PP_Accounts where AccountID = " + AccountID_textEdit.Text + "";
           string res = WS.svc.Execute_Query(query);
            if (res == "**SUCCESS##")
            {
                RefreshAndClear();
                set_ButtonStates(UserInputMode.View);
            }
            else
            {
                XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Fill_AccountsData(string AccountID)
        {
            try
            {
               DataSet ds= WS.svc.Get_DataSet("Select * from PP_Accounts where AccountID='" + AccountID + "'");
               if (ds != null)
               {
                   if (ds.Tables[0].Rows.Count > 0)
                   {

                       this.AccountID_textEdit.Tag = ds.Tables[0].Rows[0]["AccountID"].ToString();
                       if (ds.Tables[0].Rows[0]["AccountID"].ToString() != "")
                       {
                           this.AccountID_textEdit.EditValue = ds.Tables[0].Rows[0]["AccountID"].ToString();
                           this.AccountID_textEdit.Tag = ds.Tables[0].Rows[0]["AccountID"].ToString();
                       }
                       else
                       {
                           this.AccountID_textEdit.EditValue = null;
                           this.AccountID_textEdit.Tag = null;
                       }

                       if (ds.Tables[0].Rows[0]["AccountName"].ToString() != "")
                           this.AccountName_textEdit1.EditValue = ds.Tables[0].Rows[0]["AccountName"].ToString();
                       else
                           this.AccountName_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["FactoryAddress"].ToString() != "")
                           this.FactoryAddress_textEdit1.EditValue = ds.Tables[0].Rows[0]["FactoryAddress"].ToString();
                       else
                           this.FactoryAddress_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["Mobile1"].ToString() != "")
                           this.Mobile1_textEdit1.EditValue = ds.Tables[0].Rows[0]["Mobile1"].ToString();
                       else
                           this.Mobile1_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["Mobile2"].ToString() != "")
                           this.Mobile2_textEdit1.EditValue = ds.Tables[0].Rows[0]["Mobile2"].ToString();
                       else
                           this.Mobile2_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["Phone1"].ToString() != "")
                           this.Phone1_textEdit1.EditValue = ds.Tables[0].Rows[0]["Phone1"].ToString();
                       else
                           this.Phone1_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["Phone2"].ToString() != "")
                           this.Phone2_textEdit1.EditValue = ds.Tables[0].Rows[0]["Phone2"].ToString();
                       else
                           this.Phone2_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["MailingAddress"].ToString() != "")
                           this.MailingAddress_textEdit1.EditValue = ds.Tables[0].Rows[0]["MailingAddress"].ToString();
                       else
                           this.MailingAddress_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["NTN"].ToString() != "")
                           this.NTN_textEdit1.EditValue = ds.Tables[0].Rows[0]["NTN"].ToString();
                       else
                           this.NTN_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["GST"].ToString() != "")
                           this.GST_textEdit1.EditValue = ds.Tables[0].Rows[0]["GST"].ToString();
                       else
                           this.GST_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["ConcernedPerson1"].ToString() != "")
                           this.ConcernedPerson1_textEdit1.EditValue = ds.Tables[0].Rows[0]["ConcernedPerson1"].ToString();
                       else
                           this.ConcernedPerson1_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["CP1Mobile1"].ToString() != "")
                           this.CP1Mobile1_textEdit1.EditValue = ds.Tables[0].Rows[0]["CP1Mobile1"].ToString();
                       else
                           this.CP1Mobile1_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["CP1Mobile2"].ToString() != "")
                           this.CP1Mobile2_textEdit1.EditValue = ds.Tables[0].Rows[0]["CP1Mobile2"].ToString();
                       else
                           this.CP1Mobile2_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["ConcernedPerson2"].ToString() != "")
                           this.ConcernedPerson2_textEdit1.EditValue = ds.Tables[0].Rows[0]["ConcernedPerson2"].ToString();
                       else
                           this.ConcernedPerson2_textEdit1.EditValue = null; ;
                       if (ds.Tables[0].Rows[0]["CP2Mobile1"].ToString() != "")
                           this.CP2Mobile1_textEdit1.EditValue = ds.Tables[0].Rows[0]["CP2Mobile1"].ToString();
                       else
                           this.CP2Mobile1_textEdit1.EditValue = null;
                       if (ds.Tables[0].Rows[0]["CP2Mobile2"].ToString() != "")
                           this.CP2Mobile2_textEdit1.EditValue = ds.Tables[0].Rows[0]["CP2Mobile2"].ToString();
                       else
                           this.CP2Mobile2_textEdit1.EditValue = null;
                   }

               }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_View_Click(object sender, EventArgs e)
        {
            uiMode = UserInputMode.View;
            this.btn_Edit.Enabled = true;
            this.btn_Del.Enabled = true;
            this.btn_Add.Enabled = true;
            this.btn_Cancel.Enabled = false;
            this.btn_Close.Enabled = true;
            this.btn_Save.Enabled = false;

            Data_Accounts_View FrmView = new Data_Accounts_View();
            FrmView.sRow = SelectedRow;
            FrmView.ShowDialog();
            if (SelectedRow.Status == ParameterStatus.Selected)
            {
                Fill_AccountsData(this.SelectedRow.PrimeryID);

            }
        }
        
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            set_ButtonStates(UserInputMode.View);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void UpdateExisting()
        {
            if (this.AccountID_textEdit.EditValue == null)
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.AccountID_textEdit.Tag == null)
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.AccountID_textEdit.Tag.ToString()=="")
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.AccountName_textEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account Name", "Error");
                return;
            }
            string query = "update PP_Accounts set ";

            if (this.AccountID_textEdit.EditValue != null)
                query += "AccountID='" + this.AccountID_textEdit.EditValue.ToString() + "'";
            else
                query += "AccountID=null";
            if (this.AccountName_textEdit1.EditValue != null)
                query += ",AccountName='" + this.AccountName_textEdit1.EditValue.ToString() + "'";
            else
                query += ",AccountName=null";
            if (this.FactoryAddress_textEdit1.EditValue != null)
                query += ",FactoryAddress='" + this.FactoryAddress_textEdit1.EditValue.ToString() + "'";
            else
                query += ",FactoryAddress=null";
            if (this.Mobile1_textEdit1.EditValue != null)
                query += ",Mobile1='" + this.Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",Mobile1=null";
            if (this.Mobile2_textEdit1.EditValue != null)
                query += ",Mobile2='" + this.Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",Mobile2=null";
            if (this.Phone1_textEdit1.EditValue != null)
                query += ",Phone1='" + this.Phone1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",Phone1=null";
            if (this.Phone2_textEdit1.EditValue != null)
                query += ",Phone2='" + this.Phone2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",Phone2=null";
            if (this.MailingAddress_textEdit1.EditValue != null)
                query += ",MailingAddress='" + this.MailingAddress_textEdit1.EditValue.ToString() + "'";
            else
                query += ",MailingAddress=null";
            if (this.NTN_textEdit1.EditValue != null)
                query += ",NTN='" + this.NTN_textEdit1.EditValue.ToString() + "'";
            else
                query += ",NTN=null";
            if (this.GST_textEdit1.EditValue != null)
                query += ",GST='" + this.GST_textEdit1.EditValue.ToString() + "'";
            else
                query += ",GST=null";
            if (this.ConcernedPerson1_textEdit1.EditValue != null)
                query += ",ConcernedPerson1='" + this.ConcernedPerson1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",ConcernedPerson1=null";
            if (this.CP1Mobile1_textEdit1.EditValue != null)
                query += ",CP1Mobile1='" + this.CP1Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",CP1Mobile1=null";
            if (this.CP1Mobile2_textEdit1.EditValue != null)
                query += ",CP1Mobile2='" + this.CP1Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",CP1Mobile2=null";
            if (this.ConcernedPerson2_textEdit1.EditValue != null)
                query += ",ConcernedPerson2='" + this.ConcernedPerson1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",ConcernedPerson2=null";
            if (this.CP2Mobile1_textEdit1.EditValue != null)
                query += ",CP2Mobile1='" + this.CP2Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",CP2Mobile1=null";
            if (this.CP2Mobile2_textEdit1.EditValue != null)
                query += ",CP2Mobile2='" + this.CP2Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",CP2Mobile2=null";
            query += " where AccountID='"+this.AccountID_textEdit.Tag.ToString()+"'";
            string tResult = WS.svc.Execute_Query(query);
            if (tResult != "**SUCCESS##")
            {
                XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                RefreshAndClear();
            }

        }
        private void SaveNew()
        {
            if (this.AccountID_textEdit.EditValue == null)
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.AccountName_textEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account Name", "Error");
                return;
            }
            string query = "insert into PP_Accounts (AccountID,AccountName,FactoryAddress,Mobile1,Mobile2,Phone1,Phone2,MailingAddress,NTN,GST,ConcernedPerson1,CP1Mobile1,CP1Mobile2,ConcernedPerson2,CP2Mobile1,CP2Mobile2) Values( '" + this.AccountID_textEdit.EditValue.ToString() + "','" + this.AccountName_textEdit1.EditValue.ToString() + "'";
            if (this.FactoryAddress_textEdit1.EditValue != null)
               query += ",'" + this.FactoryAddress_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Mobile1_textEdit1.EditValue != null)
                query += ",'" + this.Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Mobile2_textEdit1.EditValue != null)
                query += ",'" + this.Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Phone1_textEdit1.EditValue != null)
                query += ",'" + this.Phone1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Phone2_textEdit1.EditValue != null)
                query += ",'" + this.Phone2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.MailingAddress_textEdit1.EditValue != null)
                query += ",'" + this.MailingAddress_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.NTN_textEdit1.EditValue != null)
                query += ",'" + this.NTN_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.GST_textEdit1.EditValue != null)
                query += ",'" + this.GST_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.ConcernedPerson1_textEdit1.EditValue != null)
                query += ",'" + this.ConcernedPerson1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.CP1Mobile1_textEdit1.EditValue != null)
                query += ",'" + this.CP1Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.CP1Mobile2_textEdit1.EditValue != null)
                query += ",'" + this.CP1Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.ConcernedPerson2_textEdit1.EditValue != null)
                query += ",'" + this.ConcernedPerson1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.CP2Mobile1_textEdit1.EditValue != null)
                query += ",'" + this.CP2Mobile1_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.CP2Mobile2_textEdit1.EditValue != null)
                query += ",'" + this.CP2Mobile2_textEdit1.EditValue.ToString() + "'";
            else
                query += ",null";
            query += ")";
             string tResult = WS.svc.Execute_Query(query);
             if (tResult != "**SUCCESS##")
             {
                 XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             else
             {
                 RefreshAndClear();
             }

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string mRetVal;
            string[] mSql = new string[0];
            Array.Resize(ref mSql, 1);
            mRetVal = CheckValidation_Edit();
            if (mRetVal == "**SUCCESS##")
            {
                if (uiMode == UserInputMode.Add)
                {
                    SaveNew();
                }
                else if (uiMode == UserInputMode.Edit)
                {
                    UpdateExisting();
                }

                else if (uiMode == UserInputMode.Delete)
                    DeleteExisting();

            }
        }
        private string CheckValidation_Edit()
        {
            string  mRetVal = "";
            if (AccountID_textEdit.Text.Trim() == "")
            {
                mRetVal = "Account Id must be define";
            }
            if (AccountName_textEdit1.Text.Trim() == "")
            {
                mRetVal = "Account name must be define";
            }
            if (mRetVal.Length > 0)
                MessageBox.Show(mRetVal);
            else
                mRetVal = "**SUCCESS##";

            return mRetVal;
        }
    }
}