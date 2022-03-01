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
    public partial class xu_SalesArticle : DevExpress.XtraEditors.XtraUserControl
    {
      
        public xu_SalesArticle()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
          
            fc.Currencies(ref this.Currency);
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
                xu_SalesArticle nControl = new xu_SalesArticle();
              
                nControl.Text = this.Text;
                this.Parent.Controls.Add(nControl);
            }

            else if (e.KeyCode == Keys.D && e.Control == true)
            {
                if (this.Parent.Controls.Count > 1)
                    this.Parent.Controls.Remove(this);
            }

        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void ArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Quantity_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }

        private void textEdit4_KeyDown(object sender, KeyEventArgs e)
        {
            TakeAction(e);
        }
        private void PriceCalc()
        {

            try
            {
               
                double wpp = 0;double qtylbs = 0,QtyPcs = 0;
                double WastagePercentage = 0;
                double WastageLbs = 0;
                if (this.WastageAllowed.EditValue == null)
                    this.WastageAllowed.EditValue = "3.50";
                double.TryParse(this.WastageAllowed.EditValue.ToString(), out WastagePercentage);
                if (this.QuantityPcs.EditValue != null)
                {
                    double.TryParse(this.QuantityPcs.EditValue.ToString(), out QtyPcs);

                }
                if (this.WPP.EditValue!= null)
                {
                    double.TryParse(this.WPP.EditValue.ToString(), out wpp);
                    qtylbs =(wpp*2.2046/1000)*QtyPcs;
                    
                    WastageLbs = qtylbs * WastagePercentage / 100;
                    qtylbs = Math.Round(qtylbs + WastageLbs,2);
                    this.QuantityLbs.EditValue = qtylbs.ToString();
                }



                double ppmeter = 0, tAmount = 0;

                if (this.Price.EditValue != null)
                {
                    double.TryParse(this.Price.EditValue.ToString(), out ppmeter);

                }
               

                tAmount = ppmeter * qtylbs;
                this.Amount.EditValue = tAmount;
                 for (int x = 0; x < scroll_Fancy.Controls.Count; x++)
                {
                    UserControls.PO_Yarn py = (UserControls.PO_Yarn)scroll_Fancy.Controls[x];

                    py.LbsTotalRequired=qtylbs;
                    py.AutoFillQuantities();
                }
                 for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                 {
                     UserControls.PO_Yarn py = (UserControls.PO_Yarn)this.scroll_Pile.Controls[x];
                     py.LbsTotalRequired = qtylbs;
                     py.AutoFillQuantities();
                 }
                 for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                 {
                     UserControls.PO_Yarn py = (UserControls.PO_Yarn)this.scroll_Warp.Controls[x];
                     py.LbsTotalRequired = qtylbs;
                     py.AutoFillQuantities();
                 }
                 for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                 {
                     UserControls.PO_Yarn py = (UserControls.PO_Yarn)this.scroll_Weft.Controls[x];
                     py.LbsTotalRequired = qtylbs;
                     py.AutoFillQuantities();
                 }
            }
            catch
            {
            }
        }

        private void Quantity_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }

        private void Price_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }

        private void Unit_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }

        private void ArticleNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.Enter)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleTowelView.ShowDialog();
                try
                {
                    if (Program.MainWindow.ArticleTowelView.SelectedRow.Status != ParameterStatus.Cancelled)
                    {
                        this.scroll_Fancy.Controls.Clear();
                        this.scroll_Pile.Controls.Clear();
                        this.scroll_Warp.Controls.Clear();
                        this.scroll_Weft.Controls.Clear();
                       this.ArticleNumber.Text  = Program.MainWindow.ArticleTowelView.SelectedRow.PrimeryID;
                        this.ArticleName.Text = Program.MainWindow.ArticleTowelView.SelectedRow.PrimaryString;
                        this.WPP.EditValue = Program.MainWindow.ArticleTowelView.SelectedRow.SelectedDataRow["WAA"].ToString();
                        DataSet ds = WS.svc.Get_DataSet("Select * from PP_Article where ArticleNumber='" + Program.MainWindow.ArticleTowelView.SelectedRow.PrimeryID + "'");
                        if (ds != null)
                        {

                            for (int x = 0; x <= 5; x++)
                            {
                                if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                {
                                    UserControls.PO_Yarn dytb = new UserControls.PO_Yarn();
                                    if (this.scroll_Warp.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Warp.Controls[this.scroll_Warp.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Warp.Controls.Add(dytb);
                                    PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

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
                                    UserControls.PO_Yarn dytb = new UserControls.PO_Yarn();
                                    if (this.scroll_Weft.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Weft.Controls[this.scroll_Weft.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Weft.Controls.Add(dytb);
                                    PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

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
                                    UserControls.PO_Yarn dytb = new UserControls.PO_Yarn();
                                    if (this.scroll_Fancy.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Fancy.Controls[this.scroll_Fancy.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Fancy.Controls.Add(dytb);
                                    PriceCalc();
                                    dytb.AutoFillQuantities();
                                    if (ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString() != "")
                                        dytb.Counts.EditValue = ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Counts.EditValue = null;

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
                            for (int x = 0; x <= 5; x++)
                            {
                                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                {


                                    UserControls.PO_Yarn dytb = new UserControls.PO_Yarn();
                                    if (this.scroll_Pile.Controls.Count <= 0) dytb.Top = 0;
                                    else
                                        dytb.Top = this.scroll_Pile.Controls[this.scroll_Pile.Controls.Count - 1].Top + dytb.Height;
                                    this.scroll_Pile.Controls.Add(dytb);
                                    PriceCalc();
                                    dytb.AutoFillQuantities();
                                        if (ds.Tables[0].Rows[0]["PileWarpYarnCount_" + x.ToString() + ""].ToString() != "")
                                            dytb.Counts.EditValue = ds.Tables[0].Rows[0]["PileWarpYarnCount_" + x.ToString() + ""].ToString();
                                        else
                                            dytb.Counts.EditValue = null;

                                        if (ds.Tables[0].Rows[0]["PileWarpYarnPly_" + x.ToString() + ""].ToString() != "")
                                            dytb.Ply.EditValue = ds.Tables[0].Rows[0]["PileWarpYarnPly_" + x.ToString() + ""].ToString();
                                        else
                                            dytb.Ply.EditValue = null;

                                        if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_" + x.ToString() + ""].ToString() != "")
                                            dytb.Blends.EditValue = ds.Tables[0].Rows[0]["PileWarpYarnBlend_" + x.ToString() + ""].ToString();
                                        else
                                            dytb.Blends.EditValue = null;

                                        if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_" + x.ToString() + ""].ToString() != "")
                                            dytb.Desc.EditValue = ds.Tables[0].Rows[0]["PileWarpYarnDesc_" + x.ToString() + ""].ToString();
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

        private void QuantityPcs_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }

        private void WPP_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }

        private void WastageAllowed_EditValueChanged(object sender, EventArgs e)
        {
            PriceCalc();
        }
    }
}
