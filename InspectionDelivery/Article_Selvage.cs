using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.InspectionDelivery
{
    public partial class Article_Selvage : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        public selectedrow sRow = new selectedrow();
        DataRow SelvageAccountRow;
        UserInputMode uiModeSelvage;
        int SelvageFocusedRowHandle;
        public Article_Selvage()
        {
            InitializeComponent();
        }
        private void SetButtonStates_Selvage(UserInputMode uim)
        {
            uiModeSelvage = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.Selvage_Execute.Enabled = false;
                    this.Selvage_Cancel.Enabled = false;
                    this.Selvage_Add.Enabled = true;




                    if (this.ArticleSelvageID.Tag != null)
                    {
                        if (this.ArticleSelvageID.Tag.ToString() != "")
                        {

                            this.Selvage_Edit.Enabled = true;
                            this.Selvage_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.Selvage_Edit.Enabled = false;
                            this.Selvage_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Selvage_Edit.Enabled = false;
                        Selvage_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    this.ArticleSelvageID.Tag = null;
                    this.Selvage_Add.Enabled = false;
                    this.Selvage_Cancel.Enabled = true;
                    Selvage_Execute.Enabled = true;
                    Selvage_Edit.Enabled = false;

                    Selvage_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Selvage_Add.Enabled = false;
                    Selvage_Cancel.Enabled = true;
                    Selvage_Execute.Enabled = true;
                    Selvage_Edit.Enabled = false;

                    Selvage_Delete.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Selvage_Add.Enabled = false;
                    Selvage_Cancel.Enabled = true;
                    Selvage_Execute.Enabled = true;
                    Selvage_Edit.Enabled = false;

                    Selvage_Delete.Enabled = false;


                    break;
                default:
                    break;
            }
        }
        private bool SelvageGetNextNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    if (this.PartyID.EditValue == null)
                    {
                        XtraMessageBox.Show("Invalid Party Selected!", "Error");
                        return false;
                    }
                    query = "select max(Convert(numeric(18),SubString(SelvageID,7,7)))+1 as MaxNumber  from PP_ArticlePartySelvages where PartyID='" + this.PartyID.EditValue.ToString() + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ArticleSelvageID.EditValue = null;
                        return false;
                    }
                    iNumber = this.PartyID.EditValue.ToString().PadLeft(6,'0') +  iNumber.PadLeft(7, '0');
                    this.ArticleSelvageID.EditValue =iNumber;
                    return true;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ArticleSelvageID.EditValue = null;
                    return false;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.ArticleSelvageID.EditValue = null;
                return false;
            }
        }
        private void SelvageSaveNew()
        {
            if (this.PartyID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party Account ID", "Error");
                return;
            }
            if (this.ArticleSelvageID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Account ID", "Error");
                return;
            }
           
            if (this.ArticleSelvageName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Name", "Error");
                return;
            }
            string[] queries = new string[0];
            string vnum = "";

            vnum = this.ArticleSelvageID.EditValue.ToString();




            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into PP_ArticlePartySelvages (iStatus,PartyID,SelvageID,SelvageName) Values (";
            queries[queries.Length - 1] += "'U','"+this.PartyID.EditValue.ToString()+"','" + this.ArticleSelvageID.EditValue.ToString() + "'";

            if (this.ArticleSelvageName.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ArticleSelvageName.EditValue + "'";
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
                   


                    DataView gdv = (DataView)this.gridView_Selvage.DataSource;
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["PartyID"] = this.PartyID.EditValue.ToString();
                    _ravi["SelvageID"] = this.ArticleSelvageID.EditValue.ToString();
                    if (this.ArticleSelvageName.EditValue != null)
                        _ravi["SelvageName"] = this.ArticleSelvageName.EditValue.ToString();
                    else
                        _ravi["SelvageName"] = "";

                    _ravi["iStatus"] = "U";
                    gdt.Rows.Add(_ravi);
                    //gdt.Merge(dt);
                    
                    this.ArticleSelvageName.EditValue = null; 
                    this.ArticleSelvageID.EditValue = null;
                   
                    SetButtonStates_Selvage(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void SelvageUpdateExisting()
        {
            if (this.PartyID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party Account ID", "Error");
                return;
            }
            if (this.ArticleSelvageID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Account ID", "Error");
                return;
            }
            if (this.ArticleSelvageName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Name", "Error");
                return;
            }


            string[] queries = new string[0];
           
            string CodeToUpdate = this.ArticleSelvageID.Tag.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update PP_ArticlePartySelvages set ";
            queries[queries.Length - 1] += "PartyID='" + this.PartyID.EditValue.ToString() + "', SelvageID='" + this.ArticleSelvageID.EditValue.ToString() + "' ";



            if (this.ArticleSelvageName.EditValue != null)
                queries[queries.Length - 1] += ",SelvageName='" + this.ArticleSelvageName.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SelvageName=null";

          
            queries[queries.Length - 1] += " where SelvageID='" + CodeToUpdate + "'";

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
                    SelvageAccountRow["SelvageID"] = this.ArticleSelvageID.EditValue.ToString();
                    SelvageAccountRow["PartyID"] = this.PartyID.EditValue.ToString();

                    if (this.ArticleSelvageName.EditValue != null)
                        SelvageAccountRow["SelvageName"] = this.ArticleSelvageName.EditValue.ToString();
                    else
                       SelvageAccountRow["SelvageName"] = "";
                  
                        SelvageAccountRow["iStatus"] = "U";


                        this.ArticleSelvageID.EditValue = null;
                        this.ArticleSelvageName.EditValue = null; 
                        
                   
                    SetButtonStates_Selvage(UserInputMode.View);

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void SelvageDeleteExisting()
        {



            if (this.PartyID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party Account ID", "Error");
                return;
            }
            if (this.ArticleSelvageID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Account ID", "Error");
                return;
            }
            if (this.ArticleSelvageName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Selvage Name", "Error");
                return;
            }

          


            string[] queries = new string[0];
            string GRNtoUpdate = this.ArticleSelvageID.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Selvage Account ID  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from PP_ArticlePartySelvages where SelvageID='" + GRNtoUpdate + "'";
           

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

                    this.ArticleSelvageID.EditValue = null;
                    this.ArticleSelvageName.EditValue = null;
                    gridView_Selvage.DeleteRow(SelvageFocusedRowHandle);
                    SetButtonStates_Selvage(UserInputMode.View);
                   
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void FillSelvageFromSelectedRow()
        {
            if (SelvageFocusedRowHandle != -1)
            {
                SelvageAccountRow = this.gridView_Selvage.GetDataRow(this.gridView_Selvage.FocusedRowHandle);
                if (SelvageAccountRow != null)
                {
                    this.ArticleSelvageID.EditValue = SelvageAccountRow["SelvageID"].ToString();
                    this.ArticleSelvageName.EditValue = SelvageAccountRow["SelvageName"].ToString();
                    this.DocumentStatus.EditValue = SelvageAccountRow["iStatus"].ToString();
                    SetButtonStates_Selvage(UserInputMode.View);
                }
            }
        }
        private void gridView_Selvage_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelvageFocusedRowHandle = this.gridView_Selvage.FocusedRowHandle;
            FillSelvageFromSelectedRow();
        }
        public void LoadList(string argpartyID, string argpartyName)
        {
            this.PartyID.EditValue = argpartyID;
            this.PartyName.EditValue = argpartyName;
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select SelvageID,SelvageName,PartyID,iStatus from PP_ArticlePartySelvages where PartyID='"+argpartyID+"' order by Convert(numeric(18,0),SelvageID)");

                this.gridControl_Selvage.DataSource = ds.Tables[0];
                if (ds != null)
                {
                    if (ds.Tables[0].Columns.Count > 0)
                    {
                        for (int x = 2; x < ds.Tables[0].Columns.Count; x++)
                        {
                            this.gridView_Selvage.Columns[x].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("LoadSelvages::" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView_Selvage_DoubleClick(object sender, EventArgs e)
        {
            if (SelvageFocusedRowHandle != -1)
            {
                if (SelvageAccountRow != null)
                {
                    sRow.SelectedDataRow = SelvageAccountRow;
                    sRow.PrimeryID = SelvageAccountRow["SelvageID"].ToString();
                    sRow.PrimaryString = SelvageAccountRow["SelvageName"].ToString();
                    sRow.Status = ParameterStatus.Selected;
                    this.Close();
                }
            }
        }

        private void gridView_Selvage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (SelvageFocusedRowHandle != -1)
                {
                    if (SelvageAccountRow != null)
                    {
                        sRow.SelectedDataRow = SelvageAccountRow;
                        sRow.PrimeryID = SelvageAccountRow["SelvageID"].ToString();
                        sRow.PrimaryString = SelvageAccountRow["SelvageName"].ToString();
                        sRow.Status = ParameterStatus.Selected;
                        this.Close();
                    }
                }
            }
        }

        private void Selvage_Add_Click(object sender, EventArgs e)
        {




            this.DocumentStatus.EditValue = "U";
            this.ArticleSelvageName.EditValue = null;
            this.ArticleSelvageID.EditValue = null;
            if(SelvageGetNextNumber()==true)
            SetButtonStates_Selvage(UserInputMode.Add);
        }

        private void Selvage_Edit_Click(object sender, EventArgs e)
        {
            if (this.ArticleSelvageID.Tag == null)
            {
                XtraMessageBox.Show("invalid selvage selected!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentStatus.EditValue == null)
            {
                XtraMessageBox.Show("invalid Document State!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (SelvageAccountRow == null)
            {
                XtraMessageBox.Show("invalid Selvage Row!", "Error", MessageBoxButtons.OK);
                    return;
          
            }
           // this.DocumentStatus.EditValue = "U";
           
            
                SetButtonStates_Selvage(UserInputMode.Edit);
        }

        private void Selvage_Delete_Click(object sender, EventArgs e)
        {
            if (this.ArticleSelvageID.Tag == null)
            {
                XtraMessageBox.Show("invalid selvage selected!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.DocumentStatus.EditValue == null)
            {
                XtraMessageBox.Show("invalid Document State!", "Error", MessageBoxButtons.OK);
                return;
            }
            // this.DocumentStatus.EditValue = "U";

            if (SelvageAccountRow == null)
            {
                XtraMessageBox.Show("invalid Selvage Row!", "Error", MessageBoxButtons.OK);
                return;

            }
            SetButtonStates_Selvage(UserInputMode.Delete);
        }

        private void Selvage_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates_Selvage(UserInputMode.View);
        }

        private void Selvage_Close_Click(object sender, EventArgs e)
        {
            sRow.Status = ParameterStatus.Cancelled;
            this.Close();
        }

        private void Selvage_Execute_Click(object sender, EventArgs e)
        {
            if (uiModeSelvage == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SelvageSaveNew();
            }
            else if (uiModeSelvage == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentStatus.EditValue.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                      return;
                }
                SelvageUpdateExisting();
            }
            else if (uiModeSelvage == UserInputMode.Delete)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentStatus.EditValue.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SelvageDeleteExisting();
            }
        }

        private void gridControl_Selvage_Click(object sender, EventArgs e)
        {

        }
    }
}