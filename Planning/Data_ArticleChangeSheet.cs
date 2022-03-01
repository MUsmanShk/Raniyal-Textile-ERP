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
   
    public partial class Data_ArticleChangeSheet : DevExpress.XtraEditors.XtraForm
    {
        enum UserInputMode { View = 0, Add = 1, Edit = 2, Delete = 3 };
        UserInputMode uiMode;
        public MaxACS newACS = new MaxACS();
       
        public selectedrow SelectedRow = new selectedrow();
       
        string ArticleChangeSheetToPrint = "";
        public Data_ArticleChangeSheet()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.Clients(ref Party);
         
        }




        private void ClearACS()
        {
            this.PONUMBER.EditValue = null;
            this.ACSNumber.Text = "";
            this.ACSNumber.Tag = null;
            this.PileHeight.Text = "";
            this.ReedCount.Text = "";
            this.ReedSpace.Text = "";
            this.JDN.Text = "";
            this.LoomGrid.Rows.Clear();
        }
        private void ClearArticleRelatedParams()
        {
                    
            this.ArticleNumber.Tag = null;
          
            this.ArticleNumber.Text = "";
            this.Article_Width_textEdit.Text = "";
            this.Article_PPI_textEdit.Text = "";
            this.Article_EPI_textEdit.Text = "";
            this.ArticleName.Text = "";
            this.Blend_Pile_0.Text = "";
            this.Blend_Pile_1.Text = "";
            this.Blend_Pile_2.Text = "";
            this.Blend_Pile_3.Text = "";
            this.Blend_Pile_4.Text = "";
            this.Blend_Pile_5.Text = "";
            this.Blend_Warp_0.Text = "";
            this.Blend_Warp_1.Text = "";
            this.Blend_Warp_2.Text = "";
            this.Blend_Warp_3.Text = "";
            this.Blend_Warp_4.Text = "";
            this.Blend_Warp_5.Text = "";
            this.Blend_Weft_0.Text = "";
            this.Blend_Weft_1.Text = "";
            this.Blend_Weft_2.Text = "";
            this.Blend_Weft_3.Text = "";
            this.Blend_Weft_4.Text = "";
            this.Blend_Weft_5.Text = "";
            this.Color_Pile_0.Text = "";
            this.Color_Pile_1.Text = "";
            this.Color_Pile_2.Text = "";
            this.Color_Pile_3.Text = "";
            this.Color_Pile_4.Text = "";
            this.Color_Pile_5.Text = "";
            this.Color_Warp_0.Text = "";
            this.Color_Warp_1.Text = "";
            this.Color_Warp_2.Text = "";
            this.Color_Warp_3.Text = "";
            this.Color_Warp_4.Text = "";
            this.Color_Warp_5.Text = "";
            this.Color_Weft_0.Text = "";
            this.Color_Weft_1.Text = "";
            this.Color_Weft_2.Text = "";
            this.Color_Weft_3.Text = "";
            this.Color_Weft_4.Text = "";
            this.Color_Weft_5.Text = "";
            this.Count_Pile_0.Text = "";
            this.Count_Pile_1.Text = "";
            this.Count_Pile_2.Text = "";
            this.Count_Pile_3.Text = "";
            this.Count_Pile_4.Text = "";
            this.Count_Pile_5.Text = "";
            this.Count_Warp_0.Text = "";
            this.Count_Warp_1.Text = "";
            this.Count_Warp_2.Text = "";
            this.Count_Warp_3.Text = "";
            this.Count_Warp_4.Text = "";
            this.Count_Warp_5.Text = "";
            this.Count_Weft_0.Text = "";
            this.Count_Weft_1.Text = "";
            this.Count_Weft_2.Text = "";
            this.Count_Weft_3.Text = "";
            this.Count_Weft_4.Text = "";
            this.Count_Weft_5.Text = "";
            this.Desc_Pile_0.Text = "";
            this.Desc_Pile_1.Text = "";
            this.Desc_Pile_2.Text = "";
            this.Desc_Pile_3.Text = "";
            this.Desc_Pile_4.Text = "";
            this.Desc_Pile_5.Text = "";
            this.Desc_Warp_0.Text = "";
            this.Desc_Warp_1.Text = "";
            this.Desc_Warp_2.Text = "";
            this.Desc_Warp_3.Text = "";
            this.Desc_Warp_4.Text = "";
            this.Desc_Warp_5.Text = "";
            this.Desc_Weft_0.Text = "";
            this.Desc_Weft_1.Text = "";
            this.Desc_Weft_2.Text = "";
            this.Desc_Weft_3.Text = "";
            this.Desc_Weft_4.Text = "";
            this.Desc_Weft_5.Text = "";
            this.EndsPicks_Pile_0.Text = "";
            this.EndsPicks_Pile_1.Text = "";
            this.EndsPicks_Pile_2.Text = "";
            this.EndsPicks_Pile_3.Text = "";
            this.EndsPicks_Pile_4.Text = "";
            this.EndsPicks_Pile_5.Text = "";
            this.EndsPicks_Warp_0.Text = "";
            this.EndsPicks_Warp_1.Text = "";
            this.EndsPicks_Warp_2.Text = "";
            this.EndsPicks_Warp_3.Text = "";
            this.EndsPicks_Warp_4.Text = "";
            this.EndsPicks_Warp_5.Text = "";
            this.EndsPicks_Weft_0.Text = "";
            this.EndsPicks_Weft_1.Text = "";
            this.EndsPicks_Weft_2.Text = "";
            this.EndsPicks_Weft_3.Text = "";
            this.EndsPicks_Weft_4.Text = "";
            this.EndsPicks_Weft_5.Text = "";
            this.GSM.Text = "";
            this.InsertionType.Text = "";
            this.PileHeight.Text = "";
            this.Ply_Pile_0.Text = "";
            this.Ply_Pile_1.Text = "";
            this.Ply_Pile_2.Text = "";
            this.Ply_Pile_3.Text = "";
            this.Ply_Pile_4.Text = "";
            this.Ply_Pile_5.Text = "";
            this.Ply_Warp_0.Text = "";
            this.Ply_Warp_1.Text = "";
            this.Ply_Warp_2.Text = "";
            this.Ply_Warp_3.Text = "";
            this.Ply_Warp_4.Text = "";
            this.Ply_Warp_5.Text = "";
            this.Ply_Weft_0.Text = "";
            this.Ply_Weft_1.Text = "";
            this.Ply_Weft_2.Text = "";
            this.Ply_Weft_3.Text = "";
            this.Ply_Weft_4.Text = "";
            this.Ply_Weft_5.Text = "";
        
            this.SizeCM.Text = "";
            this.TotalPicksBody.Text = "";
            this.TotalPicksFancy.Text = "";
            this.Weave.Text = "";
         

        }
    

        private void BrowseLoomNumbers_Click(object sender, EventArgs e)
        {
            if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();
            Program.MainWindow.LoomsList.ShowDialog(this);
            if (Program.MainWindow.LoomsList.SelectedRow.Status != ParameterStatus.Cancelled)
            {

               
                LoomGrid.Rows.Add();
                LoomGrid.Rows[LoomGrid.Rows.Count - 1].Cells["LoomID"].Value = Program.MainWindow.LoomsList.SelectedRow.PrimeryID;             
                LoomGrid.Rows[LoomGrid.Rows.Count - 1].Cells["LoomName"].Value = Program.MainWindow.LoomsList.SelectedRow.PrimaryString;
                newACS.LoomIndex = Program.MainWindow.LoomsList.SelectedRow.PrimeryID.PadLeft(3, '0');
               
            }
        }
        private void Save_ArticleChangeSheet()
        {
            string[] queries = new string[0];
            int[] aLooms=new int[0];
            bool ChangeOnLoom = false;
            if(ACSNumber.Text =="")
            {
                XtraMessageBox.Show("Article Change Sheet is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (ACSNumber.Text.Length != 13)
            //{
            //    XtraMessageBox.Show("Article Change Sheet is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if(ACSDated.EditValue==null)
            {
                XtraMessageBox.Show("Date is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(ArticleNumber.Text =="")
            {
                XtraMessageBox.Show("Article Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (ArticleNumber.Text.Length !=4)
            //{
            //    XtraMessageBox.Show("Article Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (LoomGrid.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Loom Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     return;
            }

          
            DateTime dated=Convert.ToDateTime(ACSDated.EditValue);

            //execute save query (save records into database)
            Array.Resize(ref queries, 1);
           
            queries[0] = "insert into PP_ArticleChangeSheet (ACSNumber,Dated,ArticleNumber,ReedCount,PONO,PartyID,ReedSpace,JDN,PileHeight,TotalEndsPileBeam,TotalEndsGroundBeam,NumberofPanels,endsPerpieceGroundSelvage1,EndsPerPieceGroundBody,EndsPerPieceGroundSelvage2,BeamSpacePile,BeamSpaceGround,BeamSpacePileCMINCHES,BeamSpaceGroundCMINCHES,SelvageYarnSpecs,SelvageGroundYarnSpecs,SelvagePrint,Remarks) Values (";
            queries[0] += "'" + this.ACSNumber.Text + "','" + dated.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "','" + ArticleNumber.Text + "'";
            if (this.ReedCount.Text != "")
                queries[0] += ",'" + this.ReedCount.Text + "'";
            else
                queries[0] += ",null";
            if (this.PONUMBER.EditValue != null)
                queries[0] += ",'" + this.PONUMBER.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.Party.EditValue!=null)
                queries[0] += ",'" +this.Party.EditValue.ToString() + "'";
            else
                queries[0] += ",null";
            if (this.ReedSpace.Text != "")
                queries[0] += ",'" + this.ReedSpace.Text + "'";
            else
                queries[0] += ",null";
            if (this.JDN.Text != "")
                queries[0] += ",'" + this.JDN.Text + "'";
            else
                queries[0] += ",null";
            if (this.PileHeight.Text != "")
                queries[0] += ",'" + this.PileHeight.Text + "'";
            else
                queries[0] += ",null";
            //TotalEndsPileBeam,TotalEndsGroundBeam,NumberofPanels,endsPerpieceGroundSelvage1,EndsPerPieceGroundBody,EndsPerPieceGroundSelvage2,BeamSpacePile,BeamSpaceGround,BeamSpacePileCMINCHES,BeamSpaceGroundCMINCHES,Remarks
            if (this.TotalEndsPileBeam.Text != "")
                queries[0] += ",'" + this.TotalEndsPileBeam.Text + "'";
            else
                queries[0] += ",null";

            if (this.TotalEndsGroundBeam.Text != "")
                queries[0] += ",'" + this.TotalEndsGroundBeam.Text + "'";
            else
                queries[0] += ",null";
            if (this.NumberofPanels.Text != "")
                queries[0] += ",'" + this.NumberofPanels.Text + "'";
            else
                queries[0] += ",null";
            if (this.EndsPerPieceGround_Selvage1.Text != "")
                queries[0] += ",'" + this.EndsPerPieceGround_Selvage1.Text + "'";
            else
                queries[0] += ",null";
            if (this.EndsPerPieceGround_Body.Text != "")
                queries[0] += ",'" + this.EndsPerPieceGround_Body.Text + "'";
            else
                queries[0] += ",null";
            if (this.EndsPerPieceGround_Selvage2.Text != "")
                queries[0] += ",'" + this.EndsPerPieceGround_Selvage2.Text + "'";
            else
                queries[0] += ",null";
            if (this.BeamSpacePile.Text != "")
                queries[0] += ",'" + this.BeamSpacePile.Text + "'";
            else
                queries[0] += ",null";
            if (this.BeamSpaceGround.Text != "")
                queries[0] += ",'" + this.BeamSpaceGround.Text + "'";
            else
                queries[0] += ",null";
            if (this.BeamSpacePileCMINCHES.Checked==false)
                queries[0] += ",'cm'";
            else
                queries[0] += ",'inch'";
            if (this.BeamSpaceGroundCMINCHES.Checked == false)
                queries[0] += ",'cm'";
            else
                queries[0] += ",'inch'";

            if (this.SelvageSpecs.Text != "")
                queries[0] += ",'" + this.SelvageSpecs.Text + "'";
            else
                queries[0] += ",null";
            if (this.SelvageGroundSpecs.Text != "")
                queries[0] += ",'" + this.SelvageGroundSpecs.Text + "'";
            else
                queries[0] += ",null";
            if (this.SelvagePrint.Text != "")
                queries[0] += ",'" + this.SelvagePrint.Text + "'";
            else
                queries[0] += ",null";
            if (this.Remarks.Text != "")
                queries[0] += ",'" + this.Remarks.Text + "'";
            else
                queries[0] += ",null";
            queries[0] += ")";

              for (int x = 0; x < LoomGrid.Rows.Count; x++)
                {
                    Array.Resize(ref aLooms,aLooms.Length+1);
                   // Array.Resize(ref queries, queries.Length + 1);
                    aLooms[aLooms.Length-1]=Convert.ToInt16(this.LoomGrid.Rows[x].Cells[0].Value);
                    //queries[queries.Length-1]="update MT_Looms set ACSNumber='"+this.ACSNumber.Text +"',ArticleNumber='"+this.ArticleNumber.Text +"' where LoomID="+this.LoomGrid.Rows[x].Cells[0].Value+"";
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into PP_ArticleChangeSheet_Looms (ACSNumber,LoomID) values ('" + this.ACSNumber.Text + "'," + this.LoomGrid.Rows[x].Cells[0].Value + ")";
                    //ChangeOnLoom = true;
                }
            
            try
            {
                string qres=WS.svc.newArticleChangeSheet(aLooms, this.ArticleNumber.Text, this.ACSNumber.Text, queries, ChangeOnLoom);
                if (qres != "**SUCCESS##")
                    XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    //if (ChangeOnLoom == true)
                    //{
                    //    for (int x = 0; x < LoomGrid.Rows.Count; x++)
                    //    {
                    //        Program.ss.Machines.Looms[Convert.ToInt16(LoomGrid.Rows[x].Cells[0].Value)].CurrentAssignedParams.ACSNumber = this.ACSNumber.Text;
                    //        Program.ss.Machines.Looms[Convert.ToInt16(LoomGrid.Rows[x].Cells[0].Value)].CurrentAssignedParams.ArticleNumber = this.ArticleNumber.Text;
                    //    }
                    //}
                    ArticleChangeSheetToPrint = this.ACSNumber.Text;
                    ClearACS();
                    ClearArticleRelatedParams();

                    this.btn_Add.Enabled = true;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_Edit.Enabled = false;
                    this.btn_Save.Enabled = false;
                    this.btn_View.Enabled = true;
                    this.uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         

        }
        private void Update_ArticleChangeSheet()
        {
            string[] queries = new string[0];
            int[] aLooms = new int[0];
            bool ChangeOnLoom = false;
            if (ACSNumber.Text == "")
            {
                XtraMessageBox.Show("Article Change Sheet is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ACSNumber.Tag == null)
            {
                XtraMessageBox.Show("Article Change Sheet is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ACSNumber.Text.Length != 13)
            {
                XtraMessageBox.Show("Article Change Sheet is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ACSDated.EditValue == null)
            {
                XtraMessageBox.Show("Date is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ArticleNumber.Text == "")
            {
                XtraMessageBox.Show("Article Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ArticleNumber.Text.Length != 4)
            {
                XtraMessageBox.Show("Article Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (LoomGrid.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Loom Number is invalid", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            DateTime dated = Convert.ToDateTime(ACSDated.EditValue);

            //execute save query (save records into database)
            Array.Resize(ref queries, 1);

            queries[0] = "update PP_ArticleChangeSheet set ";
            queries[0] += "Dated='" + dated.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' , ArticleNumber='" + ArticleNumber.Text + "'";
            if (this.ReedCount.Text != "")
                queries[0] += ",ReedCount='" + this.ReedCount.Text + "'";
            else
                queries[0] += ",ReedCount=null";
            if (this.PONUMBER.EditValue!=null)
                queries[0] += ",PONO='" + this.PONUMBER.EditValue.ToString() + "'";
            else
                queries[0] += ",PONO=null";
            if (this.Party.EditValue != null)
                queries[0] += ",PartyID='" + this.Party.EditValue.ToString() + "'";
            else
                queries[0] += ",PartyID=null";
            if (this.ReedSpace.Text != "")
                queries[0] += ",ReedSpace='" + this.ReedSpace.Text + "'";
            else
                queries[0] += ",ReedSpace=null";
            if (this.JDN.Text != "")
                queries[0] += ",JDN='" + this.JDN.Text + "'";
            else
                queries[0] += ",JDN=null";
            if (this.PileHeight.Text != "")
                queries[0] += ",PileHeight='" + this.PileHeight.Text + "'";
            else
                queries[0] += ",PileHeight=null";
            //TotalEndsPileBeam,TotalEndsGroundBeam,NumberofPanels,endsPerpieceGroundSelvage1,EndsPerPieceGroundBody,EndsPerPieceGroundSelvage2,BeamSpacePile,BeamSpaceGround,BeamSpacePileCMINCHES,BeamSpaceGroundCMINCHES,Remarks
            if (this.TotalEndsPileBeam.Text != "")
                queries[0] += ",TotalEndsPileBeam='" + this.TotalEndsPileBeam.Text + "'";
            else
                queries[0] += ",TotalEndsPileBeam=null";

            if (this.TotalEndsGroundBeam.Text != "")
                queries[0] += ",TotalEndsGroundBeam='" + this.TotalEndsGroundBeam.Text + "'";
            else
                queries[0] += ",TotalEndsGroundBeam=null";
            if (this.NumberofPanels.Text != "")
                queries[0] += ",NumberofPanels='" + this.NumberofPanels.Text + "'";
            else
                queries[0] += ",NumberofPanels=null";
            if (this.EndsPerPieceGround_Selvage1.Text != "")
                queries[0] += ",endsPerpieceGroundSelvage1='" + this.EndsPerPieceGround_Selvage1.Text + "'";
            else
                queries[0] += ",endsPerpieceGroundSelvage1=null";
            if (this.EndsPerPieceGround_Body.Text != "")
                queries[0] += ",EndsPerPieceGroundBody='" + this.EndsPerPieceGround_Body.Text + "'";
            else
                queries[0] += ",EndsPerPieceGroundBody=null";
            if (this.EndsPerPieceGround_Selvage2.Text != "")
                queries[0] += ",EndsPerPieceGroundSelvage2='" + this.EndsPerPieceGround_Selvage2.Text + "'";
            else
                queries[0] += ",EndsPerPieceGroundSelvage2=null";
            if (this.BeamSpacePile.Text != "")
                queries[0] += ",BeamSpacePile='" + this.BeamSpacePile.Text + "'";
            else
                queries[0] += ",BeamSpacePile=null";
            if (this.BeamSpaceGround.Text != "")
                queries[0] += ",BeamSpaceGround='" + this.BeamSpaceGround.Text + "'";
            else
                queries[0] += ",BeamSpaceGround=null";
            if (this.BeamSpacePileCMINCHES.Checked == false)
                queries[0] += ",BeamSpacePileCMINCHES='cm'";
            else
                queries[0] += ",BeamSpacePileCMINCHES='inch'";
            if (this.BeamSpaceGroundCMINCHES.Checked == false)
                queries[0] += ",BeamSpaceGroundCMINCHES='cm'";
            else
                queries[0] += ",BeamSpaceGroundCMINCHES='inch'";

            if (this.SelvageSpecs.Text != "")
                queries[0] += ",SelvageYarnSpecs='" + this.SelvageSpecs.Text + "'";
            else
                queries[0] += ",SelvageYarnSpecs=null";

            if (this.SelvageGroundSpecs.Text != "")
                queries[0] += ",SelvageGroundYarnSpecs='" + this.SelvageGroundSpecs.Text + "'";
            else
                queries[0] += ",SelvageGroundYarnSpecs=null";
            if (this.SelvagePrint.Text != "")
                queries[0] += ",SelvagePrint='" + this.SelvagePrint.Text + "'";
            else
                queries[0] += ",SelvagePrint=null";
            if (this.Remarks.Text != "")
                queries[0] += ",Remarks='" + this.Remarks.Text + "'";
            else
                queries[0] += ",Remarks=null";
            queries[0] += " where ACSNumber='"+this.ACSNumber.Tag.ToString()+"'";
            if (CheckEditLooms.Checked == true)
            {
                Array.Resize(ref queries, queries.Length + 1);
                queries[queries.Length - 1] = "delete from PP_ArticleChangeSheet_Looms where ACSNumber='" + this.ACSNumber.Tag.ToString() + "'";

                for (int x = 0; x < LoomGrid.Rows.Count; x++)
                {
                    Array.Resize(ref aLooms, aLooms.Length + 1);

                    aLooms[aLooms.Length - 1] = Convert.ToInt16(this.LoomGrid.Rows[x].Cells[0].Value);
                    if (Settings.CurrentSettings.SaveArticleONACS == true)
                    {
                        Array.Resize(ref queries, queries.Length + 1);
                        queries[queries.Length - 1] = "update MT_Looms set ACSNumber='" + this.ACSNumber.Text + "',ArticleNumber='" + this.ArticleNumber.Text + "' where LoomID=" + this.LoomGrid.Rows[x].Cells[0].Value + "";
                    }
                    Array.Resize(ref queries, queries.Length + 1);
                    queries[queries.Length - 1] = "insert into PP_ArticleChangeSheet_Looms (ACSNumber,LoomID) values ('" + this.ACSNumber.Text + "'," + this.LoomGrid.Rows[x].Cells[0].Value + ")";
                    ChangeOnLoom = true;
                }
            }
            
            try
            {
                string qres = WS.svc.newArticleChangeSheet(aLooms, this.ArticleNumber.Text, this.ACSNumber.Text, queries, ChangeOnLoom);
                if (qres != "**SUCCESS##")
                    XtraMessageBox.Show(qres, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    //if (ChangeOnLoom == true)
                    //{
                    //    for (int x = 0; x < LoomGrid.Rows.Count; x++)
                    //    {
                    //        Program.ss.Machines.Looms[Convert.ToInt16(LoomGrid.Rows[x].Cells[0].Value)].CurrentAssignedParams.ACSNumber = this.ACSNumber.Text;
                    //        Program.ss.Machines.Looms[Convert.ToInt16(LoomGrid.Rows[x].Cells[0].Value)].CurrentAssignedParams.ArticleNumber = this.ArticleNumber.Text;
                    //    }
                    //}
                    ArticleChangeSheetToPrint = this.ACSNumber.Text;
                    ClearACS();
                    ClearArticleRelatedParams();

                    this.btn_Add.Enabled = true;
                    this.btn_Cancel.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_Edit.Enabled = false;
                    this.btn_Save.Enabled = false;
                    this.btn_View.Enabled = true;
                    this.uiMode = UserInputMode.View;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void set_ButtonStates(UserInputMode uim)
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
                    

                    if (this.ACSNumber.Tag != null)
                    {
                        if (this.ACSNumber.Tag.ToString() != "")
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
                   
                    break;
                case UserInputMode.Edit:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                 
                    break;
                case UserInputMode.Delete:
                    this.btn_Add.Enabled = false;
                    this.btn_Cancel.Enabled = true;
                    this.btn_Save.Enabled = true;
                    this.btn_Edit.Enabled = false;
                    this.btn_Close.Enabled = true;
                    this.btn_Del.Enabled = false;
                    this.btn_View.Enabled = false;
                  
                    break;
                default:
                    break;
            }

        }
        private void FillArticle(string ArticleNumber)
        {
            ClearArticleRelatedParams();

            


            try
            {
                DataSet ds = WS.svc.Get_DataSet("select * from PP_Article where articlenumber='" + ArticleNumber + "'");


                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;
                this.ArticleNumber.Text = ArticleNumber;
                this.ArticleNumber.Tag = ArticleNumber;
                this.ArticleName.Text = ds.Tables[0].Rows[0]["ArticleName"].ToString();
                this.Article_EPI_textEdit.Text = ds.Tables[0].Rows[0]["EPI"].ToString();
                this.InsertionType.Text = ds.Tables[0].Rows[0]["InsertionType"].ToString();

                this.Article_PPI_textEdit.Text = ds.Tables[0].Rows[0]["PPI"].ToString();
                this.Selvage.Text = ds.Tables[0].Rows[0]["ArticleSelvage"].ToString();
                this.Weave.EditValue = ds.Tables[0].Rows[0]["ArticleWeave"].ToString();
                this.Article_Width_textEdit.Text = ds.Tables[0].Rows[0]["Width"].ToString();

                if (ds.Tables[0].Rows[0]["SizeWidth"].ToString() != "")
                    SizeCM.Text = ds.Tables[0].Rows[0]["SizeWidth"].ToString();
                else
                    SizeCM.Text = "";
                if (ds.Tables[0].Rows[0]["SizeHeight"].ToString() != "")
                    SizeCM.Text += "x" +  ds.Tables[0].Rows[0]["SizeHeight"].ToString();
                else
                    SizeCM.Text = "";
                if (ds.Tables[0].Rows[0]["CMORINCHES"].ToString() != "")
                    SizeCM.Text += " " +  ds.Tables[0].Rows[0]["CMORINCHES"].ToString();
                else
                    SizeCM.Text = "";
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

                if (ds.Tables[0].Rows[0]["WeightGrams"].ToString() != "")
                    txtWeightGrams.Text = ds.Tables[0].Rows[0]["WeightGrams"].ToString();
                else
                    txtWeightGrams.Text = "";




                if (ds.Tables[0].Rows[0]["WarpYarnCount_0"].ToString() != "")
                    Count_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnCount_0"].ToString();
                else
                    Count_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnCount_1"].ToString() != "")
                    Count_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnCount_1"].ToString();
                else
                    Count_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnCount_2"].ToString() != "")
                    Count_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnCount_2"].ToString();
                else
                    Count_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnCount_3"].ToString() != "")
                    Count_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnCount_3"].ToString();
                else
                    Count_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnCount_4"].ToString() != "")
                    Count_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnCount_4"].ToString();
                else
                    Count_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnCount_5"].ToString() != "")
                    Count_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnCount_5"].ToString();
                else
                    Count_Warp_5.Text = "";


                if (ds.Tables[0].Rows[0]["WarpYarnPly_0"].ToString() != "")
                    Ply_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnPly_0"].ToString();
                else
                    Ply_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnPly_1"].ToString() != "")
                    Ply_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnPly_1"].ToString();
                else
                    Ply_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnPly_2"].ToString() != "")
                    Ply_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnPly_2"].ToString();
                else
                    Ply_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnPly_3"].ToString() != "")
                    Ply_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnPly_3"].ToString();
                else
                    Ply_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnPly_4"].ToString() != "")
                    Ply_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnPly_4"].ToString();
                else
                    Ply_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnPly_5"].ToString() != "")
                    Ply_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnPly_5"].ToString();
                else
                    Ply_Warp_5.Text = "";



                if (ds.Tables[0].Rows[0]["WarpYarnBlend_0"].ToString() != "")
                    Blend_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_0"].ToString();
                else
                    Blend_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnBlend_1"].ToString() != "")
                    Blend_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_1"].ToString();
                else
                    Blend_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnBlend_2"].ToString() != "")
                    Blend_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_2"].ToString();
                else
                    Blend_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnBlend_3"].ToString() != "")
                    Blend_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_3"].ToString();
                else
                    Blend_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnBlend_4"].ToString() != "")
                    Blend_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_4"].ToString();
                else
                    Blend_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnBlend_5"].ToString() != "")
                    Blend_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnBlend_5"].ToString();
                else
                    Blend_Warp_5.Text = "";



                if (ds.Tables[0].Rows[0]["WarpYarnDesc_0"].ToString() != "")
                    Desc_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_0"].ToString();
                else
                    Desc_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnDesc_1"].ToString() != "")
                    Desc_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_1"].ToString();
                else
                    Desc_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnDesc_2"].ToString() != "")
                    Desc_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_2"].ToString();
                else
                    Desc_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnDesc_3"].ToString() != "")
                    Desc_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_3"].ToString();
                else
                    Desc_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnDesc_4"].ToString() != "")
                    Desc_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_4"].ToString();
                else
                    Desc_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnDesc_5"].ToString() != "")
                    Desc_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnDesc_5"].ToString();
                else
                    Desc_Warp_5.Text = "";


                if (ds.Tables[0].Rows[0]["WarpYarnColor_0"].ToString() != "")
                    Color_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnColor_0"].ToString();
                else
                    Color_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnColor_1"].ToString() != "")
                    Color_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnColor_1"].ToString();
                else
                    Color_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnColor_2"].ToString() != "")
                    Color_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnColor_2"].ToString();
                else
                    Color_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnColor_3"].ToString() != "")
                    Color_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnColor_3"].ToString();
                else
                    Color_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnColor_4"].ToString() != "")
                    Color_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnColor_4"].ToString();
                else
                    Color_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnColor_5"].ToString() != "")
                    Color_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnColor_5"].ToString();
                else
                    Color_Warp_5.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnEnds_0"].ToString() != "")
                    EndsPicks_Warp_0.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_0"].ToString();
                else
                    EndsPicks_Warp_0.Text = "";

                if (ds.Tables[0].Rows[0]["WarpYarnEnds_1"].ToString() != "")
                    EndsPicks_Warp_1.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_1"].ToString();
                else
                    EndsPicks_Warp_1.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnEnds_2"].ToString() != "")
                    EndsPicks_Warp_2.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_2"].ToString();
                else
                    EndsPicks_Warp_2.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnEnds_3"].ToString() != "")
                    EndsPicks_Warp_3.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_3"].ToString();
                else
                    EndsPicks_Warp_3.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnEnds_4"].ToString() != "")
                    EndsPicks_Warp_4.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_4"].ToString();
                else
                    EndsPicks_Warp_4.Text = "";
                if (ds.Tables[0].Rows[0]["WarpYarnEnds_5"].ToString() != "")
                    EndsPicks_Warp_5.Text = ds.Tables[0].Rows[0]["WarpYarnEnds_5"].ToString();
                else
                    EndsPicks_Warp_5.Text = "";





                if (ds.Tables[0].Rows[0]["WeftYarnCount_0"].ToString() != "")
                    Count_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnCount_0"].ToString();
                else
                    Count_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnCount_1"].ToString() != "")
                    Count_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnCount_1"].ToString();
                else
                    Count_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnCount_2"].ToString() != "")
                    Count_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnCount_2"].ToString();
                else
                    Count_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnCount_3"].ToString() != "")
                    Count_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnCount_3"].ToString();
                else
                    Count_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnCount_4"].ToString() != "")
                    Count_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnCount_4"].ToString();
                else
                    Count_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnCount_5"].ToString() != "")
                    Count_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnCount_5"].ToString();
                else
                    Count_Weft_5.Text = "";


                if (ds.Tables[0].Rows[0]["WeftYarnPly_0"].ToString() != "")
                    Ply_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnPly_0"].ToString();
                else
                    Ply_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnPly_1"].ToString() != "")
                    Ply_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnPly_1"].ToString();
                else
                    Ply_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPly_2"].ToString() != "")
                    Ply_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnPly_2"].ToString();
                else
                    Ply_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPly_3"].ToString() != "")
                    Ply_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnPly_3"].ToString();
                else
                    Ply_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPly_4"].ToString() != "")
                    Ply_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnPly_4"].ToString();
                else
                    Ply_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPly_5"].ToString() != "")
                    Ply_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnPly_5"].ToString();
                else
                    Ply_Weft_5.Text = "";



                if (ds.Tables[0].Rows[0]["WeftYarnBlend_0"].ToString() != "")
                    Blend_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_0"].ToString();
                else
                    Blend_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnBlend_1"].ToString() != "")
                    Blend_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_1"].ToString();
                else
                    Blend_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnBlend_2"].ToString() != "")
                    Blend_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_2"].ToString();
                else
                    Blend_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnBlend_3"].ToString() != "")
                    Blend_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_3"].ToString();
                else
                    Blend_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnBlend_4"].ToString() != "")
                    Blend_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_4"].ToString();
                else
                    Blend_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnBlend_5"].ToString() != "")
                    Blend_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnBlend_5"].ToString();
                else
                    Blend_Weft_5.Text = "";



                if (ds.Tables[0].Rows[0]["WeftYarnDesc_0"].ToString() != "")
                    Desc_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_0"].ToString();
                else
                    Desc_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnDesc_1"].ToString() != "")
                    Desc_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_1"].ToString();
                else
                    Desc_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnDesc_2"].ToString() != "")
                    Desc_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_2"].ToString();
                else
                    Desc_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnDesc_3"].ToString() != "")
                    Desc_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_3"].ToString();
                else
                    Desc_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnDesc_4"].ToString() != "")
                    Desc_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_4"].ToString();
                else
                    Desc_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnDesc_5"].ToString() != "")
                    Desc_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnDesc_5"].ToString();
                else
                    Desc_Weft_5.Text = "";


                if (ds.Tables[0].Rows[0]["WeftYarnColor_0"].ToString() != "")
                    Color_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnColor_0"].ToString();
                else
                    Color_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnColor_1"].ToString() != "")
                    Color_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnColor_1"].ToString();
                else
                    Color_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnColor_2"].ToString() != "")
                    Color_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnColor_2"].ToString();
                else
                    Color_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnColor_3"].ToString() != "")
                    Color_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnColor_3"].ToString();
                else
                    Color_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnColor_4"].ToString() != "")
                    Color_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnColor_4"].ToString();
                else
                    Color_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnColor_5"].ToString() != "")
                    Color_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnColor_5"].ToString();
                else
                    Color_Weft_5.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnPicks_0"].ToString() != "")
                    EndsPicks_Weft_0.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_0"].ToString();
                else
                    EndsPicks_Weft_0.Text = "";

                if (ds.Tables[0].Rows[0]["WeftYarnPicks_1"].ToString() != "")
                    EndsPicks_Weft_1.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_1"].ToString();
                else
                    EndsPicks_Weft_1.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPicks_2"].ToString() != "")
                    EndsPicks_Weft_2.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_2"].ToString();
                else
                    EndsPicks_Weft_2.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPicks_3"].ToString() != "")
                    EndsPicks_Weft_3.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_3"].ToString();
                else
                    EndsPicks_Weft_3.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPicks_4"].ToString() != "")
                    EndsPicks_Weft_4.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_4"].ToString();
                else
                    EndsPicks_Weft_4.Text = "";
                if (ds.Tables[0].Rows[0]["WeftYarnPicks_5"].ToString() != "")
                    EndsPicks_Weft_5.Text = ds.Tables[0].Rows[0]["WeftYarnPicks_5"].ToString();
                else
                    EndsPicks_Weft_5.Text = "";




                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_0"].ToString() != "")
                    Count_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_0"].ToString();
                else
                    Count_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_1"].ToString() != "")
                    Count_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_1"].ToString();
                else
                    Count_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_2"].ToString() != "")
                    Count_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_2"].ToString();
                else
                    Count_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_3"].ToString() != "")
                    Count_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_3"].ToString();
                else
                    Count_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_4"].ToString() != "")
                    Count_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_4"].ToString();
                else
                    Count_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnCount_5"].ToString() != "")
                    Count_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnCount_5"].ToString();
                else
                    Count_Pile_5.Text = "";


                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_0"].ToString() != "")
                    Ply_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_0"].ToString();
                else
                    Ply_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_1"].ToString() != "")
                    Ply_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_1"].ToString();
                else
                    Ply_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_2"].ToString() != "")
                    Ply_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_2"].ToString();
                else
                    Ply_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_3"].ToString() != "")
                    Ply_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_3"].ToString();
                else
                    Ply_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_4"].ToString() != "")
                    Ply_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_4"].ToString();
                else
                    Ply_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnPly_5"].ToString() != "")
                    Ply_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnPly_5"].ToString();
                else
                    Ply_Pile_5.Text = "";



                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_0"].ToString() != "")
                    Blend_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_0"].ToString();
                else
                    Blend_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_1"].ToString() != "")
                    Blend_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_1"].ToString();
                else
                    Blend_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_2"].ToString() != "")
                    Blend_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_2"].ToString();
                else
                    Blend_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_3"].ToString() != "")
                    Blend_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_3"].ToString();
                else
                    Blend_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_4"].ToString() != "")
                    Blend_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_4"].ToString();
                else
                    Blend_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnBlend_5"].ToString() != "")
                    Blend_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnBlend_5"].ToString();
                else
                    Blend_Pile_5.Text = "";



                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_0"].ToString() != "")
                    Desc_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_0"].ToString();
                else
                    Desc_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_1"].ToString() != "")
                    Desc_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_1"].ToString();
                else
                    Desc_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_2"].ToString() != "")
                    Desc_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_2"].ToString();
                else
                    Desc_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_3"].ToString() != "")
                    Desc_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_3"].ToString();
                else
                    Desc_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_4"].ToString() != "")
                    Desc_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_4"].ToString();
                else
                    Desc_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnDesc_5"].ToString() != "")
                    Desc_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnDesc_5"].ToString();
                else
                    Desc_Pile_5.Text = "";


                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_0"].ToString() != "")
                    Color_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_0"].ToString();
                else
                    Color_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_1"].ToString() != "")
                    Color_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_1"].ToString();
                else
                    Color_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_2"].ToString() != "")
                    Color_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_2"].ToString();
                else
                    Color_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_3"].ToString() != "")
                    Color_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_3"].ToString();
                else
                    Color_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_4"].ToString() != "")
                    Color_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_4"].ToString();
                else
                    Color_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnColor_5"].ToString() != "")
                    Color_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnColor_5"].ToString();
                else
                    Color_Pile_5.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_0"].ToString() != "")
                    EndsPicks_Pile_0.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_0"].ToString();
                else
                    EndsPicks_Pile_0.Text = "";

                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_1"].ToString() != "")
                    EndsPicks_Pile_1.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_1"].ToString();
                else
                    EndsPicks_Pile_1.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_2"].ToString() != "")
                    EndsPicks_Pile_2.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_2"].ToString();
                else
                    EndsPicks_Pile_2.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_3"].ToString() != "")
                    EndsPicks_Pile_3.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_3"].ToString();
                else
                    EndsPicks_Pile_3.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_4"].ToString() != "")
                    EndsPicks_Pile_4.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_4"].ToString();
                else
                    EndsPicks_Pile_4.Text = "";
                if (ds.Tables[0].Rows[0]["PileWarpYarnEnds_5"].ToString() != "")
                    EndsPicks_Pile_5.Text = ds.Tables[0].Rows[0]["PileWarpYarnEnds_5"].ToString();
                else
                    EndsPicks_Pile_5.Text = "";

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BrowseArticleNumbers_Click(object sender, EventArgs e)
        {
            if (this.PONUMBER.EditValue != null)
            {
                XtraMessageBox.Show("Article be selected by PO...Remove PO for new Article", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

            Program.MainWindow.ArticleView.ShowDialog();
            try
            {
                if (Program.MainWindow.ArticleView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.Tag = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                    this.ArticleNumber.Text = Program.MainWindow.ArticleView.SelectedRow.PrimeryID;
                    newACS.ArticleNumber = Program.MainWindow.ArticleView.SelectedRow.PrimeryID.PadLeft(4, '0');
                    GetNextACS();
                    FillArticle(this.ArticleNumber.Text);

                }
                }catch(Exception ex)
                    {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
                }
        }
        private void MakeBarcode(string ACSNumber)
        {

            //int W = Convert.ToInt32(this.barcode.Width);
            //int H = Convert.ToInt32(this.barcode.Height);
            //b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            //BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE128;

            //try
            //{
            //    if (type != BarcodeLib.TYPE.UNSPECIFIED)
            //    {
            //        b.IncludeLabel = true;

            //        b.RotateFlipType = RotateFlipType.RotateNoneFlipNone;
            //        b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;

            //        barcode.Image = b.Encode(type, this.ACSNumber.Text, Color.Black, Color.White, W, H);
            //        //===================================






            //    }//if




            //}//try
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, "Error Barcode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}//catch
        }
        private void GetNextACS()
        {
            try
            {

                //if (this.LoomNumber.Tag != null)
                //{
                //    string ln= this.LoomNumber.Tag.ToString();
                //    newACS.LoomIndex = ln.PadLeft(3, '0');
                //}
                //else
                //    newACS.LoomIndex = "000";
                string MaxACS = WS.svc.Get_MaxACSNumber("0");
                ACSNumber.Tag = null;
                newACS.ACSNumber = MaxACS;

                this.ACSNumber.Text = "33" + newACS.ACSNumber + newACS.ArticleNumber;

                MakeBarcode(this.ACSNumber.Text);
            }
            catch 
            {
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.LoomGrid.Rows.Clear();
            GetNextACS();
            set_ButtonStates(UserInputMode.Add);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (uiMode == UserInputMode.Add)
                Save_ArticleChangeSheet();
            else if (uiMode==UserInputMode.Edit)
                Update_ArticleChangeSheet();
            if (uiMode == UserInputMode.Delete)
                Delete_ArticleChangeSheet();
        }
        private void Delete_ArticleChangeSheet()
        {
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete " + this.ACSNumber.Tag.ToString() + " ?", "Delete ACS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;

            try
            {
                string[] q= new string[0];
                Array.Resize(ref q, 1);
                q[q.Length - 1] = "update MT_Looms set ACSNumber=null where ACSNumber='" + this.ACSNumber.Tag.ToString() + "'";
                Array.Resize(ref q, q.Length + 1);
                q[q.Length - 1] = "delete from PP_ArticleChangeSheet_Looms where ACSNumber='" + this.ACSNumber.Tag.ToString() + "'";
                Array.Resize(ref   q, q.Length + 1);
                q[q.Length -1] = "Delete from PP_ArticleChangeSheet where ACSNumber='" + this.ACSNumber.Tag.ToString() + "'";
                string result = WS.svc.Execute_Transaction(q);
                if (result != "**SUCCESS##")
                    XtraMessageBox.Show(result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    ClearACS();
                    ClearArticleRelatedParams();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.ACSNumber.Tag == null)
            {
                XtraMessageBox.Show("Select Article Change Sheet to edit", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            set_ButtonStates(UserInputMode.Edit);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (this.ACSNumber.Tag == null)
            {
                XtraMessageBox.Show("Select Article Change Sheet to delete", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            set_ButtonStates(UserInputMode.Delete);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            set_ButtonStates(UserInputMode.View);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_View_Click(object sender, EventArgs e)
        {
            bool UseFilter = false;
            string query = "select * from PP_ArticleChangeSheet";
            if (FilterACSDate.Checked == true)
            {
                if (ACSDated.EditValue == null)
                {
                    XtraMessageBox.Show("invalid Date, Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }

            if (FilterArticleNumber.Checked == true)
            {
                if (ArticleNumber.Tag  == null)
                {
                    XtraMessageBox.Show("invalid ArticleNumber, Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }
            if (FilterJDN.Checked == true)
            {
                if (JDN.Text =="")
                {
                    XtraMessageBox.Show("invalid Jacquard Design, Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }
            if (FilterLoomNumber.Checked ==true)
            {
                //if ( LoomNumber.Tag == null)
                //{
                //    XtraMessageBox.Show("invalid Loom Number , Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                UseFilter = true;
            }
            if (FilterPileHeight.Checked == true)
            {
                if (PileHeight.Text =="")
                {
                    XtraMessageBox.Show("invalid Pile Height, Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }
            if (FilterReedCount.Checked == true)
            {
                if (ReedCount.Text  == "")
                {
                    XtraMessageBox.Show("invalid Reed Count, Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }
            if (FilterReedSpace.Checked == true)
            {
                if (ReedSpace.Text =="")
                {
                    XtraMessageBox.Show("invalid Reed Space , Either uncheck Filter or select valid parameter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                UseFilter = true;
            }
           
            if (UseFilter == true)
            {
                query += " where ";
                bool AppendAnd = false;
                if (FilterArticleNumber.Checked == true)
                {
                    query += "ArticleNumber='" + this.ArticleNumber.Text + "'";
                    AppendAnd = true;
                }
                if (FilterACSDate.Checked == true)
                {
                   // if (AppendAnd == true)
                   //     query += " and ";
                    
                   
                  //  AppendAnd = true;

                }
                if (FilterJDN.Checked == true)
                {
                    if (AppendAnd == true)
                        query += " and ";
                    query += " JDN='" + this.JDN.Text + "'";
                    AppendAnd = true;
                }
                //if (FilterLoomNumber.Checked == true)
                //{
                //    if (AppendAnd == true)
                //        query += " and ";
                //    query += " LoomID=" + this.LoomNumber.Tag.ToString() + "";
                //    AppendAnd = true;
                //}
                if ( FilterPileHeight.Checked == true)
                {
                    if (AppendAnd == true)
                        query += " and ";
                    query += " PileHeight='" + this.PileHeight.Text  + "'";
                    AppendAnd = true;
                }

                if ( FilterReedCount.Checked == true)
                {
                    if (AppendAnd == true)
                        query += " and ";
                    query += " ReedCount='" + this.ReedCount.Text + "'";
                    AppendAnd = true;
                }
                if ( FilterReedSpace.Checked == true)
                {
                    if (AppendAnd == true)
                        query += " and ";
                    query += " ReedSpace='" + this.ReedSpace.Text + "'";
                    AppendAnd = true;
                }
                query += " order by dated";
              
            }
            Data.Data_View View = new Data_View();
            View.sRow = SelectedRow;
            View.Load_View(query, "ACSNumber", "AcsNumber");
            View.ShowDialog(this);
            if (SelectedRow.Status != ParameterStatus.Selected)
                return;
            if (this.SelectedRow.SelectedDataRow == null)
                    return;
            this.LoomGrid.Rows.Clear();
            this.ACSNumber.Text = this.SelectedRow.PrimeryID;
            this.ACSNumber.Tag = this.SelectedRow.PrimeryID;
            ArticleChangeSheetToPrint = this.SelectedRow.PrimeryID;
            this.ACSDated.EditValue = this.SelectedRow.SelectedDataRow["Dated"].ToString();
            this.ReedCount.Text = this.SelectedRow.SelectedDataRow["ReedCount"].ToString();
            this.ReedSpace.Text = this.SelectedRow.SelectedDataRow["ReedSpace"].ToString();
           
            this.ArticleNumber.Text = this.SelectedRow.SelectedDataRow["ArticleNumber"].ToString();
            this.ArticleNumber.Tag = this.SelectedRow.SelectedDataRow["ArticleNumber"].ToString();




            if (this.SelectedRow.SelectedDataRow["PartyID"].ToString() != "")
                this.Party.EditValue = this.SelectedRow.SelectedDataRow["PartyID"].ToString();
            else
                this.Party.EditValue = null;
            this.JDN.Text = this.SelectedRow.SelectedDataRow["JDN"].ToString();
            this.PileHeight.Text = this.SelectedRow.SelectedDataRow["PileHeight"].ToString();
            if (this.SelectedRow.SelectedDataRow["PONO"].ToString() != "")
                this.PONUMBER.EditValue = this.SelectedRow.SelectedDataRow["PONO"].ToString();
            else

                this.PONUMBER.EditValue = null;
             this.TotalEndsGroundBeam.Text = this.SelectedRow.SelectedDataRow["TotalEndsGroundBeam"].ToString();
             this.TotalEndsPileBeam.Text = this.SelectedRow.SelectedDataRow["TotalEndsPileBeam"].ToString();
             this.NumberofPanels.Text = this.SelectedRow.SelectedDataRow["NumberofPanels"].ToString();
             this.EndsPerPieceGround_Selvage1.Text = this.SelectedRow.SelectedDataRow["endsPerpieceGroundSelvage1"].ToString();
             this.EndsPerPieceGround_Body.Text = this.SelectedRow.SelectedDataRow["EndsPerPieceGroundBody"].ToString();
             this.EndsPerPieceGround_Selvage2.Text = this.SelectedRow.SelectedDataRow["EndsPerPieceGroundSelvage2"].ToString();
             this.BeamSpacePile.Text = this.SelectedRow.SelectedDataRow["BeamSpacePile"].ToString();
             this.BeamSpaceGround.Text = this.SelectedRow.SelectedDataRow["BeamSpaceGround"].ToString();
             this.SelvagePrint.Text = this.SelectedRow.SelectedDataRow["SelvagePrint"].ToString();
             this.SelvageGroundSpecs.Text = this.SelectedRow.SelectedDataRow["SelvageGroundYarnSpecs"].ToString();
             this.SelvageSpecs.Text = this.SelectedRow.SelectedDataRow["SelvageYarnSpecs"].ToString();
             if(this.SelectedRow.SelectedDataRow["BeamSpacePileCMINCHES"].ToString()=="cm")
                 this.BeamSpacePileCMINCHES.Checked =false;
             else
                 this.BeamSpacePileCMINCHES.Checked=true;
             if (this.SelectedRow.SelectedDataRow["BeamSpaceGroundCMINCHES"].ToString() == "cm")
                 this.BeamSpaceGroundCMINCHES.Checked = false;
             else
                 this.BeamSpaceGroundCMINCHES.Checked = true;
             this.Remarks.Text = this.SelectedRow.SelectedDataRow["remarks"].ToString();
            
            FillArticle(this.ArticleNumber.Tag.ToString());
            FillLooms(this.SelectedRow.PrimeryID);
            MakeBarcode(this.ACSNumber.Text);
            set_ButtonStates(UserInputMode.View);
        }
        private void FillLooms(string ACSNumber)
        {
            LoomGrid.Rows.Clear();
            DataSet ds = WS.svc.Get_DataSet("Select * from  qP_ArticleChangeSheet_Looms where ACSNumber='" + ACSNumber + "'");
            if (ds == null)
                return;
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                LoomGrid.Rows.Add();
                LoomGrid.Rows[LoomGrid.Rows.Count - 1].Cells[0].Value = ds.Tables[0].Rows[x]["LoomID"].ToString();
                LoomGrid.Rows[LoomGrid.Rows.Count - 1].Cells[1].Value = ds.Tables[0].Rows[x]["LoomName"].ToString();
            }
        }
        private void Print_Click(object sender, EventArgs e)
        {
            if (this.ACSNumber.Tag == null)
            {
                XtraMessageBox.Show("Select Article Change sheet to display", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = WS.svc.Get_DataSet("Select * from QP_ArticleChangeSheet where ACSNumber='" + ArticleChangeSheetToPrint + "'");
            if (ds == null)
            {
                XtraMessageBox.Show("Record Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (ds.Tables[0].Rows.Count<=0)
            {
                XtraMessageBox.Show("Record Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if (ds.Tables[0].Rows[0]["WarpYarnCount_1"].ToString() != "" || ds.Tables[0].Rows[0]["WeftYarnCount_1"].ToString() != "" || ds.Tables[0].Rows[0]["PileWarpYarnCount_1"].ToString() != "")
            {
                Reports.ArticleChangeSheetComplex ACS = new Reports.ArticleChangeSheetComplex();
                ACS.BeginInit();
                ACS.DataSource = ds.Tables[0];
                ACS.EndInit();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet dsLooms = WS.svc.Get_DataSet("Select * from qp_articlechangesheet_looms where ACSNumber='" + ds.Tables[0].Rows[0]["ACSNumber"].ToString() + "'");
                    string LoomNumber = "";
                    for (int x = 0; x < dsLooms.Tables[0].Rows.Count; x++)
                    {
                        if (x == 0) LoomNumber = dsLooms.Tables[0].Rows[x]["ShedName"].ToString() + " Looms " + dsLooms.Tables[0].Rows[x]["LoomName"].ToString();
                        else
                            LoomNumber += " , " + dsLooms.Tables[0].Rows[x]["LoomName"].ToString();
                    }
                    ACS.xr_Looms.Text = LoomNumber;
                }
                ACS.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
                ACS.RepH_Barcode.Text = ds.Tables[0].Rows[0]["ACSNumber"].ToString();
                ACS.RepH_DocumentNumber.Text = ds.Tables[0].Rows[0]["ACSNumber"].ToString();
                ACS.ShowPreview();
            }
            else
            {
               
                Reports.ArticleChangeSheet ACS = new Reports.ArticleChangeSheet();
                ACS.BeginInit();
                ACS.DataSource = ds.Tables[0];
                ACS.EndInit();
                ACS.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
                ACS.RepH_Barcode.Text = ds.Tables[0].Rows[0]["ACSNumber"].ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet dsLooms = WS.svc.Get_DataSet("Select * from qp_articlechangesheet_looms where ACSNumber='" + ds.Tables[0].Rows[0]["ACSNumber"].ToString() + "'");
                    string LoomNumber = "";
                    for (int x = 0; x < dsLooms.Tables[0].Rows.Count; x++)
                    {
                        if (x == 0) LoomNumber = "Shed " + dsLooms.Tables[0].Rows[x]["ShedName"].ToString() + " Looms " + dsLooms.Tables[0].Rows[x]["LoomName"].ToString();
                        else
                            LoomNumber += " , " + dsLooms.Tables[0].Rows[x]["LoomName"].ToString();
                    }
                    ACS.xr_Looms.Text = LoomNumber;
                }
               
                ACS.RepH_DocumentNumber.Text = ds.Tables[0].Rows[0]["ACSNumber"].ToString();
                ACS.ShowPreview();
            }
        }

        private void BeamSpacePileCMINCHES_CheckedChanged(object sender, EventArgs e)
        {
            if (BeamSpacePileCMINCHES.Checked == false)
                BeamSpacePileCMINCHES.Text = "cm";
            else
                BeamSpacePileCMINCHES.Text = "inch";
        }

        private void BeamSpaceGroundCMINCHES_CheckedChanged(object sender, EventArgs e)
        {
            if (BeamSpaceGroundCMINCHES.Checked == false)
                BeamSpaceGroundCMINCHES.Text = "cm";
            else
                BeamSpaceGroundCMINCHES.Text = "inch";

        }

        private void LoomsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RemoveLoomNumber_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in LoomGrid.SelectedRows)
            {
                if (item != null)
                {
                    LoomGrid.Rows.Remove(item);
                }
            }
        }

        private void ClearParty_Click(object sender, EventArgs e)
        {
            this.Party.EditValue = null;
        }

        private void Reload_Party_Click(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.Clients(ref Party);
        }

        private void Data_ArticleChangeSheet_Load(object sender, EventArgs e)
        {
            this.ACSDated.DateTime = DateTime.Now;
        }

        private void InsertionType_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SelectPONUMBER_Click(object sender, EventArgs e)
        {
          //  string query = " select  PONumber,PartyID,PartyName,ArticleNumber,ArticleShortName from RFC_PO_Details where POStatus=0";
            try
            {
              
                    string strFilterQuery = "SELECT PONumber,PartyID,PartyName,ArticleNumber,ArticleShortName,POQTY as Qty  FROM RFC_PO where POStatus=0   ";

                    selectedrow sRow = new selectedrow();
                    Data.Data_View FrmView = new Data.Data_View();
                    FrmView.Load_View(strFilterQuery, "PONumber", "ArticleNumber");
                    FrmView.sRow = sRow;
                    FrmView.ShowDialog();
                    if (sRow.Status == ParameterStatus.Selected)
                    {

                        if (sRow.SelectedDataRow == null)
                            return;

                        this.PONUMBER.EditValue = sRow.PrimeryID;
                        this.ArticleNumber.EditValue = sRow.PrimaryString;
                        this.ArticleName.Text = sRow.SelectedDataRow["ArticleShortName"].ToString();
                        this.Party.EditValue = sRow.SelectedDataRow["PartyID"].ToString();
                        //this.ArticleNumber.Tag = sRow.PrimaryString;
                        //this.PONumber.Tag = sRow.PrimeryID;
                    }
                
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PONUMBER_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.PONUMBER.EditValue = null;
        }

       
      
   

       
    }
    public class MaxACS
    {
        public string ACSNumber { get; set; }
        public string ArticleNumber { get; set; }
        public string LoomIndex { get; set; }

        public MaxACS()
        {
            ACSNumber = "0000";
            ArticleNumber = "0000";
            LoomIndex = "000";
        }
    }
    
}