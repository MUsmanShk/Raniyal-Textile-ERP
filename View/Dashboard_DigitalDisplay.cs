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
    public partial class Dashboard_DigitalDisplay : DevExpress.XtraEditors.XtraForm
    {
        public int ShedIndex;
        public Dashboard_DigitalDisplay()
        {
            InitializeComponent();
        }

        private void Dashboard_DigitalDisplay_Enter(object sender, EventArgs e)
        {
            CurrentSelection.SelectedView = this;
        }
        private void ChangeTops()
        {
            
          
            for (int x = 0; x < this.scrollLooms.Controls.Count; x++)
            {

                UserControls.dxLoomZ dxEffZ = (UserControls.dxLoomZ)this.scrollLooms.Controls[x];

                try
                {
                    Program.ss.SetMachineDisplayZ(ref Program.ss.Machines.Looms[Convert.ToInt32(dxEffZ.LoomNumber.Tag)], ref dxEffZ);
                }
                catch
                {
                }
               
                //this.scrollLooms.Controls[x].Left = this.scrollLooms.Controls[x].Left -3;
              
                //if (this.scrollLooms.Controls[x].Left < (this.scrollLooms.Controls[x].Width - (this.scrollLooms.Controls[x].Width * 3)))
                //    this.scrollLooms.Controls[x].Left = this.scrollLooms.Controls[x == 0 ? this.scrollLooms.Controls.Count - 1 : x - 1].Left + this.scrollLooms.Controls[0].Width;

            }
        }
        private void Dashboard_DigitalDisplay_Load(object sender, EventArgs e)
        {

            ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.Tag.ToString());
            Settings.DataWaitingSeconds = 300;
           
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                if (Program.ss.Machines.Looms[x].PersonalInfo.ShedID == Convert.ToInt16(this.Tag.ToString()))
                {

                    UserControls.dxLoomZ uc = new UserControls.dxLoomZ();
                    uc.LoomNumber.Text = Program.ss.Machines.Looms[x].PersonalInfo.LoomName;
                    uc.LoomNumber.Tag = Program.ss.Machines.Looms[x].PersonalInfo.LoomID;
                    uc.Efficiency.Tag = "0.0";
                    uc.Left = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.DisplayX);
                    uc.Top = Convert.ToInt32(Program.ss.Machines.Looms[x].Drawing.DisplayY);
                    uc.Name = "Loom" + x.ToString();
                    ControlMover.Init(uc);
                    //if (this.scrollLooms.Controls.Count >= 1)
                    //    uc.Left = this.scrollLooms.Controls[this.scrollLooms.Controls.Count - 1].Left + uc.Width;
                    this.scrollLooms.Controls.Add(uc);
                    
                     
                }



            }

        }

        private void timer_AutoRefresh_Tick(object sender, EventArgs e)
        {
            ChangeTops();
            if (this.ShedEfficiency.Tag.ToString() != Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString())
            {
                this.ShedEfficiency.Tag = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString();
                this.ShedEfficiency.Text = double.IsNaN(Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff) == true ? "0.0" : Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedEfficiency.Eff.ToString("#,##0.0");

            }
        }

        private void Dashboard_DigitalDisplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.Exit == false) { e.Cancel = true; this.Hide(); }
        }

        private void Dashboard_DigitalDisplay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Hide();
        }
    }
}