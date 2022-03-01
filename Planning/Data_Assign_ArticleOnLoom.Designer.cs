namespace MachineEyes.Data
{
    partial class Data_Assign_ArticleOnLoom
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.AssignTime = new DevExpress.XtraEditors.TextEdit();
            this.CloseForm = new DevExpress.XtraEditors.SimpleButton();
            this.ChangeArticle = new DevExpress.XtraEditors.SimpleButton();
            this.BrowseArticleNumbers = new DevExpress.XtraEditors.SimpleButton();
            this.ArticleDesignNumber = new DevExpress.XtraEditors.LabelControl();
            this.ArticleName = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.ArticleNumber = new DevExpress.XtraEditors.LabelControl();
            this.ArticleChangeSheetNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxLoomInfo1 = new MachineEyes.UserControls.dxLoomInfo();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssignTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.AssignTime);
            this.groupControl1.Controls.Add(this.CloseForm);
            this.groupControl1.Controls.Add(this.ChangeArticle);
            this.groupControl1.Controls.Add(this.BrowseArticleNumbers);
            this.groupControl1.Controls.Add(this.ArticleDesignNumber);
            this.groupControl1.Controls.Add(this.ArticleName);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.ArticleNumber);
            this.groupControl1.Controls.Add(this.ArticleChangeSheetNumber);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(11, 158);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(794, 271);
            this.groupControl1.TabIndex = 64;
            this.groupControl1.Text = "Running Article";
            // 
            // AssignTime
            // 
            this.AssignTime.Location = new System.Drawing.Point(141, 78);
            this.AssignTime.Name = "AssignTime";
            this.AssignTime.Size = new System.Drawing.Size(316, 20);
            this.AssignTime.TabIndex = 203;
            this.AssignTime.ToolTip = "Press Ctrl + Enter to Select Date and Time or Ctrl + Insert to Insert now time.";
            this.AssignTime.ToolTipTitle = "Knotting Time";
            this.AssignTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AssignTime_KeyDown);
            // 
            // CloseForm
            // 
            this.CloseForm.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseForm.Appearance.Options.UseFont = true;
            this.CloseForm.Image = global::MachineEyes.Properties.Resources.Close16;
            this.CloseForm.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.CloseForm.Location = new System.Drawing.Point(696, 225);
            this.CloseForm.Name = "CloseForm";
            this.CloseForm.Size = new System.Drawing.Size(43, 41);
            this.CloseForm.TabIndex = 202;
            this.CloseForm.Click += new System.EventHandler(this.Close_Click);
            // 
            // ChangeArticle
            // 
            this.ChangeArticle.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeArticle.Appearance.Options.UseFont = true;
            this.ChangeArticle.Image = global::MachineEyes.Properties.Resources.Execute;
            this.ChangeArticle.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.ChangeArticle.Location = new System.Drawing.Point(647, 225);
            this.ChangeArticle.Name = "ChangeArticle";
            this.ChangeArticle.Size = new System.Drawing.Size(43, 41);
            this.ChangeArticle.TabIndex = 199;
            this.ChangeArticle.Click += new System.EventHandler(this.ChangeArticle_Click);
            // 
            // BrowseArticleNumbers
            // 
            this.BrowseArticleNumbers.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseArticleNumbers.Appearance.Options.UseFont = true;
            this.BrowseArticleNumbers.Image = global::MachineEyes.Properties.Resources.browse;
            this.BrowseArticleNumbers.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.BrowseArticleNumbers.Location = new System.Drawing.Point(275, 41);
            this.BrowseArticleNumbers.Name = "BrowseArticleNumbers";
            this.BrowseArticleNumbers.Size = new System.Drawing.Size(20, 21);
            this.BrowseArticleNumbers.TabIndex = 198;
            this.BrowseArticleNumbers.Click += new System.EventHandler(this.BrowseArticleNumbers_Click);
            // 
            // ArticleDesignNumber
            // 
            this.ArticleDesignNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ArticleDesignNumber.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ArticleDesignNumber.Location = new System.Drawing.Point(141, 165);
            this.ArticleDesignNumber.Name = "ArticleDesignNumber";
            this.ArticleDesignNumber.Size = new System.Drawing.Size(225, 22);
            this.ArticleDesignNumber.TabIndex = 73;
            // 
            // ArticleName
            // 
            this.ArticleName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ArticleName.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ArticleName.Location = new System.Drawing.Point(141, 138);
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.Size = new System.Drawing.Size(598, 21);
            this.ArticleName.TabIndex = 72;
            // 
            // labelControl7
            // 
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl7.LineVisible = true;
            this.labelControl7.Location = new System.Drawing.Point(5, 77);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(130, 21);
            this.labelControl7.TabIndex = 71;
            this.labelControl7.Text = "Assign Time";
            // 
            // ArticleNumber
            // 
            this.ArticleNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ArticleNumber.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ArticleNumber.Location = new System.Drawing.Point(141, 113);
            this.ArticleNumber.Name = "ArticleNumber";
            this.ArticleNumber.Size = new System.Drawing.Size(225, 19);
            this.ArticleNumber.TabIndex = 70;
            // 
            // ArticleChangeSheetNumber
            // 
            this.ArticleChangeSheetNumber.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.ArticleChangeSheetNumber.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.ArticleChangeSheetNumber.Location = new System.Drawing.Point(141, 41);
            this.ArticleChangeSheetNumber.Name = "ArticleChangeSheetNumber";
            this.ArticleChangeSheetNumber.Size = new System.Drawing.Size(128, 21);
            this.ArticleChangeSheetNumber.TabIndex = 69;
            // 
            // labelControl4
            // 
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(5, 165);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(130, 22);
            this.labelControl4.TabIndex = 68;
            this.labelControl4.Text = "Design Number";
            // 
            // labelControl3
            // 
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(5, 41);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(130, 21);
            this.labelControl3.TabIndex = 67;
            this.labelControl3.Text = "Article  Change Sheet #";
            // 
            // labelControl2
            // 
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(5, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(130, 21);
            this.labelControl2.TabIndex = 66;
            this.labelControl2.Text = "Construction";
            // 
            // labelControl1
            // 
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 113);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(130, 19);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "Article Number";
            // 
            // dxLoomInfo1
            // 
            this.dxLoomInfo1.Location = new System.Drawing.Point(8, 1);
            this.dxLoomInfo1.Name = "dxLoomInfo1";
            this.dxLoomInfo1.Size = new System.Drawing.Size(803, 147);
            this.dxLoomInfo1.TabIndex = 63;
            // 
            // Data_Assign_ArticleOnLoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 441);
            this.ControlBox = false;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.dxLoomInfo1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Data_Assign_ArticleOnLoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Article on Loom";
            this.Load += new System.EventHandler(this.Data_Assign_ArticleOnLoom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssignTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.dxLoomInfo dxLoomInfo1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl ArticleNumber;
        private DevExpress.XtraEditors.LabelControl ArticleChangeSheetNumber;
        private DevExpress.XtraEditors.LabelControl ArticleDesignNumber;
        private DevExpress.XtraEditors.LabelControl ArticleName;
        private DevExpress.XtraEditors.SimpleButton BrowseArticleNumbers;
        private DevExpress.XtraEditors.SimpleButton ChangeArticle;
        private DevExpress.XtraEditors.SimpleButton CloseForm;
        private DevExpress.XtraEditors.TextEdit AssignTime;
    }
}