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
    public partial class udDevice : UserControl
    {
        public udDevice()
        {
            InitializeComponent();
        }

        private void setMACAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SETDEVICE_MACAdress(Convert.ToInt32(this.DeviceID.Text), currentMAC.Text);
        }
        private void SETDEVICE_MACAdress(int argDeviceID, string newMAC)
        {
            try
            {
                string s = WS.svc.SETDEVICE_MacAddress(argDeviceID, newMAC);
                if (s == "**SUCCESS##")
                {
                    //Program.ss.Machines.Devices[argDeviceID].PersonalInfo.MAC = newMAC;
                    RemotePort.Text = newMAC;

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
        private void SETDEVICE_PauseSeconds(int argDeviceID, string newPauseSeconds)
        {
            try
            {
                //string s = Logic.svc.SETDEVICE_PauseSeconds(argDeviceID, newPauseSeconds);
                //if (s == "**SUCCESS##")
                //{
                //   Logic.Devices[argDeviceID].PersonalInfo.PauseSeconds = Convert.ToInt32(newPauseSeconds);
                //    MessageBox.Show("Device Pause Seconds Changed as per instructions", "Pause Seconds", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show(s, "Error PauseSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void udDevice_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int DeviceIndex = Convert.ToInt16(this.DeviceID.Text);
                if (DeviceIndex != -1)
                {
                    //currentMAC.Text = Program.ss.Devices[DeviceIndex].PersonalInfo.MAC;
                    //currentPauseSeconds.Text = Logic.Devices[Convert.ToInt16(this.DeviceID.Text)].PersonalInfo.PauseSeconds.ToString();
                   // contextMenuStrip1.Show(this, Screen.PrimaryScreen.WorkingArea.X, Screen.PrimaryScreen.WorkingArea.Y);
                }
            }
        }

        private void setPauseSecondstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SETDEVICE_PauseSeconds(Convert.ToInt32(this.DeviceID.Text), currentPauseSeconds.Text);
        }

        private void Ping_Data_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NodeID_Click(object sender, EventArgs e)
        {

        }
      
    }
}
