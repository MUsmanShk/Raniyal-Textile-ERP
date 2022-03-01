using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.LDS.ReportingParameters
{
    public partial class xu_Planning_BeamContraction : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_Planning_BeamContraction()
        {
            InitializeComponent();
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Reports.Parameters.ReportsMDI mr = (Reports.Parameters.ReportsMDI)this.Parent.Parent;
            mr.Close();
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
        }

        private void ArticleNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleGreigeView.ShowDialog();
                if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.ArticleName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.ArticleName.EditValue = null;
                this.ArticleNumber.EditValue = null;
            }
        }

        private void ArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                if (Program.MainWindow.ListsLoaded == false) Program.MainWindow.LoadLists();

                Program.MainWindow.ArticleGreigeView.ShowDialog();
                if (Program.MainWindow.ArticleGreigeView.SelectedRow.Status != ParameterStatus.Cancelled)
                {

                    this.ArticleNumber.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimeryID;
                    this.ArticleName.EditValue = Program.MainWindow.ArticleGreigeView.SelectedRow.PrimaryString;

                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                this.ArticleName.EditValue = null;
                this.ArticleNumber.EditValue = null;
            }
        }

        private void SetNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                string strFilterQuery = "SELECT  SETNO,WarpingProgramNumber,Ends,SizingDate,TotalSizedBeams,SizingMachineID from SW_Sizing ";
               
                selectedrow sRow = new selectedrow();





                strFilterQuery += " ORDER BY setno ";
                Data.Data_View FrmView = new Data.Data_View();
                FrmView.Load_View(strFilterQuery, "SetNo", "WarpingProgramNumber");
                FrmView.sRow = sRow;
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.SetNumber.EditValue = sRow.PrimeryID;
                   


                }
            }
            if (e.KeyCode == Keys.Delete)
                this.SetNumber.EditValue = null;
        }

        private void ShedID_EditValueChanged(object sender, EventArgs e)
        {
            int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.ShedID.Text);
            if (shedindex != -1)
            {
                this.ShedID.Tag = this.ShedID.Text;
                this.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[shedindex].ShedName;
            }
            else
            {
                this.ShedID.Tag = null;
                this.ShedName.Text = "";
            }
        }

        private void LoomNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ShedID.Tag == null)
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
                return;
            }
            int loomid = Program.ss.Machines.ReturnArrayIndex_Loom(this.LoomNumber.Text, this.ShedID.Tag.ToString());
            if (loomid != -1)
            {
                this.LoomNumber.ForeColor = Color.Black;
                this.LoomNumber.BackColor = Color.White;
                this.LoomNumber.Tag = loomid.ToString();
            }
            else
            {
                this.LoomNumber.ForeColor = Color.White;
                this.LoomNumber.BackColor = Color.Red;
                this.LoomNumber.Tag = null;
            }
        }

        private void xu_Planning_BeamContraction_Load(object sender, EventArgs e)
        {
            this.FromDate.DateTime = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            this.ToDate.DateTime = DateTime.Now;
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.FromDate.DateTime == null || this.ToDate.DateTime==null)
            {
                XtraMessageBox.Show("invalid Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BeamContraction();
        }
        private void BeamContraction()
        {
         

            Reports.Planning_BeamContraction ABC = new Reports.Planning_BeamContraction();

            //AB.ShedIndex = ShedIndex;

            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.FromDate.Text = this.FromDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.UptoDate.Text = this.ToDate.DateTime.ToString("dd-MMM-yyyy");
            ABC.BeginInit();
            string dsstring = "select LoomID,LoomName, 0.0 as ExpectedCrimp, SetNo, BeamNumber,Ends,BeamLength, '0' as ArticleNumber, 'A' as ArticleShortName ,0.0 as ProductionMeters,0.0 as RemainingLength,0.0 as ActualCrimp from SWQ_Sizing_Details where SizingDate>='" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and SizingDate<='" +  this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and LoomID is not null ";
            if (this.LoomNumber.EditValue != null && this.LoomNumber.Tag != null)
            {
                dsstring+=" and LoomID="+this.LoomNumber.Tag.ToString()+"";
                ABC.LoomNumberFilter.Text = this.LoomNumber.EditValue.ToString();
            }

            if (this.SetNumber.EditValue != null )
            {
                dsstring += " and SetNo='" + this.SetNumber.EditValue.ToString() + "'";
                ABC.SetNumberFilter.Text = this.SetNumber.EditValue.ToString();
            }
           
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        string LoomLogTable = "LoomLog_" + ds.Tables[0].Rows[x]["LoomID"].ToString();
                        if (ds.Tables[0].Rows[x]["SetNo"].ToString() != "" && ds.Tables[0].Rows[x]["BeamNumber"].ToString() != "")
                        {
                            string lengthquery = "Select ArticleNumber,Sum(Picks) as TotalPicks from " + LoomLogTable + " where SetNo='" + ds.Tables[0].Rows[x]["SetNo"].ToString() + "' and BeamNo='" + ds.Tables[0].Rows[x]["BeamNumber"].ToString() + "' group by ArticleNumber";
                            DataSet dsl = WS.svc.Get_DataSet(lengthquery);
                            try
                            {
                            if (dsl != null)
                            {
                                if (dsl.Tables[0].Rows.Count > 0)
                                {
                                    DataRow d = ds.Tables[0].Rows[x];
                                    double TotalMetersProduced = 0; double BeamLength = 0; double RemainingLength = 0;
                                    for (int l = 0; l < dsl.Tables[0].Rows.Count; l++)
                                    {
                                        double tpicks; double tMeters = 0;
                                        double.TryParse(dsl.Tables[0].Rows[l]["TotalPicks"].ToString(), out tpicks);
                                        article nArticle = Program.ss.Machines.PresentationData.Return_Article(dsl.Tables[0].Rows[l]["ArticleNumber"].ToString());
                                        if (nArticle != null)
                                        {
                                            d["ArticleNumber"] = nArticle.ArticleNumber;
                                            d["ArticleShortName"] = nArticle.ArticleName;
                                            d["ExpectedCrimp"] = nArticle.ExpectedCrimp.ToString();
                                        }
                                        if (nArticle != null)
                                        {
                                            tMeters = tpicks * 0.0254 / nArticle.PPI;
                                        }
                                        else
                                            tMeters = tpicks * 0.0254 / 30;
                                        TotalMetersProduced += tMeters;
                                    }

                                    try
                                    {
                                        double ActualCrimp = 0;

                                        double.TryParse(d["BeamLength"].ToString(), out BeamLength);
                                        d["ProductionMeters"] = TotalMetersProduced.ToString();
                                        RemainingLength = BeamLength - TotalMetersProduced;
                                        d["RemainingLength"] = RemainingLength.ToString();
                                        ActualCrimp = RemainingLength / BeamLength * 100;
                                        d["ActualCrimp"] = ActualCrimp.ToString();
                                    }
                                    catch
                                    {
                                    }

                                }
                            }
                        }catch(Exception ex)
                        {
                            XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        }

                    }
                }
            }

            if (ds != null)
            {

                if (this.ArticleName.EditValue != null && this.ArticleNumber.EditValue != null)
                {
                    ds.Tables[0].DefaultView.RowFilter = "ArticleNumber='" + this.ArticleNumber.EditValue.ToString() + "'";
                    ABC.ArticleFilter.Text = this.ArticleName.EditValue.ToString();
                }

                               ABC.DataSource = ds.Tables[0];
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
    }
}
