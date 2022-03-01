using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.View
{
    public partial class Dashboard_Colors : DevExpress.XtraEditors.XtraForm
    {
        Rectangle borderRectangle = new Rectangle(0, 0, 1, 1);
        Button selectedButton;
        public Dashboard_Colors()
        {
            InitializeComponent();
            CurrentSelection.CurrentClassicColorMode = this.radioGroup1.EditValue.ToString();
        }

       

        private void SelectionBorder(int xx, int yy, int w, int h)
        {
            ControlPaint.DrawBorder(this.CreateGraphics(), borderRectangle, Color.Black, System.Windows.Forms.ButtonBorderStyle.Solid);
            borderRectangle.X = xx; 
            borderRectangle.Y = yy; 
            borderRectangle.Width = w; 
            borderRectangle.Height = h; 
            ControlPaint.DrawBorder(this.CreateGraphics(), borderRectangle, Color.Yellow, System.Windows.Forms.ButtonBorderStyle.Solid);
        }

        private void Efficiency_Click(object sender, EventArgs e)
        {
            selectedButton = (Button)sender;
            CurrentSelection.CurrentClassicButton = selectedButton;
            SelectionBorder(selectedButton.Location.X - 1, selectedButton.Location.Y - 1, selectedButton.Width + 2, selectedButton.Height + 2);
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            DialogResult dg = XtraMessageBox.Show("Are you sure to save color,images and name settings settings?", "Save Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;
            string[] queries = new string[0];
            Array.Resize(ref queries, 18);
            ColorConverter cc = new ColorConverter();
            queries[0] = "update MT_Cause set BackColor='" +cc.ConvertToString( this.Efficiency_Unknown.BackColor) + "',ForeColor='" +cc.ConvertToString( this.Efficiency_Unknown.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Unknown.FlatAppearance.BorderColor) + "',CauseName='"+this.CauseName_Uknown.Text+"' where Cause='" + this.Efficiency_Unknown.Tag.ToString() + "'";
            queries[1] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Warp.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Warp.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Warp.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_Warp.Text + "' where Cause='" + this.Efficiency_Warp.Tag.ToString() + "'";
            queries[2] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Weft.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Weft.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Weft.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_Weft.Text + "' where Cause='" + this.Efficiency_Weft.Tag.ToString() + "'";
            queries[3] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Leno.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Leno.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Leno.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_Leno.Text + "' where Cause='" + this.Efficiency_Leno.Tag.ToString() + "'";
            queries[4] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Other.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Other.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Other.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseImage_Other.Text + "' where Cause='" + this.Efficiency_Other.Tag.ToString() + "'";
            queries[5] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Pile.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Pile.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Pile.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseImage_Pile.Text + "' where Cause='" + this.Efficiency_Pile.Tag.ToString() + "'";
            queries[6] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Mechanical.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Mechanical.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Mechanical.FlatAppearance.BorderColor) + ",CauseName='" + this.CauseImage_Mechanical.Text + "'' where Cause='" + this.Efficiency_Mechanical.Tag.ToString() + "'";
            queries[7] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Electrical.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Electrical.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Electrical.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseImage_Electrical.Text + "' where Cause='" + this.Efficiency_Electrical.Tag.ToString() + "'";
            queries[8] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Knotting.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Knotting.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Knotting.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseImage_Knotting.Text + "' where Cause='" + this.Efficiency_Knotting.Tag.ToString() + "'";
            queries[9] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Article.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Article.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Article.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_Article.Text + "' where Cause='" + this.Efficiency_Article.Tag.ToString() + "'";
            queries[10] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_OtherLong.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_OtherLong.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_OtherLong.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_OtherLong.Text + "' where Cause='" + this.Efficiency_OtherLong.Tag.ToString() + "'";
            queries[11] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_PowerOff.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_PowerOff.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_PowerOff.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_PowerOff.Text + "' where Cause='" + this.Efficiency_PowerOff.Tag.ToString() + "'";
            queries[12] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_Running.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_Running.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_Running.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_Running.Text + "' where Cause='" + this.Efficiency_Running.Tag.ToString() + "'";
            queries[13] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_LongStop_5.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_LongStop_5.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_LongStop_5.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_LongStop_5.Text + "' where Cause='" + this.Efficiency_LongStop_5.Tag.ToString() + "'";
            queries[14] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_LongStop_6.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_LongStop_6.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_LongStop_6.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_LongStop_6.Text + "' where Cause='" + this.Efficiency_LongStop_6.Tag.ToString() + "'";
            queries[15] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_LongStop_7.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_LongStop_7.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_LongStop_7.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_LongStop_7.Text + "' where Cause='" + this.Efficiency_LongStop_7.Tag.ToString() + "'";
            queries[16] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_LongStop_8.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_LongStop_8.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_LongStop_8.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_LongStop_8.Text + "' where Cause='" + this.Efficiency_LongStop_8.Tag.ToString() + "'";
            queries[17] = "update MT_Cause set BackColor='" + cc.ConvertToString(this.Efficiency_LongStop_9.BackColor) + "',ForeColor='" + cc.ConvertToString(this.Efficiency_LongStop_9.ForeColor) + "',BorderColor='" + cc.ConvertToString(this.Efficiency_LongStop_9.FlatAppearance.BorderColor) + "',CauseName='" + this.CauseName_LongStop_9.Text + "' where Cause='" + this.Efficiency_LongStop_9.Tag.ToString() + "'";

            try
            {


                //foreach (Control cControl in this.Controls)
                //{


                //    if (cControl is SimpleButton)
                //    {
                //        if (cControl.Name.Contains("CauseImage") == true)
                //        {

                //            SimpleButton b = (SimpleButton)cControl;

                //          string s=  WS.svc.Update_stopCauseImage(b.Tag.ToString(), Program.imageToByteArray(Settings.stopCauses[Settings.ReturnCauseIndex(b.Tag.ToString())].image));
                //          if (s.Contains("**SUCCESS##") == false)
                //          {
                //              XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //              return;
                //          }

                //        }
                //    }

                   
                //}

               string retres= WS.svc.Execute_Transaction(queries);
               if (retres != "**SUCCESS##")
               {
                   XtraMessageBox.Show(retres, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
               }
               else
               {
                   Settings.Load_StopCauses();
                   this.Close();
               }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {
            CurrentSelection.CurrentClassicColorMode = this.radioGroup1.EditValue.ToString();
        }
        private void RefreshCauseImagesIntoImageList()
        {

            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Unknown")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Unknown");
            //    this.CauseImages.Images.Add("Unknown", Settings.stopCauses[Settings.ReturnCauseIndex("Unknown")].image);
                
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Warp")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Warp");
            //    this.CauseImages.Images.Add("Warp", Settings.stopCauses[Settings.ReturnCauseIndex("Warp")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Weft")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Weft");
            //    this.CauseImages.Images.Add("Weft", Settings.stopCauses[Settings.ReturnCauseIndex("Weft")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Leno")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Leno");
            //    this.CauseImages.Images.Add("Leno", Settings.stopCauses[Settings.ReturnCauseIndex("Leno")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Other")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Other");
            //    this.CauseImages.Images.Add("Other", Settings.stopCauses[Settings.ReturnCauseIndex("Other")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Pile")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Pile");
            //    this.CauseImages.Images.Add("Pile", Settings.stopCauses[Settings.ReturnCauseIndex("Pile")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Mechanical")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Mechanical");
            //    this.CauseImages.Images.Add("Mechanical", Settings.stopCauses[Settings.ReturnCauseIndex("Mechanical")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Electrical")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Electrical");
            //    this.CauseImages.Images.Add("Electrical", Settings.stopCauses[Settings.ReturnCauseIndex("Electrical")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Knotting")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Knotting");
            //    this.CauseImages.Images.Add("Knotting", Settings.stopCauses[Settings.ReturnCauseIndex("Knotting")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Article")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Article");
            //    this.CauseImages.Images.Add("Article", Settings.stopCauses[Settings.ReturnCauseIndex("Article")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("OtherLong")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("OtherLong");
            //    this.CauseImages.Images.Add("OtherLong", Settings.stopCauses[Settings.ReturnCauseIndex("OtherLong")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("PowerOff")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("PowerOff");
            //    this.CauseImages.Images.Add("PowerOff", Settings.stopCauses[Settings.ReturnCauseIndex("PowerOff")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_5")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("LongStop_5");
            //    this.CauseImages.Images.Add("LongStop_5", Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_5")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_6")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("LongStop_6");
            //    this.CauseImages.Images.Add("LongStop_6", Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_6")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_7")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("LongStop_7");
            //    this.CauseImages.Images.Add("LongStop_7", Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_7")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_8")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("LongStop_8");
            //    this.CauseImages.Images.Add("LongStop_8", Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_8")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_9")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("LongStop_9");
            //    this.CauseImages.Images.Add("LongStop_9", Settings.stopCauses[Settings.ReturnCauseIndex("LongStop_9")].image);
            //}
            //if (Settings.stopCauses[Settings.ReturnCauseIndex("Running")].image != null)
            //{
            //    this.CauseImages.Images.RemoveByKey("Running");
            //    this.CauseImages.Images.Add("Running", Settings.stopCauses[Settings.ReturnCauseIndex("Running")].image);
            //}


        }
        private void Dashboard_Colors_Load(object sender, EventArgs e)
        {


            RefreshCauseImagesIntoImageList();
            foreach (Control   cc in this.Controls)
            {
                if (cc is Button)
                {
                    try
                    {
                        if (cc.Name.Contains("Efficiency") == true)
                        {
                            Button b = (Button)cc;
                            b.BackColor = Settings.Get_StopCauseColor_backColor((Cause)Convert.ToInt32(cc.Tag.ToString()));
                            b.ForeColor = Settings.Get_StopCauseColor_foreColor((Cause)Convert.ToInt32(cc.Tag.ToString()));
                            b.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor((Cause)Convert.ToInt32(cc.Tag.ToString()));
                        }
                    }
                    catch
                    {
                    }
                    
                }

                if (cc is SimpleButton)
                {
                    try
                    {
                        if (cc.Name.Contains("CauseImage") == true)
                        {

                            SimpleButton b = (SimpleButton)cc;
                            b.Image = CauseImages.Images[b.Tag.ToString()];

                        }
                    }
                    catch
                    {
                    }
                }

                if (cc is DevExpress.XtraEditors.TextEdit)
                {
                    try
                    {
                        if (cc.Name.Contains("CauseName") == true)
                        {
                            DevExpress.XtraEditors.TextEdit b = (DevExpress.XtraEditors.TextEdit)cc;
                            b.Text = Settings.stopCauses[Convert.ToInt16(cc.Tag.ToString())].CauseName;

                        }
                    }
                    catch
                    {
                    }

                }
                
            }
        }

        private void Number_Weft_Click(object sender, EventArgs e)
        {

        }

        private void CauseImage_Uknown_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|BMP Files (*.bmp)|*.bmp|GIF Files (*.gif)|*.gif|All Files (*.*)|*.*";
            DialogResult dg = openFileDialog1.ShowDialog();
            if (dg != DialogResult.OK) return;
            try
            {
                string strFn = this.openFileDialog1.FileName;
                Image thisImage = Image.FromFile(strFn);
                SimpleButton b = (SimpleButton)sender;
                if (thisImage != null)
                {
                    this.CauseImages.Images.RemoveByKey(b.Tag.ToString());
                    this.CauseImages.Images.Add(b.Tag.ToString(), thisImage);
                   // Settings.stopCauses[Settings.ReturnCauseIndex(b.Tag.ToString())].image = thisImage;
                    b.Image = this.CauseImages.Images[b.Tag.ToString()];
                }
              

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}