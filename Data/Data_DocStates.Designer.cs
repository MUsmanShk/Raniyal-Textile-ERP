namespace MachineEyes.Data
{
    partial class Data_DocStates
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioStates = new DevExpress.XtraEditors.RadioGroup();
            this.SelectDocumentState = new DevExpress.XtraEditors.SimpleButton();
            this.Cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.radioStates.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // radioStates
            // 
            this.radioStates.Location = new System.Drawing.Point(2, 3);
            this.radioStates.Name = "radioStates";
            this.radioStates.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("0", "Open"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "Closed"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "Authorized"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "Cancelled")});
            this.radioStates.Size = new System.Drawing.Size(136, 115);
            this.radioStates.TabIndex = 0;
            // 
            // SelectDocumentState
            // 
            this.SelectDocumentState.Location = new System.Drawing.Point(2, 124);
            this.SelectDocumentState.Name = "SelectDocumentState";
            this.SelectDocumentState.Size = new System.Drawing.Size(65, 23);
            this.SelectDocumentState.TabIndex = 1;
            this.SelectDocumentState.Text = "Select";
            this.SelectDocumentState.Click += new System.EventHandler(this.Select_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(73, 124);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(65, 23);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Data_DocStates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(141, 153);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.SelectDocumentState);
            this.Controls.Add(this.radioStates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Data_DocStates";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Document States";
            ((System.ComponentModel.ISupportInitialize)(this.radioStates.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton SelectDocumentState;
        private DevExpress.XtraEditors.SimpleButton Cancel;
        public DevExpress.XtraEditors.RadioGroup radioStates;
    }
}