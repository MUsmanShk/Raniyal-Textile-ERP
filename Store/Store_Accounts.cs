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
    public partial class Store_Accounts : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        DataRow ControlAccountRow;
        DataRow GroupAccountRow;
        DataRow ItemAccountRow;
        private string G_InvoiceOpening;
        private string N_InvoiceOpening;
        UserInputMode uiMode;
        UserInputMode uiModeGroup;
        UserInputMode uiModeItem;
        UserInputMode uiModeOpening;
        int FocusedRowHandle;
        int GroupFocusedRowHandle;
        int ItemFocusedRowHandle;
        public Store_Accounts()
        {
            InitializeComponent();
            LoadControlAccounts();
            this.xtraTabPage_Group.PageEnabled = false;
            this.xtraTabPage_Item.PageEnabled = false;
            FillCombos fc = new FillCombos();
            fc.MeasurementUnits(ref this.ItemConsumptionUnit);
            fc.MeasurementUnits(ref this.ItemPurchaseUnit);
            fc.StoreItemLocations(ref this.ItemLocation);
            fc.ItemMC(ref this.MC);
            fc.ItemConditions(ref this.Condition);
            fc.ItemTypes(ref this.ItemType);
            G_InvoiceOpening = "072";
            N_InvoiceOpening= "082";
            this.Prefix.Text = G_InvoiceOpening;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NGOpening.Tag = "G";
            this.DatedOpening.DateTime = DateTime.Now;
        }

        private void Store_Accounts_Load(object sender, EventArgs e)
        {

        }

       
        private void LoadControlAccounts()
        {
            DataSet ds = WS.svc.Get_DataSet("Select * from ST_ControlAccounts order by Convert(numeric(18),ControlAccountID)");
          
                this.gridControl_Control.DataSource = ds.Tables[0];
     

        }
        private void SetButtonStates(UserInputMode uim)
        {
            uiMode = uim;
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
        private void SetButtonStates_Group(UserInputMode uim)
        {
            uiModeGroup = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.Group_Execute.Enabled = false;
                    this.Group_Cancel.Enabled = false;
                    this.Group_Add.Enabled = true;

                    


                    if (this.GroupAccountID.Tag != null)
                    {
                        if (this.GroupAccountID.Tag.ToString() != "")
                        {

                            this.Group_Edit.Enabled = true;
                            this.Group_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.Group_Edit.Enabled = false;
                            this.Group_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Group_Edit.Enabled = false;
                        Group_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.GroupAccountID.Tag = null;
                    this.Group_Add.Enabled = false;
                    this.Group_Cancel.Enabled = true;
                    Group_Execute.Enabled = true;
                    Group_Edit.Enabled = false;
                    
                    Group_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Group_Add.Enabled = false;
                    Group_Cancel.Enabled = true;
                    Group_Execute.Enabled = true;
                    Group_Edit.Enabled = false;

                    Group_Delete.Enabled = false;
                  

                    break;
                case UserInputMode.Delete:
                    Group_Add.Enabled = false;
                    Group_Cancel.Enabled = true;
                    Group_Execute.Enabled = true;
                    Group_Edit.Enabled = false;

                    Group_Delete.Enabled = false;
                   

                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Opening(UserInputMode uim)
        {
            uiModeOpening = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.POD_ExecuteOpening.Enabled = false;
                   
                    this.POD_AddOpening.Enabled = false;




                    if (this.RefOpeningDetailNumber.Tag != null)
                    {
                        if (this.RefOpeningDetailNumber.Tag.ToString() != "")
                        {

                            this.POD_EditOpening.Enabled = true;
                            this.POD_DeleteOpening.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.POD_EditOpening.Enabled = false;
                            this.POD_DeleteOpening.Enabled = false;
                            this.POD_AddOpening.Enabled = true;
                        }
                    }
                    else
                    {
                        this.POD_EditOpening.Enabled = false;
                        this.POD_DeleteOpening.Enabled = false;
                        this.POD_AddOpening.Enabled = true;
                    }
                    break;
                case UserInputMode.Add:
                    this.RefOpeningDetailNumber.Tag = null;
                    this.POD_AddOpening.Enabled = false;
                  
                    this.POD_ExecuteOpening.Enabled = true;
                    this.POD_EditOpening.Enabled = false;

                    this.POD_DeleteOpening.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    this.POD_AddOpening.Enabled = false;
                    
                    this.POD_ExecuteOpening.Enabled = true;
                    this.POD_EditOpening.Enabled = false;

                    this.POD_DeleteOpening.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    this.POD_AddOpening.Enabled = false;
                   
                    this.POD_ExecuteOpening.Enabled = true;
                    this.POD_EditOpening.Enabled = false;

                    this.POD_DeleteOpening.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private void SetButtonStates_Item(UserInputMode uim)
        {
            uiModeItem = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.Item_Execute.Enabled = false;
                    this.Item_Cancel.Enabled = false;
                    this.Item_Add.Enabled = true;




                    if (this.ItemAccountID.Tag != null)
                    {
                        if (this.ItemAccountID.Tag.ToString() != "")
                        {

                            this.Item_Edit.Enabled = true;
                            this.Item_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.Item_Edit.Enabled = false;
                            this.Item_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Item_Edit.Enabled = false;
                        Item_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.ItemAccountID.Tag = null;
                    this.Item_Add.Enabled = false;
                    this.Item_Cancel.Enabled = true;
                    Item_Execute.Enabled = true;
                    Item_Edit.Enabled = false;

                    Item_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Item_Add.Enabled = false;
                    Item_Cancel.Enabled = true;
                    Item_Execute.Enabled = true;
                    Item_Edit.Enabled = false;

                    Item_Delete.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Item_Add.Enabled = false;
                    Item_Cancel.Enabled = true;
                    Item_Execute.Enabled = true;
                    Item_Edit.Enabled = false;

                    Item_Delete.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private bool GetNextControlAccountNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),ControlAccountID))+1 as MaxNumber  from ST_ControlAccounts";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 3)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ControlAccountID.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(3, '0');
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
        private bool GroupGetNextAccountNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(GroupAccountID,4,4)))+1 as MaxNumber  from ST_GroupAccounts where ControlAccountID='" + SelectedControlAccountID.Text + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 4)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.GroupAccountID.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(4, '0');
                    this.GroupAccountID.Text = this.SelectedControlAccountID.Text +  iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.GroupAccountID.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.GroupAccountID.Text = "";
                return false;
            }
        }
        private void SaveNew()
        {
            if (this.ControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Control Account ID", "Error");
                return;
            }
            if (this.ControlAccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid control ACCOUNT ID ...length must be 3 Characters", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";
           
                vnum = this.ControlAccountID.Text;

           


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_ControlAccounts (ControlAccountID,ControlAccountName,MappedAccountID,AssetsMappedAccountID) Values (";
            queries[queries.Length - 1] += "'" +  this.ControlAccountID.Text + "'";

            if (this.ControlAccountName.Text != "")
                queries[queries.Length - 1] += ",'" + this.ControlAccountName.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.MappedAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.MappedAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.AssetMappedAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.AssetMappedAccountID.EditValue.ToString() + "'";
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
                    dt.Columns.Add("ControlAccountID");
                    dt.Columns.Add("ControlAccountName");
                    dt.Columns.Add("MappedAccountID");
                    dt.Columns.Add("AssetsMappedAccountID");
                    DataRow _ravi = dt.NewRow();
                    _ravi["ControlAccountID"] = this.ControlAccountID.Text;
                    _ravi["ControlAccountName"] = this.ControlAccountName.Text;
                    if (this.MappedAccountID.EditValue != null) _ravi["MappedAccountID"] = this.MappedAccountID.EditValue.ToString();
                    if (this.MappedAccountID.EditValue != null) _ravi["AssetsMappedAccountID"] = this.AssetMappedAccountID.EditValue.ToString();
                    dt.Rows.Add(_ravi);

                    DataView  gdv = (DataView)this.gridView_Control.DataSource;
                    DataTable gdt = gdv.Table;
                    gdt.Merge(dt);
                    this.ControlAccountID.Text = "";
                    this.ControlAccountName.Text = "";
                    this.MappedAccountID.EditValue = null;
                    this.MappedAccountName.EditValue = null;
                    this.AssetMappedAccountID.EditValue = null;
                    this.AssetMappedAccountName.EditValue = null;
                    SetButtonStates(UserInputMode.View);
                    
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void UpdateExisting()
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

            if (this.ControlAccountID.Text.Length != 3)
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
           
            string CodeToUpdate = this.ControlAccountID.Tag.ToString();

        

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_ControlAccounts set ";
            queries[queries.Length - 1] += " ControlAccountID='" + this.ControlAccountID.Text + "' ";
          


            if (this.ControlAccountName.Text!="")
                queries[queries.Length - 1] += ",ControlAccountName='" + this.ControlAccountName.Text  + "'";
            else
                queries[queries.Length - 1] += ",ControlAccountName=null";
            if (this.MappedAccountID.EditValue!=null)
                queries[queries.Length - 1] += ",MappedAccountID='" + this.MappedAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",MappedAccountID=null";
            if (this.AssetMappedAccountID.EditValue != null)
                queries[queries.Length - 1] += ",AssetsMappedAccountID='" + this.AssetMappedAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AssetsMappedAccountID=null";
            queries[queries.Length - 1] += " where ControlAccountID='" + CodeToUpdate + "'";

           
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
                    ControlAccountRow["ControlAccountID"] = this.ControlAccountID.Text;
                    ControlAccountRow["ControlAccountName"] = this.ControlAccountName.Text;
                   if(this.MappedAccountID.EditValue!=null)ControlAccountRow["MappedAccountID"] = this.MappedAccountID.EditValue.ToString();
                   if (this.AssetMappedAccountID.EditValue != null) ControlAccountRow["AssetsMappedAccountID"] = this.AssetMappedAccountID.EditValue.ToString();
                    this.ControlAccountID.Text = "";
                    this.ControlAccountID.Tag = null;
                    this.MappedAccountID.EditValue = null;
                    this.MappedAccountName.EditValue = null;
                    this.AssetMappedAccountID.EditValue = null;
                    this.AssetMappedAccountName.EditValue = null;
                    this.ControlAccountName.Text = "";
                    SetButtonStates(UserInputMode.View);
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteExisting()
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

            if (this.ControlAccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (FocusedRowHandle ==-1)
            {
                XtraMessageBox.Show("invalid control account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string[] queries = new string[0];
            string GRNtoUpdate = this.ControlAccountID.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Control Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_ControlAccounts where ControlAccountID='" + GRNtoUpdate + "'";
           


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
                    this.AssetMappedAccountName.EditValue = null;
                    this.AssetMappedAccountID.EditValue = null;
                    this.MappedAccountName.EditValue = null;
                    this.MappedAccountID.EditValue = null;
                    gridView_Control.DeleteRow(FocusedRowHandle);
                    SetButtonStates(UserInputMode.View);
                    this.Control_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GroupSaveNew()
        {
            if (this.SelectedControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Control Account ID", "Error");
                return;
            }
            if (this.SelectedControlAccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid control ACCOUNT ID ...length must be 3 Characters", "Error");
                return;
            }
            if (this.GroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Group Account ID", "Error");
                return;
            }
            if (this.GroupAccountID.Text.Length != 7)
            {
                XtraMessageBox.Show("invalid Group ACCOUNT ID ...length must be 7 Characters", "Error");
                return;
            }

            string[] queries = new string[0];
            string vnum = "";

            vnum = this.GroupAccountID.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_GroupAccounts (ControlAccountID,GroupAccountID,GroupAccountname) Values (";
            queries[queries.Length - 1] += "'" + this.SelectedControlAccountID.Text + "','"+this.GroupAccountID.Text +"'";

            if (this.GroupAccountName.Text != "")
                queries[queries.Length - 1] += ",'" + this.GroupAccountName.Text + "'";
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
                    dt.Columns.Add("GroupAccountID");
                    dt.Columns.Add("GroupAccountName");
                    DataRow _ravi = dt.NewRow();
                    _ravi["GroupAccountID"] = this.GroupAccountID.Text;
                    _ravi["GroupAccountName"] = this.GroupAccountName.Text;
                    dt.Rows.Add(_ravi);

                    DataView gdv = (DataView)this.gridView_Group.DataSource;
                    DataTable gdt = gdv.Table;
                    gdt.Merge(dt);
                    this.GroupAccountID.Text = "";
                    this.GroupAccountName.Text = "";
                    this.GroupAccountID.Tag = null;
                    SetButtonStates_Group(UserInputMode.View);
                    this.Group_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void GroupUpdateExisting()
        {
            if (this.SelectedControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupAccountID.Tag == null)
            {
                XtraMessageBox.Show("Group ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GroupAccountID.Text.Length != 7)
            {
                XtraMessageBox.Show("Group ID is invalid ...must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.GroupAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Group ID is invalid must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
         
            string CodeToUpdate = this.GroupAccountID.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_GroupAccounts set ";
            queries[queries.Length - 1] += "ControlAccountID='"+this.SelectedControlAccountID.Text +"', GroupAccountID='" + this.GroupAccountID.Text + "' ";



            if (this.GroupAccountName.Text != "")
                queries[queries.Length - 1] += ",GroupAccountName='" + this.GroupAccountName.Text + "'";
            else
                queries[queries.Length - 1] += ",GroupAccountName=null";

            queries[queries.Length - 1] += " where GroupAccountID='" + CodeToUpdate + "'";

           
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
                    GroupAccountRow["GroupAccountID"] = this.GroupAccountID.Text;
                    GroupAccountRow["GroupAccountName"] = this.GroupAccountName.Text;
                    this.GroupAccountID.Text = "";
                    this.GroupAccountID.Tag = null;
                    this.GroupAccountName.Text = "";
                    SetButtonStates_Group(UserInputMode.View);
                   
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void GroupDeleteExisting()
        {





            if (this.SelectedControlAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

           
            if (this.GroupAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Group ID is invalid must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (GroupFocusedRowHandle == -1)
            {
                XtraMessageBox.Show("invalid Group account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string[] queries = new string[0];
            string GRNtoUpdate = this.GroupAccountID.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Group Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_GroupAccounts where GroupAccountID='" + GRNtoUpdate + "'";
            


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

                    this.GroupAccountID.Tag = null;
                    this.GroupAccountName.Text = "";
                    this.GroupAccountID.Text = "";
                    gridView_Group.DeleteRow(GroupFocusedRowHandle);
                    SetButtonStates_Group(UserInputMode.View);
                    this.Group_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GotoControlTab()
        {
            this.xtraTabPage_Group.PageEnabled = false;
            this.xtraTabPage_Control.PageEnabled = true;
            this.xtraTabPage_Item.PageEnabled = false;
            this.xtraTabPage_Opening.PageEnabled = false;
            this.gridView_Control.Focus();
        }
        private void GotoGroupTab()
        {
            if (FocusedRowHandle == -1) return;
            if (ControlAccountRow == null) return;
            this.SelectedControlAccountID.Text = ControlAccountRow["ControlAccountID"].ToString();
            this.SelectedControlAccountName.Text = ControlAccountRow["ControlAccountName"].ToString();
            DataSet ds = WS.svc.Get_DataSet("Select GroupAccountID,GroupAccountName from ST_GroupAccounts where ControlAccountID='" + this.SelectedControlAccountID.Text + "'");
            this.gridControl_Group.DataSource = ds.Tables[0];
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Group;
            this.xtraTabPage_Group.PageEnabled = true;
            this.xtraTabPage_Control.PageEnabled = false;
            this.xtraTabPage_Item.PageEnabled = false;
            this.xtraTabPage_Opening.PageEnabled = false;
            this.Group_Add.Focus();

        }
        private void GotoOpeningTab()
        {
            this.PODQtyOpening.EditValue = null;
            this.MC.EditValue = null;
            this.Condition.EditValue = null;
            this.PODRemarksOpening.EditValue = null;
            if (this.PODItemAccountIDOpening.EditValue == null) return;
            if (this.UOMOpening.EditValue == null) return;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Opening;
            this.xtraTabPage_Group.PageEnabled = false;
            this.xtraTabPage_Control.PageEnabled = false;
            this.xtraTabPage_Item.PageEnabled = false;
            this.xtraTabPage_Opening.PageEnabled = true;
           string  strFilterQuery = "SELECT *  FROM RST_StoreDetails  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NGOpening.Tag.ToString() + "' and PRTypeID=7 and PRDNO in(Select PRDNO from ST_StoreDetails where ItemAccountID='"+this.ItemAccountID.EditValue.ToString()+"')";
            DataSet ds = WS.svc.Get_DataSet(strFilterQuery);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        this.DatedOpening.DateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                    }
                    catch
                    {
                    }




                    this.iCodeType.EditValue = "0";
                    this.FinancialYear.EditValue = ds.Tables[0].Rows[0]["iYear"].ToString();
                    this.Prefix.EditValue = ds.Tables[0].Rows[0]["iType"].ToString();
                    this.Prefix.Tag = ds.Tables[0].Rows[0]["iType"].ToString();
                    this.FinancialYear.Tag = ds.Tables[0].Rows[0]["iYear"].ToString();
                    this.RefOpeningNoteNumber.EditValue = ds.Tables[0].Rows[0]["PRNO"].ToString();
                    this.RefOpeningDetailNumber.EditValue = ds.Tables[0].Rows[0]["PRDNO"].ToString();
                    this.RefOpeningNoteNumber.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString(); ;
                    this.RefOpeningDetailNumber.Tag = ds.Tables[0].Rows[0]["PRDNO"].ToString();
                    this.Suffix.Text = ds.Tables[0].Rows[0]["PRNO"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString().Substring(7, 6);



                    SetButtonStates_Opening(UserInputMode.View);


                    this.PODQtyOpening.EditValue = ds.Tables[0].Rows[0]["PlusQty"].ToString();
                    this.PODRemarksOpening.EditValue = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    this.RatesOpening.EditValue = ds.Tables[0].Rows[0]["PlusRate"].ToString();
                    this.UOMOpening.EditValue = ds.Tables[0].Rows[0]["UOM"].ToString();
                    this.Condition.EditValue = ds.Tables[0].Rows[0]["ConditionID"].ToString();
                    this.MC.EditValue = ds.Tables[0].Rows[0]["MC"].ToString();
                }
                else
                {
                    this.RefOpeningNoteNumber.EditValue = null;
                    this.RefOpeningDetailNumber.EditValue = null;
                   
                    SetButtonStates_Opening(UserInputMode.View);
                }
            }
            else
            {
                this.RefOpeningNoteNumber.EditValue = null;
                this.RefOpeningDetailNumber.EditValue = null;
                SetButtonStates_Opening(UserInputMode.View);
            }
        }
        private void GotoItemTab()
        {
            if (GroupFocusedRowHandle == -1) return;
            if (GroupAccountRow == null) return;
            this.SelectedGroupAccountID.Text = GroupAccountRow["GroupAccountID"].ToString();
            this.SelectedGroupAccountName.Text = GroupAccountRow["GroupAccountName"].ToString();
            DataSet ds = WS.svc.Get_DataSet("Select  ItemAccountID,PartNumber, ItemAccountName,ItemTypeID,GroupAccountID,ReOrderLevel, bUnit, cUnit, bUnitRate, cUnitRate, cUnitinpUnit,iStatus,AddAsSizingChemical,ItemLocation from ST_ItemAccounts where GroupAccountID='" + this.SelectedGroupAccountID.Text + "'");
            this.gridControl_Item.DataSource = ds.Tables[0];
            for (int x = 0; x < this.gridView_Item.Columns.Count; x++)
            {
                if (x > 2) this.gridView_Item.Columns[x].Visible = false;
            }
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Item;
            this.xtraTabPage_Group.PageEnabled = false;
            this.xtraTabPage_Control.PageEnabled = false;
            this.xtraTabPage_Opening.PageEnabled = false;
            this.xtraTabPage_Item.PageEnabled = true;
            this.Item_Add.Focus();

        }
        private void FillControlFromSelectedRow()
        {
            if (FocusedRowHandle != -1)
            {
                ControlAccountRow = this.gridView_Control.GetDataRow(this.gridView_Control.FocusedRowHandle);
                if (ControlAccountRow != null)
                {
                    this.ControlAccountID.Text = ControlAccountRow["ControlAccountID"].ToString();
                    this.ControlAccountName.Text = ControlAccountRow["ControlAccountName"].ToString();
                    this.ControlAccountID.Tag = ControlAccountRow["ControlAccountID"].ToString();
                    this.SelectedControlAccountID.Text = ControlAccountRow["ControlAccountID"].ToString();
                    this.SelectedControlAccountName.Text = ControlAccountRow["ControlAccountName"].ToString();
                    if (ControlAccountRow["MappedAccountID"].ToString() != "")
                        this.MappedAccountID.EditValue = ControlAccountRow["MappedAccountID"].ToString();
                    else
                        this.MappedAccountID.EditValue = null;
                    if (ControlAccountRow["AssetsMappedAccountID"].ToString() != "")
                        this.AssetMappedAccountID.EditValue = ControlAccountRow["AssetsMappedAccountID"].ToString();
                    else
                        this.AssetMappedAccountID.EditValue = null;
                    SetButtonStates(UserInputMode.View);
                }
            }
        }
        private void gridView_Control_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FocusedRowHandle = this.gridView_Control.FocusedRowHandle;
            FillControlFromSelectedRow();
        }

      
      

       


       

        private void Group_Add_Click(object sender, EventArgs e)
        {
            this.GroupAccountID.Text = "";
            this.GroupAccountID.Tag = null;
            this.GroupAccountID.EditValue = null;
            bool rRes = GroupGetNextAccountNumber();


            SetButtonStates_Group(UserInputMode.Add);
        }

        private void Group_Execute_Click(object sender, EventArgs e)
        {
            if (uiModeGroup == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GroupSaveNew();
            }
            else if (uiModeGroup == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    //// XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //  return;
                }
                GroupUpdateExisting();
            }
            else if (uiModeGroup == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete,docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                GroupDeleteExisting();
            }
        }

        private void Group_Edit_Click(object sender, EventArgs e)
        {
            if (this.GroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GroupAccountID.Text.Length != 7)
            {
                XtraMessageBox.Show("Group ID is invalid ...must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.SelectedControlAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Control Account is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.GroupAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Group(UserInputMode.Edit);
        }

        private void Group_Delete_Click(object sender, EventArgs e)
        {
            if (this.GroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.GroupAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.GroupAccountID.Text.Length != 7)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.GroupAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 7 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Group(UserInputMode.Delete);
        }

        private void Group_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates_Group(UserInputMode.View);
        }

        private void Group_Print_Click(object sender, EventArgs e)
        {
            if (GroupAccountID.Tag == null)
            {
                XtraMessageBox.Show("Invalid Group Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (GroupAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Group Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "select * from RST_ItemAccounts where GroupAccountID='" + this.GroupAccountID.Tag.ToString() + "'";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds == null)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;

            }
            Reports.Store_ItemAccounts Items = new Reports.Store_ItemAccounts();
            Items.BeginInit();
            Items.DataSource = ds;
            Items.EndInit();
            Items.ShowPreview();
        }
        private void FillGroupFromSelectedRow()
        {
            if (GroupFocusedRowHandle != -1)
            {
                GroupAccountRow = this.gridView_Group.GetDataRow(this.gridView_Group.FocusedRowHandle);
                if (GroupAccountRow != null)
                {
                    this.GroupAccountID.Text = GroupAccountRow["GroupAccountID"].ToString();
                    this.GroupAccountName.Text = GroupAccountRow["GroupAccountName"].ToString();
                    this.GroupAccountID.Tag = GroupAccountRow["GroupAccountID"].ToString();
                    //SetButtonStates_Group(UserInputMode.View);
                }
            }
        }
        private void gridView_Group_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GroupFocusedRowHandle = this.gridView_Group.FocusedRowHandle;
            FillGroupFromSelectedRow();
        }

     

       

       

        private void gridView_Control_DoubleClick(object sender, EventArgs e)
        {
            GotoGroupTab();
        }

        private void gridView_Control_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control ==true && e.KeyCode ==Keys.Enter)
            GotoGroupTab();
        }

        private void gotoGroupAccountTab_Click(object sender, EventArgs e)
        {
            GotoGroupTab();
        }

        private void gotoControlAccountTab_Click(object sender, EventArgs e)
        {
            GotoControlTab();
        }
        private void ItemSaveNew()
        {
            if (this.SelectedGroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Group Account ID", "Error");
                return;
            }
            if (this.SelectedGroupAccountID.Text.Length != 7)
            {
                XtraMessageBox.Show("invalid Group ACCOUNT ID ...length must be 7 Characters", "Error");
                return;
            }
            if (this.ItemAccountID.Text == "")
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.ItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }

            string[] queries = new string[0];
            string vnum = ""; 

            vnum = this.ItemAccountID.Text;



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_ItemAccounts (iStatus,GroupAccountID,ItemAccountID,PartNumber,ItemLocation,ItemAccountname,ReOrderLevel,bUnit,cUnit,bUnitRate,cUnitRate,cUnitInpUnit,ItemTypeID,AddAsSizingChemical) Values (";
            queries[queries.Length - 1] += "'U','" + this.SelectedGroupAccountID.Text + "','" + this.ItemAccountID.Text + "'";

            if (this.PartNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.PartNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ItemLocation.EditValue!=null)
                queries[queries.Length - 1] += ",'" + this.ItemLocation.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ItemAccountName.Text != "")
                queries[queries.Length - 1] += ",'" + this.ItemAccountName.Text + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.ItemReorderLevel.EditValue!=null)
                queries[queries.Length - 1] += "," + this.ItemReorderLevel.EditValue.ToString()+ "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ItemPurchaseUnit.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ItemPurchaseUnit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ItemConsumptionUnit.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ItemConsumptionUnit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ItemPurchaseRate.EditValue != null)
                if (this.ItemPurchaseRate.EditValue.ToString()!="")
                queries[queries.Length - 1] += "," + this.ItemPurchaseRate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ItemSalesRate.EditValue != null)
                if(this.ItemSalesRate.EditValue.ToString() != "")
                queries[queries.Length - 1] += "," + this.ItemSalesRate.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
            else
                queries[queries.Length - 1] += ",0";
            if (this.ItemUnitRatio.EditValue != null)
                queries[queries.Length - 1] += "," + this.ItemUnitRatio.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",1";
          
            if (this.ItemType.EditValue != null)
                queries[queries.Length - 1] += "," + this.ItemType.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",1";

            if (this.AddtoSizingChemical.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
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
                    
                     
                  

                   // dt.Rows.Add(_ravi);

                    DataView gdv = (DataView)this.gridView_Item.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["ItemAccountID"] = this.ItemAccountID.Text;
                    _ravi["ItemAccountName"] = this.ItemAccountName.Text;
                    if (this.ItemType.EditValue != null)
                        _ravi["ItemTypeID"] = this.ItemType.EditValue.ToString();
                    else
                        _ravi["ItemTypeID"] = "1";
                    if (this.PartNumber.Text != "")
                        _ravi["PartNumber"] = this.PartNumber.Text;
                    else
                        _ravi["PartNumber"] = DBNull.Value;

                    if (this.ItemLocation.EditValue!=null)
                        _ravi["ItemLocation"] = this.ItemLocation.EditValue.ToString();
                    else
                        _ravi["ItemLocation"] = DBNull.Value;
                    _ravi["GroupAccountID"] = this.SelectedGroupAccountID.Text;
                    if (this.ItemReorderLevel.EditValue != null)
                        _ravi["ReOrderLevel"] = this.ItemReorderLevel.EditValue.ToString();
                    else
                        _ravi["ReOrderLevel"] = "0";
                    if (this.ItemPurchaseUnit.EditValue != null)
                        _ravi["bUnit"] = this.ItemPurchaseUnit.EditValue.ToString();
                    else
                        _ravi["bUnit"] = "0";
                    if (this.ItemConsumptionUnit.EditValue != null)
                        _ravi["cUnit"] = this.ItemConsumptionUnit.EditValue.ToString();
                    else
                        _ravi["cUnit"] = "0";
                    if (this.ItemPurchaseRate.EditValue != null)
                        _ravi["bUnitRate"] = this.ItemPurchaseRate.EditValue.ToString();
                    else
                        _ravi["bUnitRate"] = "0";
                    if (this.ItemSalesRate.EditValue != null)
                        _ravi["cUnitRate"] = this.ItemSalesRate.EditValue.ToString();
                    else
                        _ravi["cUnitRate"] = "0";
                    if (this.ItemUnitRatio.EditValue != null)
                        _ravi["cUnitinpUnit"] = this.ItemUnitRatio.EditValue.ToString();
                    else
                        _ravi["cUnitinpUnit"] = "1";
                    _ravi["iStatus"] = "U";
                    gdt.Rows.Add(_ravi);
                    //gdt.Merge(dt);
                    this.PODItemAccountIDOpening.EditValue = this.ItemAccountID.EditValue;
                    this.PODItemAccountNameOpening.EditValue = this.ItemAccountName.EditValue;
                    this.RatesOpening.Tag = this.ItemPurchaseRate.EditValue;
                    this.RatesOpening.EditValue = this.ItemPurchaseRate.EditValue;
                    this.UOMOpening.EditValue = this.ItemConsumptionUnit.EditValue;
                    this.UOMOpening.Tag = this.ItemConsumptionUnit.EditValue;
                    this.ItemAccountID.Text = "";
                    this.ItemAccountName.Text = "";
                    this.ItemUnitRatio.EditValue = null;
                    this.ItemType.EditValue = null;
                    this.ItemSalesRate.EditValue = null;
                    this.ItemReorderLevel.EditValue = null;
                    this.ItemPurchaseUnit.EditValue = null;
                    this.ItemPurchaseRate.EditValue = null;
                    this.ItemConsumptionUnit.EditValue = null;
                    this.PartNumber.Text = "";
                    this.ItemLocation.EditValue = null;
                    this.ItemAccountID.Tag = null;
                    SetButtonStates_Item(UserInputMode.View);
                    this.Item_Add.Focus();
                    //GotoOpeningTab();
                   
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ItemUpdateExisting()
        {
            if (this.SelectedGroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Group ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemAccountID.Tag == null)
            {
                XtraMessageBox.Show("Group ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ItemAccountID.Text.Length !=13)
            {
                XtraMessageBox.Show("Item ID is invalid ...must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ItemAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Item ID is invalid must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string[] queries = new string[0];
           
            string CodeToUpdate = this.ItemAccountID.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_ItemAccounts set ";
            queries[queries.Length - 1] += "GroupAccountID='" + this.SelectedGroupAccountID.Text + "', ItemAccountID='" + this.ItemAccountID.Text + "' ";

            if (this.PartNumber.Text != "")
                queries[queries.Length - 1] += ",PartNumber='" + this.PartNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",PartNumber=null";

            if (this.ItemLocation.EditValue!=null)
                queries[queries.Length - 1] += ",ItemLocation='" + this.ItemLocation.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemLocation=null";
            if (this.ItemAccountName.Text != "")
                queries[queries.Length - 1] += ",ItemAccountName='" + this.ItemAccountName.Text + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountName=null";

            if (this.ItemReorderLevel.EditValue != null)
                queries[queries.Length - 1] += ",ReOrderLevel=" + this.ItemReorderLevel.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ReOrderLevel=0";
            if (this.ItemPurchaseUnit.EditValue != null)
                queries[queries.Length - 1] += ",bUnit='" + this.ItemPurchaseUnit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",bUnit=null";
            if (this.ItemConsumptionUnit.EditValue != null)
                queries[queries.Length - 1] += ",cUnit='" + this.ItemConsumptionUnit.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",cUnit=null";
            if (this.ItemPurchaseRate.EditValue != null)
                queries[queries.Length - 1] += ",bUnitRate=" + this.ItemPurchaseRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",bUnitRate=0";
            if (this.ItemSalesRate.EditValue != null)
                queries[queries.Length - 1] += ",cUnitRate=" + this.ItemSalesRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",cUnitRate=0";
            if (this.ItemUnitRatio.EditValue != null)
                queries[queries.Length - 1] += ",cUnitinPUnit=" + this.ItemUnitRatio.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",cUnitinPUnit=1";
           
            if (this.ItemType.EditValue != null)
                queries[queries.Length - 1] += ",ItemTypeID=" + this.ItemType.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ItemTypeID=1";
            if (this.AddtoSizingChemical.Checked ==true)
                queries[queries.Length - 1] += ",AddAsSizingChemical=1";
            else
                queries[queries.Length - 1] += ",AddAsSizingChemical=0";
            queries[queries.Length - 1] += " where ItemAccountID='" + CodeToUpdate + "'";


            if (AddtoSizingChemical.Checked == true)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "delete from SW_Sizing_Chemicals where ChemicalID='" + CodeToUpdate + "'";
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into SW_Sizing_Chemicals (ChemicalID) Values ('" + this.ItemAccountID.Text + "')";
            }
            else
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "delete from SW_Sizing_Chemicals where ChemicalID='" + this.ItemAccountID.Text + "'";
            }
            
          
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
                    ItemAccountRow["ItemAccountID"] = this.ItemAccountID.Text;
                    ItemAccountRow["ItemAccountName"] = this.ItemAccountName.Text;

                    if (this.ItemType.EditValue != null)
                        ItemAccountRow["ItemTypeID"] = this.ItemType.EditValue.ToString();
                    else
                        ItemAccountRow["ItemTypeID"] = "1";

                    if (this.PartNumber.Text != "")
                        ItemAccountRow["PartNumber"] = this.PartNumber.Text;
                    else
                        ItemAccountRow["PartNumber"] = DBNull.Value;
                    if (this.ItemLocation.EditValue != null)
                        ItemAccountRow["ItemLocation"] = this.ItemLocation.EditValue.ToString();
                    else
                        ItemAccountRow["ItemLocation"] = DBNull.Value;
                    ItemAccountRow["GroupAccountID"] = this.SelectedGroupAccountID.Text;
                    if (this.ItemReorderLevel.EditValue != null)
                        ItemAccountRow["ReOrderLevel"] = this.ItemReorderLevel.EditValue.ToString();
                    else
                        ItemAccountRow["ReOrderLevel"] = "0";
                    if (this.ItemPurchaseUnit.EditValue != null)
                        ItemAccountRow["bUnit"] = this.ItemPurchaseUnit.EditValue.ToString();
                    else
                        ItemAccountRow["bUnit"] = "";
                    if (this.ItemConsumptionUnit.EditValue != null)
                        ItemAccountRow["cUnit"] = this.ItemConsumptionUnit.EditValue.ToString();
                    else
                        ItemAccountRow["cUnit"] = "";
                    if (this.ItemPurchaseRate.EditValue != null)
                        ItemAccountRow["bUnitRate"] = this.ItemPurchaseRate.EditValue.ToString();
                    else
                        ItemAccountRow["bUnitRate"] = "0";
                    if (this.ItemSalesRate.EditValue != null)
                        ItemAccountRow["cUnitRate"] = this.ItemSalesRate.EditValue.ToString();
                    else
                        ItemAccountRow["cUnitRate"] = "0";
                    if (this.ItemUnitRatio.EditValue != null)
                        ItemAccountRow["cUnitinpUnit"] = this.ItemUnitRatio.EditValue.ToString();
                    else
                        ItemAccountRow["cUnitinpUnit"] = "1";

                    if (this.AddtoSizingChemical.Checked == true)
                        ItemAccountRow["AddAsSizingChemical"] = "True";
                    else
                        ItemAccountRow["AddAsSizingChemical"] = "False";
                    this.PODItemAccountIDOpening.EditValue = this.ItemAccountID.EditValue;
                    this.PODItemAccountNameOpening.EditValue = this.ItemAccountName.EditValue;
                    this.RatesOpening.Tag = this.ItemPurchaseRate.EditValue;
                    this.RatesOpening.EditValue = this.ItemPurchaseRate.EditValue;
                    this.UOMOpening.EditValue = this.ItemConsumptionUnit.EditValue;
                    this.UOMOpening.Tag = this.ItemConsumptionUnit.EditValue;
                    this.ItemAccountID.Text = "";
                    this.ItemAccountID.Tag = null;
                    this.ItemAccountName.Text = "";
                    this.ItemUnitRatio.EditValue = null;
                    this.ItemType.EditValue = null;
                    this.ItemLocation.EditValue = null;
                    this.PartNumber.Text = "";
                    this.ItemSalesRate.EditValue = null;
                    this.ItemReorderLevel.EditValue = null;
                    this.ItemPurchaseUnit.EditValue = null;
                    this.ItemPurchaseRate.EditValue = null;
                    this.ItemConsumptionUnit.EditValue = null;
                    SetButtonStates_Item(UserInputMode.View);

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void ItemDeleteExisting()
        {





            if (this.SelectedGroupAccountID.Text == "")
            {
                XtraMessageBox.Show("Group ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemAccountID.Tag == null)
            {
                XtraMessageBox.Show("Item ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            if (this.ItemAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Item ID is invalid must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ItemFocusedRowHandle == -1)
            {
                XtraMessageBox.Show("invalid Item account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string[] queries = new string[0];
            string GRNtoUpdate = this.ItemAccountID.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_Chemicals where ChemicalID='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_ItemAccounts where ItemAccountID='" + GRNtoUpdate + "'";
           


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

                    this.ItemAccountID.Tag = null;
                    this.ItemAccountName.Text = "";
                    this.ItemAccountID.Text = "";
                    this.ItemAccountName.Text = "";
                    this.ItemUnitRatio.EditValue = null;
                    this.ItemType.EditValue = null;
                    this.ItemSalesRate.EditValue = null;
                    this.ItemReorderLevel.EditValue = null;
                    this.ItemPurchaseUnit.EditValue = null;
                    this.ItemPurchaseRate.EditValue = null;
                    this.ItemConsumptionUnit.EditValue = null;
                    this.ItemLocation.EditValue = null;
                    this.PartNumber.Text = "";
                    gridView_Item.DeleteRow(ItemFocusedRowHandle);
                    SetButtonStates_Item(UserInputMode.View);
                    this.Item_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FillItemFromSelectedRow()
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.gridView_Item.GetDataRow(this.gridView_Item.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                    this.ItemAccountID.Text = ItemAccountRow["ItemAccountID"].ToString();
                    this.ItemAccountName.Text = ItemAccountRow["ItemAccountName"].ToString();
                    this.ItemAccountID.Tag = ItemAccountRow["ItemAccountID"].ToString();
                    this.PODItemAccountIDOpening.EditValue = ItemAccountRow["ItemAccountID"].ToString();
                    this.PODItemAccountNameOpening.EditValue = ItemAccountRow["ItemAccountName"].ToString();
                    this.UOMOpening.EditValue = ItemAccountRow["cUnit"].ToString();
                    this.RatesOpening.EditValue = ItemAccountRow["bUnitRate"].ToString();
                    this.RatesOpening.Tag = ItemAccountRow["bUnitRate"].ToString();
                    this.ItemConsumptionUnit.EditValue = ItemAccountRow["cUnit"].ToString();
                    this.ItemPurchaseRate.EditValue = ItemAccountRow["bUnitRate"].ToString();
                    this.ItemPurchaseUnit.EditValue = ItemAccountRow["bUnit"].ToString();
                    this.ItemReorderLevel.EditValue = ItemAccountRow["ReOrderLevel"].ToString();
                    this.ItemSalesRate.EditValue = ItemAccountRow["cUnitRate"].ToString();
                    this.ItemType.EditValue = ItemAccountRow["ItemTypeID"].ToString();
                    this.ItemUnitRatio.EditValue = ItemAccountRow["cUnitInPUnit"].ToString();
                    this.PartNumber.Text = ItemAccountRow["PartNumber"].ToString();
                    if (ItemAccountRow["ItemLocation"].ToString() != "")
                        this.ItemLocation.EditValue = ItemAccountRow["ItemLocation"].ToString();
                    else
                        this.ItemLocation.EditValue = null;
                    if (ItemAccountRow["AddAsSizingChemical"].ToString().ToUpper() == "TRUE")
                    {
                        this.AddtoSizingChemical.Checked = true;
                    }
                    else
                    {
                        this.AddtoSizingChemical.Checked = false;
                    }
                    SetButtonStates_Item(UserInputMode.View);
                }
            }
        }

        private void gridView_Item_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ItemFocusedRowHandle = this.gridView_Item.FocusedRowHandle;
            FillItemFromSelectedRow();
        }

        private void gotoItemAccountTab_Click(object sender, EventArgs e)
        {
            GotoItemTab();
        }

        private void gridView_Group_DoubleClick(object sender, EventArgs e)
        {
            GotoItemTab();
        }

        private void gridView_Group_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
                GotoItemTab();
        }

        private void Item_Add_Click(object sender, EventArgs e)
        {
            this.ItemAccountID.Text = "";
            this.ItemAccountID.Tag = null;
            this.ItemAccountID.EditValue = null;
            this.ItemUnitRatio.EditValue = null;
            this.ItemType.EditValue = null;
            this.ItemSalesRate.EditValue = null;
            this.ItemReorderLevel.EditValue = null;
            this.ItemPurchaseUnit.EditValue = null;
            this.ItemPurchaseRate.EditValue = null;
            this.ItemConsumptionUnit.EditValue = null;
            this.ItemAccountID.Tag = null;
            this.ItemLocation.EditValue = null;
            this.PartNumber.Text = "";
            bool rRes = ItemGetNextAccountNumber();
            SetButtonStates_Item(UserInputMode.Add);
            this.PartNumber.Focus();
        }
        private bool ItemGetNextAccountNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(ItemAccountID,8,6)))+1 as MaxNumber  from ST_ItemAccounts where GroupAccountID='" + SelectedGroupAccountID.Text + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ItemAccountID.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.ItemAccountID.Text = this.SelectedGroupAccountID.Text + iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ItemAccountID.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.ItemAccountID.Text = "";
                return false;
            }
        }

        private void Item_Execute_Click(object sender, EventArgs e)
        {
            if (uiModeItem == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ItemSaveNew();
            }
            else if (uiModeItem == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    //// XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //  return;
                }
                ItemUpdateExisting();
            }
            else if (uiModeItem == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                ItemDeleteExisting();
            }
        }

        private void Item_Edit_Click(object sender, EventArgs e)
        {
            if (this.ItemAccountID.Text == "")
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemAccountID.Tag == null)
            {
                XtraMessageBox.Show("Control ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Item ID is invalid ...must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ItemAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Item ID is invalid must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Item(UserInputMode.Edit);
        }

        private void Item_Delete_Click(object sender, EventArgs e)
        {
            if (this.ItemAccountID.Text == "")
            {
                XtraMessageBox.Show("Item ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ItemAccountID.Tag == null)
            {
                XtraMessageBox.Show("Item ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.ItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Item ID is invalid ...must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ItemAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Item ID is invalid must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_Item(UserInputMode.Delete);
        }

        private void Item_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates_Item(UserInputMode.View);
        }

        private void Item_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Item_Back_Click(object sender, EventArgs e)
        {
            GotoGroupTab();
        }

        private void Control_Add_Click(object sender, EventArgs e)
        {
            this.ControlAccountID.Text = "";
            this.ControlAccountID.Tag = null;
            this.ControlAccountID.EditValue = null;
            bool rRes = GetNextControlAccountNumber();


            SetButtonStates(UserInputMode.Add);
        }

        private void Control_Execute_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiMode == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit,docState.Open);
                if (canProceed == false)
                {
                    //// XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //  return;
                }
                UpdateExisting();
            }
            else if (uiMode == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DeleteExisting();
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

            if (this.ControlAccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates(UserInputMode.Edit);
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

            if (this.ControlAccountID.Text.Length != 3)
            {
                XtraMessageBox.Show("Control ID is invalid ...must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Control ID is invalid must be 3 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates(UserInputMode.Delete);
        }

        private void Control_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void gridView_Item_Click(object sender, EventArgs e)
        {
            FillItemFromSelectedRow();
        }

        private void gridView_Group_Click(object sender, EventArgs e)
        {
            FillGroupFromSelectedRow();
        }

        private void gridView_Control_Click(object sender, EventArgs e)
        {
            FillControlFromSelectedRow();
        }

        private void Control_Print_Click(object sender, EventArgs e)
        {
            if (ControlAccountID.Tag == null)
            {
                XtraMessageBox.Show("Invalid Control Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ControlAccountID.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Control Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query="select * from RST_ItemAccounts where ControlAccountID='"+this.ControlAccountID.Tag.ToString()+"'";
            DataSet ds=WS.svc.Get_DataSet(query);
            if(ds==null)
            {
                XtraMessageBox.Show("No Records Found!","Error",MessageBoxButtons.OK);
                return;
            }
            if(ds.Tables[0].Rows.Count<=0)
            {
                XtraMessageBox.Show("No Records Found!","Error",MessageBoxButtons.OK);
                return;

            }
            Reports.Store_ItemAccounts Items=new Reports.Store_ItemAccounts();
            Items.BeginInit();
            Items.DataSource =ds;
            Items.EndInit();
            Items.ShowPreview();
            
        }

        private void MappedAccountID_EditValueChanged(object sender, EventArgs e)
        {

            if (this.MappedAccountID.EditValue != null)
            {
                string sAccountName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.MappedAccountID.EditValue.ToString());
                if (sAccountName != "")
                    this.MappedAccountName.EditValue = sAccountName;
                else
                    this.MappedAccountName.EditValue = null;
            }
            else
            {
                this.MappedAccountName.EditValue = null;
            }
                  
            
        }

        private void MappedAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.MappedAccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.MappedAccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (this.MappedAccountID.EditValue != null)
                {
                    if (this.MappedAccountID.EditValue.ToString() != "")
                    {
                        Accounts.Account_info info = new Accounts.Account_info();
                        info.FillAccount(this.MappedAccountID.Text);
                        info.ShowDialog();
                    }
                }

            }
        }

        private void ItemConsumptionUnit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl8_Click(object sender, EventArgs e)
        {

        }

        private void ItemLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                ItemLocation.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.StoreItemLocations(ref this.ItemLocation);
            }
        }

        private void ItemPurchaseUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.MeasurementUnits(ref this.ItemPurchaseUnit);
            }
        }

        private void ItemConsumptionUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.MeasurementUnits(ref this.ItemConsumptionUnit);
            }
        }

        private void AssetMappedAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AssetMappedAccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AssetMappedAccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (this.AssetMappedAccountID.EditValue != null)
                {
                    if (this.AssetMappedAccountID.EditValue.ToString() != "")
                    {
                        Accounts.Account_info info = new Accounts.Account_info();
                        info.FillAccount(this.AssetMappedAccountID.Text);
                        info.ShowDialog();
                    }
                }

            }
        }

        private void AssetMappedAccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.AssetMappedAccountID.EditValue != null)
            {
                string sAccountName = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AssetMappedAccountID.EditValue.ToString());
                if (sAccountName != "")
                    this.AssetMappedAccountName.EditValue = sAccountName;
                else
                    this.AssetMappedAccountName.EditValue = null;
            }
            else
            {
                this.AssetMappedAccountName.EditValue = null;
            }
        }

        private void Item_Next_Click(object sender, EventArgs e)
        {
            this.PODItemAccountIDOpening.EditValue = this.ItemAccountID.EditValue;
            this.PODItemAccountNameOpening.EditValue = this.ItemAccountName.EditValue;
            this.RatesOpening.Tag = this.ItemPurchaseRate.EditValue;
            this.RatesOpening.EditValue = this.ItemPurchaseRate.EditValue;
            this.UOMOpening.EditValue = this.ItemConsumptionUnit.EditValue;
            this.UOMOpening.Tag = this.ItemConsumptionUnit.EditValue;
            GotoOpeningTab();
        }
        private bool PODGetNextNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    if (this.RefOpeningNoteNumber.EditValue == null)
                    {
                        XtraMessageBox.Show("Invalid Opening # Selected!", "Error");
                        return false;
                    }
                    query = "select max(Convert(numeric(18),SubString(PRDNO,14,7)))+1 as MaxNumber  from ST_StoreDetails where PRNO='" + this.RefOpeningNoteNumber.EditValue.ToString() + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.RefOpeningDetailNumber.EditValue = null;
                        return false;
                    }
                    iNumber = iNumber.PadLeft(7, '0');
                    this.RefOpeningDetailNumber.EditValue = this.RefOpeningNoteNumber.EditValue.ToString() + iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.RefOpeningDetailNumber.EditValue = null;
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.Suffix.Text = "";
                return false;
            }
        }
        private bool GetNextOpeningNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(PRNO,8,6)))+1 as MaxNumber  from ST_StorePR where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NGOpening.Tag + "' and NumberType='0'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Suffix.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.Suffix.Text = iNumber;
                    this.RefOpeningNoteNumber.EditValue = this.Prefix.Text + this.FinancialYear.Text + iNumber;

                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Suffix.Text = "";
                    this.RefOpeningNoteNumber.EditValue = null;
                    return false;
                }

              



            }
            catch
            {
                this.Suffix.Text = "";
                this.RefOpeningNoteNumber.EditValue = null;
                return false;
            }
        }
        private void POD_AddOpening_Click(object sender, EventArgs e)
        {
            
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Invalid financial year ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            if (this.Prefix.Text == "" || this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            this.Suffix.Text = "";
            this.Suffix.Tag = null;
            this.Suffix.EditValue = null;
           




            if (this.iCodeType.EditValue.ToString() == "0")
            {

                bool rRes = GetNextOpeningNumber();
            }
            if(this.RefOpeningNoteNumber.EditValue!=null)
            {
               bool b= PODGetNextNumber();
               if (b == true)
               {
                   SetButtonStates_Opening(UserInputMode.Add);
                   this.PODQtyOpening.Focus();
               }
                }
            
        }

        private void gridView_Item_DoubleClick(object sender, EventArgs e)
        {
            GotoOpeningTab();
        }
        private void SaveOpening()
        {
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (this.DatedOpening.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.DatedOpening.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.DatedOpening.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.RefOpeningNoteNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Opening Note #", "Error");
                return;
            }
            if (this.RefOpeningDetailNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Opening Detail Note #", "Error");
                return;
            }

            if (this.PODItemAccountIDOpening.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.PODItemAccountIDOpening.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }
            if (this.PODQtyOpening.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string[] queries = new string[0];
            string vnum = "";
            if (this.iCodeType.EditValue.ToString() == "0")
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
                vnum = this.Suffix.Text;

            char vCat = 'G';
            if (NGOpening.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (this.iCodeType.EditValue.ToString() == "1")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Opening Note code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_StorePR (NumberType,PRNO,PRTypeID,iType,iCat,iYear,iStatus,Dated,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.iCodeType.EditValue.ToString() + "','" + vnum + "',7,'" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";



            if (this.DatedOpening.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.DatedOpening.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";




            
                queries[queries.Length - 1] += ",'Opening Entry'";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_StoreDetails (PRNO,PRDNO,ItemAccountID,PlusQty,PlusRate,UOM,Remarks,ConditionID,MC) Values (";
            queries[queries.Length - 1] += "'" + this.RefOpeningNoteNumber.Text + "','" + this.RefOpeningDetailNumber.EditValue.ToString() + "'";

            if (this.PODItemAccountIDOpening.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODItemAccountIDOpening.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PODQtyOpening.EditValue != null)
                queries[queries.Length - 1] += "," + this.PODQtyOpening.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.RatesOpening.EditValue != null)
                queries[queries.Length - 1] += "," + this.RatesOpening.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";



            if (this.UOMOpening.Text != "")
                queries[queries.Length - 1] += ",'" + this.UOMOpening.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODRemarksOpening.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODRemarksOpening.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Condition.EditValue != null)
                queries[queries.Length - 1] += "," + this.Condition.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.MC.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.MC.EditValue.ToString() + "'";
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

                    

                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.RefOpeningNoteNumber.EditValue = null;
                    this.RefOpeningDetailNumber.EditValue = null;
                    this.PODItemAccountIDOpening.EditValue = null;
                    this.PODItemAccountNameOpening.EditValue = null;
                    this.UOMOpening.EditValue = null;
                    this.RatesOpening.EditValue = null;
                    this.PODRemarksOpening.EditValue = null;


                    SetButtonStates_Opening(UserInputMode.View);
                    GotoItemTab();

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void POD_ExecuteOpening_Click(object sender, EventArgs e)
        {
            if (uiModeOpening == UserInputMode.Add)
                SaveOpening();
            else if (uiModeOpening == UserInputMode.Edit)
                UpdateOpening();
            else if (uiModeOpening == UserInputMode.Delete)
                DeleteOpening();
        }
        private void UpdateOpening()
        {
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (this.DatedOpening.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.DatedOpening.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.DatedOpening.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DatedOpening.Focus();
                return;
            }
            if (this.RefOpeningNoteNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Opening Note #", "Error");
                return;
            }
            if (this.RefOpeningDetailNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Opening Detail Note #", "Error");
                return;
            }

            if (this.PODItemAccountIDOpening.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.PODItemAccountIDOpening.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }
            if (this.PODQtyOpening.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            string[] queries = new string[0];
            string vnum = "";
            if (this.iCodeType.EditValue.ToString() == "0")
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
                vnum = this.Suffix.Text;

           
            if (this.iCodeType.EditValue.ToString() == "1")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Opening Note code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StorePR set Dated=";
            if (this.DatedOpening.EditValue != null)
                queries[queries.Length - 1] += "'" + this.DatedOpening.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += "null";





          
            queries[queries.Length - 1] += "where PRNO='"+this.RefOpeningNoteNumber.EditValue.ToString()+"'";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StoreDetails set ";
          

            if (this.PODItemAccountIDOpening.EditValue != null)
                queries[queries.Length - 1] += "ItemAccountID='" + this.PODItemAccountIDOpening.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += "ItemAccountID=null";

            if (this.PODQtyOpening.EditValue != null)
                queries[queries.Length - 1] += ",PlusQty=" + this.PODQtyOpening.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PlusQty=0";

            if (this.RatesOpening.EditValue != null)
                queries[queries.Length - 1] += ",PlusRate=" + this.RatesOpening.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PlusRate=0";



            if (this.UOMOpening.Text != "")
                queries[queries.Length - 1] += ",UOM='" + this.UOMOpening.Text + "'";
            else
                queries[queries.Length - 1] += ",UOM=null";
            if (this.PODRemarksOpening.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.PODRemarksOpening.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            if (this.Condition.EditValue != null)
                queries[queries.Length - 1] += ",ConditionID=" + this.Condition.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ConditionID=null";
            if (this.MC.EditValue != null)
                queries[queries.Length - 1] += ",MC='" + this.MC.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",MC=null";
            queries[queries.Length - 1] += "where PRDNO='"+this.RefOpeningDetailNumber.EditValue.ToString()+"'";



           
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

                    if (this.PODItemAccountIDOpening.EditValue != null)
                    {
                        string[] ParamName = new string[0];
                        string[] ParamValue = new string[0];
                        MachineService.SqlDbType[] dbType = new MachineService.SqlDbType[0];
                        Array.Resize(ref ParamName, 1);
                        Array.Resize(ref ParamValue, 1);
                        Array.Resize(ref dbType, 1);


                        ParamName[0] = "ItemAccountID";
                        ParamValue[0] = this.PODItemAccountIDOpening.EditValue.ToString();
                        dbType[0] = MachineService.SqlDbType.VarChar;

                        string rSp = WS.svc.Execute_StoredProcedure("PROC_UpdateStockForItem", ParamName, ParamValue, dbType);
                        if (rSp != "**SUCCESS##")
                        {
                            XtraMessageBox.Show("Executing Stored Procedure to update stock returned error: " + rSp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.RefOpeningNoteNumber.EditValue = null;
                    this.RefOpeningDetailNumber.EditValue = null;
                    this.PODItemAccountIDOpening.EditValue = null;
                    this.PODItemAccountNameOpening.EditValue = null;
                    this.UOMOpening.EditValue = null;
                    this.RatesOpening.EditValue = null;
                    this.PODRemarksOpening.EditValue = null;


                    SetButtonStates_Opening(UserInputMode.View);
                    GotoItemTab();

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void NGOpening_CheckedChanged(object sender, EventArgs e)
        {
            if (NGOpening.Checked == true)
            {
                NGOpening.Image = MachineEyes.Properties.Resources.N32;
                NGOpening.Tag = "N";
               

                this.Prefix.Text = N_InvoiceOpening;
                if (uiModeOpening == UserInputMode.Add || uiModeOpening == UserInputMode.Edit)
                {
                    if (this.iCodeType.EditValue.ToString() == "0")
                        GetNextOpeningNumber();
                    if (this.RefOpeningNoteNumber.EditValue != null)
                        PODGetNextNumber();
                }
            }
            else
            {
                NGOpening.Tag = "G";
               
                NGOpening.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_InvoiceOpening;
                if (uiModeOpening == UserInputMode.Add)
                {
                    if (this.iCodeType.EditValue.ToString() == "0")
                        GetNextOpeningNumber();
                    if (this.RefOpeningNoteNumber.EditValue != null)
                        PODGetNextNumber();
                }
            }
        }

        private void POD_BackOpening_Click(object sender, EventArgs e)
        {
            this.RefOpeningDetailNumber.Tag = null;
            this.RefOpeningNoteNumber.Tag = null;
            GotoItemTab();
        }

        private void RatesOpening_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (this.RatesOpening.Tag != null)
                    this.RatesOpening.EditValue = this.RatesOpening.Tag.ToString();
            }
        }

        private void UOMOpening_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (this.UOMOpening.Tag != null)
                    this.UOMOpening.EditValue = this.UOMOpening.Tag.ToString();
            }
        }

        private void POD_CancelOpening_Click(object sender, EventArgs e)
        {

        }

        private void POD_CloseOpening_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DeleteOpening()
        {
            string[] queries = new string[0];
            string GRNtoUpdate = this.RefOpeningNoteNumber.Tag.ToString();
            if (this.PODItemAccountIDOpening.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Selection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Opening Note  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  ST_StoreDetails where PRNO='" + GRNtoUpdate + "' and ItemAccountID='"+this.PODItemAccountIDOpening.EditValue.ToString()+"'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_StorePR where PRNO='" + GRNtoUpdate + "'";
     

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

                    if (this.PODItemAccountIDOpening.EditValue != null)
                    {
                        string[] ParamName = new string[0];
                        string[] ParamValue = new string[0];
                        MachineService.SqlDbType[] dbType = new MachineService.SqlDbType[0];
                        Array.Resize(ref ParamName, 1);
                        Array.Resize(ref ParamValue, 1);
                        Array.Resize(ref dbType, 1);


                        ParamName[0] = "ItemAccountID";
                        ParamValue[0] = this.PODItemAccountIDOpening.EditValue.ToString();
                        dbType[0] = MachineService.SqlDbType.VarChar;

                        string rSp = WS.svc.Execute_StoredProcedure("PROC_UpdateStockForItem", ParamName, ParamValue, dbType);
                        if (rSp != "**SUCCESS##")
                        {
                            XtraMessageBox.Show("Executing Stored Procedure to update stock returned error: " + rSp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.RefOpeningNoteNumber.EditValue = null;
                    this.RefOpeningDetailNumber.EditValue = null;
                    this.PODItemAccountIDOpening.EditValue = null;
                    this.PODItemAccountNameOpening.EditValue = null;
                    this.UOMOpening.EditValue = null;
                    this.RatesOpening.EditValue = null;
                    this.PODRemarksOpening.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.RefOpeningNoteNumber.Tag = null;
                    this.RefOpeningDetailNumber.Tag = null;
                   

                    SetButtonStates(UserInputMode.View);
                   
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void POD_DeleteOpening_Click(object sender, EventArgs e)
        {
            if (this.RefOpeningDetailNumber.Tag==null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.RefOpeningDetailNumber.Tag==null )
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SetButtonStates_Opening(UserInputMode.Delete);
        }

        private void POD_EditOpening_Click(object sender, EventArgs e)
        {
            if (this.RefOpeningDetailNumber.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.RefOpeningDetailNumber.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            SetButtonStates_Opening(UserInputMode.Edit);
        }
    }
}