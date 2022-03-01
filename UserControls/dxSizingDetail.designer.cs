namespace MachineEyes
{
    partial class dxSizingDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BeamLength = new DevExpress.XtraEditors.TextEdit();
            this.BeamSpeed = new DevExpress.XtraEditors.TextEdit();
            this.Pressure = new DevExpress.XtraEditors.TextEdit();
            this.GrossWeight = new DevExpress.XtraEditors.TextEdit();
            this.Remarks = new DevExpress.XtraEditors.TextEdit();
            this.BeamNumber = new DevExpress.XtraEditors.TextEdit();
            this.Sizer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.Shift = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamLength.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamSpeed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pressure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossWeight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sizer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shift.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BeamLength
            // 
            this.BeamLength.EnterMoveNextControl = true;
            this.BeamLength.Location = new System.Drawing.Point(75, 24);
            this.BeamLength.Name = "BeamLength";
            this.BeamLength.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamLength.Properties.Appearance.Options.UseFont = true;
            this.BeamLength.Properties.Mask.EditMask = "n0";
            this.BeamLength.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.BeamLength.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.BeamLength.Properties.NullValuePrompt = "Length";
            this.BeamLength.Properties.NullValuePromptShowForEmptyValue = true;
            this.BeamLength.Size = new System.Drawing.Size(62, 18);
            this.BeamLength.TabIndex = 1;
            this.BeamLength.Leave += new System.EventHandler(this.BeamLength_Leave);
            // 
            // BeamSpeed
            // 
            this.BeamSpeed.EnterMoveNextControl = true;
            this.BeamSpeed.Location = new System.Drawing.Point(205, 2);
            this.BeamSpeed.Name = "BeamSpeed";
            this.BeamSpeed.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamSpeed.Properties.Appearance.Options.UseFont = true;
            this.BeamSpeed.Properties.Mask.EditMask = "n0";
            this.BeamSpeed.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.BeamSpeed.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.BeamSpeed.Properties.NullValuePrompt = "Speed";
            this.BeamSpeed.Properties.NullValuePromptShowForEmptyValue = true;
            this.BeamSpeed.Size = new System.Drawing.Size(64, 18);
            this.BeamSpeed.TabIndex = 2;
            this.BeamSpeed.Leave += new System.EventHandler(this.BeamSpeed_Leave);
            // 
            // Pressure
            // 
            this.Pressure.EnterMoveNextControl = true;
            this.Pressure.Location = new System.Drawing.Point(205, 24);
            this.Pressure.Name = "Pressure";
            this.Pressure.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pressure.Properties.Appearance.Options.UseFont = true;
            this.Pressure.Properties.Mask.EditMask = "n0";
            this.Pressure.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Pressure.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Pressure.Properties.NullValuePrompt = "Pressure";
            this.Pressure.Properties.NullValuePromptShowForEmptyValue = true;
            this.Pressure.Size = new System.Drawing.Size(64, 18);
            this.Pressure.TabIndex = 3;
            this.Pressure.Leave += new System.EventHandler(this.Pressure_Leave);
            // 
            // GrossWeight
            // 
            this.GrossWeight.EditValue = 0D;
            this.GrossWeight.EnterMoveNextControl = true;
            this.GrossWeight.Location = new System.Drawing.Point(354, 2);
            this.GrossWeight.Name = "GrossWeight";
            this.GrossWeight.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrossWeight.Properties.Appearance.Options.UseFont = true;
            this.GrossWeight.Properties.Mask.EditMask = "n2";
            this.GrossWeight.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.GrossWeight.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.GrossWeight.Properties.NullValuePrompt = "Gross Weight";
            this.GrossWeight.Properties.NullValuePromptShowForEmptyValue = true;
            this.GrossWeight.Size = new System.Drawing.Size(65, 18);
            this.GrossWeight.TabIndex = 4;
            // 
            // Remarks
            // 
            this.Remarks.EnterMoveNextControl = true;
            this.Remarks.Location = new System.Drawing.Point(496, 24);
            this.Remarks.Name = "Remarks";
            this.Remarks.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.Properties.Appearance.Options.UseFont = true;
            this.Remarks.Properties.MaxLength = 50;
            this.Remarks.Properties.NullValuePrompt = "Remarks (if any)";
            this.Remarks.Properties.NullValuePromptShowForEmptyValue = true;
            this.Remarks.Size = new System.Drawing.Size(241, 18);
            this.Remarks.TabIndex = 7;
            // 
            // BeamNumber
            // 
            this.BeamNumber.EnterMoveNextControl = true;
            this.BeamNumber.Location = new System.Drawing.Point(75, 2);
            this.BeamNumber.Name = "BeamNumber";
            this.BeamNumber.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BeamNumber.Properties.Appearance.Options.UseFont = true;
            this.BeamNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.BeamNumber.Properties.NullValuePrompt = "Beam #";
            this.BeamNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.BeamNumber.Size = new System.Drawing.Size(62, 18);
            this.BeamNumber.TabIndex = 0;
            this.BeamNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BeamNumber_KeyDown);
            // 
            // Sizer
            // 
            this.Sizer.EnterMoveNextControl = true;
            this.Sizer.Location = new System.Drawing.Point(496, 2);
            this.Sizer.Name = "Sizer";
            this.Sizer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sizer.Properties.Appearance.Options.UseFont = true;
            this.Sizer.Properties.NullValuePrompt = "Press Ctrl +Enter to select Sizers";
            this.Sizer.Properties.NullValuePromptShowForEmptyValue = true;
            this.Sizer.Properties.ReadOnly = true;
            this.Sizer.Size = new System.Drawing.Size(241, 18);
            this.Sizer.TabIndex = 6;
            this.Sizer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Sizer_KeyDown);
            this.Sizer.Leave += new System.EventHandler(this.Sizer_Leave);
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl18.LineVisible = true;
            this.labelControl18.Location = new System.Drawing.Point(3, 3);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(69, 17);
            this.labelControl18.TabIndex = 158;
            this.labelControl18.Text = "Beam #";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 17);
            this.labelControl1.TabIndex = 159;
            this.labelControl1.Text = "Length";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(143, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 160;
            this.labelControl2.Text = "Speed";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(143, 25);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(56, 17);
            this.labelControl3.TabIndex = 161;
            this.labelControl3.Text = "Pressure";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(272, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(76, 17);
            this.labelControl4.TabIndex = 162;
            this.labelControl4.Text = "G.W (Lbs)";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(272, 25);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 17);
            this.labelControl5.TabIndex = 163;
            this.labelControl5.Text = "Shift";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.LineVisible = true;
            this.labelControl6.Location = new System.Drawing.Point(425, 3);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 17);
            this.labelControl6.TabIndex = 164;
            this.labelControl6.Text = "Sizer";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(425, 25);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 17);
            this.labelControl7.TabIndex = 165;
            this.labelControl7.Text = "Remarks";
            // 
            // Shift
            // 
            this.Shift.EnterMoveNextControl = true;
            this.Shift.Location = new System.Drawing.Point(354, 22);
            this.Shift.Name = "Shift";
            this.Shift.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Shift.Properties.Appearance.Options.UseFont = true;
            this.Shift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Shift.Properties.NullText = "";
            this.Shift.Properties.NullValuePrompt = "Shift";
            this.Shift.Properties.NullValuePromptShowForEmptyValue = true;
            this.Shift.Size = new System.Drawing.Size(65, 20);
            this.Shift.TabIndex = 5;
            this.Shift.Leave += new System.EventHandler(this.Shift_Leave);
            // 
            // dxSizingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Shift);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.Sizer);
            this.Controls.Add(this.BeamNumber);
            this.Controls.Add(this.Remarks);
            this.Controls.Add(this.GrossWeight);
            this.Controls.Add(this.Pressure);
            this.Controls.Add(this.BeamSpeed);
            this.Controls.Add(this.BeamLength);
            this.Name = "dxSizingDetail";
            this.Size = new System.Drawing.Size(742, 47);
            ((System.ComponentModel.ISupportInitialize)(this.BeamLength.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamSpeed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pressure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrossWeight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Remarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeamNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sizer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shift.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit BeamLength;
        public DevExpress.XtraEditors.TextEdit BeamSpeed;
        public DevExpress.XtraEditors.TextEdit Pressure;
        public DevExpress.XtraEditors.TextEdit GrossWeight;
        public DevExpress.XtraEditors.TextEdit Remarks;
        public DevExpress.XtraEditors.TextEdit BeamNumber;
        public DevExpress.XtraEditors.TextEdit Sizer;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.LookUpEdit Shift;

    }
}
