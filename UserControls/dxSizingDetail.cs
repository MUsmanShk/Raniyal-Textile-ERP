using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes
{
    public partial class dxSizingDetail : DevExpress.XtraEditors.XtraUserControl
    {
        public bool AddMode = false;
        enum SizingProductionType { SizedfromOutsideSizingOurBeams = 0, SizedfromInHouseSizingOurBeams = 1,SizedfromOutSideSizingPartyBeams=2,SizedfromInHouseSizingPartyBeams=3 };
       
        public dxSizingDetail()
        {
            InitializeComponent();
            FillCombos fc = new FillCombos();
            fc.Shifts(ref this.Shift);
        }


        private void Sizer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                try
                {
                
                string query = "select EmployeeID,EmployeeName from PP_Employees where SubDepartmentID in(Select SubDepartmentID from PP_DepartmentsSub where DepartmentID='" + Departments.Sizing + "') order by Convert(numeric(18),EmployeeID)";
                selectedrow sr = new selectedrow();
                Data.Data_View DView = new Data.Data_View();
                DView.Load_View(query, "EmployeeID", "EmployeeName");
                DView.sRow = sr;
                DView.ShowDialog();
                if (sr.Status != ParameterStatus.Selected)
                    return;
                this.Sizer.Tag = sr.PrimeryID;
                this.Sizer.Text = sr.PrimaryString;
              
                }catch(Exception ex)
                {
                    XtraMessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        

        private void BeamLength_Leave(object sender, EventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                dxSizingDetail dxs = (dxSizingDetail)c;
                if (dxs.BeamLength.EditValue == null)
                    dxs.BeamLength.EditValue = this.BeamLength.EditValue;

            }
        }

        private void BeamSpeed_Leave(object sender, EventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                dxSizingDetail dxs = (dxSizingDetail)c;
                if (dxs.BeamSpeed.EditValue == null)
                {
                    dxs.BeamSpeed.EditValue = this.BeamSpeed.EditValue;

                }

            }
        }

        private void Pressure_Leave(object sender, EventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                dxSizingDetail dxs = (dxSizingDetail)c;
                if (dxs.Pressure.EditValue == null)
                {
                    dxs.Pressure.EditValue = this.Pressure.EditValue;

                }

            }
        }

        private void Shift_Leave(object sender, EventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                dxSizingDetail dxs = (dxSizingDetail)c;
                if (dxs.Shift.EditValue == null)
                {
                    dxs.Shift.EditValue = this.Shift.EditValue;

                }

            }
        }

        private void Sizer_Leave(object sender, EventArgs e)
        {
            foreach (Control c in this.Parent.Controls)
            {
                dxSizingDetail dxs = (dxSizingDetail)c;
                if (dxs.Sizer.EditValue == null)
                {
                    dxs.Sizer.EditValue = this.Sizer.EditValue;
                    dxs.Sizer.Tag = this.Sizer.Tag;
                }

            }
        }

        private void BeamNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && e.Control == true)
            {
                if (this.BeamNumber.Tag == null) return;
                if (this.Tag == null) return;
                if (BeamNumber.Tag != null)
                {
                    if (BeamNumber.Tag.ToString() != "")
                    {
                        DialogResult dg = XtraMessageBox.Show("Are you sure to delete beam # " + this.BeamNumber.Tag.ToString() + "", "Delete Beam",MessageBoxButtons.YesNo);
                        if (dg != DialogResult.Yes) return;
                        string query = "delete from SW_Sizing_Details where BeamNumber='" + this.BeamNumber.Tag.ToString() + "' and SetNo='" + this.Tag.ToString() + "'";
                       string res= WS.svc.Execute_Query(query);
                       if (res == "**SUCCESS##")
                       {
                           foreach (Control c in this.Parent.Controls)
                           {
                               dxSizingDetail dxs = (dxSizingDetail)c;
                               if (dxs.BeamNumber.Tag == this.BeamNumber.Tag)
                               {
                                   this.Parent.Controls.Remove(c);

                               }

                           }
                       }
                       else
                       {
                           XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK);
                           return;
                       }
                    }
                }
            }
        }


    }
}
