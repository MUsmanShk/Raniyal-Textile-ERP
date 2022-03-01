using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Store
{
    public partial class Store_ChartofLocations: DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        DataRow DataAccountRow_I;
        DataRow DataAccountRow_II;
        DataRow DataAccountRow_III;
        
        UserInputMode uiMode_Level_I;
        UserInputMode uiMode_Level_II;
        UserInputMode uiMode_Level_III;

      
        public Store_ChartofLocations()
        {
            InitializeComponent();
            Load_Level_I();
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
   
        }

      
       
        private void Load_Level_I()
        {
            DataSet ds = WS.svc.Get_DataSet("Select ControlLocation,ControlLocationDesc from ST_Locations_Control order by ControlLocation");
          
                this.gridControl_Control.DataSource = ds.Tables[0];
     

        }
        private void Load_Level_II(string pRefAccountID_I)
        {
            DataSet ds = WS.svc.Get_DataSet("Select GroupLocation,GroupLocationDesc from ST_Locations_Group where ControlLocation='"+pRefAccountID_I+"' order by GroupLocation");

            this.gridControl_Level_II.DataSource = ds.Tables[0];


        }
        private void Load_Level_III(string pRefAccountID_II)
        {
            DataSet ds = WS.svc.Get_DataSet("Select ItemLocation,ItemLocationDesc from ST_Locations_Item where GroupLocation='" + pRefAccountID_II + "' order by ItemLocation");

            this.gridControl_Level_III.DataSource = ds.Tables[0];


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

                    


                    if (ControlLocation.Tag != null)
                    {
                        if (ControlLocation.Tag.ToString() != "")
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
                    this.ControlLocation.Tag = null;

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




                    if (this.GroupLocation.Tag != null)
                    {
                        if (this.GroupLocation.Tag.ToString() != "")
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
                    this.GroupLocation.Tag = null;

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




                    if (this.ItemLocation.Tag != null)
                    {
                        if (this.ItemLocation.Tag.ToString() != "")
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
                    this.ItemLocation.Tag = null;

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
      
        private bool Get_MaxID_Level_I()
        {
            return true;
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
            if (this.ControlLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Control Lcoation", "Error");
                return;
            }
           
            string[] queries = new string[0];
            string vnum = "";
           
                vnum = this.ControlLocation.Text;

           


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_Locations_Control (ControlLocation,ControlLocationDesc) Values (";
            queries[queries.Length - 1] += "'" +  this.ControlLocation.Text + "'";

            if (this.ControlLocationDesc.Text != "")
                queries[queries.Length - 1] += ",'" + this.ControlLocationDesc.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
           
               queries[queries.Length - 1] += ")";

         
            try
            {
                string tResult = WS.svc.Execute_Query(queries[0]);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Clear();
                    dt.Columns.Add("ControlLocation");
                    dt.Columns.Add("ControlLocationDesc");
                    DataRow _ravi = dt.NewRow();
                    _ravi["ControlLocation"] = this.ControlLocation.Text;
                    _ravi["ControlLocationDesc"] = this.ControlLocationDesc.Text;
                    dt.Rows.Add(_ravi);

                    DataView  gdv = (DataView)this.gridView_Control.DataSource;
                    DataTable gdt = gdv.Table;
                    gdt.Merge(dt);
                    this.ControlLocation.Text = "";
                    this.ControlLocationDesc.Text = "";
                    
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
            if (this.GroupLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
           
            if (this.RefAccountID_I.Text=="")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
          
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.GroupLocation.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_Locations_Group (ControlLocation,GroupLocation,GroupLocationDesc) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_I.Text + "'";

            if (this.GroupLocation.Text != "")
                queries[queries.Length - 1] += ",'" + this.GroupLocation.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.GroupLocationDesc.Text != "")
                queries[queries.Length - 1] += ",'" + this.GroupLocationDesc.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ")";

           
            try
            {
                string tResult = WS.svc.Execute_Query(queries[0]);
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
                    _ravi["GroupLocation"] = this.GroupLocation.Text;
                    _ravi["GroupLocationDesc"] = this.GroupLocationDesc.Text;
                    gdt.Rows.Add(_ravi);
                    this.GroupLocationDesc.Text = "";
                    this.GroupLocation.Text = "";
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
            if (this.ItemLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                return;
            }
           
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("invalid Ref AccountID ...", "Error");
                return;
            }
           
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.ItemLocation.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_Locations_Item (GroupLocation,ItemLocation,ItemLocationDesc) Values (";
            queries[queries.Length - 1] += "'" + this.RefAccountID_II.Text + "'";

            if (this.ItemLocation.Text != "")
                queries[queries.Length - 1] += ",'" + this.ItemLocation.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.ItemLocationDesc.Text != "")
                queries[queries.Length - 1] += ",'" + this.ItemLocationDesc.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ")";

          
            try
            {
                string tResult = WS.svc.Execute_Query(queries[0]);
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
                    _ravi["ItemLocation"] = this.ItemLocation.Text;
                    _ravi["ItemLocationDesc"] = this.ItemLocationDesc.Text;
                    gdt.Rows.Add(_ravi);
                    this.ItemLocationDesc.Text = "";
                    this.ItemLocation.Text = "";
                    SetButtonStates_Level_III(UserInputMode.View);
                    this.Add_III.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
   
        private void Update_Level_I_Account()
        {
            if (this.ControlLocation.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlLocation.Tag ==null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                return;
            }

          
            if (this.ControlLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
    
            string[] queries = new string[0];
           
            string CodeToUpdate = this.ControlLocation.Tag.ToString();

        

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_Locations_Control set ";
            queries[queries.Length - 1] += " ControlLocation='" + this.ControlLocation.Text + "' ";
          


            if (this.ControlLocationDesc.Text!="")
                queries[queries.Length - 1] += ",ControlLocationDesc='" + this.ControlLocationDesc.Text  + "'";
            else
                queries[queries.Length - 1] += ",ControlLocationDesc=null";
            
            queries[queries.Length - 1] += " where ControlLocation='" + CodeToUpdate + "'";

    
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
                    DataAccountRow_I["ControlLocation"] = this.ControlLocation.Text;
                    DataAccountRow_I["ControlLocationDesc"] = this.ControlLocationDesc.Text;
                  
                    this.ControlLocation.Text = "";
                    this.ControlLocation.Tag = null;
                 
                    this.ControlLocationDesc.Text = "";
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
            if (this.GroupLocation.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

         
            if (this.GroupLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
           
            string CodeToUpdate = this.GroupLocation.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_Locations_Group set ";
            queries[queries.Length - 1] += " ControlLocation='" + this.RefAccountID_I.Text + "' ";

            if (this.GroupLocation.Text != "")
                queries[queries.Length - 1] += ",GroupLocation='" + this.GroupLocation.Text + "'";
            else
                queries[queries.Length - 1] += ",GroupLocation=null";

            if (this.GroupLocationDesc.Text != "")
                queries[queries.Length - 1] += ",GroupLocationDesc='" + this.GroupLocationDesc.Text + "'";
            else
                queries[queries.Length - 1] += ",GroupLocationDesc=null";

            queries[queries.Length - 1] += " where GroupLocation='" + CodeToUpdate + "'";

  
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
                    DataAccountRow_II["GroupLocation"] = this.GroupLocation.Text;
                    DataAccountRow_II["GroupLocationDesc"] = this.GroupLocationDesc.Text;

                    this.GroupLocationDesc.Text = "";
                    this.GroupLocation.Tag = null;

                    this.GroupLocation.Text = "";
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
            if (this.ItemLocation.Tag == null)
            {
                XtraMessageBox.Show("Account id is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

          
            if (this.ItemLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
          
            string CodeToUpdate = this.ItemLocation.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_Locations_Item set ";
            queries[queries.Length - 1] += " GroupLocation='" + this.RefAccountID_II.Text + "' ";

            if (this.ItemLocation.Text != "")
                queries[queries.Length - 1] += ",ItemLocation='" + this.ItemLocation.Text + "'";
            else
                queries[queries.Length - 1] += ",ItemLocation=null";

            if (this.ItemLocationDesc.Text != "")
                queries[queries.Length - 1] += ",ItemLocationDesc='" + this.ItemLocationDesc.Text + "'";
            else
                queries[queries.Length - 1] += ",ItemLocationDesc=null";

            queries[queries.Length - 1] += " where ItemLocation='" + CodeToUpdate + "'";

      
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
                    DataAccountRow_III["ItemLocation"] = this.ItemLocation.Text;
                    DataAccountRow_III["ItemLocationDesc"] = this.ItemLocationDesc.Text;

                    this.ItemLocationDesc.Text = "";
                    this.ItemLocation.Tag = null;

                    this.ItemLocation.Text = "";
                    SetButtonStates_Level_III(UserInputMode.View);
                    this.Add_III.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
     
        private void Delete_Level_I_Account()
        {





            if (this.ControlLocation.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlLocation.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

           
            if (this.ControlLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

           

            string[] queries = new string[0];
            string GRNtoUpdate = this.ControlLocation.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Control Location  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_Locations_Control where ControlLocation='" + GRNtoUpdate + "'";
          

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

                    this.ControlLocation.Tag = null;
                    this.ControlLocationDesc.Text = "";
                    this.ControlLocation.Text = "";
                    
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





          
            if (this.GroupLocation.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

          
            if (this.GroupLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.GroupLocation.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Group Location   # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_Locations_Group where GroupLocation='" + GRNtoUpdate + "'";
         

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

                    this.GroupLocation.Tag = null;
                    this.GroupLocation.Text = "";
                    this.GroupLocationDesc.Text = "";

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






            if (this.ItemLocation.Tag == null)
            {
                XtraMessageBox.Show("Account ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (this.ItemLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Account ID is invalid ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            string[] queries = new string[0];
            string GRNtoUpdate = this.ItemLocation.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item Location   # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_Locations_Item where ItemLocation='" + GRNtoUpdate + "'";
           

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

                    this.ItemLocation.Tag = null;
                    this.ItemLocation.Text = "";
                    this.ItemLocationDesc.Text = "";

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
      
        private void Fill_Level_I_Row()
        {
            if (this.gridView_Control.FocusedRowHandle != -1)
            {
                DataAccountRow_I = this.gridView_Control.GetDataRow(this.gridView_Control.FocusedRowHandle);
                if (DataAccountRow_I != null)
                {
                    this.ControlLocation.Text = DataAccountRow_I["ControlLocation"].ToString();
                    this.ControlLocationDesc.Text = DataAccountRow_I["ControlLocationDesc"].ToString();
                    this.ControlLocation.Tag = DataAccountRow_I["ControlLocation"].ToString();
                    this.RefAccountID_I.Text = DataAccountRow_I["ControlLocation"].ToString();
                    this.RefAccountName_I.Text = DataAccountRow_I["ControlLocationDesc"].ToString();
                    

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
                    
                    this.GroupLocation.Text = DataAccountRow_II["GroupLocation"].ToString();
                    this.GroupLocationDesc.Text = DataAccountRow_II["GroupLocationDesc"].ToString();
                    this.GroupLocation.Tag = DataAccountRow_II["GroupLocation"].ToString();
                    this.RefAccountID_II.Text = DataAccountRow_II["GroupLocation"].ToString();
                    this.RefAccountName_II.Text = DataAccountRow_II["GroupLocationDesc"].ToString();


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
                    this.ItemLocation.Text = DataAccountRow_III["ItemLocation"].ToString();
                    this.ItemLocationDesc.Text = DataAccountRow_III["ItemLocationDesc"].ToString();
                    this.ItemLocation.Tag = DataAccountRow_III["ItemLocation"].ToString();
                  

                    SetButtonStates_Level_III(UserInputMode.View);
                }
            }
        }
   
        private void gridView_Control_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            Fill_Level_I_Row();
        }
        
        private void Control_Add_Click(object sender, EventArgs e)
        {
            this.ControlLocation.Text = "";
            this.ControlLocation.Tag = null;
            this.ControlLocation.EditValue = null;
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

            if (this.ControlLocation.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlLocation.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ControlLocation.Text.Length != 2)
            {
                XtraMessageBox.Show("Level I is invalid ...must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_I(UserInputMode.Edit);
        }

        private void Control_Delete_Click(object sender, EventArgs e)
        {
            if (this.ControlLocation.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ControlLocation.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ControlLocation.Text.Length != 2)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 2 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlLocation.Tag.ToString() == "")
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
         
            Load_Level_III(this.RefAccountID_II.Text);
        }

      

       
        private void Goto_Level_I_Click(object sender, EventArgs e)
        {
           
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
            xtraTabPage_III.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
          
        }

        private void Backto_Level_IV_Click(object sender, EventArgs e)
        {
           
         
         
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
           
        }

        private void Backto_Level_III_Click(object sender, EventArgs e)
        {
            xtraTabPage_III.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_III;
            xtraTabPage_I.PageEnabled = false;
            xtraTabPage_II.PageEnabled = false;
          
           
        }

        private void Backto_Level_II_Click(object sender, EventArgs e)
        {
            xtraTabPage_II.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_II;
            xtraTabPage_I.PageEnabled = false;
           
            xtraTabPage_III.PageEnabled = false;
          
            DataAccountRow_III = null;
        }

        private void Backto_Level_I_Click(object sender, EventArgs e)
        {
            DataAccountRow_II = null;
            xtraTabPage_I.PageEnabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage_I;
          
            xtraTabPage_II.PageEnabled = false;
            xtraTabPage_III.PageEnabled = false;
           
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

       

     
        private void gridView_Level_II_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                Goto_Level_III_Click(sender, e);
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

      

       
        private void Add_II_Click(object sender, EventArgs e)
        {
            this.GroupLocation.Text = "";
            this.GroupLocation.Tag = null;
            this.GroupLocationDesc.Text = "";
            SetButtonStates_Level_II(UserInputMode.Add);
            //string mAccountID = ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_II,3,4)))+1 as MaxNumber  from AC_Level_II where AccountID_I='" +this.RefAccountID_I.Text + "'");
           // if (mAccountID == "") return;
            string mAccountID = this.RefAccountID_I.Text + "-";
            this.GroupLocation.Text = mAccountID;
        }

        private void Add_III_Click(object sender, EventArgs e)
        {
            this.ItemLocation.Text = "";
            this.ItemLocation.Tag = null;
            this.ItemLocationDesc.Text = "";
            SetButtonStates_Level_III(UserInputMode.Add);
            string mAccountID ;//= ReturnMaxNumber("select max(Convert(numeric(9),SubString(AccountID_III,5,7)))+1 as MaxNumber  from AC_Level_III where AccountID_II='" + this.RefAccountID_II.Text + "'");

            mAccountID = this.RefAccountID_II.Text + "-";
            this.ItemLocation.Text = mAccountID;
        }

       

      

        private void Edit_II_Click(object sender, EventArgs e)
        {
            if (this.GroupLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_I.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GroupLocation.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_II(UserInputMode.Edit);
        }

        private void Edit_III_Click(object sender, EventArgs e)
        {
            if (this.ItemLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ItemLocation.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_III(UserInputMode.Edit);
        }


        private void Delete_II_Click(object sender, EventArgs e)
        {
            if (this.GroupLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_I.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GroupLocation.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID II  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_II(UserInputMode.Delete);
        }

        private void Delete_III_Click(object sender, EventArgs e)
        {
            if (this.ItemLocation.Text == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefAccountID_II.Text == "")
            {
                XtraMessageBox.Show("Invalid Ref Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ItemLocation.Tag == null)
            {
                XtraMessageBox.Show("Invalid Account ID   Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemLocation.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Account ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Level_III(UserInputMode.Delete);
        }

       

        private void Cancel_II_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_II(UserInputMode.View);
        }

        private void Cancel_III_Click(object sender, EventArgs e)
        {
            SetButtonStates_Level_III(UserInputMode.View);
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

     
       

        

        

     

       
      

      
     
        
    }
}