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
    public partial class Dashboard_ShedEfficiencyGraph : DevExpress.XtraEditors.XtraForm
    {
        public int ShedIndex;
        public Dashboard_ShedEfficiencyGraph()
        {
            InitializeComponent();
        }

        private void Dashboard_ShedEfficiencyGraph_Load(object sender, EventArgs e)
        {
            this.chart1.Series.Clear();
            System.Windows.Forms.DataVisualization.Charting.Series s = new System.Windows.Forms.DataVisualization.Charting.Series("Looms");
            this.chart1.Series.Add(s);
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                
                System.Windows.Forms.DataVisualization.Charting.DataPoint dp = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0, 0);
                this.chart1.Series[0].Points.Add(dp);
                this.chart1.Series[0].Points[x].BorderColor = Color.Red;
                this.chart1.Series[0].Points[x].IsValueShownAsLabel = false;
                this.chart1.Series[0].Points[x].Label = Program.ss.Machines.Looms[x].PersonalInfo.LoomName;
                this.chart1.Series[0].Points[x].LabelBorderWidth = 2;
             
           
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {


                this.chart1.Series[0].Points[x].BorderColor = ReturnCauseColor((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause);
                if (this.chart1.Series[0].Points[x].YValues[0] != Program.ss.Machines.Looms[x].CurrentParams.Current_Eff)
                {
                    this.chart1.Series[0].Points[x].YValues[0] = Program.ss.Machines.Looms[x].CurrentParams.Current_Eff;
                    this.chart1.Series[0].Points[x].Color = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnColor(ColorCauses.EfficiencyColors, Program.ss.Machines.Looms[x].CurrentParams.Current_Eff);
                }
                
                
                


            }
        }
        private Color ReturnCauseColor(Cause cause)
        {
            if (cause == Cause.Warp)
                return Color.Blue;
            else if (cause == Cause.Weft)
                return Color.Red;
            else if (cause == Cause.Unknown)
                return Color.White;
            else if (cause == Cause.PowerOff)
                return Color.Black;
            else if (cause == Cause.Other)
                return Color.Blue;

            return Color.Yellow;
        }

        private void Dashboard_ShedEfficiencyGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }
    }
}