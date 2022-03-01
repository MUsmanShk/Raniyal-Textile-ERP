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
    public partial class Store_PurchaseOrder : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePO;
        UserInputMode uiModePOD;
        private string G_Invoice;
        private string N_Invoice;
        DataRow ItemAccountRow;
        
        int ItemFocusedRowHandle;
        public Store_PurchaseOrder()
        {
            InitializeComponent();
           
            G_Invoice = "771";
            N_Invoice = "781";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
            fc.Departments_Sub(ref this.PODDepartment);
        }
        private void PODSaveNew()
        {
            if (this.SelectedPONO.EditValue==null)
            {
                XtraMessageBox.Show("Invalid PO #", "Error");
                return;
            }
           
            if (this.PODItemAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.PODItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }
            if (this.PODQty.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.PODLPR.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Last Purchase Rate...Enter Estimated value if price is unknown", "Error", MessageBoxButtons.OK);
                return;
            }

            if (Settings.Store_BoundPurcahseOrderWithApproval == true)
            {
                if (this.PODPurchaseRequisitionNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.PODPurchaseRequisitionNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string[] queries = new string[0];
            string vnum = "";

            vnum = this.PODNumber.EditValue.ToString();




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_PurchaseOrderDetails (PONO,PODNO,ItemAccountID,RequisitionNumber,Qty,LPR,LPD,SubDepartmentID,ShedID,LoomID,LoomName,UOM,Remarks) Values (";
            queries[queries.Length - 1] += "'" + this.SelectedPONO.Text + "','" + this.PODNumber.EditValue.ToString() + "'";

            if (this.PODItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODPurchaseRequisitionNo.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODPurchaseRequisitionNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODQty.EditValue != null)
                queries[queries.Length - 1] += "," + this.PODQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PODLPR.EditValue != null)
                if(this.PODLPR.EditValue.ToString()!="")
                queries[queries.Length - 1] += "," + this.PODLPR.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
            else
                queries[queries.Length - 1] += ",0";
            if (this.PODLPD.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODLPD.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PODDepartment.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODShedID.EditValue != null)
                if(this.PODShedID.EditValue.ToString()!="")
                queries[queries.Length - 1] += "," + this.PODShedID.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PODLoomNumber.Tag != null)
                queries[queries.Length - 1] += "," + this.PODLoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODLoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODLoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODUOM.Text != "")
                queries[queries.Length - 1] += ",'" + this.PODUOM.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODRemarks.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODRemarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ")";


            if (this.PODPurchaseRequisitionNo.EditValue != null)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "update ST_DepartmentStoreRequisition set RequisitionStatusID='4',PODNO='" + vnum + "' where RequisitionNumber='" + this.PODPurchaseRequisitionNo.EditValue.ToString() + "'";
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
                    



                 

                    DataView gdv = (DataView)this.PODGridView_Item.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["ItemAccountID"] = this.PODItemAccountID.EditValue.ToString();
                    if (this.PODItemAccountName.EditValue != null) _ravi["ItemAccountName"] = this.PODItemAccountName.EditValue.ToString();
                    _ravi["PONO"] = this.SelectedPONO.EditValue.ToString();
                    _ravi["PODNO"] = this.PODNumber.EditValue.ToString();
                    if (this.PODQty.EditValue != null) _ravi["QTY"] = this.PODQty.EditValue.ToString();
                    if (this.PODLPR.EditValue != null)
                    {
                        if(this.PODLPR.EditValue.ToString()!="")
                        _ravi["LPR"] = this.PODLPR.EditValue.ToString();
                    }
                    if (this.PODLPD.EditValue != null) _ravi["LPD"] = this.PODLPD.DateTime.ToString();
                    if (this.PODPurchaseRequisitionNo.EditValue != null) _ravi["RequisitionNumber"] = this.PODPurchaseRequisitionNo.EditValue.ToString();
                    if (this.PODDepartment.EditValue != null) _ravi["SubDepartmentID"] = this.PODDepartment.EditValue.ToString();
                    if (this.PODShedID.EditValue != null) { if (this.PODShedID.EditValue.ToString() != "") _ravi["ShedID"] = this.PODShedID.EditValue.ToString(); }
                    if (this.PODLoomNumber.Tag != null) _ravi["LoomID"] = this.PODLoomNumber.Tag.ToString();
                    if (this.PODLoomNumber.EditValue != null) _ravi["LoomName"] = this.PODLoomNumber.EditValue.ToString();

                    if (this.PODUOM.Text != "") _ravi["UOM"] = this.PODUOM.Text;
                    if (this.PODRemarks.Text != "") _ravi["remarks"] = this.Remarks.Text;
                    
                    gdt.Rows.Add(_ravi);

                    
                    this.PODNumber.EditValue = null;
                    this.PODItemAccountID.Tag = null;
                    this.PODItemAccountID.EditValue = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
                    this.PODPurchaseRequisitionNo.Tag = null;
                    this.PODLPR.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODUOM.Text = "";
                    this.PODDepartment.EditValue = null;
                    this.PODItemAccountName.EditValue = null;
                    this.PODLoomNumber.EditValue = null;
                    this.PODLoomNumber.Tag = null;
                    this.PODLPD.EditValue = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
                    this.PODQty.EditValue = null;
                    this.PODRemarks.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODStock.EditValue = null;
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
            if (this.SelectedPONO.EditValue==null)
            {
                XtraMessageBox.Show("PO  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.PODNumber.EditValue == null)
            {
                XtraMessageBox.Show("invalid POD # ", "Error");
                return;
            }
            if (this.PODItemAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Item ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.PODItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("Item ID is invalid ...must be 13 characters", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (this.PODLPR.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Last Purchase Rate", "Error", MessageBoxButtons.OK);
                return;
            }
            if (Settings.Store_BoundIssueNoteWithApproval == true)
            {
                if (this.PODPurchaseRequisitionNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.PODPurchaseRequisitionNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (this.PODPurchaseRequisitionNo.Tag == null)
                {
                    XtraMessageBox.Show("Old Requisition is invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.PODPurchaseRequisitionNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Old Requisition invalid requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string[] queries = new string[0];
            
            string CodeToUpdate = this.PODNumber.EditValue.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_PurchaseOrderDetails set ";
            queries[queries.Length - 1] += "PONO='" + this.SelectedPONO.EditValue.ToString() + "', PODNO='" + this.PODNumber.EditValue.ToString() + "' ";



            if (this.PODItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",ItemAccountID='" + this.PODItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountID=null";

            if (this.PODQty.EditValue != null)
                queries[queries.Length - 1] += ",QTY=" + this.PODQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",QTY=0";

            if (this.PODLPR.EditValue != null)
                queries[queries.Length - 1] += ",LPR=" + this.PODLPR.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",LPR=0";
            if (this.PODLPD.EditValue != null)
                queries[queries.Length - 1] += ",LPD='" + this.PODLPD.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",LPD=null";

            if (this.PODDepartment.EditValue != null)
                queries[queries.Length - 1] += ",SubDepartmentID='" + this.PODDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SubDepartmentID=null";
            if (this.PODShedID.EditValue != null)
                if(this.PODShedID.EditValue.ToString()!="")
                queries[queries.Length - 1] += ",ShedID=" + this.PODShedID.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",ShedID=null";
            else
                queries[queries.Length - 1] += ",ShedID=null";

            if (this.PODLoomNumber.Tag != null)
                queries[queries.Length - 1] += ",LoomID=" + this.PODLoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",LoomID=null";
            if (this.PODLoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",LoomName='" + this.PODLoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Loomname=null";
            if (this.PODUOM.Text != "")
                queries[queries.Length - 1] += ",UOM='" + this.PODUOM.Text + "'";
            else
                queries[queries.Length - 1] += ",UOM=null";
            if (this.PODRemarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.PODRemarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
          

            queries[queries.Length - 1] += " where PODNO='" + CodeToUpdate + "'";

            if (this.PODPurchaseRequisitionNo.EditValue != null)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "update ST_DepartmentStoreRequisition set RequisitionStatusID='1',PODNO=null where RequisitionNumber='" + this.PODPurchaseRequisitionNo.Tag.ToString() + "'";
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "update ST_DepartmentStoreRequisition set RequisitionStatusID='4',PODNO='" + CodeToUpdate + "' where RequisitionNumber='" + this.PODPurchaseRequisitionNo.EditValue.ToString() + "'";
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
                    ItemAccountRow["ItemAccountID"] = this.PODItemAccountID.EditValue.ToString();
                    if(this.PODItemAccountName.EditValue!=null)ItemAccountRow["ItemAccountName"] = this.PODItemAccountName.EditValue.ToString();
                    ItemAccountRow["PONO"] = this.SelectedPONO.EditValue.ToString();
                    ItemAccountRow["PODNO"] = this.PODNumber.EditValue.ToString();
                    if (this.PODQty.EditValue != null) ItemAccountRow["QTY"] = this.PODQty.EditValue.ToString();
                    if (this.PODLPR.EditValue != null)
                    {
                        if (this.PODLPR.EditValue.ToString() != "")
                            ItemAccountRow["LPR"] = this.PODLPR.EditValue.ToString();
                    }
                    if(this.PODLPD.EditValue != null)ItemAccountRow["LPD"] =  this.PODLPD.DateTime.ToString();
                    if (this.PODPurchaseRequisitionNo.EditValue != null) ItemAccountRow["RequisitionNumber"] = this.PODPurchaseRequisitionNo.EditValue.ToString();
                    if (this.PODDepartment.EditValue != null) ItemAccountRow["SubDepartmentID"] = this.PODDepartment.EditValue.ToString();
                    if (this.PODShedID.EditValue != null) { if(this.PODShedID.EditValue.ToString()!="") ItemAccountRow["ShedID"] = this.PODShedID.EditValue.ToString(); }
                    if (this.PODLoomNumber.Tag != null) ItemAccountRow["LoomID"] = this.PODLoomNumber.Tag.ToString();
                    if (this.PODLoomNumber.EditValue != null) ItemAccountRow["LoomName"] = this.PODLoomNumber.EditValue.ToString();

                    if (this.PODUOM.Text != "") ItemAccountRow["UOM"] = this.PODUOM.Text;
                    if (this.PODRemarks.Text != "") ItemAccountRow["remarks"] = this.Remarks.Text;
                   
                  


                   
                    SetButtonStates_POD(UserInputMode.View);
                    this.PODNumber.EditValue = null;
                    this.PODItemAccountID.Tag = null;
                    this.PODItemAccountID.EditValue = null;

                    this.PODLPR.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODUOM.Text = "";
                    this.PODDepartment.EditValue = null;
                    this.PODItemAccountName.EditValue = null;
                    this.PODLoomNumber.EditValue = null;
                    this.PODLoomNumber.Tag = null;
                    this.PODLPD.EditValue = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
                    this.PODQty.EditValue = null;
                    this.PODRemarks.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODStock.EditValue = null;
                    this.PODPurchaseRequisitionNo.Tag = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
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





            if (this.SelectedPONO.EditValue==null )
            {
                XtraMessageBox.Show("PO #  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.PODNumber.EditValue == null)
            {
                XtraMessageBox.Show("POD ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            string[] queries = new string[0];
            string GRNtoUpdate = this.PODNumber.EditValue.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item POD # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_PurchaseOrderDetails where PODNO='" + GRNtoUpdate + "'";
            if (this.PODPurchaseRequisitionNo.Tag != null)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "update ST_DepartmentStoreRequisition set RequisitionStatusID='1',PODNO=null where RequisitionNumber='" + this.PODPurchaseRequisitionNo.Tag.ToString() + "'";
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

                   
                    this.PODGridView_Item.DeleteRow(ItemFocusedRowHandle);
                    this.PODNumber.EditValue = null;
                    this.PODItemAccountID.Tag = null;
                    this.PODItemAccountID.EditValue = null;

                    this.PODLPR.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODUOM.Text = "";
                    this.PODDepartment.EditValue = null;
                    this.PODItemAccountName.EditValue = null;
                    this.PODLoomNumber.EditValue = null;
                    this.PODLoomNumber.Tag = null;
                    this.PODLPD.EditValue = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
                    this.PODQty.EditValue = null;
                    this.PODRemarks.EditValue = null;
                    this.PODROL.EditValue = null;
                    this.PODStock.EditValue = null;
                    this.PODPurchaseRequisitionNo.Tag = null;
                    this.PODPurchaseRequisitionNo.EditValue = null;
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




                    if (this.PODNumber.EditValue != null)
                    {
                        if (this.PODItemAccountID.Tag != null)
                        {
                            if (this.PODItemAccountID.Tag.ToString() != "")
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
        private void PO_Add_Click(object sender, EventArgs e)
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



            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState("U"));
            this.Suffix.Text = "";
            this.Suffix.Tag = null;
            this.Suffix.EditValue = null;
            this.Remarks.EditValue = null;
            this.Remarks.EditValue = null;
           



            if (this.iCodeType.EditValue.ToString() == "0")
            {

                bool rRes = GetNextInvoiceNumber();
            }

            SetButtonStates(UserInputMode.Add);
        }
        private void PO_Edit_Click(object sender, EventArgs e)
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

            if (this.Suffix.Tag == null || this.Prefix.Tag == null || this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Suffix.Tag.ToString() == "" || this.Prefix.Tag.ToString() == "" || this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SetButtonStates(UserInputMode.Edit);
        }
        private void SetButtonStates(UserInputMode uim)
        {
            uiModePO = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    PO_Execute.Enabled = false;
                    PO_Cancel.Enabled = false;
                    PO_Add.Enabled = true;

                    PO_View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            PO_Edit.Enabled = true;
                            PO_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            PO_Edit.Enabled = false;
                            PO_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        PO_Edit.Enabled = false;
                        PO_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";

                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_View.Enabled = false;
                    PO_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_Delete.Enabled = false;
                    PO_View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    PO_Add.Enabled = false;
                    PO_Cancel.Enabled = true;
                    PO_Execute.Enabled = true;
                    PO_Edit.Enabled = false;

                    PO_Delete.Enabled = false;
                    PO_View.Enabled = false;

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
                    query = "select max(Convert(numeric(18),SubString(PONO,8,6)))+1 as MaxNumber  from ST_PurchaseOrder where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Suffix.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.Suffix.Text = iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Suffix.Text = "";
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
        private bool PODGetNextNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    if (this.SelectedPONO.EditValue == null)
                    {
                        XtraMessageBox.Show("Invalid PO Selected!", "Error");
                        return false;
                    }
                    query = "select max(Convert(numeric(18),SubString(PODNO,14,7)))+1 as MaxNumber  from ST_PurchaseOrderDetails where PONO='"+this.SelectedPONO.EditValue.ToString()+"'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.PODNumber.EditValue = null;
                        return false;
                    }
                    iNumber = iNumber.PadLeft(7, '0');
                    this.PODNumber.EditValue= this.SelectedPONO.EditValue.ToString() +  iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.PODNumber.EditValue = null;
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
        private void gotoPODTab(bool GetRecords)
        {
            if (this.SelectedPONO.EditValue == null) return;
            if (this.PO_Print.Tag == null) return;
            DataSet ds = WS.svc.Get_DataSet("Select ItemAccountID, ItemAccountName, QTY, UOM,PODNO, PONO, LPR, LPD, SubDepartmentID, ShedID, LoomID, LoomName, Remarks,RequisitionNumber from RST_PurchaseOrderDetails where PONO='" + this.SelectedPONO.EditValue.ToString() + "'");
            if (ds != null)
            {
                this.PODGrid_Item.DataSource = ds.Tables[0];
                for (int x = 4; x < ds.Tables[0].Columns.Count; x++)
                {
                    this.PODGridView_Item.Columns[x].Visible = false;
                }

            }

            this.xtraTabPage_PO.PageEnabled = false;
            this.xtraTabPage_DiscountTaxes.PageEnabled = false;
            this.xtraTabPage_POD.PageEnabled = true;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_POD;
        }
        private void gotoPOTab()
        {
            this.xtraTabPage_PO.PageEnabled = true;
            this.xtraTabPage_POD.PageEnabled = false;
            this.xtraTabPage_DiscountTaxes.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PO;
        }
        
        private void SaveNew()
        {
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }

         


            string[] queries = new string[0];
            string vnum = "";
            if (this.iCodeType.EditValue.ToString() == "0")
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
                vnum = this.Suffix.Text;

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (this.iCodeType.EditValue.ToString() == "1")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Purchase Order list  code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_PurchaseOrder (NumberType,POTypeID,PONO,iType,iCat,iYear,iStatus,Dated,AccountID_V,Mapped_ID,doDiscount,Discountpercent,DiscountAmount,doGST,GSTPercent,GSTAmount,doWHT,WHTPercent,WHTAmount,doWHST,WHSTPercent,WHSTAmount,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.iCodeType.EditValue.ToString() + "',"+this.POTypeID.EditValue.ToString()+",'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            

            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.AccountID_V.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.AccountID_V.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Mapped_ID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Mapped_ID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.doDiscount.Checked ==true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doDiscount.Checked == true && this.DiscountPercent.EditValue!=null)
                queries[queries.Length - 1] += ","+this.DiscountPercent.EditValue.ToString()+"";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doDiscount.Checked == true && this.DiscountAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.DiscountAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.doGST.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doGST.Checked == true && this.GSTPercent.EditValue != null)
                queries[queries.Length - 1] += "," + this.GSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doGST.Checked == true && this.GSTAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.GSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doWHT.Checked == true && this.WHTPercent.EditValue != null)
                queries[queries.Length - 1] += "," + this.WHTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doWHT.Checked == true && this.WHTAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.WHTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doWHST.Checked == true)
                queries[queries.Length - 1] += ",1";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doWHST.Checked == true && this.WHSTPercent.EditValue != null)
                queries[queries.Length - 1] += "," + this.WHSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.doWHST.Checked == true && this.WHSTAmount.EditValue != null)
                queries[queries.Length - 1] += "," + this.WHSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
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
                    
                    this.PO_Print.Tag = vnum;
                    this.SelectedPONO.EditValue = vnum;
                    this.AccountName_V.Text = "";
                    this.AccountID_V.EditValue = null;
                    this.Mapped_ID.EditValue = null;
                    this.doGST.Checked = false;
                    this.doWHST.Checked = false;
                    this.doWHT.Checked = false;
                    this.doDiscount.Checked = false;
                    this.WHTPercent.EditValue = 0;
                    this.WHTAmount.EditValue = 0;
                    this.DiscountAmount.EditValue = 0;
                    this.DiscountPercent.EditValue = 0;
                    this.WHSTAmount.EditValue = 0;
                    this.WHSTPercent.EditValue = 0;
                    this.GSTAmount.EditValue = 0;
                    this.GSTPercent.EditValue = 0;
                        this.Remarks.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    gotoPODTab(false);
                    
                    SetButtonStates(UserInputMode.View);
                    
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void UpdateExisting()
        {
            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("Voucher Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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



            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("Series  is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.FinancialYear.Tag.ToString().Length != 4)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag.ToString().Length != 3)
            {
                XtraMessageBox.Show("invalid series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.Dated.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            



            string[] queries = new string[0];
            string vnum = "";
            string CodeToUpdate = "";

            if (this.iCodeType.EditValue.ToString() == "0")
            {
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
                CodeToUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            }
            else
            {
                vnum = this.Suffix.Text;
                CodeToUpdate = this.Suffix.Tag.ToString();
            }

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (this.iCodeType.EditValue.ToString() == "1")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("inspection code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_PurchaseOrder set ";
            queries[queries.Length - 1] += " NumberType='" + this.iCodeType.EditValue.ToString() + "',PONO='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "',iStatus='U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

            if (this.AccountID_V.EditValue != null)
                queries[queries.Length - 1] += ",AccountID_V='" + this.AccountID_V.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AccountID_V=null";
            if (this.Mapped_ID.EditValue != null)
                queries[queries.Length - 1] += ",Mapped_ID='" + this.Mapped_ID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Mapped_ID=null";

            if (this.doDiscount.Checked == true)
                queries[queries.Length - 1] += ",doDiscount=1";
            else
                queries[queries.Length - 1] += ",doDiscount=0";
            if (this.doDiscount.Checked == true && this.DiscountPercent.EditValue != null)
                queries[queries.Length - 1] += ",DiscountPercent=" + this.DiscountPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",DiscountPercent=0";
            if (this.doDiscount.Checked == true && this.DiscountAmount.EditValue != null)
                queries[queries.Length - 1] += ",DiscountAmount=" + this.DiscountAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",DiscountAmount=0";

            if (this.doGST.Checked == true)
                queries[queries.Length - 1] += ",doGST=1";
            else
                queries[queries.Length - 1] += ",doGST=0";
            if (this.doGST.Checked == true && this.GSTPercent.EditValue != null)
                queries[queries.Length - 1] += ",GSTPercent=" + this.GSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",GSTPercent=0";
            if (this.doGST.Checked == true && this.GSTAmount.EditValue != null)
                queries[queries.Length - 1] += ",GSTAmount=" + this.GSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",GSTAmount=0";

            if (this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",doWHT=1";
            else
                queries[queries.Length - 1] += ",doWHT=0";
            if (this.doWHT.Checked == true && this.WHTPercent.EditValue != null)
                queries[queries.Length - 1] += ",WHTPercent=" + this.WHTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTPercent=0";
            if (this.doWHT.Checked == true && this.WHTAmount.EditValue != null)
                queries[queries.Length - 1] += ",WHTAmount=" + this.WHTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTAmount=0";
            if (this.doWHST.Checked == true)
                queries[queries.Length - 1] += ",doWHST=1";
            else
                queries[queries.Length - 1] += ",doWHST=0";
            if (this.doWHST.Checked == true && this.WHSTPercent.EditValue != null)
                queries[queries.Length - 1] += ",WHSTPercent=" + this.WHSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHSTPercent=0";
            if (this.doWHST.Checked == true && this.WHSTAmount.EditValue != null)
                queries[queries.Length - 1] += ",WHSTAmount=" + this.WHSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHSTAmount=0";
          
           
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
          

            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PONO='" + CodeToUpdate + "'";

          
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
                    
                    this.PO_Print.Tag = vnum;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountName_V.Text = "";
                    this.AccountID_V.EditValue = null;
                    this.Mapped_ID.EditValue = null;
                    this.doGST.Checked = false;
                    this.doWHST.Checked = false;
                    this.doWHT.Checked = false;
                    this.doDiscount.Checked = false;
                    this.Remarks.EditValue = null;
                    this.WHTPercent.EditValue = 0;
                    this.WHTAmount.EditValue = 0;
                    this.DiscountAmount.EditValue = 0;
                    this.DiscountPercent.EditValue = 0;
                    this.WHSTAmount.EditValue = 0;
                    this.WHSTPercent.EditValue = 0;
                    this.GSTAmount.EditValue = 0;
                    this.GSTPercent.EditValue = 0;
                    SetButtonStates(UserInputMode.View);
                    this.PO_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteExisting()
        {








            string[] queries = new string[0];
            string GRNtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Packing List  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  ST_PurchaseOrderDetails where PONO='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_PurchaseOrder where PONO='" + GRNtoUpdate + "'";
           
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

                    
                    this.PO_Print.Tag = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.Remarks.EditValue = null;
                    this.AccountName_V.Text = "";
                    this.AccountID_V.EditValue = null;
                    this.Mapped_ID.EditValue = null;
                    this.doGST.Checked = false;
                    this.doWHST.Checked = false;
                    this.doWHT.Checked = false;
                    this.doDiscount.Checked = false;

                    this.WHTPercent.EditValue = 0;
                    this.WHTAmount.EditValue = 0;
                    this.DiscountAmount.EditValue = 0;
                    this.DiscountPercent.EditValue = 0;
                    this.WHSTAmount.EditValue = 0;
                    this.WHSTPercent.EditValue = 0;
                    this.GSTAmount.EditValue = 0;
                    this.GSTPercent.EditValue = 0;

                    SetButtonStates(UserInputMode.View);
                    this.PO_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PO_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePO == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiModePO == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiModePO == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                DeleteExisting();
            }
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {

            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";


                this.Prefix.Text = N_Invoice;
                if (uiModePO == UserInputMode.Add || uiModePO == UserInputMode.Edit)
                {
                    if (this.iCodeType.EditValue.ToString() == "0")
                        GetNextInvoiceNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Invoice;
                if (uiModePO == UserInputMode.Add)
                {
                    if (this.iCodeType.EditValue.ToString() == "0")
                        GetNextInvoiceNumber();
                }
            }
        }

        private void PO_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void PO_Delete_Click(object sender, EventArgs e)
        {
            if (this.Suffix.Tag == null || this.Prefix.Tag == null || this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Suffix.Tag.ToString() == "" || this.Prefix.Tag.ToString() == "" || this.FinancialYear.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            SetButtonStates(UserInputMode.Delete);
        }

        private void POD_Add_Click(object sender, EventArgs e)
        {
            this.PODNumber.EditValue = null;
            this.PODItemAccountID.Tag = null;
            this.PODItemAccountID.EditValue = null;
            
            this.PODLPR.EditValue = null;
            this.PODROL.EditValue = null;
            this.PODUOM.Text = "";
            this.PODDepartment.EditValue = null;
            this.PODItemAccountName.EditValue = null;
            this.PODLoomNumber.EditValue = null;
            this.PODLoomNumber.Tag = null;
            this.PODLPD.EditValue = null;
            this.PODPurchaseRequisitionNo.EditValue = null;
            this.PODQty.EditValue = null;
            this.PODRemarks.EditValue = null;
            this.PODROL.EditValue = null;
            this.PODStock.EditValue = null;

            bool rRes = PODGetNextNumber();
            SetButtonStates_POD(UserInputMode.Add);
            this.PODPurchaseRequisitionNo.Focus();
        }
        private void SelectPODRecord()
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.PODGridView_Item.GetDataRow(this.PODGridView_Item.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                    this.PODItemAccountID.EditValue = ItemAccountRow["ItemAccountID"].ToString();
                    this.PODItemAccountName.EditValue = ItemAccountRow["ItemAccountName"].ToString();
                    if (ItemAccountRow["RequisitionNumber"].ToString() != "")
                    {
                        this.PODPurchaseRequisitionNo.EditValue = ItemAccountRow["RequisitionNumber"].ToString();
                        this.PODPurchaseRequisitionNo.Tag = ItemAccountRow["RequisitionNumber"].ToString();
                    }
                    else
                    {
                        this.PODPurchaseRequisitionNo.EditValue = null;
                        this.PODPurchaseRequisitionNo.Tag = null;
                    }
                    this.PODItemAccountID.Tag = ItemAccountRow["ItemAccountID"].ToString();
                    this.PODUOM.Text = ItemAccountRow["UOM"].ToString();
                    this.PODNumber.EditValue = ItemAccountRow["PODNO"].ToString();
                    this.PODLPR.EditValue = ItemAccountRow["LPR"].ToString() == "" ? null : ItemAccountRow["LPR"].ToString();
                    this.PODLPD.EditValue = ItemAccountRow["LPD"].ToString() == "" ? null : ItemAccountRow["LPD"].ToString();
                    this.PODQty.EditValue = ItemAccountRow["QTY"].ToString() == "" ? null : ItemAccountRow["QTY"].ToString();
                    this.PODRemarks.EditValue = ItemAccountRow["Remarks"].ToString() == "" ? null : ItemAccountRow["Remarks"].ToString();
                    this.PODDepartment.EditValue = ItemAccountRow["SubDepartmentID"].ToString() == "" ? null : ItemAccountRow["SubDepartmentID"].ToString();
                    this.PODShedID.EditValue = ItemAccountRow["ShedID"].ToString() == "" ? null : ItemAccountRow["ShedID"].ToString();
                    this.PODLoomNumber.Tag = ItemAccountRow["LoomID"].ToString() == "" ? null : ItemAccountRow["LoomID"].ToString();
                    this.PODLoomNumber.EditValue = ItemAccountRow["LoomName"].ToString() == "" ? null : ItemAccountRow["LoomName"].ToString();
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
            if (this.PODNumber.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            SetButtonStates_POD(UserInputMode.Edit);
        }

        private void POD_Delete_Click(object sender, EventArgs e)
        {
            if (this.PODNumber.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    this.PODItemAccountID.EditValue = sRow.PrimeryID;
                    this.PODItemAccountName.EditValue = sRow.PrimaryString;
                    try
                    {
                        this.PODROL.EditValue = sRow.SelectedDataRow["ReOrderLevel"].ToString() == "" ?  null : sRow.SelectedDataRow["ReOrderLevel"].ToString();
                        this.PODLPR.EditValue = sRow.SelectedDataRow["bUnitRate"].ToString() == "" ?  null : sRow.SelectedDataRow["bUnitRate"].ToString();
                        this.PODLPD.EditValue = sRow.SelectedDataRow["bDate"].ToString() == "" ? null : sRow.SelectedDataRow["bDate"].ToString();
                        this.PODUOM.Text = sRow.SelectedDataRow["bUnit"].ToString() == "" ? null : sRow.SelectedDataRow["bUnit"].ToString();
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
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();
            




            strFilterQuery = "SELECT PONO,Dated,Remarks  FROM ST_PurchaseOrder  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' and iStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' and POTypeID="+this.POTypeID.EditValue.ToString()+"";

            




            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "PONO", "PONO");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.PO_Print.Tag = sRow.PrimeryID;
                this.PO_View.Tag = sRow.PrimeryID;
                Fill_PurchaseOrder(sRow.PrimeryID);

            }
        }
        private void Fill_PurchaseOrder(string PONO)
        {
            try
            {
                this.PO_Edit.Enabled = false;
                this.PO_Delete.Enabled = false;
                DataSet ds = WS.svc.Get_DataSet("Select * from ST_PurchaseOrder where PONO='" + PONO + "'");
                if (ds == null) return;

                if (ds.Tables[0].Rows.Count <= 0) return;



              

                if (ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    this.Remarks.EditValue = ds.Tables[0].Rows[0]["Remarks"].ToString();

                }
                else
                {
                    this.Remarks.EditValue = null;

                }

               
                try
                {
                    this.Dated.DateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                }
             
              


                this.iCodeType.EditValue = ds.Tables[0].Rows[0]["NumberType"].ToString();
                this.FinancialYear.EditValue = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.Prefix.EditValue = ds.Tables[0].Rows[0]["iType"].ToString();
                this.Prefix.Tag = ds.Tables[0].Rows[0]["iType"].ToString();
                this.FinancialYear.Tag = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.DocumentState.Tag = ds.Tables[0].Rows[0]["iStatus"].ToString();
                this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (ds.Tables[0].Rows[0]["NumberType"].ToString() == "0")
                {
                    this.Suffix.Text = ds.Tables[0].Rows[0]["PONO"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PONO"].ToString().Substring(7, 6);


                }
                else
                {
                    this.Suffix.EditValue = ds.Tables[0].Rows[0]["PONO"].ToString();
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PONO"].ToString();
                }
                this.POTypeID.EditValue = ds.Tables[0].Rows[0]["POTypeID"].ToString();
              
                if (ds.Tables[0].Rows[0]["doDiscount"].ToString() == "True")
                {
                    if (ds.Tables[0].Rows[0]["DiscountPercent"].ToString() == "0")
                    {
                        this.radioGroup_Discount.EditValue = "1";

                    }
                    else
                        this.radioGroup_Discount.EditValue = "0";
                    this.DiscountAmount.EditValue = ds.Tables[0].Rows[0]["DiscountAmount"].ToString();
                    this.DiscountPercent.EditValue = ds.Tables[0].Rows[0]["DiscountPercent"].ToString();
                    this.doDiscount.Checked = true;
                    
                }
                else
                {
                    this.DiscountAmount.EditValue = null;
                    this.DiscountPercent.EditValue = null;
                    this.doDiscount.Checked = false;
                }

                if (ds.Tables[0].Rows[0]["doGST"].ToString() == "True")
                {
                    
                    this.GSTAmount.EditValue = ds.Tables[0].Rows[0]["GSTAmount"].ToString();
                    this.GSTPercent.EditValue = ds.Tables[0].Rows[0]["GSTPercent"].ToString();
                    this.doGST.Checked = true;
                }
                else
                {
                    this.GSTPercent.EditValue = null;
                    this.GSTAmount.EditValue = null;
                    this.doGST.Checked = false;
                }

                if (ds.Tables[0].Rows[0]["doWHT"].ToString() == "True")
                {
                    this.WHTAmount.EditValue = ds.Tables[0].Rows[0]["WHTAmount"].ToString();
                    this.WHTPercent.EditValue = ds.Tables[0].Rows[0]["WHTPercent"].ToString();
                    this.doWHT.Checked = true;
                }
                else
                {
                    this.WHTPercent.EditValue = null;
                    this.WHTAmount.EditValue = null;
                    this.doWHT.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["doWHST"].ToString() == "True")
                {
                    this.WHSTPercent.EditValue = ds.Tables[0].Rows[0]["WHSTPercent"].ToString();
                    this.WHSTAmount.EditValue = ds.Tables[0].Rows[0]["WHSTAmount"].ToString();
                    this.doWHST.Checked = true;
                }
                else
                {
                    this.WHSTAmount.EditValue = null;
                    this.WHSTPercent.EditValue = null;
                    this.doWHST.Checked = false;
                }
                if (ds.Tables[0].Rows[0]["AccountID_V"].ToString() != "")
                {
                    this.AccountID_V.EditValue = ds.Tables[0].Rows[0]["AccountID_V"].ToString();
                    this.AccountName_V.EditValue = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(ds.Tables[0].Rows[0]["AccountID_V"].ToString());
                    this.Mapped_ID.EditValue = ds.Tables[0].Rows[0]["Mapped_ID"].ToString();
                }
                else
                {
                    this.AccountName_V.EditValue = null;
                    this.AccountID_V.EditValue = null;
                    this.Mapped_ID.EditValue = null;
                }
                this.PO_Print.Tag = ds.Tables[0].Rows[0]["PONO"].ToString();
                this.PO_View.Tag = ds.Tables[0].Rows[0]["PONO"].ToString();
                this.SelectedPONO.EditValue = ds.Tables[0].Rows[0]["PONO"].ToString();
                this.PO_Edit.Enabled = true;
                this.PO_Delete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PO_Next_Click(object sender, EventArgs e)
        {
            gotoPODTab(true);
        }

        private void PODShedID_EditValueChanged(object sender, EventArgs e)
        {

            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.PODShedID.Text);
            if (shedindex != -1)
            {
                this.PODShedID.Tag = shedindex.ToString();
                this.PODShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.PODShedID.Tag = null;
                this.PODShedName.Text = "";
            }
        }

        private void PODLoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.PODShedID.Tag == null)
            {
                this.PODLoomNumber.ForeColor = Color.White;
                this.PODLoomNumber.BackColor = Color.Red;
                this.PODLoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.PODLoomNumber.Text, this.PODShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.PODLoomNumber.ForeColor = Color.Black;
                this.PODLoomNumber.BackColor = Color.White;
                this.PODLoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.PODLoomNumber.ForeColor = Color.White;
                this.PODLoomNumber.BackColor = Color.Red;
                this.PODLoomNumber.Tag = null;
            }
        }

        private void POD_Back_Click(object sender, EventArgs e)
        {
            gotoPOTab();
        }

        private void Store_PurchaseOrder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dailyShift_Summary1.RP_DailyShiftSummary' table. You can move, or remove it, as needed.
           
            gotoPOTab();
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
            if(this.POTypeID.EditValue.ToString()=="0")
            MachineEyes.Classes.Printing.Print_ST_PO(this.PO_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
            else if(this.POTypeID.EditValue.ToString()=="1")
                MachineEyes.Classes.Printing.Print_ST_PO_PAKA(this.PO_Print.Tag.ToString(),this.radioGroup_CopyType.EditValue.ToString());
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

        private void PODPurchaseRequisitionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {


                string query = "SELECT Distinct RequisitionNumber,ItemAccountID,ItemAccountName,QtyApproved,UOM,DepartmentID,StockAtTime,LPR from RST_DepartmentStoreRequisition where  ( StockAtTime<=0 or StockAtTime<QtyApproved ) and RequisitionStatusID='1'";


                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "RequisitionNumber", "ItemAccountID");
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.PODPurchaseRequisitionNo.EditValue = sRow.PrimeryID;

                    this.PODItemAccountID.EditValue = sRow.PrimaryString;

                    try
                    {
                        this.PODQty.EditValue = sRow.SelectedDataRow["QtyApproved"].ToString();
                        this.PODStock.EditValue = sRow.SelectedDataRow["StockAtTime"].ToString();
                        this.PODLPR.EditValue = sRow.SelectedDataRow["LPR"].ToString();
                        this.PODItemAccountName.EditValue = sRow.SelectedDataRow["ItemAccountName"].ToString();
                        this.PODUOM.Text = sRow.SelectedDataRow["UOM"].ToString();
                        this.PODDepartment.EditValue = sRow.SelectedDataRow["DepartmentID"].ToString();
                        if (sRow.SelectedDataRow["ShedID"].ToString() != "")
                        {
                            this.PODShedID.EditValue = sRow.SelectedDataRow["ShedID"].ToString();
                            this.PODLoomNumber.EditValue = sRow.SelectedDataRow["LoomName"].ToString();
                        }
                    }
                    catch
                    {
                    }

                }



            }
        }

        private void POTypeID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.POTypeID.EditValue.ToString() == "0")
            {
                this.PurchaseOrderOptions.Enabled = false;
            }
            else
            {
                this.PurchaseOrderOptions.Enabled = true;
            }
        }

        private void AccountID_V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                    Program.MainWindow.AccountsList.ShowDialog();
                    if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.AccountID_V.Text = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                        if (Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString() != "")
                            this.Mapped_ID.EditValue = Program.MainWindow.AccountsList.SelectedRow.SelectedDataRow["MappedAccountID"].ToString();
                        else
                            this.Mapped_ID.EditValue = null;
                        this.AccountName_V.Text = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.Mapped_ID.EditValue = null;
                this.AccountID_V.EditValue = null;
                this.AccountName_V.EditValue = null;
            }
        }

        private void POD_Next_Click(object sender, EventArgs e)
        {
            
            if (this.POTypeID.EditValue.ToString() == "0")
            {
                this.xtraTabPage_PO.PageEnabled = true;
                this.xtraTabPage_DiscountTaxes.PageEnabled = false;
                this.xtraTabPage_POD.PageEnabled = false;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PO;
            }
            else
            {
                this.xtraTabPage_PO.PageEnabled = false;
                this.xtraTabPage_DiscountTaxes.PageEnabled = true;
                this.xtraTabPage_POD.PageEnabled = false;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_DiscountTaxes;
                try
                {
                    string query = "Select sum(Amount) as GrossAmount from RST_PurchaseOrderDetails where PONO='" + this.SelectedPONO.Text + "'";
                    DataSet ds = WS.svc.Get_DataSet(query);
                    if (ds != null)
                    {
                        this.GrossAmount.EditValue = ds.Tables[0].Rows[0]["GrossAmount"].ToString();
                    }
                    else
                    {
                        this.GrossAmount.EditValue = 0;

                    }
                    CalculateAutoAmounts();
                }
                catch
                {
                }
            }
        }

        private void CalculateAutoAmounts()
        {
            double dGrossAmount = 0;
            double dDiscountpercent = 0;
            double dDiscountAmount = 0;
            double dGSTPercent = 0;
            double dGSTAmount = 0;
            double dWHTPercent = 0;
            double dWHTAmount = 0;
            double dWHSTPercent = 0;
            double dWHSTAmount = 0;
         
            double dAmountBeforeApplicableTaxes = 0;
            double dAmountBeforeDeductions = 0;
            double dNetAmount = 0;

            if (this.GrossAmount.EditValue != null)
                double.TryParse(this.GrossAmount.EditValue.ToString(), out dGrossAmount);
            if (doDiscount.Checked == true)
            {
                if (this.radioGroup_Discount.EditValue.ToString() == "0")//Percent
                {
                    if (this.DiscountPercent.EditValue != null)
                        double.TryParse(this.DiscountPercent.EditValue.ToString(), out dDiscountpercent);
                    dDiscountAmount = dDiscountpercent * dGrossAmount / 100;
                    this.DiscountAmount.EditValue = dDiscountAmount;

                }
                else
                {
                    if (this.DiscountAmount.EditValue != null)
                        double.TryParse(this.DiscountAmount.EditValue.ToString(), out dDiscountAmount);

                }
            }
            else
            {
                dDiscountAmount = 0;
                dDiscountpercent = 0;
            }
            dAmountBeforeApplicableTaxes = dGrossAmount - dDiscountAmount;
            this.AmountBeforeApplicableTaxes.EditValue = dAmountBeforeApplicableTaxes;
            if (this.doGST.Checked == true)
            {
                if (this.GSTPercent.EditValue != null)
                    double.TryParse(this.GSTPercent.EditValue.ToString(), out dGSTPercent);
                dGSTAmount = dGSTPercent * dAmountBeforeApplicableTaxes / 100;
                this.GSTAmount.EditValue = dGSTAmount;
            }
            else
            {
                dGSTPercent = 0;
                dGSTAmount = 0;
            }
            dAmountBeforeDeductions = dAmountBeforeApplicableTaxes+ dGSTAmount;
            this.AmountBeforeDeductions.EditValue = dAmountBeforeDeductions;
            if (this.doWHT.Checked == true)
            {
                if (this.WHTPercent.EditValue != null)
                    double.TryParse(this.WHTPercent.EditValue.ToString(), out dWHTPercent);
                dWHTAmount = dWHTPercent * dAmountBeforeDeductions / 100;
                this.WHTAmount.EditValue = dWHTAmount;
            }
            else
            {
                dWHTAmount = 0;
                dWHTPercent = 0;
            }
            if (this.doWHST.Checked == true)
            {
                if (this.WHSTPercent.EditValue != null)
                    double.TryParse(this.WHSTPercent.EditValue.ToString(), out dWHSTPercent);
                dWHSTAmount = dWHSTPercent * dGSTAmount / 100;
                this.WHSTAmount.EditValue = dWHSTAmount;
            }
            else
            {
                dWHSTAmount = 0;
                dWHSTPercent = 0;
            }
            dNetAmount = dAmountBeforeDeductions - dWHTAmount - dWHSTAmount;
            this.NetAmount.EditValue = dNetAmount;
        }

        private void BackToDetailTab_Click(object sender, EventArgs e)
        {
            this.xtraTabPage_PO.PageEnabled = false;
            this.xtraTabPage_POD.PageEnabled = true;
            this.xtraTabPage_DiscountTaxes.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_POD;
        }

        private void gotoPOMainTab_Click(object sender, EventArgs e)
        {
            this.xtraTabPage_PO.PageEnabled = true;
            this.xtraTabPage_POD.PageEnabled = false;
            this.xtraTabPage_DiscountTaxes.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PO;
        }

        private void radioGroup_Discount_EditValueChanged(object sender, EventArgs e)
        {
            if (this.radioGroup_Discount.EditValue.ToString() == "0")
            {
                this.DiscountPercent.Enabled = true;
                this.DiscountAmount.Properties.ReadOnly = true;
                CalculateAutoAmounts();
            }
            else
            {
                this.DiscountPercent.Enabled = false;
                this.DiscountPercent.EditValue = 0;
                this.DiscountAmount.Properties.ReadOnly = false;
                CalculateAutoAmounts();
            }
        }

        private void doGST_CheckedChanged(object sender, EventArgs e)
        {
            CalculateAutoAmounts();
        }

        private void DiscountPercent_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAutoAmounts();
        }

        private void DiscountAmount_EditValueChanged(object sender, EventArgs e)
        {
            CalculateAutoAmounts();
        }

        private void UpdateValues_Click(object sender, EventArgs e)
        {
            string[] queries = new string[0];




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_PurchaseOrder set ";
            queries[queries.Length - 1] += " NumberType='" + this.iCodeType.EditValue.ToString() + "'";



            if (this.doDiscount.Checked == true)
                queries[queries.Length - 1] += ",doDiscount=1";
            else
                queries[queries.Length - 1] += ",doDiscount=0";
            if (this.doDiscount.Checked == true && this.DiscountPercent.EditValue != null)
                queries[queries.Length - 1] += ",DiscountPercent=" + this.DiscountPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",DiscountPercent=0";
            if (this.doDiscount.Checked == true && this.DiscountAmount.EditValue != null)
                queries[queries.Length - 1] += ",DiscountAmount=" + this.DiscountAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",DiscountAmount=0";

            if (this.doGST.Checked == true)
                queries[queries.Length - 1] += ",doGST=1";
            else
                queries[queries.Length - 1] += ",doGST=0";
            if (this.doGST.Checked == true && this.GSTPercent.EditValue != null)
                queries[queries.Length - 1] += ",GSTPercent=" + this.GSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",GSTPercent=0";
            if (this.doGST.Checked == true && this.GSTAmount.EditValue != null)
                queries[queries.Length - 1] += ",GSTAmount=" + this.GSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",GSTAmount=0";

            if (this.doWHT.Checked == true)
                queries[queries.Length - 1] += ",doWHT=1";
            else
                queries[queries.Length - 1] += ",doWHT=0";
            if (this.doWHT.Checked == true && this.WHTPercent.EditValue != null)
                queries[queries.Length - 1] += ",WHTPercent=" + this.WHTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTPercent=0";
            if (this.doWHT.Checked == true && this.WHTAmount.EditValue != null)
                queries[queries.Length - 1] += ",WHTAmount=" + this.WHTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHTAmount=0";
            if (this.doWHST.Checked == true)
                queries[queries.Length - 1] += ",doWHST=1";
            else
                queries[queries.Length - 1] += ",doWHST=0";
            if (this.doWHST.Checked == true && this.WHSTPercent.EditValue != null)
                queries[queries.Length - 1] += ",WHSTPercent=" + this.WHSTPercent.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHSTPercent=0";
            if (this.doWHST.Checked == true && this.WHSTAmount.EditValue != null)
                queries[queries.Length - 1] += ",WHSTAmount=" + this.WHSTAmount.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",WHSTAmount=0";


            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";


            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PONO='" + this.SelectedPONO.Text + "'";


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

                    this.PO_Print.Tag = this.SelectedPONO.Text;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountName_V.Text = "";
                    this.AccountID_V.EditValue = null;
                    this.Mapped_ID.EditValue = null;
                    this.doGST.Checked = false;
                    this.doWHST.Checked = false;
                    this.doWHT.Checked = false;
                    this.doDiscount.Checked = false;
                    this.Remarks.EditValue = null;
                    this.WHTPercent.EditValue = 0;
                    this.WHTAmount.EditValue = 0;
                    this.DiscountAmount.EditValue = 0;
                    this.DiscountPercent.EditValue = 0;
                    this.WHSTAmount.EditValue = 0;
                    this.WHSTPercent.EditValue = 0;
                    this.GSTAmount.EditValue = 0;
                    this.GSTPercent.EditValue = 0;
                    SetButtonStates(UserInputMode.View);
                    this.PO_Add.Focus();
                    this.xtraTabPage_PO.PageEnabled = true;
                    this.xtraTabPage_POD.PageEnabled = false;
                    this.xtraTabPage_DiscountTaxes.PageEnabled = false;
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_PO;
                }

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
       
    }
}