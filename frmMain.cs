using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.Utils.Drawing;
using DevExpress.Utils;
using DevExpress.Tutorials.Controls;
using DevExpress.XtraEditors.Controls;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraTab;
using DevExpress.XtraBars;
using System.Linq;
using MachineEyes.View;
using DevExpress.XtraBars.Alerter;

namespace MachineEyes {
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm {
        public bool AutoLogin_Succeeded = false;
        Dashboard_Shed[] ShedView=new Dashboard_Shed[0];
       
        Dashboard_ShedMergedView[] ShedMergedLayout = new Dashboard_ShedMergedView[0];
        View.Dashboard_DigitalDisplay[] DigitalDisplay = new View.Dashboard_DigitalDisplay[0];
        Dashboard_Shed_Classic[] ShedClassicView = new Dashboard_Shed_Classic[0];
        DashBoard_Shed_MakeView[] ShedMakeView = new DashBoard_Shed_MakeView[0];
        Dashboard_Sizing SizingView;
        Dashboard_Weavers[] WeaversScrollView=new Dashboard_Weavers[0];
        DashBoard_WeaversMainView[] WeaversMainView=new DashBoard_WeaversMainView[0];
        Data_Tools_EfficiencyColors EfficiencyColors;
        View.Dashboard_Executive ExecutiveSummary;
        Dashboard_ModelShedEff[] ModelEff = new Dashboard_ModelShedEff[0];
        MachineEyes.View.Dashboard_ArticleEfficiency_ScrollView ArticleScrollView;
        serviceStatus preServiceStatus = new serviceStatus();
        public Data_Article_Main_View ArticleView;
        public Planning.Data_ArticleTowel_Main_View ArticleTowelView;
        public Planning.Data_ArticleJacquard_Main_View ArticleJacquardView;
        public Planning.Data_ArticleGreige_Main_View ArticleGreigeView;
        public MachineService.alertinfo NewAlert = new MachineService.alertinfo();
        public Data.Data_Looms LoomsList = new Data.Data_Looms();
        public Accounts.AccountsList AccountsList = new Accounts.AccountsList();
        public Store.Store_ItemsList StoreAccountsList = new Store.Store_ItemsList();

        public bool ListsLoaded = false;
        public frmMain() {
           
            InitializeComponent();
            CreateColorPopup(popupControlContainer1);
            InitSkinGallery();
            InitFontGallery();
            InitColorGallery();
            preServiceStatus = serviceStatus.DISCONNECTED;
            UserLookAndFeel.Default.SetSkinStyle("Office 2010 Black");
            DisableMenu();
            ribbonControl1.SelectedPage = page_LDS;
           
        }

        int documentIndex = 0;
        ColorPopup cp;
        
        
        GalleryItem fCurrentFontItem, fCurrentColorItem;
        string DocumentName { get { return string.Format("New Document {0}", documentIndex); } }

       
        
        
       
       
      

        private void CreateColorPopup(PopupControlContainer container) {
            cp = new ColorPopup(container, iFontColor, this);
        }
        #region Init
        private void frmMain_Activated(object sender, System.EventArgs e) {
            
        }
        public void UpdateText() {
            ribbonControl1.ApplicationCaption = "Machine Eyes ";
            ribbonControl1.ApplicationDocumentCaption ="" ;
           
        }
        void ChangeActiveForm() {
            UpdateText();
            
            
        }
        private void xtraTabbedMdiManager1_FloatMDIChildActivated(object sender, EventArgs e) {
            ChangeActiveForm();
        }
        private void xtraTabbedMdiManager1_FloatMDIChildDeactivated(object sender, EventArgs e) {
            BeginInvoke(new MethodInvoker(ChangeActiveForm));
        }
        private void frmMain_MdiChildActivate(object sender, System.EventArgs e) {
            ChangeActiveForm();
        }
        void rtPad_SelectionChanged(object sender, System.EventArgs e) {
           
            RichTextBox rtPad = sender as RichTextBox;
            InitFormat();
        
          
          
            
        }
        

        protected void InitFormat() {
           
            bool enabled = true;
            rgbiFontColor.Enabled = enabled;
            
            rpgFont.ShowCaptionButton = enabled;
            rpgFontColor.ShowCaptionButton = enabled;
            if(!enabled) ClearFormats();
         
        }

        void ClearFormats()
        {
            bbi_Debug_DebugMode.Down = false;
            bbi_Tools_RPMColors.Down = false;
            bbi_Tools_EffColors.Down = false;
        }

       

  

        void InitNewDocument(RichTextBox rtbControl) {
            rtbControl.SelectionChanged += new System.EventHandler(this.rtPad_SelectionChanged);
            
        }

        void InitCurrentDocument(RichTextBox rtbControl) {
            bool enabled = rtbControl != null;
           
    
            bbiUserManagement.Enabled = enabled;
            
           
           
           
            
            
            InitFormat();
        }


        #endregion
 
        #region Format
        private FontStyle rtPadFontStyle() {
            FontStyle fs = new FontStyle();
            if(bbi_Debug_DebugMode.Down) fs |= FontStyle.Bold;
            if(bbi_Tools_RPMColors.Down) fs |= FontStyle.Italic;
            if(bbi_Tools_EffColors.Down) fs |= FontStyle.Underline;
            return fs;
        }

      
       

      

       


       
        void ShowFontDialog() {
            
            Font dialogFont = null;
            
            XtraFontDialog dlg = new XtraFontDialog(dialogFont);
            if(dlg.ShowDialog() == DialogResult.OK) {
                //CurrentRichTextBox.SelectionFont = dlg.ResultFont;
                beiFontSize.EditValue = dlg.ResultFont.Size;
            }
        }
        private void iFont_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ShowFontDialog();
        }
        private void iFontColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if (EfficiencyColors != null)
                if(CurrentSelection.CurrentEfficiencyColor!=null)
                CurrentSelection.CurrentEfficiencyColor.ForeColor = cp.ResultColor;
            //CurrentRichTextBox.SelectionColor = cp.ResultColor;
        }
        #endregion
        #region Edit
       
     

        

        

       
      
        private void ribbonPageGroup2_CaptionButtonClick(object sender, DevExpress.XtraBars.Ribbon.RibbonPageGroupEventArgs e) {
            pmMain.ShowPopup(ribbonControl1.Manager, MousePosition);
        }
        #endregion
        #region SkinGallery
        void InitSkinGallery() {
            SimpleButton imageButton = new SimpleButton();
            foreach(SkinContainer cnt in SkinManager.Default.Skins) {
                imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName);
                GalleryItem gItem = new GalleryItem();
                int groupIndex = 0;
                if(cnt.SkinName.Contains("Office")) groupIndex = 1;
                if(DevExpress.DXperience.Demos.LookAndFeelMenu.IsBonusSkin(cnt.SkinName)) groupIndex = 2;
                rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                gItem.Caption = cnt.SkinName;

                gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                gItem.Caption = cnt.SkinName;
                gItem.Hint = cnt.SkinName;
            }
            rgbiSkins.Gallery.Groups[1].Visible = false;
            rgbiSkins.Gallery.Groups[2].Visible = false;
        }
        Bitmap GetSkinImage(SimpleButton button, int width, int height, int indent) {
            Bitmap image = new Bitmap(width, height);
            using(Graphics g = Graphics.FromImage(image)) {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));
                info.Bounds = new Rectangle(0, 0, width, height);
                button.LookAndFeel.Painter.GroupPanel.DrawObject(info);
                button.LookAndFeel.Painter.Border.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, width - indent * 2, height - indent * 2);
                button.LookAndFeel.Painter.Button.DrawObject(info);
            }
            return image;
        }
        private void rgbiSkins_Gallery_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e) {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
        }

        private void rgbiSkins_Gallery_InitDropDownGallery(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e) {
            e.PopupGallery.CreateFrom(rgbiSkins.Gallery);
            e.PopupGallery.AllowFilter = false;
            e.PopupGallery.ShowItemText = true;
            e.PopupGallery.ShowGroupCaption = true;
            e.PopupGallery.AllowHoverImages = false;
            foreach(GalleryItemGroup galleryGroup in e.PopupGallery.Groups)
                foreach(GalleryItem item in galleryGroup.Items)
                    item.Image = item.HoverImage;
            e.PopupGallery.ColumnCount = 2;
            e.PopupGallery.ImageSize = new Size(70, 36);
        }
        #endregion
        #region FontGallery
        Image GetFontImage(int width, int height, string fontName, int fontSize) {
            Rectangle rect = new Rectangle(0, 0, width, height);
            Image fontImage = new Bitmap(width, height);
            try {
                using(Font fontSample = new Font(fontName, fontSize)) {
                    Graphics g = Graphics.FromImage(fontImage);
                    g.FillRectangle(Brushes.White, rect);
                    using(StringFormat fs = new StringFormat()) {
                        fs.Alignment = StringAlignment.Center;
                        fs.LineAlignment = StringAlignment.Center;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        g.DrawString("Aa", fontSample, Brushes.Black, rect, fs);
                        g.Dispose();
                    }
                }
            }
            catch { }
            return fontImage;
        }
        void InitFont(GalleryItemGroup groupDropDown, GalleryItemGroup galleryGroup) {
            FontFamily[] fonts = FontFamily.Families;
            for(int i = 0; i < fonts.Length; i++) {
                if(!FontFamily.Families[i].IsStyleAvailable(FontStyle.Regular)) continue;
                string fontName = fonts[i].Name;
                GalleryItem item = new GalleryItem();
                item.Caption = fontName;
                item.Image = GetFontImage(32, 28, fontName, 12);
                item.HoverImage = item.Image;
                item.Description = fontName;
                item.Hint = fontName;
                try {
                    item.Tag = new Font(fontName, 9);
                    if(DevExpress.Utils.ControlUtils.IsSymbolFont((Font)item.Tag)) {
                        item.Tag = new Font(DevExpress.Utils.AppearanceObject.DefaultFont.FontFamily, 9);
                        item.Description += " (Symbol Font)";
                    }
                }
                catch {
                    continue;
                }
                groupDropDown.Items.Add(item);
                galleryGroup.Items.Add(item);
            }
        }
        void InitFontGallery() {
            InitFont(gddFont.Gallery.Groups[0], rgbiFont.Gallery.Groups[0]);
            beiFontSize.EditValue = 8;
        }
        
       
        private void gddFont_Gallery_CustomDrawItemText(object sender, GalleryItemCustomDrawEventArgs e) {
            DevExpress.XtraBars.Ribbon.ViewInfo.GalleryItemViewInfo itemInfo = e.ItemInfo as DevExpress.XtraBars.Ribbon.ViewInfo.GalleryItemViewInfo;
            itemInfo.PaintAppearance.ItemDescription.DrawString(e.Cache, e.Item.Description, itemInfo.DescriptionBounds);
            AppearanceObject app = itemInfo.PaintAppearance.ItemCaption.Clone() as AppearanceObject;
            app.Font = (Font)e.Item.Tag;
            try {
                e.Cache.Graphics.DrawString(e.Item.Caption, app.Font, app.GetForeBrush(e.Cache), itemInfo.CaptionBounds);
            }
            catch { }
            e.Handled = true;
        }
        #endregion
        #region ColorGallery
        void InitColorGallery() {
            gddFontColor.BeginUpdate();
            foreach(Color color in DevExpress.XtraEditors.Popup.ColorListBoxViewInfo.WebColors) {
                if(color == Color.Transparent) continue;
                GalleryItem item = new GalleryItem();
                item.Caption = color.Name;
                item.Tag = color;
                item.Hint = color.Name;
                gddFontColor.Gallery.Groups[0].Items.Add(item);
                rgbiFontColor.Gallery.Groups[0].Items.Add(item);
            }
            foreach(Color color in DevExpress.XtraEditors.Popup.ColorListBoxViewInfo.SystemColors) {
                GalleryItem item = new GalleryItem();
                item.Caption = color.Name;
                item.Tag = color;
                gddFontColor.Gallery.Groups[1].Items.Add(item);
            }
            gddFontColor.EndUpdate();
        }
        private void gddFontColor_Gallery_CustomDrawItemImage(object sender, GalleryItemCustomDrawEventArgs e) {
            Color clr = (Color)e.Item.Tag;
            using(Brush brush = new SolidBrush(clr)) {
                e.Cache.FillRectangle(brush, e.Bounds);
                e.Handled = true;
            }
        }
        
      
        
        #endregion



        public DevExpress.XtraEditors.XtraForm CheckifFormAlradyOpen(string Name)
        {
            try
            {
                foreach (DevExpress.XtraEditors.XtraForm form1 in Application.OpenForms)
                {
                    if (form1.Name == Name)
                        return form1;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
        private void iWeb_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Process process = new Process();
            process.StartInfo.FileName = "http://www.infox.com.pk";
            process.StartInfo.Verb = "Open";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
        }

        private void iAbout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            //DevExpress.Utils.About.frmAbout dlg = new DevExpress.Utils.About.frmAbout("Machine Eyes ");
            //dlg.ShowDialog();
        }

        string TextByCaption(string caption) {
            return caption.Replace("&", "");
        }
        public void LoadLists()
        {
            this.ArticleView = new Data_Article_Main_View();
            ArticleView.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleView.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ArticleView.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleView.Height = Screen.PrimaryScreen.WorkingArea.Height;


            this.ArticleTowelView = new Planning.Data_ArticleTowel_Main_View();
            ArticleTowelView.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleTowelView.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ArticleTowelView.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleTowelView.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.ArticleGreigeView = new Planning.Data_ArticleGreige_Main_View();
            ArticleGreigeView.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleGreigeView.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ArticleGreigeView.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleGreigeView.Height = Screen.PrimaryScreen.WorkingArea.Height;

            this.ArticleJacquardView = new Planning.Data_ArticleJacquard_Main_View();
            ArticleJacquardView.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleJacquardView.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ArticleJacquardView.Width = Screen.PrimaryScreen.WorkingArea.Width;
            ArticleJacquardView.Height = Screen.PrimaryScreen.WorkingArea.Height;


            this.LoomsList = new Data.Data_Looms();
            LoomsList.panelControl1.Width = Screen.PrimaryScreen.WorkingArea.Width;
            LoomsList.panelControl1.Height = Screen.PrimaryScreen.WorkingArea.Height;
            LoomsList.Width = Screen.PrimaryScreen.WorkingArea.Width;
            LoomsList.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.LoomsList.LoadLooms();
            this.ListsLoaded = true;
        }
        public void DisableMenu()
        {
            
            foreach (object c in this.ribbonControl1.Items)
            {
                string s = c.GetType().Name;
                if (c.GetType().Name == "BarButtonItem")
                {

                    BarButtonItem bbi = (BarButtonItem)c;
                    bbi.Enabled = false;
                    

                }

            }
            this.bbiLogin.Enabled = true;
            this.bbiExitMachineEyesERP.Enabled = true;
            this.bar_Progress.Enabled = true;
            this.bar_ServiceStatus.Enabled = true;
            this.bar_Shift.Enabled = true;
            this.Company.Enabled = true;
            this.bar_Shift.Enabled = true;
           
        }
       
        private void frmMain_Load(object sender, System.EventArgs e) {
            // TODO: This line of code loads data into the 'dailyShift_Summary1.RP_DailyShiftSummary' table. You can move, or remove it, as needed.
            
            //arMRUList = new MRUArrayList(pcAppMenuFileLabels, imageCollection3.Images[0], imageCollection3.Images[1]);
            //arMRUList.LabelClicked += new EventHandler(OnLabelClicked);
         
            InitMostRecentFiles(arMRUList);
            ribbonControl1.ForceInitialize();
            foreach(DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins) {
                BarCheckItem item = ribbonControl1.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(OnPaintStyleClick);
                iPaintStyle.ItemLinks.Add(item);
            }
            AutomaticLogin();
            //ribbonPage1.Visible = true;
           // barEditItem1.EditValue = (Bitmap)DevExpress.Utils.ResourceImageHelper.CreateImageFromResources("MachineEyes.online.gif", typeof(frmMain).Assembly);
        }
        private void AutomaticLogin()
        {
            Program.ss.ReadXML_MachineEyesConfigs();
            if (Settings.AutoLogin == true)
            {
                bool fvalue = Program.ss.Login(MachineEyes.Classes.Security.User.UserID,MachineEyes.Classes.Security.User.Password, "1");

                if (fvalue == true)
                {
                    Program.ss.StartPing();
                    Program.ss.ConfigureLooms();

                    if (Program.ss.ConfigurationLoaded == true)
                    {
                        meProgress.Status = progressStatus.SUCCEEDED;
                        Program.MainWindow.LoadForms();
                        Program.MainWindow.RefreshAccountingParams();
                        MachineEyes.Classes.Security.LoadGroups();
                        MachineEyes.Classes.Security.User.LoadSystemRights();
                        MachineEyes.Classes.Security.ImplementSecurity();
                        Program.ss.Machines.StartSyncLooms();
                        ShedView[Settings.DefaultShed] = new Dashboard_Shed();

                        ShedView[Settings.DefaultShed].Name = "ShedView" + Settings.DefaultShed.ToString();
                        ShedView[Settings.DefaultShed].Text = Program.ss.Machines.PresentationData.Sheds[Settings.DefaultShed].ShedName + " View";
                        ShedView[Settings.DefaultShed].Tag = Program.ss.Machines.PresentationData.Sheds[Settings.DefaultShed].ShedID;


                        ShedView[Settings.DefaultShed].MdiParent = this;
                        ShedView[Settings.DefaultShed].BringToFront();
                        ShedView[Settings.DefaultShed].Show();


                        //DigitalDisplay[Settings.DefaultShed] = new View.Dashboard_DigitalDisplay();

                        //DigitalDisplay[Settings.DefaultShed].Name = "DigitalView" + Settings.DefaultShed.ToString();
                        //DigitalDisplay[Settings.DefaultShed].Text = Program.ss.Machines.PresentationData.Sheds[Settings.DefaultShed].ShedName + " Digital View";
                        //DigitalDisplay[Settings.DefaultShed].Tag = Program.ss.Machines.PresentationData.Sheds[Settings.DefaultShed].ShedID;


                        //DigitalDisplay[Settings.DefaultShed].BringToFront();
                        //DigitalDisplay[Settings.DefaultShed].TopMost = true;
                        //DigitalDisplay[Settings.DefaultShed].Show();
                        AutoLogin_Succeeded = true;
                    }
                    else
                    {
                        meProgress.Status = progressStatus.FAILED;

                    }


                }
            }
            //string Role = "1";
            //WS.svc.Url = "http://localhost:1447/MachineEyesService.asmx";
            //bool fvalue = Program.ss.Login("0000000001", "valueadded", Role);
            
        }
        void OnPaintStyleClick(object sender, ItemClickEventArgs e) {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
        }

        private void iPaintStyle_Popup(object sender, System.EventArgs e) {
            foreach(BarItemLink link in iPaintStyle.ItemLinks)
                ((BarCheckItem)link.Item).Checked = link.Item.Caption == defaultLookAndFeel1.LookAndFeel.ActiveSkinName;
        }
        #region GalleryItemsChecked

        GalleryItem GetColorItemByColor(Color color, BaseGallery gallery) {
            foreach(GalleryItemGroup galleryGroup in gallery.Groups)
                foreach(GalleryItem item in galleryGroup.Items)
                    if(item.Caption == color.Name)
                        return item;
            return null;
        }
        GalleryItem GetFontItemByFont(string fontName, BaseGallery gallery) {
            foreach(GalleryItemGroup galleryGroup in gallery.Groups)
                foreach(GalleryItem item in galleryGroup.Items)
                    if(item.Caption == fontName)
                        return item;
            return null;
        }
        GalleryItem CurrentFontItem {
            get { return fCurrentFontItem; }
            set {
                if(fCurrentFontItem == value) return;
                if(fCurrentFontItem != null) fCurrentFontItem.Checked = false;
                fCurrentFontItem = value;
                if(fCurrentFontItem != null) {
                    fCurrentFontItem.Checked = true;
                    MakeFontVisible(fCurrentFontItem);
                }
            }
        }
        void MakeFontVisible(GalleryItem item) {
            gddFont.Gallery.MakeVisible(fCurrentFontItem);
            rgbiFont.Gallery.MakeVisible(fCurrentFontItem);
        }
        GalleryItem CurrentColorItem {
            get { return fCurrentColorItem; }
            set {
                if(fCurrentColorItem == value) return;
                if(fCurrentColorItem != null) fCurrentColorItem.Checked = false;
                fCurrentColorItem = value;
                if(fCurrentColorItem != null) {
                    fCurrentColorItem.Checked = true;
                    MakeColorVisible(fCurrentColorItem);
                }
            }
        }
        void MakeColorVisible(GalleryItem item) {
            gddFontColor.Gallery.MakeVisible(fCurrentColorItem);
            rgbiFontColor.Gallery.MakeVisible(fCurrentColorItem);
        }
        
        
        private void gddFontColor_Popup(object sender, System.EventArgs e) {
            MakeColorVisible(CurrentColorItem);
        }
        #endregion
        #region MostRecentFiles
        MRUArrayList arMRUList = null;
        string mrfFileName = "RibbonMRUFiles.ini";
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            Settings.Exit = true;

            Program.ss.Machines.debugTimer.Enabled = false;
            Program.ss.Machines.webServiceTimer.Enabled = false;
            try
            {

                foreach (DevExpress.XtraEditors.XtraForm form1 in Application.OpenForms)
                {
                    form1.Close();
                }

            }
            catch
            {
               
            }
            Application.Exit();
          
            
        }
        void InitMostRecentFiles(MRUArrayList arList) {
            string fileName = Application.StartupPath + "\\" + mrfFileName;
            if(!System.IO.File.Exists(fileName)) {
                AddToMostRecentFiles("Document1.rtf", arList);
                return;
            }
            System.IO.StreamReader sr = System.IO.File.OpenText(fileName);
            for(string s = sr.ReadLine(); s != null; s = sr.ReadLine())
                AddToMostRecentFiles(s, arList);
            sr.Close();
        }

        void SaveMostRecentFiles(MRUArrayList arList) {
            try {
                System.IO.StreamWriter sw = System.IO.File.CreateText(Application.StartupPath + "\\" + mrfFileName);
                for(int i = arList.Count - 1; i >= 0; i--) sw.WriteLine(string.Format("{0},{1}", arList[i].ToString(), arList.GetLabelChecked(arList[i].ToString())));
                sw.Close();
            }
            catch { }
        }

        void AddToMostRecentFiles(string name, MRUArrayList arList) {
            //arList.InsertElement(name);
        }
        void OnLabelClicked(object sender, EventArgs e) {
            pmAppMain.HidePopup();
            this.Refresh();
                    }
        class MRUArrayList : ArrayList {
            PanelControl container;
            int maxRecentFiles = 9;
            Image imgChecked, imgUncheked;
            public event EventHandler LabelClicked;
            public MRUArrayList(PanelControl cont, Image iChecked, Image iUnchecked)
                : base() {
                this.imgChecked = iChecked;
                this.imgUncheked = iUnchecked;
                this.container = cont;
            }
            public void InsertElement(object value) {
                string[] names = value.ToString().Split(',');
                string name = names[0];
                bool checkedLabel = false;
                if(names.Length > 1) checkedLabel = names[1].ToLower().Equals("true");
                foreach(AppMenuFileLabel ml in container.Controls) {
                    if(ml.Tag.Equals(name)) {
                        checkedLabel = ml.Checked;
                        base.Remove(name);
                        ml.LabelClick -= new EventHandler(OnLabelClick);
                        ml.Dispose();
                        break;
                    }
                }
                bool access = true;
                if(base.Count >= maxRecentFiles)
                    access = RemoveLastElement();
                if(access) {
                    base.Insert(0, name);
                    AppMenuFileLabel ml = new AppMenuFileLabel();
                    container.Controls.Add(ml);
                    ml.Tag = name;
                    ml.Text = GetFileName(name);
                    ml.Checked = checkedLabel;
                    ml.AutoHeight = true;
                    ml.Dock = DockStyle.Top;
                    ml.Image = imgUncheked;
                    ml.SelectedImage = imgChecked;
                    ml.LabelClick += new EventHandler(OnLabelClick);
                    SetElementsRange();
                }
            }
            void OnLabelClick(object sender, EventArgs e) {
                if(LabelClicked != null)
                    LabelClicked(((AppMenuFileLabel)sender).Tag.ToString(), e);
            }
            public bool RemoveLastElement() {
                for(int i = 0; i < container.Controls.Count; i++) {
                    AppMenuFileLabel ml = container.Controls[i] as AppMenuFileLabel;
                    if(!ml.Checked) {
                        base.Remove(ml.Tag);
                        ml.LabelClick -= new EventHandler(OnLabelClick);
                        ml.Dispose();
                        return true;
                    }
                }
                return false;
            }
            string GetFileName(object obj) {
                FileInfo fi = new FileInfo(obj.ToString());
                return fi.Name;
            }
            void SetElementsRange() {
                int i = 0;
                foreach(AppMenuFileLabel ml in container.Controls) {
                    ml.Caption = string.Format("&{0}", container.Controls.Count - i);
                    i++;
                }
            }
            public bool GetLabelChecked(string name) {
                foreach(AppMenuFileLabel ml in container.Controls) {
                    if(ml.Tag.Equals(name)) return ml.Checked;
                }
                return false;
            }
        }
        #endregion

        private void ribbonControl1_ApplicationButtonDoubleClick(object sender, EventArgs e) {
            if(ribbonControl1.RibbonStyle == RibbonControlStyle.Office2007)
                this.Close();
        }

        private void barEditItem1_ItemPress(object sender, ItemClickEventArgs e) {
            System.Diagnostics.Process.Start("http://www.infox.com.pk");
        }

        private void bbiLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin Login = new frmLogin();
            Login.ShowDialog();
        }
        private void bcigroup_ItemClick(object sender, ItemClickEventArgs e)
        {

            BarCheckItem bci = (BarCheckItem)e.Item;
            DialogResult dg = XtraMessageBox.Show("Are you sure to assign group " + bci.Caption + " to loom # " + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName + " ?", "Assign Group to Loom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg != DialogResult.Yes) return;
            try
            {
               // MachineService.loompersonalInfo personalinfo = new MachineService.loompersonalInfo();
               // personalinfo = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo;
                //personalinfo.GroupNumber = Convert.ToInt32(bci.Tag.ToString());
                string res=WS.svc.SETLOOM_GroupNumber(CurrentSelection.LoomIndex, bci.Tag.ToString());
                //string res = WS.svc.UpdateLoomPersonalInfo(CurrentSelection.LoomIndex, personalinfo);
                if (res != "**SUCCESS##")
                {
                    XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.GroupNumber = Convert.ToInt32(bci.Tag);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void MergeView_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int LayoutIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (LayoutIndex == -1) return;
            ShedMergedLayout[LayoutIndex].Show();

        }
        public void LoadMergedLayouts()
        {
            try
            {
                BarButtonItem[] bbi_ShedMergedViews = new BarButtonItem[0];
                DataSet ds = WS.svc.Get_DataSet("Select * from MT_Sheds_MergedLayout order by Layoutindex");
                if (ds == null) return;
                if (ds.Tables[0].Rows.Count <= 0) return;
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    Array.Resize(ref ShedMergedLayout, ShedMergedLayout.Length + 1);
                    ShedMergedLayout[x] = new Dashboard_ShedMergedView();
                    ShedMergedLayout[x].LayoutIndex = x;
                    ShedMergedLayout[x].Name = "Merged View ";
                    ShedMergedLayout[x].Text = ds.Tables[0].Rows[x]["LayoutName"].ToString();

                    string ShedsIndexes = "";
                    if (ds.Tables[0].Rows[x]["ShedID_0"].ToString() != "")
                    {
                        if (ShedsIndexes != "") ShedsIndexes += "," + ds.Tables[0].Rows[x]["ShedID_0"].ToString(); else ShedsIndexes = ds.Tables[0].Rows[x]["ShedID_0"].ToString();
                       
                    }
                    if (ds.Tables[0].Rows[x]["ShedID_1"].ToString() != "")
                    {
                        if (ShedsIndexes != "") ShedsIndexes += "," + ds.Tables[0].Rows[x]["ShedID_1"].ToString(); else ShedsIndexes = ds.Tables[0].Rows[x]["ShedID_1"].ToString();
                      
                    }
                    if (ds.Tables[0].Rows[x]["ShedID_2"].ToString() != "")
                    {
                        if (ShedsIndexes != "") ShedsIndexes += "," + ds.Tables[0].Rows[x]["ShedID_2"].ToString(); else ShedsIndexes = ds.Tables[0].Rows[x]["ShedID_2"].ToString();
                     
                    }
                    if (ds.Tables[0].Rows[x]["ShedID_3"].ToString() != "")
                    {
                        if (ShedsIndexes != "") ShedsIndexes += "," + ds.Tables[0].Rows[x]["ShedID_3"].ToString(); else ShedsIndexes = ds.Tables[0].Rows[x]["ShedID_3"].ToString();
                       
                    }
                    if (ds.Tables[0].Rows[x]["ShedID_4"].ToString() != "")
                    {
                        if (ShedsIndexes != "") ShedsIndexes += "," + ds.Tables[0].Rows[x]["ShedID_4"].ToString(); else ShedsIndexes = ds.Tables[0].Rows[x]["ShedID_4"].ToString();
                       
                    }


                    ShedMergedLayout[x].Tag = ShedsIndexes;



                    ShedMergedLayout[x].MdiParent = this;

                    Array.Resize(ref bbi_ShedMergedViews, bbi_ShedMergedViews.Length + 1);
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].Name = "bbi_ShedMergedViews_" + x.ToString();
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].Tag = x.ToString();
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].Caption = ds.Tables[0].Rows[x]["LayoutName"].ToString();
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].Description = "[Dashboard] Merged Shed Layout : " + ds.Tables[0].Rows[x]["LayoutName"].ToString();
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].Visibility = BarItemVisibility.Always;
                    this.ribbonControl1.Items.Add(bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1]);
                    this.bbi_LoomFilter.ItemLinks.Add(bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1]);
                    this.bbi_LoomFilter.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1]));
                    bbi_ShedMergedViews[bbi_ShedMergedViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MergeView_ItemClick);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:MergeLayouts()", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void LoadForms()
        {
            try
            {
                BarSubItem[] bbi_Sheds = new BarSubItem[0];
                this.Company.Caption = Program.ss.Machines.PresentationData.CPInfo.cpName;
                BarButtonItem[] bbi_DailySummary = new BarButtonItem[0];
                BarButtonItem[] bbi_TopWorse = new BarButtonItem[0];
                BarButtonItem[] bbi_MakeViews = new BarButtonItem[0];
                BarButtonItem[] bbi_WeaversMainViews = new BarButtonItem[0];
                BarButtonItem[] bbi_WeaversScrollViews = new BarButtonItem[0];
                BarButtonItem[] bbi_ShedSummaryViews = new BarButtonItem[0];
                BarButtonItem[] rpi_DailyEfficiencyReport = new BarButtonItem[0];
                BarButtonItem[] rpi_DailyEfficiencyReport_WeaverWise = new BarButtonItem[0];
                BarButtonItem[] bbi_DailyEfficiency_WeaversWages = new BarButtonItem[0];
                BarButtonItem[] rpi_WeeklyEfficiencyReport = new BarButtonItem[0];
                BarButtonItem[] bbi_MonthlyEfficiencyTabularReport = new BarButtonItem[0];
                BarButtonItem[] bbi_MonthlyProductionEfficiencyReport = new BarButtonItem[0];
                BarButtonItem[] bbi_MonthlyUnitsTabularReport = new BarButtonItem[0];
                BarButtonItem[] bbi_ProductionLossSummary = new BarButtonItem[0];
                BarButtonItem[] bbi_DailyEfficiencyWithProductionLossReport = new BarButtonItem[0];
                BarButtonItem[] bbi_DailyEfficiencyQualityWiseReport = new BarButtonItem[0];
                BarButtonItem[] bbi_DailyUnitsWeaverWise = new BarButtonItem[0];
                BarButtonItem[] bbi_DailyUnitsLoomWise = new BarButtonItem[0];
                BarButtonItem[] bbi_MonthlyUnitsWeaverWise = new BarButtonItem[0];
                BarButtonItem[] bbi_MonthlyUnitsQualityWise = new BarButtonItem[0];
                BarButtonItem[] bbi_CommingKnottings = new BarButtonItem[0];
                BarButtonItem[] bbi_ShedEfficiencyLog = new BarButtonItem[0];
                BarButtonItem[] bbi_ShedEfficiencyGraph = new BarButtonItem[0];

                BarButtonItem[] bbi_Years = new BarButtonItem[0];
                if (ShedView.Length <= 0)
                {
                    Array.Resize(ref ShedView, Program.ss.Machines.PresentationData.Sheds.Length);
                    Array.Resize(ref DigitalDisplay, Program.ss.Machines.PresentationData.Sheds.Length);
                    Array.Resize(ref bbi_Sheds, Program.ss.Machines.PresentationData.Sheds.Length);
                    Array.Resize(ref ShedClassicView, Program.ss.Machines.PresentationData.Sheds.Length);

                    Array.Resize(ref this.WeaversMainView, Program.ss.Machines.PresentationData.Sheds.Length);
                    Array.Resize(ref this.WeaversScrollView, Program.ss.Machines.PresentationData.Sheds.Length);
                    Array.Resize(ref this.ModelEff, Program.ss.Machines.PresentationData.Sheds.Length);
                    #region ShedCalcs
                    for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds.Length; x++)
                    {




                        bbi_Sheds[x] = new BarSubItem();

                        bbi_Sheds[x].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_Sheds[x].Caption = Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_Sheds[x].Visibility = BarItemVisibility.Always;

                        this.ribbonControl1.Items.Add(bbi_Sheds[x]);
                        this.bbi_Shed.ItemLinks.Add(bbi_Sheds[x]);
                        this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_Sheds[x]));

                        #region DailyShiftEfficiencyDailyUnits
                        Array.Resize(ref rpi_DailyEfficiencyReport, rpi_DailyEfficiencyReport.Length + 1);
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Caption = "Daily Shift Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Description = "[Weaving] Print Daily Shift Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Name = "rpiDailyEfficiency_" + rpi_DailyEfficiencyReport.Length + x;
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]);
                        this.rpi_ConstructionWise.ItemLinks.Add(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]);
                        this.rpi_ConstructionWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]));
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyEfficiencyReport_ItemClick);
                        #endregion


                       

                        #region DailyShiftEfficiency_WeaverWise
                        Array.Resize(ref rpi_DailyEfficiencyReport_WeaverWise, rpi_DailyEfficiencyReport_WeaverWise.Length + 1);
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Caption = "Daily Shift Summary  [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Description = "[Weaving] Print Daily Shift Summary Weaver Wise [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Name = "rpiDailyEfficiency_WeaverWise_" + rpi_DailyEfficiencyReport.Length + x;
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]);
                        this.rpi_WeaverWise.ItemLinks.Add(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]);
                        this.rpi_WeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]));
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyEfficiencyReport_WeaverWise_ItemClick);
                        #endregion

                        #region WeeklyShiftEfficiency
                        Array.Resize(ref rpi_WeeklyEfficiencyReport, rpi_WeeklyEfficiencyReport.Length + 1);
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Caption = "Weekly Shift Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Name = "rpiWeeklyEfficiency_" + rpi_WeeklyEfficiencyReport.Length + x;
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Description = "[Weaving] Print Weekly Shift Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]);
                        this.rpi_WeeklyEfficiencyLoomWise.ItemLinks.Add(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]);
                        this.rpi_WeeklyEfficiencyLoomWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]));
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_WeeklyEfficiencyReport_ItemClick);
                        #endregion

                        #region MonthlyEfficiencyTabular
                        Array.Resize(ref bbi_MonthlyEfficiencyTabularReport, bbi_MonthlyEfficiencyTabularReport.Length + 1);
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Caption = "Monthly Efficiency [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Name = "bbiMonthlyEfficiencyTabular_" + bbi_MonthlyEfficiencyTabularReport.Length + x;
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Description = "[Weaving] Print Monthly Efficiency Tabular Report [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]);
                        this.rpi_MonthlyEfficiencyTabular.ItemLinks.Add(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]);
                        this.rpi_MonthlyEfficiencyTabular.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]));
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MonthlyEfficiencyTabularReport_ItemClick);
                        #endregion

                        #region MonthlyProductionEfficiencyTabular
                        Array.Resize(ref bbi_MonthlyProductionEfficiencyReport, bbi_MonthlyProductionEfficiencyReport.Length + 1);
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].Caption = "Monthly Production Efficiency [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].Name = "bbiMonthlyProductionEfficiency_" + bbi_MonthlyProductionEfficiencyReport.Length + x;
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].Description = "[Weaving] Print Monthly Production Efficiency [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1]);
                        this.rpi_MonthlyProductionEfficiency.ItemLinks.Add(bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1]);
                        this.rpi_MonthlyProductionEfficiency.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1]));
                        bbi_MonthlyProductionEfficiencyReport[bbi_MonthlyProductionEfficiencyReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MonthlyProductionEfficiencyReport_ItemClick);
                        #endregion
                        #region MonthlyUnitsTabular
                        Array.Resize(ref bbi_MonthlyUnitsTabularReport, bbi_MonthlyUnitsTabularReport.Length + 1);
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].Caption = "Monthly Units [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].Name = "bbiMonthlyUnitsTabular_" + bbi_MonthlyUnitsTabularReport.Length + x;
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].Description = "[Weaving] Print Monthly Units Tabular Report [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1]);
                        this.rpi_MonthlyUnitsTabular.ItemLinks.Add(bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1]);
                        this.rpi_MonthlyUnitsTabular.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1]));
                        bbi_MonthlyUnitsTabularReport[bbi_MonthlyUnitsTabularReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MonthlyUnitsTabularReport_ItemClick);
                        #endregion

                        #region ProductionLossSummary
                        Array.Resize(ref bbi_ProductionLossSummary, bbi_ProductionLossSummary.Length + 1);
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Caption = "Production Loss Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Name = "rpiProductionLossSummary_" + rpi_WeeklyEfficiencyReport.Length + x;
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Description = "[Weaving] Print Production Loss Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]);
                        this.rpi_DailyProductionLoss.ItemLinks.Add(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]);
                        this.rpi_DailyProductionLoss.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]));
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_ProductionLossReport_ItemClick);
                        #endregion
                        #region DailyEfficiencyWithProductionLossReport
                        Array.Resize(ref bbi_DailyEfficiencyWithProductionLossReport, bbi_DailyEfficiencyWithProductionLossReport.Length + 1);
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Caption = "Daily Efficiency with Production Loss Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Name = "rpiDailyEfficiencyandProductionLossReport_" + bbi_DailyEfficiencyWithProductionLossReport.Length + x;
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Description = "[Weaving] Print Daily Efficiency with Prod. Loss Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]);
                        this.rpi_DailyEfficiencyWithProductionLoss.ItemLinks.Add(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]);
                        this.rpi_DailyEfficiencyWithProductionLoss.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]));
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyEfficiencyWithProductionLossReport_ItemClick);
                        #endregion

                        #region DailyEfficiencyQualityWiseReport
                        Array.Resize(ref bbi_DailyEfficiencyQualityWiseReport, bbi_DailyEfficiencyQualityWiseReport.Length + 1);
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Caption = "Daily Efficiency QualityWise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Name = "rpiDailyEfficiencyQualityWiseReport_" + bbi_DailyEfficiencyQualityWiseReport.Length + x;
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Description = "[Weaving] Print Daily Efficiency Quality Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]);
                        this.rpi_DailyEfficiencyQualityWise.ItemLinks.Add(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]);
                        this.rpi_DailyEfficiencyQualityWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]));
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyEfficiencyQualityWiseReport_ItemClick);
                        #endregion

                        #region DailyUnitsWeaverWiseReport
                        Array.Resize(ref bbi_DailyUnitsWeaverWise, bbi_DailyUnitsWeaverWise.Length + 1);
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Caption = "Daily Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Name = "rpiDailyUnitsWeaversWiseReport_" + bbi_DailyUnitsWeaverWise.Length + x;
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Description = "[Weaving] Print Daily Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]);
                        this.rpi_DailyUnitsWeaverWise.ItemLinks.Add(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]);
                        this.rpi_DailyUnitsWeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]));
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyUnitsWeaverWiseReport_ItemClick);
                        #endregion

                        #region DailyUnitsLoomWiseReport
                        Array.Resize(ref bbi_DailyUnitsLoomWise, bbi_DailyUnitsLoomWise.Length + 1);
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Caption = "Daily Loom Wise Efficiency [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Name = "rpiDailyUnitsLoomWiseReport_" + bbi_DailyUnitsLoomWise.Length + x;
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Description = "[Weaving] Print Daily Efficiency Loom Wise[ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]);
                        this.rpi_LoomWise.ItemLinks.Add(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]);
                        this.rpi_LoomWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]));
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_LoomWise_ItemClick);
                        #endregion

                        #region MonthlyUnitsWeaverWiseReport
                        Array.Resize(ref bbi_MonthlyUnitsWeaverWise, bbi_MonthlyUnitsWeaverWise.Length + 1);
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Caption = "Monthly Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Name = "rpiMonthlyUnitsWeaversWiseReport_" + bbi_MonthlyUnitsWeaverWise.Length + x;
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Description = "[Weaving] Print Monthly Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]);
                        this.rpi_MonthlyUnitsWeaverWise.ItemLinks.Add(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]);
                        this.rpi_MonthlyUnitsWeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]));
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MonthlyUnitsWeaverWiseReport_ItemClick);
                        #endregion

                        #region MonthlyUnitsQualityWiseReport
                        Array.Resize(ref bbi_MonthlyUnitsQualityWise, bbi_MonthlyUnitsQualityWise.Length + 1);
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Caption = "Monthly Units Quality Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Name = "rpiMonthlyUnitsQualityWiseReport_" + bbi_MonthlyUnitsQualityWise.Length + x;
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Description = "[Weaving] Print Monthly Units Quality Wise Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]);
                        this.rpi_MonthlyUnitsQualityWise.ItemLinks.Add(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]);
                        this.rpi_MonthlyUnitsQualityWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]));
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MonthlyUnitsQualityWiseReport_ItemClick);
                        #endregion
                        #region CommingKnottingsReport
                        Array.Resize(ref bbi_CommingKnottings, bbi_CommingKnottings.Length + 1);
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Caption = "Up-Comming Knottings Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Name = "rpiCommingKnottingsReport_" + rpi_WeeklyEfficiencyReport.Length + x;
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Description = "[Weaving] Print Up-Comming Knottings Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]);
                        this.rpi_CommingKnottings.ItemLinks.Add(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]);
                        this.rpi_CommingKnottings.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]));
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_CommingKnottings_ItemClick);
                        #endregion


                        #region DailySummary
                        Array.Resize(ref bbi_DailySummary, bbi_DailySummary.Length + 1);
                        bbi_DailySummary[bbi_DailySummary.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailySummary[bbi_DailySummary.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailySummary[bbi_DailySummary.Length - 1].Caption = "Daily Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailySummary[bbi_DailySummary.Length - 1].Name = "rpiDailySummary_Report_" + bbi_DailySummary.Length + x;
                        bbi_DailySummary[bbi_DailySummary.Length - 1].Description = "[Weaving] Daily Summary [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailySummary[bbi_DailySummary.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailySummary[bbi_DailySummary.Length - 1]);
                        this.rpi_DailySummary.ItemLinks.Add(bbi_DailySummary[bbi_DailySummary.Length - 1]);
                        this.rpi_DailySummary.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailySummary[bbi_DailySummary.Length - 1]));
                        bbi_DailySummary[bbi_DailySummary.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailySummary_ItemClick);
                        #endregion


                        #region TopWorse
                        Array.Resize(ref bbi_TopWorse, bbi_TopWorse.Length + 1);
                        bbi_TopWorse[bbi_TopWorse.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_TopWorse[bbi_TopWorse.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_TopWorse[bbi_TopWorse.Length - 1].Caption = "Top Worse Articles / Looms [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_TopWorse[bbi_TopWorse.Length - 1].Name = "rpiTopWorseArticlesLooms_Report_" + bbi_TopWorse.Length + x;
                        bbi_TopWorse[bbi_TopWorse.Length - 1].Description = "[Weaving] Top Worse Articles / Looms  [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_TopWorse[bbi_TopWorse.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_TopWorse[bbi_TopWorse.Length - 1]);
                        this.rpi_TopWorseArticlesLooms.ItemLinks.Add(bbi_TopWorse[bbi_TopWorse.Length - 1]);
                        this.rpi_TopWorseArticlesLooms.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_TopWorse[bbi_TopWorse.Length - 1]));
                        bbi_TopWorse[bbi_TopWorse.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_TopWorseArticlesLooms_ItemClick);
                        #endregion

                        #region DailyUnitsWeaverWiseAndDailyWagesReport
                        Array.Resize(ref bbi_DailyEfficiency_WeaversWages, bbi_DailyEfficiency_WeaversWages.Length + 1);
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Caption = "Efficiency and Weaver Wages [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Name = "rpiDailyUnitsWeaversWise_DailyWages_Report_" + bbi_DailyUnitsWeaverWise.Length + x;
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Description = "[Weaving] Print Daily Efficiency and  Weaver Wages Report [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]);
                        this.rpi_DailyEfficiencyWithDailyWage.ItemLinks.Add(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]);
                        this.rpi_DailyEfficiencyWithDailyWage.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]));
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_DailyEfficiencyWithDailyWage_ItemClick);
                        #endregion

                        #region ShedViews
                        Array.Resize(ref bbi_ShedSummaryViews, bbi_ShedSummaryViews.Length + 1);
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].Name = "bbiShedSummary_" + Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].Tag = "SID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]SID";
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].Caption = Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].Description = "[Dashboard] Shed Summary : " + Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1]);
                        bbi_Summary.ItemLinks.Add(bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1]);
                        this.bbi_Summary.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1]));
                        bbi_ShedSummaryViews[bbi_ShedSummaryViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ShedViews_ItemClick);
                        #endregion


                        #region ShedEfficiencyLog
                        Array.Resize(ref bbi_ShedEfficiencyLog, bbi_ShedEfficiencyLog.Length + 1);
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].Caption = "Shed Efficiency Log [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].Name = "bbi_ShedEfficiecyLog_" + bbi_ShedEfficiencyLog.Length + x;
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].Description = "[Weaving] Shed Efficiency Log [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1]);
                        this.rpi_ShedEfficiencyLog.ItemLinks.Add(bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1]);
                        this.rpi_ShedEfficiencyLog.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1]));
                        bbi_ShedEfficiencyLog[bbi_ShedEfficiencyLog.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_ShedEfficiencyLog_ItemClick);
                        #endregion

                        #region ShedEfficiencyGraph
                        Array.Resize(ref bbi_ShedEfficiencyGraph, bbi_ShedEfficiencyGraph.Length + 1);
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].Caption = "Shed Efficiency Graph [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].Name = "bbi_ShedEfficiecyGraph_" + bbi_ShedEfficiencyGraph.Length + x;
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].Description = "[Weaving] Shed Efficiency Graph [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1]);
                        this.rpi_ShedEfficiencyGraph.ItemLinks.Add(bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1]);
                        this.rpi_ShedEfficiencyGraph.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1]));
                        bbi_ShedEfficiencyGraph[bbi_ShedEfficiencyGraph.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_ShedEfficiencyGraph_ItemClick);
                        #endregion



                        #region MakeViews
                        Array.Resize(ref bbi_MakeViews, bbi_MakeViews.Length + 1);
                        bbi_MakeViews[bbi_MakeViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Tag = "SID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]SID";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Caption = "Shed View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Name = "bbiShedView_" + bbi_MakeViews.Length + x;
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Description = "[Dashboard] Shed View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        bbi_Sheds[x].ItemLinks.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MakeViews[bbi_MakeViews.Length - 1]));
                        bbi_MakeViews[bbi_MakeViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MakeViews_ItemClick);

                        Array.Resize(ref bbi_MakeViews, bbi_MakeViews.Length + 1);
                        bbi_MakeViews[bbi_MakeViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Tag = "DID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]DID";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Caption = "Digital View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Name = "bbiDigitalView_" + bbi_MakeViews.Length + x;
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Description = "[Dashboard] Digital View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        bbi_Sheds[x].ItemLinks.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MakeViews[bbi_MakeViews.Length - 1]));
                        bbi_MakeViews[bbi_MakeViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MakeViews_ItemClick);

                        Array.Resize(ref bbi_MakeViews, bbi_MakeViews.Length + 1);
                        bbi_MakeViews[bbi_MakeViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Name = "bbiClassicShedView_" + bbi_MakeViews.Length + x;
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Tag = "CID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]CID";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Caption = "Classic View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Description = "[Dashboard] Classic View [ " + Program.ss.Machines.PresentationData.Sheds[x].ShedName + " ]";
                        bbi_MakeViews[bbi_MakeViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        bbi_Sheds[x].ItemLinks.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                        this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MakeViews[bbi_MakeViews.Length - 1]));
                        bbi_MakeViews[bbi_MakeViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MakeViews_ItemClick);

                        for (int tx = 0; tx < Program.ss.Machines.PresentationData.Sheds[x].TypesOfLooms.Length; tx++)
                        {
                            Array.Resize(ref bbi_MakeViews, bbi_MakeViews.Length + 1);
                            Array.Resize(ref ShedMakeView, ShedMakeView.Length + 1);
                            bbi_MakeViews[bbi_MakeViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();

                            bbi_MakeViews[bbi_MakeViews.Length - 1].Name = "bbiMakeView_" + bbi_MakeViews.Length + tx;
                            bbi_MakeViews[bbi_MakeViews.Length - 1].Tag = "SSD[" + x.ToString() + "]SSD TTD[" + Program.ss.Machines.PresentationData.Sheds[x].TypesOfLooms[tx].TypeID + "]TTD";
                            bbi_MakeViews[bbi_MakeViews.Length - 1].Caption = Program.ss.Machines.PresentationData.Sheds[x].TypesOfLooms[tx].TypeName;
                            bbi_MakeViews[bbi_MakeViews.Length - 1].Description = "[Dashboard] Model Display : " + Program.ss.Machines.PresentationData.Sheds[x].TypesOfLooms[tx].TypeName;
                            bbi_MakeViews[bbi_MakeViews.Length - 1].Visibility = BarItemVisibility.Always;
                            this.ribbonControl1.Items.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                            bbi_Sheds[x].ItemLinks.Add(bbi_MakeViews[bbi_MakeViews.Length - 1]);
                            this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MakeViews[bbi_MakeViews.Length - 1]));
                            bbi_MakeViews[bbi_MakeViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MakeViews_ItemClick);

                        }

                        #endregion

                        #region WeaversMainViews
                        Array.Resize(ref bbi_WeaversMainViews, bbi_WeaversMainViews.Length + 1);
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].Name = "bbiWeaversMainView_" + bbi_WeaversMainViews.Length + x;
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].Tag = "SID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]SID";
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].Caption = Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].Description = "[Dashboard] Weavers View: " + Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1]);
                        this.bbi_WeaverMain.ItemLinks.Add(bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1]);
                        this.bbi_WeaverMain.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1]));
                        bbi_WeaversMainViews[bbi_WeaversMainViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_WeaversMainViews_ItemClick);
                        #endregion
                        #region WeaversScrollViews
                        Array.Resize(ref bbi_WeaversScrollViews, bbi_WeaversScrollViews.Length + 1);
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].Tag = "SID[" + Program.ss.Machines.PresentationData.Sheds[x].ShedID + "]SID";
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].Name = "bbiWeaversScrollView_" + bbi_WeaversScrollViews.Length + x;
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].Caption = Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].Description = "[Dashboard] Weavers Scroll View: " + Program.ss.Machines.PresentationData.Sheds[x].ShedName;
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1]);
                        this.bbi_WeaversScroll.ItemLinks.Add(bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1]);
                        this.bbi_WeaversScroll.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1]));
                        bbi_WeaversScrollViews[bbi_WeaversScrollViews.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_WeaversScrollViews_ItemClick);
                        #endregion



                    }
                    #endregion
                    LoadMergedLayouts();
                    #region MergCalcs
                    for (int x = 0; x < Program.ss.Machines.PresentationData.MergedSheds.Length; x++)
                    {




                        bbi_Sheds[x] = new BarSubItem();

                        bbi_Sheds[x].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_Sheds[x].Caption = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName;
                        bbi_Sheds[x].Visibility = BarItemVisibility.Always;

                        this.ribbonControl1.Items.Add(bbi_Sheds[x]);
                        this.bbi_Shed.ItemLinks.Add(bbi_Sheds[x]);
                        this.bbi_Shed.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_Sheds[x]));

                        #region DailyShiftEfficiencyDailyUnits
                        Array.Resize(ref rpi_DailyEfficiencyReport, rpi_DailyEfficiencyReport.Length + 1);
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Caption = "Daily Shift Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Description = "[Weaving] Print Daily Shift Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Name = "rpiDailyEfficiency_" + rpi_DailyEfficiencyReport.Length + x;
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]);
                        this.rpi_ConstructionWise.ItemLinks.Add(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]);
                        this.rpi_ConstructionWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1]));
                        rpi_DailyEfficiencyReport[rpi_DailyEfficiencyReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyEfficiencyReport_ItemClick);
                        #endregion

                        #region DailyShiftEfficiency_WeaverWise
                        Array.Resize(ref rpi_DailyEfficiencyReport_WeaverWise, rpi_DailyEfficiencyReport_WeaverWise.Length + 1);
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Caption = "Daily Shift Summary  [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Description = "[Weaving] Print Daily Shift Summary Weaver Wise [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Name = "rpiDailyEfficiency_WeaverWise_" + rpi_DailyEfficiencyReport.Length + x;
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]);
                        this.rpi_WeaverWise.ItemLinks.Add(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]);
                        this.rpi_WeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1]));
                        rpi_DailyEfficiencyReport_WeaverWise[rpi_DailyEfficiencyReport_WeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyEfficiencyReport_WeaverWise_ItemClick);
                        #endregion

                        #region WeeklyShiftEfficiency
                        Array.Resize(ref rpi_WeeklyEfficiencyReport, rpi_WeeklyEfficiencyReport.Length + 1);
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Caption = "Weekly Shift Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Name = "rpiWeeklyEfficiency_" + rpi_WeeklyEfficiencyReport.Length + x;
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Description = "[Weaving] Print Weekly Shift Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]);
                        this.rpi_WeeklyEfficiencyLoomWise.ItemLinks.Add(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]);
                        this.rpi_WeeklyEfficiencyLoomWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1]));
                        rpi_WeeklyEfficiencyReport[rpi_WeeklyEfficiencyReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedWeeklyEfficiencyReport_ItemClick);
                        #endregion

                        #region MonthlyEfficiencyTabular
                        Array.Resize(ref bbi_MonthlyEfficiencyTabularReport, bbi_MonthlyEfficiencyTabularReport.Length + 1);
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Caption = "Monthly Efficiency [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Name = "bbiMonthlyEfficiencyTabular_" + bbi_MonthlyEfficiencyTabularReport.Length + x;
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Description = "[Weaving] Print Monthly Efficiency Tabular Report [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]);
                        this.rpi_MonthlyEfficiencyTabular.ItemLinks.Add(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]);
                        this.rpi_MonthlyEfficiencyTabular.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1]));
                        bbi_MonthlyEfficiencyTabularReport[bbi_MonthlyEfficiencyTabularReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_MergedMonthlyEfficiencyTabularReport_ItemClick);
                        #endregion

                        #region ProductionLossSummary
                        Array.Resize(ref bbi_ProductionLossSummary, bbi_ProductionLossSummary.Length + 1);
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Caption = "Production Loss Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Name = "rpiProductionLossSummary_" + rpi_WeeklyEfficiencyReport.Length + x;
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Description = "[Weaving] Print Production Loss Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]);
                        this.rpi_DailyProductionLoss.ItemLinks.Add(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]);
                        this.rpi_DailyProductionLoss.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1]));
                        bbi_ProductionLossSummary[bbi_ProductionLossSummary.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedProductionLossReport_ItemClick);
                        #endregion
                        #region DailyEfficiencyWithProductionLossReport
                        Array.Resize(ref bbi_DailyEfficiencyWithProductionLossReport, bbi_DailyEfficiencyWithProductionLossReport.Length + 1);
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Caption = "Daily Efficiency with Production Loss Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Name = "rpiDailyEfficiencyandProductionLossReport_" + bbi_DailyEfficiencyWithProductionLossReport.Length + x;
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Description = "[Weaving] Print Daily Efficiency with Prod. Loss Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]);
                        this.rpi_DailyEfficiencyWithProductionLoss.ItemLinks.Add(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]);
                        this.rpi_DailyEfficiencyWithProductionLoss.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1]));
                        bbi_DailyEfficiencyWithProductionLossReport[bbi_DailyEfficiencyWithProductionLossReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyEfficiencyWithProductionLossReport_ItemClick);
                        #endregion

                        #region DailyEfficiencyQualityWiseReport
                        Array.Resize(ref bbi_DailyEfficiencyQualityWiseReport, bbi_DailyEfficiencyQualityWiseReport.Length + 1);
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Caption = "Daily Efficiency QualityWise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Name = "rpiDailyEfficiencyQualityWiseReport_" + bbi_DailyEfficiencyQualityWiseReport.Length + x;
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Description = "[Weaving] Print Daily Efficiency Quality Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]);
                        this.rpi_DailyEfficiencyQualityWise.ItemLinks.Add(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]);
                        this.rpi_DailyEfficiencyQualityWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1]));
                        bbi_DailyEfficiencyQualityWiseReport[bbi_DailyEfficiencyQualityWiseReport.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyEfficiencyQualityWiseReport_ItemClick);
                        #endregion

                        #region DailyUnitsWeaverWiseReport
                        Array.Resize(ref bbi_DailyUnitsWeaverWise, bbi_DailyUnitsWeaverWise.Length + 1);
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Caption = "Daily Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Name = "rpiDailyUnitsWeaversWiseReport_" + bbi_DailyUnitsWeaverWise.Length + x;
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Description = "[Weaving] Print Daily Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]);
                        this.rpi_DailyUnitsWeaverWise.ItemLinks.Add(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]);
                        this.rpi_DailyUnitsWeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1]));
                        bbi_DailyUnitsWeaverWise[bbi_DailyUnitsWeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyUnitsWeaverWiseReport_ItemClick);
                        #endregion

                        #region DailyUnitsLoomWiseReport
                        Array.Resize(ref bbi_DailyUnitsLoomWise, bbi_DailyUnitsLoomWise.Length + 1);
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Caption = "Daily Loom Wise Efficiency [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Name = "rpiDailyUnitsLoomWiseReport_" + bbi_DailyUnitsLoomWise.Length + x;
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Description = "[Weaving] Print Daily Efficiency Loom Wise[ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]);
                        this.rpi_LoomWise.ItemLinks.Add(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]);
                        this.rpi_LoomWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1]));
                        bbi_DailyUnitsLoomWise[bbi_DailyUnitsLoomWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedLoomWise_ItemClick);
                        #endregion

                        #region MonthlyUnitsWeaverWiseReport
                        Array.Resize(ref bbi_MonthlyUnitsWeaverWise, bbi_MonthlyUnitsWeaverWise.Length + 1);
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Caption = "Monthly Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Name = "rpiMonthlyUnitsWeaversWiseReport_" + bbi_MonthlyUnitsWeaverWise.Length + x;
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Description = "[Weaving] Print Monthly Units Weaver Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]);
                        this.rpi_MonthlyUnitsWeaverWise.ItemLinks.Add(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]);
                        this.rpi_MonthlyUnitsWeaverWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1]));
                        bbi_MonthlyUnitsWeaverWise[bbi_MonthlyUnitsWeaverWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedMonthlyUnitsWeaverWiseReport_ItemClick);
                        #endregion

                        #region MonthlyUnitsQualityWiseReport
                        Array.Resize(ref bbi_MonthlyUnitsQualityWise, bbi_MonthlyUnitsQualityWise.Length + 1);
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Caption = "Monthly Units Quality Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Name = "rpiMonthlyUnitsQualityWiseReport_" + bbi_MonthlyUnitsQualityWise.Length + x;
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Description = "[Weaving] Print Monthly Units Quality Wise Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]);
                        this.rpi_MonthlyUnitsQualityWise.ItemLinks.Add(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]);
                        this.rpi_MonthlyUnitsQualityWise.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1]));
                        bbi_MonthlyUnitsQualityWise[bbi_MonthlyUnitsQualityWise.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedMonthlyUnitsQualityWiseReport_ItemClick);
                        #endregion
                        #region CommingKnottingsReport
                        Array.Resize(ref bbi_CommingKnottings, bbi_CommingKnottings.Length + 1);
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Caption = "Up-Comming Knottings Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Name = "rpiCommingKnottingsReport_" + rpi_WeeklyEfficiencyReport.Length + x;
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Description = "[Weaving] Print Up-Comming Knottings Summary [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]);
                        this.rpi_CommingKnottings.ItemLinks.Add(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]);
                        this.rpi_CommingKnottings.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_CommingKnottings[bbi_CommingKnottings.Length - 1]));
                        bbi_CommingKnottings[bbi_CommingKnottings.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedCommingKnottings_ItemClick);
                        #endregion


                        #region DailyUnitsWeaverWiseAndDailyWagesReport
                        Array.Resize(ref bbi_DailyEfficiency_WeaversWages, bbi_DailyEfficiency_WeaversWages.Length + 1);
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Tag = Program.ss.Machines.PresentationData.MergedSheds[x].LayoutIndex.ToString();
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Caption = "Efficiency and Weaver Wages [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Name = "rpiDailyUnitsWeaversWise_DailyWages_Report_" + bbi_DailyUnitsWeaverWise.Length + x;
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Description = "[Weaving] Print Daily Efficiency and  Weaver Wages Report [ " + Program.ss.Machines.PresentationData.MergedSheds[x].LayoutName + " ]";
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]);
                        this.rpi_DailyEfficiencyWithDailyWage.ItemLinks.Add(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]);
                        this.rpi_DailyEfficiencyWithDailyWage.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1]));
                        bbi_DailyEfficiency_WeaversWages[bbi_DailyEfficiency_WeaversWages.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.rpi_MergedDailyEfficiencyWithDailyWage_ItemClick);
                        #endregion

                       


                     

                  



                    

                     


                    }
                    #endregion
                    for (int x = 0; x < MachineEyes.Classes.Accounting.FinancialYears.Length; x++)
                    {
                        Array.Resize(ref bbi_Years, bbi_Years.Length + 1);
                        bbi_Years[bbi_Years.Length - 1] = new DevExpress.XtraBars.BarButtonItem();
                        bbi_Years[bbi_Years.Length - 1].Tag = MachineEyes.Classes.Accounting.FinancialYears[x].fYear;
                        bbi_Years[bbi_Years.Length - 1].Name = "bbi_Years" + bbi_Years.Length + x;
                        bbi_Years[bbi_Years.Length - 1].Caption = MachineEyes.Classes.Accounting.FinancialYears[x].YearFormat;
                        bbi_Years[bbi_Years.Length - 1].Description = "[Accounts and Finance] Financial Year: " + MachineEyes.Classes.Accounting.FinancialYears[x].YearFormat;
                        bbi_Years[bbi_Years.Length - 1].Visibility = BarItemVisibility.Always;
                        this.ribbonControl1.Items.Add(bbi_Years[bbi_Years.Length - 1]);
                        this.barSubItem_FinancialYears.ItemLinks.Add(bbi_Years[bbi_Years.Length - 1]);
                        this.barSubItem_FinancialYears.LinksPersistInfo.Add(new DevExpress.XtraBars.LinkPersistInfo(bbi_Years[bbi_Years.Length - 1]));
                        bbi_Years[bbi_Years.Length - 1].ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Years_ItemClick);
                    }

                    DataSet ds = WS.svc.Get_DataSet("Select * from MT_LoomsGroups order by GroupNumber");

                    if (ds != null)
                    {
                        for (int gx = 0; gx < ds.Tables[0].Rows.Count; gx++)
                        {
                            BarCheckItem bcigroup = new BarCheckItem();


                            bcigroup.Caption = ds.Tables[0].Rows[gx]["GroupName"].ToString();
                            bcigroup.Tag = ds.Tables[0].Rows[gx]["GroupNumber"].ToString();//"SSD[" + ds.Tables[0].Rows[gx]["ShedID"].ToString() + "]SSD GPN[" + ds.Tables[0].Rows[gx]["GroupNumber"].ToString() + "]GPN";// ds.Tables[0].Rows[gx]["GroupNumber"].ToString();
                            bcigroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bcigroup_ItemClick);

                            this.bbiSubMenu_AssignToGroup.AddItem(bcigroup);

                        }
                        ds = null;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:LoadForms()", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       
        private void bbi_Years_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            string stag = bbiItem.Tag.ToString();
            int findex = MachineEyes.Classes.Accounting.Return_FinancialYear(stag);
            BarSubItem bsi = this.barSubItem_FinancialYears;

            //foreach (BarItemLink biLink in bsi.ItemLinks)
            //{
            //    if (biLink.Item.Tag != null)
            //    {
            //        if (biLink.Item.Name.Contains("bbi_Year") == true)
            //        {
            //            BarCheckItem bci = (BarCheckItem)biLink.Item;
            //            bci.Checked = false;

            //        }
                   
            //    }

            //}
            if (findex != -1)
            {
               
                this.FinancialYear.Caption = "Financial Year : " + MachineEyes.Classes.Accounting.RegAccounts.sFinancialPeriod.Year.ToString() + "-" + MachineEyes.Classes.Accounting.RegAccounts.eFinancialPeriod.Year.ToString();
                this.FinancialYear.Tag = MachineEyes.Classes.Accounting.FinancialYears[findex].fYear.ToString();
                MachineEyes.Classes.Accounting.RegAccounts.FinancialYear = MachineEyes.Classes.Accounting.FinancialYears[findex].fYear.ToString();
            }
           




        }
        private void bci_DashBoard_DesignMove_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (bci_DashBoard_DesignMove.Checked == true)
            {
                CurrentSelection.CurrentSelectionMode = SelectionMode.MoveMachine;
                ControlMover.Mode = ControlMover.vMode.Move;
            }
            else
            {
                ControlMover.Mode = ControlMover.vMode.View;
                CurrentSelection.CurrentSelectionMode = SelectionMode.NoSelection;
            }
        }

        private void bbi_DashBoard_DesignSave_ItemClick(object sender, ItemClickEventArgs e)
        {

           
            if (CurrentSelection.CurrentSelectionMode == SelectionMode.EfficiencyFont)
            {


                return;

            }
            
            
            for (int shedx = 0; shedx < Program.ss.Machines.PresentationData.Sheds.Length; shedx++)
            {
                if (ShedView[shedx] != null)
                {
                    for (int x = 0; x < ShedView[shedx].panelControl1.Controls.Count; x++)
                    {
                        Control contr = ShedView[shedx].panelControl1.Controls[x];
                        if (contr is dxLoom)
                        {
                            dxLoom Loom = (dxLoom)contr;

                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.x = contr.Left;
                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.y = contr.Top;

                            //string s=WS.svc.Save_LoomDrawing(Convert.ToInt16(Loom.LoomNumber.Tag.ToString()),loomDrawing); 

                        }
                    }
                }
                if (DigitalDisplay[shedx] != null)
                {
                    for (int x = 0; x < DigitalDisplay[shedx].scrollLooms.Controls.Count; x++)
                    {
                        Control contr = DigitalDisplay[shedx].scrollLooms.Controls[x];
                        if (contr is UserControls.dxLoomZ)
                        {
                            UserControls.dxLoomZ Loom = (UserControls.dxLoomZ)contr;

                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.DisplayX = contr.Left;
                            Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.DisplayY = contr.Top;

                            //string s=WS.svc.Save_LoomDrawing(Convert.ToInt16(Loom.LoomNumber.Tag.ToString()),loomDrawing); 

                        }
                    }
                }
                for (int typex = 0; typex < Program.ss.Machines.PresentationData.Sheds[shedx].TypesOfLooms.Length; typex++)
                {
                    if (ShedMakeView[typex] != null)
                    {
                        for (int x = 0; x < this.ShedMakeView[typex].panelControl1.Controls.Count; x++)
                        {
                            Control contr = this.ShedMakeView[typex].panelControl1.Controls[x];
                            if (contr is dxLoomY)
                            {
                                dxLoomY Loom = (dxLoomY)contr;

                                Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.DrawMakeX = contr.Left; ;
                                Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.DrawMakeY = contr.Top; ;


                            }
                        }
                    }

                }
            }
            for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
            {
                string s=WS.svc.Save_LoomDrawing(x,Program.ss.Machines.Looms[x].Drawing); 

            }
            XtraMessageBox.Show("Efficiency Board Updated Successfully!", "Success");
           
        }

        private void bbi_LockApp_ItemClick(object sender, ItemClickEventArgs e)
        {
           // WS.svc.Url = "http://175.110.153.248:3128/MachineEyesService.asmx";
           // WS.svc.Url = "http://192.168.1.17:3128/MachineEyesService.asmx";
        }
       
        private void Alert_Click(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            if (e.Info.Tag != null)
            {
                if (Convert.ToInt32(e.Info.Tag.ToString()) == (int)AlertTokens.StoreRequisitionRaised)
                {
                    Store.Store_RequestApproval Approval = new Store.Store_RequestApproval();
                    Approval.MdiParent = this;
                    Approval.Show();
                   
                }
                else if (Convert.ToInt32(e.Info.Tag.ToString()) == (int)AlertTokens.StoreRequisitionDiscuss)
                {
                    Store.Store_StoreRequisition Req = new Store.Store_StoreRequisition();
                    Req.MdiParent = this;
                    Req.Show();

                }
            }
           
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.AutoLogin == true && AutoLogin_Succeeded == false)
                AutomaticLogin();
            
            
            if (NewAlert != Program.ss.Machines.PresentationData.DesktopAlert)
            {
                NewAlert = Program.ss.Machines.PresentationData.DesktopAlert;
                string tag="";
                if (NewAlert.Caption != "" && NewAlert.Caption!=null)
                {
                   
                    tag = Convert.ToString(NewAlert.TokenID);
                    if (NewAlert.TokenID == (int)AlertTokens.StoreRequisitionRaised || NewAlert.TokenID == (int)AlertTokens.StoreRequisitionDiscuss)
                    {
                        Alert.AlertClick += new AlertClickEventHandler(Alert_Click);
                    }

                   
                        if (NewAlert.Type == MachineService.alertType.Information)
                        {
                            Alert.AppearanceText.TextOptions.WordWrap = WordWrap.Wrap;
                            Alert.AppearanceText.BackColor = Color.Green;
                            Alert.AppearanceText.ForeColor = Color.Black;
                            Alert.Show(this, NewAlert.Caption, NewAlert.info,NewAlert.info, imageCollection1.Images[290],tag);
                            try
                            {
                                if (Settings.AlertSound != "")
                                {
                                    System.Media.SoundPlayer simpleSound = new System.Media.SoundPlayer(@Settings.AlertSound);
                                    simpleSound.Play();
                                }
                            }
                            catch
                            {
                            }
                        }
                        else if (NewAlert.Type == MachineService.alertType.Warning)
                        {
                            Alert.AppearanceText.BackColor = Color.Yellow;
                            Alert.AppearanceText.ForeColor = Color.Green;
                            Alert.AppearanceText.TextOptions.WordWrap = WordWrap.Wrap;
                            Alert.Show(this, NewAlert.Caption, NewAlert.info, NewAlert.info, imageCollection1.Images[291], tag);
                        }
                        else if (NewAlert.Type == MachineService.alertType.Error)
                        {
                            Alert.AppearanceText.BackColor = Color.Black;
                            Alert.AppearanceText.ForeColor = Color.Red;
                            Alert.AppearanceText.TextOptions.WordWrap = WordWrap.Wrap;
                            Alert.Show(this, NewAlert.Caption, NewAlert.info, NewAlert.info, imageCollection1.Images[292], tag);
                        }
           
                  
                   

                }
                
            }
            if (meProgress.Status == progressStatus.INPROGRESS)
            {
                bar_Progress.Caption = "INIT : "+  meProgress.Progress.ToString() + "%";

            }
            else if (meProgress.Status == progressStatus.SYNCRONIZING)
            {
                bar_Progress.Caption = "SYNC : " + meProgress.Progress.ToString() + "%";
            }
            else
            {
                bar_Progress.Caption = "TASK : " + meProgress.Status.ToString();
            }
            this.bar_ServiceStatus.ImageIndex = Convert.ToInt16(WS.ServiceIcon);
            this.bar_ServiceStatus.Caption = WS.svcStatus.Status.ToString();
           
            if (preServiceStatus != WS.svcStatus.Status)
            {
                SuperToolTip stp = this.bar_ServiceStatus.SuperTip;
                stp.Items.Clear();
                stp.Items.Add(WS.svcStatus.LastErrMsg );
                stp.Items.Add("Connection: " + WS.svc.Url);
                stp.Items.AddTitle("Service Status: " + WS.svcStatus.Status.ToString());
                stp.Items.AddSeparator();
                preServiceStatus = WS.svcStatus.Status;
            }

            try
            {
                if (Program.ss.Machines.PresentationData.CurrentShift.WShift != null)
                {
                    if (this.bar_Shift.Tag.ToString() != Program.ss.Machines.PresentationData.CurrentShift.WShift)
                    {
                        this.bar_Shift.Caption = "Shift: " + Program.ss.Machines.PresentationData.CurrentShift.WShift;
                        this.bar_Shift.Tag = Program.ss.Machines.PresentationData.CurrentShift.WShift;
                    }
                }
               
            }
            catch 
            {
                
            }
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            

        }

        private void bar_ServiceStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Service Status " + WS.svcStatus.Status.ToString() + "\r\n Last Successfull Ping  " + WS.svcStatus.LastSuccessfullPingTime + "\r\n Last Error Encountered " + WS.svcStatus.LastErrMsg, "Service Info..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bbi_DashBoard_SizingView_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SizingView = new Dashboard_Sizing();
            //SizingView.MdiParent = this;
            //SizingView.Show();
            Dashboard_Category Cat_Board = new Dashboard_Category();
            Cat_Board.MdiParent = this;
            Cat_Board.Show();
        }

      


        private void bbi_Data_Article_Insertion_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Article Insertions", "insertionType", "PP_ArticleInsertionTypes");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_Selvage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
           ParameterReturn pr=  param.Display_Parameter(MousePosition, "Article Selvage", "ArticleSelvage", "PP_ArticleSelvages");
           if (pr.Status == ParameterStatus.Error)
           {
               XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void bbi_Data_Article_Weave_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Article Weaves", "Articleweave", "PP_Articleweaves");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_Main_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Data_Article_Main Article= new Data_Article_Main();
            //Article.MdiParent = this;
            //Article.Show();
        }

        private void bbi_Data_Employees_Dept_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void bbi_Data_Employees_Desig_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bbi_Data_Yarn_Brands_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bbi_Data_Warping_Main_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Warping Warping = new Data_Warping();
            Warping.MdiParent = this;
            Warping.Show();
        }

        private void bbi_Data_Warping_Beams_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bbi_Data_Warping_Machines_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Warping_Machine Warp_Machines = new Data_Warping_Machine();
            Warp_Machines.MdiParent = this;
            Warp_Machines.Show();
        }

        private void bbi_Data_Sizing_Beams_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Data_Beams Sizing_Beams = new Data_Beams();
            //Sizing_Beams.MdiParent = this;
            //Sizing_Beams.Show();
        }

        private void bbi_Data_Sizing_Main_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Sizing Sizing = new Data_Sizing();
            Sizing.MdiParent = this;
            Sizing.Show();
          
        }

        private void bbi_Data_Sizing_Chemicals_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Sizing_chemicals Sizing_Chemicals = new Data_Sizing_chemicals();
            Sizing_Chemicals.MdiParent = this;
            Sizing_Chemicals.Show();
        }

        private void bbi_Data_Knotting_Main_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Knottings Knottings = new Data_Knottings();
            Knottings.MdiParent = this;
            Knottings.Show();
        }

      

      

        private void bbi_Tools_EffColors_ItemClick(object sender, ItemClickEventArgs e)
        {   
            if(EfficiencyColors==null)
            EfficiencyColors = new Data_Tools_EfficiencyColors();
            EfficiencyColors.MdiParent = this;
            EfficiencyColors.Show();
           
        }

        private void rgbiFontColor_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            
            ColorConverter cr = new ColorConverter();
            if(EfficiencyColors!=null)
                if(CurrentSelection.CurrentEfficiencyColor!=null)
                    CurrentSelection.CurrentEfficiencyColor.ForeColor = (Color)cr.ConvertFromString(e.Item.Hint);
            ChangeClassicButtonColor((Color)cr.ConvertFromString(e.Item.Hint));
           
        }
        private void ChangeClassicButtonColor( Color c)
        {
            if (CurrentSelection.CurrentClassicButton != null)
            {
                if (CurrentSelection.CurrentClassicColorMode != "")
                {
                    if (CurrentSelection.CurrentClassicColorMode == "backcolor")
                    {
                        CurrentSelection.CurrentClassicButton.BackColor = c;
                    }
                    else if (CurrentSelection.CurrentClassicColorMode == "forecolor")
                    {
                        CurrentSelection.CurrentClassicButton.ForeColor = c;
                    }
                    else if (CurrentSelection.CurrentClassicColorMode == "bordercolor")
                    {
                        CurrentSelection.CurrentClassicButton.FlatAppearance.BorderColor = c;
                    }
                }
            }
        }
        
        private void gddFontColor_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            ColorConverter cr = new ColorConverter();
            if (EfficiencyColors != null)
                if(CurrentSelection.CurrentEfficiencyColor!=null)
                    CurrentSelection.CurrentEfficiencyColor.ForeColor = (Color)cr.ConvertFromString(e.Item.Hint);
            ChangeClassicButtonColor((Color)cr.ConvertFromString(e.Item.Hint));
        }

        private void bbi_Data_WarpYarn_Counts_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Fabric Selvage", "ArticleSelvage", "PP_ArticleSelvages");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void bbi_Data_Article_weftyarncount_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Weft Yarn Counts", "WeftYarnCount", "PP_weftyarncounts");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_warpyarntwist_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Warp Yarn Twist", "WarpYarnTwist", "PP_warpyarntwist");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_weftyarntwist_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Weft Yarn Twist", "WeftYarnTwist", "PP_weftyarntwist");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_warpyarnblend_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Warp Yarn Blends", "WarpYarnBlend", "PP_warpyarnblend");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_Article_weftyarnblend_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Weft Yarn Blends", "WeftYarnBlend", "PP_weftyarnblend");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_Data_AssignLoom_Beam_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Knottings KnottingInfo = new Data_Knottings();
            KnottingInfo.ShowDialog();
        }

        private void bbi_Tools_CalcTimeOnLastSinkFetched_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bbi_Debug_DebugMode.Down == true)
            {
                Program.ss.Machines.debugTimer.Enabled = true;
                Program.ss.Machines.PresentationData.PresentationSettings.DebugMode = true;
            }
            else
            {
                Program.ss.Machines.debugTimer.Enabled = false;
                Program.ss.Machines.PresentationData.PresentationSettings.DebugMode = false;
            }
        }

        

        private void bbi_Debug_WaitingTimeButton_EditValueChanged(object sender, EventArgs e)
        {
          
           try
           {
               Settings.DataWaitingSeconds = Convert.ToInt32(bbi_Debug_WaitingTimeButton.EditValue); 
           }catch (Exception ex)
           {
               XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

       

        private void CRP_DailyShiftSummary_Simple_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void bar_Shift_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Current Shift " + Program.ss.Machines.PresentationData.CurrentShift.WShift + "\r\nChanged At :   " + Program.ss.Machines.PresentationData.CurrentShift.ChangedAt.ToLongDateString() + "  " + Program.ss.Machines.PresentationData.CurrentShift.ChangedAt.ToLongTimeString() + "\r\n Shift Started At:  " + Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.ToLongDateString() + " " +  Program.ss.Machines.PresentationData.CurrentShift.ShiftStartDate.ToLongTimeString(), "Shift Info..", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barAssign_Mechanical_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barAssign_Mechanical_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (barAssign_Mechanical.Checked == true)
            {
                DialogResult dg = XtraMessageBox.Show("Are you sure to assign stop cause as mechanical reason?", "Assign Long Stop Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes) return;
            AssignCause:    string wres = WS.svc.Update_LoomsLongCause(CurrentSelection.LoomIndex, (int)Cause.Mechanical);
                if (wres != "**SUCCESS##")
                {
                    dg=XtraMessageBox.Show(wres, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                     if (dg == DialogResult.Retry) goto AssignCause;
                }
                else
                   Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause=(int)Cause.Mechanical;
               

            }
        }

        private void barAssign_Electrical_ItemClick(object sender, ItemClickEventArgs e)
        {
             if (barAssign_Electrical.Checked == true)
            {
                DialogResult dg = XtraMessageBox.Show("Are you sure to assign stop cause as electrical reason?", "Assign Long Stop Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes) return;
            AssignCause:    string wres = WS.svc.Update_LoomsLongCause(CurrentSelection.LoomIndex, (int)Cause.Electrical);
                if (wres != "**SUCCESS##")
                {
                    dg=XtraMessageBox.Show(wres, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dg == DialogResult.Retry) goto AssignCause;
                }
                 else
                   Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause=(int)Cause.Electrical;
             }
        }

        private void barAssign_Knotting_ItemClick(object sender, ItemClickEventArgs e)
        {
         if (barAssign_Knotting.Checked == true)
            {
                DialogResult dg = XtraMessageBox.Show("Are you sure to assign stop cause as Knotting reason?", "Assign Long Stop Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes) return;
            AssignCause:    string wres = WS.svc.Update_LoomsLongCause(CurrentSelection.LoomIndex, (int)Cause.Knotting);
                if (wres != "**SUCCESS##")
                {
                    dg=XtraMessageBox.Show(wres, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dg == DialogResult.Retry) goto AssignCause;
                } else
                   Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause=(int)Cause.Knotting;
             }
        }

        private void barAssign_ArticleChange_ItemClick(object sender, ItemClickEventArgs e)
        {
         if (barAssign_ArticleChange.Checked == true)
            {
                DialogResult dg = XtraMessageBox.Show("Are you sure to assign stop cause as Article Change reason?", "Assign Long Stop Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes) return;
            AssignCause:    string wres = WS.svc.Update_LoomsLongCause(CurrentSelection.LoomIndex, (int)Cause.ArticleChange);
                if (wres != "**SUCCESS##")
                {
                    dg=XtraMessageBox.Show(wres, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dg == DialogResult.Retry) goto AssignCause;
                } else
                   Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause=(int)Cause.ArticleChange;
             }
        }

        private void barAssign_OtherStop_ItemClick(object sender, ItemClickEventArgs e)
        {
         if (barAssign_OtherStop.Checked == true)
            {
                DialogResult dg = XtraMessageBox.Show("Are you sure to assign stop cause as Other reason?", "Assign Long Stop Cause", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dg != DialogResult.Yes) return;
            AssignCause:    string wres = WS.svc.Update_LoomsLongCause(CurrentSelection.LoomIndex, (int)Cause.OtherLong);
                if (wres != "**SUCCESS##")
                {
                    dg=XtraMessageBox.Show(wres, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dg == DialogResult.Retry) goto AssignCause;
                } else
                   Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.Current_Cause=(int)Cause.OtherLong;
             }
        }

        private void bbi_AssignLoomsToWeavers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Assign_Weaver AssignLoomsToWeavers = new Data_Assign_Weaver();
            AssignLoomsToWeavers.MdiParent = this;
            AssignLoomsToWeavers.Show();

        }

        private void bbiSubMenu_AssignToGroup_Popup(object sender, EventArgs e)
        {
            BarSubItem bsi = (BarSubItem)sender;
            
            foreach (BarItemLink biLink in bsi.ItemLinks)
            {
                if (biLink.Item.Tag != null)
                {
                    if (biLink.Item.Tag.ToString() == Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.GroupNumber.ToString())
                    {
                        BarCheckItem bci = (BarCheckItem)biLink.Item;
                        bci.Checked = true;

                    }
                    else
                    {
                        BarCheckItem bci = (BarCheckItem)biLink.Item;
                        bci.Checked = false;
                    }

                }

            }
            

        }

      

        private void bbi_DashBoard_DesignMoveGroup_CheckedChanged(object sender, ItemClickEventArgs e)
        {

            if (bbi_DashBoard_DesignMoveGroup.Checked == true)
                ControlMover.Mode = ControlMover.vMode.Move;
            else
                ControlMover.Mode = ControlMover.vMode.View;
        }

        private void bbi_Dashboard_DesignSaveGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            int Groupindex = 0;
            for (int wMV = 0; wMV < WeaversMainView.Length; wMV++)
            {
                if(WeaversMainView[wMV]!=null)
                {
                    if( WeaversMainView[wMV].panelControl1!=null)
                    {
                        try
                        {
                for (int x = 0; x < WeaversMainView[wMV].panelControl1.Controls.Count; x++)
                {
                    Control contr = WeaversMainView[wMV].panelControl1.Controls[x];
                    if (contr is dxLoomGroup)
                    {
                        dxLoomGroup group = (dxLoomGroup)contr;
                        Groupindex = Program.ss.Machines.PresentationData.Sheds[WeaversMainView[wMV].ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(group.Tag.ToString()));
                        StartUpdateGroupPostion: string webres = WS.svc.Execute_Query("update MT_LoomsGroups set x=" + group.Left.ToString() + ",y=" + group.Top.ToString() + " where GroupNumber=" + group.Tag.ToString() + "");
                        if (webres == "**SUCCESS##")
                        {
                            Program.ss.Machines.PresentationData.Sheds[WeaversMainView[wMV].ShedIndex].LoomGroups[Groupindex].x = group.Left;
                            Program.ss.Machines.PresentationData.Sheds[WeaversMainView[wMV].ShedIndex].LoomGroups[Groupindex].y = group.Top;
                        }
                        else
                        {
                            DialogResult dg = XtraMessageBox.Show(webres, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                            if (dg == DialogResult.Abort) return;
                            if (dg == DialogResult.Retry) goto StartUpdateGroupPostion;

                        }


                    }

                }
                    }catch(Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
            }
            }
            XtraMessageBox.Show("Weavers Efficiency Board Updated Successfully!", "Success");
        }

        private void bbi_ShedGraph_View_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (ShedGraphView == null)
           //     ShedGraphView = new Dashboard_ShedEfficiencyGraph();
            Dashboard_ShedEfficiencyGraph shd = new Dashboard_ShedEfficiencyGraph();
            
            shd.MdiParent = this;
            shd.Show();
            shd.BringToFront();
        }

     

        private void bbi_AutomaticUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
           
          
            //MachineEyes.Data.AutoUpdate AutomaticUpdate = new Data.AutoUpdate();
            //AutomaticUpdate.Show();
           
        }

        private void bbi_MakeView1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        
       
        private void rpi_DailyEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
           // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {
                
                    XR_DailyShiftSummaryAB_Micro(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_DailyShiftSummaryABC_Micro(ShedIndex);

         
        }
        private void rpi_MergedDailyEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_MergedDailyShiftSummaryAB_Micro(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_MergedDailyShiftSummaryABC_Micro(ShedIndex);


        }
        private void rpi_LoomWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_DailyEfficiencyLoomWise_AB(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_DailyEfficiencyLoomWise_ABC(ShedIndex);


        }
        private void rpi_MergedLoomWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_MergedDailyEfficiencyLoomWise_AB(mShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_MergedDailyEfficiencyLoomWise_ABC(mShedIndex);


        }
        private void XR_DailyEfficiencyLoomWise_AB(int ShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            
            Reports.Efficiency_Daily_LoomWise_AB AB = new Reports.Efficiency_Daily_LoomWise_AB();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by Convert(numeric(9),LoomName),ArticleShortName";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_MergedDailyEfficiencyLoomWise_AB(int MergedShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Efficiency_Daily_LoomWise_AB AB = new Reports.Efficiency_Daily_LoomWise_AB();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) order by Convert(numeric(9),LoomName),ArticleShortName";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_DailyEfficiencyLoomWise_ABC(int ShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Efficiency_Daily_LoomWise_ABC AB = new Reports.Efficiency_Daily_LoomWise_ABC();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by Convert(numeric(9),LoomName),ArticleShortName";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
               

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(C_Units) as C_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters,Sum(C_Meters) as C_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_MergedDailyEfficiencyLoomWise_ABC(int MergedShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Efficiency_Daily_LoomWise_ABC AB = new Reports.Efficiency_Daily_LoomWise_ABC();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) order by Convert(numeric(9),LoomName),ArticleShortName";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;


                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(C_Units) as C_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters,Sum(C_Meters) as C_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void rpi_DailyUnitsWeaverWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_DailyUnitsWeaverWise_ABC(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_DailyUnitsWeaverWise_ABC(ShedIndex);


        }
        private void rpi_MergedDailyUnitsWeaverWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_MergedDailyUnitsWeaverWise_ABC(mShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_MergedDailyUnitsWeaverWise_ABC(mShedIndex);


        }
        private void rpi_DailyEfficiencyWithDailyWage_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_DailyShiftSummaryAB_WeaverWise_DailyWages(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_DailyShiftSummaryAB_WeaverWise_DailyWages(ShedIndex);


        }
        private void rpi_MergedDailyEfficiencyWithDailyWage_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {

                XR_MergedDailyShiftSummaryAB_WeaverWise_DailyWages(mShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_MergedDailyShiftSummaryAB_WeaverWise_DailyWages(mShedIndex);


        }
        private void rpi_ShedEfficiencyGraph_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            Data.Param_TwoDateTimes DateForm = new Data.Param_TwoDateTimes();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_ShedGraph ABC = new Reports.Efficiency_ShedGraph();
            ABC.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy hh:mm tt");
            ABC.repH_To.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy hh:mm tt");
            string dsstring = "SELECT     LogTime,ShedEfficiency from MT_Sheds_EfficiencyLog  where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and LogTime>='" + SelectedDate.Date.ToString("s") + "' and LogTime<='" + SelectedDate.upTo.ToString("s") + "' ";
            DataSet ds = WS.svc.Get_DataSet(dsstring);



            ABC.BeginInit();
            if (ds != null)
                ABC.DataSource = ds.Tables[0];
            
            ABC.xrChart1.Series[0].ArgumentDataMember = "LogTime";
            ABC.xrChart1.Series[0].ValueDataMembers[0] = "ShedEfficiency";
            ABC.DataSource = ds.Tables[0];
            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void rpi_ShedEfficiencyLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;

            Data.Param_TwoDateTimes DateForm = new Data.Param_TwoDateTimes();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_ShedEfficiencyLog ABC = new Reports.Efficiency_ShedEfficiencyLog();

            ABC.ShedName.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy hh:mm tt");
            ABC.repH_To.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy hh:mm tt");
            string dsstring = "SELECT     * from MT_Sheds_EfficiencyLog  where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and LogTime>='"+SelectedDate.Date.ToString("s")+"' and LogTime<='"+SelectedDate.upTo.ToString("s")+"' ";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
           
            ABC.BeginInit();
            if(ds!=null)
            ABC.DataSource = ds.Tables[0];

            ABC.EndInit();
            ABC.ShowPreview();

        }
        private void rpi_MonthlyUnitsWeaverWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;

            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            LDS.ReportingParameters.xu_MonthlyUnits yru_itemledger = new LDS.ReportingParameters.xu_MonthlyUnits();
            yru_itemledger.Shed.Tag = ShedIndex.ToString();
            yru_itemledger.Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
            // if (Settings.CurrentSettings.NoofShifts == 2)
            //if (Settings.CurrentSettings.NoofShifts == 2)
            //{

            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);
            //}
            //else if (Settings.CurrentSettings.NoofShifts == 3)
            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);


        }
        private void rpi_MergedMonthlyUnitsWeaverWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;

            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            LDS.ReportingParameters.xu_MonthlyUnits yru_itemledger = new LDS.ReportingParameters.xu_MonthlyUnits();
            yru_itemledger.Shed.Tag = mShedIndex.ToString();
            yru_itemledger.Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[mShedIndex].ShedIds;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
           


        }
        private void rpi_MonthlyUnitsQualityWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;

            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            LDS.ReportingParameters.xu_MonthlyUnitsQualityWise yru_itemledger = new LDS.ReportingParameters.xu_MonthlyUnitsQualityWise();
            yru_itemledger.Shed.Tag = ShedIndex.ToString();
            yru_itemledger.Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
            // if (Settings.CurrentSettings.NoofShifts == 2)
            //if (Settings.CurrentSettings.NoofShifts == 2)
            //{

            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);
            //}
            //else if (Settings.CurrentSettings.NoofShifts == 3)
            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);


        }
        private void rpi_MergedMonthlyUnitsQualityWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;

            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            LDS.ReportingParameters.xu_MonthlyUnitsQualityWise yru_itemledger = new LDS.ReportingParameters.xu_MonthlyUnitsQualityWise();
            yru_itemledger.Shed.Tag = mShedIndex.ToString();
            yru_itemledger.Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[mShedIndex].LayoutName;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
            // if (Settings.CurrentSettings.NoofShifts == 2)
            //if (Settings.CurrentSettings.NoofShifts == 2)
            //{

            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);
            //}
            //else if (Settings.CurrentSettings.NoofShifts == 3)
            //    XR_MontlyUnitsWeaverWise_ABC(ShedIndex);


        }
        private void rpi_DailyEfficiencyReport_WeaverWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {
                XR_DailyShiftSummaryAB_WeaverWise(ShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
            {
                XR_DailyShiftSummaryABC_WeaverWise(ShedIndex);
            }


        }
        private void rpi_MergedDailyEfficiencyReport_WeaverWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            if (Settings.CurrentSettings.NoofShifts == 2)
            {
               // XR_MergedDailyShiftSummaryAB_WeaverWise(mShedIndex);
            }
            else if (Settings.CurrentSettings.NoofShifts == 3)
            {
                XR_MergedDailyShiftSummaryABC_WeaverWise(mShedIndex);
            }


        }
        private void bbi_MonthlyEfficiencyTabularReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MonthlyShiftSummaryABC_LoomWise(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);
        }
        private void bbi_MonthlyProductionEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MonthlyProductionEfficiencyABC_LoomWise(ShedIndex);
            //XR_MonthlyShiftSummaryABC_LoomWise(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);
        }
        private void bbi_MonthlyUnitsTabularReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MonthlyShiftSummaryABC_Units(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);
        }
        private void bbi_MergedMonthlyEfficiencyTabularReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MergedMonthlyShiftSummaryABC_LoomWise(mShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);
        }
        private void rpi_WeeklyEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_WeeklyShiftSummaryABC_LoomWise(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_MergedWeeklyEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MergedWeeklyShiftSummaryABC_LoomWise(mShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_ProductionLossReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_DailyProductionLossABC(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_MergedProductionLossReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MergedDailyProductionLossABC(mShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }


        private void rpi_DailyEfficiencyWithProductionLossReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_DailyEfficiencyWithProductionLossABC(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_DailySummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            DailyReports_DailyLoomSummary(ShedIndex);
        }



         private void rpi_TopWorseArticlesLooms_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            LDS.ReportingParameters.xu_TopWorseArticles summary = new LDS.ReportingParameters.xu_TopWorseArticles();
            summary.Shed.Tag = ShedIndex.ToString();
            summary.Shed.Text = Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ShedIndex.ToString())].ShedName;
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
            
        }


        private void rpi_MergedDailyEfficiencyWithProductionLossReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MergedDailyEfficiencyWithProductionLossABC(mShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_DailyEfficiencyQualityWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
             if (Settings.CurrentSettings.NoofShifts == 2)
            XR_DailyShiftSummaryAB_QualityWise(ShedIndex);
             else if (Settings.CurrentSettings.NoofShifts == 3)
            XR_DailyShiftSummaryABC_QualityWise(ShedIndex);


        }
        private void rpi_MergedDailyEfficiencyQualityWiseReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            if (Settings.CurrentSettings.NoofShifts == 2)
                XR_MergedDailyShiftSummaryAB_QualityWise(mShedIndex);
            else if (Settings.CurrentSettings.NoofShifts == 3)
                XR_MergedDailyShiftSummaryABC_QualityWise(mShedIndex);


        }
        private void rpi_CommingKnottings_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int ShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(bbiItem.Tag.ToString());
            if (ShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_CommingKnottings(ShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        private void rpi_MergedCommingKnottings_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            int mShedIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_MergedSheds(Convert.ToInt32(bbiItem.Tag.ToString()));
            if (mShedIndex == -1) return;
            // if (Settings.CurrentSettings.NoofShifts == 2)
            XR_MergedCommingKnottings(mShedIndex);
            // else if (Settings.CurrentSettings.NoofShifts == 3)
            //    DailyShiftSummaryABC(ShedIndex);


        }
        //private void XR_WeeklySHiftSummaryAB(int ShedIndex)
        //{
        //    Param_Date DateForm = new Param_Date();
        //    DateForm.ShowDialog();
        //    if (SelectedDate.isCanceled == true) return;

        //    Reports.Efficiency_Weekly_AB AB = new Reports.Efficiency_Weekly_AB();
        //    Reports.HighestWeftBreakages Hf = new Reports.HighestWeftBreakages();
        //    Reports.ColorIndications CI = new Reports.ColorIndications();
        //    Reports.Efficiency_Weekly_AB_Sub Ist=new Reports.Efficiency_Weekly_AB_Sub();

        //    DataSet ds1 = WS.svc.Get_DataSet("Select * from SS_ColorSettings where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
        //    CI.BeginInit();
        //    CI.DataSource = ds1;
        //    CI.EndInit();
        //    // DataSet dsW = WS.svc.Get_DataSet("SELECT     top(5) * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by A_WarpStops DESC");




        //    //AB.ShedIndex = ShedIndex;
        //    AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
        //    AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
        //    AB.repH_Dated_From.Text = SelectedDate.Date.ToLongDateString();
        //    TimeSpan ts=new TimeSpan(7,0,0,0);
        //    DateTime dUpto = SelectedDate.Date.Add(ts);
        //    AB.repH_Dated_Upto.Text = dUpto.ToLongDateString();
        //    string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by loomid";
        //    DataSet ds = WS.svc.Get_DataSet(dsstring);

          

            
         
        //   // Hf.BeginInit();
        //   // Hf.DataSource = dtTop5_Weft;
        //   // Hf.EndInit();
        //    AB.BeginInit();
            
        //   // AB.Sub_HighestWeftBreakages.ReportSource = Hf;
        //    AB.DataSource = ds;
        //    AB.EndInit();
        //    AB.ShowPreview();
        //}
        private void XR_DailyShiftSummaryAB_Micro(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_AB_Micro AB = new Reports.Efficiency_Daily_AB_Micro();

            Reports.HighestWeftBreakages Hf = new Reports.HighestWeftBreakages();
            Reports.ColorIndications CI = new Reports.ColorIndications();
            Reports.HighestWarpBreakages Hw = new Reports.HighestWarpBreakages();
          
                DataSet ds1 = WS.svc.Get_DataSet("Select * from SS_ColorSettings where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
                CI.BeginInit();
                CI.DataSource = ds1;
                CI.EndInit();
           
            // DataSet dsW = WS.svc.Get_DataSet("SELECT     top(5) * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by A_WarpStops DESC");




            AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by ArticleName,Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;
            //dv_Main.Sort = "  ArticleName,LoomName";
            DataTable dAB = dv_Main.ToTable();
           
                DataView dv_Warp = ds.Tables[0].DefaultView;
                dv_Warp.Sort = " T_WarpETime DESC";
                DataTable dtTopAll_Warp = dv_Warp.ToTable();
                DataTable dtTop5_Warp = dtTopAll_Warp.Clone();
                for (int i = 0; i < 5; i++)
                    dtTop5_Warp.ImportRow(dtTopAll_Warp.Rows[i]);
                Hw.BeginInit();
                Hw.DataSource = dtTop5_Warp;
                Hw.EndInit();
               
                DataView dv_Weft = ds.Tables[0].DefaultView;
                dv_Weft.Sort = " T_WeftETime DESC";
                DataTable dtTopAll_Weft = dv_Weft.ToTable();
                DataTable dtTop5_Weft = dtTopAll_Weft.Clone();
                for (int i = 0; i < 5; i++)
                    dtTop5_Weft.ImportRow(dtTopAll_Weft.Rows[i]);
                Hw.BeginInit();
                Hw.DataSource = dtTop5_Warp;
                Hw.EndInit();
                Hf.BeginInit();
                Hf.DataSource = dtTop5_Weft;
                Hf.EndInit();
          


            AB.BeginInit();
            
          
                AB.Sub_HighestWarpBreakages.ReportSource = Hw;
                AB.Sub_HighestWeftBreakages.ReportSource = Hf;
          
            AB.DataSource = dAB;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryAB_Micro(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_AB_Micro AB = new Reports.Efficiency_Daily_AB_Micro();

            Reports.HighestWeftBreakages Hf = new Reports.HighestWeftBreakages();
            Reports.ColorIndications CI = new Reports.ColorIndications();
            Reports.HighestWarpBreakages Hw = new Reports.HighestWarpBreakages();
          
                DataSet ds1 = WS.svc.Get_DataSet("Select * from SS_ColorSettings where ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")");
                CI.BeginInit();
                CI.DataSource = ds1;
                CI.EndInit();
          
            // DataSet dsW = WS.svc.Get_DataSet("SELECT     top(5) * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by A_WarpStops DESC");




            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) order by ArticleName,Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;
            //dv_Main.Sort = "  ArticleName,LoomName";
            DataTable dAB = dv_Main.ToTable();
           
                DataView dv_Warp = ds.Tables[0].DefaultView;
                dv_Warp.Sort = " T_WarpETime DESC";
                DataTable dtTopAll_Warp = dv_Warp.ToTable();
                DataTable dtTop5_Warp = dtTopAll_Warp.Clone();
                for (int i = 0; i < 5; i++)
                    dtTop5_Warp.ImportRow(dtTopAll_Warp.Rows[i]);
                Hw.BeginInit();
                Hw.DataSource = dtTop5_Warp;
                Hw.EndInit();

                DataView dv_Weft = ds.Tables[0].DefaultView;
                dv_Weft.Sort = " T_WeftETime DESC";
                DataTable dtTopAll_Weft = dv_Weft.ToTable();
                DataTable dtTop5_Weft = dtTopAll_Weft.Clone();
                for (int i = 0; i < 5; i++)
                    dtTop5_Weft.ImportRow(dtTopAll_Weft.Rows[i]);
                Hw.BeginInit();
                Hw.DataSource = dtTop5_Warp;
                Hw.EndInit();
                Hf.BeginInit();
                Hf.DataSource = dtTop5_Weft;
                Hf.EndInit();
        


            AB.BeginInit();

           
                AB.Sub_HighestWarpBreakages.ReportSource = Hw;
                AB.Sub_HighestWeftBreakages.ReportSource = Hf;
          
            AB.DataSource = dAB;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        
        private void XR_DailyShiftSummaryABC_Micro(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_ABC_Micro ABC = new Reports.Efficiency_Daily_ABC_Micro();

            // Reports.HighestWeftBreakages Hf = new Reports.HighestWeftBreakages();
            // Reports.ColorIndications CI = new Reports.ColorIndications();
            // Reports.HighestWarpBreakages Hw = new Reports.HighestWarpBreakages();
            //if (Check_PrintColorIndications.Checked == true)
            //{
            //    DataSet ds1 = WS.svc.Get_DataSet("Select * from SS_ColorSettings where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
            //    CI.BeginInit();
            //    CI.DataSource = ds1;
            //    CI.EndInit();
            //}
            // DataSet dsW = WS.svc.Get_DataSet("SELECT     top(5) * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by A_WarpStops DESC");




            ABC.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary  where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and activated=1) order by ArticleName,Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;
            // dv_Main.Sort = "  ArticleName,LoomName";
            DataTable dAB = dv_Main.ToTable();
            //if (Check_PrintWWB.Checked == true)
            //{
            //    DataView dv_Warp = ds.Tables[0].DefaultView;
            //    dv_Warp.Sort = " AB_WarpETime DESC";
            //    DataTable dtTopAll_Warp = dv_Warp.ToTable();
            //    DataTable dtTop5_Warp = dtTopAll_Warp.Clone();
            //    for (int i = 0; i < 5; i++)
            //        dtTop5_Warp.ImportRow(dtTopAll_Warp.Rows[i]);
            //    Hw.BeginInit();
            //    Hw.DataSource = dtTop5_Warp;
            //    Hw.EndInit();

            //    DataView dv_Weft = ds.Tables[0].DefaultView;
            //    dv_Weft.Sort = " AB_WeftETime DESC";
            //    DataTable dtTopAll_Weft = dv_Weft.ToTable();
            //    DataTable dtTop5_Weft = dtTopAll_Weft.Clone();
            //    for (int i = 0; i < 5; i++)
            //        dtTop5_Weft.ImportRow(dtTopAll_Weft.Rows[i]);
            //    Hw.BeginInit();
            //    Hw.DataSource = dtTop5_Warp;
            //    Hw.EndInit();
            //    Hf.BeginInit();
            //    Hf.DataSource = dtTop5_Weft;
            //    Hf.EndInit();
            //}


            ABC.BeginInit();
            //if (Check_PrintColorIndications.Checked == true)
            //{
            //    AB.Sub_ColorIndications.ReportSource = CI;
            //}
            //else
            //    AB.Sub_ColorIndications.Visible = false;
            //if (Check_PrintWWB.Checked == true)
            //{
            //    AB.Sub_HighestWarpBreakages.ReportSource = Hw;
            //    AB.Sub_HighestWeftBreakages.ReportSource = Hf;
            //}
            //else
            //{
            //    AB.Sub_HighestWarpBreakages.Visible = false;
            //    AB.Sub_HighestWeftBreakages.Visible = false;
            //}
            ABC.DataSource = dAB;
            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryABC_Micro(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_ABC_Micro ABC = new Reports.Efficiency_Daily_ABC_Micro();

           

            //ABC.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary  where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) order by ArticleName,Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;
            // dv_Main.Sort = "  ArticleName,LoomName";
            DataTable dAB = dv_Main.ToTable();
            //if (Check_PrintWWB.Checked == true)
            //{
            //    DataView dv_Warp = ds.Tables[0].DefaultView;
            //    dv_Warp.Sort = " AB_WarpETime DESC";
            //    DataTable dtTopAll_Warp = dv_Warp.ToTable();
            //    DataTable dtTop5_Warp = dtTopAll_Warp.Clone();
            //    for (int i = 0; i < 5; i++)
            //        dtTop5_Warp.ImportRow(dtTopAll_Warp.Rows[i]);
            //    Hw.BeginInit();
            //    Hw.DataSource = dtTop5_Warp;
            //    Hw.EndInit();

            //    DataView dv_Weft = ds.Tables[0].DefaultView;
            //    dv_Weft.Sort = " AB_WeftETime DESC";
            //    DataTable dtTopAll_Weft = dv_Weft.ToTable();
            //    DataTable dtTop5_Weft = dtTopAll_Weft.Clone();
            //    for (int i = 0; i < 5; i++)
            //        dtTop5_Weft.ImportRow(dtTopAll_Weft.Rows[i]);
            //    Hw.BeginInit();
            //    Hw.DataSource = dtTop5_Warp;
            //    Hw.EndInit();
            //    Hf.BeginInit();
            //    Hf.DataSource = dtTop5_Weft;
            //    Hf.EndInit();
            //}


            ABC.BeginInit();
            //if (Check_PrintColorIndications.Checked == true)
            //{
            //    AB.Sub_ColorIndications.ReportSource = CI;
            //}
            //else
            //    AB.Sub_ColorIndications.Visible = false;
            //if (Check_PrintWWB.Checked == true)
            //{
            //    AB.Sub_HighestWarpBreakages.ReportSource = Hw;
            //    AB.Sub_HighestWeftBreakages.ReportSource = Hf;
            //}
            //else
            //{
            //    AB.Sub_HighestWarpBreakages.Visible = false;
            //    AB.Sub_HighestWeftBreakages.Visible = false;
            //}
            ABC.DataSource = dAB;
            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_DailyUnitsWeaverWise_ABC(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyUnits_WeaverWise_ABC ABC = new Reports.Efficiency_DailyUnits_WeaverWise_ABC();

            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary  where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and activated=1) order by Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;
         
            DataTable dAB = dv_Main.ToTable();
                      ABC.BeginInit();
          
            ABC.DataSource = dAB;
           
            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyUnitsWeaverWise_ABC(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyUnits_WeaverWise_ABC ABC = new Reports.Efficiency_DailyUnits_WeaverWise_ABC();

            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary  where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and activated=1) order by Convert(numeric(9),LoomName)";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            DataView dv_Main = ds.Tables[0].DefaultView;

            DataTable dAB = dv_Main.ToTable();
            ABC.BeginInit();

            ABC.DataSource = dAB;

            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MonthlyUnitsWeaverWise_ABC(int ShedIndex)
        {
           
            
        }
        private void XR_DailyShiftSummaryAB_WeaverWise(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_WeaverWise_AB AB = new Reports.Efficiency_Daily_WeaverWise_AB();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;

            Reports.Efficiency_DailyLoss_SubReport ShortLossReport = new Reports.Efficiency_DailyLoss_SubReport();
            string ShortStopString = "SELECT     Sum(A_WarpStops) as A_WarpStops,Sum(WarpLoss_A)/Count(LoomID) as A_WarpLoss,Avg(A_WarpPerHour) as A_WarpPerHour , Sum(A_WeftStops) as A_WeftStops,Sum(WeftLoss_A)/Count(LoomID) as A_WeftLoss,Avg(A_WeftPerHour) as A_WeftPerHour,   Sum(A_OtherStops) as A_OtherStops,Sum(OtherLoss_A)/Count(LoomID) as A_OtherLoss,Avg(A_OtherPerHour) as A_OtherPerHour,  Sum(B_WarpStops) as B_WarpStops,Sum(WarpLoss_A)/Count(LoomID) as B_WarpLoss,Avg(B_WarpPerHour) as B_WarpPerHour , Sum(B_WeftStops) as B_WeftStops,Sum(WeftLoss_A)/Count(LoomID) as B_WeftLoss,Avg(B_WeftPerHour) as B_WeftPerHour,   Sum(B_OtherStops) as B_OtherStops,Sum(OtherLoss_B)/Count(LoomID) as B_OtherLoss,Avg(B_OtherPerHour) as B_OtherPerHour,  Sum(T_WarpStops) as T_WarpStops,Sum(WarpLoss_A)/Count(LoomID) as T_WarpLoss,Avg(T_WarpPerHour) as T_WarpPerHour , Sum(T_WeftStops) as T_WeftStops,Sum(WeftLoss_A)/Count(LoomID) as T_WeftLoss,Avg(T_WeftPerHour) as T_WeftPerHour,   Sum(T_OtherStops) as T_OtherStops,Sum(OtherLoss_T)/Count(LoomID) as T_OtherLoss,Avg(T_OtherPerHour) as T_OtherPerHour from RP_DailyShiftSummaryAndProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") ";

            DataSet dsShortStopsSummary = WS.svc.Get_DataSet(ShortStopString);
            if (dsShortStopsSummary != null)
            {

                double A_WarpLoss = 0; double A_WarpPerHour = 0; 
                double A_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpStops"].ToString(), out A_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpPerHour"].ToString(),out A_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpLoss"].ToString(),out A_WarpLoss);
                

                A_WarpLoss=double.IsNaN(A_WarpLoss)==true?0:A_WarpLoss;
                A_WarpPerHour=double.IsNaN(A_WarpPerHour)==true?0:A_WarpPerHour;
                ShortLossReport.A_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_WarpStops"].ToString();
                ShortLossReport.A_WarpPerHour.Text = A_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.A_WarpLoss.Text = A_WarpLoss.ToString("#,##0.00");

                double A_WeftLoss = 0; double A_WeftPerHour = 0;
                double A_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftStops"].ToString(), out A_WeftStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftPerHour"].ToString(), out A_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftLoss"].ToString(), out A_WeftLoss);
                A_WeftLoss = double.IsNaN(A_WeftLoss) == true ? 0 : A_WeftLoss;
                A_WeftPerHour = double.IsNaN(A_WeftPerHour) == true ? 0 : A_WeftPerHour;
                ShortLossReport.A_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_WeftStops"].ToString();
                ShortLossReport.A_WeftPerHour.Text = A_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.A_WeftLoss.Text = A_WeftLoss.ToString("#,##0.00");

                double A_OtherLoss = 0; double A_OtherPerHour = 0;
                double A_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherStops"].ToString(), out A_OtherStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherPerHour"].ToString(), out A_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherLoss"].ToString(), out A_OtherLoss);
                A_OtherLoss = double.IsNaN(A_OtherLoss) == true ? 0 : A_OtherLoss;
                A_OtherPerHour = double.IsNaN(A_OtherPerHour) == true ? 0 : A_OtherPerHour;
                ShortLossReport.A_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_OtherStops"].ToString();
                ShortLossReport.A_OtherPerHour.Text = A_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.A_OtherLoss.Text = A_OtherLoss.ToString("#,##0.00");

               ////////////////////////////////////////////////////////////////////////////
                double B_WarpLoss = 0; double B_WarpPerHour = 0;
                double B_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpStops"].ToString(), out B_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpPerHour"].ToString(), out B_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpLoss"].ToString(), out B_WarpLoss);
                B_WarpLoss = double.IsNaN(B_WarpLoss) == true ? 0 : B_WarpLoss;
                B_WarpPerHour = double.IsNaN(B_WarpPerHour) == true ? 0 : B_WarpPerHour;
                ShortLossReport.B_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_WarpStops"].ToString();
                ShortLossReport.B_WarpPerHour.Text = B_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.B_WarpLoss.Text = B_WarpLoss.ToString("#,##0.00");

                double B_WeftLoss = 0; double B_WeftPerHour = 0;
                double B_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftStops"].ToString(), out B_WeftStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftPerHour"].ToString(), out B_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftLoss"].ToString(), out B_WeftLoss);
                B_WeftLoss = double.IsNaN(B_WeftLoss) == true ? 0 : B_WeftLoss;
                B_WeftPerHour = double.IsNaN(B_WeftPerHour) == true ? 0 : B_WeftPerHour;
                ShortLossReport.B_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_WeftStops"].ToString();
                ShortLossReport.B_WeftPerHour.Text = B_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.B_WeftLoss.Text = B_WeftLoss.ToString("#,##0.00");

                double B_OtherLoss = 0; double B_OtherPerHour = 0;
                double B_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherStops"].ToString(), out B_OtherStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherPerHour"].ToString(), out B_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherLoss"].ToString(), out B_OtherLoss);
                B_OtherLoss = double.IsNaN(B_OtherLoss) == true ? 0 : B_OtherLoss;
                B_OtherPerHour = double.IsNaN(B_OtherPerHour) == true ? 0 : B_OtherPerHour;
                ShortLossReport.B_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_OtherStops"].ToString();
                ShortLossReport.B_OtherPerHour.Text = B_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.B_OtherLoss.Text = B_OtherLoss.ToString("#,##0.00");
                /////////////////////////////////////////////////////////////////////////////////
                double T_WarpLoss = 0; double T_WarpPerHour = 0;
                double T_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpStops"].ToString(), out T_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpPerHour"].ToString(), out T_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpLoss"].ToString(), out T_WarpLoss);
                T_WarpLoss = double.IsNaN(T_WarpLoss) == true ? 0 : T_WarpLoss;
                T_WarpPerHour = double.IsNaN(T_WarpPerHour) == true ? 0 : T_WarpPerHour;
                ShortLossReport.T_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_WarpStops"].ToString();
                ShortLossReport.T_WarpPerHour.Text = T_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.T_WarpLoss.Text = T_WarpLoss.ToString("#,##0.00");

                double T_WeftLoss = 0; double T_WeftPerHour = 0;
                double T_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftStops"].ToString(), out T_WeftStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftPerHour"].ToString(), out T_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftLoss"].ToString(), out T_WeftLoss);
                T_WeftLoss = double.IsNaN(T_WeftLoss) == true ? 0 : T_WeftLoss;
                T_WeftPerHour = double.IsNaN(T_WeftPerHour) == true ? 0 : T_WeftPerHour;
                ShortLossReport.T_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_WeftStops"].ToString();
                ShortLossReport.T_WeftPerHour.Text = T_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.T_WeftLoss.Text = T_WeftLoss.ToString("#,##0.00");

                double T_OtherLoss = 0; double T_OtherPerHour = 0;
                double T_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherStops"].ToString(), out T_OtherStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherPerHour"].ToString(), out T_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherLoss"].ToString(), out T_OtherLoss);
                T_OtherLoss = double.IsNaN(T_OtherLoss) == true ? 0 : T_OtherLoss;
                T_OtherPerHour = double.IsNaN(T_OtherPerHour) == true ? 0 : T_OtherPerHour;
                ShortLossReport.T_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_OtherStops"].ToString();
                ShortLossReport.T_OtherPerHour.Text = T_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.T_OtherLoss.Text = T_OtherLoss.ToString("#,##0.00");


                double A_TotalStops = 0, A_TotalLoss = 0, A_TotalPerHour = 0;
                if (double.IsNaN(A_WarpStops) == false)
                    A_TotalStops += A_WarpStops;
                if (double.IsNaN(A_WeftStops) == false)
                    A_TotalStops += A_WeftStops;
                if (double.IsNaN(A_OtherStops) == false)
                    A_TotalStops += A_OtherStops;

                if (double.IsNaN(A_WarpLoss) == false)
                    A_TotalLoss += A_WarpLoss;
                if (double.IsNaN(A_WeftLoss) == false)
                    A_TotalLoss += A_WeftLoss;
                if (double.IsNaN(A_OtherLoss) == false)
                    A_TotalLoss += A_OtherLoss;

                if (double.IsNaN(A_WarpPerHour) == false)
                    A_TotalPerHour += A_WarpPerHour;
                if (double.IsNaN(A_WeftPerHour) == false)
                    A_TotalPerHour += A_WeftPerHour;
                if (double.IsNaN(A_OtherPerHour) == false)
                    A_TotalPerHour += A_OtherPerHour;

                ShortLossReport.A_TotalStops.Text = A_TotalStops.ToString("#,##");
                ShortLossReport.A_TotalperHour.Text = A_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.A_TotalLoss.Text = A_TotalLoss.ToString("#,##0.00");

                double B_TotalStops = 0, B_TotalLoss = 0, B_TotalPerHour = 0;
                if (double.IsNaN(B_WarpStops) == false)
                    B_TotalStops += B_WarpStops;
                if (double.IsNaN(B_WeftStops) == false)
                    B_TotalStops += B_WeftStops;
                if (double.IsNaN(B_OtherStops) == false)
                    B_TotalStops += B_OtherStops;

                if (double.IsNaN(B_WarpLoss) == false)
                    B_TotalLoss += B_WarpLoss;
                if (double.IsNaN(B_WeftLoss) == false)
                    B_TotalLoss += B_WeftLoss;
                if (double.IsNaN(B_OtherLoss) == false)
                    B_TotalLoss += B_OtherLoss;

                if (double.IsNaN(B_WarpPerHour) == false)
                    B_TotalPerHour += B_WarpPerHour;
                if (double.IsNaN(B_WeftPerHour) == false)
                    B_TotalPerHour += B_WeftPerHour;
                if (double.IsNaN(B_OtherPerHour) == false)
                    B_TotalPerHour += B_OtherPerHour;

                ShortLossReport.B_TotalStops.Text = B_TotalStops.ToString("#,##");
                ShortLossReport.B_TotalPerHour.Text = B_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.B_TotalLoss.Text = B_TotalLoss.ToString("#,##0.00");


                double T_TotalStops = 0, T_TotalLoss = 0, T_TotalPerHour = 0;
                if (double.IsNaN(T_WarpStops) == false)
                    T_TotalStops += T_WarpStops;
                if (double.IsNaN(T_WeftStops) == false)
                    T_TotalStops += T_WeftStops;
                if (double.IsNaN(T_OtherStops) == false)
                    T_TotalStops += T_OtherStops;

                if (double.IsNaN(T_WarpLoss) == false)
                    T_TotalLoss += T_WarpLoss;
                if (double.IsNaN(T_WeftLoss) == false)
                    T_TotalLoss += T_WeftLoss;
                if (double.IsNaN(T_OtherLoss) == false)
                    T_TotalLoss += T_OtherLoss;

                if (double.IsNaN(T_WarpPerHour) == false)
                    T_TotalPerHour += T_WarpPerHour;
                if (double.IsNaN(T_WeftPerHour) == false)
                    T_TotalPerHour += T_WeftPerHour;
                if (double.IsNaN(T_OtherPerHour) == false)
                    T_TotalPerHour += T_OtherPerHour;

                ShortLossReport.T_TotalStops.Text = T_TotalStops.ToString("#,##");
                ShortLossReport.T_TotalPerHour.Text = T_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.T_TotalLoss.Text = T_TotalLoss.ToString("#,##0.00");

            }

            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
           
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;

            Reports.Efficiency_SectionWiseSubReport SectionWiseReport = new Reports.Efficiency_SectionWiseSubReport();
            string SectionString = "SELECT     SectionID,SectionName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by SectionID,SectionName order by SectionID,SectionName";
          
            DataSet dsSection = WS.svc.Get_DataSet(SectionString);
            if (dsSection != null)
            {

                SectionWiseReport.DataSource = dsSection.Tables[0];
            }
            else
                SectionWiseReport.DataSource = null;

            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.SubReport_SectionWise.ReportSource = SectionWiseReport;
            AB.SubReport_ShortStopSummary.ReportSource = ShortLossReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_DailyShiftSummaryAB_WeaverWise_DailyWages(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_WeaverWise_AB_SalaryPlusUnits AB = new Reports.Efficiency_Daily_WeaverWise_AB_SalaryPlusUnits();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryAB_WeaverWise_DailyWages(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_WeaverWise_AB_SalaryPlusUnits AB = new Reports.Efficiency_Daily_WeaverWise_AB_SalaryPlusUnits();

            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                AB.DataSource = dAB;
            }
            else
                AB.DataSource = null;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_DailyShiftSummaryABC_WeaverWise(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_WeaverWise_ABC ABC = new Reports.Efficiency_Daily_WeaverWise_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryABC_WeaverWise(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_WeaverWise_ABC ABC = new Reports.Efficiency_Daily_WeaverWise_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) order by GroupNumber,Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_DailyShiftSummaryABC_QualityWise(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_QualityWise_ABC ABC = new Reports.Efficiency_Daily_QualityWise_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryABC_QualityWise(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_QualityWise_ABC ABC = new Reports.Efficiency_Daily_QualityWise_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_DailyShiftSummaryAB_QualityWise(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_QualityWise_AB AB = new Reports.Efficiency_Daily_QualityWise_AB();

            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT   *  from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by ArticleShortName,Convert(numeric(9),LoomName)";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
                AB.DataSource = ds;
            else
                AB.DataSource = null;
            string subreportString = "SELECT   *  from RP_MonthlyProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "";
            DataSet dssubrep = WS.svc.Get_DataSet(subreportString);
            if (dssubrep != null)
            {
                if (dssubrep.Tables[0].Rows.Count > 0)
                {
                    double loss = 0;
                    MachineEyes.Reports.Efficiency_DailyEfficiencyLossSummary LossSummary = new Reports.Efficiency_DailyEfficiencyLossSummary();
                    double.TryParse(dssubrep.Tables[0].Rows[0]["ArtLoss"].ToString(), out loss);
                    LossSummary.Loss_Article.Text = loss.ToString("#,##0.00");

                    double.TryParse(dssubrep.Tables[0].Rows[0]["BeamShortLoss"].ToString(), out loss);
                    LossSummary.Loss_BeamShort.Text = loss.ToString("#,##0.00");

                    double.TryParse(dssubrep.Tables[0].Rows[0]["ElecLoss"].ToString(), out loss);
                    LossSummary.Loss_Electrical.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["KnotLoss"].ToString(), out loss);
                    LossSummary.Loss_Knotting.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["MecLoss"].ToString(), out loss);
                    LossSummary.Loss_Mechanical.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["OtherLongLoss"].ToString(), out loss);
                    LossSummary.Loss_OtherLong.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["PowerOffLoss"].ToString(), out loss);
                    LossSummary.Loss_PoweredOff.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["WarpLoss"].ToString(), out loss);
                    LossSummary.Loss_Warp.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["WeftLoss"].ToString(), out loss);
                    LossSummary.Loss_Weft.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["OtherLoss"].ToString(), out loss);
                    LossSummary.Loss_Other.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWarpPerHour"].ToString(), out loss);
                    LossSummary.PerHourWarp.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWeftPerHour"].ToString(), out loss);
                    LossSummary.PerHourWeft.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalOtherPerHour"].ToString(), out loss);
                    LossSummary.PerHourOther.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWarpStops"].ToString(), out loss);
                    LossSummary.Stops_Warp.Text = loss.ToString("#,##");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWeftStops"].ToString(), out loss);
                    LossSummary.Stops_Weft.Text = loss.ToString("#,##");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalOtherStops"].ToString(), out loss);
                    LossSummary.Stops_Other.Text = loss.ToString("#,##");
                    AB.LossSummary.ReportSource = LossSummary;



                }
                else
                    AB.LossSummary.Visible = false;
            }
            else
                AB.LossSummary.Visible = false;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_MergedDailyShiftSummaryAB_QualityWise(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_Daily_QualityWise_AB AB = new Reports.Efficiency_Daily_QualityWise_AB();

            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT   *  from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) order by ArticleShortName,Convert(numeric(9),LoomName)";
            AB.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
                AB.DataSource = ds;
            else
                AB.DataSource = null;
            string subreportString = "SELECT   *  from RP_MonthlyProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")";
            DataSet dssubrep = WS.svc.Get_DataSet(subreportString);
            if (dssubrep != null)
            {
                if (dssubrep.Tables[0].Rows.Count > 0)
                {
                    double loss = 0;
                    MachineEyes.Reports.Efficiency_DailyEfficiencyLossSummary LossSummary = new Reports.Efficiency_DailyEfficiencyLossSummary();
                    double.TryParse(dssubrep.Tables[0].Rows[0]["ArtLoss"].ToString(), out loss);
                    LossSummary.Loss_Article.Text = loss.ToString("#,##0.00");

                    double.TryParse(dssubrep.Tables[0].Rows[0]["BeamShortLoss"].ToString(), out loss);
                    LossSummary.Loss_BeamShort.Text = loss.ToString("#,##0.00");

                    double.TryParse(dssubrep.Tables[0].Rows[0]["ElecLoss"].ToString(), out loss);
                    LossSummary.Loss_Electrical.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["KnotLoss"].ToString(), out loss);
                    LossSummary.Loss_Knotting.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["MecLoss"].ToString(), out loss);
                    LossSummary.Loss_Mechanical.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["OtherLongLoss"].ToString(), out loss);
                    LossSummary.Loss_OtherLong.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["PowerOffLoss"].ToString(), out loss);
                    LossSummary.Loss_PoweredOff.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["WarpLoss"].ToString(), out loss);
                    LossSummary.Loss_Warp.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["WeftLoss"].ToString(), out loss);
                    LossSummary.Loss_Weft.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["OtherLoss"].ToString(), out loss);
                    LossSummary.Loss_Other.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWarpPerHour"].ToString(), out loss);
                    LossSummary.PerHourWarp.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWeftPerHour"].ToString(), out loss);
                    LossSummary.PerHourWeft.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalOtherPerHour"].ToString(), out loss);
                    LossSummary.PerHourOther.Text = loss.ToString("#,##0.00");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWarpStops"].ToString(), out loss);
                    LossSummary.Stops_Warp.Text = loss.ToString("#,##");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalWeftStops"].ToString(), out loss);
                    LossSummary.Stops_Weft.Text = loss.ToString("#,##");
                    double.TryParse(dssubrep.Tables[0].Rows[0]["TotalOtherStops"].ToString(), out loss);
                    LossSummary.Stops_Other.Text = loss.ToString("#,##");
                    AB.LossSummary.ReportSource = LossSummary;



                }
                else
                    AB.LossSummary.Visible = false;
            }
            else
                AB.LossSummary.Visible = false;
            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";
            AB.BeginInit();
            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;
            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.EndInit();
            AB.ShowPreview();
        }
        private void XR_CommingKnottings(int ShedIndex)
        {


            Reports.Planning_CommingKnottings ABC = new Reports.Planning_CommingKnottings();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            string dsstring = "select  LoomID, LoomName, Current_RPM, ShedID,ExpectedCrimp,Current_PPI, SetNo, BeamNumber,BeamLength, ArticleNumber, ArticleShortName ,0.0 as ProductionMeters,0.0 as RemainingLength,'01/01/2014 8:00:00 AM' as CommingKnotting,'25 days 5 hours' as DaysRemaining from MTQ_Looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " order by Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            int LoomID=0;
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        try
                        {
                        LoomID=Convert.ToInt32(ds.Tables[0].Rows[x]["LoomID"].ToString());
                        }catch
                        {
                        }
                        string LoomLogTable = "LoomLog_" + ds.Tables[0].Rows[x]["LoomID"].ToString();
                        if (ds.Tables[0].Rows[x]["SetNo"].ToString() != "" && ds.Tables[0].Rows[x]["BeamNumber"].ToString() != "")
                        {
                            string lengthquery = "Select ArticleNumber,Sum(Picks) as TotalPicks from " + LoomLogTable + " where SetNo='" + ds.Tables[0].Rows[x]["SetNo"].ToString() + "' and BeamNo='" + ds.Tables[0].Rows[x]["BeamNumber"].ToString() + "' group by ArticleNumber";
                            DataSet dsl = WS.svc.Get_DataSet(lengthquery);
                            if (dsl != null)
                            {
                                if (dsl.Tables[0].Rows.Count > 0)
                                {
                                    double TotalMetersProduced = 0; double BeamLength = 0; double RemainingLength = 0; double EC = 0; double EC_Meters = 0; double Current_RPM = 250; double Current_PPI = 30;
                                    for (int l = 0; l < dsl.Tables[0].Rows.Count; l++)
                                    {
                                        double tpicks; double tMeters=0;
                                        double.TryParse(dsl.Tables[0].Rows[l]["TotalPicks"].ToString(), out tpicks);
                                        article nArticle = Program.ss.Machines.PresentationData.Return_Article(dsl.Tables[0].Rows[l]["ArticleNumber"].ToString());
                                        if (nArticle != null)
                                        {
                                            tMeters = tpicks * 0.0254 / nArticle.PPI;
                                        }
                                        else
                                            tMeters = tpicks * 0.0254 / 30;
                                        TotalMetersProduced += tMeters;
                                    }
                                    DataRow d = ds.Tables[0].Rows[x];
                                    try
                                    {
                                        double.TryParse(d["BeamLength"].ToString(), out BeamLength);
                                        d["ProductionMeters"] = TotalMetersProduced.ToString();
                                        RemainingLength = BeamLength - TotalMetersProduced;
                                        d["RemainingLength"] = RemainingLength.ToString();
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        double.TryParse(d["ExpectedCrimp"].ToString(), out EC);
                                        EC_Meters = BeamLength * EC / 100;
                                        double.TryParse(d["Current_RPM"].ToString(), out Current_RPM);
                                        double.TryParse(d["Current_PPI"].ToString(), out Current_PPI);
                                        double RemainingMinutes = ((RemainingLength - EC_Meters) * Current_PPI / 0.0254) / Current_RPM;
                                        double RealEfficiencyDifference = 100 - Program.ss.Machines.Looms[LoomID].CurrentParams.Current_Eff;
                                        double AddRemainingMinutes = RemainingMinutes * RealEfficiencyDifference / 100;
                                        RemainingMinutes = RemainingMinutes + AddRemainingMinutes;
                                        TimeSpan ts = new TimeSpan(0, Convert.ToInt32(RemainingMinutes), 0);
                                        DateTime E_K = DateTime.Now.Add(ts);
                                        
                                        d["CommingKnotting"] = E_K.ToString();
                                        d["DaysRemaining"] = ts.Days.ToString() + "  Day(s) " + ts.Hours.ToString() + "  hour(s)";

                                    }
                                    catch
                                    {
                                    }

                                }
                            }
                        }

                    }
                }
            }
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
               

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedCommingKnottings(int MergedShedIndex)
        {


            Reports.Planning_CommingKnottings ABC = new Reports.Planning_CommingKnottings();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            string dsstring = "select  LoomID, LoomName, Current_RPM, ShedID,ExpectedCrimp,Current_PPI, SetNo, BeamNumber,BeamLength, ArticleNumber, ArticleShortName ,0.0 as ProductionMeters,0.0 as RemainingLength,'01/01/2014 8:00:00 AM' as CommingKnotting,'25 days 5 hours' as DaysRemaining from MTQ_Looms where  ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") order by Convert(numeric(9),LoomName)";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        string LoomLogTable = "LoomLog_" + ds.Tables[0].Rows[x]["LoomID"].ToString();
                        if (ds.Tables[0].Rows[x]["SetNo"].ToString() != "" && ds.Tables[0].Rows[x]["BeamNumber"].ToString() != "")
                        {
                            string lengthquery = "Select ArticleNumber,Sum(Picks) as TotalPicks from " + LoomLogTable + " where SetNo='" + ds.Tables[0].Rows[x]["SetNo"].ToString() + "' and BeamNo='" + ds.Tables[0].Rows[x]["BeamNumber"].ToString() + "' group by ArticleNumber";
                            DataSet dsl = WS.svc.Get_DataSet(lengthquery);
                            if (dsl != null)
                            {
                                if (dsl.Tables[0].Rows.Count > 0)
                                {
                                    double TotalMetersProduced = 0; double BeamLength = 0; double RemainingLength = 0; double EC = 0; double EC_Meters = 0; double Current_RPM = 250; double Current_PPI = 30;
                                    for (int l = 0; l < dsl.Tables[0].Rows.Count; l++)
                                    {
                                        double tpicks; double tMeters = 0;
                                        double.TryParse(dsl.Tables[0].Rows[l]["TotalPicks"].ToString(), out tpicks);
                                        article nArticle = Program.ss.Machines.PresentationData.Return_Article(dsl.Tables[0].Rows[l]["ArticleNumber"].ToString());
                                        if (nArticle != null)
                                        {
                                            tMeters = tpicks * 0.0254 / nArticle.PPI;
                                        }
                                        else
                                            tMeters = tpicks * 0.0254 / 30;
                                        TotalMetersProduced += tMeters;
                                    }
                                    DataRow d = ds.Tables[0].Rows[x];
                                    try
                                    {
                                        double.TryParse(d["BeamLength"].ToString(), out BeamLength);
                                        d["ProductionMeters"] = TotalMetersProduced.ToString();
                                        RemainingLength = BeamLength - TotalMetersProduced;
                                        d["RemainingLength"] = RemainingLength.ToString();
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        double.TryParse(d["ExpectedCrimp"].ToString(), out EC);
                                        EC_Meters = BeamLength * EC / 100;
                                        double.TryParse(d["Current_RPM"].ToString(), out Current_RPM);
                                        double.TryParse(d["Current_PPI"].ToString(), out Current_PPI);
                                        double RemainingMinutes = ((RemainingLength - EC_Meters) * Current_PPI / 0.0254) / Current_RPM;

                                        TimeSpan ts = new TimeSpan(0, Convert.ToInt32(RemainingMinutes), 0);
                                        DateTime E_K = DateTime.Now.Add(ts);

                                        d["CommingKnotting"] = E_K.ToString();
                                        d["DaysRemaining"] = ts.Days.ToString() + "  Day(s) " + ts.Hours.ToString() + "  hour(s)";

                                    }
                                    catch
                                    {
                                    }

                                }
                            }
                        }

                    }
                }
            }
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;


                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_BeamContraction()
        {

            
        }
        private void XR_WeeklyShiftSummaryABC_LoomWise(int ShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            DateTime D1_Date = SelectedDate.Date;
            DateTime D2_Date = SelectedDate.Date.AddDays(1);
            DateTime D3_Date = SelectedDate.Date.AddDays(2);
            DateTime D4_Date = SelectedDate.Date.AddDays(3);
            DateTime D5_Date = SelectedDate.Date.AddDays(4);
            DateTime D6_Date = SelectedDate.Date.AddDays(5);
            DateTime D7_Date = SelectedDate.Date.AddDays(6);

            Reports.Efficiency_Weekly_AB ABC = new Reports.Efficiency_Weekly_AB();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.Label_D1.Text = D1_Date.DayOfWeek.ToString() + " " + D1_Date.Day.ToString();
            ABC.Label_D2.Text = D2_Date.DayOfWeek.ToString() + " " + D2_Date.Day.ToString();
            ABC.Label_D3.Text = D3_Date.DayOfWeek.ToString() + " " + D3_Date.Day.ToString();
            ABC.Label_D4.Text = D4_Date.DayOfWeek.ToString() + " " + D4_Date.Day.ToString();
            ABC.Label_D5.Text = D5_Date.DayOfWeek.ToString() + " " + D5_Date.Day.ToString();
            ABC.Label_D6.Text = D6_Date.DayOfWeek.ToString() + " " + D6_Date.Day.ToString();
            ABC.Label_D7.Text = D7_Date.DayOfWeek.ToString() + " " + D7_Date.Day.ToString();
            ABC.repH_Dated_From.Text = D1_Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = D7_Date.ToString("dd/MM/yyyy");
           // ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     LoomID,LoomName,avg(t_rpm) as AvgRPM" +
                " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D1_A_Eff" + 
                 " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D1_B_Eff" + 
                  " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D1_C_Eff" + 
                   " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D1_T_Eff" +
                   " , sum(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D1_Units" +

                    " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D2_A_Eff" +
                 " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D2_B_Eff" +
                  " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D2_C_Eff" +
                   " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D2_T_Eff" +
                   " , sum(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D2_Units" +

                    " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D3_A_Eff" +
                 " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D3_B_Eff" +
                  " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D3_C_Eff" +
                   " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D3_T_Eff" +
                   " , sum(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D3_Units" +

                    " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D4_A_Eff" +
                 " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D4_B_Eff" +
                  " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D4_C_Eff" +
                   " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D4_T_Eff" +
                   " , sum(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D4_Units" +

                    " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D5_A_Eff" +
                 " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D5_B_Eff" +
                  " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D5_C_Eff" +
                   " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D5_T_Eff" +
                   " , sum(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D5_Units" +

                    " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D6_A_Eff" +
                 " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D6_B_Eff" +
                  " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D6_C_Eff" +
                   " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D6_T_Eff" +
                   " , sum(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D6_Units" +

                    " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D7_A_Eff" +
                 " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D7_B_Eff" +
                  " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D7_C_Eff" +
                   " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D7_T_Eff" +
                   " , sum(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D7_Units" +


                 " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as DW_A_Eff" +
                 " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as DW_B_Eff" +
                  " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as DW_C_Eff" +
                   " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as DW_T_Eff" +
                   " , sum(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as DW_Units" + 

            "  from RP_dailyShiftSummary where  shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") group by loomid,loomname order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedWeeklyShiftSummaryABC_LoomWise(int MergedShedIndex)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            DateTime D1_Date = SelectedDate.Date;
            DateTime D2_Date = SelectedDate.Date.AddDays(1);
            DateTime D3_Date = SelectedDate.Date.AddDays(2);
            DateTime D4_Date = SelectedDate.Date.AddDays(3);
            DateTime D5_Date = SelectedDate.Date.AddDays(4);
            DateTime D6_Date = SelectedDate.Date.AddDays(5);
            DateTime D7_Date = SelectedDate.Date.AddDays(6);

            Reports.Efficiency_Weekly_AB ABC = new Reports.Efficiency_Weekly_AB();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.Label_D1.Text = D1_Date.DayOfWeek.ToString() + " " + D1_Date.Day.ToString();
            ABC.Label_D2.Text = D2_Date.DayOfWeek.ToString() + " " + D2_Date.Day.ToString();
            ABC.Label_D3.Text = D3_Date.DayOfWeek.ToString() + " " + D3_Date.Day.ToString();
            ABC.Label_D4.Text = D4_Date.DayOfWeek.ToString() + " " + D4_Date.Day.ToString();
            ABC.Label_D5.Text = D5_Date.DayOfWeek.ToString() + " " + D5_Date.Day.ToString();
            ABC.Label_D6.Text = D6_Date.DayOfWeek.ToString() + " " + D6_Date.Day.ToString();
            ABC.Label_D7.Text = D7_Date.DayOfWeek.ToString() + " " + D7_Date.Day.ToString();
            ABC.repH_Dated_From.Text = D1_Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = D7_Date.ToString("dd/MM/yyyy");
            // ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     LoomID,LoomName,avg(t_rpm) as AvgRPM" +
                " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D1_A_Eff" +
                 " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D1_B_Eff" +
                  " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D1_C_Eff" +
                   " , avg(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D1_T_Eff" +
                   " , sum(Case when shiftdate='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D1_Units" +

                    " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D2_A_Eff" +
                 " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D2_B_Eff" +
                  " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D2_C_Eff" +
                   " , avg(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D2_T_Eff" +
                   " , sum(Case when shiftdate='" + D2_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D2_Units" +

                    " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D3_A_Eff" +
                 " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D3_B_Eff" +
                  " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D3_C_Eff" +
                   " , avg(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D3_T_Eff" +
                   " , sum(Case when shiftdate='" + D3_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D3_Units" +

                    " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D4_A_Eff" +
                 " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D4_B_Eff" +
                  " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D4_C_Eff" +
                   " , avg(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D4_T_Eff" +
                   " , sum(Case when shiftdate='" + D4_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D4_Units" +

                    " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D5_A_Eff" +
                 " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D5_B_Eff" +
                  " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D5_C_Eff" +
                   " , avg(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D5_T_Eff" +
                   " , sum(Case when shiftdate='" + D5_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D5_Units" +

                    " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D6_A_Eff" +
                 " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D6_B_Eff" +
                  " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D6_C_Eff" +
                   " , avg(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D6_T_Eff" +
                   " , sum(Case when shiftdate='" + D6_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D6_Units" +

                    " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as D7_A_Eff" +
                 " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as D7_B_Eff" +
                  " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as D7_C_Eff" +
                   " , avg(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as D7_T_Eff" +
                   " , sum(Case when shiftdate='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as D7_Units" +


                 " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  A_Eff else null end) as DW_A_Eff" +
                 " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then B_Eff  else null end) as DW_B_Eff" +
                  " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then C_Eff else null end) as DW_C_Eff" +
                   " , avg(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Eff else null end) as DW_T_Eff" +
                   " , sum(Case when shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then T_Units else 0 end) as DW_Units" +

            "  from RP_dailyShiftSummary where  shiftdate>='" + D1_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + D7_Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) group by loomid,loomname order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MonthlyShiftSummaryABC_LoomWise(int ShedIndex)
        {

            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            if (SelectedDate.upTo <= SelectedDate.Date)
            {
                XtraMessageBox.Show("Invalid date....date from must be less than date upto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
               
            }

            TimeSpan ts = SelectedDate.upTo.Subtract(SelectedDate.Date);
            int days = ts.Days+1;
           
            if (days > 31)
            {
                XtraMessageBox.Show("Invalid date...Maximum limit between two dates is limited to 1 month....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (days < 1)
            {
                XtraMessageBox.Show("Invalid date...minimum limit between two dates is 1 day....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Reports.Efficiency_Monthly_ABC ABC = new Reports.Efficiency_Monthly_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            ABC.repH_Dated_From.Text = SelectedDate.Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = SelectedDate.upTo.ToString("dd/MM/yyyy");

            string query = "SELECT     LoomID,LoomName,avg(T_rpm) as AvgRPM,avg(T_Eff) as AvgEff";
            string substring = "";
            string colname = "";
            DateTime nextdate = SelectedDate.Date;
            for (int d = 1; d <= days; d++)
            {

                colname = "Eff" + d.ToString();
                DevExpress.XtraReports.UI.XRControl xrc = ABC.GetXRControlByName("D" + d.ToString());
                if (xrc != null)
                {
                    xrc.Visible = true;
                    xrc.Text = nextdate.Day.ToString();
                }
                xrc = ABC.GetXRControlByName("Eff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                xrc = ABC.GetXRControlByName("AvgEff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                
                substring = " , avg(Case when shiftdate='" + nextdate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  T_Eff else null end) as " + colname + "";
                nextdate = nextdate.AddDays(1);
                query += substring;
                substring = "";
            }
            colname = "Eff" + (days+1).ToString();
            DevExpress.XtraReports.UI.XRControl xrT = ABC.GetXRControlByName("D" + (days + 1).ToString());
            if (xrT != null)
            {
                xrT.Visible = true;
                xrT.Text = "Total";
            }
            xrT = ABC.GetXRControlByName(colname);
            if (xrT != null)
            {
                xrT.Visible = true;
              
            }
            xrT = ABC.GetXRControlByName("AvgEff" + (days + 1).ToString());
            if (xrT != null)
            {

                xrT.Visible = true;
            }
            substring = " , avg(Case when shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then  T_Eff else null end) as " + colname + "";
            query += substring;
            substring = "  from RP_dailyShiftSummary where  shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") group by loomid,loomname order by LoomID";
            query += substring;
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MonthlyShiftSummaryABC_Units(int ShedIndex)
        {

            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            if (SelectedDate.upTo <= SelectedDate.Date)
            {
                XtraMessageBox.Show("Invalid date....date from must be less than date upto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            TimeSpan ts = SelectedDate.upTo.Subtract(SelectedDate.Date);
            int days = ts.Days + 1;

            if (days > 31)
            {
                XtraMessageBox.Show("Invalid date...Maximum limit between two dates is limited to 1 month....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (days < 1)
            {
                XtraMessageBox.Show("Invalid date...minimum limit between two dates is 1 day....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Reports.Efficiency_MonthlyUnits_ABC ABC = new Reports.Efficiency_MonthlyUnits_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            ABC.repH_Dated_From.Text = SelectedDate.Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = SelectedDate.upTo.ToString("dd/MM/yyyy");

            string query = "SELECT     LoomID,LoomName,TypeName,avg(T_rpm) as AvgRPM,sum(T_Units) as AvgUnits";
            string substring = "";
            string colname = "";
            DateTime nextdate = SelectedDate.Date;
            for (int d = 1; d <= days; d++)
            {

                colname = "Units" + d.ToString();
                DevExpress.XtraReports.UI.XRControl xrc = ABC.GetXRControlByName("D" + d.ToString());
                if (xrc != null)
                {
                    xrc.Visible = true;
                    xrc.Text = nextdate.Day.ToString();
                }
                xrc = ABC.GetXRControlByName("Units" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                xrc = ABC.GetXRControlByName("AvgUnits" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                xrc = ABC.GetXRControlByName("GroupUnits" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }

                substring = " , sum(Case when shiftdate='" + nextdate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  T_Units else 0 end) as " + colname + "";
                nextdate = nextdate.AddDays(1);
                query += substring;
                substring = "";
            }
            colname = "Units" + (days + 1).ToString();

            DevExpress.XtraReports.UI.XRControl xrTotalLabel = ABC.GetXRControlByName("D32");
            DevExpress.XtraReports.UI.XRControl xrTotal = ABC.GetXRControlByName("Units32");
            DevExpress.XtraReports.UI.XRControl xrTotalSum = ABC.GetXRControlByName("AvgUnits32");
            DevExpress.XtraReports.UI.XRControl xrGroupSum = ABC.GetXRControlByName("GroupUnits32");

            DevExpress.XtraReports.UI.XRControl xrT = ABC.GetXRControlByName("D" + (days + 1).ToString());
            if (xrT != null)
            {
                xrT.Visible = false;
                xrT.Text = "Total";
                xrTotalLabel.LocationF= xrT.LocationF;
                xrTotalLabel.Visible = true;
            }
            xrT = ABC.GetXRControlByName(colname);
            if (xrT != null)
            {
                xrT.Visible = false;
                xrTotal.LocationF = xrT.LocationF;
                xrTotal.Visible = true;

            }
            xrT = ABC.GetXRControlByName("AvgUnits" + (days + 1).ToString());
            if (xrT != null)
            {

                xrT.Visible = false;
                xrTotalSum.LocationF = xrT.LocationF;
                xrTotalSum.Visible = true;
            }
            xrT = ABC.GetXRControlByName("GroupUnits" + (days + 1).ToString());
            if (xrT != null)
            {

                xrT.Visible = false;
                xrGroupSum.LocationF = xrT.LocationF;
                xrGroupSum.Visible = true;
            }
            substring = " , sum(Case when shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then  T_Units else 0 end) as Units32 ";
            query += substring;
            substring = "  from RP_dailyShiftSummary where  shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") group by loomid,loomname,TypeName order by TypeName,LoomID";
            query += substring;
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedMonthlyShiftSummaryABC_LoomWise(int MergedShedIndex)
        {

            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            if (SelectedDate.upTo <= SelectedDate.Date)
            {
                XtraMessageBox.Show("Invalid date....date from must be less than date upto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            TimeSpan ts = SelectedDate.upTo.Subtract(SelectedDate.Date);
            int days = ts.Days + 1;

            if (days > 31)
            {
                XtraMessageBox.Show("Invalid date...Maximum limit between two dates is limited to 1 month....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (days < 1)
            {
                XtraMessageBox.Show("Invalid date...minimum limit between two dates is 1 day....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Reports.Efficiency_Monthly_ABC ABC = new Reports.Efficiency_Monthly_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            ABC.repH_Dated_From.Text = SelectedDate.Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = SelectedDate.upTo.ToString("dd/MM/yyyy");

            string query = "SELECT     LoomID,LoomName,avg(T_rpm) as AvgRPM,avg(T_Eff) as AvgEff";
            string substring = "";
            string colname = "";
            DateTime nextdate = SelectedDate.Date;
            for (int d = 1; d <= days; d++)
            {

                colname = "Eff" + d.ToString();
                DevExpress.XtraReports.UI.XRControl xrc = ABC.GetXRControlByName("D" + d.ToString());
                if (xrc != null)
                {
                    xrc.Visible = true;
                    xrc.Text = nextdate.Day.ToString();
                }
                xrc = ABC.GetXRControlByName("Eff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                xrc = ABC.GetXRControlByName("AvgEff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }

                substring = " , avg(Case when shiftdate='" + nextdate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  T_Eff else null end) as " + colname + "";
                nextdate = nextdate.AddDays(1);
                query += substring;
                substring = "";
            }
            colname = "Eff" + (days + 1).ToString();
            DevExpress.XtraReports.UI.XRControl xrT = ABC.GetXRControlByName("D" + (days + 1).ToString());
            if (xrT != null)
            {
                xrT.Visible = true;
                xrT.Text = "Total";
            }
            xrT = ABC.GetXRControlByName(colname);
            if (xrT != null)
            {
                xrT.Visible = true;

            }
            xrT = ABC.GetXRControlByName("AvgEff" + (days + 1).ToString());
            if (xrT != null)
            {

                xrT.Visible = true;
            }
            substring = " , avg(Case when shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then  T_Eff else null end) as " + colname + "";
            query += substring;
            substring = "  from RP_dailyShiftSummary where  shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ")) group by loomid,loomname order by LoomID";
            query += substring;
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MonthlyProductionEfficiencyABC_LoomWise(int ShedIndex)
        {

            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            if (SelectedDate.upTo <= SelectedDate.Date)
            {
                XtraMessageBox.Show("Invalid date....date from must be less than date upto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }

            TimeSpan ts = SelectedDate.upTo.Subtract(SelectedDate.Date);
            int days = ts.Days + 1;

            if (days > 31)
            {
                XtraMessageBox.Show("Invalid date...Maximum limit between two dates is limited to 1 month....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (days < 1)
            {
                XtraMessageBox.Show("Invalid date...minimum limit between two dates is 1 day....", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Reports.Efficiency_Monthly_Prod_ABC ABC = new Reports.Efficiency_Monthly_Prod_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;

            ABC.repH_Dated_From.Text = SelectedDate.Date.ToString("dd/MM/yyyy");
            ABC.repH_Dated_Upto.Text = SelectedDate.upTo.ToString("dd/MM/yyyy");

            string query = "SELECT     LoomID,LoomName,avg(T_rpm) as AvgRPM,avg(T_ProdEff) as AvgEff";
            string substring = "";
            string colname = "";
            DateTime nextdate = SelectedDate.Date;
            for (int d = 1; d <= days; d++)
            {

                colname = "Eff" + d.ToString();
                DevExpress.XtraReports.UI.XRControl xrc = ABC.GetXRControlByName("D" + d.ToString());
                if (xrc != null)
                {
                    xrc.Visible = true;
                    xrc.Text = nextdate.Day.ToString();
                }
                xrc = ABC.GetXRControlByName("Eff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }
                xrc = ABC.GetXRControlByName("AvgEff" + d.ToString());
                if (xrc != null)
                {

                    xrc.Visible = true;
                }

                substring = " , avg(Case when shiftdate='" + nextdate.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  then  T_ProdEff else null end) as " + colname + "";
                nextdate = nextdate.AddDays(1);
                query += substring;
                substring = "";
            }
            colname = "Eff" + (days + 1).ToString();
            DevExpress.XtraReports.UI.XRControl xrT = ABC.GetXRControlByName("D" + (days + 1).ToString());
            if (xrT != null)
            {
                xrT.Visible = true;
                xrT.Text = "Total";
            }
            xrT = ABC.GetXRControlByName(colname);
            if (xrT != null)
            {
                xrT.Visible = true;

            }
            xrT = ABC.GetXRControlByName("AvgEff" + (days + 1).ToString());
            if (xrT != null)
            {

                xrT.Visible = true;
            }
            substring = " , avg(Case when shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then  T_ProdEff else null end) as " + colname + "";
            query += substring;
            substring = "  from RP_dailyShiftSummary where  shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "'  and shiftdate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and  LoomID in(select loomid from MT_Looms where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") group by loomid,loomname order by LoomID";
            query += substring;
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }

        private void XR_DailyProductionLossABC(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyProductionLoss_ABC ABC = new Reports.Efficiency_DailyProductionLoss_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT * from RP_ProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1  order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyProductionLossABC(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyProductionLoss_ABC ABC = new Reports.Efficiency_DailyProductionLoss_ABC();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT * from RP_ProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1  order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_DailyEfficiencyWithProductionLossABC(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyEfficiency_WithProductionLoss ABC = new Reports.Efficiency_DailyEfficiency_WithProductionLoss();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT * from RP_DailyShiftSummaryAndProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1  order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        private void XR_MergedDailyEfficiencyWithProductionLossABC(int MergedShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Efficiency_DailyEfficiency_WithProductionLoss ABC = new Reports.Efficiency_DailyEfficiency_WithProductionLoss();

            //AB.ShedIndex = ShedIndex;
            ABC.repH_Shed.Text = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutName;
            ABC.repH_Shed.Tag = Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].LayoutIndex.ToString();
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT * from RP_DailyShiftSummaryAndProductionLoss where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and ShedID in(" + Program.ss.Machines.PresentationData.MergedSheds[MergedShedIndex].ShedIds + ") and Activated=1  order by LoomID";
            ABC.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

                DataTable dAB = dv_Main.ToTable();
                ABC.DataSource = dAB;
            }
            else
                ABC.DataSource = null;


            ABC.EndInit();
            ABC.ShowPreview();
        }
        //private void XR_DailyShiftSummaryAB(int ShedIndex)
        //{
        //    Param_Date DateForm = new Param_Date();
        //    DateForm.ShowDialog();
        //    if (SelectedDate.isCanceled == true)
        //        return;
        //    Reports.Efficiency_Daily_AB AB = new Reports.Efficiency_Daily_AB();
           
        //    Reports.HighestWeftBreakages Hf = new Reports.HighestWeftBreakages();
        //    Reports.ColorIndications CI = new Reports.ColorIndications();
        //    Reports.HighestWarpBreakages Hw = new Reports.HighestWarpBreakages();
        //    if (Check_PrintColorIndications.Checked == true)
        //    {
        //        DataSet ds1 = WS.svc.Get_DataSet("Select * from SS_ColorSettings where ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + "");
        //        CI.BeginInit();
        //        CI.DataSource = ds1;
        //        CI.EndInit();
        //    }
        //   // DataSet dsW = WS.svc.Get_DataSet("SELECT     top(5) * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") order by A_WarpStops DESC");

      
          
   
        //    AB.ShedIndex = ShedIndex;
        //    AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
        //    AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
        //    AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
        //    AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
        //    string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and activated=1) order by ArticleName,LoomID";
        //    DataSet ds = WS.svc.Get_DataSet(dsstring);
        //    DataView dv_Main = ds.Tables[0].DefaultView;
        //    dv_Main.Sort = "  ArticleName,LoomName";
        //    DataTable dAB = dv_Main.ToTable();
        //    if (Check_PrintWWB.Checked == true)
        //    {
        //        DataView dv_Warp = ds.Tables[0].DefaultView;
        //        dv_Warp.Sort = " AB_WarpETime DESC";
        //        DataTable dtTopAll_Warp = dv_Warp.ToTable();
        //        DataTable dtTop5_Warp = dtTopAll_Warp.Clone();
        //        for (int i = 0; i < 5; i++)
        //            dtTop5_Warp.ImportRow(dtTopAll_Warp.Rows[i]);
        //        Hw.BeginInit();
        //        Hw.DataSource = dtTop5_Warp;
        //        Hw.EndInit();

        //        DataView dv_Weft = ds.Tables[0].DefaultView;
        //        dv_Weft.Sort = " AB_WeftETime DESC";
        //        DataTable dtTopAll_Weft = dv_Weft.ToTable();
        //        DataTable dtTop5_Weft = dtTopAll_Weft.Clone();
        //        for (int i = 0; i < 5; i++)
        //            dtTop5_Weft.ImportRow(dtTopAll_Weft.Rows[i]);
        //        Hw.BeginInit();
        //        Hw.DataSource = dtTop5_Warp;
        //        Hw.EndInit();
        //        Hf.BeginInit();
        //        Hf.DataSource = dtTop5_Weft;
        //        Hf.EndInit();
        //    }

        //    AB.BeginInit();
        //    if (Check_PrintColorIndications.Checked == true)
        //    {
        //        AB.Sub_ColorIndications.ReportSource = CI;
        //    }
        //    else
        //        AB.Sub_ColorIndications.Visible = false;
        //    if (Check_PrintWWB.Checked == true)
        //    {
        //        AB.Sub_HighestWarpBreakages.ReportSource = Hw;
        //        AB.Sub_HighestWeftBreakages.ReportSource = Hf;
        //    }
        //    else
        //    {
        //        AB.Sub_HighestWarpBreakages.Visible = false;
        //        AB.Sub_HighestWeftBreakages.Visible = false;
        //    }
        //    AB.DataSource = dAB;
        //    AB.EndInit();
        //    AB.ShowPreview();
        //}
        private void bbi_MakeViews_ItemClick(object sender, ItemClickEventArgs e)
        {
            int sIndex=-1;
            int eIndex=-1;
            string subString;
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            string stag = bbiItem.Tag.ToString();
            if (stag.Contains("CID[") == true)
            {
                sIndex = stag.IndexOf("CID[");
                eIndex = stag.IndexOf("]CID");
                if (eIndex != -1 && sIndex != -1)
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                else
                    subString = "";
                if (eIndex != -1 && sIndex != -1)
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in ShedClassicView)
                    {
                        if (f != null)
                        {
                            if (f.Name == "ShedClassicView" + subString)
                            {
                                f.MdiParent = this;
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }


                    ShedClassicView[Convert.ToInt32(subString)] = new Dashboard_Shed_Classic();

                    ShedClassicView[Convert.ToInt32(subString)].Name = "ShedClassicView" + subString;
                    ShedClassicView[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName + " Classic View";
                    ShedClassicView[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;
                    ShedClassicView[Convert.ToInt32(subString)].MdiParent = this;
                    ShedClassicView[Convert.ToInt32(subString)].BringToFront();
                    ShedClassicView[Convert.ToInt32(subString)].Show();
                    return;
                }
            }
            else if (stag.Contains("SID[") == true)
            {
                sIndex = stag.LastIndexOf("SID[");
                eIndex = stag.IndexOf("]SID");
                if (eIndex != -1 && sIndex != -1)
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                else
                    subString = "";
                if (eIndex != -1 && sIndex != -1)
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in ShedView)
                    {
                        if (f != null)
                        {
                            if (f.Name == "ShedView" + subString)
                            {
                                f.MdiParent = this;
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }


                    ShedView[Convert.ToInt32(subString)] = new Dashboard_Shed();

                    ShedView[Convert.ToInt32(subString)].Name = "ShedView" + subString;
                    ShedView[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName + " View";
                    ShedView[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;

                  
                    ShedView[Convert.ToInt32(subString)].MdiParent = this;
                    ShedView[Convert.ToInt32(subString)].BringToFront();
                    ShedView[Convert.ToInt32(subString)].Show();
                    return;
                }
            }

            else if (stag.Contains("DID[") == true)
            {
                sIndex = stag.LastIndexOf("DID[");
                eIndex = stag.IndexOf("]DID");
                if (eIndex != -1 && sIndex != -1)
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                else
                    subString = "";
                if (eIndex != -1 && sIndex != -1)
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in DigitalDisplay)
                    {
                        if (f != null)
                        {
                            if (f.Name == "DigitalView" + subString)
                            {
                               
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }


                    DigitalDisplay[Convert.ToInt32(subString)] = new Dashboard_DigitalDisplay();

                    DigitalDisplay[Convert.ToInt32(subString)].Name = "DigitalView" + subString;
                    DigitalDisplay[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName + " Digital View";
                    DigitalDisplay[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;
                    DigitalDisplay[Convert.ToInt32(subString)].BringToFront();
                    DigitalDisplay[Convert.ToInt32(subString)].Show();
                    return;
                }
            }
            else if (stag.Contains("SSD[") == true)
            {
                sIndex = stag.LastIndexOf("SSD[");
                eIndex = stag.IndexOf("]SSD");
                int shedTempIndex;
                int typeTempIndex;
                if (eIndex != -1 && sIndex != -1)
                {
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                    shedTempIndex = Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(subString);
                    if (shedTempIndex != -1)
                    {
                        sIndex = stag.LastIndexOf("TTD[");
                        eIndex = stag.IndexOf("]TTD");
                        if (sIndex != -1 && eIndex != -1)
                        {
                            subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                            typeTempIndex = Program.ss.Machines.PresentationData.Sheds[shedTempIndex].ReturnArrayIndex_Types(subString);
                            if (typeTempIndex != -1)
                            {

                                foreach (DevExpress.XtraEditors.XtraForm f in ShedMakeView)
                                {
                                    if (f != null)
                                    {
                                        if (f.Name == "ShedMakeView" + Program.ss.Machines.PresentationData.Sheds[shedTempIndex].TypesOfLooms[typeTempIndex].TypeID)
                                        {
                                            f.MdiParent = this;
                                            f.BringToFront();
                                            f.Show();
                                            return;
                                        }
                                    }
                                }


                                ShedMakeView[typeTempIndex] = new DashBoard_Shed_MakeView();

                                ShedMakeView[typeTempIndex].Name = "ShedMakeView" + Program.ss.Machines.PresentationData.Sheds[shedTempIndex].TypesOfLooms[typeTempIndex].TypeID;
                                ShedMakeView[typeTempIndex].Text = Program.ss.Machines.PresentationData.Sheds[shedTempIndex].TypesOfLooms[typeTempIndex].TypeName;
                                ShedMakeView[typeTempIndex].Tag = Program.ss.Machines.PresentationData.Sheds[shedTempIndex].TypesOfLooms[typeTempIndex].TypeID;
                                ShedMakeView[typeTempIndex].ShedIndex = shedTempIndex;
                                ShedMakeView[typeTempIndex].MakeIndex = typeTempIndex;
                                ShedMakeView[typeTempIndex].MdiParent = this;
                                ShedMakeView[typeTempIndex].BringToFront();
                                ShedMakeView[typeTempIndex].Show();


                              

                                return;
                               
                            }
                        }
                    }
                }
                //ShedMakeView[Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(stag.ToString())].ReturnArrayIndex_Types(bbiItem.Tag.ToString())].MdiParent = this;
                // ShedMakeView[Program.ss.Machines.PresentationData.ReturnArrayIndex_Types(bbiItem.Tag.ToString())].Show();
            }
        }

        private void bbi_ShedViews_ItemClick(object sender, ItemClickEventArgs e)
        {
            int sIndex = -1;
            int eIndex = -1;
            string subString;
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            string stag = bbiItem.Tag.ToString();
          
            if (stag.Contains("SID[") == true)
            {
                sIndex = stag.LastIndexOf("SID[");
                eIndex = stag.IndexOf("]SID");
                subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                if (eIndex != -1 && sIndex != -1)
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in ModelEff)
                    {
                        if (f != null)
                        {
                            if (f.Name == "ModelEff" + subString)
                            {
                                f.MdiParent = this;
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }

                  
                        ModelEff[Convert.ToInt32(subString)] = new Dashboard_ModelShedEff();
                        ModelEff[Convert.ToInt32(subString)].ShedIndex = Convert.ToInt32(subString);
                        ModelEff[Convert.ToInt32(subString)].Name = "ModelEff" + subString;
                        ModelEff[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName + " Summary View";
                        ModelEff[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;
                        ModelEff[Convert.ToInt32(subString)].MdiParent = this;
                        ModelEff[Convert.ToInt32(subString)].BringToFront();
                        ModelEff[Convert.ToInt32(subString)].Show();

                   
                       

              


      
                  
                

                    
                   
                }
            }

        }
        
        private void bbi_WeaversMainViews_ItemClick(object sender, ItemClickEventArgs e)
        {
            int sIndex = -1;
            int eIndex = -1;
            string subString;
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            string stag = bbiItem.Tag.ToString();

            if (stag.Contains("SID[") == true)
            {
                sIndex = stag.LastIndexOf("SID[");
                eIndex = stag.IndexOf("]SID");
                if (eIndex != -1 && sIndex != -1)
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                else
                    subString = "";
                if (eIndex != -1 && sIndex != -1 && subString!="")
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in WeaversMainView)
                    {
                        if (f != null)
                        {
                            if (f.Name == "WeaversMain" + subString)
                            {
                                f.MdiParent = this;
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }


                    WeaversMainView[Convert.ToInt32(subString)] = new DashBoard_WeaversMainView();
                    WeaversMainView[Convert.ToInt32(subString)].ShedIndex = Convert.ToInt32(subString);
                    WeaversMainView[Convert.ToInt32(subString)].Name = "WeaversMain" + subString;
                    WeaversMainView[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName;
                    WeaversMainView[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;
                    WeaversMainView[Convert.ToInt32(subString)].MdiParent = this;
                    WeaversMainView[Convert.ToInt32(subString)].BringToFront();
                    WeaversMainView[Convert.ToInt32(subString)].Show();













                }
            }

        }
        private void bbi_WeaversScrollViews_ItemClick(object sender, ItemClickEventArgs e)
        {
            int sIndex = -1;
            int eIndex = -1;
            string subString;
            BarButtonItem bbiItem = (BarButtonItem)e.Item;
            string stag = bbiItem.Tag.ToString();

            if (stag.Contains("SID[") == true)
            {
                sIndex = stag.LastIndexOf("SID[");
                eIndex = stag.IndexOf("]SID");
                if (eIndex != -1 && sIndex != -1)
                    subString = stag.Substring(sIndex + 4, eIndex - sIndex - 4);
                else
                    subString = "";
                if (eIndex != -1 && sIndex != -1 && subString != "")
                {
                    foreach (DevExpress.XtraEditors.XtraForm f in WeaversScrollView)
                    {
                        if (f != null)
                        {
                            if (f.Name == "WeaversScroll" + subString)
                            {
                                f.MdiParent = this;
                                f.BringToFront();
                                f.Show();
                                return;
                            }
                        }
                    }


                    WeaversScrollView[Convert.ToInt32(subString)] = new Dashboard_Weavers();
                    WeaversScrollView[Convert.ToInt32(subString)].ShedIndex = Convert.ToInt32(subString);
                    WeaversScrollView[Convert.ToInt32(subString)].Name = "WeaversMain" + subString;
                    WeaversScrollView[Convert.ToInt32(subString)].Text = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedName;
                    WeaversScrollView[Convert.ToInt32(subString)].Tag = Program.ss.Machines.PresentationData.Sheds[Convert.ToInt32(subString)].ShedID;
                    WeaversScrollView[Convert.ToInt32(subString)].MdiParent = this;
                    WeaversScrollView[Convert.ToInt32(subString)].BringToFront();
                    WeaversScrollView[Convert.ToInt32(subString)].Show();













                }
            }


        }
        private void repositoryItemButton_LoomTop_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
           
        }

        private void barAssign_SetTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {


                int loomindex = 0;// Program.ss.Machines.ReturnArrayIndex_Loom(LoomName);
                if (loomindex == -1)
                {
                    XtraMessageBox.Show("Loom Name is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (CurrentSelection.SelectedView is Dashboard_Shed)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.y = Program.ss.Machines.Looms[loomindex].Drawing.y;
                    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[loomindex].Drawing.y);
                }
                else if (CurrentSelection.SelectedView is Dashboard_DigitalDisplay)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DisplayY = Program.ss.Machines.Looms[loomindex].Drawing.DisplayY;
                    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[loomindex].Drawing.DisplayY);
                }
                else if (CurrentSelection.SelectedView is Dashboard_Shed_Classic)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.y = Program.ss.Machines.Looms[loomindex].Drawing.y;

                    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[loomindex].Drawing.y);
                }
                else if (CurrentSelection.SelectedView is DashBoard_Shed_MakeView)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DrawMakeY = Program.ss.Machines.Looms[loomindex].Drawing.DrawMakeY;

                    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[loomindex].Drawing.DrawMakeY);
                }
            }
            catch
            {
            }
        }

        private void bbi_SetLoomLeftRef_ItemClick(object sender, ItemClickEventArgs e)
        {
            bbi_SetLoomLeft.Caption = "Set Loom Left Position  as Loom #  " + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName;
            bbi_SetLoomLeft.Tag = CurrentSelection.LoomIndex.ToString();



        }

        private void bbi_SetLoomTopRef_ItemClick(object sender, ItemClickEventArgs e)
        {
            bbi_SetLoomTop.Caption = "Set Loom Top Position  as Loom #  " + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.LoomName;
            bbi_SetLoomTop.Tag = CurrentSelection.LoomIndex.ToString();
        }

        private void bbi_SetLoomLeft_ItemClick(object sender, ItemClickEventArgs e)
        {


            if (bbi_SetLoomLeft.Tag == null) return;
            if (bbi_SetLoomLeft.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                CurrentSelection.SelectedControl.Left = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.x);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.x = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.x;

            }
            else if (CurrentSelection.SelectedView is Dashboard_DigitalDisplay)
            {
                CurrentSelection.SelectedControl.Left = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.DisplayX);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DisplayX = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.DisplayX;
            }
            else if (CurrentSelection.SelectedView is Dashboard_Shed_Classic)
            {
                CurrentSelection.SelectedControl.Left = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.x);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.x = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.x;
            }
            else if (CurrentSelection.SelectedView is DashBoard_Shed_MakeView)
            {
                CurrentSelection.SelectedControl.Left = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.DrawMakeX);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DrawMakeX = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomLeft.Tag.ToString())].Drawing.DrawMakeX;
            }
        }

        private void bbi_SetLoomTop_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bbi_SetLoomTop.Tag == null) return;
            if (bbi_SetLoomTop.Tag.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.y = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y;

            }
            else if (CurrentSelection.SelectedView is Dashboard_Shed_Classic)
            {
                CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.y = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y;
            }
            else if (CurrentSelection.SelectedView is DashBoard_Shed_MakeView)
            {
                CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.DrawMakeY);
                Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DrawMakeY = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.DrawMakeY;
            }
        }

        private void bbi_Dashboard_ArticleEfficiency_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(ArticleScrollView ==null)
            ArticleScrollView = new View.Dashboard_ArticleEfficiency_ScrollView();
            ArticleScrollView.MdiParent = this;
            ArticleScrollView.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void bbi_Data_AssignLoom_CurrentLoomInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Info.shortStopInfo sinfo = new Info.shortStopInfo();
            sinfo.ShowDialog(this);
        }

       

        private void mYarnData_Counts_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_CountManagement param = new MachineEyes.Data.Data_CountManagement();
            param.MdiParent = this;
            param.Show();
        }

        private void mYarnData_Brands_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn Brands", "YarnBrand", "PP_YarnBrands");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mYarnData_Blends_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn Blends", "YarnBlend", "PP_YarnBlend");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_Twsits_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn Twist", "YarnTwist", "PP_YarnTwist");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void mYarnData_PaperConeColors_ItemClick(object sender, ItemClickEventArgs e)
        {

            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn paper Cone Color", "PaperConeColor", "PP_YarnPaperConeColors");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_YarnContract_ItemClick(object sender, ItemClickEventArgs e)
        {
           

        }

        private void mYarnData_GRN_ItemClick_1(object sender, ItemClickEventArgs e)
        {
           
           
        }

        private void mYarnData_GIN_ItemClick(object sender, ItemClickEventArgs e)
        {
           // Ma//chineEyes.Data.Data_YarnGRN DataYarnGRN = new Data.Data_YarnGRN();
           // DataYarnGRN.mDocumentType = MachineEyes.Data.Data_YarnGRN.DocumentType.GIN;
           // DataYarnGRN.Text = "Goods Issue Note";
           // DataYarnGRN.MdiParent = this;
           // DataYarnGRN.Show();
        }

        private void mYarnData_ConeWeight_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Cone Weight", "YarnConeWeight", "PP_YarnConeWeight");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mDataMisc_Employees_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Emp Employees = new Data_Emp();
            Employees.MdiParent = this;
            Employees.Show();
        }

        private void mDataMisc_Departments_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_Emp_Dept Employees_Dept = new Data_Emp_Dept();
            Employees_Dept.MdiParent = this;
            Employees_Dept.Show();
        }

        private void mDataMisc_Accounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_Accounts Accounts = new Data.Data_Accounts();
            Accounts.MdiParent = this;
            Accounts.Show();

        }

        private void mDataMisc_Designations_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void mYarnData_ConesPerBag_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Number of Cones per Bag", "YarnConesPerBag", "PP_YarnConesPerBag");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_LbsPerBag_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Weight (Lbs) Per Bag", "YarnLbsPerBag", "PP_YarnLbsPerBag");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_CottonOrigin_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Cotton Origin(s)", "YarnCottonOrigin", "PP_YarnCottonOrigins");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_YarnDesc_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn Description(s)", "YarnDesc", "PP_YarnDesc");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mDataMisc_DeliveryTerms_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Delivery Terms", "DeliveryTerms", "PP_DeliveryTerms");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mDataMisc_PaymentTerms_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Payment Terms", "PaymentTerms", "PP_Paymentterms");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gddFont_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            FontConverter cr = new FontConverter();
            int fsize = 12;
            if (FontSizeControl.EditValue != null)
            {
                int.TryParse(FontSizeControl.EditValue.ToString(), out fsize);

            }
            Font f=new Font(e.Item.Hint,fsize);

            if (CurrentSelection.CurrentSelectionMode == SelectionMode.EfficiencyFont)
            {
                 
                
                for (int x = 0; x < this.ShedView[0].panelControl1.Controls.Count; x++)
                {

                    Control uictr = this.ShedView[0].panelControl1.Controls[x];
                    if (uictr is dxLoom)
                    {
                        dxLoom uiLoom = (dxLoom)uictr;
                        uiLoom.Efficiency.Font  = f;
                        
                    }
                }
               
            }
            else if (ControlMoverOrResizer.ControlsAreInResizeMode == true)
            {
                if (CurrentSelection.LoomIndex != -1)
                {
                    if (CurrentSelection.SelectedControl != null)
                    {
                        dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;
                        if (LoomX.SelectedButton != null)
                        {
                            LoomX.SelectedButton.Font = f;
                        }
                    }
                }
            }
        }

        private void bbi_Tools_EffFont_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (bbi_Tools_EffFont.Down == true)
            {
                CurrentSelection.CurrentSelectionMode = SelectionMode.EfficiencyFont;
            }
            else
                CurrentSelection.CurrentSelectionMode = SelectionMode.NoSelection;

        }

        private void bbi_Data_AssignLoom_CurrentLoomStats_ItemClick(object sender, ItemClickEventArgs e)
        {
           // MachineEyes.Info.CurrentStatistics MachineStats = new Info.CurrentStatistics();
           // MachineStats.ShowDialog(this);
            if (CurrentSelection.LoomIndex == -1) return;
            Data.Data_AboutLoom AboutLoom = new Data.Data_AboutLoom();
            AboutLoom.LoomIndex = CurrentSelection.LoomIndex;
            AboutLoom.ShowDialog();
        }

        private void rgbiFont_GalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            FontConverter cr = new FontConverter();
            int fsize = 12;
            if (FontSizeControl.EditValue != null)
            {
                int.TryParse(FontSizeControl.EditValue.ToString(), out fsize);
            }
            Font f = new Font(e.Item.Hint, fsize);

            if (CurrentSelection.CurrentSelectionMode == SelectionMode.EfficiencyFont)
            {


                for (int x = 0; x < this.ShedView[0].panelControl1.Controls.Count; x++)
                {

                    Control uictr = this.ShedView[0].panelControl1.Controls[x];
                    if (uictr is dxLoom)
                    {
                        dxLoom uiLoom = (dxLoom)uictr;
                        uiLoom.Efficiency.Font = f;

                    }
                }

            }
            else if (ControlMoverOrResizer.ControlsAreInResizeMode == true)
            {
                if (CurrentSelection.LoomIndex != -1)
                {
                    if (CurrentSelection.SelectedControl != null)
                    {
                        dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;
                        if (LoomX.SelectedButton != null)
                        {
                            LoomX.SelectedButton.Font = f;
                        }
                    }
                }
            }
        }

        private void bbi_Dashboard_ExecutiveSummary_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (ExecutiveSummary == null)
                ExecutiveSummary = new View.Dashboard_Executive();
                ExecutiveSummary.Show();
                ExecutiveSummary.BringToFront();
          
        }

        private void mDataMisc_WHT_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "With Holding Tax", "WHT", "PP_WHT");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mYarnData_LedgerGRN_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void mYarn_GRNGINStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn GRN GIN Status", "YarnGRNGINStatus", "PP_YarnGRNGINStatus");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void PGB_ArticleChangeSheet_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Data_ArticleChangeSheet ArticleChangeSheet = new Data.Data_ArticleChangeSheet();
            ArticleChangeSheet.MdiParent = this;
            ArticleChangeSheet.Show();
        }

        private void YarnContract_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnContract DataYarnContract = new Data.Data_YarnContract();
            DataYarnContract.MdiParent = this;
            DataYarnContract.Show();
        }

        private void YarnReceiveNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_ReceiveNote RN = new Yarn.Yarn_ReceiveNote();
            RN.MdiParent = this;
            RN.Show();
            //MachineEyes.Data.Data_YarnGRN_New YarnGRN = new Data.Data_YarnGRN_New();
            //YarnGRN.MdiParent = this;
            //YarnGRN.Show();
           // MachineEyes.Yarn.Yarn_GRN GRN = new Yarn.Yarn_GRN();
          
        }

        private void YarnIssueNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_IssueNote GIN = new Yarn.Yarn_IssueNote();
            GIN.MdiParent = this;
            GIN.Show();
        }

      

        private void Accounts_ChartofAccountsTree_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_ChartofAccount ChartofAccounts = new Accounts.Accounts_ChartofAccount();
            ChartofAccounts.MdiParent = this;
            ChartofAccounts.Show();
        }

        private void bbi_Data_AssignLoom_Article_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Data_Assign_ArticleOnLoom AssignArticle = new Data.Data_Assign_ArticleOnLoom();
            AssignArticle.ShowDialog();
        }

        private void bbi_Data_Loom_Log_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            LDS.ReportingParameters.xu_MachineLog MachineLog = new LDS.ReportingParameters.xu_MachineLog();

            Report.reportControlParent.Size = MachineLog.Size;
            Report.Size = MachineLog.Size;
            Report.reportControlParent.Controls.Add(MachineLog);
            Report.Show();
        }

        private void Refresh_Accounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            RefreshAccountingParams();
        }
        public void RefreshAccountingParams()
        {
            Cursor currentCursor = Cursor.Current;
            try
            {

                Cursor.Current = Cursors.WaitCursor;
                MachineEyes.Classes.Accounting.Load_Accounts();
               
                MachineEyes.Classes.Accounting.Load_PurchaseTypes();
                MachineEyes.Classes.Accounting.Load_SalesTypes();
                MachineEyes.Classes.Accounting.Load_RegisteredAccounts();
                MachineEyes.Classes.Accounting.Load_MappedAccounts();
                Cursor.Current = currentCursor;
            }
            catch (Exception ex)
            {
                Cursor.Current = currentCursor;
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Accounts_CashPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_CashPayment CashPayment = new Accounts.Accounts_Voucher_CashPayment();
            CashPayment.MdiParent = this;
            CashPayment.Show();
        }

        private void bbi_Data_Assign_DNI_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI == false)
            {
                bool res = WS.svc.UpdateLoom_ForceDNI(CurrentSelection.LoomIndex, true);
                if (res == true)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI= true;
                    bbi_Data_Assign_FDNI.Caption = "Include into Running Efficiency";
                    bbi_Data_Assign_FDNI.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI.ToString();
                }
                

            }
            else if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI == true)
            {
                bool res = WS.svc.UpdateLoom_ForceDNI(CurrentSelection.LoomIndex, false);
                if (res == true)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI = false;
                    bbi_Data_Assign_FDNI.Caption = "Exclude from Running Efficiency";
                    bbi_Data_Assign_FDNI.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNI.ToString();
                }


            }

        }

        private void Accounts_FabricSales_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_SalesInvoice SalesInvoice = new Accounts.Accounts_SalesInvoice();
            SalesInvoice.MdiParent = this;
            SalesInvoice.Show();
        }

        private void Accounts_GeneralLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.Ledger GeneralLedger = new Accounts.ReportingParameters.Ledger();
            GeneralLedger.ShowDialog();
        }

        private void bbi_Data_AssignLoom_FDNE_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE == false)
            {
                bool res = WS.svc.UpdateLoom_ForceDNE(CurrentSelection.LoomIndex, true);
                if (res == true)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE = true;
                    bbi_Data_AssignLoom_FDNE.Caption = "Leave at Auto include / exclude";
                    bbi_Data_AssignLoom_FDNE.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE.ToString();
                }


            }
            else if (Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE == true)
            {
                bool res = WS.svc.UpdateLoom_ForceDNE(CurrentSelection.LoomIndex, false);
                if (res == true)
                {
                    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE = false;
                    bbi_Data_AssignLoom_FDNE.Caption = "Force include into Running Efficiency";
                    bbi_Data_AssignLoom_FDNE.Tag = Program.ss.Machines.Looms[CurrentSelection.LoomIndex].CurrentParams.FDNE.ToString();
                }


            }
        }

        private void Accounts_BankPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_BankPayment BankPayment = new Accounts.Accounts_Voucher_BankPayment();
            BankPayment.MdiParent = this;
            BankPayment.Show();
        }

        private void Accounts_CashReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_CashReceipt CashReceipt = new Accounts.Accounts_Voucher_CashReceipt();
            CashReceipt.MdiParent = this;
            CashReceipt.Show();

        }

        private void Accounts_BankReceipt_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_BankReceipt BankReceipt = new Accounts.Accounts_Voucher_BankReceipt();
            BankReceipt.MdiParent = this;
            BankReceipt.Show();
        }

        private void Accounts_GeneralVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_General GeneralVoucher = new Accounts.Accounts_Voucher_General();
            GeneralVoucher.MdiParent = this;
            GeneralVoucher.Show();
        }

        private void Accounts_PeriodicTrialBalance_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.TrialBalancePeriodic TB = new Accounts.ReportingParameters.TrialBalancePeriodic();
            TB.Show();
        } 

        private void Company_ItemClick(object sender, ItemClickEventArgs e)
        {
            SuperToolTip stp = new SuperToolTip();
            stp.Items.Clear();
            stp.Items.Add("Company : " + Program.ss.Machines.PresentationData.CPInfo.cpName);
            stp.Items.AddSeparator();
            stp.Items.Add("Address: " + Program.ss.Machines.PresentationData.CPInfo.cpAddress + "\nPhone: " + Program.ss.Machines.PresentationData.CPInfo.cpPhone + "\nFax: " + Program.ss.Machines.PresentationData.CPInfo.cpFAX + "\nE-Mail: " + Program.ss.Machines.PresentationData.CPInfo.cpEmail + "\nNTN # " + Program.ss.Machines.PresentationData.CPInfo.cpNTN + " GST # " + Program.ss.Machines.PresentationData.CPInfo.cpSTN);
            stp.Items.AddSeparator();
            Company.SuperTip = stp;
        }

        private void Accounts_OpeningBalances_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_Opening Opening = new Reports.Accounts_Opening();



            string query = "SELECT * from Accounts_Vouchers_Opening where vnumber in(select vnumber from AC_Voucher_Main where vYear='" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "' and vType in('000'))";
            DataSet ds = WS.svc.Get_DataSet(query);



            //Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            //Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            //Ledger.xr_Accountof.Text = this.AccountID.Text;
            // Ledger.xr_AccountofName.Text = this.AccountName.Text;
            //ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString("s") + "' and vDate<='" + ToDate.DateTime.ToString("s") + "' ");
            Opening.BeginInit();
            Opening.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;

            Opening.RepH_DocumentName.Text = "Opening Balances [G]";
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Opening.DataSource = ds;
                else
                    Opening.DataSource = null;
            }
            else
                Opening.DataSource = null;
            Opening.EndInit();
            Opening.ShowPreview();
        }

        private void Accounts_DailyCashAndBankTransactionReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_DailyCashAndBank DailycashReport = new Accounts.ReportingParameters.xu_DailyCashAndBank();
            Report.reportControlParent.Size = DailycashReport.Size;
            Report.Size = DailycashReport.Size;
            Report.reportControlParent.Controls.Add(DailycashReport);
            Report.Show();
        }

        private void Accounts_AuditTrailReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_AuditTrail dailyAudit = new Accounts.ReportingParameters.xu_AuditTrail();
            Report.reportControlParent.Size = dailyAudit.Size;
            Report.Size = dailyAudit.Size;
            Report.reportControlParent.Controls.Add(dailyAudit);
            Report.Show();
        }

        private void Accounts_SalesReturnFabric_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_SalesInvoiceReturn Return = new Accounts.Accounts_SalesInvoiceReturn();
            Return.MdiParent = this;
            Return.Show();
        }

        private void Accounts_Generalledger_AI_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_Contraledger gl_ai = new Accounts.ReportingParameters.xu_Contraledger();
            gl_ai.Account_IV = MachineEyes.Classes.Accounting.RegAccounts.Cash_IV;
            gl_ai.LedgerType.Text = "General Ledger (AI) Cash";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void Accounts_Generalledger_AI_Bank_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_Contraledger gl_ai = new Accounts.ReportingParameters.xu_Contraledger();
            gl_ai.Account_IV = MachineEyes.Classes.Accounting.RegAccounts.Bank_IV;
            gl_ai.LedgerType.Text = "General Ledger (AI) Bank";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void Accounts_OpeningBalances_N_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_Opening Opening = new Reports.Accounts_Opening();



            string query = "SELECT * from Accounts_Vouchers_Opening where vnumber in(select vnumber from AC_Voucher_Main where vYear='" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "' and vType in('001'))";
            DataSet ds = WS.svc.Get_DataSet(query);



            //Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            //Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            //Ledger.xr_Accountof.Text = this.AccountID.Text;
            // Ledger.xr_AccountofName.Text = this.AccountName.Text;
            //ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString("s") + "' and vDate<='" + ToDate.DateTime.ToString("s") + "' ");
            Opening.BeginInit();
            Opening.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;

            Opening.RepH_DocumentName.Text = "Opening Balances [N]";
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Opening.DataSource = ds;
                else
                    Opening.DataSource = null;
            }
            else
                Opening.DataSource = null;
            Opening.EndInit();
            Opening.ShowPreview();
        }

        private void Accounts_OpeningBalances_B_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_Opening Opening = new Reports.Accounts_Opening();



            string query = "SELECT * from Accounts_Vouchers_Opening where vnumber in(select vnumber from AC_Voucher_Main where vYear='" + MachineEyes.Classes.Accounting.RegAccounts.FinancialYear + "' and vType in('000','001'))";
            DataSet ds = WS.svc.Get_DataSet(query);



            //Ledger.xr_FromDate.Text = this.FromDate.DateTime.ToLongDateString();
            //Ledger.xr_ToDate.Text = this.ToDate.DateTime.ToLongDateString();
            //Ledger.xr_Accountof.Text = this.AccountID.Text;
            // Ledger.xr_AccountofName.Text = this.AccountName.Text;
            //ds = WS.svc.Get_DataSet("Select * from Accounts_Vouchers where AccountID_V='" + this.AccountID.Text + "' and vDate>='" + FromDate.DateTime.ToString("s") + "' and vDate<='" + ToDate.DateTime.ToString("s") + "' ");
            Opening.BeginInit();
            Opening.FinancialYear.Text = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
            Opening.RepH_DocumentName.Text = "Opening Balances [B]";
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Opening.DataSource = ds;
                else
                    Opening.DataSource = null;
            }
            else
                Opening.DataSource = null;
            Opening.EndInit();
            Opening.ShowPreview();
        }

        private void Accounts_STAnnexC_ItemClick(object sender, ItemClickEventArgs e)
        {

            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_AnnexC AnC = new Accounts.ReportingParameters.xu_AnnexC();
            Report.reportControlParent.Size = AnC.Size;
            Report.Size = AnC.Size;
            Report.reportControlParent.Controls.Add(AnC);
            Report.Show();

        }

        private void Accounts_YarnPurchases_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Accounts.Accounts_PurchasesYarn yarnPurchases = new Accounts.Accounts_PurchasesYarn();
            yarnPurchases.MdiParent = this;
            yarnPurchases.Show();
        }

        private void Accounts_FabricPurchases_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesFabric FabricPurchases = new Accounts.Accounts_PurchasesFabric();
            FabricPurchases.MdiParent = this;
            FabricPurchases.Show();
        }

        private void Accounts_OtherPurchases_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesOthers OtherPurchases = new Accounts.Accounts_PurchasesOthers();
            OtherPurchases.MdiParent = this;
            OtherPurchases.Show();
        }

        private void PGB_Employees_Employee_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Data_Emp");
            if (OpenedForm == null)
            {
                Data_Emp Employee = new Data_Emp();
                Employee.MdiParent = this;
                Employee.Show();
            }
            else
                OpenedForm.Show();
        }

        private void PGB_Employees_Departments_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Data_Emp_Dept");
            if (OpenedForm == null)
            {
                Data_Emp_Dept Department = new Data_Emp_Dept();
                Department.MdiParent = this;
                Department.Show();
            }
            else
                OpenedForm.Show();
        }

        private void PGB_Employees_Designations_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void bbiUsersandRights_ItemClick(object sender, ItemClickEventArgs e)
        {
            Security.Security_Users Users = new Security.Security_Users();
            Users.MdiParent = this;
            Users.Show();
        }

        private void bbiExitMachineEyesERP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Settings.Exit = true;

           
            MachineEyes.Data.frmWait Wait = new Data.frmWait();
            Wait.ShowDialog();

        }

        private void bbiChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            Security.Security_ChangePassword ChangePassword = new Security.Security_ChangePassword();
            ChangePassword.ShowDialog();
        }

        private void bbiCurrentSession_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Security_Sessions");
            if (OpenedForm == null)
            {
                Security.Security_Sessions S = new Security.Security_Sessions();
                S.MdiParent = this;
                S.Show();
            }
            else
                OpenedForm.Show();
        }

        private void Accounts_STAnnexA_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_AnnexA AnA = new Accounts.ReportingParameters.xu_AnnexA();
            Report.reportControlParent.Size = AnA.Size;
            Report.Size = AnA.Size;
            Report.reportControlParent.Controls.Add(AnA);
            Report.Show();
        }

        private void Accounts_ConsolidatedLedger_IV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_ConsolidatedLedger gl_ai = new Accounts.ReportingParameters.xu_ConsolidatedLedger();
            gl_ai.AccountLevel = "4";
            gl_ai.LedgerType.Text = "Consolidated Ledger Level IV";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void Accounts_ConsolidatedLedger_III_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_ConsolidatedLedger gl_ai = new Accounts.ReportingParameters.xu_ConsolidatedLedger();
            gl_ai.AccountLevel = "3";
            gl_ai.LedgerType.Text = "Consolidated Ledger Level III";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void Accounts_ConsolidatedLedger_II_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_ConsolidatedLedger gl_ai = new Accounts.ReportingParameters.xu_ConsolidatedLedger();
            gl_ai.AccountLevel = "2";
            gl_ai.LedgerType.Text = "Consolidated Ledger Level II";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void Accounts_ConsolidatedLedger_I_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_ConsolidatedLedger gl_ai = new Accounts.ReportingParameters.xu_ConsolidatedLedger();
            gl_ai.AccountLevel = "1";
            gl_ai.LedgerType.Text = "Consolidated Ledger Level I";
            Report.reportControlParent.Size = gl_ai.Size;
            Report.Size = gl_ai.Size;
            Report.reportControlParent.Controls.Add(gl_ai);
            Report.Show();
        }

        private void bbi_Tool_ClassicViewColors_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.View.Dashboard_Colors ColorSettings = new View.Dashboard_Colors();
            ColorSettings.MdiParent = this;
            ColorSettings.Show();
        }

        private void Accounts_PurchasesFabric_Return_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesFabricReturn fabricreturn = new Accounts.Accounts_PurchasesFabricReturn();
            fabricreturn.MdiParent = this;
            fabricreturn.Show();
        }

        private void Contracts_Sales_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void Accounts_SalesSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void Accounts_SalesSummary_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_SalesSummary summary = new Accounts.ReportingParameters.xu_SalesSummary();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

       

        private void bbi_Tools_SMSSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMS.SMS_Contacts SMSContactsManagement = new SMS.SMS_Contacts();
            SMSContactsManagement.MdiParent = this;
            SMSContactsManagement.Show();
        }

        private void ClassicalCheck_Efficiency_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.EfficiencyView;
        }

        private void ClassicalCheck_RPMView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.RPMView;
        }

        private void ClassicalCheck_WarpView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.WarpCounterView;
        }

        private void ClassicalCheck_WeftView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.WeftCounterView;
        }

        private void ClassicalCheck_WarpKnottView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.WarpKnottView;
        }

        private void ClassicalCheck_WeftKnottView_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            Settings.CurrentClassicalView = ClassicalViewType.WeftKnottView;
        }

        private void Accounts_FilteredAuditTrailReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_PostedUnpostedVouchers dailyAudit = new Accounts.ReportingParameters.xu_PostedUnpostedVouchers();
            Report.reportControlParent.Size = dailyAudit.Size;
            Report.Size = dailyAudit.Size;
            Report.reportControlParent.Controls.Add(dailyAudit);
            Report.Show();
        }

       

        private void Accounts_SalesTaxRegister_Article_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_SalesTaxRegister_FilterArticle summary = new Accounts.ReportingParameters.xu_SalesTaxRegister_FilterArticle();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Accounts_SalesRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_SalesRegister_FilterParty summary = new Accounts.ReportingParameters.xu_SalesRegister_FilterParty();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void ValidateMoreSecure_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                foreach (object c in Program.MainWindow.ribbonControl1.Items)
                {
                    string s = c.GetType().Name;
                    if (c.GetType().Name == "BarButtonItem")
                    {

                        BarButtonItem bbi = (BarButtonItem)c;
                        string GroupID = MachineEyes.Classes.Security.GetGroupID(bbi.Description);
                        string res = WS.svc.Execute_Query("Insert into PP_SecurityItems ( iUniqueName, iUniqueCaption, iDescription,iUniqueGroupID) values('" + bbi.Name + "','" + bbi.Caption + "','" + bbi.Description + "','" + GroupID + "')");
                        if (res != "**SUCCESS##")
                        {
                            //XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Accounts_STAnnexIDebitNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_AnnexI_DebitNote summary = new Accounts.ReportingParameters.xu_AnnexI_DebitNote();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Accounts_AnnexICreditNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_AnnexI_CreditNote summary = new Accounts.ReportingParameters.xu_AnnexI_CreditNote();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Debug_ConnectedCoorindators_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Debug_SinkClients");
            if (OpenedForm == null)
            {
                Debug.Debug_SinkClients SinkList = new Debug.Debug_SinkClients();
                SinkList.MdiParent = this;
                SinkList.Show();
            }
            else
                OpenedForm.Show();
        }

        private void Debug_LoomsWindow_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Debug_Looms");
            if (OpenedForm == null)
            {
                Debug.Debug_Looms LoomsList = new Debug.Debug_Looms();
                LoomsList.MdiParent = this;
                LoomsList.Show();
            }
            else
                OpenedForm.Show();
        }

        private void Debug_WirelessDevices_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Debug_Devices");
            if (OpenedForm == null)
            {
                Debug.Debug_Devices DevicesList = new Debug.Debug_Devices();
                DevicesList.MdiParent = this;
                DevicesList.Show();
            }
            else
                OpenedForm.Show();
        }

        private void Accounts_WeavingPNLAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_PNL_Weaving_All PNL = new Reports.Accounts_PNL_Weaving_All();
            PNL.BeginInit();
            PNL.Init_PNL();
            PNL.EndInit();
            PNL.ShowPreview();
        }

        private void Accounts_PaymentAdvice_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PaymentAdvice PaymentAdvice = new Accounts.Accounts_PaymentAdvice();
            PaymentAdvice.MdiParent = this;
            PaymentAdvice.Show();
        }

      
       

      

        private void SW_ProgramSheet_ItemClick(object sender, ItemClickEventArgs e)
        {
            WarpingSizing.Warping_ProgramSheet ProgramSheet = new WarpingSizing.Warping_ProgramSheet();
            ProgramSheet.MdiParent = this;
            ProgramSheet.Show();
        }

        private void Planning_ProgramSheet_ItemClick(object sender, ItemClickEventArgs e)
        {
            WarpingSizing.Warping_ProgramSheet ProgramSheet = new WarpingSizing.Warping_ProgramSheet();
            ProgramSheet.MdiParent = this;
            ProgramSheet.Show();
        }

        private void bbiALUGPU_ItemClick(object sender, ItemClickEventArgs e)
        {
            Security.Authenticity Auth = new Security.Authenticity();
            Auth.ShowDialog();
        }

        private void bbi_Data_Article_FabricName_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_YarnFabricParameters param = new Data_YarnFabricParameters();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Fabric Names", "FabricName", "PP_ArticleFabricNames");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiGotoFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.View_FilterView FilterView = new View_FilterView();
            FilterView.MdiParent = this;
           
            FilterView.Show();
        }

        private void ButtonFuction_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineService.smsPending sP = new MachineService.smsPending();
            sP = WS.svc.SMS_GetPendings(1);

        }

        private void Efficiency_ArticleEfficiencyReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.Efficiency_ArticleReport yru_itemledger = new Yarn.ReportingParameters.Efficiency_ArticleReport();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void Efficiency_MonthlyProductionLoss_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.Efficiency_MonthlyProductionLossReport yru_itemledger = new Yarn.ReportingParameters.Efficiency_MonthlyProductionLossReport();
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void Efficiency_QualityWiseProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.Efficiency_ArticleWiseProduction yru_itemledger = new Yarn.ReportingParameters.Efficiency_ArticleWiseProduction();
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void Inspection_DailyInspection_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeInspection Primary = new InspectionDelivery.Godown_GreigeInspection();
            Primary.MdiParent = this;
            Primary.Show();
        }

        private void ReportsDailyInspection_DailyInspectionQualityWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.IP_DailyInspectionQualityWise yru_itemledger = new Yarn.ReportingParameters.IP_DailyInspectionQualityWise();
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

       

      

        private void Efficiency_ShedLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            LDS.ReportingParameters.xu_ShedLog MachineLog = new LDS.ReportingParameters.xu_ShedLog();

            Report.reportControlParent.Size = MachineLog.Size;
            Report.Size = MachineLog.Size;
            Report.reportControlParent.Controls.Add(MachineLog);
            Report.Show();
        }

        private void ReportsDailyInspection_DailyStockQualityWise_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            Reports.Inspection_StockQualityWise Stockreport = new Reports.Inspection_StockQualityWise();

            //AB.ShedIndex = ShedIndex;
           
            Stockreport.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Stockreport.Dated.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            string dsstring = "SELECT     ArticleShortName,sum(case when Grade='A' and Delivered=0 then Meters else 0 end) as A_Meters,sum(case when Grade='A' and Delivered=0 then 1 else 0 end) as A_Bales,sum(case when Grade='B' and Delivered=0 then Meters else 0 end) as B_Meters,sum(case when Grade='B' and Delivered=0 then 1 else 0 end) as B_Bales,sum(case when Grade='C' and Delivered=0 then Meters else 0 end) as C_Meters,sum(case when Grade='C' and Delivered=0 then 1 else 0 end) as C_Bales,sum(case when Grade='SP' and Delivered=0 then Meters else 0 end) as SP_Meters,sum(case when Grade='SP' and Delivered=0 then 1 else 0 end) as SP_Bales,sum(case when Grade='CP' and Delivered=0 then Meters else 0 end) as CP_Meters,sum(case when Grade='CP' and Delivered=0 then 1 else 0 end) as CP_Bales from RIP_DailyInspectionWithDetails group by ArticleShortName order by ArticleShortName";
            Stockreport.BeginInit();
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                DataTable dstable = ds.Tables[0];

                EnumerableRowCollection<DataRow> query = from table1 in dstable.AsEnumerable()
                                                         where table1.Field<decimal>("A_Meters") > 0 || table1.Field<decimal>("B_Meters") > 0 || table1.Field<decimal>("C_Meters") > 0 || table1.Field<decimal>("CP_Meters") > 0 || table1.Field<decimal>("SP_Meters")>0
                                                         select table1;

                DataView view = query.AsDataView();
                Stockreport.DataSource = view;
            }
            else
                Stockreport.DataSource = null;


            Stockreport.EndInit();
            Stockreport.ShowPreview();
            
        }

        private void AccountsTrialBalancesSumBalances_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_PeriodicTrialBalanceFinalBalances cReport = new Accounts.ReportingParameters.xu_PeriodicTrialBalanceFinalBalances();
            Report.reportControlParent.Size = cReport.Size;
            Report.Size = cReport.Size;
            Report.reportControlParent.Controls.Add(cReport);
            Report.Show();
        }

        private void AccountsTrialBalanceConsolidated_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_TrialBalanceConsolidated cReport = new Accounts.ReportingParameters.xu_TrialBalanceConsolidated();
            Report.reportControlParent.Size = cReport.Size;
            Report.Size = cReport.Size;
            Report.reportControlParent.Controls.Add(cReport);
            Report.Show();
        }

       

        private void Accounts_TrialBalanceEnding_ItemClick(object sender, ItemClickEventArgs e)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Accounts_TrialBalanceEnding TrialBalance = new Reports.Accounts_TrialBalanceEnding();
            string query = "SELECT     AccountID_IV,AccountName_IV,AccountID_V, AccountName_V,SUM(vDebitAmount) -SUM(vCreditAmount) AS eDebit,SUM(vCreditAmount)-SUM(vDebitAmount) as eCredit " +
                     " FROM  dbo.Accounts_Vouchers where vDate<='"+SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern)+"' GROUP BY AccountID_IV,AccountName_IV,AccountID_V, AccountName_V order by AccountID_V,AccountID_IV";
            //string query = "SELECT     AccountID_V, AccountName_V,SUM(vDebitAmount) AS eDebit,SUM(vCreditAmount) as eCredit,SUM(vDebitAmount)-SUM(vCreditAmount) as eBalance " +
            //      " FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_V, AccountName_V order by AccountID_V";
            DataSet ds = WS.svc.Get_DataSet(query);
            TrialBalance.BeginInit();
            TrialBalance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            
            TrialBalance.NGB.Text = "B";
            TrialBalance.DataSource = ds;
            TrialBalance.EndInit();
            TrialBalance.ShowPreview();
        }

        private void Inspection_TakeTowelToGodown_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.InspectionDelivery.Godown_TowelTakeToGodown Filter = new InspectionDelivery.Godown_TowelTakeToGodown();
            Filter.MdiParent = this;
            Filter.Show();
        }

        private void Production_OutSideSizing_ItemClick(object sender, ItemClickEventArgs e)
        {
            WarpingSizing.SW_OutSideSizing OutSideSizing = new WarpingSizing.SW_OutSideSizing();
            OutSideSizing.MdiParent = this;
            OutSideSizing.Show();
        }

        private void Button_StoreAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_Accounts NewAccount = new Store.Store_Accounts();
            NewAccount.MdiParent = this;
            NewAccount.Show();
        }

        private void Button_PurchaseOrderStore_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_PurchaseOrder PurchaseOrder = new Store.Store_PurchaseOrder();
            PurchaseOrder.MdiParent = this;
            PurchaseOrder.Show();
        }

        private void ReportButton_StoreAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            string query = "select * from RST_ItemAccounts order by ControlAccountID,GroupAccountID,ItemAccountID";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds == null)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;

            }
            Reports.Store_ItemAccounts Items = new Reports.Store_ItemAccounts();
           
            Items.BeginInit();
            Items.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Items.DataSource = ds;
            Items.EndInit();
            Items.ShowPreview();
        }

       

       

        private void ButtonProductionSectionWarping_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data_WarpingSection SectionWarping = new Data_WarpingSection();
            SectionWarping.MdiParent = this;
            SectionWarping.Show();
        }

        private void Button_StorePurchaseRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_PurchaseRegister PurchaseRegister = new Store.Store_PurchaseRegister();
            PurchaseRegister.MdiParent = this;
            PurchaseRegister.Show();
        }

        private void FabricContracts_ItemClick(object sender, ItemClickEventArgs e)
        {
            PO.Fabric_Contract_Sales_Towel SalesContractTowel = new PO.Fabric_Contract_Sales_Towel();
            SalesContractTowel.MdiParent = this;
            SalesContractTowel.Show();
        }

        private void Button_StorePurchaseReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_PurchaseReturn PurchaseReturnStore = new Store.Store_PurchaseReturn();
            PurchaseReturnStore.MdiParent = this;
            PurchaseReturnStore.Show();
        }

        private void Button_StoreIssueNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_StoreIssueNote IssueNote = new Store.Store_StoreIssueNote();
            IssueNote.MdiParent = this;
            IssueNote.Show();
        }

        private void Store_Opening_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_StoreOpening Opening = new Store.Store_StoreOpening();
            Opening.MdiParent = this;
            Opening.Show();
        }

        private void Store_OpeningEnteries_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            string query = "select * from RST_StoreDetails where PRNO in(Select PRNO from ST_StorePR where PRTYPEID=7) order by ControlAccountID,GroupAccountID,Convert(numeric(36,0),PRDNO)";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds == null)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;
            }
            if (ds.Tables[0].Rows.Count <= 0)
            {
                XtraMessageBox.Show("No Records Found!", "Error", MessageBoxButtons.OK);
                return;

            }
            Reports.Store_OpeningReport Opening = new Reports.Store_OpeningReport();
            Opening.BeginInit();
            Opening.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null)
                Opening.DataSource = ds;
            else
                Opening.DataSource = null;
            Opening.EndInit();
            Opening.ShowPreview();
        }

        private void Accounts_StoreCashPurchases_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_Voucher_StorePurchase CashStore = new Accounts.Accounts_Voucher_StorePurchase();
            CashStore.MdiParent = this;
            CashStore.Show();
        }

        private void Accounts_CreditStorePurchases_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesOthersStore CreditStore = new Accounts.Accounts_PurchasesOthersStore();
            CreditStore.MdiParent = this;
            CreditStore.Show();
        }

        private void Production_SizingSummaryReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.SW_SizingSummary summary = new Yarn.ReportingParameters.SW_SizingSummary();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Store_ItemBinCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.Store_BinCardReport summary = new Yarn.ReportingParameters.Store_BinCardReport();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Store_ReceiveNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_StoreReceiveNote ReceiveNote = new Store.Store_StoreReceiveNote();
            ReceiveNote.MdiParent = this;
            ReceiveNote.Show();
        }

        private void Store_ControlAccountsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Store_ControlItemAccounts ControlList = new Reports.Store_ControlItemAccounts();
            DataSet ds = WS.svc.Get_DataSet("Select * from ST_ControlAccounts order by Convert(numeric(9),ControlAccountID) ");
            ControlList.BeginInit();
            ControlList.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ControlList.DataSource = ds.Tables[0];
            ControlList.EndInit();
            ControlList.ShowPreview();
        }

        

        private void barButtonItem_GoogleEarth_ItemClick(object sender, ItemClickEventArgs e)
        {
            
           
          
           
        }

      

        private void Tracking_VehicleMakes_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Vehicle Makes", "Make", "TK_VehicleMakes");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tracking_VehicleModels_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Vehicle Models", "Model", "TK_VehicleModels");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tracking_VehicleTypes_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Vehicle Types", "Type", "TK_VehicleTypes");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_ManageVehicles_ItemClick(object sender, ItemClickEventArgs e)
        {
            GPS.TK_VehiclesManagement vManagement = new GPS.TK_VehiclesManagement();
            vManagement.MdiParent = this;
            vManagement.Show();
        }

        private void Accounts_PrintChartOfAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_ChartofAccount ChartofAccounts = new Reports.Accounts_ChartofAccount();
           DataSet ds= WS.svc.Get_DataSet("Select * from Accounts_ChartofAccounts order by AccountID_I,AccountID_II,AccountID_III,AccountID_IV,AccountID_V");
            ChartofAccounts.BeginInit();
            if (ds != null)
                ChartofAccounts.DataSource = ds.Tables[0];
            else
                ChartofAccounts.DataSource = null;

            ChartofAccounts.EndInit();
            ChartofAccounts.ShowPreview();
        }

      

      

        private void Button_TowelArticles_ItemClick(object sender, ItemClickEventArgs e)
        {
            Planning.Data_ArticleTowel_Main TowelArticles = new Planning.Data_ArticleTowel_Main();
            TowelArticles.MdiParent = this;
            TowelArticles.Show();
        }

        private void Accounts_TrialBalanceEndingG_ItemClick(object sender, ItemClickEventArgs e)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Accounts_TrialBalanceEnding TrialBalance = new Reports.Accounts_TrialBalanceEnding();
            string query = "SELECT     AccountID_IV,AccountName_IV,AccountID_V, AccountName_V,SUM(vDebitAmount) -SUM(vCreditAmount) AS eDebit,SUM(vCreditAmount)-SUM(vDebitAmount) as eCredit " +
                     " FROM  dbo.Accounts_Vouchers where vcat='G' and  vDate<='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_IV,AccountName_IV,AccountID_V, AccountName_V order by AccountID_V,AccountID_IV";
            //string query = "SELECT     AccountID_V, AccountName_V,SUM(vDebitAmount) AS eDebit,SUM(vCreditAmount) as eCredit,SUM(vDebitAmount)-SUM(vCreditAmount) as eBalance " +
            //      " FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_V, AccountName_V order by AccountID_V";
            DataSet ds = WS.svc.Get_DataSet(query);
            TrialBalance.BeginInit();
            TrialBalance.NGB.Text = "G";
            TrialBalance.DataSource = ds;
            TrialBalance.EndInit();
            TrialBalance.ShowPreview();
        }

        private void Accounts_TrialBalanceEndingN_ItemClick(object sender, ItemClickEventArgs e)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;

            Reports.Accounts_TrialBalanceEnding TrialBalance = new Reports.Accounts_TrialBalanceEnding();
            string query = "SELECT     AccountID_IV,AccountName_IV,AccountID_V, AccountName_V,SUM(vDebitAmount) -SUM(vCreditAmount) AS eDebit,SUM(vCreditAmount)-SUM(vDebitAmount) as eCredit " +
                     " FROM  dbo.Accounts_Vouchers where vCat='N' and vDate<='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_IV,AccountName_IV,AccountID_V, AccountName_V order by AccountID_V,AccountID_IV";
            //string query = "SELECT     AccountID_V, AccountName_V,SUM(vDebitAmount) AS eDebit,SUM(vCreditAmount) as eCredit,SUM(vDebitAmount)-SUM(vCreditAmount) as eBalance " +
            //      " FROM  dbo.Accounts_Vouchers where VCat in(" + VCat + ") and vDate >= '" + this.FromDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and vDate <= '" + this.ToDate.DateTime.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' GROUP BY AccountID_V, AccountName_V order by AccountID_V";
            DataSet ds = WS.svc.Get_DataSet(query);
            TrialBalance.BeginInit();
            TrialBalance.NGB.Text = "N";
            TrialBalance.DataSource = ds;
            TrialBalance.EndInit();
            TrialBalance.ShowPreview();
        }

        private void Store_UnitsMeasurements_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Units Measurements", "Unit", "PP_Units");
            if (pr.Status == ParameterStatus.Error)
            {
            }
                
        }

        private void bar_AutomaticUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
           // MachineEyes.Data.AutoUpdate AutomaticUpdate = new Data.AutoUpdate();
          //  AutomaticUpdate.Show();
        }

        private void barButtonItem_GreigeArticle_ItemClick(object sender, ItemClickEventArgs e)
        {
            Planning.Data_Article_Greige Greige = new Planning.Data_Article_Greige();
            Greige.MdiParent = this;
            Greige.Show();
        }

        private void Store_ClosingStockReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            //
            Reports.Store_ClosingStock Report = new Reports.Store_ClosingStock();
            string query = "Select  ItemAccountID, ItemAccountName, GroupAccountID, GroupAccountName, ControlAccountID, ControlAccountName, UOM, AVG(PlusRate) AS CurrentRate,{ fn IFNULL(SUM(PlusQty), 0) } - { fn IFNULL(SUM(MinusQty), 0) } AS Quantity, { fn IFNULL(SUM(PlusAmount), 0) } - { fn IFNULL(SUM(MinusAmount), 0) } AS Amount from RST_StoreDetails where Dated<='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' group by ItemAccountID,ItemAccountName,GroupAccountID,GroupAccountName,ControlAccountID,ControlAccountName,UOM,CurrentRate";
            DataSet ds = WS.svc.Get_DataSet(query);
            //ds.Tables[0].DefaultView.RowFilter = "Quantity>0";
            Report.BeginInit();
            Report.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null)
                Report.DataSource = ds.Tables[0];
            else
                Report.DataSource = null;
            Report.Dated.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            Report.EndInit();
            Report.ShowPreview();
        }

        private void Button_Inspection_POYarnBalanceSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

       

        private void Accounts_ChartOfAccount_TabView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_ChartofAccounts ChartofAccount = new Accounts.Accounts_ChartofAccounts();
            ChartofAccount.MdiParent = this;
            ChartofAccount.Show();
        }

      

       

        private void PO_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            PO.Fabric_Contract_Sales_Greige GreigePO = new PO.Fabric_Contract_Sales_Greige();
            GreigePO.MdiParent = this;
            GreigePO.Show();
        }

        private void MDC_CashPaymentVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_VouchersAll CashPayment = new Accounts.Accounts_VouchersAll();
            CashPayment.SetVoucherType(enVoucherType.CashPaymentVoucher);
           
            CashPayment.MdiParent = this;
            CashPayment.Show();
        }

        private void MDC_BankPaymentVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_VouchersAll BankPayment = new Accounts.Accounts_VouchersAll();
            BankPayment.SetVoucherType(enVoucherType.BankPaymentVoucher);
            BankPayment.MdiParent = this;
            BankPayment.Show();
        }

        private void MDC_CashReceiptVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_VouchersAll CashReceipt = new Accounts.Accounts_VouchersAll();
            CashReceipt.SetVoucherType(enVoucherType.CashReceiptVoucher);
            CashReceipt.MdiParent = this;
            CashReceipt.Show();
        }

        private void MDC_BankReceiptVoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_VouchersAll BankReceipt = new Accounts.Accounts_VouchersAll();
            BankReceipt.SetVoucherType(enVoucherType.BankReceiptVoucher);
            BankReceipt.MdiParent = this;
            BankReceipt.Show();
        }

        private void MDC_Journalvoucher_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_VouchersAll JournalVoucher = new Accounts.Accounts_VouchersAll();
            JournalVoucher.SetVoucherType(enVoucherType.GeneralVoucher);
            JournalVoucher.MdiParent = this;
            JournalVoucher.Show();
        }

        private void SaveAsDefaultSkin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (meProgress.Status == progressStatus.SUCCEEDED)
            {
                try
                {
                    DialogResult dg = XtraMessageBox.Show("Are you sure to Save skin ?", "Save Skin as default profile", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dg != DialogResult.Yes) return;
                    string res = WS.svc.Execute_Query("update PP_Employees set DefaultSkinName='" + defaultLookAndFeel1.LookAndFeel.ActiveSkinName + "' where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "'");
                    if (res != "**SUCCESS##")
                    {
                        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        XtraMessageBox.Show("Skin Saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void Purchases_PurchaseLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_PurchasesSummary_AccountsWise cReport = new Accounts.ReportingParameters.xu_PurchasesSummary_AccountsWise();
            Report.reportControlParent.Size = cReport.Size;
            Report.Size = cReport.Size;
            Report.reportControlParent.Controls.Add(cReport);
            Report.Show();
        }

        private void Purchases_PurchasesSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_PurchasesSummary summary = new Accounts.ReportingParameters.xu_PurchasesSummary();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

       

        private void barButtonItem_Opening_Inward_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_TowelOpening Opening = new InspectionDelivery.Godown_TowelOpening();
            Opening.MdiParent = this;
            Opening.Show();
        }

        private void barButtonItem_Opening_OutWard_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_TowelOpeningOutward Opening = new InspectionDelivery.Godown_TowelOpeningOutward();
            Opening.MdiParent = this;
            Opening.Show();
        }

        private void barButtonItem_Towel_Inspection_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_TowelInspection PrimaryInspectionTowel = new InspectionDelivery.Godown_TowelInspection();
            PrimaryInspectionTowel.MdiParent = this;
            PrimaryInspectionTowel.Show();
        }

        private void barButtonItem_TakeToGodown_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_TowelTakeToGodown TTG = new InspectionDelivery.Godown_TowelTakeToGodown();
            TTG.MdiParent = this;
            TTG.Show();
        }

        private void barButtonItem_PackingList_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_TowelPackingList PL = new InspectionDelivery.Godown_TowelPackingList();
            PL.MdiParent = this;
            PL.Show();
        }

        private void barButtonItem_ArticleBinCard_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            InspectionDelivery.UserControls.Towel_ArticleBinCard summary = new InspectionDelivery.UserControls.Towel_ArticleBinCard();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void barButtonItem_POBinCard_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            InspectionDelivery.UserControls.Towel_ArticleBinCardWithPO summary = new InspectionDelivery.UserControls.Towel_ArticleBinCardWithPO();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void barButtonItem_DailyContractPosition_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Inspection_Towel_DailyContractPosition DailyPositionTowel = new Reports.Inspection_Towel_DailyContractPosition();
            string query = " Select * from IP_Godown_Towel_ContractPosition where POStatusID=0 order by BuyerName,ArticleNumber,ArticleShortName,PONO";
            DataSet ds = WS.svc.Get_DataSet(query);
            DailyPositionTowel.BeginInit();
            DailyPositionTowel.StatusDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            if (ds != null) DailyPositionTowel.DataSource = ds.Tables[0]; else DailyPositionTowel.DataSource = null;

            DailyPositionTowel.EndInit();
            DailyPositionTowel.ShowPreview();
        }

        private void barButtonItem_StockReport_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem_YarnBalanceSummary_Towel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            InspectionDelivery.UserControls.Towel_ContractYarnAndTowelSummary summary = new InspectionDelivery.UserControls.Towel_ContractYarnAndTowelSummary();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void barButtonItem_Inspection_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeInspection Inspection = new InspectionDelivery.Godown_GreigeInspection();
            Inspection.MdiParent = this;
            Inspection.Show();
        }

        private void barButtonItem_JacquardArticles_ItemClick(object sender, ItemClickEventArgs e)
        {
            Planning.Data_Article_Jacquard Jacquard = new Planning.Data_Article_Jacquard();
            Jacquard.MdiParent = this;
            Jacquard.Show();
        }

        private void barButtonItem_TaketoGodown_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            //InspectionDelivery.Godown_GreigeTakeToGodown TakeToGodown_Greige = new InspectionDelivery.Godown_GreigeTakeToGodown();
            //TakeToGodown_Greige.MdiParent = this;
            //TakeToGodown_Greige.Show();
        }

        private void barButtonItem_PackingList_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigePackingList PackingList = new InspectionDelivery.Godown_GreigePackingList();
            PackingList.MdiParent = this;
            PackingList.Show();
        }

        private void barButtonItem_Opening_Inward_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeOpeningInward InwardOpening = new InspectionDelivery.Godown_GreigeOpeningInward();
            InwardOpening.MdiParent = this;
            InwardOpening.Show();
        }

        private void Store_MonthlyIssuance_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 and IssueTypeID='1' group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if(ds!=null)
            ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.IssueType.Text = "Expense A/C";
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if(ds!=null)MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void Store_MonthlyIssuanceGroupAccount_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_IssuanceGroupAccounts MonthlyIssuance = new Reports.Store_IssuanceGroupAccounts();
            string query = "select GroupAccountID,GroupAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 group by GroupAccountID,GroupAccountName,DepartmentName,UOM,loomName order by DepartmentName,GroupAccountID,GroupAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if(ds!=null)ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if(ds!=null)MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void barButtonItem_MonthlyPurchasesDetailedItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyPurchasesDetailedItem MonthlyIssuance = new Reports.Store_MonthlyPurchasesDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Sum(PRDQty) as PlusQty,Sum(PRDAmount) as PlusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=0 group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            string query2 = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(PIDRate) as MinusRate,Sum(PIDQty) as MinusQty,Sum(PIDAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=2 group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet dsm = WS.svc.Get_DataSet(query2);
            if(dsm!=null && ds!=null)
            ds.Merge(dsm);
            if(ds!=null)ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0 or PlusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if(ds!=null)MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void Accounts_PurchasesOthers_Return_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesOthersReturn OthersReturn = new Accounts.Accounts_PurchasesOthersReturn();
            OthersReturn.MdiParent = this;
            OthersReturn.Show();
        }

        private void Accounts_PurchasesYarn_Return_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.Accounts_PurchasesYarnReturn YarnReturn = new Accounts.Accounts_PurchasesYarnReturn();
            YarnReturn.MdiParent = this;
            YarnReturn.Show();
        }

        private void Accounts_SalesRegister_PartyFilter_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_SalesTaxRegister_FilterParty summary = new Accounts.ReportingParameters.xu_SalesTaxRegister_FilterParty();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Store_Monthly_GetBacks_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyGetBacks MonthlyGetBacks = new Reports.Store_MonthlyGetBacks();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Sum(PlusQty) as PlusQty,Sum(PlusAmount) as PlusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=5 group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            ds.Tables[0].DefaultView.RowFilter = "PlusAmount>0";

            MonthlyGetBacks.BeginInit();
            MonthlyGetBacks.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyGetBacks.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyGetBacks.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            MonthlyGetBacks.DataSource = ds.Tables[0];
            MonthlyGetBacks.EndInit();
            MonthlyGetBacks.ShowPreview();
        }

        private void Inspection_OutsideWeaving_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeInspectionOutsideWeaving OutsideInspection = new InspectionDelivery.Godown_GreigeInspectionOutsideWeaving();
            OutsideInspection.MdiParent = this;
            OutsideInspection.Show();
        }

        private void barButtonItem_Opening_OutWard_Greige_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeOpeningOutward OpeningOutward = new InspectionDelivery.Godown_GreigeOpeningOutward();
            OpeningOutward.MdiParent = this;
            OpeningOutward.Show();
        }

        private void Greige_ArticleBinCard_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            InspectionDelivery.UserControls.Greige_ArticleBinCard summary = new InspectionDelivery.UserControls.Greige_ArticleBinCard();

            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Greige_CurrentContractsPosition_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Inspection_Greige_DailyContractPosition DailyPositionGreige = new Reports.Inspection_Greige_DailyContractPosition();
            string query = " Select BuyerID,BuyerName,PONO,ArticleNumber,ArticleShortName,POQtyMtrs,Sum(IN_A) as IN_A,sum(IN_B) as IN_B,sum(IN_C) as IN_C,SUM(IN_SP) as IN_SP,sum(IN_CP) as IN_CP,sum(OUT_A) as OUT_A,sum(OUT_B) as OUT_B,sum(OUT_C) as OUT_C,sum(OUT_SP) as OUT_SP,sum(Out_CP) as Out_CP,sum(IN_A)-sum(OUT_A) as Balance_A,sum(IN_B)-sum(OUT_B) as Balance_B,sum(IN_C)-sum(OUT_C) as Balance_C,sum(IN_SP)-sum(OUT_SP) as Balance_SP,sum(IN_CP)-sum(OUT_CP) as Balance_CP from RIP_Godown_Greige_Details where POStatusID=0 group by BuyerID,BuyerName,PONO,ArticleNumber,ArticleShortName,POQTYMtrs order by BuyerID,BuyerName,PONO,ArticleNumber,ArticleShortName";
            DataSet ds = WS.svc.Get_DataSet(query);
            DailyPositionGreige.BeginInit();
            DailyPositionGreige.StatusDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            DailyPositionGreige.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null) DailyPositionGreige.DataSource = ds.Tables[0]; else DailyPositionGreige.DataSource = null;
            DailyPositionGreige.EndInit();
            DailyPositionGreige.ShowPreview();
        }

        private void Greige_ContractAcitivtySheet_Report_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Inspection_Greige_ContractActivity DailyPositionGreige = new Reports.Inspection_Greige_ContractActivity();



            string query =     
            @"SELECT     BuyerID, BuyerName, PONO, ArticleNumber, ArticleShortName, POQTYMTRS, SUM(CASE WHEN godownentrytypeid IN (0, 1, 4) THEN IN_A ELSE 0 END)
                     + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4) THEN IN_B ELSE 0 END) AS Produced_Fresh, SUM(CASE WHEN godownentrytypeid IN (0, 1, 4) 
                      THEN IN_C ELSE 0 END) + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4) THEN IN_SP ELSE 0 END) + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4) 
                     THEN IN_CP ELSE 0 END) AS Produced_Rejected, SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_A ELSE 0 END) 
                    + SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_B ELSE 0 END) AS Delivered_Fresh, SUM(CASE WHEN godownentrytypeid = 5 THEN IN_A ELSE 0 END)
                      + SUM(CASE WHEN godownentrytypeid = 5 THEN IN_B ELSE 0 END) AS Returned_Fresh, SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_A ELSE 0 END) 
                     + SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_B ELSE 0 END) - SUM(CASE WHEN godownentrytypeid = 5 THEN IN_A ELSE 0 END) 
                      - SUM(CASE WHEN godownentrytypeid = 5 THEN IN_B ELSE 0 END) AS NetDispatched_Fresh, SUM(CASE WHEN GodownEntryTypeID IN (0, 1, 4, 6) 
                      THEN IN_A ELSE 0 END) + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4, 6) THEN IN_B ELSE 0 END) 
                      - SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_A ELSE 0 END) - SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_B ELSE 0 END) AS Stock_Fresh,
                      SUM(CASE WHEN GodownEntryTypeID IN (0, 1, 4, 6) THEN IN_C ELSE 0 END) + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4, 6) THEN IN_SP ELSE 0 END) 
                       + SUM(CASE WHEN godownentrytypeid IN (0, 1, 4, 6) THEN IN_CP ELSE 0 END) - SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_C ELSE 0 END) 
                      - SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_SP ELSE 0 END) - SUM(CASE WHEN godownentrytypeid = 3 THEN OUT_CP ELSE 0 END) 
                    AS Stock_Rejected FROM         RIP_Godown_Greige_Details WHERE     (POStatusID = 0) GROUP BY BuyerID, BuyerName, PONO, ArticleNumber, ArticleShortName, POQTYMTRS ORDER BY BuyerID, BuyerName, PONO, ArticleNumber, ArticleShortName ";
            
            
            
            
            
            
            
            
            DataSet ds = WS.svc.Get_DataSet(query);
            DailyPositionGreige.BeginInit();
            DailyPositionGreige.ReportDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            DailyPositionGreige.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            if (ds != null) DailyPositionGreige.DataSource = ds.Tables[0]; else DailyPositionGreige.DataSource = null;
            DailyPositionGreige.EndInit();
            DailyPositionGreige.ShowPreview();
        }

        private void Greige_FabricReturn_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeInspectionReturn FabricReturn = new InspectionDelivery.Godown_GreigeInspectionReturn();
            FabricReturn.MdiParent = this;
            FabricReturn.Show();
        }

        private void Greige_ReCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            InspectionDelivery.Godown_GreigeInspectionRecheck ReCheck = new InspectionDelivery.Godown_GreigeInspectionRecheck();
            ReCheck.MdiParent = this;
            ReCheck.Show();
        }

        private void GPS_ClientsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraForm OpenedForm = CheckifFormAlradyOpen("Debug_GPSClients");
            if (OpenedForm == null)
            {
                Debug.Debug_GPSClients SinkList = new Debug.Debug_GPSClients();
                SinkList.MdiParent = this;
                SinkList.Show();
            }
            else
                OpenedForm.Show();
        }

        private void Monthly_Efficiency_SelectedLoom_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            LDS.ReportingParameters.xu_Monthly_Loom_Production yru_itemledger = new LDS.ReportingParameters.xu_Monthly_Loom_Production();
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void Accounts_SalesRegister_Dated_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_SalesTaxRegister_FilterDated Ledger = new Reports.Accounts_SalesTaxRegister_FilterDated();
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
           
           
            string query = "Select * from Accounts_SalesTaxRegister_FilterParty where iDate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18,0),iNumber)  ";
            DataSet ds = WS.svc.Get_DataSet(query);
            Ledger.BeginInit();
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Ledger.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yy");
            Ledger.xr_ToDate.Text = SelectedDate.upTo.ToString("dd-MMM-yy");
           
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Ledger.DataSource = ds;
                else
                    Ledger.DataSource = null;
            }
            else
                Ledger.DataSource = null;
            Ledger.EndInit();
            Ledger.ShowPreview();
        }

        private void Accounts_PurchaseRegister_DuringPeriod_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Accounts_PurchaseRegister_FilterDated Ledger = new Reports.Accounts_PurchaseRegister_FilterDated();
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;


            string query = "Select * from Accounts_PurchasesSummary_IstStage where iDate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and iDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by Convert(numeric(18,0),iNumber)  ";
            DataSet ds = WS.svc.Get_DataSet(query);
            Ledger.BeginInit();
            Ledger.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            Ledger.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yy");
            Ledger.xr_ToDate.Text = SelectedDate.upTo.ToString("dd-MMM-yy");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                    Ledger.DataSource = ds;
                else
                    Ledger.DataSource = null;
            }
            else
                Ledger.DataSource = null;
            Ledger.EndInit();
            Ledger.ShowPreview();
        }

        private void Accounts_SalesRegister_Article_ItemClick(object sender, ItemClickEventArgs e)
        {
            Accounts.ReportingParameters.MultiReports Report = new Accounts.ReportingParameters.MultiReports();
            Accounts.ReportingParameters.xu_SalesTaxRegister_FilterArticle summary = new Accounts.ReportingParameters.xu_SalesTaxRegister_FilterArticle();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Efficiency_BeamContraction_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            LDS.ReportingParameters.xu_Planning_BeamContraction summary = new LDS.ReportingParameters.xu_Planning_BeamContraction();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Efficiency_QualityWiseBreakageReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            LDS.ReportingParameters.xu_Efficiency_BreakagesPerHour summary = new LDS.ReportingParameters.xu_Efficiency_BreakagesPerHour();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void Efficiency_QualityWiseBreakagesGrouped_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates DatesBetween = new Data.Param_TwoDates();
            DatesBetween.ShowDialog();
            if (SelectedDate.isCanceled == true) return;

           
            Reports.Efficiency_AvgBreakagesPerHourGroupByQuality ABC = new Reports.Efficiency_AvgBreakagesPerHourGroupByQuality();

           
            ABC.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            ABC.FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            ABC.UptoDate.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            string dsstring = "SELECT     ShiftDate,ArticleNumber,ArticleShortName,Count(LoomID) as NoofLooms,Avg(T_RPM) as T_RPM,Avg(T_Eff) as T_Eff,Sum(T_WarpStops) as T_WarpStops , Sum(T_WeftStops) as T_WeftStops,Avg(T_Warpperhour) as T_Warpperhour,Avg(T_Weftperhour) as T_Weftperhour from RP_dailyShiftSummary  where  Shiftdate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and ShiftDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' group by ArticleNumber,ArticleShortName,ShiftDate order by ArticleShortName,ShiftDate";
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            
            ABC.BeginInit();
            if(ds!=null)
            ABC.DataSource = ds.Tables[0];
            ABC.EndInit();
            ABC.ShowPreview();
        }

        private void YarnReports_POSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Yarn_ContractSummary YLedger = new Reports.Yarn_ContractSummary();

            Data.Param_TwoDates seDate = new Data.Param_TwoDates();
            seDate.ShowDialog();
            if (SelectedDate.isCanceled == true) return;


            YLedger.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            
            string query = "Select AccountID,PONO,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end) as Lbs_Received,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end) as Lbs_Issued,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn-LbsOut+LbsAdj else 0 end) +sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIn else 0 end)-sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOut else 0 end)+sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Balance,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end) as Bags_Received,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end) as Bags_Issued,sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn-BagsOut+BagsAdj else 0 end) +sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIn else 0 end)-sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOut else 0 end)+sum(case when Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Balance    from YQ_YarnStock group by  PONO,AccountID,AccountName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
            DataSet ds = WS.svc.Get_DataSet(query);

            YLedger.BeginInit();
            if(ds!=null)
            ds.Tables[0].DefaultView.RowFilter = "Lbs_Balance>0";
            if (ds != null)
                YLedger.DataSource = ds;
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void Yarn_ReturnToParty_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_ReturnToParty GIN = new Yarn.Yarn_ReturnToParty();
            GIN.MdiParent = this;
            GIN.Show();
        }

        private void YarnInward_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_Inward GRN = new Yarn.Yarn_Inward();
            GRN.MdiParent = this;
            GRN.Show();
        }

        private void YarnOutward_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_Outward Outward = new Yarn.Yarn_Outward();
            Outward.MdiParent = this;
            Outward.Show();
        }

        private void SizingWorkOrderButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            WarpingSizing.SizingWorkOrder SWO = new WarpingSizing.SizingWorkOrder();
            SWO.MdiParent = this;
            SWO.Show();
        }

        private void DoublingWorkOrderButton_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void DoublingWorkOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.DoublingWorkOrder DWO = new Yarn.DoublingWorkOrder();
            DWO.MdiParent = this;
            DWO.Show();
        }

        private void IssuetoDoubling_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.DoublingIssueNote DIN = new Yarn.DoublingIssueNote();
            DIN.MdiParent = this;
            DIN.Show();
        }

        private void ReceiveFromDoubling_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.DoublingReceiveNote DRN = new Yarn.DoublingReceiveNote();
            DRN.MdiParent = this;
            DRN.Show();
        }

        private void MovetoPO_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.MovePO MN = new Yarn.MovePO();
            MN.MdiParent = this;
            MN.Show();
        }

        private void GreigeContractsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.FC_PO_Greige_List FCList = new Reports.FC_PO_Greige_List();

            Data.Param_TwoDates seDate = new Data.Param_TwoDates();
            seDate.ShowDialog();
            if (SelectedDate.isCanceled == true) return;


            FCList.repH_DatedFrom.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            FCList.repH_DatedTo.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");

            string query = "Select * from RFC_PO where  ((Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "') or dated is null) and POQtyMtrs>0";
            DataSet ds = WS.svc.Get_DataSet(query);

            FCList.BeginInit();
          
            if (ds != null)
                FCList.DataSource = ds;
            else
                FCList.DataSource = null;

        
        }

        private void DenimArticlesAdd_ItemClick(object sender, ItemClickEventArgs e)
        {

            Planning.Data_Article_Custom Custom = new Planning.Data_Article_Custom();
            Custom.MdiParent = this;
            Custom.Show();
        }

        private void barButtonItemYarnColor_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Data.Data_YarnParams param = new MachineEyes.Data.Data_YarnParams();
            ParameterReturn pr = param.Display_Parameter(MousePosition, "Yarn Colors", "YarnColor", "PP_YarnColor");
            if (pr.Status == ParameterStatus.Error)
            {
                XtraMessageBox.Show(pr.ParameterValue, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbi_SetLoomResizeControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentSelection.LoomIndex == -1) return;
            if (CurrentSelection.LoomIndex.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentSelection.SelectedControl == null)
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;
                ControlMoverOrResizer.Init(LoomX);
                LoomX.BackColor = Color.White;
                ControlMoverOrResizer.Init(LoomX.Efficiency);
                ControlMoverOrResizer.Init(LoomX.LoomNumber);
                ControlMoverOrResizer.Init(LoomX.RPM);
                ControlMoverOrResizer.Init(LoomX.ElapsedTime);
                ControlMoverOrResizer.ControlsAreInResizeMode = true;
            }
            //else if (CurrentSelection.SelectedView is Dashboard_Shed_Classic)
            //{
            //    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y);
            //    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.y = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.y;
            //}
            //else if (CurrentSelection.SelectedView is DashBoard_Shed_MakeView)
            //{
            //    CurrentSelection.SelectedControl.Top = Convert.ToInt32(Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.DrawMakeY);
            //    Program.ss.Machines.Looms[CurrentSelection.LoomIndex].Drawing.DrawMakeY = Program.ss.Machines.Looms[Convert.ToInt16(bbi_SetLoomTop.Tag.ToString())].Drawing.DrawMakeY;
            //}
        }
        private void SaveNewShedsLayoutIntoProfile()
        {
            ControlMoverOrResizer.ControlsAreInResizeMode = false;
            if (CurrentSelection.LoomIndex == -1) return;
            if (CurrentSelection.LoomIndex.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentSelection.SelectedControl == null)
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;

                
               
                   
                        DialogResult dg = XtraMessageBox.Show("Are you sure to save position, layout and fonts of loom as referenced loom...the layout will be saved into your default profile..?", "Save Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg != DialogResult.Yes) return;
                        string query = "insert into MT_ShedsLayout_Employees (EmployeeID,ShedID,H_loom,W_Loom,H_Efficiency,W_Efficiency,X_Efficiency,Y_Efficiency,F_Efficiency,S_Efficiency,H_RPM,W_RPM,X_RPM,Y_RPM,F_RPM,S_RPM,H_LoomNumber,W_LoomNumber,X_LoomNumber,Y_LoomNumber,F_LoomNumber,S_LoomNumber,H_ElapsedTime,W_ElapsedTime,X_ElapsedTime,Y_ElapsedTime,F_ElapsedTime,S_ElapsedTime) Values('" + MachineEyes.Classes.Security.User.UserID + "'," + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString() + "," + LoomX.Height.ToString() + " ";
                        query += "," + LoomX.Width.ToString() + "";
                        query += "," + LoomX.Efficiency.Height.ToString() + "";
                        query += "," + LoomX.Efficiency.Width.ToString() + "";
                        query += "," + LoomX.Efficiency.Left.ToString() + "";
                        query += "," + LoomX.Efficiency.Top.ToString() + "";

                        Font f = LoomX.Efficiency.Font;

                        if (f.Name != "")
                            query += ",'" + f.Name + "'";
                        else
                            query += ",null";
                        if (f.Size != 0)
                            query += "," + f.Size.ToString() + "";
                        else
                            query += ",null";

                        query += "," + LoomX.RPM.Height.ToString() + "";
                        query += "," + LoomX.RPM.Width.ToString() + "";
                        query += "," + LoomX.RPM.Left.ToString() + "";
                        query += "," + LoomX.RPM.Top.ToString() + "";

                        f = LoomX.RPM.Font;

                        if (f.Name != "")
                            query += ",'" + f.Name + "'";
                        else
                            query += ",null";
                        if (f.Size != 0)
                            query += "," + f.Size.ToString() + "";
                        else
                            query += ",null";

                        query += "," + LoomX.LoomNumber.Height.ToString() + "";
                        query += "," + LoomX.LoomNumber.Width.ToString() + "";
                        query += "," + LoomX.LoomNumber.Left.ToString() + "";
                        query += "," + LoomX.LoomNumber.Top.ToString() + "";

                        f = LoomX.LoomNumber.Font;

                        if (f.Name != "")
                            query += ",'" + f.Name + "'";
                        else
                            query += ",null";
                        if (f.Size != 0)
                            query += "," + f.Size.ToString() + "";
                        else
                            query += ",null";

                        query += "," + LoomX.ElapsedTime.Height.ToString() + "";
                        query += "," + LoomX.ElapsedTime.Width.ToString() + "";
                        query += "," + LoomX.ElapsedTime.Left.ToString() + "";
                        query += "," + LoomX.ElapsedTime.Top.ToString() + "";
                        f = LoomX.ElapsedTime.Font;

                        if (f.Name != "")
                            query += ",'" + f.Name + "'";
                        else
                            query += ",null";
                        if (f.Size != 0)
                            query += "," + f.Size.ToString() + "";
                        else
                            query += ",null";
                        query += ") ";

                        string res = WS.svc.Execute_Query(query);
                        if (res != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Layout saved into profile successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    
                




            }
        }

        private void bbi_SaveLoomResizeControl_ItemClick(object sender, ItemClickEventArgs e)
        {
           

            ControlMoverOrResizer.ControlsAreInResizeMode = false;
            if (CurrentSelection.LoomIndex == -1) return;
            if (CurrentSelection.LoomIndex.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (CurrentSelection.SelectedControl == null)
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;

                DataSet ds = WS.svc.Get_DataSet("Select Count(ShedID) as Rows from MT_ShedsLayout_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "' and ShedID=" + LoomX.ShedIndex.ToString() + "");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows[0]["Rows"].ToString() != "" && ds.Tables[0].Rows[0]["Rows"].ToString() != "0")
                    {
                        DialogResult dg = XtraMessageBox.Show("Are you sure to save position, layout and fonts of loom as referenced loom...the layout will be saved into your default profile..?", "Save Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg != DialogResult.Yes) return;
                        string query = "Update MT_ShedsLayout_Employees set H_Loom=" + LoomX.Height.ToString() + " ";
                        query += ",W_Loom=" + LoomX.Width.ToString() + "";
                        query += ",H_Efficiency=" + LoomX.Efficiency.Height.ToString() + "";
                        query += ",W_Efficiency=" + LoomX.Efficiency.Width.ToString() + "";
                        query += ",X_Efficiency=" + LoomX.Efficiency.Left.ToString() + "";
                        query += ",Y_Efficiency=" + LoomX.Efficiency.Top.ToString() + "";

                        Font f = LoomX.Efficiency.Font;

                        if (f.Name != "")
                            query += ",F_Efficiency='" + f.Name + "'";
                        else
                            query += ",F_Efficiency=null";
                        if (f.Size != 0)
                            query += ",S_Efficiency=" + f.Size.ToString() + "";
                        else
                            query += ",S_Efficiency=null";

                        query += ",H_RPM=" + LoomX.RPM.Height.ToString() + "";
                        query += ",W_RPM=" + LoomX.RPM.Width.ToString() + "";
                        query += ",X_RPM=" + LoomX.RPM.Left.ToString() + "";
                        query += ",Y_RPM=" + LoomX.RPM.Top.ToString() + "";

                        f = LoomX.RPM.Font;

                        if (f.Name != "")
                            query += ",F_RPM='" + f.Name + "'";
                        else
                            query += ",F_RPM=null";
                        if (f.Size != 0)
                            query += ",S_RPM=" + f.Size.ToString() + "";
                        else
                            query += ",S_RPM=null";

                        query += ",H_LoomNumber=" + LoomX.LoomNumber.Height.ToString() + "";
                        query += ",W_LoomNumber=" + LoomX.LoomNumber.Width.ToString() + "";
                        query += ",X_LoomNumber=" + LoomX.LoomNumber.Left.ToString() + "";
                        query += ",Y_LoomNumber=" + LoomX.LoomNumber.Top.ToString() + "";

                        f = LoomX.LoomNumber.Font;

                        if (f.Name != "")
                            query += ",F_LoomNumber='" + f.Name + "'";
                        else
                            query += ",F_LoomNumber=null";
                        if (f.Size != 0)
                            query += ",S_LoomNumber=" + f.Size.ToString() + "";
                        else
                            query += ",S_LoomNumber=null";

                        query += ",H_ElapsedTime=" + LoomX.ElapsedTime.Height.ToString() + "";
                        query += ",W_ElapsedTime=" + LoomX.ElapsedTime.Width.ToString() + "";
                        query += ",X_ElapsedTime=" + LoomX.ElapsedTime.Left.ToString() + "";
                        query += ",Y_ElapsedTime=" + LoomX.ElapsedTime.Top.ToString() + "";
                        f = LoomX.ElapsedTime.Font;

                        if (f.Name != "")
                            query += ",F_ElapsedTime='" + f.Name + "'";
                        else
                            query += ",F_ElapsedTime=null";
                        if (f.Size != 0)
                            query += ",S_ElapsedTime=" + f.Size.ToString() + "";
                        else
                            query += ",S_ElapsedTime=null";
                        query += " where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "' and ShedID=" + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString() + "";

                        string res = WS.svc.Execute_Query(query);
                        if (res != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Layout saved into profile successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                        SaveNewShedsLayoutIntoProfile();
                }
                else
                    SaveNewShedsLayoutIntoProfile();
               

               

            }
        }

        private void bbi_SaveLoomLayoutintoProfile_ItemClick(object sender, ItemClickEventArgs e)
        {




              if (CurrentSelection.LoomIndex == -1) return;
            if (CurrentSelection.LoomIndex.ToString() == "")
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (CurrentSelection.SelectedControl == null)
            {
                XtraMessageBox.Show("Select Referenced Loom", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           

            if (CurrentSelection.SelectedView is Dashboard_Shed)
            {
                dxLoom LoomX = (dxLoom)CurrentSelection.SelectedControl;

                DataSet ds = WS.svc.Get_DataSet("Select Count(ShedID) as Rows from MT_ShedsLayout_Employees where EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "' and ShedID=" + LoomX.ShedIndex.ToString() + "");
                if (ds != null)
                {
                    string[] queries = new string[0];
                   
                        DialogResult dg = XtraMessageBox.Show("Are you sure to save layout ...the layout will be saved into your default profile..?", "Save Profile", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dg != DialogResult.Yes) return;
                        
                            Array.Resize(ref queries, 1);
                            queries[0] = "Delete from MT_ShedsLoomsLayout_Employees where ShedID=" + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString() + " and EmployeeID='" + MachineEyes.Classes.Security.User.UserID + "'";
                        if (ShedView[LoomX.ShedIndex] != null)
                        {
                            for (int x = 0; x < ShedView[LoomX.ShedIndex].panelControl1.Controls.Count; x++)
                            {
                                Control contr = ShedView[LoomX.ShedIndex].panelControl1.Controls[x];
                                if (contr is dxLoom)
                                {
                                    dxLoom Loom = (dxLoom)contr;

                                    Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.x = contr.Left;
                                    Program.ss.Machines.Looms[Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString())].Drawing.y = contr.Top;
                                    Array.Resize(ref queries, queries.Length + 1);
                                    queries[queries.Length - 1] = "insert into MT_ShedsLoomsLayout_Employees (EmployeeID,ShedID,LoomID,Loom_X,Loom_Y) Values('" + MachineEyes.Classes.Security.User.UserID + "'," + Program.ss.Machines.Looms[CurrentSelection.LoomIndex].PersonalInfo.ShedID.ToString() + "," + Program.ss.ReturnArrayLoomIndex(Loom.LoomNumber.Tag.ToString()) + ", " + contr.Left.ToString() + "," + contr.Top.ToString() + ")";
                                  
                                }
                            }
                        }

                        

                        string res = WS.svc.Execute_Transaction(queries);
                        if (res != "**SUCCESS##")
                        {
                            XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            XtraMessageBox.Show("Layout saved into profile successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                   
                    
                }
               




            }
        }

        private void bbi_SMSDeviceAndServiceStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            SMS.SMS_DeviceStatus DeviceStatus = new SMS.SMS_DeviceStatus();
            DeviceStatus.MdiParent = this;
            DeviceStatus.Show();
        }

        private void bbiYarnOpeningPlus_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.Yarn_InwardOpening OpeningPlus = new Yarn.Yarn_InwardOpening();
            OpeningPlus.MdiParent = this;
            OpeningPlus.Show();
        }

        private void bbiYarnPartyStockReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnPartyWiseStockBalance yru_itemledger = new Yarn.ReportingParameters.nYarnPartyWiseStockBalance();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void bbiTowelContractsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.FC_PO_Towel_List FCList = new Reports.FC_PO_Towel_List();

            Data.Param_TwoDates seDate = new Data.Param_TwoDates();
            seDate.ShowDialog();
            if (SelectedDate.isCanceled == true) return;


            FCList.repH_DatedFrom.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            FCList.repH_DatedTo.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");

            string query = "Select * from RFC_PO where  ((Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "') or dated is null) and POQtyLbs>0";
            DataSet ds = WS.svc.Get_DataSet(query);

            FCList.BeginInit();

            if (ds != null)
                FCList.DataSource = ds;
            else
                FCList.DataSource = null;

            FCList.EndInit();
            FCList.ShowPreview();
        }

        private void bbiYarnPartyWiseStockSummary_ItemClick(object sender, ItemClickEventArgs e)
        {


            Data.Param_TwoDates seDate = new Data.Param_TwoDates();
            seDate.ShowDialog();
            if (SelectedDate.isCanceled == true) return;




            Reports.nYarn_PartyWiseStock_GodownPosition YLedger = new Reports.nYarn_PartyWiseStock_GodownPosition();

            YLedger.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            YLedger.xr_ToDate.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");

            
            string query = "Select BuyerID,BuyerName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc,sum(case when Dated<'" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward-LbsOutward+LbsReceived-LbsIssued+LbsAdj else 0 end) as Lbs_Opening,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end) as Lbs_Received,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end) as Lbs_Issued,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) as Lbs_Inward,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Outward,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end) as Lbs_Adjusted,sum(case when Dated<'" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived-LbsIssued+LbsInward-LbsOutward+LbsAdj else 0 end) +sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsReceived else 0 end)-sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsIssued else 0 end)+sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsAdj else 0 end)+sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsInward else 0 end) -sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then LbsOutward else 0 end) as Lbs_Balance,sum(case when Dated<'" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward-BagsOutward+BagsReceived-BagsIssued+BagsAdj else 0 end) as Bags_Opening,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end) as Bags_Received,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end) as Bags_Issued,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) as Bags_Inward,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Outward,sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end) as Bags_Adjusted,sum(case when Dated<'" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived-BagsIssued+BagsInward-BagsOutward+BagsAdj else 0 end) +sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsReceived else 0 end)-sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsIssued else 0 end)+sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsAdj else 0 end)+sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsInward else 0 end) -sum(case when Dated>='" +SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' then BagsOutward else 0 end) as Bags_Balance     from YNQ_Yarn group by  BuyerId,BuyerName,YarnBagsType,YarnCount,YarnPly,YarnBlend,YarnBrand,YarnDesc ";
            DataSet ds = WS.svc.Get_DataSet(query);


            YLedger.BeginInit();

            if (ds != null)
            {
               
                    ds.Tables[0].DefaultView.RowFilter = "Bags_Balance<>0";
                YLedger.DataSource = ds;
            }
            else
                YLedger.DataSource = null;

            YLedger.EndInit();
            YLedger.ShowPreview();
        }

        private void bbiYarnIssueBetweenParties_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Yarn.Yarn_IssueToParty GIN = new Yarn.Yarn_IssueToParty();
            GIN.MdiParent = this;
            GIN.Show();
        }

        private void bbiYarnDepartmentStockSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnDepartmentStock yru_itemledger = new Yarn.ReportingParameters.nYarnDepartmentStock();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void bbiYarnGodownOrPartitionStockSummary_ItemClick(object sender, ItemClickEventArgs e)
        {

            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnGodownWiseStockSummary yru_itemledger = new Yarn.ReportingParameters.nYarnGodownWiseStockSummary();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void bbiYarnItemLedgerReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnItemLedger yru_itemledger = new Yarn.ReportingParameters.nYarnItemLedger();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void Production_SizingMonthlyProduction_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.SW_SizingMonthlyProduction MonthlySizingProductionReport = new Reports.SW_SizingMonthlyProduction();
            MonthlySizingProductionReport.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlySizingProductionReport.xr_ToDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select * from SWQ_SizingMonthlyProduction where SizingDate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and SizingDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by SizingDate,SetNo");
                MonthlySizingProductionReport.BeginInit();
                if (ds != null)
                    MonthlySizingProductionReport.DataSource = ds.Tables[0];
                MonthlySizingProductionReport.EndInit();
               
            }catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            MonthlySizingProductionReport.ShowPreview();

        }

        private void Production_SizingMonthlyProductionPartyWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.SW_SizingMonthlyProductionPartyWise MonthlySizingProductionReport = new Reports.SW_SizingMonthlyProductionPartyWise();
            MonthlySizingProductionReport.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlySizingProductionReport.xr_ToDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            DataSet ds = WS.svc.Get_DataSet("Select * from SWQ_SizingMonthlyProduction where SizingDate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and SizingDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by PartyName,SizingDate,SetNo");
            MonthlySizingProductionReport.BeginInit();
            if (ds != null)
                MonthlySizingProductionReport.DataSource = ds.Tables[0];
            MonthlySizingProductionReport.EndInit();
            MonthlySizingProductionReport.ShowPreview();
        }

        private void Production_SizingMonthlyProductionCountWise_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates DateForm = new Data.Param_TwoDates();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.SW_SizingMonthlyProductionCountWise MonthlySizingProductionReport = new Reports.SW_SizingMonthlyProductionCountWise();
            MonthlySizingProductionReport.xr_FromDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlySizingProductionReport.xr_ToDate.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            DataSet ds = WS.svc.Get_DataSet("Select * from SWQ_SizingMonthlyProduction where SizingDate>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and SizingDate<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' order by YarnCount,YarnPly,YarnBlend,PartyName,SizingDate,SetNo");
            MonthlySizingProductionReport.BeginInit();
            if (ds != null)
                MonthlySizingProductionReport.DataSource = ds.Tables[0];
            MonthlySizingProductionReport.EndInit();
            MonthlySizingProductionReport.ShowPreview();
        }

        private void bbi_Dashboard_ShedEff_ItemClick(object sender, ItemClickEventArgs e)
        {
            for (int x = 0; x < Program.ss.Machines.PresentationData.Sheds.Length; x++)
            {
                if(ShedView[x]==null)
                       ShedView[x] = new Dashboard_Shed();

                ShedView[x].Name = "ShedView" + Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                ShedView[x].Text = Program.ss.Machines.PresentationData.Sheds[x].ShedName + " View";
                ShedView[x].Tag = Program.ss.Machines.PresentationData.Sheds[x].ShedID;
                ShedView[x].MdiParent = this;
                ShedView[x].BringToFront();
                ShedView[x].Show();
            }
        }

        private void WeaverGroupsManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Data_GroupManagement Groups = new Data.Data_GroupManagement();
            Groups.MdiParent = this;
            Groups.Show();
        }

        private void StoreLocations_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_ChartofLocations Locations = new Store.Store_ChartofLocations();
            Locations.MdiParent = this;
            Locations.Show();
        }

        private void Store_MonthlyIssuance_Report_Asset_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 and IssueTypeID='2' group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.IssueType.Text = "Assets A/C";
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void Store_MonthlyIssuance_Report_DevelopmentConstruction_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 and IssueTypeID='3' group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.IssueType.Text = "Development & Construction A/C";
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void DepartmentRequisitionSlip_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_StoreRequisition Request = new Store.Store_StoreRequisition();
            Request.MdiParent = this;
            Request.Show();

        }

        private void MergedShedLayoutSaveMenuButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ShedMergedLayout == null) return;
            if (ShedMergedLayout.Length <= 0) return;

            for (int x = 0; x < ShedMergedLayout.Length; x++)
            {
                for (int loomx = 0; loomx < ShedMergedLayout[x].panelControl1.Controls.Count; loomx++)
                {
                    dxLoom dx = (dxLoom)ShedMergedLayout[x].panelControl1.Controls[loomx];
                    string xAxes, yAxes;
                    xAxes = "ML_" + x.ToString() + "_X";
                    yAxes = "ML_" + x.ToString() + "_Y";
                StartUpdateGroupPostion: string webres = WS.svc.Execute_Query("update MT_Looms set "+xAxes+"=" + dx.Left + ","+yAxes+"=" + dx.Top + " where LoomID=" + dx.LoomNumber.Tag.ToString() + "");
                    if (webres!= "**SUCCESS##")
                    {
                        DialogResult dg = XtraMessageBox.Show(webres, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (dg == DialogResult.Abort) return;
                        if (dg == DialogResult.Retry) goto StartUpdateGroupPostion;

                    }
                }
            }
        }

        private void YarnDoublingWorkOrderLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnDoublingPOLedger yru_itemledger = new Yarn.ReportingParameters.nYarnDoublingPOLedger();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void DoublingAdjustmentNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.DoublingAdjustmentNote Adjustment = new Yarn.DoublingAdjustmentNote();
            Adjustment.MdiParent = this;
            Adjustment.Show();
        }

        private void DoublingWorkOrdersSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnDoublingPOLedger yru_itemledger = new Yarn.ReportingParameters.nYarnDoublingPOLedger();
            yru_itemledger.WorkOrderLabel.Visible = false;
            yru_itemledger.DoublingWorkOrderNumber.Visible = false;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void YarnDyingIssueNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.YarnDyingIssueNote DyingIssueNote = new Yarn.YarnDyingIssueNote();
            DyingIssueNote.MdiParent = this;
            DyingIssueNote.Show();
        }

        private void YarnDyingReceiveNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.YarnDyingReceiveNote DyingRNote = new Yarn.YarnDyingReceiveNote();
            DyingRNote.MdiParent = this;
            DyingRNote.Show();
        }

        private void YarnDyingWorkOrder_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.YarnDyingWorkOrder ydwo = new Yarn.YarnDyingWorkOrder();
            ydwo.MdiParent = this;
            ydwo.Show();
        }

        private void YarnDyingAdjustmentNote_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.YarnDyingAdjustmentNote DAdjustment = new Yarn.YarnDyingAdjustmentNote();
            DAdjustment.MdiParent = this;
            DAdjustment.Show();
        }

        private void YarnDyingWorkOrderLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnDyingPOLedger yru_itemledger = new Yarn.ReportingParameters.nYarnDyingPOLedger();

            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void YarnDyingWorkOrderSummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnDyingPOLedger yru_itemledger = new Yarn.ReportingParameters.nYarnDyingPOLedger();
            yru_itemledger.DyingWorkOrderNumber.Visible = false;
            yru_itemledger.WorkOrderLabel.Visible = false;
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void RequestApproval_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_RequestApproval ApprovalForm = new Store.Store_RequestApproval();
            ApprovalForm.MdiParent = this;
            ApprovalForm.Show();
        }

        private void EmailSettings_ItemClick(object sender, ItemClickEventArgs e)
        {
            View.Email_Notifications Email = new Email_Notifications();
            Email.MdiParent = this;
            Email.Show();
        }

        private void SizingYarnLedger_ItemClick(object sender, ItemClickEventArgs e)
        {
            Yarn.ReportingParameters.Yarn_Reports Report = new Yarn.ReportingParameters.Yarn_Reports();
            Yarn.ReportingParameters.nYarnSizingPOLedger yru_itemledger = new Yarn.ReportingParameters.nYarnSizingPOLedger();
            Report.reportControlParent.Size = yru_itemledger.Size;
            Report.Size = yru_itemledger.Size;
            Report.reportControlParent.Controls.Add(yru_itemledger);
            Report.Show();
        }

        private void MonthlyIssuanceOthers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4 and IssueTypeID is null group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.IssueType.Text = " (Others) ";
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void MonthlyIssuanceAllAccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Param_TwoDates Dates = new Data.Param_TwoDates();
            Dates.ShowDialog();
            if (SelectedDate.isCanceled == true) return;
            if (SelectedDate.upTo == null) return;
            if (SelectedDate.Date == null) return;
            Reports.Store_MonthlyIssuanceDetailedItem MonthlyIssuance = new Reports.Store_MonthlyIssuanceDetailedItem();
            string query = "select ItemAccountID,ItemAccountName,DepartmentName,LoomName,UOM,Avg(MinusRate) as MinusRate,Sum(MinusQty) as MinusQty,Sum(MinusAmount) as MinusAmount from RST_StoreDetails where Dated>='" + SelectedDate.Date.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and Dated<='" + SelectedDate.upTo.ToString(MachineEyes.Classes.Accounting.culture.DateTimeFormat.ShortDatePattern) + "' and PRTypeID=4  group by ItemAccountID,ItemAccountName,DepartmentName,UOM,loomName order by DepartmentName,ItemAccountID,ItemAccountName,UOM,LoomName";
            DataSet ds = WS.svc.Get_DataSet(query);
            if (ds != null)
                ds.Tables[0].DefaultView.RowFilter = "MinusAmount>0";

            MonthlyIssuance.BeginInit();
            MonthlyIssuance.IssueType.Text = "All A/C";
            MonthlyIssuance.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            MonthlyIssuance.From.Text = SelectedDate.Date.ToString("dd-MMM-yyyy");
            MonthlyIssuance.Upto.Text = SelectedDate.upTo.ToString("dd-MMM-yyyy");
            if (ds != null) MonthlyIssuance.DataSource = ds.Tables[0];
            MonthlyIssuance.EndInit();
            MonthlyIssuance.ShowPreview();
        }

        private void Contracts_Sales_Fabric_Sale_ItemClick(object sender, ItemClickEventArgs e)
        {
            PO.Fabric_Contract_Sales_Greige GreigePO = new PO.Fabric_Contract_Sales_Greige();
            GreigePO.MdiParent = this;
            GreigePO.Show();
        }

        private void Contracts_Sales_Fabric_Conversion_ItemClick(object sender, ItemClickEventArgs e)
        {
            PO.Fabric_Contract_Conversion_Greige ConversionPO = new PO.Fabric_Contract_Conversion_Greige();
            ConversionPO.MdiParent = this;
            ConversionPO.Show();
        }

        private void Contracts_Sales_Fabric_Overhead_ItemClick(object sender, ItemClickEventArgs e)
        {
            PO.Fabric_Contract_Overhead_Greige OverheadPO = new PO.Fabric_Contract_Overhead_Greige();
            OverheadPO.MdiParent = this;
            OverheadPO.Show();
        }

        private void Store_RequisitionList_ItemClick(object sender, ItemClickEventArgs e)
        {
            Store.Store_StoreRequisitionList ReqList = new Store.Store_StoreRequisitionList();
            ReqList.MdiParent = this;
            ReqList.Show();
        }

        private void Store_MonthlyDepartmentIssuance_ItemClick(object sender, ItemClickEventArgs e)
        {
            Reports.Parameters.ReportsMDI Report = new Reports.Parameters.ReportsMDI();
            Store.ReportingParameters.nStoreDepartmentIssuance summary = new Store.ReportingParameters.nStoreDepartmentIssuance();
            Report.reportControlParent.Size = summary.Size;
            Report.Size = summary.Size;
            Report.reportControlParent.Controls.Add(summary);
            Report.Show();
        }

        private void barButtonItem_MoveRunningPercent_ItemClick(object sender, ItemClickEventArgs e)
        {
           // CurrentSelection
             if (CurrentSelection.CategorySelected!=null)
            {
            //    Dashboard_Shed dashboard = (Dashboard_Shed)CurrentSelection.SelectedView;
                UserControls.dxLoomCategory lCat = (UserControls.dxLoomCategory)CurrentSelection.CategorySelected;
                lCat.Panel_Looms.Dock = DockStyle.None;
                lCat.Panel_Looms.Height = 5;
                lCat.Panel_Looms.Width = 5;
                 ControlMoverOrResizer.Init(lCat);
                
                ControlMoverOrResizer.ControlsAreInResizeMode = true;
            //    barButtonItem_SaveRunningPercentLocation.Enabled = true;
            }
        }

        private void barButtonItem_SaveRunningPercentLocation_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (CurrentSelection.SelectedView is Dashboard_Shed)
            //{
            //    Dashboard_Shed dashboard = (Dashboard_Shed)CurrentSelection.SelectedView;

              

            //    ControlMoverOrResizer.ControlsAreInResizeMode = false;
            //    string res = WS.svc.Execute_Query("Update MT_Sheds set PercentRunningX=" + dashboard.percentRunning.Left + ",PercentRunningY=" + dashboard.percentRunning.Top + " where ShedID=" + dashboard.percentRunning.Tag.ToString() + "");
            //    if (res != "**SUCCESS##")
            //    {
            //        XtraMessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //    else
            //    {
            //        barButtonItem_SaveRunningPercentLocation.Enabled = false;
            //    }
               
            //}
        }

        private void ButtonEfficiencyType_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
            {
                Settings.efficiencyType = EfficiencyType.ProductionEfficiency;
                ButtonEfficiencyType.Caption = "Production Efficiency";
               
            }
            else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
            {
                Settings.efficiencyType = EfficiencyType.TimeEfficiency;
                ButtonEfficiencyType.Caption = "Time Shed Efficiency";

            }
            else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency)
            {
                Settings.efficiencyType = EfficiencyType.TimeProductionEfficiency;
                ButtonEfficiencyType.Caption = "Time Production Efficiency";

            }
            else if (Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
            {
                Settings.efficiencyType = EfficiencyType.ShedEfficiency;
                ButtonEfficiencyType.Caption = "Shed Efficiency";

            }
        }

        private void DailyReport_DailySummary_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DailyReports_DailyLoomSummary(0);

          
        }


        private void DailyReports_DailyLoomSummary(int ShedIndex)
        {

            Param_Date DateForm = new Param_Date();
            DateForm.ShowDialog();
            if (SelectedDate.isCanceled == true)
                return;
            Reports.Summary_Daily_ABC AB = new Reports.Summary_Daily_ABC();
            AB.BeginInit();
            //AB.ShedIndex = ShedIndex;
            AB.repH_Shed.Text = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedName;
            AB.repH_Shed.Tag = Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID;
            AB.RepH_Company.Text = Program.ss.Machines.PresentationData.CPInfo.cpName;
            AB.repH_Dated.Text = SelectedDate.Date.ToLongDateString();
            string dsstring = "SELECT     * from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) order by GroupNumber,Convert(numeric(9),LoomName)";
           
            DataSet ds = WS.svc.Get_DataSet(dsstring);
            if (ds != null)
            {
                //DataView dv_Main = ds.Tables[0].DefaultView;
                //dv_Main.Sort = "  ArticleName,LoomName";

               // DataTable dAB = dv_Main.ToTable();
                AB.DataSource = ds.Tables[0];
            }
            else
                AB.DataSource = null;

            Reports.Efficiency_DailyLoss_SubReport ShortLossReport = new Reports.Efficiency_DailyLoss_SubReport();
            string ShortStopString = "SELECT    Avg(T_WarpCMPX) as T_WarpCMPX,Avg(T_WeftCMPX) as T_WeftCMPX,Avg(T_OtherCMPX) as T_OtherCMPX, Sum(A_WarpStops) as A_WarpStops,Sum(A_WarpLoss)/Count(LoomID) as A_WarpLoss,Avg(A_WarpPerHour) as A_WarpPerHour , Sum(A_WeftStops) as A_WeftStops,Sum(A_WeftLoss)/Count(LoomID) as A_WeftLoss,Avg(A_WeftPerHour) as A_WeftPerHour,   Sum(A_OtherStops) as A_OtherStops,Sum(A_OtherLoss)/Count(LoomID) as A_OtherLoss,Avg(A_OtherPerHour) as A_OtherPerHour,  Sum(B_WarpStops) as B_WarpStops,Sum(B_WarpLoss)/Count(LoomID) as B_WarpLoss,Avg(B_WarpPerHour) as B_WarpPerHour , Sum(B_WeftStops) as B_WeftStops,Sum(B_WeftLoss)/Count(LoomID) as B_WeftLoss,Avg(B_WeftPerHour) as B_WeftPerHour,   Sum(B_OtherStops) as B_OtherStops,Sum(B_OtherLoss)/Count(LoomID) as B_OtherLoss,Avg(B_OtherPerHour) as B_OtherPerHour,  Sum(C_WarpStops) as C_WarpStops,Sum(C_WarpLoss)/Count(LoomID) as C_WarpLoss,Avg(C_WarpPerHour) as C_WarpPerHour , Sum(C_WeftStops) as C_WeftStops,Sum(C_WeftLoss)/Count(LoomID) as C_WeftLoss,Avg(C_WeftPerHour) as C_WeftPerHour,   Sum(C_OtherStops) as C_OtherStops,Sum(C_OtherLoss)/Count(LoomID) as C_OtherLoss,Avg(C_OtherPerHour) as C_OtherPerHour,  Sum(T_WarpStops) as T_WarpStops,Sum(T_WarpLoss)/Count(LoomID) as T_WarpLoss,Avg(T_WarpPerHour) as T_WarpPerHour , Sum(T_WeftStops) as T_WeftStops,Sum(T_WeftLoss)/Count(LoomID) as T_WeftLoss,Avg(T_WeftPerHour) as T_WeftPerHour,   Sum(T_OtherStops) as T_OtherStops,Sum(T_OtherLoss)/Count(LoomID) as T_OtherLoss,Avg(T_OtherPerHour) as T_OtherPerHour from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") ";

            DataSet dsShortStopsSummary = WS.svc.Get_DataSet(ShortStopString);
            if (dsShortStopsSummary != null)
            {

                double A_WarpLoss = 0; double A_WarpPerHour = 0; 
                double A_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpStops"].ToString(), out A_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpPerHour"].ToString(), out A_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WarpLoss"].ToString(), out A_WarpLoss);
                

                A_WarpLoss = double.IsNaN(A_WarpLoss) == true ? 0 : A_WarpLoss;
                A_WarpPerHour = double.IsNaN(A_WarpPerHour) == true ? 0 : A_WarpPerHour;
                ShortLossReport.A_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_WarpStops"].ToString();
                ShortLossReport.A_WarpPerHour.Text = A_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.A_WarpLoss.Text = A_WarpLoss.ToString("#,##0.00");

                double A_WeftLoss = 0; double A_WeftPerHour = 0;
                double A_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftStops"].ToString(), out A_WeftStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftPerHour"].ToString(), out A_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_WeftLoss"].ToString(), out A_WeftLoss);
                A_WeftLoss = double.IsNaN(A_WeftLoss) == true ? 0 : A_WeftLoss;
                A_WeftPerHour = double.IsNaN(A_WeftPerHour) == true ? 0 : A_WeftPerHour;
                ShortLossReport.A_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_WeftStops"].ToString();
                ShortLossReport.A_WeftPerHour.Text = A_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.A_WeftLoss.Text = A_WeftLoss.ToString("#,##0.00");

                double A_OtherLoss = 0; double A_OtherPerHour = 0;
                double A_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherStops"].ToString(), out A_OtherStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherPerHour"].ToString(), out A_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["A_OtherLoss"].ToString(), out A_OtherLoss);
                A_OtherLoss = double.IsNaN(A_OtherLoss) == true ? 0 : A_OtherLoss;
                A_OtherPerHour = double.IsNaN(A_OtherPerHour) == true ? 0 : A_OtherPerHour;
                ShortLossReport.A_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["A_OtherStops"].ToString();
                ShortLossReport.A_OtherPerHour.Text = A_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.A_OtherLoss.Text = A_OtherLoss.ToString("#,##0.00");

                ////////////////////////////////////////////////////////////////////////////
                double B_WarpLoss = 0; double B_WarpPerHour = 0;
                double B_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpStops"].ToString(), out B_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpPerHour"].ToString(), out B_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WarpLoss"].ToString(), out B_WarpLoss);
                B_WarpLoss = double.IsNaN(B_WarpLoss) == true ? 0 : B_WarpLoss;
                B_WarpPerHour = double.IsNaN(B_WarpPerHour) == true ? 0 : B_WarpPerHour;
                ShortLossReport.B_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_WarpStops"].ToString();
                ShortLossReport.B_WarpPerHour.Text = B_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.B_WarpLoss.Text = B_WarpLoss.ToString("#,##0.00");

                double B_WeftLoss = 0; double B_WeftPerHour = 0;
                double B_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftStops"].ToString(), out B_WeftStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftPerHour"].ToString(), out B_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_WeftLoss"].ToString(), out B_WeftLoss);
                B_WeftLoss = double.IsNaN(B_WeftLoss) == true ? 0 : B_WeftLoss;
                B_WeftPerHour = double.IsNaN(B_WeftPerHour) == true ? 0 : B_WeftPerHour;
                ShortLossReport.B_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_WeftStops"].ToString();
                ShortLossReport.B_WeftPerHour.Text = B_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.B_WeftLoss.Text = B_WeftLoss.ToString("#,##0.00");

                double B_OtherLoss = 0; double B_OtherPerHour = 0;
                double B_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherStops"].ToString(), out B_OtherStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherPerHour"].ToString(), out B_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["B_OtherLoss"].ToString(), out B_OtherLoss);
                B_OtherLoss = double.IsNaN(B_OtherLoss) == true ? 0 : B_OtherLoss;
                B_OtherPerHour = double.IsNaN(B_OtherPerHour) == true ? 0 : B_OtherPerHour;
                ShortLossReport.B_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["B_OtherStops"].ToString();
                ShortLossReport.B_OtherPerHour.Text = B_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.B_OtherLoss.Text = B_OtherLoss.ToString("#,##0.00");
                /////////////////////////////////////////////////////////////////////////////////

                ////////////////////////////////////////////////////////////////////////////
                double C_WarpLoss = 0; double C_WarpPerHour = 0;
                double C_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WarpStops"].ToString(), out C_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WarpPerHour"].ToString(), out C_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WarpLoss"].ToString(), out C_WarpLoss);
                C_WarpLoss = double.IsNaN(C_WarpLoss) == true ? 0 : C_WarpLoss;
                C_WarpPerHour = double.IsNaN(C_WarpPerHour) == true ? 0 : C_WarpPerHour;
                ShortLossReport.C_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["C_WarpStops"].ToString();
                ShortLossReport.C_WarpPerHour.Text = C_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.C_WarpLoss.Text = C_WarpLoss.ToString("#,##0.00");

                double C_WeftLoss = 0; double C_WeftPerHour = 0;
                double C_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WeftStops"].ToString(), out C_WeftStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WeftPerHour"].ToString(), out C_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_WeftLoss"].ToString(), out C_WeftLoss);
                C_WeftLoss = double.IsNaN(C_WeftLoss) == true ? 0 : C_WeftLoss;
                C_WeftPerHour = double.IsNaN(C_WeftPerHour) == true ? 0 : C_WeftPerHour;
                ShortLossReport.C_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["C_WeftStops"].ToString();
                ShortLossReport.C_WeftPerHour.Text = C_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.C_WeftLoss.Text = C_WeftLoss.ToString("#,##0.00");

                double C_OtherLoss = 0; double C_OtherPerHour = 0;
                double C_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_OtherStops"].ToString(), out C_OtherStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_OtherPerHour"].ToString(), out C_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["C_OtherLoss"].ToString(), out C_OtherLoss);
                C_OtherLoss = double.IsNaN(C_OtherLoss) == true ? 0 : C_OtherLoss;
                C_OtherPerHour = double.IsNaN(C_OtherPerHour) == true ? 0 : C_OtherPerHour;
                ShortLossReport.C_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["C_OtherStops"].ToString();
                ShortLossReport.C_OtherPerHour.Text = C_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.C_OtherLoss.Text = C_OtherLoss.ToString("#,##0.00");
                /////////////////////////////////////////////////////////////////////////////////



                double T_WarpLoss = 0; double T_WarpPerHour = 0; double T_WarpCMPX = 0; double T_WeftCMPX = 0; double T_OtherCMPX = 0;
                double T_WarpStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpStops"].ToString(), out T_WarpStops);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpPerHour"].ToString(), out T_WarpPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpLoss"].ToString(), out T_WarpLoss);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WarpCMPX"].ToString(), out T_WarpCMPX);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftCMPX"].ToString(), out T_WeftCMPX);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherCMPX"].ToString(), out T_OtherCMPX);
                T_WarpCMPX = double.IsNaN(T_WarpCMPX) == true ? 0 : T_WarpCMPX;
                T_WeftCMPX = double.IsNaN(T_WeftCMPX) == true ? 0 : T_WeftCMPX;
                T_OtherCMPX = double.IsNaN(T_OtherCMPX) == true ? 0 : T_OtherCMPX;

                T_WarpLoss = double.IsNaN(T_WarpLoss) == true ? 0 : T_WarpLoss;
                T_WarpPerHour = double.IsNaN(T_WarpPerHour) == true ? 0 : T_WarpPerHour;
                ShortLossReport.T_WarpStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_WarpStops"].ToString();
                ShortLossReport.T_WarpPerHour.Text = T_WarpPerHour.ToString("#,##0.00");
                ShortLossReport.T_WarpLoss.Text = T_WarpLoss.ToString("#,##0.00");
               
                double T_WeftLoss = 0; double T_WeftPerHour = 0;
                double T_WeftStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftStops"].ToString(), out T_WeftStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftPerHour"].ToString(), out T_WeftPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_WeftLoss"].ToString(), out T_WeftLoss);
                T_WeftLoss = double.IsNaN(T_WeftLoss) == true ? 0 : T_WeftLoss;
                T_WeftPerHour = double.IsNaN(T_WeftPerHour) == true ? 0 : T_WeftPerHour;
                ShortLossReport.T_WeftStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_WeftStops"].ToString();
                ShortLossReport.T_WeftPerHour.Text = T_WeftPerHour.ToString("#,##0.00");
                ShortLossReport.T_WeftLoss.Text = T_WeftLoss.ToString("#,##0.00");

                double T_OtherLoss = 0; double T_OtherPerHour = 0;
                double T_OtherStops = 0;
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherStops"].ToString(), out T_OtherStops);

                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherPerHour"].ToString(), out T_OtherPerHour);
                double.TryParse(dsShortStopsSummary.Tables[0].Rows[0]["T_OtherLoss"].ToString(), out T_OtherLoss);
                T_OtherLoss = double.IsNaN(T_OtherLoss) == true ? 0 : T_OtherLoss;
                T_OtherPerHour = double.IsNaN(T_OtherPerHour) == true ? 0 : T_OtherPerHour;
                ShortLossReport.T_OtherStops.Text = dsShortStopsSummary.Tables[0].Rows[0]["T_OtherStops"].ToString();
                ShortLossReport.T_OtherPerHour.Text = T_OtherPerHour.ToString("#,##0.00");
                ShortLossReport.T_OtherLoss.Text = T_OtherLoss.ToString("#,##0.00");

                double T_TotalCMPX = 0;
                double A_TotalStops = 0, A_TotalLoss = 0, A_TotalPerHour = 0;
                if (double.IsNaN(A_WarpStops) == false)
                    A_TotalStops += A_WarpStops;
                if (double.IsNaN(A_WeftStops) == false)
                    A_TotalStops += A_WeftStops;
                if (double.IsNaN(A_OtherStops) == false)
                    A_TotalStops += A_OtherStops;

                if (double.IsNaN(A_WarpLoss) == false)
                    A_TotalLoss += A_WarpLoss;
                if (double.IsNaN(A_WeftLoss) == false)
                    A_TotalLoss += A_WeftLoss;
                if (double.IsNaN(A_OtherLoss) == false)
                    A_TotalLoss += A_OtherLoss;

                if (double.IsNaN(A_WarpPerHour) == false)
                    A_TotalPerHour += A_WarpPerHour;
                if (double.IsNaN(A_WeftPerHour) == false)
                    A_TotalPerHour += A_WeftPerHour;
                if (double.IsNaN(A_OtherPerHour) == false)
                    A_TotalPerHour += A_OtherPerHour;
                T_TotalCMPX = T_WarpCMPX + T_WeftCMPX + T_OtherCMPX;
                ShortLossReport.T_WarpCMPX.Text = T_WarpCMPX.ToString("#,##0.00");
                ShortLossReport.T_WeftCMPX.Text = T_WeftCMPX.ToString("#,##0.00");
                ShortLossReport.T_OtherCMPX.Text = T_OtherCMPX.ToString("#,##0.00");
                ShortLossReport.T_TotalCMPX.Text = T_TotalCMPX.ToString("#,##0.00");
                ShortLossReport.A_TotalStops.Text = A_TotalStops.ToString("#,##");
                ShortLossReport.A_TotalperHour.Text = A_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.A_TotalLoss.Text = A_TotalLoss.ToString("#,##0.00");
               
                double B_TotalStops = 0, B_TotalLoss = 0, B_TotalPerHour = 0;
                if (double.IsNaN(B_WarpStops) == false)
                    B_TotalStops += B_WarpStops;
                if (double.IsNaN(B_WeftStops) == false)
                    B_TotalStops += B_WeftStops;
                if (double.IsNaN(B_OtherStops) == false)
                    B_TotalStops += B_OtherStops;

                if (double.IsNaN(B_WarpLoss) == false)
                    B_TotalLoss += B_WarpLoss;
                if (double.IsNaN(B_WeftLoss) == false)
                    B_TotalLoss += B_WeftLoss;
                if (double.IsNaN(B_OtherLoss) == false)
                    B_TotalLoss += B_OtherLoss;

                if (double.IsNaN(B_WarpPerHour) == false)
                    B_TotalPerHour += B_WarpPerHour;
                if (double.IsNaN(B_WeftPerHour) == false)
                    B_TotalPerHour += B_WeftPerHour;
                if (double.IsNaN(B_OtherPerHour) == false)
                    B_TotalPerHour += B_OtherPerHour;

                ShortLossReport.B_TotalStops.Text = B_TotalStops.ToString("#,##");
                ShortLossReport.B_TotalPerHour.Text = B_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.B_TotalLoss.Text = B_TotalLoss.ToString("#,##0.00");


                double C_TotalStops = 0, C_TotalLoss = 0, C_TotalPerHour = 0;
                if (double.IsNaN(C_WarpStops) == false)
                    C_TotalStops += C_WarpStops;
                if (double.IsNaN(C_WeftStops) == false)
                    C_TotalStops += C_WeftStops;
                if (double.IsNaN(C_OtherStops) == false)
                    C_TotalStops += C_OtherStops;

                if (double.IsNaN(C_WarpLoss) == false)
                    C_TotalLoss += C_WarpLoss;
                if (double.IsNaN(C_WeftLoss) == false)
                    C_TotalLoss += C_WeftLoss;
                if (double.IsNaN(C_OtherLoss) == false)
                    C_TotalLoss += C_OtherLoss;

                if (double.IsNaN(C_WarpPerHour) == false)
                    C_TotalPerHour += C_WarpPerHour;
                if (double.IsNaN(C_WeftPerHour) == false)
                    C_TotalPerHour += C_WeftPerHour;
                if (double.IsNaN(C_OtherPerHour) == false)
                    C_TotalPerHour += C_OtherPerHour;

                ShortLossReport.C_TotalStops.Text = C_TotalStops.ToString("#,##");
                ShortLossReport.C_TotalPerHour.Text = C_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.C_TotalLoss.Text = C_TotalLoss.ToString("#,##0.00");




                double T_TotalStops = 0, T_TotalLoss = 0, T_TotalPerHour = 0;
                if (double.IsNaN(T_WarpStops) == false)
                    T_TotalStops += T_WarpStops;
                if (double.IsNaN(T_WeftStops) == false)
                    T_TotalStops += T_WeftStops;
                if (double.IsNaN(T_OtherStops) == false)
                    T_TotalStops += T_OtherStops;

                if (double.IsNaN(T_WarpLoss) == false)
                    T_TotalLoss += T_WarpLoss;
                if (double.IsNaN(T_WeftLoss) == false)
                    T_TotalLoss += T_WeftLoss;
                if (double.IsNaN(T_OtherLoss) == false)
                    T_TotalLoss += T_OtherLoss;

                if (double.IsNaN(T_WarpPerHour) == false)
                    T_TotalPerHour += T_WarpPerHour;
                if (double.IsNaN(T_WeftPerHour) == false)
                    T_TotalPerHour += T_WeftPerHour;
                if (double.IsNaN(T_OtherPerHour) == false)
                    T_TotalPerHour += T_OtherPerHour;

                ShortLossReport.T_TotalStops.Text = T_TotalStops.ToString("#,##");
                ShortLossReport.T_TotalPerHour.Text = T_TotalPerHour.ToString("#,##0.00");
                ShortLossReport.T_TotalLoss.Text = T_TotalLoss.ToString("#,##0.00");

            }



            Reports.Efficiency_ArticleWiseSubReport ArticleWiseSubReport = new Reports.Efficiency_ArticleWiseSubReport();
            string ArticleWiseString = "SELECT     ArticleNumber,ArticleName,Avg(T_RPM) as T_RPM,Count(Distinct LoomID) as TotalLooms,Avg(A_Eff) as A_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(T_Eff) as T_Eff,Sum(T_WarpStops) as T_WarpStops,Avg(T_WarpPerHour) as T_WarpPerHour , Sum(T_WeftStops) as T_WeftStops,Avg(T_WarpCMPX) as T_WarpCMPX ,Avg(T_WeftCMPX) as T_WeftCMPX,Avg(T_WeftPerHour) as T_WeftPerHour,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY ArticleNumber, ArticleName";

            DataSet dsArticleWiseSummary = WS.svc.Get_DataSet(ArticleWiseString);
            if (dsArticleWiseSummary != null)
            {

                ArticleWiseSubReport.DataSource = dsArticleWiseSummary.Tables[0];
            }

            Reports.Efficiency_SetWiseSubReport SetWiseSubReport = new Reports.Efficiency_SetWiseSubReport();
            string SetWiseString = "SELECT     SetNo,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Sum(T_WarpStops) as T_WarpStops,Avg(T_WarpPerHour) as T_WarpPerHour ,Avg(T_WarpCMPX) as T_WarpCMPX, Sum(T_WeftStops) as T_WeftStops,Avg(T_WeftPerHour) as T_WeftPerHour ,Avg(T_WeftCMPX) as T_WeftCMPX ,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY SetNo";

            DataSet dsSetWiseSummary = WS.svc.Get_DataSet(SetWiseString);
            if (dsSetWiseSummary != null)
            {

                SetWiseSubReport.DataSource = dsSetWiseSummary.Tables[0];
            }
            TimeSpan ts=new TimeSpan(7,0,0,0);
            /////////////////////////////////////////////////////////////////////////////////////////Worse Looms of week/////////////////////////////////////////////////////////////////////////////
            DateTime StartWeek = SelectedDate.Date.Subtract(ts);
         
            Reports.Efficiency_Weekly_WorseLooms_SubReport WorseLoomsSubReport = new Reports.Efficiency_Weekly_WorseLooms_SubReport();
            string WorseLoomsSubReportString = "SELECT    Top(5) LoomID,LoomName,Avg(T_RPM) as T_RPM,Avg(T_Eff) as T_Eff,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)>=" + StartWeek.Date.Day + " and datepart(MONTH, ShiftDate)>=" + StartWeek.Date.Month + " and datepart(YEAR, ShiftDate)>=" + StartWeek.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY LoomID,LoomName order by Avg(T_Eff) ";

            DataSet dsWorseLoomsSubReport = WS.svc.Get_DataSet(WorseLoomsSubReportString);
            if (dsWorseLoomsSubReport != null)
            {

                WorseLoomsSubReport.DataSource = dsWorseLoomsSubReport.Tables[0];
            }

            Reports.Efficiency_Weekly_GoodLooms_SubReport GoodLoomsSubReport = new Reports.Efficiency_Weekly_GoodLooms_SubReport();
            string GoodLoomsSubReportString = "SELECT    Top(5) LoomID,LoomName,Avg(T_RPM) as T_RPM,Avg(T_Eff) as T_Eff,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)>=" + StartWeek.Date.Day + " and datepart(MONTH, ShiftDate)>=" + StartWeek.Date.Month + " and datepart(YEAR, ShiftDate)>=" + StartWeek.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY LoomID,LoomName order by Avg(T_Eff) desc ";

            DataSet dsGoodLoomsSubReport = WS.svc.Get_DataSet(GoodLoomsSubReportString);
            if (dsGoodLoomsSubReport != null)
            {

                GoodLoomsSubReport.DataSource = dsGoodLoomsSubReport.Tables[0];
            }

            Reports.Efficiency_Weekly_GoodArticles_SubReport GoodArticlesSubReport = new Reports.Efficiency_Weekly_GoodArticles_SubReport();
            string GoodArticlesSubReportString = "SELECT    Top(5) ArticleNumber,Count(Distinct LoomID) as TotalLooms,Avg(T_RPM) as T_RPM,Avg(T_Eff) as T_Eff,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)>=" + StartWeek.Date.Day + " and datepart(MONTH, ShiftDate)>=" + StartWeek.Date.Month + " and datepart(YEAR, ShiftDate)>=" + StartWeek.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY ArticleNumber order by Avg(T_Eff) desc ";

            DataSet dsGoodArticlesSubReport = WS.svc.Get_DataSet(GoodArticlesSubReportString);
            if (dsGoodArticlesSubReport != null)
            {

                GoodArticlesSubReport.DataSource = dsGoodArticlesSubReport.Tables[0];
            }


            Reports.Efficiency_Weekly_PoorArticles_SubReport PoorArticlesSubReport = new Reports.Efficiency_Weekly_PoorArticles_SubReport();
            string PoorArticlesSubReportString = "SELECT    Top(5) ArticleNumber,Count(Distinct LoomID) as TotalLooms,Avg(T_RPM) as T_RPM,Avg(T_Eff) as T_Eff,sum(T_Meters) as T_Meters  from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)>=" + StartWeek.Date.Day + " and datepart(MONTH, ShiftDate)>=" + StartWeek.Date.Month + " and datepart(YEAR, ShiftDate)>=" + StartWeek.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") GROUP BY ArticleNumber order by Avg(T_Eff) ";

            DataSet dsPoorArticlesSubReport = WS.svc.Get_DataSet(PoorArticlesSubReportString);
            if (dsPoorArticlesSubReport != null)
            {

                PoorArticlesSubReport.DataSource = dsPoorArticlesSubReport.Tables[0];
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string LongStopString = "SELECT     Sum(A_MechanicalLoss)/Count(LoomID) as A_MechanicalLoss,Sum(A_ElectricalLoss)/Count(LoomID) as A_ElectricalLoss,Sum(A_KnottingLoss)/Count(LoomID) as A_KnottingLoss,Sum(A_ArticleLoss)/Count(LoomID) as A_ArticleLoss,Sum(A_LongStop_5_Loss)/Count(LoomID) as A_LongStop_5_Loss,Sum(A_LongStop_6_Loss)/Count(LoomID) as A_LongStop_6_Loss,Sum(A_LongStop_7_Loss)/Count(LoomID) as A_LongStop_7_Loss,Sum(A_LongStop_8_Loss)/Count(LoomID) as A_LongStop_8_Loss,Sum(A_LongStop_9_Loss)/Count(LoomID) as A_LongStop_9_Loss,Sum(A_PowerOffLoss)/Count(LoomID) as A_PowerOffLoss,Sum(A_LongOtherLoss)/Count(LoomID) as A_LongOtherLoss, Sum(B_MechanicalLoss)/Count(LoomID) as B_MechanicalLoss,Sum(B_ElectricalLoss)/Count(LoomID) as B_ElectricalLoss,Sum(B_KnottingLoss)/Count(LoomID) as B_KnottingLoss,Sum(B_ArticleLoss)/Count(LoomID) as B_ArticleLoss,Sum(B_LongStop_5_Loss)/Count(LoomID) as B_LongStop_5_Loss,Sum(B_LongStop_6_Loss)/Count(LoomID) as B_LongStop_6_Loss,Sum(B_LongStop_7_Loss)/Count(LoomID) as B_LongStop_7_Loss,Sum(B_LongStop_8_Loss)/Count(LoomID) as B_LongStop_8_Loss,Sum(B_LongStop_9_Loss)/Count(LoomID) as B_LongStop_9_Loss,Sum(B_PowerOffLoss)/Count(LoomID) as B_PowerOffLoss,Sum(B_LongOtherLoss)/Count(LoomID) as B_LongOtherLoss,Sum(C_MechanicalLoss)/Count(LoomID) as C_MechanicalLoss,Sum(C_ElectricalLoss)/Count(LoomID) as C_ElectricalLoss,Sum(C_KnottingLoss)/Count(LoomID) as C_KnottingLoss,Sum(C_ArticleLoss)/Count(LoomID) as C_ArticleLoss,Sum(C_LongStop_5_Loss)/Count(LoomID) as C_LongStop_5_Loss,Sum(C_LongStop_6_Loss)/Count(LoomID) as C_LongStop_6_Loss,Sum(C_LongStop_7_Loss)/Count(LoomID) as C_LongStop_7_Loss,Sum(C_LongStop_8_Loss)/Count(LoomID) as C_LongStop_8_Loss,Sum(C_LongStop_9_Loss)/Count(LoomID) as C_LongStop_9_Loss,Sum(C_PowerOffLoss)/Count(LoomID) as C_PowerOffLoss,Sum(C_LongOtherLoss)/Count(LoomID) as C_LongOtherLoss,Sum(T_MechanicalLoss)/Count(LoomID) as T_MechanicalLoss,Sum(T_ElectricalLoss)/Count(LoomID) as T_ElectricalLoss,Sum(T_KnottingLoss)/Count(LoomID) as T_KnottingLoss,Sum(T_ArticleLoss)/Count(LoomID) as T_ArticleLoss,Sum(T_LongStop_5_Loss)/Count(LoomID) as T_LongStop_5_Loss,Sum(T_LongStop_6_Loss)/Count(LoomID) as T_LongStop_6_Loss,Sum(T_LongStop_7_Loss)/Count(LoomID) as T_LongStop_7_Loss,Sum(T_LongStop_8_Loss)/Count(LoomID) as T_LongStop_8_Loss,Sum(T_LongStop_9_Loss)/Count(LoomID) as T_LongStop_9_Loss,Sum(T_PowerOffLoss)/Count(LoomID) as T_PowerOffLoss,Sum(T_LongOtherLoss)/Count(LoomID) as T_LongOtherLoss,Sum(A_LongLoss)/Count(LoomID) as A_LongLoss,Sum(B_LongLoss)/Count(LoomID) as B_LongLoss,Sum(C_LongLoss)/Count(LoomID) as C_LongLoss,Sum(T_LongLoss)/Count(LoomID) as T_LongLoss from RP_DailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + ") ";


            

            DataSet dsLongStopSummary = WS.svc.Get_DataSet(LongStopString);
            if (dsLongStopSummary != null)
            {
                double A_TotalLongLoss = 0;
                double B_TotalLongLoss = 0;
                double C_TotalLongLoss = 0;
                double T_TotalLongLoss = 0;

                double A_MechanicalLoss = 0; 
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_MechanicalLoss"].ToString(), out A_MechanicalLoss);
                A_MechanicalLoss = double.IsNaN(A_MechanicalLoss) == true ? 0 : A_MechanicalLoss;
                A_TotalLongLoss += A_MechanicalLoss;
                ShortLossReport.L_A_Mechanical.Text = A_MechanicalLoss.ToString("#,##0.00");

                double A_ElectricalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_ElectricalLoss"].ToString(), out A_ElectricalLoss);
                A_ElectricalLoss = double.IsNaN(A_ElectricalLoss) == true ? 0 : A_ElectricalLoss;
                A_TotalLongLoss += A_ElectricalLoss;

                ShortLossReport.L_A_Electrical.Text = A_ElectricalLoss.ToString("#,##0.00");

                double A_KnottingLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_KnottingLoss"].ToString(), out A_KnottingLoss);
                A_KnottingLoss = double.IsNaN(A_KnottingLoss) == true ? 0 : A_KnottingLoss;
                A_TotalLongLoss += A_KnottingLoss;

                ShortLossReport.L_A_Knotting.Text = A_KnottingLoss.ToString("#,##0.00");

                double A_ArticleLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_ArticleLoss"].ToString(), out A_ArticleLoss);
                A_ArticleLoss = double.IsNaN(A_ArticleLoss) == true ? 0 : A_ArticleLoss;
                A_TotalLongLoss += A_ArticleLoss;

                ShortLossReport.L_A_Article.Text = A_ArticleLoss.ToString("#,##0.00");

                double A_PowerOffLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_PowerOffLoss"].ToString(), out A_PowerOffLoss);
                A_PowerOffLoss = double.IsNaN(A_PowerOffLoss) == true ? 0 : A_PowerOffLoss;
                A_TotalLongLoss += A_PowerOffLoss;

                ShortLossReport.L_A_PowerOff.Text = A_PowerOffLoss.ToString("#,##0.00");

                double A_LongOtherLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongOtherLoss"].ToString(), out A_LongOtherLoss);
                A_LongOtherLoss = double.IsNaN(A_LongOtherLoss) == true ? 0 : A_LongOtherLoss;
                A_TotalLongLoss += A_LongOtherLoss;

                ShortLossReport.L_A_Other.Text = A_LongOtherLoss.ToString("#,##0.00");

                double A_LongStop_5_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongStop_5_Loss"].ToString(), out A_LongStop_5_Loss);
                A_LongStop_5_Loss = double.IsNaN(A_LongStop_5_Loss) == true ? 0 : A_LongStop_5_Loss;
                A_TotalLongLoss += A_LongStop_5_Loss;

                ShortLossReport.L_A_LongStop_5.Text = A_LongStop_5_Loss.ToString("#,##0.00");

                double A_LongStop_6_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongStop_6_Loss"].ToString(), out A_LongStop_6_Loss);
                A_LongStop_6_Loss = double.IsNaN(A_LongStop_6_Loss) == true ? 0 : A_LongStop_6_Loss;
                A_TotalLongLoss += A_LongStop_6_Loss;
                ShortLossReport.L_A_LongStop_6.Text = A_LongStop_6_Loss.ToString("#,##0.00");

                double A_LongStop_7_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongStop_7_Loss"].ToString(), out A_LongStop_7_Loss);
                A_LongStop_7_Loss = double.IsNaN(A_LongStop_7_Loss) == true ? 0 : A_LongStop_7_Loss;
                A_TotalLongLoss += A_LongStop_7_Loss;
                ShortLossReport.L_A_LongStop_7.Text = A_LongStop_7_Loss.ToString("#,##0.00");

                double A_LongStop_8_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongStop_8_Loss"].ToString(), out A_LongStop_8_Loss);
                A_LongStop_8_Loss = double.IsNaN(A_LongStop_8_Loss) == true ? 0 : A_LongStop_8_Loss;
                A_TotalLongLoss += A_LongStop_8_Loss;
                ShortLossReport.L_A_LongStop_8.Text = A_LongStop_8_Loss.ToString("#,##0.00");

                double A_LongStop_9_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["A_LongStop_9_Loss"].ToString(), out A_LongStop_9_Loss);
                A_LongStop_9_Loss = double.IsNaN(A_LongStop_9_Loss) == true ? 0 : A_LongStop_9_Loss;
                A_TotalLongLoss += A_LongStop_9_Loss;
                ShortLossReport.L_A_LongStop_9.Text = A_LongStop_9_Loss.ToString("#,##0.00");




                double B_MechanicalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_MechanicalLoss"].ToString(), out B_MechanicalLoss);
                B_MechanicalLoss = double.IsNaN(B_MechanicalLoss) == true ? 0 : B_MechanicalLoss;
                B_TotalLongLoss += B_MechanicalLoss;
                ShortLossReport.L_B_Mechanical.Text = B_MechanicalLoss.ToString("#,##0.00");

                double B_ElectricalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_ElectricalLoss"].ToString(), out B_ElectricalLoss);
                B_ElectricalLoss = double.IsNaN(B_ElectricalLoss) == true ? 0 : B_ElectricalLoss;
                B_TotalLongLoss += B_ElectricalLoss;
                ShortLossReport.L_B_Electrical.Text = B_ElectricalLoss.ToString("#,##0.00");

                double B_KnottingLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_KnottingLoss"].ToString(), out B_KnottingLoss);
                B_KnottingLoss = double.IsNaN(B_KnottingLoss) == true ? 0 : B_KnottingLoss;
                B_TotalLongLoss += B_KnottingLoss;
                ShortLossReport.L_B_Knotting.Text = B_KnottingLoss.ToString("#,##0.00");

                double B_ArticleLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_ArticleLoss"].ToString(), out B_ArticleLoss);
                B_ArticleLoss = double.IsNaN(B_ArticleLoss) == true ? 0 : B_ArticleLoss;
                B_TotalLongLoss += B_ArticleLoss;
                ShortLossReport.L_B_Article.Text = B_ArticleLoss.ToString("#,##0.00");

                double B_PowerOffLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_PowerOffLoss"].ToString(), out B_PowerOffLoss);
                B_PowerOffLoss = double.IsNaN(B_PowerOffLoss) == true ? 0 : B_PowerOffLoss;
                B_TotalLongLoss += B_PowerOffLoss;
                ShortLossReport.L_B_PowerOff.Text = B_PowerOffLoss.ToString("#,##0.00");

                double B_LongOtherLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongOtherLoss"].ToString(), out B_LongOtherLoss);
                B_LongOtherLoss = double.IsNaN(B_LongOtherLoss) == true ? 0 : B_LongOtherLoss;
                B_TotalLongLoss += B_LongOtherLoss;
                ShortLossReport.L_B_Other.Text = B_LongOtherLoss.ToString("#,##0.00");

                double B_LongStop_5_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongStop_5_Loss"].ToString(), out B_LongStop_5_Loss);
                B_LongStop_5_Loss = double.IsNaN(B_LongStop_5_Loss) == true ? 0 : B_LongStop_5_Loss;
                B_TotalLongLoss += B_LongStop_5_Loss;
                ShortLossReport.L_B_LongStop_5.Text = B_LongStop_5_Loss.ToString("#,##0.00");

                double B_LongStop_6_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongStop_6_Loss"].ToString(), out B_LongStop_6_Loss);
                B_LongStop_6_Loss = double.IsNaN(B_LongStop_6_Loss) == true ? 0 : B_LongStop_6_Loss;
                B_TotalLongLoss += B_LongStop_6_Loss;
                ShortLossReport.L_B_LongStop_6.Text = B_LongStop_6_Loss.ToString("#,##0.00");

                double B_LongStop_7_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongStop_7_Loss"].ToString(), out B_LongStop_7_Loss);
                B_LongStop_7_Loss = double.IsNaN(B_LongStop_7_Loss) == true ? 0 : B_LongStop_7_Loss;
                B_TotalLongLoss += B_LongStop_7_Loss;
                ShortLossReport.L_B_LongStop_7.Text = B_LongStop_7_Loss.ToString("#,##0.00");

                double B_LongStop_8_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongStop_8_Loss"].ToString(), out B_LongStop_8_Loss);
                B_LongStop_8_Loss = double.IsNaN(B_LongStop_8_Loss) == true ? 0 : B_LongStop_8_Loss;
                B_TotalLongLoss += B_LongStop_8_Loss;
                ShortLossReport.L_B_LongStop_8.Text = B_LongStop_8_Loss.ToString("#,##0.00");

                double B_LongStop_9_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["B_LongStop_9_Loss"].ToString(), out B_LongStop_9_Loss);
                B_LongStop_9_Loss = double.IsNaN(B_LongStop_9_Loss) == true ? 0 : B_LongStop_9_Loss;
                B_TotalLongLoss += B_LongStop_9_Loss;
                ShortLossReport.L_B_LongStop_9.Text = B_LongStop_9_Loss.ToString("#,##0.00");


                double C_MechanicalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_MechanicalLoss"].ToString(), out C_MechanicalLoss);
                C_MechanicalLoss = double.IsNaN(C_MechanicalLoss) == true ? 0 : C_MechanicalLoss;
                C_TotalLongLoss += C_MechanicalLoss;
                ShortLossReport.L_C_Mechanical.Text = C_MechanicalLoss.ToString("#,##0.00");

                double C_ElectricalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_ElectricalLoss"].ToString(), out C_ElectricalLoss);
                C_ElectricalLoss = double.IsNaN(C_ElectricalLoss) == true ? 0 : C_ElectricalLoss;
                C_TotalLongLoss += C_ElectricalLoss;
                ShortLossReport.L_C_Electrical.Text = C_ElectricalLoss.ToString("#,##0.00");

                double C_KnottingLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_KnottingLoss"].ToString(), out C_KnottingLoss);
                C_KnottingLoss = double.IsNaN(C_KnottingLoss) == true ? 0 : C_KnottingLoss;
                C_TotalLongLoss += C_KnottingLoss;
                ShortLossReport.L_C_Knotting.Text = C_KnottingLoss.ToString("#,##0.00");

                double C_ArticleLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_ArticleLoss"].ToString(), out C_ArticleLoss);
                C_ArticleLoss = double.IsNaN(C_ArticleLoss) == true ? 0 : C_ArticleLoss;
                C_TotalLongLoss += C_ArticleLoss;
                ShortLossReport.L_C_Article.Text = C_ArticleLoss.ToString("#,##0.00");

                double C_PowerOffLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_PowerOffLoss"].ToString(), out C_PowerOffLoss);
                C_PowerOffLoss = double.IsNaN(C_PowerOffLoss) == true ? 0 : C_PowerOffLoss;
                C_TotalLongLoss += C_PowerOffLoss;
                ShortLossReport.L_C_PowerOff.Text = C_PowerOffLoss.ToString("#,##0.00");

                double C_LongOtherLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongOtherLoss"].ToString(), out C_LongOtherLoss);
                C_LongOtherLoss = double.IsNaN(C_LongOtherLoss) == true ? 0 : C_LongOtherLoss;
                C_TotalLongLoss += C_LongOtherLoss;
                ShortLossReport.L_C_Other.Text = C_LongOtherLoss.ToString("#,##0.00");

                double C_LongStop_5_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongStop_5_Loss"].ToString(), out C_LongStop_5_Loss);
                C_LongStop_5_Loss = double.IsNaN(C_LongStop_5_Loss) == true ? 0 : C_LongStop_5_Loss;
                C_TotalLongLoss += C_LongStop_5_Loss;
                ShortLossReport.L_C_LongStop_5.Text = C_LongStop_5_Loss.ToString("#,##0.00");

                double C_LongStop_6_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongStop_6_Loss"].ToString(), out C_LongStop_6_Loss);
                C_LongStop_6_Loss = double.IsNaN(C_LongStop_6_Loss) == true ? 0 : C_LongStop_6_Loss;
                C_TotalLongLoss += C_LongStop_6_Loss;
                ShortLossReport.L_C_LongStop_6.Text = C_LongStop_6_Loss.ToString("#,##0.00");

                double C_LongStop_7_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongStop_7_Loss"].ToString(), out C_LongStop_7_Loss);
                C_LongStop_7_Loss = double.IsNaN(C_LongStop_7_Loss) == true ? 0 : C_LongStop_7_Loss;
                C_TotalLongLoss += C_LongStop_7_Loss;
                ShortLossReport.L_C_LongStop_7.Text = C_LongStop_7_Loss.ToString("#,##0.00");

                double C_LongStop_8_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongStop_8_Loss"].ToString(), out C_LongStop_8_Loss);
                C_LongStop_8_Loss = double.IsNaN(C_LongStop_8_Loss) == true ? 0 : C_LongStop_8_Loss;
                C_TotalLongLoss += C_LongStop_8_Loss;
                ShortLossReport.L_C_LongStop_8.Text = C_LongStop_8_Loss.ToString("#,##0.00");

                double C_LongStop_9_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["C_LongStop_9_Loss"].ToString(), out C_LongStop_9_Loss);
                C_LongStop_9_Loss = double.IsNaN(C_LongStop_9_Loss) == true ? 0 : C_LongStop_9_Loss;
                C_TotalLongLoss += C_LongStop_9_Loss;
                ShortLossReport.L_C_LongStop_9.Text = C_LongStop_9_Loss.ToString("#,##0.00");


                double T_MechanicalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_MechanicalLoss"].ToString(), out T_MechanicalLoss);
                T_MechanicalLoss = double.IsNaN(T_MechanicalLoss) == true ? 0 : T_MechanicalLoss;
                T_TotalLongLoss += T_MechanicalLoss;
                ShortLossReport.L_T_Mechanical.Text = T_MechanicalLoss.ToString("#,##0.00");

                double T_ElectricalLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_ElectricalLoss"].ToString(), out T_ElectricalLoss);
                T_ElectricalLoss = double.IsNaN(T_ElectricalLoss) == true ? 0 : T_ElectricalLoss;
                T_TotalLongLoss += T_ElectricalLoss;
                ShortLossReport.L_T_Electrical.Text = T_ElectricalLoss.ToString("#,##0.00");

                double T_KnottingLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_KnottingLoss"].ToString(), out T_KnottingLoss);
                T_KnottingLoss = double.IsNaN(T_KnottingLoss) == true ? 0 : T_KnottingLoss;
                T_TotalLongLoss += T_KnottingLoss;
                ShortLossReport.L_T_Knotting.Text = T_KnottingLoss.ToString("#,##0.00");

                double T_ArticleLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_ArticleLoss"].ToString(), out T_ArticleLoss);
                T_ArticleLoss = double.IsNaN(T_ArticleLoss) == true ? 0 : T_ArticleLoss;
                T_TotalLongLoss += T_ArticleLoss;
                ShortLossReport.L_T_Article.Text = T_ArticleLoss.ToString("#,##0.00");

                double T_PowerOffLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_PowerOffLoss"].ToString(), out T_PowerOffLoss);
                T_PowerOffLoss = double.IsNaN(T_PowerOffLoss) == true ? 0 : T_PowerOffLoss;
                T_TotalLongLoss += T_PowerOffLoss;
                ShortLossReport.L_T_PowerOff.Text = T_PowerOffLoss.ToString("#,##0.00");

                double T_LongOtherLoss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongOtherLoss"].ToString(), out T_LongOtherLoss);
                T_LongOtherLoss = double.IsNaN(T_LongOtherLoss) == true ? 0 : T_LongOtherLoss;
                T_TotalLongLoss += T_LongOtherLoss;
                ShortLossReport.L_T_Other.Text = T_LongOtherLoss.ToString("#,##0.00");

                double T_LongStop_5_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongStop_5_Loss"].ToString(), out T_LongStop_5_Loss);
                T_LongStop_5_Loss = double.IsNaN(T_LongStop_5_Loss) == true ? 0 : T_LongStop_5_Loss;
                T_TotalLongLoss += T_LongStop_5_Loss;
                ShortLossReport.L_T_LongStop_5.Text = T_LongStop_5_Loss.ToString("#,##0.00");

                double T_LongStop_6_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongStop_6_Loss"].ToString(), out T_LongStop_6_Loss);
                T_LongStop_6_Loss = double.IsNaN(T_LongStop_6_Loss) == true ? 0 : T_LongStop_6_Loss;
                T_TotalLongLoss += T_LongStop_6_Loss;
                ShortLossReport.L_T_LongStop_6.Text = T_LongStop_6_Loss.ToString("#,##0.00");

                double T_LongStop_7_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongStop_7_Loss"].ToString(), out T_LongStop_7_Loss);
                T_LongStop_7_Loss = double.IsNaN(T_LongStop_7_Loss) == true ? 0 : T_LongStop_7_Loss;
                T_TotalLongLoss += T_LongStop_7_Loss;
                ShortLossReport.L_T_LongStop_7.Text = T_LongStop_7_Loss.ToString("#,##0.00");

                double T_LongStop_8_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongStop_8_Loss"].ToString(), out T_LongStop_8_Loss);
                T_LongStop_8_Loss = double.IsNaN(T_LongStop_8_Loss) == true ? 0 : T_LongStop_8_Loss;
                T_TotalLongLoss += T_LongStop_8_Loss;
                ShortLossReport.L_T_LongStop_8.Text = T_LongStop_8_Loss.ToString("#,##0.00");

                double T_LongStop_9_Loss = 0;
                double.TryParse(dsLongStopSummary.Tables[0].Rows[0]["T_LongStop_9_Loss"].ToString(), out T_LongStop_9_Loss);
                T_LongStop_9_Loss = double.IsNaN(T_LongStop_9_Loss) == true ? 0 : T_LongStop_9_Loss;
                T_TotalLongLoss += T_LongStop_9_Loss;
                ShortLossReport.L_T_LongStop_9.Text = T_LongStop_9_Loss.ToString("#,##0.00");


                ShortLossReport.L_A_Total.Text = A_TotalLongLoss.ToString("#,##0.00");


                ShortLossReport.L_B_Total.Text = B_TotalLongLoss.ToString("#,##0.00");


                ShortLossReport.L_C_Total.Text = C_TotalLongLoss.ToString("#,##0.00");


                ShortLossReport.L_T_Total.Text = T_TotalLongLoss.ToString("#,##0.00");

            }

            Reports.Efficiency_ModelWiseSubReport ModelWiseReport = new Reports.Efficiency_ModelWiseSubReport();
            string ModelString = "SELECT     TypeID,TypeName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(C_Units) as C_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by TypeID,TypeName order by TypeID,TypeName";

            DataSet dsModel = WS.svc.Get_DataSet(ModelString);
            if (dsModel != null)
            {

                ModelWiseReport.DataSource = dsModel.Tables[0];
            }
            else
                ModelWiseReport.DataSource = null;

            Reports.Efficiency_SectionWiseSubReport SectionWiseReport = new Reports.Efficiency_SectionWiseSubReport();
            string SectionString = "SELECT     SectionID,SectionName,Avg(T_RPM) as T_RPM,Count(LoomID) as TotalLooms,Avg(T_Eff) as T_Eff,Avg(B_Eff) as B_Eff,Avg(C_Eff) as C_Eff,Avg(A_Eff) as A_Eff,Sum(A_Units) as A_Units,Sum(B_Units) as B_Units,Sum(C_Units) as C_Units,Sum(T_Units) as T_Units,Sum(A_Meters) as A_Meters,Sum(B_Meters) as B_Meters, Sum(T_Meters) as T_Meters from RP_dailyShiftSummary where  datepart(DAY, ShiftDate)=" + SelectedDate.Date.Day + " and datepart(MONTH, ShiftDate)=" + SelectedDate.Date.Month + " and datepart(YEAR, ShiftDate)=" + SelectedDate.Date.Year + " and loomid in(select loomid from MT_looms where  ShedID=" + Program.ss.Machines.PresentationData.Sheds[ShedIndex].ShedID + " and Activated=1) group by SectionID,SectionName order by SectionID,SectionName";

            DataSet dsSection = WS.svc.Get_DataSet(SectionString);
            if (dsSection != null)
            {

                SectionWiseReport.DataSource = dsSection.Tables[0];
            }
            else
                SectionWiseReport.DataSource = null;

            AB.SubReport_ModelWise.ReportSource = ModelWiseReport;
            AB.SubReport_SectionWise.ReportSource = SectionWiseReport;
            AB.SubReport_ShortStopSummary.ReportSource = ShortLossReport;
            AB.SubReport_ArticleWise.ReportSource = ArticleWiseSubReport;
            AB.SubReport_SetWise.ReportSource = SetWiseSubReport;
            AB.SubReport_WorseWeeklyLooms.ReportSource = WorseLoomsSubReport;
            AB.SubReport_BetterPerformanceWeekly.ReportSource = GoodLoomsSubReport;
            AB.SubReport_BetterArticlesWeekly.ReportSource = GoodArticlesSubReport;
            AB.SubReport_PoorArticlesWeekly.ReportSource = PoorArticlesSubReport;
            AB.EndInit();
            AB.ShowPreview();
        }

        private void barButton_NewCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            Data.Data_LoomCategories Category = new Data.Data_LoomCategories();
            Category.MdiParent = this;
            Category.Show();
        }

        private void barButtonItem_Category_SaveCategoryLayout_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dg = XtraMessageBox.Show("Are you sure to save location and size of category : " + CurrentSelection.CategorySelected.CategoryName.Text, "Category Layout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dg != DialogResult.Yes) return;
            string s = WS.svc.Execute_Query("Update MT_LoomCategories set X=" + CurrentSelection.CategorySelected.Left + ",Y=" + CurrentSelection.CategorySelected.Top + ",Height=" + CurrentSelection.CategorySelected.Height + ",Width=" + CurrentSelection.CategorySelected.Width + " where CategoryID=" + CurrentSelection.CategorySelected.CategoryName.Tag.ToString() + "");
            if (s.Contains("SUCCESS") == false)
            {
                XtraMessageBox.Show(s, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void barButtonItem_Category_AddLooms_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentSelection.CategorySelected != null)
            {
                
                UserControls.dxLoomCategory lCat = (UserControls.dxLoomCategory)CurrentSelection.CategorySelected;

                string query = "Select LoomID,ShedID,ShedName,LoomName from RMT_Looms where CategoryID is null";
                Data.Data_LoomCategories_Looms AddLooms = new Data.Data_LoomCategories_Looms(true, query);
                AddLooms.ShowDialog();
                
            }
        }

        private void barButtonItem_Category_RemoveLooms_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CurrentSelection.CategorySelected != null)
            {

                UserControls.dxLoomCategory lCat = (UserControls.dxLoomCategory)CurrentSelection.CategorySelected;

                string query = "Select LoomID,ShedID,ShedName,LoomName from RMT_Looms where CategoryID="+lCat.CategoryName.Tag.ToString()+"";
                Data.Data_LoomCategories_Looms RemoveLooms = new Data.Data_LoomCategories_Looms(false, query);
              
                RemoveLooms.ShowDialog();

            }
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {

        }

        private void btnProduction_Inward_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Production.Production_Inwards Inward = new Production.Production_Inwards();
            Inward.MdiParent = this;
            Inward.Show();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Production.Production_Dispatched Dispatched = new Production.Production_Dispatched();
            Dispatched.MdiParent = this;
            Dispatched.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Production.Production_Status_Report statusReport = new Production.Production_Status_Report();
            statusReport.MdiParent = this;
            statusReport.Show();
            
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            MachineEyes.Production.List_Production_Inwards listProductionInwards = new Production.List_Production_Inwards();
            listProductionInwards.MdiParent = this;
            listProductionInwards.Show();
        }
       


    }
    
    public class ColorPopup
    {
        XtraTabControl tabControl;
        Color fResultColor;
        BarItem itemFontColor;
        PopupControlContainer container;
        frmMain main;
        public ColorPopup(PopupControlContainer container, BarItem item, frmMain parent)
        {
            this.main = parent;
            this.container = container;
            this.itemFontColor = item;
            this.fResultColor = Color.Empty;
            this.tabControl = CreateTabControl();
            this.tabControl.TabStop = false;
            this.tabControl.TabPages.AddRange(new XtraTabPage[] { new XtraTabPage(), new XtraTabPage(), new XtraTabPage() });
            for (int i = 0; i < tabControl.TabPages.Count; i++) SetTabPageProperties(i);
            tabControl.Dock = DockStyle.Fill;
            this.container.Controls.AddRange(new System.Windows.Forms.Control[] { tabControl });
            this.container.Size = CalcFormSize();
        }
        private XtraTabControl CreateTabControl() { return new XtraTabControl(); }
        private ColorListBox CreateColorListBox() { return new ColorListBox(); }
        private void SetTabPageProperties(int pageIndex)
        {
           
            XtraTabPage tabPage = this.tabControl.TabPages[pageIndex];
            ColorListBox colorBox = null;
            BaseControl control = null;
            switch (pageIndex)
            {
                case 0:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabCustom);
                    control = new ColorCellsControl(null);
                    DevExpress.XtraEditors.Repository.RepositoryItemColorEdit rItem = new DevExpress.XtraEditors.Repository.RepositoryItemColorEdit();
                    rItem.ShowColorDialog = false;
                    (control as ColorCellsControl).Properties = rItem;
                    (control as ColorCellsControl).EnterColor += new EnterColorEventHandler(OnEnterColor);
                    control.Size = ColorCellsControlViewInfo.BestSize;
                    break;
                case 1:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabWeb);
                    colorBox = CreateColorListBox();
                    colorBox.Items.AddRange(ColorListBoxViewInfo.WebColors);
                    colorBox.EnterColor += new EnterColorEventHandler(OnEnterColor);
                    control = colorBox;
                    break;
                case 2:
                    tabPage.Text = Localizer.Active.GetLocalizedString(StringId.ColorTabSystem);
                    colorBox = CreateColorListBox();
                    colorBox.Items.AddRange(ColorListBoxViewInfo.SystemColors);
                    colorBox.EnterColor += new EnterColorEventHandler(OnEnterColor);
                    control = colorBox;
                    break;
            }
            control.Dock = DockStyle.Fill;
            control.BorderStyle = BorderStyles.NoBorder;
            control.LookAndFeel.ParentLookAndFeel = itemFontColor.Manager.GetController().LookAndFeel;
            tabPage.Controls.Add(control);
        }
        private void OnEnterColor(object sender, EnterColorEventArgs e)
        {
            ResultColor = e.Color;
            OnEnterColor(e.Color);
        }
        public static void SetImageColor(BarItem item, Color clr)
        {
            int imIndex = item.ImageIndex;
            ImageCollection iml = item.Images as ImageCollection;
            Bitmap im = (Bitmap)iml.Images[imIndex];
            Graphics g = Graphics.FromImage(im);
            Rectangle r = new Rectangle(2, 12, 12, 3);
            g.FillRectangle(new SolidBrush(clr), r);
            if (imIndex == iml.Images.Count - 1)
            {
                iml.Images.RemoveAt(imIndex);
            }
            g.Dispose();
            iml.Images.Add(im);
            item.ImageIndex = iml.Images.Count - 1;
        }
        private void OnEnterColor(Color clr)
        {
            container.HidePopup();

        }
        private ColorCellsControl CellsControl { get { return ((ColorCellsControl)tabControl.TabPages[0].Controls[0]); } }
        private string CustomColorsName { get { return "CustomColors"; } }
        public Color ResultColor
        {
            get { return fResultColor; }
            set
            {
                fResultColor = value;
                SetImageColor(itemFontColor, fResultColor);
            }
        }

        public Size CalcFormSize()
        {
            Size size = ColorCellsControlViewInfo.BestSize;
            size.Height = 113;
            return tabControl.CalcSizeByPageClient(size);
        }
       
    }

       
}
