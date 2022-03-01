using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Yarn.ReportingParameters
{
    public partial class SW_SizingSummary : DevExpress.XtraEditors.XtraUserControl
    {
        public SW_SizingSummary()
        {
            InitializeComponent();
        }

        private void CloseMe_Click(object sender, EventArgs e)
        {
            MachineEyes.Yarn.ReportingParameters.Yarn_Reports mr = (MachineEyes.Yarn.ReportingParameters.Yarn_Reports)this.Parent.Parent;
            mr.Close();
        }

        private void PrintReport_Click(object sender, EventArgs e)
        {
            if (this.SetNo.EditValue == null)
            {
                XtraMessageBox.Show("Invalid set no", "Error", MessageBoxButtons.OK);
                return;
            }
            if (this.RefWarpingProgramNumber.EditValue == null)
            {
                XtraMessageBox.Show("Invalid warping program ", "Error", MessageBoxButtons.OK);
                return;
            }
            MachineEyes.Classes.Printing.Print_SW_SizingSummary(this.SetNo.EditValue.ToString(),this.RadioPageSetting.EditValue.ToString());
        }

        private void SetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                string strFilterQuery = "SELECT  SETNO,WarpingProgramNumber,Ends,SizingDate,TotalSizedBeams,SizingMachineID from SW_Sizing ";
                strFilterQuery += "  where SizingTypeID='1' ";
                selectedrow sRow = new selectedrow();





                strFilterQuery += " ORDER BY setno ";
                Data.Data_View FrmView = new Data.Data_View();
                FrmView.Load_View(strFilterQuery, "SetNO", "WarpingProgramNumber");
                FrmView.sRow = sRow;
                FrmView.ShowDialog();
                if (sRow.Status == ParameterStatus.Selected)
                {

                    if (sRow.SelectedDataRow == null)
                        return;
                    this.SetNo.EditValue = sRow.PrimeryID;
                    this.RefWarpingProgramNumber.EditValue = sRow.PrimaryString;


                }
            }
        }
    }
}
