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
    public partial class Data_GroupManagement : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;

        public Data_GroupManagement()
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
                   
                    if (this.GroupIndex.Tag != null)
                    {
                        if (this.GroupIndex.Tag.ToString() != "")
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
            this.GroupIndex.Tag = "";
            this.GroupIndex.EditValue=null;;
            this.GroupName.EditValue = null;
            this.MoneyPerUnit.EditValue = null;
            this.ApplyOnUnitsGreaterThan.EditValue = null;
            this.FixedDailyWage.EditValue = null;
            this.Shed.EditValue = "";
            set_ButtonStates(UserInputMode.View);
        }
       

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            DataSet ds = WS.svc.Get_DataSet("select isnull(Max(Convert(numeric,GroupNumber)),0) +1 as GroupIndex from MT_LoomsGroups ");
            try
            {
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        int MaxID = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        this.GroupIndex.Text = MaxID.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            set_ButtonStates(UserInputMode.Add);
            this.GroupName.Focus();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (GroupIndex.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (GroupIndex.Tag.ToString() == "")
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
            if (GroupIndex.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (GroupIndex.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string query = "";
           query= "Delete from MT_LoomsGroups where GroupNumber = " + GroupIndex.Tag.ToString() + "";
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
        private void Fill_GroupData(string GroupIndex)
        {
            try
            {
               DataSet ds= WS.svc.Get_DataSet("Select * from MT_LoomsGroups where GroupNumber='" + GroupIndex + "'");
               if (ds != null)
               {
                   if (ds.Tables[0].Rows.Count > 0)
                   {

                       this.GroupIndex.Tag = ds.Tables[0].Rows[0]["GroupNumber"].ToString();
                       if (ds.Tables[0].Rows[0]["GroupNumber"].ToString() != "")
                       {
                           this.GroupIndex.EditValue = ds.Tables[0].Rows[0]["GroupNumber"].ToString();
                           this.GroupIndex.Tag = ds.Tables[0].Rows[0]["GroupNumber"].ToString();
                       }
                       else
                       {
                           this.GroupIndex.EditValue = null;
                           this.GroupIndex.Tag = null;
                       }

                       if (ds.Tables[0].Rows[0]["GroupName"].ToString() != "")
                           this.GroupName.EditValue = ds.Tables[0].Rows[0]["GroupName"].ToString();
                       else
                           this.GroupName.EditValue = null;
                     
                       if (ds.Tables[0].Rows[0]["WagePerUnit"].ToString() != "")
                           this.MoneyPerUnit.EditValue = ds.Tables[0].Rows[0]["WagePerUnit"].ToString();
                       else
                           this.MoneyPerUnit.EditValue = null;
                       if (ds.Tables[0].Rows[0]["ApplyifUnitsGreaterThan"].ToString() != "")
                           this.ApplyOnUnitsGreaterThan.EditValue = ds.Tables[0].Rows[0]["ApplyIfUnitsGreaterThan"].ToString();
                       else
                           this.ApplyOnUnitsGreaterThan.EditValue = null;
                       if (ds.Tables[0].Rows[0]["FixedDailyWage"].ToString() != "")
                           this.FixedDailyWage.EditValue = ds.Tables[0].Rows[0]["FixedDailyWage"].ToString();
                       else
                           this.FixedDailyWage.EditValue = null;
                       
                       if (ds.Tables[0].Rows[0]["ShedID"].ToString() != "")
                           this.Shed.EditValue = ds.Tables[0].Rows[0]["ShedID"].ToString();
                       else
                           this.Shed.EditValue = null;
                     
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

   

            string Query= "Select * from MT_LoomsGroups order by GroupNumber";
          selectedrow sRow = new selectedrow();
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(Query, "GroupNumber", "GroupNumber");
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
            if (this.GroupIndex.EditValue == null)
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.GroupIndex.Tag == null)
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.GroupIndex.Tag.ToString()=="")
            {
                XtraMessageBox.Show("Invalid AccountID ", "Error");
                return;
            }
            if (this.GroupName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account Name", "Error");
                return;
            }
            string query = "update MT_LoomsGroups set ";

            if (this.GroupIndex.EditValue != null)
                query += "GroupNumber=" + this.GroupIndex.EditValue.ToString() + "";
            else
                query += "GroupNumber=null";
            if (this.GroupName.EditValue != null)
                query += ",GroupName='" + this.GroupName.EditValue.ToString() + "'";
            else
                query += ",GroupName=null";
           
            if (this.MoneyPerUnit.EditValue != null)
                query += ",WagePerUnit=" + this.MoneyPerUnit.EditValue.ToString() + "";
            else
                query += ",WagePerUnit=0";
            if (this.ApplyOnUnitsGreaterThan.EditValue != null)
                query += ",ApplyIfUnitsGreaterThan=" + this.ApplyOnUnitsGreaterThan.EditValue.ToString() + "";
            else
                query += ",ApplyIfUnitsGreaterThan=0";
            if (this.FixedDailyWage.EditValue != null)
                query += ",FixedDailyWage=" + this.FixedDailyWage.EditValue.ToString() + "";
            else
                query += ",FixedDailyWage=0";
            if (this.Shed.Tag != null)
                query += ",ShedID=" + this.Shed.Tag.ToString() + "";
            else
                query += ",ShedID=null";
            
            query += " where GroupNumber="+this.GroupIndex.Tag.ToString()+"";
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
            if (this.GroupIndex.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Group Index ", "Error");
                return;
            }
            if (this.GroupName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Group Name", "Error");
                return;
            }
            string query = "insert into MT_LoomsGroups (GroupNumber,GroupName,ShedID,WagePerUnit,ApplyifUnitsGreaterThan,FixedDailyWage) Values( '" + this.GroupIndex.EditValue.ToString() + "'";
            if (this.GroupName.EditValue != null)
               query += ",'" + this.GroupName.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Shed.Tag != null)
                query += "," + this.Shed.Tag.ToString() + "";
            else
                query += ",0";

            if (this.MoneyPerUnit.EditValue != null)
                query += "," + this.MoneyPerUnit.EditValue.ToString() + "";
            else
                query += ",0";

            if (this.ApplyOnUnitsGreaterThan.EditValue != null)
                query += "," + this.ApplyOnUnitsGreaterThan.EditValue.ToString() + "";
            else
                query += ",0";
            if (this.FixedDailyWage.EditValue != null)
                query += "," + this.FixedDailyWage.EditValue.ToString() + "";
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
      
        private void Shed_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = this.Shed.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
                this.ShedName.ForeColor = Color.Black;
                this.ShedName.BackColor = Color.White;
                this.Shed.ForeColor = Color.Black;
                this.Shed.BackColor = Color.White;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
                this.ShedName.ForeColor = Color.White;
                this.ShedName.BackColor = Color.Red;
                this.Shed.ForeColor = Color.White;
                this.Shed.BackColor = Color.Red;
              
                return;
            }


           
        }
    }
}