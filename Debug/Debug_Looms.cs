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
    public partial class Debug_Looms : DevExpress.XtraEditors.XtraForm
    {
        public Debug_Looms()
        {
            InitializeComponent();
            AddLoomsToLoomsView();
        }
        private void AddLoomsToLoomsView()
        {
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                ucLoom uc = new ucLoom();
                uc.lblLoomNumber.Tag = Program.ss.Machines.Looms[x].PersonalInfo.LoomID;
                uc.lblLoomNumber.Text = Program.ss.Machines.Looms[x].PersonalInfo.LoomName;
                uc.lblRPM.Text = Program.ss.Machines.Looms[x].CurrentParams.Current_RPM.ToString();
               
                uc.ShedID.Text = Program.ss.Machines.Looms[x].PersonalInfo.ShedID.ToString();
                if (Program.ss.Machines.Looms[x].PersonalInfo.SaveDebug == MachineService.SaveDebugData.Save)
                    uc.lblLoomNumber.BackColor = Color.Green;
                else
                    uc.lblLoomNumber.BackColor = Color.Yellow;
                layout.Controls.Add(uc);

            }
            ucLoom ucKnown = new ucLoom();
            ucKnown.lblLoomNumber.Tag = "-1";
            ucKnown.lblLoomNumber.Text = "@";
            ucKnown.lblRPM.Text = "";

            ucKnown.ShedID.Text = "@";

            ucKnown.lblLoomNumber.BackColor = Color.Green;

            layout.Controls.Add(ucKnown);

        }
        private void DisplayLoomsData()
        {
            try
            {
                
                if (this.layout.Controls.Count <= 0) return;

                for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
                {

                    ucLoom ucv;

                    ucv = (ucLoom)this.layout.Controls[x];

                    
                    ucv.DataNumber = Program.ss.Machines.Looms[x].CurrentParams.DataNumber;
                    if (Program.ss.Machines.Looms[x].CurrentParams.Current_SinkTime != null)
                    {
                        ucv.NewCounterFetched.Visible = true;
                       
                        TimeSpan ts = DateTime.Now.Subtract(Program.ss.Machines.Looms[x].CurrentParams.Current_SinkTime);


                        ucv.NewCounterFetched.Text = Program.ss.Get_FormattedTime(ts, 1);
                        if (ts.TotalMinutes <= 1)
                            ucv.NewCounterFetched.ForeColor = Color.Green;
                        if (ts.TotalMinutes > 1 && ts.TotalMinutes <= 2)
                            ucv.NewCounterFetched.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes > 2 && ts.TotalMinutes <= 10)
                            ucv.NewCounterFetched.ForeColor = Color.Orange;
                        else if (ts.TotalMinutes > 10)
                            ucv.NewCounterFetched.ForeColor = Color.Red;


                    }
                    else
                        ucv.NewCounterFetched.Visible = false;

                    if (Program.ss.Machines.Looms[x].CurrentParams.CounterTime != null)
                    {
                        ucv.lblTime.Visible = true;
                        TimeSpan ts = DateTime.Now.Subtract(Program.ss.Machines.Looms[x].CurrentParams.CounterTime);

                        ucv.lblTime.Text = Program.ss.Get_FormattedTime(ts,1);
                        if (ts.TotalMinutes <= 1)
                            ucv.lblTime.ForeColor = Color.Green;
                        if (ts.TotalMinutes > 1 && ts.TotalMinutes <= 2)
                            ucv.lblTime.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes > 2 && ts.TotalMinutes <= 10)
                            ucv.lblTime.ForeColor = Color.Orange;
                        else if (ts.TotalMinutes > 10)
                            ucv.lblTime.ForeColor = Color.Red;

                    }
                    else
                        ucv.lblTime.Visible = false;

                    ucv.lblCounter.Text = Program.ss.Machines.Looms[x].CurrentParams.Counter.ToString();
                    switch ((MachineService.CounterState)Program.ss.Machines.Looms[x].CurrentParams.CounterState)
                    {
                        case MachineService.CounterState.Duplicate:
                            ucv.lblCounter.BackColor = Color.Orange;

                            break;
                        case MachineService.CounterState.Missing:
                            ucv.lblCounter.BackColor = Color.Red;
                            break;
                        case MachineService.CounterState.Normal:
                            ucv.lblCounter.BackColor = Color.LawnGreen;
                            break;
                        case MachineService.CounterState.Recovered:
                            ucv.lblCounter.BackColor = Color.BlueViolet;
                            break;
                        case MachineService.CounterState.Reset:
                            ucv.lblCounter.BackColor = Color.Gold;
                            break;
                        case MachineService.CounterState.Unknown:
                            ucv.lblCounter.BackColor = ucv.BackColor;
                            break;

                    }
                    ucv.lblRPM.Text = Program.ss.Machines.Looms[x].CurrentParams.Current_RPM.ToString();
                    ucv.Picks.Text = Program.ss.Machines.Looms[x].CurrentParams.Current_Picks.ToString();
                    ucv.SinkNumber.Text = Program.ss.Machines.Looms[x].CurrentParams.Current_SinkIP;
                    ucv.RFID.Text = Program.ss.Machines.Looms[x].RFIDInfo.Current_RFID;
                    switch ((State)Program.ss.Machines.Looms[x].CurrentParams.Current_State)

                    {
                        case State.PowerOff:
                            ucv.lblStateAndCause.BackColor = Color.Red;
                            ucv.lblStateAndCause.Text = "No Signal";
                            break;
                        case State.Running:
                            ucv.lblStateAndCause.BackColor = Color.Green;
                            ucv.lblStateAndCause.ForeColor = Color.White;
                            ucv.lblStateAndCause.Text = "Running";
                            break;
                        case State.Unknown:
                            ucv.lblStateAndCause.BackColor = Color.Black;
                            ucv.lblStateAndCause.ForeColor = Color.White;
                            ucv.lblStateAndCause.Text = "AVR/ERR";
                            break;
                        case State.Stopped:
                            if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == Cause.Leno)
                            {
                                ucv.lblStateAndCause.BackColor = Color.Indigo;
                                ucv.lblStateAndCause.ForeColor = Color.White;
                                ucv.lblStateAndCause.Text = "Leno";

                            }
                            else if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == Cause.Other)
                            {
                                ucv.lblStateAndCause.BackColor = Color.White;
                                ucv.lblStateAndCause.ForeColor = Color.Black;
                                ucv.lblStateAndCause.Text = "Other";

                            }

                            else if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == Cause.Unknown)
                            {
                                ucv.lblStateAndCause.BackColor = Color.Brown;
                                ucv.lblStateAndCause.ForeColor = Color.White;
                                ucv.lblStateAndCause.Text = "Other";

                            }

                            else if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == Cause.Warp)
                            {
                                ucv.lblStateAndCause.BackColor = Color.Blue;
                                ucv.lblStateAndCause.ForeColor = Color.White;
                                ucv.lblStateAndCause.Text = "Warp";

                            }

                            else if ((Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause == Cause.Weft)
                            {
                                ucv.lblStateAndCause.BackColor = Color.Orange;
                                ucv.lblStateAndCause.ForeColor = Color.Black;
                                ucv.lblStateAndCause.Text = "Weft";

                            }
                            else
                            {
                                Cause tcause = (Cause)Program.ss.Machines.Looms[x].CurrentParams.Current_Cause;
                                ucv.lblStateAndCause.BackColor = Color.Orange;
                                ucv.lblStateAndCause.ForeColor = Color.Black;
                                ucv.lblStateAndCause.Text = tcause.ToString();

                            }
                            break;

                    }
                    }

                                    

                   ucLoom ucvk = (ucLoom)this.layout.Controls[this.layout.Controls.Count-1];

                    
                    ucvk.DataNumber = Program.ss.Machines.UnknownLoomMAC.DataNumber;
                    if (Program.ss.Machines.UnknownLoomMAC.CounterTime != null)
                    {
                        ucvk.NewCounterFetched.Visible = true;
                       
                        TimeSpan ts = DateTime.Now.Subtract(Program.ss.Machines.UnknownLoomMAC.CounterTime);


                        ucvk.NewCounterFetched.Text = Program.ss.Get_FormattedTime(ts, 1);
                        if (ts.TotalMinutes <= 1)
                            ucvk.NewCounterFetched.ForeColor = Color.Green;
                        if (ts.TotalMinutes > 1 && ts.TotalMinutes <= 2)
                            ucvk.NewCounterFetched.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes > 2 && ts.TotalMinutes <= 10)
                            ucvk.NewCounterFetched.ForeColor = Color.Orange;
                        else if (ts.TotalMinutes > 10)
                            ucvk.NewCounterFetched.ForeColor = Color.Red;


                    }
                    else
                        ucvk.NewCounterFetched.Visible = false;

                    if (Program.ss.Machines.UnknownLoomMAC.CounterTime != null)
                    {
                        ucvk.lblTime.Visible = true;
                        TimeSpan ts = DateTime.Now.Subtract(Program.ss.Machines.UnknownLoomMAC.CounterTime);

                        ucvk.lblTime.Text = Program.ss.Get_FormattedTime(ts,1);
                        if (ts.TotalMinutes <= 1)
                            ucvk.lblTime.ForeColor = Color.Green;
                        if (ts.TotalMinutes > 1 && ts.TotalMinutes <= 2)
                            ucvk.lblTime.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes > 2 && ts.TotalMinutes <= 10)
                            ucvk.lblTime.ForeColor = Color.Orange;
                        else if (ts.TotalMinutes > 10)
                            ucvk.lblTime.ForeColor = Color.Red;

                    }
                    else
                        ucvk.lblTime.Visible = false;

                    ucvk.lblCounter.Text = Program.ss.Machines.UnknownLoomMAC.Counter.ToString();
                    
                    ucvk.lblRPM.Text = Program.ss.Machines.UnknownLoomMAC.RPM.ToString();
                    ucvk.Picks.Text = Program.ss.Machines.UnknownLoomMAC.Picks.ToString();
                    ucvk.SinkNumber.Text = Program.ss.Machines.UnknownLoomMAC.SinkIP;

                    switch ((State)Program.ss.Machines.UnknownLoomMAC.State)
                    {
                        case State.PowerOff:
                            ucvk.lblStateAndCause.BackColor = Color.Red;
                            ucvk.lblStateAndCause.Text = "PowerOff";
                            break;
                        case State.Running:
                            ucvk.lblStateAndCause.BackColor = Color.Green;
                            ucvk.lblStateAndCause.ForeColor = Color.White;
                            ucvk.lblStateAndCause.Text = "Running";
                            break;
                        case State.Unknown:
                            ucvk.lblStateAndCause.BackColor = Color.Black;
                            ucvk.lblStateAndCause.ForeColor = Color.White;
                            ucvk.lblStateAndCause.Text = "AVR/ERR";
                            break;
                        case State.Stopped:
                           
                            if ((Cause)Program.ss.Machines.UnknownLoomMAC.Cause== Cause.Leno)
                            {
                                ucvk.lblStateAndCause.BackColor = Color.Indigo;
                                ucvk.lblStateAndCause.ForeColor = Color.White;
                                ucvk.lblStateAndCause.Text = "Leno";

                            }
                            else if ((Cause)Program.ss.Machines.UnknownLoomMAC.Cause == Cause.Other)
                            {
                                
                                ucvk.lblStateAndCause.Text = "Other";

                            }

                            else if ((Cause)Program.ss.Machines.UnknownLoomMAC.Cause == Cause.Unknown)
                            {
                                ucvk.lblStateAndCause.BackColor = Color.Brown;
                                ucvk.lblStateAndCause.ForeColor = Color.White;
                                ucvk.lblStateAndCause.Text = "Other";

                            }

                            else if ((Cause)Program.ss.Machines.UnknownLoomMAC.Cause== Cause.Warp)
                            {
                                ucvk.lblStateAndCause.BackColor = Color.Blue;
                                ucvk.lblStateAndCause.ForeColor = Color.White;
                                ucvk.lblStateAndCause.Text = "Warp";

                            }

                            else if ((Cause)Program.ss.Machines.UnknownLoomMAC.Cause == Cause.Weft)
                            {
                                ucvk.lblStateAndCause.BackColor = Color.Orange;
                                ucvk.lblStateAndCause.ForeColor = Color.Black;
                                ucvk.lblStateAndCause.Text = "Weft";

                            }
                            else
                            {
                                Cause tcause = (Cause)Program.ss.Machines.UnknownLoomMAC.Cause;
                                ucvk.lblStateAndCause.BackColor = Color.Orange;
                                ucvk.lblStateAndCause.ForeColor = Color.Black;
                                ucvk.lblStateAndCause.Text = tcause.ToString();

                            }
                            break;
                            

                    }
                    

                
            }
            catch 
            {
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisplayLoomsData();
        }
    }
}