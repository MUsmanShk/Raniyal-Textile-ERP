using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.View
{
    public partial class Email_Notifications: DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
       
        UserInputMode uiModePOD;
        private string G_Invoice;
       
        DataRow ItemAccountRow;
 
        
        int ItemFocusedRowHandle;
        public Email_Notifications()
        {
            InitializeComponent();
           
            G_Invoice = "DRQ";
           
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
           
            FillCombos fc = new FillCombos();
       
            fc.Email_EncryptedConnections(ref this.SMTPEncryptionTypes);
            fc.Email_AlertTypes(ref this.NotificationAlertType);
            Fill_Requisition("0");
        }
        private void PODSaveNew()
        {

            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationNumber.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
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
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationAlertType.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification Alert Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationPersonName.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification Person", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue.ToString().Contains("@") == false)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue.ToString().Contains(".") == false)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.Prefix.Text + this.FinancialYear.Text + this.NotificationNumber.Text;
          

            char vCat = 'G';
           

                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Requisition  code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
      
          




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into Email_NotificationAddresses (iType,iYear,iCat,iStatus,Notification_Number,Notification_Person,Notification_Email,Notification_TypeID,Notification_isActive) Values (";
            queries[queries.Length - 1] += "'"+this.Prefix.Text+"','"+this.FinancialYear.Text+"','"+vCat+"',0,'" + vnum + "'";

           

            if (this.NotificationPersonName.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.NotificationPersonName.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.NotificationEmail.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.NotificationEmail.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.NotificationAlertType.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.NotificationAlertType.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Notification_isActive.Checked ==true )
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            

           
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





                    DataView gdv = (DataView)this.PODGridView_Item.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                   
                    if (this.NotificationPersonName.EditValue != null) _ravi["Notification_Person"] = this.NotificationPersonName.EditValue.ToString();
                    if (this.NotificationEmail.EditValue != null) _ravi["Notification_Email"] = this.NotificationEmail.EditValue.ToString();
                    _ravi["Notification_Number"] = vnum;
                   

                    if (this.NotificationAlertType.EditValue!=null) _ravi["Notification_TypeID"] = this.NotificationAlertType.EditValue.ToString();
                    if (this.Notification_isActive.Checked == true) _ravi["Notification_isActive"] = "True"; else _ravi["Notification_isActive"] = "False";
                    _ravi["iType"] = this.Prefix.Text;
                    _ravi["iYear"] = this.FinancialYear.Text;
                    _ravi["iCat"] = vCat;
                    _ravi["iStatus"] = "0";
                   
                    
                    gdt.Rows.Add(_ravi);


                    this.NotificationNumber.EditValue = null;

                    this.NotificationPersonName.EditValue = null;
                    this.NotificationEmail.EditValue = null;
                    this.Notification_isActive.Checked = false;
                    SetButtonStates_POD(UserInputMode.View);
                    this.POD_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PODUpdateExisting()
        {



            string vnum = "";
            string vnumtoUpdate = "";
            string[] queries = new string[0];



            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationNumber.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.NotificationNumber.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
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
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationAlertType.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification Alert Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationPersonName.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification Person", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue == null)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue.ToString().Contains("@") == false)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationEmail.EditValue.ToString().Contains(".") == false)
            {
                XtraMessageBox.Show("invalid Notification email", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            vnum = this.Prefix.Text + this.FinancialYear.Text + this.NotificationNumber.Text;
            vnumtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.NotificationNumber.Tag.ToString();
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update Email_NotificationAddresses set ";
            queries[queries.Length - 1] += "Notification_Number='" + vnum + "' ";



           

           
            
          

           
            if (this.NotificationAlertType.EditValue != null)
                queries[queries.Length - 1] += ",Notification_TypeID='" + this.NotificationAlertType.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Notification_TypeID=null";
           
            if (this.NotificationPersonName.EditValue != null)
                queries[queries.Length - 1] += ",Notification_Person='" + this.NotificationPersonName.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Notification_Person=null";
            if (this.NotificationEmail.EditValue != null)
                queries[queries.Length - 1] += ",Notification_Email='" + this.NotificationEmail.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Notification_Email=null";
            if (this.Notification_isActive.Checked  ==true)
                queries[queries.Length - 1] += ",Notification_isActive=1";
            else
                queries[queries.Length - 1] += ",Notification_isActive=0";
            queries[queries.Length - 1] += " where Notification_Number='" + vnumtoUpdate + "'";

            
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
                    DataRow _ravi = ItemAccountRow;

                    if (this.NotificationPersonName.EditValue != null) _ravi["Notification_Person"] = this.NotificationPersonName.EditValue.ToString();
                    if (this.NotificationEmail.EditValue != null) _ravi["Notification_Email"] = this.NotificationEmail.EditValue.ToString();
                    _ravi["Notification_Number"] = vnum;


                    if (this.NotificationAlertType.EditValue != null) _ravi["Notification_TypeID"] = this.NotificationAlertType.EditValue.ToString();
                    if (this.Notification_isActive.Checked == true) _ravi["Notification_isActive"] = "True";
                    else
                        _ravi["Notification_isActive"] = "False";
                    _ravi["iType"] = this.Prefix.Text;
                    _ravi["iYear"] = this.FinancialYear.Text;
                    _ravi["iCat"] = "0";
                    _ravi["iStatus"] = "0";
                   
                  
                   
                    SetButtonStates_POD(UserInputMode.View);
                    
                   
                  
                    this.NotificationPersonName.EditValue = null;
                    this.NotificationEmail.EditValue = null;
                    this.Notification_isActive.Checked = false;
                    this.POD_Add.Focus();

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PODDeleteExisting()
        {





            string vnum = "";
            string vnumtoUpdate = "";
            string[] queries = new string[0];



            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.NotificationNumber.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.NotificationNumber.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Text == "")
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Text.Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
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
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
         
            vnum = this.Prefix.Text + this.FinancialYear.Text + this.NotificationNumber.Text;
            vnumtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.NotificationNumber.Tag.ToString();



            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item POD # " + vnumtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from Email_NotificationAddresses where Notification_Number='" + vnumtoUpdate + "'";
         

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

                   
                    this.PODGridView_Item.DeleteRow(ItemFocusedRowHandle);
                  
                    this.NotificationEmail.EditValue = null;
                    this.NotificationPersonName.EditValue = null;
                    this.Notification_isActive.Checked = false;
                    SetButtonStates_POD(UserInputMode.View);
                    this.POD_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetButtonStates_POD(UserInputMode uim)
        {
            uiModePOD = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.POD_Execute.Enabled = false;
                    this.POD_Cancel.Enabled = false;
                    this.POD_Add.Enabled = true;




                    if (this.NotificationNumber.Tag != null)
                    {
                        if (this.NotificationNumber.Tag.ToString() != "")
                        {

                            this.POD_Edit.Enabled = true;
                            this.POD_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.POD_Edit.Enabled = false;
                            this.POD_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        POD_Edit.Enabled = false;
                        POD_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    
                    this.POD_Add.Enabled = false;
                    this.POD_Cancel.Enabled = true;
                    POD_Execute.Enabled = true;
                    POD_Edit.Enabled = false;

                    POD_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    POD_Add.Enabled = false;
                    POD_Cancel.Enabled = true;
                    POD_Execute.Enabled = true;
                    POD_Edit.Enabled = false;

                    POD_Delete.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    POD_Add.Enabled = false;
                    POD_Cancel.Enabled = true;
                    POD_Execute.Enabled = true;
                    POD_Edit.Enabled = false;

                    POD_Delete.Enabled = false;


                    break;
                default:
                    break;
            }
        }
     
      
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(Notification_Number,8,6)))+1 as MaxNumber  from Email_NotificationAddresses where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.NotificationNumber.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.NotificationNumber.Text = iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.NotificationNumber.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.NotificationNumber.Text = "";
                return false;
            }
        }

       
        
       

      

     

      

        private void POD_Add_Click(object sender, EventArgs e)
        {
         
            
           
            this.NotificationPersonName.EditValue = null;
           
            this.NotificationNumber.EditValue = null;
           

            bool rRes = GetNextInvoiceNumber();
            SetButtonStates_POD(UserInputMode.Add);
          
        }
        private void SelectPODRecord()
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.PODGridView_Item.GetDataRow(this.PODGridView_Item.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                   
                    this.NotificationPersonName.EditValue = ItemAccountRow["Notification_Person"].ToString();
                    this.NotificationEmail.EditValue = ItemAccountRow["Notification_Email"].ToString();
                   
                    if (ItemAccountRow["Notification_isActive"].ToString().ToUpper() == "TRUE")
                        this.Notification_isActive.Checked = true;
                    else
                        this.Notification_isActive.Checked = false;
                    this.Prefix.Text = ItemAccountRow["iType"].ToString();
                    this.FinancialYear.Text = ItemAccountRow["iYear"].ToString();
                    this.Prefix.Tag = ItemAccountRow["iType"].ToString();
                    this.FinancialYear.Tag = ItemAccountRow["iYear"].ToString();
                   
                    this.NotificationNumber.Text = ItemAccountRow["Notification_Number"].ToString().Substring(7, 6);
                    this.NotificationNumber.Tag = ItemAccountRow["Notification_Number"].ToString().Substring(7, 6);
                   
                    SetButtonStates_POD(UserInputMode.View);
                }
            }
        }
        private void PODGridView_Item_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ItemFocusedRowHandle = this.PODGridView_Item.FocusedRowHandle;
            SelectPODRecord();
        }

        private void POD_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePOD == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                PODSaveNew();
            }
            else if (uiModePOD == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit,docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      return;
                }
                PODUpdateExisting();
            }
            else if (uiModePOD == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                PODDeleteExisting();
            }
        }

        private void POD_Edit_Click(object sender, EventArgs e)
        {
            if (this.NotificationNumber.Tag == null)
            {
                XtraMessageBox.Show("Requisition  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            SetButtonStates_POD(UserInputMode.Edit);
        }

        private void POD_Delete_Click(object sender, EventArgs e)
        {
            if (this.NotificationNumber.Tag == null)
            {
                XtraMessageBox.Show("Requisition Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_POD(UserInputMode.Delete);
        }

        private void POD_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates_POD(UserInputMode.View);
        }

        private void PODItemAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow ;
                sRow = Program.MainWindow.StoreAccountsList.SelectedRow;
                Program.MainWindow.StoreAccountsList.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                   
                    this.NotificationPersonName.EditValue = sRow.PrimaryString;
                    try
                    {
                        
                        this.NotificationAlertType.EditValue = sRow.SelectedDataRow["bUnit"].ToString() == "" ? null : sRow.SelectedDataRow["bUnit"].ToString();
                       
                        this.NotificationEmail.EditValue = sRow.SelectedDataRow["PartNumber"].ToString() == "" ? null : sRow.SelectedDataRow["PartNumber"].ToString();
                    }
                    catch(Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PO_View_Click(object sender, EventArgs e)
        {
            
                Fill_Requisition(this.NotificationAlertType.EditValue.ToString());

          
        }
        private void Fill_Requisition(string AlertTypeID)
        {


           
            try
            {
                this.NotificationAlertType.EditValue = AlertTypeID;
                DataSet ds = WS.svc.Get_DataSet("Select * from Email_NotificationAddresses where Notification_TypeID='" + AlertTypeID + "'");
                
                if (ds == null) return;

                
                this.PODGrid_Item.DataSource = ds.Tables[0];


               
              


               
           
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        

       
     
        private void PODGridView_Item_Click(object sender, EventArgs e)
        {
            SelectPODRecord();
        }

        private void PODGridView_Item_DoubleClick(object sender, EventArgs e)
        {
            SelectPODRecord();
        }

        private void PO_Print_Click(object sender, EventArgs e)
        {
            if (this.PO_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PO #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MachineEyes.Classes.Printing.Print_ST_PO(this.PO_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void POD_Print_Click(object sender, EventArgs e)
        {
            if (this.PO_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PO #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MachineEyes.Classes.Printing.Print_ST_PO(this.PO_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void Email_Notifications_Load(object sender, EventArgs e)
        {
            try
            {
                MachineService.Email_SMTPServerSettings smtp = WS.svc.Get_SMTPCurrentSettings();
                if (smtp != null)
                {
                    this.SMTP_SPA.Checked = smtp.SMTP_SPA;
                    this.SMTPEncryptionTypes.EditValue = smtp.SMTP_EncryptionConnectionType;
                    this.SMTPIfRequireEncryption.Checked = smtp.SMTP_isEncrypted;
                    this.SMTPPassword.Text = Classes.Security.DecryptData("1,", smtp.Password);
                    this.SMTPPort.Text = smtp.SMTP_Port;
                    this.SMTPServer.Text = smtp.SMTP_Server;
                    this.SMTPUserName.Text = smtp.UserName;
                   
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Loading EmailSettings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

        }

        private void SMTP_UpdateSettings_Click(object sender, EventArgs e)
        {
            if(this.SMTPEncryptionTypes.EditValue==null)
            {
                XtraMessageBox.Show("Select Encryption Connection Type","Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
             if(this.SMTPServer.EditValue==null)
            {
                XtraMessageBox.Show("Select SMTP Server","Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to update email SMTP server Settings ?", "SMTP", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
             MachineService.Email_SMTPServerSettings smtp = new MachineService.Email_SMTPServerSettings();
             if (smtp != null)
             {
                smtp.SMTP_SPA = this.SMTP_SPA.Checked;
                smtp.SMTP_EncryptionConnectionType= this.SMTPEncryptionTypes.EditValue.ToString();
                 smtp.SMTP_isEncrypted = this.SMTPIfRequireEncryption.Checked;
                smtp.Password = Classes.Security.EncryptData("1,", this.SMTPPassword.Text);
                 smtp.SMTP_Port = this.SMTPPort.Text;
                smtp.SMTP_Server= this.SMTPServer.Text;
                smtp.UserName = this.SMTPUserName.Text;
                 string s = WS.svc.Set_SMTPCurrentSettings(smtp);
                 if (s != "**SUCCESS##")
                 {
                     XtraMessageBox.Show("Invalid SMTP Settings! " + s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 else
                 {
                     this.Close();
                 }
             }

        }

        private void NotificationAlertType_EditValueChanged(object sender, EventArgs e)
        {
            if(this.NotificationAlertType.EditValue!=null)
            Fill_Requisition(this.NotificationAlertType.EditValue.ToString());
        }

       
       
    }
}