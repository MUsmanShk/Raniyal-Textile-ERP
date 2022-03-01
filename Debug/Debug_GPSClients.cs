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
    public partial class Debug_GPSClients : DevExpress.XtraEditors.XtraForm
    {

        public Debug_GPSClients()
        {
            InitializeComponent();
            CreateListColumns();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.GPSTCPClients.Length; x++)
            {
                bool exist = ExistInList(Program.ss.Machines.PresentationData.GPSTCPClients[x].Handle);
                if (exist == false)
                {
                    AddtoList(Program.ss.Machines.PresentationData.GPSTCPClients[x]);
                }

            }
           
            ReCheck:
            for (int x = 0; x < ClientsList.Items.Count; x++)
            {
                bool exist = ExistInService(ClientsList.Items[x].ListView.Items[0].Text);
                if (exist == false)
                {
                    ClientsList.Items[x].Remove();
                    goto ReCheck;
                }
                else
                {
                    UpdateList(GetCLI(ClientsList.Items[x].SubItems[0].Text), x);
                }
            }

          
        }
        private void AddtoList(MachineService.ClientListInfo cli)
        {
            ClientsList.Items.Add(cli.Handle, cli.Handle, -1);
            
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(ClientsList.Items.Count.ToString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.IP);
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenConnectionEstablished.ToLongDateString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenConnectionEstablished.ToLongTimeString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.Socket);
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenDataReceived.ToLongDateString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.TimeWhenDataReceived.ToLongTimeString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.DataNumber.ToString());
            ClientsList.Items[ClientsList.Items.Count - 1].SubItems.Add(cli.Data);
           
        }
        private void CreateListColumns()
        {
            ListView lvtcpclients = this.ClientsList;
            lvtcpclients.FullRowSelect = true;
            lvtcpclients.GridLines = true;
            lvtcpclients.Clear();
            
            lvtcpclients.Columns.Add("Handle","Handle", 100, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("Index", "Index", 50, HorizontalAlignment.Left, -1);
            lvtcpclients.Columns.Add("IP","IP", 100, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("TimeWhenConnectionEstablishedDate","Connection Date", 250, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("TimeWhenConnectionEstablishedTime","Connection Time", 250, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("Socket","Socket", 100, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("TimeWhenDataReceivedDate","Data Date", 250, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("TimeWhenDataReceivedTime","Data Time", 250, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("DataNumber","Data Number", 200, HorizontalAlignment.Left,-1);
            lvtcpclients.Columns.Add("Data","Data", 200, HorizontalAlignment.Left,-1);
            ClientsList.View = System.Windows.Forms.View.Details;
            lvtcpclients.GridLines = false;

        }
        private MachineService.ClientListInfo GetCLI(string Handle)
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.GPSTCPClients.Length; x++)
            {
                if (Program.ss.Machines.PresentationData.GPSTCPClients[x].Handle == Handle)
                    return Program.ss.Machines.PresentationData.GPSTCPClients[x];
            }
            return null; 
        }
        private void UpdateList(MachineService.ClientListInfo cli,int ItemIndex)
        {
            if (cli == null) return;
            if (cli.Handle == ClientsList.Items[ItemIndex].SubItems[0].Text)
            {
                if (ClientsList.Items[ItemIndex].SubItems[8].Text != cli.DataNumber.ToString())
                {
                    ClientsList.Items[ItemIndex].SubItems[2].Text = cli.IP;
                    ClientsList.Items[ItemIndex].SubItems[3].Text = cli.TimeWhenConnectionEstablished.ToLongDateString();
                    ClientsList.Items[ItemIndex].SubItems[4].Text = cli.TimeWhenConnectionEstablished.ToLongTimeString();
                    ClientsList.Items[ItemIndex].SubItems[5].Text = cli.Socket;
                    ClientsList.Items[ItemIndex].SubItems[6].Text = cli.TimeWhenDataReceived.ToLongDateString();
                    ClientsList.Items[ItemIndex].SubItems[7].Text = cli.TimeWhenDataReceived.ToLongTimeString();
                    ClientsList.Items[ItemIndex].SubItems[8].Text = cli.DataNumber.ToString();
                    ClientsList.Items[ItemIndex].SubItems[9].Text = cli.Data;

                }
            }

        }
        private bool ExistInService(string Handle)
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.GPSTCPClients.Length; x++)
            {
                if (Program.ss.Machines.PresentationData.GPSTCPClients[x].Handle == Handle)
                    return true;
            }
            return false;
        }
        private bool ExistInList(string Handle)
        {
            for (int x = 0; x < ClientsList.Items.Count; x++)
            {
                if (ClientsList.Items[x].SubItems[0].Text  == Handle)
                    return true;
            }
            return false;
        }
    }
}