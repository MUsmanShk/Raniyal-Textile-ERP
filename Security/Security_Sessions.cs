using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.Security
{
    public partial class Security_Sessions : DevExpress.XtraEditors.XtraForm
    {
        public Security_Sessions()
        {
            InitializeComponent();
        }
        private void Loadsessions()
        {
            try
            {
                DataSet ds = new DataSet();
                this.gridView1.Columns.Clear();
                this.gridControl1.DataSource = null;

                ds = WS.svc.get_ssSessions();


                if (ds != null)
                {
                    this.gridControl1.DataSource = ds.Tables[0];


                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Security_Sessions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Security_Sessions_Load(object sender, EventArgs e)
        {
            Loadsessions();
        }
    }
}