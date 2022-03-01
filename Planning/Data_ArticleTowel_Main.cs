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
    public partial class Data_ArticleTowel_Main : DevExpress.XtraEditors.XtraForm
    {
       
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public Data_ArticleTowel_Main()
        {
            InitializeComponent();
        }
        

       
        private void dxData_Article_Load(object sender, EventArgs e)
        {


            FillCombos fc = new FillCombos();
            Add_ArticleWarpParams();
            Add_ArticleWeftParams();
            Add_ArticlePileParams();

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

        private void btn_Add_Click(object sender, EventArgs e)
        {
           
           
            try
            {


                this.Article_Number_textEdit.Text = WS.svc.Get_MaxArticleNumber();
            }
            catch
            {
                this.Article_Number_textEdit.Text = "0001";
            }
            
            set_ButtonStates(UserInputMode.Add);
           
           
        }
        private string CheckValidation_Add()
        {
           
            Make_Article();
            if (Article_Number_textEdit.Text == "")
            {
                return "Article weave field is mendatory must enter..";
            }
              string Count = "";
            string Ply = "";
            string Blend = "";
            
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                
                dxYarnCountTwistBlend dytb =(dxYarnCountTwistBlend) this.scroll_Warp.Controls[x];
                try
                {
                    Count = (string)dytb.Counts.GetColumnValue(dytb.Counts.Properties.ValueMember).ToString();
                }catch
                {
                    return "Warp Count Not Valid";
                }
                if(Count=="")
                    return "warp Count not valid";
                try{
                    Ply =(string)dytb.Ply.GetColumnValue(dytb.Ply.Properties.ValueMember).ToString();
                }
                catch
                {
                   
                }
               
                try

                {
                    Blend =(string)dytb.Blends.GetColumnValue(dytb.Blends.Properties.ValueMember).ToString();
                }catch
                {
                   
                }
              
               

            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {

                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                try
                {
                    Count = (string)dytb.Counts.GetColumnValue(dytb.Counts.Properties.ValueMember).ToString();
                }
                catch
                {
                    return "Weft Count Not Valid";
                }
                if (Count == "")
                    return "weft Count not valid";
                try
                {
                    Ply = (string)dytb.Ply.GetColumnValue(dytb.Ply.Properties.ValueMember).ToString();
                }
                catch
                {
                   
                }
               
                try
                {
                    Blend = (string)dytb.Blends.GetColumnValue(dytb.Blends.Properties.ValueMember).ToString();
                }
                catch
                {
                    
                }
             
             

            }
          
           
           

         


            return "**SUCCESS##";
        }
        private string CheckValidation_Edit()
        {
            if (Article_Number_textEdit.Text == "")

                return "Article weave field is mendatory must enter..";

            return "**SUCCESS##";



        }
        private string CheckValidation_Delete()
        {

            return "**SUCCESS##";
        }
        private void Update_Article()
        {
            if (this.SizeWidth.EditValue == null)
            {
                XtraMessageBox.Show("invalid size width", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.SizeHeight.EditValue == null)
            {
                XtraMessageBox.Show("invalid size height", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.txtWeightGrams.EditValue == null)
            {
                XtraMessageBox.Show("invalid weight per piece in grams", "Error", MessageBoxButtons.OK);
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
            //execute save query (save records into database)
            string query = "update PP_Article set ";
            query += " ArticleNumber='" + this.Article_Number_textEdit.Text + "',ArticleName='" + this.Article_Details_Label.Text + "',ArticleShortName='"+this.ShortName.Text +"'";
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
             if (this.txtWeightGrams.Text != "")
                 query += ",WeightGrams='" + this.txtWeightGrams.Text + "'";
             else
                 query += ",WeightGrams=null";
             if (this.GSM.Text != "")
                 query += ",GSM='" + this.GSM.Text + "'";
             else
                 query += ",GSM=null";
             if (this.TotalPicksBody.Text != "")
                 query += ",TotalPicksBody='" + this.TotalPicksBody.Text + "'";
             else
                 query += ",TotalPicksBody=null";
             if (this.TotalPicksFancy.Text != "")
                 query += ",TotalPicksFancy='" + this.TotalPicksFancy.Text + "'";
             else
                 query += ",TotalPicksFancy=null";
             if (this.SizeWidth.Text != "")
                 query += ",SizeWidth='" + this.SizeWidth.Text + "'";
             else
                 query += ",SizeWidth=null";
             if (this.SizeHeight.Text != "")
                 query += ",SizeHeight='" + this.SizeHeight.Text + "'";
             else
                 query += ",SizeHeight=null";
             if (this.CMINCHES.Checked==false)
                 query += ",CMORINCHES='cm'";
             else
                 query += ",CMORINCHES='inch'";
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

            
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Warp.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",WarpYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",WarpYarnCount_" + x.ToString() + "=null";

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
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",WeftYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",WeftYarnCount_" + x.ToString() + "=null";

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
            for (int x = 0; x < this.scroll_Fancy.Controls.Count; x++)
            {
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Fancy.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",FancyYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",FancyYarnCount_" + x.ToString() + "=null";

                if (dytb.Ply.EditValue != null)
                    query += ",FancyYarnPly_" + x.ToString() + "='" + (string)dytb.Ply.EditValue + "'";
                else
                    query += ",FancyYarnPly_" + x.ToString() + "=null";

                if (dytb.Blends.EditValue != null)
                    query += ",FancyYarnBlend_" + x.ToString() + "='" + (string)dytb.Blends.EditValue + "'";
                else
                    query += ",FancyYarnBlend_" + x.ToString() + "=null";
                if (dytb.Desc.EditValue != null)
                    query += ",FancyYarnDesc_" + x.ToString() + "='" + (string)dytb.Desc.EditValue + "'";
                else
                    query += ",FancyYarnDesc_" + x.ToString() + "=null";
                if (dytb.Color.EditValue != null)
                    query += ",FancyYarnColor_" + x.ToString() + "='" + (string)dytb.Color.EditValue + "'";
                else
                    query += ",FancyYarnColor_" + x.ToString() + "=null";

                if (dytb.PicksorEnds.Text != "")
                    query += ",FancyYarnPicks_" + x.ToString() + "='" + (string)dytb.PicksorEnds.Text + "'";
                else
                    query += ",FancyYarnPicks_" + x.ToString() + "=null";
            }
            for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
            {
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];

                if (dytb.Counts.EditValue != null)
                    query += ",PileWarpYarnCount_" + x.ToString() + "='" + (string)dytb.Counts.EditValue + "'";
                else
                    query += ",PileWarpYarnCount_" + x.ToString() + "=null";

                if (dytb.Ply.EditValue != null)
                    query += ",PileWarpYarnPly_" + x.ToString() + "='" + (string)dytb.Ply.EditValue + "'";
                else
                    query += ",PileWarpYarnPly_" + x.ToString() + "=null";

                if (dytb.Blends.EditValue != null)
                    query += ",PileWarpYarnBlend_" + x.ToString() + "='" + (string)dytb.Blends.EditValue + "'";
                else
                    query += ",PileWarpYarnBlend_" + x.ToString() + "=null";
                if (dytb.Desc.EditValue != null)
                    query += ",PileWarpYarnDesc_" + x.ToString() + "='" + (string)dytb.Desc.EditValue + "'";
                else
                    query += ",PileWarpYarnDesc_" + x.ToString() + "=null";
                if (dytb.Color.EditValue != null)
                    query += ",PileWarpYarnColor_" + x.ToString() + "='" + (string)dytb.Color.EditValue + "'";
                else
                    query += ",PileWarpYarnColor_" + x.ToString() + "=null";

                if (dytb.PicksorEnds.Text != "")
                    query += ",PileWarpYarnEnds_" + x.ToString() + "='" + (string)dytb.PicksorEnds.Text + "'";
                else
                    query += ",PileWarpYarnEnds_" + x.ToString() + "=null";
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
            if (this.SizeWidth.EditValue == null)
            {
                XtraMessageBox.Show("invalid size width", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.SizeHeight.EditValue == null)
            {
                XtraMessageBox.Show("invalid size height", "Error", MessageBoxButtons.OK);
                return;
            }

            if (this.txtWeightGrams.EditValue == null)
            {
                XtraMessageBox.Show("invalid weight per piece in grams", "Error", MessageBoxButtons.OK);
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
            //execute save query (save records into database)
            string query = "insert into PP_Article (articlenumber,articleTypeID,articlename,ArticleShortName,FabricName,EPI,PPI,Width,InsertionType,ArticleWeave,ArticleSelvage,GSM,TotalPicksFancy,TotalPicksBody,SizeWidth,SizeHeight,CMORINCHES,WeightGrams";

            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                query += ",warpyarncount_" + x.ToString() + ",warpyarnply_" + x.ToString() + ",warpyarnblend_" + x.ToString() + ",warpyarndesc_" + x.ToString() + ",warpyarncolor_" + x.ToString() + ",warpyarnends_" + x.ToString();
                
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                query += ",weftyarncount_" + x.ToString() + ",weftyarnply_" + x.ToString() + ",weftyarnblend_" + x.ToString() + ",weftyarndesc_" + x.ToString() + ",weftyarncolor_" + x.ToString() + ",weftyarnpicks_" + x.ToString();
                
             
            }
           
                for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                {
                    query += ",pilewarpyarncount_" + x.ToString() + ",pilewarpyarnply_" + x.ToString() + ",pilewarpyarnblend_" + x.ToString() + ",pilewarpyarndesc_" + x.ToString() + ",pilewarpyarncolor_" + x.ToString() + ",pilewarpyarnends_" + x.ToString();
                   
                }
                for (int x = 0; x < this.scroll_Fancy.Controls.Count; x++)
                {
                    query += ",fancyyarncount_" + x.ToString() + ",fancyyarnply_" + x.ToString() + ",fancyyarnblend_" + x.ToString() + ",fancyyarndesc_" + x.ToString() + ",fancyyarncolor_" + x.ToString() + ",fancyyarnpicks_" + x.ToString();

                }
            query += ") values (";

            query += "'" + this.Article_Number_textEdit.Text + "',1,'" + this.Article_Details_Label.Text + "','"+this.ShortName.Text +"'";
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
            if (this.GSM.Text !="")
                query += ",'" + this.GSM.Text + "'";
            else
                query += ",null";
            if (this.TotalPicksFancy.Text != "")
                query += ",'" + this.TotalPicksFancy.Text + "'";
            else
                query += ",null";
            if (this.TotalPicksBody.Text != "")
                query += ",'" + this.TotalPicksBody.Text + "'";
            else
                query += ",null";
            if (this.SizeWidth.Text != "")
                query += ",'" + this.SizeWidth.Text + "'";
            else
                query += ",null";
            if (this.SizeHeight.Text != "")
                query += ",'" + this.SizeHeight.Text + "'";
            else
                query += ",null";
            if (CMINCHES.Checked==false)
                query += ",'cm'";
            else
                query += ",'inch'";
            if (this.txtWeightGrams.Text != "")
                query += ",'" + this.txtWeightGrams.Text + "'";
            else
                query += ",null";
            
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                  dxYarnCountTwistBlend dytb =(dxYarnCountTwistBlend) this.scroll_Warp.Controls[x];
                    
                 if(dytb.Counts.EditValue!=null)
                     query += ",'" + dytb.Counts.EditValue.ToString() + "'";
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
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                if (dytb.Counts.EditValue != null)
                    query += ",'" + dytb.Counts.EditValue.ToString() + "'";
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
            
                for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                {
                    dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];

                    if (dytb.Counts.EditValue != null)
                        query += ",'" + dytb.Counts.EditValue.ToString() + "'";
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
                for (int x = 0; x < this.scroll_Fancy.Controls.Count; x++)
                {
                    dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Fancy.Controls[x];
                    if (dytb.Counts.EditValue != null)
                        query += ",'" + dytb.Counts.EditValue.ToString() + "'";
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
        private void Clear_Article()
        {
            this.Article_Number_textEdit.Text = "";
            this.Article_Number_textEdit.Tag = "";
            this.Article_Details_Label.Text = "";
            this.Article_Details_Label.Tag = "";
            this.Article_EPI_textEdit.Text = "";
            
            this.Article_Number_textEdit.Text = "";
            this.FabricName.EditValue = null;
            this.SizeWidth.Text = "";
            this.SizeHeight.Text = "";
            this.Article_PPI_textEdit.Text = "";
            this.Article_Weave_comboBoxEdit.EditValue = null;
            this.Article_Selvages_comboBoxEdit.EditValue = null;
            this.insertiontype.EditValue = null;
           

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
            foreach (Control c in this.scroll_Pile.Controls)
            {
                if (this.scroll_Pile.Controls.Count > 1)
                    this.scroll_Pile.Controls.RemoveAt(this.scroll_Pile.Controls.Count - 1);
            }
            this.scroll_Fancy.Controls.Clear();
           dxYarnCountTwistBlend dxy= (dxYarnCountTwistBlend)this.scroll_Warp.Controls[0];
           dxy.Counts.EditValue = null;
           dxy.Blends.EditValue = null;
           dxy.Color.EditValue = null;
           dxy.Desc.EditValue = null;
           dxy.PicksorEnds.EditValue = null;
           dxy.Ply.EditValue = null;
           dxy.PicksorEnds.Visible = false;
           dxy = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[0];
           dxy.Counts.EditValue = null;
           dxy.Blends.EditValue = null;
           dxy.Color.EditValue = null;
           dxy.Desc.EditValue = null;
           dxy.PicksorEnds.EditValue = null;
           dxy.Ply.EditValue = null;
           dxy.PicksorEnds.Visible = false;
           if (this.scroll_Pile.Controls.Count >= 1)
           {
               dxy = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[0];
               dxy.Counts.EditValue = null;
               dxy.Blends.EditValue = null;
               dxy.Color.EditValue = null;
               dxy.Desc.EditValue = null;
               dxy.PicksorEnds.EditValue = null;
               dxy.Ply.EditValue = null;
               dxy.PicksorEnds.Visible = false;
              
           }
          
           this.ComplexQualityCheck.Checked = false;
          
        }
        private void Add_ArticleWarpParams()
        {
            dxYarnCountTwistBlend warpparam = new dxYarnCountTwistBlend();
            if (ComplexQualityCheck.Checked == true)
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
        private void Add_ArticlePileParams()
        {
            dxYarnCountTwistBlend pileparam = new dxYarnCountTwistBlend();
            if (ComplexQualityCheck.Checked == true)
            {
                pileparam.PicksorEnds.Properties.NullValuePrompt = "Ends";
                pileparam.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                pileparam.PicksorEnds.Visible = true;
            }
            else
            {
               
                pileparam.PicksorEnds.Visible = false;
            }
            if (this.scroll_Pile.Controls.Count <= 0) pileparam.Top = 0;
            else
                pileparam.Top = this.scroll_Pile.Controls[this.scroll_Pile.Controls.Count - 1].Top + pileparam.Height;
            scroll_Pile.Controls.Add(pileparam);
        }
        private void Add_ArticleFancyParams()
        {
            dxYarnCountTwistBlend fancyparam = new dxYarnCountTwistBlend();
            if (ComplexQualityCheck.Checked == true)
            {
                fancyparam.PicksorEnds.Properties.NullValuePrompt = "Picks";
                fancyparam.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                fancyparam.PicksorEnds.Visible = true;
            }
            else
            {

                fancyparam.PicksorEnds.Visible = false;
            }
            if (this.scroll_Fancy.Controls.Count <= 0) fancyparam.Top = 0;
            else
                fancyparam.Top = this.scroll_Pile.Controls[this.scroll_Fancy.Controls.Count - 1].Top + fancyparam.Height;
            scroll_Fancy.Controls.Add(fancyparam);
        }
        private void Add_ArticleWeftParams()
        {
            dxYarnCountTwistBlend weftparam = new dxYarnCountTwistBlend();
            if (ComplexQualityCheck.Checked == true)
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

                string retv = CheckValidation_Edit();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                Make_Article();
                Update_Article();  
                
            }
            else if (uiMode == UserInputMode.Add)
            {
                //check validation here
                string retv = CheckValidation_Add();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Make_Article();

                Save_Article();
                   
               
               
            }
            else if (uiMode == UserInputMode.Delete)
            {
                string retv = CheckValidation_Delete();
                if (retv != "**SUCCESS##")
                {
                    XtraMessageBox.Show(retv, "Validation Control Check", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
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
        private void Make_Article()
        {
            
            string Articlename = "";
            string ArticleShortName = "";
            string Count = "";
            string Ply = "";
            string Blend = "";
            string Desc = "";
            string Color = "";
            string Ends = "";
            string Picks = "";

            string pBlend = "";
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                string nBlend = "";
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Warp.Controls[x];
                if (dytb.Blends.EditValue != null)
                    nBlend = dytb.Blends.EditValue.ToString();
               
                if(nBlend!="")
                pBlend = nBlend;
            }
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                string nBlend = "";
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                if (dytb.Blends.EditValue != null)
                    nBlend = dytb.Blends.EditValue.ToString();
               
                if(nBlend!="")
                pBlend = nBlend;
            }
            for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
            {
                string nBlend = "";
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];
                if (dytb.Blends.EditValue != null)
                    nBlend = dytb.Blends.EditValue.ToString();
               
                if(nBlend!="")
                pBlend = nBlend;
            }
           
                if (this.SizeWidth.Text != "" && this.SizeHeight.Text != "")
                {
                    if (CMINCHES.Checked == true)
                    {
                        Articlename += "( " + this.SizeWidth.Text + " X " + this.SizeHeight.Text + " )" + "in ";
                        ArticleShortName += "( " + this.SizeWidth.Text + " X " + this.SizeHeight.Text + " )" + "in ";
                    }
                    else
                    {
                        Articlename += "( " + this.SizeWidth.Text + " X " + this.SizeHeight.Text + " )" + "cm ";
                        ArticleShortName += "( " + this.SizeWidth.Text + " X " + this.SizeHeight.Text + " )" + "cm ";
                    }
                    if (this.txtWeightGrams.EditValue != null)
                    {
                        if (this.txtWeightGrams.EditValue.ToString() != "")
                        {
                            ArticleShortName += this.txtWeightGrams.EditValue.ToString() + "g ";
                           
                        }
                    }
                    if (this.FabricName.EditValue != null)
                    {
                        ArticleShortName += " " + this.FabricName.EditValue.ToString();
                    }
                }

            
            for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
            {
                Articlename += x == 0 ? "" : " + ";
               
                dxYarnCountTwistBlend dytb =(dxYarnCountTwistBlend) this.scroll_Warp.Controls[x];
                try
                {
                    if (dytb.Counts.EditValue != null)
                        Count = (string)dytb.Counts.EditValue.ToString();
                }catch
                {
                }
                try{
                    if (dytb.Ply.EditValue != null)
                        Ply = (string)dytb.Ply.EditValue.ToString();
                }
                catch
                {
                }
                try

                {
                    if (dytb.Blends.EditValue != null)
                        Blend = (string)dytb.Blends.EditValue.ToString();
                }catch
                {
                }
                try
                {
                    if (dytb.Desc.EditValue != null)
                        Desc = (string)dytb.Desc.EditValue.ToString();
                }
                catch
                {
                    Desc = "";
                }
                try
                {
                    if (dytb.Color.EditValue != null)
                        Color = (string)dytb.Color.EditValue.ToString();
                }
                catch
                {
                    Color = "";
                }
                try
                {
                    if(dytb.PicksorEnds.EditValue!=null)
                    Ends = (string)dytb.PicksorEnds.Text;
                }
                catch
                {
                    Ends = "";
                }

                if(Ply!="")
                Articlename += Count + "/" + Ply + " " + Blend;
                else
                    Articlename += Count + " " + Blend;

               
                
                if (Desc != "")
                    Articlename += " " + Desc;

                if (Color != "")
                    Articlename += " " + Color;
                if (Ends != "")
                    Articlename += " " + Ends;
            }
           
                Articlename += " * ";

               
                for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                {
                    Articlename += x == 0 ? "" : " + ";
                   
                    dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];
                    try
                    {
                        if (dytb.Counts.EditValue != null)
                            Count = (string)dytb.Counts.EditValue.ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (dytb.Ply.EditValue != null)
                            Ply = (string)dytb.Ply.EditValue.ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (dytb.Blends.EditValue != null)
                            Blend = (string)dytb.Blends.EditValue.ToString();
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (dytb.Desc.EditValue != null)
                            Desc = (string)dytb.Desc.EditValue.ToString();
                    }
                    catch
                    {
                        Desc = "";
                    }
                    try
                    {
                        if (dytb.Color.EditValue != null)
                            Color = (string)dytb.Color.EditValue.ToString();
                    }
                    catch
                    {
                        Color = "";
                    }
                    try
                    {
                        if (dytb.PicksorEnds.EditValue != null)
                            Ends = (string)dytb.PicksorEnds.Text;
                    }
                    catch
                    {
                        Ends = "";
                    }
                    if (Ply != "")
                        Articlename += Count + "/" + Ply + " " + Blend;
                    else
                        Articlename += Count + " " + Blend;
                   
                    if (Desc != "")
                        Articlename += " " + Desc;
                    if (Color != "")
                        Articlename += " " + Color;
                    if (Picks != "")
                        Articlename += " " + Ends;
                }
            
            Articlename += " * ";
           
            for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
            {
                Articlename += x == 0 ? "" : " + ";
              
                dxYarnCountTwistBlend dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                try
                {
                    if (dytb.Counts.EditValue != null)
                        Count = (string)dytb.Counts.EditValue.ToString();
                }
                catch
                {
                }
                try
                {
                    if (dytb.Ply.EditValue != null)
                        Ply = (string)dytb.Ply.EditValue.ToString();
                }
                catch
                {
                }
                try
                {
                    if (dytb.Blends.EditValue != null)
                        Blend = (string)dytb.Blends.EditValue.ToString();
                }
                catch
                {
                }
                try
                {
                    if (dytb.Desc.EditValue != null)
                        Desc = (string)dytb.Desc.EditValue.ToString();
                }
                catch
                {
                    Desc = "";
                }
                try
                {
                    if (dytb.Color.EditValue != null)
                        Color = (string)dytb.Color.EditValue.ToString();
                }
                catch
                {
                    Color = "";
                }
                try
                {
                    if (dytb.PicksorEnds.EditValue != null)
                        Picks = (string)dytb.PicksorEnds.Text;
                }
                catch
                {
                    Picks = "";
                }
                if(Ply!="")
                Articlename += Count + "/" + Ply + " " + Blend;
                else
                    Articlename += Count +  " " + Blend;
               
                if (Desc != "")
                    Articlename += " " + Desc;
                if (Color != "")
                    Articlename += " " + Color;
                if (Picks != "")
                    Articlename += " " + Picks;
            }

            if (this.Article_PPI_textEdit.Text != "" && this.Article_EPI_textEdit.Text != "")
            {
                Articlename += " /  " + this.Article_EPI_textEdit.Text + " x " + this.Article_PPI_textEdit.Text;
                
            }
            if (this.Article_Width_textEdit.Text != "")
            {
                Articlename += " = " + this.Article_Width_textEdit.Text + "`` ";
              

            }
            if (this.FabricName.EditValue != null)
            {
                Articlename += "  " + this.FabricName.EditValue.ToString();
               

            }
           
            if(this.Article_Weave_comboBoxEdit.EditValue!=null)
                Articlename +=" " + this.Article_Weave_comboBoxEdit.EditValue.ToString();
            if(this.insertiontype.EditValue!=null)
                Articlename += " " + this.insertiontype.EditValue ;
            if (Article_Selvages_comboBoxEdit.EditValue != null)
            {
                if(Article_Selvages_comboBoxEdit.EditValue.ToString()!="")
                Articlename += " (" + this.Article_Selvages_comboBoxEdit.EditValue.ToString() + ")";
            }
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

            Program.MainWindow.ArticleTowelView.ShowDialog();

            try
            {
                if (Program.MainWindow.ArticleTowelView.SelectedRow.Status != ParameterStatus.Cancelled)
                {
                    Clear_Article();
                    this.Article_Number_textEdit.Tag = Program.MainWindow.ArticleTowelView.SelectedRow.PrimeryID;
                    this.Article_Number_textEdit.Text = Program.MainWindow.ArticleTowelView.SelectedRow.PrimeryID;
                    this.Article_Details_Label.Tag = Program.MainWindow.ArticleTowelView.SelectedRow.PrimaryString;
                    this.scroll_Fancy.Controls.Clear();
                    dxYarnCountTwistBlend dytb;
                    
                    try
                    {
                        DataSet ds = WS.svc.Get_DataSet("select * from PP_Article where articlenumber='" + this.Article_Number_textEdit.Tag.ToString() + "'");
                        ComplexQualityCheck.Checked = false;
                       
                        if (ds == null) return;


                        if (ds.Tables[0].Rows.Count <= 0) return;


                        this.Article_EPI_textEdit.Text = ds.Tables[0].Rows[0]["EPI"].ToString();
                        this.insertiontype.EditValue = ds.Tables[0].Rows[0]["InsertionType"].ToString();
                      
                        this.Article_PPI_textEdit.Text = ds.Tables[0].Rows[0]["PPI"].ToString();
                        this.Article_Selvages_comboBoxEdit.EditValue = ds.Tables[0].Rows[0]["ArticleSelvage"].ToString();
                        this.Article_Weave_comboBoxEdit.EditValue = ds.Tables[0].Rows[0]["ArticleWeave"].ToString();
                        this.Article_Width_textEdit.Text = ds.Tables[0].Rows[0]["Width"].ToString();
                        if (ds.Tables[0].Rows[0]["WeightGrams"].ToString() != null)
                            this.txtWeightGrams.EditValue = ds.Tables[0].Rows[0]["WeightGrams"].ToString();
                        else
                            this.txtWeightGrams.EditValue = null;
                        if (ds.Tables[0].Rows[0]["SizeWidth"].ToString() != "")
                            SizeWidth.Text = ds.Tables[0].Rows[0]["SizeWidth"].ToString();
                        else
                            SizeWidth.Text = "";

                        if (ds.Tables[0].Rows[0]["SizeHeight"].ToString() != "")
                            SizeHeight.Text = ds.Tables[0].Rows[0]["SizeHeight"].ToString();
                        else
                            SizeHeight.Text = "";
                        if (ds.Tables[0].Rows[0]["FabricName"].ToString() != "")
                            this.FabricName.EditValue = ds.Tables[0].Rows[0]["FabricName"].ToString();
                        else
                            this.FabricName.EditValue = null;
                        if (ds.Tables[0].Rows[0]["CMORINCHES"].ToString() != "")
                        {
                            if (ds.Tables[0].Rows[0]["CMORINCHES"].ToString() == "cm")
                                this.CMINCHES.Checked = false;
                            else
                                this.CMINCHES.Checked = true;
                        }
                        if (ds.Tables[0].Rows[0]["GSM"].ToString() != "")
                            GSM.Text = ds.Tables[0].Rows[0]["GSM"].ToString();
                        else
                            GSM.Text = "";
                        if (ds.Tables[0].Rows[0]["TotalPicksBody"].ToString() != "")
                            TotalPicksBody.Text = ds.Tables[0].Rows[0]["TotalPicksBody"].ToString();
                        else
                            TotalPicksBody.Text = "";
                        if (ds.Tables[0].Rows[0]["TotalPicksFancy"].ToString() != "")
                            TotalPicksFancy.Text = ds.Tables[0].Rows[0]["TotalPicksFancy"].ToString();
                        else
                            TotalPicksFancy.Text = "";

                       
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["WarpYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                                if (x > 0) Add_ArticleWarpParams();
                                dytb = (dxYarnCountTwistBlend)this.scroll_Warp.Controls[x];
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
                                if (x > 0) this.ComplexQualityCheck.Checked = true;
                            }


                          
                        }

                       
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["WeftYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                                if(x>0)Add_ArticleWeftParams();
                                dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
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
                                if (x > 0) this.ComplexQualityCheck.Checked = true;
                            }



                        }
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["FancyYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                                Add_ArticleFancyParams();
                                dytb = (dxYarnCountTwistBlend)this.scroll_Fancy.Controls[x];
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
                                if (ds.Tables[0].Rows[0]["FancyYarnColor_" + x.ToString() + ""].ToString() != "")
                                    dytb.Color.EditValue = ds.Tables[0].Rows[0]["FancyYarnColor_" + x.ToString() + ""].ToString();
                                else
                                    dytb.Color.EditValue = null;
                                if (ds.Tables[0].Rows[0]["FancyYarnPicks_" + x.ToString() + ""].ToString() != "")
                                {
                                    dytb.PicksorEnds.Text = ds.Tables[0].Rows[0]["FancyYarnPicks_" + x.ToString() + ""].ToString();
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
                                if (x > 0) this.ComplexQualityCheck.Checked = true;
                            }



                        }
                        for (int x = 0; x <= 5; x++)
                        {
                            if (ds.Tables[0].Rows[0]["PileWarpYarnCount_" + x.ToString() + ""].ToString() != "")
                            {
                               
                                if(x>0) Add_ArticlePileParams();
                                if (this.scroll_Pile.Controls.Count > 0)
                                {
                                    dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];
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
                                    if (ds.Tables[0].Rows[0]["PileWarpYarnColor_" + x.ToString() + ""].ToString() != "")
                                        dytb.Color.EditValue = ds.Tables[0].Rows[0]["PileWarpYarnColor_" + x.ToString() + ""].ToString();
                                    else
                                        dytb.Color.EditValue = null;
                                    if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_" + x.ToString() + ""].ToString() != "")
                                    {
                                        dytb.PicksorEnds.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_" + x.ToString() + ""].ToString();
                                        dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                                        dytb.PicksorEnds.Visible = true;
                                    }
                                    else
                                    {
                                        dytb.PicksorEnds.Text = "";
                                        dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                                        dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                                        dytb.PicksorEnds.Visible = false;
                                    }
                                }
                                if (x > 0) this.ComplexQualityCheck.Checked = true;
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
        }

        private void Less_Warp_Click(object sender, EventArgs e)
        {
            if (this.scroll_Warp.Controls.Count > 1)
                this.scroll_Warp.Controls.RemoveAt(this.scroll_Warp.Controls.Count - 1);

        }

        private void Add_Weft_Click(object sender, EventArgs e)
        {
            Add_ArticleWeftParams();
        }

        private void Less_Weft_Click(object sender, EventArgs e)
        {
            if (this.scroll_Weft.Controls.Count > 1)
                this.scroll_Weft.Controls.RemoveAt(this.scroll_Weft.Controls.Count - 1);
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

        private void Less_Pile_Click(object sender, EventArgs e)
        {
                if (this.scroll_Pile.Controls.Count > 1)
                this.scroll_Pile.Controls.RemoveAt(this.scroll_Pile.Controls.Count - 1);
        }

       

        private void insertiontype_EditValueChanged(object sender, EventArgs e)
        {
            Make_Article();
        }

        private void Add_Pile_Click(object sender, EventArgs e)
        {
            Add_ArticlePileParams();
        }

        private void ComplexQualityCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ComplexQualityCheck.Checked == true)
            {
                dxYarnCountTwistBlend dytb;
                for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Warp.Controls[x];
                    dytb.PicksorEnds.Visible = true;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                    dytb.PicksorEnds.Visible = true;
                   
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                }
                for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];
                    dytb.PicksorEnds.Visible = true;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                Make_Article();
            }
            else
            {
                dxYarnCountTwistBlend dytb;
                for (int x = 0; x < this.scroll_Warp.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Warp.Controls[x];
                    dytb.PicksorEnds.Visible = false;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                for (int x = 0; x < this.scroll_Weft.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Weft.Controls[x];
                    dytb.PicksorEnds.Visible = false;

                    dytb.PicksorEnds.Properties.NullValuePrompt = "Picks";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;
                }
                for (int x = 0; x < this.scroll_Pile.Controls.Count; x++)
                {
                    dytb = (dxYarnCountTwistBlend)this.scroll_Pile.Controls[x];
                    dytb.PicksorEnds.Visible = false;
                    dytb.PicksorEnds.Properties.NullValuePrompt = "Ends";
                    dytb.PicksorEnds.Properties.NullValuePromptShowForEmptyValue = true;

                }
                Make_Article();
            }
        }

        private void CMINCHES_CheckedChanged(object sender, EventArgs e)
        {
            if (CMINCHES.Checked == false)
                CMINCHES.Text = "cm";
            else
                CMINCHES.Text = "inch";
            Make_Article();
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
            if (e.KeyCode == Keys.Down)
                this.SizeWidth.Focus();
            else if (e.KeyCode == Keys.Up)
                this.Article_Selvages_comboBoxEdit.Focus();
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
            if (e.KeyCode == Keys.Down)
                this.insertiontype.Focus();
            else if (e.KeyCode == Keys.Up)
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
            if (e.KeyCode == Keys.Down)
                this.Article_Selvages_comboBoxEdit.Focus();
            else if (e.KeyCode == Keys.Up)
                this.Article_Weave_comboBoxEdit.Focus();
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
            if (e.KeyCode == Keys.Down)
                this.FabricName.Focus();
            else if (e.KeyCode == Keys.Up)
                this.insertiontype.Focus();
        }

        private void labelControl17_Click(object sender, EventArgs e)
        {

        }

        private void ArticleData_groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Add_fancy_Click(object sender, EventArgs e)
        {

            Add_ArticleFancyParams();
        }

        private void Less_Fancy_Click(object sender, EventArgs e)
        {
            if (this.scroll_Fancy.Controls.Count > 0)
                this.scroll_Fancy.Controls.RemoveAt(this.scroll_Fancy.Controls.Count - 1);
        }

        private void Article_EPI_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.Article_PPI_textEdit.Focus();
            else if (e.KeyCode == Keys.Up)
                this.scroll_Fancy.Focus();
        }

        private void Article_PPI_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.Article_Width_textEdit.Focus();
            else if (e.KeyCode == Keys.Up)
                this.Article_EPI_textEdit.Focus();
        }

        private void Article_Width_textEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.Article_Weave_comboBoxEdit.Focus();
            else if (e.KeyCode == Keys.Up)
                this.Article_PPI_textEdit.Focus();
        }

        private void SizeWidth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.TotalPicksBody.Focus();
            else if (e.KeyCode == Keys.Up)
                this.FabricName.Focus();
            else if (e.KeyCode == Keys.Right)
                this.SizeHeight.Focus();
        }

        private void SizeHeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.TotalPicksBody.Focus();
            else if (e.KeyCode == Keys.Up)
                this.FabricName.Focus();
            else if (e.KeyCode == Keys.Left)
                this.SizeWidth.Focus();
            else if (e.KeyCode == Keys.Right)
                this.CMINCHES.Focus();
        }

        private void TotalPicksBody_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.TotalPicksFancy.Focus();
            else if (e.KeyCode == Keys.Up)
                this.SizeHeight.Focus();
            else if (e.KeyCode == Keys.Left)
                this.SizeHeight.Focus();
        }

        private void TotalPicksFancy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.GSM.Focus();
            else if (e.KeyCode == Keys.Up)
                this.TotalPicksBody.Focus();
            
        }

        private void GSM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.txtWeightGrams.Focus();
            else if (e.KeyCode == Keys.Up)
                this.TotalPicksFancy.Focus();
          
        }

        private void txtWeightGrams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.btn_Save.Focus();
            else if (e.KeyCode == Keys.Up)
                this.GSM.Focus();
         
        }

        private void CMINCHES_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                this.TotalPicksBody.Focus();
            
            else if (e.KeyCode == Keys.Left)
                this.SizeHeight.Focus();
        }

     
    }
}