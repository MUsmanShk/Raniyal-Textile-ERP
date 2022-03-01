using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MachineEyes.Classes;
namespace MachineEyes.PO
{
    public partial class Fabric_Contract_Sales_Greige : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        private string G_Invoice;
        private string N_Invoice;
        public Fabric_Contract_Sales_Greige()
        {
            InitializeComponent();

            this.Prefix.Text = "FSC";
            G_Invoice = "FSX";
            N_Invoice = "NSC";
            this.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            this.NG.Tag = "G";
            this.ExpiryDate.DateTime = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0));
            this.Dated.DateTime = DateTime.Now;
            UserControls.dxTerms deliveryterms = new UserControls.dxTerms();
            deliveryterms.typeTerms = TermsType.Delivery;
            tableLayoutPanel_DeliveryTerms.Controls.Add(deliveryterms);
            UserControls.dxTerms payment = new UserControls.dxTerms();
            payment.typeTerms = TermsType.Payment;
            this.tableLayoutPanel_Paymentterms.Controls.Add(payment);
            UserControls.dxTerms general = new UserControls.dxTerms();
            general.typeTerms = TermsType.General;
            this.tableLayoutPanel_Generalterms.Controls.Add(general);
            POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
            this.tableLayoutPanel_Article.Controls.Add(SalesArticle);
            FillCombos fc = new FillCombos();
            fc.Departments_Sub(ref this.WeavingDepartment,"1");

        }
        private bool GetNextInvoiceNumber()
        {
            string iNumber; string query;
            try
            {
                try
                {
                    query = "select max(Convert(numeric(18),SubString(PONumber,8,6)))+1 as MaxNumber  from FC_PO_Main where iYear='" + this.FinancialYear.Text + "' and iType='" + this.Prefix.Text + "' and iCat='" + this.NG.Tag + "' and NumberType='0'";
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

        private void SetButtonStates(UserInputMode uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                    Execute.Enabled = false;
                   
                    Add.Enabled = true;

                    View.Enabled = true;


                    if (Suffix.Tag != null)
                    {
                        if (Suffix.Tag.ToString() != "")
                        {

                            Edit.Enabled = true;
                            Delete.Enabled = true;
                            return;
                        }
                        else
                        {
                            Edit.Enabled = false;
                            Delete.Enabled = false;
                        }
                    }
                    else
                    {
                        Edit.Enabled = false;
                        Delete.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:
                    Suffix.Tag = "";
                    Cancelit.Enabled = true;
                    Add.Enabled = false;
                    
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    View.Enabled = false;
                    Delete.Enabled = false;


                    break;
                case UserInputMode.Edit:
                    Add.Enabled = false;
                    Cancelit.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                case UserInputMode.Delete:
                    Add.Enabled = false;
                    Cancelit.Enabled = true;
                    Execute.Enabled = true;
                    Edit.Enabled = false;

                    Delete.Enabled = false;
                    View.Enabled = false;

                    break;
                default:
                    break;
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





            if (this.NumberType.EditValue.ToString() == "0")
            {

                bool rRes = GetNextInvoiceNumber();
            }

            SetButtonStates(UserInputMode.Add);
            if (tableLayoutPanel_Article.Controls.Count <= 0)

            {

                POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                this.tableLayoutPanel_Article.Controls.Add(SalesArticle);
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


            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
            if (this.ExpiryDate.DateTime == null)
            {
                XtraMessageBox.Show("Expriry Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ExpiryDate.Focus();
                return;
            }
            if (this.ExpiryDate.EditValue == null)
            {
                XtraMessageBox.Show("Expriry Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ExpiryDate.Focus();
                return;
            }
          
           
           

            if (this.BuyerID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Buyer", "Error");
                return;
            }
            if (this.SellerID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Seller", "Error");
                return;
            }
            
            if (WeavingDepartment.EditValue == null)
            {
                XtraMessageBox.Show("invalid department", "Error");
                return;
            }
            foreach (Control c in this.tableLayoutPanel_Article.Controls)
            {
                POUserControls.xu_SalesArticle_Greige s = (POUserControls.xu_SalesArticle_Greige)c;
                if (s.ArticleNumber.EditValue == null)
                {
                    XtraMessageBox.Show("invalid article #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                if (s.Currency.EditValue == null)
                {
                    XtraMessageBox.Show("invalid currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                if (s.Price.EditValue == null)
                {
                    XtraMessageBox.Show("invalid price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (s.QuantityMtrs.EditValue == null)
                {
                    XtraMessageBox.Show("invalid quantity Mtrs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (s.ExchangeCurrency.EditValue == null)
                {
                    XtraMessageBox.Show("invalid exchange currency", "Validation");
                    return;
                }
                if (s.ExchangeRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid exchange Rate", "Validation");
                    return;
                }
                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Warp.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count Warp", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply Warp", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend Warp", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio Warp", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs Warp", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at Warp", "Error");
                        return;
                    }
                 

                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Weft.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count weft", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply weft", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend weft", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio weft", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs weft", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at weft", "Error");
                        return;
                    }
                 
                }
                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Fancy.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count fancy ", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply fancy ", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend fancy ", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio fancy", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs fancy ", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at fancy", "Error");
                        return;
                    }

                }

               
            }

          
            string[] queries = new string[0];
            string vnum = "";
            if (this.NumberType.EditValue.ToString() == "0")
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
                vnum = this.Suffix.Text;

            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (this.NumberType.EditValue.ToString() == "0")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("PO Number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }


            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "insert into FC_PO_Main (NumberType,POTypeID,PONumber,iType,iCat,iYear,iStatus,Dated,ExpiryDate,BuyerID,AgentID,SellerID,ReferenceNumber,CommissionRate,DeptID,cUserID,cUserTime) Values (";
            queries[queries.Length - 1] += "'" + this.NumberType.EditValue.ToString() + "','3','" + vnum + "','" + this.Prefix.Text + "','" + vCat + "','" + this.FinancialYear.Text + "','U'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ExpiryDate.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ExpiryDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.BuyerID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.BuyerID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";

            if (this.Agent.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.Agent.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.SellerID.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.SellerID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.ReferenceNumber.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.ReferenceNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            if (this.CommissionRate.EditValue != null)
                queries[queries.Length - 1] += "," +CommissionRate.EditValue.ToString()+ "";
            else
                queries[queries.Length - 1] += ",0";
            if (this.WeavingDepartment.EditValue != null)
                queries[queries.Length - 1] += ",'" + this.WeavingDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",null";
            queries[queries.Length - 1] += ",'" + MachineEyes.Classes.Security.User.SCodes.UserID + "','" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += ")";



            foreach (Control c in this.tableLayoutPanel_Article.Controls)
            {
                POUserControls.xu_SalesArticle_Greige s = (POUserControls.xu_SalesArticle_Greige)c;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into FC_PO_YarnRequired (PONO,ArticleNumber,Price,Amount,Currency,POQTYMtrs,ExchangeRate,ExchangeCurrency,WarpYarnPerMeter,WeftYarnPerMeter,SizingRatePerMeter,WeavingRatePerMeter";
                

                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",WarpYarnWastage_" + x.ToString() + ",WarpYarnRatio_" + x.ToString() + ",WarpYarnLbsPerBag_" + x.ToString() + ",WarpYarnLbsRequired_" + x.ToString() + ",WarpYarnBagsRequired_" + x.ToString() + ",warpyarncount_" + x.ToString() + ",warpyarnply_" + x.ToString() + ",warpyarnblend_" + x.ToString() + ",warpyarndesc_" + x.ToString() + ",warpyarncolor_" + x.ToString() + ",warpyarnends_" + x.ToString() + ",warpyarnrates_" + x.ToString();

                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",WeftYarnWastage_" + x.ToString() + ",WeftYarnRatio_" + x.ToString() + ",WeftYarnLbsPerBag_" + x.ToString() + ",WeftYarnLbsRequired_" + x.ToString() + ",WeftYarnBagsRequired_" + x.ToString() + ",weftyarncount_" + x.ToString() + ",weftyarnply_" + x.ToString() + ",weftyarnblend_" + x.ToString() + ",weftyarndesc_" + x.ToString() + ",weftyarncolor_" + x.ToString() + ",weftyarnpicks_" + x.ToString() + ",weftyarnrates_" + x.ToString();


                }
                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",FancyYarnWastage_" + x.ToString() + ",FancyYarnRatio_" + x.ToString() + ",FancyYarnLbsPerBag_" + x.ToString() + ",FancyYarnLbsRequired_" + x.ToString() + ",FancyYarnBagsRequired_" + x.ToString() + ",fancyyarncount_" + x.ToString() + ",fancyyarnply_" + x.ToString() + ",fancyyarnblend_" + x.ToString() + ",fancyyarndesc_" + x.ToString() + ",fancyyarncolor_" + x.ToString() + ",fancyyarnpicks_" + x.ToString() + ",fancyyarnrates_" + x.ToString();


                }
               
                queries[queries.Length - 1] += " ) Values ( '" + vnum + "'";

                if (s.ArticleNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.ArticleNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";

                
                if (s.Price.EditValue != null)
                    queries[queries.Length - 1] += "," + s.Price.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.Amount.EditValue != null)
                    queries[queries.Length - 1] += "," + s.Amount.EditValue + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.Currency.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.Currency.EditValue + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.QuantityMtrs.EditValue != null)
                    queries[queries.Length - 1] += "," + s.QuantityMtrs.EditValue + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (s.ExchangeRate.EditValue != null)
                    queries[queries.Length - 1] += "," + s.ExchangeRate.EditValue + "";
                else
                    queries[queries.Length - 1] += ",1";
                if (s.ExchangeCurrency.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.ExchangeCurrency.EditValue + "'";
                else
                    queries[queries.Length - 1] += ",null";

                if (s.WarpYarnPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WarpYarnPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.WeftYarnPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WeftYarnPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.SizingPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.SizingPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.WeavingPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WeavingPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Warp.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.LbsPerBag.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Weft.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.LbsPerBag.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";


                }
                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Fancy.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.LbsPerBag.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";


                }
                queries[queries.Length - 1] += ")";
            }
            


            foreach (Control c in this.tableLayoutPanel_DeliveryTerms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',0";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
                }
            }
            foreach (Control c in this.tableLayoutPanel_Generalterms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',2";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
                }
            }
            foreach (Control c in this.tableLayoutPanel_Paymentterms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',1";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
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

                    this.Print.Tag = vnum;
                    this.Suffix.Text = "";
                    this.tableLayoutPanel_Paymentterms.Controls.Clear();
                    this.tableLayoutPanel_Generalterms.Controls.Clear();
                    this.tableLayoutPanel_DeliveryTerms.Controls.Clear();
                    this.tableLayoutPanel_Article.Controls.Clear();
                   
                    this.Suffix.Tag = null;
                    this.BuyerID.EditValue = null;
                    this.BuyerName.Text = "";
                    this.Agent.EditValue = null;
                    this.AgentName.Text = "";

                    UserControls.dxTerms deliveryterms = new UserControls.dxTerms();
                    deliveryterms.typeTerms = TermsType.Delivery;
                    tableLayoutPanel_DeliveryTerms.Controls.Add(deliveryterms);


                    UserControls.dxTerms payment = new UserControls.dxTerms();
                    payment.typeTerms = TermsType.Payment;
                    this.tableLayoutPanel_Paymentterms.Controls.Add(payment);
                    UserControls.dxTerms general = new UserControls.dxTerms();
                    general.typeTerms = TermsType.General;
                    this.tableLayoutPanel_Generalterms.Controls.Add(general);
                   

                    POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                    this.tableLayoutPanel_Article.Controls.Add(SalesArticle);

                    SetButtonStates(UserInputMode.View);
                    this.Add.Focus();
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void DeleteExisting()
        {
           
            if (this.Suffix.Text == "")
            {
                XtraMessageBox.Show("Voucher Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }

           
           
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("Number is not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Suffix.Focus();
                return;
            }


            DialogResult dg = XtraMessageBox.Show("Are you sure to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
          




          

          


            string[] queries = new string[0];

            string vnumtoUpdate = "";
            if (this.NumberType.EditValue.ToString() == "0")
                vnumtoUpdate = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            else
            vnumtoUpdate=this.Suffix.Tag.ToString();
            



            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_YarnRequired where PONO='" + vnumtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_Terms where PONumber='" + vnumtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_Main where PONumber='"+vnumtoUpdate+"'";

        
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

                   
                    this.Suffix.Text = "";
                    this.tableLayoutPanel_Paymentterms.Controls.Clear();
                    this.tableLayoutPanel_Generalterms.Controls.Clear();
                    this.tableLayoutPanel_DeliveryTerms.Controls.Clear();
                    this.tableLayoutPanel_Article.Controls.Clear();
                    this.Suffix.Tag = null;
                    this.BuyerID.EditValue = null;
                    this.BuyerName.Text = "";
                    this.Agent.EditValue = null;
                    this.AgentName.Text = "";

                    UserControls.dxTerms deliveryterms = new UserControls.dxTerms();
                    deliveryterms.typeTerms = TermsType.Delivery;
                    tableLayoutPanel_DeliveryTerms.Controls.Add(deliveryterms);
                    
                    UserControls.dxTerms payment = new UserControls.dxTerms();
                    payment.typeTerms = TermsType.Payment;
                    this.tableLayoutPanel_Paymentterms.Controls.Add(payment);
                    UserControls.dxTerms general = new UserControls.dxTerms();
                    general.typeTerms = TermsType.General;
                    this.tableLayoutPanel_Generalterms.Controls.Add(general);

                    POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                    this.tableLayoutPanel_Article.Controls.Add(SalesArticle);

                    SetButtonStates(UserInputMode.View);
                    this.Add.Focus();
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
                XtraMessageBox.Show("invalid sales PO series", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.ExpiryDate.DateTime == null)
            {
                XtraMessageBox.Show("Expriry Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ExpiryDate.Focus();
                return;
            }
            if (this.ExpiryDate.EditValue == null)
            {
                XtraMessageBox.Show("Expriry Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.ExpiryDate.Focus();
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

           
           
            if (this.FinancialYear.Tag ==null)
            {
                XtraMessageBox.Show("Financial Year is invalid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           




            if (this.Dated.EditValue == null)
            {
                XtraMessageBox.Show("Date / Time Value not valid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dated.Focus();
                return;
            }
           

            if (this.BuyerID.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Party", "Error");
                return;
            }
           
          
            foreach (Control c in this.tableLayoutPanel_Article.Controls)
            {
                POUserControls.xu_SalesArticle_Greige s = (POUserControls.xu_SalesArticle_Greige)c;
                if (s.ArticleNumber.EditValue == null)
                {
                    XtraMessageBox.Show("invalid article #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (s.Currency.EditValue == null)
                {
                    XtraMessageBox.Show("invalid currency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                if (s.Price.EditValue == null)
                {
                    XtraMessageBox.Show("invalid price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (s.QuantityMtrs.EditValue == null)
                {
                    XtraMessageBox.Show("invalid quantity Mtrs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (s.ExchangeCurrency.EditValue != null)
                {
                    if (s.ExchangeCurrency.EditValue.ToString() == "")
                        s.ExchangeCurrency.EditValue = "PKR";
                }
                if (s.ExchangeRate.EditValue != null)
                {
                    if (s.ExchangeRate.EditValue.ToString() == "")
                        s.ExchangeRate.EditValue = "1";
                }
                if (s.ExchangeCurrency.EditValue == null)
                {
                    XtraMessageBox.Show("invalid exchange currency", "Validation");
                    return;
                }
                if (s.ExchangeRate.EditValue == null)
                {
                    XtraMessageBox.Show("invalid exchange Rate", "Validation");
                    return;
                }
                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Warp.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count Warp", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply Warp", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend Warp", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio Warp", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs Warp", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at Warp", "Error");
                        return;
                    }
                    


                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Weft.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count weft", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply weft", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend weft", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio weft", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs weft", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at weft", "Error");
                        return;
                    }
                  

                }

                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Fancy.Controls[x];
                    if (py.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid count fancy ", "Error");
                        return;
                    }
                    if (py.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ply fancy ", "Error");
                        return;
                    }
                    if (py.Blends.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid blend fancy ", "Error");
                        return;
                    }

                    if (py.Weight.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid ratio fancy", "Error");
                        return;
                    }
                    if (py.Lbs.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid lbs fancy ", "Error");
                        return;
                    }
                    if (py.WastageAllowed.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid allowed wastage at fancy", "Error");
                        return;
                    }

                }


            }

            if (this.WeavingDepartment.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Weaving department", "Error");
                return;
            }

            string[] queries = new string[0];
            string vnum = "";
            string vnumtoUpdate = "";
            if (this.NumberType.EditValue.ToString() == "0")
            {
                vnumtoUpdate = this.Prefix.Tag.ToString() + this.FinancialYear.Tag.ToString()+  this.Suffix.Tag.ToString();
                vnum = this.Prefix.Text + this.FinancialYear.Text + this.Suffix.Text;
            }
            else
            {
                vnum = this.Suffix.Text;
                vnumtoUpdate = this.Suffix.Tag.ToString();
            }


            char vCat = 'G';
            if (NG.Checked == true)
                vCat = 'N';
            else
                vCat = 'G';
            if (this.NumberType.EditValue.ToString() == "0")
            {
                if (vnum.Length != 13)
                {
                    XtraMessageBox.Show("PO Number is not valid....", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    return;
                }
            }

           
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_Terms where PONumber='" + vnumtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "delete from FC_PO_YarnRequired where PONO='" + vnumtoUpdate + "'";
            Array.Resize(ref queries, queries.Length + 1);
            queries[queries.Length - 1] = "update FC_PO_Main set ";
            queries[queries.Length - 1] += "NumberType='" + this.NumberType.EditValue.ToString() + "',PONumber='" + vnum + "',iType='" + this.Prefix.Text + "',iCat='" + vCat + "',iYear='" + this.FinancialYear.Text + "'";
            if (this.Dated.EditValue != null)
                queries[queries.Length - 1] += ",Dated='" + this.Dated.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",Dated=null";
            if (this.ExpiryDate.EditValue != null)
                queries[queries.Length - 1] += ",ExpiryDate='" + this.ExpiryDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'";
            else
                queries[queries.Length - 1] += ",ExpiryDate=null";
          
                queries[queries.Length - 1] += ",POTypeID='3'";
            
            if (this.BuyerID.EditValue != null)
                queries[queries.Length - 1] += ",BuyerID='" + this.BuyerID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",BuyerID=null";
            if (this.SellerID.EditValue != null)
                queries[queries.Length - 1] += ",SellerID='" + this.SellerID.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",SellerID=null";
            if (this.Agent.EditValue != null)
                queries[queries.Length - 1] += ",AgentID='" + this.Agent.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",AgentID=null";
            if (this.CommissionRate.EditValue != null)
                queries[queries.Length - 1] += ",CommissionRate=" + CommissionRate.EditValue.ToString() + "";
            else
                queries[queries.Length - 1] += ",CommissionRate=0";
           
            if (this.ReferenceNumber.EditValue != null)
                queries[queries.Length - 1] += ",ReferenceNumber='" + this.ReferenceNumber.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",ReferenceNumber=null";
            if (this.WeavingDepartment.EditValue != null)
                queries[queries.Length - 1] += ",DeptID='" + this.WeavingDepartment.EditValue.ToString() + "'";
            else
                queries[queries.Length - 1] += ",DeptID=null";
            queries[queries.Length - 1] += ",eUserID='" + MachineEyes.Classes.Security.User.SCodes.UserID + "',eUserTime='" + DateTime.Now.ToString(MachineEyes.Classes.Accounting.culture) + "'";
            queries[queries.Length - 1] += " where PONumber='" +vnumtoUpdate+"' ";



            foreach (Control c in this.tableLayoutPanel_Article.Controls)
            {
                POUserControls.xu_SalesArticle_Greige s = (POUserControls.xu_SalesArticle_Greige)c;
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "insert into FC_PO_YarnRequired (PONO,ArticleNumber,Price,Amount,Currency,POQTYMtrs,ExchangeRate,ExchangeCurrency,WarpYarnPerMeter,WeftYarnperMeter,SizingRatePerMeter,WeavingRatePerMeter";


                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",WarpYarnWastage_" + x.ToString() + ",WarpYarnRatio_" + x.ToString() + ",WarpYarnLbsPerBag_" + x.ToString() + ",WarpYarnLbsRequired_" + x.ToString() + ",WarpYarnBagsRequired_" + x.ToString() + ",warpyarncount_" + x.ToString() + ",warpyarnply_" + x.ToString() + ",warpyarnblend_" + x.ToString() + ",warpyarndesc_" + x.ToString() + ",warpyarncolor_" + x.ToString() + ",warpyarnends_" + x.ToString() + ",warpyarnrates_" + x.ToString();

                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",WeftYarnWastage_" + x.ToString() + ",WeftYarnRatio_" + x.ToString() + ",WeftYarnLbsPerBag_" + x.ToString() + ",WeftYarnLbsRequired_" + x.ToString() + ",WeftYarnBagsRequired_" + x.ToString() + ",weftyarncount_" + x.ToString() + ",weftyarnply_" + x.ToString() + ",weftyarnblend_" + x.ToString() + ",weftyarndesc_" + x.ToString() + ",weftyarncolor_" + x.ToString() + ",weftyarnpicks_" + x.ToString() + ",weftyarnrates_" + x.ToString();


                }

                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    queries[queries.Length - 1] += ",FancyYarnWastage_" + x.ToString() + ",FancyYarnRatio_" + x.ToString() + ",FancyYarnLbsPerBag_" + x.ToString() + ",FancyYarnLbsRequired_" + x.ToString() + ",FancyYarnBagsRequired_" + x.ToString() + ",fancyyarncount_" + x.ToString() + ",fancyyarnply_" + x.ToString() + ",fancyyarnblend_" + x.ToString() + ",fancyyarndesc_" + x.ToString() + ",fancyyarncolor_" + x.ToString() + ",fancyyarnpicks_" + x.ToString() + ",fancyyarnrates_" + x.ToString();


                }
                queries[queries.Length - 1] += " ) Values ( '" + vnum + "'";

                if (s.ArticleNumber.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.ArticleNumber.EditValue.ToString() + "'";
                else
                    queries[queries.Length - 1] += ",null";


                if (s.Price.EditValue != null)
                    queries[queries.Length - 1] += "," + s.Price.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.Amount.EditValue != null)
                    queries[queries.Length - 1] += "," + s.Amount.EditValue + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.Currency.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.Currency.EditValue + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.QuantityMtrs.EditValue != null)
                    queries[queries.Length - 1] += "," + s.QuantityMtrs.EditValue + "";
                else
                    queries[queries.Length - 1] += ",0";
                if (s.ExchangeRate.EditValue != null)
                    queries[queries.Length - 1] += "," + s.ExchangeRate.EditValue + "";
                else
                    queries[queries.Length - 1] += ",1";
                if (s.ExchangeCurrency.EditValue != null)
                    queries[queries.Length - 1] += ",'" + s.ExchangeCurrency.EditValue + "'";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.WarpYarnPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WarpYarnPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.WeftYarnPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WeftYarnPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.SizingPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.SizingPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                if (s.WeavingPerMeter.EditValue != null)
                    queries[queries.Length - 1] += "," + s.WeavingPerMeter.EditValue.ToString() + "";
                else
                    queries[queries.Length - 1] += ",null";
                for (int x = 0; x < s.scroll_Warp.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Warp.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                }
                for (int x = 0; x < s.scroll_Weft.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Weft.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                }
                for (int x = 0; x < s.scroll_Fancy.Controls.Count; x++)
                {
                    POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)s.scroll_Fancy.Controls[x];
                    if (py.WastageAllowed.EditValue != null)
                        queries[queries.Length - 1] += "," + py.WastageAllowed.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Weight.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Weight.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.LbsPerBag.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Lbs.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Lbs.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Bags.EditValue != null)
                        queries[queries.Length - 1] += "," + py.Bags.EditValue.ToString() + "";
                    else
                        queries[queries.Length - 1] += ",0";
                    if (py.Counts.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Counts.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Ply.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Ply.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Blends.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Blends.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Desc.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Desc.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.Color.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.Color.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.PicksEnds.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.PicksEnds.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";
                    if (py.YarnRate.EditValue != null)
                        queries[queries.Length - 1] += ",'" + py.YarnRate.EditValue.ToString() + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                }

                queries[queries.Length - 1] += ")";
            }
            
            foreach (Control c in this.tableLayoutPanel_DeliveryTerms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',0";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
                }
            }
            foreach (Control c in this.tableLayoutPanel_Generalterms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',2";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
                }
            }
            foreach (Control c in this.tableLayoutPanel_Paymentterms.Controls)
            {
                UserControls.dxTerms s = (UserControls.dxTerms)c;
                if (s.Terms.EditValue != null)
                {
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into FC_PO_Terms (PONumber,TermsTypeID,Terms) Values (";
                    queries[queries.Length - 1] += "'" + vnum + "',1";
                    if (s.Terms.EditValue != null)
                        queries[queries.Length - 1] += ",'" + s.Terms.EditValue + "'";
                    else
                        queries[queries.Length - 1] += ",null";

                    queries[queries.Length - 1] += ")";
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

                    this.Print.Tag = vnum;
                    this.Suffix.Text = "";
                    this.tableLayoutPanel_Paymentterms.Controls.Clear();
                    this.tableLayoutPanel_Generalterms.Controls.Clear();
                    this.tableLayoutPanel_DeliveryTerms.Controls.Clear();
                    this.tableLayoutPanel_Article.Controls.Clear();
                   
                    this.Suffix.Tag = null;
                    this.BuyerID.EditValue = null;
                    this.BuyerName.Text = "";
                    this.Agent.EditValue = null;
                    this.AgentName.Text = "";

                    UserControls.dxTerms deliveryterms = new UserControls.dxTerms();
                    deliveryterms.typeTerms = TermsType.Delivery;
                    tableLayoutPanel_DeliveryTerms.Controls.Add(deliveryterms);
                    
                    UserControls.dxTerms payment = new UserControls.dxTerms();
                    payment.typeTerms = TermsType.Payment;
                    this.tableLayoutPanel_Paymentterms.Controls.Add(payment);
                    UserControls.dxTerms general = new UserControls.dxTerms();
                    general.typeTerms = TermsType.General;
                    this.tableLayoutPanel_Generalterms.Controls.Add(general);

                    POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                    this.tableLayoutPanel_Article.Controls.Add(SalesArticle);

                    SetButtonStates(UserInputMode.View);
                    this.Add.Focus();
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
                DialogResult dg = XtraMessageBox.Show("Are you sure to update this contract !", "Update", MessageBoxButtons.YesNo);
                if (dg != DialogResult.Yes) return;
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
            if (tableLayoutPanel_Article.Controls.Count <= 0)
            {

                POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                this.tableLayoutPanel_Article.Controls.Add(SalesArticle);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.Suffix.Tag == null)
            {
                XtraMessageBox.Show("invalid inspection code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetButtonStates(UserInputMode.Delete);
        }

        private void View_Click(object sender, EventArgs e)
        {
            string strFilterQuery = "";
            DataSet ds = new DataSet();
            selectedrow sRow = new selectedrow();




           


            strFilterQuery = "SELECT PONumber,BuyerName,SellerName,ReferenceNumber from RFC_PO_Main   ";
            strFilterQuery += "  where POTypeID='3'  ";







            Data.Data_View FrmView = new Data.Data_View();
            FrmView.Load_View(strFilterQuery, "PONumber", "BuyerName");
            FrmView.sRow = sRow;
            FrmView.ShowDialog();
            if (sRow.Status == ParameterStatus.Selected)
            {

                if (sRow.SelectedDataRow == null)
                    return;
                this.Print.Tag = sRow.PrimeryID;
                this.View.Tag = sRow.PrimeryID;
                Fill_PO(sRow.PrimeryID);

            }
        }
        private void Fill_PO(string PONUMBER)
        {
            try
            {
                this.Edit.Enabled = false;
                this.Delete.Enabled = false;
                DataSet ds = WS.svc.Get_DataSet("Select * from RFC_PO_Main where PONumber='" + PONUMBER + "'");
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;
                if (ds.Tables[0].Rows[0]["PONumber"].ToString() != "")
                {
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PONUmber"].ToString();
                    this.Suffix.EditValue = ds.Tables[0].Rows[0]["PONumber"].ToString();
                    
                }
                else
                {
                    this.Suffix.Tag = null;
                    this.Suffix.EditValue = null;
                    
                }
               
                if (ds.Tables[0].Rows[0]["BuyerID"].ToString() != "")
                {
                    this.BuyerID.EditValue = ds.Tables[0].Rows[0]["BuyerID"].ToString();
                    this.BuyerName.Text = ds.Tables[0].Rows[0]["BuyerName"].ToString();
                }
                else
                {
                    this.BuyerID.EditValue = null;
                    this.BuyerName.Text = null;
                }

                if (ds.Tables[0].Rows[0]["SellerID"].ToString() != "")
                {
                    this.SellerID.EditValue = ds.Tables[0].Rows[0]["SellerID"].ToString();
                    this.SellerName.Text = ds.Tables[0].Rows[0]["SellerName"].ToString();
                }
                else
                {
                    this.SellerID.EditValue = null;
                    this.SellerName.Text = null;
                }
                if (ds.Tables[0].Rows[0]["Dated"].ToString() != "")
                {
                    this.Dated.EditValue = ds.Tables[0].Rows[0]["Dated"].ToString();
                    
                }
                else
                {
                    this.Dated.EditValue = DateTime.Now;
                    
                }
                if (ds.Tables[0].Rows[0]["ExpiryDate"].ToString() != "")
                {
                    this.ExpiryDate.EditValue = ds.Tables[0].Rows[0]["ExpiryDate"].ToString();

                }
                else
                {
                    this.ExpiryDate.EditValue = DateTime.Now;

                }
                if (ds.Tables[0].Rows[0]["AgentID"].ToString() != "")
                {
                    this.Agent.EditValue = ds.Tables[0].Rows[0]["AgentID"].ToString();
                    this.AgentName.Text = ds.Tables[0].Rows[0]["AgentName"].ToString();
                }
                else
                {
                    this.Agent.EditValue = null;
                    this.AgentName.Text = null;
                }
                if (ds.Tables[0].Rows[0]["DeptID"].ToString() != "")
                {
                    this.WeavingDepartment.EditValue = ds.Tables[0].Rows[0]["DeptID"].ToString();
                    
                }
                else
                {
                    this.WeavingDepartment.EditValue = null;
                   
                }
                this.CommissionRate.Text = ds.Tables[0].Rows[0]["CommissionRate"].ToString();
                this.Status.Tag  = ds.Tables[0].Rows[0]["POStatusID"].ToString();
                this.Status.Text = ds.Tables[0].Rows[0]["POStatusName"].ToString();

                this.tableLayoutPanel_Article.Controls.Clear();
                DataSet dsdetails = WS.svc.Get_DataSet("Select * from FC_PO_YarnRequired where PONO='" + PONUMBER + "'");
                if (dsdetails != null)

                {
                    if (dsdetails.Tables[0].Rows.Count > 0)
                    {
                        for (int x = 0; x < dsdetails.Tables[0].Rows.Count; x++)
                        {
                           
                            POUserControls.xu_SalesArticle_Greige SalesArticle = new POUserControls.xu_SalesArticle_Greige();
                            this.tableLayoutPanel_Article.Controls.Add(SalesArticle);
                            SalesArticle.ArticleNumber.EditValue  = dsdetails.Tables[0].Rows[x]["ArticleNumber"].ToString();
                            //SalesArticle.ArticleName.EditValue = dsdetails.Tables[0].Rows[x]["ArticleShortName"].ToString();
                            SalesArticle.Price.EditValue = dsdetails
                                .Tables[0].Rows[x]["Price"].ToString();
                        
                            SalesArticle.QuantityMtrs.EditValue = dsdetails.Tables[0].Rows[x]["POQTYMtrs"].ToString();
                            SalesArticle.Amount.EditValue = dsdetails.Tables[0].Rows[x]["Amount"].ToString();
                            SalesArticle.Currency.EditValue = dsdetails.Tables[0].Rows[x]["Currency"].ToString();
                            SalesArticle.ExchangeCurrency.EditValue = dsdetails.Tables[0].Rows[x]["ExchangeCurrency"].ToString();
                            if (dsdetails.Tables[0].Rows[x]["WarpYarnPerMeter"].ToString() != "")
                                SalesArticle.WarpYarnPerMeter.EditValue = dsdetails.Tables[0].Rows[x]["WarpYarnPerMeter"].ToString();
                            else
                                SalesArticle.WarpYarnPerMeter.EditValue = null;

                            if (dsdetails.Tables[0].Rows[x]["WeftYarnPerMeter"].ToString() != "")
                                SalesArticle.WeftYarnPerMeter.EditValue = dsdetails.Tables[0].Rows[x]["WeftYarnPerMeter"].ToString();
                            else
                                SalesArticle.WeftYarnPerMeter.EditValue = null;

                            if (dsdetails.Tables[0].Rows[x]["SizingRatePerMeter"].ToString() != "")
                                SalesArticle.SizingPerMeter.EditValue = dsdetails.Tables[0].Rows[x]["SizingRatePerMeter"].ToString();
                            else
                                SalesArticle.SizingPerMeter.EditValue = null;

                            if (dsdetails.Tables[0].Rows[x]["WeavingRatePerMeter"].ToString() != "")
                                SalesArticle.WeavingPerMeter.EditValue = dsdetails.Tables[0].Rows[x]["WeavingRatePerMeter"].ToString();
                            else
                                SalesArticle.WeavingPerMeter.EditValue = null;

                            SalesArticle.ExchangeRate.EditValue = dsdetails.Tables[0].Rows[x]["ExchangeRate"].ToString();
                          double QtyMeters=0;
                          double.TryParse(dsdetails.Tables[0].Rows[x]["POQTYMtrs"].ToString(), out QtyMeters);
                            SalesArticle.scroll_Warp.Controls.Clear();
                            SalesArticle.scroll_Weft.Controls.Clear();
                            SalesArticle.scroll_Fancy.Controls.Clear();
                            for (int xx = 0; xx <= 5; xx++)
                            {
                                if (dsdetails.Tables[0].Rows[0]["WarpYarnCount_" + xx.ToString() + ""].ToString() != "")
                                {

                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                   
                                    if (SalesArticle.scroll_Warp.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = SalesArticle.scroll_Warp.Controls[SalesArticle.scroll_Warp.Controls.Count - 1].Top + dytb.Height;
                                    SalesArticle.scroll_Warp.Controls.Add(dytb);
                                    dytb.MetersRequired = QtyMeters;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnWastage_" + xx.ToString() + ""].ToString() != "")
                                        dytb.WastageAllowed.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnWastage_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.WastageAllowed.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnRatio_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnRatio_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnLbsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Lbs.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnLbsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Lbs.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnBagsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Bags.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnBagsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Bags.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnLbsPerBag_" + xx.ToString() + ""].ToString() != "")
                                        dytb.LbsPerBag.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnLbsPerBag_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.LbsPerBag.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnCount_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnCount_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnPly_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnPly_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnBlend_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnBlend_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnDesc_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnDesc_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnColor_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Color.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnColor_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Color.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnRates_" + xx.ToString() + ""].ToString() != "")
                                        dytb.YarnRate.EditValue = dsdetails.Tables[0].Rows[0]["WarpYarnRates_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.YarnRate.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WarpYarnEnds_" + xx.ToString() + ""].ToString() != "")
                                    {
                                        dytb.PicksEnds.Text = dsdetails.Tables[0].Rows[0]["WarpYarnEnds_" + xx.ToString() + ""].ToString();

                                        dytb.PicksEnds.Visible = true;
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Ends";
                                        dytb.PicksEndsLabel.Text = "Ends";
                                        dytb.PicksEndsLabel.Visible = true;
                                        dytb.PicksEnds.Visible = true;
                                    }
                                    else
                                    {
                                        dytb.PicksEnds.Text = "";
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Ends";
                                        dytb.PicksEnds.Visible = false;
                                        dytb.PicksEndsLabel.Visible = false;
                                    }
                                    
                                }
                                if (dsdetails.Tables[0].Rows[0]["WeftYarnCount_" + xx.ToString() + ""].ToString() != "")
                                {

                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                    if (SalesArticle.scroll_Weft.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = SalesArticle.scroll_Weft.Controls[SalesArticle.scroll_Weft.Controls.Count - 1].Top + dytb.Height;
                                    SalesArticle.scroll_Weft.Controls.Add(dytb);
                                    dytb.MetersRequired = QtyMeters;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnWastage_" + xx.ToString() + ""].ToString() != "")
                                        dytb.WastageAllowed.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnWastage_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.WastageAllowed.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnRatio_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnRatio_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnLbsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Lbs.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnLbsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Lbs.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnBagsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Bags.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnBagsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Bags.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnLbsPerBag_" + xx.ToString() + ""].ToString() != "")
                                        dytb.LbsPerBag.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnLbsPerBag_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.LbsPerBag.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnCount_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnCount_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnPly_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnPly_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnBlend_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnBlend_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnDesc_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnDesc_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnColor_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Color.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnColor_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Color.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnRates_" + xx.ToString() + ""].ToString() != "")
                                        dytb.YarnRate.EditValue = dsdetails.Tables[0].Rows[0]["WeftYarnRates_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.YarnRate.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["WeftYarnPicks_" + xx.ToString() + ""].ToString() != "")
                                    {
                                        dytb.PicksEnds.Text = dsdetails.Tables[0].Rows[0]["WeftYarnPicks_" + xx.ToString() + ""].ToString();

                                        dytb.PicksEnds.Visible = true;
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Picks";
                                        dytb.PicksEndsLabel.Text = "Picks";
                                        dytb.PicksEndsLabel.Visible = true;
                                        dytb.PicksEnds.Visible = true;
                                    }
                                    else
                                    {
                                        dytb.PicksEnds.Text = "";
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Picks";
                                        dytb.PicksEnds.Visible = false;
                                        dytb.PicksEndsLabel.Visible = false;
                                    }

                                }

                                if (dsdetails.Tables[0].Rows[0]["FancyYarnCount_" + xx.ToString() + ""].ToString() != "")
                                {

                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                    if (SalesArticle.scroll_Fancy.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = SalesArticle.scroll_Fancy.Controls[SalesArticle.scroll_Fancy.Controls.Count - 1].Top + dytb.Height;
                                    SalesArticle.scroll_Fancy.Controls.Add(dytb);
                                    dytb.MetersRequired = QtyMeters;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnWastage_" + xx.ToString() + ""].ToString() != "")
                                        dytb.WastageAllowed.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnWastage_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.WastageAllowed.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnRatio_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnRatio_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnLbsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Lbs.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnLbsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Lbs.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnBagsRequired_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Bags.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnBagsRequired_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Bags.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnLbsPerBag_" + xx.ToString() + ""].ToString() != "")
                                        dytb.LbsPerBag.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnLbsPerBag_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.LbsPerBag.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnCount_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnCount_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnPly_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnPly_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnBlend_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnBlend_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnDesc_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnDesc_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnColor_" + xx.ToString() + ""].ToString() != "")
                                        dytb.Color.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnColor_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.Color.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnRates_" + xx.ToString() + ""].ToString() != "")
                                        dytb.YarnRate.EditValue = dsdetails.Tables[0].Rows[0]["FancyYarnRates_" + xx.ToString() + ""].ToString();
                                    else
                                        dytb.YarnRate.EditValue = null;
                                    if (dsdetails.Tables[0].Rows[0]["FancyYarnPicks_" + xx.ToString() + ""].ToString() != "")
                                    {
                                        dytb.PicksEnds.Text = dsdetails.Tables[0].Rows[0]["FancyYarnPicks_" + xx.ToString() + ""].ToString();

                                        dytb.PicksEnds.Visible = true;
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Picks";
                                        dytb.PicksEndsLabel.Text = "Picks";
                                        dytb.PicksEndsLabel.Visible = true;
                                        dytb.PicksEnds.Visible = true;
                                    }
                                    else
                                    {
                                        dytb.PicksEnds.Text = "";
                                        dytb.PicksEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksEnds.Properties.NullValuePrompt = "Picks";
                                        dytb.PicksEnds.Visible = false;
                                        dytb.PicksEndsLabel.Visible = false;
                                    }

                                }



                            }
                              
                            }
                            

                        }
                    }


               
                dsdetails = WS.svc.Get_DataSet("Select * from RFC_PO_Terms where PONumber='" + PONUMBER + "'");
                this.tableLayoutPanel_DeliveryTerms.Controls.Clear();
                this.tableLayoutPanel_Generalterms.Controls.Clear();
                this.tableLayoutPanel_Paymentterms.Controls.Clear();
                if (dsdetails != null)
                {
                    if (dsdetails.Tables[0].Rows.Count > 0)
                    {
                        for (int x = 0; x < dsdetails.Tables[0].Rows.Count; x++)
                        {

                            UserControls.dxTerms terms = new UserControls.dxTerms();
                            if (dsdetails.Tables[0].Rows[x]["TermsTypeID"].ToString() == "1")
                            {
                                this.tableLayoutPanel_Paymentterms.Controls.Add(terms);
                                terms.Terms.EditValue = dsdetails.Tables[0].Rows[x]["Terms"].ToString();
                                terms.typeTerms = TermsType.Payment;
                            }
                            else if (dsdetails.Tables[0].Rows[x]["TermsTypeID"].ToString() == "0")
                            {
                                this.tableLayoutPanel_DeliveryTerms.Controls.Add(terms);
                                terms.Terms.EditValue = dsdetails.Tables[0].Rows[x]["Terms"].ToString();
                                terms.typeTerms = TermsType.Delivery;
                            }
                            else if (dsdetails.Tables[0].Rows[x]["TermsTypeID"].ToString() == "2")
                            {
                                this.tableLayoutPanel_Generalterms.Controls.Add(terms);
                                terms.Terms.EditValue = dsdetails.Tables[0].Rows[x]["Terms"].ToString();
                                terms.typeTerms = TermsType.General;
                            }
                        }


                    }
                }

                if (this.tableLayoutPanel_DeliveryTerms.Controls.Count <= 0)
                {
                    UserControls.dxTerms terms = new UserControls.dxTerms();
                    terms.typeTerms = TermsType.Delivery;
                    this.tableLayoutPanel_DeliveryTerms.Controls.Add(terms);
                }
                if (this.tableLayoutPanel_Generalterms.Controls.Count <= 0)
                {
                    UserControls.dxTerms terms = new UserControls.dxTerms();
                    this.tableLayoutPanel_Generalterms.Controls.Add(terms);
                    terms.typeTerms = TermsType.General;
                }
                if (this.tableLayoutPanel_Paymentterms.Controls.Count <= 0)
                {
                    UserControls.dxTerms terms = new UserControls.dxTerms();
                    this.tableLayoutPanel_Paymentterms.Controls.Add(terms);
                    terms.typeTerms = TermsType.Payment;
                }

                this.NumberType.EditValue = ds.Tables[0].Rows[0]["NumberType"].ToString();
                this.FinancialYear.EditValue = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.Prefix.EditValue = ds.Tables[0].Rows[0]["iType"].ToString();
                this.Prefix.Tag = ds.Tables[0].Rows[0]["iType"].ToString();
                this.FinancialYear.Tag = ds.Tables[0].Rows[0]["iYear"].ToString();
                this.DocumentState.Tag = ds.Tables[0].Rows[0]["iStatus"].ToString();
                this.DocumentState.Image = MachineEyes.Classes.Accounting.ReturnDocStateImage(MachineEyes.Classes.Accounting.ReturnDocState(this.DocumentState.Tag.ToString()));
                if (ds.Tables[0].Rows[0]["NumberType"].ToString() == "0")
                {
                    this.Suffix.Text = ds.Tables[0].Rows[0]["PONumber"].ToString().Substring(7, 6);
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PONumber"].ToString().Substring(7, 6);

                }
                else
                {
                    this.Suffix.EditValue = ds.Tables[0].Rows[0]["PONumber"].ToString();
                    this.Suffix.Tag = ds.Tables[0].Rows[0]["PONumber"].ToString();
                }
                this.Print.Tag = ds.Tables[0].Rows[0]["PONumber"].ToString();
                this.Edit.Enabled = true;
                this.Delete.Enabled = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Cancelit_Click(object sender, EventArgs e)
        {
            SetButtonStates(UserInputMode.View);
        }

        private void Clostit_Click(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (this.Print.Tag != null)
            {
                if (this.Print.Tag.ToString() != "")
                {
                    Printing.Print_FC_PO_Greige(this.Print.Tag.ToString(), "F");
                }
            }
        }

        private void groupControl9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Party_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
               
                Data.Data_Accounts_View AView = new Data.Data_Accounts_View();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.BuyerID.EditValue = sRow.PrimeryID;
                        this.BuyerName.Text = sRow.PrimaryString;
                       
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Control == true)
            {
                this.BuyerID.EditValue = null;
                this.BuyerName.Text = "";
               
            }
        }

        private void Agent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();
                Data.Data_Accounts_View AView = new Data.Data_Accounts_View();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.Agent.Text = sRow.PrimeryID;
                        this.AgentName.Text = sRow.PrimaryString;
                        
                    }
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Control == true)
            {
                this.Agent.Text = "";
                this.AgentName.Text = "";
               
            }
        }

        private void TotalAmount_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    TextEdit te = (TextEdit)sender;
            //    double amounttotal = 0;
            //    double.TryParse(te.Text, out amounttotal);
            //    this.AmountinWords.Text = MachineEyes.Classes.Accounting.ReturnAmountInWords(amounttotal);
            //}
            //catch
            //{
            //}
        }

        private void Article_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void xtraTabPage_Deliveryandterms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NG_CheckedChanged(object sender, EventArgs e)
        {
            if (NG.Checked == true)
            {
                NG.Image = MachineEyes.Properties.Resources.N32;
                NG.Tag = "N";
                VtypeCap.Text = "[N]";


                this.Prefix.Text = N_Invoice;
               
            }
            else
            {
                NG.Tag = "G";
                VtypeCap.Text = "";
                NG.Image = MachineEyes.Properties.Resources.G32;


                this.Prefix.Text = G_Invoice;
               
            }
        }

        private void SellerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                selectedrow sRow = new selectedrow();

                Data.Data_Accounts_View AView = new Data.Data_Accounts_View();
                AView.sRow = sRow;
                AView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {
                    if (sRow.SelectedDataRow != null)
                    {
                        this.SellerID.EditValue = sRow.PrimeryID;
                        this.SellerName.Text = sRow.PrimaryString;

                    }
                }
            }
            else if (e.KeyCode == Keys.Delete && e.Control == true)
            {
                this.SellerID.EditValue = null;
                this.SellerName.Text = "";

            }
        }

        private void BuyerID_EditValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}