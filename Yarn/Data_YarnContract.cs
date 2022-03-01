using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace MachineEyes.Data
{
    public partial class Data_YarnContract : DevExpress.XtraEditors.XtraForm
    {
        public selectedrow SelectedRow = new selectedrow();
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;


        public Data_YarnContract()
        {
            InitializeComponent();
            YarnSuppliers();
            Agents();
            YarnCounts();
            YarnBrands();
            YarnBlends();
            PaymentTerms();
            YarnDesc();
            YarnCottonOrigins();
            YarnLbsPerBag();
            YarnConeWeight();
            DeliveryTerms();
            YarnConesPerBag();
            PricePerLbs_textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            QtyBags_textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            WeightLbs_textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Ply_textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.YarnConeWeight_lookUpEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
        }

        public void YarnSuppliers()
        {
            DataSet ds_Dept;
            YarnSupplierID_lookUpEdit1.Properties.Columns.Clear();
            ds_Dept = WS.svc.Get_DataSet("select AccountName,AccountID from PP_Accounts");
            if(ds_Dept!=null)YarnSupplierID_lookUpEdit1.Properties.DataSource = ds_Dept.Tables[0];
            YarnSupplierID_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName"));
            YarnSupplierID_lookUpEdit1.Properties.DisplayMember = "AccountName";
            YarnSupplierID_lookUpEdit1.Properties.ValueMember = "AccountID";
        }
        public void Agents()
        {
            DataSet ds;
            AgentID_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select AccountName,AccountID from PP_Accounts");
            if(ds!=null)AgentID_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            AgentID_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AccountName"));
            AgentID_lookUpEdit1.Properties.DisplayMember = "AccountName";
            AgentID_lookUpEdit1.Properties.ValueMember = "AccountID";
        }
        public void YarnCounts()
        {
            DataSet ds;
            YarnCount_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnCount from PP_YarnCounts order by YarnCount");
            if(ds!=null)YarnCount_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnCount_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnCount"));
            YarnCount_lookUpEdit1.Properties.DisplayMember = "YarnCount";
            YarnCount_lookUpEdit1.Properties.ValueMember = "YarnCount";
        }
        public void YarnBrands()
        {
            DataSet ds;
            YarnBrand_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBrand from PP_YarnBrands order by YarnBrand");
            if(ds!=null)YarnBrand_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnBrand_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBrand"));
            YarnBrand_lookUpEdit1.Properties.DisplayMember = "YarnBrand";
            YarnBrand_lookUpEdit1.Properties.ValueMember = "YarnBrand";
        }
        public void YarnBlends()
        {
            DataSet ds;
            YarnBlend_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnBlend from PP_YarnBlend order by YarnBlend");
            if(ds!=null)YarnBlend_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnBlend_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnBlend"));
            YarnBlend_lookUpEdit1.Properties.DisplayMember = "YarnBlend";
            YarnBlend_lookUpEdit1.Properties.ValueMember = "YarnBlend";
        }
        public void YarnDesc()
        {
            DataSet ds;
            YarnDesc_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnDesc from PP_YarnDesc order by YarnDesc");
            if (ds != null) YarnDesc_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnDesc_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnDesc"));
            YarnDesc_lookUpEdit1.Properties.DisplayMember = "YarnDesc";
            YarnDesc_lookUpEdit1.Properties.ValueMember = "YarnDesc";
        }
        public void YarnCottonOrigins()
        {
            DataSet ds;
            YarnCottonOrigin_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnCottonOrigin from PP_YarnCottonOrigins order by YarnCottonOrigin");
            if (ds != null) YarnCottonOrigin_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnCottonOrigin_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnCottonOrigin"));
            YarnCottonOrigin_lookUpEdit1.Properties.DisplayMember = "YarnCottonOrigin";
            YarnCottonOrigin_lookUpEdit1.Properties.ValueMember = "YarnCottonOrigin";
        }

        public void YarnConesPerBag()
        {
            DataSet ds;
            YarnConesPerBag_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnConesPerBag from PP_YarnConesPerBag order by YarnConesPerBag");
            if (ds != null) YarnConesPerBag_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnConesPerBag_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnConesPerBag"));
            YarnConesPerBag_lookUpEdit1.Properties.DisplayMember = "YarnConesPerBag";
            YarnConesPerBag_lookUpEdit1.Properties.ValueMember = "YarnConesPerBag";
        }
        public void YarnLbsPerBag()
        {
            DataSet ds;
            YarnLbsPerBag_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnLbsPerBag from PP_YarnLbsPerBag order by YarnLbsPerBag");
            if (ds != null) YarnLbsPerBag_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnLbsPerBag_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnLbsPerBag"));
            YarnLbsPerBag_lookUpEdit1.Properties.DisplayMember = "YarnLbsPerBag";
            YarnLbsPerBag_lookUpEdit1.Properties.ValueMember = "YarnLbsPerBag";
        }
        public void YarnConeWeight()
        {
            DataSet ds;
            YarnBlend_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select YarnConeWeight from PP_YarnConeWeight order by YarnConeWeight");
            if (ds != null) YarnConeWeight_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            YarnConeWeight_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("YarnConeWeight"));
            YarnConeWeight_lookUpEdit1.Properties.DisplayMember = "YarnConeWeight";
            YarnConeWeight_lookUpEdit1.Properties.ValueMember = "YarnConeWeight";
        }
        public void PaymentTerms()
        {
            DataSet ds;
            PaymentTerms_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select PaymentTerms from PP_PaymentTerms order by PaymentTerms");
            if(ds!=null)PaymentTerms_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            PaymentTerms_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PaymentTerms"));
            PaymentTerms_lookUpEdit1.Properties.DisplayMember = "PaymentTerms";
            PaymentTerms_lookUpEdit1.Properties.ValueMember = "PaymentTerms";
        }
        public void DeliveryTerms()
        {
            DataSet ds;
            DeliveryTerms_lookUpEdit1.Properties.Columns.Clear();
            ds = WS.svc.Get_DataSet("select DeliveryTerms from PP_DeliveryTerms order by DeliveryTerms");
            if (ds != null) DeliveryTerms_lookUpEdit1.Properties.DataSource = ds.Tables[0];
            DeliveryTerms_lookUpEdit1.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DeliveryTerms"));
            DeliveryTerms_lookUpEdit1.Properties.DisplayMember = "DeliveryTerms";
            DeliveryTerms_lookUpEdit1.Properties.ValueMember = "DeliveryTerms";
        }
       
        private void Data_YarnContract_Load(object sender, EventArgs e)
        {
            set_ButtonStates(UserInputMode.View);
            RefreshAndClear();
            this.ContractDate_Edit1.DateTime = DateTime.Now;
            this.DeliveryDueDate_dateEdit1.DateTime = DateTime.Now.AddMonths(1);
        }
        private void set_ButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    btn_Save.Enabled = false;
                    btn_Cancel.Enabled = false;
                    btn_Add.Enabled = true;
                    btn_Close.Enabled = true;
                    btn_View.Enabled = true;
                  

                    if (YarnContractNumber_textEdit1 .Tag != null)
                    {
                        if (YarnContractNumber_textEdit1.Tag.ToString() != "")
                        {

                            btn_Edit.Enabled = true;
                            btn_Del.Enabled = true;
                            return;
                        }
                        else
                        {
                            btn_Edit.Enabled = false;
                            btn_Del.Enabled = false;
                        }
                    }
                    else
                    {
                        btn_Edit.Enabled = false;
                        btn_Del.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:

                    btn_Add.Enabled = false;
                    btn_Cancel.Enabled = true;
                    btn_Save.Enabled = true;
                    btn_Edit.Enabled = false;
                    btn_Close.Enabled = true;
                    btn_View.Enabled = false;
                    btn_Del.Enabled = false;
                 
                    break;
                case UserInputMode.Edit:
                    btn_Add.Enabled = false;
                    btn_Cancel.Enabled = true;
                    btn_Save.Enabled = true;
                    btn_Edit.Enabled = false;
                    btn_Close.Enabled = true;
                    btn_Del.Enabled = false;
                    btn_View.Enabled = false;
                
                    break;
                case UserInputMode.Delete:
                    btn_Add.Enabled = false;
                    btn_Cancel.Enabled = true;
                    btn_Save.Enabled = true;
                    btn_Edit.Enabled = false;
                    btn_Close.Enabled = true;
                    btn_Del.Enabled = false;
                    btn_View.Enabled = false;
            
                    break;
                default:
                    break;
            }
        }
        private void RefreshAndClear()
        {
            YarnContractNumber_textEdit1.Tag = "";
            YarnContractNumber_textEdit1.Text = "";
            SupplierContractRef_textEdit1.Text = "";
            AgentContractRef_textEdit1.Text = "";
            AgentCommissionRate_textEdit1.Text = "0";
            DeliveryDueDate_dateEdit1.EditValue = System.DateTime.Now;
            PaymentTerms_lookUpEdit1.EditValue = null;
            PricePerLbs_textEdit1.Text = "0";
            Remarks_textEdit.Text = "";
            ContractDate_Edit1.EditValue = System.DateTime.Now;
            YarnSupplierID_lookUpEdit1.EditValue = null;
            AgentID_lookUpEdit1.EditValue = null;
            YarnCount_lookUpEdit1.EditValue = null;
            YarnBrand_lookUpEdit1.EditValue = null;
            YarnBlend_lookUpEdit1.EditValue = null;
            Ply_textEdit1.Text = "0";
            QtyBags_textEdit1.Text = "0";
            WeightLbs_textEdit1.Text = "0";
            DeliveryTerms_lookUpEdit1.EditValue = null;
            YarnCottonOrigin_lookUpEdit1.EditValue = null;
            YarnDesc_lookUpEdit1.EditValue = null;
            YarnConeWeight_lookUpEdit1.EditValue = null;
            YarnConesPerBag_lookUpEdit1.EditValue = null;
            YarnLbsPerBag_lookUpEdit1.EditValue = null;
         
           set_ButtonStates(UserInputMode.View);
        }
        private void FillContract(string ContractNumber)
        {
            RefreshAndClear();
            DataSet ds = WS.svc.Get_DataSet("Select * from YN_YarnContracts where YarnContractNumber='" + ContractNumber + "'");
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;

            YarnContractNumber_textEdit1.Tag = ContractNumber;
            YarnContractNumber_textEdit1.Text = ContractNumber;
                if(ds.Tables[0].Rows[0]["ContractDate"].ToString()!="")
                ContractDate_Edit1.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["ContractDate"].ToString());
                if (ds.Tables[0].Rows[0]["YarnSupplierID"].ToString() != "")
                    YarnSupplierID_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnSupplierID"].ToString();
                else
                    YarnSupplierID_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                    AgentID_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["AgentID"].ToString();
                else
                    AgentID_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnCount"].ToString() != "")
                    YarnCount_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnCount"].ToString();
                else
                    YarnCount_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnBrand"].ToString() != "")
                    YarnBrand_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnBrand"].ToString();
                else
                    YarnBrand_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnBlend"].ToString() != "")
                    YarnBlend_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnBlend"].ToString();
                else
                    YarnBlend_lookUpEdit1.EditValue = null;

                Ply_textEdit1.EditValue = ds.Tables[0].Rows[0]["Ply"].ToString();
                QtyBags_textEdit1.EditValue = ds.Tables[0].Rows[0]["QtyBags"].ToString();
                PricePerLbs_textEdit1.EditValue = ds.Tables[0].Rows[0]["PricePerLbs"].ToString();
                this.WeightLbs_textEdit1.EditValue = ds.Tables[0].Rows[0]["WeightLbs"].ToString();
                //WeightLbs_textEdit1.Text = ds.Tables[0].Rows[0]["WeightLbs"].ToString();
                if (ds.Tables[0].Rows[0]["DeliveryDueDate"].ToString() != "")
                    DeliveryDueDate_dateEdit1.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["DeliveryDueDate"]);
                else
                    DeliveryDueDate_dateEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["PaymentTerms"].ToString() != "")
                    PaymentTerms_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["PaymentTerms"].ToString();
                else
                    PaymentTerms_lookUpEdit1.EditValue = null;

                AgentContractRef_textEdit1.Text = ds.Tables[0].Rows[0]["AgentContractRef"].ToString();
            
                AgentCommissionRate_textEdit1.EditValue = ds.Tables[0].Rows[0]["AgentCommission"].ToString();
                Remarks_textEdit.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["DeliveryTerms"].ToString() != "")
                    DeliveryTerms_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["DeliveryTerms"].ToString();
                else
                    DeliveryTerms_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnCottonOrigin"].ToString() != "")
                    YarnCottonOrigin_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnCottonOrigin"].ToString();
                else
                    YarnCottonOrigin_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnDescription"].ToString() != "")
                    YarnDesc_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnDescription"].ToString();
                else
                    YarnDesc_lookUpEdit1.EditValue = null;
                if (ds.Tables[0].Rows[0]["YarnConeWeight"].ToString() != "")
                    YarnConeWeight_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnConeWeight"];
                else
                    YarnConeWeight_lookUpEdit1.EditValue = null;
                //YarnConesPerBag_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnConesPerBag"].ToString();
                if (ds.Tables[0].Rows[0]["YarnLbsPerBag"].ToString() != "")
                    YarnLbsPerBag_lookUpEdit1.EditValue = ds.Tables[0].Rows[0]["YarnLbsPerBag"];
                else
                    YarnLbsPerBag_lookUpEdit1.EditValue = null;


                if (ds.Tables[0].Rows[0]["yarnConesPerBag"].ToString() != "")
                    this.YarnConesPerBag_lookUpEdit1.EditValue =ds.Tables[0].Rows[0]["YarnConesPerBag"];
                else
                    YarnConesPerBag_lookUpEdit1.EditValue = null;
            
        }
        private void btn_View_Click(object sender, EventArgs e)
        {
           
            string strFilterQuery = "SELECT YarnContractNumber,ContractDate,SupplierContractNumber,YarnSupplierID  FROM YN_YarnContracts   ";
            strFilterQuery += "  where cType='001' ";



            if (this.Filter_ContractDate.Checked == true)
            {
                if (this.ContractDate_Edit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid date selected, either uncheck date filter or select proper date", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and ContractDate='" + this.ContractDate_Edit1.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";

            }

            if (this.Filter_BagsQty.Checked == true)
            {
                if (this.QtyBags_textEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Bags selected, either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and QtyBags=" + this.QtyBags_textEdit1.EditValue.ToString() + "";

            }

            if (this.Filter_PricePerLbs.Checked == true)
            {
                if (this.PricePerLbs_textEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Price / lbs selected, either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and PricePerLbs=" + this.PricePerLbs_textEdit1.EditValue.ToString() + "";

            }
            if (this.Filter_SupplierContractNumber.Checked == true)
            {
                if (this.SupplierContractRef_textEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Suppliers Contract Reference selected, either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and SupplierContractNumber like '%" + this.SupplierContractRef_textEdit1.EditValue.ToString() + "%'";

            }
            if (this.Filter_SupplierID.Checked == true)
            {
                if (this.YarnSupplierID_lookUpEdit1.EditValue == null)
                {
                   XtraMessageBox.Show("Invalid Supplier Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnSupplierID='" + this.YarnSupplierID_lookUpEdit1.EditValue.ToString() + "'";

            }

            if (this.Filter_YarnAgent.Checked == true)
            {
                if (this.AgentID_lookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid yarn Agent selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and AgentID='" + this.AgentID_lookUpEdit1.EditValue.ToString() + "'";

            }
            if (this.Filter_YarnBlend.Checked == true)
            {
                if (this.YarnBlend_lookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Blend Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnBlend='" + this.YarnBlend_lookUpEdit1.EditValue.ToString() + "'";

            }
            if (this.Filter_YarnBrand.Checked == true)
            {
                if (this.YarnBrand_lookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Brand Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnBrand='" + this.YarnBrand_lookUpEdit1.EditValue.ToString() + "'";

            }
            if (this.Filter_YarnContractNumber.Checked == true)
            {
                if (this.YarnContractNumber_textEdit1.Text  == "")
                {
                    XtraMessageBox.Show("Invalid Yarn contract number Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnContractNumber like '%" + this.YarnContractNumber_textEdit1.Text + "%'";

            }
            if (this.Filter_YarnCount.Checked == true)
            {
                if (this.YarnCount_lookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Count Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnCount='" + this.YarnCount_lookUpEdit1.EditValue.ToString() + "'";

            }
            if (this.Filter_YarnDesc.Checked == true)
            {
                if (this.YarnDesc_lookUpEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Yarn Description Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and YarnDesc='" + this.YarnDesc_lookUpEdit1.EditValue.ToString() + "'";

            }
            if (this.Filter_YarnPly.Checked == true)
            {
                if (this.Ply_textEdit1.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid ply Selected , either uncheck date filter or select proper value", "Error", MessageBoxButtons.OK);
                    return;
                }
                strFilterQuery += " and Ply=" + this.Ply_textEdit1.EditValue.ToString() + "";

            }

            uiMode = UserInputMode.View;
            selectedrow sRow = new selectedrow();
            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "YarnContractNumber", "SupplierContractNumber");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.btn_View.Tag = sRow.PrimeryID;
                

                FillContract(sRow.PrimeryID);
                set_ButtonStates(UserInputMode.View);

            }

           
           
        }
     

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string iNumber; string query;
            try
            {
                try
                {
                    if (this.NumberType.EditValue.ToString() == "0")
                    {
                        query = "select max(Convert(numeric(18),SubString(YarnContractNumber,8,6)))+1 as MaxNumber  from YN_YarnContracts where cYear='" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "' and cType='001'";
                        iNumber = WS.svc.Get_MaxNumber(query);
                        if (iNumber.Length > 6)
                        {
                            XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.YarnContractNumber_textEdit1.Text = "";

                        }
                        iNumber = iNumber.PadLeft(6, '0');
                        this.YarnContractNumber_textEdit1.Text = "001" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + iNumber;
                    }
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.YarnContractNumber_textEdit1.Text = "";
                    return;
                }

                //vNumber = vNumber.PadLeft(6, '0');



            }
            catch
            {
                this.YarnContractNumber_textEdit1.Text = "";
                return;
            }
            set_ButtonStates(UserInputMode.Add);
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (YarnContractNumber_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (YarnContractNumber_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
            set_ButtonStates(UserInputMode.Edit);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
       

            if (YarnContractNumber_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }
            if (YarnContractNumber_textEdit1.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record ..");
                return;
            }
           
            set_ButtonStates(UserInputMode.Edit);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            set_ButtonStates(UserInputMode.View);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveNewContract()
        {
            if (this.YarnContractNumber_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Invalid contract Number", "Error", MessageBoxButtons.OK);
                return;
            }
            // if (this.ContractDate_Edit1.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod )
            //{
            //    XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    this.ContractDate_Edit1.Focus();
            //    return;
            //}
            if (this.ContractDate_Edit1.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ContractDate_Edit1.Focus();
                return;
            }
            if (this.YarnBrand_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn brand", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.YarnBlend_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn blend", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Ply_textEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn ply", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.YarnCount_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn count", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);

            queries[0] = "insert into YN_YarnContracts ([YarnContractNumber],[cYear],[cType],[ContractDate],[YarnSupplierID],[SupplierContractNumber],[YarnCount],[Ply],[YarnBlend],[YarnBrand],[YarnDescription],[YarnCottonOrigin],[YarnConeWeight],[YarnConesPerBag],[YarnLbsPerBag],[AgentID],[AgentContractRef],[AgentCommission],[PricePerLbs],[QtyBags],[WeightLbs],[TotalAmount]  ,[PaymentTerms],[DeliveryTerms],[DeliveryDueDate],[Remarks],[ContractStatusID]) values(";
            queries[0] += "'" + this.YarnContractNumber_textEdit1.Text + "','" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "','001'";
           
            
            
            
            if (this.ContractDate_Edit1.EditValue != null)
                queries[0] += ",'" + this.ContractDate_Edit1.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[0] += ",null";
            if (this.YarnSupplierID_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnSupplierID_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";

            if (this.SupplierContractRef_textEdit1.EditValue != null)
                queries[0] += ",'" + this.SupplierContractRef_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnCount_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnCount_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.Ply_textEdit1.EditValue != null)
                queries[0] += "," + this.Ply_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",null";
            if (this.YarnBlend_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnBlend_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnBrand_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnBrand_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnDesc_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnDesc_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnCottonOrigin_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnCottonOrigin_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnConeWeight_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnConeWeight_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnConesPerBag_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnConesPerBag_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.YarnLbsPerBag_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.YarnLbsPerBag_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.AgentID_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.AgentID_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.AgentContractRef_textEdit1.EditValue != null)
                queries[0] += ",'" + this.AgentContractRef_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.AgentCommissionRate_textEdit1.EditValue != null)
                queries[0] += "," + this.AgentCommissionRate_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",null";
            if (this.PricePerLbs_textEdit1.EditValue != null)
                queries[0] += "," + this.PricePerLbs_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",null";
            if (this.QtyBags_textEdit1.EditValue != null)
                queries[0] += ",'" + this.QtyBags_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.WeightLbs_textEdit1.EditValue != null)
                queries[0] += "," + this.WeightLbs_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",null";
            if (this.TotalAmount.EditValue != null)
                queries[0] += "," + this.TotalAmount.EditValue.ToString() + "";
            else
                queries[0] += ",null";
            if (this.PaymentTerms_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.PaymentTerms_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.DeliveryTerms_lookUpEdit1.EditValue != null)
                queries[0] += ",'" + this.DeliveryTerms_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.DeliveryDueDate_dateEdit1.EditValue != null)
                queries[0] += ",'" + this.DeliveryDueDate_dateEdit1.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[0] += ",null";
            if (this.Remarks_textEdit.EditValue != null)
                queries[0] += ",'" + this.Remarks_textEdit.Text + "'";
            else
                queries[0] += ",null";

            queries[0] += ",0)";
            foreach (Control c in this.tableLayoutPanel_Terms.Controls)
            {
                TextEdit Rem=(TextEdit)c;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into YN_YarnContracts_Terms (YarnContractNumber,Terms) Values ('"+this.YarnContractNumber_textEdit1.Text +"','"+Rem.Text +"')";
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
                    this.Print.Tag = this.YarnContractNumber_textEdit1.Text;
                    RefreshAndClear();

                    set_ButtonStates(UserInputMode.View);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditContract()
        {
            if (this.YarnContractNumber_textEdit1.Text == "")
            {
                XtraMessageBox.Show("Invalid contract Number", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.YarnContractNumber_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Invalid contract Number", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.ContractDate_Edit1.DateTime < MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ContractDate_Edit1.Focus();
                return;
            }
            if (this.ContractDate_Edit1.DateTime > MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod)
            {
                XtraMessageBox.Show("Date / Time out of range from Financial Period specified", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ContractDate_Edit1.Focus();
                return;
            }
            if (this.YarnBrand_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn brand", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.YarnBlend_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn blend", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Ply_textEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn ply", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.YarnCount_lookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("invalid yarn count", "validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);

            queries[0] = "update YN_YarnContracts set YarnContractNumber=";
            queries[0] += "'" + this.YarnContractNumber_textEdit1.Text + "'";




            if (this.ContractDate_Edit1.EditValue != null)
                queries[0] += ",ContractDate='" + this.ContractDate_Edit1.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[0] += ",ContractDate=null";
            if (this.YarnSupplierID_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnSupplierID='" + this.YarnSupplierID_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnSupplierID=null";

            if (this.SupplierContractRef_textEdit1.EditValue != null)
                queries[0] += ",SupplierContractNumber='" + this.SupplierContractRef_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",SupplierContractNumber=null";
            if (this.YarnCount_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnCount='" + this.YarnCount_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnCount=null";
            if (this.Ply_textEdit1.EditValue != null)
                queries[0] += ",Ply=" + this.Ply_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",Ply=null";
            if (this.YarnBlend_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnBlend='" + this.YarnBlend_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnBlend=null";
            if (this.YarnBrand_lookUpEdit1.EditValue != null)
                queries[0] += ",yarnBrand='" + this.YarnBrand_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",yarnBrand=null";
            if (this.YarnDesc_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnDescription='" + this.YarnDesc_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnDescription=null";
            if (this.YarnCottonOrigin_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnCottonOrigin='" + this.YarnCottonOrigin_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnCottonOrigin=null";
            if (this.YarnConeWeight_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnConeWeight='" + this.YarnConeWeight_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnConeWeight=null";
            if (this.YarnConesPerBag_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnConesPerBag='" + this.YarnConesPerBag_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnConesPerBag=null";
            if (this.YarnLbsPerBag_lookUpEdit1.EditValue != null)
                queries[0] += ",YarnLbsPerBag='" + this.YarnLbsPerBag_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",YarnLbsPerBag=null";
            if (this.AgentID_lookUpEdit1.EditValue != null)
                queries[0] += ",AgentID='" + this.AgentID_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",AgentID=null";
            if (this.AgentContractRef_textEdit1.EditValue != null)
                queries[0] += ",AgentContractRef='" + this.AgentContractRef_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",AgentContractRef=null";
            if (this.AgentCommissionRate_textEdit1.EditValue != null)
                queries[0] += ",AgentCommission=" + this.AgentCommissionRate_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",AgentCommission=null";
            if (this.PricePerLbs_textEdit1.EditValue != null)
                queries[0] += ",PricePerLbs=" + this.PricePerLbs_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",PricePerLbs=null";
            if (this.QtyBags_textEdit1.EditValue != null)
                queries[0] += ",QtyBags='" + this.QtyBags_textEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",QtyBags=null";
            if (this.WeightLbs_textEdit1.EditValue != null)
                queries[0] += ",WeightLbs=" + this.WeightLbs_textEdit1.EditValue.ToString() + "";
            else
                queries[0] += ",WeightLbs=null";
            if (this.TotalAmount.EditValue != null)
                queries[0] += ",TotalAmount=" + this.TotalAmount.EditValue.ToString() + "";
            else
                queries[0] += ",TotalAmount=null";
            if (this.PaymentTerms_lookUpEdit1.EditValue != null)
                queries[0] += ",PaymentTerms='" + this.PaymentTerms_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",PaymentTerms=null";
            if (this.DeliveryTerms_lookUpEdit1.EditValue != null)
                queries[0] += ",DeliveryTerms='" + this.DeliveryTerms_lookUpEdit1.EditValue.ToString() + "'";
            else
                queries[0] += ",DeliveryTerms=null";
            if (this.DeliveryDueDate_dateEdit1.EditValue != null)
                queries[0] += ",DeliveryDueDate='" + this.DeliveryDueDate_dateEdit1.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            else
                queries[0] += ",DeliveryDueDate=null";
            if (this.Remarks_textEdit.EditValue != null)
                queries[0] += ",Remarks='" + this.Remarks_textEdit.Text + "'";
            else
                queries[0] += ",Remarks=null";

            queries[0] += "where YarnContractNumber='"+this.YarnContractNumber_textEdit1.Tag.ToString()+"'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from  YN_YarnContracts_Terms  where YarnContractNumber='"+this.YarnContractNumber_textEdit1.Tag.ToString()+"'";
            foreach (Control c in this.tableLayoutPanel_Terms.Controls)
            {
                TextEdit Rem = (TextEdit)c;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into YN_YarnContracts_Terms (YarnContractNumber,Terms) Values ('" + this.YarnContractNumber_textEdit1.Text + "','" + Rem.Text + "')";
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
                    this.Print.Tag = this.YarnContractNumber_textEdit1.Text;
                    RefreshAndClear();

                    set_ButtonStates(UserInputMode.View);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteContract()
        {

          
            
            if (this.YarnContractNumber_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("Invalid contract Number", "Error", MessageBoxButtons.OK);
                return;
            }

            DialogResult dg = XtraMessageBox.Show("Are you sure to delete " + this.YarnContractNumber_textEdit1.Tag.ToString() + "  ?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;
      
            string[] queries = new string[0];
            Array.Resize(ref queries, 1);

            queries[0] = "delete from  YN_YarnContracts_Terms where YarnContractNumber='" + this.YarnContractNumber_textEdit1.Tag.ToString() + "'";
            Array.Resize(ref queries, 1);

            queries[1] = "delete from  YN_YarnContracts where YarnContractNumber='"+this.YarnContractNumber_textEdit1.Tag.ToString()+"'";
           



          
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
                    RefreshAndClear();

                    set_ButtonStates(UserInputMode.View);

                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            
                if (uiMode == UserInputMode.Add)
                {

                    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Add, docState.Open);
                    if (canProceed == false)
                    {
                        XtraMessageBox.Show("You don't have rights to add new document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    SaveNewContract();
                }
                else if (uiMode == UserInputMode.Edit)
                {

                    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Edit,MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                    if (canProceed == false)
                    {
                        XtraMessageBox.Show("You don't have rights to edit this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    EditContract();
                }
                else if (uiMode == UserInputMode.Delete)
                {
                    bool canProceed = MachineEyes.Classes.Security.User.CheckDocumentValidation(mode.Delete, MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                    if (canProceed == false)
                    {
                        XtraMessageBox.Show("You don't have rights to delete this document , please contact your system administrator !", "Security", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DeleteContract();
                }
              
           
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (YarnContractNumber_textEdit1.Tag == null)
            {
                XtraMessageBox.Show("invalid Yarn Contract Number", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = WS.svc.Get_DataSet("select * from QYN_YarnContracts where YarnContractNumber='" + this.YarnContractNumber_textEdit1.Tag.ToString() + "'");
            if (ds == null)
            {
                XtraMessageBox.Show("No Records Founds", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ds.Tables[0].Rows.Count<=0)
            {
                XtraMessageBox.Show("No Records Founds", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Reports.YarnContract yContract = new Reports.YarnContract();
            yContract.repH_Address.Text = Program.ss.Machines.PresentationData.CPInfo.cpAddress;
            yContract.RepH_Barcode.Text = ds.Tables[0].Rows[0]["YarnContractNumber"].ToString();
            yContract.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            yContract.repH_Email.Text = Program.ss.Machines.PresentationData.CPInfo.cpEmail;
            yContract.repH_GST.Text = Program.ss.Machines.PresentationData.CPInfo.cpSTN;
            yContract.repH_NTN.Text = Program.ss.Machines.PresentationData.CPInfo.cpNTN;
            yContract.DataSource = ds.Tables[0];
            yContract.ShowPreview();

            
        }

        private void Reload_Suppliers_Click(object sender, EventArgs e)
        {
            YarnSuppliers();
        }

        private void Reload_Counts_Click(object sender, EventArgs e)
        {
            YarnCounts();
        }

        private void Reload_Blends_Click(object sender, EventArgs e)
        {
            YarnBlends();
        }

        private void Reload_Agents_Click(object sender, EventArgs e)
        {
            Agents();
        }

        private void Reload_Brands_Click(object sender, EventArgs e)
        {
            YarnBrands();
        }

        private void Reload_Terms_Click(object sender, EventArgs e)
        {
            PaymentTerms();
        }

        private void AddPaymentTerms_Click(object sender, EventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Payment terms", "Paymentterms", "PP_Paymentterms");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void Reload_DeliveryTerms_Click(object sender, EventArgs e)
        {
            DeliveryTerms();
        }

        private void Reload_ConesPerBag_Click(object sender, EventArgs e)
        {
            YarnConesPerBag();
        }

        private void Reload_LbsPerBag_Click(object sender, EventArgs e)
        {
            YarnLbsPerBag();
        }

        private void Reload_CottonOrigin_Click(object sender, EventArgs e)
        {
            YarnCottonOrigins();
        }

        private void Reload_YarnDesc_Click(object sender, EventArgs e)
        {
            YarnDesc();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            YarnConeWeight();
        }

        private void YarnLbsPerBag_lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void YarnLbsPerBag_lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }
        private void Calculations()
        {
            if (YarnLbsPerBag_lookUpEdit1.EditValue != null)
            {
                if (QtyBags_textEdit1.EditValue != null)
                {
                    double lbsperbag = 0, qtybags = 0, totallbs = 0, priceperlbs = 0, amount = 0;
                    double.TryParse(YarnLbsPerBag_lookUpEdit1.EditValue.ToString(), out lbsperbag);
                    double.TryParse(QtyBags_textEdit1.EditValue.ToString(), out  qtybags);
                    totallbs = lbsperbag * qtybags;
                    this.WeightLbs_textEdit1.EditValue = totallbs;
                    if (PricePerLbs_textEdit1.EditValue != null)
                    {
                        double.TryParse(PricePerLbs_textEdit1.EditValue.ToString(), out priceperlbs);
                        amount = priceperlbs * totallbs;
                        this.TotalAmount.EditValue = amount;

                    }
                }
            }
        }

        private void PricePerLbs_textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void QtyBags_textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void WeightLbs_textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        

     

       
    }
}