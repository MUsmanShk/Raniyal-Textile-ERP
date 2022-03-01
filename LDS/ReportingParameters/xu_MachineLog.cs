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
    public partial class xu_MachineLog : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_MachineLog()
        {
            InitializeComponent();
            dFrom.EditValue = DateTime.Now;
            dUpto.EditValue = DateTime.Now;
        }

        private void SelectDate_Click(object sender, EventArgs e)
        {
           
           
            Reports.Loom_Log Log = new Reports.Loom_Log();
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString());
            if (ShedIndex == -1)
            {
                XtraMessageBox.Show("invalid shed", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int TypeIndex = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_Types(Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.TypeID.ToString());

            if (TypeIndex == -1)
            {
                XtraMessageBox.Show("invalid Type", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            string Table = "LoomLog_" + CurrentSelection.LoomIndex.ToString();
            Log.repH_LoomNumber.Text = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName;
            Log.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            Log.repH_LoomType.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].TypeName;
            Log.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

           
            int LongstopsMin = 0;
            int.TryParse(this.LongStopMinutes.Text, out LongstopsMin);

            string dsstring ="";
            if(Radio_RecordsType.EditValue.ToString()=="0")
                dsstring = "SELECT     * from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + "";
            else if(Radio_RecordsType.EditValue.ToString()=="1")
                 dsstring= "SELECT     * from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and cause not in(1,2,3,4,5) and datediff(n,sDated,eDated)>="+LongstopsMin.ToString()+" ";
            else if (Radio_RecordsType.EditValue.ToString() == "2")
                dsstring = "SELECT     * from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and cause in(1,2,3,4,5) and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + "";
            else if (Radio_RecordsType.EditValue.ToString() == "3")
                dsstring = "SELECT     * from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State<>1 and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + " ";
            else if (Radio_RecordsType.EditValue.ToString() == "4")
                dsstring = "SELECT     * from " + Table + " where  sDated>='" + this.dFrom.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and eDated<='" + this.dUpto.DateTime.ToString(MachineEyes.Classes.Accounting.culture) + "' and State=1 and datediff(n,sDated,eDated)>=" + LongstopsMin.ToString() + " ";
            DataSet ds = WS.svc.Get_DataSet(dsstring);

            if (ds == null)
            {
                XtraMessageBox.Show("No Records Found", "Empty Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Log.BeginInit();
            Log.repH_From.Text = this.dFrom.DateTime.ToString();
            Log.repH_To.Text = this.dUpto.DateTime.ToString();
            if (ds != null)
            {
               
                if (ds.Tables[0].Rows.Count > 0)
                    Log.DataSource = ds;
                else
                    Log.DataSource = null;
            }
            else
                Log.DataSource = null;
            Log.EndInit();
            Log.ShowPreview();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            MachineEyes.Accounts.ReportingParameters.MultiReports mr = (MachineEyes.Accounts.ReportingParameters.MultiReports)this.Parent.Parent;
            mr.Close();
        }
    }
}
