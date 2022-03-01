using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Data_Sizing : DevExpress.XtraEditors.XtraForm
    {

        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        public Data_Sizing()
        {
            InitializeComponent();
            this.Prefix.Text = "104";
            G_Invoice = "104";
            N_Invoice = "114";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            FillCombos fc = new FillCombos();
            fc.SizingMachines(ref this.SizingMachine);
            this.SizingDate.DateTime = DateTime.Now;
            this.StartTime.DateTime = DateTime.Now.Subtract(new TimeSpan(2, 0, 0));
            this.EndTime.DateTime = DateTime.Now;
        }
        private void SetButtonStates(UserInputMode input)
        {
            uiMode = input;
            switch (input)
            {
                case UserInputMode.View:
                    this.Add.Enabled = true;
                    this.CancelThis.Enabled = false;
                    this.CloseThis.Enabled = true;
                    if (this.Suffix.Tag != null)
                    {
                        if (this.Suffix.Tag.ToString() != "")
                        {
                            this.Delete.Enabled = true;
                            this.Edit.Enabled = true;
                        }
                        else
                        {
                            this.Delete.Enabled = false;
                            this.Edit.Enabled = false;
                        }
                    }
                    else
                    {
                        this.Delete.Enabled = false;
                        this.Edit.Enabled = false;
                    }
                    this.Execute.Enabled = false;
                    this.View.Enabled = true;

                    break;
                case UserInputMode.Add:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;
                    break;
                case UserInputMode.Edit:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                case UserInputMode.Delete:

                    this.Add.Enabled = false;
                    this.CancelThis.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseThis.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

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
                    query = "select max(Convert(numeric(18),SubString(SETNO,8,6)))+1 as MaxNumber  from SW_Sizing where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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
        private void Add_Click(object sender, EventArgs e)
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
            this.Suffix.Text = "";

            this.Suffix.Text = "";
            
       
            this.Remarks.Text = "";
            this.Suffix.Text = "";
            this.SetNo.EditValue = null;
          
           

           


            if (this.SetNoType.EditValue.ToString() == "0")
            {
                bool rRes = GetNextInvoiceNumber();
                if (rRes != false)
                    SetButtonStates(UserInputMode.Add);
            }else
                SetButtonStates(UserInputMode.Add);
            this.tableLayoutPanel_SizingDetails.Controls.Clear();
            this.TableLayout_Chemicals.Controls.Clear();
            this.TableLayout_Chemicals.Controls.Add(new UserControls.dxSizingChemicalConsumption());
            this.SetNo.Focus();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiMode == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiMode == UserInputMode.Delete)
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

        private void Edit_Click(object sender, EventArgs e)
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


            if (this.SetNoType.EditValue.ToString() == "0")
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
            }
            else
            {
                if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
            }


            if(this.TableLayout_Chemicals.Controls.Count<=0)
            this.TableLayout_Chemicals.Controls.Add(new UserControls.dxSizingChemicalConsumption());
            SetButtonStates(UserInputMode.Edit);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (SetNoType.EditValue.ToString() == "0")
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
            }
            else
            {
                if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }


            }

            SetButtonStates(UserInputMode.Delete);
        }

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.FilterSizingDate.Checked == true)
            {
                if (this.SizingDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }

            if (this.FilterWarpingProgramNumber.Checked == true)
            {
                if (this.WarpingProgramNumber.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Program Number filter or enter valid Program Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.FilterSetNo.Checked == true)
            {
                if (this.SetNoType.EditValue.ToString() == "0")
                {
                    if (this.Suffix.Text == "")
                    {
                        XtraMessageBox.Show("Either uncheck the Set number filter or enter valid set # ", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    if (this.SetNo.EditValue == null)
                    {
                            XtraMessageBox.Show("Either uncheck the Set number filter or enter valid set # ", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        

                    }
                    if (this.SetNo.EditValue.ToString() == null)
                    {
                        XtraMessageBox.Show("Either uncheck the Set number filter or enter valid set # ", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;


                    }


                }

            }
            if (this.FilterSizingMachine.Checked == true)
            {
                if (this.SizingMachine.EditValue == null && this.SizingMachine.Tag==null)
                {
                    XtraMessageBox.Show("Either uncheck the sizing machine filter or select valid sizing machine", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
          

        



            strFilterQuery = "SELECT  SETNO,ProgramSheetNumber,WarpingProgramNumber,SizingDate,TotalSizedBeams,SizingMachineID from SWQ_Sizing ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' and SizingTypeID='1' ";



            if (this.FilterSizingDate.Checked == true)
            {

                strFilterQuery += " and SizingDate='" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.FilterSetNo.Checked == true)
            {
                if(this.SetNoType.EditValue.ToString()=="0")
                strFilterQuery += " and Setno like '%" + this.Suffix.Text + "%'";
                else
                    strFilterQuery += " and Setno like '%" + this.SetNo.EditValue.ToString() + "%'";
                
            }

            if (this.FilterSizingMachine.Checked == true)
            {

                strFilterQuery += " and SizingMachineID='" + this.SizingMachine.EditValue.ToString() + "'";

            }
            if (this.FilterWarpingProgramNumber.Checked == true)
            {

                strFilterQuery += " and WarpingProgramNumber='" + this.WarpingProgramNumber.Tag.ToString() + "'";

            }
           
          


           // strFilterQuery += " ORDER BY Convert(numeric(18),SetNo) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "SetNO", "SetNO");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_SizingSheet(sRow.PrimeryID);

            }
        }
        private void Fill_SizingSheet(string SetNo)
        {
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from SW_Sizing where SetNO='" + SetNo + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;

            if (ds_VoucherMain.Tables[0].Rows[0]["iCat"].ToString() == "G")
            {
                this.NG.Checked = false;

            }
            else
            {

                this.NG.Checked = true;
            }

            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNo"].ToString();
            this.SetNoType.EditValue = ds_VoucherMain.Tables[0].Rows[0]["SetNoType"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["SetNoType"].ToString() == "0")
            {
                this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString().Substring(7, 6);
                this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString().Substring(7, 6); ;
                this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString().Substring(7, 6);
            }
            else
            {
                
                this.SetNo.EditValue = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString();
                this.SetNo.Tag = ds_VoucherMain.Tables[0].Rows[0]["SetNO"].ToString();
            }
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iType"].ToString();
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iYear"].ToString();
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["RatePerLbs"].ToString() != "")
                this.RateperLbs.EditValue = ds_VoucherMain.Tables[0].Rows[0]["RatePerLbs"].ToString();
            else
                this.RateperLbs.EditValue = null;
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

            try
            {
                this.SizingDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["SizingDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            }
            catch
            {
            }
            try
            {
                this.StartTime.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["StartTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            }
            catch
            {
            }
            try
            {
                this.EndTime.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["EndTime"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            }
            catch
            {
            }


            if (ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString() != "")
            {
                this.WarpingProgramNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
                this.WarpingProgramNumber.EditValue = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            }
            else
                this.WarpingProgramNumber.Tag = null;

           
            this.SizingMachine.EditValue = ds_VoucherMain.Tables[0].Rows[0]["SizingMachineID"].ToString();
            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
           
            this.Breakages.EditValue = ds_VoucherMain.Tables[0].Rows[0]["Breakages"].ToString();
            this.TotalSizedBeams.EditValue = ds_VoucherMain.Tables[0].Rows[0]["TotalSizedBeams"].ToString();
            this.TotalSizedBeams.Tag = ds_VoucherMain.Tables[0].Rows[0]["TotalSizedBeams"].ToString();



            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SWQ_Sizing_Details where Setno='" + SetNo + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_SizingDetails.Controls.Clear();

            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                dxSizingDetail ysub = new dxSizingDetail();
                this.tableLayoutPanel_SizingDetails.Controls.Add(ysub);
                ysub.Tag = this.SetNo.Tag;
                
                ysub.GrossWeight.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["GWeight"].ToString();
                ysub.BeamLength.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BeamLength"].ToString();
                ysub.BeamSpeed.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Speed"].ToString();
                ysub.Pressure.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Pressure"].ToString();
                ysub.Remarks.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Remarks"].ToString();
                ysub.BeamNumber.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Beamnumber"].ToString();
                ysub.BeamNumber.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["Beamnumber"].ToString();
                if (ds_VoucherSub_T.Tables[0].Rows[x]["SizerID"].ToString() != "")
                {
                    ysub.Sizer.Tag = ds_VoucherSub_T.Tables[0].Rows[x]["SizerID"].ToString();
                    ysub.Sizer.Text = ds_VoucherSub_T.Tables[0].Rows[x]["SizerName"].ToString();
                }
                else
                {
                    ysub.Sizer.Tag = null;
                    ysub.Sizer.Text = "";
                    ysub.Sizer.EditValue = null;
                }

                ysub.Shift.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Shift"].ToString();
                
            }
            DataSet ds_VoucherSub_C = WS.svc.Get_DataSet("select * from SWQ_Sizing_ChemicalsConsumption where SetnO='" + SetNo + "'");
            if (ds_VoucherSub_C == null) return;
            this.TableLayout_Chemicals.Controls.Clear();

            for (int x = 0; x < ds_VoucherSub_C.Tables[0].Rows.Count; x++)
            {
                UserControls.dxSizingChemicalConsumption ysub = new UserControls.dxSizingChemicalConsumption();
                this.TableLayout_Chemicals.Controls.Add(ysub);

                if (ds_VoucherSub_C.Tables[0].Rows[x]["ChemicalID"].ToString() != "")
                {
                    ysub.ChemicalID.Tag = ds_VoucherSub_C.Tables[0].Rows[x]["ChemicalID"].ToString();
                    ysub.ChemicalID.EditValue = ds_VoucherSub_C.Tables[0].Rows[x]["ChemicalName"].ToString();
                    ysub.cUnit.EditValue = ds_VoucherSub_C.Tables[0].Rows[x]["cUnit"].ToString();
                    ysub.cUnit.Tag = ds_VoucherSub_C.Tables[0].Rows[x]["cUnitRate"].ToString();
               
                    ysub.Batches.EditValue = ds_VoucherSub_C.Tables[0].Rows[x]["Batches"].ToString();
                    ysub.Quantity.EditValue = ds_VoucherSub_C.Tables[0].Rows[x]["QuantityConsumed"].ToString();
                    ysub.Remarks.EditValue = ds_VoucherSub_C.Tables[0].Rows[x]["Remarks"].ToString();
               
                }
                else
                {
                    ysub.ChemicalID.Tag = null;
                    ysub.ChemicalID.EditValue = null;
                    ysub.Quantity.EditValue = null;
                    ysub.Batches.EditValue = null;
                    ysub.cUnit.EditValue = null;
                    ysub.cUnit.Tag = null;
                }
               
               

            }

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;
        }
        private void CancelThis_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void CloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";


                this.Prefix.Text = N_Invoice;
                if (uiMode == UserInputMode.Add || uiMode == UserInputMode.Edit)
                {

                    GetNextInvoiceNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Invoice;
                if (uiMode == UserInputMode.Add)
                {

                    GetNextInvoiceNumber();
                }
            }
        }
        private void SaveNew()
        {
            if (SetNoType.EditValue.ToString() == "0")
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
                if (this.Suffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Suffix.Focus();
                    return;
                }
                int suffix = 0;
                if (Int32.TryParse(this.Suffix.Text, out suffix) == false)
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
                if (this.Suffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
            }

            if (this.SizingDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.TotalSizedBeams.EditValue == null)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                return;
            }

            int NoofBeams = 0;
            int.TryParse(this.TotalSizedBeams.EditValue.ToString(), out NoofBeams);
            if (NoofBeams <= 0 || NoofBeams > 20)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            //if (this.WarpingProgramNumber.Text == "")
            //{
            //    XtraMessageBox.Show("invalid referenced warping program", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}

            //if (this.WarpingProgramNumber.Tag == null)
            //{
            //    XtraMessageBox.Show("invalid referenced warping program", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}
            string[] queries = new string[0];

            string vnum = "";
            if (this.SetNoType.EditValue.ToString() == "0")
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
                vnum = this.SetNo.EditValue.ToString();
            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            //if (vnum.Length != 13)
            //{
            //    XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.BeamLength.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Length", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.Shift.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Shift", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                //if (AField.Sizer.EditValue == null)
                //{
                //    XtraMessageBox.Show("Invalid Sizer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
             
             

            }
            
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into SW_Sizing (SizingTypeID,SetNoType,SetNo,iType,iCat,iYear,iStatus,WarpingProgramNumber,SizingMachineID,Breakages,RatePerLbs,SizingDate,TotalSizedBeams,Starttime,EndTime,Remarks,cUserId,CuserTime) Values (";
            queries[queries.Length - 1] += "'1',"+this.SetNoType.EditValue.ToString()+",'" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            
            if (this.WarpingProgramNumber.Text != "")
                queries[queries.Length - 1] += ",'" + this.WarpingProgramNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.SizingMachine.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.SizingMachine.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.Breakages.EditValue != null)
                queries[queries.Length - 1] += "," + this.Breakages.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.RateperLbs.EditValue != null)
                queries[queries.Length - 1] += "," + this.RateperLbs.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.SizingDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.TotalSizedBeams.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalSizedBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.StartTime.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.StartTime.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.EndTime.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.EndTime.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[queries.Length - 1] += ",null";
         
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
       
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";

            if (this.WarpingProgramNumber.Tag != null)
            {
                if (this.WarpingProgramNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_Warping  set iStatus='P' where WarpingProgramNumber='" + this.WarpingProgramNumber.Text + "' ";
                }
            }

            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Sizing_Details (SetNo,BeamNumber,BeamLength,Speed,Pressure,SizerID,Shift,GWeight,Remarks,BeamStatus) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";

                if (AField.BeamNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.BeamNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.BeamLength.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BeamLength.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BeamSpeed.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BeamSpeed.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Pressure.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Pressure.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Sizer.Tag != null)
                    queries[queries.Length - 1] += ",'" + AField.Sizer.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Shift.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Shift.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text!="")
                    queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text!="")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",1)";

            }

            foreach (Control C in this.TableLayout_Chemicals.Controls)
            {
                UserControls.dxSizingChemicalConsumption AField = (UserControls.dxSizingChemicalConsumption)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Sizing_ChemicalsConsumption (SetNo,ChemicalID,cUnit,cUnitRate,QuantityConsumed,Batches,Remarks) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";

                if (AField.ChemicalID.EditValue != null && AField.ChemicalID.Tag!=null)
                    queries[queries.Length - 1] += ",'" + AField.ChemicalID.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.cUnit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.cUnit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.cUnit.Tag != null)
                    if(AField.cUnit.Tag.ToString()!="")
                    queries[queries.Length - 1] += "," + AField.cUnit.Tag.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Quantity.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Quantity.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Batches.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Batches.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",1";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";

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

                    this.Print.Tag = vnum;
                    this.Suffix.Text = "";
                    this.Remarks.Text = "";
                    this.Suffix.Tag = null;
                    this.SetNo.EditValue = null;
                    this.WarpingProgramNumber.EditValue = null;
                    this.WarpingProgramNumber.Tag = null;
                    this.Breakages.EditValue = null;
                    this.TotalSizedBeams.EditValue = 0;
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Add(new UserControls.dxSizingChemicalConsumption());
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
            if (this.SetNoType.EditValue.ToString() == "0")
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
                if (this.Suffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Suffix.Focus();
                    return;
                }
                int suffix = 0;
                if (Int32.TryParse(this.Suffix.Text, out suffix) == false)
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
                if (this.Suffix.Text.Length != 6)
                {
                    XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                if (this.SetNo.Tag == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.SetNo.EditValue == null)
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
                if (this.SetNo.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid setno", "Error", MessageBoxButtons.OK);
                    return;

                }
            }

            if (this.SizingDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.SizingDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.SizingDate.Focus();
                return;
            }
            if (this.TotalSizedBeams.EditValue == null)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            if (this.TotalSizedBeams.Tag == null)
            {
                XtraMessageBox.Show("invalid number of beams were before editing", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            int NoofBeams = 0;
            int.TryParse(this.TotalSizedBeams.EditValue.ToString(), out NoofBeams);
            if (NoofBeams <= 0 || NoofBeams > 20)
            {
                XtraMessageBox.Show("invalid number of beams", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            //if (this.WarpingProgramNumber.Text == "")
            //{
            //    XtraMessageBox.Show("invalid referenced warping program", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}

            //if (this.WarpingProgramNumber.Tag == null)
            //{
            //    XtraMessageBox.Show("invalid referenced warping program", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}
            string[] queries = new string[0];
            string vnum = "";
            string vnumtoupdate = "";
            if (this.SetNoType.EditValue.ToString() == "0")
            {
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
                vnumtoupdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            }
            else
            {
                vnum = this.SetNo.EditValue.ToString();
                vnumtoupdate = this.SetNo.Tag.ToString();
            }
            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            //if (vnum.Length != 13)
            //{
            //    XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //    return;
            //}
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.BeamLength.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Beam Length", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                if (AField.Shift.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Shift", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                //if (AField.Sizer.EditValue == null)
                //{
                //    XtraMessageBox.Show("Invalid Sizer", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}



            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update SW_Sizing set ";
            queries[queries.Length - 1] += "SetNo='" + vnum + "',SetNoType="+this.SetNoType.EditValue.ToString()+",iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "' ";


            if (this.WarpingProgramNumber.Text != "")
                queries[queries.Length - 1] += ",WarpingProgramNumber='" + this.WarpingProgramNumber.Text + "'";
            else
                queries[queries.Length - 1] += ",WarpingProgramNumber=null";
            if (this.SizingMachine.EditValue != null)
                queries[queries.Length - 1] += ",SizingMachineID='" + this.SizingMachine.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SizingMachineID=null";
            if (this.Breakages.EditValue != null)
                queries[queries.Length - 1] += ",Breakages=" + this.Breakages.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",Breakages=0";

            if (this.SizingDate.EditValue != null)
                queries[queries.Length - 1] += ",SizingDate='" + this.SizingDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",SizingDate=null";
            if (this.TotalSizedBeams.EditValue != null)
                queries[queries.Length - 1] += ",TotalSizedBeams=" + this.TotalSizedBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",TotalSizedBeams=0";
            if (this.RateperLbs.EditValue != null)
                queries[queries.Length - 1] += ",RatePerLbs=" + this.RateperLbs.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",RatePerLbs=0";
            if (this.StartTime.EditValue != null)
                queries[queries.Length - 1] += ",StartTime='" + this.StartTime.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[queries.Length - 1] += ",StartTime=null";
            if (this.EndTime.EditValue != null)
                queries[queries.Length - 1] += ",EndTime='" + this.EndTime.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[queries.Length - 1] += ",EndTime=null";

            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",Remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",Remarks=null";

            queries[queries.Length - 1] += ",euserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime ='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where Setno='"+vnumtoupdate+"'";
            Array.Resize(ref queries, queries.Length + 1);

            queries[queries.Length - 1] = "update SW_Warping  set iStatus='U' where WarpingProgramNumber in(select warpingProgramNumber from SW_Sizing where Setno='" + vnumtoupdate + "' )";
            if (this.WarpingProgramNumber.Tag != null)
            {
                if (this.WarpingProgramNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_Warping  set iStatus='P' where WarpingProgramNumber='" +this.WarpingProgramNumber.Text + "'";
                }
            }
            //Array.Resize(ref queries, queries.Length + 1);
            //queries[queries.Length - 1] = "delete from SW_Sizing_Details where setno ='"+vnumtoupdate+"' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_ChemicalsConsumption where setno ='" + vnumtoupdate + "' ";
            foreach (Control C in this.tableLayoutPanel_SizingDetails.Controls)
            {
                dxSizingDetail AField = (dxSizingDetail)C;

                if (AField.BeamNumber.Tag == null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into SW_Sizing_Details (SetNo,BeamNumber,BeamLength,Speed,Pressure,SizerID,Shift,GWeight,Remarks) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (AField.BeamNumber.EditValue != null)
                        queries[queries.Length - 1] += ",'" + AField.BeamNumber.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.BeamLength.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.BeamLength.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.BeamSpeed.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.BeamSpeed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Pressure.EditValue != null)
                        queries[queries.Length - 1] += "," + AField.Pressure.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Sizer.Tag != null)
                        if (AField.Sizer.ToString() != "")
                            queries[queries.Length - 1] += ",'" + AField.Sizer.Tag.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",null";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.Shift.EditValue != null)
                        queries[queries.Length - 1] += ",'" + AField.Shift.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                        queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (AField.Remarks.Text != "")
                        queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    queries[queries.Length - 1] += ")";
                }
                else
                {

                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_Sizing_Details set ";

                    if (AField.BeamNumber.EditValue != null)
                        queries[queries.Length - 1] += "BeamNumber='" + AField.BeamNumber.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += "BeamNumber=null";
                    if (AField.BeamLength.EditValue != null)
                        queries[queries.Length - 1] += ",BeamLength=" + AField.BeamLength.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",BeamLength=0";
                    if (AField.BeamSpeed.EditValue != null)
                        queries[queries.Length - 1] += ",Speed=" + AField.BeamSpeed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",Speed=0";
                    if (AField.Pressure.EditValue != null)
                        queries[queries.Length - 1] += ",Pressure=" + AField.Pressure.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",Pressure=0";
                    if (AField.Sizer.Tag != null)
                        if (AField.Sizer.ToString() != "")
                            queries[queries.Length - 1] += ",SizerID='" + AField.Sizer.Tag.ToString() + "'";
                        else
                            queries[queries.Length - 1] += ",SizerID=null";
                    else
                        queries[queries.Length - 1] += ",SizerID=null";
                    if (AField.Shift.EditValue != null)
                        queries[queries.Length - 1] += ",Shift='" + AField.Shift.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",Shift=null";
                    if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                        queries[queries.Length - 1] += ",GWeight=" + AField.GrossWeight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",GWeight=0";
                    if (AField.Remarks.Text != "")
                        queries[queries.Length - 1] += ",Remarks='" + AField.Remarks.Text + "'";
                    else
                        queries[queries.Length - 1] += ",Remarks=null";
                    queries[queries.Length - 1] += " where SetNo ='" + vnumtoupdate + "' and beamNumber='" + AField.BeamNumber.Tag.ToString() + "'";

                }

            }

            foreach (Control C in this.TableLayout_Chemicals.Controls)
            {
                UserControls.dxSizingChemicalConsumption AField = (UserControls.dxSizingChemicalConsumption)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Sizing_ChemicalsConsumption (SetNo,ChemicalID,cUnit,cUnitRate,QuantityConsumed,Batches,Remarks) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";

                if (AField.ChemicalID.EditValue != null && AField.ChemicalID.Tag != null)
                    queries[queries.Length - 1] += ",'" + AField.ChemicalID.Tag.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.cUnit.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.cUnit.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.cUnit.Tag != null)
                    queries[queries.Length - 1] += "," + AField.cUnit.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Quantity.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Quantity.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Batches.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Batches.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",1";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ")";

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
                    this.SetNo.EditValue = null;
                    this.SetNo.Tag = null;
                    this.Print.Tag = vnum;
                    this.Suffix.Text = "";
                    this.Remarks.Text = "";
                    this.Suffix.Tag = null;
                    this.WarpingProgramNumber.EditValue = null;
                    this.WarpingProgramNumber.Tag = null;
                    this.Breakages.EditValue = null;
                    this.TotalSizedBeams.EditValue = 0;
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Add(new UserControls.dxSizingChemicalConsumption());
                    SetButtonStates(UserInputMode.View);
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
            string ProgNumber = "";
            if (this.SetNoType.EditValue.ToString() == "0")
                ProgNumber = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            else
                ProgNumber = this.SetNo.Tag.ToString();

            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Sizing Program Number # " + ProgNumber + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_Details where SetNo='" + ProgNumber + "'";

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_ChemicalsConsumption where SetNO='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing where SetNO='" + ProgNumber + "'";
           
            if (this.WarpingProgramNumber.Tag != null)
            {
                if (this.WarpingProgramNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_Warping  set iStatus='U' where WarpingProgramNumber='" + this.WarpingProgramNumber.Tag.ToString() + "' ";
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
                    this.SetNo.Tag = null;
                    this.SetNo.EditValue = null;
                    this.Print.Tag = "";
                    this.Suffix.Tag = null;
                    this.Suffix.Text = "";
                    this.Suffix.Text = "";
                    this.Remarks.Text = "";
                    this.Suffix.Tag = null;
                    this.WarpingProgramNumber.EditValue = null;
                    this.WarpingProgramNumber.Tag = null;
                    this.Breakages.EditValue = null;
                    this.TotalSizedBeams.EditValue = 0;
                    this.tableLayoutPanel_SizingDetails.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Clear();
                    this.TableLayout_Chemicals.Controls.Add(new UserControls.dxSizingChemicalConsumption());
                    SetButtonStates(UserInputMode.View);

                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void WarpingProgramNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                string query="Select WarpingProgramNumber,ProgramSheetNumber,PartyName,WarpingProgramDate,NoofWarpBeams,EndsPerWarpBeam,LengthperWarpBeam,ArticleShortName from SWQ_Warping where iStatus='U' order by Convert(numeric(18,0),WarpingProgramNumber)";
                View.Load_View(query, "WarpingProgramNumber", "ProgramSheetNumber");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.WarpingProgramNumber.Tag = sRow.PrimeryID;
                    this.WarpingProgramNumber.Text = sRow.PrimeryID;
                    this.RefProgramSheetNumber.EditValue = sRow.PrimaryString;
                    try
                    {
                        this.RefParty.EditValue = sRow.SelectedDataRow["PartyName"].ToString();
                    }
                    catch
                    {
                    }
                   
                   
                }
            }
        }

        private void TotalSizedBeams_EditValueChanged(object sender, EventArgs e)
        {
            int totalbeams = 0;
            int.TryParse(TotalSizedBeams.EditValue.ToString(), out totalbeams);
            if(totalbeams<=20)
            LoadSizedBeams(totalbeams);
        }
        private void LoadSizedBeams( int totalbeams)
        {
            if (uiMode == UserInputMode.Edit)
            {
                int TotalSizedBeamsBeforeEditing = 0;
                if (this.TotalSizedBeams.Tag == null)
                {
                    XtraMessageBox.Show("invalid number of beams before editing", "Error", MessageBoxButtons.OK); return;

                }
                int.TryParse(this.TotalSizedBeams.Tag.ToString(), out TotalSizedBeamsBeforeEditing);
            DeleteBeams:
                foreach (Control c in this.tableLayoutPanel_SizingDetails.Controls)
                {
                    dxSizingDetail dxs = (dxSizingDetail)c;
                    if (dxs.BeamNumber.Tag == null)
                        this.tableLayoutPanel_SizingDetails.Controls.Remove(c);
                }
                if (this.tableLayoutPanel_SizingDetails.Controls.Count > TotalSizedBeamsBeforeEditing) goto DeleteBeams;
                for (int x = TotalSizedBeamsBeforeEditing; x < totalbeams; x++)
                {
                    dxSizingDetail dxs = new dxSizingDetail();
                    this.tableLayoutPanel_SizingDetails.Controls.Add(dxs);
                }
            }
            else
            {
                this.tableLayoutPanel_SizingDetails.Controls.Clear();
                for (int x = 0; x < totalbeams; x++)
                {
                    dxSizingDetail dxs = new dxSizingDetail();
                    this.tableLayoutPanel_SizingDetails.Controls.Add(dxs);
                }
            }
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

        private void SetNoType_EditValueChanged(object sender, EventArgs e)
        {
            if (this.SetNoType.EditValue.ToString() == "0")
            {
                this.Prefix.Enabled = true;
                this.Suffix.Enabled = true;
                this.FinancialYear.Enabled = true;
                this.SetNo.Enabled = false;
            }
            else
            {
                this.SetNo.Enabled = true;
                this.Prefix.Enabled = false;
                this.Suffix.Enabled = false;
                this.FinancialYear.Enabled = false;
            }
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void WarpingProgramNumber_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FilterWarpingProgramNumber_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SizingSummary_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag == null)
            {
                XtraMessageBox.Show("invalid Sizing summary", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.Print.Tag.ToString() == "")
            {
                XtraMessageBox.Show("invalid Sizing summary", "Error", MessageBoxButtons.OK);
                return;
            }
            MachineEyes.Classes.Printing.Print_SW_SizingSummary(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void RateperLbs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.xtraTabControl1.SelectedTabPage = this.xtraTabPage_Detail;

            }
        }

        private void Data_Sizing_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void Data_Sizing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && e.Control == true)
            {
                if (this.xtraTabControl1.SelectedTabPageIndex < (this.xtraTabControl1.TabPages.Count - 1))
                    this.xtraTabControl1.SelectedTabPageIndex++;
                else
                    this.xtraTabControl1.SelectedTabPageIndex = 0;
            }
            else if (e.KeyCode == Keys.Left && e.Control == true)
            {
                if (this.xtraTabControl1.SelectedTabPageIndex > 0)
                    this.xtraTabControl1.SelectedTabPageIndex--;
                else
                    this.xtraTabControl1.SelectedTabPageIndex = this.xtraTabControl1.TabPages.Count - 1;
            }
        }

      

        

    
        
        }


    }
