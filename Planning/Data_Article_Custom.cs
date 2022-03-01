using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Planning
{
    public partial class Data_Article_Custom : DevExpress.XtraEditors.XtraForm
    {
       
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public Data_Article_Custom()
        {
            InitializeComponent();
        }
        

       
        private void dxData_Article_Load(object sender, EventArgs e)
        {


            FillCombos fc = new FillCombos();
            Add_ArticleWarpParams();
            Add_ArticleWeftParams();
         
            fc.ArticleInsertionTypes(ref insertiontype);
            fc.ArticleFabricNames(ref this.FabricName);
            fc.ArticleSelvages(ref Article_Selvages_comboBoxEdit);
            fc.ArticleWeaves(ref Article_Weave_comboBoxEdit);
            set_ButtonStates(UserInputMode.View);
        }

            private void set_ButtonStates(UserInputMode  uim)
        {
            uiMode = uim;
            switch (uim)
            {
                case UserInputMode.View:
                             this.btn_Save.Enabled = false;
                            this.btn_Cancel.Enabled = false;
                            this.btn_Add.Enabled = true;
                            this.btn_Close.Enabled = true;
                            this.btn_View.Enabled = true;
                            set_ReadOnly(true);

                    if (this.Article_Number_textEdit.Tag != null)
                    {
                        if (this.Article_Number_textEdit.Tag.ToString() != "")
                        {
                            
                            this.btn_Edit.Enabled = true;
                            this.btn_Del.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.btn_Edit.Enabled = false;
                            this.btn_Del.Enabled = false;
                    }
                    }
                    else
                    {
                        this.btn_Edit.Enabled = false;
                        this.btn_Del.Enabled = false;
                    }
                    break;
                case UserInputMode.Add:

                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_View.Enabled = false;
                    this.btn_Del.Enabled = false;
                    set_ReadOnly(false);
                    break;
                case UserInputMode.Edit:
                    this.btn_Add.Enabled = false;
                this.btn_Cancel.Enabled = true;
                this.btn_Save.Enabled = true;
                this.btn_Edit.Enabled = false;
                this.btn_Close.Enabled = true;
                this.btn_Del.Enabled = false;
                this.btn_View.Enabled = false;
                set_ReadOnly(false);
                    break;
                case UserInputMode.Delete:
                this.btn_Add.Enabled = false;
                this.btn_Cancel.Enabled = true;
                this.btn_Save.Enabled = true;
                this.btn_Edit.Enabled = false;
                this.btn_Close.Enabled = true;
                this.btn_Del.Enabled = false;
                this.btn_View.Enabled = false;
                set_ReadOnly(false);
                    break;
                default:
                    break;
            }
            
        }
            private string GenerateArticleNumber()
            {
                string iNumber; string query;
                try
                {
                    try
                    {
                        query = "select max(Convert(numeric(18),ArticleNumber)+1 as MaxNumber  from PP_Article where ArticleNumberTypeID<>1";
                        iNumber = WS.svc.Get_MaxNumber(query);
                        if (iNumber.Length > 6)
                        {
                            XtraMessageBox.Show(iNumber, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         
                            return "";
                        }
                        iNumber = iNumber.PadLeft(6, '0');
                        return iNumber;
                       
                    }
                    catch (Exception ex)
                    {

                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return "";
                    }

                    //vNumber = vNumber.PadLeft(6, '0');



                }
                catch
                {
                    
                    return "";
                }
            }
        private void btn_Add_Click(object sender, EventArgs e)
        {
           
           
            try
            {

                if (this.NumberTypeRadio.EditValue.ToString() == "A")
                    this.Article_Number_textEdit.Text = GenerateArticleNumber();
                
            }
            catch
            {
                this.Article_Number_textEdit.Text = "000001";
            }
            
            set_ButtonStates(UserInputMode.Add);
           
           
        }
        private void CalcualteWarpWeight()
        {
           
        }

    
  
        private void Update_Article()
        {
            if (this.Article_Number_textEdit.Tag == null)
            {
                XtraMessageBox.Show("invalid Article selected!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.Article_PPI_textEdit.EditValue == null)
            {
                XtraMessageBox.Show("Invalid Picks Per Inch , must enter ppi value", "PPI Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Article_PPI_textEdit.Focus();
                return;
            }
            int dppi = 0;
            int.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dppi);
            if (dppi <= 0)
            {
                XtraMessageBox.Show("Invalid Picks Per Inch , ppi must not be zero, must enter ppi value", "PPI Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Article_PPI_textEdit.Focus();
                return;
            }
            ////if (this.Article_EPI_textEdit.EditValue == null)
            ////{
            ////    XtraMessageBox.Show("Invalid EPI", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////    return;
            ////}

            ////if (this.Article_PPI_textEdit.EditValue == null)
            ////{
            ////    XtraMessageBox.Show("Invalid PPI", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////    return;
            ////}
            ////if (this.Article_Width_textEdit.EditValue == null)
            ////{
            ////    XtraMessageBox.Show("Invalid Width", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////    return;
            ////}
            ////for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            ////{

            ////    UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
            ////    if (dytb.Counts.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Ply.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Blends.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Desc.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Yarn Desc", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }

            ////}
            ////for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            ////{

            ////    UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
            ////    if (dytb.Counts.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Ply.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Blends.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Blend", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }
            ////    if (dytb.Desc.EditValue == null)
            ////    {
            ////        XtraMessageBox.Show("invalid Yarn Desc", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            ////        return;
            ////    }

            ////}
            if (this.Article_Number_textEdit.EditValue == null)
            {
                XtraMessageBox.Show("invalid article #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

            }
            //if (this.Article_Number_textEdit.Text.Length !=6)
            //{
            //    XtraMessageBox.Show("invalid article #, length must be 6 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

            //}
            if (this.ShortName.EditValue == null)
            {
                XtraMessageBox.Show("invalid article custom name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;

            }
            if (this.ShortName.Text.Length <= 0)
            {
                XtraMessageBox.Show("invalid article custom name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;


            }
            string Articlenumtypeid = "0";
            if (this.NumberTypeRadio.EditValue.ToString() == "A")
                Articlenumtypeid = "1";
            else
                Articlenumtypeid = "0";
            
            //execute save query (save records into database)
            string query = "update PP_Article set ";
            query += "articlenumbertypeid="+Articlenumtypeid+", ArticleNumber='" + this.Article_Number_textEdit.Text + "',ArticleName='" + this.Article_Details_Label.Text + "',ArticleShortName='"+this.ShortName.Text +"'";
            if(this.Article_EPI_textEdit.Text !="")
            query+=",EPI='" + this.Article_EPI_textEdit.Text + "'";
            else
                query+=",EPI=null";
             if(this.Article_PPI_textEdit.Text !="")
            query+=",PPI='" + this.Article_PPI_textEdit.Text + "'";
            else
                query+=",PPI=null";

             if (this.FabricName.EditValue != null)
                 query += ",FabricName='" + this.FabricName.EditValue.ToString() + "'";
             else
                 query += ",FabricName=null";
            
             if (this.Article_Width_textEdit.Text != "")
                 query += ",Width='" + this.Article_Width_textEdit.Text + "'";
             else
                 query += ",Width=null";

          
            
             if (this.Article_Weave_comboBoxEdit.EditValue  !=null)
                 query += ",ArticleWeave='" + this.Article_Weave_comboBoxEdit.EditValue + "'";
             else
                 query += ",ArticleWeave=null";

             if (this.insertiontype.EditValue != null)
                 query += ",InsertionType='" + this.insertiontype.EditValue + "'";
             else
                 query += ",InsertionType=null";
             if (this.Article_Selvages_comboBoxEdit.EditValue != null)
                 query += ",ArticleSelvage='" + this.Article_Selvages_comboBoxEdit.EditValue + "'";
             else
                 query += ",ArticleSelvage=null";
             if (this.Crimp.EditValue != null)
                 query += ",ExpectedCrimp='" + this.Crimp.EditValue + "'";
             else
                 query += ",ExpectedCrimp=0";
             if (this.NoofEnds.EditValue != null)
                 query += ",Noofends=" + this.NoofEnds.EditValue.ToString() + "";
             else
                 query += ",NoofEnds=0";
             if (this.WeightOz.EditValue != null)
                 query += ",WeightOz=" + this.WeightOz.EditValue.ToString() + "";
             else
                 query += ",WeightOz=0";
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",WarpYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",WarpYarnCount_" + x.ToString() + "=null";
                if (dytb.Weight.EditValue != null)
                    query += ",WarpWeight_" + x.ToString() + "=" + (string)dytb.Weight.EditValue + "";
                else
                    query += ",WarpWeight_" + x.ToString() + "=null";
                if (dytb.Ply.EditValue != null)
                    query += ",WarpYarnPly_" + x.ToString() + "='" + (string)dytb.Ply.EditValue + "'";
                else
                    query += ",WarpYarnPly_" + x.ToString() + "=null";

                if (dytb.Blends.EditValue != null)
                    query += ",WarpYarnBlend_" + x.ToString() + "='" + (string)dytb.Blends.EditValue + "'";
                else
                    query += ",WarpYarnBlend_" + x.ToString() + "=null";
                if (dytb.Desc.EditValue != null)
                    query += ",WarpYarnDesc_" + x.ToString() + "='" + (string)dytb.Desc.EditValue + "'";
                else
                    query += ",WarpYarnDesc_" + x.ToString() + "=null";
                if (dytb.Color.EditValue != null)
                    query += ",WarpYarnColor_" + x.ToString() + "='" + (string)dytb.Color.EditValue + "'";
                else
                    query += ",WarpYarnColor_" + x.ToString() + "=null";

                if (dytb.PicksorEnds.Text != "")
                    query += ",WarpYarnEnds_" + x.ToString() + "='" + (string)dytb.PicksorEnds.Text  + "'";
                else
                    query += ",WarpYarnEnds_" + x.ToString() + "=null";
            }

            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",WeftYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",WeftYarnCount_" + x.ToString() + "=null";
                if (dytb.Weight.EditValue != null)
                    query += ",WeftWeight_" + x.ToString() + "=" + (string)dytb.Weight.EditValue + "";
                else
                    query += ",WeftWeight_" + x.ToString() + "=null";
                if (dytb.Ply.EditValue != null)
                    query += ",WeftYarnPly_" + x.ToString() + "='" + (string)dytb.Ply.EditValue + "'";
                else
                    query += ",WeftYarnPly_" + x.ToString() + "=null";

                if (dytb.Blends.EditValue != null)
                    query += ",WeftYarnBlend_" + x.ToString() + "='" + (string)dytb.Blends.EditValue + "'";
                else
                    query += ",WeftYarnBlend_" + x.ToString() + "=null";
                if (dytb.Desc.EditValue != null)
                    query += ",WeftYarnDesc_" + x.ToString() + "='" + (string)dytb.Desc.EditValue + "'";
                else
                    query += ",WeftYarnDesc_" + x.ToString() + "=null";
                if (dytb.Color.EditValue != null)
                    query += ",WeftYarnColor_" + x.ToString() + "='" + (string)dytb.Color.EditValue + "'";
                else
                    query += ",WeftYarnColor_" + x.ToString() + "=null";

                if (dytb.PicksorEnds.Text != "")
                    query += ",WeftYarnPicks_" + x.ToString() + "='" + (string)dytb.PicksorEnds.Text + "'";
                else
                    query += ",WeftYarnPicks_" + x.ToString() + "=null";
            }

            query += " where articlenumber='"+this.Article_Number_textEdit.Tag.ToString()+"'";

            try
            {
                string qres = WS.svc.Execute_Query(query);
                if (qres != "**SUCCESS##")
                    XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    Clear_Article();
                  
                    this.btn_Add.Enabled = true;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false ;
                    this.btn_Edit.Enabled = false ;
                    this.btn_Save.Enabled = false;
                    this.btn_View.Enabled = true;
                    this.uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Updating", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Save_Article()
        {
           
            if (this.Article_Number_textEdit.EditValue == null)
            {
                XtraMessageBox.Show("invalid article #", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
               
            }
            //if (this.Article_Number_textEdit.Text.Length!= 6)
            //{
            //    XtraMessageBox.Show("invalid article #, length must be 6 characters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                
            //}
            if (this.ShortName.EditValue ==null)
            {
                XtraMessageBox.Show("invalid article custom name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
               
            }
            if (this.ShortName.Text.Length<=0)
            {
                XtraMessageBox.Show("invalid article custom name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                
            }
           if(this.Article_PPI_textEdit.EditValue==null)
           {
               XtraMessageBox.Show("Invalid Picks Per Inch , must enter ppi value", "PPI Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.Article_PPI_textEdit.Focus();
               return;
           }
           int dppi = 0;
           int.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dppi);
           if (dppi <= 0)
           {
               XtraMessageBox.Show("Invalid Picks Per Inch , ppi must not be zero, must enter ppi value", "PPI Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
               this.Article_PPI_textEdit.Focus();
               return;
           }
            if (DenimArticleType.EditValue.ToString() == "G")
            {
                if (this.Article_PPI_textEdit.EditValue == null)
                {
                    XtraMessageBox.Show("invalid ppi ", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (this.Article_PPI_textEdit.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("invalid ppi ", "Error", MessageBoxButtons.OK);
                    return;
                }
                if (Article_Weave_comboBoxEdit.EditValue == null)
                {
                    XtraMessageBox.Show("Invalid Article ....for greige denim style weave must be entered!", "Error");
                    return;
                }
                if (Article_Weave_comboBoxEdit.EditValue.ToString() == "")
                {
                    XtraMessageBox.Show("Invalid Article ....for greige denim style weave must be entered!", "Error");
                    return;
                }
                //if (this.NoofEnds.EditValue == null)
                //{
                //    XtraMessageBox.Show("Invalid Article ....for greige denim style ends must be entered!", "Error");
                //    return;
                //}
                //if (this.NoofEnds.EditValue.ToString() == "")
                //{
                //    XtraMessageBox.Show("Invalid Article ....for greige denim style ends must be entered!", "Error");
                //    return;
                //}
                for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                {

                    UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
                    if (dytb.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dytb.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                   

                }
                for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                {

                    UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                    if (dytb.Counts.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid Count", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    if (dytb.Ply.EditValue == null)
                    {
                        XtraMessageBox.Show("invalid Ply", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                  

                }
            }
            string Articlenumtypeid="0";
            if (this.NumberTypeRadio.EditValue.ToString() == "A")
                Articlenumtypeid = "1";
            else
                Articlenumtypeid = "0";
            string query = "insert into PP_Article (articlenumbertypeid,articleTypeID,articlenumber,articlename,ArticleShortName,FabricName,EPI,PPI,Width,InsertionType,ArticleWeave,ArticleSelvage,ExpectedCrimp,NoofEnds,WeightOz";

            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                query += ",warpyarncount_" + x.ToString() + ",warpweight_" + x.ToString() + ",warpyarnply_" + x.ToString() + ",warpyarnblend_" + x.ToString() + ",warpyarndesc_" + x.ToString() + ",warpyarncolor_" + x.ToString() + ",warpyarnends_" + x.ToString();
                
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                query += ",weftyarncount_" + x.ToString() + ",weftweight_" + x.ToString() + ",weftyarnply_" + x.ToString() + ",weftyarnblend_" + x.ToString() + ",weftyarndesc_" + x.ToString() + ",weftyarncolor_" + x.ToString() + ",weftyarnpicks_" + x.ToString();
                
             
            }
            
            query += ") values ("+Articlenumtypeid+",3,";

            query += "'" + this.Article_Number_textEdit.Text + "','" + this.Article_Details_Label.Text + "','"+this.ShortName.Text +"'";
            if (this.FabricName.EditValue != null)
                query += ",'" + this.FabricName.EditValue.ToString() + "'";
            else
                query += ",null";
            if(this.Article_EPI_textEdit.Text !="")
                query+=",'" + this.Article_EPI_textEdit.Text +"'";
            else
                query+=",null";
            if(this.Article_PPI_textEdit.Text !="")
                query+=",'" + this.Article_PPI_textEdit.Text +"'";
            else
                query+=",null";
            
            if(this.Article_Width_textEdit.Text !="")
                query+=",'" + this.Article_Width_textEdit.Text +"'";
            else
                query+=",null";

            if (this.insertiontype.EditValue !=null)
                query += ",'" + this.insertiontype.EditValue.ToString() + "'";
            else
                query += ",null";
            if (this.Article_Weave_comboBoxEdit.EditValue != null)
                query += ",'" + this.Article_Weave_comboBoxEdit.EditValue.ToString() + "'";
            else
                query += ",null";

            if (this.Article_Selvages_comboBoxEdit.EditValue != null)
                query += ",'" + this.Article_Selvages_comboBoxEdit.EditValue.ToString() + "'";
            else
                query += ",null";

            if (this.Crimp.EditValue != null)
                query += "," + this.Crimp.EditValue.ToString() + "";
            else
                query += ",0";
            if (this.NoofEnds.EditValue != null)
                query += "," + this.NoofEnds.EditValue.ToString() + "";
            else
                query += ",0";
            if (this.WeightOz.EditValue != null)
                query += "," + this.WeightOz.EditValue.ToString() + "";
            else
                query += ",0";
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
                    
                 if(dytb.Counts.EditValue!=null)
                     query += ",'" + dytb.Counts.EditValue.ToString() + "'";
                 else
                     query += ",null";

                 if (dytb.Weight.EditValue != null)
                     query += "," + dytb.Weight.EditValue.ToString() + "";
                 else
                     query += ",null";
                 if (dytb.Ply.EditValue != null)
                     query += ",'" + dytb.Ply.EditValue.ToString() + "'";
                 else
                     query += ",null";

                 if (dytb.Blends.EditValue != null)
                     query += ",'" + dytb.Blends.EditValue.ToString() + "'";
                 else
                     query += ",null";
                 if (dytb.Desc.EditValue != null)
                     query += ",'" + dytb.Desc.EditValue.ToString() + "'";
                 else
                     query += ",null";
                 if (dytb.Color.EditValue != null)
                     query += ",'" + dytb.Color.EditValue.ToString() + "'";
                 else
                     query += ",null";
                 if (dytb.PicksorEnds.Text  != "")
                     query += ",'" + dytb.PicksorEnds.Text + "'";
                 else
                     query += ",null";

                  
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                if (dytb.Counts.EditValue != null)
                    query += ",'" + dytb.Counts.EditValue.ToString() + "'";
                else
                    query += ",null";

                if (dytb.Weight.EditValue != null)
                    query += "," + dytb.Weight.EditValue.ToString() + "";
                else
                    query += ",null";
                if (dytb.Ply.EditValue != null)
                    query += ",'" + dytb.Ply.EditValue.ToString() + "'";
                else
                    query += ",null";

                if (dytb.Blends.EditValue != null)
                    query += ",'" + dytb.Blends.EditValue.ToString() + "'";
                else
                    query += ",null";
                if (dytb.Desc.EditValue != null)
                    query += ",'" + dytb.Desc.EditValue.ToString() + "'";
                else
                    query += ",null";
                if (dytb.Color.EditValue != null)
                    query += ",'" + dytb.Color.EditValue.ToString() + "'";
                else
                    query += ",null";
                if (dytb.PicksorEnds.Text != "")
                    query += ",'" + dytb.PicksorEnds.Text + "'";
                else
                    query += ",null";

            }

            query += ")";

            try
            {
                string qres = WS.svc.Execute_Query(query);
                if (qres != "**SUCCESS##")
                    XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                   
                    Clear_Article();
                    this.btn_Add.Enabled = true;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false ;
                    this.btn_Edit.Enabled = false ;
                    this.btn_Save.Enabled = false;
                    this.btn_View.Enabled = true;
                    this.uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddWarpWeftWeightParams()
        {
            double dPPI = 0;
            double dEPI = 0;
            double dWidth = 0;
            if (this.Article_PPI_textEdit.EditValue != null)
                double.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dPPI);
            if (this.Article_EPI_textEdit.EditValue != null)
                double.TryParse(this.Article_EPI_textEdit.EditValue.ToString(), out dEPI);
            if (this.Article_Width_textEdit.EditValue != null)
                double.TryParse(this.Article_Width_textEdit.EditValue.ToString(), out dWidth);
            for (int x = 0; x < scroll_Warp.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dxy = (UserControls.dxGreigeArticleParams)scroll_Warp.Controls[x];
                dxy.PPI = dPPI;
                dxy.EPI = dEPI;
                dxy.WIDTH = dWidth;
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                UserControls.dxGreigeArticleParams dxy = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                dxy.PPI = dPPI;
                dxy.EPI = dEPI;
                dxy.WIDTH = dWidth;
            }
        }
        private void Clear_Article()
        {
            this.Article_Number_textEdit.Text = "";
            this.Article_Number_textEdit.Tag = "";
            this.Article_Details_Label.Text = "";
            this.Article_Details_Label.Tag = "";
            this.Article_EPI_textEdit.Text = "";
            
            this.Article_Number_textEdit.Text = "";
            this.FabricName.EditValue = null;
            
            this.Article_PPI_textEdit.Text = "";
            this.Article_Weave_comboBoxEdit.EditValue = null;
            this.Article_Selvages_comboBoxEdit.EditValue = null;
            this.insertiontype.EditValue = null;
            this.WeightOz.EditValue = null;
            this.NoofEnds.EditValue = null;

            foreach (Control c in this.scroll_Warp.Controls)
            {
                if (this.scroll_Warp.Controls.Count > 1)
                    this.scroll_Warp.Controls.RemoveAt(this.scroll_Warp.Controls.Count - 1);
            }
            foreach (Control c in this.scroll_Weft.Controls)
            {
                if (this.scroll_Weft.Controls.Count > 1)
                    this.scroll_Weft.Controls.RemoveAt(this.scroll_Weft.Controls.Count - 1);
            }

            UserControls.dxGreigeArticleParams dxy = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[0];
           dxy.Counts.EditValue = null;
           dxy.Blends.EditValue = null;
           dxy.Color.EditValue = null;
           dxy.Desc.EditValue = null;
           dxy.PicksorEnds.EditValue = null;
           dxy.Ply.EditValue = null;
           dxy.PicksorEnds.Visible = false;
           dxy = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[0];
           dxy.Counts.EditValue = null;
           dxy.Blends.EditValue = null;
           dxy.Color.EditValue = null;
           dxy.Desc.EditValue = null;
           dxy.PicksorEnds.EditValue = null;
           dxy.Ply.EditValue = null;
           dxy.PicksorEnds.Visible = false;

        }
        private void Add_ArticleWarpParams()
        {
            UserControls.dxGreigeArticleParams warpparam = new UserControls.dxGreigeArticleParams();
            warpparam.isWarp = true;
            double dPPI = 0, dEPI = 0, dWidth = 0;
            if (this.Article_PPI_textEdit.EditValue != null)
                double.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dPPI);
            if (this.Article_EPI_textEdit.EditValue != null)
                double.TryParse(this.Article_EPI_textEdit.EditValue.ToString(), out dEPI);
            if (this.Article_Width_textEdit.EditValue != null)
                double.TryParse(this.Article_Width_textEdit.EditValue.ToString(), out dWidth);
            warpparam.PPI = dPPI;
            warpparam.EPI = dEPI;
            warpparam.WIDTH = dWidth;
            if (this.ComplexQuality.Checked == true)
            {
               
                warpparam.PicksorEnds.Visible = true;
                warpparam.PicksorEnds.Properties.NullValuePrompt = "Ends";
                warpparam.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
            }
            else
            {
               
                warpparam.PicksorEnds.Visible = false;
            }
            if (this.scroll_Warp.Controls.Count <= 0) warpparam.Top = 0;
            else
                warpparam.Top = this.scroll_Warp.Controls[this.scroll_Warp.Controls.Count - 1].Top + warpparam.Height;
            scroll_Warp.Controls.Add(warpparam);
        }
       
        private void Add_ArticleWeftParams()
        {
            UserControls.dxGreigeArticleParams weftparam = new UserControls.dxGreigeArticleParams();
            weftparam.isWarp = false;
            double dPPI = 0, dEPI = 0, dWidth = 0;
            if (this.Article_PPI_textEdit.EditValue != null)
                double.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dPPI);
            if (this.Article_EPI_textEdit.EditValue != null)
                double.TryParse(this.Article_EPI_textEdit.EditValue.ToString(), out dEPI);
            if (this.Article_Width_textEdit.EditValue != null)
                double.TryParse(this.Article_Width_textEdit.EditValue.ToString(), out dWidth);
            weftparam.PPI = dPPI;
            weftparam.EPI = dEPI;
            weftparam.WIDTH = dWidth;
            if (this.ComplexQuality.Checked == true)
            {
                weftparam.PicksorEnds.Properties.NullValuePrompt = "Picks";
                weftparam.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                weftparam.PicksorEnds.Visible = true;
            }
            else
            {
              
                weftparam.PicksorEnds.Visible = false;
            }
            if (this.scroll_Weft.Controls.Count <= 0) weftparam.Top = 0;
            else
                weftparam.Top = this.scroll_Weft.Controls[this.scroll_Weft.Controls.Count - 1].Top + weftparam.Height;
            
            scroll_Weft.Controls.Add(weftparam);
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Edit)
            {
                
                if (XtraMessageBox.Show("You are about to edit following record...\r\nArticle "
                    + this.Article_Number_textEdit.Tag.ToString() + " \r\nArticle details as "
                    + Article_Details_Label.Tag.ToString() + " ", "Confirm Service", MessageBoxButtons.YesNo) != DialogResult.Yes)
                                   return;

              
                Make_Article();
                Update_Article();  
                
            }
            else if (uiMode == UserInputMode.Add)
            {
               
                Make_Article();

                Save_Article();
                   
               
               
            }
            else if (uiMode == UserInputMode.Delete)
            {
                if (this.Article_Number_textEdit.Tag == null)
                {
                    XtraMessageBox.Show("invalid Article selected!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (XtraMessageBox.Show("Are you sure to delete record? \r\nArticle Number "
                    + this.Article_Number_textEdit.Tag.ToString()+ " \r\nArticle as "
                    + Article_Details_Label.Tag.ToString()  + "", "Confirm Service", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string retval = WS.svc.Execute_Query("delete from PP_Article where ArticleNumber='" + Article_Number_textEdit.Tag.ToString() + "'");
                    if (retval != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(retval,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                      
                    }
                    else
                    {
                        Clear_Article();
                      
                        this.btn_Add.Enabled = true;
                        this.btn_Cancel.Enabled = false;
                        this.btn_Close.Enabled = true;
                        this.btn_Del.Enabled = false ;
                        this.btn_Edit.Enabled = false ;
                        this.btn_Save.Enabled = false;
                        this.btn_View.Enabled = true;
                        this.uiMode = UserInputMode.View;
                    }
                    
                }


            }

           
           
            
           
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (Article_Number_textEdit.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }

            if (Article_Number_textEdit.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record from grid..");
                return;
            }
           
               set_ButtonStates( UserInputMode.Edit);
                
           
            
            
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (Article_Number_textEdit.Tag == null)
            {
                XtraMessageBox.Show("Select Record to edit");
                return;
            }

            if (Article_Number_textEdit.Tag.ToString() == "")
            {
                XtraMessageBox.Show("You must select record from grid..");
                return;
            }
           
        
                set_ButtonStates(UserInputMode.Delete);    
               
                
                

        
        }


        private void set_ReadOnly(bool val)
        {
            this.Article_EPI_textEdit.Properties.ReadOnly = val;
            this.insertiontype.Properties.ReadOnly = val;
            this.Article_Number_textEdit.Properties.ReadOnly = val;
           
            this.Article_PPI_textEdit.Properties.ReadOnly = val;
            this.Article_Selvages_comboBoxEdit.Properties.ReadOnly = val;
            this.Article_Weave_comboBoxEdit.Properties.ReadOnly = val;
            this.Article_Width_textEdit.Properties.ReadOnly = val;
            
           
                this.Add_Warp.Enabled = !val;
                this.Add_Weft.Enabled = !val;
                this.Less_Warp.Enabled = !val;
                this.Less_Weft.Enabled = !val;
              
              
           
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            
            set_ButtonStates(UserInputMode.View);
           
           
           
        }
       
        
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Make_ArticleGreigeDenimStyle()
        {
        }
        private void Make_Article()
        {


           
            string Articlename = "";
            string ArticleShortName = "";
          


            if (DenimArticleType.EditValue.ToString() == "F")
            {
                Make_ArticleGreigeDenimStyle();
                return;
            }
            else if (DenimArticleType.EditValue.ToString() == "C")
                return;

            if (this.Article_Weave_comboBoxEdit.EditValue != null)
                ArticleShortName += this.Article_Weave_comboBoxEdit.EditValue.ToString();

            if (this.NoofEnds.EditValue != null)
                ArticleShortName += "  " + this.NoofEnds.Text;

            if (this.scroll_Warp.Controls.Count > 1)
                ArticleShortName += "  ( ";
            else
                ArticleShortName += " ";
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                string tCount = ""; string tPly = ""; string tBlend = ""; string tDesc = ""; string tColor = "";
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];

                if (dytb.Counts.EditValue != null)
                    tCount = dytb.Counts.EditValue.ToString();
                if (dytb.Ply.EditValue != null)
                    tPly = dytb.Ply.EditValue.ToString();
                if (dytb.Blends.EditValue != null)
                    tBlend = dytb.Blends.EditValue.ToString();
                if (dytb.Desc.EditValue != null)
                    tDesc = dytb.Desc.EditValue.ToString();
                if (dytb.Color.EditValue != null)
                    tColor = dytb.Color.EditValue.ToString();
                if (this.scroll_Warp.Controls.Count <= 1)
                {
                    ArticleShortName += tCount + " / " + tPly;
                    if (tBlend != "")
                        ArticleShortName += " " + tBlend;
                    if (tDesc != "")
                        ArticleShortName += " " + tDesc;
                    if(tColor !="")
                        ArticleShortName += " " + tColor;
                }

                else
                {
                    ArticleShortName += tCount;
                    if (tBlend != "")
                        ArticleShortName += " " + tBlend;
                    if (tDesc != "")
                        ArticleShortName += " " + tDesc;
                    if (tColor != "")
                        ArticleShortName += " " + tColor;
                    if (x + 1 < this.scroll_Warp.Controls.Count)
                        ArticleShortName += " X ";

                }

               
            }
            if (this.scroll_Warp.Controls.Count > 1)
                ArticleShortName += " ) ";

            if (this.scroll_Weft.Controls.Count > 1)
                ArticleShortName += "  ( ";
            else
                ArticleShortName += " ";
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                string tCount = ""; string tPly = ""; string tBlend = ""; string tDesc = ""; string tColor = "";
                UserControls.dxGreigeArticleParams dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];

                if (dytb.Counts.EditValue != null)
                    tCount = dytb.Counts.EditValue.ToString();
                if (dytb.Ply.EditValue != null)
                    tPly = dytb.Ply.EditValue.ToString();
                if (dytb.Blends.EditValue != null)
                    tBlend = dytb.Blends.EditValue.ToString();
                if (dytb.Desc.EditValue != null)
                    tDesc = dytb.Desc.EditValue.ToString();
                if (dytb.Color.EditValue != null)
                    tColor = dytb.Color.EditValue.ToString();
                if (this.scroll_Weft.Controls.Count <= 1)
                {
                    ArticleShortName += tCount + " / " + tPly;
                    if (tBlend != "")
                        ArticleShortName += " " + tBlend;
                    if (tDesc != "")
                        ArticleShortName += " " + tDesc;
                    if (tColor != "")
                        ArticleShortName += " " + tColor;
                }
                else
                {
                    ArticleShortName += tCount;
                    if (tBlend != "")
                        ArticleShortName += " " + tBlend;
                    if (tDesc != "")
                        ArticleShortName += " " + tDesc;
                    if (tColor != "")
                        ArticleShortName += " " + tColor;
                    if (x + 1 < this.scroll_Weft.Controls.Count)
                        ArticleShortName += " X ";
                }


            }
            if (this.scroll_Weft.Controls.Count > 1)
                ArticleShortName += " ) ";




            if (this.Article_PPI_textEdit.Text != "" )
            {

                ArticleShortName += "   " + this.Article_PPI_textEdit.Text + "p";
            }
           
            if (this.FabricName.EditValue != null)
            {
               
               ArticleShortName += "  " + this.FabricName.EditValue.ToString();

            }

            Articlename = ArticleShortName;
          this.Article_Details_Label.Text = Articlename;
          this.ShortName.Text = ArticleShortName;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Data_YarnFabricParameters AddwarpyarnCount = new Data_YarnFabricParameters();
          
           ParameterReturn pr= AddwarpyarnCount.Display_Parameter(MousePosition, "Warp Yarn Count", "WarpYarnCount", "PP_warpYarnCounts");
           if (pr.Status == ParameterStatus.Error)
           {
               XtraMessageBox.Show("Error", pr.ParameterValue, MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           else
           {
              //
              //add value to combox box
           }
        }

      

      

      
        private void Article_EPI_textEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_PPI_textEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_Width_textEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_Weave_comboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_InsertionType_comboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_Selvages_comboBoxEdit_TextChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

      

        private void btn_View_Click(object sender, EventArgs e)
        {
            if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

            Program.MainWindow.ArticleGreigeView.ShowDialog();

            try
            {
                if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    Clear_Article();
                    this.Article_Number_textEdit.Tag = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.Article_Number_textEdit.Text = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.Article_Details_Label.Tag = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;

                    UserControls.dxGreigeArticleParams dytb;
                    
                    try
                    {
                        DataSet ds = WS.svc.Get_DataSet("select * from PP_Article where articlenumber='" + this.Article_Number_textEdit.Tag.ToString() + "'");
                        this.ComplexQuality.Checked = false;
                       
                        if (ds == null) return;


                        if (ds.Tables[0].Rows.Count <= 0) return;


                        this.Article_EPI_textEdit.Text = ds.Tables[0].Rows[0]["EPI"].ToString();
                        this.insertiontype.EditValue = ds.Tables[0].Rows[0]["InsertionType"].ToString();
                       
                        this.Article_PPI_textEdit.Text = ds.Tables[0].Rows[0]["PPI"].ToString();
                        this.Article_Selvages_comboBoxEdit.EditValue = ds.Tables[0].Rows[0]["ArticleSelvage"].ToString();
                        this.Article_Weave_comboBoxEdit.EditValue = ds.Tables[0].Rows[0]["ArticleWeave"].ToString();
                        this.Article_Width_textEdit.Text = ds.Tables[0].Rows[0]["Width"].ToString();
                        if (ds.Tables[0].Rows[0]["ExpectedCrimp"].ToString() != "")
                            this.Crimp.EditValue = ds.Tables[0].Rows[0]["ExpectedCrimp"].ToString();
                        else
                            this.Crimp.EditValue = null;
                        if (ds.Tables[0].Rows[0]["NoofEnds"].ToString() != "")
                            this.NoofEnds.EditValue = ds.Tables[0].Rows[0]["NoofEnds"].ToString();
                        else
                            this.NoofEnds.EditValue = null;
                        if (ds.Tables[0].Rows[0]["WeightOz"].ToString() != "")
                            this.WeightOz.EditValue = ds.Tables[0].Rows[0]["WeightOz"].ToString();
                        else
                            this.WeightOz.EditValue = null;
                        if (ds.Tables[0].Rows[0]["FabricName"].ToString() != "")
                            this.FabricName.EditValue = ds.Tables[0].Rows[0]["FabricName"].ToString();
                        else
                            this.FabricName.EditValue = null;
                       
                      
                    
                       
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                                if (x > 0) Add_ArticleWarpParams();
                                dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
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
                                if (ds.Tables[0].Rows[0]["WarpYarnColor_" + x.ToString() + ""].ToString() != "")
                                    dytb.Color.EditValue = ds.Tables[0].Rows[0]["WarpYarnColor_" + x.ToString() + ""].ToString();
                                else
                                    dytb.Color.EditValue = null;
                                if (ds.Tables[0].Rows[0]["WarpYarnEnds_" + x.ToString() + ""].ToString() != "")
                                {
                                    dytb.PicksorEnds.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_" + x.ToString() + ""].ToString();
                                    
                                    dytb.PicksorEnds.Visible = true;
                                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                                }
                                else
                                {
                                    dytb.PicksorEnds.Text = "";
                                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                                    dytb.PicksorEnds.Visible = false;
                                }
                                if (x > 0) this.ComplexQuality.Checked = true;
                            }


                          
                        }

                       
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                                if(x>0)Add_ArticleWeftParams();
                                dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
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
                                if (ds.Tables[0].Rows[0]["WeftYarnColor_" + x.ToString() + ""].ToString() != "")
                                    dytb.Color.EditValue = ds.Tables[0].Rows[0]["WeftYarnColor_" + x.ToString() + ""].ToString();
                                else
                                    dytb.Color.EditValue = null;
                                if (ds.Tables[0].Rows[0]["WeftYarnPicks_" + x.ToString() + ""].ToString() != "")
                                {
                                    dytb.PicksorEnds.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_" + x.ToString() + ""].ToString();
                                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                                    dytb.PicksorEnds.Visible = true;
                                }
                                else
                                {
                                    dytb.PicksorEnds.Text = "";
                                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                                    dytb.PicksorEnds.Visible = false;
                                }
                                if (x > 0) this.ComplexQuality.Checked = true;
                            }



                        }
                      

                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Make_Article();

                    set_ButtonStates(UserInputMode.View);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void Add_Warp_Click(object sender, EventArgs e)
        {
            Add_ArticleWarpParams();
            AddWarpWeftWeightParams();
        }

        private void Less_Warp_Click(object sender, EventArgs e)
        {
            if (this.scroll_Warp.Controls.Count > 1)
                this.scroll_Warp.Controls.RemoveAt(this.scroll_Warp.Controls.Count - 1);
            AddWarpWeftWeightParams();

        }

        private void Add_Weft_Click(object sender, EventArgs e)
        {
            Add_ArticleWeftParams();
            AddWarpWeftWeightParams();
        }

        private void Less_Weft_Click(object sender, EventArgs e)
        {
            if (this.scroll_Weft.Controls.Count > 1)
                this.scroll_Weft.Controls.RemoveAt(this.scroll_Weft.Controls.Count - 1);
            AddWarpWeftWeightParams();
        }

        private void Article_Weave_comboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_weave_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
           
            fc.ArticleWeaves(ref Article_Weave_comboBoxEdit);
        }

        private void Refresh_insertiontype_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            
            fc.ArticleInsertionTypes(ref insertiontype);
         
        }

        private void Refresh_selvege_Click(object sender, EventArgs e)
        {
            
        }

       

       

        private void insertiontype_EditValueChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

      
        private void ComplexQualityCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ComplexQuality.Checked == true)
            {
                UserControls.dxGreigeArticleParams dytb;
                for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                {
                    dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
                    dytb.PicksorEnds.Visible = true;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                {
                    dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                    dytb.PicksorEnds.Visible = true;
                   
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                }
                               Make_Article();
            }
            else
            {
                UserControls.dxGreigeArticleParams dytb;
                for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                {
                    dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
                    dytb.PicksorEnds.Visible = false;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                {
                    dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                    dytb.PicksorEnds.Visible = false;

                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                }
               
                Make_Article();
            }
        }

       

        private void ClearWeave_Click(object sender, EventArgs e)
        {
            Article_Weave_comboBoxEdit.EditValue = null;
        }

        private void ClearInsertion_Click(object sender, EventArgs e)
        {
            insertiontype.EditValue = null;
        }

        private void ClearSelvage_Click(object sender, EventArgs e)
        {
            Article_Selvages_comboBoxEdit.EditValue = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void scroll_Weft_Click(object sender, EventArgs e)
        {

        }

        private void FabricName_EditValueChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Article_Width_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            PreProcessLbs();
            Make_Article();
        }

        private void FabricName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.ArticleFabricNames(ref this.FabricName);
            }
            else if (e.KeyCode == Keys.Delete)
                this.FabricName.EditValue = null;
            else if (e.KeyCode == Keys.Down)
                if (this.btn_Save.Enabled == true) this.btn_Save.Focus();
                else
                    this.btn_View.Focus();

        }

        private void Article_Weave_comboBoxEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.ArticleWeaves(ref this.Article_Weave_comboBoxEdit);
            }
            else if (e.KeyCode == Keys.Delete)
                this.Article_Weave_comboBoxEdit.EditValue = null;
            if (e.KeyCode == Keys.Up)
                this.Article_PPI_textEdit.Focus();
            else if (e.KeyCode == Keys.Down)
                this.Article_Width_textEdit.Focus();
        }

        private void insertiontype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.ArticleInsertionTypes(ref this.insertiontype);
            }
            else if (e.KeyCode == Keys.Delete)
                this.insertiontype.EditValue = null;
            if (e.KeyCode == Keys.Up)
                this.Article_Width_textEdit.Focus();
            else if (e.KeyCode == Keys.Down)
                this.Article_Selvages_comboBoxEdit.Focus();
        }

        private void Article_Selvages_comboBoxEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillCombos fc = new FillCombos();
                fc.ArticleSelvages(ref this.Article_Selvages_comboBoxEdit);
            }
            else if (e.KeyCode == Keys.Delete)
                this.Article_Selvages_comboBoxEdit.EditValue = null;
            if (e.KeyCode == Keys.Up)
                this.insertiontype.Focus();
            else if (e.KeyCode == Keys.Down)
                this.FabricName.Focus();
            
        }

        private void Article_EPI_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            PreProcessLbs();
        }

        private void Article_EPI_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                Article_PPI_textEdit.Focus();
        }

        private void Article_PPI_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                Article_EPI_textEdit.Focus();
            else if (e.KeyCode == Keys.Down)
                Article_Weave_comboBoxEdit.Focus();
        }

        private void Article_Width_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                this.Article_Weave_comboBoxEdit.Focus();
            else if (e.KeyCode == Keys.Down)
                this.insertiontype.Focus();
        }

        private void Article_Selvages_comboBoxEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
        private void PreProcessLbs()
        {

            UserControls.dxGreigeArticleParams dytb;
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                dytb = (UserControls.dxGreigeArticleParams)this.scroll_Warp.Controls[x];
                dytb.isWarp = true;
                double dPPI = 0, dEPI = 0, dWidth = 0;
                if (this.Article_PPI_textEdit.EditValue != null)
                    double.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dPPI);
                if (this.Article_EPI_textEdit.EditValue != null)
                    double.TryParse(this.Article_EPI_textEdit.EditValue.ToString(), out dEPI);
                if (this.Article_Width_textEdit.EditValue != null)
                    double.TryParse(this.Article_Width_textEdit.EditValue.ToString(), out dWidth);
                dytb.PPI = dPPI;
                dytb.EPI = dEPI;
                dytb.WIDTH = dWidth;

                dytb.CalculateWarpWeftWeight();
               

            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                dytb = (UserControls.dxGreigeArticleParams)this.scroll_Weft.Controls[x];
                dytb.isWarp = false;
                double dPPI = 0, dEPI = 0, dWidth = 0;
                if (this.Article_PPI_textEdit.EditValue != null)
                    double.TryParse(this.Article_PPI_textEdit.EditValue.ToString(), out dPPI);
                if (this.Article_EPI_textEdit.EditValue != null)
                    double.TryParse(this.Article_EPI_textEdit.EditValue.ToString(), out dEPI);
                if (this.Article_Width_textEdit.EditValue != null)
                    double.TryParse(this.Article_Width_textEdit.EditValue.ToString(), out dWidth);
                dytb.PPI = dPPI;
                dytb.EPI = dEPI;
                dytb.WIDTH = dWidth;
                dytb.CalculateWarpWeftWeight();



            }
        }
        private void Article_EPI_textEdit_Properties_EditValueChanged(object sender, EventArgs e)
        {
            PreProcessLbs();
        }

        private void Article_PPI_textEdit_EditValueChanged(object sender, EventArgs e)
        {
            PreProcessLbs();
        }

        private void ShortName_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void ArticleData_groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoofEnds_EditValueChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void WeightOz_EditValueChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Article_Number_textEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

     
    }
}