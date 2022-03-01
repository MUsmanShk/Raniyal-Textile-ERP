using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MachineEyes.Debug
{
    public partial class ucLoom : UserControl
    {
        public int DataNumber;
        public ucLoom()
        {
            InitializeComponent();
        }
        private void ucLoom_Load(object sender, EventArgs e)
        {
           
        }
        private void button_zbState_Click(object sender, EventArgs e)
        {
        }
        
     
        private void lblLoomNumber_DoubleClick(object sender, EventArgs e)
        {

        }
        private void ucLoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.lblLoomNumber.Tag != null)
                {
                    if (this.lblLoomNumber.Tag.ToString() != "")
                    
                    {
                        if (this.lblLoomNumber.Tag.ToString() != "-1")
                        {
                            currentMAC.Text = Program.ss.Machines.Looms[Convert.ToInt16(this.lblLoomNumber.Tag)].PersonalInfo.MAC;
                            currentLRFID.Text = Program.ss.Machines.Looms[Convert.ToInt16(this.lblLoomNumber.Tag)].RFIDInfo.Current_RFID;
                           
                        }
                        else if (this.lblLoomNumber.Tag.ToString() == "-1")
                        {
                            currentMAC.Text = Program.ss.Machines.UnknownLoomMAC.MAC;
                            currentLRFID.Text = Program.ss.Machines.UnknownLoomMAC.RFID;
                        }
                       
                        contextMenuStrip1.Show(this, Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
                    }
                }
            }
        }
       
        private void setMACAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.lblLoomNumber.Tag.ToString()!="-1")
            SETLOOM_MACAdress(Convert.ToInt16(this.lblLoomNumber.Tag),currentMAC.Text);
        }

        private void SETLOOM_MACAdress(int argLoomID, string newMAC)
        {
            try
            {
                string s = WS.svc.SETLOOM_MACAdress(argLoomID, newMAC);
                if (s == "**SUCCESS##")
                {
                    Program.ss.Machines.Looms[argLoomID].PersonalInfo.MAC = newMAC;
                    MessageBox.Show("Mac Address Changed per instructions", "MAC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(s, "Error MAC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        private void setRFIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }

}
