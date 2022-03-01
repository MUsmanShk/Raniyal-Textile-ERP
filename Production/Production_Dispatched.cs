using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace MachineEyes.Production
{
    public partial class Production_Dispatched : DevExpress.XtraEditors.XtraForm
    {
       
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        string strResult;
        string[] dbQueries;
        public string RemainingQty;
        public string TotalQty;

        public Production_Dispatched()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            dgDispatched.AllowUserToAddRows = false;
            //fc.LoomTypes(ref this.Salvedge);
        }
        private void SetButtonStates(UserInputMode input)
        {
        }

        private void Add_Click(object sender, EventArgs e)
        {
            cleanAlltxt();
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
            //    if (Convert.ToDecimal(txtAvailGradeA.Text = string.IsNullOrEmpty(txtAvailGradeA.Text) ? "0" : txtAvailGradeA.Text)<
            //        Convert.ToDecimal(txtGradeA.Text = string.IsNullOrEmpty(txtGradeA.Text) ? "0" : txtGradeA.Text))
            //{
            //    XtraMessageBox.Show("Entered more than A Grade Production", "Error");
            //    return;
            //}
            //if(Convert.ToDecimal(txtAvailGradeB.Text = string.IsNullOrEmpty(txtAvailGradeB.Text) ? "0" : txtAvailGradeB.Text)<
            //        Convert.ToDecimal(txtGradeB.Text = string.IsNullOrEmpty(txtGradeB.Text) ? "0" : txtGradeB.Text))
            //{
            //    XtraMessageBox.Show("Entered more than B Grade Production", "Error");
            //    return;
            //}
            //if (Convert.ToDecimal(txtAvailGradeC_40UP.Text = string.IsNullOrEmpty(txtAvailGradeC_40UP.Text) ? "0" : txtAvailGradeC_40UP.Text)<
            //        Convert.ToDecimal(txtGradeC40up.Text = string.IsNullOrEmpty(txtGradeC40up.Text) ? "0" : txtGradeC40up.Text))
            //{
            //    XtraMessageBox.Show("Entered more than C 40UP Grade Production", "Error");
            //    return;
            //}
            //if (Convert.ToDecimal(txtAvailGradeC_10UP.Text = string.IsNullOrEmpty(txtAvailGradeC_10UP.Text) ? "0" : txtAvailGradeC_10UP.Text)<
            //        Convert.ToDecimal(txtGradeC10up.Text = string.IsNullOrEmpty(txtGradeC10up.Text) ? "0" : txtGradeC10up.Text))
            //{
            //    XtraMessageBox.Show("Entered more than C 10UP Grade Production", "Error");
            //    return;
            //}
            //if (Convert.ToDecimal(txtAvailGradeC_1to9.Text = string.IsNullOrEmpty(txtAvailGradeC_1to9.Text) ? "0" : txtAvailGradeC_1to9.Text)<
            //        Convert.ToDecimal(txtGradeC1to9.Text = string.IsNullOrEmpty(txtGradeC1to9.Text) ? "0" : txtGradeC1to9.Text))
            //{
            //    XtraMessageBox.Show("Entered more than C 1 To 9 Grade Production", "Error");
            //    return;
            //}
            //else 
            //{
            SaveNew();
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {}

        private void cleanAlltxt()
        {
            txtGradeA.Text =
                txtGradeB.Text =
                txtGradeC40up.Text =
                txtGradeC10up.Text =
                txtGradeC1to9.Text =
                txtGatePass.Text =
                txtPackingList.Text = 
           SaleContract.Text = "";
        }

        private void cleantxt()
        {
            txtGradeA.Text =
                txtGradeB.Text =
                txtGradeC40up.Text =
                txtGradeC10up.Text =
                txtGradeC1to9.Text = 
                txtGatePass.Text =
                txtPackingList.Text = "";
        }
      
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
            if (this.DispatchedDate.Text == "")
            {
                XtraMessageBox.Show("Enter Production Date", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<ListProductionDispatched> production = new List<ListProductionDispatched>();
            foreach (DataGridViewRow items in dgDispatched.Rows)
            {
               // if ())
                if (!string.IsNullOrEmpty(items.Cells[8].Value.ToString() )
                    && Convert.ToBoolean(items.Cells[8].Value.ToString()) == true)
                {
                    production.Add(new ListProductionDispatched
                    {
                        Id = items.Cells[0].Value.ToString()
                    });

                }
            }
            //for (int i = 0; i < production.Count; i++)
            string[] queries = new string[production.Count];
            int i = -1;
            foreach(ListProductionDispatched objProd in production)
            {
                i += 1;
                queries[i] = ("insert into FC_PO_Production_Dispatched (DispatchedDate,GatePass,PackingList,FC_PO_Production_Inward_Id,cUserID " +
                 " ,cUserTime) Values ('" + DispatchedDate.DateTime + "','" + txtGatePass.Text +  "','" + txtPackingList.Text + "','" + objProd.Id + "', " +
                "'" +MachineEyes.Classes.Security.User.SCodes.UserID+ "', "+
                "'" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "')");
            }
            string tResult = WS.svc.Execute_Transaction(queries);
         

            //try 
            //{
            //     dbQueries = (string[])arrayList.ToArray(typeof(string));
            //    //strResult = SQLHelper.ExecuteNonQueryWithTransactionManagement(dbQueries, null);
            //    string tResult = WS.svc.Execute_Query(arrayList);
            if (tResult != "**SUCCESS##")
            {
                XtraMessageBox.Show(tResult, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //GetDataView();
                //cleantxt();
                return;
                
            }
            else
            {
                XtraMessageBox.Show(tResult, "Succesfully saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GetDataView();
                cleanAlltxt();
                cleantxt();
                return;
            }
         //   }
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }


        private void UpdateExisting()
        {


            
        }


     
        private void TotalSizedBeams_EditValueChanged(object sender, EventArgs e)
        {
            //int totalbeams = 0;
           // int.TryParse(txtAvailGradeB.EditValue.ToString(), out totalbeams);
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

       
        private void txtGradeA_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SaleContract_KeyDown(object sender, KeyEventArgs e)

        {
         if (e.KeyCode == Keys.Enter && e.Control == true)
         {
                SelectRowProductionInward sRow = new SelectRowProductionInward();
                Data.Data_Production_Inward_Detail AView = new Data.Data_Production_Inward_Detail();
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
            }
         else if (e.KeyCode == Keys.Delete && e.Control == true)
         {
             this.SaleContract.Text = "";
         }

        }

        private void GetDataView()
        {
            DataSet ds = new DataSet();
            string query =  "Select   I.ID	,I.Grade_A  As Grade_A, "+
                            "I.Grade_B  AS Grade_B,  "+
                            "I.Grade_C_40Up AS Grade_C_40up, "+  
                            "I.Grade_C_10UP AS Grade_C_10up,   "+
                            "I.Grade_C_1to9 AS Grade_C_1to9 , "+
                            "I.R_Work AS R_Work , isnull(Y.POQTYMTRS,'0.00')as POQTYMTRS " +
                            "FROM FC_PO_Production_Inward I "+ 
                            "LEFT JOIN FC_PO_Production_Dispatched D  "+
                            "ON D.FC_PO_Production_Inward_Id = I.ID  "+
                            "INNER JOIN [dbo].[FC_PO_Main]M  "+
                            "ON M.PONumber = I.PONumber "+
						    "INNER JOIN PP_Article P "+
						    "ON I.ArticleNumber = P.ArticleNumber "+
                            "INNER JOIN [dbo].[PP_Accounts] A  "+
                            "ON M.BuyerID = A.AccountID  "+
                            "inner join FC_PO_YarnRequired Y  "+
                            "on Y.PONO = I.PONumber  "+
						    "where I.R_Work = 0 and D.FC_PO_Production_Inward_Id IS NULL "+
						    "and  I.PONumber='" + this.SaleContract.Text + "'";
            ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0].Copy();
                DataTable dtFinal = dt.Copy();
                dtFinal.Columns.Add("Dispatched", typeof(Boolean));
                this.dgDispatched.DataSource = dtFinal;
                dgDispatched.Columns["POQTYMTRS"].Visible = false;
                foreach (DataRow row in dt.Rows)
                {
                    TotalQty = row ["POQTYMTRS"].ToString();
                }
                // dgDispatched.Rows[7].Visible = false;
                ds = new DataSet();
                query = "select (ISNULL(SUM(ISNULL(I.Grade_A,0)),0)+ISNULL(SUM(ISNULL(I.Grade_B,0)),0)+ "+
                        "ISNULL(SUM(ISNULL(I.Grade_C_40Up,0)),0)+ISNULL(SUM(ISNULL(I.Grade_C_10UP,0)),0)+ "+
                        "+ISNULL(SUM(ISNULL(I.Grade_C_1to9,0)),0)+ISNULL(SUM(ISNULL(I.R_Work,0)),0)) "+
                        "as TotalProductionInward  "+
                        "from FC_PO_Production_Inward I "+
                        "INNER JOIN FC_PO_Production_Dispatched D "+
                        "ON I.ID = D.FC_PO_Production_Inward_Id "+
                        "  where I.PONumber = '" + this.SaleContract.Text + "'";
                ds = WS.svc.Get_DataSet(query);
                dt = new DataTable();
                dt = ds.Tables[0].Copy();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        RemainingQty = row["TotalProductionInward"].ToString();
                        txtBalance.Text = (Convert.ToDecimal(TotalQty) - Convert.ToDecimal(RemainingQty)).ToString();
                    }
                }
                //if (dt.Rows.Count > 0)
                //{
                    
                    //foreach (DataRow row in dt.Rows)
                    //{
                    //    this.dgDispatched.DataSource = null;

                    //    if(dgDispatched.Columns.Contains("Dispatched") && dgDispatched.Columns["Dispatched"].Visible)
                    //    {
                    //        dgDispatched.Columns.Remove("Dispatched");
                    //        //dtFinal.Rows.Add(row);
                    //    }
                    //    DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                    //    this.dgDispatched.DataSource = dt;
                    //    dgDispatched.Columns.Add(col);
                    //    col.HeaderText = "Dispatched";
                    //    col.Name = "Dispatched";
                       

                    //}
                   
               // }
            }
        }
        private void txtAvailGradeA_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGradeB_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtGradeC10up_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Production_Dispatched_Load(object sender, EventArgs e)
        {

        }


        private void dgDispatched_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string GradeA = "0";
            string GradeB = "0";
            string GradeC40up = "0";
            string GradeC10up = "0";
            string GradeC1to9up = "0";
            string GatePass = "";
            //string PackingList = "0";
            if (e.ColumnIndex == 8)//set your checkbox column index instead of 2
            {
                //if (Convert.ToBoolean(dgDispatched.Rows[e.RowIndex].Cells[7].EditedFormattedValue) == true)
                //{
                    this.dgDispatched.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    
                    foreach (DataGridViewRow items in dgDispatched.Rows)
                    {
                        if (!string.IsNullOrEmpty(items.Cells[8].Value.ToString())
                                  && Convert.ToBoolean(items.Cells[8].Value.ToString()) == true)
                        {
                            GradeA = Convert.ToString(Convert.ToDecimal(GradeA) + Convert.ToDecimal(items.Cells[1].Value.ToString()));
                            GradeB = Convert.ToString(Convert.ToDecimal(GradeB) + Convert.ToDecimal(items.Cells[2].Value.ToString()));
                            GradeC40up = Convert.ToString(Convert.ToDecimal(GradeC40up) + Convert.ToDecimal(items.Cells[3].Value.ToString()));
                            GradeC10up = Convert.ToString(Convert.ToDecimal(GradeC10up) + Convert.ToDecimal(items.Cells[4].Value.ToString()));
                            GradeC1to9up = Convert.ToString(Convert.ToDecimal(GradeC1to9up) + Convert.ToDecimal(items.Cells[5].Value.ToString()));
                            GatePass =  "RAN - " + DateTime.Now.ToShortDateString();
                            //PackingList = Convert.ToString(Convert.ToDecimal(PackingList) + Convert.ToDecimal(items.Cells[7].Value.ToString()));

                        }
                    }

                    txtGradeA.Text = GradeA.ToString();
                    txtGradeB.Text = GradeB.ToString();
                    txtGradeC40up.Text = GradeC40up.ToString();
                    txtGradeC10up.Text = GradeC10up.ToString();
                    txtGradeC1to9.Text = GradeC1to9up.ToString();
                    txtGatePass.Text = GatePass;
               // }
            }
        }

        private void View_Click(object sender, EventArgs e)
        {

        }

        private void CancelThis_Click(object sender, EventArgs e)
        {
            cleanAlltxt();
            cleantxt();
        }

     
       

    }
}