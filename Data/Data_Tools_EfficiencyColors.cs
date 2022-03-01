using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class Data_Tools_EfficiencyColors : DevExpress.XtraEditors.XtraForm
    {
        public int  ShedIndex;
        public Data_Tools_EfficiencyColors()
        {
            InitializeComponent();
            Get_ShedData();
        }
        public void Get_ShedData()
        {
            DataSet ds_ShedData = WS.svc.Get_DataSet("select ShedID,ShedName from MT_Sheds order by shedid");
            DataTable dt = ds_ShedData.Tables[0];
            this.lookUpEdit_Shed.Properties.DataSource = dt;
            this.lookUpEdit_Shed.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ShedName"));
            this.lookUpEdit_Shed.Properties.DisplayMember = "ShedName";
            this.lookUpEdit_Shed.Properties.ValueMember = "ShedID";
        }

        private void Data_Tools_EfficiencyColors_Load(object sender, EventArgs e)
        {
            
        }

        private void Load_Colors(TableLayoutPanel argtablelayoutpanel,ColorCauses argcolorCause)
        {
            ColorConverter cr = new ColorConverter();
           argtablelayoutpanel.Controls.Clear();
           
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length; x++)
            {
                if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].CC == (int)argcolorCause)
                {
                    dxRange Range = new dxRange();

                    Range.RangeFrom.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].Minimum.ToString();
                    Range.RangeTo.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].Maximum.ToString();
                    Range.RangeColor.ForeColor = (Color)cr.ConvertFromString(Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].FontColor);
                    Range.RangeColor.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].index.ToString();
                    Range.IndexNumber.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[x].index.ToString();
                    argtablelayoutpanel.Controls.Add(Range);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (lookUpEdit_Shed.EditValue == null) return;
            SimpleButton sb = (SimpleButton)sender;
            ColorCauses cCause = ColorCauses.WeaversEfficiency;
            TableLayoutPanel tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
            switch (sb.Name)
            {
                case "btn_Add_EffColor":
                    cCause = ColorCauses.EfficiencyColors;
                    tableLayPanel = this.tableLayoutPanel_EffColor;
                    break;
                case "btn_Add_RPMColor":
                    cCause = ColorCauses.RPMColors;
                    tableLayPanel = this.tableLayoutPanel_RPMColor;
                    break;
                case "btn_Add_WeaverEffColor":
                    cCause = ColorCauses.WeaversEfficiency;
                    tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
                    break;
                case "btn_Add_AvgWarpTimeColor":
                    cCause = ColorCauses.AvgWarpKnotTime;
                    tableLayPanel = this.tableLayoutPanel_AvgWarpTimeColor;
                    break;
                case "btn_Add_AvgWeftTimeColor":
                    tableLayPanel = this.tableLayoutPanel_AvgWeftTimeColor;
                    cCause = ColorCauses.AvgWeftKnotTime;
                    break;

            }
            try
            {

                string qres = WS.svc.Execute_Query("insert into MT_ColorSettings (ShedID,ColorCauseID,Colorindex,Minimum,Maximum,FontColor) values(" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "," + Convert.ToString((int)cCause) + ", " + Convert.ToString((Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnMax_EffIndex() + 1)) + ",0,0,'Black')");
                if (qres == "**SUCCESS##")
                {

                    Array.Resize(ref Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color, Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length + 1);
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1] = new range();
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].index = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnMax_EffIndex() + 1);
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].CC = (int)cCause;
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].Maximum = 0.0;
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].Minimum = 0.0;
                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].FontColor = "Black";
                    dxRange nRange = new dxRange();
                    nRange.RangeFrom.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].Minimum.ToString();
                    nRange.RangeTo.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].Maximum.ToString();
                    nRange.RangeColor.ForeColor = Color.Black;
                    nRange.RangeColor.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].index.ToString();
                    nRange.IndexNumber.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color[Program.ss.Machines.PresentationData.Sheds[ShedIndex].Range_Color.Length - 1].index.ToString();
                    tableLayPanel.Controls.Add(nRange);
                   
                }
                else
                    XtraMessageBox.Show(qres, "Error executing webservice method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            SimpleButton sb = (SimpleButton)sender;
            ColorCauses cCause = ColorCauses.WeaversEfficiency;
            TableLayoutPanel tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
            switch (sb.Name)
            {
                case "btn_Del_EffColor":
                    cCause = ColorCauses.EfficiencyColors;
                    tableLayPanel = this.tableLayoutPanel_EffColor;
                    break;
                case "btn_Del_RPMColor":
                    cCause = ColorCauses.RPMColors;
                    tableLayPanel = this.tableLayoutPanel_RPMColor;
                    break;
                case "btn_Del_WeaverEffColor":
                    cCause = ColorCauses.WeaversEfficiency;
                    tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
                    break;
                case "btn_Del_AvgWarpTimeColor":
                    cCause = ColorCauses.AvgWarpKnotTime;
                    tableLayPanel = this.tableLayoutPanel_AvgWarpTimeColor;
                    break;
                case "btn_Del_AvgWeftTimeColor":
                    tableLayPanel = this.tableLayoutPanel_AvgWeftTimeColor;
                    cCause = ColorCauses.AvgWeftKnotTime;
                    break;

            }
            DialogResult dg = XtraMessageBox.Show("Are you sure to delete selected Range # " + CurrentSelection.CurrentEfficiencyColor.Tag.ToString() + " ?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;
            try
            {
                string qres = WS.svc.Execute_Query("delete from MT_ColorSettings where ColorIndex="+CurrentSelection.CurrentEfficiencyColor.Tag.ToString()+" and ColorCauseID="+(int)cCause+" and shedid="+Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID +"");
                if (qres == "**SUCCESS##")
                {

                    Program.ss.Machines.PresentationData.Sheds[ShedIndex].init_Colors();
                    Load_Colors(tableLayPanel,cCause);

                }
                else
                    XtraMessageBox.Show(qres, "Error executing webservice method", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            SimpleButton sb = (SimpleButton)sender;
            ColorCauses cCause = ColorCauses.WeaversEfficiency;
            TableLayoutPanel tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
            switch (sb.Name)
            {
                case "btn_Save_EffColor":
                    cCause = ColorCauses.EfficiencyColors;
                    tableLayPanel = this.tableLayoutPanel_EffColor;
                    break;
                case "btn_Save_RPMColor":
                    cCause = ColorCauses.RPMColors;
                    tableLayPanel = this.tableLayoutPanel_RPMColor;
                    break;
                case "btn_Save_WeaverEffColor":
                    cCause = ColorCauses.WeaversEfficiency;
                    tableLayPanel = this.tableLayoutPanel_WeaverEffColor;
                    break;
                case "btn_Save_AvgWarpTimeColor":
                    cCause = ColorCauses.AvgWarpKnotTime;
                    tableLayPanel = this.tableLayoutPanel_AvgWarpTimeColor;
                    break;
                case "btn_Save_AvgWeftTimeColor":
                    tableLayPanel = this.tableLayoutPanel_AvgWeftTimeColor;
                    cCause = ColorCauses.AvgWeftKnotTime;
                    break;

            }
            ColorConverter cr=new ColorConverter();
            for (int x = 0; x < tableLayPanel.Controls.Count; x++)
            {
                dxRange Range = (dxRange)tableLayPanel.Controls[x];

                try
                {
                    string fontColor=cr.ConvertToString(Range.RangeColor.ForeColor);
                    string qres = WS.svc.Execute_Query("update MT_ColorSettings set minimum="+Range.RangeFrom.Value.ToString()+",maximum="+Range.RangeTo.Value.ToString()+",FontColor='"+ fontColor+"' where ColorIndex=" +Range.RangeColor.Tag.ToString() + " and ColorCauseID="+(int)cCause+" and ShedID="+Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID+"");
                    if (qres != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(qres, "Error executing webservice method", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                       

                    }
                    
                       
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Program.ss.Machines.PresentationData.Sheds[ShedIndex].init_Colors();
            Load_Colors(tableLayPanel, cCause);
            XtraMessageBox.Show("Range Changes has been executed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookUpEdit_Shed_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_Shed.EditValue != null)
            {
                ShedIndex = Convert.ToInt32(lookUpEdit_Shed.EditValue.ToString());
                Load_Colors(this.tableLayoutPanel_EffColor, ColorCauses.EfficiencyColors);
                Load_Colors(this.tableLayoutPanel_RPMColor, ColorCauses.RPMColors);
                Load_Colors(this.tableLayoutPanel_WeaverEffColor, ColorCauses.WeaversEfficiency);
                Load_Colors(this.tableLayoutPanel_AvgWarpTimeColor, ColorCauses.AvgWarpKnotTime);
                Load_Colors(this.tableLayoutPanel_AvgWeftTimeColor, ColorCauses.AvgWeftKnotTime);
            }
        }
      

       

      
       
      

      

       
      

      
      
    }
}