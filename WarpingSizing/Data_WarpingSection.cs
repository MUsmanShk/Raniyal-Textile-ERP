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
    public partial class Data_WarpingSection : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
       
        public Data_WarpingSection()
        {
            InitializeComponent();
            this.Prefix.Text = "105";
            G_Invoice = "105";
            N_Invoice = "115";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.WarpProgDate.DateTime = DateTime.Now;
        }
        
       
        
       
      
      
      
        private void SetButtonStates(UserInputMode input)
        {
            uiMode = input;
            switch (input)
            {
                case UserInputMode.View:
                    this.Add.Enabled = true;
                    this.CancelAction.Enabled = false;
                    this.CloseAction.Enabled = true;
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
                    this.CancelAction.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseAction.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                case UserInputMode.Edit:
                    
                    this.Add.Enabled = false;
                    this.CancelAction.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseAction.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                case UserInputMode.Delete:
                   
                    this.Add.Enabled = false;
                    this.CancelAction.Enabled = true;
                    this.Execute.Enabled = true;
                    this.Edit.Enabled = false;
                    this.CloseAction.Enabled = true;
                    this.View.Enabled = false;
                    this.Delete.Enabled = false;

                    break;
                default:
                    break;
            }
        }
       

    
     
       
     
        private void dxData_Warping_Load(object sender, EventArgs e)
        {
            this.WarpProgDate.DateTime = DateTime.Now;

            SetButtonStates(UserInputMode.View);
        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(WarpingProgramNumber,8,6)))+1 as MaxNumber  from SW_Warping where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'";
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
            this.RefProgramSheetNumber.Tag = null;
            this.RefProgramSheetNumber.Text = "";
           
            this.WarpMachineNumber.Tag = null;
            this.WarpMachineNumber.EditValue = null;
            this.EndsPerWarpBeam.EditValue = null;
            this.LengthPerBeam.EditValue = null;
            this.PartyID.Tag = null;
            this.PartyID.EditValue = null;
            this.Remarks.Text = "";
            this.Suffix.Text = "";
            this.TotalBeams.EditValue = null;
            this.TotalBreaks.EditValue = null;
            this.TotalCreels.EditValue = null;
            this.ArticleNumber.Tag = null;
            this.ArticleNumber.Text = "";
            this.FabricContractNumber.Tag = null;
            this.FabricContractNumber.Text = "";
            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarpingAfter());
            SetButtonStates(UserInputMode.View);





            bool rRes = GetNextInvoiceNumber();
            if (rRes != false)
                SetButtonStates(UserInputMode.Add);
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
            int esuffix = 0;
            if (Int32.TryParse(this.Suffix.Text, out esuffix) == false)
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
            if (this.Suffix.Text.Length != 6)
            {
                XtraMessageBox.Show("invalid sales invoice number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.RefProgramSheetNumber.Tag == null)
            {
                XtraMessageBox.Show("invalid Reference Program Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.WarpProgDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }
            if (this.WarpProgDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }
            if (this.WarpProgDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }

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
                    XtraMessageBox.Show("Invalid Shift in beams details", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }





            }
            string[] queries = new string[0];
            string vnumtoupdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (vnum.Length != 13)
            {
                XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarpingAfter AField = (UserControls.dxYarnWarpingAfter)C;

                if (AField.BagsType.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Sub Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.BagsType.Focus();
                    return;
                }

                if (AField.Counts.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }



                if (AField.Blends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Blend ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.Brand.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Brand ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (AField.Desc.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Desc ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.BagsReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Bags Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Cones Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.LbsReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Lbs Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.EmptyBagsWeight.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Empty Bag Weight ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.EmptyConesWeight.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Empty cone Weight ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.BagsFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Full Bags of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.BagsHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Full Bags of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid number of cones of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid number of cones of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.KgFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Weight of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.KgHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Weight of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

            }
            string OutsideProgramNumber = outSideSetProgram.Text;
            if (this.RefProgramSheetNumber.Tag != null)
            {
                if (RefProgramSheetNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_ProgramSheet  set iStatus='P' where WarpProgNumber='" + this.RefProgramSheetNumber.Text + "' ";
                }
            }
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Warping_YarnConsumption where WarpingProgramNumber='"+vnumtoupdate+"' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_Details where SetNo='" + vnumtoupdate + "' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing where SetNo='" + vnumtoupdate + "' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update SW_Warping set ";
            queries[queries.Length - 1] += " WarpTypeID='" + RadioWarpType.EditValue.ToString() + "',WarpingProgramNumber='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
           
            if (this.RefProgramSheetNumber.EditValue != null)
                queries[queries.Length - 1] += ",ProgramSheetNumber='" + this.RefProgramSheetNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ProgramSheetNumber=null";
            if (OutsideProgramNumber != "")
                queries[queries.Length - 1] += ",OutSideProgramNumber='" + OutsideProgramNumber + "'";
            else
                queries[queries.Length - 1] += ",OutSideProgramNumber=null";
            
            if (this.PartyID.Tag != null)
                queries[queries.Length - 1] += ",PartyID='" + this.PartyID.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",PartyID=null";
            if (this.WarpMachineNumber.Tag != null)
                queries[queries.Length - 1] += ",WarpingMachineNumber='" + this.WarpMachineNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",WarpingMachineNumber=null";
            if (this.WarpProgDate.EditValue != null)
                queries[queries.Length - 1] += ",WarpingProgramDate='" + this.WarpProgDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",WarpingProgramDate=null";
            //NoofCreels,NoofWarpBeams,EndsperWarpBeam,lengthperWarpBeam,TotalBreaks,Remarks) 
            if (this.TotalCreels.EditValue != null)
                queries[queries.Length - 1] += ",NoofCreels=" + this.TotalCreels.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",NoofCreels=0";

            if (this.TotalBeams.EditValue != null)
                queries[queries.Length - 1] += ",NoofWarpBeams=" + this.TotalBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",NoofWarpBeams=0";
            if (this.EndsPerWarpBeam.EditValue != null)
                queries[queries.Length - 1] += ",EndsPerWarpBeam=" + this.EndsPerWarpBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",EndsPerWarpBeam=0";
            if (this.LengthPerBeam.EditValue != null)
                queries[queries.Length - 1] += ",LengthPerWarpBeam=" + this.LengthPerBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",LengthPerWarpBeam=0";
            if (this.TotalBreaks.EditValue != null)
                queries[queries.Length - 1] += ",TotalBreaks=" + this.TotalBreaks.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",TotalBreaks=0";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",remarks='" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",remarks=null";
            if (this.ArticleNumber.Tag != null)
                queries[queries.Length - 1] += ",ArticleNumber='" + this.ArticleNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ArticleNumber=null";
            if (this.FabricContractNumber.Tag != null)
                queries[queries.Length - 1] += ",FCC='" + this.FabricContractNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",FCC=null";
            queries[queries.Length - 1] += ",EUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',EUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where WarpingProgramNumber='"+vnumtoupdate+"'";



            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarpingAfter AField = (UserControls.dxYarnWarpingAfter)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Warping_YarnConsumption (WarpingProgramNumber,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsReceived,ConesReceived,LbsReceived,FullConesBags,HalfConesBags,FullConesTotal,HalfConesTotal,FullConesKg,HalfConesKg,EachEmptyBagWeight,EachEmptyConesWeight,NetWeightConsumed,ActualWarpCount,Ends,EnglishCount) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";

                if (AField.BagsType.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.BagsType.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ConesPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.ConesPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.LbsPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.LbsPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Counts.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Counts.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Ply.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Ply.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Blends.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Blends.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Brand.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Brand.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Desc.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Desc.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";


                if (AField.BagsReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.LbsReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.LbsReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BagsFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BagsHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.KgFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.KgFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.KgHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.KgHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EmptyBagsWeight.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.EmptyBagsWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EmptyConesWeight.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.EmptyConesWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.CalcNetLbsConsumed.Tag != null)
                    queries[queries.Length - 1] += "," + AField.CalcNetLbsConsumed.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.WarpCount.Tag != null)
                    queries[queries.Length - 1] += "," + AField.WarpCount.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Ends.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Ends.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EnglishCount!=0)
                    queries[queries.Length - 1] += "," + AField.GetEnglishCount().ToString() + "";
                else
                    queries[queries.Length - 1] += ",1";
                queries[queries.Length - 1] += ")";



            }
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into SW_Sizing (SizingTypeID,SetNo,iType,iCat,iYear,iStatus,WarpingProgramNumber,SizingMachineID,Breakages,SizingDate,TotalSizedBeams,Ends,Starttime,EndTime,Remarks,cUserId,CuserTime) Values (";
            queries[queries.Length - 1] += "'2','" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "','U'";

            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",0";

            if (this.WarpProgDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.WarpProgDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.TotalBeams.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.EndsPerWarpBeam.EditValue != null)
                queries[queries.Length - 1] += "," + this.EndsPerWarpBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null";

            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



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
                if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                    queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",1)";

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
                    this.RefProgramSheetNumber.Tag = null;
                    this.RefProgramSheetNumber.Text = "";
                    
                    this.WarpMachineNumber.Tag = null;
                    this.WarpMachineNumber.EditValue = null;
                    this.EndsPerWarpBeam.EditValue = null;
                    this.LengthPerBeam.EditValue = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.Remarks.Text = "";
                    this.Suffix.Text = "";
                    this.TotalBeams.EditValue = null;
                    this.TotalBreaks.EditValue = null;
                    this.TotalCreels.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.ArticleNumber.Text = "";
                    this.outSideSetProgram.Text = "";
                    this.FabricContractNumber.Tag = null;
                    this.FabricContractNumber.Text = "";
                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarpingAfter());
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void DeleteExisting()
        {






            string[] queries = new string[0];
            string ProgNumber = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete Program Number # " + ProgNumber + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Warping_YarnConsumption where WarpingProgramNumber='" + ProgNumber + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing_Details where SetNo='" + ProgNumber + "' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Sizing where SetNo='" + ProgNumber + "' ";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from SW_Warping where WarpingProgramNumber='" + ProgNumber + "'";
            
            if (this.RefProgramSheetNumber.Tag != null)
            {
                if (RefProgramSheetNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_ProgramSheet  set iStatus='U' where WarpProgNumber='" + this.RefProgramSheetNumber.Tag.ToString() + "' ";
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

                    this.Print.Tag = "";
                    this.Suffix.Tag = null;
                    this.Suffix.Text = "";
                    this.RefProgramSheetNumber.Tag = null;
                    this.RefProgramSheetNumber.Text = "";
                
                    this.WarpMachineNumber.Tag = null;
                    this.WarpMachineNumber.EditValue = null;
                    this.EndsPerWarpBeam.EditValue = null;
                    this.LengthPerBeam.EditValue = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.Remarks.Text = "";
                    this.Suffix.Text = "";
                    this.TotalBeams.EditValue = null;
                    this.TotalBreaks.EditValue = null;
                    this.TotalCreels.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.ArticleNumber.Text = "";
                    this.FabricContractNumber.Tag = null;
                    this.FabricContractNumber.Text = "";
                    this.outSideSetProgram.Text = "";
                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarpingAfter());
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Delete_Click(object sender, EventArgs e)
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

        private void CancelAction_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void CloseAction_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (this.RefProgramSheetNumber.Tag == null)
            {
                XtraMessageBox.Show("invalid Reference Program Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          
            if (this.WarpProgDate.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }
            if (this.WarpProgDate.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }
            if (this.WarpProgDate.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.WarpProgDate.Focus();
                return;
            }
           
         
           
          


            string[] queries = new string[0];
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (vnum.Length != 13)
            {
                XtraMessageBox.Show("Voucher number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarpingAfter AField = (UserControls.dxYarnWarpingAfter)C;

                if (AField.BagsType.EditValue==null)
                {
                    XtraMessageBox.Show("Invalid Sub Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.BagsType.Focus();
                    return;
                }
                if (AField.Ends.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Ends", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    AField.Ends.Focus();
                    return;
                }
                if (AField.Counts.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               return;
                }

               

                if (AField.Blends.EditValue==null)
                {
                    XtraMessageBox.Show("Invalid Yarn Blend ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
                    return;
                }
                if (AField.Brand.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Brand ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                       return;
                }

                if (AField.Desc.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Desc ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 
                    return;
                }
                if (AField.BagsReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Bags Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Cones Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.LbsReceived.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Lbs Received ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.EmptyBagsWeight.EditValue ==null)
                {
                    XtraMessageBox.Show("Invalid Empty Bag Weight ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.EmptyConesWeight.EditValue ==null)
                {
                    XtraMessageBox.Show("Invalid Empty cone Weight ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.BagsFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Full Bags of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.BagsHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Full Bags of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid number of cones of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.ConesHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid number of cones of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.KgFullCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Weight of Full Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
                if (AField.KgHalfCones.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Weight of Half Cones ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }

            }
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
                    XtraMessageBox.Show("Invalid Shift in beams details", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }





            }
            string OutsideProgramNumber = this.outSideSetProgram.Text;
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into SW_Warping (WarpTypeID,WarpingProgramNumber,iType,iCat,iYear,iStatus,ProgramSheetNumber,OutSideProgramNumber,PartyID,WarpingMachineNumber,WarpingProgramDate,NoofCreels,NoofWarpBeams,EndsperWarpBeam,lengthperWarpBeam,TotalBreaks,Remarks,ArticleNumber,FCC,cUserID,cUserTime) Values (";
            queries[queries.Length - 1] += "'"+RadioWarpType.EditValue.ToString()+"','" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";

            if (this.RefProgramSheetNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.RefProgramSheetNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (OutsideProgramNumber != "")
                queries[queries.Length - 1] += ",'" + OutsideProgramNumber + "'";
            else
                queries[queries.Length - 1] += ",null";
           
            if (this.PartyID.Tag != null)
                queries[queries.Length - 1] += ",'" + this.PartyID.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.WarpMachineNumber.Tag != null)
                queries[queries.Length - 1] += ",'" + this.WarpMachineNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.WarpProgDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.WarpProgDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            //NoofCreels,NoofWarpBeams,EndsperWarpBeam,lengthperWarpBeam,TotalBreaks,Remarks) 
            if (this.TotalCreels.EditValue!=null)
                queries[queries.Length - 1] += "," + this.TotalCreels.EditValue.ToString()+ "";
            else
                queries[queries.Length - 1] += ",0";

            if (this.TotalBeams.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.EndsPerWarpBeam.EditValue != null)
                queries[queries.Length - 1] += "," + this.EndsPerWarpBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.LengthPerBeam.EditValue != null)
                queries[queries.Length - 1] += "," + this.LengthPerBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.TotalBreaks.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalBreaks.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ArticleNumber.Tag != null)
                queries[queries.Length - 1] += ",'" + this.ArticleNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.FabricContractNumber.Tag != null)
                queries[queries.Length - 1] += ",'" + this.FabricContractNumber.Tag.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";

            if (this.RefProgramSheetNumber.Tag != null)
            {
                if (RefProgramSheetNumber.Text != "")
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "update SW_ProgramSheet  set iStatus='P' where WarpProgNumber='" + this.RefProgramSheetNumber.Text + "' ";
                }
            }

            foreach (Control C in this.tableLayoutPanel_YarnInfo.Controls)
            {
                UserControls.dxYarnWarpingAfter AField = (UserControls.dxYarnWarpingAfter)C;
                Array.Resize(ref queries, queries.Length + 1);

                queries[queries.Length - 1] = "insert into SW_Warping_YarnConsumption (WarpingProgramNumber,YarnBagsType,YarnConesPerBag,YarnLbsPerBag,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,BagsReceived,ConesReceived,LbsReceived,FullConesBags,HalfConesBags,FullConesTotal,HalfConesTotal,FullConesKg,HalfConesKg,EachEmptyBagWeight,EachEmptyConesWeight,NetWeightConsumed,ActualWarpCount,Ends,EnglishCount) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
               
                if (AField.BagsType.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.BagsType.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.ConesPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.ConesPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (AField.LbsPerBag.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.LbsPerBag.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Counts.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Counts.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Ply.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Ply.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Blends.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Blends.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Brand.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Brand.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (AField.Desc.EditValue != null)
                    queries[queries.Length - 1] += ",'" + AField.Desc.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
               

                if (AField.BagsReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.LbsReceived.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.LbsReceived.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BagsFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.BagsHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.BagsHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.ConesHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.ConesHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.KgFullCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.KgFullCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.KgHalfCones.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.KgHalfCones.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EmptyBagsWeight.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.EmptyBagsWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EmptyConesWeight.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.EmptyConesWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.CalcNetLbsConsumed.Tag != null)
                    queries[queries.Length - 1] += "," + AField.CalcNetLbsConsumed.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.WarpCount.Tag != null)
                    queries[queries.Length - 1] += "," + AField.WarpCount.Tag.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Ends.EditValue != null)
                    queries[queries.Length - 1] += "," + AField.Ends.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.EnglishCount != 0)
                    queries[queries.Length - 1] += "," + AField.GetEnglishCount().ToString() + "";
                else
                    queries[queries.Length - 1] += ",1";
                queries[queries.Length - 1] += ")";
               

               
            }

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into SW_Sizing (SizingTypeID,SetNo,iType,iCat,iYear,iStatus,WarpingProgramNumber,SizingMachineID,Breakages,SizingDate,TotalSizedBeams,Ends,Starttime,EndTime,Remarks,cUserId,CuserTime) Values (";
            queries[queries.Length - 1] += "'2','" + vnum + "','"+this.Prefix.Text +"','"+vCat+"','" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "','U'";

            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",0";

            if (this.WarpProgDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.WarpProgDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.TotalBeams.EditValue != null)
                queries[queries.Length - 1] += "," + this.TotalBeams.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.EndsPerWarpBeam.EditValue != null)
                queries[queries.Length - 1] += "," + this.EndsPerWarpBeam.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",0";
            queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",null";

            if (this.Remarks.Text != "")
                queries[queries.Length - 1] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



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
                if (AField.GrossWeight.EditValue != null && AField.GrossWeight.Text != "")
                    queries[queries.Length - 1] += "," + AField.GrossWeight.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (AField.Remarks.Text != "")
                    queries[queries.Length - 1] += ",'" + AField.Remarks.Text + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",1)";

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
                    this.RefProgramSheetNumber.Tag = null;
                    this.RefProgramSheetNumber.Text = "";
                
                    this.WarpMachineNumber.Tag = null;
                    this.WarpMachineNumber.EditValue = null;
                    this.EndsPerWarpBeam.EditValue = null;
                    this.LengthPerBeam.EditValue = null;
                    this.PartyID.Tag = null;
                    this.PartyID.EditValue = null;
                    this.Remarks.Text = "";
                    this.Suffix.Text = "";
                    this.TotalBeams.EditValue = null;
                    this.TotalBreaks.EditValue = null;
                    this.TotalCreels.EditValue = null;
                    this.ArticleNumber.Tag = null;
                    this.ArticleNumber.Text = "";
                    this.FabricContractNumber.Tag = null;
                    this.FabricContractNumber.Text = "";
                    this.outSideSetProgram.Text = "";
                    this.tableLayoutPanel_YarnInfo.Controls.Clear();
                    this.tableLayoutPanel_YarnInfo.Controls.Add(new UserControls.dxYarnWarpingAfter());
                    SetButtonStates(UserInputMode.View);
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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

        private void xtraTabPage_General_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefProgramSheetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if ( this.RadioWarpType.EditValue.ToString()=="0" &&  e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select WarpProgNumber,ProgramDate,BeamType,BeamSpace,BeamLength,NoofBeams,PartyID,AccountName,ArticleNumber,ArticleShortName from SWQ_ProgramSheet where iStatus='U' order by Convert(numeric(18,0),WarpProgNumber)", "WarpProgNumber", "WarpProgNumber");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.RefProgramSheetNumber.Tag = sRow.PrimeryID;
                    this.RefProgramSheetNumber.Text = sRow.PrimeryID;

                    FillProgrambyRefProgramSheet(sRow.PrimeryID);
                    try
                    {
                    }
                    catch 
                    {
                    }
                }
            }
        }


        private void FillProgrambyRefProgramSheet(string ProgramSheetNumber)
        {
            try
            {
                DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from SWQ_ProgramSheet where WarpProgNumber='" + ProgramSheetNumber + "'");
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


                this.PartyID.Tag = ds_VoucherMain.Tables[0].Rows[0]["PartyID"].ToString();
                this.PartyID.Text = ds_VoucherMain.Tables[0].Rows[0]["AccountName"].ToString();
                this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
               
                if(ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString()!="")
                this.ArticleNumber.Tag =ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString();
                else
                    this.ArticleNumber.Tag =null;

                if (ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString() != "")
                    this.ArticleNumber.EditValue = ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString();
                else
                    this.ArticleNumber.EditValue = null;



                DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SW_ProgramSheet_Sub where WarpProgNumber='" + ProgramSheetNumber + "'");
                if (ds_VoucherSub_T == null) return;
                this.tableLayoutPanel_YarnInfo.Controls.Clear();
                for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
                {
                    UserControls.dxYarnWarpingAfter ysub = new UserControls.dxYarnWarpingAfter();

                    this.tableLayoutPanel_YarnInfo.Controls.Add(ysub);
                    ysub.BagsType.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBagsType"].ToString();
                    ysub.Counts.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnCount"].ToString();
                    ysub.Blends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBlend"].ToString();
                    ysub.Ply.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnPly"].ToString();
                    ysub.Desc.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnDesc"].ToString();
                    ysub.Brand.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBrand"].ToString();
                    ysub.LbsPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnLbsperBag"].ToString();
                    ysub.ConesPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnConesPerBag"].ToString();
                    ysub.BagsReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Bags"].ToString();
                    ysub.LbsReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Lbs"].ToString();
                    ysub.ConesReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Cones"].ToString();
                    ysub.Ends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Ends"].ToString();


                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.Check_WarpProgramDate.Checked == true)
            {
                if (this.WarpProgDate.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
           
            if (this.Check_RefProgramNumber.Checked == true)
            {
                if (this.RefProgramSheetNumber.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Program Number filter or enter valid Program Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Check_WarpingProgramNumber.Checked == true)
            {
                if (this.Suffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Program Number filter or enter valid Program Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Check_EndsPerWarpBeam.Checked == true)
            {
                if (this.EndsPerWarpBeam.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Ends/Warp Beam filter or enter valid Ends / Warp Beam", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            if (this.Check_PartyID.Checked == true)
            {
                if (this.PartyID.Tag == null)
                {
                    XtraMessageBox.Show("Either uncheck the Party filter or enter valid Article", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.PartyID.Tag.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Party filter or enter valid Article Number", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            
           
            if (this.Check_LengthPerWarpBeam.Checked == true)
            {
                if (this.LengthPerBeam.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Warping Company filter or enter valid Warping Company", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.LengthPerBeam.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Either uncheck the Warping Company filter or enter valid Warping Company", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            



            strFilterQuery = "SELECT WarpingProgramNumber,WarpingProgramDate,PartyName,EndsPerWarpBeam,LengthPerWarpBeam  FROM SWQ_Warping  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + FinancialYear.Text + "' and iCAT='" + this.NG.Tag.ToString() + "' ";



            if (this.Check_WarpProgramDate.Checked == true)
            {

                strFilterQuery += " and WarpingProgramDate='" + this.WarpProgDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }
           
            if (this.Check_WarpingProgramNumber.Checked == true)
            {

                strFilterQuery += " and WarpingProgramNumber like '%" + this.Suffix.Text + "'%";

            }

            if (this.Check_WarpingMachineNumber.Checked == true)
            {

                strFilterQuery += " and WarpingMachineNumber='" + this.WarpMachineNumber.Tag.ToString() + "'";

            }
            if (this.Check_PartyID.Checked == true)
            {

                strFilterQuery += " and PartyID='" + this.PartyID.Tag.ToString() + "'";

            }
            if (this.Check_LengthPerWarpBeam.Checked == true)
            {

                strFilterQuery += " and LengthPerWarpBeam=" + this.LengthPerBeam.EditValue.ToString() + "";

            }
            if (this.Check_RefProgramNumber.Checked == true)
            {

                strFilterQuery += " and ProgramSheetNumber='" + this.RefProgramSheetNumber.EditValue.ToString() + "'";

            }
          
            if (this.Check_EndsPerWarpBeam.Checked == true)
            {

                strFilterQuery += " and EndsPerWarpBeam=" + this.EndsPerWarpBeam.EditValue.ToString() + "";

            }

           
            strFilterQuery += " ORDER BY Convert(numeric(18),WarpingProgramNumber) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "WarpingProgramNumber", "WarpingProgramNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_WarpingSheet(sRow.PrimeryID);

            }
        }
        private void Fill_WarpingSheet(string WarpingProgramNumber)
        {

            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from SWQ_Warping where WarpingProgramNumber='" + WarpingProgramNumber + "'");
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
            this.Print.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString();
            this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString().Substring(7, 6);
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString().Substring(7, 6); ;
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["iType"].ToString();
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["iYear"].ToString();
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramNumber"].ToString().Substring(0, 3);
            this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
            if (ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString() != "")
                this.ArticleNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["ArticleNumber"].ToString();
            else
                this.ArticleNumber.Tag = null;

            this.RadioWarpType.EditValue = ds_VoucherMain.Tables[0].Rows[0]["WarpTypeID"].ToString();
            this.ArticleNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["ArticleShortName"].ToString();
            this.FabricContractNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["FCC"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["FCC"].ToString() != "")
                this.FabricContractNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["FCC"].ToString();
            else
                this.FabricContractNumber.Tag = null;
            if (ds_VoucherMain.Tables[0].Rows[0]["PartyID"].ToString() != "")
                this.PartyID.Tag = ds_VoucherMain.Tables[0].Rows[0]["PartyID"].ToString();
            else
                this.PartyID.Tag = null;
            this.PartyID.Text = ds_VoucherMain.Tables[0].Rows[0]["PartyName"].ToString();
            this.Remarks.Text = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
           
            if (ds_VoucherMain.Tables[0].Rows[0]["ProgramSheetNumber"].ToString() != "")
                this.RefProgramSheetNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["ProgramSheetNumber"].ToString();
            else
                this.RefProgramSheetNumber.Tag = null;
            this.RefProgramSheetNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["ProgramSheetNumber"].ToString();
            this.TotalBeams.EditValue = ds_VoucherMain.Tables[0].Rows[0]["NoofWarpBeams"].ToString();
            this.TotalBreaks.EditValue = ds_VoucherMain.Tables[0].Rows[0]["TotalBreaks"].ToString();
            this.TotalCreels.EditValue = ds_VoucherMain.Tables[0].Rows[0]["NoofCreels"].ToString();
            this.EndsPerWarpBeam.EditValue = ds_VoucherMain.Tables[0].Rows[0]["EndsPerWarpBeam"].ToString();
            this.LengthPerBeam.EditValue = ds_VoucherMain.Tables[0].Rows[0]["LengthPerWarpBeam"].ToString();
            int LengthPerWarpBeam = 0, totalWarpBeams = 1, TotalWarpBeamLength = 0; int TotalEndsofWarpBeams = 0;
            if(this.EndsPerWarpBeam.EditValue!=null)
            int.TryParse(this.EndsPerWarpBeam.EditValue.ToString(), out TotalEndsofWarpBeams);
            
            int.TryParse(ds_VoucherMain.Tables[0].Rows[0]["LengthPerWarpBeam"].ToString(), out LengthPerWarpBeam);
            int.TryParse(ds_VoucherMain.Tables[0].Rows[0]["NoofWarpBeams"].ToString(), out totalWarpBeams);
            TotalWarpBeamLength = totalWarpBeams * LengthPerWarpBeam;
            TotalEndsofWarpBeams = TotalEndsofWarpBeams * totalWarpBeams;
            if (ds_VoucherMain.Tables[0].Rows[0]["WarpingMachineNumber"].ToString() != "")
                this.WarpMachineNumber.Tag = ds_VoucherMain.Tables[0].Rows[0]["WarpingMachineNumber"].ToString();
            else
                this.WarpMachineNumber.Tag = null;
            this.WarpMachineNumber.Text = ds_VoucherMain.Tables[0].Rows[0]["WarpMachineDesc"].ToString();
            this.outSideSetProgram.Text= ds_VoucherMain.Tables[0].Rows[0]["OutSideProgramNumber"].ToString();
            try
            {
                this.WarpProgDate.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["WarpingProgramDate"].ToString(), System.Globalization.CultureInfo.CurrentCulture);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

           



            DataSet ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SW_Warping_YarnConsumption where WarpingProgramNumber='" + WarpingProgramNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_YarnInfo.Controls.Clear();
            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                UserControls.dxYarnWarpingAfter ysub = new UserControls.dxYarnWarpingAfter();

                this.tableLayoutPanel_YarnInfo.Controls.Add(ysub);
                ysub.BagsType.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBagsType"].ToString();
                ysub.Counts.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnCount"].ToString();
                ysub.Blends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBlend"].ToString();
                ysub.Ply.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnPly"].ToString();
                ysub.Desc.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnDesc"].ToString();
                ysub.Brand.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnBrand"].ToString();
                ysub.LbsPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnLbsperBag"].ToString();
                ysub.ConesPerBag.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["YarnConesPerBag"].ToString();
                ysub.BagsReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BagsReceived"].ToString();
                ysub.LbsReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["LbsReceived"].ToString();
                ysub.ConesReceived.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["ConesReceived"].ToString();
                ysub.Ends.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Ends"].ToString();

                ysub.BagsFullCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["FullConesBags"].ToString();
                ysub.BagsHalfCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["HalfConesBags"].ToString();
                ysub.ConesFullCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["FullConesTotal"].ToString();
                ysub.ConesHalfCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["HalfConesTotal"].ToString();
                ysub.KgFullCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["FullConesKg"].ToString();
                ysub.KgHalfCones.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["HalfConesKg"].ToString();
                ysub.EmptyBagsWeight.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["EachEmptyBagWeight"].ToString();
                ysub.EmptyConesWeight.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["EachEmptyConesWeight"].ToString();
                ysub.Length = LengthPerWarpBeam;
                ysub.EndsTotalWarpBeams = TotalEndsofWarpBeams;
                ysub.CalculateNetWeightConsumed();
            }
            ds_VoucherSub_T = WS.svc.Get_DataSet("select * from SWQ_Sizing_Details where Setno='" + WarpingProgramNumber + "'");
            if (ds_VoucherSub_T == null) return;
            this.tableLayoutPanel_SizingDetails.Controls.Clear();

            for (int x = 0; x < ds_VoucherSub_T.Tables[0].Rows.Count; x++)
            {
                dxSizingDetail ysub = new dxSizingDetail();
                this.tableLayoutPanel_SizingDetails.Controls.Add(ysub);


                ysub.GrossWeight.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["GWeight"].ToString();
                ysub.BeamLength.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["BeamLength"].ToString();
                ysub.BeamSpeed.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Speed"].ToString();
                ysub.Pressure.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Pressure"].ToString();
                ysub.Remarks.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Remarks"].ToString();

                ysub.BeamNumber.EditValue = ds_VoucherSub_T.Tables[0].Rows[x]["Beamnumber"].ToString();
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

            this.Edit.Enabled = true;
            this.Delete.Enabled = true;

        }

        private void PartyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select AccountID,AccountName,MailingAddress from PP_Accounts order by AccountName", "AccountID", "AccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.PartyID.Tag = sRow.PrimeryID;
                    this.PartyID.EditValue = sRow.PrimaryString;

                }
            }
        }

      

        private void WarpMachineNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select WarpMachineNumber,CreelCapacity,Make,WarpMachineDesc from SW_WarpingMachines", "WarpMachineNumber", "WarpMachineDesc");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.WarpMachineNumber.Tag = sRow.PrimeryID;
                    this.WarpMachineNumber.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select ArticleNumber,ArticleShortName from PP_Article order by ArticleNumber", "ArticleNumber", "ArticleShortName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.ArticleNumber.Tag = sRow.PrimeryID;
                    this.ArticleNumber.EditValue = sRow.PrimaryString;

                }
            }
        }

        private void LengthPerBeam_EditValueChanged(object sender, EventArgs e)
        {

            CalculateLengthTotal();
            
        }


        private void CalculateLengthTotal()
        {
            try
            {
                int iLengthPerBeam = 0;
                int iNoofBeams = 1;
                int iEndsperWarpBeam = 0;
                if (EndsPerWarpBeam.EditValue != null)
                    int.TryParse(this.EndsPerWarpBeam.EditValue.ToString(), out iEndsperWarpBeam);
                if (LengthPerBeam.EditValue != null)
                    int.TryParse(LengthPerBeam.EditValue.ToString(), out iLengthPerBeam);
                if (TotalBeams.EditValue != null)
                    int.TryParse(TotalBeams.EditValue.ToString(), out iNoofBeams);
                else
                    iNoofBeams = 1;

                foreach (Control c in this.tableLayoutPanel_YarnInfo.Controls)
                {
                    UserControls.dxYarnWarpingAfter dyW = (UserControls.dxYarnWarpingAfter)c;
                    dyW.Length = iLengthPerBeam;
                    dyW.EndsTotalWarpBeams = iEndsperWarpBeam * iNoofBeams;
                    dyW.CalculateNetWeightConsumed();
                }
            }
            catch
            {
            }
        }

        private void TotalBeams_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLengthTotal();
            int noofbeams = 0;
            if (TotalBeams.EditValue != null)
                int.TryParse(this.TotalBeams.EditValue.ToString(), out noofbeams);
            if (noofbeams > 20)
            {
                XtraMessageBox.Show("Invalid # of Warped Beams", "Error", MessageBoxButtons.OK);
                return;
            }
            LoadSizedBeams(noofbeams);
        }
        private void LoadSizedBeams(int totalbeams)
        {
            this.tableLayoutPanel_SizingDetails.Controls.Clear();
            for (int x = 0; x < totalbeams; x++)
            {
                dxSizingDetail dxs = new dxSizingDetail();
                this.tableLayoutPanel_SizingDetails.Controls.Add(dxs);
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
            MachineEyes.Classes.Printing.Print_SW_WarpingSheetSection(this.Print.Tag.ToString(), this.RadioPageSetting.EditValue.ToString());
        }

        private void xtraTabControl_Warping_Click(object sender, EventArgs e)
        {

        }

        

        

    

        

        
    }
}