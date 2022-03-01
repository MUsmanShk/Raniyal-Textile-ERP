using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Accounts
{
    public partial class Accounts_ChartofAccounts : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        DataRow DataAccountRow_I;
        DataRow DataAccountRow_II;
        DataRow DataAccountRow_III;
        DataRow DataAccountRow_IV;
        DataRow DataAccountRow_V;
        UserInputMode uiMode_Level_I;
        UserInputMode uiMode_Level_II;
        UserInputMode uiMode_Level_III;
        UserInputMode uiMode_Level_IV;
        UserInputMode uiMode_Level_V;
       
      
        public Accounts_ChartofAccounts()
        {
            InitializeComponent();
            Load_Level_I();
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
        }

      
       
        private void Load_Level_I()
        {
            DataSet ds = WS.svc.Get_DataSet("Select AccountID_I,AccountName_I from AC_Level_I order by AccountName_I");
          
                this.gridControl_Control.DataSource = ds.Tables[0];
     

        }
        private void Load_Level_II(string pRefAccountID_I)
        {
            DataSet ds = WS.svc.Get_DataSet("Select AccountID_II,AccountName_II from AC_Level_II where AccountID_I='"+pRefAccountID_I+"' order by AccountName_II");

            this.gridControl_Level_II.DataSource = ds.Tables[0];


        }
        private void Load_Level_III(string pRefAccountID_II)
        {
            DataSet ds = WS.svc.Get_DataSet("Select AccountID_III,AccountName_III from AC_Level_III where AccountID_II='" + pRefAccountID_II + "' order by AccountName_III");

            this.gridControl_Level_III.DataSource = ds.Tables[0];


        }
        private void Load_Level_IV(string pRefAccountID_III)
        {
            DataSet ds = WS.svc.Get_DataSet("Select AccountID_IV,AccountName_IV from AC_Level_IV where AccountID_III='" + pRefAccountID_III + "' order by AccountName_IV");

            this.gridControl_Level_IV.DataSource = ds.Tables[0];


        }
        private void Load_Level_V(string pRefAccountID_IV)
        {
            string s = "Select AccountID_V,AccountName_V,MappedAccountID from AC_Level_V where AccountID_IV='" + pRefAccountID_IV + "' order by AccountName_V";
            DataSet ds = WS.svc.Get_DataSet(s);
            this.gridControl_Level_V.DataSource = ds.Tables[0];
        }
        private void SetButtonStates_Level_I(UserInputMode uim)
        {
            uiMode_Level_I = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Control_Execute.Enabled = false;
                    Control_Cancel.Enabled = false;
                    Control_Add.Enabled = true;

                    


                    if (ControlAccountID.Tag != null)
                    {
                        if (ControlAccountID.Tag.ToString() != "")
                        {

                            Control_Edit.Enabled = true;
                            Control_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            Control_Edit.Enabled = false;
                            Control_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Control_Edit.Enabled = false;
                        Control_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.ControlAccountID.Tag = null;

                    Control_Add.Enabled = false;
                    Control_Cancel.Enabled = true;
                    Control_Execute.Enabled = true;
                    Control_Edit.Enabled = false;

                    
                    Control_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Control_Add.Enabled = false;
                    Control_Cancel.Enabled = true;
                    Control_Execute.Enabled = true;
                    Control_Edit.Enabled = false;

                    Control_Delete.Enabled = false;
                   

                    break;
                case UserInputMode.Delete:
                    Control_Add.Enabled = false;
                    Control_Cancel.Enabled = true;
                    Control_Execute.Enabled = true;
                    Control_Edit.Enabled = false;

                    Control_Delete.Enabled = false;
                   

                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Level_II(UserInputMode uim)
        {
            uiMode_Level_II = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute_II.Enabled = false;
                    Cancel_II.Enabled = false;
                    Add_II.Enabled = true;




                    if (this.AccountID_Level_II.Tag != null)
                    {
                        if (this.AccountID_Level_II.Tag.ToString() != "")
                        {

                            Edit_II.Enabled = true;
                            Delete_II.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit_II.Enabled = false;
                            Delete_II.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit_II.Enabled = false;
                        Delete_II.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.AccountID_Level_II.Tag = null;

                    Add_II.Enabled = false;
                    Cancel_II.Enabled = true;
                    Execute_II.Enabled = true;
                    Edit_II.Enabled = false;


                    Delete_II.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Add_II.Enabled = false;
                    Cancel_II.Enabled = true;
                    Execute_II.Enabled = true;
                    Edit_II.Enabled = false;

                    Delete_II.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_II.Enabled = false;
                    Cancel_II.Enabled = true;
                    Execute_II.Enabled = true;
                    Edit_II.Enabled = false;

                    Delete_II.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Level_III(UserInputMode uim)
        {
            uiMode_Level_III = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute_III.Enabled = false;
                    Cancel_III.Enabled = false;
                    Add_III.Enabled = true;




                    if (this.AccountID_Level_III.Tag != null)
                    {
                        if (this.AccountID_Level_III.Tag.ToString() != "")
                        {

                            Edit_III.Enabled = true;
                            Delete_III.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit_III.Enabled = false;
                            Delete_III.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit_III.Enabled = false;
                        Delete_III.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.AccountID_Level_III.Tag = null;

                    Add_III.Enabled = false;
                    Cancel_III.Enabled = true;
                    Execute_III.Enabled = true;
                    Edit_III.Enabled = false;


                    Delete_III.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Add_III.Enabled = false;
                    Cancel_III.Enabled = true;
                    Execute_III.Enabled = true;
                    Edit_III.Enabled = false;

                    Delete_III.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_III.Enabled = false;
                    Cancel_III.Enabled = true;
                    Execute_III.Enabled = true;
                    Edit_III.Enabled = false;

                    Delete_III.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Level_IV(UserInputMode uim)
        {
            uiMode_Level_IV = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute_IV.Enabled = false;
                    Cancel_IV.Enabled = false;
                    Add_IV.Enabled = true;




                    if (this.AccountID_Level_IV.Tag != null)
                    {
                        if (this.AccountID_Level_IV.Tag.ToString() != "")
                        {

                            Edit_IV.Enabled = true;
                            Delete_IV.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit_IV.Enabled = false;
                            Delete_IV.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit_IV.Enabled = false;
                        Delete_IV.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.AccountID_Level_IV.Tag = null;

                    Add_IV.Enabled = false;
                    Cancel_IV.Enabled = true;
                    Execute_IV.Enabled = true;
                    Edit_IV.Enabled = false;


                    Delete_IV.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Add_IV.Enabled = false;
                    Cancel_IV.Enabled = true;
                    Execute_IV.Enabled = true;
                    Edit_IV.Enabled = false;

                    Delete_IV.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_IV.Enabled = false;
                    Cancel_IV.Enabled = true;
                    Execute_IV.Enabled = true;
                    Edit_IV.Enabled = false;

                    Delete_IV.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Level_V(UserInputMode uim)
        {
            uiMode_Level_V = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute_V.Enabled = false;
                    Cancel_V.Enabled = false;
                    Add_V.Enabled = true;




                    if (this.AccountID_Level_V.Tag != null)
                    {
                        if (this.AccountID_Level_V.Tag.ToString() != "")
                        {

                            Edit_V.Enabled = true;
                            Delete_V.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit_V.Enabled = false;
                            Delete_V.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit_V.Enabled = false;
                        Delete_V.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.AccountID_Level_V.Tag = null;

                    Add_V.Enabled = false;
                    Cancel_V.Enabled = true;
                    Execute_V.Enabled = true;
                    Edit_V.Enabled = false;


                    Delete_V.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Add_V.Enabled = false;
                    Cancel_V.Enabled = true;
                    Execute_V.Enabled = true;
                    Edit_V.Enabled = false;

                    Delete_V.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_V.Enabled = false;
                    Cancel_V.Enabled = true;
                    Execute_V.Enabled = true;
                    Edit_V.Enabled = false;

                    Delete_V.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private bool Get_MaxID_Level_I()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),AccountID_I))+1 as MaxNumber  from AC_Level_I";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 2)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ControlAccountID.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(2, '0');
                    this.ControlAccountID.Text = iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ControlAccountID.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.ControlAccountID.Text = "";
                return false;
            }
        }
        private string ReturnMaxNumber(string Query)
        {
            try
            {
                return WS.svc.Get_MaxNumber(Query);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }     
        private void Save_Level_I_Account()
        {
            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Control Account ID", "Error");
                return;
            }
            if (this.ControlAccountID.Text.Length != 2)
            {
                XtraMessageBox.Show("invalid control ACCOUNT ID ...length must be 3 Characters", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";
           
                vnum = this.ControlAccountID.Text;

           


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Level_I (AccountID_I,AccountName_I) Values (";
            queries[queries.Length - 1] += "'" +  this.ControlAccountID.Text + "'";

            if (this.ControlAccountName.Text != "")
                queries[queries.Length - 1] += ",'" + this.ControlAccountName.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
           
               queries[queries.Length - 1] += ")";

        
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("AccountID_I");
                    dt.Columns.Add("AccountName_I");
                    DataRow _ravi = dt.NewRow();
                    _ravi["AccountID_I"] = this.ControlAccountID.Text;
                    _ravi["AccountName_I"] = this.ControlAccountName.Text;
                    dt.Rows.Add(_ravi);

                    DataView  gdv = (DataView)this.gridView_Control.DataSource;
                    DataTable gdt = gdv.Table;
                    gdt.Merge(dt);
                    this.ControlAccountID.Text = "";
                    this.ControlAccountName.Text = "";
                    
                    SetButtonStates_Level_I(UserInputMode.View);
                    
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Save_Level_II_Account()
        {
            if (this.AccountID_Level_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
            if (this.AccountID_Level_II.Text.Length != 4)
            {
                XtraMessageBox.Show("invalid ACCOUNT ID ...length must be 4 Characters", "Error");
                return;
            }
            if (this.RefAccountID_I.Text=="")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
            if (this.AccountName_Level_II.Text == "")
            {
                XtraMessageBox.Show("invalid Account Name...", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.AccountID_Level_II.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Level_II (AccountID_I,AccountID_II,AccountName_II) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_I.Text + "'";

            if (this.AccountID_Level_II.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountID_Level_II.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.AccountName_Level_II.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountName_Level_II.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ")";

       
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                   
                  
                    DataView gdv = (DataView)this.gridView_Level_II.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["AccountID_II"] = this.AccountID_Level_II.Text;
                    _ravi["AccountName_II"] = this.AccountName_Level_II.Text;
                    gdt.Rows.Add(_ravi);
                    this.AccountName_Level_II.Text = "";
                    this.AccountID_Level_II.Text = "";
                    SetButtonStates_Level_II(UserInputMode.View);
                    this.Add_II.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Save_Level_III_Account()
        {
            if (this.AccountID_Level_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
            if (this.AccountID_Level_III.Text.Length != 7)
            {
                XtraMessageBox.Show("invalid ACCOUNT ID ...length must be 4 Characters", "Error");
                return;
            }
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
            if (this.AccountName_Level_III.Text == "")
            {
                XtraMessageBox.Show("invalid Account Name...", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.AccountID_Level_III.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Level_III (AccountID_II,AccountID_III,AccountName_III) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_II.Text + "'";

            if (this.AccountID_Level_III.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountID_Level_III.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.AccountName_Level_III.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountName_Level_III.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ")";

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    DataView gdv = (DataView)this.gridView_Level_III.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["AccountID_III"] = this.AccountID_Level_III.Text;
                    _ravi["AccountName_III"] = this.AccountName_Level_III.Text;
                    gdt.Rows.Add(_ravi);
                    this.AccountName_Level_III.Text = "";
                    this.AccountID_Level_III.Text = "";
                    SetButtonStates_Level_III(UserInputMode.View);
                    this.Add_III.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Save_Level_IV_Account()
        {
            if (this.AccountID_Level_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
            if (this.AccountID_Level_IV.Text.Length != 10)
            {
                XtraMessageBox.Show("invalid ACCOUNT ID ...length must be 4 Characters", "Error");
                return;
            }
            if (this.RefAccountID_III.Text == "")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
            if (this.AccountName_Level_IV.Text == "")
            {
                XtraMessageBox.Show("invalid Account Name...", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.AccountID_Level_IV.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Level_IV (AccountID_III,AccountID_IV,AccountName_IV) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_III.Text + "'";

            if (this.AccountID_Level_IV.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountID_Level_IV.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.AccountName_Level_IV.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountName_Level_IV.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ")";

     
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    DataView gdv = (DataView)this.gridView_Level_IV.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["AccountID_IV"] = this.AccountID_Level_IV.Text;
                    _ravi["AccountName_IV"] = this.AccountName_Level_IV.Text;
                    gdt.Rows.Add(_ravi);
                    this.AccountName_Level_IV.Text = "";
                    this.AccountID_Level_IV.Text = "";
                    SetButtonStates_Level_IV(UserInputMode.View);
                    this.Add_IV.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Save_Level_V_Account()
        {
            if (this.AccountID_Level_V.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
            if (this.AccountID_Level_V.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid ACCOUNT ID ...length must be 4 Characters", "Error");
                return;
            }
            if (this.RefAccountID_IV.Text == "")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
            if (this.AccountName_Level_V.Text == "")
            {
                XtraMessageBox.Show("invalid Account Name...", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.AccountID_Level_V.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Level_V (AccountID_IV,AccountID_V,AccountName_V,MappedAccountID) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_IV.Text + "'";

            if (this.AccountID_Level_V.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountID_Level_V.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.AccountName_Level_V.Text != "")
                queries[queries.Length - 1] += ",'" + this.AccountName_Level_V.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.MappedAccountID.EditValue!=null)
                queries[queries.Length - 1] += ",'" + this.MappedAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ")";

        
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    DataView gdv = (DataView)this.gridView_Level_V.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["AccountID_V"] = this.AccountID_Level_V.Text;
                    _ravi["AccountName_V"] = this.AccountName_Level_V.Text;
                    if (this.MappedAccountID.EditValue != null)
                        _ravi["MappedAccountID"] = this.MappedAccountID.EditValue.ToString();
                    gdt.Rows.Add(_ravi);
                    this.AccountName_Level_V.Text = "";
                    this.AccountID_Level_V.Text = "";
                    this.MappedAccountID.EditValue = null;
                    this.MappedAccountName.EditValue = null;
                    SetButtonStates_Level_V(UserInputMode.View);
                    this.Add_V.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Update_Level_I_Account()
        {
            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlAccountID.Tag ==null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }

            if (this.ControlAccountID.Text.Length != 2)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
    
            string[] queries = new string[0];
           
            string CodeToUpdate = this.ControlAccountID.Tag.ToString();

        

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Level_I set ";
            queries[queries.Length - 1] += " AccountID_I='" + this.ControlAccountID.Text + "' ";
          


            if (this.ControlAccountName.Text!="")
                queries[queries.Length - 1] += ",AccountName_I='" + this.ControlAccountName.Text  + "'";
            else
                queries[queries.Length - 1] += ",AccountName_I=null";
            
            queries[queries.Length - 1] += " where AccountID_I='" + CodeToUpdate + "'";

     
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataAccountRow_I["AccountID_I"] = this.ControlAccountID.Text;
                    DataAccountRow_I["AccountName_I"] = this.ControlAccountName.Text;
                  
                    this.ControlAccountID.Text = "";
                    this.ControlAccountID.Tag = null;
                 
                    this.ControlAccountName.Text = "";
                    SetButtonStates_Level_I(UserInputMode.View);
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Update_Level_II_Account()
        {
            if (this.RefAccountID_I.Text == "")
            {
                XtraMessageBox.Show("Invalid Referenced Account ID  ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_II.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_II.Text.Length != 4)
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.AccountID_Level_II.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
          
            string CodeToUpdate = this.AccountID_Level_II.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Level_II set ";
            queries[queries.Length - 1] += " AccountID_I='" + this.RefAccountID_I.Text + "' ";

            if (this.AccountID_Level_II.Text != "")
                queries[queries.Length - 1] += ",AccountID_II='" + this.AccountID_Level_II.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountID_II=null";

            if (this.AccountName_Level_II.Text != "")
                queries[queries.Length - 1] += ",AccountName_II='" + this.AccountName_Level_II.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountName_II=null";

            queries[queries.Length - 1] += " where AccountID_II='" + CodeToUpdate + "'";

         
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataAccountRow_II["AccountID_II"] = this.AccountID_Level_II.Text;
                    DataAccountRow_II["AccountName_II"] = this.AccountName_Level_II.Text;

                    this.AccountName_Level_II.Text = "";
                    this.AccountID_Level_II.Tag = null;

                    this.AccountID_Level_II.Text = "";
                    SetButtonStates_Level_II(UserInputMode.View);
                    this.Add_II.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Update_Level_III_Account()
        {
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Referenced Account ID  ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_III.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_III.Text.Length != 7)
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.AccountID_Level_III.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
          
            string CodeToUpdate = this.AccountID_Level_III.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Level_III set ";
            queries[queries.Length - 1] += " AccountID_II='" + this.RefAccountID_II.Text + "' ";

            if (this.AccountID_Level_III.Text != "")
                queries[queries.Length - 1] += ",AccountID_III='" + this.AccountID_Level_III.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountID_III=null";

            if (this.AccountName_Level_III.Text != "")
                queries[queries.Length - 1] += ",AccountName_III='" + this.AccountName_Level_III.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountName_III=null";

            queries[queries.Length - 1] += " where AccountID_III='" + CodeToUpdate + "'";

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataAccountRow_III["AccountID_III"] = this.AccountID_Level_III.Text;
                    DataAccountRow_III["AccountName_III"] = this.AccountName_Level_III.Text;

                    this.AccountName_Level_III.Text = "";
                    this.AccountID_Level_III.Tag = null;

                    this.AccountID_Level_III.Text = "";
                    SetButtonStates_Level_III(UserInputMode.View);
                    this.Add_III.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Update_Level_IV_Account()
        {
            if (this.RefAccountID_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Referenced Account ID  ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_IV.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_IV.Text.Length != 10)
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.AccountID_Level_IV.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
           
            string CodeToUpdate = this.AccountID_Level_IV.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Level_IV set ";
            queries[queries.Length - 1] += " AccountID_III='" + this.RefAccountID_III.Text + "' ";

            if (this.AccountID_Level_IV.Text != "")
                queries[queries.Length - 1] += ",AccountID_IV='" + this.AccountID_Level_IV.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountID_IV=null";

            if (this.AccountName_Level_IV.Text != "")
                queries[queries.Length - 1] += ",AccountName_IV='" + this.AccountName_Level_IV.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountName_IV=null";

            queries[queries.Length - 1] += " where AccountID_IV='" + CodeToUpdate + "'";

   
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataAccountRow_IV["AccountID_IV"] = this.AccountID_Level_IV.Text;
                    DataAccountRow_IV["AccountName_IV"] = this.AccountName_Level_IV.Text;

                    this.AccountName_Level_IV.Text = "";
                    this.AccountID_Level_IV.Tag = null;

                    this.AccountID_Level_IV.Text = "";
                    SetButtonStates_Level_IV(UserInputMode.View);
                    this.Add_IV.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Update_Level_V_Account()
        {
            if (this.RefAccountID_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Referenced Account ID  ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_V.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_V.Text.Length != 13)
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.AccountID_Level_V.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
          
            string CodeToUpdate = this.AccountID_Level_V.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Level_V set ";
            queries[queries.Length - 1] += " AccountID_IV='" + this.RefAccountID_IV.Text + "' ";

            if (this.AccountID_Level_V.Text != "")
                queries[queries.Length - 1] += ",AccountID_V='" + this.AccountID_Level_V.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountID_V=null";

            if (this.AccountName_Level_V.Text != "")
                queries[queries.Length - 1] += ",AccountName_V='" + this.AccountName_Level_V.Text + "'";
            else
                queries[queries.Length - 1] += ",AccountName_V=null";
            if (this.MappedAccountID.EditValue!=null)
                queries[queries.Length - 1] += ",MappedAccountID='" + this.MappedAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",MappedAccountID=null";
            queries[queries.Length - 1] += " where AccountID_V='" + CodeToUpdate + "'";

         
            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataAccountRow_V["AccountID_V"] = this.AccountID_Level_V.Text;
                    DataAccountRow_V["AccountName_V"] = this.AccountName_Level_V.Text;
                    if (this.MappedAccountID.EditValue != null) DataAccountRow_V["MappedAccountID"] = this.MappedAccountID.EditValue.ToString();
                    else
                        DataAccountRow_V["MappedAccountID"] = "";
                    this.AccountName_Level_V.Text = "";
                    this.AccountID_Level_V.Tag = null;
                    this.MappedAccountID.EditValue = null;
                    this.MappedAccountName.EditValue = null;
                    this.AccountID_Level_V.Text = "";
                    SetButtonStates_Level_V(UserInputMode.View);
                    this.Add_V.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void Delete_Level_I_Account()
        {





            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ControlAccountID.Text.Length != 2)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           

            string[] queries = new string[0];
            string GRNtoUpdate = this.ControlAccountID.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Control Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Level_I where AccountID_I='" + GRNtoUpdate + "'";
           

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.ControlAccountID.Tag = null;
                    this.ControlAccountName.Text = "";
                    this.ControlAccountID.Text = "";
                    
                    gridView_Control.DeleteRow(this.gridView_Control.FocusedRowHandle);
                    SetButtonStates_Level_I(UserInputMode.View);
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Delete_Level_II_Account()
        {





          
            if (this.AccountID_Level_II.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

          
            if (this.AccountID_Level_II.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.AccountID_Level_II.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Level_II where AccountID_II='" + GRNtoUpdate + "'";
         

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.AccountID_Level_II.Tag = null;
                    this.AccountID_Level_II.Text = "";
                    this.AccountName_Level_II.Text = "";

                    this.gridView_Level_II.DeleteRow(this.gridView_Level_II.FocusedRowHandle);
                    SetButtonStates_Level_II(UserInputMode.View);
                    this.Add_II.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Delete_Level_III_Account()
        {






            if (this.AccountID_Level_III.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (this.AccountID_Level_III.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.AccountID_Level_III.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Level_III where AccountID_III='" + GRNtoUpdate + "'";
           

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.AccountID_Level_III.Tag = null;
                    this.AccountID_Level_III.Text = "";
                    this.AccountName_Level_III.Text = "";

                    this.gridView_Level_III.DeleteRow(this.gridView_Level_III.FocusedRowHandle);
                    SetButtonStates_Level_III(UserInputMode.View);
                    this.Add_III.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Delete_Level_IV_Account()
        {






            if (this.AccountID_Level_IV.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (this.AccountID_Level_IV.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.AccountID_Level_IV.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Level_IV where AccountID_IV='" + GRNtoUpdate + "'";
         

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.AccountID_Level_IV.Tag = null;
                    this.AccountID_Level_IV.Text = "";
                    this.AccountName_Level_IV.Text = "";

                    this.gridView_Level_IV.DeleteRow(this.gridView_Level_IV.FocusedRowHandle);
                    SetButtonStates_Level_IV(UserInputMode.View);
                    this.Add_IV.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Delete_Level_V_Account()
        {






            if (this.AccountID_Level_V.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (this.AccountID_Level_V.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.AccountID_Level_V.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from AC_Level_V where AccountID_V='" + GRNtoUpdate + "'";
         

            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {

                    this.AccountID_Level_V.Tag = null;
                    this.AccountID_Level_V.Text = "";
                    this.AccountName_Level_V.Text = "";
                    this.MappedAccountName.EditValue = null;
                    this.MappedAccountID.EditValue = null;
                    this.gridView_Level_V.DeleteRow(this.gridView_Level_V.FocusedRowHandle);
                    SetButtonStates_Level_V(UserInputMode.View);
                    this.Add_V.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Fill_Level_I_Row()
        {
            if (this.gridView_Control.FocusedRowHandle != -1)
            {
                DataAccountRow_I = this.gridView_Control.GetDataRow(this.gridView_Control.FocusedRowHandle);
                if (DataAccountRow_I != null)
                {
                    this.ControlAccountID.Text = DataAccountRow_I["AccountID_I"].ToString();
                    this.ControlAccountName.Text = DataAccountRow_I["AccountName_I"].ToString();
                    this.ControlAccountID.Tag = DataAccountRow_I["AccountID_I"].ToString();
                    this.RefAccountID_I.Text = DataAccountRow_I["AccountID_I"].ToString();
                    this.RefAccountName_I.Text = DataAccountRow_I["AccountName_I"].ToString();
                    

                    SetButtonStates_Level_I(UserInputMode.View);
                }
            }
        }
        private void Fill_Level_II_Row()
        {
            if (this.gridView_Level_II.FocusedRowHandle != -1)
            {
                DataAccountRow_II = this.gridView_Level_II.GetDataRow(this.gridView_Level_II.FocusedRowHandle);
                if (DataAccountRow_II != null)
                {
                    
                    this.AccountID_Level_II.Text = DataAccountRow_II["AccountID_II"].ToString();
                    this.AccountName_Level_II.Text = DataAccountRow_II["AccountName_II"].ToString();
                    this.AccountID_Level_II.Tag = DataAccountRow_II["AccountID_II"].ToString();
                    this.RefAccountID_II.Text = DataAccountRow_II["AccountID_II"].ToString();
                    this.RefAccountName_II.Text = DataAccountRow_II["AccountName_II"].ToString();


                    SetButtonStates_Level_II(UserInputMode.View);
                }
            }
        }
        private void Fill_Level_III_Row()
        {
            if (this.gridView_Level_III.FocusedRowHandle != -1)
            {
                DataAccountRow_III = this.gridView_Level_III.GetDataRow(this.gridView_Level_III.FocusedRowHandle);
                if (DataAccountRow_III != null)
                {
                    this.AccountID_Level_III.Text = DataAccountRow_III["AccountID_III"].ToString();
                    this.AccountName_Level_III.Text = DataAccountRow_III["AccountName_III"].ToString();
                    this.AccountID_Level_III.Tag = DataAccountRow_III["AccountID_III"].ToString();
                    this.RefAccountID_III.Text = DataAccountRow_III["AccountID_III"].ToString();
                    this.RefAccountName_III.Text = DataAccountRow_III["AccountName_III"].ToString();


                    SetButtonStates_Level_III(UserInputMode.View);
                }
            }
        }
        private void Fill_Level_IV_Row()
        {
            if (this.gridView_Level_IV.FocusedRowHandle != -1)
            {
                DataAccountRow_IV= this.gridView_Level_IV.GetDataRow(this.gridView_Level_IV.FocusedRowHandle);
                if (DataAccountRow_IV != null)
                {
                    this.AccountID_Level_IV.Text = DataAccountRow_IV["AccountID_IV"].ToString();
                    this.AccountName_Level_IV.Text = DataAccountRow_IV["AccountName_IV"].ToString();
                    this.AccountID_Level_IV.Tag = DataAccountRow_IV["AccountID_IV"].ToString();
                    this.RefAccountID_IV.Text = DataAccountRow_IV["AccountID_IV"].ToString();
                    this.RefAccountName_IV.Text = DataAccountRow_IV["AccountName_IV"].ToString();


                    SetButtonStates_Level_IV(UserInputMode.View);
                }
            }
        }
        private void Fill_Level_V_Row()
        {
            if (this.gridView_Level_V.FocusedRowHandle != -1)
            {
                DataAccountRow_V = this.gridView_Level_V.GetDataRow(this.gridView_Level_V.FocusedRowHandle);
                if (DataAccountRow_V != null)
                {
                    this.AccountID_Level_V.Text = DataAccountRow_V["AccountID_V"].ToString();
                    this.AccountName_Level_V.Text = DataAccountRow_V["AccountName_V"].ToString();
                    this.AccountID_Level_V.Tag = DataAccountRow_V["AccountID_V"].ToString();
                    if (DataAccountRow_V["MappedAccountID"].ToString() != "")
                    {
                        this.MappedAccountID.EditValue = DataAccountRow_V["MappedAccountID"].ToString();
                       //this.MappedAccountName.EditValue = DataAccountRow_V["MappedAccountName"].ToString();
                    }
                    else
                    {
                        
                        this.MappedAccountID.EditValue = null;
                    }
                    SetButtonStates_Level_V(UserInputMode.View);
                }
            }
        }
        private void gridView_Control_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            Fill_Level_I_Row();
        }
        
        private void Control_Add_Click(object sender, EventArgs e)
        {
            this.ControlAccountID.Text = "";
            this.ControlAccountID.Tag = null;
            this.ControlAccountID.EditValue = null;
            bool rRes = Get_MaxID_Level_I();


            SetButtonStates_Level_I(UserInputMode.Add);
        }

        private void Control_Execute_Click(object sender, EventArgs e)
        {
            if (uiMode_Level_I == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Save_Level_I_Account();
            }
            else if (uiMode_Level_I == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit,docState.Open);
                if (canProceed == false)
                {
                     XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                     return;
                }
                Update_Level_I_Account();
            }
            else if (uiMode_Level_I == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Level_I_Account();
            }
        }

        private void Control_Edit_Click(object sender, EventArgs e)
        {

            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ControlAccountID.Text.Length != 2)
            {
                XtraMessageBox.Show("Level I is invalid ...must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_I(UserInputMode.Edit);
        }

        private void Control_Delete_Click(object sender, EventArgs e)
        {
            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ControlAccountID.Text.Length != 2)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_I(UserInputMode.Delete);
        }

        private void Control_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_I(UserInputMode.View);
        }

        private void Goto_Level_II_Click(object sender, EventArgs e)
        {
            if (RefAccountID_I.Text == "")
                return;
            if (RefAccountName_I.Text == "")
                return;
            if (DataAccountRow_I == null) return;
            xtraTabPage_II.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_II;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
            Load_Level_II(this.RefAccountID_I.Text);
        }

        private void Goto_Level_III_Click(object sender, EventArgs e)
        {
            if (RefAccountID_II.Text == "")
                return;
            if (RefAccountName_II.Text == "")
                return;
            if (DataAccountRow_II == null) return;
            xtraTabPage_III.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_III;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
            Load_Level_III(this.RefAccountID_II.Text);
        }

        private void Goto_Level_IV_Click(object sender, EventArgs e)
        {
            if (RefAccountID_III.Text == "")
                return;
            if (RefAccountName_III.Text == "")
                return;
            if (DataAccountRow_III == null) return;
            xtraTabPage_IV.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_IV;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
            Load_Level_IV(this.RefAccountID_III.Text);
        }

        private void Goto_Level_V_Click(object sender, EventArgs e)
        {
            if (RefAccountID_IV.Text == "")
                return;
            if (RefAccountName_IV.Text == "")
                return;
            if (DataAccountRow_IV == null) return;
            xtraTabPage_V.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_V;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            Load_Level_V(this.RefAccountID_IV.Text);
        }

        private void Goto_Level_I_Click(object sender, EventArgs e)
        {
           
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
        }

        private void Backto_Level_IV_Click(object sender, EventArgs e)
        {
            DataAccountRow_V = null;
            xtraTabPage_IV.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_IV;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
        }

        private void Backto_Level_III_Click(object sender, EventArgs e)
        {
            xtraTabPage_III.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_III;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
            DataAccountRow_IV = null;
        }

        private void Backto_Level_II_Click(object sender, EventArgs e)
        {
            xtraTabPage_II.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_II;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
            DataAccountRow_III = null;
        }

        private void Backto_Level_I_Click(object sender, EventArgs e)
        {
            DataAccountRow_II = null;
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
            xtraTabPage_IV.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_V.PageEnabled = false;
        }

        private void gridView_Control_DoubleClick(object sender, EventArgs e)
        {
            Goto_Level_II_Click(sender, e);
        }

        private void gridView_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_II_Click(sender, e);
        }

        private void gridView_Level_II_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Fill_Level_II_Row();
        }

        private void gridView_Level_III_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Fill_Level_III_Row();
        }

        private void gridView_Level_IV_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Fill_Level_IV_Row();
        }

        private void gridView_Level_V_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Fill_Level_V_Row();
        }

        private void gridView_Level_II_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_III_Click(sender, e);
        }

        private void gridView_Level_III_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_IV_Click(sender, e);
        }

        private void gridView_Level_IV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_V_Click(sender, e);
        }

        private void gridView_Level_V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_I_Click(sender, e);
        }

        private void gridView_Level_II_DoubleClick(object sender, EventArgs e)
        {
            
                Goto_Level_III_Click(sender, e);
        }

        private void gridView_Level_III_DoubleClick(object sender, EventArgs e)
        {
            Goto_Level_IV_Click(sender, e);
        }

        private void gridView_Level_IV_DoubleClick(object sender, EventArgs e)
        {
            Goto_Level_V_Click(sender, e);
        }

        private void Add_II_Click(object sender, EventArgs e)
        {
            this.AccountID_Level_II.Text = "";
            this.AccountID_Level_II.Tag = null;
            this.AccountName_Level_II.Text = "";
            SetButtonStates_Level_II(UserInputMode.Add);
            string mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_II,3,4)))+1 as MaxNumber  from AC_Level_II where AccountID_I='" +this.RefAccountID_I.Text + "'");
            if (mAccountID == "") return;
            mAccountID = this.RefAccountID_I.Text + mAccountID.PadLeft(2, '0');
            this.AccountID_Level_II.Text = mAccountID;
        }

        private void Add_III_Click(object sender, EventArgs e)
        {
            this.AccountID_Level_III.Text = "";
            this.AccountID_Level_III.Tag = null;
            this.AccountName_Level_III.Text = "";
            SetButtonStates_Level_III(UserInputMode.Add);
            string mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_III,5,7)))+1 as MaxNumber  from AC_Level_III where AccountID_II='" + this.RefAccountID_II.Text + "'");
            if (mAccountID == "") return;
            mAccountID = this.RefAccountID_II.Text + mAccountID.PadLeft(3, '0');
            this.AccountID_Level_III.Text = mAccountID;
        }

        private void Add_IV_Click(object sender, EventArgs e)
        {
            this.AccountID_Level_IV.Text = "";
            this.AccountID_Level_IV.Tag = null;
            this.AccountName_Level_IV.Text = "";
            SetButtonStates_Level_IV(UserInputMode.Add);
            string mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_IV,8,10)))+1 as MaxNumber  from AC_Level_IV where AccountID_III='" + this.RefAccountID_III.Text + "'");
            if (mAccountID == "") return;
            mAccountID = this.RefAccountID_III.Text + mAccountID.PadLeft(3, '0');
            this.AccountID_Level_IV.Text = mAccountID;
        }

        private void Add_V_Click(object sender, EventArgs e)
        {
            this.AccountID_Level_V.Text = "";
            this.AccountID_Level_V.Tag = null;
            this.AccountName_Level_V.Text = "";
            this.MappedAccountID.EditValue = null;
            SetButtonStates_Level_V(UserInputMode.Add);
            string mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_V,11,13)))+1 as MaxNumber  from AC_Level_V where AccountID_IV='" + this.RefAccountID_IV.Text + "'");
            if (mAccountID == "") return;
            mAccountID = this.RefAccountID_IV.Text + mAccountID.PadLeft(3, '0');
            this.AccountID_Level_V.Text = mAccountID;
            this.AccountName_Level_V.Focus();
        }

        private void Edit_II_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_I.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_II.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_II.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_II(UserInputMode.Edit);
        }

        private void Edit_III_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_III.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_III.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_III(UserInputMode.Edit);
        }

        private void Edit_IV_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_IV.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_IV.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_IV(UserInputMode.Edit);
        }

        private void Edit_V_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_V.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_V.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_V.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_V(UserInputMode.Edit);
        }

        private void Delete_II_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_I.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_II.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_II.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_II(UserInputMode.Delete);
        }

        private void Delete_III_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_III.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_III.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_III(UserInputMode.Delete);
        }

        private void Delete_IV_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_III.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_IV.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_IV.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_IV(UserInputMode.Delete);
        }

        private void Delete_V_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_V.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_IV.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.AccountID_Level_V.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_V.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_V(UserInputMode.Delete);
        }

        private void Cancel_II_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_II(UserInputMode.View);
        }

        private void Cancel_III_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_III(UserInputMode.View);
        }

        private void Cancel_IV_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_IV(UserInputMode.View);
        }

        private void Cancel_V_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_V(UserInputMode.View);
        }

        private void Execute_II_Click(object sender, EventArgs e)
        {
            if (uiMode_Level_II == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Save_Level_II_Account();
            }
            else if (uiMode_Level_II == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Update_Level_II_Account();
            }
            else if (uiMode_Level_II == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Level_II_Account();
            }
        }

        private void Execute_III_Click(object sender, EventArgs e)
        {
            if (uiMode_Level_III == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Save_Level_III_Account();
            }
            else if (uiMode_Level_III == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Update_Level_III_Account();
            }
            else if (uiMode_Level_III == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Level_III_Account();
            }
        }

        private void Execute_IV_Click(object sender, EventArgs e)
        {
            if (uiMode_Level_IV == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Save_Level_IV_Account();
            }
            else if (uiMode_Level_IV == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Update_Level_IV_Account();
            }
            else if (uiMode_Level_IV == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Level_IV_Account();
            }
        }

        private void Execute_V_Click(object sender, EventArgs e)
        {
            if (uiMode_Level_V == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Save_Level_V_Account();
            }
            else if (uiMode_Level_V == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Update_Level_V_Account();
            }
            else if (uiMode_Level_V == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Delete_Level_V_Account();
            }
        }

        private void MappedAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();

                Data.Data_Accounts_View AView = new Data.Data_Accounts_View();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.MappedAccountID.EditValue = sRow.PrimeryID;
                        this.MappedAccountName.Text = sRow.PrimaryString;

                    }
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.MappedAccountID.EditValue = null;
                this.MappedAccountName.EditValue = null;

            }
        }

        private void MappedAccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.MappedAccountID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.MappedAccountID.EditValue.ToString());
                if (mAcID != "")
                    this.MappedAccountName.EditValue = mAcID;
                else
                    this.MappedAccountName.EditValue = null;
            }
            else
            {
                this.MappedAccountName.EditValue = null;
            }
        }

        private void TransferFromAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.TransferFromAccount.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                    this.TransferFromAccount.Tag  = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.TransferFromAccount.Tag = null;
                this.TransferFromAccount.EditValue = null;
            }
        }

        private void TransferAccount_Click(object sender, EventArgs e)
        {
            if (this.AccountID_Level_V.Tag==null)
            {
                XtraMessageBox.Show("Invalid Account ID   ....ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.AccountID_Level_V.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID   ....ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.TransferFromAccount.Tag == null)
            {
                XtraMessageBox.Show("Invalid Transferable Account ID   ....ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.TransferFromAccount.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Transferable Account ID   ....ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to transfer all related data from \n " + this.TransferFromAccount.Tag.ToString() + "   " + this.TransferFromAccount.EditValue.ToString() + " \n to \n " + this.AccountID_Level_V.Tag.ToString() + "   " + this.AccountName_Level_V.EditValue.ToString() + " ?", "Transfer Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 0);
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Voucher_Sub set AccountID_V='" + this.AccountID_Level_V.Tag.ToString() + "' where AccountID_V='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Sales_Sub set AccountID='" + this.AccountID_Level_V.Tag.ToString() + "' where AccountID='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Purchases_Sub set AccountID='" + this.AccountID_Level_V.Tag.ToString() + "' where AccountID='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StorePR set AccountID='" + this.AccountID_Level_V.Tag.ToString() + "' where AccountID='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_PaymentAdvice_Sub set AccountID_V='" + this.AccountID_Level_V.Tag.ToString() + "' where AccountID_V='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Sales_Main set BuyerID='" + this.AccountID_Level_V.Tag.ToString() + "' where BuyerID='" + this.TransferFromAccount.Tag.ToString() + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update AC_Purchases_Main set SupplierID='" + this.AccountID_Level_V.Tag.ToString() + "' where SupplierID='" + this.TransferFromAccount.Tag.ToString() + "'";
            try
            {
                string res = WS.svc.Execute_Transaction(queries);
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.TransferFromAccount.EditValue = null;
                    this.TransferFromAccount.Tag = null;
                    this.AccountID_Level_V.EditValue = null;
                    this.AccountID_Level_V.Tag = null;
                    this.AccountName_Level_V.EditValue = null;

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AccountName_Level_V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountName_Level_V.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                }
            }
        }

      

      
     
        
    }
}