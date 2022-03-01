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
    public partial class Data_CountManagement : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;

        public Data_CountManagement()
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
                   
                    if (this.DisplayCount.Tag != null)
                    {
                        if (this.DisplayCount.Tag.ToString() != "")
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
                   
                    break;
                case UserInputMode.Edit:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                   
                    break;
                case UserInputMode.Delete:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                  
                    break;
                default:
                    break;
            }
        }
        private void RefreshAndClear()
        {
          
            this.DisplayCount.EditValue = null;
            this.EnglishCount.EditValue = null;
            
            set_ButtonStates(UserInputMode.View);
        }
       

        private void btn_Add_Click(object sender, EventArgs e)
        {
           
            set_ButtonStates(UserInputMode.Add);
            this.DisplayCount.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
           
            set_ButtonStates(UserInputMode.Edit);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {

            set_ButtonStates(UserInputMode.Delete);
            
        }
        private void DeleteExisting()
        {
           
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string query = "";
           query= "Delete from PP_YarnCounts where YarnCount = " + this.DisplayCount.Tag.ToString() + "";
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
        private void Fill_GroupData(string YarnCount)
        {
            try
            {
               DataSet ds= WS.svc.Get_DataSet("Select * from PP_YarnCounts where YarnCount='" + YarnCount + "'");
               if (ds != null)
               {
                   if (ds.Tables[0].Rows.Count > 0)
                   {

                       this.DisplayCount.Tag = ds.Tables[0].Rows[0]["YarnCount"].ToString();
                       if (ds.Tables[0].Rows[0]["YarnCount"].ToString() != "")
                       {
                           this.DisplayCount.EditValue = ds.Tables[0].Rows[0]["YarnCount"].ToString();
                           this.DisplayCount.Tag = ds.Tables[0].Rows[0]["YarnCount"].ToString();
                       }
                       else
                       {
                           this.DisplayCount.EditValue = null;
                           this.DisplayCount.Tag = null;
                       }

                       
                     
                       if (ds.Tables[0].Rows[0]["EnglishCount"].ToString() != "")
                           this.EnglishCount.EditValue = ds.Tables[0].Rows[0]["EnglishCount"].ToString();
                       else
                           this.EnglishCount.EditValue = null;
                       if (ds.Tables[0].Rows[0]["CountTypeID"].ToString() == "")
                           this.RadioCountType.EditValue = "0";
                       else
                           this.RadioCountType.EditValue = ds.Tables[0].Rows[0]["CountTypeID"].ToString();
                      
                     
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

   

            string Query= "Select * from PP_YarnCounts order by EnglishCount";
          selectedrow sRow = new selectedrow();
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(Query, "YarnCount", "YarnCount");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                Fill_GroupData(sRow.PrimeryID);
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
            if (this.DisplayCount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Count ", "Error");
                return;
            }
            if (this.DisplayCount.Tag == null)
            {
                XtraMessageBox.Show("Invalid Count ", "Error");
                return;
            }
            if (this.DisplayCount.Tag.ToString()=="")
            {
                XtraMessageBox.Show("Invalid Count ", "Error");
                return;
            }
           
            string query = "update PP_YarnCounts set ";

            if (this.DisplayCount.EditValue != null)
                query += "YarnCount='" + this.DisplayCount.EditValue.ToString() + "'";
            else
                query += "YarnCount=null";
            if (this.EnglishCount.EditValue != null)
                query += ",EnglishCount=" + this.EnglishCount.EditValue.ToString() + "";
            else
                query += ",EnglishCount=null";
           
            if (this.RadioCountType.EditValue != null)
                query += ",CountTypeID=" + this.RadioCountType.EditValue.ToString() + "";
            else
                query += ",CountTypeID=0";
            
           
            
            query += " where YarnCount='"+this.DisplayCount.Tag.ToString()+"'";
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
            if (this.DisplayCount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Count ", "Error");
                return;
            }
            if (this.DisplayCount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Count", "Error");
                return;
            }
            string query = "insert into PP_YarnCounts (CountTypeID,YarnCount,EnglishCount) Values( " + this.RadioCountType.EditValue.ToString() + "";
            if (this.DisplayCount.EditValue != null)
               query += ",'" + this.DisplayCount.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.EnglishCount.EditValue != null)
                query += "," + this.EnglishCount.ToString() + "";
            else
                query += ",0";

           
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
}