using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.PO.POUserControls
{
    public partial class xu_SalesArticle_Greige : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_SalesArticle_Greige()
        {
            InitializeComponent();
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleGreigeView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                       
                        this.scroll_Warp.Controls.Clear();
                        this.scroll_Weft.Controls.Clear();
                        this.scroll_Fancy.Controls.Clear();
                        this.ArticleNumber.Text = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                        this.ArticleName.Text = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;
                        
                        DataSet ds = WS.svc.Get_DataSet("Select * from PP_Article where ArticleNumber='" + Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID + "'");
                        if (ds != null)
                        {

                            for (int x = 0; x <= 5; x++)
                            {
                                if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                {
                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                    if (this.scroll_Warp.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Warp.Controls[this.scroll_Warp.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Warp.Controls.Add(dytb);
                                    //PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["WarpWeight_" + x.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = ds.Tables[0].Rows[0]["WarpWeight_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["WarpYarnPly_" + x.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = ds.Tables[0].Rows[0]["WarpYarnPly_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["WarpYarnBlend_" + x.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = ds.Tables[0].Rows[0]["WarpYarnBlend_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["WarpYarnDesc_" + x.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = ds.Tables[0].Rows[0]["WarpYarnDesc_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;


                                }



                            }
                            for (int x = 0; x <= 5; x++)
                            {
                                if (ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString() != "")
                                {
                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                    if (this.scroll_Weft.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Weft.Controls[this.scroll_Weft.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Weft.Controls.Add(dytb);
                                   // PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["WeftWeight_" + x.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = ds.Tables[0].Rows[0]["WeftWeight_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["WeftYarnPly_" + x.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = ds.Tables[0].Rows[0]["WeftYarnPly_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["WeftYarnBlend_" + x.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = ds.Tables[0].Rows[0]["WeftYarnBlend_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["WeftYarnDesc_" + x.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = ds.Tables[0].Rows[0]["WeftYarnDesc_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;

                                }



                            }

                            for (int x = 0; x <= 5; x++)
                            {
                                if (ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString() != "")
                                {
                                    POUserControls.PO_YarnGreige dytb = new POUserControls.PO_YarnGreige();
                                    if (this.scroll_Fancy.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Fancy.Controls[this.scroll_Fancy.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Fancy.Controls.Add(dytb);
                                    // PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["FancyWeight_" + x.ToString() + ""].ToString() != "")
                                        dytb.Weight.EditValue = ds.Tables[0].Rows[0]["FancyWeight_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Weight.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["FancyYarnPly_" + x.ToString() + ""].ToString() != "")
                                        dytb.Ply.EditValue = ds.Tables[0].Rows[0]["FancyYarnPly_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Ply.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["FancyYarnBlend_" + x.ToString() + ""].ToString() != "")
                                        dytb.Blends.EditValue = ds.Tables[0].Rows[0]["FancyYarnBlend_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Blends.EditValue = null;

                                    if (ds.Tables[0].Rows[0]["FancyYarnDesc_" + x.ToString() + ""].ToString() != "")
                                        dytb.Desc.EditValue = ds.Tables[0].Rows[0]["FancyYarnDesc_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Desc.EditValue = null;

                                }



                            }


                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void xu_SalesArticle_Greige_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();

            fc.Currencies(ref this.Currency);
            fc.Currencies(ref this.ExchangeCurrency);
        }
        private void TakeAction(KeyEventArgs e)
        {
            if (e.Control == false) return;
            if (e.KeyCode == Keys.Delete)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }
            else if (e.KeyCode == Keys.Insert)
            {
                xu_SalesArticle_Greige nControl = new xu_SalesArticle_Greige();

                nControl.Text = this.Text;
                this.Parent.Controls.Add(nControl);
            }

            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }

        }

        private void QuantityLbs_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLbs();
        }
        private void CalculateLbs()
        {
         
            double dTotalMeters = 0;
          
          
            if (this.QuantityMtrs.EditValue != null)
                double.TryParse(this.QuantityMtrs.EditValue.ToString(), out dTotalMeters);
            else
                dTotalMeters = 0;
         
          
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)this.scroll_Warp.Controls[x];
                py.MetersRequired = dTotalMeters;
                py.AutoFillQuantities();
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                POUserControls.PO_YarnGreige py = (POUserControls.PO_YarnGreige)this.scroll_Weft.Controls[x];
                py.MetersRequired = dTotalMeters;
                py.AutoFillQuantities();
            }
        }

        private void LbsPerMeter_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLbs();
        }

        private void QuantityMtrs_EditValueChanged(object sender, EventArgs e)
        {
            CalculateLbs();
            CalculatePrice();
        }

        private void ArticleNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (ArticleNumber.EditValue != null)
            {
                article f = Program.ss.Machines.PresentationData.Return_Article(ArticleNumber.EditValue.ToString());
                if (f != null)
                {
                    this.ArticleName.EditValue = f.ArticleName;
                   
                }
                else
                {
                    this.ArticleName.EditValue = null;
                }
            }
            else
                this.ArticleName.EditValue = null;
            CalculateLbs();
            CalculatePrice();
        }
        private void CalculatePrice()
        {
            double dRatePerMeter = 0;
            double dTotalMeters = 0;
            double dTotalPrice = 0;
            if (this.QuantityMtrs.EditValue != null)
                double.TryParse(this.QuantityMtrs.EditValue.ToString(), out dTotalMeters);
            else
                dTotalMeters = 0;
            if (this.Price.EditValue != null)
                double.TryParse(this.Price.EditValue.ToString(), out dRatePerMeter);
            else
                dRatePerMeter = 0;
            dTotalPrice = dRatePerMeter * dTotalMeters;
            dTotalPrice = Math.Round(dTotalPrice, 0);
            this.Amount.EditValue = dTotalPrice;
        }
        private void Price_EditValueChanged(object sender, EventArgs e)
        {

            CalculatePrice();

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }
    }
}
