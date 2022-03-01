using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MachineEyes.View
{
    public partial class View_FilterView : DevExpress.XtraEditors.XtraForm
    {
        public View_FilterView()
        {
            InitializeComponent();
           
            //for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            //{
            //    Da
            //}
            LoadGrid();
            
        }
        private void LoadGrid()
        {
            UserControls.dx_FilterView View = new UserControls.dx_FilterView();
            View.Width = Screen.PrimaryScreen.WorkingArea.Width;
            View.Height = Screen.PrimaryScreen.WorkingArea.Height;
           
           

            this.panelControl1.Controls.Add(View);
        }

    }
   
   
}