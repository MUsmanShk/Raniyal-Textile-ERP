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
    public partial class xu_SelectedLoomsEfficiency : DevExpress.XtraEditors.XtraUserControl
    {
        public xu_SelectedLoomsEfficiency()
        {
            InitializeComponent();
        }

        private void xu_SelectedLoomsEfficiency_Load(object sender, EventArgs e)
        {
            FillCombos fc = new FillCombos();
            fc.Sheds(ref this.LookupShed);
            this.Dated.DateTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
        }

        private void LookupShed_EditValueChanged(object sender, EventArgs e)
        {
            this.IncludedList.DataSource = null;
            if (this.LookupShed.EditValue != null)
            {
               // int shedindex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(this.LookupShed.EditValue.ToString());
                int ShedID=0 ;
                int.TryParse(this.LookupShed.EditValue.ToString(), out ShedID);

                DataSet ds=WS.svc.Get_DataSet("Select LoomID,LoomName from MT_Looms where ShedID="+ShedID+" order by Convert(numeric(9),LoomName)");
                this.IncludedList.DataSource =ds.Tables[0];
                this.IncludedList.ValueMember="LoomID";
                this.IncludedList.DisplayMember="LoomName";
             
                //for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
                //{
                //    if (Program.ss.Machines.Looms[x].PersonalInfo.ShedID == ShedID)
                //    {
                //        this.IncludedList.Items.d(Program.ss.Machines.Looms[x].PersonalInfo.LoomName
                //    }
                //}
            }
        }
        
    }
}
