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
namespace MachineEyes {

    partial class frmMain {

        #region Designer generated code
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup1 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup2 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup3 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup4 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup5 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup6 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup7 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup8 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.XtraBars.Ribbon.GalleryItemGroup galleryItemGroup9 = new DevExpress.XtraBars.Ribbon.GalleryItemGroup();
            this.popupControlContainer1 = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.pmAppMain = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.bbiLogin = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUsersandRights = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCurrentSession = new DevExpress.XtraBars.BarButtonItem();
            this.bbiwhatcanido = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.Debug_ConnectedCoorindators = new DevExpress.XtraBars.BarButtonItem();
            this.GPS_ClientsList = new DevExpress.XtraBars.BarButtonItem();
            this.Debug_WirelessDevices = new DevExpress.XtraBars.BarButtonItem();
            this.Debug_LoomsWindow = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExitMachineEyesERP = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.bbi_Data_Article_Insertion = new DevExpress.XtraBars.BarButtonItem();
            this.iFont = new DevExpress.XtraBars.BarButtonItem();
            this.gddFont = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.iWeb = new DevExpress.XtraBars.BarButtonItem();
            this.iAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Debug_DebugMode = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Tools_RPMColors = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Tools_EffColors = new DevExpress.XtraBars.BarButtonItem();
            this.iFontColor = new DevExpress.XtraBars.BarButtonItem();
            this.gddFontColor = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.sbiShed = new DevExpress.XtraBars.BarSubItem();
            this.iPaintStyle = new DevExpress.XtraBars.BarSubItem();
            this.rgbiSkins = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.beiFontSize = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.rgbiFont = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.bbiFontColorPopup = new DevExpress.XtraBars.BarButtonItem();
            this.rgbiFontColor = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.bbi_Data_Article_Selvage = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Article_Weave = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Warping_Beams = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Warping_Machines = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Warping_Main = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Sizing_Beams = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Sizing_Chemicals = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Sizing_Main = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Knotting_Main = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Dashboard_ShedEff = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_DashBoard_SizingView = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Dashboard_ArticleEfficiency = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Dashboard_ExecutiveSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Tools_SMSSettings = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bbi_Data_AssignLoom_Weavers = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_Technician = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_Beam = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_LockApp = new DevExpress.XtraBars.BarButtonItem();
            this.bci_DashBoard_DesignMove = new DevExpress.XtraBars.BarCheckItem();
            this.bbi_DashBoard_DesignSave = new DevExpress.XtraBars.BarButtonItem();
            this.bar_ServiceStatus = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Progress = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_CurrentLoomInfo = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubMenu_AssignStopCause = new DevExpress.XtraBars.BarSubItem();
            this.barAssign_Mechanical = new DevExpress.XtraBars.BarCheckItem();
            this.barAssign_Electrical = new DevExpress.XtraBars.BarCheckItem();
            this.barAssign_Knotting = new DevExpress.XtraBars.BarCheckItem();
            this.barAssign_ArticleChange = new DevExpress.XtraBars.BarCheckItem();
            this.barAssign_OtherStop = new DevExpress.XtraBars.BarCheckItem();
            this.bbi_Data_Assign_FDNI = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Debug_WaitingTimeButton = new DevExpress.XtraBars.BarEditItem();
            this.bbi_Debug_WaitingTime = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bar_Shift = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubMenu_AssignToGroup = new DevExpress.XtraBars.BarSubItem();
            this.bbi_Dashboard_DesignSaveGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_DashBoard_DesignMoveGroup = new DevExpress.XtraBars.BarCheckItem();
            this.bbi_ShedGraph_View = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_AutomaticUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSubMenu_AssignPosition = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem_Drawingleft = new DevExpress.XtraBars.BarSubItem();
            this.bbi_SetLoomLeft = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_SetLoomLeftRef = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_DrawingTop = new DevExpress.XtraBars.BarSubItem();
            this.bbi_SetLoomTop = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_SetLoomTopRef = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Resize = new DevExpress.XtraBars.BarSubItem();
            this.bbi_SetLoomResizeControl = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_SaveLoomResizeControl = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_SaveLoomLayoutintoProfile = new DevExpress.XtraBars.BarButtonItem();
            this.MergedShedLayoutSaveMenu = new DevExpress.XtraBars.BarSubItem();
            this.MergedShedLayoutSaveMenuButton = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Category = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Category_Move = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Category_AddLooms = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Category_RemoveLooms = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Category_SaveCategoryLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barAssign_TopSpin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit_LoomForTop = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.bbi_Shed = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyShiftSummary = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailySummary = new DevExpress.XtraBars.BarSubItem();
            this.rpi_ConstructionWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_LoomWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyUnitsWeaverWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_WeaverWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyEfficiencyQualityWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyEfficiencyWithProductionLoss = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyProductionLoss = new DevExpress.XtraBars.BarSubItem();
            this.rpi_WeeklyEfficiencyLoomWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_MonthlyEfficiencyTabular = new DevExpress.XtraBars.BarSubItem();
            this.rpi_MonthlyUnitsTabular = new DevExpress.XtraBars.BarSubItem();
            this.rpi_MonthlyProductionEfficiency = new DevExpress.XtraBars.BarSubItem();
            this.rpi_CommingKnottings = new DevExpress.XtraBars.BarSubItem();
            this.Efficiency_ArticleEfficiencyReport = new DevExpress.XtraBars.BarButtonItem();
            this.Efficiency_MonthlyProductionLoss = new DevExpress.XtraBars.BarButtonItem();
            this.Monthly_Efficiency_SelectedLoom = new DevExpress.XtraBars.BarButtonItem();
            this.Efficiency_QualityWiseProduction = new DevExpress.XtraBars.BarButtonItem();
            this.Efficiency_ShedLog = new DevExpress.XtraBars.BarButtonItem();
            this.rpi_MonthlyUnitsWeaverWise = new DevExpress.XtraBars.BarSubItem();
            this.rpi_MonthlyUnitsQualityWise = new DevExpress.XtraBars.BarSubItem();
            this.Efficiency_BeamContraction = new DevExpress.XtraBars.BarButtonItem();
            this.Efficiency_QualityWiseBreakageReport = new DevExpress.XtraBars.BarButtonItem();
            this.Efficiency_QualityWiseBreakagesGrouped = new DevExpress.XtraBars.BarButtonItem();
            this.rpi_ShedEfficiencyLog = new DevExpress.XtraBars.BarSubItem();
            this.rpi_ShedEfficiencyGraph = new DevExpress.XtraBars.BarSubItem();
            this.rpi_DailyEfficiencyWithDailyWage = new DevExpress.XtraBars.BarSubItem();
            this.rpi_TopWorseArticlesLooms = new DevExpress.XtraBars.BarSubItem();
            this.mrip_Warping = new DevExpress.XtraBars.BarSubItem();
            this.mrip_Sizing = new DevExpress.XtraBars.BarSubItem();
            this.Production_SizingSummaryReport = new DevExpress.XtraBars.BarButtonItem();
            this.Production_SizingMonthlyProduction = new DevExpress.XtraBars.BarButtonItem();
            this.Production_SizingMonthlyProductionPartyWise = new DevExpress.XtraBars.BarButtonItem();
            this.Production_SizingMonthlyProductionCountWise = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.mdata_Yarn = new DevExpress.XtraBars.BarSubItem();
            this.mYarnData_Params = new DevExpress.XtraBars.BarSubItem();
            this.mYarnData_Counts = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_Brands = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_Blends = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_Twsits = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemYarnColor = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_PaperConeColors = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_ConeWeight = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_ConesPerBag = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_LbsPerBag = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_CottonOrigin = new DevExpress.XtraBars.BarButtonItem();
            this.mYarnData_YarnDesc = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDebugFunction = new DevExpress.XtraBars.BarSubItem();
            this.mYarnData_Contracts = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_MappedAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Tools_EffFont = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_CurrentLoomStats = new DevExpress.XtraBars.BarButtonItem();
            this.Company = new DevExpress.XtraBars.BarButtonItem();
            this.barContracts = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.PGB_ArticleChangeSheet = new DevExpress.XtraBars.BarButtonItem();
            this.YarnContract = new DevExpress.XtraBars.BarButtonItem();
            this.YarnReceiveNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnIssueNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDemandNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnRequisitionNote = new DevExpress.XtraBars.BarButtonItem();
            this.DesignChangeSheet = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_ChartofAccountsTree = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_Article = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Summary = new DevExpress.XtraBars.BarSubItem();
            this.bbi_WeaverMain = new DevExpress.XtraBars.BarSubItem();
            this.bbi_WeaversScroll = new DevExpress.XtraBars.BarSubItem();
            this.bbi_Data_Loom_Log = new DevExpress.XtraBars.BarButtonItem();
            this.Refresh_Accounts = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_CashPayment = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_BankPayment = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_CashReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_BankReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.FinancialYear = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_AssignLoom_FDNE = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_FabricSales = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesReturnFabric = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsReports_Menu = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_DailyCashAndBankTransactionReport = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsMenu_Ledger = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_GeneralLedger = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_Generalledger_AI_Cash = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_Generalledger_AI_Bank = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesTaxRegister_Article = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_OpeningMenu = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_OpeningBalances_G = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_OpeningBalances_N = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_OpeningBalances_B = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesTaxReturn_Menu = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_STAnnexC = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_STAnnexA = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesSummary_Report = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_STAnnexIDebitNote = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_AnnexICreditNote = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_ConsolidatedLedger_IV = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_ConsolidatedLedger_III = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_ConsolidatedLedger_II = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_ConsolidatedLedger_I = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem9 = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_AuditTrailReport = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_FilteredAuditTrailReport = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SubMenu_PNL = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_WeavingPNLAll = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsMenuTrialBalance = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_PeriodicTrialBalance = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsTrialBalancesSumBalances = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsTrialBalanceConsolidated = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_TrialBalanceEnding = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_TrialBalanceEndingG = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_TrialBalanceEndingN = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsMenuChartofAccounts = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_PrintChartOfAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.AccountsMenuPurchases = new DevExpress.XtraBars.BarSubItem();
            this.Purchases_PurchaseLedger = new DevExpress.XtraBars.BarButtonItem();
            this.Purchases_PurchasesSummary = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_PurchaseRegister_DuringPeriod = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem14 = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_SalesRegister_PartyFilter = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesRegister_Dated = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesRegister_Article = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_GeneralVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_PurchaseMenu = new DevExpress.XtraBars.BarSubItem();
            this.AccountsMenu_Purchases = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_YarnPurchases = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_FabricPurchases = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_OtherPurchases = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.Accounts_PurchasesYarn_Return = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_PurchasesFabric_Return = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_PurchasesOthers_Return = new DevExpress.XtraBars.BarButtonItem();
            this.PGB_Employees_Employee = new DevExpress.XtraBars.BarButtonItem();
            this.PGB_Employees_Departments = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_UnlockApp = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Tool_ClassicViewColors = new DevExpress.XtraBars.BarButtonItem();
            this.Menu_GreigeFabricContracts = new DevExpress.XtraBars.BarSubItem();
            this.Menu_GreigeFabricSalesContracts = new DevExpress.XtraBars.BarSubItem();
            this.Contracts_Sales_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Overhead = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Conversion = new DevExpress.XtraBars.BarButtonItem();
            this.Menu_TowelContracts = new DevExpress.XtraBars.BarSubItem();
            this.Menu_TowelSalesContracts = new DevExpress.XtraBars.BarSubItem();
            this.Menu_TowelPurchasesContracts = new DevExpress.XtraBars.BarSubItem();
            this.Menu_Summaries = new DevExpress.XtraBars.BarSubItem();
            this.ClassicalCheck_Efficiency = new DevExpress.XtraBars.BarCheckItem();
            this.ClassicalCheck_RPMView = new DevExpress.XtraBars.BarCheckItem();
            this.ClassicalCheck_WarpView = new DevExpress.XtraBars.BarCheckItem();
            this.ClassicalCheck_WeftView = new DevExpress.XtraBars.BarCheckItem();
            this.ClassicalCheck_WarpKnottView = new DevExpress.XtraBars.BarCheckItem();
            this.ClassicalCheck_WeftKnottView = new DevExpress.XtraBars.BarCheckItem();
            this.Accounts_SalesTaxRegister_FilterParty = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_SalesRegister = new DevExpress.XtraBars.BarButtonItem();
            this.ValidateMoreSecure = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_PaymentAdvice = new DevExpress.XtraBars.BarButtonItem();
            this.Planning_ProgramSheet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiALUGPU = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_Data_Article_FabricName = new DevExpress.XtraBars.BarButtonItem();
            this.bbi_LoomFilter = new DevExpress.XtraBars.BarSubItem();
            this.bbiGotoFilter = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonFuction = new DevExpress.XtraBars.BarButtonItem();
            this.Production_OutSideSizing = new DevExpress.XtraBars.BarButtonItem();
            this.Button_StoreAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.Button_PurchaseOrderStore = new DevExpress.XtraBars.BarButtonItem();
            this.Button_StorePurchaseRegister = new DevExpress.XtraBars.BarButtonItem();
            this.Button_StorePurchaseReturn = new DevExpress.XtraBars.BarButtonItem();
            this.Button_StoreIssueNote = new DevExpress.XtraBars.BarButtonItem();
            this.SubMenu_Reports_Store = new DevExpress.XtraBars.BarSubItem();
            this.SubMenuStore_Accounts = new DevExpress.XtraBars.BarSubItem();
            this.ReportButton_StoreAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.Store_ItemBinCard = new DevExpress.XtraBars.BarButtonItem();
            this.Store_ControlAccountsList = new DevExpress.XtraBars.BarButtonItem();
            this.Store_Opening_SubMenu = new DevExpress.XtraBars.BarSubItem();
            this.Store_OpeningEnteries_Report = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemStoreStockReports = new DevExpress.XtraBars.BarSubItem();
            this.Store_ClosingStockReport = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Issuancereports_Store = new DevExpress.XtraBars.BarSubItem();
            this.Store_MonthlyIssuance_Report = new DevExpress.XtraBars.BarButtonItem();
            this.Store_MonthlyIssuance_Report_Asset = new DevExpress.XtraBars.BarButtonItem();
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction = new DevExpress.XtraBars.BarButtonItem();
            this.MonthlyIssuanceOthers = new DevExpress.XtraBars.BarButtonItem();
            this.Store_MonthlyIssuanceGroupAccount_Report = new DevExpress.XtraBars.BarButtonItem();
            this.MonthlyIssuanceAllAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.Store_MonthlyDepartmentIssuance = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_PurchasesReports_Store = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_MonthlyPurchasesDetailedItem = new DevExpress.XtraBars.BarButtonItem();
            this.Store_ReturnBackReports_Menu = new DevExpress.XtraBars.BarSubItem();
            this.Store_Monthly_GetBacks = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonProductionSectionWarping = new DevExpress.XtraBars.BarButtonItem();
            this.FabricContracts = new DevExpress.XtraBars.BarButtonItem();
            this.Store_Opening = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_StoreCashPurchases = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_CreditStorePurchases = new DevExpress.XtraBars.BarButtonItem();
            this.Store_ReceiveNote = new DevExpress.XtraBars.BarButtonItem();
            this.Button_Towel_Opening = new DevExpress.XtraBars.BarButtonItem();
            this.Button_ManageVehicles = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_GoogleEarth = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_PluginOptions = new DevExpress.XtraBars.BarSubItem();
            this.barCheckItem_Navigator = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_Atmosphere = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_StatusBar = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_OverView = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_Borders = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_Terrain = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_Roads = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem_Buildings = new DevExpress.XtraBars.BarCheckItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem5 = new DevExpress.XtraBars.BarStaticItem();
            this.barLinkContainerItem1 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.Tracking_VehicleMakes = new DevExpress.XtraBars.BarButtonItem();
            this.Tracking_VehicleModels = new DevExpress.XtraBars.BarButtonItem();
            this.Tracking_VehicleTypes = new DevExpress.XtraBars.BarButtonItem();
            this.Button_Planning_TowelArticles = new DevExpress.XtraBars.BarButtonItem();
            this.Button_TowelArticles = new DevExpress.XtraBars.BarButtonItem();
            this.Store_UnitsMeasurements = new DevExpress.XtraBars.BarButtonItem();
            this.Store_Origins = new DevExpress.XtraBars.BarButtonItem();
            this.bar_AutomaticUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_FinancialYears = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_GreigeArticle = new DevExpress.XtraBars.BarButtonItem();
            this.Accounts_ChartOfAccount_TabView = new DevExpress.XtraBars.BarButtonItem();
            this.PO_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.MDC = new DevExpress.XtraBars.BarSubItem();
            this.MDC_CashPaymentVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.MDC_BankPaymentVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.MDC_CashReceiptVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.MDC_BankReceiptVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.MDC_JournalVoucher = new DevExpress.XtraBars.BarButtonItem();
            this.barListItem1 = new DevExpress.XtraBars.BarListItem();
            this.barLinkContainerItem2 = new DevExpress.XtraBars.BarLinkContainerItem();
            this.SaveAsDefaultSkin = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.Button_Towel_OpeningOutward = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Towel_OpeningMenu = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Opening_Inward_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Opening_OutWard_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Towel_Inspection = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_PackingList_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Reports_Towel = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_ArticleBinCard_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_POBinCard_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_DailyContractPosition_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_StockReport_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_YarnBalanceSummary_Towel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Inspection_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_TaketoGodown_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_PackingList_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Opening_Greige_Menu = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem_Opening_Inward_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_Opening_OutWard_Greige = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_Reports_Greige_Menu = new DevExpress.XtraBars.BarSubItem();
            this.Greige_ArticleBinCard = new DevExpress.XtraBars.BarButtonItem();
            this.Greige_CurrentContractsPosition = new DevExpress.XtraBars.BarButtonItem();
            this.Greige_ContractAcitivtySheet_Report = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_JacquardArticles = new DevExpress.XtraBars.BarButtonItem();
            this.Inspection_OutsideWeaving = new DevExpress.XtraBars.BarButtonItem();
            this.Greige_FabricReturn = new DevExpress.XtraBars.BarButtonItem();
            this.Greige_ReCheck = new DevExpress.XtraBars.BarButtonItem();
            this.rpi_BeamContraction = new DevExpress.XtraBars.BarSubItem();
            this.YarnReports_Menu = new DevExpress.XtraBars.BarSubItem();
            this.YarnReports_POSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnPartyStockReport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnPartyWiseStockSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnDepartmentStockSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnGodownOrPartitionStockSummary = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnItemLedgerReport = new DevExpress.XtraBars.BarButtonItem();
            this.SizingYarnLedger = new DevExpress.XtraBars.BarButtonItem();
            this.Yarn_ReturnToParty = new DevExpress.XtraBars.BarButtonItem();
            this.YarnInward = new DevExpress.XtraBars.BarButtonItem();
            this.YarnOutward = new DevExpress.XtraBars.BarButtonItem();
            this.SizingWorkOrderButton = new DevExpress.XtraBars.BarButtonItem();
            this.DoublingMenu = new DevExpress.XtraBars.BarSubItem();
            this.IssuetoDoubling = new DevExpress.XtraBars.BarButtonItem();
            this.ReceiveFromDoubling = new DevExpress.XtraBars.BarButtonItem();
            this.DoublingWorkOrder = new DevExpress.XtraBars.BarButtonItem();
            this.DoublingAdjustmentNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDoublingWorkOrderLedger = new DevExpress.XtraBars.BarButtonItem();
            this.DoublingWorkOrdersSummary = new DevExpress.XtraBars.BarButtonItem();
            this.MovetoPO = new DevExpress.XtraBars.BarButtonItem();
            this.ReportsMenuContracts = new DevExpress.XtraBars.BarSubItem();
            this.GreigeContractsList = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTowelContractsList = new DevExpress.XtraBars.BarButtonItem();
            this.DenimArticlesAdd = new DevExpress.XtraBars.BarButtonItem();
            this.FontSizeControl = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.bbi_SMSDeviceAndServiceStatus = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnOpeningPlus = new DevExpress.XtraBars.BarButtonItem();
            this.bbiYarnIssueBetweenParties = new DevExpress.XtraBars.BarButtonItem();
            this.MenuYarnInwardOutward = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.MenuYarnReceiveIssue = new DevExpress.XtraBars.BarSubItem();
            this.WeaverGroupsManagement = new DevExpress.XtraBars.BarButtonItem();
            this.StoreLocations = new DevExpress.XtraBars.BarButtonItem();
            this.DepartmentRequisitionSlip = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingMenu = new DevExpress.XtraBars.BarSubItem();
            this.YarnDyingIssueNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingReceiveNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingWorkOrder = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingAdjustmentNote = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingWorkOrderLedger = new DevExpress.XtraBars.BarButtonItem();
            this.YarnDyingWorkOrderSummary = new DevExpress.XtraBars.BarButtonItem();
            this.RequestApproval = new DevExpress.XtraBars.BarButtonItem();
            this.EmailSettings = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sale = new DevExpress.XtraBars.BarSubItem();
            this.Contracts_Sales_Fabric = new DevExpress.XtraBars.BarSubItem();
            this.Contracts_Sales_Fabric_Overhead = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Fabric_Conversion = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Fabric_Sale = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Towel = new DevExpress.XtraBars.BarSubItem();
            this.Contracts_Sales_Towel_Overhead = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Towel_Conversion = new DevExpress.XtraBars.BarButtonItem();
            this.Contracts_Sales_Towel_Sale = new DevExpress.XtraBars.BarButtonItem();
            this.Store_RequisitionList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_SaveRunningPercentLocation = new DevExpress.XtraBars.BarButtonItem();
            this.ButtonEfficiencyType = new DevExpress.XtraBars.BarButtonItem();
            this.barButton_NewCategory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem10 = new DevExpress.XtraBars.BarSubItem();
            this.btnProduction_Inward = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.page_LDS = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PG_Dashboard_Shed = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Dashboard_Sizing = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Dashboard_Weavers = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Dashboard_Articles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_DailyEfficiency = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_Planning = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ContractsPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Planning_Articles = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Planning_ArticleChangeSheet = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_Yarn = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PG_Yarn_YarnContractManagement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Yarn_GRNGIN = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroup_Store = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.StoreParametersPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_Production = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PG_Production_Warping = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Production_Sizing = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Production_ReportsWarping = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Production_ReportsSizing = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_inspectionanddelivery = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup_Towel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_Greige = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_HR = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PG_HR_Employees = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_Accounts = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PG_Accounts_ChartofAccounts = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Accounts_Payments = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Accounts_Receipts = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Accounts_General = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Accounts_Purchases = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PG_Accounts_Reports = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_FinYears = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.page_Tools = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup22 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgFont = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupFontSize = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgFontColor = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupDebug = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rib_Hidden = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPGWeaving = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup17 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_ClassicalView = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage_Tracking = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup_TrackingVehiclesInfo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup_EarthPlugin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.riicStyle = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup2 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemRadioGroup3 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBox_AssesmentYear = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.siDocName = new DevExpress.XtraBars.BarStaticItem();
            this.pmNew = new DevExpress.XtraBars.PopupMenu(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.pmMain = new DevExpress.XtraBars.PopupMenu(this.components);
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiUserManagement = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection_Main = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.ribbonGalleryBarItem1 = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.Alert = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.CauseImages = new DevExpress.Utils.ImageCollection(this.components);
            this.CauseImagesBlack = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPageGroup_ClassicalViewMenu = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rP_DailyShiftSummaryTableAdapter = new MachineEyes.DataTables.DailyShift_SummaryTableAdapters.RP_DailyShiftSummaryTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFontColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbi_Debug_WaitingTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit_LoomForTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_AssesmentYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImagesBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // popupControlContainer1
            // 
            this.popupControlContainer1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.popupControlContainer1.Location = new System.Drawing.Point(0, 0);
            this.popupControlContainer1.Name = "popupControlContainer1";
            this.popupControlContainer1.Size = new System.Drawing.Size(0, 0);
            this.popupControlContainer1.TabIndex = 6;
            this.popupControlContainer1.Visible = false;
            // 
            // pmAppMain
            // 
            this.pmAppMain.BottomPaneControlContainer = null;
            this.pmAppMain.ItemLinks.Add(this.bbiLogin);
            this.pmAppMain.ItemLinks.Add(this.bbiUsersandRights);
            this.pmAppMain.ItemLinks.Add(this.bbiCurrentSession);
            this.pmAppMain.ItemLinks.Add(this.bbiwhatcanido);
            this.pmAppMain.ItemLinks.Add(this.bbiChangePassword);
            this.pmAppMain.ItemLinks.Add(this.Debug_ConnectedCoorindators);
            this.pmAppMain.ItemLinks.Add(this.GPS_ClientsList);
            this.pmAppMain.ItemLinks.Add(this.Debug_WirelessDevices);
            this.pmAppMain.ItemLinks.Add(this.Debug_LoomsWindow);
            this.pmAppMain.ItemLinks.Add(this.bbiExitMachineEyesERP);
            this.pmAppMain.Name = "pmAppMain";
            this.pmAppMain.Ribbon = this.ribbonControl1;
            this.pmAppMain.RightPaneControlContainer = null;
            this.pmAppMain.ShowRightPane = true;
            // 
            // bbiLogin
            // 
            this.bbiLogin.Caption = "Login Machine Eyes";
            this.bbiLogin.Description = "[Security] Machine Eyes ERP Login";
            this.bbiLogin.Id = 182;
            this.bbiLogin.LargeImageIndex = 42;
            this.bbiLogin.Name = "bbiLogin";
            this.bbiLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogin_ItemClick);
            // 
            // bbiUsersandRights
            // 
            this.bbiUsersandRights.Caption = "Manage Users and Rights";
            this.bbiUsersandRights.Description = "[Security] Add New Users. Assign, Revoke and Manage System and Interface Rights";
            this.bbiUsersandRights.Id = 171;
            this.bbiUsersandRights.LargeImageIndex = 79;
            this.bbiUsersandRights.Name = "bbiUsersandRights";
            this.bbiUsersandRights.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUsersandRights_ItemClick);
            // 
            // bbiCurrentSession
            // 
            this.bbiCurrentSession.Caption = "Current user sessions";
            this.bbiCurrentSession.Description = "[Security] Current User Logged in Sessions";
            this.bbiCurrentSession.Id = 391;
            this.bbiCurrentSession.LargeImageIndex = 1;
            this.bbiCurrentSession.Name = "bbiCurrentSession";
            this.bbiCurrentSession.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCurrentSession_ItemClick);
            // 
            // bbiwhatcanido
            // 
            this.bbiwhatcanido.Caption = "What can i do?";
            this.bbiwhatcanido.Description = "[Security] what can i do?";
            this.bbiwhatcanido.Id = 392;
            this.bbiwhatcanido.LargeImageIndex = 303;
            this.bbiwhatcanido.Name = "bbiwhatcanido";
            // 
            // bbiChangePassword
            // 
            this.bbiChangePassword.Caption = "Change my password";
            this.bbiChangePassword.Description = "[Security] Change user password";
            this.bbiChangePassword.Id = 393;
            this.bbiChangePassword.LargeImageIndex = 8;
            this.bbiChangePassword.Name = "bbiChangePassword";
            this.bbiChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiChangePassword_ItemClick);
            // 
            // Debug_ConnectedCoorindators
            // 
            this.Debug_ConnectedCoorindators.Caption = "Connected Coordinators";
            this.Debug_ConnectedCoorindators.Description = "[Debug] Connected Coordinators List";
            this.Debug_ConnectedCoorindators.Id = 442;
            this.Debug_ConnectedCoorindators.ImageIndex = 3;
            this.Debug_ConnectedCoorindators.Name = "Debug_ConnectedCoorindators";
            this.Debug_ConnectedCoorindators.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Debug_ConnectedCoorindators_ItemClick);
            // 
            // GPS_ClientsList
            // 
            this.GPS_ClientsList.Caption = "Connected GPRS Clients";
            this.GPS_ClientsList.Description = "[Debug] Connected GPRS Clients";
            this.GPS_ClientsList.Id = 627;
            this.GPS_ClientsList.Name = "GPS_ClientsList";
            this.GPS_ClientsList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GPS_ClientsList_ItemClick);
            // 
            // Debug_WirelessDevices
            // 
            this.Debug_WirelessDevices.Caption = "Debug Wireless Devices";
            this.Debug_WirelessDevices.Description = "[Debug] Debug Wireless Devices";
            this.Debug_WirelessDevices.Id = 444;
            this.Debug_WirelessDevices.LargeImageIndex = 70;
            this.Debug_WirelessDevices.Name = "Debug_WirelessDevices";
            this.Debug_WirelessDevices.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Debug_WirelessDevices_ItemClick);
            // 
            // Debug_LoomsWindow
            // 
            this.Debug_LoomsWindow.Caption = "Debug Looms View";
            this.Debug_LoomsWindow.Description = "[Debug] Debug Looms View";
            this.Debug_LoomsWindow.Id = 443;
            this.Debug_LoomsWindow.LargeImageIndex = 49;
            this.Debug_LoomsWindow.Name = "Debug_LoomsWindow";
            this.Debug_LoomsWindow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Debug_LoomsWindow_ItemClick);
            // 
            // bbiExitMachineEyesERP
            // 
            this.bbiExitMachineEyesERP.Caption = "Exit Machine Eyes";
            this.bbiExitMachineEyesERP.Description = "[Security] Exit Machine Eyes ERP";
            this.bbiExitMachineEyesERP.Id = 394;
            this.bbiExitMachineEyesERP.LargeImageIndex = 6;
            this.bbiExitMachineEyesERP.Name = "bbiExitMachineEyesERP";
            this.bbiExitMachineEyesERP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExitMachineEyesERP_ItemClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.pmAppMain;
            this.ribbonControl1.ApplicationButtonText = null;
            this.ribbonControl1.Categories.AddRange(new DevExpress.XtraBars.BarManagerCategory[] {
            new DevExpress.XtraBars.BarManagerCategory("File", new System.Guid("4b511317-d784-42ba-b4ed-0d2a746d6c1f")),
            new DevExpress.XtraBars.BarManagerCategory("Edit", new System.Guid("7c2486e1-92ea-4293-ad55-b819f61ff7f1")),
            new DevExpress.XtraBars.BarManagerCategory("Format", new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258")),
            new DevExpress.XtraBars.BarManagerCategory("Help", new System.Guid("e07a4c24-66ac-4de6-bbcb-c0b6cfa7798b")),
            new DevExpress.XtraBars.BarManagerCategory("Status", new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d"))});
            this.ribbonControl1.Images = this.imageCollection2;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbi_Data_Article_Insertion,
            this.iFont,
            this.iWeb,
            this.iAbout,
            this.bbi_Debug_DebugMode,
            this.bbi_Tools_RPMColors,
            this.bbi_Tools_EffColors,
            this.iFontColor,
            this.sbiShed,
            this.iPaintStyle,
            this.rgbiSkins,
            this.beiFontSize,
            this.rgbiFont,
            this.bbiFontColorPopup,
            this.rgbiFontColor,
            this.barEditItem1,
            this.bbi_Data_Article_Selvage,
            this.bbi_Data_Article_Weave,
            this.bbi_Data_Warping_Beams,
            this.bbi_Data_Warping_Machines,
            this.bbi_Data_Warping_Main,
            this.bbi_Data_Sizing_Beams,
            this.bbi_Data_Sizing_Chemicals,
            this.bbi_Data_Sizing_Main,
            this.bbi_Data_Knotting_Main,
            this.bbi_Dashboard_ShedEff,
            this.bbi_DashBoard_SizingView,
            this.bbi_Dashboard_ArticleEfficiency,
            this.bbi_Dashboard_ExecutiveSummary,
            this.bbi_Tools_SMSSettings,
            this.barSubItem1,
            this.bbiUsersandRights,
            this.bbi_Data_AssignLoom_Weavers,
            this.bbi_Data_AssignLoom_Technician,
            this.bbi_Data_AssignLoom_Beam,
            this.bbi_LockApp,
            this.bbiLogin,
            this.bci_DashBoard_DesignMove,
            this.bbi_DashBoard_DesignSave,
            this.bar_ServiceStatus,
            this.bar_Progress,
            this.bbi_Data_AssignLoom_CurrentLoomInfo,
            this.bbiSubMenu_AssignStopCause,
            this.barAssign_Mechanical,
            this.barAssign_Electrical,
            this.barAssign_Knotting,
            this.barAssign_ArticleChange,
            this.barAssign_OtherStop,
            this.bbi_Data_Assign_FDNI,
            this.bbi_Debug_WaitingTimeButton,
            this.bar_Shift,
            this.bbiSubMenu_AssignToGroup,
            this.bbi_Dashboard_DesignSaveGroup,
            this.bbi_DashBoard_DesignMoveGroup,
            this.bbi_ShedGraph_View,
            this.bbi_AutomaticUpdate,
            this.bbiSubMenu_AssignPosition,
            this.barAssign_TopSpin,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barSubItem_Drawingleft,
            this.bbi_SetLoomLeft,
            this.bbi_SetLoomLeftRef,
            this.barSubItem_DrawingTop,
            this.bbi_SetLoomTop,
            this.bbi_SetLoomTopRef,
            this.bbi_Shed,
            this.barSubItem2,
            this.rpi_DailyShiftSummary,
            this.mrip_Warping,
            this.mrip_Sizing,
            this.barStaticItem4,
            this.mdata_Yarn,
            this.mYarnData_Params,
            this.bbiDebugFunction,
            this.mYarnData_Counts,
            this.mYarnData_Brands,
            this.mYarnData_Blends,
            this.mYarnData_Twsits,
            this.mYarnData_PaperConeColors,
            this.mYarnData_Contracts,
            this.mYarnData_ConeWeight,
            this.Accounts_MappedAccounts,
            this.mYarnData_ConesPerBag,
            this.mYarnData_LbsPerBag,
            this.mYarnData_CottonOrigin,
            this.mYarnData_YarnDesc,
            this.bbi_Tools_EffFont,
            this.bbi_Data_AssignLoom_CurrentLoomStats,
            this.Company,
            this.barContracts,
            this.barSubItem5,
            this.barSubItem6,
            this.barSubItem7,
            this.PGB_ArticleChangeSheet,
            this.YarnContract,
            this.YarnReceiveNote,
            this.YarnIssueNote,
            this.YarnDemandNote,
            this.YarnRequisitionNote,
            this.DesignChangeSheet,
            this.Accounts_ChartofAccountsTree,
            this.bbi_Data_AssignLoom_Article,
            this.bbi_Summary,
            this.bbi_WeaverMain,
            this.bbi_WeaversScroll,
            this.bbi_Data_Loom_Log,
            this.Refresh_Accounts,
            this.Accounts_CashPayment,
            this.Accounts_BankPayment,
            this.Accounts_CashReceipt,
            this.Accounts_BankReceipt,
            this.FinancialYear,
            this.bbi_Data_AssignLoom_FDNE,
            this.Accounts_FabricSales,
            this.Accounts_SalesReturnFabric,
            this.AccountsReports_Menu,
            this.Accounts_GeneralLedger,
            this.Accounts_GeneralVoucher,
            this.Accounts_PeriodicTrialBalance,
            this.Accounts_OpeningBalances_G,
            this.Accounts_DailyCashAndBankTransactionReport,
            this.Accounts_AuditTrailReport,
            this.AccountsMenu_Ledger,
            this.Accounts_Generalledger_AI_Cash,
            this.Accounts_Generalledger_AI_Bank,
            this.Accounts_OpeningMenu,
            this.Accounts_OpeningBalances_N,
            this.Accounts_OpeningBalances_B,
            this.Accounts_SalesTaxReturn_Menu,
            this.Accounts_STAnnexC,
            this.Accounts_PurchaseMenu,
            this.Accounts_YarnPurchases,
            this.Accounts_FabricPurchases,
            this.Accounts_OtherPurchases,
            this.PGB_Employees_Employee,
            this.PGB_Employees_Departments,
            this.bbi_UnlockApp,
            this.bbiCurrentSession,
            this.bbiwhatcanido,
            this.bbiChangePassword,
            this.bbiExitMachineEyesERP,
            this.Accounts_STAnnexA,
            this.barSubItem4,
            this.Accounts_ConsolidatedLedger_IV,
            this.Accounts_ConsolidatedLedger_III,
            this.Accounts_ConsolidatedLedger_II,
            this.Accounts_ConsolidatedLedger_I,
            this.bbi_Tool_ClassicViewColors,
            this.Accounts_PurchasesYarn_Return,
            this.Accounts_PurchasesFabric_Return,
            this.AccountsMenu_Purchases,
            this.barSubItem8,
            this.Menu_GreigeFabricContracts,
            this.Menu_TowelContracts,
            this.Menu_GreigeFabricSalesContracts,
            this.Menu_TowelSalesContracts,
            this.Menu_TowelPurchasesContracts,
            this.Contracts_Sales_Greige,
            this.Contracts_Sales_Overhead,
            this.Contracts_Sales_Conversion,
            this.Menu_Summaries,
            this.Accounts_SalesSummary_Report,
            this.rpi_ConstructionWise,
            this.rpi_WeaverWise,
            this.ClassicalCheck_Efficiency,
            this.ClassicalCheck_RPMView,
            this.ClassicalCheck_WarpView,
            this.ClassicalCheck_WeftView,
            this.ClassicalCheck_WarpKnottView,
            this.ClassicalCheck_WeftKnottView,
            this.barSubItem9,
            this.Accounts_FilteredAuditTrailReport,
            this.Accounts_SalesTaxRegister_FilterParty,
            this.Accounts_SalesTaxRegister_Article,
            this.Accounts_SalesRegister,
            this.ValidateMoreSecure,
            this.Accounts_STAnnexIDebitNote,
            this.Accounts_AnnexICreditNote,
            this.Debug_ConnectedCoorindators,
            this.Debug_LoomsWindow,
            this.Debug_WirelessDevices,
            this.Accounts_SubMenu_PNL,
            this.Accounts_WeavingPNLAll,
            this.Accounts_PaymentAdvice,
            this.Planning_ProgramSheet,
            this.rpi_WeeklyEfficiencyLoomWise,
            this.rpi_MonthlyEfficiencyTabular,
            this.rpi_DailyProductionLoss,
            this.rpi_DailyEfficiencyWithProductionLoss,
            this.bbiALUGPU,
            this.rpi_DailyEfficiencyQualityWise,
            this.bbi_Data_Article_FabricName,
            this.rpi_CommingKnottings,
            this.bbi_LoomFilter,
            this.bbiGotoFilter,
            this.ButtonFuction,
            this.Efficiency_ArticleEfficiencyReport,
            this.Efficiency_MonthlyProductionLoss,
            this.Efficiency_QualityWiseProduction,
            this.Efficiency_ShedLog,
            this.AccountsTrialBalancesSumBalances,
            this.AccountsTrialBalanceConsolidated,
            this.AccountsMenuTrialBalance,
            this.Accounts_TrialBalanceEnding,
            this.Production_OutSideSizing,
            this.Button_StoreAccounts,
            this.Button_PurchaseOrderStore,
            this.Button_StorePurchaseRegister,
            this.Button_StorePurchaseReturn,
            this.Button_StoreIssueNote,
            this.SubMenu_Reports_Store,
            this.SubMenuStore_Accounts,
            this.ReportButton_StoreAccounts,
            this.rpi_DailyUnitsWeaverWise,
            this.rpi_MonthlyUnitsWeaverWise,
            this.rpi_MonthlyUnitsQualityWise,
            this.ButtonProductionSectionWarping,
            this.FabricContracts,
            this.Store_Opening,
            this.Store_Opening_SubMenu,
            this.Store_OpeningEnteries_Report,
            this.Accounts_StoreCashPurchases,
            this.Accounts_CreditStorePurchases,
            this.Production_SizingSummaryReport,
            this.Store_ItemBinCard,
            this.Store_ReceiveNote,
            this.Store_ControlAccountsList,
            this.rpi_LoomWise,
            this.Button_Towel_Opening,
            this.Button_ManageVehicles,
            this.barButtonItem_GoogleEarth,
            this.barSubItem_PluginOptions,
            this.barCheckItem_Navigator,
            this.barSubItem3,
            this.barCheckItem_Atmosphere,
            this.barCheckItem_OverView,
            this.barCheckItem_StatusBar,
            this.barStaticItem5,
            this.barLinkContainerItem1,
            this.barCheckItem_Borders,
            this.barCheckItem_Terrain,
            this.barCheckItem_Roads,
            this.barCheckItem_Buildings,
            this.Tracking_VehicleMakes,
            this.Tracking_VehicleModels,
            this.Tracking_VehicleTypes,
            this.AccountsMenuChartofAccounts,
            this.Accounts_PrintChartOfAccounts,
            this.Button_Planning_TowelArticles,
            this.Button_TowelArticles,
            this.Accounts_TrialBalanceEndingG,
            this.Accounts_TrialBalanceEndingN,
            this.Store_UnitsMeasurements,
            this.Store_Origins,
            this.bar_AutomaticUpdate,
            this.barSubItem_FinancialYears,
            this.barButtonItem_GreigeArticle,
            this.barSubItemStoreStockReports,
            this.Store_ClosingStockReport,
            this.Accounts_ChartOfAccount_TabView,
            this.PO_Greige,
            this.MDC,
            this.MDC_CashPaymentVoucher,
            this.MDC_BankPaymentVoucher,
            this.barListItem1,
            this.barLinkContainerItem2,
            this.MDC_CashReceiptVoucher,
            this.MDC_BankReceiptVoucher,
            this.MDC_JournalVoucher,
            this.SaveAsDefaultSkin,
            this.barButtonItem2,
            this.AccountsMenuPurchases,
            this.barSubItem14,
            this.Purchases_PurchaseLedger,
            this.Purchases_PurchasesSummary,
            this.Button_Towel_OpeningOutward,
            this.barSubItem_Towel_OpeningMenu,
            this.barButtonItem_Towel_Inspection,
            this.barButtonItem_PackingList_Towel,
            this.barButtonItem_Opening_Inward_Towel,
            this.barButtonItem_Opening_OutWard_Towel,
            this.barSubItem_Reports_Towel,
            this.barButtonItem_ArticleBinCard_Towel,
            this.barButtonItem_POBinCard_Towel,
            this.barButtonItem_DailyContractPosition_Towel,
            this.barButtonItem_StockReport_Towel,
            this.barButtonItem_YarnBalanceSummary_Towel,
            this.barButtonItem_Inspection_Greige,
            this.barButtonItem_TaketoGodown_Greige,
            this.barButtonItem_PackingList_Greige,
            this.barSubItem_Opening_Greige_Menu,
            this.barButtonItem_Opening_Inward_Greige,
            this.barButtonItem_Opening_OutWard_Greige,
            this.barSubItem_Reports_Greige_Menu,
            this.barButtonItem_JacquardArticles,
            this.barSubItem_Issuancereports_Store,
            this.Store_MonthlyIssuance_Report,
            this.Store_MonthlyIssuanceGroupAccount_Report,
            this.barSubItem_PurchasesReports_Store,
            this.barButtonItem_MonthlyPurchasesDetailedItem,
            this.Accounts_PurchasesOthers_Return,
            this.Accounts_SalesRegister_PartyFilter,
            this.Store_ReturnBackReports_Menu,
            this.Store_Monthly_GetBacks,
            this.Inspection_OutsideWeaving,
            this.Greige_ArticleBinCard,
            this.Greige_CurrentContractsPosition,
            this.Greige_ContractAcitivtySheet_Report,
            this.Greige_FabricReturn,
            this.Greige_ReCheck,
            this.GPS_ClientsList,
            this.Monthly_Efficiency_SelectedLoom,
            this.Accounts_SalesRegister_Dated,
            this.Accounts_PurchaseRegister_DuringPeriod,
            this.Accounts_SalesRegister_Article,
            this.rpi_BeamContraction,
            this.Efficiency_BeamContraction,
            this.Efficiency_QualityWiseBreakageReport,
            this.Efficiency_QualityWiseBreakagesGrouped,
            this.YarnReports_Menu,
            this.YarnReports_POSummary,
            this.Yarn_ReturnToParty,
            this.YarnInward,
            this.YarnOutward,
            this.SizingWorkOrderButton,
            this.DoublingMenu,
            this.IssuetoDoubling,
            this.ReceiveFromDoubling,
            this.DoublingWorkOrder,
            this.MovetoPO,
            this.ReportsMenuContracts,
            this.GreigeContractsList,
            this.DenimArticlesAdd,
            this.rpi_ShedEfficiencyLog,
            this.rpi_ShedEfficiencyGraph,
            this.barButtonItemYarnColor,
            this.barSubItem_Resize,
            this.bbi_SetLoomResizeControl,
            this.bbi_SaveLoomResizeControl,
            this.FontSizeControl,
            this.bbi_SaveLoomLayoutintoProfile,
            this.bbi_SMSDeviceAndServiceStatus,
            this.bbiYarnOpeningPlus,
            this.bbiYarnPartyStockReport,
            this.bbiTowelContractsList,
            this.bbiYarnPartyWiseStockSummary,
            this.bbiYarnIssueBetweenParties,
            this.MenuYarnInwardOutward,
            this.MenuYarnReceiveIssue,
            this.bbiYarnDepartmentStockSummary,
            this.bbiYarnGodownOrPartitionStockSummary,
            this.bbiYarnItemLedgerReport,
            this.Production_SizingMonthlyProduction,
            this.Production_SizingMonthlyProductionPartyWise,
            this.Production_SizingMonthlyProductionCountWise,
            this.WeaverGroupsManagement,
            this.rpi_DailyEfficiencyWithDailyWage,
            this.StoreLocations,
            this.Store_MonthlyIssuance_Report_Asset,
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction,
            this.DepartmentRequisitionSlip,
            this.barButtonItem1,
            this.MergedShedLayoutSaveMenu,
            this.MergedShedLayoutSaveMenuButton,
            this.YarnDoublingWorkOrderLedger,
            this.DoublingAdjustmentNote,
            this.DoublingWorkOrdersSummary,
            this.YarnDyingMenu,
            this.YarnDyingIssueNote,
            this.YarnDyingReceiveNote,
            this.YarnDyingWorkOrder,
            this.YarnDyingAdjustmentNote,
            this.YarnDyingWorkOrderLedger,
            this.YarnDyingWorkOrderSummary,
            this.RequestApproval,
            this.EmailSettings,
            this.SizingYarnLedger,
            this.MonthlyIssuanceOthers,
            this.MonthlyIssuanceAllAccounts,
            this.Contracts_Sale,
            this.Contracts_Sales_Fabric,
            this.Contracts_Sales_Towel,
            this.Contracts_Sales_Fabric_Overhead,
            this.Contracts_Sales_Fabric_Conversion,
            this.Contracts_Sales_Fabric_Sale,
            this.Contracts_Sales_Towel_Overhead,
            this.Contracts_Sales_Towel_Conversion,
            this.Contracts_Sales_Towel_Sale,
            this.Store_RequisitionList,
            this.rpi_MonthlyUnitsTabular,
            this.Store_MonthlyDepartmentIssuance,
            this.rpi_MonthlyProductionEfficiency,
            this.barSubItem_Category,
            this.barButtonItem_Category_Move,
            this.barButtonItem_SaveRunningPercentLocation,
            this.ButtonEfficiencyType,
            this.rpi_DailySummary,
            this.barButton_NewCategory,
            this.barButtonItem_Category_AddLooms,
            this.barButtonItem_Category_RemoveLooms,
            this.barButtonItem_Category_SaveCategoryLayout,
            this.rpi_TopWorseArticlesLooms,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barSubItem10,
            this.barButtonItem5,
            this.barButtonItem6,
            this.btnProduction_Inward,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9});
            this.ribbonControl1.LargeImages = this.imageCollection1;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 737;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.ribbonControl1.PageHeaderItemLinks.Add(this.iAbout);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.page_LDS,
            this.page_Planning,
            this.page_Yarn,
            this.page_Production,
            this.page_inspectionanddelivery,
            this.page_HR,
            this.page_Accounts,
            this.page_Tools,
            this.rib_Hidden,
            this.ribbonPage_Tracking});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.repositoryItemPictureEdit1,
            this.riicStyle,
            this.bbi_Debug_WaitingTime,
            this.repositoryItemRadioGroup1,
            this.repositoryItemRadioGroup2,
            this.repositoryItemRadioGroup3,
            this.repositoryItemTextEdit1,
            this.repositoryItemSpinEdit_LoomForTop,
            this.repositoryItemComboBox_AssesmentYear,
            this.repositoryItemSpinEdit2});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.SelectedPage = this.page_Production;
            this.ribbonControl1.Size = new System.Drawing.Size(1342, 144);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ItemLinks.Add(this.iPaintStyle);
            this.ribbonControl1.Toolbar.ItemLinks.Add(this.bbi_LockApp);
            this.ribbonControl1.Toolbar.ItemLinks.Add(this.bbi_UnlockApp);
            this.ribbonControl1.Toolbar.ItemLinks.Add(this.SaveAsDefaultSkin);
            this.ribbonControl1.TransparentEditors = true;
            this.ribbonControl1.ApplicationButtonDoubleClick += new System.EventHandler(this.ribbonControl1_ApplicationButtonDoubleClick);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.Images.SetKeyName(0, "blend.jpg");
            this.imageCollection2.Images.SetKeyName(1, "contacts.png");
            this.imageCollection2.Images.SetKeyName(2, "FabricArticle.png");
            this.imageCollection2.Images.SetKeyName(3, "inspection.png");
            this.imageCollection2.Images.SetKeyName(4, "Knotting.png");
            this.imageCollection2.Images.SetKeyName(5, "login.png");
            this.imageCollection2.Images.SetKeyName(6, "poweroff.png");
            this.imageCollection2.Images.SetKeyName(7, "reports.png");
            this.imageCollection2.Images.SetKeyName(8, "security.png");
            this.imageCollection2.Images.SetKeyName(9, "sizing.png");
            this.imageCollection2.Images.SetKeyName(10, "warp.png");
            this.imageCollection2.Images.SetKeyName(11, "yarn.png");
            this.imageCollection2.Images.SetKeyName(12, "Customer.png");
            this.imageCollection2.Images.SetKeyName(13, "Groups.png");
            this.imageCollection2.Images.SetKeyName(14, "Add.png");
            this.imageCollection2.Images.SetKeyName(15, "Arrow-Left.png");
            this.imageCollection2.Images.SetKeyName(16, "Arrow-Right.png");
            this.imageCollection2.Images.SetKeyName(17, "audacious.png");
            this.imageCollection2.Images.SetKeyName(18, "Bails.png");
            this.imageCollection2.Images.SetKeyName(19, "blend.jpg");
            this.imageCollection2.Images.SetKeyName(20, "blend.png");
            this.imageCollection2.Images.SetKeyName(21, "BurnAware2.png");
            this.imageCollection2.Images.SetKeyName(22, "Calculator.png");
            this.imageCollection2.Images.SetKeyName(23, "Calendar_01.png");
            this.imageCollection2.Images.SetKeyName(24, "Chart.png");
            this.imageCollection2.Images.SetKeyName(25, "ColorsManagement.png");
            this.imageCollection2.Images.SetKeyName(26, "contacts.png");
            this.imageCollection2.Images.SetKeyName(27, "Customer.png");
            this.imageCollection2.Images.SetKeyName(28, "Cut.png");
            this.imageCollection2.Images.SetKeyName(29, "defrag.png");
            this.imageCollection2.Images.SetKeyName(30, "Delete.png");
            this.imageCollection2.Images.SetKeyName(31, "Documents.png");
            this.imageCollection2.Images.SetKeyName(32, "Eject.png");
            this.imageCollection2.Images.SetKeyName(33, "Exclaim.png");
            this.imageCollection2.Images.SetKeyName(34, "FabricArticle.png");
            this.imageCollection2.Images.SetKeyName(35, "Flag_Green.png");
            this.imageCollection2.Images.SetKeyName(36, "Flag_Red.png");
            this.imageCollection2.Images.SetKeyName(37, "gear.png");
            this.imageCollection2.Images.SetKeyName(38, "Graph_01.png");
            this.imageCollection2.Images.SetKeyName(39, "Groups.png");
            this.imageCollection2.Images.SetKeyName(40, "increase.png");
            this.imageCollection2.Images.SetKeyName(41, "inspection.png");
            this.imageCollection2.Images.SetKeyName(42, "Key.png");
            this.imageCollection2.Images.SetKeyName(43, "kgzt.png");
            this.imageCollection2.Images.SetKeyName(44, "Knotting.png");
            this.imageCollection2.Images.SetKeyName(45, "light.png");
            this.imageCollection2.Images.SetKeyName(46, "Lock.png");
            this.imageCollection2.Images.SetKeyName(47, "login.png");
            this.imageCollection2.Images.SetKeyName(48, "lol.png");
            this.imageCollection2.Images.SetKeyName(49, "NetworkConfigs.png");
            this.imageCollection2.Images.SetKeyName(50, "nokia pc suite.png");
            this.imageCollection2.Images.SetKeyName(51, "PaperClip.png");
            this.imageCollection2.Images.SetKeyName(52, "poweroff.png");
            this.imageCollection2.Images.SetKeyName(53, "qip.png");
            this.imageCollection2.Images.SetKeyName(54, "refresh.png");
            this.imageCollection2.Images.SetKeyName(55, "Refresh_1.png");
            this.imageCollection2.Images.SetKeyName(56, "reports.png");
            this.imageCollection2.Images.SetKeyName(57, "RFID.png");
            this.imageCollection2.Images.SetKeyName(58, "security.png");
            this.imageCollection2.Images.SetKeyName(59, "settings.png");
            this.imageCollection2.Images.SetKeyName(60, "sizing.png");
            this.imageCollection2.Images.SetKeyName(61, "sms.png");
            this.imageCollection2.Images.SetKeyName(62, "Standby.png");
            this.imageCollection2.Images.SetKeyName(63, "Stat.png");
            this.imageCollection2.Images.SetKeyName(64, "steam2.png");
            this.imageCollection2.Images.SetKeyName(65, "Sygic-Aura.png");
            this.imageCollection2.Images.SetKeyName(66, "task manager.png");
            this.imageCollection2.Images.SetKeyName(67, "Tools.png");
            this.imageCollection2.Images.SetKeyName(68, "Trash.png");
            this.imageCollection2.Images.SetKeyName(69, "warp.png");
            this.imageCollection2.Images.SetKeyName(70, "WirelessSettings.png");
            this.imageCollection2.Images.SetKeyName(71, "wordpad.png");
            this.imageCollection2.Images.SetKeyName(72, "xbmc.png");
            this.imageCollection2.Images.SetKeyName(73, "xwidget.png");
            this.imageCollection2.Images.SetKeyName(74, "yarn.png");
            this.imageCollection2.Images.SetKeyName(75, "zoomin.png");
            this.imageCollection2.Images.SetKeyName(76, "zoomout.png");
            this.imageCollection2.Images.SetKeyName(77, "database.png");
            this.imageCollection2.Images.SetKeyName(78, "ID.png");
            this.imageCollection2.Images.SetKeyName(79, "technician.png");
            this.imageCollection2.Images.SetKeyName(80, "beam.jpg");
            this.imageCollection2.Images.SetKeyName(81, "article_A.png");
            this.imageCollection2.Images.SetKeyName(82, "Article_B.png");
            this.imageCollection2.Images.SetKeyName(83, "Article_C.png");
            this.imageCollection2.Images.SetKeyName(84, "Article_D.png");
            this.imageCollection2.Images.SetKeyName(85, "machine.png");
            this.imageCollection2.Images.SetKeyName(86, "Beam.png");
            this.imageCollection2.Images.SetKeyName(87, "chemical.png");
            this.imageCollection2.Images.SetKeyName(88, "Desig.png");
            this.imageCollection2.Images.SetKeyName(89, "Dept.png");
            this.imageCollection2.Images.SetKeyName(90, "Grade.png");
            this.imageCollection2.Images.SetKeyName(91, "lock (1).png");
            this.imageCollection2.Images.SetKeyName(92, "chabi.png");
            this.imageCollection2.Images.SetKeyName(93, "dice.png");
            this.imageCollection2.Images.SetKeyName(94, "CONNECTED_3.png");
            this.imageCollection2.Images.SetKeyName(95, "CONNECTED_1.png");
            this.imageCollection2.Images.SetKeyName(96, "CONNECTED_2.png");
            this.imageCollection2.Images.SetKeyName(97, "DISCONNECTED_2.png");
            this.imageCollection2.Images.SetKeyName(98, "DISCONNECTED_1.png");
            this.imageCollection2.Images.SetKeyName(99, "progress.png");
            this.imageCollection2.Images.SetKeyName(100, "works_in_progress.png");
            this.imageCollection2.Images.SetKeyName(101, "article.png");
            this.imageCollection2.Images.SetKeyName(102, "BeamShort.png");
            this.imageCollection2.Images.SetKeyName(103, "electrical.png");
            this.imageCollection2.Images.SetKeyName(104, "knotting.png");
            this.imageCollection2.Images.SetKeyName(105, "leno.png");
            this.imageCollection2.Images.SetKeyName(106, "mechanical.png");
            this.imageCollection2.Images.SetKeyName(107, "other.png");
            this.imageCollection2.Images.SetKeyName(108, "Other_Long.png");
            this.imageCollection2.Images.SetKeyName(109, "Pile.png");
            this.imageCollection2.Images.SetKeyName(110, "reknotting.png");
            this.imageCollection2.Images.SetKeyName(111, "unknown.png");
            this.imageCollection2.Images.SetKeyName(112, "warp.png");
            this.imageCollection2.Images.SetKeyName(113, "weft.png");
            this.imageCollection2.Images.SetKeyName(114, "electrical.png");
            this.imageCollection2.Images.SetKeyName(115, "mechanical.png");
            this.imageCollection2.Images.SetKeyName(116, "other.png");
            this.imageCollection2.Images.SetKeyName(117, "otherlong.png");
            this.imageCollection2.Images.SetKeyName(118, "Shift.png");
            this.imageCollection2.Images.SetKeyName(119, "simplereport.png");
            this.imageCollection2.Images.SetKeyName(120, "Email-Forward-icon.png");
            this.imageCollection2.Images.SetKeyName(121, "loom.png");
            this.imageCollection2.Images.SetKeyName(122, "puzzle.png");
            this.imageCollection2.Images.SetKeyName(123, "alt_out_box.png");
            this.imageCollection2.Images.SetKeyName(124, "alt_out_box_2.png");
            this.imageCollection2.Images.SetKeyName(125, "out.png");
            this.imageCollection2.Images.SetKeyName(126, "out_box.png");
            this.imageCollection2.Images.SetKeyName(127, "out_folder.png");
            this.imageCollection2.Images.SetKeyName(128, "sign_in (1).png");
            this.imageCollection2.Images.SetKeyName(129, "sign_in.png");
            this.imageCollection2.Images.SetKeyName(130, "sign_out (1).png");
            this.imageCollection2.Images.SetKeyName(131, "sign_out (2).png");
            this.imageCollection2.Images.SetKeyName(132, "sign_out (3).png");
            this.imageCollection2.Images.SetKeyName(133, "sign_out.png");
            this.imageCollection2.Images.SetKeyName(134, "sign_up.png");
            this.imageCollection2.Images.SetKeyName(135, "Execute.png");
            this.imageCollection2.Images.SetKeyName(136, "RefreshAccounts.png");
            this.imageCollection2.Images.SetKeyName(137, "Cash.png");
            this.imageCollection2.Images.SetKeyName(138, "dollar.png");
            this.imageCollection2.Images.SetKeyName(139, "bank.png");
            this.imageCollection2.Images.SetKeyName(140, "currency_dollar_green.png");
            this.imageCollection2.Images.SetKeyName(141, "currency_dollar_red.png");
            this.imageCollection2.Images.SetKeyName(142, "bank (1).png");
            this.imageCollection2.Images.SetKeyName(143, "DNI.png");
            this.imageCollection2.Images.SetKeyName(144, "FI.png");
            this.imageCollection2.Images.SetKeyName(145, "SalesReturn32.png");
            this.imageCollection2.Images.SetKeyName(146, "FDNI16.png");
            this.imageCollection2.Images.SetKeyName(147, "SecurityAllowed.png");
            this.imageCollection2.Images.SetKeyName(148, "SecurityNotAllowed.png");
            this.imageCollection2.Images.SetKeyName(149, "filter.png");
            this.imageCollection2.Images.SetKeyName(150, "FinancialYears.png");
            // 
            // bbi_Data_Article_Insertion
            // 
            this.bbi_Data_Article_Insertion.Caption = "Insertion";
            this.bbi_Data_Article_Insertion.CategoryGuid = new System.Guid("7c2486e1-92ea-4293-ad55-b819f61ff7f1");
            this.bbi_Data_Article_Insertion.Description = "[Planning] Manage weaving insertion list";
            this.bbi_Data_Article_Insertion.Hint = "Paste";
            this.bbi_Data_Article_Insertion.Id = 11;
            this.bbi_Data_Article_Insertion.ImageIndex = 84;
            this.bbi_Data_Article_Insertion.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V));
            this.bbi_Data_Article_Insertion.Name = "bbi_Data_Article_Insertion";
            this.bbi_Data_Article_Insertion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Article_Insertion_ItemClick);
            // 
            // iFont
            // 
            this.iFont.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.iFont.Caption = "Font...";
            this.iFont.CategoryGuid = new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258");
            this.iFont.Description = "[Display] Changes the font and character spacing formats of the selected text.";
            this.iFont.DropDownControl = this.gddFont;
            this.iFont.Hint = "Font Dialog";
            this.iFont.Id = 17;
            this.iFont.ImageIndex = 4;
            this.iFont.Name = "iFont";
            this.iFont.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.iFont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iFont_ItemClick);
            // 
            // gddFont
            // 
            // 
            // 
            // 
            this.gddFont.Gallery.Appearance.ItemCaption.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.gddFont.Gallery.Appearance.ItemCaption.Options.UseFont = true;
            this.gddFont.Gallery.Appearance.ItemCaption.Options.UseTextOptions = true;
            this.gddFont.Gallery.Appearance.ItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gddFont.Gallery.Appearance.ItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gddFont.Gallery.Appearance.ItemDescription.Options.UseTextOptions = true;
            this.gddFont.Gallery.Appearance.ItemDescription.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gddFont.Gallery.Appearance.ItemDescription.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gddFont.Gallery.ColumnCount = 1;
            this.gddFont.Gallery.FixedImageSize = false;
            galleryItemGroup1.Caption = "Main";
            this.gddFont.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup1});
            this.gddFont.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Left;
            this.gddFont.Gallery.RowCount = 6;
            this.gddFont.Gallery.ShowGroupCaption = false;
            this.gddFont.Gallery.ShowItemText = true;
            this.gddFont.Gallery.SizeMode = DevExpress.XtraBars.Ribbon.GallerySizeMode.Vertical;
            this.gddFont.Gallery.CustomDrawItemText += new DevExpress.XtraBars.Ribbon.GalleryItemCustomDrawEventHandler(this.gddFont_Gallery_CustomDrawItemText);
            this.gddFont.Name = "gddFont";
            this.gddFont.Ribbon = this.ribbonControl1;
            this.gddFont.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.gddFont_GalleryItemClick);
            // 
            // iWeb
            // 
            this.iWeb.Caption = "Machine Eyes";
            this.iWeb.CategoryGuid = new System.Guid("e07a4c24-66ac-4de6-bbcb-c0b6cfa7798b");
            this.iWeb.Description = "[About] Machine eyes design and development related information";
            this.iWeb.Hint = "Developer Express on the Web";
            this.iWeb.Id = 21;
            this.iWeb.ImageIndex = 24;
            this.iWeb.Name = "iWeb";
            this.iWeb.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iWeb_ItemClick);
            // 
            // iAbout
            // 
            this.iAbout.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.iAbout.Caption = "About";
            this.iAbout.CategoryGuid = new System.Guid("e07a4c24-66ac-4de6-bbcb-c0b6cfa7798b");
            this.iAbout.Description = "[About] Displays the description of this program.";
            this.iAbout.Hint = "Displays the About dialog";
            this.iAbout.Id = 22;
            this.iAbout.ImageIndex = 45;
            this.iAbout.Name = "iAbout";
            this.iAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAbout_ItemClick);
            // 
            // bbi_Debug_DebugMode
            // 
            this.bbi_Debug_DebugMode.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbi_Debug_DebugMode.Caption = "Debug Mode";
            this.bbi_Debug_DebugMode.CategoryGuid = new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258");
            this.bbi_Debug_DebugMode.Description = "[Debug] Displays Timings on the basis of last Sink Fetched Time...(Debugging only" +
    ")";
            this.bbi_Debug_DebugMode.Hint = "Bold";
            this.bbi_Debug_DebugMode.Id = 24;
            this.bbi_Debug_DebugMode.ImageIndex = 15;
            this.bbi_Debug_DebugMode.ItemShortcut = new DevExpress.XtraBars.BarShortcut(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                | System.Windows.Forms.Keys.D));
            this.bbi_Debug_DebugMode.Name = "bbi_Debug_DebugMode";
            this.bbi_Debug_DebugMode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Tools_CalcTimeOnLastSinkFetched_ItemClick);
            // 
            // bbi_Tools_RPMColors
            // 
            this.bbi_Tools_RPMColors.Caption = "RPM Colors";
            this.bbi_Tools_RPMColors.CategoryGuid = new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258");
            this.bbi_Tools_RPMColors.Description = "[Dashboard] set RPM colors for real time loom display layout and reports";
            this.bbi_Tools_RPMColors.Hint = "Italic";
            this.bbi_Tools_RPMColors.Id = 25;
            this.bbi_Tools_RPMColors.ImageIndex = 16;
            this.bbi_Tools_RPMColors.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.bbi_Tools_RPMColors.Name = "bbi_Tools_RPMColors";
            // 
            // bbi_Tools_EffColors
            // 
            this.bbi_Tools_EffColors.Caption = "Efficiency Colors";
            this.bbi_Tools_EffColors.CategoryGuid = new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258");
            this.bbi_Tools_EffColors.Description = "[Dashboard] set efficiency colors for real time loom display layout and reports";
            this.bbi_Tools_EffColors.Hint = "Underline";
            this.bbi_Tools_EffColors.Id = 26;
            this.bbi_Tools_EffColors.ImageIndex = 7;
            this.bbi_Tools_EffColors.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U));
            this.bbi_Tools_EffColors.Name = "bbi_Tools_EffColors";
            this.bbi_Tools_EffColors.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Tools_EffColors_ItemClick);
            // 
            // iFontColor
            // 
            this.iFontColor.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.iFontColor.Caption = "Font Color";
            this.iFontColor.CategoryGuid = new System.Guid("d3052f28-4b3e-4bae-b581-b3bb1c432258");
            this.iFontColor.Description = "[Display] Formats the selected text with the color you click.";
            this.iFontColor.DropDownControl = this.gddFontColor;
            this.iFontColor.Hint = "Font Color";
            this.iFontColor.Id = 30;
            this.iFontColor.ImageIndex = 5;
            this.iFontColor.Name = "iFontColor";
            this.iFontColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iFontColor_ItemClick);
            // 
            // gddFontColor
            // 
            // 
            // 
            // 
            this.gddFontColor.Gallery.Appearance.ItemCaption.Font = new System.Drawing.Font("Tahoma", 6.75F);
            this.gddFontColor.Gallery.Appearance.ItemCaption.Options.UseFont = true;
            this.gddFontColor.Gallery.Appearance.ItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gddFontColor.Gallery.FilterCaption = "All Colors";
            this.gddFontColor.Gallery.FixedImageSize = false;
            galleryItemGroup2.Caption = "Web Colors";
            galleryItemGroup3.Caption = "System Colors";
            this.gddFontColor.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup2,
            galleryItemGroup3});
            this.gddFontColor.Gallery.ImageSize = new System.Drawing.Size(48, 16);
            this.gddFontColor.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.gddFontColor.Gallery.RowCount = 5;
            this.gddFontColor.Gallery.ShowItemText = true;
            this.gddFontColor.Gallery.SizeMode = DevExpress.XtraBars.Ribbon.GallerySizeMode.Both;
            this.gddFontColor.Gallery.CustomDrawItemImage += new DevExpress.XtraBars.Ribbon.GalleryItemCustomDrawEventHandler(this.gddFontColor_Gallery_CustomDrawItemImage);
            this.gddFontColor.Name = "gddFontColor";
            this.gddFontColor.Ribbon = this.ribbonControl1;
            this.gddFontColor.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.gddFontColor_GalleryItemClick);
            this.gddFontColor.Popup += new System.EventHandler(this.gddFontColor_Popup);
            // 
            // sbiShed
            // 
            this.sbiShed.Caption = "Shed";
            this.sbiShed.CategoryGuid = new System.Guid("7c2486e1-92ea-4293-ad55-b819f61ff7f1");
            this.sbiShed.Description = "Inserts the contents of the Clipboard at the insertion point";
            this.sbiShed.Hint = "Inserts the contents of the Clipboard at the insertion point";
            this.sbiShed.Id = 1;
            this.sbiShed.ImageIndex = 8;
            this.sbiShed.LargeImageIndex = 3;
            this.sbiShed.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_Data_Article_Insertion)});
            this.sbiShed.Name = "sbiShed";
            this.sbiShed.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // iPaintStyle
            // 
            this.iPaintStyle.Caption = "Paint style";
            this.iPaintStyle.Description = "Select a paint scheme";
            this.iPaintStyle.Hint = "Select a paint scheme";
            this.iPaintStyle.Id = 7;
            this.iPaintStyle.ImageIndex = 26;
            this.iPaintStyle.Name = "iPaintStyle";
            this.iPaintStyle.Popup += new System.EventHandler(this.iPaintStyle_Popup);
            // 
            // rgbiSkins
            // 
            this.rgbiSkins.Caption = "Skins";
            // 
            // 
            // 
            this.rgbiSkins.Gallery.AllowHoverImages = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.Options.UseFont = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.Options.UseTextOptions = true;
            this.rgbiSkins.Gallery.Appearance.ItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.rgbiSkins.Gallery.ColumnCount = 4;
            this.rgbiSkins.Gallery.FixedHoverImageSize = false;
            galleryItemGroup4.Caption = "Main Skins";
            galleryItemGroup5.Caption = "Office Skins";
            galleryItemGroup6.Caption = "Bonus Skins";
            this.rgbiSkins.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup4,
            galleryItemGroup5,
            galleryItemGroup6});
            this.rgbiSkins.Gallery.ImageSize = new System.Drawing.Size(32, 17);
            this.rgbiSkins.Gallery.ItemImageLocation = DevExpress.Utils.Locations.Top;
            this.rgbiSkins.Gallery.RowCount = 4;
            this.rgbiSkins.Gallery.InitDropDownGallery += new DevExpress.XtraBars.Ribbon.InplaceGalleryEventHandler(this.rgbiSkins_Gallery_InitDropDownGallery);
            this.rgbiSkins.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiSkins_Gallery_ItemClick);
            this.rgbiSkins.Id = 13;
            this.rgbiSkins.Name = "rgbiSkins";
            // 
            // beiFontSize
            // 
            this.beiFontSize.Caption = "Font Size";
            this.beiFontSize.Edit = this.repositoryItemSpinEdit1;
            this.beiFontSize.Hint = "Font Size";
            this.beiFontSize.Id = 27;
            this.beiFontSize.Name = "beiFontSize";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            this.repositoryItemSpinEdit1.UseParentBackground = true;
            // 
            // rgbiFont
            // 
            this.rgbiFont.Caption = "Font";
            // 
            // 
            // 
            this.rgbiFont.Gallery.AllowHoverImages = true;
            galleryItemGroup7.Caption = "Main";
            this.rgbiFont.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup7});
            this.rgbiFont.GalleryDropDown = this.gddFont;
            this.rgbiFont.Id = 29;
            this.rgbiFont.Name = "rgbiFont";
            this.rgbiFont.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiFont_GalleryItemClick);
            // 
            // bbiFontColorPopup
            // 
            this.bbiFontColorPopup.ActAsDropDown = true;
            this.bbiFontColorPopup.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.bbiFontColorPopup.Caption = "Font Color";
            this.bbiFontColorPopup.Description = "[Display] Formats the selected text with the color you click";
            this.bbiFontColorPopup.DropDownControl = this.popupControlContainer1;
            this.bbiFontColorPopup.Hint = "Formats the selected text with the color you click";
            this.bbiFontColorPopup.Id = 36;
            this.bbiFontColorPopup.Name = "bbiFontColorPopup";
            // 
            // rgbiFontColor
            // 
            this.rgbiFontColor.Caption = "Color";
            // 
            // 
            // 
            this.rgbiFontColor.Gallery.ColumnCount = 10;
            galleryItemGroup8.Caption = "Main";
            this.rgbiFontColor.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup8});
            this.rgbiFontColor.Gallery.ImageSize = new System.Drawing.Size(10, 7);
            this.rgbiFontColor.Gallery.CustomDrawItemImage += new DevExpress.XtraBars.Ribbon.GalleryItemCustomDrawEventHandler(this.gddFontColor_Gallery_CustomDrawItemImage);
            this.rgbiFontColor.GalleryDropDown = this.gddFontColor;
            this.rgbiFontColor.Id = 37;
            this.rgbiFontColor.Name = "rgbiFontColor";
            this.rgbiFontColor.GalleryItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.rgbiFontColor_GalleryItemClick);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barEditItem1.CanOpenEdit = false;
            this.barEditItem1.Edit = this.repositoryItemPictureEdit1;
            this.barEditItem1.Id = 94;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Width = 130;
            this.barEditItem1.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemPress);
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.AllowFocused = false;
            this.repositoryItemPictureEdit1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.UseParentBackground = true;
            // 
            // bbi_Data_Article_Selvage
            // 
            this.bbi_Data_Article_Selvage.Caption = "Selvage";
            this.bbi_Data_Article_Selvage.Description = "[Planning]  Manage common fabric selvage list";
            this.bbi_Data_Article_Selvage.Id = 128;
            this.bbi_Data_Article_Selvage.ImageIndex = 82;
            this.bbi_Data_Article_Selvage.Name = "bbi_Data_Article_Selvage";
            this.bbi_Data_Article_Selvage.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Article_Selvage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Article_Selvage_ItemClick);
            // 
            // bbi_Data_Article_Weave
            // 
            this.bbi_Data_Article_Weave.Caption = "Weave";
            this.bbi_Data_Article_Weave.Description = "[Planning] Manage articles weave list";
            this.bbi_Data_Article_Weave.Id = 129;
            this.bbi_Data_Article_Weave.ImageIndex = 83;
            this.bbi_Data_Article_Weave.Name = "bbi_Data_Article_Weave";
            this.bbi_Data_Article_Weave.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Article_Weave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Article_Weave_ItemClick);
            // 
            // bbi_Data_Warping_Beams
            // 
            this.bbi_Data_Warping_Beams.Caption = "Beams";
            this.bbi_Data_Warping_Beams.Description = "[Production] Manage warping beams list";
            this.bbi_Data_Warping_Beams.Id = 137;
            this.bbi_Data_Warping_Beams.ImageIndex = 86;
            this.bbi_Data_Warping_Beams.Name = "bbi_Data_Warping_Beams";
            this.bbi_Data_Warping_Beams.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Warping_Beams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Warping_Beams_ItemClick);
            // 
            // bbi_Data_Warping_Machines
            // 
            this.bbi_Data_Warping_Machines.Caption = "Machines";
            this.bbi_Data_Warping_Machines.Description = "[Production] Manage warping machines list";
            this.bbi_Data_Warping_Machines.Id = 138;
            this.bbi_Data_Warping_Machines.ImageIndex = 85;
            this.bbi_Data_Warping_Machines.Name = "bbi_Data_Warping_Machines";
            this.bbi_Data_Warping_Machines.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Warping_Machines.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Warping_Machines_ItemClick);
            // 
            // bbi_Data_Warping_Main
            // 
            this.bbi_Data_Warping_Main.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Data_Warping_Main.Appearance.Options.UseFont = true;
            this.bbi_Data_Warping_Main.Caption = "Warping";
            this.bbi_Data_Warping_Main.Description = "[Production] Manage warping daily production";
            this.bbi_Data_Warping_Main.Id = 139;
            this.bbi_Data_Warping_Main.ImageIndex = 10;
            this.bbi_Data_Warping_Main.LargeImageIndex = 10;
            this.bbi_Data_Warping_Main.Name = "bbi_Data_Warping_Main";
            this.bbi_Data_Warping_Main.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbi_Data_Warping_Main.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Warping_Main_ItemClick);
            // 
            // bbi_Data_Sizing_Beams
            // 
            this.bbi_Data_Sizing_Beams.Caption = "Beams";
            this.bbi_Data_Sizing_Beams.Description = "[Production] Manage sizing beams list";
            this.bbi_Data_Sizing_Beams.Id = 140;
            this.bbi_Data_Sizing_Beams.ImageIndex = 86;
            this.bbi_Data_Sizing_Beams.Name = "bbi_Data_Sizing_Beams";
            this.bbi_Data_Sizing_Beams.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Sizing_Beams.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Sizing_Beams_ItemClick);
            // 
            // bbi_Data_Sizing_Chemicals
            // 
            this.bbi_Data_Sizing_Chemicals.Caption = "Chemicals";
            this.bbi_Data_Sizing_Chemicals.Description = "[Production] Manage sizing chemicals names and parameters";
            this.bbi_Data_Sizing_Chemicals.Id = 141;
            this.bbi_Data_Sizing_Chemicals.ImageIndex = 87;
            this.bbi_Data_Sizing_Chemicals.Name = "bbi_Data_Sizing_Chemicals";
            this.bbi_Data_Sizing_Chemicals.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_Sizing_Chemicals.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Sizing_Chemicals_ItemClick);
            // 
            // bbi_Data_Sizing_Main
            // 
            this.bbi_Data_Sizing_Main.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Data_Sizing_Main.Appearance.Options.UseFont = true;
            this.bbi_Data_Sizing_Main.Caption = "Sizing ";
            this.bbi_Data_Sizing_Main.Description = "[Production] Manage daily sizing production";
            this.bbi_Data_Sizing_Main.Id = 142;
            this.bbi_Data_Sizing_Main.ImageIndex = 9;
            this.bbi_Data_Sizing_Main.LargeImageIndex = 9;
            this.bbi_Data_Sizing_Main.Name = "bbi_Data_Sizing_Main";
            this.bbi_Data_Sizing_Main.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbi_Data_Sizing_Main.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Sizing_Main_ItemClick);
            // 
            // bbi_Data_Knotting_Main
            // 
            this.bbi_Data_Knotting_Main.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Data_Knotting_Main.Appearance.Options.UseFont = true;
            this.bbi_Data_Knotting_Main.Caption = "Knotting";
            this.bbi_Data_Knotting_Main.Description = "[Weaving] set knotting parameters on machine";
            this.bbi_Data_Knotting_Main.Id = 143;
            this.bbi_Data_Knotting_Main.ImageIndex = 11;
            this.bbi_Data_Knotting_Main.LargeImageIndex = 11;
            this.bbi_Data_Knotting_Main.Name = "bbi_Data_Knotting_Main";
            this.bbi_Data_Knotting_Main.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Knotting_Main_ItemClick);
            // 
            // bbi_Dashboard_ShedEff
            // 
            this.bbi_Dashboard_ShedEff.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Dashboard_ShedEff.Appearance.Options.UseFont = true;
            this.bbi_Dashboard_ShedEff.Appearance.Options.UseTextOptions = true;
            this.bbi_Dashboard_ShedEff.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.bbi_Dashboard_ShedEff.AppearanceDisabled.Options.UseTextOptions = true;
            this.bbi_Dashboard_ShedEff.AppearanceDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.bbi_Dashboard_ShedEff.Caption = "Shed Efficiency";
            this.bbi_Dashboard_ShedEff.Description = "[Dashboard] Real time display of shed efficiency of weaving shed";
            this.bbi_Dashboard_ShedEff.Id = 152;
            this.bbi_Dashboard_ShedEff.LargeImageIndex = 66;
            this.bbi_Dashboard_ShedEff.Name = "bbi_Dashboard_ShedEff";
            this.bbi_Dashboard_ShedEff.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Dashboard_ShedEff_ItemClick);
            // 
            // bbi_DashBoard_SizingView
            // 
            this.bbi_DashBoard_SizingView.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_DashBoard_SizingView.Appearance.Options.UseFont = true;
            this.bbi_DashBoard_SizingView.Appearance.Options.UseTextOptions = true;
            this.bbi_DashBoard_SizingView.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.bbi_DashBoard_SizingView.Caption = "Catogory Efficiency";
            this.bbi_DashBoard_SizingView.Description = "[Dashboard] Real time display of sizing category wise efficiency";
            this.bbi_DashBoard_SizingView.Id = 153;
            this.bbi_DashBoard_SizingView.LargeImageIndex = 59;
            this.bbi_DashBoard_SizingView.Name = "bbi_DashBoard_SizingView";
            this.bbi_DashBoard_SizingView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_DashBoard_SizingView_ItemClick);
            // 
            // bbi_Dashboard_ArticleEfficiency
            // 
            this.bbi_Dashboard_ArticleEfficiency.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Dashboard_ArticleEfficiency.Appearance.Options.UseFont = true;
            this.bbi_Dashboard_ArticleEfficiency.Appearance.Options.UseTextOptions = true;
            this.bbi_Dashboard_ArticleEfficiency.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.bbi_Dashboard_ArticleEfficiency.Caption = "Article View";
            this.bbi_Dashboard_ArticleEfficiency.Description = "[Dashboard] Displays Machine Eyes real time article wise display";
            this.bbi_Dashboard_ArticleEfficiency.Id = 155;
            this.bbi_Dashboard_ArticleEfficiency.ImageIndex = 25;
            this.bbi_Dashboard_ArticleEfficiency.Name = "bbi_Dashboard_ArticleEfficiency";
            this.bbi_Dashboard_ArticleEfficiency.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Dashboard_ArticleEfficiency_ItemClick);
            // 
            // bbi_Dashboard_ExecutiveSummary
            // 
            this.bbi_Dashboard_ExecutiveSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Dashboard_ExecutiveSummary.Appearance.Options.UseFont = true;
            this.bbi_Dashboard_ExecutiveSummary.Appearance.Options.UseTextOptions = true;
            this.bbi_Dashboard_ExecutiveSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.bbi_Dashboard_ExecutiveSummary.Caption = "Executive View";
            this.bbi_Dashboard_ExecutiveSummary.Description = "[Dashboard] Displays Machine Eyes real time executive dashboard";
            this.bbi_Dashboard_ExecutiveSummary.Id = 156;
            this.bbi_Dashboard_ExecutiveSummary.ImageIndex = 7;
            this.bbi_Dashboard_ExecutiveSummary.Name = "bbi_Dashboard_ExecutiveSummary";
            this.bbi_Dashboard_ExecutiveSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Dashboard_ExecutiveSummary_ItemClick);
            // 
            // bbi_Tools_SMSSettings
            // 
            this.bbi_Tools_SMSSettings.Caption = "SMS Settings";
            this.bbi_Tools_SMSSettings.Description = "[SMS] SMS Settings";
            this.bbi_Tools_SMSSettings.Id = 165;
            this.bbi_Tools_SMSSettings.LargeImageIndex = 61;
            this.bbi_Tools_SMSSettings.Name = "bbi_Tools_SMSSettings";
            this.bbi_Tools_SMSSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Tools_SMSSettings_ItemClick);
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Id = 168;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bbi_Data_AssignLoom_Weavers
            // 
            this.bbi_Data_AssignLoom_Weavers.Caption = "Assign Weavers";
            this.bbi_Data_AssignLoom_Weavers.Description = "[Weaving] assign weavers working on looms";
            this.bbi_Data_AssignLoom_Weavers.Id = 174;
            this.bbi_Data_AssignLoom_Weavers.ImageIndex = 78;
            this.bbi_Data_AssignLoom_Weavers.Name = "bbi_Data_AssignLoom_Weavers";
            this.bbi_Data_AssignLoom_Weavers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // bbi_Data_AssignLoom_Technician
            // 
            this.bbi_Data_AssignLoom_Technician.Caption = "Assign Technician";
            this.bbi_Data_AssignLoom_Technician.Description = "[Weaving] assign technician working on machine";
            this.bbi_Data_AssignLoom_Technician.Id = 175;
            this.bbi_Data_AssignLoom_Technician.ImageIndex = 79;
            this.bbi_Data_AssignLoom_Technician.Name = "bbi_Data_AssignLoom_Technician";
            this.bbi_Data_AssignLoom_Technician.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            // 
            // bbi_Data_AssignLoom_Beam
            // 
            this.bbi_Data_AssignLoom_Beam.Caption = "View and Assign Sized Beam";
            this.bbi_Data_AssignLoom_Beam.Description = "[Weaving] assign sized beam to loom";
            this.bbi_Data_AssignLoom_Beam.Id = 176;
            this.bbi_Data_AssignLoom_Beam.ImageIndex = 86;
            this.bbi_Data_AssignLoom_Beam.Name = "bbi_Data_AssignLoom_Beam";
            this.bbi_Data_AssignLoom_Beam.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bbi_Data_AssignLoom_Beam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_AssignLoom_Beam_ItemClick);
            // 
            // bbi_LockApp
            // 
            this.bbi_LockApp.Caption = "Lock";
            this.bbi_LockApp.Description = "[Display] temporarily locks the application";
            this.bbi_LockApp.Id = 181;
            this.bbi_LockApp.ImageIndex = 91;
            this.bbi_LockApp.Name = "bbi_LockApp";
            toolTipTitleItem1.Text = "Lock Application";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Click here to temporarily lock the application...you will need to re-enter your p" +
    "assword to unlock...";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.bbi_LockApp.SuperTip = superToolTip1;
            this.bbi_LockApp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_LockApp_ItemClick);
            // 
            // bci_DashBoard_DesignMove
            // 
            this.bci_DashBoard_DesignMove.Caption = "Move";
            this.bci_DashBoard_DesignMove.Description = "[Dashboard] Move Looms real time display layout and settle shed layout";
            this.bci_DashBoard_DesignMove.Id = 184;
            this.bci_DashBoard_DesignMove.ImageIndex = 93;
            this.bci_DashBoard_DesignMove.Name = "bci_DashBoard_DesignMove";
            this.bci_DashBoard_DesignMove.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.bci_DashBoard_DesignMove.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bci_DashBoard_DesignMove_CheckedChanged);
            // 
            // bbi_DashBoard_DesignSave
            // 
            this.bbi_DashBoard_DesignSave.Caption = "Save";
            this.bbi_DashBoard_DesignSave.Description = "[Dashboard] Save Looms real time display layout and settle shed layout";
            this.bbi_DashBoard_DesignSave.Id = 185;
            this.bbi_DashBoard_DesignSave.ImageIndex = 32;
            this.bbi_DashBoard_DesignSave.Name = "bbi_DashBoard_DesignSave";
            this.bbi_DashBoard_DesignSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_DashBoard_DesignSave_ItemClick);
            // 
            // bar_ServiceStatus
            // 
            this.bar_ServiceStatus.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar_ServiceStatus.Appearance.Options.UseFont = true;
            this.bar_ServiceStatus.Caption = "DISCONNECTED";
            this.bar_ServiceStatus.Description = "[Status] service connection status";
            this.bar_ServiceStatus.Id = 186;
            this.bar_ServiceStatus.ImageIndex = 98;
            this.bar_ServiceStatus.Name = "bar_ServiceStatus";
            toolTipTitleItem2.Text = "SERVICE STATUS";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Service is configured to connect to http://127.0.0.1/MachineeyesService.asmx";
            toolTipTitleItem3.LeftIndent = 6;
            toolTipTitleItem3.Text = "http://www.infox.com.pk";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            superToolTip2.Items.Add(toolTipSeparatorItem1);
            superToolTip2.Items.Add(toolTipTitleItem3);
            this.bar_ServiceStatus.SuperTip = superToolTip2;
            this.bar_ServiceStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_ServiceStatus_ItemClick);
            // 
            // bar_Progress
            // 
            this.bar_Progress.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar_Progress.Appearance.Options.UseFont = true;
            this.bar_Progress.Caption = "Progress";
            this.bar_Progress.Description = "[Status] service progress and connection";
            this.bar_Progress.Id = 187;
            this.bar_Progress.ImageIndex = 100;
            this.bar_Progress.Name = "bar_Progress";
            // 
            // bbi_Data_AssignLoom_CurrentLoomInfo
            // 
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Appearance.Options.UseFont = true;
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Caption = "Stops and prod. Loss";
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Description = "[Dashboard] current loom stops";
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Id = 202;
            this.bbi_Data_AssignLoom_CurrentLoomInfo.ImageIndex = 33;
            this.bbi_Data_AssignLoom_CurrentLoomInfo.Name = "bbi_Data_AssignLoom_CurrentLoomInfo";
            this.bbi_Data_AssignLoom_CurrentLoomInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_AssignLoom_CurrentLoomInfo_ItemClick);
            // 
            // bbiSubMenu_AssignStopCause
            // 
            this.bbiSubMenu_AssignStopCause.Caption = "Assign Stop Cause";
            this.bbiSubMenu_AssignStopCause.Id = 206;
            this.bbiSubMenu_AssignStopCause.ImageIndex = 36;
            this.bbiSubMenu_AssignStopCause.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAssign_Mechanical),
            new DevExpress.XtraBars.LinkPersistInfo(this.barAssign_Electrical),
            new DevExpress.XtraBars.LinkPersistInfo(this.barAssign_Knotting),
            new DevExpress.XtraBars.LinkPersistInfo(this.barAssign_ArticleChange),
            new DevExpress.XtraBars.LinkPersistInfo(this.barAssign_OtherStop)});
            this.bbiSubMenu_AssignStopCause.Name = "bbiSubMenu_AssignStopCause";
            // 
            // barAssign_Mechanical
            // 
            this.barAssign_Mechanical.Caption = "Mechanical Stop";
            this.barAssign_Mechanical.Id = 207;
            this.barAssign_Mechanical.ImageIndex = 115;
            this.barAssign_Mechanical.Name = "barAssign_Mechanical";
            this.barAssign_Mechanical.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_Mechanical_CheckedChanged);
            this.barAssign_Mechanical.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_Mechanical_ItemClick);
            // 
            // barAssign_Electrical
            // 
            this.barAssign_Electrical.Caption = "Electrical Stop";
            this.barAssign_Electrical.Id = 208;
            this.barAssign_Electrical.ImageIndex = 114;
            this.barAssign_Electrical.Name = "barAssign_Electrical";
            this.barAssign_Electrical.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_Electrical_ItemClick);
            // 
            // barAssign_Knotting
            // 
            this.barAssign_Knotting.Caption = "Knotting";
            this.barAssign_Knotting.Id = 209;
            this.barAssign_Knotting.ImageIndex = 104;
            this.barAssign_Knotting.Name = "barAssign_Knotting";
            this.barAssign_Knotting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_Knotting_ItemClick);
            // 
            // barAssign_ArticleChange
            // 
            this.barAssign_ArticleChange.Caption = "Article Change";
            this.barAssign_ArticleChange.Id = 210;
            this.barAssign_ArticleChange.ImageIndex = 101;
            this.barAssign_ArticleChange.Name = "barAssign_ArticleChange";
            this.barAssign_ArticleChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_ArticleChange_ItemClick);
            // 
            // barAssign_OtherStop
            // 
            this.barAssign_OtherStop.Caption = "Other Stop";
            this.barAssign_OtherStop.Id = 211;
            this.barAssign_OtherStop.ImageIndex = 117;
            this.barAssign_OtherStop.Name = "barAssign_OtherStop";
            this.barAssign_OtherStop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barAssign_OtherStop_ItemClick);
            // 
            // bbi_Data_Assign_FDNI
            // 
            this.bbi_Data_Assign_FDNI.Caption = "Exclude from Running Efficiency";
            this.bbi_Data_Assign_FDNI.Description = "[Dashboard] exclude machine from running efficiency";
            this.bbi_Data_Assign_FDNI.Id = 212;
            this.bbi_Data_Assign_FDNI.ImageIndex = 146;
            this.bbi_Data_Assign_FDNI.Name = "bbi_Data_Assign_FDNI";
            this.bbi_Data_Assign_FDNI.Tag = "0";
            this.bbi_Data_Assign_FDNI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Assign_DNI_ItemClick);
            // 
            // bbi_Debug_WaitingTimeButton
            // 
            this.bbi_Debug_WaitingTimeButton.Caption = "Waiting Time";
            this.bbi_Debug_WaitingTimeButton.Description = "[Tools] Wating Time Setting";
            this.bbi_Debug_WaitingTimeButton.Edit = this.bbi_Debug_WaitingTime;
            this.bbi_Debug_WaitingTimeButton.EditValue = 180D;
            this.bbi_Debug_WaitingTimeButton.Id = 214;
            this.bbi_Debug_WaitingTimeButton.Name = "bbi_Debug_WaitingTimeButton";
            this.bbi_Debug_WaitingTimeButton.EditValueChanged += new System.EventHandler(this.bbi_Debug_WaitingTimeButton_EditValueChanged);
            // 
            // bbi_Debug_WaitingTime
            // 
            this.bbi_Debug_WaitingTime.AutoHeight = false;
            this.bbi_Debug_WaitingTime.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.bbi_Debug_WaitingTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.bbi_Debug_WaitingTime.IsFloatValue = false;
            this.bbi_Debug_WaitingTime.Mask.EditMask = "N00";
            this.bbi_Debug_WaitingTime.Name = "bbi_Debug_WaitingTime";
            this.bbi_Debug_WaitingTime.UseParentBackground = true;
            // 
            // bar_Shift
            // 
            this.bar_Shift.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar_Shift.Appearance.Options.UseFont = true;
            this.bar_Shift.Caption = "Current Shift  Here";
            this.bar_Shift.Description = "[Status] current running shift";
            this.bar_Shift.Id = 217;
            this.bar_Shift.ImageIndex = 118;
            this.bar_Shift.Name = "bar_Shift";
            this.bar_Shift.Tag = "0";
            this.bar_Shift.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_Shift_ItemClick);
            // 
            // bbiSubMenu_AssignToGroup
            // 
            this.bbiSubMenu_AssignToGroup.Caption = "Assign to Group";
            this.bbiSubMenu_AssignToGroup.Id = 223;
            this.bbiSubMenu_AssignToGroup.ImageIndex = 25;
            this.bbiSubMenu_AssignToGroup.Name = "bbiSubMenu_AssignToGroup";
            this.bbiSubMenu_AssignToGroup.Popup += new System.EventHandler(this.bbiSubMenu_AssignToGroup_Popup);
            // 
            // bbi_Dashboard_DesignSaveGroup
            // 
            this.bbi_Dashboard_DesignSaveGroup.Caption = "Save";
            this.bbi_Dashboard_DesignSaveGroup.Description = "[Dashboard] Save Machine Eyes real time weavers layout";
            this.bbi_Dashboard_DesignSaveGroup.Id = 225;
            this.bbi_Dashboard_DesignSaveGroup.ImageIndex = 32;
            this.bbi_Dashboard_DesignSaveGroup.Name = "bbi_Dashboard_DesignSaveGroup";
            this.bbi_Dashboard_DesignSaveGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Dashboard_DesignSaveGroup_ItemClick);
            // 
            // bbi_DashBoard_DesignMoveGroup
            // 
            this.bbi_DashBoard_DesignMoveGroup.Caption = "Move";
            this.bbi_DashBoard_DesignMoveGroup.Description = "[Dashboard] Move Machine eyes real time weavers groups layout";
            this.bbi_DashBoard_DesignMoveGroup.Id = 227;
            this.bbi_DashBoard_DesignMoveGroup.ImageIndex = 93;
            this.bbi_DashBoard_DesignMoveGroup.Name = "bbi_DashBoard_DesignMoveGroup";
            this.bbi_DashBoard_DesignMoveGroup.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_DashBoard_DesignMoveGroup_CheckedChanged);
            // 
            // bbi_ShedGraph_View
            // 
            this.bbi_ShedGraph_View.Caption = "Shed Graph";
            this.bbi_ShedGraph_View.Description = "[Dashboard] Display Machine Eyes real time shed graph";
            this.bbi_ShedGraph_View.Id = 228;
            this.bbi_ShedGraph_View.ImageIndex = 38;
            this.bbi_ShedGraph_View.Name = "bbi_ShedGraph_View";
            this.bbi_ShedGraph_View.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_ShedGraph_View_ItemClick);
            // 
            // bbi_AutomaticUpdate
            // 
            this.bbi_AutomaticUpdate.Caption = "Automatic Update";
            this.bbi_AutomaticUpdate.Description = "[Update] Automatic update and builds";
            this.bbi_AutomaticUpdate.Id = 229;
            this.bbi_AutomaticUpdate.ImageIndex = 145;
            this.bbi_AutomaticUpdate.Name = "bbi_AutomaticUpdate";
            this.bbi_AutomaticUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_AutomaticUpdate_ItemClick);
            // 
            // bbiSubMenu_AssignPosition
            // 
            this.bbiSubMenu_AssignPosition.Caption = "Drawing";
            this.bbiSubMenu_AssignPosition.Id = 237;
            this.bbiSubMenu_AssignPosition.ImageIndex = 83;
            this.bbiSubMenu_AssignPosition.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Drawingleft),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_DrawingTop),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Resize),
            new DevExpress.XtraBars.LinkPersistInfo(this.MergedShedLayoutSaveMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Category)});
            this.bbiSubMenu_AssignPosition.Name = "bbiSubMenu_AssignPosition";
            // 
            // barSubItem_Drawingleft
            // 
            this.barSubItem_Drawingleft.Caption = "Left";
            this.barSubItem_Drawingleft.Id = 245;
            this.barSubItem_Drawingleft.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SetLoomLeft),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SetLoomLeftRef)});
            this.barSubItem_Drawingleft.Name = "barSubItem_Drawingleft";
            // 
            // bbi_SetLoomLeft
            // 
            this.bbi_SetLoomLeft.Caption = "Set Left As Loom #";
            this.bbi_SetLoomLeft.Description = "[Dashboard] set looms left layout position";
            this.bbi_SetLoomLeft.Id = 246;
            this.bbi_SetLoomLeft.Name = "bbi_SetLoomLeft";
            this.bbi_SetLoomLeft.Tag = "";
            this.bbi_SetLoomLeft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SetLoomLeft_ItemClick);
            // 
            // bbi_SetLoomLeftRef
            // 
            this.bbi_SetLoomLeftRef.Caption = "Set As Reference";
            this.bbi_SetLoomLeftRef.Description = "[Dashboard] Set loom layout as reference position";
            this.bbi_SetLoomLeftRef.Id = 247;
            this.bbi_SetLoomLeftRef.Name = "bbi_SetLoomLeftRef";
            this.bbi_SetLoomLeftRef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SetLoomLeftRef_ItemClick);
            // 
            // barSubItem_DrawingTop
            // 
            this.barSubItem_DrawingTop.Caption = "Top";
            this.barSubItem_DrawingTop.Id = 248;
            this.barSubItem_DrawingTop.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SetLoomTop),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SetLoomTopRef)});
            this.barSubItem_DrawingTop.Name = "barSubItem_DrawingTop";
            // 
            // bbi_SetLoomTop
            // 
            this.bbi_SetLoomTop.Caption = "Set Top As Loom #";
            this.bbi_SetLoomTop.Description = "[Dashboard] Set loom top layout position";
            this.bbi_SetLoomTop.Id = 249;
            this.bbi_SetLoomTop.Name = "bbi_SetLoomTop";
            this.bbi_SetLoomTop.Tag = "";
            this.bbi_SetLoomTop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SetLoomTop_ItemClick);
            // 
            // bbi_SetLoomTopRef
            // 
            this.bbi_SetLoomTopRef.Caption = "Set As Reference";
            this.bbi_SetLoomTopRef.Description = "[Dashboard] Set loom layout as reference position";
            this.bbi_SetLoomTopRef.Id = 250;
            this.bbi_SetLoomTopRef.Name = "bbi_SetLoomTopRef";
            this.bbi_SetLoomTopRef.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SetLoomTopRef_ItemClick);
            // 
            // barSubItem_Resize
            // 
            this.barSubItem_Resize.Caption = "Layout";
            this.barSubItem_Resize.Id = 655;
            this.barSubItem_Resize.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SetLoomResizeControl),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SaveLoomResizeControl),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbi_SaveLoomLayoutintoProfile)});
            this.barSubItem_Resize.Name = "barSubItem_Resize";
            // 
            // bbi_SetLoomResizeControl
            // 
            this.bbi_SetLoomResizeControl.Caption = "Resize Loom Controls";
            this.bbi_SetLoomResizeControl.Description = "[Dashboard] set looms resizing of controls";
            this.bbi_SetLoomResizeControl.Id = 656;
            this.bbi_SetLoomResizeControl.Name = "bbi_SetLoomResizeControl";
            this.bbi_SetLoomResizeControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SetLoomResizeControl_ItemClick);
            // 
            // bbi_SaveLoomResizeControl
            // 
            this.bbi_SaveLoomResizeControl.Caption = "Save Loom Size and Fonts into profile";
            this.bbi_SaveLoomResizeControl.Description = "[Dashboard] Save Loom Size and Fonts into profile";
            this.bbi_SaveLoomResizeControl.Id = 657;
            this.bbi_SaveLoomResizeControl.Name = "bbi_SaveLoomResizeControl";
            this.bbi_SaveLoomResizeControl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SaveLoomResizeControl_ItemClick);
            // 
            // bbi_SaveLoomLayoutintoProfile
            // 
            this.bbi_SaveLoomLayoutintoProfile.Caption = "Save Looms Layout into profile";
            this.bbi_SaveLoomLayoutintoProfile.Description = "[Dashboard] Save Looms Layout into profile";
            this.bbi_SaveLoomLayoutintoProfile.Id = 659;
            this.bbi_SaveLoomLayoutintoProfile.Name = "bbi_SaveLoomLayoutintoProfile";
            this.bbi_SaveLoomLayoutintoProfile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SaveLoomLayoutintoProfile_ItemClick);
            // 
            // MergedShedLayoutSaveMenu
            // 
            this.MergedShedLayoutSaveMenu.Caption = "Merged Layout";
            this.MergedShedLayoutSaveMenu.Id = 682;
            this.MergedShedLayoutSaveMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MergedShedLayoutSaveMenuButton)});
            this.MergedShedLayoutSaveMenu.Name = "MergedShedLayoutSaveMenu";
            // 
            // MergedShedLayoutSaveMenuButton
            // 
            this.MergedShedLayoutSaveMenuButton.Caption = "Save Looms Layout for Merged Sheds";
            this.MergedShedLayoutSaveMenuButton.Description = "[Dashboard] Save Looms Layout for Merged Sheds";
            this.MergedShedLayoutSaveMenuButton.Id = 683;
            this.MergedShedLayoutSaveMenuButton.Name = "MergedShedLayoutSaveMenuButton";
            this.MergedShedLayoutSaveMenuButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MergedShedLayoutSaveMenuButton_ItemClick);
            // 
            // barSubItem_Category
            // 
            this.barSubItem_Category.Caption = "Category Layout";
            this.barSubItem_Category.Id = 712;
            this.barSubItem_Category.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Category_Move),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Category_AddLooms),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Category_RemoveLooms),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Category_SaveCategoryLayout)});
            this.barSubItem_Category.Name = "barSubItem_Category";
            // 
            // barButtonItem_Category_Move
            // 
            this.barButtonItem_Category_Move.Caption = "Move Category";
            this.barButtonItem_Category_Move.Description = "[Dashboard] Category: Move Category";
            this.barButtonItem_Category_Move.Id = 713;
            this.barButtonItem_Category_Move.Name = "barButtonItem_Category_Move";
            this.barButtonItem_Category_Move.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MoveRunningPercent_ItemClick);
            // 
            // barButtonItem_Category_AddLooms
            // 
            this.barButtonItem_Category_AddLooms.Caption = "Add Looms into Category";
            this.barButtonItem_Category_AddLooms.Description = "[Dashboard] Category: Add Looms into Category";
            this.barButtonItem_Category_AddLooms.Id = 721;
            this.barButtonItem_Category_AddLooms.Name = "barButtonItem_Category_AddLooms";
            this.barButtonItem_Category_AddLooms.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Category_AddLooms_ItemClick);
            // 
            // barButtonItem_Category_RemoveLooms
            // 
            this.barButtonItem_Category_RemoveLooms.Caption = "Remove Looms from Category";
            this.barButtonItem_Category_RemoveLooms.Description = "[Dashboard] Category: Remove Looms from Category";
            this.barButtonItem_Category_RemoveLooms.Id = 722;
            this.barButtonItem_Category_RemoveLooms.Name = "barButtonItem_Category_RemoveLooms";
            this.barButtonItem_Category_RemoveLooms.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Category_RemoveLooms_ItemClick);
            // 
            // barButtonItem_Category_SaveCategoryLayout
            // 
            this.barButtonItem_Category_SaveCategoryLayout.Caption = "Save Category Layout";
            this.barButtonItem_Category_SaveCategoryLayout.Description = "[Dashboard] Category: Save Category Layout";
            this.barButtonItem_Category_SaveCategoryLayout.Id = 723;
            this.barButtonItem_Category_SaveCategoryLayout.Name = "barButtonItem_Category_SaveCategoryLayout";
            this.barButtonItem_Category_SaveCategoryLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Category_SaveCategoryLayout_ItemClick);
            // 
            // barAssign_TopSpin
            // 
            this.barAssign_TopSpin.Caption = "Set Top with Ref to Loom #";
            this.barAssign_TopSpin.Edit = this.repositoryItemSpinEdit_LoomForTop;
            this.barAssign_TopSpin.Id = 241;
            this.barAssign_TopSpin.Name = "barAssign_TopSpin";
            // 
            // repositoryItemSpinEdit_LoomForTop
            // 
            this.repositoryItemSpinEdit_LoomForTop.AutoHeight = false;
            this.repositoryItemSpinEdit_LoomForTop.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit_LoomForTop.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.repositoryItemSpinEdit_LoomForTop.Name = "repositoryItemSpinEdit_LoomForTop";
            this.repositoryItemSpinEdit_LoomForTop.UseParentBackground = true;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Set Left As Loom #";
            this.barStaticItem1.Id = 242;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "Set Top As Loom #";
            this.barStaticItem2.Id = 243;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "-";
            this.barStaticItem3.Id = 244;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bbi_Shed
            // 
            this.bbi_Shed.Caption = "Sheds";
            this.bbi_Shed.Id = 251;
            this.bbi_Shed.ImageIndex = 121;
            this.bbi_Shed.Name = "bbi_Shed";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "barSubItem2";
            this.barSubItem2.Id = 252;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // rpi_DailyShiftSummary
            // 
            this.rpi_DailyShiftSummary.Appearance.Options.UseTextOptions = true;
            this.rpi_DailyShiftSummary.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.rpi_DailyShiftSummary.Caption = "Reports";
            this.rpi_DailyShiftSummary.Id = 253;
            this.rpi_DailyShiftSummary.LargeImageIndex = 228;
            this.rpi_DailyShiftSummary.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailySummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_ConstructionWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_LoomWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailyUnitsWeaverWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_WeaverWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailyEfficiencyQualityWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailyEfficiencyWithProductionLoss),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailyProductionLoss),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_WeeklyEfficiencyLoomWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_MonthlyEfficiencyTabular),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_MonthlyUnitsTabular),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_MonthlyProductionEfficiency),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_CommingKnottings),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_ArticleEfficiencyReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_MonthlyProductionLoss),
            new DevExpress.XtraBars.LinkPersistInfo(this.Monthly_Efficiency_SelectedLoom),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_QualityWiseProduction),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_ShedLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_MonthlyUnitsWeaverWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_MonthlyUnitsQualityWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_BeamContraction),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_QualityWiseBreakageReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.Efficiency_QualityWiseBreakagesGrouped),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_ShedEfficiencyLog),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_ShedEfficiencyGraph),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_DailyEfficiencyWithDailyWage),
            new DevExpress.XtraBars.LinkPersistInfo(this.rpi_TopWorseArticlesLooms)});
            this.rpi_DailyShiftSummary.Name = "rpi_DailyShiftSummary";
            // 
            // rpi_DailySummary
            // 
            this.rpi_DailySummary.Caption = "Daily Summary";
            this.rpi_DailySummary.Id = 718;
            this.rpi_DailySummary.Name = "rpi_DailySummary";
            // 
            // rpi_ConstructionWise
            // 
            this.rpi_ConstructionWise.Caption = "Daily Unit Report";
            this.rpi_ConstructionWise.Id = 425;
            this.rpi_ConstructionWise.Name = "rpi_ConstructionWise";
            // 
            // rpi_LoomWise
            // 
            this.rpi_LoomWise.Caption = "Daily Loom Wise Efficiency";
            this.rpi_LoomWise.Id = 525;
            this.rpi_LoomWise.Name = "rpi_LoomWise";
            // 
            // rpi_DailyUnitsWeaverWise
            // 
            this.rpi_DailyUnitsWeaverWise.Caption = "Daily Unit (Weaver Wise)";
            this.rpi_DailyUnitsWeaverWise.Id = 510;
            this.rpi_DailyUnitsWeaverWise.Name = "rpi_DailyUnitsWeaverWise";
            // 
            // rpi_WeaverWise
            // 
            this.rpi_WeaverWise.Caption = "Daily Efficiency Weaver Wise";
            this.rpi_WeaverWise.Id = 426;
            this.rpi_WeaverWise.Name = "rpi_WeaverWise";
            // 
            // rpi_DailyEfficiencyQualityWise
            // 
            this.rpi_DailyEfficiencyQualityWise.Caption = "Daily Efficiency [Quality Wise]";
            this.rpi_DailyEfficiencyQualityWise.Id = 459;
            this.rpi_DailyEfficiencyQualityWise.Name = "rpi_DailyEfficiencyQualityWise";
            // 
            // rpi_DailyEfficiencyWithProductionLoss
            // 
            this.rpi_DailyEfficiencyWithProductionLoss.Caption = "Daily Efficiency && Prod. Loss";
            this.rpi_DailyEfficiencyWithProductionLoss.Id = 457;
            this.rpi_DailyEfficiencyWithProductionLoss.Name = "rpi_DailyEfficiencyWithProductionLoss";
            // 
            // rpi_DailyProductionLoss
            // 
            this.rpi_DailyProductionLoss.Caption = "Daily Production Loss";
            this.rpi_DailyProductionLoss.Id = 455;
            this.rpi_DailyProductionLoss.Name = "rpi_DailyProductionLoss";
            // 
            // rpi_WeeklyEfficiencyLoomWise
            // 
            this.rpi_WeeklyEfficiencyLoomWise.Caption = "Weekly Efficiency [Tabular]";
            this.rpi_WeeklyEfficiencyLoomWise.Id = 453;
            this.rpi_WeeklyEfficiencyLoomWise.Name = "rpi_WeeklyEfficiencyLoomWise";
            // 
            // rpi_MonthlyEfficiencyTabular
            // 
            this.rpi_MonthlyEfficiencyTabular.Caption = "Monthly Efficiency [Tabular]";
            this.rpi_MonthlyEfficiencyTabular.Id = 454;
            this.rpi_MonthlyEfficiencyTabular.Name = "rpi_MonthlyEfficiencyTabular";
            // 
            // rpi_MonthlyUnitsTabular
            // 
            this.rpi_MonthlyUnitsTabular.Caption = "Monthly Units [Tablular]";
            this.rpi_MonthlyUnitsTabular.Id = 709;
            this.rpi_MonthlyUnitsTabular.Name = "rpi_MonthlyUnitsTabular";
            // 
            // rpi_MonthlyProductionEfficiency
            // 
            this.rpi_MonthlyProductionEfficiency.Caption = "Monthly Production Efficiency";
            this.rpi_MonthlyProductionEfficiency.Id = 711;
            this.rpi_MonthlyProductionEfficiency.Name = "rpi_MonthlyProductionEfficiency";
            // 
            // rpi_CommingKnottings
            // 
            this.rpi_CommingKnottings.Caption = "Comming Knottings";
            this.rpi_CommingKnottings.Id = 462;
            this.rpi_CommingKnottings.Name = "rpi_CommingKnottings";
            // 
            // Efficiency_ArticleEfficiencyReport
            // 
            this.Efficiency_ArticleEfficiencyReport.Caption = "Article Efficiency Report";
            this.Efficiency_ArticleEfficiencyReport.Description = "[Dashboard] Report: Article Efficiency Report";
            this.Efficiency_ArticleEfficiencyReport.Id = 478;
            this.Efficiency_ArticleEfficiencyReport.Name = "Efficiency_ArticleEfficiencyReport";
            this.Efficiency_ArticleEfficiencyReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_ArticleEfficiencyReport_ItemClick);
            // 
            // Efficiency_MonthlyProductionLoss
            // 
            this.Efficiency_MonthlyProductionLoss.Caption = "Monthly Production Loss";
            this.Efficiency_MonthlyProductionLoss.Description = "[Dashboard] Report: Monthly Production Loss";
            this.Efficiency_MonthlyProductionLoss.Id = 479;
            this.Efficiency_MonthlyProductionLoss.Name = "Efficiency_MonthlyProductionLoss";
            this.Efficiency_MonthlyProductionLoss.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_MonthlyProductionLoss_ItemClick);
            // 
            // Monthly_Efficiency_SelectedLoom
            // 
            this.Monthly_Efficiency_SelectedLoom.Caption = "Monthly Efficiency (Selected Loom)";
            this.Monthly_Efficiency_SelectedLoom.Description = "[Dashboard] Report: Monthly Efficiency Report (Selected Loom)";
            this.Monthly_Efficiency_SelectedLoom.Id = 628;
            this.Monthly_Efficiency_SelectedLoom.Name = "Monthly_Efficiency_SelectedLoom";
            this.Monthly_Efficiency_SelectedLoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Monthly_Efficiency_SelectedLoom_ItemClick);
            // 
            // Efficiency_QualityWiseProduction
            // 
            this.Efficiency_QualityWiseProduction.Caption = "Quality Wise Production";
            this.Efficiency_QualityWiseProduction.Description = "[Dashboard] Report: Quality Wise Production";
            this.Efficiency_QualityWiseProduction.Id = 480;
            this.Efficiency_QualityWiseProduction.Name = "Efficiency_QualityWiseProduction";
            this.Efficiency_QualityWiseProduction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_QualityWiseProduction_ItemClick);
            // 
            // Efficiency_ShedLog
            // 
            this.Efficiency_ShedLog.Caption = "Shed Log";
            this.Efficiency_ShedLog.Description = "[Dashboard] Report: Shed Log";
            this.Efficiency_ShedLog.Id = 488;
            this.Efficiency_ShedLog.Name = "Efficiency_ShedLog";
            this.Efficiency_ShedLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_ShedLog_ItemClick);
            // 
            // rpi_MonthlyUnitsWeaverWise
            // 
            this.rpi_MonthlyUnitsWeaverWise.Caption = "Monthly Units (Weaver Wise)";
            this.rpi_MonthlyUnitsWeaverWise.Id = 511;
            this.rpi_MonthlyUnitsWeaverWise.Name = "rpi_MonthlyUnitsWeaverWise";
            // 
            // rpi_MonthlyUnitsQualityWise
            // 
            this.rpi_MonthlyUnitsQualityWise.Caption = "Monthly Units (Quality Wise)";
            this.rpi_MonthlyUnitsQualityWise.Id = 512;
            this.rpi_MonthlyUnitsQualityWise.Name = "rpi_MonthlyUnitsQualityWise";
            // 
            // Efficiency_BeamContraction
            // 
            this.Efficiency_BeamContraction.Caption = "Beam Contraction Report";
            this.Efficiency_BeamContraction.Description = "[Dashboard] Report: Beam Contraction Summary";
            this.Efficiency_BeamContraction.Id = 633;
            this.Efficiency_BeamContraction.Name = "Efficiency_BeamContraction";
            this.Efficiency_BeamContraction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_BeamContraction_ItemClick);
            // 
            // Efficiency_QualityWiseBreakageReport
            // 
            this.Efficiency_QualityWiseBreakageReport.Caption = "Quality Wise Breakage Report";
            this.Efficiency_QualityWiseBreakageReport.Description = "[Dashboard] Report: Quality Wise Breakages Report";
            this.Efficiency_QualityWiseBreakageReport.Id = 634;
            this.Efficiency_QualityWiseBreakageReport.Name = "Efficiency_QualityWiseBreakageReport";
            this.Efficiency_QualityWiseBreakageReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_QualityWiseBreakageReport_ItemClick);
            // 
            // Efficiency_QualityWiseBreakagesGrouped
            // 
            this.Efficiency_QualityWiseBreakagesGrouped.Caption = "Quality Wise Breakages (Grouped)";
            this.Efficiency_QualityWiseBreakagesGrouped.Description = "[Dashboard] Report: Quality Wise Breakages (Grouped) Report";
            this.Efficiency_QualityWiseBreakagesGrouped.Id = 635;
            this.Efficiency_QualityWiseBreakagesGrouped.Name = "Efficiency_QualityWiseBreakagesGrouped";
            this.Efficiency_QualityWiseBreakagesGrouped.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Efficiency_QualityWiseBreakagesGrouped_ItemClick);
            // 
            // rpi_ShedEfficiencyLog
            // 
            this.rpi_ShedEfficiencyLog.Caption = "Shed Efficiency Log";
            this.rpi_ShedEfficiencyLog.Id = 652;
            this.rpi_ShedEfficiencyLog.Name = "rpi_ShedEfficiencyLog";
            // 
            // rpi_ShedEfficiencyGraph
            // 
            this.rpi_ShedEfficiencyGraph.Caption = "Shed Efficiency Graph";
            this.rpi_ShedEfficiencyGraph.Id = 653;
            this.rpi_ShedEfficiencyGraph.Name = "rpi_ShedEfficiencyGraph";
            // 
            // rpi_DailyEfficiencyWithDailyWage
            // 
            this.rpi_DailyEfficiencyWithDailyWage.Caption = "Daily Efficiency and Weavers Wages";
            this.rpi_DailyEfficiencyWithDailyWage.Id = 675;
            this.rpi_DailyEfficiencyWithDailyWage.Name = "rpi_DailyEfficiencyWithDailyWage";
            // 
            // rpi_TopWorseArticlesLooms
            // 
            this.rpi_TopWorseArticlesLooms.Caption = "Top Worse Articles / Looms";
            this.rpi_TopWorseArticlesLooms.Id = 724;
            this.rpi_TopWorseArticlesLooms.Name = "rpi_TopWorseArticlesLooms";
            // 
            // mrip_Warping
            // 
            this.mrip_Warping.Appearance.Options.UseTextOptions = true;
            this.mrip_Warping.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.mrip_Warping.Caption = "Warping Reports";
            this.mrip_Warping.Id = 263;
            this.mrip_Warping.LargeImageIndex = 124;
            this.mrip_Warping.Name = "mrip_Warping";
            // 
            // mrip_Sizing
            // 
            this.mrip_Sizing.Appearance.Options.UseTextOptions = true;
            this.mrip_Sizing.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.mrip_Sizing.Caption = "Sizing Reports";
            this.mrip_Sizing.Id = 264;
            this.mrip_Sizing.LargeImageIndex = 90;
            this.mrip_Sizing.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Production_SizingSummaryReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.Production_SizingMonthlyProduction),
            new DevExpress.XtraBars.LinkPersistInfo(this.Production_SizingMonthlyProductionPartyWise),
            new DevExpress.XtraBars.LinkPersistInfo(this.Production_SizingMonthlyProductionCountWise)});
            this.mrip_Sizing.Name = "mrip_Sizing";
            // 
            // Production_SizingSummaryReport
            // 
            this.Production_SizingSummaryReport.Caption = "Sizing Summary";
            this.Production_SizingSummaryReport.Description = "[Production] {Reports} Sizing Summary";
            this.Production_SizingSummaryReport.Id = 521;
            this.Production_SizingSummaryReport.Name = "Production_SizingSummaryReport";
            this.Production_SizingSummaryReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Production_SizingSummaryReport_ItemClick);
            // 
            // Production_SizingMonthlyProduction
            // 
            this.Production_SizingMonthlyProduction.Caption = "Monthly Sizing Production";
            this.Production_SizingMonthlyProduction.Description = "[Production] {Reports} Sizing Monthly Production Summary";
            this.Production_SizingMonthlyProduction.Id = 671;
            this.Production_SizingMonthlyProduction.Name = "Production_SizingMonthlyProduction";
            this.Production_SizingMonthlyProduction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Production_SizingMonthlyProduction_ItemClick);
            // 
            // Production_SizingMonthlyProductionPartyWise
            // 
            this.Production_SizingMonthlyProductionPartyWise.Caption = "Party Wise Production Report";
            this.Production_SizingMonthlyProductionPartyWise.Description = "[Production] {Reports} Sizing Monthly Production Party Wise";
            this.Production_SizingMonthlyProductionPartyWise.Id = 672;
            this.Production_SizingMonthlyProductionPartyWise.Name = "Production_SizingMonthlyProductionPartyWise";
            this.Production_SizingMonthlyProductionPartyWise.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Production_SizingMonthlyProductionPartyWise_ItemClick);
            // 
            // Production_SizingMonthlyProductionCountWise
            // 
            this.Production_SizingMonthlyProductionCountWise.Caption = "Count Wise Production Report";
            this.Production_SizingMonthlyProductionCountWise.Description = "[Production] {Reports} Sizing Monthly Production Count Wise";
            this.Production_SizingMonthlyProductionCountWise.Id = 673;
            this.Production_SizingMonthlyProductionCountWise.Name = "Production_SizingMonthlyProductionCountWise";
            this.Production_SizingMonthlyProductionCountWise.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Production_SizingMonthlyProductionCountWise_ItemClick);
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "barStaticItem4";
            this.barStaticItem4.Id = 268;
            this.barStaticItem4.Name = "barStaticItem4";
            this.barStaticItem4.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // mdata_Yarn
            // 
            this.mdata_Yarn.Caption = "Parameters";
            this.mdata_Yarn.Id = 270;
            this.mdata_Yarn.LargeImageIndex = 294;
            this.mdata_Yarn.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_Params)});
            this.mdata_Yarn.Name = "mdata_Yarn";
            // 
            // mYarnData_Params
            // 
            this.mYarnData_Params.Caption = "Parameters";
            this.mYarnData_Params.Id = 275;
            this.mYarnData_Params.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_Counts),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_Brands),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_Blends),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_Twsits),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemYarnColor),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_PaperConeColors),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_ConeWeight),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_ConesPerBag),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_LbsPerBag),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_CottonOrigin),
            new DevExpress.XtraBars.LinkPersistInfo(this.mYarnData_YarnDesc)});
            this.mYarnData_Params.Name = "mYarnData_Params";
            // 
            // mYarnData_Counts
            // 
            this.mYarnData_Counts.Caption = "Counts";
            this.mYarnData_Counts.Description = "[Yarn Management] Manage yarn counts list";
            this.mYarnData_Counts.Id = 282;
            this.mYarnData_Counts.Name = "mYarnData_Counts";
            this.mYarnData_Counts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_Counts_ItemClick);
            // 
            // mYarnData_Brands
            // 
            this.mYarnData_Brands.Caption = "Brands";
            this.mYarnData_Brands.Description = "[Yarn Management] Manage yarn brands list";
            this.mYarnData_Brands.Id = 283;
            this.mYarnData_Brands.Name = "mYarnData_Brands";
            this.mYarnData_Brands.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_Brands_ItemClick);
            // 
            // mYarnData_Blends
            // 
            this.mYarnData_Blends.Caption = "Blends";
            this.mYarnData_Blends.Description = "[Yarn Management] Manage yarn blends list";
            this.mYarnData_Blends.Id = 284;
            this.mYarnData_Blends.Name = "mYarnData_Blends";
            this.mYarnData_Blends.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_Blends_ItemClick);
            // 
            // mYarnData_Twsits
            // 
            this.mYarnData_Twsits.Caption = "Ply";
            this.mYarnData_Twsits.Description = "[Yarn Management] Manage yarn ply 1 single , 2 double , 3 tripple.";
            this.mYarnData_Twsits.Id = 285;
            this.mYarnData_Twsits.Name = "mYarnData_Twsits";
            this.mYarnData_Twsits.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_Twsits_ItemClick);
            // 
            // barButtonItemYarnColor
            // 
            this.barButtonItemYarnColor.Caption = "Color";
            this.barButtonItemYarnColor.Description = "[Yarn Management] Manage yarn colors , (warp and weft)";
            this.barButtonItemYarnColor.Id = 654;
            this.barButtonItemYarnColor.Name = "barButtonItemYarnColor";
            this.barButtonItemYarnColor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemYarnColor_ItemClick);
            // 
            // mYarnData_PaperConeColors
            // 
            this.mYarnData_PaperConeColors.Caption = "Paper Cone Colors";
            this.mYarnData_PaperConeColors.Description = "[Yarn Management] Manage yarn paper cone colors list";
            this.mYarnData_PaperConeColors.Id = 286;
            this.mYarnData_PaperConeColors.Name = "mYarnData_PaperConeColors";
            this.mYarnData_PaperConeColors.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_PaperConeColors_ItemClick);
            // 
            // mYarnData_ConeWeight
            // 
            this.mYarnData_ConeWeight.Caption = "Cone Weight";
            this.mYarnData_ConeWeight.Description = "[Yarn Management] Manage yarn common empty cones weights list";
            this.mYarnData_ConeWeight.Id = 292;
            this.mYarnData_ConeWeight.Name = "mYarnData_ConeWeight";
            this.mYarnData_ConeWeight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_ConeWeight_ItemClick);
            // 
            // mYarnData_ConesPerBag
            // 
            this.mYarnData_ConesPerBag.Caption = "No of Cones Per Bag";
            this.mYarnData_ConesPerBag.Description = "[Yarn Management] Manage number of cones in one bag related to yarn";
            this.mYarnData_ConesPerBag.Id = 300;
            this.mYarnData_ConesPerBag.Name = "mYarnData_ConesPerBag";
            this.mYarnData_ConesPerBag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_ConesPerBag_ItemClick);
            // 
            // mYarnData_LbsPerBag
            // 
            this.mYarnData_LbsPerBag.Caption = "Weight (Lbs) Per Bag";
            this.mYarnData_LbsPerBag.Description = "[Yarn Management] Manage yarn weight in lbs per bag commonly available";
            this.mYarnData_LbsPerBag.Id = 301;
            this.mYarnData_LbsPerBag.Name = "mYarnData_LbsPerBag";
            this.mYarnData_LbsPerBag.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_LbsPerBag_ItemClick);
            // 
            // mYarnData_CottonOrigin
            // 
            this.mYarnData_CottonOrigin.Caption = "Cotton Origin";
            this.mYarnData_CottonOrigin.Description = "[Yarn Management] Manage yarn cotton origin [country] list";
            this.mYarnData_CottonOrigin.Id = 304;
            this.mYarnData_CottonOrigin.Name = "mYarnData_CottonOrigin";
            this.mYarnData_CottonOrigin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_CottonOrigin_ItemClick);
            // 
            // mYarnData_YarnDesc
            // 
            this.mYarnData_YarnDesc.Caption = "Description";
            this.mYarnData_YarnDesc.Description = "[Yarn Management] Manage yarn description list";
            this.mYarnData_YarnDesc.Id = 305;
            this.mYarnData_YarnDesc.Name = "mYarnData_YarnDesc";
            this.mYarnData_YarnDesc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mYarnData_YarnDesc_ItemClick);
            // 
            // bbiDebugFunction
            // 
            this.bbiDebugFunction.Id = 287;
            this.bbiDebugFunction.Name = "bbiDebugFunction";
            // 
            // mYarnData_Contracts
            // 
            this.mYarnData_Contracts.Caption = "Contracts";
            this.mYarnData_Contracts.Id = 288;
            this.mYarnData_Contracts.Name = "mYarnData_Contracts";
            // 
            // Accounts_MappedAccounts
            // 
            this.Accounts_MappedAccounts.Caption = "Mapped Accounts";
            this.Accounts_MappedAccounts.Description = "[Accounts and Finance] Settle mapped accounts for cross cascadings";
            this.Accounts_MappedAccounts.Id = 299;
            this.Accounts_MappedAccounts.ImageIndex = 72;
            this.Accounts_MappedAccounts.Name = "Accounts_MappedAccounts";
            this.Accounts_MappedAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mDataMisc_Accounts_ItemClick);
            // 
            // bbi_Tools_EffFont
            // 
            this.bbi_Tools_EffFont.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            this.bbi_Tools_EffFont.Caption = "Efficiency Font";
            this.bbi_Tools_EffFont.Description = "[Dashboard] set real time efficiency layout fonts";
            this.bbi_Tools_EffFont.Id = 309;
            this.bbi_Tools_EffFont.ImageIndex = 17;
            this.bbi_Tools_EffFont.Name = "bbi_Tools_EffFont";
            this.bbi_Tools_EffFont.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Tools_EffFont_ItemClick);
            // 
            // bbi_Data_AssignLoom_CurrentLoomStats
            // 
            this.bbi_Data_AssignLoom_CurrentLoomStats.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.bbi_Data_AssignLoom_CurrentLoomStats.Appearance.Options.UseFont = true;
            this.bbi_Data_AssignLoom_CurrentLoomStats.Caption = "Current Statistics...";
            this.bbi_Data_AssignLoom_CurrentLoomStats.Description = "[Dashboard] Display current statistics of machine";
            this.bbi_Data_AssignLoom_CurrentLoomStats.Id = 310;
            this.bbi_Data_AssignLoom_CurrentLoomStats.ImageIndex = 40;
            this.bbi_Data_AssignLoom_CurrentLoomStats.Name = "bbi_Data_AssignLoom_CurrentLoomStats";
            this.bbi_Data_AssignLoom_CurrentLoomStats.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_AssignLoom_CurrentLoomStats_ItemClick);
            // 
            // Company
            // 
            this.Company.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Company.Appearance.Options.UseFont = true;
            this.Company.Caption = "Company Name Here";
            this.Company.Description = "[Status] company name / factory name";
            this.Company.Id = 311;
            this.Company.ImageIndex = 122;
            this.Company.Name = "Company";
            this.Company.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.Company.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Company_ItemClick);
            // 
            // barContracts
            // 
            this.barContracts.Id = 313;
            this.barContracts.LargeImageIndex = 7;
            this.barContracts.Name = "barContracts";
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "Fabric [Local]";
            this.barSubItem5.Id = 314;
            this.barSubItem5.ImageIndex = 19;
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Id = 387;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Id = 388;
            this.barSubItem7.Name = "barSubItem7";
            // 
            // PGB_ArticleChangeSheet
            // 
            this.PGB_ArticleChangeSheet.Caption = "Article Change Sheet";
            this.PGB_ArticleChangeSheet.Description = "[Planning] Add , Edit article change sheet (ACS)";
            this.PGB_ArticleChangeSheet.Id = 327;
            this.PGB_ArticleChangeSheet.LargeImageIndex = 21;
            this.PGB_ArticleChangeSheet.Name = "PGB_ArticleChangeSheet";
            this.PGB_ArticleChangeSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PGB_ArticleChangeSheet_ItemClick);
            // 
            // YarnContract
            // 
            this.YarnContract.Caption = "Yarn Contract";
            this.YarnContract.Description = "[Yarn Management] Add new yarn contract";
            this.YarnContract.Id = 328;
            this.YarnContract.LargeImageIndex = 56;
            this.YarnContract.Name = "YarnContract";
            this.YarnContract.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnContract_ItemClick);
            // 
            // YarnReceiveNote
            // 
            this.YarnReceiveNote.Caption = "Receive Note";
            this.YarnReceiveNote.Description = "[Yarn Management] Yarn Receive Note";
            this.YarnReceiveNote.Id = 329;
            this.YarnReceiveNote.LargeImageIndex = 89;
            this.YarnReceiveNote.Name = "YarnReceiveNote";
            this.YarnReceiveNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnReceiveNote_ItemClick);
            // 
            // YarnIssueNote
            // 
            this.YarnIssueNote.Caption = "Issue Note";
            this.YarnIssueNote.Description = "[Yarn Management] Yarn Issue Note";
            this.YarnIssueNote.Id = 330;
            this.YarnIssueNote.LargeImageIndex = 88;
            this.YarnIssueNote.Name = "YarnIssueNote";
            this.YarnIssueNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnIssueNote_ItemClick);
            // 
            // YarnDemandNote
            // 
            this.YarnDemandNote.Caption = "Yarn Demand Slip";
            this.YarnDemandNote.Description = "[Yarn Management] Add , Edit , Delete yarn demand note";
            this.YarnDemandNote.Id = 333;
            this.YarnDemandNote.LargeImageIndex = 296;
            this.YarnDemandNote.Name = "YarnDemandNote";
            // 
            // YarnRequisitionNote
            // 
            this.YarnRequisitionNote.Caption = "Yarn Requisition Slip";
            this.YarnRequisitionNote.Description = "[Yarn Management] Add , Edit , Delete yarn requisition slip";
            this.YarnRequisitionNote.Id = 334;
            this.YarnRequisitionNote.LargeImageIndex = 299;
            this.YarnRequisitionNote.Name = "YarnRequisitionNote";
            // 
            // DesignChangeSheet
            // 
            this.DesignChangeSheet.Caption = "Design Change Sheet";
            this.DesignChangeSheet.Description = "[Planning] Add , Edit article design sheet (ADS)";
            this.DesignChangeSheet.Id = 335;
            this.DesignChangeSheet.LargeImageIndex = 4;
            this.DesignChangeSheet.Name = "DesignChangeSheet";
            // 
            // Accounts_ChartofAccountsTree
            // 
            this.Accounts_ChartofAccountsTree.Caption = "Chart of Accounts";
            this.Accounts_ChartofAccountsTree.Description = "[Accounts and Finance] Chart of Accounts";
            this.Accounts_ChartofAccountsTree.Id = 337;
            this.Accounts_ChartofAccountsTree.LargeImageIndex = 301;
            this.Accounts_ChartofAccountsTree.Name = "Accounts_ChartofAccountsTree";
            this.Accounts_ChartofAccountsTree.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ChartofAccountsTree_ItemClick);
            // 
            // bbi_Data_AssignLoom_Article
            // 
            this.bbi_Data_AssignLoom_Article.Caption = "Assign Article";
            this.bbi_Data_AssignLoom_Article.Description = "[Planning] assign / designate article on machine";
            this.bbi_Data_AssignLoom_Article.Id = 339;
            this.bbi_Data_AssignLoom_Article.ImageIndex = 135;
            this.bbi_Data_AssignLoom_Article.Name = "bbi_Data_AssignLoom_Article";
            this.bbi_Data_AssignLoom_Article.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_AssignLoom_Article_ItemClick);
            // 
            // bbi_Summary
            // 
            this.bbi_Summary.Caption = "Summary";
            this.bbi_Summary.Id = 341;
            this.bbi_Summary.ImageIndex = 136;
            this.bbi_Summary.Name = "bbi_Summary";
            // 
            // bbi_WeaverMain
            // 
            this.bbi_WeaverMain.Caption = "Weavers";
            this.bbi_WeaverMain.Id = 342;
            this.bbi_WeaverMain.LargeImageIndex = 81;
            this.bbi_WeaverMain.Name = "bbi_WeaverMain";
            // 
            // bbi_WeaversScroll
            // 
            this.bbi_WeaversScroll.Caption = "Scroll";
            this.bbi_WeaversScroll.Id = 343;
            this.bbi_WeaversScroll.ImageIndex = 1;
            this.bbi_WeaversScroll.Name = "bbi_WeaversScroll";
            // 
            // bbi_Data_Loom_Log
            // 
            this.bbi_Data_Loom_Log.Caption = "Machine Session Log";
            this.bbi_Data_Loom_Log.Description = "[Weaving] Prints machine session log";
            this.bbi_Data_Loom_Log.Id = 346;
            this.bbi_Data_Loom_Log.ImageIndex = 119;
            this.bbi_Data_Loom_Log.Name = "bbi_Data_Loom_Log";
            this.bbi_Data_Loom_Log.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Loom_Log_ItemClick);
            // 
            // Refresh_Accounts
            // 
            this.Refresh_Accounts.Caption = "Refresh Accounts";
            this.Refresh_Accounts.Description = "[Accounts and Finance] Refresh accounting parameters";
            this.Refresh_Accounts.Id = 351;
            this.Refresh_Accounts.ImageIndex = 136;
            this.Refresh_Accounts.Name = "Refresh_Accounts";
            this.Refresh_Accounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Refresh_Accounts_ItemClick);
            // 
            // Accounts_CashPayment
            // 
            this.Accounts_CashPayment.Caption = "Cash Payment";
            this.Accounts_CashPayment.Description = "[Accounts and Finance] Add, Edit, Delete cash payment voucher";
            this.Accounts_CashPayment.Id = 352;
            this.Accounts_CashPayment.ImageIndex = 141;
            this.Accounts_CashPayment.Name = "Accounts_CashPayment";
            this.Accounts_CashPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_CashPayment_ItemClick);
            // 
            // Accounts_BankPayment
            // 
            this.Accounts_BankPayment.Caption = "Bank Payment";
            this.Accounts_BankPayment.Description = "[Accounts and Finance] Add, Edit , Delete bank payment voucher";
            this.Accounts_BankPayment.Id = 353;
            this.Accounts_BankPayment.ImageIndex = 139;
            this.Accounts_BankPayment.Name = "Accounts_BankPayment";
            this.Accounts_BankPayment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_BankPayment_ItemClick);
            // 
            // Accounts_CashReceipt
            // 
            this.Accounts_CashReceipt.Caption = "Cash Receipt";
            this.Accounts_CashReceipt.Description = "[Accounts and Finance] Add , Edit , Delete cash receipt voucher";
            this.Accounts_CashReceipt.Id = 354;
            this.Accounts_CashReceipt.ImageIndex = 140;
            this.Accounts_CashReceipt.Name = "Accounts_CashReceipt";
            this.Accounts_CashReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_CashReceipt_ItemClick);
            // 
            // Accounts_BankReceipt
            // 
            this.Accounts_BankReceipt.Caption = "Bank Receipt";
            this.Accounts_BankReceipt.Description = "[Accounts and Finance] Add, Edit , Delete bank receipt voucher";
            this.Accounts_BankReceipt.Id = 355;
            this.Accounts_BankReceipt.ImageIndex = 142;
            this.Accounts_BankReceipt.Name = "Accounts_BankReceipt";
            this.Accounts_BankReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_BankReceipt_ItemClick);
            // 
            // FinancialYear
            // 
            this.FinancialYear.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinancialYear.Appearance.Options.UseFont = true;
            this.FinancialYear.Caption = "Financial Year 2013";
            this.FinancialYear.Description = "[Status] working financial year";
            this.FinancialYear.Id = 356;
            this.FinancialYear.ImageIndex = 150;
            this.FinancialYear.Name = "FinancialYear";
            this.FinancialYear.Tag = "2003";
            // 
            // bbi_Data_AssignLoom_FDNE
            // 
            this.bbi_Data_AssignLoom_FDNE.Caption = "Force include into Running Efficiency";
            this.bbi_Data_AssignLoom_FDNE.Description = "[Dashboard] force loom into running efficiency";
            this.bbi_Data_AssignLoom_FDNE.Id = 358;
            this.bbi_Data_AssignLoom_FDNE.ImageIndex = 144;
            this.bbi_Data_AssignLoom_FDNE.Name = "bbi_Data_AssignLoom_FDNE";
            this.bbi_Data_AssignLoom_FDNE.Tag = "0";
            this.bbi_Data_AssignLoom_FDNE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_AssignLoom_FDNE_ItemClick);
            // 
            // Accounts_FabricSales
            // 
            this.Accounts_FabricSales.Caption = "Fabric Sales";
            this.Accounts_FabricSales.Description = "[Accounts and Finance] Manage fabric sales";
            this.Accounts_FabricSales.Id = 359;
            this.Accounts_FabricSales.LargeImageIndex = 302;
            this.Accounts_FabricSales.Name = "Accounts_FabricSales";
            this.Accounts_FabricSales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_FabricSales_ItemClick);
            // 
            // Accounts_SalesReturnFabric
            // 
            this.Accounts_SalesReturnFabric.Caption = "Credit Note";
            this.Accounts_SalesReturnFabric.Description = "[Accounts and Finance] Add , Edit , Delete credit note";
            this.Accounts_SalesReturnFabric.Id = 360;
            this.Accounts_SalesReturnFabric.ImageIndex = 145;
            this.Accounts_SalesReturnFabric.Name = "Accounts_SalesReturnFabric";
            this.Accounts_SalesReturnFabric.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesReturnFabric_ItemClick);
            // 
            // AccountsReports_Menu
            // 
            this.AccountsReports_Menu.Caption = "Reports";
            this.AccountsReports_Menu.Id = 361;
            this.AccountsReports_Menu.LargeImageIndex = 113;
            this.AccountsReports_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_DailyCashAndBankTransactionReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsMenu_Ledger),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_OpeningMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesTaxReturn_Menu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SubMenu_PNL),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsMenuTrialBalance),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsMenuChartofAccounts),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsMenuPurchases),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem14)});
            this.AccountsReports_Menu.Name = "AccountsReports_Menu";
            // 
            // Accounts_DailyCashAndBankTransactionReport
            // 
            this.Accounts_DailyCashAndBankTransactionReport.Caption = "Daily Cash and Bank Transaction";
            this.Accounts_DailyCashAndBankTransactionReport.Description = "[Accounts and Finance] Prints daily cash and bank transaction";
            this.Accounts_DailyCashAndBankTransactionReport.Id = 366;
            this.Accounts_DailyCashAndBankTransactionReport.Name = "Accounts_DailyCashAndBankTransactionReport";
            this.Accounts_DailyCashAndBankTransactionReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_DailyCashAndBankTransactionReport_ItemClick);
            // 
            // AccountsMenu_Ledger
            // 
            this.AccountsMenu_Ledger.Caption = "Ledger";
            this.AccountsMenu_Ledger.Id = 368;
            this.AccountsMenu_Ledger.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_GeneralLedger),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_Generalledger_AI_Cash),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_Generalledger_AI_Bank),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesTaxRegister_Article)});
            this.AccountsMenu_Ledger.Name = "AccountsMenu_Ledger";
            // 
            // Accounts_GeneralLedger
            // 
            this.Accounts_GeneralLedger.Caption = "General Ledger";
            this.Accounts_GeneralLedger.Description = "[Accounts and Finance] Prints General ledger";
            this.Accounts_GeneralLedger.Id = 362;
            this.Accounts_GeneralLedger.Name = "Accounts_GeneralLedger";
            this.Accounts_GeneralLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_GeneralLedger_ItemClick);
            // 
            // Accounts_Generalledger_AI_Cash
            // 
            this.Accounts_Generalledger_AI_Cash.Caption = "General Ledger -Cash (AI)";
            this.Accounts_Generalledger_AI_Cash.Description = "[Accounts and Finance] Prints Cash ledger with contra accounts";
            this.Accounts_Generalledger_AI_Cash.Id = 369;
            this.Accounts_Generalledger_AI_Cash.Name = "Accounts_Generalledger_AI_Cash";
            this.Accounts_Generalledger_AI_Cash.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_Generalledger_AI_ItemClick);
            // 
            // Accounts_Generalledger_AI_Bank
            // 
            this.Accounts_Generalledger_AI_Bank.Caption = "General Ledger-Banks (AI)";
            this.Accounts_Generalledger_AI_Bank.Description = "[Accounts and Finance] Prints General ledger bank with contra accounts";
            this.Accounts_Generalledger_AI_Bank.Id = 370;
            this.Accounts_Generalledger_AI_Bank.Name = "Accounts_Generalledger_AI_Bank";
            this.Accounts_Generalledger_AI_Bank.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_Generalledger_AI_Bank_ItemClick);
            // 
            // Accounts_SalesTaxRegister_Article
            // 
            this.Accounts_SalesTaxRegister_Article.Caption = "Sales Tax Register (Article)";
            this.Accounts_SalesTaxRegister_Article.Description = "[Accounts and Finance] Prints Article Sales Tax Register";
            this.Accounts_SalesTaxRegister_Article.Id = 437;
            this.Accounts_SalesTaxRegister_Article.Name = "Accounts_SalesTaxRegister_Article";
            this.Accounts_SalesTaxRegister_Article.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesTaxRegister_Article_ItemClick);
            // 
            // Accounts_OpeningMenu
            // 
            this.Accounts_OpeningMenu.Caption = "Opening";
            this.Accounts_OpeningMenu.Id = 371;
            this.Accounts_OpeningMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_OpeningBalances_G),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_OpeningBalances_N),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_OpeningBalances_B)});
            this.Accounts_OpeningMenu.Name = "Accounts_OpeningMenu";
            // 
            // Accounts_OpeningBalances_G
            // 
            this.Accounts_OpeningBalances_G.Caption = "Opening Balances [G]";
            this.Accounts_OpeningBalances_G.Description = "[Accounts and Finance] Prints Opening balances [G]";
            this.Accounts_OpeningBalances_G.Id = 365;
            this.Accounts_OpeningBalances_G.Name = "Accounts_OpeningBalances_G";
            this.Accounts_OpeningBalances_G.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_OpeningBalances_ItemClick);
            // 
            // Accounts_OpeningBalances_N
            // 
            this.Accounts_OpeningBalances_N.Caption = "Opening Balances [N]";
            this.Accounts_OpeningBalances_N.Description = "[Accounts and Finance] Prints Opening Balance [N]";
            this.Accounts_OpeningBalances_N.Id = 372;
            this.Accounts_OpeningBalances_N.Name = "Accounts_OpeningBalances_N";
            this.Accounts_OpeningBalances_N.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_OpeningBalances_N_ItemClick);
            // 
            // Accounts_OpeningBalances_B
            // 
            this.Accounts_OpeningBalances_B.Caption = "Opening Balances [B]";
            this.Accounts_OpeningBalances_B.Description = "[Accounts and Finance] Prints Opening Balance [B]";
            this.Accounts_OpeningBalances_B.Id = 373;
            this.Accounts_OpeningBalances_B.Name = "Accounts_OpeningBalances_B";
            this.Accounts_OpeningBalances_B.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_OpeningBalances_B_ItemClick);
            // 
            // Accounts_SalesTaxReturn_Menu
            // 
            this.Accounts_SalesTaxReturn_Menu.Caption = "Sales Tax Return";
            this.Accounts_SalesTaxReturn_Menu.Id = 374;
            this.Accounts_SalesTaxReturn_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_STAnnexC),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_STAnnexA),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesSummary_Report),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_STAnnexIDebitNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_AnnexICreditNote)});
            this.Accounts_SalesTaxReturn_Menu.Name = "Accounts_SalesTaxReturn_Menu";
            // 
            // Accounts_STAnnexC
            // 
            this.Accounts_STAnnexC.Caption = "ST Annex C";
            this.Accounts_STAnnexC.Description = "[Accounts and Finance] Prints sales tax Annexture C";
            this.Accounts_STAnnexC.Id = 375;
            this.Accounts_STAnnexC.Name = "Accounts_STAnnexC";
            this.Accounts_STAnnexC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_STAnnexC_ItemClick);
            // 
            // Accounts_STAnnexA
            // 
            this.Accounts_STAnnexA.Caption = "ST Annex A";
            this.Accounts_STAnnexA.Description = "[Accounts and Finance] Prints sales tax Annexture A";
            this.Accounts_STAnnexA.Id = 395;
            this.Accounts_STAnnexA.Name = "Accounts_STAnnexA";
            this.Accounts_STAnnexA.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_STAnnexA_ItemClick);
            // 
            // Accounts_SalesSummary_Report
            // 
            this.Accounts_SalesSummary_Report.Caption = "Sales Summary";
            this.Accounts_SalesSummary_Report.Description = "[Accounts and Finance] Prints Sales Summary";
            this.Accounts_SalesSummary_Report.Id = 423;
            this.Accounts_SalesSummary_Report.Name = "Accounts_SalesSummary_Report";
            this.Accounts_SalesSummary_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesSummary_Report_ItemClick);
            // 
            // Accounts_STAnnexIDebitNote
            // 
            this.Accounts_STAnnexIDebitNote.Caption = "ST Annex I (Debit Note)";
            this.Accounts_STAnnexIDebitNote.Description = "[Accounts and Finance] Prints Sales Tax Annex I (Debit Note)";
            this.Accounts_STAnnexIDebitNote.Id = 440;
            this.Accounts_STAnnexIDebitNote.Name = "Accounts_STAnnexIDebitNote";
            this.Accounts_STAnnexIDebitNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_STAnnexIDebitNote_ItemClick);
            // 
            // Accounts_AnnexICreditNote
            // 
            this.Accounts_AnnexICreditNote.Caption = "ST Annex I (Credit Note)";
            this.Accounts_AnnexICreditNote.Description = "[Accounts and Finance] Prints Sales Tax Annex I (Credit Note)";
            this.Accounts_AnnexICreditNote.Id = 441;
            this.Accounts_AnnexICreditNote.Name = "Accounts_AnnexICreditNote";
            this.Accounts_AnnexICreditNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_AnnexICreditNote_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "Consolidated Ledger";
            this.barSubItem4.Id = 396;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_ConsolidatedLedger_IV),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_ConsolidatedLedger_III),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_ConsolidatedLedger_II),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_ConsolidatedLedger_I)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // Accounts_ConsolidatedLedger_IV
            // 
            this.Accounts_ConsolidatedLedger_IV.Caption = "Account Level IV";
            this.Accounts_ConsolidatedLedger_IV.Description = "[Accounts and Finance] Prints Consolidated Ledger Level IV";
            this.Accounts_ConsolidatedLedger_IV.Id = 397;
            this.Accounts_ConsolidatedLedger_IV.Name = "Accounts_ConsolidatedLedger_IV";
            this.Accounts_ConsolidatedLedger_IV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ConsolidatedLedger_IV_ItemClick);
            // 
            // Accounts_ConsolidatedLedger_III
            // 
            this.Accounts_ConsolidatedLedger_III.Caption = "Account Level III";
            this.Accounts_ConsolidatedLedger_III.Description = "[Accounts and Finance] Prints Consolidated Ledger Level III";
            this.Accounts_ConsolidatedLedger_III.Id = 398;
            this.Accounts_ConsolidatedLedger_III.Name = "Accounts_ConsolidatedLedger_III";
            this.Accounts_ConsolidatedLedger_III.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ConsolidatedLedger_III_ItemClick);
            // 
            // Accounts_ConsolidatedLedger_II
            // 
            this.Accounts_ConsolidatedLedger_II.Caption = "Account Level II";
            this.Accounts_ConsolidatedLedger_II.Description = "[Accounts and Finance] Prints Consolidated Ledger Level II";
            this.Accounts_ConsolidatedLedger_II.Id = 399;
            this.Accounts_ConsolidatedLedger_II.Name = "Accounts_ConsolidatedLedger_II";
            this.Accounts_ConsolidatedLedger_II.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ConsolidatedLedger_II_ItemClick);
            // 
            // Accounts_ConsolidatedLedger_I
            // 
            this.Accounts_ConsolidatedLedger_I.Caption = "Account Level I";
            this.Accounts_ConsolidatedLedger_I.Description = "[Accounts and Finance] Prints Consolidated Ledger Level I";
            this.Accounts_ConsolidatedLedger_I.Id = 400;
            this.Accounts_ConsolidatedLedger_I.Name = "Accounts_ConsolidatedLedger_I";
            this.Accounts_ConsolidatedLedger_I.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ConsolidatedLedger_I_ItemClick);
            // 
            // barSubItem9
            // 
            this.barSubItem9.Caption = "Audit Trail Reports";
            this.barSubItem9.Id = 434;
            this.barSubItem9.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_AuditTrailReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_FilteredAuditTrailReport)});
            this.barSubItem9.Name = "barSubItem9";
            // 
            // Accounts_AuditTrailReport
            // 
            this.Accounts_AuditTrailReport.Caption = "Daily Audit Trail Report";
            this.Accounts_AuditTrailReport.Description = "[Accounts and Finance] Prints daily audit trail report";
            this.Accounts_AuditTrailReport.Id = 367;
            this.Accounts_AuditTrailReport.Name = "Accounts_AuditTrailReport";
            this.Accounts_AuditTrailReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_AuditTrailReport_ItemClick);
            // 
            // Accounts_FilteredAuditTrailReport
            // 
            this.Accounts_FilteredAuditTrailReport.Caption = "Filtered Audit Trail Report";
            this.Accounts_FilteredAuditTrailReport.Description = "[Accounts and Finance] Prints Filtered audit trail report";
            this.Accounts_FilteredAuditTrailReport.Id = 435;
            this.Accounts_FilteredAuditTrailReport.Name = "Accounts_FilteredAuditTrailReport";
            this.Accounts_FilteredAuditTrailReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_FilteredAuditTrailReport_ItemClick);
            // 
            // Accounts_SubMenu_PNL
            // 
            this.Accounts_SubMenu_PNL.Caption = "Profit && Loss Account";
            this.Accounts_SubMenu_PNL.Id = 445;
            this.Accounts_SubMenu_PNL.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_WeavingPNLAll)});
            this.Accounts_SubMenu_PNL.Name = "Accounts_SubMenu_PNL";
            // 
            // Accounts_WeavingPNLAll
            // 
            this.Accounts_WeavingPNLAll.Caption = "Weaving Profit && Loss Account";
            this.Accounts_WeavingPNLAll.Description = "[Accounts and Finance] Prints Profit and Loss Weaving";
            this.Accounts_WeavingPNLAll.Id = 446;
            this.Accounts_WeavingPNLAll.Name = "Accounts_WeavingPNLAll";
            this.Accounts_WeavingPNLAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_WeavingPNLAll_ItemClick);
            // 
            // AccountsMenuTrialBalance
            // 
            this.AccountsMenuTrialBalance.Caption = "Trial Balance";
            this.AccountsMenuTrialBalance.Id = 493;
            this.AccountsMenuTrialBalance.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PeriodicTrialBalance),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsTrialBalancesSumBalances),
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsTrialBalanceConsolidated),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_TrialBalanceEnding),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_TrialBalanceEndingG),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_TrialBalanceEndingN)});
            this.AccountsMenuTrialBalance.Name = "AccountsMenuTrialBalance";
            // 
            // Accounts_PeriodicTrialBalance
            // 
            this.Accounts_PeriodicTrialBalance.Caption = "Periodic Trial Balance (Detailed Level)";
            this.Accounts_PeriodicTrialBalance.Description = "[Accounts and Finance] Prints periodic trial balance";
            this.Accounts_PeriodicTrialBalance.Id = 364;
            this.Accounts_PeriodicTrialBalance.Name = "Accounts_PeriodicTrialBalance";
            this.Accounts_PeriodicTrialBalance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PeriodicTrialBalance_ItemClick);
            // 
            // AccountsTrialBalancesSumBalances
            // 
            this.AccountsTrialBalancesSumBalances.Caption = "Periodic Trial Balance (Sum Balances)";
            this.AccountsTrialBalancesSumBalances.Description = "[Accounts and Finance] Prints periodic trial balance (Sum Balances)";
            this.AccountsTrialBalancesSumBalances.Id = 491;
            this.AccountsTrialBalancesSumBalances.Name = "AccountsTrialBalancesSumBalances";
            this.AccountsTrialBalancesSumBalances.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AccountsTrialBalancesSumBalances_ItemClick);
            // 
            // AccountsTrialBalanceConsolidated
            // 
            this.AccountsTrialBalanceConsolidated.Caption = "Consolidated Trial Balance";
            this.AccountsTrialBalanceConsolidated.Description = "[Accounts and Finance] Prints periodic trial balance Consolidated";
            this.AccountsTrialBalanceConsolidated.Id = 492;
            this.AccountsTrialBalanceConsolidated.Name = "AccountsTrialBalanceConsolidated";
            this.AccountsTrialBalanceConsolidated.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AccountsTrialBalanceConsolidated_ItemClick);
            // 
            // Accounts_TrialBalanceEnding
            // 
            this.Accounts_TrialBalanceEnding.Caption = "Ending Trial Balance [B]";
            this.Accounts_TrialBalanceEnding.Description = "[Accounts and Finance] Prints ending trial balance Type-B";
            this.Accounts_TrialBalanceEnding.Id = 496;
            this.Accounts_TrialBalanceEnding.Name = "Accounts_TrialBalanceEnding";
            this.Accounts_TrialBalanceEnding.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_TrialBalanceEnding_ItemClick);
            // 
            // Accounts_TrialBalanceEndingG
            // 
            this.Accounts_TrialBalanceEndingG.Caption = "Ending Trial Balance [G]";
            this.Accounts_TrialBalanceEndingG.Description = "[Accounts and Finance] Prints ending trial balance Type-G";
            this.Accounts_TrialBalanceEndingG.Id = 553;
            this.Accounts_TrialBalanceEndingG.Name = "Accounts_TrialBalanceEndingG";
            this.Accounts_TrialBalanceEndingG.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_TrialBalanceEndingG_ItemClick);
            // 
            // Accounts_TrialBalanceEndingN
            // 
            this.Accounts_TrialBalanceEndingN.Caption = "Ending Trial Balance [N]";
            this.Accounts_TrialBalanceEndingN.Description = "[Accounts and Finance] Prints ending trial balance Type-N";
            this.Accounts_TrialBalanceEndingN.Id = 554;
            this.Accounts_TrialBalanceEndingN.Name = "Accounts_TrialBalanceEndingN";
            this.Accounts_TrialBalanceEndingN.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_TrialBalanceEndingN_ItemClick);
            // 
            // AccountsMenuChartofAccounts
            // 
            this.AccountsMenuChartofAccounts.Caption = "Chart of Accounts";
            this.AccountsMenuChartofAccounts.Id = 544;
            this.AccountsMenuChartofAccounts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PrintChartOfAccounts)});
            this.AccountsMenuChartofAccounts.Name = "AccountsMenuChartofAccounts";
            // 
            // Accounts_PrintChartOfAccounts
            // 
            this.Accounts_PrintChartOfAccounts.Caption = "Chart of Accounts Tree";
            this.Accounts_PrintChartOfAccounts.Description = "[Accounts and Finance] Prints Charts of Accounts";
            this.Accounts_PrintChartOfAccounts.Id = 545;
            this.Accounts_PrintChartOfAccounts.Name = "Accounts_PrintChartOfAccounts";
            this.Accounts_PrintChartOfAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PrintChartOfAccounts_ItemClick);
            // 
            // AccountsMenuPurchases
            // 
            this.AccountsMenuPurchases.Caption = "Purchases";
            this.AccountsMenuPurchases.Id = 581;
            this.AccountsMenuPurchases.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Purchases_PurchaseLedger),
            new DevExpress.XtraBars.LinkPersistInfo(this.Purchases_PurchasesSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PurchaseRegister_DuringPeriod)});
            this.AccountsMenuPurchases.Name = "AccountsMenuPurchases";
            // 
            // Purchases_PurchaseLedger
            // 
            this.Purchases_PurchaseLedger.Caption = "Purchase Leger";
            this.Purchases_PurchaseLedger.Description = "[Accounts and Finance] Purchases ledger";
            this.Purchases_PurchaseLedger.Id = 583;
            this.Purchases_PurchaseLedger.Name = "Purchases_PurchaseLedger";
            this.Purchases_PurchaseLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Purchases_PurchaseLedger_ItemClick);
            // 
            // Purchases_PurchasesSummary
            // 
            this.Purchases_PurchasesSummary.Caption = "Purchases Summary";
            this.Purchases_PurchasesSummary.Description = "[Accounts and Finance] Purchases Summary";
            this.Purchases_PurchasesSummary.Id = 584;
            this.Purchases_PurchasesSummary.Name = "Purchases_PurchasesSummary";
            this.Purchases_PurchasesSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Purchases_PurchasesSummary_ItemClick);
            // 
            // Accounts_PurchaseRegister_DuringPeriod
            // 
            this.Accounts_PurchaseRegister_DuringPeriod.Caption = "Purchases During Period";
            this.Accounts_PurchaseRegister_DuringPeriod.Description = "[Accounts and Finance] Purchases During Period";
            this.Accounts_PurchaseRegister_DuringPeriod.Id = 630;
            this.Accounts_PurchaseRegister_DuringPeriod.Name = "Accounts_PurchaseRegister_DuringPeriod";
            this.Accounts_PurchaseRegister_DuringPeriod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PurchaseRegister_DuringPeriod_ItemClick);
            // 
            // barSubItem14
            // 
            this.barSubItem14.Caption = "Sales";
            this.barSubItem14.Id = 582;
            this.barSubItem14.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesRegister_PartyFilter),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesRegister_Dated),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_SalesRegister_Article)});
            this.barSubItem14.Name = "barSubItem14";
            // 
            // Accounts_SalesRegister_PartyFilter
            // 
            this.Accounts_SalesRegister_PartyFilter.Caption = "Sales Register (Party)";
            this.Accounts_SalesRegister_PartyFilter.Description = "[Accounts and Finance] Sales Register ( Party )";
            this.Accounts_SalesRegister_PartyFilter.Id = 618;
            this.Accounts_SalesRegister_PartyFilter.Name = "Accounts_SalesRegister_PartyFilter";
            this.Accounts_SalesRegister_PartyFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesRegister_PartyFilter_ItemClick);
            // 
            // Accounts_SalesRegister_Dated
            // 
            this.Accounts_SalesRegister_Dated.Caption = "Sales During Period";
            this.Accounts_SalesRegister_Dated.Description = "[Accounts and Finance] Sales Register (During Period)";
            this.Accounts_SalesRegister_Dated.Id = 629;
            this.Accounts_SalesRegister_Dated.Name = "Accounts_SalesRegister_Dated";
            this.Accounts_SalesRegister_Dated.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesRegister_Dated_ItemClick);
            // 
            // Accounts_SalesRegister_Article
            // 
            this.Accounts_SalesRegister_Article.Caption = "Sales Register (Article)";
            this.Accounts_SalesRegister_Article.Description = "[Accounts and Finance] Sales Register ( Article )";
            this.Accounts_SalesRegister_Article.Id = 631;
            this.Accounts_SalesRegister_Article.Name = "Accounts_SalesRegister_Article";
            this.Accounts_SalesRegister_Article.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesRegister_Article_ItemClick);
            // 
            // Accounts_GeneralVoucher
            // 
            this.Accounts_GeneralVoucher.Caption = "General Voucher";
            this.Accounts_GeneralVoucher.Description = "[Accounts and Finance] Add , Edit , Delete general voucher";
            this.Accounts_GeneralVoucher.Id = 363;
            this.Accounts_GeneralVoucher.ImageIndex = 124;
            this.Accounts_GeneralVoucher.Name = "Accounts_GeneralVoucher";
            this.Accounts_GeneralVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_GeneralVoucher_ItemClick);
            // 
            // Accounts_PurchaseMenu
            // 
            this.Accounts_PurchaseMenu.Caption = "Purchases";
            this.Accounts_PurchaseMenu.Id = 377;
            this.Accounts_PurchaseMenu.LargeImageIndex = 3;
            this.Accounts_PurchaseMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AccountsMenu_Purchases),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8)});
            this.Accounts_PurchaseMenu.Name = "Accounts_PurchaseMenu";
            // 
            // AccountsMenu_Purchases
            // 
            this.AccountsMenu_Purchases.Caption = "Purchases";
            this.AccountsMenu_Purchases.Id = 404;
            this.AccountsMenu_Purchases.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_YarnPurchases),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_FabricPurchases),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_OtherPurchases)});
            this.AccountsMenu_Purchases.Name = "AccountsMenu_Purchases";
            // 
            // Accounts_YarnPurchases
            // 
            this.Accounts_YarnPurchases.Caption = "Yarn Purchases";
            this.Accounts_YarnPurchases.Description = "[Accounts and Finance] Purchases Yarn";
            this.Accounts_YarnPurchases.Id = 378;
            this.Accounts_YarnPurchases.Name = "Accounts_YarnPurchases";
            this.Accounts_YarnPurchases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_YarnPurchases_ItemClick);
            // 
            // Accounts_FabricPurchases
            // 
            this.Accounts_FabricPurchases.Caption = "Fabric Purchases";
            this.Accounts_FabricPurchases.Description = "[Accounts and Finance] Purchases Fabric";
            this.Accounts_FabricPurchases.Id = 379;
            this.Accounts_FabricPurchases.Name = "Accounts_FabricPurchases";
            this.Accounts_FabricPurchases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_FabricPurchases_ItemClick);
            // 
            // Accounts_OtherPurchases
            // 
            this.Accounts_OtherPurchases.Caption = "Other Purchases";
            this.Accounts_OtherPurchases.Description = "[Accounts and Finance] Purchases Others";
            this.Accounts_OtherPurchases.Id = 382;
            this.Accounts_OtherPurchases.Name = "Accounts_OtherPurchases";
            this.Accounts_OtherPurchases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_OtherPurchases_ItemClick);
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "Purchase Return";
            this.barSubItem8.Id = 405;
            this.barSubItem8.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PurchasesYarn_Return),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PurchasesFabric_Return),
            new DevExpress.XtraBars.LinkPersistInfo(this.Accounts_PurchasesOthers_Return)});
            this.barSubItem8.Name = "barSubItem8";
            // 
            // Accounts_PurchasesYarn_Return
            // 
            this.Accounts_PurchasesYarn_Return.Caption = "Purchase Return (Yarn)";
            this.Accounts_PurchasesYarn_Return.Description = "[Accounts and Finance] Purchases Return (Yarn)";
            this.Accounts_PurchasesYarn_Return.Id = 402;
            this.Accounts_PurchasesYarn_Return.Name = "Accounts_PurchasesYarn_Return";
            this.Accounts_PurchasesYarn_Return.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PurchasesYarn_Return_ItemClick);
            // 
            // Accounts_PurchasesFabric_Return
            // 
            this.Accounts_PurchasesFabric_Return.Caption = "Purchase Return (Fabric)";
            this.Accounts_PurchasesFabric_Return.Description = "[Accounts and Finance] Purchases Return (Fabric)";
            this.Accounts_PurchasesFabric_Return.Id = 403;
            this.Accounts_PurchasesFabric_Return.Name = "Accounts_PurchasesFabric_Return";
            this.Accounts_PurchasesFabric_Return.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PurchasesFabric_Return_ItemClick);
            // 
            // Accounts_PurchasesOthers_Return
            // 
            this.Accounts_PurchasesOthers_Return.Caption = "Purchase Return (Others)";
            this.Accounts_PurchasesOthers_Return.Description = "[Accounts and Finance] Purchases Return (Others)";
            this.Accounts_PurchasesOthers_Return.Id = 617;
            this.Accounts_PurchasesOthers_Return.Name = "Accounts_PurchasesOthers_Return";
            this.Accounts_PurchasesOthers_Return.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PurchasesOthers_Return_ItemClick);
            // 
            // PGB_Employees_Employee
            // 
            this.PGB_Employees_Employee.Caption = "Employees";
            this.PGB_Employees_Employee.Description = "[HR] Manage factory / mill employees";
            this.PGB_Employees_Employee.Id = 383;
            this.PGB_Employees_Employee.LargeImageIndex = 5;
            this.PGB_Employees_Employee.Name = "PGB_Employees_Employee";
            this.PGB_Employees_Employee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PGB_Employees_Employee_ItemClick);
            // 
            // PGB_Employees_Departments
            // 
            this.PGB_Employees_Departments.Caption = "Departments";
            this.PGB_Employees_Departments.Description = "[HR] Manage departments , designation and sub departments related to employees";
            this.PGB_Employees_Departments.Id = 384;
            this.PGB_Employees_Departments.ImageIndex = 87;
            this.PGB_Employees_Departments.Name = "PGB_Employees_Departments";
            this.PGB_Employees_Departments.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PGB_Employees_Departments_ItemClick);
            // 
            // bbi_UnlockApp
            // 
            this.bbi_UnlockApp.Caption = "unlock";
            this.bbi_UnlockApp.Description = "[Display] unlocks the application";
            this.bbi_UnlockApp.Id = 390;
            this.bbi_UnlockApp.ImageIndex = 92;
            this.bbi_UnlockApp.Name = "bbi_UnlockApp";
            // 
            // bbi_Tool_ClassicViewColors
            // 
            this.bbi_Tool_ClassicViewColors.Caption = "Colors [Classic View]";
            this.bbi_Tool_ClassicViewColors.Description = "[Dashboard] Colors Classic View Settings";
            this.bbi_Tool_ClassicViewColors.Id = 401;
            this.bbi_Tool_ClassicViewColors.Name = "bbi_Tool_ClassicViewColors";
            this.bbi_Tool_ClassicViewColors.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Tool_ClassicViewColors_ItemClick);
            // 
            // Menu_GreigeFabricContracts
            // 
            this.Menu_GreigeFabricContracts.Caption = "Greige Fabric";
            this.Menu_GreigeFabricContracts.Id = 407;
            this.Menu_GreigeFabricContracts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Menu_GreigeFabricSalesContracts)});
            this.Menu_GreigeFabricContracts.Name = "Menu_GreigeFabricContracts";
            // 
            // Menu_GreigeFabricSalesContracts
            // 
            this.Menu_GreigeFabricSalesContracts.Caption = "Sales";
            this.Menu_GreigeFabricSalesContracts.Id = 411;
            this.Menu_GreigeFabricSalesContracts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Greige),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Overhead),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Conversion)});
            this.Menu_GreigeFabricSalesContracts.Name = "Menu_GreigeFabricSalesContracts";
            // 
            // Contracts_Sales_Greige
            // 
            this.Contracts_Sales_Greige.Caption = "Sales Contract [Greige]";
            this.Contracts_Sales_Greige.Id = 415;
            this.Contracts_Sales_Greige.Name = "Contracts_Sales_Greige";
            this.Contracts_Sales_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Contracts_Sales_Greige_ItemClick);
            // 
            // Contracts_Sales_Overhead
            // 
            this.Contracts_Sales_Overhead.Caption = "Overhead Sales";
            this.Contracts_Sales_Overhead.Id = 416;
            this.Contracts_Sales_Overhead.Name = "Contracts_Sales_Overhead";
            // 
            // Contracts_Sales_Conversion
            // 
            this.Contracts_Sales_Conversion.Caption = "Conversion Sales";
            this.Contracts_Sales_Conversion.Id = 417;
            this.Contracts_Sales_Conversion.Name = "Contracts_Sales_Conversion";
            // 
            // Menu_TowelContracts
            // 
            this.Menu_TowelContracts.Caption = "Towel";
            this.Menu_TowelContracts.Id = 408;
            this.Menu_TowelContracts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Menu_TowelSalesContracts),
            new DevExpress.XtraBars.LinkPersistInfo(this.Menu_TowelPurchasesContracts)});
            this.Menu_TowelContracts.Name = "Menu_TowelContracts";
            // 
            // Menu_TowelSalesContracts
            // 
            this.Menu_TowelSalesContracts.Caption = "Sales";
            this.Menu_TowelSalesContracts.Id = 413;
            this.Menu_TowelSalesContracts.Name = "Menu_TowelSalesContracts";
            // 
            // Menu_TowelPurchasesContracts
            // 
            this.Menu_TowelPurchasesContracts.Caption = "Purchases";
            this.Menu_TowelPurchasesContracts.Id = 414;
            this.Menu_TowelPurchasesContracts.Name = "Menu_TowelPurchasesContracts";
            // 
            // Menu_Summaries
            // 
            this.Menu_Summaries.Caption = "Summary";
            this.Menu_Summaries.Id = 421;
            this.Menu_Summaries.Name = "Menu_Summaries";
            // 
            // ClassicalCheck_Efficiency
            // 
            this.ClassicalCheck_Efficiency.Caption = "Efficiency View";
            this.ClassicalCheck_Efficiency.Checked = true;
            this.ClassicalCheck_Efficiency.Description = "[Dashboard] Real time Efficiency View";
            this.ClassicalCheck_Efficiency.Id = 428;
            this.ClassicalCheck_Efficiency.ImageIndex = 66;
            this.ClassicalCheck_Efficiency.Name = "ClassicalCheck_Efficiency";
            this.ClassicalCheck_Efficiency.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_Efficiency_CheckedChanged);
            // 
            // ClassicalCheck_RPMView
            // 
            this.ClassicalCheck_RPMView.Caption = "RPM View";
            this.ClassicalCheck_RPMView.Description = "[Dashboard] Real time RPM View";
            this.ClassicalCheck_RPMView.Id = 429;
            this.ClassicalCheck_RPMView.ImageIndex = 105;
            this.ClassicalCheck_RPMView.Name = "ClassicalCheck_RPMView";
            this.ClassicalCheck_RPMView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_RPMView_CheckedChanged);
            // 
            // ClassicalCheck_WarpView
            // 
            this.ClassicalCheck_WarpView.Caption = "Warp Counter View";
            this.ClassicalCheck_WarpView.Id = 430;
            this.ClassicalCheck_WarpView.ImageIndex = 112;
            this.ClassicalCheck_WarpView.Name = "ClassicalCheck_WarpView";
            this.ClassicalCheck_WarpView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_WarpView_CheckedChanged);
            // 
            // ClassicalCheck_WeftView
            // 
            this.ClassicalCheck_WeftView.Caption = "Weft Counter View";
            this.ClassicalCheck_WeftView.Id = 431;
            this.ClassicalCheck_WeftView.ImageIndex = 113;
            this.ClassicalCheck_WeftView.Name = "ClassicalCheck_WeftView";
            this.ClassicalCheck_WeftView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_WeftView_CheckedChanged);
            // 
            // ClassicalCheck_WarpKnottView
            // 
            this.ClassicalCheck_WarpKnottView.Caption = "Average Warp Knot. Time";
            this.ClassicalCheck_WarpKnottView.Id = 432;
            this.ClassicalCheck_WarpKnottView.ImageIndex = 124;
            this.ClassicalCheck_WarpKnottView.Name = "ClassicalCheck_WarpKnottView";
            this.ClassicalCheck_WarpKnottView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_WarpKnottView_CheckedChanged);
            // 
            // ClassicalCheck_WeftKnottView
            // 
            this.ClassicalCheck_WeftKnottView.Caption = "Average Weft Knot. Time";
            this.ClassicalCheck_WeftKnottView.Id = 433;
            this.ClassicalCheck_WeftKnottView.ImageIndex = 130;
            this.ClassicalCheck_WeftKnottView.Name = "ClassicalCheck_WeftKnottView";
            this.ClassicalCheck_WeftKnottView.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.ClassicalCheck_WeftKnottView_CheckedChanged);
            // 
            // Accounts_SalesTaxRegister_FilterParty
            // 
            this.Accounts_SalesTaxRegister_FilterParty.Caption = "Sales Tax Register";
            this.Accounts_SalesTaxRegister_FilterParty.Description = "[Accounts and Finance] Prints Party Sales Tax Register";
            this.Accounts_SalesTaxRegister_FilterParty.Id = 436;
            this.Accounts_SalesTaxRegister_FilterParty.Name = "Accounts_SalesTaxRegister_FilterParty";
            // 
            // Accounts_SalesRegister
            // 
            this.Accounts_SalesRegister.Caption = "Sales Register";
            this.Accounts_SalesRegister.Description = "[Accounts and Finance] Prints Party Sales Register";
            this.Accounts_SalesRegister.Id = 438;
            this.Accounts_SalesRegister.Name = "Accounts_SalesRegister";
            this.Accounts_SalesRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_SalesRegister_ItemClick);
            // 
            // ValidateMoreSecure
            // 
            this.ValidateMoreSecure.Caption = "Validate Security";
            this.ValidateMoreSecure.Description = "[Tools] Valid Security";
            this.ValidateMoreSecure.Id = 439;
            this.ValidateMoreSecure.Name = "ValidateMoreSecure";
            this.ValidateMoreSecure.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ValidateMoreSecure_ItemClick);
            // 
            // Accounts_PaymentAdvice
            // 
            this.Accounts_PaymentAdvice.Caption = "Payment Advice";
            this.Accounts_PaymentAdvice.Description = "[Accounts and Finance] Add, Edit , Delete Payment Advice";
            this.Accounts_PaymentAdvice.Id = 447;
            this.Accounts_PaymentAdvice.ImageIndex = 53;
            this.Accounts_PaymentAdvice.Name = "Accounts_PaymentAdvice";
            this.Accounts_PaymentAdvice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_PaymentAdvice_ItemClick);
            // 
            // Planning_ProgramSheet
            // 
            this.Planning_ProgramSheet.Caption = "Program Sheet";
            this.Planning_ProgramSheet.Description = "[Planning] Warping/Sizing Program Sheet";
            this.Planning_ProgramSheet.Id = 452;
            this.Planning_ProgramSheet.LargeImageIndex = 3;
            this.Planning_ProgramSheet.Name = "Planning_ProgramSheet";
            this.Planning_ProgramSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Planning_ProgramSheet_ItemClick);
            // 
            // bbiALUGPU
            // 
            this.bbiALUGPU.Caption = "ALUGPU";
            this.bbiALUGPU.Description = "[Tools] Set ALUGPU";
            this.bbiALUGPU.Id = 458;
            this.bbiALUGPU.Name = "bbiALUGPU";
            this.bbiALUGPU.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiALUGPU_ItemClick);
            // 
            // bbi_Data_Article_FabricName
            // 
            this.bbi_Data_Article_FabricName.Caption = "Fabric Names";
            this.bbi_Data_Article_FabricName.Description = "[Planning]  Manage common fabric names list";
            this.bbi_Data_Article_FabricName.Id = 460;
            this.bbi_Data_Article_FabricName.ImageIndex = 4;
            this.bbi_Data_Article_FabricName.Name = "bbi_Data_Article_FabricName";
            this.bbi_Data_Article_FabricName.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_Data_Article_FabricName_ItemClick);
            // 
            // bbi_LoomFilter
            // 
            this.bbi_LoomFilter.Caption = "Merged Layouts";
            this.bbi_LoomFilter.Id = 463;
            this.bbi_LoomFilter.ImageIndex = 149;
            this.bbi_LoomFilter.Name = "bbi_LoomFilter";
            // 
            // bbiGotoFilter
            // 
            this.bbiGotoFilter.Caption = "Filter List";
            this.bbiGotoFilter.Description = "[Dashboard] Real time filter display of shed efficiency of weaving shed";
            this.bbiGotoFilter.Id = 464;
            this.bbiGotoFilter.Name = "bbiGotoFilter";
            this.bbiGotoFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGotoFilter_ItemClick);
            // 
            // ButtonFuction
            // 
            this.ButtonFuction.Caption = "FunctionDebug";
            this.ButtonFuction.Description = "[Debug] Function Debug";
            this.ButtonFuction.Id = 477;
            this.ButtonFuction.Name = "ButtonFuction";
            this.ButtonFuction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonFuction_ItemClick);
            // 
            // Production_OutSideSizing
            // 
            this.Production_OutSideSizing.Caption = "Outside Sizing";
            this.Production_OutSideSizing.Description = "[Production] Outside Sizing";
            this.Production_OutSideSizing.Id = 498;
            this.Production_OutSideSizing.ImageIndex = 29;
            this.Production_OutSideSizing.Name = "Production_OutSideSizing";
            this.Production_OutSideSizing.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Production_OutSideSizing_ItemClick);
            // 
            // Button_StoreAccounts
            // 
            this.Button_StoreAccounts.Caption = "Store Accounts";
            this.Button_StoreAccounts.Description = "[Store] Store Item Accounts";
            this.Button_StoreAccounts.Id = 499;
            this.Button_StoreAccounts.LargeImageIndex = 14;
            this.Button_StoreAccounts.Name = "Button_StoreAccounts";
            this.Button_StoreAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_StoreAccounts_ItemClick);
            // 
            // Button_PurchaseOrderStore
            // 
            this.Button_PurchaseOrderStore.Caption = "Purchase Order";
            this.Button_PurchaseOrderStore.Description = "[Store] Store Purchase Order";
            this.Button_PurchaseOrderStore.Id = 500;
            this.Button_PurchaseOrderStore.LargeImageIndex = 314;
            this.Button_PurchaseOrderStore.Name = "Button_PurchaseOrderStore";
            this.Button_PurchaseOrderStore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_PurchaseOrderStore_ItemClick);
            // 
            // Button_StorePurchaseRegister
            // 
            this.Button_StorePurchaseRegister.Caption = "Purchase Register";
            this.Button_StorePurchaseRegister.Description = "[Store] Store Purchase Register";
            this.Button_StorePurchaseRegister.Id = 501;
            this.Button_StorePurchaseRegister.LargeImageIndex = 315;
            this.Button_StorePurchaseRegister.Name = "Button_StorePurchaseRegister";
            this.Button_StorePurchaseRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_StorePurchaseRegister_ItemClick);
            // 
            // Button_StorePurchaseReturn
            // 
            this.Button_StorePurchaseReturn.Caption = "Purchase Return";
            this.Button_StorePurchaseReturn.Description = "[Store] Store Purchase Return";
            this.Button_StorePurchaseReturn.Id = 502;
            this.Button_StorePurchaseReturn.LargeImageIndex = 317;
            this.Button_StorePurchaseReturn.Name = "Button_StorePurchaseReturn";
            this.Button_StorePurchaseReturn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_StorePurchaseReturn_ItemClick);
            // 
            // Button_StoreIssueNote
            // 
            this.Button_StoreIssueNote.Caption = "Issue Note";
            this.Button_StoreIssueNote.Description = "[Store] Store Issue Note";
            this.Button_StoreIssueNote.Id = 503;
            this.Button_StoreIssueNote.LargeImageIndex = 313;
            this.Button_StoreIssueNote.Name = "Button_StoreIssueNote";
            this.Button_StoreIssueNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_StoreIssueNote_ItemClick);
            // 
            // SubMenu_Reports_Store
            // 
            this.SubMenu_Reports_Store.Caption = "Store Reports";
            this.SubMenu_Reports_Store.Id = 505;
            this.SubMenu_Reports_Store.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.SubMenuStore_Accounts),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_Opening_SubMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemStoreStockReports),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_Issuancereports_Store),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem_PurchasesReports_Store),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_ReturnBackReports_Menu)});
            this.SubMenu_Reports_Store.Name = "SubMenu_Reports_Store";
            // 
            // SubMenuStore_Accounts
            // 
            this.SubMenuStore_Accounts.Caption = "Item Accounts";
            this.SubMenuStore_Accounts.Id = 506;
            this.SubMenuStore_Accounts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ReportButton_StoreAccounts),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_ItemBinCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_ControlAccountsList)});
            this.SubMenuStore_Accounts.Name = "SubMenuStore_Accounts";
            // 
            // ReportButton_StoreAccounts
            // 
            this.ReportButton_StoreAccounts.Caption = "Store Accounts";
            this.ReportButton_StoreAccounts.Description = "[Store] {Reports} Store Item Account List";
            this.ReportButton_StoreAccounts.Id = 507;
            this.ReportButton_StoreAccounts.Name = "ReportButton_StoreAccounts";
            this.ReportButton_StoreAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ReportButton_StoreAccounts_ItemClick);
            // 
            // Store_ItemBinCard
            // 
            this.Store_ItemBinCard.Caption = "Item Bin Card";
            this.Store_ItemBinCard.Description = "[Store] {Reports} Store Item Bin Card";
            this.Store_ItemBinCard.Id = 522;
            this.Store_ItemBinCard.Name = "Store_ItemBinCard";
            this.Store_ItemBinCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_ItemBinCard_ItemClick);
            // 
            // Store_ControlAccountsList
            // 
            this.Store_ControlAccountsList.Caption = "Control Accounts List";
            this.Store_ControlAccountsList.Description = "[Store] {Reports} Store Control Accounts";
            this.Store_ControlAccountsList.Id = 524;
            this.Store_ControlAccountsList.Name = "Store_ControlAccountsList";
            this.Store_ControlAccountsList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_ControlAccountsList_ItemClick);
            // 
            // Store_Opening_SubMenu
            // 
            this.Store_Opening_SubMenu.Caption = "Opening";
            this.Store_Opening_SubMenu.Id = 517;
            this.Store_Opening_SubMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_OpeningEnteries_Report)});
            this.Store_Opening_SubMenu.Name = "Store_Opening_SubMenu";
            // 
            // Store_OpeningEnteries_Report
            // 
            this.Store_OpeningEnteries_Report.Caption = "Opening Entries Report";
            this.Store_OpeningEnteries_Report.Description = "[Store] {Reports} Store Opening Entries Report";
            this.Store_OpeningEnteries_Report.Id = 518;
            this.Store_OpeningEnteries_Report.Name = "Store_OpeningEnteries_Report";
            this.Store_OpeningEnteries_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_OpeningEnteries_Report_ItemClick);
            // 
            // barSubItemStoreStockReports
            // 
            this.barSubItemStoreStockReports.Caption = "Stock Reports";
            this.barSubItemStoreStockReports.Id = 560;
            this.barSubItemStoreStockReports.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_ClosingStockReport)});
            this.barSubItemStoreStockReports.Name = "barSubItemStoreStockReports";
            // 
            // Store_ClosingStockReport
            // 
            this.Store_ClosingStockReport.Caption = "Closing Stock";
            this.Store_ClosingStockReport.Description = "[Store] {Reports} Store Closing Stock";
            this.Store_ClosingStockReport.Id = 561;
            this.Store_ClosingStockReport.Name = "Store_ClosingStockReport";
            this.Store_ClosingStockReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_ClosingStockReport_ItemClick);
            // 
            // barSubItem_Issuancereports_Store
            // 
            this.barSubItem_Issuancereports_Store.Caption = "Issuance Reports";
            this.barSubItem_Issuancereports_Store.Id = 612;
            this.barSubItem_Issuancereports_Store.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_MonthlyIssuance_Report),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_MonthlyIssuance_Report_Asset),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_MonthlyIssuance_Report_DevelopmentConstruction),
            new DevExpress.XtraBars.LinkPersistInfo(this.MonthlyIssuanceOthers),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_MonthlyIssuanceGroupAccount_Report),
            new DevExpress.XtraBars.LinkPersistInfo(this.MonthlyIssuanceAllAccounts),
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_MonthlyDepartmentIssuance)});
            this.barSubItem_Issuancereports_Store.Name = "barSubItem_Issuancereports_Store";
            // 
            // Store_MonthlyIssuance_Report
            // 
            this.Store_MonthlyIssuance_Report.Caption = "Monthly Issuance (Expense A/C)";
            this.Store_MonthlyIssuance_Report.Description = "[Store] {Reports} Store Monthly Issuance Expense A/C";
            this.Store_MonthlyIssuance_Report.Id = 613;
            this.Store_MonthlyIssuance_Report.Name = "Store_MonthlyIssuance_Report";
            this.Store_MonthlyIssuance_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_MonthlyIssuance_Report_ItemClick);
            // 
            // Store_MonthlyIssuance_Report_Asset
            // 
            this.Store_MonthlyIssuance_Report_Asset.Caption = "Monthly Issuance (Asset A/C)";
            this.Store_MonthlyIssuance_Report_Asset.Description = "[Store] {Reports} Store Monthly Issuance Asset A/C";
            this.Store_MonthlyIssuance_Report_Asset.Id = 677;
            this.Store_MonthlyIssuance_Report_Asset.Name = "Store_MonthlyIssuance_Report_Asset";
            this.Store_MonthlyIssuance_Report_Asset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_MonthlyIssuance_Report_Asset_ItemClick);
            // 
            // Store_MonthlyIssuance_Report_DevelopmentConstruction
            // 
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction.Caption = "Monthly Issuance (Development && Construction A/C)";
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction.Description = "[Store] {Reports} Store Monthly Issuance Development and Construction A/C";
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction.Id = 678;
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction.Name = "Store_MonthlyIssuance_Report_DevelopmentConstruction";
            this.Store_MonthlyIssuance_Report_DevelopmentConstruction.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_MonthlyIssuance_Report_DevelopmentConstruction_ItemClick);
            // 
            // MonthlyIssuanceOthers
            // 
            this.MonthlyIssuanceOthers.Caption = "Monthly Issuance (Others)";
            this.MonthlyIssuanceOthers.Description = "[Store] {Reports} Store Monthly Issuance (Others)";
            this.MonthlyIssuanceOthers.Id = 697;
            this.MonthlyIssuanceOthers.Name = "MonthlyIssuanceOthers";
            this.MonthlyIssuanceOthers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MonthlyIssuanceOthers_ItemClick);
            // 
            // Store_MonthlyIssuanceGroupAccount_Report
            // 
            this.Store_MonthlyIssuanceGroupAccount_Report.Caption = "Monthly Issuance (Group Account)";
            this.Store_MonthlyIssuanceGroupAccount_Report.Description = "[Store] {Reports} Store Monthly Issuance -Group Account";
            this.Store_MonthlyIssuanceGroupAccount_Report.Id = 614;
            this.Store_MonthlyIssuanceGroupAccount_Report.Name = "Store_MonthlyIssuanceGroupAccount_Report";
            this.Store_MonthlyIssuanceGroupAccount_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_MonthlyIssuanceGroupAccount_Report_ItemClick);
            // 
            // MonthlyIssuanceAllAccounts
            // 
            this.MonthlyIssuanceAllAccounts.Caption = "Monthly Issuance (All Accounts)";
            this.MonthlyIssuanceAllAccounts.Description = "[Store] {Reports} Store Monthly Issuance All A/C";
            this.MonthlyIssuanceAllAccounts.Id = 698;
            this.MonthlyIssuanceAllAccounts.Name = "MonthlyIssuanceAllAccounts";
            this.MonthlyIssuanceAllAccounts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MonthlyIssuanceAllAccounts_ItemClick);
            // 
            // Store_MonthlyDepartmentIssuance
            // 
            this.Store_MonthlyDepartmentIssuance.Caption = "Monthly Department Issuance";
            this.Store_MonthlyDepartmentIssuance.Description = "[Store] {Reports} Store Monthly Deprartment Issuance";
            this.Store_MonthlyDepartmentIssuance.Id = 710;
            this.Store_MonthlyDepartmentIssuance.Name = "Store_MonthlyDepartmentIssuance";
            this.Store_MonthlyDepartmentIssuance.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_MonthlyDepartmentIssuance_ItemClick);
            // 
            // barSubItem_PurchasesReports_Store
            // 
            this.barSubItem_PurchasesReports_Store.Caption = "Purchases Reports";
            this.barSubItem_PurchasesReports_Store.Id = 615;
            this.barSubItem_PurchasesReports_Store.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_MonthlyPurchasesDetailedItem)});
            this.barSubItem_PurchasesReports_Store.Name = "barSubItem_PurchasesReports_Store";
            // 
            // barButtonItem_MonthlyPurchasesDetailedItem
            // 
            this.barButtonItem_MonthlyPurchasesDetailedItem.Caption = "Monthly Purchases";
            this.barButtonItem_MonthlyPurchasesDetailedItem.Description = "[Store] {Reports} Store Monthly Purchases-Detailed Items";
            this.barButtonItem_MonthlyPurchasesDetailedItem.Id = 616;
            this.barButtonItem_MonthlyPurchasesDetailedItem.Name = "barButtonItem_MonthlyPurchasesDetailedItem";
            this.barButtonItem_MonthlyPurchasesDetailedItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_MonthlyPurchasesDetailedItem_ItemClick);
            // 
            // Store_ReturnBackReports_Menu
            // 
            this.Store_ReturnBackReports_Menu.Caption = "Return Backs Reports";
            this.Store_ReturnBackReports_Menu.Id = 619;
            this.Store_ReturnBackReports_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Store_Monthly_GetBacks)});
            this.Store_ReturnBackReports_Menu.Name = "Store_ReturnBackReports_Menu";
            // 
            // Store_Monthly_GetBacks
            // 
            this.Store_Monthly_GetBacks.Caption = "Monthly Store Return Backs";
            this.Store_Monthly_GetBacks.Description = "[Store] {Reports} Store Monthly Get Backs";
            this.Store_Monthly_GetBacks.Id = 620;
            this.Store_Monthly_GetBacks.Name = "Store_Monthly_GetBacks";
            this.Store_Monthly_GetBacks.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_Monthly_GetBacks_ItemClick);
            // 
            // ButtonProductionSectionWarping
            // 
            this.ButtonProductionSectionWarping.Caption = "Section Warping";
            this.ButtonProductionSectionWarping.Description = "[Production] Manage daily Section Warping Production";
            this.ButtonProductionSectionWarping.Id = 513;
            this.ButtonProductionSectionWarping.ImageIndex = 58;
            this.ButtonProductionSectionWarping.Name = "ButtonProductionSectionWarping";
            this.ButtonProductionSectionWarping.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonProductionSectionWarping_ItemClick);
            // 
            // FabricContracts
            // 
            this.FabricContracts.Caption = "Towel";
            this.FabricContracts.Description = "[Planning] Towel P/O";
            this.FabricContracts.Id = 515;
            this.FabricContracts.LargeImageIndex = 311;
            this.FabricContracts.Name = "FabricContracts";
            this.FabricContracts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.FabricContracts_ItemClick);
            // 
            // Store_Opening
            // 
            this.Store_Opening.Caption = "Opening Enteries";
            this.Store_Opening.Description = "[Store] Store Opening Note";
            this.Store_Opening.Id = 516;
            this.Store_Opening.Name = "Store_Opening";
            this.Store_Opening.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_Opening_ItemClick);
            // 
            // Accounts_StoreCashPurchases
            // 
            this.Accounts_StoreCashPurchases.Caption = "Cash Purchases Store";
            this.Accounts_StoreCashPurchases.Description = "[Accounts and Finance] Purchases Cash Store";
            this.Accounts_StoreCashPurchases.Id = 519;
            this.Accounts_StoreCashPurchases.Name = "Accounts_StoreCashPurchases";
            this.Accounts_StoreCashPurchases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_StoreCashPurchases_ItemClick);
            // 
            // Accounts_CreditStorePurchases
            // 
            this.Accounts_CreditStorePurchases.Caption = "Credit Purchase Store";
            this.Accounts_CreditStorePurchases.Description = "[Accounts and Finance] Purchases Credit Store";
            this.Accounts_CreditStorePurchases.Id = 520;
            this.Accounts_CreditStorePurchases.Name = "Accounts_CreditStorePurchases";
            this.Accounts_CreditStorePurchases.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_CreditStorePurchases_ItemClick);
            // 
            // Store_ReceiveNote
            // 
            this.Store_ReceiveNote.Caption = "Receive Note";
            this.Store_ReceiveNote.Description = "[Store] Store Receive Note";
            this.Store_ReceiveNote.Id = 523;
            this.Store_ReceiveNote.LargeImageIndex = 316;
            this.Store_ReceiveNote.Name = "Store_ReceiveNote";
            this.Store_ReceiveNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_ReceiveNote_ItemClick);
            // 
            // Button_Towel_Opening
            // 
            this.Button_Towel_Opening.Id = 587;
            this.Button_Towel_Opening.Name = "Button_Towel_Opening";
            // 
            // Button_ManageVehicles
            // 
            this.Button_ManageVehicles.Caption = "Vehicles";
            this.Button_ManageVehicles.Description = "[GPS Tracking] Vehicles Management";
            this.Button_ManageVehicles.Id = 527;
            this.Button_ManageVehicles.LargeImageIndex = 125;
            this.Button_ManageVehicles.Name = "Button_ManageVehicles";
            this.Button_ManageVehicles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_ManageVehicles_ItemClick);
            // 
            // barButtonItem_GoogleEarth
            // 
            this.barButtonItem_GoogleEarth.Caption = "Google Earth";
            this.barButtonItem_GoogleEarth.Description = "[GPS Tracking] Earth Plugin";
            this.barButtonItem_GoogleEarth.Id = 528;
            this.barButtonItem_GoogleEarth.LargeImageIndex = 293;
            this.barButtonItem_GoogleEarth.Name = "barButtonItem_GoogleEarth";
            this.barButtonItem_GoogleEarth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_GoogleEarth_ItemClick);
            // 
            // barSubItem_PluginOptions
            // 
            this.barSubItem_PluginOptions.Caption = "Options";
            this.barSubItem_PluginOptions.Id = 529;
            this.barSubItem_PluginOptions.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Navigator),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Atmosphere),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_StatusBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_OverView),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Borders),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Terrain),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Roads),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem_Buildings)});
            this.barSubItem_PluginOptions.Name = "barSubItem_PluginOptions";
            // 
            // barCheckItem_Navigator
            // 
            this.barCheckItem_Navigator.Caption = "Navigator";
            this.barCheckItem_Navigator.Description = "[GPS Tracking] Plugin Options: Navigator";
            this.barCheckItem_Navigator.Id = 530;
            this.barCheckItem_Navigator.Name = "barCheckItem_Navigator";
            // 
            // barCheckItem_Atmosphere
            // 
            this.barCheckItem_Atmosphere.Caption = "Atmosphere";
            this.barCheckItem_Atmosphere.Description = "[GPS Tracking] Plugin Options: Atmosphere";
            this.barCheckItem_Atmosphere.Id = 532;
            this.barCheckItem_Atmosphere.Name = "barCheckItem_Atmosphere";
            // 
            // barCheckItem_StatusBar
            // 
            this.barCheckItem_StatusBar.Caption = "Status Bar";
            this.barCheckItem_StatusBar.Description = "[GPS Tracking] Plugin Options: Status Bar";
            this.barCheckItem_StatusBar.Id = 534;
            this.barCheckItem_StatusBar.Name = "barCheckItem_StatusBar";
            // 
            // barCheckItem_OverView
            // 
            this.barCheckItem_OverView.Caption = "Overview";
            this.barCheckItem_OverView.Description = "[GPS Tracking] Plugin Options: Overview";
            this.barCheckItem_OverView.Id = 533;
            this.barCheckItem_OverView.Name = "barCheckItem_OverView";
            // 
            // barCheckItem_Borders
            // 
            this.barCheckItem_Borders.Caption = "Borders";
            this.barCheckItem_Borders.Description = "[GPS Tracking] Plugin Options: Borders";
            this.barCheckItem_Borders.Id = 537;
            this.barCheckItem_Borders.Name = "barCheckItem_Borders";
            // 
            // barCheckItem_Terrain
            // 
            this.barCheckItem_Terrain.Caption = "Terrain";
            this.barCheckItem_Terrain.Description = "[GPS Tracking] Plugin Options: Terrain";
            this.barCheckItem_Terrain.Id = 538;
            this.barCheckItem_Terrain.Name = "barCheckItem_Terrain";
            // 
            // barCheckItem_Roads
            // 
            this.barCheckItem_Roads.Caption = "Roads";
            this.barCheckItem_Roads.Description = "[GPS Tracking] Plugin Options: Roads";
            this.barCheckItem_Roads.Id = 539;
            this.barCheckItem_Roads.Name = "barCheckItem_Roads";
            // 
            // barCheckItem_Buildings
            // 
            this.barCheckItem_Buildings.Caption = "Buildings";
            this.barCheckItem_Buildings.Description = "[GPS Tracking] Plugin Options: Buildings";
            this.barCheckItem_Buildings.Id = 540;
            this.barCheckItem_Buildings.Name = "barCheckItem_Buildings";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Atmosphere";
            this.barSubItem3.Id = 531;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barStaticItem5
            // 
            this.barStaticItem5.Caption = "--------";
            this.barStaticItem5.Id = 535;
            this.barStaticItem5.Name = "barStaticItem5";
            this.barStaticItem5.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barLinkContainerItem1
            // 
            this.barLinkContainerItem1.Caption = "barLinkContainerItem1";
            this.barLinkContainerItem1.Id = 536;
            this.barLinkContainerItem1.Name = "barLinkContainerItem1";
            // 
            // Tracking_VehicleMakes
            // 
            this.Tracking_VehicleMakes.Caption = "Makes";
            this.Tracking_VehicleMakes.Description = "[GPS Tracking] Makes List Management";
            this.Tracking_VehicleMakes.Id = 541;
            this.Tracking_VehicleMakes.Name = "Tracking_VehicleMakes";
            this.Tracking_VehicleMakes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Tracking_VehicleMakes_ItemClick);
            // 
            // Tracking_VehicleModels
            // 
            this.Tracking_VehicleModels.Caption = "Models";
            this.Tracking_VehicleModels.Description = "[GPS Tracking] Models List Management";
            this.Tracking_VehicleModels.Id = 542;
            this.Tracking_VehicleModels.Name = "Tracking_VehicleModels";
            this.Tracking_VehicleModels.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Tracking_VehicleModels_ItemClick);
            // 
            // Tracking_VehicleTypes
            // 
            this.Tracking_VehicleTypes.Caption = "Types";
            this.Tracking_VehicleTypes.Description = "[GPS Tracking] Types List Management";
            this.Tracking_VehicleTypes.Id = 543;
            this.Tracking_VehicleTypes.Name = "Tracking_VehicleTypes";
            this.Tracking_VehicleTypes.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Tracking_VehicleTypes_ItemClick);
            // 
            // Button_Planning_TowelArticles
            // 
            this.Button_Planning_TowelArticles.Caption = "Towel Articles";
            this.Button_Planning_TowelArticles.Id = 551;
            this.Button_Planning_TowelArticles.ImageIndex = 86;
            this.Button_Planning_TowelArticles.Name = "Button_Planning_TowelArticles";
            // 
            // Button_TowelArticles
            // 
            this.Button_TowelArticles.Caption = "Towel Articles";
            this.Button_TowelArticles.Description = "[Planning] Towel Articles";
            this.Button_TowelArticles.Id = 552;
            this.Button_TowelArticles.ImageIndex = 2;
            this.Button_TowelArticles.LargeImageIndex = 2;
            this.Button_TowelArticles.Name = "Button_TowelArticles";
            this.Button_TowelArticles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Button_TowelArticles_ItemClick);
            // 
            // Store_UnitsMeasurements
            // 
            this.Store_UnitsMeasurements.Caption = "Units";
            this.Store_UnitsMeasurements.Description = "[Store] Units Measurement";
            this.Store_UnitsMeasurements.Id = 555;
            this.Store_UnitsMeasurements.Name = "Store_UnitsMeasurements";
            this.Store_UnitsMeasurements.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_UnitsMeasurements_ItemClick);
            // 
            // Store_Origins
            // 
            this.Store_Origins.Caption = "Origins";
            this.Store_Origins.Description = "[Store] Store Origin Countries";
            this.Store_Origins.Id = 556;
            this.Store_Origins.Name = "Store_Origins";
            // 
            // bar_AutomaticUpdate
            // 
            this.bar_AutomaticUpdate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.bar_AutomaticUpdate.Caption = "Update MachineEyes";
            this.bar_AutomaticUpdate.Id = 557;
            this.bar_AutomaticUpdate.ImageIndex = 64;
            this.bar_AutomaticUpdate.Name = "bar_AutomaticUpdate";
            this.bar_AutomaticUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_AutomaticUpdate_ItemClick);
            // 
            // barSubItem_FinancialYears
            // 
            this.barSubItem_FinancialYears.Caption = "Year";
            this.barSubItem_FinancialYears.Id = 558;
            this.barSubItem_FinancialYears.LargeImageIndex = 318;
            this.barSubItem_FinancialYears.Name = "barSubItem_FinancialYears";
            // 
            // barButtonItem_GreigeArticle
            // 
            this.barButtonItem_GreigeArticle.Caption = "Greige Articles";
            this.barButtonItem_GreigeArticle.Description = "[Planning] Greige Articles";
            this.barButtonItem_GreigeArticle.Id = 559;
            this.barButtonItem_GreigeArticle.ImageIndex = 20;
            this.barButtonItem_GreigeArticle.LargeImageIndex = 20;
            this.barButtonItem_GreigeArticle.Name = "barButtonItem_GreigeArticle";
            this.barButtonItem_GreigeArticle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_GreigeArticle_ItemClick);
            // 
            // Accounts_ChartOfAccount_TabView
            // 
            this.Accounts_ChartOfAccount_TabView.Caption = "Chart of Accounts Tab View";
            this.Accounts_ChartOfAccount_TabView.Description = "[Accounts and Finance] Chart of Accounts Tab View";
            this.Accounts_ChartOfAccount_TabView.Id = 564;
            this.Accounts_ChartOfAccount_TabView.Name = "Accounts_ChartOfAccount_TabView";
            this.Accounts_ChartOfAccount_TabView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Accounts_ChartOfAccount_TabView_ItemClick);
            // 
            // PO_Greige
            // 
            this.PO_Greige.Caption = "Greige";
            this.PO_Greige.Description = "[Planning] Greige P/O";
            this.PO_Greige.Id = 567;
            this.PO_Greige.LargeImageIndex = 71;
            this.PO_Greige.Name = "PO_Greige";
            this.PO_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.PO_Greige_ItemClick);
            // 
            // MDC
            // 
            this.MDC.Caption = "MDC";
            this.MDC.Id = 568;
            this.MDC.LargeImageIndex = 7;
            this.MDC.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.MDC_CashPaymentVoucher),
            new DevExpress.XtraBars.LinkPersistInfo(this.MDC_BankPaymentVoucher),
            new DevExpress.XtraBars.LinkPersistInfo(this.MDC_CashReceiptVoucher),
            new DevExpress.XtraBars.LinkPersistInfo(this.MDC_BankReceiptVoucher),
            new DevExpress.XtraBars.LinkPersistInfo(this.MDC_JournalVoucher)});
            this.MDC.Name = "MDC";
            // 
            // MDC_CashPaymentVoucher
            // 
            this.MDC_CashPaymentVoucher.Caption = "Cash Payment Voucher";
            this.MDC_CashPaymentVoucher.Description = "[Accounts and Finance] Cash Payment Voucher";
            this.MDC_CashPaymentVoucher.Id = 569;
            this.MDC_CashPaymentVoucher.Name = "MDC_CashPaymentVoucher";
            this.MDC_CashPaymentVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MDC_CashPaymentVoucher_ItemClick);
            // 
            // MDC_BankPaymentVoucher
            // 
            this.MDC_BankPaymentVoucher.Caption = "Bank Payment Voucher";
            this.MDC_BankPaymentVoucher.Description = "[Accounts and Finance] Bank Payment Voucher";
            this.MDC_BankPaymentVoucher.Id = 570;
            this.MDC_BankPaymentVoucher.Name = "MDC_BankPaymentVoucher";
            this.MDC_BankPaymentVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MDC_BankPaymentVoucher_ItemClick);
            // 
            // MDC_CashReceiptVoucher
            // 
            this.MDC_CashReceiptVoucher.Caption = "Cash Receipt Voucher";
            this.MDC_CashReceiptVoucher.Description = "[Accounts and Finance] Cash Receipt Voucher";
            this.MDC_CashReceiptVoucher.Id = 573;
            this.MDC_CashReceiptVoucher.Name = "MDC_CashReceiptVoucher";
            this.MDC_CashReceiptVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MDC_CashReceiptVoucher_ItemClick);
            // 
            // MDC_BankReceiptVoucher
            // 
            this.MDC_BankReceiptVoucher.Caption = "Bank Receipt Voucher";
            this.MDC_BankReceiptVoucher.Description = "[Accounts and Finance] Bank Receipt Voucher";
            this.MDC_BankReceiptVoucher.Id = 574;
            this.MDC_BankReceiptVoucher.Name = "MDC_BankReceiptVoucher";
            this.MDC_BankReceiptVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MDC_BankReceiptVoucher_ItemClick);
            // 
            // MDC_JournalVoucher
            // 
            this.MDC_JournalVoucher.Caption = "Journal Voucher";
            this.MDC_JournalVoucher.Description = "[Accounts and Finance] Journal Voucher";
            this.MDC_JournalVoucher.Id = 575;
            this.MDC_JournalVoucher.Name = "MDC_JournalVoucher";
            this.MDC_JournalVoucher.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MDC_JournalVoucher_ItemClick);
            // 
            // barListItem1
            // 
            this.barListItem1.Caption = "-";
            this.barListItem1.Id = 571;
            this.barListItem1.Name = "barListItem1";
            // 
            // barLinkContainerItem2
            // 
            this.barLinkContainerItem2.Caption = "Payments";
            this.barLinkContainerItem2.Id = 572;
            this.barLinkContainerItem2.Name = "barLinkContainerItem2";
            // 
            // SaveAsDefaultSkin
            // 
            this.SaveAsDefaultSkin.Caption = "Save As Default Skin";
            this.SaveAsDefaultSkin.Description = "[Display] Save skin in profile";
            this.SaveAsDefaultSkin.Id = 576;
            this.SaveAsDefaultSkin.Name = "SaveAsDefaultSkin";
            toolTipTitleItem4.Text = "Save Profile";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "Click this button to save your profile / theme to your account ....this theme wil" +
    "l be used as your default profile at next login....";
            superToolTip3.Items.Add(toolTipTitleItem4);
            superToolTip3.Items.Add(toolTipItem3);
            this.SaveAsDefaultSkin.SuperTip = superToolTip3;
            this.SaveAsDefaultSkin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveAsDefaultSkin_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 580;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // Button_Towel_OpeningOutward
            // 
            this.Button_Towel_OpeningOutward.Id = 588;
            this.Button_Towel_OpeningOutward.Name = "Button_Towel_OpeningOutward";
            // 
            // barSubItem_Towel_OpeningMenu
            // 
            this.barSubItem_Towel_OpeningMenu.Caption = "Opening";
            this.barSubItem_Towel_OpeningMenu.Id = 590;
            this.barSubItem_Towel_OpeningMenu.LargeImageIndex = 319;
            this.barSubItem_Towel_OpeningMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Opening_Inward_Towel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Opening_OutWard_Towel)});
            this.barSubItem_Towel_OpeningMenu.Name = "barSubItem_Towel_OpeningMenu";
            // 
            // barButtonItem_Opening_Inward_Towel
            // 
            this.barButtonItem_Opening_Inward_Towel.Caption = "Inward";
            this.barButtonItem_Opening_Inward_Towel.Description = "[Inspection & Dispatch (Towel)] Opening Inward";
            this.barButtonItem_Opening_Inward_Towel.Id = 594;
            this.barButtonItem_Opening_Inward_Towel.Name = "barButtonItem_Opening_Inward_Towel";
            this.barButtonItem_Opening_Inward_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Opening_Inward_Towel_ItemClick);
            // 
            // barButtonItem_Opening_OutWard_Towel
            // 
            this.barButtonItem_Opening_OutWard_Towel.Caption = "OutWard";
            this.barButtonItem_Opening_OutWard_Towel.Description = "[Inspection & Dispatch (Towel)] Opening Outward";
            this.barButtonItem_Opening_OutWard_Towel.Id = 595;
            this.barButtonItem_Opening_OutWard_Towel.Name = "barButtonItem_Opening_OutWard_Towel";
            this.barButtonItem_Opening_OutWard_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Opening_OutWard_Towel_ItemClick);
            // 
            // barButtonItem_Towel_Inspection
            // 
            this.barButtonItem_Towel_Inspection.Caption = "Inspection";
            this.barButtonItem_Towel_Inspection.Description = "[Inspection & Dispatch (Towel)] Inspection";
            this.barButtonItem_Towel_Inspection.Id = 591;
            this.barButtonItem_Towel_Inspection.LargeImageIndex = 320;
            this.barButtonItem_Towel_Inspection.Name = "barButtonItem_Towel_Inspection";
            this.barButtonItem_Towel_Inspection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Towel_Inspection_ItemClick);
            // 
            // barButtonItem_PackingList_Towel
            // 
            this.barButtonItem_PackingList_Towel.Caption = "Packing List";
            this.barButtonItem_PackingList_Towel.Description = "[Inspection & Dispatch (Towel)] Packing List";
            this.barButtonItem_PackingList_Towel.Id = 593;
            this.barButtonItem_PackingList_Towel.LargeImageIndex = 321;
            this.barButtonItem_PackingList_Towel.Name = "barButtonItem_PackingList_Towel";
            this.barButtonItem_PackingList_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_PackingList_Towel_ItemClick);
            // 
            // barSubItem_Reports_Towel
            // 
            this.barSubItem_Reports_Towel.Caption = "Reports";
            this.barSubItem_Reports_Towel.Id = 597;
            this.barSubItem_Reports_Towel.LargeImageIndex = 323;
            this.barSubItem_Reports_Towel.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_ArticleBinCard_Towel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_POBinCard_Towel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_DailyContractPosition_Towel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_StockReport_Towel),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_YarnBalanceSummary_Towel)});
            this.barSubItem_Reports_Towel.Name = "barSubItem_Reports_Towel";
            // 
            // barButtonItem_ArticleBinCard_Towel
            // 
            this.barButtonItem_ArticleBinCard_Towel.Caption = "Article Bin Card";
            this.barButtonItem_ArticleBinCard_Towel.Description = "[Inspection & Dispatch (Towel)] Article Bin Card";
            this.barButtonItem_ArticleBinCard_Towel.Id = 598;
            this.barButtonItem_ArticleBinCard_Towel.Name = "barButtonItem_ArticleBinCard_Towel";
            this.barButtonItem_ArticleBinCard_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_ArticleBinCard_Towel_ItemClick);
            // 
            // barButtonItem_POBinCard_Towel
            // 
            this.barButtonItem_POBinCard_Towel.Caption = "PO Bin Card";
            this.barButtonItem_POBinCard_Towel.Description = "[Inspection & Dispatch (Towel)] PO Bin Card";
            this.barButtonItem_POBinCard_Towel.Id = 599;
            this.barButtonItem_POBinCard_Towel.Name = "barButtonItem_POBinCard_Towel";
            this.barButtonItem_POBinCard_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_POBinCard_Towel_ItemClick);
            // 
            // barButtonItem_DailyContractPosition_Towel
            // 
            this.barButtonItem_DailyContractPosition_Towel.Caption = "Daily Contract Position";
            this.barButtonItem_DailyContractPosition_Towel.Description = "[Inspection & Dispatch (Towel)] Daily Contract Position";
            this.barButtonItem_DailyContractPosition_Towel.Id = 600;
            this.barButtonItem_DailyContractPosition_Towel.Name = "barButtonItem_DailyContractPosition_Towel";
            this.barButtonItem_DailyContractPosition_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_DailyContractPosition_Towel_ItemClick);
            // 
            // barButtonItem_StockReport_Towel
            // 
            this.barButtonItem_StockReport_Towel.Caption = "Towel Stock Report";
            this.barButtonItem_StockReport_Towel.Description = "[Inspection & Dispatch (Towel)] Towel Stock Report";
            this.barButtonItem_StockReport_Towel.Id = 601;
            this.barButtonItem_StockReport_Towel.Name = "barButtonItem_StockReport_Towel";
            this.barButtonItem_StockReport_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_StockReport_Towel_ItemClick);
            // 
            // barButtonItem_YarnBalanceSummary_Towel
            // 
            this.barButtonItem_YarnBalanceSummary_Towel.Caption = "Yarn Balance Summary";
            this.barButtonItem_YarnBalanceSummary_Towel.Description = "[Inspection & Dispatch (Towel)] Yarn Balance Summary";
            this.barButtonItem_YarnBalanceSummary_Towel.Id = 602;
            this.barButtonItem_YarnBalanceSummary_Towel.Name = "barButtonItem_YarnBalanceSummary_Towel";
            this.barButtonItem_YarnBalanceSummary_Towel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_YarnBalanceSummary_Towel_ItemClick);
            // 
            // barButtonItem_Inspection_Greige
            // 
            this.barButtonItem_Inspection_Greige.Caption = "Inspection";
            this.barButtonItem_Inspection_Greige.Description = "[Inspection & Dispatch (Greige)] Inspection";
            this.barButtonItem_Inspection_Greige.Id = 603;
            this.barButtonItem_Inspection_Greige.LargeImageIndex = 41;
            this.barButtonItem_Inspection_Greige.Name = "barButtonItem_Inspection_Greige";
            this.barButtonItem_Inspection_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Inspection_Greige_ItemClick);
            // 
            // barButtonItem_TaketoGodown_Greige
            // 
            this.barButtonItem_TaketoGodown_Greige.Caption = "Take to Godown";
            this.barButtonItem_TaketoGodown_Greige.Description = "[Inspection & Dispatch (Greige)] Take to Godown";
            this.barButtonItem_TaketoGodown_Greige.Id = 604;
            this.barButtonItem_TaketoGodown_Greige.LargeImageIndex = 56;
            this.barButtonItem_TaketoGodown_Greige.Name = "barButtonItem_TaketoGodown_Greige";
            this.barButtonItem_TaketoGodown_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_TaketoGodown_Greige_ItemClick);
            // 
            // barButtonItem_PackingList_Greige
            // 
            this.barButtonItem_PackingList_Greige.Caption = "Packing List";
            this.barButtonItem_PackingList_Greige.Description = "[Inspection & Dispatch (Greige)] Packing List";
            this.barButtonItem_PackingList_Greige.Id = 605;
            this.barButtonItem_PackingList_Greige.LargeImageIndex = 71;
            this.barButtonItem_PackingList_Greige.Name = "barButtonItem_PackingList_Greige";
            this.barButtonItem_PackingList_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_PackingList_Greige_ItemClick);
            // 
            // barSubItem_Opening_Greige_Menu
            // 
            this.barSubItem_Opening_Greige_Menu.Caption = "Opening";
            this.barSubItem_Opening_Greige_Menu.Id = 606;
            this.barSubItem_Opening_Greige_Menu.LargeImageIndex = 43;
            this.barSubItem_Opening_Greige_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Opening_Inward_Greige),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem_Opening_OutWard_Greige)});
            this.barSubItem_Opening_Greige_Menu.Name = "barSubItem_Opening_Greige_Menu";
            // 
            // barButtonItem_Opening_Inward_Greige
            // 
            this.barButtonItem_Opening_Inward_Greige.Caption = "Inward";
            this.barButtonItem_Opening_Inward_Greige.Description = "[Inspection & Dispatch (Greige)] Opening Inward";
            this.barButtonItem_Opening_Inward_Greige.Id = 607;
            this.barButtonItem_Opening_Inward_Greige.Name = "barButtonItem_Opening_Inward_Greige";
            this.barButtonItem_Opening_Inward_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Opening_Inward_Greige_ItemClick);
            // 
            // barButtonItem_Opening_OutWard_Greige
            // 
            this.barButtonItem_Opening_OutWard_Greige.Caption = "OutWard";
            this.barButtonItem_Opening_OutWard_Greige.Description = "[Inspection & Dispatch (Greige)] Opening Outward";
            this.barButtonItem_Opening_OutWard_Greige.Id = 608;
            this.barButtonItem_Opening_OutWard_Greige.Name = "barButtonItem_Opening_OutWard_Greige";
            this.barButtonItem_Opening_OutWard_Greige.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_Opening_OutWard_Greige_ItemClick);
            // 
            // barSubItem_Reports_Greige_Menu
            // 
            this.barSubItem_Reports_Greige_Menu.Caption = "Reports";
            this.barSubItem_Reports_Greige_Menu.Id = 610;
            this.barSubItem_Reports_Greige_Menu.LargeImageIndex = 217;
            this.barSubItem_Reports_Greige_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Greige_ArticleBinCard),
            new DevExpress.XtraBars.LinkPersistInfo(this.Greige_CurrentContractsPosition),
            new DevExpress.XtraBars.LinkPersistInfo(this.Greige_ContractAcitivtySheet_Report)});
            this.barSubItem_Reports_Greige_Menu.Name = "barSubItem_Reports_Greige_Menu";
            // 
            // Greige_ArticleBinCard
            // 
            this.Greige_ArticleBinCard.Caption = "Article Bin Card";
            this.Greige_ArticleBinCard.Description = "[Inspection & Dispatch (Greige)] Article Bin Card";
            this.Greige_ArticleBinCard.Id = 622;
            this.Greige_ArticleBinCard.Name = "Greige_ArticleBinCard";
            this.Greige_ArticleBinCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Greige_ArticleBinCard_ItemClick);
            // 
            // Greige_CurrentContractsPosition
            // 
            this.Greige_CurrentContractsPosition.Caption = "Current Contracts Position";
            this.Greige_CurrentContractsPosition.Description = "[Inspection & Dispatch (Greige)] Current Contract Position";
            this.Greige_CurrentContractsPosition.Id = 623;
            this.Greige_CurrentContractsPosition.Name = "Greige_CurrentContractsPosition";
            this.Greige_CurrentContractsPosition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Greige_CurrentContractsPosition_ItemClick);
            // 
            // Greige_ContractAcitivtySheet_Report
            // 
            this.Greige_ContractAcitivtySheet_Report.Caption = "Contract Activity Sheet";
            this.Greige_ContractAcitivtySheet_Report.Description = "[Inspection & Dispatch (Greige)] Contract Activity Sheet";
            this.Greige_ContractAcitivtySheet_Report.Id = 624;
            this.Greige_ContractAcitivtySheet_Report.Name = "Greige_ContractAcitivtySheet_Report";
            this.Greige_ContractAcitivtySheet_Report.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Greige_ContractAcitivtySheet_Report_ItemClick);
            // 
            // barButtonItem_JacquardArticles
            // 
            this.barButtonItem_JacquardArticles.Caption = "Jacquard Articles";
            this.barButtonItem_JacquardArticles.Description = "[Planning] Jacquard Articles";
            this.barButtonItem_JacquardArticles.Id = 611;
            this.barButtonItem_JacquardArticles.LargeImageIndex = 0;
            this.barButtonItem_JacquardArticles.Name = "barButtonItem_JacquardArticles";
            this.barButtonItem_JacquardArticles.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_JacquardArticles_ItemClick);
            // 
            // Inspection_OutsideWeaving
            // 
            this.Inspection_OutsideWeaving.Caption = "Inspection Outside Weaving";
            this.Inspection_OutsideWeaving.Description = "[Inspection & Dispatch (Greige)] Inspection Outside Weaving";
            this.Inspection_OutsideWeaving.Id = 621;
            this.Inspection_OutsideWeaving.LargeImageIndex = 29;
            this.Inspection_OutsideWeaving.Name = "Inspection_OutsideWeaving";
            this.Inspection_OutsideWeaving.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Inspection_OutsideWeaving_ItemClick);
            // 
            // Greige_FabricReturn
            // 
            this.Greige_FabricReturn.Caption = "Fabric Return";
            this.Greige_FabricReturn.Description = "[Inspection & Dispatch (Greige)] Fabric Return";
            this.Greige_FabricReturn.Id = 625;
            this.Greige_FabricReturn.LargeImageIndex = 32;
            this.Greige_FabricReturn.Name = "Greige_FabricReturn";
            this.Greige_FabricReturn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Greige_FabricReturn_ItemClick);
            // 
            // Greige_ReCheck
            // 
            this.Greige_ReCheck.Caption = "Re-Check";
            this.Greige_ReCheck.Description = "[Inspection & Dispatch (Greige)] Re-Check Fabric Returned";
            this.Greige_ReCheck.Id = 626;
            this.Greige_ReCheck.LargeImageIndex = 21;
            this.Greige_ReCheck.Name = "Greige_ReCheck";
            this.Greige_ReCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Greige_ReCheck_ItemClick);
            // 
            // rpi_BeamContraction
            // 
            this.rpi_BeamContraction.Caption = "Beam Contraction Report";
            this.rpi_BeamContraction.Id = 632;
            this.rpi_BeamContraction.Name = "rpi_BeamContraction";
            // 
            // YarnReports_Menu
            // 
            this.YarnReports_Menu.Caption = "Yarn Reports";
            this.YarnReports_Menu.Id = 636;
            this.YarnReports_Menu.LargeImageIndex = 71;
            this.YarnReports_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnReports_POSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnPartyStockReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnPartyWiseStockSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnDepartmentStockSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnGodownOrPartitionStockSummary),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnItemLedgerReport),
            new DevExpress.XtraBars.LinkPersistInfo(this.SizingYarnLedger)});
            this.YarnReports_Menu.MenuCaption = "Yarn Reports";
            this.YarnReports_Menu.Name = "YarnReports_Menu";
            // 
            // YarnReports_POSummary
            // 
            this.YarnReports_POSummary.Caption = "P/O Summary";
            this.YarnReports_POSummary.Description = "[Yarn Management] Report: P/O Sumamry";
            this.YarnReports_POSummary.Id = 637;
            this.YarnReports_POSummary.Name = "YarnReports_POSummary";
            this.YarnReports_POSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnReports_POSummary_ItemClick);
            // 
            // bbiYarnPartyStockReport
            // 
            this.bbiYarnPartyStockReport.Caption = "Account Stock Summary";
            this.bbiYarnPartyStockReport.Description = "[Yarn Management] Report: Account Stock Summary";
            this.bbiYarnPartyStockReport.Id = 662;
            this.bbiYarnPartyStockReport.Name = "bbiYarnPartyStockReport";
            this.bbiYarnPartyStockReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnPartyStockReport_ItemClick);
            // 
            // bbiYarnPartyWiseStockSummary
            // 
            this.bbiYarnPartyWiseStockSummary.Caption = "Party Wise Stock Summary";
            this.bbiYarnPartyWiseStockSummary.Description = "[Yarn Management] Report: Party Wise Stock Summary";
            this.bbiYarnPartyWiseStockSummary.Id = 664;
            this.bbiYarnPartyWiseStockSummary.Name = "bbiYarnPartyWiseStockSummary";
            this.bbiYarnPartyWiseStockSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnPartyWiseStockSummary_ItemClick);
            // 
            // bbiYarnDepartmentStockSummary
            // 
            this.bbiYarnDepartmentStockSummary.Caption = "Department Stock Summary";
            this.bbiYarnDepartmentStockSummary.Description = "[Yarn Management] Report: Department Stock Summary";
            this.bbiYarnDepartmentStockSummary.Id = 668;
            this.bbiYarnDepartmentStockSummary.Name = "bbiYarnDepartmentStockSummary";
            this.bbiYarnDepartmentStockSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnDepartmentStockSummary_ItemClick);
            // 
            // bbiYarnGodownOrPartitionStockSummary
            // 
            this.bbiYarnGodownOrPartitionStockSummary.Caption = "Godown / Partition Stock Summary";
            this.bbiYarnGodownOrPartitionStockSummary.Description = "[Yarn Management] Report: Godown / Partition Stock Summary";
            this.bbiYarnGodownOrPartitionStockSummary.Id = 669;
            this.bbiYarnGodownOrPartitionStockSummary.Name = "bbiYarnGodownOrPartitionStockSummary";
            this.bbiYarnGodownOrPartitionStockSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnGodownOrPartitionStockSummary_ItemClick);
            // 
            // bbiYarnItemLedgerReport
            // 
            this.bbiYarnItemLedgerReport.Caption = "Yarn Item Ledger";
            this.bbiYarnItemLedgerReport.Description = "[Yarn Management] Report: Yarn item ledger";
            this.bbiYarnItemLedgerReport.Id = 670;
            this.bbiYarnItemLedgerReport.Name = "bbiYarnItemLedgerReport";
            this.bbiYarnItemLedgerReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnItemLedgerReport_ItemClick);
            // 
            // SizingYarnLedger
            // 
            this.SizingYarnLedger.Caption = "Sizing Yarn Ledger";
            this.SizingYarnLedger.Description = "[Yarn Management] Report: Sizing Yarn Ledger";
            this.SizingYarnLedger.Id = 696;
            this.SizingYarnLedger.Name = "SizingYarnLedger";
            this.SizingYarnLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SizingYarnLedger_ItemClick);
            // 
            // Yarn_ReturnToParty
            // 
            this.Yarn_ReturnToParty.Caption = "Return";
            this.Yarn_ReturnToParty.Description = "[Yarn Management] Yarn Return to Party";
            this.Yarn_ReturnToParty.Id = 638;
            this.Yarn_ReturnToParty.LargeImageIndex = 119;
            this.Yarn_ReturnToParty.Name = "Yarn_ReturnToParty";
            this.Yarn_ReturnToParty.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Yarn_ReturnToParty_ItemClick);
            // 
            // YarnInward
            // 
            this.YarnInward.Caption = "Inward";
            this.YarnInward.Description = "[Yarn Management] Yarn Inward";
            this.YarnInward.Id = 639;
            this.YarnInward.LargeImageIndex = 174;
            this.YarnInward.Name = "YarnInward";
            this.YarnInward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnInward_ItemClick);
            // 
            // YarnOutward
            // 
            this.YarnOutward.Caption = "Outward";
            this.YarnOutward.Description = "[Yarn Management] Yarn Outward";
            this.YarnOutward.Id = 640;
            this.YarnOutward.LargeImageIndex = 177;
            this.YarnOutward.Name = "YarnOutward";
            this.YarnOutward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnOutward_ItemClick);
            // 
            // SizingWorkOrderButton
            // 
            this.SizingWorkOrderButton.Caption = "Sizing Work Order";
            this.SizingWorkOrderButton.Description = "[Planning] Sizing Work Order Sheet";
            this.SizingWorkOrderButton.Id = 641;
            this.SizingWorkOrderButton.LargeImageIndex = 7;
            this.SizingWorkOrderButton.Name = "SizingWorkOrderButton";
            this.SizingWorkOrderButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SizingWorkOrderButton_ItemClick);
            // 
            // DoublingMenu
            // 
            this.DoublingMenu.Caption = "Doubling";
            this.DoublingMenu.Id = 643;
            this.DoublingMenu.LargeImageIndex = 324;
            this.DoublingMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.IssuetoDoubling),
            new DevExpress.XtraBars.LinkPersistInfo(this.ReceiveFromDoubling),
            new DevExpress.XtraBars.LinkPersistInfo(this.DoublingWorkOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.DoublingAdjustmentNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDoublingWorkOrderLedger),
            new DevExpress.XtraBars.LinkPersistInfo(this.DoublingWorkOrdersSummary)});
            this.DoublingMenu.Name = "DoublingMenu";
            // 
            // IssuetoDoubling
            // 
            this.IssuetoDoubling.Caption = "Issue to Doubling";
            this.IssuetoDoubling.Description = "[Yarn Management] Doubling Issue Note";
            this.IssuetoDoubling.Id = 644;
            this.IssuetoDoubling.Name = "IssuetoDoubling";
            this.IssuetoDoubling.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.IssuetoDoubling_ItemClick);
            // 
            // ReceiveFromDoubling
            // 
            this.ReceiveFromDoubling.Caption = "Receive from Doubling";
            this.ReceiveFromDoubling.Description = "[Yarn Management] Doubling Receive Note";
            this.ReceiveFromDoubling.Id = 645;
            this.ReceiveFromDoubling.Name = "ReceiveFromDoubling";
            this.ReceiveFromDoubling.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ReceiveFromDoubling_ItemClick);
            // 
            // DoublingWorkOrder
            // 
            this.DoublingWorkOrder.Caption = "Doubling Work Order";
            this.DoublingWorkOrder.Description = "[Yarn Management] Doubling Work Order";
            this.DoublingWorkOrder.Id = 646;
            this.DoublingWorkOrder.Name = "DoublingWorkOrder";
            this.DoublingWorkOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DoublingWorkOrder_ItemClick);
            // 
            // DoublingAdjustmentNote
            // 
            this.DoublingAdjustmentNote.Caption = "Doubling Adjustment";
            this.DoublingAdjustmentNote.Description = "[Yarn Management] Report: Doubling Adjustment Note";
            this.DoublingAdjustmentNote.Id = 685;
            this.DoublingAdjustmentNote.Name = "DoublingAdjustmentNote";
            this.DoublingAdjustmentNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DoublingAdjustmentNote_ItemClick);
            // 
            // YarnDoublingWorkOrderLedger
            // 
            this.YarnDoublingWorkOrderLedger.Caption = "Work Order Ledger";
            this.YarnDoublingWorkOrderLedger.Description = "[Yarn Management] Report: Doubling Work Order Ledger";
            this.YarnDoublingWorkOrderLedger.Id = 684;
            this.YarnDoublingWorkOrderLedger.Name = "YarnDoublingWorkOrderLedger";
            this.YarnDoublingWorkOrderLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDoublingWorkOrderLedger_ItemClick);
            // 
            // DoublingWorkOrdersSummary
            // 
            this.DoublingWorkOrdersSummary.Caption = "Work Orders Summary";
            this.DoublingWorkOrdersSummary.Description = "[Yarn Management] Report: Doubling Work Orders Summary";
            this.DoublingWorkOrdersSummary.Id = 686;
            this.DoublingWorkOrdersSummary.Name = "DoublingWorkOrdersSummary";
            this.DoublingWorkOrdersSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DoublingWorkOrdersSummary_ItemClick);
            // 
            // MovetoPO
            // 
            this.MovetoPO.Caption = "Move Between P/O ";
            this.MovetoPO.Id = 647;
            this.MovetoPO.LargeImageIndex = 325;
            this.MovetoPO.Name = "MovetoPO";
            this.MovetoPO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MovetoPO_ItemClick);
            // 
            // ReportsMenuContracts
            // 
            this.ReportsMenuContracts.Caption = "Reports";
            this.ReportsMenuContracts.Id = 649;
            this.ReportsMenuContracts.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.GreigeContractsList),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiTowelContractsList)});
            this.ReportsMenuContracts.Name = "ReportsMenuContracts";
            // 
            // GreigeContractsList
            // 
            this.GreigeContractsList.Caption = "Greige Contracts List";
            this.GreigeContractsList.Description = "[Planning] Greige Contracts List";
            this.GreigeContractsList.Id = 650;
            this.GreigeContractsList.Name = "GreigeContractsList";
            this.GreigeContractsList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.GreigeContractsList_ItemClick);
            // 
            // bbiTowelContractsList
            // 
            this.bbiTowelContractsList.Caption = "Towel Contracts List";
            this.bbiTowelContractsList.Description = "[Planning] Towel Contracts List";
            this.bbiTowelContractsList.Id = 663;
            this.bbiTowelContractsList.Name = "bbiTowelContractsList";
            this.bbiTowelContractsList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTowelContractsList_ItemClick);
            // 
            // DenimArticlesAdd
            // 
            this.DenimArticlesAdd.Caption = "Denim Articles";
            this.DenimArticlesAdd.Description = "[Planning] Denim Articles";
            this.DenimArticlesAdd.Id = 651;
            this.DenimArticlesAdd.LargeImageIndex = 25;
            this.DenimArticlesAdd.Name = "DenimArticlesAdd";
            this.DenimArticlesAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DenimArticlesAdd_ItemClick);
            // 
            // FontSizeControl
            // 
            this.FontSizeControl.Caption = "Font Size";
            this.FontSizeControl.Edit = this.repositoryItemSpinEdit2;
            this.FontSizeControl.EditValue = "12";
            this.FontSizeControl.Id = 658;
            this.FontSizeControl.Name = "FontSizeControl";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            this.repositoryItemSpinEdit2.UseParentBackground = true;
            // 
            // bbi_SMSDeviceAndServiceStatus
            // 
            this.bbi_SMSDeviceAndServiceStatus.Caption = "Device Status";
            this.bbi_SMSDeviceAndServiceStatus.Description = "[SMS] SMS Device and Service Status";
            this.bbi_SMSDeviceAndServiceStatus.Id = 660;
            this.bbi_SMSDeviceAndServiceStatus.Name = "bbi_SMSDeviceAndServiceStatus";
            this.bbi_SMSDeviceAndServiceStatus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbi_SMSDeviceAndServiceStatus_ItemClick);
            // 
            // bbiYarnOpeningPlus
            // 
            this.bbiYarnOpeningPlus.Caption = "Opening +";
            this.bbiYarnOpeningPlus.Description = "[Yarn Management] Yarn Opening +";
            this.bbiYarnOpeningPlus.Id = 661;
            this.bbiYarnOpeningPlus.LargeImageIndex = 91;
            this.bbiYarnOpeningPlus.Name = "bbiYarnOpeningPlus";
            this.bbiYarnOpeningPlus.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnOpeningPlus_ItemClick);
            // 
            // bbiYarnIssueBetweenParties
            // 
            this.bbiYarnIssueBetweenParties.Caption = "Move Between Parties";
            this.bbiYarnIssueBetweenParties.Description = "[Yarn Management] Yarn Issue Between Parties";
            this.bbiYarnIssueBetweenParties.Id = 665;
            this.bbiYarnIssueBetweenParties.LargeImageIndex = 236;
            this.bbiYarnIssueBetweenParties.Name = "bbiYarnIssueBetweenParties";
            this.bbiYarnIssueBetweenParties.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiYarnIssueBetweenParties_ItemClick);
            // 
            // MenuYarnInwardOutward
            // 
            this.MenuYarnInwardOutward.Caption = "I/O";
            this.MenuYarnInwardOutward.Id = 666;
            this.MenuYarnInwardOutward.LargeImageIndex = 99;
            this.MenuYarnInwardOutward.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnOpeningPlus),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnInward),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnOutward),
            new DevExpress.XtraBars.LinkPersistInfo(this.Yarn_ReturnToParty),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4)});
            this.MenuYarnInwardOutward.Name = "MenuYarnInwardOutward";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Sale Contract";
            this.barButtonItem4.Id = 726;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // MenuYarnReceiveIssue
            // 
            this.MenuYarnReceiveIssue.Caption = "R/I";
            this.MenuYarnReceiveIssue.Id = 667;
            this.MenuYarnReceiveIssue.LargeImageIndex = 89;
            this.MenuYarnReceiveIssue.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnReceiveNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnIssueNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiYarnIssueBetweenParties),
            new DevExpress.XtraBars.LinkPersistInfo(this.MovetoPO)});
            this.MenuYarnReceiveIssue.Name = "MenuYarnReceiveIssue";
            // 
            // WeaverGroupsManagement
            // 
            this.WeaverGroupsManagement.Caption = "Groups Mangement";
            this.WeaverGroupsManagement.Description = "[Dashboard] Weavers Groups Management";
            this.WeaverGroupsManagement.Id = 674;
            this.WeaverGroupsManagement.Name = "WeaverGroupsManagement";
            this.WeaverGroupsManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.WeaverGroupsManagement_ItemClick);
            // 
            // StoreLocations
            // 
            this.StoreLocations.Caption = "Store Locations";
            this.StoreLocations.Description = "[Store] Store Locations";
            this.StoreLocations.Id = 676;
            this.StoreLocations.Name = "StoreLocations";
            this.StoreLocations.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.StoreLocations_ItemClick);
            // 
            // DepartmentRequisitionSlip
            // 
            this.DepartmentRequisitionSlip.Caption = "Department Requisition";
            this.DepartmentRequisitionSlip.Description = "[Store] Department Store Requisition";
            this.DepartmentRequisitionSlip.Id = 679;
            this.DepartmentRequisitionSlip.LargeImageIndex = 80;
            this.DepartmentRequisitionSlip.Name = "DepartmentRequisitionSlip";
            this.DepartmentRequisitionSlip.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DepartmentRequisitionSlip_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 681;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // YarnDyingMenu
            // 
            this.YarnDyingMenu.Caption = "Yarn Dying";
            this.YarnDyingMenu.Id = 687;
            this.YarnDyingMenu.LargeImageIndex = 326;
            this.YarnDyingMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingIssueNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingReceiveNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingWorkOrder),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingAdjustmentNote),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingWorkOrderLedger),
            new DevExpress.XtraBars.LinkPersistInfo(this.YarnDyingWorkOrderSummary)});
            this.YarnDyingMenu.Name = "YarnDyingMenu";
            // 
            // YarnDyingIssueNote
            // 
            this.YarnDyingIssueNote.Caption = "Issue to Yarn Dying";
            this.YarnDyingIssueNote.Description = "[Yarn Management] Yarn Dying Issue Note";
            this.YarnDyingIssueNote.Id = 688;
            this.YarnDyingIssueNote.Name = "YarnDyingIssueNote";
            this.YarnDyingIssueNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingIssueNote_ItemClick);
            // 
            // YarnDyingReceiveNote
            // 
            this.YarnDyingReceiveNote.Caption = "Receive from Yarn Dying";
            this.YarnDyingReceiveNote.Description = "[Yarn Management] Yarn Dying Receive Note";
            this.YarnDyingReceiveNote.Id = 689;
            this.YarnDyingReceiveNote.Name = "YarnDyingReceiveNote";
            this.YarnDyingReceiveNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingReceiveNote_ItemClick);
            // 
            // YarnDyingWorkOrder
            // 
            this.YarnDyingWorkOrder.Caption = "Yarn Dying Work Order";
            this.YarnDyingWorkOrder.Description = "[Yarn Management] Yarn Dying Work Order";
            this.YarnDyingWorkOrder.Id = 690;
            this.YarnDyingWorkOrder.Name = "YarnDyingWorkOrder";
            this.YarnDyingWorkOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingWorkOrder_ItemClick);
            // 
            // YarnDyingAdjustmentNote
            // 
            this.YarnDyingAdjustmentNote.Caption = "Yarn Dying Adjustment";
            this.YarnDyingAdjustmentNote.Description = "[Yarn Management] Yarn Dying Adjustment Note";
            this.YarnDyingAdjustmentNote.Id = 691;
            this.YarnDyingAdjustmentNote.Name = "YarnDyingAdjustmentNote";
            this.YarnDyingAdjustmentNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingAdjustmentNote_ItemClick);
            // 
            // YarnDyingWorkOrderLedger
            // 
            this.YarnDyingWorkOrderLedger.Caption = "Yarn Dying Work Order Ledger";
            this.YarnDyingWorkOrderLedger.Description = "[Yarn Management] Yarn Dying Work Order Ledger";
            this.YarnDyingWorkOrderLedger.Id = 692;
            this.YarnDyingWorkOrderLedger.Name = "YarnDyingWorkOrderLedger";
            this.YarnDyingWorkOrderLedger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingWorkOrderLedger_ItemClick);
            // 
            // YarnDyingWorkOrderSummary
            // 
            this.YarnDyingWorkOrderSummary.Caption = "Yarn Dying Work Orders Summary";
            this.YarnDyingWorkOrderSummary.Description = "[Yarn Management] Yarn Dying Work Order Summary";
            this.YarnDyingWorkOrderSummary.Id = 693;
            this.YarnDyingWorkOrderSummary.Name = "YarnDyingWorkOrderSummary";
            this.YarnDyingWorkOrderSummary.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.YarnDyingWorkOrderSummary_ItemClick);
            // 
            // RequestApproval
            // 
            this.RequestApproval.Caption = "Request Approval";
            this.RequestApproval.Description = "[Store] Department Store Approval / Rejection";
            this.RequestApproval.Id = 694;
            this.RequestApproval.LargeImageIndex = 327;
            this.RequestApproval.Name = "RequestApproval";
            this.RequestApproval.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RequestApproval_ItemClick);
            // 
            // EmailSettings
            // 
            this.EmailSettings.Caption = "E-Mail Settings";
            this.EmailSettings.Id = 695;
            this.EmailSettings.LargeImageIndex = 205;
            this.EmailSettings.Name = "EmailSettings";
            this.EmailSettings.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EmailSettings_ItemClick);
            // 
            // Contracts_Sale
            // 
            this.Contracts_Sale.Caption = "Sale Contracts";
            this.Contracts_Sale.Id = 699;
            this.Contracts_Sale.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Fabric),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Towel)});
            this.Contracts_Sale.Name = "Contracts_Sale";
            // 
            // Contracts_Sales_Fabric
            // 
            this.Contracts_Sales_Fabric.Caption = "Fabric";
            this.Contracts_Sales_Fabric.Id = 700;
            this.Contracts_Sales_Fabric.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Fabric_Overhead),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Fabric_Conversion),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Fabric_Sale)});
            this.Contracts_Sales_Fabric.Name = "Contracts_Sales_Fabric";
            // 
            // Contracts_Sales_Fabric_Overhead
            // 
            this.Contracts_Sales_Fabric_Overhead.Caption = "Overhead";
            this.Contracts_Sales_Fabric_Overhead.Description = "[Planning] Sales Contract : Overhead";
            this.Contracts_Sales_Fabric_Overhead.Id = 702;
            this.Contracts_Sales_Fabric_Overhead.Name = "Contracts_Sales_Fabric_Overhead";
            this.Contracts_Sales_Fabric_Overhead.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Contracts_Sales_Fabric_Overhead_ItemClick);
            // 
            // Contracts_Sales_Fabric_Conversion
            // 
            this.Contracts_Sales_Fabric_Conversion.Caption = "Conversion";
            this.Contracts_Sales_Fabric_Conversion.Description = "[Planning] Sales Contract: Conversion";
            this.Contracts_Sales_Fabric_Conversion.Id = 703;
            this.Contracts_Sales_Fabric_Conversion.Name = "Contracts_Sales_Fabric_Conversion";
            this.Contracts_Sales_Fabric_Conversion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Contracts_Sales_Fabric_Conversion_ItemClick);
            // 
            // Contracts_Sales_Fabric_Sale
            // 
            this.Contracts_Sales_Fabric_Sale.Caption = "Sale";
            this.Contracts_Sales_Fabric_Sale.Description = "[Planning]  Sales Contract: Sale";
            this.Contracts_Sales_Fabric_Sale.Id = 704;
            this.Contracts_Sales_Fabric_Sale.Name = "Contracts_Sales_Fabric_Sale";
            this.Contracts_Sales_Fabric_Sale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Contracts_Sales_Fabric_Sale_ItemClick);
            // 
            // Contracts_Sales_Towel
            // 
            this.Contracts_Sales_Towel.Caption = "Towel";
            this.Contracts_Sales_Towel.Id = 701;
            this.Contracts_Sales_Towel.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Towel_Overhead),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Towel_Conversion),
            new DevExpress.XtraBars.LinkPersistInfo(this.Contracts_Sales_Towel_Sale)});
            this.Contracts_Sales_Towel.Name = "Contracts_Sales_Towel";
            // 
            // Contracts_Sales_Towel_Overhead
            // 
            this.Contracts_Sales_Towel_Overhead.Caption = "Overhead";
            this.Contracts_Sales_Towel_Overhead.Id = 705;
            this.Contracts_Sales_Towel_Overhead.Name = "Contracts_Sales_Towel_Overhead";
            // 
            // Contracts_Sales_Towel_Conversion
            // 
            this.Contracts_Sales_Towel_Conversion.Caption = "Conversion";
            this.Contracts_Sales_Towel_Conversion.Id = 706;
            this.Contracts_Sales_Towel_Conversion.Name = "Contracts_Sales_Towel_Conversion";
            // 
            // Contracts_Sales_Towel_Sale
            // 
            this.Contracts_Sales_Towel_Sale.Caption = "Sale";
            this.Contracts_Sales_Towel_Sale.Id = 707;
            this.Contracts_Sales_Towel_Sale.Name = "Contracts_Sales_Towel_Sale";
            // 
            // Store_RequisitionList
            // 
            this.Store_RequisitionList.Caption = "Req. List";
            this.Store_RequisitionList.Description = "[Store] Department Requisitions List";
            this.Store_RequisitionList.Id = 708;
            this.Store_RequisitionList.LargeImageIndex = 319;
            this.Store_RequisitionList.Name = "Store_RequisitionList";
            this.Store_RequisitionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Store_RequisitionList_ItemClick);
            // 
            // barButtonItem_SaveRunningPercentLocation
            // 
            this.barButtonItem_SaveRunningPercentLocation.Caption = "Save Category Size and Location";
            this.barButtonItem_SaveRunningPercentLocation.Description = "[Dashboard] Category: Save Category Size and Location";
            this.barButtonItem_SaveRunningPercentLocation.Enabled = false;
            this.barButtonItem_SaveRunningPercentLocation.Id = 714;
            this.barButtonItem_SaveRunningPercentLocation.Name = "barButtonItem_SaveRunningPercentLocation";
            this.barButtonItem_SaveRunningPercentLocation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem_SaveRunningPercentLocation_ItemClick);
            // 
            // ButtonEfficiencyType
            // 
            this.ButtonEfficiencyType.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.ButtonEfficiencyType.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEfficiencyType.Appearance.Options.UseFont = true;
            this.ButtonEfficiencyType.Caption = "Shed Efficiency";
            this.ButtonEfficiencyType.Id = 715;
            this.ButtonEfficiencyType.Name = "ButtonEfficiencyType";
            this.ButtonEfficiencyType.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ButtonEfficiencyType_ItemClick);
            // 
            // barButton_NewCategory
            // 
            this.barButton_NewCategory.Caption = "New Category";
            this.barButton_NewCategory.Id = 720;
            this.barButton_NewCategory.Name = "barButton_NewCategory";
            this.barButton_NewCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButton_NewCategory_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 725;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barSubItem10
            // 
            this.barSubItem10.Caption = "Production";
            this.barSubItem10.Id = 727;
            this.barSubItem10.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProduction_Inward),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9)});
            this.barSubItem10.Name = "barSubItem10";
            // 
            // btnProduction_Inward
            // 
            this.btnProduction_Inward.Caption = "Production Inward";
            this.btnProduction_Inward.Id = 733;
            this.btnProduction_Inward.Name = "btnProduction_Inward";
            this.btnProduction_Inward.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProduction_Inward_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Production Dispatched";
            this.barButtonItem7.Id = 734;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "Production Status Report";
            this.barButtonItem8.Id = 735;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "List Production Inward";
            this.barButtonItem9.Id = 736;
            this.barButtonItem9.Name = "barButtonItem9";
            this.barButtonItem9.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem9_ItemClick);
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Production Inward";
            this.barButtonItem5.Id = 729;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick_1);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 731;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "blend.jpg");
            this.imageCollection1.Images.SetKeyName(1, "contacts.png");
            this.imageCollection1.Images.SetKeyName(2, "FabricArticle.png");
            this.imageCollection1.Images.SetKeyName(3, "inspection.png");
            this.imageCollection1.Images.SetKeyName(4, "Knotting.png");
            this.imageCollection1.Images.SetKeyName(5, "login.png");
            this.imageCollection1.Images.SetKeyName(6, "poweroff.png");
            this.imageCollection1.Images.SetKeyName(7, "reports.png");
            this.imageCollection1.Images.SetKeyName(8, "security.png");
            this.imageCollection1.Images.SetKeyName(9, "sizing.png");
            this.imageCollection1.Images.SetKeyName(10, "warp.png");
            this.imageCollection1.Images.SetKeyName(11, "yarn.png");
            this.imageCollection1.Images.SetKeyName(12, "Customer.png");
            this.imageCollection1.Images.SetKeyName(13, "Groups.png");
            this.imageCollection1.Images.SetKeyName(14, "Add.png");
            this.imageCollection1.Images.SetKeyName(15, "Arrow-Left.png");
            this.imageCollection1.Images.SetKeyName(16, "Arrow-Right.png");
            this.imageCollection1.Images.SetKeyName(17, "audacious.png");
            this.imageCollection1.Images.SetKeyName(18, "Bails.png");
            this.imageCollection1.Images.SetKeyName(19, "blend.jpg");
            this.imageCollection1.Images.SetKeyName(20, "blend.png");
            this.imageCollection1.Images.SetKeyName(21, "BurnAware2.png");
            this.imageCollection1.Images.SetKeyName(22, "Calculator.png");
            this.imageCollection1.Images.SetKeyName(23, "Calendar_01.png");
            this.imageCollection1.Images.SetKeyName(24, "Chart.png");
            this.imageCollection1.Images.SetKeyName(25, "ColorsManagement.png");
            this.imageCollection1.Images.SetKeyName(26, "contacts.png");
            this.imageCollection1.Images.SetKeyName(27, "Customer.png");
            this.imageCollection1.Images.SetKeyName(28, "Cut.png");
            this.imageCollection1.Images.SetKeyName(29, "defrag.png");
            this.imageCollection1.Images.SetKeyName(30, "Delete.png");
            this.imageCollection1.Images.SetKeyName(31, "Documents.png");
            this.imageCollection1.Images.SetKeyName(32, "Eject.png");
            this.imageCollection1.Images.SetKeyName(33, "Exclaim.png");
            this.imageCollection1.Images.SetKeyName(34, "FabricArticle.png");
            this.imageCollection1.Images.SetKeyName(35, "Flag_Green.png");
            this.imageCollection1.Images.SetKeyName(36, "Flag_Red.png");
            this.imageCollection1.Images.SetKeyName(37, "gear.png");
            this.imageCollection1.Images.SetKeyName(38, "Graph_01.png");
            this.imageCollection1.Images.SetKeyName(39, "Groups.png");
            this.imageCollection1.Images.SetKeyName(40, "increase.png");
            this.imageCollection1.Images.SetKeyName(41, "inspection.png");
            this.imageCollection1.Images.SetKeyName(42, "Key.png");
            this.imageCollection1.Images.SetKeyName(43, "kgzt.png");
            this.imageCollection1.Images.SetKeyName(44, "Knotting.png");
            this.imageCollection1.Images.SetKeyName(45, "light.png");
            this.imageCollection1.Images.SetKeyName(46, "Lock.png");
            this.imageCollection1.Images.SetKeyName(47, "login.png");
            this.imageCollection1.Images.SetKeyName(48, "lol.png");
            this.imageCollection1.Images.SetKeyName(49, "NetworkConfigs.png");
            this.imageCollection1.Images.SetKeyName(50, "nokia pc suite.png");
            this.imageCollection1.Images.SetKeyName(51, "PaperClip.png");
            this.imageCollection1.Images.SetKeyName(52, "poweroff.png");
            this.imageCollection1.Images.SetKeyName(53, "qip.png");
            this.imageCollection1.Images.SetKeyName(54, "refresh.png");
            this.imageCollection1.Images.SetKeyName(55, "Refresh_1.png");
            this.imageCollection1.Images.SetKeyName(56, "reports.png");
            this.imageCollection1.Images.SetKeyName(57, "RFID.png");
            this.imageCollection1.Images.SetKeyName(58, "security.png");
            this.imageCollection1.Images.SetKeyName(59, "settings.png");
            this.imageCollection1.Images.SetKeyName(60, "sizing.png");
            this.imageCollection1.Images.SetKeyName(61, "sms.png");
            this.imageCollection1.Images.SetKeyName(62, "Standby.png");
            this.imageCollection1.Images.SetKeyName(63, "Stat.png");
            this.imageCollection1.Images.SetKeyName(64, "steam2.png");
            this.imageCollection1.Images.SetKeyName(65, "Sygic-Aura.png");
            this.imageCollection1.Images.SetKeyName(66, "task manager.png");
            this.imageCollection1.Images.SetKeyName(67, "Tools.png");
            this.imageCollection1.Images.SetKeyName(68, "Trash.png");
            this.imageCollection1.Images.SetKeyName(69, "warp.png");
            this.imageCollection1.Images.SetKeyName(70, "WirelessSettings.png");
            this.imageCollection1.Images.SetKeyName(71, "wordpad.png");
            this.imageCollection1.Images.SetKeyName(72, "xbmc.png");
            this.imageCollection1.Images.SetKeyName(73, "xwidget.png");
            this.imageCollection1.Images.SetKeyName(74, "yarn.png");
            this.imageCollection1.Images.SetKeyName(75, "zoomin.png");
            this.imageCollection1.Images.SetKeyName(76, "zoomout.png");
            this.imageCollection1.Images.SetKeyName(77, "UserManagement.png");
            this.imageCollection1.Images.SetKeyName(78, "ic_menu_account_list.png");
            this.imageCollection1.Images.SetKeyName(79, "ic_menu_allfriends.png");
            this.imageCollection1.Images.SetKeyName(80, "ic_menu_always_landscape_portrait.png");
            this.imageCollection1.Images.SetKeyName(81, "ID.png");
            this.imageCollection1.Images.SetKeyName(82, "key_64.png");
            this.imageCollection1.Images.SetKeyName(83, "Padlock.png");
            this.imageCollection1.Images.SetKeyName(84, "Tools (1).png");
            this.imageCollection1.Images.SetKeyName(85, "database.png");
            this.imageCollection1.Images.SetKeyName(86, "UserManagement.png");
            this.imageCollection1.Images.SetKeyName(87, "dice.png");
            this.imageCollection1.Images.SetKeyName(88, "minus.png");
            this.imageCollection1.Images.SetKeyName(89, "plus.png");
            this.imageCollection1.Images.SetKeyName(90, "action.png");
            this.imageCollection1.Images.SetKeyName(91, "add.png");
            this.imageCollection1.Images.SetKeyName(92, "add_contact.png");
            this.imageCollection1.Images.SetKeyName(93, "apple.png");
            this.imageCollection1.Images.SetKeyName(94, "approve.png");
            this.imageCollection1.Images.SetKeyName(95, "arrow_down.png");
            this.imageCollection1.Images.SetKeyName(96, "arrow_left.png");
            this.imageCollection1.Images.SetKeyName(97, "arrow_right.png");
            this.imageCollection1.Images.SetKeyName(98, "arrow_up.png");
            this.imageCollection1.Images.SetKeyName(99, "baggage_trolley.png");
            this.imageCollection1.Images.SetKeyName(100, "ball.png");
            this.imageCollection1.Images.SetKeyName(101, "bar_chart.png");
            this.imageCollection1.Images.SetKeyName(102, "barcode.png");
            this.imageCollection1.Images.SetKeyName(103, "battery_charging.png");
            this.imageCollection1.Images.SetKeyName(104, "battery_empty.png");
            this.imageCollection1.Images.SetKeyName(105, "battery_full.png");
            this.imageCollection1.Images.SetKeyName(106, "battery_one_bars.png");
            this.imageCollection1.Images.SetKeyName(107, "battery_two_bars.png");
            this.imageCollection1.Images.SetKeyName(108, "bed.png");
            this.imageCollection1.Images.SetKeyName(109, "bell.png");
            this.imageCollection1.Images.SetKeyName(110, "bicycle.png");
            this.imageCollection1.Images.SetKeyName(111, "block.png");
            this.imageCollection1.Images.SetKeyName(112, "boat.png");
            this.imageCollection1.Images.SetKeyName(113, "book.png");
            this.imageCollection1.Images.SetKeyName(114, "bottle.png");
            this.imageCollection1.Images.SetKeyName(115, "box.png");
            this.imageCollection1.Images.SetKeyName(116, "box_add.png");
            this.imageCollection1.Images.SetKeyName(117, "box_approve.png");
            this.imageCollection1.Images.SetKeyName(118, "box_delete.png");
            this.imageCollection1.Images.SetKeyName(119, "box_remove.png");
            this.imageCollection1.Images.SetKeyName(120, "briefcase.png");
            this.imageCollection1.Images.SetKeyName(121, "briefcase_download.png");
            this.imageCollection1.Images.SetKeyName(122, "briefcase_upload.png");
            this.imageCollection1.Images.SetKeyName(123, "bullseye.png");
            this.imageCollection1.Images.SetKeyName(124, "bumerang.png");
            this.imageCollection1.Images.SetKeyName(125, "bus.png");
            this.imageCollection1.Images.SetKeyName(126, "calculator.png");
            this.imageCollection1.Images.SetKeyName(127, "calendar.png");
            this.imageCollection1.Images.SetKeyName(128, "candle.png");
            this.imageCollection1.Images.SetKeyName(129, "car.png");
            this.imageCollection1.Images.SetKeyName(130, "card.png");
            this.imageCollection1.Images.SetKeyName(131, "chess.png");
            this.imageCollection1.Images.SetKeyName(132, "clock.png");
            this.imageCollection1.Images.SetKeyName(133, "cloud.png");
            this.imageCollection1.Images.SetKeyName(134, "cloud_download.png");
            this.imageCollection1.Images.SetKeyName(135, "cloud_rain.png");
            this.imageCollection1.Images.SetKeyName(136, "cloud_thunder.png");
            this.imageCollection1.Images.SetKeyName(137, "cloud_upload.png");
            this.imageCollection1.Images.SetKeyName(138, "coffee.png");
            this.imageCollection1.Images.SetKeyName(139, "comb.png");
            this.imageCollection1.Images.SetKeyName(140, "comment.png");
            this.imageCollection1.Images.SetKeyName(141, "comment_add.png");
            this.imageCollection1.Images.SetKeyName(142, "comment_approve.png");
            this.imageCollection1.Images.SetKeyName(143, "comment_delete.png");
            this.imageCollection1.Images.SetKeyName(144, "comment_remove.png");
            this.imageCollection1.Images.SetKeyName(145, "computer.png");
            this.imageCollection1.Images.SetKeyName(146, "contact_approve.png");
            this.imageCollection1.Images.SetKeyName(147, "contact_delete.png");
            this.imageCollection1.Images.SetKeyName(148, "contact_remove.png");
            this.imageCollection1.Images.SetKeyName(149, "credit_card.png");
            this.imageCollection1.Images.SetKeyName(150, "crown.png");
            this.imageCollection1.Images.SetKeyName(151, "database.png");
            this.imageCollection1.Images.SetKeyName(152, "delete.png");
            this.imageCollection1.Images.SetKeyName(153, "diamond.png");
            this.imageCollection1.Images.SetKeyName(154, "diary.png");
            this.imageCollection1.Images.SetKeyName(155, "diary_add.png");
            this.imageCollection1.Images.SetKeyName(156, "diary_approve.png");
            this.imageCollection1.Images.SetKeyName(157, "diary_delete.png");
            this.imageCollection1.Images.SetKeyName(158, "diary_remove.png");
            this.imageCollection1.Images.SetKeyName(159, "dislike.png");
            this.imageCollection1.Images.SetKeyName(160, "double_bed.png");
            this.imageCollection1.Images.SetKeyName(161, "drink.png");
            this.imageCollection1.Images.SetKeyName(162, "drop.png");
            this.imageCollection1.Images.SetKeyName(163, "edit.png");
            this.imageCollection1.Images.SetKeyName(164, "email.png");
            this.imageCollection1.Images.SetKeyName(165, "euro.png");
            this.imageCollection1.Images.SetKeyName(166, "eyedropper.png");
            this.imageCollection1.Images.SetKeyName(167, "fast_backward.png");
            this.imageCollection1.Images.SetKeyName(168, "fast_forward.png");
            this.imageCollection1.Images.SetKeyName(169, "film.png");
            this.imageCollection1.Images.SetKeyName(170, "filter.png");
            this.imageCollection1.Images.SetKeyName(171, "fix.png");
            this.imageCollection1.Images.SetKeyName(172, "flag.png");
            this.imageCollection1.Images.SetKeyName(173, "folder.png");
            this.imageCollection1.Images.SetKeyName(174, "folder_add.png");
            this.imageCollection1.Images.SetKeyName(175, "folder_approve.png");
            this.imageCollection1.Images.SetKeyName(176, "folder_delete.png");
            this.imageCollection1.Images.SetKeyName(177, "folder_remove.png");
            this.imageCollection1.Images.SetKeyName(178, "food.png");
            this.imageCollection1.Images.SetKeyName(179, "fullscreen.png");
            this.imageCollection1.Images.SetKeyName(180, "hammer.png");
            this.imageCollection1.Images.SetKeyName(181, "hand.png");
            this.imageCollection1.Images.SetKeyName(182, "headphones.png");
            this.imageCollection1.Images.SetKeyName(183, "heart.png");
            this.imageCollection1.Images.SetKeyName(184, "home.png");
            this.imageCollection1.Images.SetKeyName(185, "hourglass.png");
            this.imageCollection1.Images.SetKeyName(186, "id_card.png");
            this.imageCollection1.Images.SetKeyName(187, "images.png");
            this.imageCollection1.Images.SetKeyName(188, "inbox.png");
            this.imageCollection1.Images.SetKeyName(189, "inbox_empty.png");
            this.imageCollection1.Images.SetKeyName(190, "information.png");
            this.imageCollection1.Images.SetKeyName(191, "key.png");
            this.imageCollection1.Images.SetKeyName(192, "laboratory.png");
            this.imageCollection1.Images.SetKeyName(193, "layout_coloumns.png");
            this.imageCollection1.Images.SetKeyName(194, "layout_rows.png");
            this.imageCollection1.Images.SetKeyName(195, "layout_squares.png");
            this.imageCollection1.Images.SetKeyName(196, "layout_squares_small.png");
            this.imageCollection1.Images.SetKeyName(197, "leaves.png");
            this.imageCollection1.Images.SetKeyName(198, "light_bulb.png");
            this.imageCollection1.Images.SetKeyName(199, "like.png");
            this.imageCollection1.Images.SetKeyName(200, "list.png");
            this.imageCollection1.Images.SetKeyName(201, "locked.png");
            this.imageCollection1.Images.SetKeyName(202, "lollipop.png");
            this.imageCollection1.Images.SetKeyName(203, "magic_wand.png");
            this.imageCollection1.Images.SetKeyName(204, "magnet.png");
            this.imageCollection1.Images.SetKeyName(205, "mail.png");
            this.imageCollection1.Images.SetKeyName(206, "map_pin.png");
            this.imageCollection1.Images.SetKeyName(207, "measure.png");
            this.imageCollection1.Images.SetKeyName(208, "medal.png");
            this.imageCollection1.Images.SetKeyName(209, "megaphone.png");
            this.imageCollection1.Images.SetKeyName(210, "microphone.png");
            this.imageCollection1.Images.SetKeyName(211, "monitor.png");
            this.imageCollection1.Images.SetKeyName(212, "mouse.png");
            this.imageCollection1.Images.SetKeyName(213, "move.png");
            this.imageCollection1.Images.SetKeyName(214, "mp3_player.png");
            this.imageCollection1.Images.SetKeyName(215, "museum.png");
            this.imageCollection1.Images.SetKeyName(216, "music.png");
            this.imageCollection1.Images.SetKeyName(217, "notebook.png");
            this.imageCollection1.Images.SetKeyName(218, "outbox.png");
            this.imageCollection1.Images.SetKeyName(219, "page.png");
            this.imageCollection1.Images.SetKeyName(220, "page_add.png");
            this.imageCollection1.Images.SetKeyName(221, "page_approve.png");
            this.imageCollection1.Images.SetKeyName(222, "page_delete.png");
            this.imageCollection1.Images.SetKeyName(223, "page_remove.png");
            this.imageCollection1.Images.SetKeyName(224, "page_writing.png");
            this.imageCollection1.Images.SetKeyName(225, "paint_brush.png");
            this.imageCollection1.Images.SetKeyName(226, "parking.png");
            this.imageCollection1.Images.SetKeyName(227, "pause.png");
            this.imageCollection1.Images.SetKeyName(228, "percent.png");
            this.imageCollection1.Images.SetKeyName(229, "phone.png");
            this.imageCollection1.Images.SetKeyName(230, "photo_camera.png");
            this.imageCollection1.Images.SetKeyName(231, "piano.png");
            this.imageCollection1.Images.SetKeyName(232, "pie_chart.png");
            this.imageCollection1.Images.SetKeyName(233, "pin.png");
            this.imageCollection1.Images.SetKeyName(234, "play.png");
            this.imageCollection1.Images.SetKeyName(235, "plug.png");
            this.imageCollection1.Images.SetKeyName(236, "present.png");
            this.imageCollection1.Images.SetKeyName(237, "print.png");
            this.imageCollection1.Images.SetKeyName(238, "puzzle.png");
            this.imageCollection1.Images.SetKeyName(239, "quote.png");
            this.imageCollection1.Images.SetKeyName(240, "radio.png");
            this.imageCollection1.Images.SetKeyName(241, "reception_bell.png");
            this.imageCollection1.Images.SetKeyName(242, "repair_add.png");
            this.imageCollection1.Images.SetKeyName(243, "repair_approve.png");
            this.imageCollection1.Images.SetKeyName(244, "repair_delete.png");
            this.imageCollection1.Images.SetKeyName(245, "repair_remove.png");
            this.imageCollection1.Images.SetKeyName(246, "replay.png");
            this.imageCollection1.Images.SetKeyName(247, "save.png");
            this.imageCollection1.Images.SetKeyName(248, "save_approve.png");
            this.imageCollection1.Images.SetKeyName(249, "save_x.png");
            this.imageCollection1.Images.SetKeyName(250, "scissors.png");
            this.imageCollection1.Images.SetKeyName(251, "screen_maximize.png");
            this.imageCollection1.Images.SetKeyName(252, "screen_minimize.png");
            this.imageCollection1.Images.SetKeyName(253, "search.png");
            this.imageCollection1.Images.SetKeyName(254, "settings.png");
            this.imageCollection1.Images.SetKeyName(255, "shopping_bag.png");
            this.imageCollection1.Images.SetKeyName(256, "shopping_cart.png");
            this.imageCollection1.Images.SetKeyName(257, "shuffle.png");
            this.imageCollection1.Images.SetKeyName(258, "smart_phone.png");
            this.imageCollection1.Images.SetKeyName(259, "sound_full.png");
            this.imageCollection1.Images.SetKeyName(260, "sound_low.png");
            this.imageCollection1.Images.SetKeyName(261, "speedometer.png");
            this.imageCollection1.Images.SetKeyName(262, "spray.png");
            this.imageCollection1.Images.SetKeyName(263, "star.png");
            this.imageCollection1.Images.SetKeyName(264, "stop.png");
            this.imageCollection1.Images.SetKeyName(265, "sun.png");
            this.imageCollection1.Images.SetKeyName(266, "tag.png");
            this.imageCollection1.Images.SetKeyName(267, "teddy_bear.png");
            this.imageCollection1.Images.SetKeyName(268, "thermometer.png");
            this.imageCollection1.Images.SetKeyName(269, "trash.png");
            this.imageCollection1.Images.SetKeyName(270, "tree.png");
            this.imageCollection1.Images.SetKeyName(271, "tune.png");
            this.imageCollection1.Images.SetKeyName(272, "umbrella.png");
            this.imageCollection1.Images.SetKeyName(273, "usb_drive.png");
            this.imageCollection1.Images.SetKeyName(274, "user.png");
            this.imageCollection1.Images.SetKeyName(275, "Users.png");
            this.imageCollection1.Images.SetKeyName(276, "video_camera.png");
            this.imageCollection1.Images.SetKeyName(277, "view.png");
            this.imageCollection1.Images.SetKeyName(278, "warning.png");
            this.imageCollection1.Images.SetKeyName(279, "warning_sign.png");
            this.imageCollection1.Images.SetKeyName(280, "webcam.png");
            this.imageCollection1.Images.SetKeyName(281, "weights.png");
            this.imageCollection1.Images.SetKeyName(282, "window.png");
            this.imageCollection1.Images.SetKeyName(283, "window_accept.png");
            this.imageCollection1.Images.SetKeyName(284, "window_add.png");
            this.imageCollection1.Images.SetKeyName(285, "window_delete.png");
            this.imageCollection1.Images.SetKeyName(286, "window_remove.png");
            this.imageCollection1.Images.SetKeyName(287, "window_text.png");
            this.imageCollection1.Images.SetKeyName(288, "wired.png");
            this.imageCollection1.Images.SetKeyName(289, "write.png");
            this.imageCollection1.Images.SetKeyName(290, "Information.png");
            this.imageCollection1.Images.SetKeyName(291, "warning.jpeg");
            this.imageCollection1.Images.SetKeyName(292, "Error.png");
            this.imageCollection1.Images.SetKeyName(293, "GRNYarn.jpg");
            this.imageCollection1.Images.SetKeyName(294, "GIN.png");
            this.imageCollection1.Images.SetKeyName(295, "Ecommerce-Return-icon.png");
            this.imageCollection1.Images.SetKeyName(296, "Ecommerce-Sell-icon.png");
            this.imageCollection1.Images.SetKeyName(297, "Ecommerce-Shoping-basket-icon.png");
            this.imageCollection1.Images.SetKeyName(298, "Ecommerce-Gift-icon.png");
            this.imageCollection1.Images.SetKeyName(299, "Ecommerce-Shoping-bag-icon.png");
            this.imageCollection1.Images.SetKeyName(300, "Ecommerce-Tag-icon.png");
            this.imageCollection1.Images.SetKeyName(301, "ChartofAccounts.png");
            this.imageCollection1.Images.SetKeyName(302, "SalesInvoice32.png");
            this.imageCollection1.Images.SetKeyName(303, "whatcanido.png");
            this.imageCollection1.Images.SetKeyName(304, "DocState_Authorized.png");
            this.imageCollection1.Images.SetKeyName(305, "DocState_Cancelled.png");
            this.imageCollection1.Images.SetKeyName(306, "DocState_Closed.png");
            this.imageCollection1.Images.SetKeyName(307, "DocState_Open.png");
            this.imageCollection1.Images.SetKeyName(308, "DocState_UnDefined.png");
            this.imageCollection1.Images.SetKeyName(309, "inspection_1.png");
            this.imageCollection1.Images.SetKeyName(310, "inspection_2.png");
            this.imageCollection1.Images.SetKeyName(311, "TowelDailyInspection.png");
            this.imageCollection1.Images.SetKeyName(312, "TowelPackingList.png");
            this.imageCollection1.Images.SetKeyName(313, "Store_ItemIssueNote.png");
            this.imageCollection1.Images.SetKeyName(314, "Store_PurchaseOrder.png");
            this.imageCollection1.Images.SetKeyName(315, "Store_PurchaseRegister.png");
            this.imageCollection1.Images.SetKeyName(316, "Store_PurchaseRequisition.png");
            this.imageCollection1.Images.SetKeyName(317, "Store_PurchaseReturn.png");
            this.imageCollection1.Images.SetKeyName(318, "FinancialYears.png");
            this.imageCollection1.Images.SetKeyName(319, "OpeningTowel.png");
            this.imageCollection1.Images.SetKeyName(320, "InspectionTowel.png");
            this.imageCollection1.Images.SetKeyName(321, "packingListTowel.png");
            this.imageCollection1.Images.SetKeyName(322, "TakeToGodownTowel.png");
            this.imageCollection1.Images.SetKeyName(323, "reportsTowel.png");
            this.imageCollection1.Images.SetKeyName(324, "Doubling.png");
            this.imageCollection1.Images.SetKeyName(325, "MovePO.png");
            this.imageCollection1.Images.SetKeyName(326, "color_fill.png");
            this.imageCollection1.Images.SetKeyName(327, "Approval.png");
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "Selection";
            // 
            // page_LDS
            // 
            this.page_LDS.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PG_Dashboard_Shed,
            this.PG_Dashboard_Sizing,
            this.PG_Dashboard_Weavers,
            this.PG_Dashboard_Articles,
            this.ribbonPageGroup_DailyEfficiency});
            this.page_LDS.ImageIndex = 24;
            this.page_LDS.Name = "page_LDS";
            this.page_LDS.Text = "Monitoring";
            // 
            // PG_Dashboard_Shed
            // 
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bci_DashBoard_DesignMove);
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bbi_DashBoard_DesignSave);
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bbi_Dashboard_ShedEff);
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bbi_Shed);
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bbi_Summary);
            this.PG_Dashboard_Shed.ItemLinks.Add(this.bbi_LoomFilter);
            this.PG_Dashboard_Shed.Name = "PG_Dashboard_Shed";
            this.PG_Dashboard_Shed.Text = "Shed View";
            // 
            // PG_Dashboard_Sizing
            // 
            this.PG_Dashboard_Sizing.ItemLinks.Add(this.bbi_DashBoard_SizingView);
            this.PG_Dashboard_Sizing.ItemLinks.Add(this.barButton_NewCategory);
            this.PG_Dashboard_Sizing.Name = "PG_Dashboard_Sizing";
            this.PG_Dashboard_Sizing.Text = "Sizing View";
            // 
            // PG_Dashboard_Weavers
            // 
            this.PG_Dashboard_Weavers.ItemLinks.Add(this.bbi_DashBoard_DesignMoveGroup);
            this.PG_Dashboard_Weavers.ItemLinks.Add(this.bbi_Dashboard_DesignSaveGroup);
            this.PG_Dashboard_Weavers.ItemLinks.Add(this.bbi_WeaverMain);
            this.PG_Dashboard_Weavers.ItemLinks.Add(this.bbi_WeaversScroll);
            this.PG_Dashboard_Weavers.ItemLinks.Add(this.WeaverGroupsManagement);
            this.PG_Dashboard_Weavers.Name = "PG_Dashboard_Weavers";
            this.PG_Dashboard_Weavers.Text = "Weavers View";
            // 
            // PG_Dashboard_Articles
            // 
            this.PG_Dashboard_Articles.ItemLinks.Add(this.bbi_ShedGraph_View);
            this.PG_Dashboard_Articles.ItemLinks.Add(this.bbi_Dashboard_ExecutiveSummary);
            this.PG_Dashboard_Articles.ItemLinks.Add(this.bbi_Dashboard_ArticleEfficiency);
            this.PG_Dashboard_Articles.ItemLinks.Add(this.bbiGotoFilter);
            this.PG_Dashboard_Articles.Name = "PG_Dashboard_Articles";
            this.PG_Dashboard_Articles.Text = "Misc Views";
            // 
            // ribbonPageGroup_DailyEfficiency
            // 
            this.ribbonPageGroup_DailyEfficiency.ItemLinks.Add(this.rpi_DailyShiftSummary);
            this.ribbonPageGroup_DailyEfficiency.Name = "ribbonPageGroup_DailyEfficiency";
            this.ribbonPageGroup_DailyEfficiency.Text = "Efficiency Reports";
            // 
            // page_Planning
            // 
            this.page_Planning.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ContractsPageGroup,
            this.PG_Planning_Articles,
            this.PG_Planning_ArticleChangeSheet});
            this.page_Planning.ImageIndex = 14;
            this.page_Planning.Name = "page_Planning";
            this.page_Planning.Text = "Planning";
            // 
            // ContractsPageGroup
            // 
            this.ContractsPageGroup.ItemLinks.Add(this.FabricContracts);
            this.ContractsPageGroup.ItemLinks.Add(this.PO_Greige);
            this.ContractsPageGroup.ItemLinks.Add(this.ReportsMenuContracts);
            this.ContractsPageGroup.ItemLinks.Add(this.Contracts_Sale);
            this.ContractsPageGroup.Name = "ContractsPageGroup";
            this.ContractsPageGroup.Text = "Contracts";
            // 
            // PG_Planning_Articles
            // 
            this.PG_Planning_Articles.ItemLinks.Add(this.bbi_Data_Article_Insertion);
            this.PG_Planning_Articles.ItemLinks.Add(this.bbi_Data_Article_Weave);
            this.PG_Planning_Articles.ItemLinks.Add(this.bbi_Data_Article_FabricName);
            this.PG_Planning_Articles.ItemLinks.Add(this.Button_TowelArticles);
            this.PG_Planning_Articles.ItemLinks.Add(this.barButtonItem_GreigeArticle);
            this.PG_Planning_Articles.ItemLinks.Add(this.barButtonItem_JacquardArticles);
            this.PG_Planning_Articles.ItemLinks.Add(this.DenimArticlesAdd);
            this.PG_Planning_Articles.Name = "PG_Planning_Articles";
            this.PG_Planning_Articles.ShowCaptionButton = false;
            this.PG_Planning_Articles.Text = "Articles";
            // 
            // PG_Planning_ArticleChangeSheet
            // 
            this.PG_Planning_ArticleChangeSheet.ItemLinks.Add(this.PGB_ArticleChangeSheet);
            this.PG_Planning_ArticleChangeSheet.ItemLinks.Add(this.DesignChangeSheet);
            this.PG_Planning_ArticleChangeSheet.ItemLinks.Add(this.Planning_ProgramSheet);
            this.PG_Planning_ArticleChangeSheet.ItemLinks.Add(this.SizingWorkOrderButton);
            this.PG_Planning_ArticleChangeSheet.Name = "PG_Planning_ArticleChangeSheet";
            this.PG_Planning_ArticleChangeSheet.Text = "Planning on Loom";
            // 
            // page_Yarn
            // 
            this.page_Yarn.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PG_Yarn_YarnContractManagement,
            this.PG_Yarn_GRNGIN,
            this.PageGroup_Store,
            this.StoreParametersPageGroup});
            this.page_Yarn.ImageIndex = 4;
            this.page_Yarn.Name = "page_Yarn";
            this.page_Yarn.Text = "Yarn and Spares";
            // 
            // PG_Yarn_YarnContractManagement
            // 
            this.PG_Yarn_YarnContractManagement.ItemLinks.Add(this.YarnContract);
            this.PG_Yarn_YarnContractManagement.ItemLinks.Add(this.mdata_Yarn);
            this.PG_Yarn_YarnContractManagement.Name = "PG_Yarn_YarnContractManagement";
            this.PG_Yarn_YarnContractManagement.Text = "Yarn";
            // 
            // PG_Yarn_GRNGIN
            // 
            this.PG_Yarn_GRNGIN.ItemLinks.Add(this.DoublingMenu);
            this.PG_Yarn_GRNGIN.ItemLinks.Add(this.MenuYarnInwardOutward);
            this.PG_Yarn_GRNGIN.ItemLinks.Add(this.MenuYarnReceiveIssue);
            this.PG_Yarn_GRNGIN.ItemLinks.Add(this.YarnDyingMenu);
            this.PG_Yarn_GRNGIN.ItemLinks.Add(this.YarnReports_Menu);
            this.PG_Yarn_GRNGIN.Name = "PG_Yarn_GRNGIN";
            // 
            // PageGroup_Store
            // 
            this.PageGroup_Store.ItemLinks.Add(this.Button_StoreAccounts);
            this.PageGroup_Store.ItemLinks.Add(this.Button_PurchaseOrderStore);
            this.PageGroup_Store.ItemLinks.Add(this.Button_StorePurchaseRegister);
            this.PageGroup_Store.ItemLinks.Add(this.Button_StorePurchaseReturn);
            this.PageGroup_Store.ItemLinks.Add(this.Button_StoreIssueNote);
            this.PageGroup_Store.ItemLinks.Add(this.Store_ReceiveNote);
            this.PageGroup_Store.ItemLinks.Add(this.SubMenu_Reports_Store);
            this.PageGroup_Store.ItemLinks.Add(this.Store_Opening);
            this.PageGroup_Store.ItemLinks.Add(this.StoreLocations);
            this.PageGroup_Store.ItemLinks.Add(this.DepartmentRequisitionSlip);
            this.PageGroup_Store.ItemLinks.Add(this.RequestApproval);
            this.PageGroup_Store.ItemLinks.Add(this.Store_RequisitionList);
            this.PageGroup_Store.Name = "PageGroup_Store";
            this.PageGroup_Store.Text = "Store";
            // 
            // StoreParametersPageGroup
            // 
            this.StoreParametersPageGroup.ItemLinks.Add(this.Store_UnitsMeasurements);
            this.StoreParametersPageGroup.ItemLinks.Add(this.Store_Origins);
            this.StoreParametersPageGroup.Name = "StoreParametersPageGroup";
            this.StoreParametersPageGroup.Text = "Parameters";
            // 
            // page_Production
            // 
            this.page_Production.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PG_Production_Warping,
            this.PG_Production_Sizing,
            this.PG_Production_ReportsWarping,
            this.PG_Production_ReportsSizing});
            this.page_Production.ImageIndex = 60;
            this.page_Production.Name = "page_Production";
            this.page_Production.Text = "Production";
            // 
            // PG_Production_Warping
            // 
            this.PG_Production_Warping.ItemLinks.Add(this.bbi_Data_Warping_Beams);
            this.PG_Production_Warping.ItemLinks.Add(this.bbi_Data_Warping_Machines);
            this.PG_Production_Warping.ItemLinks.Add(this.bbi_Data_Warping_Main);
            this.PG_Production_Warping.Name = "PG_Production_Warping";
            this.PG_Production_Warping.Text = "Warping";
            // 
            // PG_Production_Sizing
            // 
            this.PG_Production_Sizing.ItemLinks.Add(this.bbi_Data_Sizing_Beams);
            this.PG_Production_Sizing.ItemLinks.Add(this.bbi_Data_Sizing_Chemicals);
            this.PG_Production_Sizing.ItemLinks.Add(this.bbi_Data_Sizing_Main);
            this.PG_Production_Sizing.ItemLinks.Add(this.Production_OutSideSizing);
            this.PG_Production_Sizing.ItemLinks.Add(this.ButtonProductionSectionWarping);
            this.PG_Production_Sizing.ItemLinks.Add(this.barSubItem10);
            this.PG_Production_Sizing.Name = "PG_Production_Sizing";
            this.PG_Production_Sizing.Text = "Sizing";
            // 
            // PG_Production_ReportsWarping
            // 
            this.PG_Production_ReportsWarping.ItemLinks.Add(this.mrip_Warping);
            this.PG_Production_ReportsWarping.Name = "PG_Production_ReportsWarping";
            this.PG_Production_ReportsWarping.Text = "Warping";
            // 
            // PG_Production_ReportsSizing
            // 
            this.PG_Production_ReportsSizing.ItemLinks.Add(this.mrip_Sizing);
            this.PG_Production_ReportsSizing.Name = "PG_Production_ReportsSizing";
            this.PG_Production_ReportsSizing.Text = "Sizing";
            // 
            // page_inspectionanddelivery
            // 
            this.page_inspectionanddelivery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup_Towel,
            this.ribbonPageGroup_Greige});
            this.page_inspectionanddelivery.ImageIndex = 144;
            this.page_inspectionanddelivery.Name = "page_inspectionanddelivery";
            this.page_inspectionanddelivery.Text = "Inspection and Delivery";
            // 
            // ribbonPageGroup_Towel
            // 
            this.ribbonPageGroup_Towel.ItemLinks.Add(this.barSubItem_Towel_OpeningMenu);
            this.ribbonPageGroup_Towel.ItemLinks.Add(this.barButtonItem_Towel_Inspection);
            this.ribbonPageGroup_Towel.ItemLinks.Add(this.barButtonItem_PackingList_Towel);
            this.ribbonPageGroup_Towel.ItemLinks.Add(this.barSubItem_Reports_Towel);
            this.ribbonPageGroup_Towel.Name = "ribbonPageGroup_Towel";
            this.ribbonPageGroup_Towel.Text = "Towel";
            // 
            // ribbonPageGroup_Greige
            // 
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.barSubItem_Opening_Greige_Menu);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.barButtonItem_Inspection_Greige);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.Inspection_OutsideWeaving);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.barButtonItem_TaketoGodown_Greige);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.barButtonItem_PackingList_Greige);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.Greige_FabricReturn);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.Greige_ReCheck);
            this.ribbonPageGroup_Greige.ItemLinks.Add(this.barSubItem_Reports_Greige_Menu);
            this.ribbonPageGroup_Greige.Name = "ribbonPageGroup_Greige";
            this.ribbonPageGroup_Greige.Text = "Greige";
            // 
            // page_HR
            // 
            this.page_HR.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PG_HR_Employees});
            this.page_HR.ImageIndex = 5;
            this.page_HR.Name = "page_HR";
            this.page_HR.Text = "Human Resource";
            // 
            // PG_HR_Employees
            // 
            this.PG_HR_Employees.ItemLinks.Add(this.PGB_Employees_Employee);
            this.PG_HR_Employees.ItemLinks.Add(this.PGB_Employees_Departments);
            this.PG_HR_Employees.Name = "PG_HR_Employees";
            this.PG_HR_Employees.Text = "Employees Management";
            // 
            // page_Accounts
            // 
            this.page_Accounts.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PG_Accounts_ChartofAccounts,
            this.PG_Accounts_Payments,
            this.PG_Accounts_Receipts,
            this.PG_Accounts_General,
            this.PG_Accounts_Purchases,
            this.PG_Accounts_Reports,
            this.ribbonPageGroup_FinYears});
            this.page_Accounts.ImageIndex = 138;
            this.page_Accounts.Name = "page_Accounts";
            this.page_Accounts.Text = "Accounts and Finance";
            // 
            // PG_Accounts_ChartofAccounts
            // 
            this.PG_Accounts_ChartofAccounts.ItemLinks.Add(this.Accounts_ChartofAccountsTree);
            this.PG_Accounts_ChartofAccounts.ItemLinks.Add(this.Refresh_Accounts);
            this.PG_Accounts_ChartofAccounts.ItemLinks.Add(this.Accounts_MappedAccounts);
            this.PG_Accounts_ChartofAccounts.ItemLinks.Add(this.Accounts_ChartOfAccount_TabView);
            this.PG_Accounts_ChartofAccounts.Name = "PG_Accounts_ChartofAccounts";
            this.PG_Accounts_ChartofAccounts.Text = "Chart of Accounts";
            // 
            // PG_Accounts_Payments
            // 
            this.PG_Accounts_Payments.ItemLinks.Add(this.Accounts_CashPayment);
            this.PG_Accounts_Payments.ItemLinks.Add(this.Accounts_BankPayment);
            this.PG_Accounts_Payments.ItemLinks.Add(this.Accounts_PaymentAdvice);
            this.PG_Accounts_Payments.ItemLinks.Add(this.MDC);
            this.PG_Accounts_Payments.Name = "PG_Accounts_Payments";
            this.PG_Accounts_Payments.Text = "Payments";
            // 
            // PG_Accounts_Receipts
            // 
            this.PG_Accounts_Receipts.ItemLinks.Add(this.Accounts_CashReceipt);
            this.PG_Accounts_Receipts.ItemLinks.Add(this.Accounts_BankReceipt);
            this.PG_Accounts_Receipts.Name = "PG_Accounts_Receipts";
            this.PG_Accounts_Receipts.Text = "Receipts";
            // 
            // PG_Accounts_General
            // 
            this.PG_Accounts_General.ItemLinks.Add(this.Accounts_FabricSales);
            this.PG_Accounts_General.ItemLinks.Add(this.Accounts_SalesReturnFabric);
            this.PG_Accounts_General.ItemLinks.Add(this.Accounts_GeneralVoucher);
            this.PG_Accounts_General.Name = "PG_Accounts_General";
            this.PG_Accounts_General.Text = "General";
            // 
            // PG_Accounts_Purchases
            // 
            this.PG_Accounts_Purchases.ItemLinks.Add(this.Accounts_PurchaseMenu);
            this.PG_Accounts_Purchases.ItemLinks.Add(this.Accounts_StoreCashPurchases);
            this.PG_Accounts_Purchases.ItemLinks.Add(this.Accounts_CreditStorePurchases);
            this.PG_Accounts_Purchases.Name = "PG_Accounts_Purchases";
            this.PG_Accounts_Purchases.Text = "Purchases & Returns";
            // 
            // PG_Accounts_Reports
            // 
            this.PG_Accounts_Reports.ItemLinks.Add(this.AccountsReports_Menu);
            this.PG_Accounts_Reports.Name = "PG_Accounts_Reports";
            this.PG_Accounts_Reports.Text = "Reports";
            // 
            // ribbonPageGroup_FinYears
            // 
            this.ribbonPageGroup_FinYears.ItemLinks.Add(this.barSubItem_FinancialYears);
            this.ribbonPageGroup_FinYears.Name = "ribbonPageGroup_FinYears";
            this.ribbonPageGroup_FinYears.Text = "Financial Years";
            // 
            // page_Tools
            // 
            this.page_Tools.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup11,
            this.ribbonPageGroup6,
            this.ribbonPageGroup22,
            this.rpgFont,
            this.ribbonPageGroupFontSize,
            this.rpgFontColor,
            this.ribbonPageGroup8,
            this.ribbonPageGroupDebug});
            this.page_Tools.ImageIndex = 67;
            this.page_Tools.Name = "page_Tools";
            this.page_Tools.Text = "Tools";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.rgbiSkins);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.ShowCaptionButton = false;
            this.ribbonPageGroup11.Text = "Skins";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ImageIndex = 26;
            this.ribbonPageGroup6.ItemLinks.Add(this.bbi_Tools_RPMColors);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbi_Tools_EffColors);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbi_Tools_EffFont);
            this.ribbonPageGroup6.ItemLinks.Add(this.bbi_Tool_ClassicViewColors);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            this.ribbonPageGroup6.Text = "Indication Management";
            // 
            // ribbonPageGroup22
            // 
            this.ribbonPageGroup22.ItemLinks.Add(this.bbi_Tools_SMSSettings);
            this.ribbonPageGroup22.ItemLinks.Add(this.bbi_SMSDeviceAndServiceStatus);
            this.ribbonPageGroup22.ItemLinks.Add(this.EmailSettings);
            this.ribbonPageGroup22.Name = "ribbonPageGroup22";
            this.ribbonPageGroup22.Text = "SMS && Email Management";
            // 
            // rpgFont
            // 
            this.rpgFont.ItemLinks.Add(this.rgbiFont);
            this.rpgFont.Name = "rpgFont";
            toolTipTitleItem5.Text = "Font Dialog";
            toolTipItem4.Text = "Show the Font dialog box";
            superToolTip4.Items.Add(toolTipTitleItem5);
            superToolTip4.Items.Add(toolTipItem4);
            this.rpgFont.SuperTip = superToolTip4;
            this.rpgFont.Text = "Font";
            // 
            // ribbonPageGroupFontSize
            // 
            this.ribbonPageGroupFontSize.ItemLinks.Add(this.FontSizeControl);
            this.ribbonPageGroupFontSize.Name = "ribbonPageGroupFontSize";
            this.ribbonPageGroupFontSize.Text = "Font Size";
            // 
            // rpgFontColor
            // 
            this.rpgFontColor.ItemLinks.Add(this.rgbiFontColor);
            this.rpgFontColor.Name = "rpgFontColor";
            toolTipTitleItem6.Text = "Color Edit";
            toolTipItem5.Text = "Show the Color edit popup";
            superToolTip5.Items.Add(toolTipTitleItem6);
            superToolTip5.Items.Add(toolTipItem5);
            this.rpgFontColor.SuperTip = superToolTip5;
            this.rpgFontColor.Text = "Font Color";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ImageIndex = 25;
            this.ribbonPageGroup8.ItemLinks.Add(this.iWeb);
            this.ribbonPageGroup8.ItemLinks.Add(this.iAbout);
            this.ribbonPageGroup8.ItemLinks.Add(this.bbi_AutomaticUpdate);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.ShowCaptionButton = false;
            this.ribbonPageGroup8.Text = "Help";
            // 
            // ribbonPageGroupDebug
            // 
            this.ribbonPageGroupDebug.ItemLinks.Add(this.bbi_Debug_DebugMode);
            this.ribbonPageGroupDebug.ItemLinks.Add(this.bbi_Debug_WaitingTimeButton);
            this.ribbonPageGroupDebug.ItemLinks.Add(this.ValidateMoreSecure);
            this.ribbonPageGroupDebug.ItemLinks.Add(this.bbiALUGPU);
            this.ribbonPageGroupDebug.ItemLinks.Add(this.ButtonFuction);
            this.ribbonPageGroupDebug.Name = "ribbonPageGroupDebug";
            this.ribbonPageGroupDebug.Text = "Debug Settings";
            // 
            // rib_Hidden
            // 
            this.rib_Hidden.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPGWeaving,
            this.ribbonPageGroup17,
            this.ribbonPageGroup_ClassicalView});
            this.rib_Hidden.Name = "rib_Hidden";
            this.rib_Hidden.Text = "Hidden";
            this.rib_Hidden.Visible = false;
            // 
            // ribbonPGWeaving
            // 
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_Weavers);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_Technician);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_Beam);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_CurrentLoomInfo);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbiSubMenu_AssignStopCause);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_Assign_FDNI);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbiSubMenu_AssignToGroup);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbiSubMenu_AssignPosition);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_CurrentLoomStats);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_Article);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_Loom_Log);
            this.ribbonPGWeaving.ItemLinks.Add(this.bbi_Data_AssignLoom_FDNE);
            this.ribbonPGWeaving.Name = "ribbonPGWeaving";
            this.ribbonPGWeaving.Text = "Assign On Loom";
            this.ribbonPGWeaving.Visible = false;
            // 
            // ribbonPageGroup17
            // 
            this.ribbonPageGroup17.ItemLinks.Add(this.bbi_Data_Knotting_Main);
            this.ribbonPageGroup17.Name = "ribbonPageGroup17";
            this.ribbonPageGroup17.Text = "Knotting";
            // 
            // ribbonPageGroup_ClassicalView
            // 
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_Efficiency);
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_RPMView);
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_WarpView);
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_WeftView);
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_WarpKnottView);
            this.ribbonPageGroup_ClassicalView.ItemLinks.Add(this.ClassicalCheck_WeftKnottView);
            this.ribbonPageGroup_ClassicalView.Name = "ribbonPageGroup_ClassicalView";
            this.ribbonPageGroup_ClassicalView.Text = "Classical View";
            this.ribbonPageGroup_ClassicalView.Visible = false;
            // 
            // ribbonPage_Tracking
            // 
            this.ribbonPage_Tracking.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup_TrackingVehiclesInfo,
            this.ribbonPageGroup_EarthPlugin});
            this.ribbonPage_Tracking.Name = "ribbonPage_Tracking";
            this.ribbonPage_Tracking.Text = "Tracking";
            // 
            // ribbonPageGroup_TrackingVehiclesInfo
            // 
            this.ribbonPageGroup_TrackingVehiclesInfo.ItemLinks.Add(this.Button_ManageVehicles);
            this.ribbonPageGroup_TrackingVehiclesInfo.ItemLinks.Add(this.Tracking_VehicleMakes);
            this.ribbonPageGroup_TrackingVehiclesInfo.ItemLinks.Add(this.Tracking_VehicleModels);
            this.ribbonPageGroup_TrackingVehiclesInfo.ItemLinks.Add(this.Tracking_VehicleTypes);
            this.ribbonPageGroup_TrackingVehiclesInfo.Name = "ribbonPageGroup_TrackingVehiclesInfo";
            this.ribbonPageGroup_TrackingVehiclesInfo.Text = "Vehicles Management";
            // 
            // ribbonPageGroup_EarthPlugin
            // 
            this.ribbonPageGroup_EarthPlugin.ItemLinks.Add(this.barButtonItem_GoogleEarth);
            this.ribbonPageGroup_EarthPlugin.ItemLinks.Add(this.barSubItem_PluginOptions);
            this.ribbonPageGroup_EarthPlugin.Name = "ribbonPageGroup_EarthPlugin";
            this.ribbonPageGroup_EarthPlugin.Text = "Earth Plugin";
            // 
            // riicStyle
            // 
            this.riicStyle.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.riicStyle.Appearance.Options.UseFont = true;
            this.riicStyle.AutoHeight = false;
            this.riicStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riicStyle.Name = "riicStyle";
            this.riicStyle.UseParentBackground = true;
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            this.repositoryItemRadioGroup1.UseParentBackground = true;
            // 
            // repositoryItemRadioGroup2
            // 
            this.repositoryItemRadioGroup2.Name = "repositoryItemRadioGroup2";
            this.repositoryItemRadioGroup2.UseParentBackground = true;
            // 
            // repositoryItemRadioGroup3
            // 
            this.repositoryItemRadioGroup3.Name = "repositoryItemRadioGroup3";
            this.repositoryItemRadioGroup3.UseParentBackground = true;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.UseParentBackground = true;
            // 
            // repositoryItemComboBox_AssesmentYear
            // 
            this.repositoryItemComboBox_AssesmentYear.AutoHeight = false;
            this.repositoryItemComboBox_AssesmentYear.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox_AssesmentYear.Name = "repositoryItemComboBox_AssesmentYear";
            this.repositoryItemComboBox_AssesmentYear.UseParentBackground = true;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.bar_ServiceStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.bar_Progress);
            this.ribbonStatusBar1.ItemLinks.Add(this.bar_Shift);
            this.ribbonStatusBar1.ItemLinks.Add(this.Company);
            this.ribbonStatusBar1.ItemLinks.Add(this.FinancialYear);
            this.ribbonStatusBar1.ItemLinks.Add(this.bar_AutomaticUpdate);
            this.ribbonStatusBar1.ItemLinks.Add(this.ButtonEfficiencyType);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 747);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1342, 25);
            // 
            // siDocName
            // 
            this.siDocName.CategoryGuid = new System.Guid("77795bb7-9bc5-4dd2-a297-cc758682e23d");
            this.siDocName.Id = 2;
            this.siDocName.Name = "siDocName";
            this.siDocName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // pmNew
            // 
            this.pmNew.Name = "pmNew";
            this.pmNew.Ribbon = this.ribbonControl1;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Black";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabbedMdiManager1.MdiParent = this;
            this.xtraTabbedMdiManager1.FloatMDIChildActivated += new System.EventHandler(this.xtraTabbedMdiManager1_FloatMDIChildActivated);
            this.xtraTabbedMdiManager1.FloatMDIChildDeactivated += new System.EventHandler(this.xtraTabbedMdiManager1_FloatMDIChildDeactivated);
            // 
            // pmMain
            // 
            this.pmMain.MenuCaption = "Edit Menu";
            this.pmMain.Name = "pmMain";
            this.pmMain.Ribbon = this.ribbonControl1;
            this.pmMain.ShowCaption = true;
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageSize = new System.Drawing.Size(15, 15);
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            // 
            // bbiUserManagement
            // 
            this.bbiUserManagement.Caption = "&User Management";
            this.bbiUserManagement.CategoryGuid = new System.Guid("4b511317-d784-42ba-b4ed-0d2a746d6c1f");
            this.bbiUserManagement.Description = "Prints the active document.";
            this.bbiUserManagement.Hint = "Prints the active document";
            this.bbiUserManagement.Id = 5;
            this.bbiUserManagement.ImageIndex = 9;
            this.bbiUserManagement.LargeImageIndex = 6;
            this.bbiUserManagement.Name = "bbiUserManagement";
            this.bbiUserManagement.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // imageCollection_Main
            // 
            this.imageCollection_Main.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection_Main.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection_Main.ImageStream")));
            this.imageCollection_Main.Images.SetKeyName(0, "blend.jpg");
            this.imageCollection_Main.Images.SetKeyName(1, "contacts.png");
            this.imageCollection_Main.Images.SetKeyName(2, "inspection.png");
            this.imageCollection_Main.Images.SetKeyName(3, "Knotting.png");
            this.imageCollection_Main.Images.SetKeyName(4, "login.png");
            this.imageCollection_Main.Images.SetKeyName(5, "poweroff.png");
            this.imageCollection_Main.Images.SetKeyName(6, "reports.png");
            this.imageCollection_Main.Images.SetKeyName(7, "security.png");
            this.imageCollection_Main.Images.SetKeyName(8, "sizing.png");
            this.imageCollection_Main.Images.SetKeyName(9, "warp.png");
            this.imageCollection_Main.Images.SetKeyName(10, "yarn.png");
            this.imageCollection_Main.Images.SetKeyName(11, "FabricArticle.png");
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Selection";
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            this.ribbonPageGroup13.Text = "Format";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "Edit";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ribbonGalleryBarItem1
            // 
            this.ribbonGalleryBarItem1.Caption = "Color";
            // 
            // 
            // 
            this.ribbonGalleryBarItem1.Gallery.ColumnCount = 10;
            galleryItemGroup9.Caption = "Main";
            this.ribbonGalleryBarItem1.Gallery.Groups.AddRange(new DevExpress.XtraBars.Ribbon.GalleryItemGroup[] {
            galleryItemGroup9});
            this.ribbonGalleryBarItem1.Gallery.ImageSize = new System.Drawing.Size(10, 7);
            this.ribbonGalleryBarItem1.Gallery.CustomDrawItemImage += new DevExpress.XtraBars.Ribbon.GalleryItemCustomDrawEventHandler(this.gddFontColor_Gallery_CustomDrawItemImage);
            this.ribbonGalleryBarItem1.GalleryDropDown = this.gddFontColor;
            this.ribbonGalleryBarItem1.Id = 37;
            this.ribbonGalleryBarItem1.Name = "ribbonGalleryBarItem1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ImageIndex = 4;
            this.ribbonPageGroup7.ItemLinks.Add(this.iFont);
            this.ribbonPageGroup7.ItemLinks.Add(this.iFontColor);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            this.ribbonPageGroup7.Text = "Font";
            this.ribbonPageGroup7.Visible = false;
            // 
            // Alert
            // 
            this.Alert.AutoFormDelay = 15000;
            this.Alert.AutoHeight = true;
            this.Alert.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Slow;
            // 
            // CauseImages
            // 
            this.CauseImages.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("CauseImages.ImageStream")));
            this.CauseImages.Images.SetKeyName(0, "Unknown");
            this.CauseImages.Images.SetKeyName(1, "Warp");
            this.CauseImages.Images.SetKeyName(2, "Weft");
            this.CauseImages.Images.SetKeyName(3, "Leno");
            this.CauseImages.Images.SetKeyName(4, "Other");
            this.CauseImages.Images.SetKeyName(5, "Pile");
            this.CauseImages.Images.SetKeyName(6, "Mechanical");
            this.CauseImages.Images.SetKeyName(7, "Electrical");
            this.CauseImages.Images.SetKeyName(8, "Knotting");
            this.CauseImages.Images.SetKeyName(9, "Article");
            this.CauseImages.Images.SetKeyName(10, "OtherLong");
            this.CauseImages.Images.SetKeyName(11, "PowerOff");
            this.CauseImages.Images.SetKeyName(12, "Beamshort.png");
            this.CauseImages.Images.SetKeyName(13, "Cut.png");
            this.CauseImages.Images.SetKeyName(14, "MechanicalAndPowerOff");
            this.CauseImages.Images.SetKeyName(15, "ElectricalAndPowerOff");
            this.CauseImages.Images.SetKeyName(16, "KnottingAndPowerOff");
            this.CauseImages.Images.SetKeyName(17, "ArticleAndPowerOff");
            this.CauseImages.Images.SetKeyName(18, "Beamshortandpoweroff.png");
            this.CauseImages.Images.SetKeyName(19, "Cutandpoweroff.png");
            this.CauseImages.Images.SetKeyName(20, "NORPM");
            this.CauseImages.Images.SetKeyName(21, "DNI16.png");
            this.CauseImages.Images.SetKeyName(22, "FDNI16.png");
            this.CauseImages.Images.SetKeyName(23, "SecurityAllowed.png");
            this.CauseImages.Images.SetKeyName(24, "SecurityNotAllowed.png");
            this.CauseImages.Images.SetKeyName(25, "Security_About.png");
            this.CauseImages.Images.SetKeyName(26, "security_Accounts.png");
            this.CauseImages.Images.SetKeyName(27, "Security_dashboard.png");
            this.CauseImages.Images.SetKeyName(28, "security_Debug.png");
            this.CauseImages.Images.SetKeyName(29, "Security_Display.png");
            this.CauseImages.Images.SetKeyName(30, "Security_HR.png");
            this.CauseImages.Images.SetKeyName(31, "security_inspection.png");
            this.CauseImages.Images.SetKeyName(32, "Security_Planning.png");
            this.CauseImages.Images.SetKeyName(33, "Security_Production.png");
            this.CauseImages.Images.SetKeyName(34, "Security_security.png");
            this.CauseImages.Images.SetKeyName(35, "Security_Status.png");
            this.CauseImages.Images.SetKeyName(36, "Security_Unassigned.png");
            this.CauseImages.Images.SetKeyName(37, "Security_Update.png");
            this.CauseImages.Images.SetKeyName(38, "Security_Weaving.png");
            this.CauseImages.Images.SetKeyName(39, "Security_Yarn.png");
            // 
            // CauseImagesBlack
            // 
            this.CauseImagesBlack.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("CauseImagesBlack.ImageStream")));
            this.CauseImagesBlack.Images.SetKeyName(0, "Unknown");
            this.CauseImagesBlack.Images.SetKeyName(1, "warp.png");
            this.CauseImagesBlack.Images.SetKeyName(2, "weft.png");
            this.CauseImagesBlack.Images.SetKeyName(3, "leno.png");
            this.CauseImagesBlack.Images.SetKeyName(4, "other.png");
            this.CauseImagesBlack.Images.SetKeyName(5, "Pile");
            this.CauseImagesBlack.Images.SetKeyName(6, "Mechanical");
            this.CauseImagesBlack.Images.SetKeyName(7, "Electrical");
            this.CauseImagesBlack.Images.SetKeyName(8, "Knotting");
            this.CauseImagesBlack.Images.SetKeyName(9, "Article");
            this.CauseImagesBlack.Images.SetKeyName(10, "OtherLong");
            this.CauseImagesBlack.Images.SetKeyName(11, "PowerOff.png");
            this.CauseImagesBlack.Images.SetKeyName(12, "MechanicalAndPowerOff");
            this.CauseImagesBlack.Images.SetKeyName(13, "ElectricalAndPowerOff");
            this.CauseImagesBlack.Images.SetKeyName(14, "KnottingAndPowerOff");
            this.CauseImagesBlack.Images.SetKeyName(15, "ArticleAndPowerOff");
            this.CauseImagesBlack.Images.SetKeyName(16, "NORPM");
            this.CauseImagesBlack.Images.SetKeyName(17, "DNI16.png");
            this.CauseImagesBlack.Images.SetKeyName(18, "FDNI16.png");
            this.CauseImagesBlack.Images.SetKeyName(19, "SecurityAllowed.png");
            this.CauseImagesBlack.Images.SetKeyName(20, "SecurityNotAllowed.png");
            this.CauseImagesBlack.Images.SetKeyName(21, "Security_About.png");
            this.CauseImagesBlack.Images.SetKeyName(22, "security_Accounts.png");
            this.CauseImagesBlack.Images.SetKeyName(23, "Security_dashboard.png");
            this.CauseImagesBlack.Images.SetKeyName(24, "security_Debug.png");
            this.CauseImagesBlack.Images.SetKeyName(25, "Security_Display.png");
            this.CauseImagesBlack.Images.SetKeyName(26, "Security_HR.png");
            this.CauseImagesBlack.Images.SetKeyName(27, "security_inspection.png");
            this.CauseImagesBlack.Images.SetKeyName(28, "Security_Planning.png");
            this.CauseImagesBlack.Images.SetKeyName(29, "Security_Production.png");
            this.CauseImagesBlack.Images.SetKeyName(30, "Security_security.png");
            this.CauseImagesBlack.Images.SetKeyName(31, "Security_Status.png");
            this.CauseImagesBlack.Images.SetKeyName(32, "Security_Unassigned.png");
            this.CauseImagesBlack.Images.SetKeyName(33, "Security_Update.png");
            this.CauseImagesBlack.Images.SetKeyName(34, "Security_Weaving.png");
            this.CauseImagesBlack.Images.SetKeyName(35, "Security_Yarn.png");
            // 
            // ribbonPageGroup_ClassicalViewMenu
            // 
            this.ribbonPageGroup_ClassicalViewMenu.Name = "ribbonPageGroup_ClassicalViewMenu";
            this.ribbonPageGroup_ClassicalViewMenu.Text = "ClassicalView Menu";
            // 
            // rP_DailyShiftSummaryTableAdapter
            // 
            this.rP_DailyShiftSummaryTableAdapter.ClearBeforeFill = true;
            // 
            // frmMain
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(9, 20);
            this.ClientSize = new System.Drawing.Size(1342, 772);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Machine Eyes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.Click += new System.EventHandler(this.frmMain_Click);
            ((System.ComponentModel.ISupportInitialize)(this.popupControlContainer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmAppMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gddFontColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bbi_Debug_WaitingTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit_LoomForTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riicStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox_AssesmentYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pmMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CauseImagesBlack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.PopupControlContainer popupControlContainer1;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.PopupMenu pmNew;
        private DevExpress.XtraBars.PopupMenu pmMain;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu pmAppMain;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ImageCollection imageCollection3;
       
       
        private BarButtonItem bbiUserManagement;
        private DevExpress.Utils.ImageCollection imageCollection_Main;
       
       
        private BarButtonItem bbi_Data_Article_Insertion;
       
      
      
        private BarButtonItem iFont;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown gddFont;
        private BarButtonItem iWeb;
        private BarButtonItem iAbout;
        private BarButtonItem bbi_Debug_DebugMode;
        private BarButtonItem bbi_Tools_RPMColors;
        private BarButtonItem bbi_Tools_EffColors;
        private BarButtonItem iFontColor;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown gddFontColor;
        
        private BarStaticItem siDocName;
        private BarSubItem sbiShed;
      
        private BarSubItem iPaintStyle;
        private RibbonGalleryBarItem rgbiSkins;
        private BarEditItem beiFontSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private RibbonGalleryBarItem rgbiFont;
        private BarButtonItem bbiFontColorPopup;
        private RibbonGalleryBarItem rgbiFontColor;
        private BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox riicStyle;
    
        private BarButtonItem bbi_Data_Article_Selvage;
        private BarButtonItem bbi_Data_Article_Weave;
        private BarButtonItem bbi_Data_Warping_Beams;
        private BarButtonItem bbi_Data_Warping_Machines;
        private BarButtonItem bbi_Data_Warping_Main;
        private BarButtonItem bbi_Data_Sizing_Beams;
        private BarButtonItem bbi_Data_Sizing_Chemicals;
        private BarButtonItem bbi_Data_Sizing_Main;
        private BarButtonItem bbi_Data_Knotting_Main;
       
       
       
        private BarButtonItem bbi_DashBoard_SizingView;
        private BarButtonItem bbi_Dashboard_ArticleEfficiency;
        private BarButtonItem bbi_Dashboard_ExecutiveSummary;
       
        private BarButtonItem bbi_Tools_SMSSettings;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage page_LDS;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Dashboard_Shed;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Dashboard_Sizing;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Dashboard_Weavers;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Dashboard_Articles;
        private DevExpress.XtraBars.Ribbon.RibbonPage page_Planning;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Planning_Articles;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Yarn_YarnContractManagement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Production_Warping;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PG_Production_Sizing;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup17;
        private DevExpress.XtraBars.Ribbon.RibbonPage page_Tools;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup22;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFont;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFontColor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
     
        private BarButtonItem bbiUsersandRights;
      
        private BarSubItem barSubItem1;
       
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPGWeaving;

        private BarButtonItem bbi_LockApp;
        private BarCheckItem bci_DashBoard_DesignMove;
        private BarButtonItem bbi_DashBoard_DesignSave;
        private BarButtonItem bar_ServiceStatus;
        private System.Windows.Forms.Timer timer1;
        private ToolTipController toolTipController1;
        public BarButtonItem bbi_Dashboard_ShedEff;
        private BarButtonItem bar_Progress;
        
       
        public RibbonControl ribbonControl1;
        public BarButtonItem bbi_Data_AssignLoom_Weavers;
        public BarButtonItem bbi_Data_AssignLoom_Technician;
        public BarButtonItem bbi_Data_AssignLoom_Beam;
        public BarButtonItem bbi_Data_AssignLoom_CurrentLoomInfo;
        public BarSubItem bbiSubMenu_AssignStopCause;
        public BarCheckItem barAssign_Mechanical;
        public BarCheckItem barAssign_Electrical;
        private BarCheckItem barAssign_Knotting;
        private BarCheckItem barAssign_ArticleChange;
        private BarCheckItem barAssign_OtherStop;
        public BarButtonItem bbi_Data_Assign_FDNI;
        private RibbonPageGroup ribbonPageGroupDebug;
        public BarEditItem bbi_Debug_WaitingTimeButton;
        public DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit bbi_Debug_WaitingTime;
        private RibbonPageGroup ribbonPageGroup_DailyEfficiency;
        public BarButtonItem bar_Shift;
       
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup3;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup2;
        private RibbonGalleryBarItem ribbonGalleryBarItem1;
        public BarSubItem bbiSubMenu_AssignToGroup;
        private BarButtonItem bbi_Dashboard_DesignSaveGroup;
        private BarCheckItem bbi_DashBoard_DesignMoveGroup;
        private BarButtonItem bbi_ShedGraph_View;
        private BarButtonItem bbi_AutomaticUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
     
       
       
        public BarSubItem bbiSubMenu_AssignPosition;
      
       
     
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private BarEditItem barAssign_TopSpin;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit_LoomForTop;
        private BarSubItem barSubItem_Drawingleft;
        private BarButtonItem bbi_SetLoomLeft;
        private BarButtonItem bbi_SetLoomLeftRef;
        private BarSubItem barSubItem_DrawingTop;
        private BarButtonItem bbi_SetLoomTop;
        private BarButtonItem bbi_SetLoomTopRef;
        private BarStaticItem barStaticItem1;
        private BarStaticItem barStaticItem2;
        private BarStaticItem barStaticItem3;
        private BarSubItem bbi_Shed;
        private BarSubItem barSubItem2;
        private BarSubItem rpi_DailyShiftSummary;
        private RibbonPageGroup PG_Production_ReportsWarping;
        private RibbonPageGroup PG_Production_ReportsSizing;
        private BarSubItem mrip_Warping;
        private BarSubItem mrip_Sizing;
        private BarStaticItem barStaticItem4;
        private RibbonPage rib_Hidden;
        private RibbonPageGroup ribbonPageGroup7;
        private BarSubItem mdata_Yarn;
        private BarSubItem mYarnData_Params;
        private BarSubItem bbiDebugFunction;
        private BarButtonItem mYarnData_Counts;
        private BarButtonItem mYarnData_Brands;
        private BarButtonItem mYarnData_Blends;
        private BarButtonItem mYarnData_Twsits;
        private BarButtonItem mYarnData_PaperConeColors;
        private BarSubItem mYarnData_Contracts;
       
      
       
        private BarButtonItem mYarnData_ConeWeight;
       
       
        private BarButtonItem Accounts_MappedAccounts;
        private BarButtonItem mYarnData_ConesPerBag;
        private BarButtonItem mYarnData_LbsPerBag;
     
       
        private BarButtonItem mYarnData_CottonOrigin;
        private BarButtonItem mYarnData_YarnDesc;
       
       
       
        private BarButtonItem bbi_Tools_EffFont;
        public BarButtonItem bbi_Data_AssignLoom_CurrentLoomStats;
      
        private BarSubItem barContracts;
        private BarSubItem barSubItem5;
     
        private BarSubItem barSubItem6;
        private BarSubItem barSubItem7;
       
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox_AssesmentYear;

        private DevExpress.XtraBars.Alerter.AlertControl Alert = new DevExpress.XtraBars.Alerter.AlertControl();
        private RibbonPage page_Yarn;
        private RibbonPage page_Production;
        private RibbonPage page_inspectionanddelivery;
        private RibbonPage page_HR;
        private RibbonPage page_Accounts;
        private BarButtonItem PGB_ArticleChangeSheet;
        private RibbonPageGroup PG_Planning_ArticleChangeSheet;
        private BarButtonItem YarnContract;
        private BarButtonItem YarnReceiveNote;
        private RibbonPageGroup PG_Yarn_GRNGIN;
        private BarButtonItem YarnIssueNote;
        private BarButtonItem YarnDemandNote;
        private BarButtonItem YarnRequisitionNote;
        private BarButtonItem DesignChangeSheet;
        private RibbonPageGroup PG_Accounts_ChartofAccounts;
        private BarButtonItem Accounts_ChartofAccountsTree;
        public ImageCollection CauseImages;
        public BarButtonItem bbi_Data_AssignLoom_Article;
        private BarSubItem bbi_Summary;
        private BarSubItem bbi_WeaverMain;
        private BarSubItem bbi_WeaversScroll;
        public BarButtonItem bbi_Data_Loom_Log;
        private BarButtonItem Refresh_Accounts;
        private RibbonPageGroup PG_Accounts_Payments;
        private BarButtonItem Accounts_CashPayment;
        private BarButtonItem Accounts_BankPayment;
        private RibbonPageGroup PG_Accounts_Receipts;
        private BarButtonItem Accounts_CashReceipt;
        private BarButtonItem Accounts_BankReceipt;
        public BarButtonItem FinancialYear;
        public BarButtonItem bbi_Data_AssignLoom_FDNE;
        private BarButtonItem Accounts_FabricSales;
        private BarButtonItem Accounts_SalesReturnFabric;
        private RibbonPageGroup PG_Accounts_General;
        private BarSubItem AccountsReports_Menu;
        private RibbonPageGroup PG_Accounts_Reports;
        private BarButtonItem Accounts_GeneralLedger;
        private BarButtonItem Accounts_GeneralVoucher;
        private BarButtonItem Accounts_PeriodicTrialBalance;
        public BarButtonItem Company;
        private BarButtonItem Accounts_OpeningBalances_G;
        private BarButtonItem Accounts_DailyCashAndBankTransactionReport;
        private BarButtonItem Accounts_AuditTrailReport;
        private BarSubItem AccountsMenu_Ledger;
        private BarButtonItem Accounts_Generalledger_AI_Cash;
        private BarButtonItem Accounts_Generalledger_AI_Bank;
        private BarSubItem Accounts_OpeningMenu;
        private BarButtonItem Accounts_OpeningBalances_N;
        private BarButtonItem Accounts_OpeningBalances_B;
        private BarSubItem Accounts_SalesTaxReturn_Menu;
        private BarButtonItem Accounts_STAnnexC;
        private RibbonPageGroup PG_Accounts_Purchases;
        private BarSubItem Accounts_PurchaseMenu;
        private BarButtonItem Accounts_YarnPurchases;
        private BarButtonItem Accounts_FabricPurchases;
     
       
        private BarButtonItem Accounts_OtherPurchases;
        private BarButtonItem PGB_Employees_Employee;
        private RibbonPageGroup PG_HR_Employees;
        private BarButtonItem PGB_Employees_Departments;
        private BarButtonItem bbi_UnlockApp;
        private BarButtonItem bbiCurrentSession;
        private BarButtonItem bbiwhatcanido;
        private BarButtonItem bbiChangePassword;
        private BarButtonItem Accounts_STAnnexA;
        public ImageCollection imageCollection1;
        private BarSubItem barSubItem4;
        private BarButtonItem Accounts_ConsolidatedLedger_IV;
        private BarButtonItem Accounts_ConsolidatedLedger_III;
        private BarButtonItem Accounts_ConsolidatedLedger_II;
        private BarButtonItem Accounts_ConsolidatedLedger_I;
        public ImageCollection CauseImagesBlack;
        private BarButtonItem bbi_Tool_ClassicViewColors;
        private BarButtonItem Accounts_PurchasesYarn_Return;
        private BarButtonItem Accounts_PurchasesFabric_Return;
        private BarSubItem AccountsMenu_Purchases;
        private BarSubItem barSubItem8;
        private BarSubItem Menu_GreigeFabricContracts;
        private BarSubItem Menu_TowelContracts;
        private BarSubItem Menu_GreigeFabricSalesContracts;
        private BarSubItem Menu_TowelSalesContracts;
        private BarSubItem Menu_TowelPurchasesContracts;
        private BarButtonItem Contracts_Sales_Greige;
        private BarButtonItem Contracts_Sales_Overhead;
        private BarButtonItem Contracts_Sales_Conversion;
        private BarSubItem Menu_Summaries;
        private BarButtonItem Accounts_SalesSummary_Report;
        private BarSubItem rpi_ConstructionWise;
        private BarSubItem rpi_WeaverWise;
        private RibbonPageGroup ribbonPageGroup_ClassicalView;
        private RibbonPageGroup ribbonPageGroup_ClassicalViewMenu;
        public BarCheckItem ClassicalCheck_RPMView;
        public BarCheckItem ClassicalCheck_WarpView;
        public BarCheckItem ClassicalCheck_WeftView;
        public BarCheckItem ClassicalCheck_WarpKnottView;
        public BarCheckItem ClassicalCheck_WeftKnottView;
        public BarCheckItem ClassicalCheck_Efficiency;
        private BarSubItem barSubItem9;
        private BarButtonItem Accounts_FilteredAuditTrailReport;
        private BarButtonItem Accounts_SalesTaxRegister_FilterParty;
        private BarButtonItem Accounts_SalesTaxRegister_Article;
        private BarButtonItem Accounts_SalesRegister;
        private BarButtonItem ValidateMoreSecure;
        private BarButtonItem Accounts_STAnnexIDebitNote;
        private BarButtonItem Accounts_AnnexICreditNote;
        private BarButtonItem Debug_ConnectedCoorindators;
        private BarButtonItem Debug_LoomsWindow;
        private BarButtonItem Debug_WirelessDevices;
        private BarSubItem Accounts_SubMenu_PNL;
        private BarButtonItem Accounts_WeavingPNLAll;
        private BarButtonItem Accounts_PaymentAdvice;
        private BarButtonItem Planning_ProgramSheet;
        private BarSubItem rpi_WeeklyEfficiencyLoomWise;
        private BarSubItem rpi_MonthlyEfficiencyTabular;
        private BarSubItem rpi_DailyProductionLoss;
        private BarSubItem rpi_DailyEfficiencyWithProductionLoss;
        private BarButtonItem bbiALUGPU;
        private BarSubItem rpi_DailyEfficiencyQualityWise;
        private BarButtonItem bbi_Data_Article_FabricName;
        private BarSubItem rpi_CommingKnottings;
        private BarSubItem bbi_LoomFilter;
        private BarButtonItem bbiGotoFilter;
        private BarButtonItem ButtonFuction;
        private BarButtonItem Efficiency_ArticleEfficiencyReport;
        private BarButtonItem Efficiency_MonthlyProductionLoss;
        private BarButtonItem Efficiency_QualityWiseProduction;
     
        private BarButtonItem Efficiency_ShedLog;
       
    
        private BarButtonItem AccountsTrialBalancesSumBalances;
        private BarButtonItem AccountsTrialBalanceConsolidated;
        private BarSubItem AccountsMenuTrialBalance;
       
        private BarButtonItem Accounts_TrialBalanceEnding;
      
        private BarButtonItem Production_OutSideSizing;
        private RibbonPageGroup PageGroup_Store;
        private BarButtonItem Button_StoreAccounts;
        private BarButtonItem Button_PurchaseOrderStore;
        private BarButtonItem Button_StorePurchaseRegister;
        private BarButtonItem Button_StorePurchaseReturn;
        private BarButtonItem Button_StoreIssueNote;
        private BarSubItem SubMenu_Reports_Store;
        private BarSubItem SubMenuStore_Accounts;
        private BarButtonItem ReportButton_StoreAccounts;
        private BarSubItem rpi_DailyUnitsWeaverWise;
        private BarSubItem rpi_MonthlyUnitsWeaverWise;
        private BarSubItem rpi_MonthlyUnitsQualityWise;
        private BarButtonItem ButtonProductionSectionWarping;
        private RibbonPageGroup ContractsPageGroup;
        private BarButtonItem FabricContracts;
        private BarButtonItem Store_Opening;
        private BarSubItem Store_Opening_SubMenu;
        private BarButtonItem Store_OpeningEnteries_Report;
        private BarButtonItem Accounts_StoreCashPurchases;
        private BarButtonItem Accounts_CreditStorePurchases;
        private BarButtonItem Production_SizingSummaryReport;
        private BarButtonItem Store_ItemBinCard;
        private BarButtonItem Store_ReceiveNote;
        private BarButtonItem Store_ControlAccountsList;
        private BarSubItem rpi_LoomWise;
        private BarButtonItem Button_Towel_Opening;
        private RibbonPage ribbonPage_Tracking;
        private RibbonPageGroup ribbonPageGroup_TrackingVehiclesInfo;
        private BarButtonItem Button_ManageVehicles;
        private RibbonPageGroup ribbonPageGroup_EarthPlugin;
        private BarButtonItem barButtonItem_GoogleEarth;
        private BarSubItem barSubItem_PluginOptions;
        private BarCheckItem barCheckItem_Navigator;
        private BarCheckItem barCheckItem_Atmosphere;
        private BarCheckItem barCheckItem_OverView;
        private BarCheckItem barCheckItem_StatusBar;
        private BarCheckItem barCheckItem_Borders;
        private BarCheckItem barCheckItem_Terrain;
        private BarCheckItem barCheckItem_Roads;
        private BarCheckItem barCheckItem_Buildings;
        private BarSubItem barSubItem3;
        private BarStaticItem barStaticItem5;
        private BarLinkContainerItem barLinkContainerItem1;
        private BarButtonItem Tracking_VehicleMakes;
        private BarButtonItem Tracking_VehicleModels;
        private BarButtonItem Tracking_VehicleTypes;
        private BarSubItem AccountsMenuChartofAccounts;
        private BarButtonItem Accounts_PrintChartOfAccounts;
        
      
        private BarButtonItem Button_Planning_TowelArticles;
        private BarButtonItem Button_TowelArticles;
        private BarButtonItem Accounts_TrialBalanceEndingG;
        private BarButtonItem Accounts_TrialBalanceEndingN;
        private RibbonPageGroup StoreParametersPageGroup;
        private BarButtonItem Store_UnitsMeasurements;
        private BarButtonItem Store_Origins;
        private BarButtonItem bar_AutomaticUpdate;
        private RibbonPageGroup ribbonPageGroup_FinYears;
        private BarSubItem barSubItem_FinancialYears;
        private BarButtonItem barButtonItem_GreigeArticle;
        private BarSubItem barSubItemStoreStockReports;
        private BarButtonItem Store_ClosingStockReport;

        private BarButtonItem Accounts_ChartOfAccount_TabView;
        private BarButtonItem PO_Greige;
        public BarButtonItem bbiLogin;
        public BarButtonItem bbiExitMachineEyesERP;
        private BarSubItem MDC;
        private BarButtonItem MDC_CashPaymentVoucher;
        private BarButtonItem MDC_BankPaymentVoucher;
        private BarButtonItem MDC_CashReceiptVoucher;
        private BarButtonItem MDC_BankReceiptVoucher;
        private BarButtonItem MDC_JournalVoucher;
        private BarListItem barListItem1;
        private BarLinkContainerItem barLinkContainerItem2;
        private BarButtonItem SaveAsDefaultSkin;
        public DefaultLookAndFeel defaultLookAndFeel1;
        private BarSubItem AccountsMenuPurchases;
        private BarSubItem barSubItem14;
        private BarButtonItem barButtonItem2;
        private BarButtonItem Purchases_PurchaseLedger;
        private BarButtonItem Purchases_PurchasesSummary;
        private BarButtonItem Button_Towel_OpeningOutward;
        private RibbonPageGroup ribbonPageGroup_Towel;
        private BarSubItem barSubItem_Towel_OpeningMenu;
        private BarButtonItem barButtonItem_Towel_Inspection;
        private BarButtonItem barButtonItem_PackingList_Towel;
        private BarButtonItem barButtonItem_Opening_Inward_Towel;
        private BarButtonItem barButtonItem_Opening_OutWard_Towel;
        private BarSubItem barSubItem_Reports_Towel;
        private BarButtonItem barButtonItem_ArticleBinCard_Towel;
        private BarButtonItem barButtonItem_POBinCard_Towel;
        private BarButtonItem barButtonItem_DailyContractPosition_Towel;
        private BarButtonItem barButtonItem_StockReport_Towel;
        private BarButtonItem barButtonItem_YarnBalanceSummary_Towel;
        private RibbonPageGroup ribbonPageGroup_Greige;
        private BarButtonItem barButtonItem_Inspection_Greige;
        private BarButtonItem barButtonItem_TaketoGodown_Greige;
        private BarButtonItem barButtonItem_PackingList_Greige;
        private BarSubItem barSubItem_Opening_Greige_Menu;
        private BarButtonItem barButtonItem_Opening_Inward_Greige;
        private BarButtonItem barButtonItem_Opening_OutWard_Greige;
        private BarSubItem barSubItem_Reports_Greige_Menu;
        private BarButtonItem barButtonItem_JacquardArticles;
        private BarSubItem barSubItem_Issuancereports_Store;
        private BarButtonItem Store_MonthlyIssuance_Report;
        private BarButtonItem Store_MonthlyIssuanceGroupAccount_Report;
        private BarSubItem barSubItem_PurchasesReports_Store;
        private BarButtonItem barButtonItem_MonthlyPurchasesDetailedItem;
        private BarButtonItem Accounts_PurchasesOthers_Return;
        private BarButtonItem Accounts_SalesRegister_PartyFilter;
        private BarSubItem Store_ReturnBackReports_Menu;
        private BarButtonItem Store_Monthly_GetBacks;
        private BarButtonItem Inspection_OutsideWeaving;
        private BarButtonItem Greige_ArticleBinCard;
        private BarButtonItem Greige_CurrentContractsPosition;
        private BarButtonItem Greige_ContractAcitivtySheet_Report;
        private BarButtonItem Greige_FabricReturn;
        private BarButtonItem Greige_ReCheck;
        private BarButtonItem GPS_ClientsList;
        private BarButtonItem Monthly_Efficiency_SelectedLoom;
        private BarButtonItem Accounts_SalesRegister_Dated;
        private BarButtonItem Accounts_PurchaseRegister_DuringPeriod;
        private BarButtonItem Accounts_SalesRegister_Article;
        private BarSubItem rpi_BeamContraction;
        private BarButtonItem Efficiency_BeamContraction;
        private BarButtonItem Efficiency_QualityWiseBreakageReport;
        private BarButtonItem Efficiency_QualityWiseBreakagesGrouped;
        private BarSubItem YarnReports_Menu;
        private BarButtonItem YarnReports_POSummary;
        private BarButtonItem Yarn_ReturnToParty;
        private BarButtonItem YarnInward;
        private BarButtonItem YarnOutward;
        private BarButtonItem SizingWorkOrderButton;
        private BarSubItem DoublingMenu;
        private BarButtonItem IssuetoDoubling;
        private BarButtonItem ReceiveFromDoubling;
        private BarButtonItem DoublingWorkOrder;
        private BarButtonItem MovetoPO;
        private BarSubItem ReportsMenuContracts;
        private BarButtonItem GreigeContractsList;
        private BarButtonItem DenimArticlesAdd;
        private BarSubItem rpi_ShedEfficiencyLog;
        private BarSubItem rpi_ShedEfficiencyGraph;
        private BarButtonItem barButtonItemYarnColor;
        private BarSubItem barSubItem_Resize;
        private BarButtonItem bbi_SetLoomResizeControl;
        private BarButtonItem bbi_SaveLoomResizeControl;
        private RibbonPageGroup ribbonPageGroupFontSize;
        private BarEditItem FontSizeControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private BarButtonItem bbi_SaveLoomLayoutintoProfile;
        private BarButtonItem bbi_SMSDeviceAndServiceStatus;
        private BarButtonItem bbiYarnOpeningPlus;
        private BarButtonItem bbiYarnPartyStockReport;
        private BarButtonItem bbiTowelContractsList;
        private BarButtonItem bbiYarnPartyWiseStockSummary;
        private BarButtonItem bbiYarnIssueBetweenParties;
        private BarSubItem MenuYarnInwardOutward;
        private BarSubItem MenuYarnReceiveIssue;
        private BarButtonItem bbiYarnDepartmentStockSummary;
        private BarButtonItem bbiYarnGodownOrPartitionStockSummary;
        private BarButtonItem bbiYarnItemLedgerReport;
        private BarButtonItem Production_SizingMonthlyProduction;
        private BarButtonItem Production_SizingMonthlyProductionPartyWise;
        private BarButtonItem Production_SizingMonthlyProductionCountWise;
        private BarButtonItem WeaverGroupsManagement;
        private BarSubItem rpi_DailyEfficiencyWithDailyWage;
        private BarButtonItem StoreLocations;
        private BarButtonItem Store_MonthlyIssuance_Report_Asset;
        private BarButtonItem Store_MonthlyIssuance_Report_DevelopmentConstruction;
        private BarButtonItem DepartmentRequisitionSlip;
        private BarButtonItem barButtonItem1;
        private BarSubItem MergedShedLayoutSaveMenu;
        private BarButtonItem MergedShedLayoutSaveMenuButton;
        private BarButtonItem YarnDoublingWorkOrderLedger;
        private BarButtonItem DoublingAdjustmentNote;
        private BarButtonItem DoublingWorkOrdersSummary;
        private BarSubItem YarnDyingMenu;
        private BarButtonItem YarnDyingIssueNote;
        private BarButtonItem YarnDyingReceiveNote;
        private BarButtonItem YarnDyingWorkOrder;
        private BarButtonItem YarnDyingAdjustmentNote;
        private BarButtonItem YarnDyingWorkOrderLedger;
        private BarButtonItem YarnDyingWorkOrderSummary;
        private DataTables.DailyShift_SummaryTableAdapters.RP_DailyShiftSummaryTableAdapter rP_DailyShiftSummaryTableAdapter;
        private BarButtonItem RequestApproval;
        private BarButtonItem EmailSettings;
        private BarButtonItem SizingYarnLedger;
        private BarButtonItem MonthlyIssuanceOthers;
        private BarButtonItem MonthlyIssuanceAllAccounts;
        private BarSubItem Contracts_Sale;
        private BarSubItem Contracts_Sales_Fabric;
        private BarButtonItem Contracts_Sales_Fabric_Overhead;
        private BarButtonItem Contracts_Sales_Fabric_Conversion;
        private BarButtonItem Contracts_Sales_Fabric_Sale;
        private BarSubItem Contracts_Sales_Towel;
        private BarButtonItem Contracts_Sales_Towel_Overhead;
        private BarButtonItem Contracts_Sales_Towel_Conversion;
        private BarButtonItem Contracts_Sales_Towel_Sale;
        private BarButtonItem Store_RequisitionList;
        private BarSubItem rpi_MonthlyUnitsTabular;
        private BarButtonItem Store_MonthlyDepartmentIssuance;
        private BarSubItem rpi_MonthlyProductionEfficiency;
        private BarButtonItem barButtonItem_Category_Move;
        private BarButtonItem barButtonItem_SaveRunningPercentLocation;
        private BarButtonItem ButtonEfficiencyType;
        private BarSubItem rpi_DailySummary;
        private BarButtonItem barButton_NewCategory;
        private BarButtonItem barButtonItem_Category_AddLooms;
        private BarButtonItem barButtonItem_Category_RemoveLooms;
        private BarButtonItem barButtonItem_Category_SaveCategoryLayout;
        public BarSubItem barSubItem_Category;
        private BarSubItem rpi_TopWorseArticlesLooms;
        private BarButtonItem barButtonItem3;
        private BarButtonItem barButtonItem4;
        private BarSubItem barSubItem10;
        private BarButtonItem barButtonItem5;
        private BarButtonItem barButtonItem6;
        private BarButtonItem btnProduction_Inward;
        private BarButtonItem barButtonItem7;
        private BarButtonItem barButtonItem8;
        private BarButtonItem barButtonItem9;
      
        
  
    }
}
