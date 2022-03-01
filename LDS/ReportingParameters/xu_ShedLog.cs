using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.LDS.ReportingParameters
{
    public partial class xu_ShedLog : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_ShedLog()
        {
            InitializeComponent();
            dFrom.EditValue = DateTime.Now;
            dUpto.EditValue = DateTime.Now;
        }

        private void Close_Click(object sender, EventArgs e)
        {

            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }

        private void SelectDate_Click(object sender, EventArgs e)
        {
            Reports.Efficiency_LongStops Log = new Reports.Efficiency_LongStops();
            
          



            
           
           
          
            Log.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Log.SessionStartLog.Text = this.dFrom.DateTime.ToString();
            Log.SessionEndLog.Text = this.dUpto.DateTime.ToString();
            DataSet dsmain = null; 
            int LongstopsMin = 0;
            int.TryParse(this.LongStopMinutes.Text, out LongstopsMin);
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                string Table = "LoomLog_" + x.ToString();
                string dsstring = "";
                if (Radio_RecordsType.EditValue.ToString() == "0")
                    dsstring = "SELECT     "+Program.ss.Machines.Looms[x].PersonalInfo.LoomName+" as LoomName,Shift,ShiftDated,sDated,eDated,State from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + "";
                else if (Radio_RecordsType.EditValue.ToString() == "1")
                    dsstring = "SELECT     " + Program.ss.Machines.Looms[x].PersonalInfo.LoomName + " as LoomName,Shift,ShiftDated,sDated,eDated,State from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and cause not in(1,2,3,4,5) and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + " ";
                else if (Radio_RecordsType.EditValue.ToString() == "2")
                    dsstring = "SELECT     " + Program.ss.Machines.Looms[x].PersonalInfo.LoomName + " as LoomName,Shift,ShiftDated,sDated,eDated,State from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and cause in(1,2,3,4,5) and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + "";
                else if (Radio_RecordsType.EditValue.ToString() == "3")
                    dsstring = "SELECT     " + Program.ss.Machines.Looms[x].PersonalInfo.LoomName + " as LoomName,Shift,ShiftDated,sDated,eDated,State from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + " ";
                else if (Radio_RecordsType.EditValue.ToString() == "4")
                    dsstring = "SELECT     " + Program.ss.Machines.Looms[x].PersonalInfo.LoomName + " as LoomName,Shift,ShiftDated,sDated,eDated,State from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State=1 and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + " ";
                DataSet ds = WS.svc.Get_DataSet(dsstring);
                if (dsmain == null) dsmain = ds;
                else
                    dsmain.Merge(ds);
            }
          
            Log.BeginInit();
           
            if (dsmain != null)
            {

                if (dsmain.Tables[0].Rows.Count > 0)
                    Log.DataSource = dsmain;
                else
                    Log.DataSource = null;
            }
            else
                Log.DataSource = null;
            Log.EndInit();
            Log.ShowPreview();
        }
    }
}
