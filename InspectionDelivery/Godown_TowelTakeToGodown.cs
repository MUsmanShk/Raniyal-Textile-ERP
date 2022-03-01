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
    public partial class Godown_TowelTakeToGodown : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModePO;
        UserInputMode uiModePOD;
        private string G_Invoice;
        private string N_Invoice;
        DataRow ItemAccountRow;
        int ItemFocusedRowHandle;
        public Godown_TowelTakeToGodown()
        {
            InitializeComponent();
           
            G_Invoice = "055";
            N_Invoice = "056";
            this.Prefix.Text = G_Invoice;
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;
            FillCombos fc = new FillCombos();
          
        }
        private void ProcessWeightPerPiece()
        {
            int Piece = 0; int TotalPieces = 0; double Weight = 0;
            if (this.Pieces_A.EditValue != null)
            {
                int.TryParse(this.Pieces_A.EditValue.ToString(), out Piece);
                TotalPieces += Piece;
            }
            if (this.Pieces_B.EditValue != null)
            {
                int.TryParse(this.Pieces_B.EditValue.ToString(), out Piece);
                TotalPieces += Piece;
            }
            if (this.Pieces_C.EditValue != null)
            {
                int.TryParse(this.Pieces_C.EditValue.ToString(), out Piece);
                TotalPieces += Piece;
            }
            if (this.Pieces_SP.EditValue != null)
            {
                int.TryParse(this.Pieces_SP.EditValue.ToString(), out Piece);
                TotalPieces += Piece;
            }
            if (this.Pieces_CP.EditValue != null)
            {
                int.TryParse(this.Pieces_CP.EditValue.ToString(), out Piece);
                TotalPieces += Piece;
            }
            this.Pieces_Total.EditValue = TotalPieces.ToString();
            if (this.Weight_Kg.EditValue != null)
            {
                double.TryParse(this.Weight_Kg.EditValue.ToString(), out Weight);
                if (TotalPieces > 0)
                {
                    double WPP = Weight / TotalPieces * 1000;
                    this.WeightPerPiece.EditValue = WPP.ToString("#,##0.00");
                    double WPPA = 0;
                    if (this.WeightPerPiecePerArticle.EditValue != null)
                    {
                        double.TryParse(this.WeightPerPiecePerArticle.EditValue.ToString(), out WPPA);
                    }
                    double ExcessShortage = 0;
                    ExcessShortage = WPP - WPPA;
                    this.WeightExcessShortage.EditValue = ExcessShortage.ToString("#,##0.00;(#,##0.00)");
                    this.WeightLbs.EditValue = Weight * 2.2046;
                    WPP = Weight * 2.2046 / TotalPieces;
                    this.LbsPerPiece.EditValue = WPP.ToString("#,##0.00");

                }
                else
                    ClearWeightProcess();
            }
            else
            {
                ClearWeightProcess();
            }
        }
        private void ClearWeightProcess()
        {
            this.WeightExcessShortage.EditValue = null;

            this.WeightLbs.EditValue = null;
            this.WeightPerPiece.EditValue = null;
            this.LbsPerPiece.EditValue = null;

        }
       
        private void PODUpdateExisting()
        {
            
            if (this.GDRNO.EditValue == null)
            {
                XtraMessageBox.Show("invalid POD # ", "Error");
                return;
            }
            if (this.ArticleNumber.EditValue == null)
            {
                XtraMessageBox.Show("Article Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

           

            if (this.ArticleNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Article #", "Error");
                return;
            }
            if (this.ArticleShortName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Article #", "Error");
                this.ArticleNumber.Focus();
                return;
            }
            if (this.RefGodownEntryCode.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Entry Code #", "Error");
                this.RefGodownEntryCode.Focus();
                return;
            }
            if (this.PartyName.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party #", "Error");
                this.PartyID.Focus();
                return;
            }
            if (this.PartyID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party #", "Error");
                this.PartyID.Focus();
                return;

            }
            if (this.PONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PO #", "Error");
                return;
            }
            if (this.GDRNO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid GDR #", "Error");
                return;
            }

            string[] queries = new string[0];
            
            string CodeToUpdate = this.GDRNO.EditValue.ToString();



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "Update IP_Godown_Towel_Details set ";
           


            if (Departments.Towel_Godown != "")
                queries[queries.Length - 1] += "DepartmentID='" + Departments.Towel_Godown + "'";
            else
                queries[queries.Length - 1] += "DepartmentID=null";
            if (this.Shed.EditValue != null)
                queries[queries.Length - 1] += ",ShedID=" + this.Shed.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",ShedID=null";
            if (this.LoomNumber.Tag != null)
                queries[queries.Length - 1] += ",LoomID=" + this.LoomNumber.Tag.ToString() + "";
            else
                queries[queries.Length - 1] += ",LoomID=null";
            if (this.LoomNumber.EditValue != null)
                queries[queries.Length - 1] += ",LoomName='" + this.LoomNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",LoomName=null";
            if (this.PONO.EditValue != null)
                queries[queries.Length - 1] += ",PONO='" + this.PONO.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PONO=null";
            if (this.ArticleNumber.EditValue != null)
                queries[queries.Length - 1] += ",ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ArticleNumber=null";
            if (this.SetNo.EditValue != null)
                queries[queries.Length - 1] += ",SetNo='" + this.SetNo.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SetNo=null";
            if (this.BeamNumber.EditValue != null)
                queries[queries.Length - 1] += ",BeamNo='" + this.BeamNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",BeamNo=null";
            
            if (this.RollThanNumber.EditValue != null)
                queries[queries.Length - 1] += ",RollNo='" + this.RollThanNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",RollNo=null";
            if (this.Code.EditValue != null)
                queries[queries.Length - 1] += ",Code='" + this.Code.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Code=null";
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
            if (this.Pieces_A.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_A=" + this.Pieces_A.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_A=0";
            if (this.Pieces_B.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_B=" + this.Pieces_B.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_B=0";
            if (this.Pieces_C.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_C=" + this.Pieces_C.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_C=0";
            if (this.Pieces_SP.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_SP=" + this.Pieces_SP.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_SP=0";
            if (this.Pieces_CP.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_CP=" + this.Pieces_CP.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_CP=0";
            if (this.Pieces_Total.EditValue != null)
                queries[queries.Length - 1] += ",Inward_P_T=" + this.Pieces_Total.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_P_T=0";
            if (this.Weight_Kg.EditValue != null)
                queries[queries.Length - 1] += ",Inward_Kg=" + this.Weight_Kg.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_Kg=0";
            if (this.WeightLbs.EditValue != null)
                queries[queries.Length - 1] += ",Inward_Lbs=" + this.WeightLbs.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_Lbs=0";
            if (this.WeightPerPiece.EditValue != null)
                queries[queries.Length - 1] += ",Inward_WPP=" + this.WeightPerPiece.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Inward_WPP=0";
            queries[queries.Length - 1] += " where GDRNO='" + CodeToUpdate + "'";

            
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
                    _ravi["ArticleNumber"] = this.ArticleNumber.EditValue.ToString();
                    if (this.ArticleShortName.EditValue != null) _ravi["ArticleShortName"] = this.ArticleShortName.EditValue.ToString();
                    _ravi["PONO"] = this.PONO.EditValue.ToString();
                    if (this.PartyID.EditValue != null) _ravi["BuyerID"] = this.PartyID.EditValue.ToString();
                    _ravi["GDRNO"] = this.GDRNO.EditValue.ToString();
                    _ravi["GodownEntryCode"] = this.RefGodownEntryCode.EditValue.ToString();
                    if (this.Pieces_A.EditValue != null) _ravi["Inward_P_A"] = this.Pieces_A.EditValue.ToString();
                    if (this.Pieces_B.EditValue != null) _ravi["Inward_P_B"] = this.Pieces_B.EditValue.ToString();
                    if (this.Pieces_C.EditValue != null) _ravi["Inward_P_C"] = this.Pieces_C.EditValue.ToString();
                    if (this.Pieces_SP.EditValue != null) _ravi["Inward_P_SP"] = this.Pieces_SP.EditValue.ToString();
                    if (this.Pieces_CP.EditValue != null) _ravi["Inward_P_CP"] = this.Pieces_CP.EditValue.ToString();
                    if (this.Weight_Kg.EditValue != null) _ravi["Inward_Kg"] = this.Weight_Kg.EditValue.ToString();
                    if (this.Shed.EditValue != null) _ravi["ShedID"] = this.Shed.EditValue.ToString();
                    if (this.LoomNumber.Tag != null) _ravi["LoomID"] = this.LoomNumber.Tag.ToString();
                    if (this.LoomNumber.EditValue != null) _ravi["LoomName"] = this.LoomNumber.EditValue.ToString();
                    if (this.PartyID.EditValue != null) _ravi["BuyerID"] = this.PartyID.EditValue.ToString();
                    if (this.PODRemarks.EditValue != null) _ravi["Remarks"] = this.PODRemarks.EditValue.ToString();
                  
                    if (this.RollThanNumber.EditValue != null) _ravi["RollNo"] = this.RollThanNumber.EditValue.ToString();
                    if (this.Code.EditValue != null) _ravi["Code"] = this.Code.EditValue.ToString();
                                     
                    SetButtonStates_POD(UserInputMode.View);
                    this.GDRNO.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.ArticleNumber.EditValue = null;

                  
                   

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void PODDeleteExisting()
        {





          
            if (this.GDRNO.EditValue == null)
            {
                XtraMessageBox.Show("POD ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }


            string[] queries = new string[0];
            string GRNtoUpdate = this.GDRNO.EditValue.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Item POD # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from IP_Godown_Towel_Details where GDRNO='" + GRNtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update IP_Godown_Towel_Details set Shifted=0,Taken=0,State=0,REFGDRNO=null where REFGDRNO='" + GRNtoUpdate + "'";
         

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


                    this.gridView_TakenToGodown.DeleteRow(ItemFocusedRowHandle);
                    this.GDRNO.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.ArticleNumber.EditValue = null;
                    SetButtonStates_POD(UserInputMode.View);
                    
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
                    



                    if (this.GDRNO.EditValue != null)
                    {
                       
                           

                                this.POD_Edit.Enabled = true;
                                this.POD_Delete.Enabled = true;
                                return;
                          
                        
                    }
                    else
                    {
                        POD_Edit.Enabled = false;
                        POD_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    
                   
                    this.POD_Cancel.Enabled = true;
                    POD_Execute.Enabled = true;
                    POD_Edit.Enabled = false;

                    POD_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                   
                    POD_Cancel.Enabled = true;
                    POD_Execute.Enabled = true;
                    POD_Edit.Enabled = false;

                    POD_Delete.Enabled = false;


                    break;
                case UserInputMode.Delete:
                   
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
                    query = "select max(Convert(numeric(18),SubString(GodownEntryCode,8,6)))+1 as MaxNumber  from IP_Godown_Towel where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0' and GodownEntryTypeID='2'";
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
        private string  PODGetNextNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {

                    query = "select max(Convert(numeric(18),SubString(GDRNO,14,7)))+1 as MaxNumber  from IP_Godown_Towel_Details where GodownEntryCode='" + this.RefGodownEntryCode.EditValue.ToString() + "'";
                    iNumber = WS.svc.Get_MaxNumber(query);
                    if (iNumber.Length > 7)
                    {
                        XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return "";
                    }
                    iNumber = iNumber.PadLeft(7, '0');
                    this.GDRNO.EditValue= this.RefGodownEntryCode.EditValue.ToString() +  iNumber;
                    return this.RefGodownEntryCode.EditValue.ToString() + iNumber;
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.GDRNO.EditValue = null;
                    return "";
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.Suffix.Text = "";
                return "";
            }
        }
       
        private void gotoPOTab()
        {
            this.xtraTabPage_Main.PageEnabled = true;
            this.xtraTabPage_Details.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Main;
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

            if (this.FinancialYear.Text != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            queries[queries.Length - 1] = "insert into IP_Godown_Towel (NumberType,GodownEntryTypeID,GodownEntryCode,iType,iCat,iYear,iStatus,Dated,Remarks,CUserID,CUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.iCodeType.EditValue.ToString() + "',2,'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            

            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
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
                    
                    this.PO_Print.Tag = vnum;
                    this.RefGodownEntryCode.EditValue = vnum;
                    this.Remarks.EditValue = null;
                    this.Suffix.EditValue = null;
                    this.Suffix.Tag = null;
                    SetButtonStates(UserInputMode.View);
                    if (this.PO_Print.Tag == null) return;
                    if (this.RefGodownEntryCode.EditValue == null) return;
                    this.xtraTabPage_Main.PageEnabled = false;
                    this.xtraTabPage_Details.PageEnabled = false;
                    this.xtraTabPage_Filter.PageEnabled = true;
                    this.xtraTabPage_Selection.PageEnabled = false;
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Filter;
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
            if (this.FinancialYear.Tag.ToString() != MachineEyes.Classes.Accounting.RegAccounts.FinancialYear)
            {
                XtraMessageBox.Show("invalid Financial Year ...Current selected financial year does not match with input financial year", "Year Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            queries[queries.Length - 1] = "update IP_Godown_Towel set ";
            queries[queries.Length - 1] += " NumberType='" + this.iCodeType.EditValue.ToString() + "',GodownEntryCode='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "',iStatus='U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";

         
          
           
            if (this.Remarks.EditValue != null)
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";
          

            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where GodownEntryCode='" + CodeToUpdate + "'";

          
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
            
                    this.Remarks.EditValue = null;
                    
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
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Godown Entry Code  # " + GRNtoUpdate + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  IP_Godown_Towel_Details where GodownEntryCode='" + GRNtoUpdate + "' and State=0 and Taken=0 and Shifted=0";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from IP_Godown_Towel where GodownEntryCode='" + GRNtoUpdate + "'";
            

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
            this.GDRNO.EditValue = null;
            this.ArticleNumber.Tag = null;
            this.ArticleNumber.EditValue = null;

            this.LoomNumber.Tag = null;
            this.LoomNumber.EditValue = null;
            this.PONO.EditValue = null;
            this.ArticleNumber.EditValue = null;
            this.PartyID.EditValue = null;
            this.PartyName.EditValue = null;
            this.ArticleShortName.EditValue = null;
           
            this.PODRemarks.EditValue = null;

            this.Pieces_A.EditValue = null;
            this.Pieces_B.EditValue = null;
            this.Pieces_C.EditValue = null;
            this.Pieces_CP.EditValue = null;
            this.Pieces_SP.EditValue = null;
            this.Weight_Kg.EditValue = null;
            this.DocState.EditValue = "0";
           
            SetButtonStates_POD(UserInputMode.Add);
            this.Shed.Focus();
           
        }
        private void SelectPODRecord()
        {
            if (ItemFocusedRowHandle != -1)
            {
                ItemAccountRow = this.gridView_TakenToGodown.GetDataRow(this.gridView_TakenToGodown.FocusedRowHandle);
                if (ItemAccountRow != null)
                {
                    this.ArticleNumber.EditValue = ItemAccountRow["ArticleNumber"].ToString();
                    this.ArticleShortName.EditValue = ItemAccountRow["ArticleShortName"].ToString();
                    this.ArticleNumber.Tag = ItemAccountRow["ArticleNumber"].ToString();
                  
                    if (ItemAccountRow["ShedID"].ToString() != "")
                        this.Shed.EditValue = ItemAccountRow["ShedID"].ToString();
                    else
                        this.Shed.EditValue = null;
                      if (ItemAccountRow["LoomName"].ToString() != "")
                        this.LoomNumber.EditValue = ItemAccountRow["LoomName"].ToString();
                    else
                        this.LoomNumber.EditValue = null;
                    if (ItemAccountRow["PONO"].ToString() != "")
                        this.PONO.EditValue = ItemAccountRow["PONO"].ToString();
                    else
                        this.PONO.EditValue = null;

                    if (ItemAccountRow["BuyerID"].ToString() != "")
                        this.PartyID.EditValue = ItemAccountRow["BuyerID"].ToString();
                    else
                        this.PartyID.EditValue = null;
                    if (ItemAccountRow["Inward_P_A"].ToString() != "")
                        this.Pieces_A.EditValue = ItemAccountRow["Inward_P_A"].ToString();
                    else
                        this.Pieces_A.EditValue = null;
                    if (ItemAccountRow["Inward_P_B"].ToString() != "")
                        this.Pieces_B.EditValue = ItemAccountRow["Inward_P_B"].ToString();
                    else
                        this.Pieces_B.EditValue = null;
                    if (ItemAccountRow["Inward_P_C"].ToString() != "")
                        this.Pieces_C.EditValue = ItemAccountRow["Inward_P_C"].ToString();
                    else
                        this.Pieces_C.EditValue = null;
                    if (ItemAccountRow["Inward_P_SP"].ToString() != "")
                        this.Pieces_SP.EditValue = ItemAccountRow["Inward_P_SP"].ToString();
                    else
                        this.Pieces_SP.EditValue = null;
                    if (ItemAccountRow["Inward_P_CP"].ToString() != "")
                        this.Pieces_CP.EditValue = ItemAccountRow["Inward_P_CP"].ToString();
                    else
                        this.Pieces_CP.EditValue = null;
                    if( ItemAccountRow["Inward_Kg"].ToString()!="")
                        this.Weight_Kg.EditValue = ItemAccountRow["Inward_Kg"].ToString();
                    else
                        this.Weight_Kg.EditValue=null;
                    if (ItemAccountRow["State"].ToString() != "")
                        this.DocState.EditValue = ItemAccountRow["State"].ToString();
                    else
                        this.DocState.EditValue = null;

                    this.GDRNO.EditValue = ItemAccountRow["GDRNO"].ToString();
                    this.TakenCheck.Checked = ItemAccountRow["Taken"].ToString() == "True" ? true : false;
                    this.ShiftedCheck.Checked = ItemAccountRow["Shifted"].ToString() == "True" ? true : false;
                   
                   
                    SetButtonStates_POD(UserInputMode.View);
                }
            }
        }
        private void PODGridView_Item_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           
        }

        private void POD_Execute_Click(object sender, EventArgs e)
        {
            if (uiModePOD == UserInputMode.Edit)
            {
                if (this.DocState.EditValue == null) this.DocState.EditValue = "0";
                docState dc = (docState)Convert.ToInt16(this.DocState.EditValue.ToString());
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, dc);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                PODUpdateExisting();
            }
            else if (uiModePOD == UserInputMode.Delete)
            {
                if (this.DocState.EditValue == null) this.DocState.EditValue = "0";
                docState dc = (docState)Convert.ToInt16(this.DocState.EditValue.ToString());
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, dc);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
              
                PODDeleteExisting();
            }
        }

        private void POD_Edit_Click(object sender, EventArgs e)
        {
            if (this.GDRNO.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.ShiftedCheck.Checked == true)
            {
                XtraMessageBox.Show("You don't have rights to edit  , the item is shifted !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.TakenCheck.Checked == true)
            {
                XtraMessageBox.Show("You don't have rights to edit  , the item is taken !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SetButtonStates_POD(UserInputMode.Edit);
        }

        private void POD_Delete_Click(object sender, EventArgs e)
        {
            if (this.GDRNO.EditValue == null)
            {
                XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.ShiftedCheck.Checked == true)
            {
                XtraMessageBox.Show("You don't have rights to delete  , the item is shifted !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.TakenCheck.Checked == true)
            {
                XtraMessageBox.Show("You don't have rights to delete , the item is taken !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        }

        private void PO_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();
            




            strFilterQuery = "SELECT GodownEntryCode,Dated,Remarks  FROM IP_Godown_Towel  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "'";






            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "GodownEntryCode", "GodownEntryCode");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.PO_Print.Tag = sRow.PrimeryID;
                this.PO_View.Tag = sRow.PrimeryID;
                Fill_Register(sRow.PrimeryID);

            }
        }
        private void Fill_Register(string GodownEntryNo)
        {
            try
            {
                this.PO_Edit.Enabled = false;
                this.PO_Delete.Enabled = false;
                DataSet ds = WS.svc.Get_DataSet("Select * from IP_Godown_Towel where GodownEntryCode='" + GodownEntryNo + "'");
                if (ds == null) { PO_Next.Enabled = false; return; }

                if (ds.Tables[0].Rows.Count <= 0) { PO_Next.Enabled = false; return; }



              

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
                    this.Suffix.Text = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString().Substring(7, 6);


                }
                else
                {
                    this.Suffix.EditValue = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                }
                
                this.PO_Print.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                this.PO_View.Tag = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                this.RefGodownEntryCode.EditValue = ds.Tables[0].Rows[0]["GodownEntryCode"].ToString();
                GetEntryRecords(ds.Tables[0].Rows[0]["GodownEntryCode"].ToString());
                this.PO_Edit.Enabled = true;
                this.PO_Delete.Enabled = true;
                this.PO_Next.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GetEntryRecords(string GodownEntryCode)
        {
            string filterquery = "Select PONO,GDRNO,LoomName,ArticleShortName,INWARD_P_A,INWARD_P_B,INWARD_P_C,INWARD_P_SP,INWARD_P_CP,INWARD_P_T,INWARD_WPP,Round(INWARD_Kg,3) as INWARD_Kg,Round(INWARD_Lbs,2) as INWARD_Lbs,Round(INWARD_ES,3) as INWARD_ES,Taken,DepartmentID,ShedID,LoomID,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,BuyerID,RollNo,Remarks,State,Shifted,Code,REFGDRNO from RIP_Godown_Towel_Details  where GodownEntryCode='" + GodownEntryCode + "'";
            DataSet dsf = WS.svc.Get_DataSet(filterquery);
            this.gridControl_TakenToGodown.DataSource = dsf.Tables[0];
            for (int x = 15; x < gridView_TakenToGodown.Columns.Count; x++)
                this.gridView_TakenToGodown.Columns[x].Visible = false;
        }
        private void PO_Next_Click(object sender, EventArgs e)
        {
            if (this.PO_Print.Tag == null) return;
            if (this.RefGodownEntryCode.EditValue == null) return;
            this.xtraTabPage_Main.PageEnabled = false;
            this.xtraTabPage_Details.PageEnabled = false;
            this.xtraTabPage_Filter.PageEnabled = true;
            this.xtraTabPage_Selection.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Filter;
        }

        private void PODShedID_EditValueChanged(object sender, EventArgs e)
        {

            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = shedindex.ToString();
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
                this.Shed.EditValue = null;
            }
        }

        private void PODLoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Shed.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.Shed.Tag.ToString());
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

        private void POD_Back_Click(object sender, EventArgs e)
        {
            gotoPOTab();
        }

        private void Store_PurchaseOrder_Load(object sender, EventArgs e)
        {
            gotoPOTab();
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

        private void ShedName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Shed_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Shed.Tag = this.Shed.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Shed.Tag = null;
                this.ShedName.Text = "";
            }
        }

        private void LoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Shed.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.Shed.Tag.ToString());
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

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                string query = "SELECT Distinct ArticleNumber,ArticleShortName,SetNo,BeamNo,WeightGrams from RP_DailyShiftSummary";
                if (LoomNumber.Tag != null)
                    query += " where LoomID=" + LoomNumber.Tag.ToString() + "";
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "ArticleNumber", "ArticleShortName");

                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.ArticleNumber.Tag = sRow.PrimeryID;
                    this.ArticleNumber.EditValue = sRow.PrimeryID;
                    this.ArticleShortName.Text = sRow.PrimaryString;
                    try
                    {
                        this.WeightPerPiecePerArticle.EditValue = sRow.SelectedDataRow["WeightGrams"].ToString();
                        this.SetNo.Text = sRow.SelectedDataRow["SetNo"].ToString();
                        this.BeamNumber.Text = sRow.SelectedDataRow["BeamNo"].ToString();
                    }
                    catch
                    {
                    }

                }
            }
            else if (e.Control == true && e.KeyCode==Keys.Insert)
            {
               
                if (this.LoomNumber.Tag == null)
                {
                    this.LoomNumber.Focus();
                    return;
                }
                if (this.LoomNumber.Tag.ToString() == "")
                {
                    this.LoomNumber.Focus();
                    return;
                }

              
               
                    try
                    {
                        if (Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.ArticleNumber != "-1")
                        {
                            this.ArticleNumber.Tag = Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.ArticleNumber;
                            this.ArticleNumber.EditValue = Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.ArticleNumber;
                            this.ArticleShortName.Text = Program.ss.Machines.PresentationData.Articles[Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.ArticleNumber].ArticleName;
                            this.WeightPerPiecePerArticle.EditValue = Program.ss.Machines.PresentationData.Articles[Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.ArticleNumber].WeightGrams;
                            this.SetNo.Text = Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.SetNo;
                            this.BeamNumber.Text = Program.ss.Machines.Looms[Convert.ToInt32(this.LoomNumber.Tag.ToString())].CurrentAssignedParams.BeamNo;

                            return;
                        }
                      

                    }
                    catch
                    {
                    }


               
              
              
            
              
              


            
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PartyID.Focus();



            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.Shed.Focus();

            else
                return;
        }

        private void PiecesEnter_EditValueChanged(object sender, EventArgs e)
        {
            ProcessWeightPerPiece();
        }

        private void Weight_Kg_Properties_EditValueChanged(object sender, EventArgs e)
        {
            ProcessWeightPerPiece();
        }

        private void Weight_Kg_EditValueChanged(object sender, EventArgs e)
        {
            ProcessWeightPerPiece();
        }
        private void BrowsePO(KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (this.ArticleNumber.EditValue != null)
                {
                    string query = "SELECT Distinct PONUMBER,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTY from RFC_PO where ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "' and POStatusID=0";
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    FrmView.Load_View(query, "PONUMBER", "BuyerID");
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.PONO.EditValue = sRow.PrimeryID;
                        this.PartyID.EditValue = sRow.PrimaryString;

                        try
                        {
                            this.PartyName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();

                        }
                        catch
                        {
                        }

                    }
                }
                else
                {
                    string query = "SELECT Distinct PONUMBER,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTY from RFC_PO where POStatusID=0";
                    selectedrow sRow = new selectedrow();

                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.sRow = sRow;
                    FrmView.Load_View(query, "PONUMBER", "BuyerID");
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;
                        this.PONO.EditValue = sRow.PrimeryID;
                        this.PartyID.EditValue = sRow.PrimaryString;

                        try
                        {
                            this.PartyName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                            this.ArticleNumber.EditValue = sRow.SelectedDataRow["ArticleNumber"].ToString();
                            this.ArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();

                        }
                        catch
                        {
                        }

                    }
                }
            }
        }
        private void PartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Up)
                this.ArticleNumber.Focus();

           else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down)
                this.PONO.Focus();
            BrowsePO(e);
        }

        private void PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
               
                string query = "SELECT Distinct PONUMBER,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTY from RFC_PO where POStatusID=0";
                if (this.ArticleNumber.EditValue != null && this.ArticleShortName.EditValue!=null)
                {
                    query += " and ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
                    
                }
                if (this.PartyName.EditValue != null && this.PartyID.EditValue != null)
                {
                    
                        query += " and ";
                  
                    query += " BuyerID='" + this.PartyID.EditValue.ToString() + "'";
                }
                        selectedrow sRow = new selectedrow();

                        Data.Data_View FrmView = new Data.Data_View();
                        FrmView.sRow = sRow;
                        FrmView.Load_View(query, "PONUMBER", "BuyerID");
                        FrmView.ShowDialog();
                        if (sRow.Status == ParameterStatus.Selected)
                        {

                            if (sRow.SelectedDataRow == null)
                                return;
                            this.PONO.EditValue = sRow.PrimeryID;
                            this.PartyID.EditValue = sRow.PrimaryString;

                            try
                            {
                                this.PartyName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();

                            }
                            catch
                            {
                            }

                        }
                    

                
            }
            


         
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.PartyID.Focus();
           
        }

        private void Shed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.ArticleNumber.Focus();
                
                
            else if (e.KeyCode == Keys.Right)
                this.LoomNumber.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.gridView_TakenToGodown.Focus();
            

        }

        private void LoomNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.ArticleNumber.Focus();


            else if (e.KeyCode == Keys.Left)
                this.Shed.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.gridView_TakenToGodown.Focus();
            
        }

        private void FrameNumber_KeyDown(object sender, KeyEventArgs e)
        {

          
            
        }

        private void InspectorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.RollThanNumber.Focus();


          
           
        }

        private void RollThanNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.Pieces_A.Focus();


          
        }

        private void Pieces_A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Pieces_B.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Pieces_C.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Pieces_A.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Pieces_SP.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Pieces_B.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_SP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Pieces_CP.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Pieces_C.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Pieces_CP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Weight_Kg.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Pieces_SP.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void Weight_Kg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.PODRemarks.Focus();


            else if (e.KeyCode == Keys.Right)
                this.PODRemarks.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Pieces_CP.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.RollThanNumber.Focus();
        }

        private void PODRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.POD_Execute.Focus();


            else if (e.KeyCode == Keys.Right)
                this.Code.Focus();
            else if (e.KeyCode == Keys.Left)
                this.Weight_Kg.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.Pieces_A.Focus();
        }

        private void Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.PageDown)
                this.POD_Execute.Focus();


            else if (e.KeyCode == Keys.Left)
                this.PODRemarks.Focus();
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.PageUp)
                this.Weight_Kg.Focus();
        }

        private void PODGridView_Item_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void POD_Add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                POD_Edit.Focus();
            if (e.KeyCode == Keys.Up)
                Pieces_A.Focus();

        }

        private void ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (ArticleNumber.EditValue != null)
            {
               article f = Program.ss.Machines.PresentationData.Return_Article(ArticleNumber.EditValue.ToString());
               if (f != null)
               {
                   this.ArticleShortName.EditValue = f.ArticleName;
                   this.WeightPerPiecePerArticle.EditValue = f.WeightGrams;
               }
               else
               {
                   this.ArticleShortName.EditValue = null;
                   this.WeightPerPiecePerArticle.EditValue = null;
               }
            }
            else
                this.ArticleShortName.EditValue = null;
        }

        private void PartyID_EditValueChanged(object sender, EventArgs e)
        {
            if (PartyID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.PartyID.EditValue.ToString());
                if (mAcID != "")
                    this.PartyName.EditValue = mAcID;
                else
                    this.PartyName.EditValue = null;
            }
            else
            {
                PartyName.EditValue = null;
            }
        }

        private void Code_EditValueChanged(object sender, EventArgs e)
        {
            if (Code.EditValue != null)
            {
                RollCodes rc = (RollCodes)Convert.ToInt32(Code.EditValue.ToString());

                this.CodeName.EditValue = rc.ToString();
            }
            else
                CodeName.EditValue = null;
        }

        private void DocState_EditValueChanged(object sender, EventArgs e)
        {
            if (DocState.EditValue != null)
            {
                docState dc=(docState) Convert.ToInt16(this.DocState.EditValue.ToString());
                DocStateName.EditValue = dc.ToString();
            }
            else
                DocStateName.EditValue = "Not Defined";
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
                    }

        private void Filter_ShedID_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Shed.Text);
            if (shedindex != -1)
            {
                this.Filter_ShedID.Tag = this.Shed.Text;
                this.Filter_ShedName.EditValue = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.Filter_ShedID.Tag = null;
                this.Filter_ShedName.EditValue = null;
            }
        }

        private void Filter_LoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.Filter_ShedID.Tag == null)
            {
                this.Filter_LoomNumber.ForeColor = Color.White;
                this.Filter_LoomNumber.BackColor = Color.Red;
                this.Filter_LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.Filter_LoomNumber.Text, this.Filter_ShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.Filter_LoomNumber.ForeColor = Color.Black;
                this.Filter_LoomNumber.BackColor = Color.White;
                this.Filter_LoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.Filter_LoomNumber.ForeColor = Color.White;
                this.Filter_LoomNumber.BackColor = Color.Red;
                this.Filter_LoomNumber.Tag = null;
            }
        }

        private void Filter_ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (Filter_ArticleNumber.EditValue != null)
            {
                article f = Program.ss.Machines.PresentationData.Return_Article(Filter_ArticleNumber.EditValue.ToString());
                if (f != null)
                {
                    this.Filter_ArticleName.EditValue = f.ArticleName;
                    
                }
                else
                {
                    this.Filter_ArticleName.EditValue = null;
                   
                }
            }
            else
                this.Filter_ArticleName.EditValue = null;
        }

        private void Filter_ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (Program.MainWindow.ArticleView == null) Program.MainWindow.ArticleView = new Data_Article_Main_View();
                Program.MainWindow.ArticleView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {

                        this.Filter_ArticleNumber.EditValue = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                        this.Filter_ArticleName.EditValue = Program.MainWindow.ArticleView.SelectedRow.PrimaryString;


                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Filter_BuyerID_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Filter_BuyerID_EditValueChanged(object sender, EventArgs e)
        {
            if (Filter_BuyerID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.Filter_BuyerID.EditValue.ToString());
                if (mAcID != "")
                    this.Filter_BuyerName.EditValue = mAcID;
                else
                    this.Filter_BuyerName.EditValue = null;
            }
            else
            {
                this.Filter_BuyerName.EditValue = null;
            }
        }

        private void Filter_PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {

                string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPcs,POQtyLbs from RFC_PO where POStatusID=0";
                if (this.Filter_ArticleName.EditValue != null && this.Filter_ArticleNumber.EditValue != null)
                {
                    query += " and ArticleNumber='" + this.Filter_ArticleNumber.EditValue.ToString() + "'";

                }
                if (this.Filter_BuyerID.EditValue != null && this.Filter_BuyerName.EditValue != null)
                {

                    query += " and ";

                    query += " BuyerID='" + this.Filter_BuyerID.EditValue.ToString() + "'";
                }
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "PONO", "BuyerID");
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.Filter_PONO.EditValue = sRow.PrimeryID;
                    this.Filter_BuyerID.EditValue = sRow.PrimaryString;

                    try
                    {
                        this.Filter_BuyerName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();

                    }
                    catch
                    {
                    }

                }



            }
        }

        private void Filter_Next_Click(object sender, EventArgs e)
        {
           
                this.xtraTabPage_Main.PageEnabled = false;
                this.xtraTabPage_Details.PageEnabled = false;
                this.xtraTabPage_Filter.PageEnabled = false;
                this.xtraTabPage_Selection.PageEnabled = true;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Selection;
            
        }

        private void Filter_Back_Click(object sender, EventArgs e)
        {
            this.xtraTabPage_Main.PageEnabled = true;
            this.xtraTabPage_Details.PageEnabled = false;
            this.xtraTabPage_Filter.PageEnabled = false;
            this.xtraTabPage_Selection.PageEnabled = false;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Main;
        }

        private void TakeToGodownCheck_CheckedChanged(object sender, EventArgs e)
        {
           if (this.gridView_Selection.FocusedRowHandle != -1)
            {

                try
                {
                    DataRow SelectedDataRow = this.gridView_Selection.GetDataRow(this.gridView_Selection.FocusedRowHandle);
                    string indexno = SelectedDataRow["GDRNO"].ToString();
                    if (indexno != "")
                    {
                        string res = "";
                        bool ischecked = (bool)TakeToGodownCheck.ValueChecked;
                        if (ischecked == true)
                            res = WS.svc.Execute_Query("update IP_Godown_Towel_Details set Taken=1 where GDRNO=" + indexno + "");
                        else
                            res = WS.svc.Execute_Query("update IP_Godown_Towel_Details set Taken=0 where GDRNO=" + indexno + "");
                        if (res != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (ischecked == true)
                                TakeToGodownCheck.ValueChecked = false;
                            else if (ischecked == false)
                                TakeToGodownCheck.ValueChecked = true;
                        }
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bool ischecked = (bool)TakeToGodownCheck.ValueChecked;
                    if (ischecked == true)
                        TakeToGodownCheck.ValueChecked = false;
                    else if (ischecked == false)
                        TakeToGodownCheck.ValueChecked = true;
                }


            }
        }

        private void Filter_Search_Click(object sender, EventArgs e)
        {
            string filterquery = "Select PONO,GDRNO,LoomName,ArticleShortName,INSPECT_P_A,INSPECT_P_B,INSPECT_P_C,INSPECT_P_SP,INSPECT_P_CP,INSPECT_P_T,INSPECT_WPP,Round(INSPECT_Kg,3) as INSPECT_Kg,Round(INSPECT_Lbs,3) as INSPECT_Lbs,Round(INSPECT_ES,3) as INSPECT_ES,Taken,DepartmentID,ShedID,LoomID,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,RollNo,Remarks,State,Shifted,Code,BuyerID,REFGDRNO from RIP_Godown_Towel_Details  where GodownEntryTypeID=1 and Taken=0 and Shifted=0";

            if (this.Filter_ArticleName.EditValue != null && this.Filter_ArticleNumber.EditValue!=null && Filter_onArticleNumber.Checked ==true)
            {
                filterquery += " and ArticleNumber='" + this.Filter_ArticleNumber.EditValue.ToString() + "'";
            }

            if (this.Filter_Dated.DateTime != null && Filter_onDated.Checked == true)
            {
                filterquery += " and Dated='" + this.Filter_Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            }
            if (this.Filter_BuyerName.EditValue != null && Filter_BuyerID.EditValue!=null &&  this.Filter_onBuyerID.Checked == true)
            {
                filterquery += " and BuyerID='" + this.Filter_BuyerID.EditValue.ToString() + "'";
            }
            if (this.Filter_ShedID.EditValue != null && Filter_ShedName.EditValue!=null &&  this.Filter_onShedID.Checked == true)
            {
                filterquery += " and ShedID=" + this.Filter_ShedID.EditValue.ToString() + "";
            }
            if (this.Filter_LoomNumber.Tag != null && this.Filter_onShedID.Checked == true && this.Filter_LoomNumber.EditValue!=null)
            {
                filterquery += " and LoomID='" + this.Filter_LoomNumber.Tag.ToString() + "'";
            }
            if (this.Filter_PONO.EditValue != null && this.Filter_onPONO.Checked == true)
            {
                filterquery += " and PONO='" + this.Filter_PONO.EditValue.ToString() + "'";
            }

            if (this.Filter_A.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_P_A=" + this.Filter_A.EditValue.ToString() + "";
            }
            if (this.Filter_B.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_P_B=" + this.Filter_B.EditValue.ToString() + "";
            }
            if (this.Filter_C.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_P_C=" + this.Filter_C.EditValue.ToString() + "";
            }
            if (this.Filter_CP.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_P_CP=" + this.Filter_CP.EditValue.ToString() + "";
            }
            if (this.Filter_SP.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_P_SP=" + this.Filter_SP.EditValue.ToString() + "";
            }
            if (this.Filter_Weight.EditValue != null && this.Filter_onPieces.Checked == true)
            {
                filterquery += " and INSPECT_Kg=" + this.Filter_Weight.EditValue.ToString() + "";
            }
            DataSet ds = WS.svc.Get_DataSet(filterquery);

            DataSet dsm = WS.svc.Get_DataSet("Select PONO,GDRNO,LoomName,ArticleShortName,INSPECT_P_A,INSPECT_P_B,INSPECT_P_C,INSPECT_P_SP,INSPECT_P_CP,INSPECT_P_T,INSPECT_WPP,Round(INWARD_Kg,3) as INSPECT_Kg,Round(INSPECT_Lbs,3) as INSPECT_Lbs,Round(INSPECT_ES,3) as INSPECT_ES,Taken,DepartmentID,ShedID,LoomID,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,RollNo,Remarks,State,Shifted,Code,REFGDRNO,BuyerID from RIP_Godown_Towel_Details  where GodownEntryTypeID=1 and Taken=1 and Shifted=0");
            ds.Merge(dsm.Tables[0]);
            if (ds != null)
            {
                gridControl_Selection.DataSource = ds.Tables[0];
            }
            this.xtraTabPage_Main.PageEnabled = false;
            this.xtraTabPage_Details.PageEnabled = false;
            this.xtraTabPage_Filter.PageEnabled = false;
            this.xtraTabPage_Selection.PageEnabled = true;
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Selection;
        }
        private void TakeFromInspectionToGodown()
        {
           
            DialogResult dg = XtraMessageBox.Show("Are you sure to take all selected towel rolls/thans/pieces to godown?", "Confirmation", MessageBoxButtons.YesNo);
            if (dg != DialogResult.Yes) return;

            string[] queries = new string[0];



            DataTable dt = (DataTable)gridControl_Selection.DataSource;
            string GDRNO = PODGetNextNumber();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (dt.Rows[x]["Taken"].ToString() == "True")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into IP_Godown_Towel_Details (GodownEntryCode,state,GDRNO,DepartmentID,ShedID,LoomID,LoomName,PONO,ArticleNumber,SetNo,BeamNo,FrameNo,InspectorID,RollNo,Code,Remarks,Inward_P_A,Inward_P_B,Inward_P_C,Inward_P_SP,Inward_P_CP,Inward_P_T,Inward_Kg,Inward_Lbs,Inward_WPP,RefGDRNO) Values (";
                    queries[queries.Length - 1] += "'" + this.RefGodownEntryCode.EditValue.ToString() + "',0,'" + GDRNO + "'";
                    if (Departments.Towel_Godown != "")
                        queries[queries.Length - 1] += ",'" + Departments.Towel_Godown + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["ShedID"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["ShedID"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["LoomID"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["LoomID"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["LoomName"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["LoomName"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["PONO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["PONO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["ArticleNumber"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["ArticleNumber"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["SetNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["SetNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["BeamNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["BeamNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["FrameNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["FrameNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["InspectorID"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["InspectorID"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Rollno"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["RollNO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Code"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["Code"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["Remarks"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["Remarks"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (dt.Rows[x]["INSPECT_P_A"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_A"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_P_B"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_B"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_P_C"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_C"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_P_SP"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_SP"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_P_CP"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_CP"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_P_T"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_P_T"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_Kg"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_Kg"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_Lbs"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_Lbs"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["INSPECT_WPP"].ToString() != "")
                        queries[queries.Length - 1] += "," + dt.Rows[x]["INSPECT_WPP"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (dt.Rows[x]["GDRNO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + dt.Rows[x]["GDRNO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    queries[queries.Length - 1] += ")";

                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update IP_Godown_Towel_Details set Shifted=1,State=1,REFGDRNO='" + GDRNO + "' where GDRNO='" + dt.Rows[x]["GDRNO"].ToString() + "'";
                   
                    GDRNO =this.RefGodownEntryCode.EditValue.ToString() +  Convert.ToString(Convert.ToInt64(GDRNO.Substring(13,7)) + 1).PadLeft(7,'0');
                }
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
                    GetEntryRecords(this.RefGodownEntryCode.EditValue.ToString());
                    this.gridControl_Selection.DataSource = null;
                  
                    this.xtraTabPage_Main.PageEnabled = false;
                    this.xtraTabPage_Details.PageEnabled = true;
                    this.xtraTabPage_Filter.PageEnabled = false;
                    this.xtraTabPage_Selection.PageEnabled = false;
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Details;
                    SetButtonStates_POD(UserInputMode.View);
                   
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void TaketoGodown_Click(object sender, EventArgs e)
        {


        }

        private void gridControl_Selection_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void gridView_TakenToGodown_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ItemFocusedRowHandle = this.gridView_TakenToGodown.FocusedRowHandle;
            SelectPODRecord();
        }

        private void gridView_Selection_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Insert && e.Control == true)
            {
                TakeFromInspectionToGodown();
            }
            else if (e.KeyCode == Keys.Right)
            {

                this.xtraTabPage_Main.PageEnabled = false;
                this.xtraTabPage_Details.PageEnabled = true;
                this.xtraTabPage_Filter.PageEnabled = false;
                this.xtraTabPage_Selection.PageEnabled = false;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Details;
            }
            else if (e.KeyCode == Keys.Left)
            {
                this.xtraTabPage_Main.PageEnabled = false;
                this.xtraTabPage_Details.PageEnabled = false;
                this.xtraTabPage_Filter.PageEnabled = true;
                this.xtraTabPage_Selection.PageEnabled = false;
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Filter;
            }
        }

        private void xtraTabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage_Main)
                {
                    this.xtraTabPage_Main.PageEnabled = false;
                    this.xtraTabPage_Details.PageEnabled = false;
                    this.xtraTabPage_Filter.PageEnabled = true;
                    this.xtraTabPage_Selection.PageEnabled = false;
                    this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Filter;
                }
            }



        }

      

       
    }
}