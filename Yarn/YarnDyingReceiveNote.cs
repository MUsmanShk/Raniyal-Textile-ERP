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
    public partial class YarnDyingReceiveNote: DevExpress.XtraEditors.XtraForm
    {
        
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiModeVoucher;
        UserInputMode uiModeDetail;
        private string G_Number;
        private string N_Number;
        DataRow GridAccountRow;
               
        public YarnDyingReceiveNote()
        {
            InitializeComponent();
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.Dated.DateTime = DateTime.Now;

           G_Number = "107";
            N_Number = "117";

            this.Prefix.Text = G_Number;
            FetchGridDataSet("XXXXXXXX");

        }
     
        private void AddToGridValues()
        {
            if (uiModeVoucher != UserInputMode.Add && uiModeVoucher != UserInputMode.Edit && uiModeVoucher != UserInputMode.Delete)
            {
                XtraMessageBox.Show("can not add while voucher is not in add , edit or delete mode!", "Error");
                return;
            }
           
            if (this.GeneralAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Account ID", "Error");
                this.GeneralAccountID.Focus();
                return;
            }
           
           
            if (this.PONO.EditValue == null )
            {
                XtraMessageBox.Show("Invalid PONO", "Error");
                this.PONO.Focus();
                return;
            }

            if (this.DyingAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Issue to Account", "Error");
                this.DyingAccountID.Focus();
                return;
            }
           
            if (this.Counts.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Count", "Error");
                this.Counts.Focus();
                return;
            }
            if (this.Ply.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Ply", "Error");
                this.Ply.Focus();
                return;
            }
            if (this.Brand.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Brand", "Error");
                this.Brand.Focus();
                return;
            }
            if (this.Blends.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Blend", "Error");
                this.Blends.Focus();
                return;
            }
            if (this.Desc.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Description", "Error");
                this.Desc.Focus();
                return;
            }
            if (this.BagsType.EditValue == null)
            {
                XtraMessageBox.Show("Invalid BagsType", "Error");
                this.PONO.Focus();
                return;
            }
            if (this.Bags.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Bags", "Error");
                this.Bags.Focus();
                return;
            }
            if (this.Cones.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Cones", "Error");
                this.Cones.Focus();
                return;
            }
            if (this.Lbs.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Lbs", "Error");
                this.Lbs.Focus();
                return;
            }
            if (DyingAccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Dying Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DyingAccountID.Focus();
                return;

            }
            if (this.DyingAccountName.EditValue == null)
            {
                XtraMessageBox.Show("invalid Dying Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DyingAccountID.Focus();
                return;

            }
            if (this.DyingWorkOrderNumber.EditValue == null)
            {
                XtraMessageBox.Show("invalid Dying Work Order # ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DyingWorkOrderNumber.Focus();
                return;

            }
            string[] queries = new string[0];
           



            try
            {



                 

                    DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
                    if (gdv == null)
                    {
                        XtraMessageBox.Show("Invalid Grid Binding", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DataTable gdt = gdv.Table;
                    DataRow _ravi = gdt.NewRow();
                    _ravi["BuyerID"] = this.GeneralAccountID.EditValue.ToString();
                    if (this.GeneralAccountID.EditValue != null) _ravi["BuyerName"] = this.GeneralAccountID.Text;
                    if (this.PONO.EditValue != null) _ravi["PONO"] = this.PONO.EditValue.ToString();
                    if (this.LotNo.EditValue != null) _ravi["LotNo"] = this.LotNo.EditValue.ToString();
                    if (this.SetNo.EditValue != null) _ravi["SetNo"] = this.SetNo.EditValue.ToString();
                    if (this.Counts.EditValue != null) _ravi["YarnCount"] = this.Counts.EditValue.ToString();
                    if (this.Ply.EditValue != null) _ravi["YarnPly"] = this.Ply.EditValue.ToString();
                    if (this.Brand.EditValue != null) _ravi["YarnBrand"] = this.Brand.EditValue.ToString();
                    if (this.Blends.EditValue != null) _ravi["YarnBlend"] = this.Blends.EditValue.ToString();
                    if (this.Desc.EditValue != null) _ravi["YarnDesc"] = this.Desc.EditValue.ToString();
                    if (this.Color.EditValue != null) _ravi["YarnColor"] = this.Color.EditValue.ToString();
                    if (this.LbsPerBag.EditValue != null) _ravi["YarnLbsPerBag"] = this.LbsPerBag.EditValue.ToString();
                    if (this.ConesPerBag.EditValue != null) _ravi["YarnConesPerBag"] = this.ConesPerBag.EditValue.ToString();
                    if (this.Bags.EditValue != null) _ravi["BagsInward"] = this.Bags.EditValue.ToString();
                    if (this.Lbs.EditValue != null) _ravi["LbsInward"] = this.Lbs.EditValue.ToString();
                    if (this.Cones.EditValue != null) _ravi["ConesInward"] = this.Cones.EditValue.ToString();
                    if (this.BagsType.EditValue != null) _ravi["YarnBagsType"] = this.BagsType.EditValue.ToString();
                    if (this.DyingWorkOrderNumber.EditValue != null) _ravi["REFPONO"] = this.DyingWorkOrderNumber.EditValue.ToString();
                    _ravi["isClosed"] = "0";
                    if (this.GodownID.EditValue != null) _ravi["GodownID"] = this.GodownID.EditValue.ToString();
                    gdt.Rows.Add(_ravi);
                 
                    
                  
                    
                  
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.ArticleShortName.EditValue = null;
                    this.PONO.EditValue = null;
                    this.SetNo.EditValue = null;
                    this.Counts.EditValue = null;
                    this.Ply.EditValue = null;
                    this.Blends.EditValue = null;
                    this.Brand.EditValue = null;
                    this.Desc.EditValue = null;
                    this.Color.EditValue = null;
                    this.LbsPerBag.EditValue = null;
                    this.ConesPerBag.EditValue = null;
                    this.Bags.EditValue = null;
                    this.Cones.EditValue = null;
                    this.Lbs.EditValue = null;
                    this.BagsType.EditValue = null;
                    this.isClosed.Checked = false;
                    this.AvailableBags.EditValue = null;
                    this.AvailableCones.EditValue = null;
                    this.AvailableLbs.EditValue = null;
                    this.LotNo.EditValue = null;

                    this.DyingWorkOrderNumber.EditValue = null;
                    this.DyingAccountID.EditValue = null;
                    this.DyingAccountName.EditValue = null;
                
                    this.PONO.EditValue = null;
                   
                    SetButtonStates_Detail(UserInputMode.View);
                    GridAccountRow = null;

                    this.Add_Detail.Focus();
                


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void UpdateGridValues()
        {
          
            if (this.GeneralAccountID.EditValue == null)
            {
                XtraMessageBox.Show("Item ID Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

           

           
            if (this.PONO.EditValue == null )
            {
                XtraMessageBox.Show("Invalid Amount", "Error");
                this.PONO.Focus();
                return;
            }

            if (DyingAccountID.EditValue == null)
            {
                XtraMessageBox.Show("invalid Yarn Dying Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DyingAccountID.Focus();
                return;

            }
            if (this.DyingAccountName.EditValue == null)
            {
                XtraMessageBox.Show("invalid Dying Account ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DyingAccountID.Focus();
                return;

            }
            if (this.DyingWorkOrderNumber.EditValue == null)
            {
                XtraMessageBox.Show("invalid Dying Work Order # ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DyingWorkOrderNumber.Focus();
                return;

            }



          


            
            try
            {

                DataRow _ravi = GridAccountRow;
                if (this.GeneralAccountID.EditValue != null) _ravi["BuyerID"] = this.GeneralAccountID.EditValue.ToString();
                 else
                    _ravi["BuyerID"] = DBNull.Value;
                if (this.GeneralAccountID.EditValue != null) _ravi["BuyerName"] = this.GeneralAccountID.Text;
                else
                    _ravi["BuyerName"] = DBNull.Value;
                if (this.PONO.EditValue != null) _ravi["PONO"] = this.PONO.EditValue.ToString();
                else
                    _ravi["PONO"] = DBNull.Value;
               
             
                if (this.LotNo.EditValue != null) _ravi["LotNo"] = this.LotNo.EditValue.ToString();
                else
                    _ravi["LotNo"] = DBNull.Value;
                if (this.SetNo.EditValue != null) _ravi["SetNo"] = this.SetNo.EditValue.ToString();
                else
                    _ravi["SetNo"] = DBNull.Value;
                if (this.Counts.EditValue != null) _ravi["YarnCount"] = this.Counts.EditValue.ToString();
                else
                    _ravi["YarnCount"] = DBNull.Value;
                if (this.Ply.EditValue != null) _ravi["YarnPly"] = this.Ply.EditValue.ToString();
                else
                    _ravi["YarnPly"] = DBNull.Value;
                if (this.Brand.EditValue != null) _ravi["YarnBrand"] = this.Brand.EditValue.ToString();
                else
                    _ravi["YarnBrand"] = DBNull.Value;
                if (this.Blends.EditValue != null) _ravi["YarnBlend"] = this.Blends.EditValue.ToString();
                else
                    _ravi["YarnBlend"] = DBNull.Value;
                if (this.Desc.EditValue != null) _ravi["YarnDesc"] = this.Desc.EditValue.ToString();
                else
                    _ravi["YarnDesc"] = DBNull.Value;
                if (this.Color.EditValue != null) _ravi["YarnColor"] = this.Color.EditValue.ToString();
                else
                    _ravi["YarnColor"] = DBNull.Value;
                if (this.LbsPerBag.EditValue != null) _ravi["YarnLbsPerBag"] = this.LbsPerBag.EditValue.ToString();
                else
                    _ravi["YarnLbsPerBag"] = DBNull.Value;
                if (this.ConesPerBag.EditValue != null) _ravi["YarnConesPerBag"] = this.ConesPerBag.EditValue.ToString();
                else
                    _ravi["YarnConesPerBag"] = DBNull.Value;
                if (this.Bags.EditValue != null) _ravi["BagsInward"] = this.Bags.EditValue.ToString();
                else
                    _ravi["BagsInward"] = DBNull.Value;
                if (this.Lbs.EditValue != null) _ravi["LbsInward"] = this.Lbs.EditValue.ToString();
                else
                    _ravi["LbsInward"] = DBNull.Value;
                if (this.Cones.EditValue != null) _ravi["ConesInward"] = this.Cones.EditValue.ToString();
                else
                    _ravi["ConesInward"] = DBNull.Value;
                if (this.BagsType.EditValue != null) _ravi["YarnBagsType"] = this.BagsType.EditValue.ToString();
                else
                    _ravi["YarnBagsType"] = DBNull.Value;
                if (this.DyingWorkOrderNumber.EditValue != null) _ravi["REFPONO"] = this.DyingWorkOrderNumber.EditValue.ToString();
                else
                    _ravi["REFPONO"] = DBNull.Value;

                if (this.GodownID.EditValue != null) _ravi["GodownID"] = this.GodownID.EditValue.ToString();
                _ravi["isClosed"] = "0";
               
            

                this.GeneralAccountID.Tag = null;
                this.GeneralAccountID.EditValue = null;
                this.PONO.EditValue = null;
                this.Counts.EditValue = null;
                this.Ply.EditValue = null;
                this.Blends.EditValue = null;
                this.Brand.EditValue = null;
                this.Desc.EditValue = null;
                this.Color.EditValue = null;
                this.LbsPerBag.EditValue = null;
                this.ConesPerBag.EditValue = null;
                this.Bags.EditValue = null;
                this.Cones.EditValue = null;
                this.Lbs.EditValue = null;
                this.BagsType.EditValue = null;
                this.isClosed.Checked = false;
                this.AvailableBags.EditValue = null;
                this.AvailableCones.EditValue = null;
                this.AvailableLbs.EditValue = null;
                this.LotNo.EditValue = null;
                this.SetNo.EditValue = null;
                this.PONO.EditValue = null;
                this.DyingWorkOrderNumber.EditValue = null;
                this.DyingAccountID.EditValue = null;
                this.DyingAccountName.EditValue = null;
          
                    SetButtonStates_Detail(UserInputMode.View);
                    GridAccountRow = null;
                    
                    this.Add_Detail.Focus();

                  
            


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteGridValues()
        {





          


           
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete  ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;


           

            try
            {
                DataRow _ravi = GridAccountRow;

                _ravi.Delete();
                    this.GeneralAccountID.Tag = null;
                this.GeneralAccountID.EditValue = null;
                this.PONO.EditValue = null;
                this.Counts.EditValue = null;
                this.Ply.EditValue = null;
                this.Blends.EditValue = null;
                this.Brand.EditValue = null;
                this.Desc.EditValue = null;
                this.Color.EditValue = null;
                this.LbsPerBag.EditValue = null;
                this.ConesPerBag.EditValue = null;
                this.Bags.EditValue = null;
                this.Cones.EditValue = null;
                this.Lbs.EditValue = null;
                this.BagsType.EditValue = null;
                this.isClosed.Checked = false;
                this.AvailableBags.EditValue = null;
                this.AvailableCones.EditValue = null;
                this.AvailableLbs.EditValue = null;
                this.LotNo.EditValue = null;
                    this.PONO.EditValue = null;
                    this.SetNo.EditValue = null;
                    this.DyingWorkOrderNumber.EditValue = null;
                    this.DyingAccountID.EditValue = null;
                    this.DyingAccountName.EditValue = null;
                    _ravi.Delete();
                    GridAccountRow = null;
                    SetButtonStates_Detail(UserInputMode.View);
                   
                    this.Add_Detail.Focus();
                 


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void SetButtonStates_Detail(UserInputMode uim)
        {
            uiModeDetail = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    this.Execute_Detail.Enabled = false;
                    this.Cancel_Detail.Enabled = true;
                    this.Add_Detail.Enabled = true;
                    this.GridControl_GeneralAccounts.Enabled = true;
                    if (GridAccountRow != null)
                    {
                        this.Delete_Detail.Enabled = true;
                        this.Edit_Detail.Enabled = true;
                    }

                    break;
                case UserInputMode.Add:
                    
                    this.Add_Detail.Enabled = false;
                    this.Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    Delete_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = true;

                    break;
                case UserInputMode.Edit:
                    Add_Detail.Enabled = false;
                    Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = false;
                    Delete_Detail.Enabled = false;


                    break;
                case UserInputMode.Delete:
                    Add_Detail.Enabled = false;
                    Cancel_Detail.Enabled = true;
                    Execute_Detail.Enabled = true;
                    Edit_Detail.Enabled = false;
                    Delete_Detail.Enabled = false;
                    this.GridControl_GeneralAccounts.Enabled = false;

                    break;
                default:
                    break;
            }
        }
        
      
        private void SetButtonStates(UserInputMode uim)
        {
            uiModeVoucher = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Voucher_Execute.Enabled = false;
                    Voucher_Cancel.Enabled = false;
                    Voucher_Add.Enabled = true;

                    Voucher_View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            Voucher_Edit.Enabled = true;
                            Voucher_Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            Voucher_Edit.Enabled = false;
                            Voucher_Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Voucher_Edit.Enabled = false;
                        Voucher_Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";

                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_View.Enabled = false;
                    Voucher_Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_Delete.Enabled = false;
                    Voucher_View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Voucher_Add.Enabled = false;
                    Voucher_Cancel.Enabled = true;
                    Voucher_Execute.Enabled = true;
                    Voucher_Edit.Enabled = false;

                    Voucher_Delete.Enabled = false;
                    Voucher_View.Enabled = false;

                    break;
                default:
                    break;
            }
        }
        private string ReturnMaxNumber(string Query)
        {
            try
            {
                return WS.svc.Get_MaxNumber(Query);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private bool GetNextVoucherNumber()
        {

            try
            {
                string vNum = ReturnMaxNumber("select max(Convert(numeric(18),SubString(GRNGIN,8,6)))+1 as MaxNumber  from YN_Yarn where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "'");
                vNum = vNum.PadLeft(6, '0');
                this.Suffix.Text = vNum;

                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void FetchGridDataSet(string vNumber)
        {
            DataSet ds = WS.svc.Get_DataSet("select * from YNQ_YarnDetail where GRNGIN='" + vNumber + "' and REFPONO is not null");
            if (ds != null)
                GridControl_GeneralAccounts.DataSource = ds.Tables[0];
            
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
            if (this.GodownID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Godown", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.GodownID.Focus();
                return;
            }

            DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
            DataTable gdt = gdv.Table;
            if (gdt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Invalid Number of Rows for Debit / Credit Account....double entry voilation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int x = 0; x < gdt.Rows.Count; x++)
            {


                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {

                    if (gdt.Rows[x]["BuyerID"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid BuyerID in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["YarnCount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Count in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnPly"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Ply in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBrand"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Brand in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBlend"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Blend in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnDesc"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Description in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBagsType"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Bags Type in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["BagsInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Bags Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["LbsInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Lbs Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["ConesInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Cones Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (vnum.Length != 13)
            {
                XtraMessageBox.Show("Issue note  number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
            queries[0] = "insert into YN_Yarn (GRNGIN,iType,iCat,iYear,Dated,iStatus,Remarks,TruckRegistrationNumber,Driver,GatePassNumber,CUserID,CUserTime) Values (";
            queries[0] += "'" + vnum + "','" + Prefix.Text + "','" + vCat + "','" + FinancialYear.Text + "'";
            if (this.Dated.DateTime != null)
                queries[0] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",null";
            queries[0] += ",'U'";
            if (this.Remarks.EditValue != null)
                queries[0] += ",'" + this.Remarks.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
         
            if (this.VRN.EditValue != null)
                queries[0] += ",'" + this.VRN.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.Driver.EditValue != null)
                queries[0] += ",'" + this.Driver.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.GatePassNumber.EditValue != null)
                queries[0] += ",'" + this.GatePassNumber.EditValue.ToString() + "'";
            else
                queries[0] += ",null";

            queries[0] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[0] += ")";
           
      
        
            for (int x = 0; x < gdt.Rows.Count;x++ )
            {
              if(gdt.Rows[x].RowState!=DataRowState.Deleted)
              {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into YN_YarnDetail (GRNGIN,GodownID,LOTNO,IssueTypeID,SETNO,PONO,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,YarnConesPerBag,YarnLbsPerBag,YarnColor,BagsInward,LbsInward,ConesInward,isClosed,refPONO) Values (";
                queries[queries.Length - 1] += "'" + vnum + "'";
                if (this.GodownID.EditValue != null)
                    queries[queries.Length - 1] += ",'" + this.GodownID.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                  if (gdt.Rows[x]["LOTNO"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["LOTNO"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                queries[queries.Length - 1] += ",3";
                if (gdt.Rows[x]["SetNo"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["SetNo"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["PONO"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["PONO"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnBagsType"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBagsType"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (gdt.Rows[x]["YarnCount"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnCount"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (gdt.Rows[x]["YarnPly"].ToString()!="")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnPly"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnBlend"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBlend"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnBrand"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBrand"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnDesc"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnDesc"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnConesPerBag"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnConesPerBag"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnLbsPerBag"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnLbsPerBag"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["YarnColor"].ToString() != "")
                    queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnColor"].ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (gdt.Rows[x]["BagsInward"].ToString() != "")
                    queries[queries.Length - 1] += "," + gdt.Rows[x]["BagsInward"].ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (gdt.Rows[x]["LbsInward"].ToString() != "")
                    queries[queries.Length - 1] += "," + gdt.Rows[x]["LbsInward"].ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (gdt.Rows[x]["ConesInward"].ToString() != "")
                    queries[queries.Length - 1] += "," + gdt.Rows[x]["ConesInward"].ToString() + "";
                else
                    queries[queries.Length - 1] += ",0";
                queries[queries.Length - 1] += ",0,'" + gdt.Rows[x]["REFPONO"].ToString() + "')";
               
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
                    this.Remarks.EditValue = null;
                    this.VRN.EditValue = null;
                    this.Driver.EditValue = null;
                    this.GatePassNumber.EditValue = null;
                    
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.PONO.EditValue = null;
                    this.Counts.EditValue = null;
                            this.Ply.EditValue = null;
                    this.Blends.EditValue = null;
                    this.Brand.EditValue = null;
                    this.Desc.EditValue = null;
                    this.SetNo.EditValue = null;
                    this.Color.EditValue = null;
                    this.LbsPerBag.EditValue = null;
                    this.ConesPerBag.EditValue = null;
                    this.Bags.EditValue = null;
                    this.Cones.EditValue = null;
                    this.Lbs.EditValue = null;
                    this.BagsType.EditValue = null;
                    this.isClosed.Checked = false;
                    this.AvailableBags.EditValue = null;
                    this.AvailableCones.EditValue = null;
                    this.AvailableLbs.EditValue = null;
                    this.LotNo.EditValue = null;
                    this.PONO.EditValue = null;
                    this.GeneralAccountID.EditValue = null;
                    this.DyingWorkOrderNumber.EditValue = null;
                    this.DyingAccountID.EditValue = null;
                    this.DyingAccountName.EditValue = null;
                    
                    this.PONO.EditValue = null;
                    this.Voucher_Print.Tag = vnum;
                    this.Voucher_View.Tag = vnum;
                   
                    this.Suffix.EditValue = null;
                  
                    FetchGridDataSet("XXXXXXX");
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
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }
            if (this.Suffix.Tag.ToString()=="")
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
            if (this.FinancialYear.Tag==null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("Type of voucher not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            if (this.GodownID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Godown", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.GodownID.Focus();
                return;
            }

            DataView gdv = (DataView)this.GridVew_GeneralAccounts.DataSource;
            DataTable gdt = gdv.Table;
            if (gdt.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Invalid Number of Rows for Debit / Credit Account....double entry voilation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int x = 0; x < gdt.Rows.Count; x++)
            {


                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {

                    if (gdt.Rows[x]["BuyerID"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid BuyerID in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                    if (gdt.Rows[x]["YarnCount"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Count in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnPly"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Ply in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBrand"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Brand in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBlend"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Blend in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnDesc"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Description in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["YarnBagsType"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Bags Type in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["BagsInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Bags Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["LbsInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Lbs Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }

                    if (gdt.Rows[x]["ConesInward"].ToString() == "")
                    {
                        XtraMessageBox.Show("Invalid Yarn Cones Issued in grid ....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                    }
                }
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);
            string vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            string veditNum = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
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

            queries[0] = "update YN_Yarn set GRNGIN='" + vnum + "',iType='" + Prefix.Text + "',iCat='" + vCat + "',iYear='" + FinancialYear.Text + "',eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";

            if (this.Dated.EditValue != null)
                queries[0] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[0] += ",Dated=null";
            


            if(this.Remarks.EditValue!=null)
                queries[0] += ",Remarks='"+this.Remarks.EditValue.ToString()+"'";
            else
            queries[0] += ",Remarks=null";
          
            if (this.VRN.EditValue != null)
                queries[0] += ",TruckRegistrationNumber='" + this.VRN.EditValue.ToString() + "'";
            else
                queries[0] += ",TruckRegistrationNumber=null";
            if (this.Driver.EditValue != null)
                queries[0] += ",Driver='" + this.Driver.EditValue.ToString() + "'";
            else
                queries[0] += ",Driver=null";
            if (this.GatePassNumber.EditValue != null)
                queries[0] += ",GatePassNumber='" + this.GatePassNumber.EditValue.ToString() + "'";
            else
                queries[0] += ",GatePassNumber=null";
         
       

            queries[0] += " where GRNGIN='" + veditNum + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_YarnDetail where GRNGIN='" + veditNum + "'";


            for (int x = 0; x < gdt.Rows.Count; x++)
            {
                if (gdt.Rows[x].RowState != DataRowState.Deleted)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into YN_YarnDetail (GRNGIN,GodownID,LOTNO,IssueTypeID,SETNO,PONO,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,YarnConesPerBag,YarnLbsPerBag,YarnColor,BagsInward,LbsInward,ConesInward,isClosed,refPONO) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "'";
                    if (this.GodownID.EditValue != null)
                        queries[queries.Length - 1] += ",'" + this.GodownID.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["LOTNO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["LOTNO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                  
                        queries[queries.Length - 1] += ",3";
                    if (gdt.Rows[x]["SetNo"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["SetNo"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["PONO"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["PONO"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnBagsType"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBagsType"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["YarnCount"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnCount"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    if (gdt.Rows[x]["YarnPly"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnPly"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnBlend"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBlend"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnBrand"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnBrand"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnDesc"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnDesc"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnConesPerBag"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnConesPerBag"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnLbsPerBag"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnLbsPerBag"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["YarnColor"].ToString() != "")
                        queries[queries.Length - 1] += ",'" + gdt.Rows[x]["YarnColor"].ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (gdt.Rows[x]["BagsInward"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["BagsInward"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (gdt.Rows[x]["LbsInward"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["LbsInward"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (gdt.Rows[x]["ConesInward"].ToString() != "")
                        queries[queries.Length - 1] += "," + gdt.Rows[x]["ConesInward"].ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    queries[queries.Length - 1] += ",0,'" + gdt.Rows[x]["REFPONO"].ToString() + "')";
                   
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
                    this.Remarks.EditValue = null;
                    this.VRN.EditValue = null;
                    this.Driver.EditValue = null;
                    this.GatePassNumber.EditValue = null;
                    this.SetNo.EditValue = null;
                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.PONO.EditValue = null;
                    this.Counts.EditValue = null;
                    this.Ply.EditValue = null;
                    this.Blends.EditValue = null;
                    this.Brand.EditValue = null;
                    this.Desc.EditValue = null;
                    this.Color.EditValue = null;
                    this.LbsPerBag.EditValue = null;
                    this.ConesPerBag.EditValue = null;
                    this.Bags.EditValue = null;
                    this.Cones.EditValue = null;
                    this.Lbs.EditValue = null;
                    this.BagsType.EditValue = null;
                    this.isClosed.Checked = false;
                    this.AvailableBags.EditValue = null;
                    this.AvailableCones.EditValue = null;
                    this.AvailableLbs.EditValue = null;
                    this.LotNo.EditValue = null;
                    this.PONO.EditValue = null;
                    this.GeneralAccountID.EditValue = null;
                  
                    this.PONO.EditValue = null;
                    this.Voucher_Print.Tag = vnum;
                    this.Voucher_View.Tag = vnum;
                    this.DyingWorkOrderNumber.EditValue = null;
                    this.DyingAccountID.EditValue = null;
                    this.DyingAccountName.EditValue = null;
                   
                    this.Suffix.EditValue = null;
                    this.FinancialYear.Tag = null;
                    this.Suffix.Tag = null;
                    this.Prefix.Tag = null;
                    FetchGridDataSet("XXXXXXX");
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




            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.Prefix.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.FinancialYear.Tag == null)
            {
                XtraMessageBox.Show("invalid voucher", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            string[] queries = new string[0];
            string vNumbertoDel = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString() + this.Suffix.Tag.ToString();
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete   # " + vNumbertoDel + " ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;

            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  YN_YarnDetail where GRNGIN='" + vNumbertoDel + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from YN_Yarn where GRNGIN='" + vNumbertoDel + "'";
          
          


            try
            {
                string tResult = WS.svc.Execute_Transaction(queries);
                if (tResult != "**SUCCESS##")
                {
                    XtraMessageBox.Show(tResult, "Error Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {


                    this.Remarks.EditValue = null;
                    this.VRN.EditValue = null;
                    this.Driver.EditValue = null;
                    this.GatePassNumber.EditValue = null;

                    this.GeneralAccountID.Tag = null;
                    this.GeneralAccountID.EditValue = null;
                    this.PONO.EditValue = null;
                    this.Counts.EditValue = null;
                    this.Ply.EditValue = null;
                    this.Blends.EditValue = null;
                    this.Brand.EditValue = null;
                    this.Desc.EditValue = null;
                    this.Color.EditValue = null;
                    this.LbsPerBag.EditValue = null;
                    this.ConesPerBag.EditValue = null;
                    this.Bags.EditValue = null;
                    this.Cones.EditValue = null;
                    this.Lbs.EditValue = null;
                    this.BagsType.EditValue = null;
                    this.isClosed.Checked = false;
                    this.AvailableBags.EditValue = null;
                    this.AvailableCones.EditValue = null;
                    this.AvailableLbs.EditValue = null;
                    this.LotNo.EditValue = null;
                    this.PONO.EditValue = null;
                    this.GeneralAccountID.EditValue = null;
                    this.SetNo.EditValue = null;

                    this.PONO.EditValue = null;
                    this.Voucher_Print.Tag = null;
                    this.Voucher_View.Tag = null;
                    this.DyingWorkOrderNumber.EditValue = null;
                    this.DyingAccountID.EditValue = null;
                    this.DyingAccountName.EditValue = null;
                  
                    this.Suffix.EditValue = null;
                    this.FinancialYear.Tag = null;
                    this.Suffix.Tag = null;
                    this.Prefix.Tag = null;
                
                    FetchGridDataSet("XXXXXXX");
                    SetButtonStates(UserInputMode.View);
                    this.Voucher_Add.Focus();
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
                VtypeCap.Text = "N";


                this.Prefix.Text = N_Number;
                if (uiModeVoucher== UserInputMode.Add || uiModeVoucher == UserInputMode.Edit)
                {

                    GetNextVoucherNumber();
                }
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Number;
                if (uiModeVoucher== UserInputMode.Add)
                {

                    GetNextVoucherNumber();
                }
            }
        }

       
        

       
        private void SelectGeneralAccountsFromGrid()
        {
            try
            {
            if (this.GridVew_GeneralAccounts.FocusedRowHandle != -1)
            {
               GridAccountRow = this.GridVew_GeneralAccounts.GetDataRow(this.GridVew_GeneralAccounts.FocusedRowHandle);
                if (GridAccountRow != null)
                {
                    this.GeneralAccountID.EditValue = GridAccountRow["BuyerID"].ToString();

                    this.GeneralAccountID.Tag = GridAccountRow["BuyerID"].ToString();

                    if (GridAccountRow["PONO"].ToString() != "")
                        this.PONO.EditValue = GridAccountRow["PONO"].ToString();
                    else
                        this.PONO.EditValue = null;
                    if (GridAccountRow["REFPONO"].ToString() != "")
                        this.DyingWorkOrderNumber.EditValue = GridAccountRow["REFPONO"].ToString();
                    else
                        this.DyingWorkOrderNumber.EditValue = null;

                    if (GridAccountRow["BuyerName"].ToString() != "")
                        this.AccountName.EditValue = GridAccountRow["BuyerName"].ToString();
                    else
                        this.AccountName.EditValue = null;
                    if (GridAccountRow["ArticleShortName"].ToString() != "")
                        this.ArticleShortName.EditValue = GridAccountRow["ArticleShortName"].ToString();
                    else
                        this.ArticleShortName.EditValue = null;
                    if (GridAccountRow["LOTNO"].ToString() != "")
                        this.LotNo.EditValue = GridAccountRow["LOTNO"].ToString();
                    else
                        this.LotNo.EditValue = null;
                    if (GridAccountRow["SetNo"].ToString() != "")
                        this.SetNo.EditValue = GridAccountRow["SetNo"].ToString();
                    else
                        this.SetNo.EditValue = null;
                  

                   
                    if (GridAccountRow["YarnCount"].ToString() != "")
                        this.Counts.EditValue = GridAccountRow["YarnCount"].ToString();
                    else
                        this.Counts.EditValue = null;
                    if (GridAccountRow["YarnPly"].ToString() != "")
                        this.Ply.EditValue = GridAccountRow["YarnPly"].ToString();
                    else
                        this.Ply.EditValue = null;
                    if (GridAccountRow["YarnBlend"].ToString() != "")
                        this.Blends.EditValue = GridAccountRow["YarnBlend"].ToString();
                    else
                        this.Blends.EditValue = null;
                    if (GridAccountRow["YarnBrand"].ToString() != "")
                        this.Brand.EditValue = GridAccountRow["YarnBrand"].ToString();
                    else
                        this.Brand.EditValue = null;
                    if (GridAccountRow["YarnDesc"].ToString() != "")
                        this.Desc.EditValue = GridAccountRow["YarnDesc"].ToString();
                    else
                        this.Desc.EditValue = null;
                    if (GridAccountRow["YarnColor"].ToString() != "")
                        this.Color.EditValue = GridAccountRow["YarnColor"].ToString();
                    else
                        this.Color.EditValue = null;
                    if (GridAccountRow["YarnBagsType"].ToString() != "")
                        this.BagsType.EditValue = GridAccountRow["YarnBagsType"].ToString();
                    else
                        this.BagsType.EditValue = null;
                    if (GridAccountRow["YarnLbsPerBag"].ToString() != "")
                        this.LbsPerBag.EditValue = GridAccountRow["YarnLbsPerBag"].ToString();
                    else
                        this.LbsPerBag.EditValue = null;
                    if (GridAccountRow["YarnConesPerBag"].ToString() != "")
                        this.ConesPerBag.EditValue = GridAccountRow["YarnConesPerBag"].ToString();
                    else
                        this.ConesPerBag.EditValue = null;
                    if (GridAccountRow["BagsInward"].ToString() != "")
                        this.Bags.EditValue = GridAccountRow["BagsInward"].ToString();
                    else
                        this.Bags.EditValue = null;
                    if (GridAccountRow["LbsInward"].ToString() != "")
                        this.Lbs.EditValue = GridAccountRow["LbsInward"].ToString();
                    else
                        this.Lbs.EditValue = null;
                    if (GridAccountRow["ConesInward"].ToString() != "")
                        this.Cones.EditValue = GridAccountRow["ConesInward"].ToString();
                    else
                        this.Cones.EditValue = null;
                   
                    if (GridAccountRow["isClosed"].ToString() != "True")
                        this.isClosed.Checked = true;
                    else
                        this.isClosed.Checked = false;
                    if (GridAccountRow["GodownID"].ToString() != "")
                        this.GodownID.EditValue = GridAccountRow["GodownID"].ToString();
                    else
                        this.GodownID.EditValue = null;
                    SetButtonStates_Detail(UserInputMode.View);
                }
                }
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:SelectGeneralAccountsFromGrid", MessageBoxButtons.OK);
            }
            
           
        }
      

       

       

     

       

        
        

       


       
        private void POD_Print_Click(object sender, EventArgs e)
        {
            if (this.Voucher_Print.Tag == null)
            {
                XtraMessageBox.Show("invalid PO #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

       


        private void Voucher_Add_Click(object sender, EventArgs e)
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
            bool rRes = GetNextVoucherNumber();


            SetButtonStates(UserInputMode.Add);
        }

        private void Voucher_Edit_Click(object sender, EventArgs e)
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

        private void Voucher_Delete_Click(object sender, EventArgs e)
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

        private void Voucher_Cancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void Voucher_Execute_Click(object sender, EventArgs e)
        {
            if (uiModeVoucher == UserInputMode.Add)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                SaveNew();
            }
            else if (uiModeVoucher == UserInputMode.Edit)
            {
                bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (canProceed == false)
                {
                    XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                UpdateExisting();
            }
            else if (uiModeVoucher == UserInputMode.Delete)
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

        private void Voucher_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

          
        private void GeneralAccountID_KeyDown(object sender, KeyEventArgs e)
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
                    this.PONO.EditValue = null;
                    this.ArticleShortName.EditValue = null;
             
                    this.GeneralAccountID.Text = sRow.PrimeryID;
                    this.AccountName.Text = sRow.PrimaryString;
                   

                }
            }
        }

       
        private void GridVew_GeneralAccounts_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SelectGeneralAccountsFromGrid();
        }

        private void Add_Detail_Click(object sender, EventArgs e)
        {
            this.GeneralAccountID.Tag = null;
            this.GeneralAccountID.EditValue = null;
            this.ArticleShortName.EditValue = null;
            this.PONO.EditValue = null;
            this.Counts.EditValue = null;
            this.Ply.EditValue = null;
            this.Blends.EditValue = null;
            this.Brand.EditValue = null;
            this.Desc.EditValue = null;
            this.Color.EditValue = null;
            this.LbsPerBag.EditValue = null;
            this.ConesPerBag.EditValue = null;
            this.Bags.EditValue = null;
            this.Cones.EditValue = null;
            this.Lbs.EditValue = null;
            this.BagsType.EditValue = null;
            this.isClosed.Checked = false;
            this.AvailableBags.EditValue = null;
            this.AvailableCones.EditValue = null;
            this.AvailableLbs.EditValue = null;
            this.LotNo.EditValue = null;
            this.DyingWorkOrderNumber.EditValue = null;
            this.DyingAccountID.EditValue = null;

            this.PONO.EditValue = null;
           
            
            SetButtonStates_Detail(UserInputMode.Add);
          
        }

        private void Execute_Detail_Click(object sender, EventArgs e)
        {
           
            if (uiModeDetail == UserInputMode.Add)
            {
                AddToGridValues();
            }
            else if (uiModeDetail == UserInputMode.Edit)
            {
               
                UpdateGridValues();
            }
            else if (uiModeDetail == UserInputMode.Delete)
            {
              
                DeleteGridValues();
            }
        }

        private void Edit_Detail_Click(object sender, EventArgs e)
        {

            //if (this.PODNumber.EditValue == null)
            //{
            //    XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            SetButtonStates_Detail(UserInputMode.Edit);
           
        }

        private void Delete_Detail_Click(object sender, EventArgs e)
        {
            //if (this.PODNumber.EditValue == null)
            //{
            //    XtraMessageBox.Show("Control ID  Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            SetButtonStates_Detail(UserInputMode.Delete);
        }

        private void Cancel_Detail_Click(object sender, EventArgs e)
        {
            SetButtonStates_Detail(UserInputMode.View);
        }

       

       

       

        private void Voucher_View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();





            if (this.F_Dated.Checked == true)
            {
                if (this.Dated.EditValue == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (this.Dated.DateTime == null)
                {
                    XtraMessageBox.Show("Either uncheck the Date filter or enter valid date", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            if (this.F_VNumber.Checked == true)
            {
                if (this.Suffix.Text == "")
                {
                    XtraMessageBox.Show("Either uncheck the Voucher filter or enter valid voucher", "View Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }



            strFilterQuery = "SELECT GRNGIN,Dated,BuyerName,PONO,Remarks,YarnCount ,YarnPly,YarnBlend,YarnBrand,YarnDesc FROM YNQ_Yarn  ";
            strFilterQuery += "  where iType='" + this.Prefix.Text + "' and iYear='" + this.FinancialYear.Text + "' and iStatus='"+this.radioGroup_ViewPostedUnposted.EditValue.ToString()+"' ";



            if (F_Dated.Checked == true)
            {

                strFilterQuery += " and Dated='" + Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }



            if (this.F_VNumber.Checked == true)
            {

                strFilterQuery += " and GRNGIN like '%" + this.Suffix.Text + "%'";

            }


         
            strFilterQuery += " ORDER BY Dated,Convert(numeric(18),GRNGIN) DESC ";
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "GRNGIN", "PONO");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Voucher_Print.Tag = sRow.PrimeryID;
                this.Voucher_View.Tag = sRow.PrimeryID;
                Fill_Voucher(sRow.PrimeryID);

            }
        }
        private void ClearAll()
        {
            this.Remarks.EditValue = null;
         
            this.GeneralAccountID.EditValue = null;
            
            this.PONO.EditValue = null;
           
            this.Suffix.EditValue = null;
          
            FetchGridDataSet("XXXXXXX");
            SetButtonStates(UserInputMode.View);
        }
        private void Fill_Voucher(string vNumber)
        {
            ClearAll();
            DataSet ds_VoucherMain = WS.svc.Get_DataSet("select * from YNQ_Yarn where GRNGIN='" + vNumber + "'");
            if (ds_VoucherMain == null) return;
            if (ds_VoucherMain.Tables[0].Rows.Count <= 0) return;
            this.Dated.DateTime = Convert.ToDateTime(ds_VoucherMain.Tables[0].Rows[0]["Dated"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
            this.GodownID.EditValue = ds_VoucherMain.Tables[0].Rows[0]["GodownID"].ToString();
            if (ds_VoucherMain.Tables[0].Rows[0]["TruckRegistrationNumber"].ToString() != "")
                this.VRN.EditValue = ds_VoucherMain.Tables[0].Rows[0]["TruckRegistrationNumber"].ToString();
            else
                this.VRN.EditValue = null;
            if (ds_VoucherMain.Tables[0].Rows[0]["GatePassNumber"].ToString() != "")
                this.GatePassNumber.EditValue = ds_VoucherMain.Tables[0].Rows[0]["GatePassNumber"].ToString();
            else
                this.GatePassNumber.EditValue = null;
            if (ds_VoucherMain.Tables[0].Rows[0]["Driver"].ToString() != "")
                this.Driver.EditValue = ds_VoucherMain.Tables[0].Rows[0]["Driver"].ToString();
            else
                this.Driver.EditValue = null;
            if (ds_VoucherMain.Tables[0].Rows[0]["iCat"].ToString() == "G")
            {
                this.NG.Checked = false;

            }
            else
            {

                this.NG.Checked = true;
            }
                       this.DocumentState.Tag = ds_VoucherMain.Tables[0].Rows[0]["iStatus"].ToString();
            this.Remarks.EditValue = ds_VoucherMain.Tables[0].Rows[0]["Remarks"].ToString();
            this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));

               
           
         

            this.Suffix.Text = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(7, 6);
            this.Suffix.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(7, 6);
            this.Prefix.Text = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(0, 3);
            this.Prefix.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(0, 3);
            this.FinancialYear.Tag = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(3, 4);
            this.FinancialYear.Text = ds_VoucherMain.Tables[0].Rows[0]["GRNGIN"].ToString().Substring(3, 4);

            FetchGridDataSet(vNumber);
            SetButtonStates(UserInputMode.View);
          
        }

        private void Voucher_Print_Click(object sender, EventArgs e)
        {
           
        }

        private void Yarn_GINWITHPO_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.YarnCounts(ref Counts);
            fc.YarnPly(ref Ply);
            fc.YarnLbsPerBag(ref LbsPerBag);
            fc.YarnConesPerBag(ref this.ConesPerBag);
            fc.YarnColors(ref this.Color);
            fc.YarnBrands(ref this.Brand);
            fc.YarnDesc(ref Desc);
            fc.YarnBagsType(ref this.BagsType);
            fc.YarnBlends(ref Blends);
         
            fc.YarnGodowns(ref this.GodownID);
        }

        private void Counts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Counts.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnCounts(ref this.Counts);
            }
        }

        private void Ply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Ply.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnPly(ref this.Ply);
            }
        }

        private void Blends_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Blends.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnBlends(ref this.Blends);
            }
        }

        private void Brand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Brand.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnBrands(ref this.Brand);
            }
        }

        private void Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Desc.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnDesc(ref this.Desc);
            }
        }

        private void Color_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.Color.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnColors(ref this.Color);
            }
        }

        private void LbsPerBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.LbsPerBag.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnLbsPerBag(ref this.LbsPerBag);
            }
        }

        private void ConesPerBag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.ConesPerBag.EditValue = null;
            else if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.YarnConesPerBag(ref this.ConesPerBag);
            }
        }

        private void GeneralAccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.GeneralAccountID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.GeneralAccountID.EditValue.ToString());
                if (mAcID != "")
                    this.AccountName.EditValue = mAcID;
                else
                    this.AccountName.EditValue = null;
            }
            else
            {
                this.AccountName.EditValue = null;
            }
        }

        private void PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {

                string query = "SELECT Distinct PONO,BUYERID,BuyerName,ArticleNumber,ArticleShortName,POQTYPCS,POQTYLBS,POQTYMTRS from RFC_PO where POStatusID=0";
               
                if (this.GeneralAccountID.EditValue != null && this.AccountName.EditValue != null)
                {

                    query += " and ";

                    query += " BuyerID='" + this.GeneralAccountID.EditValue.ToString() + "'";
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
                    this.PONO.EditValue = sRow.PrimeryID;
                    this.GeneralAccountID.EditValue = sRow.PrimaryString;

                    try
                    {
                        this.AccountName.EditValue = sRow.SelectedDataRow["BuyerName"].ToString();
                        this.ArticleShortName.Tag = sRow.SelectedDataRow["ArticleNumber"].ToString();
                        this.ArticleShortName.EditValue = sRow.SelectedDataRow["ArticleShortName"].ToString();
                    }
                    catch
                    {
                    }

                }



            }
        }

       
     
        private void CalculateYarnLbsAndCones()
        {
            decimal BagsQuantity = 0;
            decimal LbsQuantity = 0;
            decimal ConesQuantity = 0;
            decimal LbsPerBag = 0;
            decimal ConesPerBag = 0;
            if (this.AutoManual.Checked == true) return;
            if (this.LbsPerBag.EditValue == null) return;
            if (this.ConesPerBag.EditValue == null) return;
            if (this.Bags.EditValue == null) BagsQuantity = 0;
            else
                decimal.TryParse(this.Bags.EditValue.ToString(), out BagsQuantity);
            if (this.LbsPerBag.EditValue != null)
            {
                if (this.LbsPerBag.EditValue != null)
                    LbsPerBag = Convert.ToDecimal(this.LbsPerBag.EditValue.ToString());
            }

            if (this.ConesPerBag.EditValue != null)
                ConesPerBag = Convert.ToDecimal(this.ConesPerBag.EditValue.ToString());
            LbsQuantity = BagsQuantity * LbsPerBag;
            Lbs.EditValue = LbsQuantity.ToString();
            ConesQuantity = ConesPerBag * BagsQuantity;
            this.Cones.EditValue = ConesQuantity.ToString();
            this.Lbs.EditValue = LbsQuantity.ToString();
        }

        private void WhenEditValueChanged(object sender, EventArgs e)
        {
            CalculateYarnLbsAndCones();
        }

        private void panelControl_Detail_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioGroup_IssueType_EditValueChanged(object sender, EventArgs e)
        {
            //if (radioGroup_IssueType.EditValue != null)
            //{
            //    if (radioGroup_IssueType.EditValue.ToString() == "1" )
            //    {
            //        this.IssueTo_POLabel.Visible = true;
            //        this.IssueTo_PONO.Visible = true;
            //        this.IssueTo_ArticleShortName.Visible = true;
            //    }
            //    else if (radioGroup_IssueType.EditValue.ToString() == "7")
            //    {
            //        this.IssueTo_POLabel.Visible = true;
            //        this.IssueTo_PONO.Visible = true;
            //        this.IssueTo_ArticleShortName.Visible = true;
            //        this.IssueTo_AccountID.EditValue = this.GeneralAccountID.EditValue;
            //        this.IssueTo_AccountName.EditValue = this.AccountName.EditValue;
            //    }
            //    else
            //    {
            //        this.IssueTo_POLabel.Visible = false;
            //        this.IssueTo_PONO.Visible = false;
            //        this.IssueTo_ArticleShortName.Visible = false;
            //    }

            //}
        }

        private void IssueTo_AccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true )
            {

               

                selectedrow sRow = new selectedrow();
                Data.Data_View View = new Data.Data_View();
                View.sRow = sRow;
                View.Load_View("Select AccountID,AccountName,MailingAddress from PP_Accounts order by AccountName", "AccountID", "AccountName");
                View.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    this.DyingWorkOrderNumber.EditValue = null;
                  

                    this.DyingAccountID.EditValue = sRow.PrimeryID;
                    this.DyingAccountName.EditValue = sRow.PrimaryString;


                }
            }
        }

        private void IssueTo_PONO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                string query="";
               
                    query = "SELECT Distinct PONumber as WorkOrderNo,BUYERID as AccountID,BuyerName as AccountName from RFC_PO_Main where POStatusID=0 and POTYPEID ='14'";

                if (this.DyingAccountID.EditValue != null && this.DyingAccountName.EditValue != null)
                {

                    query += " and ";

                    query += " BuyerID='" + this.DyingAccountID.EditValue.ToString() + "'";
                }
                selectedrow sRow = new selectedrow();

                Data.Data_View FrmView = new Data.Data_View();
                FrmView.sRow = sRow;
                FrmView.Load_View(query, "WorkOrderNo", "AccountID");
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.DyingWorkOrderNumber.EditValue = sRow.PrimeryID;
                    this.DyingAccountID.EditValue = sRow.PrimaryString;

                    try
                    {
                        this.DyingAccountName.EditValue = sRow.SelectedDataRow["AccountName"].ToString();

                     
                    }
                    catch
                    {
                      
                       
                    }

                }



            }
        }

        private void IssueTo_AccountID_EditValueChanged(object sender, EventArgs e)
        {
            if (this.DyingAccountID.EditValue != null)
            {
                string mAcID = MachineEyes.Classes.Accounting.Get_MappedAccount(this.DyingAccountID.EditValue.ToString());
                if (mAcID != "")
                    this.DyingAccountName.EditValue = mAcID;
                else
                    this.DyingAccountName.EditValue = null;
            }
            else
            {
                this.DyingAccountName.EditValue = null;
            }
        }

        private void IssueTo_PONO_EditValueChanged(object sender, EventArgs e)
        {
            if (DyingWorkOrderNumber.EditValue != null)
            {
                 string query = "SELECT Distinct BUYERID,BuyerName from RFC_PO_Main where PONUMBER='"+this.DyingWorkOrderNumber.EditValue.ToString()+"'";
                DataSet ds=WS.svc.Get_DataSet(query);
                if(ds!=null)
                {
                    if(ds.Tables[0].Rows.Count>0)
                    {
                        this.DyingAccountID.EditValue = ds.Tables[0].Rows[0]["BuyerID"].ToString();
                        this.DyingAccountName.EditValue = ds.Tables[0].Rows[0]["BuyerName"].ToString();
                      
                    }
                }
            }
           
        }

        private void AutoManual_CheckedChanged(object sender, EventArgs e)
        {

            if (this.AutoManual.Checked == true)
                AutoManual.Text = "Manual Calculations";
            else
                AutoManual.Text = "Auto Calculations";
            CalculateYarnLbsAndCones();
        }

        private void CheckStock_Click(object sender, EventArgs e)
        {
            if (this.PONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PONO", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.PONO.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid PONO", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            CheckAvailabilityOfYarn(this.PONO, Bags, Lbs, Cones);
        }
        public bool CheckAvailabilityOfYarn(TextEdit tPONO, TextEdit tBags, TextEdit tLbs, TextEdit tCones)
        {
            if (tPONO.EditValue == null)
            {
                XtraMessageBox.Show("Invalid PONO / Work Order", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (tPONO.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid PONO / Work Order", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.Counts.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Counts.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.Ply.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Ply.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.Blends.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Blends.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Brand.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Brand", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Brand.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Brand", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Desc.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Description", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.Desc.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Description", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.BagsType.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Yarn Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.BagsType.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Yarn Bags Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.GodownID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Godown / Partition Selection", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.GodownID.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("Invalid Godown / Partition Selection", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            string argPONO = tPONO.EditValue.ToString();
            if (argPONO == "") return false;
            string argGodownID = "";
            string argYarnBagsType = "";
            string argYarnBlend = "";
            string argYarnBrand = "";
            string argYarnCount = "";
            string argYarnDesc = "";
            string argYarnPly = "";
            argYarnBagsType = this.BagsType.EditValue.ToString();
            argYarnBlend = this.Blends.EditValue.ToString();
            argYarnBrand = this.Brand.EditValue.ToString();
            argYarnCount = this.Counts.EditValue.ToString();
            argYarnDesc = this.Desc.EditValue.ToString();
            argYarnPly = this.Ply.EditValue.ToString();
            argGodownID = this.GodownID.EditValue.ToString();
            if (argYarnBagsType == "") return false;
            if (argYarnBlend == "") return false;
            if (argYarnBrand == "") return false;
            if (argYarnCount == "") return false;
            if (argYarnDesc == "") return false;
            if (argYarnPly == "") return false;
            if (argGodownID == "") return false;
            double AvailableBags = 0;
            double AvailableLbs = 0;
            double AvailableCones = 0;
            double issueBags = 0;
            double issueCones = 0;
            double issueLbs = 0;
            if (tBags.EditValue == null)
            {
                XtraMessageBox.Show("you didn't enter bags....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (tBags.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("you didn't enter bags....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }


            if (tLbs.EditValue == null)
            {
                XtraMessageBox.Show("you didn't enter Lbs....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (tLbs.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("you didn't enter Lbs....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (tCones.EditValue == null)
            {
                XtraMessageBox.Show("you didn't enter Cones....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (tCones.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("you didn't enter Cones....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            DataSet ds = WS.svc.Get_DataSet("Select sum(BagsInward)+Sum(BagsReceived)-Sum(BagsOutWard)-Sum(BagsIssued)-Sum(BagsAdj) as BagsBalance,sum(lbsInward)+Sum(lbsReceived)-Sum(lbsOutWard)-Sum(lbsIssued)-Sum(lbsAdj) as LbsBalance,sum(ConesInward)+Sum(ConesReceived)-Sum(ConesOutWard)-Sum(ConesIssued)-Sum(ConesAdj) as ConesBalance from YN_YarnDetail where PONO='" + argPONO + "' and YarnBagsType='" + argYarnBagsType + "' and YarnCount='" + argYarnCount + "' and YarnPly='" + argYarnPly + "' and YarnBrand='" + argYarnBrand + "' and YarnBlend='" + argYarnBlend + "' and YarnDesc='" + argYarnDesc + "' and GodownID='" + argGodownID + "'");
            if (ds == null)
            {
                XtraMessageBox.Show("Data set returned null value , please check connection ....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            this.AvailableBags.EditValue = ds.Tables[0].Rows[0]["BagsBalance"].ToString();
            this.AvailableCones.EditValue = ds.Tables[0].Rows[0]["ConesBalance"].ToString();
            this.AvailableLbs.EditValue = ds.Tables[0].Rows[0]["LbsBalance"].ToString();
            double.TryParse(ds.Tables[0].Rows[0]["BagsBalance"].ToString(), out AvailableBags);
            double.TryParse(ds.Tables[0].Rows[0]["LbsBalance"].ToString(), out AvailableLbs);
            double.TryParse(ds.Tables[0].Rows[0]["ConesBalance"].ToString(), out AvailableCones);

            double.TryParse(tBags.EditValue.ToString(), out issueBags);
            double.TryParse(tLbs.EditValue.ToString(), out issueLbs);
            double.TryParse(tCones.EditValue.ToString(), out issueCones);

            if (this.AvailableBags.EditValue == null)
            {
                XtraMessageBox.Show("No Available Bags....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.AvailableBags.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("No Available Bags....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }

            if (this.AvailableCones.EditValue == null)
            {
                XtraMessageBox.Show("No Available Cones....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.AvailableCones.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("No Available Cones....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.AvailableLbs.EditValue == null)
            {
                XtraMessageBox.Show("No Available Lbs....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (this.AvailableLbs.EditValue.ToString() == "")
            {
                XtraMessageBox.Show("No Available Lbs....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (AvailableBags - issueBags < 0)
            {
                XtraMessageBox.Show("Not enough Available Bags....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (AvailableCones - issueCones < 0)
            {
                XtraMessageBox.Show("Not enough Available Cones....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (AvailableLbs - issueLbs < 0)
            {
                XtraMessageBox.Show("Not enough Available Lbs....can not proceed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            return true;
        }
       
    }
}