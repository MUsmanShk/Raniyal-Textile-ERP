using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Production
{
    public partial class List_Production_Inwards : DevExpress.XtraEditors.XtraForm
    {
       
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        string TotalProductionInward;
        public decimal ProductionInwardId;
        public decimal ProductionInwardEntry;
        public List_Production_Inwards()
        {
            InitializeComponent();
            dataGridViewProductInward.AllowUserToAddRows = false;
           
        }
        private void SetButtonStates(UserInputMode input)
        {
        }

        private void Add_Click(object sender, EventArgs e)
        {
            SaleContract.Text =
            txtArticle.Text =
            txtGradeA.Text =
            txtGradeB.Text =
            txtGradeC40up.Text =
            txtGradeC10up.Text =
            txtGradeC1to9.Text =
            txtRWork.Text = "";
            dataGridViewProductInward.DataSource = null;
        }
     
        private void Execute_Click(object sender, EventArgs e)
        {
            //if (uiMode == UserInputMode.Add)
            //{
            //    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
            //    if (canProceed == false)
            //    {
            //        XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //   SaveNew();
            //}
            //else if (uiMode == UserInputMode.Edit)
            //{
            //    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
            //    if (canProceed == false)
            //    {
            //        XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //    //UpdateExisting();
            //}
            //else if (uiMode == UserInputMode.Delete)
            //{
            //    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
            //    if (canProceed == false)
            //    {
            //        XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //    //DeleteExisting();
            //} 
            // RemainingWeavig = );
            //if (Convert.ToDecimal(txtRemaingWeaving.Text = string.IsNullOrEmpty(txtRemaingWeaving.Text)?"0": txtRemaingWeaving.Text)<
            //    (Convert.ToDecimal(txtGradeA.Text = string.IsNullOrEmpty(txtGradeA.Text) ? "0" : txtGradeA.Text)+
            //    Convert.ToDecimal(txtGradeB.Text = string.IsNullOrEmpty(txtGradeB.Text)?"0": txtGradeB.Text)+
            //    Convert.ToDecimal(txtGradeC40up.Text = string.IsNullOrEmpty(txtGradeC40up.Text)?"0": txtGradeC40up.Text)+
            //    Convert.ToDecimal(txtGradeC10up.Text = string.IsNullOrEmpty(txtGradeC10up.Text)?"0": txtGradeC10up.Text)+
            //    Convert.ToDecimal(txtGradeC1to9.Text = string.IsNullOrEmpty(txtGradeC1to9.Text)?"0": txtGradeC1to9.Text)+
            //    Convert.ToDecimal(txtRWork.Text = string.IsNullOrEmpty(txtRWork.Text)?"0": txtRWork.Text)))
                
            //{          
            //    XtraMessageBox.Show("Entered more than Remaining Weaving", "Error");
            //    return;
            //}
            //else
            //{
            if (ProductionInwardEntry >= (Convert.ToDecimal(txtGradeA.Text = string.IsNullOrEmpty(txtGradeA.Text) ? "0" : txtGradeA.Text) +
                Convert.ToDecimal(txtGradeB.Text = string.IsNullOrEmpty(txtGradeB.Text) ? "0" : txtGradeB.Text) +
                Convert.ToDecimal(txtGradeC40up.Text = string.IsNullOrEmpty(txtGradeC40up.Text) ? "0" : txtGradeC40up.Text) +
                Convert.ToDecimal(txtGradeC10up.Text = string.IsNullOrEmpty(txtGradeC10up.Text) ? "0" : txtGradeC10up.Text) +
                Convert.ToDecimal(txtGradeC1to9.Text = string.IsNullOrEmpty(txtGradeC1to9.Text) ? "0" : txtGradeC1to9.Text) +
                Convert.ToDecimal(txtRWork.Text = string.IsNullOrEmpty(txtRWork.Text) ? "0" : txtRWork.Text)))
            {
                SaveNew();
                GetDataView();
                cleantxt();
            }
            else 
            {
                XtraMessageBox.Show("Entered Proper Meters", "Error");
                return;
            }
               
        //    }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
        }
      
        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void cleantxt()
        {
            txtGradeA.Text =
                txtGradeB.Text =
                txtGradeC40up.Text =
                txtGradeC10up.Text =
                txtGradeC1to9.Text =
                txtRWork.Text = "";

        }
        private void SaveNew()
        {
            string queries = string.Empty;
            queries = "UPDATE FC_PO_Production_Inward " +
                      " SET Grade_A = '" + txtGradeA.Text + "', " +
                      "  Grade_B = '" + txtGradeB.Text + "', " +
                      "  Grade_C_40Up = '" + txtGradeC40up.Text + "', " +
                      "  Grade_C_10UP = '" + txtGradeC10up.Text + "',  " +
                      "  Grade_C_1to9 = '" + txtGradeC1to9.Text + "',  " +
                      "  R_Work = '" + txtRWork.Text + "',  " +
                      "  eUserID ='" + MachineEyes.Classes.Security.User.SCodes.UserID + "'," +
                      "  eUserTime = '" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "' " +
                      "  WHERE ID  = "+ProductionInwardId+" ";
       
            try 
            {
                string tResult = WS.svc.Execute_Query(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    XtraMessageBox.Show(tResult, "Succesfully saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    //SetButtonStates(UserInputMode.View);
                    //this.Add.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void UpdateExisting()
        {


            
        }


     
        private void TotalSizedBeams_EditValueChanged(object sender, EventArgs e)
        {
            //int totalbeams = 0;
            //int.TryParse(txtPartyName.EditValue.ToString(), out totalbeams);
        }
            
        private void Print_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag == null)
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid document.... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            MachineEyes.Classes.Printing.Print_SW_SizingSheetSelf(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void panelControl_OutSideSizing_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Remarks_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void txtSaleContract_EditValueChanged(object sender, EventArgs e)
        {

        }

        
        //private void checkParty_CheckedChanged(object sender, EventArgs e)
        //{
        //        try 
        //    {
        //        if (txtSaleContract.Text != null)
        //        {
        //            string query;
        //            DataSet ds = new DataSet();
        //            query = "select  M.PONumber,Y.PONO,Ac.AccountName,a.ArticleName , D.SubDepartment " +
        //                            "from[dbo] .[FC_PO_YarnRequired] Y " +
        //                            "inner join " +
        //                            "[dbo].[FC_PO_Main]M on Y.PONO = M.PONumber " +
        //                            "inner join [dbo].[PP_Article] A " +
        //                            "on A.ArticleNumber = y.ArticleNumber " +
        //                            "inner join [dbo].[PP_Accounts] Ac " +
        //                            "on M.BuyerID = Ac.AccountID " +
        //                            "inner join [dbo].[PP_DepartmentsSub]D " +
        //                            "on D.SubDepartmentID = M.DeptID " +
        //                            "where M.PONumber = '" + txtSaleContract.Text + "'";
        //            ds = WS.svc.Get_DataSet(query);
        //            DataTable dt = new DataTable();
        //            dt = ds.Tables[0];
        //            if (dt.Rows.Count < 1)
        //            {
        //                MessageBox.Show("No Record found against this SaleContract No");
        //            }
        //            else
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    txtArcitleQuality.Text = row["ArticleName"].ToString();
        //                    txtPartyName.Text = row["AccountName"].ToString();
        //                    txtDept.Text = row["SubDepartment"].ToString();
        //                }
        //            }
        //            FillCombos fc = new FillCombos();
        //            fc.Loom_Name(ref this.Loom,txtArcitleQuality.Text);
                    
                    
        //        }
        //        else
        //        {
        //            MessageBox.Show("Enter SaleContract No");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
   
        //}

        private void txtGradeA_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SaleContract_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.ShiftKey || e.Control == false)
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                ProductionInwardList sRow = new ProductionInwardList();
                Data.Data_Production_Inward_List AView = new Data.Data_Production_Inward_List();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.SaleContract.Text = sRow.PONumber;
                        GetDataView();
                       
                    }
                }
                else if (e.KeyCode == Keys.Delete && e.Control == true)
                {
                    this.SaleContract.Text = "";
                }

            }
        }

        private void GetDataView()
        {
            DataSet ds = new DataSet();
            string query = "select I.ID,I.PONumber, A.ArticleShortName,I.Grade_A,I.Grade_B,I.Grade_C_40Up, " +
                           " I.Grade_C_10UP,I.Grade_C_1to9,I.R_Work  "+
                           " from FC_PO_Production_Inward I  "+
                           " left join FC_PO_Production_Dispatched D "+
                           " on I.ID = D.FC_PO_Production_Inward_Id "+
                           "inner join PP_Article A "+
                            "on I.ArticleNumber = A.ArticleNumber"+
                           " where PONumber ='" + this.SaleContract.Text + "' " +
                           " and D.FC_PO_Production_Inward_Id is null";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0].Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        this.dataGridViewProductInward.DataSource = dt;
                    }
                }
            }
        }
        private void dataGridViewProductInward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void dataGridViewProductInward_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedrowindex = dataGridViewProductInward.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridViewProductInward.Rows[selectedrowindex];
            try
            {
                //if (Convert.ToDecimal(selectedRow.Cells["R_Work"].Value.ToString()) > 0)
                //{
                ProductionInwardId = Convert.ToDecimal(selectedRow.Cells["Id"].Value.ToString());
                txtArticle.Text = selectedRow.Cells["ArticleShortName"].Value.ToString();
                txtGradeA.Text = selectedRow.Cells["Grade_A"].Value.ToString();
                txtGradeB.Text = selectedRow.Cells["Grade_B"].Value.ToString();
                txtGradeC40up.Text = selectedRow.Cells["Grade_C_40Up"].Value.ToString();
                txtGradeC10up.Text = selectedRow.Cells["Grade_C_10UP"].Value.ToString();
                txtGradeC1to9.Text = selectedRow.Cells["Grade_C_1to9"].Value.ToString();
                txtRWork.Text = selectedRow.Cells["R_Work"].Value.ToString();
                ProductionInwardEntry = Convert.ToDecimal(selectedRow.Cells["Grade_A"].Value.ToString()) +
                    Convert.ToDecimal(selectedRow.Cells["Grade_B"].Value.ToString()) +
                    Convert.ToDecimal(selectedRow.Cells["Grade_C_40Up"].Value.ToString()) +
                    Convert.ToDecimal(selectedRow.Cells["Grade_C_10UP"].Value.ToString()) +
                    Convert.ToDecimal(selectedRow.Cells["Grade_C_1to9"].Value.ToString()) +
                    Convert.ToDecimal(selectedRow.Cells["R_Work"].Value.ToString());
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Not Editable", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

        }

      
        
        
       

    }
}