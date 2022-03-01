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
namespace MachineEyes.Accounts
{
    public partial class Accounts_OpeningBalances: DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePR;
        UserInputMode uiModePRD;
        private string G_Invoice;
        private string N_Invoice;
        DataRow ItemAccountRow;

        int ItemFocusedRowHandle;
        public Accounts_OpeningBalances()
        {
            InitializeComponent();
            G_Invoice = "871";
            N_Invoice = "881";
            this.Prefix.Text = N_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "N";
           
            FillCombos fc = new FillCombos();
       
        }     
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(PRNO,8,6)))+1 as MaxNumber  from ST_StorePR where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0' and PRTYPEID=0";
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
        
      
        private void PRDSaveNew()
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
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (this.PRDQty.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_StoreDetails (PRDNO,PRNO,ItemAccountID,PRDQTY,PRDRATE,PlusQty,PlusRate,GENO,PODNO,PODQTY,PODRATE,SubDepartmentID,ShedID,LoomID,LoomName,UOM,ConditionID,MC,Remarks) Values (";
            queries[queries.Length - 1] += "'" + this.PRDNO.EditValue.ToString() + "','" + this.SelectedPRNO.EditValue.ToString() + "'";

            if (this.PRDItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PRDItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PRDRate.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PRDRate.EditValue != null)
                queries[queries.Length - 1] += "," + this.PRDRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.GateEntryNo.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.GateEntryNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.PODNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.PODQTY.EditValue != null)
                queries[queries.Length - 1] += "," + this.PODQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.PODRATE.EditValue != null)
                queries[queries.Length - 1] += "," + this.PODRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
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


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_ItemAccounts set ";
          

            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += "bUnitRate=" + this.PRDRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",bUnitRate=0";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",bDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",bDate=null";

            queries[queries.Length - 1] += "where ItemAccountID='"+ this.PRDItemAccountID.EditValue.ToString()+"'";

            // Array.Resize(ref queries, queries.Length + 1);
            //  queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + vnum + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','A')";
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


                    ItemAccountRow["ItemAccountID"] = this.PRDItemAccountID.EditValue.ToString();
                    if (this.PRDItemAccountName.EditValue != null) ItemAccountRow["ItemAccountName"] = this.PRDItemAccountName.EditValue.ToString();
                    ItemAccountRow["PRDNO"] = this.PRDNO.EditValue.ToString();
                    ItemAccountRow["PRNO"] = this.SelectedPRNO.EditValue.ToString();
                    if (this.PRDQty.EditValue != null) ItemAccountRow["PRDQTY"] = this.PRDQty.EditValue.ToString();
                    if (this.PRDRate.EditValue != null) ItemAccountRow["PRDRATE"] = this.PODRATE.EditValue.ToString();
                    if (this.GateEntryNo.EditValue != null) ItemAccountRow["GENO"] = this.GateEntryNo.EditValue.ToString();
                    if (this.Condition.EditValue != null) ItemAccountRow["ConditionID"] = this.Condition.EditValue.ToString();
                    if (this.MC.EditValue != null) ItemAccountRow["MC"] = this.MC.EditValue.ToString();
                    if (this.PRDRemarks.Text != "") ItemAccountRow["remarks"] = this.Remarks.Text;

                   
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
            if (this.PRDQty.EditValue == null)
            {
                XtraMessageBox.Show("invalid quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

         


            string[] queries = new string[0];
           
            string CodeToUpdate = this.PRDNO.EditValue.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_StoreDetails set ";


            queries[queries.Length - 1] += "PRDNO='" + this.PRDNO.EditValue.ToString() + "',PRNO='" + this.SelectedPRNO.EditValue.ToString() + "'";

            if (this.PRDItemAccountID.EditValue != null)
                queries[queries.Length - 1] += ",ItemAccountID='" + this.PRDItemAccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ItemAccountID=null";

            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += ",PRDQty=" + this.PRDQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PrdQty=0";

            if (this.PRDRate.EditValue != null)
                queries[queries.Length - 1] += ",PrdRate=" + this.PRDRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PrdRate=0";

            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += ",PlusQty=" + this.PRDQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PlusQty=0";

            if (this.PRDRate.EditValue != null)
                queries[queries.Length - 1] += ",PlusRate=" + this.PRDRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PlusRate=0";


            if (this.GateEntryNo.EditValue != null)
                queries[queries.Length - 1] += ",GENO='" + this.GateEntryNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",GENO=null";
            if (this.PODNumber.EditValue != null)
                queries[queries.Length - 1] += ",PODNO='" + this.PODNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PODNO=null";
            if (this.PODQTY.EditValue != null)
                queries[queries.Length - 1] += ",PODQtY=" + this.PODQTY.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PODQTY=0";

            if (this.PODRATE.EditValue != null)
                queries[queries.Length - 1] += ",PODRATE=" + this.PODRATE.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",PODRATE=0";
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

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update ST_ItemAccounts set ";


            if (this.PRDQty.EditValue != null)
                queries[queries.Length - 1] += "bUnitRate=" + this.PRDQty.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",bUnitRate=0";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",bDate='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",bDate=null";

            queries[queries.Length - 1] += "where ItemAccountID='" + this.PRDItemAccountID.EditValue.ToString() + "'";


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
                    ItemAccountRow["ItemAccountID"] = this.PRDItemAccountID.EditValue.ToString();
                    if (this.PRDItemAccountName.EditValue != null) ItemAccountRow["ItemAccountName"] = this.PRDItemAccountName.EditValue.ToString();
                    ItemAccountRow["PRDNO"] = this.PRDNO.EditValue.ToString();
                    ItemAccountRow["PRNO"] = this.SelectedPRNO.EditValue.ToString();
                    if (this.PRDQty.EditValue != null) ItemAccountRow["PRDQTY"] = this.PRDQty.EditValue.ToString();
                    if (this.PRDRate.EditValue != null) ItemAccountRow["PRDRATE"] = this.PODRATE.EditValue.ToString();
                    if (this.GateEntryNo.EditValue != null) ItemAccountRow["GENO"] = this.GateEntryNo.EditValue.ToString();
                    if (this.Condition.EditValue != null) ItemAccountRow["ConditionID"] = this.Condition.EditValue.ToString();
                    if (this.MC.EditValue != null) ItemAccountRow["MC"] = this.MC.EditValue.ToString();
                    if (this.PRDRemarks.Text != "") ItemAccountRow["remarks"] = this.Remarks.Text;







               
                    this.PODNumber.EditValue = null;
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



          

           

            string[] queries = new string[0];
                    string CodeToUpdate = this.PRDNO.EditValue.ToString();

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
                    
                    ItemAccountRow["PRDNO"] = DBNull.Value;
                    ItemAccountRow["PRNO"] = DBNull.Value;
                    ItemAccountRow["PRDQTY"] = DBNull.Value;
                    ItemAccountRow["PRDRATE"] = DBNull.Value;
                    ItemAccountRow["GENO"] = DBNull.Value;
                    ItemAccountRow["ConditionID"] = DBNull.Value;
                    ItemAccountRow["MC"] = DBNull.Value;
                   

                   
                    this.PRDItemAccountID.Tag = null;
                    this.PRDItemAccountID.EditValue = null;
                  
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




                    if (this.Suffix.EditValue != null)
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
            if (this.Prefix.Text.Length != 3)
            {
                XtraMessageBox.Show("invalid sales invoice series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


           


            string[] queries = new string[0];
            string vnum = "";
           
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
           

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("Purchase Order list  code is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
           


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into ST_StorePR (NumberType,PRTYPEID,PRNO,iType,iCat,iYear,iStatus,PONO,PONO2,PONO3,PONO4,PONO5,PONO6,Dated,AccountID,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.iCodeType.EditValue.ToString() + "',0,'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            //Array.Resize(ref queries, queries.Length + 1);
            //queries[queries.Length - 1] = "insert into ST_StoreDetails (PRNO,ItemAccountID,UOM,PODNO,PODQTY,PODRATE,ShedID,LoomID,LoomName) Select '" + vnum + "',ItemAccountID,UOM,PODNO,PODQTY,PODRATE,ShedID,LoomID,LoomName from ST_PurchaseOrderDetails (NumberType,PRNO,iType,iCat,iYear,iStatus,PONO,Dated,Remarks,CUserID,CUserTime) Values (";
           
            if (this.RefPONO.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RefPONO2.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO2.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RefPONO3.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO3.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RefPONO4.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO4.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RefPONO5.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO5.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.RefPONO6.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefPONO6.EditValue.ToString() + "'";
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




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + vnum + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','A')";
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
                    this.RefAccountID.EditValue = this.AccountID.EditValue;
                    this.PR_Print.Tag = vnum;
                    this.SelectedPRNO.EditValue = vnum;
                   
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    gotoPRDTab(true);

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

            if (this.RefPONO.EditValue != null)
                queries[queries.Length - 1] += ",PONO='" + this.RefPONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO=null";

            if (this.RefPONO2.EditValue != null)
                queries[queries.Length - 1] += ",PONO2='" + this.RefPONO2.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO2=null";
            if (this.RefPONO3.EditValue != null)
                queries[queries.Length - 1] += ",PONO3='" + this.RefPONO3.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO3=null";
            if (this.RefPONO4.EditValue != null)
                queries[queries.Length - 1] += ",PONO4='" + this.RefPONO4.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO4=null";
            if (this.RefPONO5.EditValue != null)
                queries[queries.Length - 1] += ",PONO5='" + this.RefPONO5.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO5=null";
            if (this.RefPONO6.EditValue != null)
                queries[queries.Length - 1] += ",PONO6='" + this.RefPONO6.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO6=null";
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";

            if (this.AccountID.EditValue != null)
                queries[queries.Length - 1] += ",AccountID='" + this.AccountID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AccountID=null";

            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PRNO='" + CodeToUpdate + "'";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + vnum + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','E')";
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
                    this.SelectedPRNO.EditValue = vnum;
                   
                    this.RefPONO.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;

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
            queries[queries.Length - 1] = "delete from  ST_StoreDetails where PRNO='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from ST_StorePR where PRNO='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into AC_Voucher_Security (VNumber,VUser,VTime,Action) Values ('" + GRNtoUpdate + "','" + MachineEyes.Classes.Security.User.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "','D')";


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

       
     

        private void PRD_Add_Click(object sender, EventArgs e)
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

            
            SetButtonStates_PRD(UserInputMode.Add);
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
                    if (ItemAccountRow["StatusID"].ToString() != "") this.EntryStatusID.EditValue = ItemAccountRow["StatusID"].ToString();
                    else
                        this.EntryStatusID.EditValue = null;
                    this.PRDUOM.Text = ItemAccountRow["UOM"].ToString();
                    this.PODNumber.EditValue = ItemAccountRow["PODNO"].ToString();
                   
                    
                    if (ItemAccountRow["PRDNO"].ToString()!="")
                    {
                        this.PRDNO.EditValue = ItemAccountRow["PRDNO"].ToString();
                        if (DelMode == true)
                            SetButtonStates_PRD(UserInputMode.Delete);
                        else
                        SetButtonStates_PRD(UserInputMode.Edit);
                        this.PRDRate.EditValue = ItemAccountRow["PRDRATE"].ToString();
                        this.PRDQty.EditValue = ItemAccountRow["PRDQTY"].ToString();
                        this.PRDQty.BackColor = Color.White;
                        this.PRDRate.BackColor = Color.White;
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
                        this.PRDRate.EditValue = ItemAccountRow["PODRATE"].ToString();
                        this.PRDQty.EditValue = ItemAccountRow["PODQTY"].ToString();
                       
                            this.PRDQty.BackColor = Color.Yellow;
                            this.PRDRate.BackColor = Color.Yellow;
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
                   
                   
                   
                    
                    this.PODRATE.EditValue = ItemAccountRow["PODRATE"].ToString() == "" ? null : ItemAccountRow["PODRATE"].ToString();
                    this.PODNumber.EditValue = ItemAccountRow["PODNO"].ToString() == "" ? null : ItemAccountRow["PODNO"].ToString();
                    this.PODQTY.EditValue = ItemAccountRow["PODQTY"].ToString() == "" ? null : ItemAccountRow["PODQTY"].ToString();
                    this.PRDRemarks.EditValue = ItemAccountRow["Remarks"].ToString() == "" ? null : ItemAccountRow["Remarks"].ToString();
                    this.PRDDepartment.EditValue = ItemAccountRow["SubDepartmentID"].ToString() == "" ? null : ItemAccountRow["SubDepartmentID"].ToString();
                    this.PRDShedID.EditValue = ItemAccountRow["ShedID"].ToString() == "" ? null : ItemAccountRow["ShedID"].ToString();
                    this.PRDLoomNumber.Tag = ItemAccountRow["LoomID"].ToString() == "" ? null : ItemAccountRow["LoomID"].ToString();
                    this.PRDLoomNumber.EditValue = ItemAccountRow["LoomName"].ToString() == "" ? null : ItemAccountRow["LoomName"].ToString();
                    this.Condition.EditValue = ItemAccountRow["ConditionID"].ToString() == "" ? null : ItemAccountRow["ConditionID"].ToString();
                    this.MC.EditValue = ItemAccountRow["MC"].ToString() == "" ? null : ItemAccountRow["MC"].ToString();
                   
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
            SetButtonStates_PRD(UserInputMode.Edit);
        }

        private void PRD_Delete_Click(object sender, EventArgs e)
        {
            if (this.PODNumber.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_PRD(UserInputMode.Delete);
        }

      

       

       

    
   





        private void PODGridView_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode ==Keys.Delete)
            SelectPRDRecord(true);
        }

      

        private void EntryStatusID_EditValueChanged(object sender, EventArgs e)
        {
            if (EntryStatusID.EditValue == null)
                this.EntryStatusName.EditValue = "STATUS UNKNOWN";
            else
            {
            }
        }

        private void PR_Print_Click(object sender, EventArgs e)
        {
            if (this.PR_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PR #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MachineEyes.Classes.Printing.Print_ST_PR(this.PR_Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
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
                if (this.AccountID.EditValue!= null)
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

       


    }
}