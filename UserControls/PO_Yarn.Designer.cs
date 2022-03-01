namespace MachineEyes.UserControls
{
    partial class PO_Yarn
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
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.LbsPerBag = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Lbs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Bags = new DevExpress.XtraEditors.TextEdit();
            this.Desc = new DevExpress.XtraEditors.LookUpEdit();
            this.Blends = new DevExpress.XtraEditors.LookUpEdit();
            this.Ply = new DevExpress.XtraEditors.LookUpEdit();
            this.Counts = new DevExpress.XtraEditors.LookUpEdit();
            this.Ratio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.PicksEndsLabel = new DevExpress.XtraEditors.LabelControl();
            this.Color = new DevExpress.XtraEditors.TextEdit();
            this.PicksEnds = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.LbsPerBag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bags.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blends.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ply.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Counts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ratio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicksEnds.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl8.Location = new System.Drawing.Point(455, 0);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 21);
            this.labelControl8.TabIndex = 364;
            this.labelControl8.Text = "Desc.";
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl6.Location = new System.Drawing.Point(276, 0);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(33, 21);
            this.labelControl6.TabIndex = 362;
            this.labelControl6.Text = "Blend";
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl5.Location = new System.Drawing.Point(114, 0);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 21);
            this.labelControl5.TabIndex = 361;
            this.labelControl5.Text = "Count";
            // 
            // LbsPerBag
            // 
            this.LbsPerBag.EnterMoveNextControl = true;
            this.LbsPerBag.Location = new System.Drawing.Point(233, 21);
            this.LbsPerBag.Name = "LbsPerBag";
            this.LbsPerBag.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbsPerBag.Properties.Appearance.Options.UseFont = true;
            this.LbsPerBag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LbsPerBag.Properties.NullText = "";
            this.LbsPerBag.Properties.NullValuePrompt = "Lbs / Bag";
            this.LbsPerBag.Properties.NullValuePromptShowForEmptyValue = true;
            this.LbsPerBag.Size = new System.Drawing.Size(109, 20);
            this.LbsPerBag.TabIndex = 344;
            this.LbsPerBag.EditValueChanged += new System.EventHandler(this.LbsPerBag_EditValueChanged);
            this.LbsPerBag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl2.Location = new System.Drawing.Point(506, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 21);
            this.labelControl2.TabIndex = 353;
            this.labelControl2.Text = "Lbs.";
            // 
            // Lbs
            // 
            this.Lbs.EnterMoveNextControl = true;
            this.Lbs.Location = new System.Drawing.Point(545, 22);
            this.Lbs.Name = "Lbs";
            this.Lbs.Properties.Mask.EditMask = "n2";
            this.Lbs.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Lbs.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Lbs.Properties.NullValuePrompt = "Lbs.";
            this.Lbs.Properties.NullValuePromptShowForEmptyValue = true;
            this.Lbs.Size = new System.Drawing.Size(138, 20);
            this.Lbs.TabIndex = 347;
            this.Lbs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.Location = new System.Drawing.Point(361, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 21);
            this.labelControl1.TabIndex = 352;
            this.labelControl1.Text = "# of Bags";
            // 
            // Bags
            // 
            this.Bags.EnterMoveNextControl = true;
            this.Bags.Location = new System.Drawing.Point(423, 22);
            this.Bags.Name = "Bags";
            this.Bags.Properties.Mask.EditMask = "n2";
            this.Bags.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Bags.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.Bags.Properties.NullValuePrompt = "# of Bags";
            this.Bags.Properties.NullValuePromptShowForEmptyValue = true;
            this.Bags.Size = new System.Drawing.Size(77, 20);
            this.Bags.TabIndex = 346;
            this.Bags.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // Desc
            // 
            this.Desc.EnterMoveNextControl = true;
            this.Desc.Location = new System.Drawing.Point(494, 1);
            this.Desc.Name = "Desc";
            this.Desc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desc.Properties.Appearance.Options.UseFont = true;
            this.Desc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Desc.Properties.NullText = "";
            this.Desc.Properties.NullValuePrompt = "Description";
            this.Desc.Properties.NullValuePromptShowForEmptyValue = true;
            this.Desc.Properties.ReadOnly = true;
            this.Desc.Size = new System.Drawing.Size(189, 20);
            this.Desc.TabIndex = 343;
            this.Desc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // Blends
            // 
            this.Blends.EnterMoveNextControl = true;
            this.Blends.Location = new System.Drawing.Point(315, 1);
            this.Blends.Name = "Blends";
            this.Blends.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Blends.Properties.Appearance.Options.UseFont = true;
            this.Blends.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Blends.Properties.NullText = "";
            this.Blends.Properties.NullValuePrompt = "Blend";
            this.Blends.Properties.NullValuePromptShowForEmptyValue = true;
            this.Blends.Properties.ReadOnly = true;
            this.Blends.Size = new System.Drawing.Size(138, 20);
            this.Blends.TabIndex = 341;
            this.Blends.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // Ply
            // 
            this.Ply.EnterMoveNextControl = true;
            this.Ply.Location = new System.Drawing.Point(225, 1);
            this.Ply.Name = "Ply";
            this.Ply.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ply.Properties.Appearance.Options.UseFont = true;
            this.Ply.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Ply.Properties.NullText = "";
            this.Ply.Properties.NullValuePrompt = "Ply";
            this.Ply.Properties.NullValuePromptShowForEmptyValue = true;
            this.Ply.Properties.ReadOnly = true;
            this.Ply.Size = new System.Drawing.Size(48, 20);
            this.Ply.TabIndex = 340;
            this.Ply.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // Counts
            // 
            this.Counts.EnterMoveNextControl = true;
            this.Counts.Location = new System.Drawing.Point(151, 1);
            this.Counts.Name = "Counts";
            this.Counts.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counts.Properties.Appearance.Options.UseFont = true;
            this.Counts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Counts.Properties.NullText = "";
            this.Counts.Properties.NullValuePrompt = "Count";
            this.Counts.Properties.NullValuePromptShowForEmptyValue = true;
            this.Counts.Properties.ReadOnly = true;
            this.Counts.Size = new System.Drawing.Size(73, 20);
            this.Counts.TabIndex = 339;
            this.Counts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // Ratio
            // 
            this.Ratio.Location = new System.Drawing.Point(48, 1);
            this.Ratio.Name = "Ratio";
            this.Ratio.Properties.Mask.EditMask = "f3";
            this.Ratio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Ratio.Size = new System.Drawing.Size(64, 20);
            this.Ratio.TabIndex = 371;
            this.Ratio.EditValueChanged += new System.EventHandler(this.Ratio_EditValueChanged);
            this.Ratio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TakeActionAtKeyDown);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl9.Location = new System.Drawing.Point(3, 0);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(39, 21);
            this.labelControl9.TabIndex = 372;
            this.labelControl9.Text = "Ratio";
            // 
            // PicksEndsLabel
            // 
            this.PicksEndsLabel.Appearance.Options.UseTextOptions = true;
            this.PicksEndsLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PicksEndsLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.PicksEndsLabel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.PicksEndsLabel.Location = new System.Drawing.Point(3, 21);
            this.PicksEndsLabel.Name = "PicksEndsLabel";
            this.PicksEndsLabel.Size = new System.Drawing.Size(39, 21);
            this.PicksEndsLabel.TabIndex = 373;
            this.PicksEndsLabel.Text = "P/E";
            this.PicksEndsLabel.Visible = false;
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(160, 22);
            this.Color.Name = "Color";
            this.Color.Properties.Mask.EditMask = "f3";
            this.Color.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.Color.Properties.ReadOnly = true;
            this.Color.Size = new System.Drawing.Size(64, 20);
            this.Color.TabIndex = 374;
            // 
            // PicksEnds
            // 
            this.PicksEnds.Location = new System.Drawing.Point(48, 22);
            this.PicksEnds.Name = "PicksEnds";
            this.PicksEnds.Properties.Mask.EditMask = "f3";
            this.PicksEnds.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.PicksEnds.Properties.ReadOnly = true;
            this.PicksEnds.Size = new System.Drawing.Size(64, 20);
            this.PicksEnds.TabIndex = 375;
            this.PicksEnds.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl4.Location = new System.Drawing.Point(114, 21);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(39, 21);
            this.labelControl4.TabIndex = 376;
            this.labelControl4.Text = "Color";
            // 
            // PO_Yarn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.PicksEnds);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.PicksEndsLabel);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.Ratio);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.LbsPerBag);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Lbs);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Bags);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.Blends);
            this.Controls.Add(this.Ply);
            this.Controls.Add(this.Counts);
            this.Name = "PO_Yarn";
            this.Size = new System.Drawing.Size(686, 45);
            this.Load += new System.EventHandler(this.PO_Yarn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LbsPerBag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Lbs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bags.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Desc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blends.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ply.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Counts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ratio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Color.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicksEnds.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit LbsPerBag;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit Lbs;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit Bags;
        public DevExpress.XtraEditors.LookUpEdit Desc;
        public DevExpress.XtraEditors.LookUpEdit Blends;
        public DevExpress.XtraEditors.LookUpEdit Ply;
        public DevExpress.XtraEditors.LookUpEdit Counts;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        public DevExpress.XtraEditors.TextEdit Ratio;
        public DevExpress.XtraEditors.LabelControl PicksEndsLabel;
        public DevExpress.XtraEditors.TextEdit Color;
        public DevExpress.XtraEditors.TextEdit PicksEnds;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
