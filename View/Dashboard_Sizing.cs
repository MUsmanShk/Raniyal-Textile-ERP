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
    public partial class Dashboard_Sizing : DevExpress.XtraEditors.XtraForm
    {
        public Dashboard_Sizing()
        {
            InitializeComponent();
        }

        private void Load_Sets()
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sets.Length; x++)
            {
                dxSetEff setsEff = new dxSetEff();
                this.scrollSets.Controls.Add(setsEff);
                if (x > 0) setsEff.Top = this.scrollSets.Controls[x - 1].Top + this.scrollSets.Controls[x - 1].Height;
                setsEff.IndexNumber.Text = Convert.ToString(x + 1);
                setsEff.SetNo.Text = Program.ss.Machines.PresentationData.Sets[x].SetNumber;
                setsEff.SetNo.Tag = Program.ss.Machines.PresentationData.Sets[x].SetNumber;
                setsEff.SizingDate.Text = Program.ss.Machines.PresentationData.Sets[x].SizingDate.ToShortDateString();
                setsEff.AvgWarpBrkgs_Current.Text = Program.ss.Machines.PresentationData.Sets[x].AvgWarpBreakagesPerHour_Current.ToString();
                setsEff.SetEff_Current.Text = Program.ss.Machines.PresentationData.Sets[x].Efficiency_Current.ToString("#,##0.0") + "%";

            }

        }
        private void ChangeTops()
        {

            for (int x = 0; x < this.scrollSets.Controls.Count; x++)
            {

                this.scrollSets.Controls[x].Top = this.scrollSets.Controls[x].Top - 1;
                if (this.scrollSets.Controls[x].Top < (this.scrollSets.Controls[x].Height - (this.scrollSets.Controls[x].Height * 2)))
                    this.scrollSets.Controls[x].Top = this.scrollSets.Controls[x == 0 ? this.scrollSets.Controls.Count - 1 : x - 1].Top + this.scrollSets.Controls[0].Height;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeTops();
        }

        private void Dashboard_Sizing_Load(object sender, EventArgs e)
        {
            Load_Sets();
        }

        private void Dashboard_Sizing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }
    }
}