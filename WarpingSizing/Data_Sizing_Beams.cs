using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.WarpingSizing
{
    public partial class Data_Sizing_Beams : DevExpress.XtraEditors.XtraForm
    {
        public Data_Sizing_Beams()
        {
            InitializeComponent();
        }

        private void InsertNew_Click(object sender, EventArgs e)
        {
            if (this.BeamNumber.Text == "")
            {
                XtraMessageBox.Show("invalid beam number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BeamStatus bs = Program.ss.Machines.PresentationData.Return_BeamStatus(this.BeamNumber.Text);
            if (bs != BeamStatus.BeamNotFound)
            {
                XtraMessageBox.Show("Beam already exist ...please verify the beamnumber you entered is correct for new entry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string query = "insert into SW_Beams (BeamNumber,TareWeight,BeamWidth) values(";
                query += "'" + this.BeamNumber.Text  + "',";

                if(this.TareWeight.EditValue==null)
                    query += "null,";
                else
                    query += "" +TareWeight.EditValue.ToString() + "" + ",";

                if (this.BeamWidth.EditValue == null)
                    query += "null)";
                else
                    query += "" +BeamWidth.EditValue.ToString() + "" + ")";
                string res=WS.svc.Execute_Query(query);
                if (res == "**SUCCESS##")
                {
                    Program.ss.Machines.PresentationData.init_Beams();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Closeit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}