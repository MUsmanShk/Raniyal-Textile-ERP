namespace MachineEyes.WarpingSizing
{
    partial class Data_Sizing_Beams
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
            this.Closeit = new DevExpress.XtraEditors.SimpleButton();
            this.InsertNew = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BeamNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TareWeight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.BeamWidth = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TareWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamWidth.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Closeit
            // 
            this.Closeit.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closeit.Appearance.Options.UseFont = true;
            this.Closeit.Image = global::MachineEyes.Properties.Resources.Close16;
            this.Closeit.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Closeit.Location = new System.Drawing.Point(294, 79);
            this.Closeit.Name = "Closeit";
            this.Closeit.Size = new System.Drawing.Size(26, 25);
            this.Closeit.TabIndex = 237;
            this.Closeit.Click += new System.EventHandler(this.Closeit_Click);
            // 
            // InsertNew
            // 
            this.InsertNew.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsertNew.Appearance.Options.UseFont = true;
            this.InsertNew.Image = global::MachineEyes.Properties.Resources.Execute;
            this.InsertNew.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.InsertNew.Location = new System.Drawing.Point(262, 79);
            this.InsertNew.Name = "InsertNew";
            this.InsertNew.Size = new System.Drawing.Size(26, 25);
            this.InsertNew.TabIndex = 236;
            this.InsertNew.Click += new System.EventHandler(this.InsertNew_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(44, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 17);
            this.labelControl1.TabIndex = 238;
            this.labelControl1.Text = "Beam Number";
            // 
            // BeamNumber
            // 
            this.BeamNumber.Location = new System.Drawing.Point(139, 12);
            this.BeamNumber.Name = "BeamNumber";
            this.BeamNumber.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamNumber.Properties.Appearance.Options.UseFont = true;
            this.BeamNumber.Properties.MaxLength = 13;
            this.BeamNumber.Size = new System.Drawing.Size(181, 23);
            this.BeamNumber.TabIndex = 239;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(23, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 17);
            this.labelControl2.TabIndex = 240;
            this.labelControl2.Text = "Tare Weight (Lbs)";
            // 
            // TareWeight
            // 
            this.TareWeight.Location = new System.Drawing.Point(139, 41);
            this.TareWeight.Name = "TareWeight";
            this.TareWeight.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TareWeight.Properties.Appearance.Options.UseFont = true;
            this.TareWeight.Properties.Mask.EditMask = "n2";
            this.TareWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.TareWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TareWeight.Properties.MaxLength = 13;
            this.TareWeight.Size = new System.Drawing.Size(88, 23);
            this.TareWeight.TabIndex = 241;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(128, 17);
            this.labelControl3.TabIndex = 242;
            this.labelControl3.Text = "Beam Width (inches)";
            // 
            // BeamWidth
            // 
            this.BeamWidth.Location = new System.Drawing.Point(139, 76);
            this.BeamWidth.Name = "BeamWidth";
            this.BeamWidth.Properties.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamWidth.Properties.Appearance.Options.UseFont = true;
            this.BeamWidth.Properties.Mask.EditMask = "n";
            this.BeamWidth.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.BeamWidth.Properties.MaxLength = 13;
            this.BeamWidth.Size = new System.Drawing.Size(88, 23);
            this.BeamWidth.TabIndex = 243;
            // 
            // Data_Sizing_Beams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 119);
            this.ControlBox = false;
            this.Controls.Add(this.BeamWidth);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.TareWeight);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.BeamNumber);
            this.Controls.Add(this.Closeit);
            this.Controls.Add(this.InsertNew);
            this.Name = "Data_Sizing_Beams";
            this.Text = "New Empty Beam";
            ((System.ComponentModel.ISupportInitialize)(this.BeamNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TareWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamWidth.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Closeit;
        private DevExpress.XtraEditors.SimpleButton InsertNew;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TareWeight;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit BeamWidth;
        public DevExpress.XtraEditors.TextEdit BeamNumber;
    }
}