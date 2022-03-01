using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Debug
{
    public partial class Debug_Devices : DevExpress.XtraEditors.XtraForm
    {
        public Debug_Devices()
        {
            InitializeComponent();
            AddDevicesToDevicesView();
        }
        private void AddDevicesToDevicesView()
        {
            for (int x = 0; x < Program.ss.Machines.Devices.Length; x++)
            {
                udDevice dc = new udDevice();
                dc.DeviceID.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceID == null ? "0" : Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceID;
                dc.DeviceName.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceName==null?"Not Configured":Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceName;
                dc.DeviceType.Tag = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceTypeID==null? "0":Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceTypeID;
                dc.DeviceType.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceTypeName == null ? "Infox Display Board" : Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.DeviceTypeName;
                dc.MultipleSheds.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.MultipleSheds == false ? "False" : Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.MultipleSheds.ToString();
                dc.PauseSeconds.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.PauseSeconds.ToString();
                dc.isEnabled.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.isEnabled.ToString();
                dc.RemotePort.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.RemotePort.ToString();
                dc.Shed_1.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.ShedID_1;
                dc.Shed_2.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.ShedID_2;
                dc.Shed_3.Text = Program.ss.Machines.Devices[x].PublicInfo.PersonalInfo.ShedID_3;
                this.layout.Controls.Add(dc);
                CreateListColumns(dc.ClientsList);
            }
           
            
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int d=0;d<Program.ss.Machines.Devices.Length;d++)
            {
            for (int x = 0; x < Program.ss.Machines.Devices[d].ListInfo.Length; x++)
            {
                udDevice ud = (udDevice)this.layout.Controls[d];
                bool exist = ExistInList(Program.ss.Machines.Devices[d].ListInfo[x].Handle,ud);
                if (exist == false)
                {
                    AddtoList(Program.ss.Machines.Devices[d].ListInfo[x],ud);
                }

            }
            }

        ReCheck:
            for (int c = 0; c < this.layout.Controls.Count; c++)
            {
                udDevice ud = (udDevice)this.layout.Controls[c];
                for (int x = 0; x < ud.ClientsList.Items.Count; x++)
                {
                    bool exist = ExistInService(ud.ClientsList.Items[x].ListView.Items[0].Text,c);
                    if (exist == false)
                    {
                        ud.ClientsList.Items[x].Remove();
                        goto ReCheck;
                    }
                    else
                    {
                        UpdateList(GetCLI(ud.ClientsList.Items[x].SubItems[0].Text,c), x,ud);
                    }
                }
            }


        }
        private void AddtoList(MachineService.DisplayBoardsClientListInfo cli,udDevice ud)
        {
            
            ud.ClientsList.Items.Add(cli.Handle, cli.Handle, -1);

            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(ud.ClientsList.Items.Count.ToString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.IP);
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenConnectionEstablished.ToLongDateString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenConnectionEstablished.ToLongTimeString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.Socket);
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenDataSent.ToLongDateString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenDataSent.ToLongTimeString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.DataNumber.ToString());
            ud.ClientsList.Items[ud.ClientsList.Items.Count - 1].SubItems.Add(cli.Data);

        }
        private void CreateListColumns(ListView lv)
        {
            ListView lvtcpclients = lv;
            lvtcpclients.FullRowSelect = true;
            lvtcpclients.GridLines = true;
            lvtcpclients.Clear();

            lvtcpclients.Columns.Add("Handle", "Handle", 100, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("Index", "Index", 50, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("IP", "IP", 100, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("TimeWhenConnectionEstablishedDate", "Connection Date", 250, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("TimeWhenConnectionEstablishedTime", "Connection Time", 250, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("Socket", "Socket", 100, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("TimeWhenDataSentDate", "Data Date", 250, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("TimeWhenDataSentTime", "Data Time", 250, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("DataNumber", "Data Number", 200, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("Data", "Data", 200, HorizontalAlignment.Left, -1);
            lv.View = System.Windows.Forms.View.Details;
            lvtcpclients.GridLines = false;

        }
        private MachineService.DisplayBoardsClientListInfo GetCLI(string Handle,int deviceindex)
        {
            for (int x = 0; x < Program.ss.Machines.Devices[deviceindex].ListInfo.Length; x++)
            {
                if (Program.ss.Machines.Devices[deviceindex].ListInfo[x].Handle == Handle)
                    return Program.ss.Machines.Devices[deviceindex].ListInfo[x];
            }
            return null;
        }
        private void UpdateList(MachineService.DisplayBoardsClientListInfo cli, int ItemIndex,udDevice ud)
        {
            if (cli == null) return;
            if (cli.Handle == ud.ClientsList.Items[ItemIndex].SubItems[0].Text)
            {
                if (ud.ClientsList.Items[ItemIndex].SubItems[8].Text != cli.DataNumber.ToString())
                {
                    ud.ClientsList.Items[ItemIndex].SubItems[2].Text = cli.IP;
                    ud.ClientsList.Items[ItemIndex].SubItems[3].Text = cli.TimeWhenConnectionEstablished.ToLongDateString();
                    ud.ClientsList.Items[ItemIndex].SubItems[4].Text = cli.TimeWhenConnectionEstablished.ToLongTimeString();
                    ud.ClientsList.Items[ItemIndex].SubItems[5].Text = cli.Socket;
                    ud.ClientsList.Items[ItemIndex].SubItems[6].Text = cli.TimeWhenDataSent.ToLongDateString();
                    ud.ClientsList.Items[ItemIndex].SubItems[7].Text = cli.TimeWhenDataSent.ToLongTimeString();
                    ud.ClientsList.Items[ItemIndex].SubItems[8].Text = cli.DataNumber.ToString();
                    ud.ClientsList.Items[ItemIndex].SubItems[9].Text = cli.Data;

                }
            }

        }
        private bool ExistInService(string Handle,int DeviceIndex)
        {
            for (int x = 0; x < Program.ss.Machines.Devices[x].ListInfo.Length; x++)
            {
                if (Program.ss.Machines.Devices[DeviceIndex].ListInfo[x].Handle == Handle)
                    return true;
            }
            return false;
        }
        private bool ExistInList(string Handle,udDevice ud)
        {
            for (int x = 0; x < ud.ClientsList.Items.Count; x++)
            {
                if (ud.ClientsList.Items[x].SubItems[0].Text == Handle)
                    return true;
            }
            return false;
        }

        
    }
}