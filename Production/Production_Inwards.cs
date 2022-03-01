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
    public partial class Production_Inwards : DevExpress.XtraEditors.XtraForm
    {
       
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        string TotalProductionInward;
        public Production_Inwards()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.LoomTypes(ref this.Salvedge);
            fc.ArticleQuantity(ref this.ArcitleQuality);
           
        }
        private void SetButtonStates(UserInputMode input)
        {
        }

        private void Add_Click(object sender, EventArgs e)
        {
            claeanAllTxt();
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
            if (txtPOQtyMeter.Text == "0.00")
            {
                SaveNew();
                cleantxt();
                return;
            }
            if (Convert.ToDecimal(txtRemaingWeaving.Text = string.IsNullOrEmpty(txtRemaingWeaving.Text)?"0": txtRemaingWeaving.Text)<
                (Convert.ToDecimal(txtGradeA.Text = string.IsNullOrEmpty(txtGradeA.Text) ? "0" : txtGradeA.Text)+
                Convert.ToDecimal(txtGradeB.Text = string.IsNullOrEmpty(txtGradeB.Text)?"0": txtGradeB.Text)+
                Convert.ToDecimal(txtGradeC40up.Text = string.IsNullOrEmpty(txtGradeC40up.Text)?"0": txtGradeC40up.Text)+
                Convert.ToDecimal(txtGradeC10up.Text = string.IsNullOrEmpty(txtGradeC10up.Text)?"0": txtGradeC10up.Text)+
                Convert.ToDecimal(txtGradeC1to9.Text = string.IsNullOrEmpty(txtGradeC1to9.Text)?"0": txtGradeC1to9.Text)+
                Convert.ToDecimal(txtRWork.Text = string.IsNullOrEmpty(txtRWork.Text)?"0": txtRWork.Text)))
                
            {          
                XtraMessageBox.Show("Entered more than Remaining Weaving", "Error");
                return;
            }
            else
            {
                SaveNew();
                cleantxt();

            }
        }

        private void cleantxt()
        {
            txtGradeA.Text =
                txtGradeB.Text =
                txtGradeC40up.Text =
                txtGradeC10up.Text =
                txtGradeC1to9.Text =
                txtRWork.Text = ""; 
            FillCombos fc = new FillCombos();
            fc.LoomTypes(ref this.Salvedge);
            fc.ArticleQuantity(ref this.ArcitleQuality);
            fc.Loom_Name(ref this.Loom, this.ArcitleQuality.Text);

        }

        private void claeanAllTxt()
        {
            SaleContract.Text=
               txtPartyName.Text=
               txtDept.Text= 
               txtPOQtyMeter.Text=
               txtRemaingWeaving.Text=
               ProductionDate.Text=
               
            txtGradeA.Text =
              txtGradeB.Text =
              txtGradeC40up.Text =
              txtGradeC10up.Text =
              txtGradeC1to9.Text =
              txtRWork.Text = "";
            FillCombos fc = new FillCombos();
            fc.LoomTypes(ref this.Salvedge);
            fc.ArticleQuantity(ref this.ArcitleQuality);
            fc.Loom_Name(ref this.Loom, this.ArcitleQuality.Text);
        }

        private void Edit_Click(object sender, EventArgs e)
        {}
      
        private void Delete_Click(object sender, EventArgs e)
    
        {
        }
        private void SaveNew()
        {
            if (this.SaleContract.Text == "")
            {
                XtraMessageBox.Show("Enter SaleContract name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ProductionDate.Text == "")
            {
                XtraMessageBox.Show("Enter Production Date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Loom.EditValue == null)
            {
                XtraMessageBox.Show("invalid Loom", "Error");
                return;
            }
            if (Salvedge.EditValue == null)
            {
                XtraMessageBox.Show("invalid Salvedge", "Error");
                return;
            }
            if (ArcitleQuality.Text == "NO_ARTICLE")
            {
                XtraMessageBox.Show("invalid Article Quality", "Error");
                return;
            }
            
            string queries = "insert into FC_PO_Production_Inward (PONumber,ArticleNumber,ProductionDate,Loom_Id,IGN_SalvedgeN_Id,Grade_A," +
            "Grade_B,Grade_C_40Up,Grade_C_10UP,Grade_C_1to9,R_Work,cUserID ,cUserTime) Values ('" + SaleContract.Text + "'"+
            ",'"+this.ArcitleQuality.EditValue.ToString()+"','" + ProductionDate.DateTime + "','" + this.Loom.EditValue.ToString() + "','" + this.Salvedge.EditValue.ToString() + "'," +
            "'" + (string.IsNullOrEmpty(txtGradeA.Text)?"0": txtGradeA.Text ).ToString()+ "', " +
            "'" + (string.IsNullOrEmpty(txtGradeB.Text) ? "0" : txtGradeB.Text).ToString() + "',"+
            "'" + (string.IsNullOrEmpty(txtGradeC40up.Text) ? "0" : txtGradeC40up.Text).ToString() + "'"+
            ",'" + (string.IsNullOrEmpty(txtGradeC10up.Text) ? "0" : txtGradeC10up.Text).ToString() + "',"+
            "'" + (string.IsNullOrEmpty(txtGradeC1to9.Text) ? "0" : txtGradeC1to9.Text).ToString() + "', " +
            "'" + (string.IsNullOrEmpty(txtRWork.Text) ? "0" : txtRWork.Text).ToString() + "'"+
            ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "'," +
            "'" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "')";
       
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
            int totalbeams = 0;
            int.TryParse(txtPartyName.EditValue.ToString(), out totalbeams);
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
                SelectRowSaleContract sRow = new SelectRowSaleContract();
                Data.Data_Sale_Contract_Detail AView = new Data.Data_Sale_Contract_Detail();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.SaleContract.Text = sRow.PONumber;
                       // this.txtArcitleQuality.Text = sRow.ArticleName;
                        this.ArcitleQuality.Text = sRow.ArticleName;
                        this.txtPartyName.Text = sRow.AccountName;
                        this.txtDept.Text = sRow.SubDepartment;
                        this.txtPOQtyMeter.Text = sRow.POQTYMtrs;
                        FillCombos fc = new FillCombos();
                        fc.Loom_Name(ref this.Loom, this.ArcitleQuality.Text);
                        DataSet ds = new DataSet();
                        string query = "select ISNULL(SUM(ISNULL(Grade_A,0)),0)+ISNULL(SUM(ISNULL(Grade_B,0)),0)"+
                         " +ISNULL(SUM(ISNULL(Grade_C_40Up,0)),0)+ISNULL(SUM(ISNULL(Grade_C_10UP,0)),0)+"+
                         " +ISNULL(SUM(ISNULL(Grade_C_1to9,0)),0)+ISNULL(SUM(ISNULL(R_Work,0)),0)as TotalProductionInward"+ 
                         " from FC_PO_Production_Inward where PONumber ='" + SaleContract.Text + "'";
                        ds = WS.svc.Get_DataSet(query);
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0].Copy();
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow row in dt.Rows)
                                {
                                    TotalProductionInward = row["TotalProductionInward"].ToString();
                                    decimal remainingWeaving = Convert.ToDecimal(txtPOQtyMeter.Text) - Convert.ToDecimal(TotalProductionInward);
                                    txtRemaingWeaving.Text = remainingWeaving.ToString();
                                }
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Control == true)
            {
                this.SaleContract.Text = "";
                //this.txtArcitleQuality.Text = "";
                this.txtPartyName.Text = "";
                this.txtDept.Text = "";
                this.txtRemaingWeaving.Text = "";
            }

        }

        private void CancelThis_Click(object sender, EventArgs e)
        {
            claeanAllTxt();
        }

        private void SaleContract_TextChanged(object sender, EventArgs e)
        {

        }

        
        
       

    }
}