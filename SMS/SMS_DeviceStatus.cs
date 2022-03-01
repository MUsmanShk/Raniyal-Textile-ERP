using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.SMS
{
    public partial class SMS_DeviceStatus : DevExpress.XtraEditors.XtraForm
    {
        public SMS_DeviceStatus()
        {
            InitializeComponent();
        }

        private void RefreshDeviceandServiceStatus_Click(object sender, EventArgs e)
        {
            try
            {
                MachineService.SMSDeviceStatus DevStatus;
                DevStatus = WS.svc.SMS_Get_DeviceAndServiceStatus();
                if (DevStatus != null)
                {
                    this.ServiceTime.Text = DevStatus.TimeWhenServiceResponded.ToString();
                    if (DateTime.Now.Subtract(DevStatus.TimeWhenServiceResponded).TotalMinutes< 3)
                    {
                        this.ServiceStatus.Text = "RUNNING";
                        this.ServiceStatus.ForeColor = Color.Blue;
                    }
                    else
                    {
                        this.ServiceStatus.Text = "NOT RESPONDING";
                        this.ServiceStatus.ForeColor = Color.Red;
                    }
               
                   
                    this.ServiceElapsedTime.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenServiceResponded),(int)TimeFormats.AutoHHMMSS);
                    if (DevStatus.isPortOpen == true)
                    {
                        this.PortStatus.ForeColor = Color.Blue;
                        this.PortStatus.Text = "Open";
                    }
                    else
                    {
                        this.PortStatus.ForeColor = Color.Red;
                        this.PortStatus.Text = "Closed";
                    }

                    if (DevStatus.isGSMWorking == true )
                    {
                        this.GSMStatus.ForeColor = Color.Blue;
                        this.GSMStatus.Text = "OK";
                    }
                    else
                    {
                        this.GSMStatus.ForeColor = Color.Red;
                        this.GSMStatus.Text = "OUT OF NETWORK";
                    }
                    if (DevStatus.isDeviceResponding == true && DateTime.Now.Subtract(DevStatus.TimeWhenDeviceDataReceived).TotalMinutes<=2)
                    {
                        this.DeviceStatus.ForeColor = Color.Blue;
                        this.DeviceStatus.Text = "CONNECTED";
                    }
                    else
                    {
                        this.DeviceStatus.ForeColor = Color.Red;
                        this.DeviceStatus.Text = "NOT CONNECTED";
                    }

                    this.Device_ElapsedTimeWhenReset.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenDeviceReset), (int)TimeFormats.AutoHHMMSS);
                    this.Device_TimeWhenDeviceReset.Text = DevStatus.TimeWhenDeviceReset.ToString();
                    this.Device_TimeWhenDataSent.Text = DevStatus.TimeWhenDataSentToDevice.ToString();
                    this.Device_ElapsedTimeWhenDataSent.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenDataSentToDevice), (int)TimeFormats.AutoHHMMSS);
                    this.Device_TimeWhenDataReceived.Text = DevStatus.TimeWhenDeviceDataReceived.ToString();
                    this.Device_ElapsedTimeWhenDataReceived.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenDeviceDataReceived), (int)TimeFormats.AutoHHMMSS);

                    this.SMS_TimeWhenReceived.Text = DevStatus.TimeWhenNewSMSReceived.ToString();
                    this.SMS_ElapsedTimeReceived.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenNewSMSReceived), (int)TimeFormats.AutoHHMMSS);
                    this.DataReceived.Text = DevStatus.DataReceived;
                    this.SMS_TimeWhenSent.Text = DevStatus.TimeWhenLastSMSSentByDevice.ToString();
                    this.SMS_ElapsedTimeSent.Text = Program.ss.Get_FormattedTime(DateTime.Now.Subtract(DevStatus.TimeWhenLastSMSSentByDevice), (int)TimeFormats.AutoHHMMSS);
                    this.CMGSReply.Text = DevStatus.CMGSREPLY;
                    this.CMGSReplyTime.Text = DevStatus.CMGSREPLYTIME.ToString();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}