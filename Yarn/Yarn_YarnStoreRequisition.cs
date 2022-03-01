using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn
{
    public partial class Yarn_YarnStoreRequisition : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePO;
        UserInputMode uiModePOD;
        private string G_Invoice;
        private string N_Invoice;
        DataRow ItemAccountRow;
        DateTime CurrentDate;
        
        int ItemFocusedRowHandle;
        public Yarn_YarnStoreRequisition()
        {
            InitializeComponent();
           
            G_Invoice = "DRQ";
            N_Invoice = "DRQ";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
            fc.RequisitionPriorityLevels(ref this.RequisitionPriorityLevel);
            

            fc.MeasurementUnits(ref this.UOM);
            DataSet ds = WS.svc.Get_DataSet("Select SubDepartmentID,SubDepartment from QP_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Department.Text = ds.Tables[0].Rows[0]["SubDepartment"].ToString();
                    this.Department.Tag = ds.Tables[0].Rows[0]["SubDepartmentID"].ToString();
                }
            }
            this.ReqStatusID.Text = "0";
            this.ReqStatusName.Text = "Requested";
        }
        private void PODSaveNew()
        {

            if (this.Prefix.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.DepartmentRequisitionNumber.Text == "")
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
            if (this.QuantityRequested.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ItemAccountID.EditValue != null)
            {
                if (ItemAccountID.EditValue.ToString() == "")
                    this.ItemAccountID.EditValue = null;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.Prefix.Text + this.FinancialYear.Text + this.DepartmentRequisitionNumber.Text;
          

            char vCat = 'G';
           

                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Requisition  code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
      
          




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_DepartmentStoreRequisition (iType,iYear,iCat,iStatus,RequisitionNumber,ItemAccountID,ItemAccountName,PartNumber,QtyRequested,StockAtTime,Dated,DepartmentID,ShedID,LoomID,LoomName,UOM,Remarks,RequisitionPriorityLevelID,RequisitionStatusID) Values (";
            queries[queries.Length - 1] += "'"+this.Prefix.Text+"','"+this.FinancialYear.Text+"','"+vCat+"',0,'" + vnum + "'";

            if (this.ItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.ItemAccountName.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ItemAccountName.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PartNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PartNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.QuantityRequested.EditValue != null)
                queries[queries.Length - 1] += "," + this.QuantityRequested.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.PODStock.EditValue != null)
                queries[queries.Length - 1] += "," + this.PODStock.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Department.Tag != null)
                queries[queries.Length - 1] += ",'" + this.Department.Tag.ToString()+ "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.LoomShedID.EditValue != null)
                if(this.LoomShedID.EditValue.ToString()!="")
                queries[queries.Length - 1] += "," + this.LoomShedID.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
            else
                queries[queries.Length - 1] += ",null";

            if (this.LoomNumber.Tag != null)
                queries[queries.Length - 1] += "," + this.LoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.LoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.LoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.UOM.EditValue!=null)
                queries[queries.Length - 1] += ",'" + this.UOM.EditValue + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RequisitionRemarks.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RequisitionRemarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RequisitionPriorityLevel.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RequisitionPriorityLevel.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ReqStatusID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ReqStatusID.EditValue.ToString() + "'";
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
                    



                 

                    DataView gdv = (DataView)this.PODGridView_Item.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    if(this.ItemAccountID.EditValue!=null)_ravi["ItemAccountID"] = this.ItemAccountID.EditValue.ToString();
                    if (this.ItemAccountName.EditValue != null) _ravi["ItemAccountName"] = this.ItemAccountName.EditValue.ToString();
                    if (this.PartNumber.EditValue != null) _ravi["PartNumber"] = this.PartNumber.EditValue.ToString();
                    _ravi["RequisitionNumber"] = vnum;
                    if (this.QuantityRequested.EditValue != null) _ravi["QtyRequested"] = this.QuantityRequested.EditValue.ToString();
                    if (this.Department.EditValue != null) _ravi["DepartmentName"] = this.Department.EditValue.ToString();
                    if (this.Department.Tag != null) _ravi["DepartmentID"] = this.Department.Tag.ToString();
                    if (this.LoomShedID.EditValue != null) { if (this.LoomShedID.EditValue.ToString() != "") _ravi["ShedID"] = this.LoomShedID.EditValue.ToString(); }
                    if (this.LoomNumber.Tag != null) _ravi["LoomID"] = this.LoomNumber.Tag.ToString();
                    if (this.LoomNumber.EditValue != null) _ravi["LoomName"] = this.LoomNumber.EditValue.ToString();

                    if (this.UOM.EditValue!=null) _ravi["UOM"] = this.UOM.EditValue.ToString();
                    if (this.RequisitionRemarks.Text != "") _ravi["remarks"] = this.RequisitionRemarks.Text;
                    if (this.RequisitionPriorityLevel.EditValue != null) _ravi["RequisitionPriorityLevelID"] = this.RequisitionPriorityLevel.EditValue.ToString();
                    if (this.ReqStatusID.EditValue != null) _ravi["RequisitionStatusID"] = this.ReqStatusID.EditValue.ToString();
                    if (this.ReqStatusName.EditValue != null) _ravi["RequisitionStatusName"] = this.ReqStatusName.EditValue.ToString();
                    _ravi["iType"] = this.Prefix.Text;
                    _ravi["iYear"] = this.FinancialYear.Text;
                    _ravi["iCat"] = vCat;
                    _ravi["iStatus"] = "0";
                    if (this.PODStock.EditValue != null) _ravi["StockAtTime"] = this.PODStock.EditValue.ToString();
                    else _ravi["StockAtTime"] = DBNull.Value;
                    gdt.Rows.Add(_ravi);


                    this.DepartmentRequisitionNumber.EditValue = null;
                    this.ItemAccountID.Tag = null;
                    this.ItemAccountID.EditValue = null;
                    this.ItemAccountName.EditValue = null;
                    this.LoomNumber.EditValue = null;
                    this.LoomNumber.Tag = null;
                    this.DepartmentRequisitionNumber.EditValue = null;
                    this.QuantityRequested.EditValue = null;
                    this.RequisitionRemarks.EditValue = null;
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
            if (this.DepartmentRequisitionNumber.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.DepartmentRequisitionNumber.Tag == null)
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
            if (this.QuantityRequested.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.ReqStatusID.Text != "0")
            {
                XtraMessageBox.Show("The Status for Store Requisition has been changed ! can not update !", "Status Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (ItemAccountID.EditValue != null)
            {
                if (ItemAccountID.EditValue.ToString() == "")
                    this.ItemAccountID.EditValue = null;
            }
            vnum = this.Prefix.Text + this.FinancialYear.Text + this.DepartmentRequisitionNumber.Text;
            vnumtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.DepartmentRequisitionNumber.Tag.ToString();
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_DepartmentStoreRequisition set ";
            queries[queries.Length - 1] += "RequisitionNumber='" + vnum + "' ";



            if (this.ItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",ItemAccountID='" + this.ItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountID=null";

            if (this.QuantityRequested.EditValue != null)
                queries[queries.Length - 1] += ",QTYRequested=" + this.QuantityRequested.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",QTYRequested=0";

           
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

            if (this.Department.EditValue != null)
                queries[queries.Length - 1] += ",DepartmentID='" + this.Department.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",DepartmentID=null";
            if (this.LoomShedID.EditValue != null)
                if(this.LoomShedID.EditValue.ToString()!="")
                queries[queries.Length - 1] += ",ShedID=" + this.LoomShedID.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",ShedID=null";
            else
                queries[queries.Length - 1] += ",ShedID=null";

            if (this.LoomNumber.Tag != null)
                queries[queries.Length - 1] += ",LoomID=" + this.LoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",LoomID=null";
            if (this.LoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",LoomName='" + this.LoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Loomname=null";
            if (this.UOM.EditValue != null)
                queries[queries.Length - 1] += ",UOM='" + this.UOM.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",UOM=null";
            if (this.RequisitionRemarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.RequisitionRemarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            if (this.RequisitionPriorityLevel.EditValue != null)
                queries[queries.Length - 1] += ",RequisitionPriorityLevelID='" + this.RequisitionPriorityLevel.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",RequisitionPriorityLevelID=null";
            if (this.ItemAccountName.EditValue != null)
                queries[queries.Length - 1] += ",ItemAccountName='" + this.ItemAccountName.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountName=null";
            if (this.PartNumber.EditValue != null)
                queries[queries.Length - 1] += ",PartNumber='" + this.PartNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PartNumber=null";

            queries[queries.Length - 1] += " where RequisitionNumber='" + vnumtoUpdate + "'";

            
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
                    if (this.ItemAccountID.EditValue != null) _ravi["ItemAccountID"] = this.ItemAccountID.EditValue.ToString();
                    if (this.ItemAccountName.EditValue != null) _ravi["ItemAccountName"] = this.ItemAccountName.EditValue.ToString();
                    if (this.PartNumber.EditValue != null) _ravi["PartNumber"] = this.PartNumber.EditValue.ToString();
                    _ravi["RequisitionNumber"] = vnum;
                    if (this.QuantityRequested.EditValue != null) _ravi["QtyRequested"] = this.QuantityRequested.EditValue.ToString();
                    if (this.Department.EditValue != null) _ravi["DepartmentName"] = this.Department.EditValue.ToString();
                    if (this.Department.Tag != null) _ravi["DepartmentID"] = this.Department.Tag.ToString();
                    if (this.LoomShedID.EditValue != null) { if (this.LoomShedID.EditValue.ToString() != "") _ravi["ShedID"] = this.LoomShedID.EditValue.ToString(); }
                    if (this.LoomNumber.Tag != null) _ravi["LoomID"] = this.LoomNumber.Tag.ToString();
                    if (this.LoomNumber.EditValue != null) _ravi["LoomName"] = this.LoomNumber.EditValue.ToString();

                    if (this.UOM.EditValue != null) _ravi["UOM"] = this.UOM.EditValue.ToString();
                    if (this.RequisitionRemarks.Text != "") _ravi["remarks"] = this.RequisitionRemarks.Text;
                    if (this.RequisitionPriorityLevel.EditValue != null) _ravi["RequisitionPriorityLevelID"] = this.RequisitionPriorityLevel.EditValue.ToString();
                    if (this.ReqStatusID.EditValue != null) _ravi["RequisitionStatusID"] = this.ReqStatusID.EditValue.ToString();
                    if (this.ReqStatusName.EditValue != null) _ravi["RequisitionStatusName"] = this.ReqStatusName.EditValue.ToString();
                    else
                        _ravi["RequisitionStatusName"] = DBNull.Value;
                    _ravi["iType"] = this.Prefix.Text;
                    _ravi["iYear"] = this.FinancialYear.Text;
                    _ravi["iCat"] = "G";
                    _ravi["iStatus"] = "0";
                    if (this.PODStock.EditValue != null) _ravi["StockAtTime"] = this.PODStock.EditValue.ToString();
                    else _ravi["StockAtTime"] = DBNull.Value;
                    SetButtonStates_POD(UserInputMode.View);
                    
                    this.ItemAccountID.Tag = null;
                    this.ItemAccountID.EditValue = null;

                    this.PartNumber.EditValue = null;
                    this.RequisitionPriorityLevel.EditValue = null;
                    this.LoomShedID.EditValue = null;
                    this.UOM.EditValue = null;

                    this.ItemAccountName.EditValue = null;
                    this.LoomNumber.EditValue = null;
                    this.LoomNumber.Tag = null;
                  
                    this.DepartmentRequisitionNumber.EditValue = null;
                    this.QuantityRequested.EditValue = null;
                    this.RequisitionRemarks.EditValue = null;
                    
                    this.PODStock.EditValue = null;
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
            if (this.DepartmentRequisitionNumber.Text == "")
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.DepartmentRequisitionNumber.Tag == null)
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
          
            if (this.ReqStatusID.Text != "0")
            {
                XtraMessageBox.Show("The Status for Store Requisition has been changed ! can not delete !", "Status Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            vnum = this.Prefix.Text + this.FinancialYear.Text + this.DepartmentRequisitionNumber.Text;
            vnumtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.DepartmentRequisitionNumber.Tag.ToString();



            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item POD # " + vnumtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_DepartmentStoreRequisition where RequisitionNumber='" + vnumtoUpdate + "'";
         

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
                    this.ItemAccountID.Tag = null;
                    this.ItemAccountID.EditValue = null;
                    this.PartNumber.EditValue = null;
                    this.RequisitionPriorityLevel.EditValue = null;
                    this.LoomShedID.EditValue = null;
                    this.UOM.EditValue = null;
                    this.ItemAccountName.EditValue = null;
                    this.LoomNumber.EditValue = null;
                    this.LoomNumber.Tag = null;
                    this.DepartmentRequisitionNumber.EditValue = null;
                    this.QuantityRequested.EditValue = null;
                    this.RequisitionRemarks.EditValue = null;
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
        private void SetButtonStates_POD(UserInputMode uim)
        {
            uiModePOD = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.POD_Execute.Enabled = false;
                    this.POD_Cancel.Enabled = false;
                    this.POD_Add.Enabled = true;




                    if (this.DepartmentRequisitionNumber.Tag != null)
                    {
                        if (this.DepartmentRequisitionNumber.Tag.ToString() != "")
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
                    query = "select max(Convert(numeric(18),SubString(RequisitionNumber,8,6)))+1 as MaxNumber  from ST_DepartmentStoreRequisition where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 6)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DepartmentRequisitionNumber.Text = "";
                        return false;
                    }
                    iNumber = iNumber.PadLeft(6, '0');
                    this.DepartmentRequisitionNumber.Text = iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DepartmentRequisitionNumber.Text = "";
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.DepartmentRequisitionNumber.Text = "";
                return false;
            }
        }

       
        
       

      

     

      

        private void POD_Add_Click(object sender, EventArgs e)
        {
            
            this.ItemAccountID.Tag = null;
            this.ItemAccountID.EditValue = null;
            
           
            this.ItemAccountName.EditValue = null;
            this.LoomNumber.EditValue = null;
            this.LoomNumber.Tag = null;
        
            this.DepartmentRequisitionNumber.EditValue = null;
            this.QuantityRequested.EditValue = null;
            this.RequisitionRemarks.EditValue = null;
          
            this.PODStock.EditValue = null;

            bool rRes = GetNextInvoiceNumber();
            SetButtonStates_POD(UserInputMode.Add);
            this.ReqStatusID.Text = "0";
            this.ReqStatusName.Text = "Requested";
            this.Dated.Focus();
        }
        private void SelectPODRecord()
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.PODGridView_Item.GetDataRow(this.PODGridView_Item.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                    this.ItemAccountID.EditValue = ItemAccountRow["ItemAccountID"].ToString();
                    this.ItemAccountName.EditValue = ItemAccountRow["ItemAccountName"].ToString();
                    this.ItemAccountID.Tag = ItemAccountRow["ItemAccountID"].ToString();
                    this.Prefix.Text = ItemAccountRow["iType"].ToString();
                    this.FinancialYear.Text = ItemAccountRow["iYear"].ToString();
                    this.Prefix.Tag = ItemAccountRow["iType"].ToString();
                    this.FinancialYear.Tag = ItemAccountRow["iYear"].ToString();
                    this.PODStock.EditValue = ItemAccountRow["StockAtTime"].ToString() == "" ? null : ItemAccountRow["StockAtTime"].ToString();
                    this.DepartmentRequisitionNumber.Text = ItemAccountRow["RequisitionNumber"].ToString().Substring(7, 6);
                    this.DepartmentRequisitionNumber.Tag = ItemAccountRow["RequisitionNumber"].ToString().Substring(7, 6);
                    this.QuantityRequested.EditValue = ItemAccountRow["QTYRequested"].ToString() == "" ? null : ItemAccountRow["QTYRequested"].ToString();
                    this.RequisitionRemarks.EditValue = ItemAccountRow["Remarks"].ToString() == "" ? null : ItemAccountRow["Remarks"].ToString();
                    this.RequisitionPriorityLevel.EditValue = ItemAccountRow["RequisitionPriorityLevelID"].ToString() == "" ? null : ItemAccountRow["RequisitionPriorityLevelID"].ToString();
                    this.ReqStatusID.EditValue = ItemAccountRow["RequisitionStatusID"].ToString() == "" ? null : ItemAccountRow["RequisitionStatusID"].ToString();
                    this.LoomShedID.EditValue = ItemAccountRow["ShedID"].ToString() == "" ? null : ItemAccountRow["ShedID"].ToString();
                    this.LoomNumber.Tag = ItemAccountRow["LoomID"].ToString() == "" ? null : ItemAccountRow["LoomID"].ToString();
                    this.LoomNumber.EditValue = ItemAccountRow["LoomName"].ToString() == "" ? null : ItemAccountRow["LoomName"].ToString();
                    this.UOM.EditValue = ItemAccountRow["UOM"].ToString() == "" ? null : ItemAccountRow["UOM"].ToString();
                    this.Department.EditValue = ItemAccountRow["DepartmentName"].ToString() == "" ? null : ItemAccountRow["DepartmentName"].ToString();
                    this.Department.Tag = ItemAccountRow["DepartmentID"].ToString() == "" ? null : ItemAccountRow["DepartmentID"].ToString();
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
            if (this.DepartmentRequisitionNumber.Tag == null)
            {
                XtraMessageBox.Show("Requisition  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            SetButtonStates_POD(UserInputMode.Edit);
        }

        private void POD_Delete_Click(object sender, EventArgs e)
        {
            if (this.DepartmentRequisitionNumber.Tag == null)
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
                    this.ItemAccountID.EditValue = sRow.PrimeryID;
                    this.ItemAccountName.EditValue = sRow.PrimaryString;
                    try
                    {
                        
                        this.UOM.EditValue = sRow.SelectedDataRow["bUnit"].ToString() == "" ? null : sRow.SelectedDataRow["bUnit"].ToString();
                        this.PODStock.EditValue = sRow.SelectedDataRow["StockQty"].ToString() == "" ? null : sRow.SelectedDataRow["StockQty"].ToString();
                        this.PartNumber.EditValue = sRow.SelectedDataRow["PartNumber"].ToString() == "" ? null : sRow.SelectedDataRow["PartNumber"].ToString();
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
            
                Fill_Requisition(this.Dated.DateTime);

          
        }
        private void Fill_Requisition(DateTime argDate)
        {


           
            try
            {
                CurrentDate = argDate;
                DataSet ds = WS.svc.Get_DataSet("Select * from RST_DepartmentStoreRequisition where  Dated='" + Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'");
                
                if (ds == null) return;

                
                this.PODGrid_Item.DataSource = ds.Tables[0];


                try
                {
                    this.Dated.DateTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                }
                catch
                {
                }
             
              


               
                //this.FinancialYear.EditValue = ds.Tables[0].Rows[0]["iYear"].ToString();
                //this.Prefix.EditValue = ds.Tables[0].Rows[0]["iType"].ToString();
                //this.Prefix.Tag = ds.Tables[0].Rows[0]["iType"].ToString();
                //this.FinancialYear.Tag = ds.Tables[0].Rows[0]["iYear"].ToString();
                //this.DocumentState.Tag = ds.Tables[0].Rows[0]["iStatus"].ToString();
                //this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                //this.DepartmentRequisitionNumber.Text = ds.Tables[0].Rows[0]["RequisitionNumber"].ToString().Substring(7, 6);
                //this.DepartmentRequisitionNumber.Tag = ds.Tables[0].Rows[0]["RequisitionNumber"].ToString().Substring(7, 6);
                //this.PO_Print.Tag = ds.Tables[0].Rows[0]["RequisitionNumber"].ToString();
                //this.PO_View.Tag = ds.Tables[0].Rows[0]["RequisitionNumber"].ToString();
             
           
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void PODShedID_EditValueChanged(object sender, EventArgs e)
        {

            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.LoomShedID.Text);
            if (shedindex != -1)
            {
                this.LoomShedID.Tag = shedindex.ToString();
                this.LoomShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.LoomShedID.Tag = null;
                this.LoomShedName.Text = "";
            }
        }

        private void PODLoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.LoomShedID.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.LoomShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.LoomNumber.ForeColor = Color.Black;
                this.LoomNumber.BackColor = Color.White;
                this.LoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
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

        private void Dated_EditValueChanged(object sender, EventArgs e)
        {
            if (CurrentDate.ToShortDateString() == this.Dated.DateTime.ToShortDateString()) return;
            Fill_Requisition(this.Dated.DateTime);
        }

        private void panelControl_PODEntry_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}