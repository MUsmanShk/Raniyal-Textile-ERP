using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
namespace MachineEyes.Store
{
    public partial class Store_PurchaseReturn : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePR;
        UserInputMode uiModePRD;
        private string G_Invoice;
        private string N_Invoice;
        DataRow ItemAccountRow;

        int ItemFocusedRowHandle;
        public Store_PurchaseReturn()
        {
            InitializeComponent();
            G_Invoice = "971";
            N_Invoice = "981";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
            fc.Departments_Sub(ref this.PRDDepartment);
            fc.ItemConditions(ref this.Condition);
            fc.ItemMC(ref this.MC);
           
        }

        private void PR_Add_Click(object sender, EventArgs e)
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
            this.Dated.Focus();
        }

        private void PR_Edit_Click(object sender, EventArgs e)
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
            uiModePR = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    PR_Execute.Enabled = false;
                    PR_Cancel.Enabled = false;
                    PR_Add.Enabled = true;

                    PR_View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            PR_Edit.Enabled = true;
                            PR_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            PR_Edit.Enabled = false;
                            PR_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        PR_Edit.Enabled = false;
                        PR_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";

                    PR_Add.Enabled = false;
                    PR_Cancel.Enabled = true;
                    PR_Execute.Enabled = true;
                    PR_Edit.Enabled = false;

                    PR_View.Enabled = false;
                    PR_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    PR_Add.Enabled = false;
                    PR_Cancel.Enabled = true;
                    PR_Execute.Enabled = true;
                    PR_Edit.Enabled = false;

                    PR_Delete.Enabled = false;
                    PR_View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    PR_Add.Enabled = false;
                    PR_Cancel.Enabled = true;
                    PR_Execute.Enabled = true;
                    PR_Edit.Enabled = false;

                    PR_Delete.Enabled = false;
                    PR_View.Enabled = false;

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
                    query = "select max(Convert(numeric(18),SubString(PRNO,8,6)))+1 as MaxNumber  from ST_StorePR where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0' and PRTypeID=2";
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
        private bool PRDGetNextNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    if (this.ReturnRegisterNo.EditValue == null)
                    {
                        XtraMessageBox.Show("Invalid PR Selected!", "Error");
                        return false;
                    }
                    query = "select max(Convert(numeric(18),SubString(PRDNO,14,7)))+1 as MaxNumber  from ST_StoreDetails where PRNO='" + this.ReturnRegisterNo.EditValue.ToString() + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.RefPurchaseDetailNo.EditValue = null;
                        return false;
                    }
                    iNumber = iNumber.PadLeft(7, '0');
                    this.ReturnDetailNo.EditValue = this.ReturnRegisterNo.EditValue.ToString() + iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ReturnDetailNo.EditValue = null;
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.ReturnDetailNo.EditValue = null ;
                return false;
            }
        }
        private void gotoPRDTab(bool GetRecords)
        {
            if (this.PurchaseRegisterNo.EditValue == null) return;
           if (this.PR_Print.Tag == null) return;

            this.ReturnRegisterNo.EditValue = PR_Print.Tag.ToString();
            this.RefPurchaseRegisterNo.EditValue = this.PurchaseRegisterNo.EditValue;
            string q1 = "Select ItemAccountID, ItemAccountName, PRDQTY as PurchasedQty,UOM,PRDRATE AS PurchasedRate,MC,PRNO as PurchaseRegisterNo,PRDNO as PurchaseDetailNo,ConditionID,SubDepartmentID,ShedID,LoomID,LoomName,Remarks,StatusID,GENO from RST_StoreDetails where PRNO='" + this.RefPurchaseRegisterNo.EditValue.ToString() + "' and PRDNO not in(Select RFDNO from ST_StoreDetails where PRNO='" + this.ReturnRegisterNo.EditValue.ToString() + "')";
            DataSet dsPO = WS.svc.Get_DataSet(q1);
            int y = dsPO.Tables[0].Rows.Count;
            DataSet ds = WS.svc.Get_DataSet("Select ItemAccountID, ItemAccountName,PRDQTY as PurchasedQty,UOM,PRDRATE as PurchasedRate,RFDNO as PurchaseDetailNo,SubString(RFDNO,1,13) as PurchaseRegisterNo, PIDQTY as ReturnQty,PIDRATE AS ReturnRate,MC,PRNO as ReturnRegisterNo,PRDNO as ReturnDetailNo,ConditionID,SubDepartmentID,ShedID,LoomID,LoomName,Remarks,StatusID,GENO from RST_StoreDetails where PRNO='" + this.ReturnRegisterNo.EditValue.ToString() + "'");
            ds.Tables[0].Merge(dsPO.Tables[0]);
            if (ds != null)
            {
                this.PODGrid_Item.DataSource = ds.Tables[0];
                for (int x = 8; x < ds.Tables[0].Columns.Count; x++)
                {
                    this.PODGridView_Item.Columns[x].Visible = false;
                }

            }

            DevExpress.XtraGrid.StyleFormatCondition cn;
            cn = new DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.Equal, PODGridView_Item.Columns["ReturnDetailNo"], null, null);
            cn.Appearance.BackColor = Color.Yellow;
            cn.ApplyToRow = true;
            PODGridView_Item.FormatConditions.Add(cn);

            
            this.xtraTabPage_PR.PageEnabled = false;
            this.xtraTabPage_PRD.PageEnabled = true;
            this.xtraTabControlPR.SelectedTabPage = this.xtraTabPage_PRD;
        }
        private void gotoPRTab()
        {
            this.xtraTabPage_PR.PageEnabled = true;
            this.xtraTabPage_PRD.PageEnabled = false;
            this.xtraTabControlPR.SelectedTabPage = this.xtraTabPage_PR;
        }
        private void PRDSaveNew()
        {
            if (this.RefPurchaseRegisterNo.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PO #", "Error");
                return;
            }

            if (this.PRDItemAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.PRDItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }
            if (this.PIDQTY.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.PIDRATE.EditValue == null)
            {
                XtraMessageBox.Show("invalid rates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Condition.EditValue == null)
            {
                XtraMessageBox.Show("invalid condition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.MC.EditValue == null)
            {
                XtraMessageBox.Show("invalid manufacturing country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.ReturnDetailNo.EditValue == null)
            {
                XtraMessageBox.Show("invalid PRD #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.GateEntryNo.EditValue == null)
            {
                XtraMessageBox.Show("invalid Gate Entry #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.ReturnDetailNo.EditValue.ToString();




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_StoreDetails (PRDNO,PRNO,ItemAccountID,RFDNO,PIDQTY,PIDRATE,MinusQty,MinusRate,PRDQTY,PRDRATE,GENO,SubDepartmentID,ShedID,LoomID,LoomName,UOM,ConditionID,MC,Remarks) Values (";
            queries[queries.Length - 1] += "'" + this.ReturnDetailNo.EditValue.ToString() + "','" + this.ReturnRegisterNo.EditValue.ToString() + "'";

            if (this.PRDItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PRDItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.RefPurchaseDetailNo.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPurchaseDetailNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PIDQTY.EditValue != null)
                queries[queries.Length - 1] += "," + this.PIDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PIDRATE.EditValue != null)
                queries[queries.Length - 1] += "," + this.PIDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.PIDQTY.EditValue != null)
                queries[queries.Length - 1] += "," + this.PIDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PIDRATE.EditValue != null)
                queries[queries.Length - 1] += "," + this.PIDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.PRDQTY.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PRDRATE.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";


            if (this.GateEntryNo.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.GateEntryNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            
            if (this.PRDDepartment.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PRDDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PRDShedID.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDShedID.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PRDLoomNumber.Tag != null)
                queries[queries.Length - 1] += "," + this.PRDLoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PRDLoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PRDLoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PRDUOM.Text != "")
                queries[queries.Length - 1] += ",'" + this.PRDUOM.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Condition.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Condition.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.MC.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.MC.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PRDRemarks.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PRDRemarks.EditValue.ToString() + "'";
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


                    ItemAccountRow["ItemAccountID"] = this.PRDItemAccountID.EditValue.ToString();
                    if (this.PRDItemAccountName.EditValue != null) ItemAccountRow["ItemAccountName"] = this.PRDItemAccountName.EditValue.ToString();
                    ItemAccountRow["ReturnDetailNo"] = this.ReturnDetailNo.EditValue.ToString();
                    ItemAccountRow["ReturnRegisterNo"] = this.ReturnRegisterNo.EditValue.ToString();
                    if (this.PIDQTY.EditValue != null) ItemAccountRow["ReturnQty"] = this.PIDQTY.EditValue.ToString();
                    if (this.PIDRATE.EditValue != null) ItemAccountRow["ReturnRate"] = this.PRDRATE.EditValue.ToString();
                    if (this.GateEntryNo.EditValue != null) ItemAccountRow["GENO"] = this.GateEntryNo.EditValue.ToString();
                    if (this.Condition.EditValue != null) ItemAccountRow["ConditionID"] = this.Condition.EditValue.ToString();
                    if (this.MC.EditValue != null) ItemAccountRow["MC"] = this.MC.EditValue.ToString();
                    if (this.PRDRemarks.Text != "") ItemAccountRow["remarks"] = this.Remarks.Text;

                    this.RefPurchaseDetailNo.EditValue = null;
                    this.PRDItemAccountID.Tag = null;
                    this.PRDItemAccountID.EditValue = null;
                    this.ReturnDetailNo.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDUOM.Text = "";
                    this.PRDDepartment.EditValue = null;
                    this.PRDItemAccountName.EditValue = null;
                    this.PRDLoomNumber.EditValue = null;
                    this.PRDLoomNumber.Tag = null;
                    this.GateEntryNo.EditValue = null;
                    this.PIDQTY.EditValue = null;
                    this.PRDRemarks.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDStock.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDQTY.EditValue = null;
                    this.RefPurchaseDetailNo.EditValue = null;
                    SetButtonStates_PRD(UserInputMode.View);
                    this.PRD_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PRDUpdateExisting()
        {
            if (this.RefPurchaseRegisterNo.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PO #", "Error");
                return;
            }

            if (this.PRDItemAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Item Account ID", "Error");
                return;
            }
            if (this.PRDItemAccountID.Text.Length != 13)
            {
                XtraMessageBox.Show("invalid Item ACCOUNT ID ...length must be 13 Characters", "Error");
                return;
            }
            if (this.PIDQTY.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.PIDRATE.EditValue == null)
            {
                XtraMessageBox.Show("invalid rates", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Condition.EditValue == null)
            {
                XtraMessageBox.Show("invalid condition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.MC.EditValue == null)
            {
                XtraMessageBox.Show("invalid manufacturing country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.ReturnDetailNo.EditValue == null)
            {
                XtraMessageBox.Show("invalid PRD #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.GateEntryNo.EditValue == null)
            {
                XtraMessageBox.Show("invalid Gate Entry #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string[] queries = new string[0];
           
            string CodeToUpdate = this.ReturnDetailNo.EditValue.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StoreDetails set ";


            queries[queries.Length - 1] += "PRDNO='" + this.ReturnDetailNo.EditValue.ToString() + "',PRNO='" + this.ReturnRegisterNo.EditValue.ToString() + "',RFDNO='"+this.RefPurchaseDetailNo.EditValue.ToString()+"'";

            if (this.PRDItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",ItemAccountID='" + this.PRDItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountID=null";

            if (this.PRDQTY.EditValue != null)
                queries[queries.Length - 1] += ",PRDQty=" + this.PRDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PrdQty=0";

            if (this.PRDRATE.EditValue != null)
                queries[queries.Length - 1] += ",PrdRate=" + this.PRDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PrdRate=0";

            if (this.PIDQTY.EditValue != null)
                queries[queries.Length - 1] += ",PIDQty=" + this.PIDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PIdQty=0";

            if (this.PIDRATE.EditValue != null)
                queries[queries.Length - 1] += ",PIdRate=" + this.PIDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PIdRate=0";

            if (this.PIDQTY.EditValue != null)
                queries[queries.Length - 1] += ",MinusQty=" + this.PIDQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",MinusQty=0";

            if (this.PIDRATE.EditValue != null)
                queries[queries.Length - 1] += ",MinusRate=" + this.PIDRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",MinusRate=0";
            if (this.GateEntryNo.EditValue != null)
                queries[queries.Length - 1] += ",GENO='" + this.GateEntryNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",GENO=null";
                        
            if (this.PRDDepartment.EditValue != null)
                queries[queries.Length - 1] += ",SubDepartmentID='" + this.PRDDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SubDepartmentID=null";

            if (this.PRDShedID.EditValue != null)
                queries[queries.Length - 1] += ",ShedID=" + this.PRDShedID.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ShedID=null";

            if (this.PRDLoomNumber.Tag != null)
                queries[queries.Length - 1] += ",LoomID=" + this.PRDLoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",LoomID=null";
            if (this.PRDLoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",LoomName='" + this.PRDLoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",LoomName=null";
            if (this.PRDUOM.Text != "")
                queries[queries.Length - 1] += ",UOM='" + this.PRDUOM.Text + "'";
            else
                queries[queries.Length - 1] += ",UOM=null";
            if (this.Condition.EditValue != null)
                queries[queries.Length - 1] += ",ConditionID='" + this.Condition.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ConditionID=null";
            if (this.MC.EditValue != null)
                queries[queries.Length - 1] += ",MC='" + this.MC.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",MC=null";
            if (this.PRDRemarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.PRDRemarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";

            queries[queries.Length - 1] += " where PRDNO='" + CodeToUpdate + "'";


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
                    if (this.PRDItemAccountID.Tag != null)
                    {
                        string[] ParamName = new string[0];
                        string[] ParamValue = new string[0];
                        MachineService.SqlDbType[] dbType = new MachineService.SqlDbType[0];
                        Array.Resize(ref ParamName, 1);
                        Array.Resize(ref ParamValue, 1);
                        Array.Resize(ref dbType, 1);


                        ParamName[0] = "ItemAccountID";
                        ParamValue[0] = this.PRDItemAccountID.Tag.ToString();
                        dbType[0] = MachineService.SqlDbType.VarChar;

                        string rSp = WS.svc.Execute_StoredProcedure("PROC_UpdateStockForItem", ParamName, ParamValue, dbType);
                        if (rSp != "**SUCCESS##")
                        {
                            XtraMessageBox.Show("Executing Stored Procedure to update stock returned error: " + rSp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    ItemAccountRow["ItemAccountID"] = this.PRDItemAccountID.EditValue.ToString();
                    if (this.PRDItemAccountName.EditValue != null) ItemAccountRow["ItemAccountName"] = this.PRDItemAccountName.EditValue.ToString();
                    ItemAccountRow["ReturnDetailNo"] = this.ReturnDetailNo.EditValue.ToString();
                    ItemAccountRow["ReturnRegisterNo"] = this.ReturnRegisterNo.EditValue.ToString();
                    if (this.PIDQTY.EditValue != null) ItemAccountRow["ReturnQty"] = this.PIDQTY.EditValue.ToString();
                    if (this.PIDRATE.EditValue != null) ItemAccountRow["ReturnRate"] = this.PIDRATE.EditValue.ToString();
                    if (this.GateEntryNo.EditValue != null) ItemAccountRow["GENO"] = this.GateEntryNo.EditValue.ToString();
                    if (this.Condition.EditValue != null) ItemAccountRow["ConditionID"] = this.Condition.EditValue.ToString();
                    if (this.MC.EditValue != null) ItemAccountRow["MC"] = this.MC.EditValue.ToString();
                    if (this.PRDRemarks.Text != "") ItemAccountRow["remarks"] = this.Remarks.Text;







                    this.RefPurchaseDetailNo.EditValue = null;
                    this.PRDItemAccountID.Tag = null;
                    this.PRDItemAccountID.EditValue = null;
                    this.ReturnDetailNo.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDUOM.Text = "";
                    this.PRDDepartment.EditValue = null;
                    this.PRDItemAccountName.EditValue = null;
                    this.PRDLoomNumber.EditValue = null;
                    this.PRDLoomNumber.Tag = null;
                    this.GateEntryNo.EditValue = null;
                    this.PIDQTY.EditValue = null;
                    this.PRDRemarks.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDStock.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDQTY.EditValue = null;
                    this.RefPurchaseDetailNo.EditValue = null;
                    SetButtonStates_PRD(UserInputMode.View);


                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PRDDeleteExisting()
        {



          

            if (this.ReturnDetailNo.EditValue == null)
            {
                XtraMessageBox.Show("invalid PRD #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            


            string[] queries = new string[0];
                    string CodeToUpdate = this.ReturnDetailNo.EditValue.ToString();

                    DialogResult dg = XtraMessageBox.Show("Are you sure to delete " + CodeToUpdate + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "Delete from ST_StoreDetails ";

            queries[queries.Length - 1] += " where PRDNO='" + CodeToUpdate + "'";


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
                    
                    ItemAccountRow["ReturnDetailNo"] = DBNull.Value;
                    ItemAccountRow["ReturnRegisterNo"] = DBNull.Value;
                    ItemAccountRow["ReturnQty"] = DBNull.Value;
                    ItemAccountRow["ReturnRate"] = DBNull.Value;

                    if (this.PRDItemAccountID.Tag != null)
                    {
                        string[] ParamName = new string[0];
                        string[] ParamValue = new string[0];
                        MachineService.SqlDbType[] dbType = new MachineService.SqlDbType[0];
                        Array.Resize(ref ParamName, 1);
                        Array.Resize(ref ParamValue, 1);
                        Array.Resize(ref dbType, 1);


                        ParamName[0] = "ItemAccountID";
                        ParamValue[0] = this.PRDItemAccountID.Tag.ToString();
                        dbType[0] = MachineService.SqlDbType.VarChar;

                        string rSp = WS.svc.Execute_StoredProcedure("PROC_UpdateStockForItem", ParamName, ParamValue, dbType);
                        if (rSp != "**SUCCESS##")
                        {
                            XtraMessageBox.Show("Executing Stored Procedure to update stock returned error: " + rSp, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                    this.RefPurchaseDetailNo.EditValue = null;
                    this.PRDItemAccountID.Tag = null;
                    this.PRDItemAccountID.EditValue = null;
                    this.ReturnDetailNo.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDUOM.Text = "";
                    this.PRDDepartment.EditValue = null;
                    this.PRDItemAccountName.EditValue = null;
                    this.PRDLoomNumber.EditValue = null;
                    this.PRDLoomNumber.Tag = null;
                    this.GateEntryNo.EditValue = null;
                    this.PIDQTY.EditValue = null;
                    this.PRDRemarks.EditValue = null;
                    this.PRDROL.EditValue = null;
                    this.PRDStock.EditValue = null;
                    this.PRDRATE.EditValue = null;
                    this.PRDQTY.EditValue = null;
                    this.RefPurchaseDetailNo.EditValue = null;
                    SetButtonStates_PRD(UserInputMode.View);


                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void SetButtonStates_PRD(UserInputMode uim)
        {
            uiModePRD = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    CurrentMode.Text = "View";
                    CurrentMode.ForeColor = Color.White;

                    this.PRD_Execute.Enabled = false;
                    this.PRD_Cancel.Enabled = false;
                    this.PRD_Add.Enabled = true;




                    if (this.RefPurchaseDetailNo.EditValue != null)
                    {
                        if (this.PRDItemAccountID.Tag.ToString() != "")
                        {

                            this.PRD_Edit.Enabled = true;
                            this.PRD_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.PRD_Edit.Enabled = false;
                            this.PRD_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        PRD_Edit.Enabled = false;
                        PRD_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                     CurrentMode.Text = "Add";
                    CurrentMode.ForeColor = Color.Yellow;
                    this.PRD_Add.Enabled = false;
                    this.PRD_Cancel.Enabled = true;
                    PRD_Execute.Enabled = true;
                    PRD_Edit.Enabled = false;

                    PRD_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                     CurrentMode.Text = "Edit";
                    CurrentMode.ForeColor = Color.Blue;
                    PRD_Add.Enabled = false;
                    PRD_Cancel.Enabled = true;
                    PRD_Execute.Enabled = true;
                    PRD_Edit.Enabled = false;

                    PRD_Delete.Enabled = false;


                    break;
                case UserInputMode.Delete:
                     CurrentMode.Text = "Delete";
                    CurrentMode.ForeColor = Color.Red;
                    PRD_Add.Enabled = false;
                    PRD_Cancel.Enabled = true;
                    PRD_Execute.Enabled = true;
                    PRD_Edit.Enabled = false;

                    PRD_Delete.Enabled = false;


                    break;
                default:
                    break;
            }
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

            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
                return;
            }
            if (this.AccountName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
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
            queries[queries.Length - 1] = "insert into ST_StorePR (NumberType,PRTYPEID,PRNO,iType,iCat,iYear,iStatus,PONO,Dated,AccountID,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.iCodeType.EditValue.ToString() + "',2,'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            //Array.Resize(ref queries, queries.Length + 1);
            //queries[queries.Length - 1] = "insert into ST_StoreDetails (PRNO,ItemAccountID,UOM,PODNO,PODQTY,PODRATE,ShedID,LoomID,LoomName) Select '" + vnum + "',ItemAccountID,UOM,PODNO,PODQTY,PODRATE,ShedID,LoomID,LoomName from ST_PurchaseOrderDetails (NumberType,PRNO,iType,iCat,iYear,iStatus,PONO,Dated,Remarks,CUserID,CUserTime) Values (";
           
            if (this.PurchaseRegisterNo.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PurchaseRegisterNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";


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

                    this.PR_Print.Tag = vnum;
                    this.ReturnRegisterNo.EditValue = vnum;
                    this.RefPurchaseRegisterNo.EditValue = this.PurchaseRegisterNo.EditValue.ToString();
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                    gotoPRDTab(true);

                    SetButtonStates(UserInputMode.View);
                    this.PRD_Add.Focus();

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
            if (this.AccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
                return;
            }
            if (this.AccountName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.AccountID.Focus();
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
            queries[queries.Length - 1] = "update ST_StorePR set ";
            queries[queries.Length - 1] += " NumberType='" + this.iCodeType.EditValue.ToString() + "',PRNO='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "',iStatus='U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

            if (this.PurchaseRegisterNo.EditValue != null)
                queries[queries.Length - 1] += ",PONO='" + this.PurchaseRegisterNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO=null";

            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",AccountID='" + this.AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AccountID=null";
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";


            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PRNO='" + CodeToUpdate + "'";

          
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

                    this.PR_Print.Tag = vnum;
                    this.ReturnRegisterNo.EditValue = vnum;
                    this.RefPurchaseRegisterNo.EditValue = this.PurchaseRegisterNo.EditValue;
                    this.PurchaseRegisterNo.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountName.EditValue = null;
                    this.AccountID.EditValue = null;
                    this.Remarks.EditValue = null;

                    SetButtonStates(UserInputMode.View);
                    this.PR_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteExisting()
        {




            //DialogResult dg = XtraMessageBox.Show("Are you sure to delete ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dg != DialogResult.Yes) return;
               



            string[] queries = new string[0];
            string GRNtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete PR  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

           
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


                    this.PR_Print.Tag = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    this.AccountID.EditValue = null;
                    this.AccountName.EditValue = null;
                    this.Remarks.EditValue = null;

                    SetButtonStates(UserInputMode.View);
                    this.PR_Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PR_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePR == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiModePR== UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiModePR == UserInputMode.Delete)
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
                if (uiModePR == UserInputMode.Add || uiModePR == UserInputMode.Edit)
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
                if (uiModePR == UserInputMode.Add)
                {
                    if (this.iCodeType.EditValue.ToString() == "0")
                        GetNextInvoiceNumber();
                }
            }
        }

        private void PR_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void PR_Delete_Click(object sender, EventArgs e)
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

        private void PRD_Add_Click(object sender, EventArgs e)
        {
            this.RefPurchaseDetailNo.EditValue = null;
            this.PRDItemAccountID.Tag = null;
            this.PRDItemAccountID.EditValue = null;

            this.PRDRATE.EditValue = null;
            this.PRDROL.EditValue = null;
            this.PRDUOM.Text = "";
            this.PRDDepartment.EditValue = null;
            this.PRDItemAccountName.EditValue = null;
            this.PRDLoomNumber.EditValue = null;
            this.PRDLoomNumber.Tag = null;
            
            this.GateEntryNo.EditValue = null;
            this.PIDQTY.EditValue = null;
            this.PRDRemarks.EditValue = null;
            this.PRDROL.EditValue = null;
            this.PRDStock.EditValue = null;

            
            SetButtonStates_PRD(UserInputMode.Add);
            this.GateEntryNo.Focus();
        }
        private void SelectPRDRecord(bool DelMode)
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.PODGridView_Item.GetDataRow(this.PODGridView_Item.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                    this.PRDItemAccountID.EditValue = ItemAccountRow["ItemAccountID"].ToString();
                    this.PRDItemAccountName.EditValue = ItemAccountRow["ItemAccountName"].ToString();
                    this.PRDItemAccountID.Tag = ItemAccountRow["ItemAccountID"].ToString();
                    this.PRDUOM.Text = ItemAccountRow["UOM"].ToString();
                    this.RefPurchaseDetailNo.EditValue = ItemAccountRow["PurchaseDetailNo"].ToString();
                   
                    this.RefPurchaseRegisterNo.EditValue = ItemAccountRow["PurchaseRegisterNo"].ToString() == "" ? null : ItemAccountRow["PurchaseRegisterNo"].ToString();
                    if (ItemAccountRow["ReturnDetailNo"].ToString()!="")
                    {
                        this.ReturnDetailNo.EditValue = ItemAccountRow["ReturnDetailNo"].ToString();
                        if (DelMode == true)
                            SetButtonStates_PRD(UserInputMode.Delete);
                        else
                        SetButtonStates_PRD(UserInputMode.Edit);
                        this.PIDRATE.EditValue = ItemAccountRow["ReturnRate"].ToString();
                        this.PIDQTY.EditValue = ItemAccountRow["ReturnQty"].ToString();
                        this.PIDQTY.BackColor = Color.White;
                        this.PIDRATE.BackColor = Color.White;
                        this.PRDRemarks.BackColor = Color.White;
                        this.GateEntryNo.BackColor = Color.White;
                        this.Condition.BackColor = Color.White;
                        this.MC.BackColor = Color.White;
                        this.PRDShedID.BackColor = Color.White;
                        this.PRDShedName.BackColor = Color.White;
                        this.PRDItemAccountName.BackColor = Color.White;
                        this.PRDItemAccountID.BackColor = Color.White;
                        this.PRDDepartment.BackColor = Color.White;
                        this.PRDLoomNumber.BackColor = Color.White;
                    }
                    else
                    {
                        bool rRes = PRDGetNextNumber();
                        SetButtonStates_PRD(UserInputMode.Add);
                        this.PIDRATE.EditValue = ItemAccountRow["PurchasedRate"].ToString();
                        this.PIDQTY.EditValue = ItemAccountRow["PurchasedQty"].ToString();
                       
                            this.PIDQTY.BackColor = Color.Yellow;
                            this.PIDRATE.BackColor = Color.Yellow;
                            this.PRDRemarks.BackColor = Color.Yellow;
                            this.GateEntryNo.BackColor = Color.Yellow;
                            this.Condition.BackColor = Color.Yellow;
                            this.MC.BackColor = Color.Yellow;
                            this.PRDShedID.BackColor = Color.Yellow;
                            this.PRDShedName.BackColor = Color.Yellow;
                            this.PRDItemAccountName.BackColor = Color.Yellow;
                            this.PRDItemAccountID.BackColor = Color.Yellow;
                            this.PRDDepartment.BackColor = Color.Yellow;
                            this.PRDLoomNumber.BackColor = Color.Yellow;
                        
                    }
                   
                   
                   
                    
                    this.PRDRATE.EditValue = ItemAccountRow["PurchasedRate"].ToString() == "" ? null : ItemAccountRow["PurchasedRate"].ToString();
                    this.RefPurchaseDetailNo.EditValue = ItemAccountRow["PurchaseDetailNo"].ToString() == "" ? null : ItemAccountRow["PurchaseDetailNo"].ToString();
                    this.PRDQTY.EditValue = ItemAccountRow["PurchasedQty"].ToString() == "" ? null : ItemAccountRow["PurchasedQty"].ToString();
                    this.PRDRemarks.EditValue = ItemAccountRow["Remarks"].ToString() == "" ? null : ItemAccountRow["Remarks"].ToString();
                    this.PRDDepartment.EditValue = ItemAccountRow["SubDepartmentID"].ToString() == "" ? null : ItemAccountRow["SubDepartmentID"].ToString();
                    this.PRDShedID.EditValue = ItemAccountRow["ShedID"].ToString() == "" ? null : ItemAccountRow["ShedID"].ToString();
                    this.PRDLoomNumber.Tag = ItemAccountRow["LoomID"].ToString() == "" ? null : ItemAccountRow["LoomID"].ToString();
                    this.PRDLoomNumber.EditValue = ItemAccountRow["LoomName"].ToString() == "" ? null : ItemAccountRow["LoomName"].ToString();
                    this.Condition.EditValue = ItemAccountRow["ConditionID"].ToString() == "" ? null : ItemAccountRow["ConditionID"].ToString();
                    this.MC.EditValue = ItemAccountRow["MC"].ToString() == "" ? null : ItemAccountRow["MC"].ToString();
                    this.GateEntryNo.EditValue = ItemAccountRow["GENO"].ToString() == "" ? null : ItemAccountRow["GENO"].ToString();
                   
                }
            }
        }

        private void PODGridView_Item_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ItemFocusedRowHandle = this.PODGridView_Item.FocusedRowHandle;
            SelectPRDRecord(false);
        }

        private void PRD_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePRD == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                PRDSaveNew();
            }
            else if (uiModePRD == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                PRDUpdateExisting();
            }
            else if (uiModePRD == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                PRDDeleteExisting();
            }
        }

        private void PRD_Edit_Click(object sender, EventArgs e)
        {
            if (this.RefPurchaseDetailNo.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SetButtonStates_PRD(UserInputMode.Edit);
        }

        private void PRD_Delete_Click(object sender, EventArgs e)
        {
            if (this.RefPurchaseDetailNo.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_PRD(UserInputMode.Delete);
        }

        private void PRDItemAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && e.Control == true)
            //{
            //    selectedrow sRow;
            //    sRow = Program.MainWindow.StoreAccountsList.SelectedRow;
            //    Program.MainWindow.StoreAccountsList.ShowDialog();
            //    if (sRow.Status == ParameterStatus.Selected)
            //    {
            //        this.PRDItemAccountID.EditValue = sRow.PrimeryID;
            //        this.PRDItemAccountName.EditValue = sRow.PrimaryString;
            //        try
            //        {
            //            this.PRDROL.EditValue = sRow.SelectedDataRow["ReOrderLevel"].ToString() == "" ? null : sRow.SelectedDataRow["ReOrderLevel"].ToString();
            //            this.PODRATE.EditValue = sRow.SelectedDataRow["bUnitRate"].ToString() == "" ? null : sRow.SelectedDataRow["bUnitRate"].ToString();
                       
            //            this.PRDUOM.Text = sRow.SelectedDataRow["bUnit"].ToString() == "" ? null : sRow.SelectedDataRow["bUnit"].ToString();
            //        }
            //        catch (Exception ex)
            //        {
            //            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }

        private void PR_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            strFilterQuery = "SELECT PRNO as ReturnRegisterNo,Dated,AccountName,Remarks  FROM RST_StorePR ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' and PRTypeID=2 and iStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' ";






            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "ReturnRegisterNo", "ReturnRegisterNo");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.PR_Print.Tag = sRow.PrimeryID;
                this.PR_View.Tag = sRow.PrimeryID;
                Fill_PurchaseRegister(sRow.PrimeryID);

            }
        }

        private void Fill_PurchaseRegister(string PRNO)
        {
            try
            {
                this.PR_Edit.Enabled = false;
                this.PR_Delete.Enabled = false;
                DataSet ds = WS.svc.Get_DataSet("Select * from ST_StorePR where PRNO='" + PRNO + "'");
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
                this.AccountID.EditValue = ds.Tables[0].Rows[0]["AccountID"].ToString();
                this.AccountName.EditValue = MachineEyes.Classes.Accounting.Get_AccountName_ByAccountID_V(this.AccountID.EditValue.ToString());
                this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (ds.Tables[0].Rows[0]["NumberType"].ToString() == "0")
                {
                    this.Suffix.Text = ds.Tables[0].Rows[0]["PRNO"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString().Substring(7, 6);


                }
                else
                {
                    this.Suffix.EditValue = ds.Tables[0].Rows[0]["PRNO"].ToString();
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString();
                }

                this.PR_Print.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString();
                this.PR_View.Tag = ds.Tables[0].Rows[0]["PRNO"].ToString();
                this.RefPurchaseRegisterNo.EditValue = ds.Tables[0].Rows[0]["PONO"].ToString();
                this.PurchaseRegisterNo.EditValue = ds.Tables[0].Rows[0]["PONO"].ToString();
                this.ReturnRegisterNo.EditValue = ds.Tables[0].Rows[0]["PRNO"].ToString();
                this.PR_Edit.Enabled = true;
                this.PR_Delete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PR_Next_Click(object sender, EventArgs e)
        {
            gotoPRDTab(true);
        }

        private void PRDShedID_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.PRDShedID.Text);
            if (shedindex != -1)
            {
                this.PRDShedID.Tag = shedindex.ToString();
                this.PRDShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.PRDShedID.Tag = null;
                this.PRDShedID.EditValue = null;
                this.PRDShedName.Text = "";
            }
        }

        private void PRDLoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.PRDShedID.Tag == null)
            {
                this.PRDLoomNumber.ForeColor = Color.White;
                this.PRDLoomNumber.BackColor = Color.Red;
                this.PRDLoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.PRDLoomNumber.Text, this.PRDShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.PRDLoomNumber.ForeColor = Color.Black;
                this.PRDLoomNumber.BackColor = Color.White;
                this.PRDLoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.PRDLoomNumber.ForeColor = Color.White;
                this.PRDLoomNumber.BackColor = Color.Red;
                this.PRDLoomNumber.Tag = null;
            }
        }

        private void PRD_Back_Click(object sender, EventArgs e)
        {
            gotoPRTab();
        }

        private void PODGridView_Item_Click(object sender, EventArgs e)
        {
            SelectPRDRecord(false);
        }

        private void RefPONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select PRNO as PurchaseRegisterNo,Dated,AccountName,Remarks from RST_StorePR where PRNO not in(Select PRNO from ST_StorePR where PRTypeID=2) and iYear='"+this.FinancialYear.Text+"'", "PurchaseRegisterNo", "PurchaseRegisterNo");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.PurchaseRegisterNo.Tag = sRow.PrimeryID;
                    this.PurchaseRegisterNo.EditValue = sRow.PrimeryID;
                }
            }
        }

        private void PODGridView_Item_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void PODGridView_Item_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void PRDNO_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void PODGridView_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Delete)
            SelectPRDRecord(true);
        }

        private void panelControl_PODEntry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PR_Print_Click(object sender, EventArgs e)
        {
            if (this.PR_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PR #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MachineEyes.Classes.Printing.Print_ST_PurchaseReturn(this.PR_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                Program.MainWindow.AccountsList.ShowDialog();
                if (Program.MainWindow.AccountsList.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    this.AccountID.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimeryID;
                    this.AccountName.EditValue = Program.MainWindow.AccountsList.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.F1)
            {
                if (this.AccountID.EditValue != null)
                {
                    if (this.AccountID.EditValue.ToString() != "")
                    {
                        Accounts.Account_info info = new Accounts.Account_info();
                        info.FillAccount(this.AccountID.Text);
                        info.ShowDialog();
                    }
                }

            }
        }

        private void Store_PurchaseReturn_Load(object sender, EventArgs e)
        {
            this.xtraTabPage_PR.PageEnabled = true;
            this.xtraTabPage_PRD.PageEnabled = false;
        }

    }
}