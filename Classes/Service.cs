using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Timers;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using DevExpress.XtraEditors;
using System.Runtime.InteropServices;
namespace MachineEyes
{

    public static class SelectedDate
    {
        public static DateTime Date;
        public static DateTime upTo;
        public static bool isCanceled;
    }
    public class beam
    {
        public string BeamNumber;
        public BeamStatus Status;
    }
    public class selectedrow 
    {
        public string PrimeryID;
        public string PrimaryString;
        public DataRow SelectedDataRow;
        public ParameterStatus Status;
    }
    public class ProductionInwardList 
    {
        public string PONumber;
        public DataRow SelectedDataRow;
        public ParameterStatus Status;
    }
    public class SelectRowSaleContract
    {
        public string PONumber;
        //public string PONO;
        public string AccountName;
        public string ArticleName;
        public string SubDepartment;
        public string POQTYMtrs;
        public DataRow SelectedDataRow;
        public ParameterStatus Status;
    }
    public class SelectRowProductionInward
    {
        public string PONumber;
        public string AccountName;
        public string ArticleShortName;
        public DataRow SelectedDataRow;
        public ParameterStatus Status;
    }

    public class SelectRowProductionStatusReport
    {
        public string PONumber;
        public string AccountName;
        public string ArticleShortName;
        public DataRow SelectedDataRow;
        public ParameterStatus Status;
    }
    public class range
    {
        public int CC;
        public int index;
        public double Minimum;
        public double Maximum;
        public string FontColor;
        
    }
    public class weaver
    {
        public string WeaverID_A="";
        public string WeaverName_A="";
        public string WeaverID_B = "";
        public string WeaverName_B = "";
        public string WeaverID_C = "";
        public string WeaverName_C = "";

    }
    public class loomGroup
    {
        public int GroupNumber;
        public string GroupName;
        public weaver Weavers = new weaver();
        public double WarpKnottTime;
        public double WeftKnottTime;
        public double RPM;
        public double Efficiency;
        public double ProdEff = 0;
        public double TimeEff = 0;
        public double TimeProdEff = 0;
        public int x;
        public int y;
        public int[] LoomIndexes = new int[0];
    }
    public class set
    {
        public string SetNumber;
        public DateTime SizingDate;
        public int AvgWarpBreakagesPerHour_UptoDate;
        public int AvgWarpBreakagesPerHour_Current;
        public double Efficiency_UptoDate;
        public double Efficiency_Current;
    }
    public class technician
    {
        public string TechnicianID="";
        public string TechnicianName="";
        public double Eff = 0;
        public double RPM = 0;
        public int[] LoomIndexes = new int[0];
    }
    public class longStopped
    {
        
        public int[] Mechanical = new int[0];
        public int[] Electrical = new int[0];
        public int[] Knotting = new int[0];
        public int[] ArticleChange = new int[0];
        public int[] BeamShort = new int[0];
      
        public int[] PowerOff = new int[0];
        public int[] Others = new int[0];
    }
    public class shortStopped
    {
       
        public int[] Warp = new int[0];
        public int[] Weft = new int[0];
        public int[] Others = new int[0];
        
      
    }
    public class loomType
    {
        public string TypeName="";
        public string TypeID = "";
        public double Eff=0;
        public int RunningLooms = 0;
        public double ProdEff = 0;
        public double TimeEff = 0;
        public double TimeProdEff = 0;
        public double RPM=0;
        public double RunningEff = 0;
        public int[] LoomIndexes = new int[0];
    }
    public class loomSection
    {
        public string SectionID;
        public string SectionName;
        public int tempLooms = 0;
        public int tempRunningLooms = 0;
        public double tempEff = 0;
        public double tempRPM = 0;
        public double tempRunningEff = 0;
        public double tempProdEff = 0;
        public double tempTimeEff = 0;
        public double tempTimeProdEff = 0;
        public int RunningLooms_ForRunningPercent = 0;
        public double Eff = 0;
        public double ProdEff = 0;
        public double TimeEff = 0;
        public double TimeProdEff = 0;
        public double RPM = 0;
        public double RunningEff = 0;
        public int NumberofLooms;
    }
    public class currentShift
    {
        public DateTime ShiftStartDate;
        public string WShift;
        public DateTime ChangedAt;
        public DateTime LastChecked;
    }
    public class stoppedStats
    {
        public double Units;
        public double sWarpElapsed=0;
        public double sWeftElapsed=0;
        public double sOtherElapsed=0;
        public double lKnottingElapsed=0;
        public double lPowerOffElapsed = 0;
        public double lArticleElapsed=0;
        public double lMechanicalElapsed=0;
        public double lElectricalElapsed=0;
        public double lOtherElapsed=0;
        public double lLongStop_5 = 0;
        public double lLongStop_6 = 0;
        public double lLongStop_7 = 0;
        public double lLongStop_8 = 0;
        public double lLongStop_9 = 0;
        public double sWarpTotalBreakages;
        public double sWeftTotalBreakages;
        public double sOtherTotalBreakages;
        public double TotalDownTime=0;
    }
    public class article
    {
        public string ArticleNumber;
        public string ArticleName;
        public int PPI;
        public double ExpectedCrimp;
        public string WeightGrams;
        public double eff;
        public double rpm;
        public int[] LoomIndexes = new int[0];
    }
    public  class shedEff
    {
        public double Eff=0;
        public double RPM=0;
        public double RunningEff = 0;
        public double ProductionEff = 0;
        public double TimeEff = 0;
        public double TimeProdEff = 0;
        public int RunningLooms = 0;
        public int NoofLooms = 0;
    }
    public static class CurrentSelection
    {
        public static SimpleButton CurrentEfficiencyColor;
        public static Button CurrentClassicButton;
        public static string CurrentClassicColorMode;
        public static int ShedIndex;
        public static int LoomIndex;
        public static int CurrentGroupIndex;
        public static Control SelectedControl;
        public static DevExpress.XtraEditors.XtraForm SelectedView;
        public static SelectionMode CurrentSelectionMode;
        public static connectionMode ConnectionMode;
        public static UserControls.dxLoomCategory CategorySelected;
    }
    public enum serviceStatus : int { DISCONNECTED = 0, CONNECTED = 1, BROKEN = 2 }
    public enum progressStatus : int { IDLE = 0, INPROGRESS = 1,SYNCRONIZING=2, FAILED =3, SUCCEEDED = 4, INTERRUPTED = 5 }
    public enum serviceIcons : int { CONNECTEDIDLE=97,PING = 96, DATA_RECEIVED = 94, DISCONNECTED = 98, TRYING = 96,TRYINGSUCCEEDED=95 }
    public enum connectionMode : int { LAN = 1, WAN = 2 }
    public enum mode : int { Add = 1, Edit = 2, Delete = 3,ChangeState=4,ChangeImpact=5 }
    public   class UserInfo
    {

        public string UserID;
        public string Role;
        public string Password;
        public MachineService.sCodes SCodes = new MachineService.sCodes();
        
        public docState CanAdd_OpenDocument = docState.NotDefined;
        public docState CanEdit_OpenDocument = docState.NotDefined;
        public docState CanEdit_ClosedDocument = docState.NotDefined;
        public docState CanEdit_AuthorizedDocument = docState.NotDefined;
        public docState CanEdit_CancelledDocument = docState.NotDefined;
        public docState CanDel_OpenDocument = docState.NotDefined;
        public docState CanDel_ClosedDocument = docState.NotDefined;
        public docState CanDel_AuthorizedDocument = docState.NotDefined;
        public docState CanDel_CancelledDocument = docState.NotDefined;
        public docState CanChangeState_OpenDocument = docState.NotDefined;
        public docState CanChangeState_ClosedDocument = docState.NotDefined;
        public docState CanChangeState_AuthorizedDocument = docState.NotDefined;
        public docState CanChangeState_CancelledDocument = docState.NotDefined;

        public docState CanChangeimpact_OpenDocument = docState.NotDefined;
        public docState CanChangeimpact_ClosedDocument = docState.NotDefined;
        public docState CanChangeimpact_AuthorizedDocument = docState.NotDefined;
        public docState CanChangeimpact_CancelledDocument = docState.NotDefined;
        public bool CanDoMonitoring = false;
        public bool Authenticated = false;
        public string LastMessage;
        public int Status;
        public void LoadSystemRights()
        {
            try
            {
                string query = "SELECT     EmployeeID,  isERPUser, Password, Rights_G, Rights_N, Rights_B, CanAdd_OpenDoc, CanEdit_OpenDoc, CanEdit_CancelledDoc, CanEdit_ClosedDoc, CanEdit_AuthorizedDoc, " +
                    "CanDel_OpenDoc, CanDel_CancelledDoc, CanDel_ClosedDoc, CanDel_AuthorizedDoc, ChangeImpact_OpenDoc, ChangeImpact_CancelledDoc, " +
                          "ChangeImpact_ClosedDoc, ChangeImpact_AuthorizedDoc, ChangeState_OpenDoc, ChangeState_ClosedDoc, ChangeState_CancelledDoc, " +
                          "ChangeState_AuthorizedDoc,CanDo_Monitoring,DefaultSkinName FROM         PP_Employees where EmployeeID='" + this.UserID + "'";
                DataSet ds = WS.svc.Get_DataSet(query);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CanAdd_OpenDocument = ds.Tables[0].Rows[0]["CanAdd_OpenDoc"].ToString() == "1" ? docState.Open : docState.NotDefined;
                        CanEdit_OpenDocument = ds.Tables[0].Rows[0]["CanEdit_OpenDoc"].ToString() == "1" ? docState.Open : docState.NotDefined;
                        CanEdit_ClosedDocument = ds.Tables[0].Rows[0]["CanEdit_ClosedDoc"].ToString() == "1" ? docState.Closed : docState.NotDefined;
                        CanEdit_AuthorizedDocument = ds.Tables[0].Rows[0]["CanEdit_AuthorizedDoc"].ToString() == "1" ? docState.Authorized : docState.NotDefined;
                        CanEdit_CancelledDocument = ds.Tables[0].Rows[0]["CanEdit_CancelledDoc"].ToString() == "1" ? docState.Cancelled : docState.NotDefined;
                        CanDel_OpenDocument = ds.Tables[0].Rows[0]["CanDel_OpenDoc"].ToString() == "1" ? docState.Open : docState.NotDefined;
                        CanDel_ClosedDocument = ds.Tables[0].Rows[0]["CanDel_ClosedDoc"].ToString() == "1" ? docState.Closed : docState.NotDefined;
                        CanDel_AuthorizedDocument = ds.Tables[0].Rows[0]["CanDel_AuthorizedDoc"].ToString() == "1" ? docState.Authorized : docState.NotDefined;
                        CanDel_CancelledDocument = ds.Tables[0].Rows[0]["CanDel_CancelledDoc"].ToString() == "1" ? docState.Cancelled : docState.NotDefined;
                        CanChangeState_OpenDocument = ds.Tables[0].Rows[0]["ChangeState_OpenDoc"].ToString() == "1" ? docState.Open : docState.NotDefined;
                        CanChangeState_ClosedDocument = ds.Tables[0].Rows[0]["ChangeState_ClosedDoc"].ToString() == "1" ? docState.Closed : docState.NotDefined;
                        CanChangeState_AuthorizedDocument = ds.Tables[0].Rows[0]["ChangeState_AuthorizedDoc"].ToString() == "1" ? docState.Authorized : docState.NotDefined;
                        CanChangeState_CancelledDocument = ds.Tables[0].Rows[0]["ChangeState_CancelledDoc"].ToString() == "1" ? docState.Cancelled : docState.NotDefined;

                        CanChangeimpact_OpenDocument = ds.Tables[0].Rows[0]["ChangeImpact_OpenDoc"].ToString() == "1" ? docState.Open : docState.NotDefined;
                        CanChangeimpact_ClosedDocument = ds.Tables[0].Rows[0]["ChangeImpact_ClosedDoc"].ToString() == "1" ? docState.Closed : docState.NotDefined;
                        CanChangeimpact_AuthorizedDocument = ds.Tables[0].Rows[0]["ChangeImpact_AuthorizedDoc"].ToString() == "1" ? docState.Authorized : docState.NotDefined;
                        CanChangeimpact_CancelledDocument = ds.Tables[0].Rows[0]["ChangeImpact_CancelledDoc"].ToString() == "1" ? docState.Closed : docState.NotDefined;
                        CanDoMonitoring = ds.Tables[0].Rows[0]["CanDo_Monitoring"].ToString() == "1" ? true : false;
                        if (ds.Tables[0].Rows[0]["DefaultSkinname"].ToString() != "")
                        {
                            Program.MainWindow.defaultLookAndFeel1.LookAndFeel.SetSkinStyle(ds.Tables[0].Rows[0]["DefaultSkinname"].ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:LoadSystemRights", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool CheckDocumentValidation(mode Mode, docState State)
        {

                        if (Mode == mode.Add)
            {
                switch (State)
                {
                    case docState.Open:
                        if (CanDel_OpenDocument == docState.Open)
                            return true;
                        else return false;

               
                  
                }
                return false;
            }
            else if (Mode == mode.Edit)
            {
                switch (State)
                {
                    case docState.Open:
                        if (CanEdit_OpenDocument == docState.Open)
                            return true;
                        else return false;
                       
                    case docState.Closed:
                        if (CanEdit_ClosedDocument == docState.Closed)
                            return true;
                        else return false;
                        
                    case docState.Cancelled:
                        if (CanEdit_CancelledDocument == docState.Cancelled)
                            return true;
                        else return false;
                       
                    case docState.Authorized:
                        if (CanEdit_AuthorizedDocument == docState.Authorized)
                            return true;
                        else return false;
                       
                    case docState.NotDefined:
                        return false;
                       

                }
            }
            else if (Mode == mode.Delete)
            {
                switch (State)
                {
                    case docState.Open:
                        if (CanDel_OpenDocument == docState.Open)
                            return true;
                        else return false;

                    case docState.Closed:
                        if (CanDel_ClosedDocument == docState.Closed)
                            return true;
                        else return false;

                    case docState.Cancelled:
                        if (CanDel_CancelledDocument == docState.Cancelled)
                            return true;
                        else return false;

                    case docState.Authorized:
                        if (CanDel_AuthorizedDocument == docState.Authorized)
                            return true;
                        else return false;

                    case docState.NotDefined:
                        return true;


                }
            }
                        else if (Mode == mode.ChangeImpact)
                        {
                            switch (State)
                            {
                                case docState.Open:
                                    if (CanChangeimpact_OpenDocument == docState.Open)
                                        return true;
                                    else return false;

                                case docState.Closed:
                                    if (CanChangeimpact_ClosedDocument == docState.Closed)
                                        return true;
                                    else return false;

                                case docState.Cancelled:
                                    if (CanChangeimpact_CancelledDocument == docState.Cancelled)
                                        return true;
                                    else return false;

                                case docState.Authorized:
                                    if (CanChangeimpact_AuthorizedDocument == docState.Authorized)
                                        return true;
                                    else return false;

                                case docState.NotDefined:
                                    return false;


                            }
                        }
                        else if (Mode == mode.ChangeState)
                        {
                            switch (State)
                            {
                                case docState.Open://open document , unposted document
                                    if (CanChangeState_OpenDocument == docState.Open)
                                        return true;
                                    else return false;

                                case docState.Closed://closed document, posted document
                                    if (CanChangeState_ClosedDocument == docState.Closed)
                                        return true;
                                    else return false;

                                case docState.Cancelled://cancelled document
                                    if (CanChangeState_CancelledDocument == docState.Cancelled)
                                        return true;
                                    else return false;

                                case docState.Authorized://authorized document , audited document
                                    if (CanChangeState_AuthorizedDocument == docState.Authorized)
                                        return true;
                                    else return false;

                                case docState.NotDefined:
                                    return false;


                            }
                        }
            return false;
        }
       
    }  
    public class WS_Status
    {
        public DateTime LastSuccessfullPingTime;
        public string LastErrMsg;
        public serviceStatus Status = new serviceStatus();
    }
    public class meProgress
    {
        public static progressStatus Status;
        public static int Progress;
        public static string LastErrMsg;  
    }
    public class WS
    {
        public static MachineService.AuthSoapHd spAh = new MachineService.AuthSoapHd();
        public static MachineService.Service1 svc = new MachineEyes.MachineService.Service1();
        
        public static WS_Status svcStatus = new WS_Status();
        public static serviceIcons ServiceIcon = serviceIcons.DISCONNECTED;
        public static string ReturnMaxDocument(ref MachineService.Document Doc)
        {
            try
            {

                Doc.Y = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
                string r = svc.Get_MaxDoc(Doc);
                return r;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Retreiving Next Document Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        public static string ReturnMaxDocumentSingle(ref MachineService.Document Doc)
        {
            try
            {
               
                Doc.Y = MachineEyes.Classes.Accounting.RegAccounts.FinancialYear;
                string r = svc.Get_MaxDocSingle(Doc);
                return r;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Retreiving Next Document Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
    public class DisplayBoardDevice
    {
        public int DataNumber;
        public MachineService.devicepublicinfo PublicInfo = new MachineService.devicepublicinfo();
        public MachineService.DisplayBoardsClientListInfo[] ListInfo = new MachineService.DisplayBoardsClientListInfo[0];

    }
    public class csMachines
    {
        public MachineService.Loom[] Looms = new MachineEyes.MachineService.Loom[0];
       
        //public Dictionary<string, MachineService.loompersonalInfo> MACDictionary = new Dictionary<string, MachineService.loompersonalInfo>();
        public MachineService.sinkLoomInfo UnknownLoomMAC = new MachineService.sinkLoomInfo();
        public DisplayBoardDevice[] Devices = new DisplayBoardDevice[0];
        public MachineService.Vehicle[] Vehicles = new MachineService.Vehicle[0];
        
        public presentationData PresentationData = new presentationData();
      
        public System.Timers.Timer webServiceTimer = new System.Timers.Timer();
        public  System.Timers.Timer debugTimer = new System.Timers.Timer();
        System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        System.ComponentModel.BackgroundWorker debugger = new System.ComponentModel.BackgroundWorker();
        public csMachines()
        {

            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(DoSyncLooms);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted +=
                   new RunWorkerCompletedEventHandler(WorkerCompleted);
             webServiceTimer.Elapsed += new ElapsedEventHandler(RunWorker);
             webServiceTimer.Interval = (20000);
             
            GC.KeepAlive(webServiceTimer);

            debugger.DoWork += new System.ComponentModel.DoWorkEventHandler(DoSyncDebug);
            debugger.WorkerReportsProgress = false;
            debugger.WorkerSupportsCancellation = true;
            debugger.RunWorkerCompleted +=
                   new RunWorkerCompletedEventHandler(DebuggerWorkerCompleted);
            debugTimer.Elapsed += new ElapsedEventHandler(DebuggerRunWorker);
            debugTimer.Interval = (800);

            GC.KeepAlive(debugTimer);
           // thrLooms = new System.Threading.Thread(new System.Threading.ThreadStart(UpdateLooms));
           // thrLooms.IsBackground = true;
            
           // GC.KeepAlive(thrLooms);
           // thrLooms.Start();
        }
        private void RunWorker(object source, ElapsedEventArgs e)
        {

            if (worker.IsBusy == false)
            {
                try
                {
                    worker.RunWorkerAsync();

                }
                catch 
                {

                }
            }
        }
        private void DebuggerRunWorker(object source, ElapsedEventArgs e)
        {

            if (debugger.IsBusy == false)
            {
                try
                {
                    debugger.RunWorkerAsync();

                }
                catch
                {

                }
            }
        }
        public void StartSyncLooms()
        {
            webServiceTimer.Enabled = true;
            
        }
        private void DoSyncDebug(object sender, DoWorkEventArgs e)
        {
            if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == true) return;
            if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == false) return;
            MachineService.ClientListInfo[] TCPTempList = new MachineService.ClientListInfo[0];
            MachineService.ClientListInfo[] GPSTCPTempList = new MachineService.ClientListInfo[0];
            MachineService.sinkLoomInfo TempUnknownLoomMAC = new MachineService.sinkLoomInfo();

            try
            {
                if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
                {
                    TempUnknownLoomMAC = WS.svc.GetSinkLoomInfo_UnknownMAC(Program.ss.Machines.UnknownLoomMAC.DataNumber);
                    if (TempUnknownLoomMAC != null)
                        Program.ss.Machines.UnknownLoomMAC = TempUnknownLoomMAC;
                }
                
            }
            catch
            {
            }
            try
            {
                if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
                {
                    TCPTempList = WS.svc.Get_TCP_ClientsList(Program.ss.Machines.PresentationData.TCPClients_DataNumber);
                    Program.ss.Machines.PresentationData.TCPClients_DataNumber = WS.svc.Get_TCP_ClientsMainDataNumber();
                    if (TCPTempList != null)
                    {
                        Program.ss.Machines.PresentationData.TCPClients_LastCheck = DateTime.Now;
                        Program.ss.Machines.PresentationData.TCPClients = TCPTempList;
                    }
                    else
                    {
                        if (DateTime.Now.Subtract(Program.ss.Machines.PresentationData.TCPClients_LastCheck).TotalSeconds > 300)
                        {
                            TCPTempList = WS.svc.Get_TCP_ClientsList(-1);
                            Program.ss.Machines.PresentationData.TCPClients_LastCheck = DateTime.Now;
                            Program.ss.Machines.PresentationData.TCPClients = TCPTempList;
                        }
                    }
                    
                    for (int x = 0; x < Program.ss.Machines.PresentationData.TCPClients.Length; x++)
                    {
                        MachineService.ClientListInfo cli = WS.svc.Get_TCP_ClientInfo(Program.ss.Machines.PresentationData.TCPClients[x].Handle, Program.ss.Machines.PresentationData.TCPClients[x].DataNumber);
                        if (cli != null)
                            Program.ss.Machines.PresentationData.TCPClients[x] = cli;
                    }
                }
                MachineService.loomcurrentParams lcP = new MachineService.loomcurrentParams();
                for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
                {
                   
                    lcP = WS.svc.Get_LoomCurrentParam_OnDataNumberBasis(Looms[x].PersonalInfo.LoomID, Looms[x].CurrentParams.DataNumber);
                    if (lcP != null)
                        Looms[x].CurrentParams = lcP;
                }
            }
            catch
            {
            }
            MachineService.DisplayBoardsClientListInfo[] tempDeviceConnections = new  MachineService.DisplayBoardsClientListInfo[0];
            try
            {
                for(int x=0;x<Program.ss.Machines.Devices.Length;x++)
                {
                    //tempDeviceConnections = WS.svc.Get_Device_Connections(x, Program.ss.Machines.Devices[x].DataNumber);
                    tempDeviceConnections = WS.svc.Get_Device_Connections(x, -1);
                    //Program.ss.Machines.Devices[x].DataNumber = WS.svc.Get_DisplayBoardTCP_ClientsMainDataNumber(x);
                    if (tempDeviceConnections != null)
                        Program.ss.Machines.Devices[x].ListInfo = tempDeviceConnections;

                }

            }
            catch
            {
            }
            try
            {
             
                    GPSTCPTempList = WS.svc.Get_GPS_ClientsList(Program.ss.Machines.PresentationData.GPSTCPClients_DataNumber);
                    Program.ss.Machines.PresentationData.GPSTCPClients_DataNumber = WS.svc.Get_GPS_ClientsMainDataNumber();
                    if (GPSTCPTempList != null)
                    {
                        Program.ss.Machines.PresentationData.GPSTCPClients_LastCheck = DateTime.Now;
                        Program.ss.Machines.PresentationData.GPSTCPClients = GPSTCPTempList;
                    }
                    else
                    {
                        if (DateTime.Now.Subtract(Program.ss.Machines.PresentationData.GPSTCPClients_LastCheck).TotalSeconds > 300)
                        {
                            GPSTCPTempList = WS.svc.Get_GPS_ClientsList(-1);
                            Program.ss.Machines.PresentationData.GPSTCPClients_LastCheck = DateTime.Now;
                            Program.ss.Machines.PresentationData.GPSTCPClients = GPSTCPTempList;
                        }
                    }

                    for (int x = 0; x < Program.ss.Machines.PresentationData.GPSTCPClients.Length; x++)
                    {
                        MachineService.ClientListInfo cli = WS.svc.Get_GPS_ClientInfo(Program.ss.Machines.PresentationData.GPSTCPClients[x].Handle, Program.ss.Machines.PresentationData.GPSTCPClients[x].DataNumber);
                        if (cli != null)
                            Program.ss.Machines.PresentationData.GPSTCPClients[x] = cli;
                    }
                
               
            }
            catch
            {
            }
        }
        private void DoSyncLooms(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true) return;
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == true) return;

                meProgress.Status = progressStatus.SYNCRONIZING;
                WS.ServiceIcon = serviceIcons.PING;
                MachineService.loomcurrentParams lcP = new MachineEyes.MachineService.loomcurrentParams();
                MachineService.loomShiftParams shiftParams = new MachineService.loomShiftParams();
                double TotalLooms=Looms.Length;
                double TempEff=0;
                double TempProdEff = 0;
                double TempTimeEff = 0;
                double TempTimeProdEff = 0;
                int TempRunningLooms = 0;
               // int TempLooms=0;
                double TempRPM = 0;
                double TempWarpAvgKnotTime = 0;
                double TempWeftAvgKnotTime = 0;
                int TempWarpAvgKnotMachines = 0;
                int TempWeftAvgKnotMachines = 0;
                double LoomIndex = 0;
                double Result=0;
                int ShedIndex = 0;
                int LayoutIndex = -1;
                shortStopped[] shortCauses = new shortStopped[0];
                longStopped[] longCauses = new longStopped[0];
                shedEff[] TempShedsEfficiency = new shedEff[0];
                stoppedStats[] Stopped = new stoppedStats[0];

                shortStopped[] MergedshortCauses = new shortStopped[0];
                longStopped[] MergedlongCauses = new longStopped[0];
                shedEff[] MergedTempShedsEfficiency = new shedEff[0];
                stoppedStats[] MergedStopped = new stoppedStats[0];

                Array.Resize(ref MergedshortCauses, PresentationData.MergedSheds.Length);
                Array.Resize(ref MergedlongCauses, PresentationData.MergedSheds.Length);
                Array.Resize(ref MergedTempShedsEfficiency, PresentationData.MergedSheds.Length);
                Array.Resize(ref MergedStopped, PresentationData.MergedSheds.Length);

                Array.Resize(ref shortCauses, PresentationData.Sheds.Length);
                Array.Resize(ref longCauses, PresentationData.Sheds.Length);
                Array.Resize(ref TempShedsEfficiency, PresentationData.Sheds.Length);
                Array.Resize(ref Stopped, PresentationData.Sheds.Length);
                MachineService.alertinfo nAlert = new MachineService.alertinfo();
               
                try
                {
                    if(DateTime.Now.Subtract(PresentationData.DesktopAlertTimeLastChecked).TotalSeconds>30)
                    {
                    if (PresentationData.DesktopAlert != null)
                    {
                       nAlert= WS.svc.Get_DesktopAlert(PresentationData.DesktopAlert.AlertNumber);
                       if (nAlert.Caption != "" && nAlert.Caption!=null)
                           PresentationData.DesktopAlert = nAlert;
                    }
                        PresentationData.DesktopAlertTimeLastChecked=DateTime.Now;
                    }
                }
                catch
                {
                }
                for (int sx = 0; sx < PresentationData.Sheds.Length; sx++)
                {
                    TempShedsEfficiency[sx] = new shedEff();
                    TempShedsEfficiency[sx].RunningLooms = 0;
                    TempShedsEfficiency[sx].RunningEff = 0;
                    TempShedsEfficiency[sx].ProductionEff = 0;
                    TempShedsEfficiency[sx].TimeEff = 0;
                    TempShedsEfficiency[sx].TimeProdEff = 0;
                    TempShedsEfficiency[sx].Eff = 0;
                    TempShedsEfficiency[sx].RPM = 0;
                    TempShedsEfficiency[sx].NoofLooms = 0;
                    for (int si = 0; si < PresentationData.Sheds[sx].Sections.Length; si++)
                    {
                        PresentationData.Sheds[sx].Sections[si].tempEff = 0;
                        PresentationData.Sheds[sx].Sections[si].tempProdEff = 0;
                        PresentationData.Sheds[sx].Sections[si].tempTimeEff = 0;
                        PresentationData.Sheds[sx].Sections[si].tempTimeProdEff = 0;
                        PresentationData.Sheds[sx].Sections[si].tempRPM = 0;
                        PresentationData.Sheds[sx].Sections[si].tempRunningEff = 0;
                        PresentationData.Sheds[sx].Sections[si].tempLooms = 0;
                        PresentationData.Sheds[sx].Sections[si].tempRunningLooms = 0;
                        PresentationData.Sheds[sx].Sections[si].RunningLooms_ForRunningPercent = 0;
                    }
                   
                }

                for (int sx = 0; sx < PresentationData.MergedSheds.Length; sx++)
                {
                    MergedTempShedsEfficiency[sx] = new shedEff();
                    MergedTempShedsEfficiency[sx].RunningLooms = 0;
                    MergedTempShedsEfficiency[sx].RunningEff = 0;
                    MergedTempShedsEfficiency[sx].Eff = 0;
                    MergedTempShedsEfficiency[sx].RPM = 0;
                    MergedTempShedsEfficiency[sx].NoofLooms = 0;
                    MergedTempShedsEfficiency[sx].ProductionEff = 0;
                    MergedTempShedsEfficiency[sx].TimeEff = 0;
                    MergedTempShedsEfficiency[sx].TimeProdEff = 0;
                    for (int si = 0; si < PresentationData.MergedSheds[sx].Sections.Length; si++)
                    {
                        PresentationData.MergedSheds[sx].Sections[si].tempEff = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempProdEff = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempTimeEff = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempTimeProdEff = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempRPM = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempRunningEff = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempLooms = 0;
                        PresentationData.MergedSheds[sx].Sections[si].tempRunningLooms = 0;
                        PresentationData.MergedSheds[sx].Sections[si].RunningLooms_ForRunningPercent = 0;

                    }

                }
                for (int lcs = 0; lcs < PresentationData.MergedSheds.Length; lcs++)
                {
                    MergedshortCauses[lcs] = new shortStopped();
                    MergedlongCauses[lcs] = new longStopped();
                    MergedStopped[lcs] = new stoppedStats();
                }
                for (int lcs = 0; lcs < PresentationData.Sheds.Length; lcs++)
                {
                    shortCauses[lcs] = new shortStopped();
                    longCauses[lcs] = new longStopped();
                    Stopped[lcs] = new stoppedStats();
                }
                
                TimeSpan lCheck = DateTime.Now.Subtract(Program.ss.Machines.PresentationData.CurrentShift.LastChecked);
                if (lCheck.TotalMinutes >= 1)
                {
                    try
                    {
                        
                        Program.ss.Machines.PresentationData.Get_Currentshift();
                        for (int x = 0; x < Program.ss.Machines.Looms.Length; x++)
                        {
                            shiftParams = WS.svc.Get_LoomShiftParam(Looms[x].PersonalInfo.LoomID);
                            if (shiftParams != null)
                               Looms[x].ShiftParams = shiftParams;
                            ShedIndex = PresentationData.ReturnArrayIndex_Sheds(Looms[x].PersonalInfo.ShedID.ToString());
                            #region ShedCalcs
                            if (ShedIndex != -1)
                            {
                              
                                 TimeSpan ts = DateTime.Now.Subtract(Looms[x].SessionParams.Session_StartTime);
                                 ts = ts.Add(Settings.TimeZone_Add);
                                 ts = ts.Subtract(Settings.TimeZone_Subtract);



                                 Stopped[ShedIndex].sWarpElapsed += Looms[x].ShiftParams.Shift_WarpETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Warp)
                                    Stopped[ShedIndex].sWarpElapsed +=ts.TotalSeconds;
                                Stopped[ShedIndex].TotalDownTime += Looms[x].ShiftParams.Shift_DownTime;
                                
                                if(Looms[x].CurrentParams.Current_State != (int)State.Running)
                                 Stopped[ShedIndex].TotalDownTime+=ts.TotalSeconds;
                                
                                
                                Stopped[ShedIndex].sWeftElapsed += Looms[x].ShiftParams.Shift_WeftETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Weft)
                                 Stopped[ShedIndex].sWeftElapsed += ts.TotalSeconds;
                                Stopped[ShedIndex].sOtherElapsed += Looms[x].ShiftParams.Shift_OtherETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Other)
                                 Stopped[ShedIndex].sOtherElapsed +=ts.TotalSeconds;

                                if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Unknown && Looms[x].CurrentParams.Current_State != (int)State.Running)
                                    Stopped[ShedIndex].sOtherElapsed += ts.TotalSeconds;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Pile)
                                Stopped[ShedIndex].sOtherElapsed += ts.TotalSeconds;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Leno)
                                Stopped[ShedIndex].sOtherElapsed += ts.TotalSeconds;

                                Stopped[ShedIndex].lElectricalElapsed += Looms[x].ShiftParams.Shift_ElectricalETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Electrical)
                                Stopped[ShedIndex].lElectricalElapsed +=ts.TotalSeconds;

                                Stopped[ShedIndex].lPowerOffElapsed += Looms[x].ShiftParams.Shift_PowerOffETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.PowerOff)
                                Stopped[ShedIndex].lPowerOffElapsed +=ts.TotalSeconds;

                                Stopped[ShedIndex].lKnottingElapsed += Looms[x].ShiftParams.Shift_KnottingETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Knotting)
                                   Stopped[ShedIndex].lKnottingElapsed += ts.TotalSeconds;
                                
                                Stopped[ShedIndex].lMechanicalElapsed += Looms[x].ShiftParams.Shift_MechanicalETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.Mechanical)
                                Stopped[ShedIndex].lMechanicalElapsed +=ts.TotalSeconds;

                                Stopped[ShedIndex].lArticleElapsed += Looms[x].ShiftParams.Shift_ArticleETime;
                                if (Looms[x].CurrentParams.Current_Cause == (int)Cause.ArticleChange)
                                    Stopped[ShedIndex].lArticleElapsed += ts.TotalSeconds;


                                Stopped[ShedIndex].lOtherElapsed += Looms[x].ShiftParams.Shift_LongOtherETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.OtherLong)
                                Stopped[ShedIndex].lOtherElapsed += ts.TotalSeconds;

                                Stopped[ShedIndex].lLongStop_5 += Looms[x].ShiftParams.Shift_LongStop_5_ETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_5)
                                Stopped[ShedIndex].lLongStop_5 +=ts.TotalSeconds;
                                
                                Stopped[ShedIndex].lLongStop_6 += Looms[x].ShiftParams.Shift_LongStop_6_ETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_6)
                                Stopped[ShedIndex].lLongStop_6 +=ts.TotalSeconds;
                                
                                Stopped[ShedIndex].lLongStop_7 += Looms[x].ShiftParams.Shift_LongStop_7_ETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_7)
                                Stopped[ShedIndex].lLongStop_7 +=ts.TotalSeconds;
                                
                                Stopped[ShedIndex].lLongStop_8 += Looms[x].ShiftParams.Shift_LongStop_8_ETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_8)
                                Stopped[ShedIndex].lLongStop_8 +=ts.TotalSeconds;
                                
                                Stopped[ShedIndex].lLongStop_9 += Looms[x].ShiftParams.Shift_LongStop_9_ETime;
                                if(Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_9)
                                Stopped[ShedIndex].lLongStop_9 +=ts.TotalSeconds;
                                
                                
                                
                                Stopped[ShedIndex].sWarpTotalBreakages += Looms[x].ShiftParams.Shift_Warps;
                                Stopped[ShedIndex].sWeftTotalBreakages += Looms[x].ShiftParams.Shift_Wefts;
                                Stopped[ShedIndex].sOtherTotalBreakages += Looms[x].ShiftParams.Shift_Others;
                                Stopped[ShedIndex].Units += Looms[x].ShiftParams.Shift_Picks <= 0 ? 0 : Looms[x].ShiftParams.Shift_Picks/1000;
                               
                                if ((State)Looms[x].CurrentParams.Current_State != State.Running)
                                {
                                    
                                    switch ((Cause)Looms[x].CurrentParams.Current_Cause)
                                    {
                                        case Cause.Unknown:
                                            Stopped[ShedIndex].sOtherTotalBreakages++;
                                            break;
                                        case Cause.Warp:
                                           Stopped[ShedIndex].sWarpTotalBreakages++;
                                            break;
                                        case Cause.Weft:
                                           Stopped[ShedIndex].sWeftTotalBreakages++;
                                            break;
                                        case Cause.Leno:
                                            
                                            Stopped[ShedIndex].sOtherTotalBreakages++;
                                            break;
                                        case Cause.Other:
                                            
                                            Stopped[ShedIndex].sOtherTotalBreakages++;
                                            break;
                                        case Cause.Pile:
                                            
                                            Stopped[ShedIndex].sOtherTotalBreakages++;

                                            break;
                                        

                                        
                                    }
                                }
                            }
                            #endregion
                            #region MergedCalcs
                            for (int mIndex = 0; mIndex < PresentationData.MergedSheds.Length; mIndex++)
                            {
                                LayoutIndex = PresentationData.ReturnArrayIndex_MergedSheds(Looms[x].PersonalInfo.ShedID.ToString());

                                if (LayoutIndex != -1)
                                {

                                    TimeSpan ts = DateTime.Now.Subtract(Looms[x].SessionParams.Session_StartTime);
                                    ts = ts.Add(Settings.TimeZone_Add);
                                    ts = ts.Subtract(Settings.TimeZone_Subtract);




                                    MergedStopped[LayoutIndex].sWarpElapsed += Looms[x].ShiftParams.Shift_WarpETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Warp)
                                        MergedStopped[LayoutIndex].sWarpElapsed += ts.TotalSeconds;
                                    MergedStopped[LayoutIndex].TotalDownTime += Looms[x].ShiftParams.Shift_DownTime;

                                    if (Looms[x].CurrentParams.Current_State != (int)State.Running)
                                        MergedStopped[LayoutIndex].TotalDownTime += ts.TotalSeconds;


                                    MergedStopped[LayoutIndex].sWeftElapsed += Looms[x].ShiftParams.Shift_WeftETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Weft)
                                        MergedStopped[LayoutIndex].sWeftElapsed += ts.TotalSeconds;
                                    MergedStopped[LayoutIndex].sOtherElapsed += Looms[x].ShiftParams.Shift_OtherETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Other)
                                        MergedStopped[LayoutIndex].sOtherElapsed += ts.TotalSeconds;

                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Unknown && Looms[x].CurrentParams.Current_State != (int)State.Running)
                                        MergedStopped[LayoutIndex].sOtherElapsed += ts.TotalSeconds;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Pile)
                                        MergedStopped[LayoutIndex].sOtherElapsed += ts.TotalSeconds;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Leno)
                                        MergedStopped[LayoutIndex].sOtherElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lElectricalElapsed += Looms[x].ShiftParams.Shift_ElectricalETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Electrical)
                                        MergedStopped[LayoutIndex].lElectricalElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lPowerOffElapsed += Looms[x].ShiftParams.Shift_PowerOffETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.PowerOff)
                                        MergedStopped[LayoutIndex].lPowerOffElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lKnottingElapsed += Looms[x].ShiftParams.Shift_KnottingETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Knotting)
                                        MergedStopped[LayoutIndex].lKnottingElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lMechanicalElapsed += Looms[x].ShiftParams.Shift_MechanicalETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.Mechanical)
                                        MergedStopped[LayoutIndex].lMechanicalElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lArticleElapsed += Looms[x].ShiftParams.Shift_ArticleETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.ArticleChange)
                                        MergedStopped[LayoutIndex].lArticleElapsed += ts.TotalSeconds;


                                    MergedStopped[LayoutIndex].lOtherElapsed += Looms[x].ShiftParams.Shift_LongOtherETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.OtherLong)
                                        MergedStopped[LayoutIndex].lOtherElapsed += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lLongStop_5 += Looms[x].ShiftParams.Shift_LongStop_5_ETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_5)
                                        MergedStopped[LayoutIndex].lLongStop_5 += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lLongStop_6 += Looms[x].ShiftParams.Shift_LongStop_6_ETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_6)
                                        MergedStopped[LayoutIndex].lLongStop_6 += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lLongStop_7 += Looms[x].ShiftParams.Shift_LongStop_7_ETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_7)
                                        MergedStopped[LayoutIndex].lLongStop_7 += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lLongStop_8 += Looms[x].ShiftParams.Shift_LongStop_8_ETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_8)
                                        MergedStopped[LayoutIndex].lLongStop_8 += ts.TotalSeconds;

                                    MergedStopped[LayoutIndex].lLongStop_9 += Looms[x].ShiftParams.Shift_LongStop_9_ETime;
                                    if (Looms[x].CurrentParams.Current_Cause == (int)Cause.LongStop_9)
                                        MergedStopped[LayoutIndex].lLongStop_9 += ts.TotalSeconds;


                                    MergedStopped[LayoutIndex].sWarpTotalBreakages += Looms[x].ShiftParams.Shift_Warps;
                                    MergedStopped[LayoutIndex].sWeftTotalBreakages += Looms[x].ShiftParams.Shift_Wefts;
                                    MergedStopped[LayoutIndex].sOtherTotalBreakages += Looms[x].ShiftParams.Shift_Others;
                                    MergedStopped[LayoutIndex].Units += Looms[x].ShiftParams.Shift_Picks <= 0 ? 0 : Looms[x].ShiftParams.Shift_Picks / 1000;
                                    MergedStopped[LayoutIndex].sWarpTotalBreakages += Looms[x].ShiftParams.Shift_Warps;
                                    MergedStopped[LayoutIndex].sWeftTotalBreakages += Looms[x].ShiftParams.Shift_Wefts;
                                    MergedStopped[LayoutIndex].sOtherTotalBreakages += Looms[x].ShiftParams.Shift_Others;
                                    MergedStopped[LayoutIndex].Units += Looms[x].ShiftParams.Shift_Picks <= 0 ? 0 : Looms[x].ShiftParams.Shift_Picks / 1000;

                                    if ((State)Looms[x].CurrentParams.Current_State != State.Running)
                                    {
                                       
                                        switch ((Cause)Looms[x].CurrentParams.Current_Cause)
                                        {
                                            case Cause.Unknown:
                                              
                                                MergedStopped[LayoutIndex].sOtherTotalBreakages++;
                                                break;
                                            case Cause.Warp:
                                              
                                                MergedStopped[LayoutIndex].sWarpTotalBreakages++;
                                                break;
                                            case Cause.Weft:
                                             
                                                MergedStopped[LayoutIndex].sWeftTotalBreakages++;
                                                break;
                                            case Cause.Leno:
                                              
                                                MergedStopped[LayoutIndex].sOtherTotalBreakages++;
                                                break;
                                            case Cause.Other:
                                            
                                                MergedStopped[LayoutIndex].sOtherTotalBreakages++;
                                                break;
                                            case Cause.Pile:
                                             
                                                MergedStopped[LayoutIndex].sOtherTotalBreakages++;
                                                break;
                                            
                                        }
                                    }
                                }
                            }
                            #endregion
                            LoomIndex = (double)x;
                            Result = ((LoomIndex + 1) / TotalLooms) * 100;
                            meProgress.Progress = (int)Result;
                            WS.ServiceIcon = serviceIcons.TRYINGSUCCEEDED;
                        }
                        try
                        {
                            #region ShedCalcs
                            for (int sx = 0; sx < Program.ss.Machines.PresentationData.Sheds.Length; sx++)
                            {
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sWarpElapsed = Stopped[sx].sWarpElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sWeftElapsed = Stopped[sx].sWeftElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.TotalDownTime = Stopped[sx].TotalDownTime;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sOtherElapsed = Stopped[sx].sOtherElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lPowerOffElapsed = Stopped[sx].lPowerOffElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lElectricalElapsed = Stopped[sx].lElectricalElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lKnottingElapsed = Stopped[sx].lKnottingElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lMechanicalElapsed = Stopped[sx].lMechanicalElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lLongStop_5 = Stopped[sx].lLongStop_5;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lLongStop_6 = Stopped[sx].lLongStop_6;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lLongStop_7 = Stopped[sx].lLongStop_7;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lLongStop_8 = Stopped[sx].lLongStop_8;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lLongStop_9 = Stopped[sx].lLongStop_9;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lOtherElapsed = Stopped[sx].lOtherElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.lArticleElapsed = Stopped[sx].lArticleElapsed;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sWarpTotalBreakages = Stopped[sx].sWarpTotalBreakages;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sWeftTotalBreakages = Stopped[sx].sWeftTotalBreakages;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.sOtherTotalBreakages = Stopped[sx].sOtherTotalBreakages;
                                Program.ss.Machines.PresentationData.Sheds[sx].StoppedStats.Units = Stopped[sx].Units;
                            }
                            #endregion
                            #region MergedCalcs
                            for (int sx = 0; sx < Program.ss.Machines.PresentationData.MergedSheds.Length; sx++)
                            {
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sWarpElapsed = MergedStopped[sx].sWarpElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sWeftElapsed = MergedStopped[sx].sWeftElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.TotalDownTime = MergedStopped[sx].TotalDownTime;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sOtherElapsed = MergedStopped[sx].sOtherElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lPowerOffElapsed = MergedStopped[sx].lPowerOffElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lElectricalElapsed = MergedStopped[sx].lElectricalElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lKnottingElapsed = MergedStopped[sx].lKnottingElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lMechanicalElapsed = MergedStopped[sx].lMechanicalElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lLongStop_5 = MergedStopped[sx].lLongStop_5;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lLongStop_6 = MergedStopped[sx].lLongStop_6;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lLongStop_7 = MergedStopped[sx].lLongStop_7;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lLongStop_8 = MergedStopped[sx].lLongStop_8;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lLongStop_9 = MergedStopped[sx].lLongStop_9;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lOtherElapsed = MergedStopped[sx].lOtherElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.lArticleElapsed = MergedStopped[sx].lArticleElapsed;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sWarpTotalBreakages = MergedStopped[sx].sWarpTotalBreakages;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sWeftTotalBreakages = MergedStopped[sx].sWeftTotalBreakages;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.sOtherTotalBreakages = MergedStopped[sx].sOtherTotalBreakages;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].StoppedStats.Units = MergedStopped[sx].Units;
                            }
                            #endregion
                        }
                        catch
                        {
                        }
                    }
                    catch 
                    {
                    }
                }
               
               
                for (int  x = 0; x < Looms.Length; x++)
                {
                    
                   
                     lcP = WS.svc.Get_LoomCurrentParam_OnCounterBasis(Looms[x].PersonalInfo.LoomID, -2);
                     if (lcP != null)
                     {
                         ShedIndex = PresentationData.ReturnArrayIndex_Sheds(Looms[x].PersonalInfo.ShedID.ToString());
                         Looms[x].CurrentParams = lcP;
                         #region ShedCalcs
                         if (ShedIndex != -1)
                         {
                             if (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections.Length > 0)
                             {
                                 int SectionIndex = (Program.ss.Machines.PresentationData.Sheds[ShedIndex].Return_SectionIndex(Looms[x].PersonalInfo.SectionID.ToString()));
                                 if (SectionIndex != -1)
                                 {
                                    
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempLooms++;
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempEff += Looms[x].CurrentParams.Current_Eff;
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Prod_Eff;
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempTimeEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[x].CurrentParams.Current_Time_Eff;
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempTimeProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Time_Prod_Eff;
                                     Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempRPM += Looms[x].CurrentParams.Current_RPM;
                                     if(Looms[x].CurrentParams.Current_State==(int)State.Running)
                                         Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].RunningLooms_ForRunningPercent++;
                                     if (Looms[x].CurrentParams.FDNI == false && Looms[x].CurrentParams.DNI == false)
                                     {
                                         Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempRunningEff += Looms[x].CurrentParams.Current_Eff;
                                         Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempRunningLooms++;
                                     }
                                     else if (Looms[x].CurrentParams.FDNE == true && Looms[x].CurrentParams.DNI == true)
                                     {
                                         Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempRunningEff += Looms[x].CurrentParams.Current_Eff;
                                         Program.ss.Machines.PresentationData.Sheds[ShedIndex].Sections[SectionIndex].tempRunningLooms++;
                                     }
                                 }
                             }
                             if (Looms[x].CurrentParams.FDNI == false && Looms[x].CurrentParams.DNI==false)
                             {
                                 TempShedsEfficiency[ShedIndex].RunningEff += Looms[x].CurrentParams.Current_Eff;
                                 TempShedsEfficiency[ShedIndex].RunningLooms += 1;
                             }
                             else if (Looms[x].CurrentParams.FDNE == true && Looms[x].CurrentParams.DNI == true)
                             {
                                 TempShedsEfficiency[ShedIndex].RunningEff += Looms[x].CurrentParams.Current_Eff;
                                 TempShedsEfficiency[ShedIndex].RunningLooms += 1;
                             }
                            
                             TempShedsEfficiency[ShedIndex].Eff += Looms[x].CurrentParams.Current_Eff;

                             TempShedsEfficiency[ShedIndex].ProductionEff += double.IsNaN(Looms[x].CurrentParams.Current_Prod_Eff)==true?100:Looms[x].CurrentParams.Current_Prod_Eff;
                             TempShedsEfficiency[ShedIndex].TimeEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[x].CurrentParams.Current_Time_Eff;
                             TempShedsEfficiency[ShedIndex].TimeProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Time_Prod_Eff;

                             TempShedsEfficiency[ShedIndex].RPM += Looms[x].CurrentParams.Current_RPM;
                             TempShedsEfficiency[ShedIndex].NoofLooms += 1;
                         }
                       
                         //TempLooms++;
                         if ((State)Looms[x].CurrentParams.Current_State != State.Running)
                         {
                             switch ((Cause)Looms[x].CurrentParams.Current_Cause)
                             {
                                 case Cause.Unknown:
                                     Array.Resize(ref shortCauses[ShedIndex].Others, shortCauses[ShedIndex].Others.Length + 1);
                                     shortCauses[ShedIndex].Others[shortCauses[ShedIndex].Others.Length - 1] = x;
                                     break;
                                 case Cause.Warp:
                                     Array.Resize(ref shortCauses[ShedIndex].Warp, shortCauses[ShedIndex].Warp.Length + 1);
                                     shortCauses[ShedIndex].Warp[shortCauses[ShedIndex].Warp.Length - 1] = x;
                                     break;
                                 case Cause.Weft:
                                     Array.Resize(ref shortCauses[ShedIndex].Weft, shortCauses[ShedIndex].Weft.Length + 1);
                                     shortCauses[ShedIndex].Weft[shortCauses[ShedIndex].Weft.Length - 1] = x;
                                     break;
                                 case Cause.Leno:
                                     Array.Resize(ref shortCauses[ShedIndex].Others, shortCauses[ShedIndex].Others.Length + 1);
                                     shortCauses[ShedIndex].Others[shortCauses[ShedIndex].Others.Length - 1] = x;
                                     break;
                                 case Cause.Other:
                                     Array.Resize(ref shortCauses[ShedIndex].Others, shortCauses[ShedIndex].Others.Length + 1);
                                     shortCauses[ShedIndex].Others[shortCauses[ShedIndex].Others.Length - 1] = x;
                                     break;
                                 case Cause.Pile:
                                     Array.Resize(ref shortCauses[ShedIndex].Others, shortCauses[ShedIndex].Others.Length + 1);
                                     shortCauses[ShedIndex].Others[shortCauses[ShedIndex].Others.Length - 1] = x;
                                     break;
                                 case Cause.Mechanical:
                                     Array.Resize(ref longCauses[ShedIndex].Mechanical, longCauses[ShedIndex].Mechanical.Length + 1);
                                     longCauses[ShedIndex].Mechanical[longCauses[ShedIndex].Mechanical.Length - 1] = x;
                                     break;
                                 case Cause.PowerOff:
                                      Array.Resize(ref longCauses[ShedIndex].PowerOff, longCauses[ShedIndex].PowerOff.Length + 1);
                                     longCauses[ShedIndex].PowerOff[longCauses[ShedIndex].PowerOff.Length - 1] = x;
                                     break;
                                 case Cause.Electrical:
                                     Array.Resize(ref longCauses[ShedIndex].Electrical, longCauses[ShedIndex].Electrical.Length + 1);
                                     longCauses[ShedIndex].Electrical[longCauses[ShedIndex].Electrical.Length - 1] = x;
                                     break;
                                 case Cause.Knotting:
                                     Array.Resize(ref longCauses[ShedIndex].Knotting, longCauses[ShedIndex].Knotting.Length + 1);
                                     longCauses[ShedIndex].Knotting[longCauses[ShedIndex].Knotting.Length - 1] = x;
                                     break;
                                 case Cause.ArticleChange:
                                     Array.Resize(ref longCauses[ShedIndex].ArticleChange, longCauses[ShedIndex].ArticleChange.Length + 1);
                                     longCauses[ShedIndex].ArticleChange[longCauses[ShedIndex].ArticleChange.Length - 1] = x;
                                     break;
                                 case Cause.LongStop_5:
                                     Array.Resize(ref longCauses[ShedIndex].BeamShort, longCauses[ShedIndex].BeamShort.Length + 1);
                                     longCauses[ShedIndex].BeamShort[longCauses[ShedIndex].BeamShort.Length - 1] = x;
                                     break;
                               

                                
                             
                               
                                
                                
                                
                              
                                 case Cause.OtherLong:
                                     Array.Resize(ref longCauses[ShedIndex].Others, longCauses[ShedIndex].Others.Length + 1);
                                     longCauses[ShedIndex].Others[longCauses[ShedIndex].Others.Length - 1] = x;
                                     break;
                                 default:
                                     break;
                             }
                         }
#endregion
                         #region MergedCalcs
                         for (int mIndex = 0; mIndex < PresentationData.MergedSheds.Length; mIndex++)
                         {
                             LayoutIndex = PresentationData.ReturnArrayIndex_MergedSheds(Looms[x].PersonalInfo.ShedID.ToString());

                             if (LayoutIndex != -1)
                             {

                                 if (Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections.Length > 0)
                                     {
                                         int SectionIndex = (Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Return_SectionIndex(Looms[x].PersonalInfo.SectionID.ToString()));
                                         if (SectionIndex != -1)
                                         {

                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempLooms++;
                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempEff += Looms[x].CurrentParams.Current_Eff;
                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Prod_Eff;
                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempTimeEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[x].CurrentParams.Current_Time_Eff;
                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempTimeProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Time_Prod_Eff;
                                             Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempRPM += Looms[x].CurrentParams.Current_RPM;
                                             if (Looms[x].CurrentParams.FDNI == false && Looms[x].CurrentParams.DNI == false)
                                             {
                                                 Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempRunningEff += Looms[x].CurrentParams.Current_Eff;
                                                 Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempRunningLooms++;
                                             }
                                             else if (Looms[x].CurrentParams.FDNE == true && Looms[x].CurrentParams.DNI == true)
                                             {
                                                 Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempRunningEff += Looms[x].CurrentParams.Current_Eff;
                                                 Program.ss.Machines.PresentationData.MergedSheds[LayoutIndex].Sections[SectionIndex].tempRunningLooms++;
                                             }
                                         }
                                     }
                                     if (Looms[x].CurrentParams.FDNI == false && Looms[x].CurrentParams.DNI == false)
                                     {
                                         MergedTempShedsEfficiency[LayoutIndex].RunningEff += Looms[x].CurrentParams.Current_Eff;
                                         MergedTempShedsEfficiency[LayoutIndex].RunningLooms += 1;
                                     }
                                     else if (Looms[x].CurrentParams.FDNE == true && Looms[x].CurrentParams.DNI == true)
                                     {
                                         MergedTempShedsEfficiency[LayoutIndex].RunningEff += Looms[x].CurrentParams.Current_Eff;
                                         MergedTempShedsEfficiency[LayoutIndex].RunningLooms += 1;
                                     }

                                     MergedTempShedsEfficiency[LayoutIndex].Eff += Looms[x].CurrentParams.Current_Eff;
                                     MergedTempShedsEfficiency[LayoutIndex].ProductionEff += double.IsNaN(Looms[x].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Prod_Eff;
                                     MergedTempShedsEfficiency[LayoutIndex].TimeEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[x].CurrentParams.Current_Time_Eff;
                                     MergedTempShedsEfficiency[LayoutIndex].TimeProdEff += double.IsNaN(Looms[x].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[x].CurrentParams.Current_Time_Prod_Eff;
                                     MergedTempShedsEfficiency[LayoutIndex].RPM += Looms[x].CurrentParams.Current_RPM;
                                     MergedTempShedsEfficiency[LayoutIndex].NoofLooms += 1;
                                 

                                // TempLooms++;
                                 if ((State)Looms[x].CurrentParams.Current_State != State.Running)
                                 {
                                     switch ((Cause)Looms[x].CurrentParams.Current_Cause)
                                     {
                                         case Cause.Unknown:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Others, MergedshortCauses[LayoutIndex].Others.Length + 1);
                                             MergedshortCauses[LayoutIndex].Others[MergedshortCauses[LayoutIndex].Others.Length - 1] = x;
                                             break;
                                         case Cause.Warp:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Warp, MergedshortCauses[LayoutIndex].Warp.Length + 1);
                                             MergedshortCauses[LayoutIndex].Warp[MergedshortCauses[LayoutIndex].Warp.Length - 1] = x;
                                             break;
                                         case Cause.Weft:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Weft, MergedshortCauses[LayoutIndex].Weft.Length + 1);
                                             MergedshortCauses[LayoutIndex].Weft[MergedshortCauses[LayoutIndex].Weft.Length - 1] = x;
                                             break;
                                         case Cause.Leno:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Others, MergedshortCauses[LayoutIndex].Others.Length + 1);
                                             MergedshortCauses[LayoutIndex].Others[MergedshortCauses[LayoutIndex].Others.Length - 1] = x;
                                             break;
                                         case Cause.Other:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Others, MergedshortCauses[LayoutIndex].Others.Length + 1);
                                             MergedshortCauses[LayoutIndex].Others[MergedshortCauses[LayoutIndex].Others.Length - 1] = x;
                                             break;
                                         case Cause.Pile:
                                             Array.Resize(ref MergedshortCauses[LayoutIndex].Others, MergedshortCauses[LayoutIndex].Others.Length + 1);
                                             MergedshortCauses[LayoutIndex].Others[MergedshortCauses[LayoutIndex].Others.Length - 1] = x;
                                             break;
                                         case Cause.Mechanical:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].Mechanical, MergedlongCauses[LayoutIndex].Mechanical.Length + 1);
                                             longCauses[LayoutIndex].Mechanical[longCauses[LayoutIndex].Mechanical.Length - 1] = x;
                                             break;
                                         case Cause.PowerOff:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].PowerOff, MergedlongCauses[LayoutIndex].PowerOff.Length + 1);
                                             MergedlongCauses[LayoutIndex].PowerOff[MergedlongCauses[LayoutIndex].PowerOff.Length - 1] = x;
                                             break;
                                         case Cause.Electrical:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].Electrical, MergedlongCauses[LayoutIndex].Electrical.Length + 1);
                                             MergedlongCauses[LayoutIndex].Electrical[MergedlongCauses[LayoutIndex].Electrical.Length - 1] = x;
                                             break;
                                         case Cause.Knotting:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].Knotting, MergedlongCauses[LayoutIndex].Knotting.Length + 1);
                                             MergedlongCauses[LayoutIndex].Knotting[MergedlongCauses[LayoutIndex].Knotting.Length - 1] = x;
                                             break;
                                         case Cause.ArticleChange:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].ArticleChange, MergedlongCauses[LayoutIndex].ArticleChange.Length + 1);
                                             MergedlongCauses[LayoutIndex].ArticleChange[MergedlongCauses[LayoutIndex].ArticleChange.Length - 1] = x;
                                             break;
                                         case Cause.LongStop_5:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].BeamShort, MergedlongCauses[LayoutIndex].BeamShort.Length + 1);
                                             MergedlongCauses[LayoutIndex].BeamShort[MergedlongCauses[LayoutIndex].BeamShort.Length - 1] = x;
                                             break;


                                      

                                      

                                         case Cause.OtherLong:
                                             Array.Resize(ref MergedlongCauses[LayoutIndex].Others, MergedlongCauses[LayoutIndex].Others.Length + 1);
                                             MergedlongCauses[LayoutIndex].Others[MergedlongCauses[LayoutIndex].Others.Length - 1] = x;
                                             break;
                                         default:
                                             break;
                                     }
                                 }
                             }
                         }

                         #endregion
                     }
                    LoomIndex = (double)x;
                    Result = ((LoomIndex + 1) / TotalLooms) * 100;
                    meProgress.Progress = (int)Result;
                    WS.ServiceIcon = serviceIcons.TRYINGSUCCEEDED;
                }
                #region ShedsCalcs
                try
                {
                    for (int shedsX = 0; shedsX < Program.ss.Machines.PresentationData.Sheds.Length; shedsX++)
                    {
                        for (int sectionX = 0; sectionX < Program.ss.Machines.PresentationData.Sheds[shedsX].Sections.Length; sectionX++)
                        {
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].NumberofLooms = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].Eff = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempEff / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].ProdEff = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempProdEff / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].TimeEff = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempTimeEff / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].TimeProdEff = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempTimeProdEff / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].RPM = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempRPM / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].RunningEff = Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempRunningEff / Program.ss.Machines.PresentationData.Sheds[shedsX].Sections[sectionX].tempRunningLooms;
                        }
                    }
                }
                catch
                {
                }
                #endregion
                #region MergedCalcs
                try
                {
                    for (int shedsX = 0; shedsX < Program.ss.Machines.PresentationData.MergedSheds.Length; shedsX++)
                    {
                        for (int sectionX = 0; sectionX < Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections.Length; sectionX++)
                        {
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].Eff = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempEff / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].ProdEff = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempProdEff / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].TimeEff = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempTimeEff / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].TimeProdEff = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempTimeProdEff / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].RPM = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempRPM / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].RunningEff = Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempRunningEff / Program.ss.Machines.PresentationData.MergedSheds[shedsX].Sections[sectionX].tempRunningLooms;
                        }
                    }
                }
                catch
                {
                }
                #endregion
                #region ArticleEff
                try
                {
                    double articleeff = 0, articlerpm = 0;
                    foreach (article item in Program.ss.Machines.PresentationData.Articles.Values)
                    {

                        for (int x = 0; x < item.LoomIndexes.Length; x++)
                        {
                            articleeff += Program.ss.Machines.Looms[item.LoomIndexes[x]].CurrentParams.Current_Eff;
                            articlerpm += Program.ss.Machines.Looms[item.LoomIndexes[x]].CurrentParams.Current_RPM;
                        }
                        try
                        {
                            if (item.LoomIndexes.Length > 0)
                            {
                                item.eff = articleeff / item.LoomIndexes.Length;
                                item.rpm = articlerpm / item.LoomIndexes.Length;
                            }
                        }
                        catch
                        {
                        }
                        articleeff = 0; articlerpm = 0;
                    }
                }
                catch 
                {
                }
                #endregion
                meProgress.Status = progressStatus.SUCCEEDED;
                WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;

                #region ShedCalc
                for (int sx = 0; sx < PresentationData.Sheds.Length; sx++)
                {
                    try
                    {
                        #region Causes
                        Program.ss.Machines.PresentationData.Sheds[sx].LongStops = longCauses[sx];
                        Program.ss.Machines.PresentationData.Sheds[sx].ShortStops = shortCauses[sx];
                        #endregion
                    }
                    catch 
                    {
                    }
                    try
                    {
                        int TypeRunningLooms = 0;
                        double TypeRunningEff = 0;
                        #region TypeEff
                        for (int TypeX = 0; TypeX < Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms.Length; TypeX++)
                        {
                            TempEff = 0; TempRPM = 0; TypeRunningEff = 0; TypeRunningLooms = 0; TempProdEff = 0; TempTimeEff = 0; TempTimeProdEff = 0; TempRunningLooms = 0;
                            for (int LoomX = 0; LoomX < Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length; LoomX++)
                            {
                                if (Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_State == (int)State.Running)
                                    TempRunningLooms++;
                                if (Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.FDNI == false && Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.DNI == false)
                                {
                                    TypeRunningLooms++;
                                    TypeRunningEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                }
                                else if (Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.FDNE == true && Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.DNI == true)
                                {
                                    TypeRunningLooms++;
                                    TypeRunningEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                }
                                TempEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                TempProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff;
                                TempTimeEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff;
                                TempTimeProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff;
                                TempRPM += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_RPM) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_RPM;
                            }
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].RunningLooms = TempRunningLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].Eff = TempEff / Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].ProdEff = TempProdEff / Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].TimeEff = TempTimeEff / Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].TimeProdEff = TempTimeProdEff / Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].RPM = TempRPM / Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.Sheds[sx].TypesOfLooms[TypeX].RunningEff = TypeRunningEff /TypeRunningLooms;
                            
                        }
                        #endregion
                    }
                    catch 
                    {
                    }
                    try
                    {
                        #region LoomGroup
                        for (int Groupindex = 0; Groupindex < Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups.Length; Groupindex++)
                        {
                            TempEff = 0; TempRPM = 0; TempProdEff = 0; TempTimeEff = 0; TempTimeProdEff = 0;
                            for (int LoomX = 0; LoomX < Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length; LoomX++)
                            {

                                TempEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                TempProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff;
                                TempTimeEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff;
                                TempTimeProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff;
                                TempRPM += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_RPM) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_RPM;
                                TempWarpAvgKnotTime += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime;
                                TempWeftAvgKnotTime += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime) == true ? 0 : Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime;
                                TempWarpAvgKnotMachines += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime) == true ? 0 : 1;
                                TempWeftAvgKnotMachines += double.IsNaN(Looms[Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime) == true ? 0 : 1;


                            }
                            try
                            {
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].Efficiency = TempEff / Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].ProdEff = TempProdEff / Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].TimeEff = TempTimeEff / Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].TimeProdEff = TempTimeProdEff / Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].RPM = TempRPM / Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].WarpKnottTime = TempWarpAvgKnotTime / TempWarpAvgKnotMachines;
                                Program.ss.Machines.PresentationData.Sheds[sx].LoomGroups[Groupindex].WeftKnottTime = TempWeftAvgKnotTime / TempWeftAvgKnotMachines;
                                TempWarpAvgKnotMachines = 0;
                                TempWarpAvgKnotTime = 0;
                                TempWeftAvgKnotMachines = 0;
                                TempWeftAvgKnotTime = 0;
                            }
                            catch
                            {
                                TempWarpAvgKnotMachines = 0;
                                TempWarpAvgKnotTime = 0;
                                TempWeftAvgKnotMachines = 0;
                                TempWeftAvgKnotTime = 0;


                            }
                        }
                        #endregion
                    }
                    catch
                    {
                    }
                    try
                    {
                        #region ShedEff

                        try
                        {
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.Eff = TempShedsEfficiency[sx].Eff / TempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.ProductionEff = TempShedsEfficiency[sx].ProductionEff / TempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.TimeEff = TempShedsEfficiency[sx].TimeEff / TempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.TimeProdEff = TempShedsEfficiency[sx].TimeProdEff / TempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.RunningLooms = TempShedsEfficiency[sx].RunningLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.RunningEff = TempShedsEfficiency[sx].RunningEff / TempShedsEfficiency[sx].RunningLooms;
                            Program.ss.Machines.PresentationData.Sheds[sx].ShedEfficiency.RPM = TempShedsEfficiency[sx].RPM / TempShedsEfficiency[sx].NoofLooms;
                        }
                        catch 
                        {
                        }

                        #endregion
                    }
                    catch 
                    {
                    }
                }
                #endregion

                #region MergedCalc
                for (int sx = 0; sx < PresentationData.MergedSheds.Length; sx++)
                {
                    try
                    {
                        #region Causes
                        Program.ss.Machines.PresentationData.MergedSheds[sx].LongStops = MergedlongCauses[sx];
                        Program.ss.Machines.PresentationData.MergedSheds[sx].ShortStops = MergedshortCauses[sx];
                        #endregion
                    }
                    catch
                    {
                    }
                    try
                    {
                        int TypeRunningLooms = 0;
                        double TypeRunningEff = 0;
                        #region TypeEff
                        for (int TypeX = 0; TypeX < Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms.Length; TypeX++)
                        {
                            TempEff = 0; TempRPM = 0; TypeRunningEff = 0; TypeRunningLooms = 0; TempProdEff = 0; TempTimeEff = 0; TempTimeProdEff = 0; TempRunningLooms = 0;
                            for (int LoomX = 0; LoomX < Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length; LoomX++)
                            {
                                if (Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_State == (int)State.Running)
                                    TempRunningLooms++;
                                if (Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.FDNI == false && Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.DNI == false)
                                {
                                    TypeRunningLooms++;
                                    TypeRunningEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                }
                                else if (Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.FDNE == true && Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.DNI == true)
                                {
                                    TypeRunningLooms++;
                                    TypeRunningEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                }
                                TempEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                TempProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff;
                                TempTimeEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff;
                                TempTimeProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff;




                                TempRPM += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_RPM) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes[LoomX]].CurrentParams.Current_RPM;
                            }
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].RunningLooms = TempRunningLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].Eff = TempEff / Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].ProdEff = TempProdEff / Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].TimeEff = TempTimeEff / Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].TimeProdEff = TempTimeProdEff / Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].RPM = TempRPM / Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].LoomIndexes.Length;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].TypesOfLooms[TypeX].RunningEff = TypeRunningEff / TypeRunningLooms;

                        }
                        #endregion
                    }
                    catch
                    {
                    }
                    try
                    {
                        #region LoomGroup
                        for (int Groupindex = 0; Groupindex < Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups.Length; Groupindex++)
                        {
                            TempEff = 0; TempRPM = 0; TempProdEff = 0; TempTimeEff = 0; TempTimeProdEff = 0;
                            for (int LoomX = 0; LoomX < Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length; LoomX++)
                            {

                                TempEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Eff;
                                TempProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Prod_Eff;
                                TempTimeEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Eff;
                                TempTimeProdEff += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff) == true ? 100 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_Time_Prod_Eff;
                                TempRPM += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_RPM) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.Current_RPM;
                                TempWarpAvgKnotTime += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime;
                                TempWeftAvgKnotTime += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime) == true ? 0 : Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime;
                                TempWarpAvgKnotMachines += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WarpAvgKnotTime) == true ? 0 : 1;
                                TempWeftAvgKnotMachines += double.IsNaN(Looms[Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes[LoomX]].CurrentParams.WeftAvgKnotTime) == true ? 0 : 1;


                            }
                            try
                            {
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].Efficiency = TempEff / Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].ProdEff = TempProdEff / Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].TimeEff = TempTimeEff / Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].TimeProdEff = TempTimeProdEff / Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].RPM = TempRPM / Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].LoomIndexes.Length;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].WarpKnottTime = TempWarpAvgKnotTime / TempWarpAvgKnotMachines;
                                Program.ss.Machines.PresentationData.MergedSheds[sx].LoomGroups[Groupindex].WeftKnottTime = TempWeftAvgKnotTime / TempWeftAvgKnotMachines;
                                TempWarpAvgKnotMachines = 0;
                                TempWarpAvgKnotTime = 0;
                                TempWeftAvgKnotMachines = 0;
                                TempWeftAvgKnotTime = 0;
                            }
                            catch
                            {
                                TempWarpAvgKnotMachines = 0;
                                TempWarpAvgKnotTime = 0;
                                TempWeftAvgKnotMachines = 0;
                                TempWeftAvgKnotTime = 0;


                            }
                        }
                        #endregion
                    }
                    catch
                    {
                    }
                    try
                    {
                        #region ShedEff

                        try
                        {
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.Eff = MergedTempShedsEfficiency[sx].Eff / MergedTempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.ProductionEff = MergedTempShedsEfficiency[sx].ProductionEff / MergedTempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.TimeEff = MergedTempShedsEfficiency[sx].TimeEff / MergedTempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.TimeProdEff = MergedTempShedsEfficiency[sx].TimeProdEff / MergedTempShedsEfficiency[sx].NoofLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.RunningLooms = MergedTempShedsEfficiency[sx].RunningLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.RunningEff = MergedTempShedsEfficiency[sx].RunningEff / MergedTempShedsEfficiency[sx].RunningLooms;
                            Program.ss.Machines.PresentationData.MergedSheds[sx].ShedEfficiency.RPM = MergedTempShedsEfficiency[sx].RPM / MergedTempShedsEfficiency[sx].NoofLooms;
                        }
                        catch
                        {
                        }

                        #endregion
                    }
                    catch
                    {
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                meProgress.Status = progressStatus.FAILED;
                meProgress.LastErrMsg = ex.Message;
            }

        }
        private void DebuggerWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (WS.svcStatus.Status == serviceStatus.CONNECTED)
                WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;
        }
        public int ReturnArrayIndex_Loom(string LoomName,string ShedID)
        {
           
            for (int x = 0; x < Looms.Length; x++)
            {
                if (Looms[x].PersonalInfo.LoomName == LoomName && Looms[x].PersonalInfo.ShedID.ToString()==ShedID)
                    return x;
            }
            return -1;
        }
      
       /*
        private void UpdateLooms()
        {
            MachineService.loomcurrentParams lcP = new MachineEyes.MachineService.loomcurrentParams();
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                Application.DoEvents();
                while (WS.svcStatus.Status == serviceStatus.CONNECTED)
                {
                    
                    try
                    {

                        for (int x = 0; x < Looms.Length; x++)
                        {
                           // lcP = WS.svc.Get_LoomCurrentParam(Looms[x].PersonalInfo.LoomID, Looms[x].CurrentParams.Counter);
                            if (lcP != null)
                                Looms[x].CurrentParams = lcP;

                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        */
    }
    class Service
    {
       
        
        public csMachines Machines = new csMachines();
        private System.Timers.Timer webServiceTimer = new System.Timers.Timer();
        System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
        public bool ConfigurationLoaded = false;
        public void SetMachineDisplay(ref MachineService.Loom ArrLoom, ref dxLoom ctrLoom)
        {

            //ctrLoom.ElapsedTime.BackColor = Settings.Get_StopCauseColor_backColor((Cause)ArrLoom.CurrentParams.Current_Cause);
            //ctrLoom.ElapsedTime.Appearance.BorderColor = Settings.Get_StopCauseColor_backColor((Cause)ArrLoom.CurrentParams.Current_Cause);
            //ctrLoom.ElapsedTime.Appearance.ForeColor = Settings.Get_StopCauseColor_foreColor((Cause)ArrLoom.CurrentParams.Current_Cause);
            if (ArrLoom.CurrentParams.DNI == true && ArrLoom.CurrentParams.FDNE == false)
                ctrLoom.Efficiency.ImageIndex = (int)Cause.DNI;
            else if (ArrLoom.CurrentParams.FDNI == true)
                ctrLoom.Efficiency.ImageIndex = (int)Cause.FDNI;
            else
                ctrLoom.Efficiency.ImageIndex = -1;
            if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
            {
                ctrLoom.Efficiency.Text = "";
            }
            else
            {

                if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
                {
                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Eff, 1).ToString();
                    if (Convert.ToDouble(eff) >= 100)
                    {

                        ctrLoom.Efficiency.Tag = eff;
                        ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : 99.9);


                    }
                    else
                    {


                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff);

                    }
                }
                else if (Settings.efficiencyType == EfficiencyType.ProductionEfficiency)
                {
                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Prod_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Prod_Eff, 1).ToString();
                    if (Convert.ToDouble(eff) >= 100)
                    {

                        ctrLoom.Efficiency.Tag = eff;
                        ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Prod_Eff) == true ? 0.00 : 99.9);


                    }
                    else
                    {


                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Prod_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Prod_Eff);

                    }
                }
                else if (Settings.efficiencyType == EfficiencyType.TimeEfficiency)
                {
                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Time_Eff, 1).ToString();
                    if (Convert.ToDouble(eff) >= 100)
                    {

                        ctrLoom.Efficiency.Tag = eff;
                        ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Eff) == true ? 0.00 : 99.9);


                    }
                    else
                    {


                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Time_Eff);

                    }
                }
                else if (Settings.efficiencyType == EfficiencyType.TimeProductionEfficiency)
                {
                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Prod_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Time_Prod_Eff, 1).ToString();
                    if (Convert.ToDouble(eff) >= 100)
                    {

                        ctrLoom.Efficiency.Tag = eff;
                        ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Prod_Eff) == true ? 0.00 : 99.9);


                    }
                    else
                    {


                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Time_Prod_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Time_Prod_Eff);

                    }
                }

            }


            if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
            {
                TimeSpan ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Current_SinkTime);
               ts= ts.Add(Settings.TimeZone_Add);
                ts=ts.Subtract(Settings.TimeZone_Subtract);
                if (ts.TotalSeconds >= Settings.DataWaitingSeconds)
                {
                    if (ts.TotalMinutes >= 10)
                        ctrLoom.LoomNumber.ForeColor = Color.DarkRed;
                    else if (ts.TotalMinutes < 10 && ts.TotalMinutes >= 5)
                        if (ctrLoom.LoomNumber.ForeColor != Color.DarkRed)
                            ctrLoom.LoomNumber.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes < 5)
                            if (ctrLoom.LoomNumber.ForeColor != Color.DarkRed && ctrLoom.LoomNumber.ForeColor != Color.Blue)
                                ctrLoom.LoomNumber.ForeColor = Color.Green;

                    // Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)].CurrentParams.Cause_Current = (int)Cause.WaitingWireless;
                    ctrLoom.RPM.ImageIndex = (int)Cause.PowerOff;
                    ctrLoom.RPM.Text = "";
                    ctrLoom.ElapsedTime.Text = Get_FormattedTime(ts,0);

                }
                else
                {
                    ctrLoom.RPM.ImageIndex = -1;
                    ctrLoom.ElapsedTime.Text = "";
                }
            }
            else
            {

                
            


               
               
                    if ((State)ArrLoom.CurrentParams.Current_State != State.Running)
                    {
                       
                        ctrLoom.RPM.Text = "";
                        ctrLoom.RPM.ImageIndex = ArrLoom.CurrentParams.Current_Cause;
                        ctrLoom.RPM.Text = "";
                    if (CurrentSelection.ConnectionMode != connectionMode.WAN)
                        {

                            TimeSpan ts= DateTime.Now.Subtract(ArrLoom.CurrentParams.Session_ActualStartTime);
                                 ts = ts.Add(Settings.TimeZone_Add);
                            ts = ts.Subtract(Settings.TimeZone_Subtract);
                            ctrLoom.ElapsedTime.Text = Get_FormattedTime(ts,0);
                        }

                    }
                    else
                    {
                        ctrLoom.RPM.Text = Double.IsNaN(ArrLoom.CurrentParams.Current_RPM) == true ? "" : ArrLoom.CurrentParams.Current_RPM.ToString("#,##");
                        if (ctrLoom.RPM.Text != "")
                            ctrLoom.RPM.ImageIndex = -1;
                        else
                            ctrLoom.RPM.ImageIndex = (int)Cause.RunningbutNoRPM;
                        ctrLoom.ElapsedTime.Text = "";

                    }
                
            }
        }
        public void SetLongStoppedMachineDisplay(ref MachineService.Loom ArrLoom,ref  UserControls.dxLongStoppedLoom ctrLoom)
        {

           
           
                if (Settings.efficiencyType == EfficiencyType.ShedEfficiency)
                {
                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Eff, 1).ToString();
                    ctrLoom.Efficiency.Tag = eff;
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff);

                    
                }

                        TimeSpan ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Session_ActualStartTime);
                        ts = ts.Add(Settings.TimeZone_Add);
                        ts = ts.Subtract(Settings.TimeZone_Subtract);
                        ctrLoom.ElapsedTime.Text = Get_FormattedTime(ts, 0);


                        double s;
                        double Defficiency = 100 - ArrLoom.CurrentParams.Current_Eff;

                        if (Defficiency < 0) Defficiency = 0;

                        if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.Mechanical)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_MechanicalETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.Electrical)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_ElectricalETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.Knotting)
                        {
                            double ktime = ArrLoom.ShiftParams.Shift_KnottingETime;
                           
                            s = (((ArrLoom.ShiftParams.Shift_KnottingETime+ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime+ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.ArticleChange)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_ArticleETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.OtherLong)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongOtherETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.PowerOff)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_PowerOffETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.LongStop_5)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongStop_5_ETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.LongStop_6)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongStop_6_ETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.LongStop_7)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongStop_7_ETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.LongStop_8)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongStop_8_ETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }
                        else if (ArrLoom.CurrentParams.Current_Cause == (int)Cause.LongStop_9)
                        {
                            s = (((ArrLoom.ShiftParams.Shift_LongStop_9_ETime + ts.TotalSeconds) / (ArrLoom.ShiftParams.Shift_DownTime + ts.TotalSeconds)) * 100) * Defficiency / 100;
                            ctrLoom.LongStopLoss.Text = double.IsNaN(s) == true ? "0.00%" : s.ToString("#,##0.00") + "%";
                        }

        }
        public string Get_FormattedTime(TimeSpan ts,int Style)
        {
            string s = "";
            if (Style == (int)TimeFormats.dh)
            {
                if (ts.Days > 0)
                    s = ts.Days.ToString() + "d " + ts.Hours.ToString();
                else if (ts.Hours > 0)
                    s = ts.Hours.ToString() + "h " + ts.Minutes.ToString();
                else if (ts.Minutes > 0)
                    s = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
                else
                    s = ts.Seconds.ToString();
            }
            else if (Style == (int)TimeFormats.HHMMSS)
            {
                s = ts.ToString(@"hh\:mm\:ss");
            }
            else if (Style == (int)TimeFormats.MMSS)
            {
                s = ts.ToString(@"mm\:ss");
            }
            else if (Style == (int)TimeFormats.HHMM)
            {
                s = ts.ToString(@"hh\:mm");
            }
            else if (Style ==(int)TimeFormats.DaysHoursMinutes)
            {
                s = ts.Days.ToString() + " / " + ts.Hours.ToString() + " : " + ts.Minutes.ToString();
            }
            else
            {

                if (ts.TotalHours >= 1)
                    s = ts.ToString(@"hh\:mm\:ss");
                else
                    s = ts.ToString(@"mm\:ss");

            }
            return s;
        }
        public string Get_FormattedTime(int Seconds)
        {

            TimeSpan ts ;
            try
            {
                ts = new TimeSpan(0, 0, Seconds);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            string s = "";
            if (ts.Days > 0)
                s = ts.Days.ToString() + "d " + ts.Hours.ToString();
            else if (ts.Hours > 0)
                s = ts.Hours.ToString() + "h " + ts.Minutes.ToString();
            else if (ts.Minutes > 0)
                s = ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
            else
                s = ts.Seconds.ToString();
            return s;
        }
        public void SetMachineDisplayX(ref MachineService.Loom ArrLoom, ref dxLoomX ctrLoom)
        {
            Font f_running = new Font("Tahoma", 9, FontStyle.Bold);
            Font f_stopped = new Font("Tahoma", 7, FontStyle.Regular);

            if (Settings.CurrentClassicalView == ClassicalViewType.EfficiencyView)
            {

                if (ArrLoom.CurrentParams.DNI == true && ArrLoom.CurrentParams.FDNE == false)
                    ctrLoom.Efficiency.ImageIndex = (int)Cause.DNI;
                else if (ArrLoom.CurrentParams.FDNI == true)
                    ctrLoom.Efficiency.ImageIndex = (int)Cause.FDNI;
                else
                    ctrLoom.Efficiency.ImageIndex = -1;

                if ((State)ArrLoom.CurrentParams.Current_State == State.Running)
                {
                    ctrLoom.Efficiency.Font = f_running;

                    ctrLoom.Efficiency.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Running);

                    ctrLoom.Efficiency.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Running);
                    if (ArrLoom.CurrentParams.Current_Eff < Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ArrLoom.PersonalInfo.ShedID.ToString())].TargetEff)
                        ctrLoom.Efficiency.ForeColor = Color.Red;
                    else
                        ctrLoom.Efficiency.ForeColor = Color.White;



                    string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Eff, 1).ToString();
                    if (Convert.ToDouble(eff) >= 100)
                    {
                        ctrLoom.Efficiency.Tag = eff;
                        ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : 100) + "%";

                    }


                    else
                    {





                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff);




                    }
                }
                else
                {
                    TimeSpan ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Current_SinkTime);
                    ts = ts.Add(Settings.TimeZone_Add);
                    ts = ts.Subtract(Settings.TimeZone_Subtract);
                    ctrLoom.Efficiency.BackColor = Settings.Get_StopCauseColor_backColor((Cause)ArrLoom.CurrentParams.Current_Cause);
                    ctrLoom.Efficiency.ForeColor = Settings.Get_StopCauseColor_foreColor((Cause)ArrLoom.CurrentParams.Current_Cause);
                    ctrLoom.Efficiency.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor((Cause)ArrLoom.CurrentParams.Current_Cause);





                    ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Session_ActualStartTime);
                    ts = ts.Add(Settings.TimeZone_Add);
                    ts = ts.Subtract(Settings.TimeZone_Subtract);
                    if (ts.TotalHours >= 1)
                        ctrLoom.Efficiency.Font = f_stopped;
                    else
                        ctrLoom.Efficiency.Font = f_running;

                    ctrLoom.Efficiency.Text = Get_FormattedTime(ts, 1);

                }

            }
            else if (Settings.CurrentClassicalView == ClassicalViewType.RPMView)
            {
                ctrLoom.Efficiency.Font = f_running;
                ctrLoom.Efficiency.BackColor = Color.White;
                ctrLoom.Efficiency.FlatAppearance.BorderColor = Color.White;
                if (ArrLoom.CurrentParams.Current_RPM < Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ArrLoom.PersonalInfo.ShedID.ToString())].TargetRPM)
                    ctrLoom.Efficiency.ForeColor = Color.Red;
                else
                    ctrLoom.Efficiency.ForeColor = Color.Black;
                ctrLoom.Efficiency.Text = ArrLoom.CurrentParams.Current_RPM.ToString("#,##");
            }
            else if (Settings.CurrentClassicalView == ClassicalViewType.WarpCounterView)
            {
                ctrLoom.Efficiency.Font = f_running;
                ctrLoom.Efficiency.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Warp);

                ctrLoom.Efficiency.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Warp);
                ctrLoom.Efficiency.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Warp);

                ctrLoom.Efficiency.Text = ArrLoom.ShiftParams.Shift_Warps.ToString();
            }
            else if (Settings.CurrentClassicalView == ClassicalViewType.WeftCounterView)
            {
                ctrLoom.Efficiency.Font = f_running;
                ctrLoom.Efficiency.BackColor = Settings.Get_StopCauseColor_backColor(Cause.Weft);

                ctrLoom.Efficiency.FlatAppearance.BorderColor = Settings.Get_StopCauseColor_borderColor(Cause.Weft);
                ctrLoom.Efficiency.ForeColor = Settings.Get_StopCauseColor_foreColor(Cause.Weft);

                ctrLoom.Efficiency.Text = ArrLoom.ShiftParams.Shift_Wefts.ToString();
            }
            else if (Settings.CurrentClassicalView == ClassicalViewType.WarpKnottView)
            {
                ctrLoom.Efficiency.Font = f_running;
                ctrLoom.Efficiency.BackColor = Color.White;

                ctrLoom.Efficiency.FlatAppearance.BorderColor = Color.White;
                if (ArrLoom.CurrentParams.WarpAvgKnotTime > Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ArrLoom.PersonalInfo.ShedID.ToString())].TargetWarpKnotTimeInSeconds)
                    ctrLoom.Efficiency.ForeColor = Color.Red;
                else
                    ctrLoom.Efficiency.ForeColor = Color.Black;
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(ArrLoom.CurrentParams.WarpAvgKnotTime));
                ctrLoom.Efficiency.Text = ts.ToString(@"mm\:ss");
            }
            else if (Settings.CurrentClassicalView == ClassicalViewType.WeftKnottView)
            {
                ctrLoom.Efficiency.Font = f_running;
                ctrLoom.Efficiency.BackColor = Color.White;

                ctrLoom.Efficiency.FlatAppearance.BorderColor = Color.White;
                if (ArrLoom.CurrentParams.WeftAvgKnotTime > Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ArrLoom.PersonalInfo.ShedID.ToString())].TargetWeftKnotTimeInSeconds)
                    ctrLoom.Efficiency.ForeColor = Color.Red;
                else
                    ctrLoom.Efficiency.ForeColor = Color.Black;
                TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(ArrLoom.CurrentParams.WeftAvgKnotTime));
                ctrLoom.Efficiency.Text = ts.ToString(@"mm\:ss");
            }
        }
        public void SetMachineDisplayZ(ref MachineService.Loom ArrLoom, ref UserControls.dxLoomZ ctrLoom)
        {





            if (ArrLoom.CurrentParams.Current_Eff < Program.ss.Machines.PresentationData.Sheds[Program.ss.Machines.PresentationData.ReturnArrayIndex_Sheds(ArrLoom.PersonalInfo.ShedID.ToString())].TargetEff)
                ctrLoom.Efficiency.ForeColor = Color.Red;
            else
                ctrLoom.Efficiency.ForeColor = Color.Yellow;



                string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Eff, 1).ToString();
                if (Convert.ToDouble(eff) >= 100)
                    if (ctrLoom.Efficiency.Tag != null)
                    {
                        if (eff != ctrLoom.Efficiency.Tag.ToString())
                        {
                            ctrLoom.Efficiency.Tag = eff;
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.0 : 99.9); 

                        }
                    }
                    else
                    {
                        ctrLoom.Efficiency.Tag = "100";
                        ctrLoom.Efficiency.Text = "99.9";
                    }
                else
                {


                   
                        ctrLoom.Efficiency.Tag = eff;
                          ctrLoom.Efficiency.Tag = eff;
                           
                                ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.0 : ArrLoom.CurrentParams.Current_Eff);

                       

                   
                }
       
           





        }
        public void SetMachineDisplayY(ref MachineService.Loom ArrLoom, ref dxLoomY ctrLoom)
        {
            if (ArrLoom.CurrentParams.DNI == true && ArrLoom.CurrentParams.FDNE == false)
                ctrLoom.Efficiency.ImageIndex = (int)Cause.DNI;
            else if (ArrLoom.CurrentParams.FDNI == true)
                ctrLoom.Efficiency.ImageIndex = (int)Cause.FDNI;
            else
                ctrLoom.Efficiency.ImageIndex = -1;
            if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
            {
                ctrLoom.Efficiency.Text = "S " + ArrLoom.CurrentParams.SinkNumber;
            }
            else
            {
                string eff = Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? "0.0" : Math.Round(ArrLoom.CurrentParams.Current_Eff, 1).ToString();
                if (Convert.ToDouble(eff) >= 100)
                    if (ctrLoom.Efficiency.Tag != null)
                    {
                       
                            ctrLoom.Efficiency.Tag = eff;
                            
                                ctrLoom.Efficiency.Tag = eff;
                                if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                                    ctrLoom.Efficiency.Text = "";//ArrLoom.CurrentParams.Current_Eff.ToString("#,##");
                                else
                                    ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff);

                          

                    }
                    else
                    {
                        ctrLoom.Efficiency.Tag = "0";
                    }
                else
                {


                   
                        ctrLoom.Efficiency.Tag = eff;
                        if ((ArrLoom.CurrentParams.FDNI == true || ArrLoom.CurrentParams.DNI == true) && ArrLoom.CurrentParams.FDNE == false)
                            ctrLoom.Efficiency.Text = "";//ArrLoom.CurrentParams.Current_Eff.ToString("#,##");
                        else
                            ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff);
                       // ctrLoom.Efficiency.Text = String.Format("{0:F1}", Double.IsNaN(ArrLoom.CurrentParams.Current_Eff) == true ? 0.00 : ArrLoom.CurrentParams.Current_Eff) + "%";

                   
                }
            }


            if (Program.ss.Machines.PresentationData.PresentationSettings.DebugMode == true)
            {
                TimeSpan ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Current_SinkTime);
                ts = ts.Add(Settings.TimeZone_Add);
                ts = ts.Subtract(Settings.TimeZone_Subtract);
                if (ts.TotalSeconds >= Settings.DataWaitingSeconds)
                {
                    if (ts.TotalMinutes >= 10)
                        ctrLoom.LoomNumber.ForeColor = Color.DarkRed;
                    else if (ts.TotalMinutes < 10 && ts.TotalMinutes >= 5)
                        if (ctrLoom.LoomNumber.ForeColor != Color.DarkRed)
                            ctrLoom.LoomNumber.ForeColor = Color.Blue;
                        else if (ts.TotalMinutes < 5)
                            if (ctrLoom.LoomNumber.ForeColor != Color.DarkRed && ctrLoom.LoomNumber.ForeColor != Color.Blue)
                                ctrLoom.LoomNumber.ForeColor = Color.Green;

                    // Program.ss.Machines.Looms[Convert.ToInt32(uiLoom.LoomNumber.Tag)].CurrentParams.Cause_Current = (int)Cause.WaitingWireless;
                    ctrLoom.RPM.ImageIndex = (int)Cause.PowerOff;
                    ctrLoom.RPM.Text = "";
                    ctrLoom.ElapsedTime.Text = Get_FormattedTime(ts,0);

                }
                else
                {
                    ctrLoom.RPM.ImageIndex = -1;
                    ctrLoom.ElapsedTime.Text = "";
                }
            }
            else
            {

                TimeSpan ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Current_SinkTime);
                ts = ts.Add(Settings.TimeZone_Add);
                ts = ts.Subtract(Settings.TimeZone_Subtract);
                      if ((State)ArrLoom.CurrentParams.Current_State != State.Running)
                    {
                        
                        ctrLoom.RPM.Text = "";

                        ctrLoom.RPM.ImageIndex = ArrLoom.CurrentParams.Current_Cause;



                        ts = DateTime.Now.Subtract(ArrLoom.CurrentParams.Session_ActualStartTime);


                        ctrLoom.ElapsedTime.Text = Get_FormattedTime(ts,0);
                    }
                    else
                    {
                        ctrLoom.RPM.Text = Double.IsNaN(ArrLoom.CurrentParams.Current_RPM) == true ? "" : ArrLoom.CurrentParams.Current_RPM.ToString("#,##");
                        if (ctrLoom.RPM.Text != "")
                            ctrLoom.RPM.ImageIndex = -1;
                        else
                            ctrLoom.RPM.ImageIndex = (int)Cause.RunningbutNoRPM;
                        ctrLoom.ElapsedTime.Text = "";

                    }
                
            }
        }
        public int ReturnArrayLoomIndex(string LoomID)
        {
            for (int x = 0; x < Machines.Looms.Length; x++)
            {
                if (Machines.Looms[x].PersonalInfo.LoomID == Convert.ToInt16(LoomID))
                    return x;
            }
            return -1;
        }
        #region Vehicles
        public int ReturnVehicleIndex_ByIMEI(string IMEI)
        {
            try
            {
                if (Machines.Vehicles == null)
                    return -1;
                if (Machines.Vehicles.Length <= 0) return -1;
                for (int x = 0; x < Machines.Vehicles.Length; x++)
                {
                    if (Machines.Vehicles[x].IMEI == IMEI)
                        return x;
                }
                return -1;
            }
            catch 
            {

                return -1;
            }
        }
        public int ReturnVehicleIndex_ByGSM(string GSM)
        {
            try
            {
                if (Machines.Vehicles == null)
                    return -1;
                if (Machines.Vehicles.Length <= 0) return -1;
                for (int x = 0; x < Machines.Vehicles.Length; x++)
                {
                    if (Machines.Vehicles[x].GSM == GSM)
                        return x;
                }
                return -1;
            }
            catch
            {

                return -1;
            }
        }

        public int ReturnVehicleIndex_ByVDN(string VDN)
        {
            try
            {
                if (Machines.Vehicles == null)
                    return -1;
                if (Machines.Vehicles.Length <= 0) return -1;
                for (int x = 0; x < Machines.Vehicles.Length; x++)
                {
                    if (Machines.Vehicles[x].VDN == VDN)
                        return x;
                }
                return -1;
            }
            catch 
            {

                return -1;
            }
        }
        #endregion
        public Service()
        {
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(DoWork);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = true;
            worker.RunWorkerCompleted +=
                   new RunWorkerCompletedEventHandler(WorkerCompleted);
           
            webServiceTimer.Elapsed += new ElapsedEventHandler(CheckService);
            webServiceTimer.Interval = (20000);
            
            GC.KeepAlive(webServiceTimer);
        }
        public void StartPing()
        {
            webServiceTimer.Enabled = true;
            
        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                pingSession();

            }
            catch 
            {

            }
          
        }
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (WS.svcStatus.Status == serviceStatus.CONNECTED)
                WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;
        }
        #region MachinesConfigs
        public void ConfigureDevices()
        {
            try
            {
                int NumberofDevices = WS.svc.getTotalNumberofDevices();
                Array.Resize(ref Machines.Devices, NumberofDevices);
                for (int x = 0; x < NumberofDevices; x++)
                {
                    Machines.Devices[x] = new DisplayBoardDevice();
                    Machines.Devices[x].PublicInfo = WS.svc.Get_DeviceByID(x.ToString());
                    if (Machines.Devices[x].PublicInfo != null)
                    {
                        try
                        {
                        MachineService.DisplayBoardsClientListInfo[] ls= WS.svc.Get_Device_Connections(x, -1);
                        if (ls != null)
                            Machines.Devices[x].ListInfo = ls;
                        }
                        catch
                        {                            }
                        
                    }
                   

                   
                }
               
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error_ConfigureDevices", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        public void ConfigureVehicles()
        {
            int TotalVehicles = 0;
            try
            {
                TotalVehicles = WS.svc.Get_GPS_TotalVehicles();
                Array.Resize(ref Machines.Vehicles, TotalVehicles);
                for (int x = 0; x < TotalVehicles; x++)
                {
                    Machines.Vehicles[x] = new MachineService.Vehicle();
                    Machines.Vehicles[x] = WS.svc.Get_GPS_ReturnVehicle_ByIndex(x);

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error_ConfigureVehicles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ConfigureLooms()
        {
            double total;
            double xx=0;
            double result;
            try
            {
                WS.ServiceIcon = serviceIcons.PING;
                int TotalLooms = WS.svc.Get_TotalLooms();
                WS.ServiceIcon = serviceIcons.DATA_RECEIVED;
                total = Convert.ToDouble(TotalLooms+5);
                try
                {
                    DateTime ServerTime = WS.svc.Get_CurrentTime();
                    DateTime MyTime = DateTime.Now;
                    TimeSpan ts;
                    if (ServerTime > MyTime)
                    {
                        ts = ServerTime.Subtract(MyTime);
                        Settings.TimeZone_Add = ts;
                        Settings.TimeZone_Subtract = new TimeSpan(0);

                    }
                    else if (ServerTime < MyTime)
                    {
                        ts = MyTime.Subtract(ServerTime);
                        Settings.TimeZone_Subtract = ts;
                        Settings.TimeZone_Add = new TimeSpan(0);
                    }
                    else
                    {
                        ts = new TimeSpan(0);
                        Settings.TimeZone_Subtract = ts;
                        Settings.TimeZone_Add = ts;
                    }
                }
                catch
                {
                }
                Machines.PresentationData.init_Counts();
                Machines.PresentationData.init_CPInfo();
                result = (( 1) / total) * 100;
                meProgress.Progress = (int)result;
                if(Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode==false)Machines.PresentationData.init_Sets();
                result = ((2) / total) * 100;
                meProgress.Progress = (int)result;
                Machines.PresentationData.Get_Currentshift();
                result = ((3) / total) * 100;
                meProgress.Progress = (int)result;
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) Machines.PresentationData.init_Sheds();
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) Machines.PresentationData.init_MergedSheds();
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) Machines.PresentationData.init_Beams();
                result = ((4) / total) * 100;
                meProgress.Progress = (int)result;
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) Machines.PresentationData.init_Articles();
                
                result = ((5) / total) * 100;
                Machines.PresentationData.Get_WebServiceSettings();
                meProgress.Progress = (int)result;

                result = ((6) / total) * 100;
                ConfigureDevices();
                meProgress.Progress = (int)result;

                //ConfigureVehicles();
             
                #region Looms
                if (TotalLooms > 0 && Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode==false)
                {
                    Array.Resize(ref Machines.Looms, 0);
                    Array.Resize(ref Machines.Looms, TotalLooms);

                    for (int x = 0; x < TotalLooms; x++)
                    {
                        Array.Resize(ref Machines.Looms, x + 1);
                        
                        Machines.Looms[x] = new MachineService.Loom();
                        Machines.Looms[x].sLI = new MachineEyes.MachineService.sinkLoomInfo();
                        Machines.Looms[x].CurrentParams = new MachineEyes.MachineService.loomcurrentParams();
                        Machines.Looms[x].PersonalInfo = new MachineEyes.MachineService.loompersonalInfo();
                        Machines.Looms[x].Drawing = new MachineEyes.MachineService.loomdrawingInfo();

                        if (Settings.LoadFromCache == false)
                        {
                            
                            Machines.Looms[x] = WS.svc.Get_Loom_byLoomID(x);
                            
                        }
                        else
                        {
                            //fetch from local mdb database file
                        }
                        xx = Convert.ToDouble(x);
                        result = ((xx + 6) / total) * 100;
                        meProgress.Progress = (int)result;
                        WS.ServiceIcon = serviceIcons.TRYINGSUCCEEDED;
                    }

                    
            
                    // LoomDraw[0].drawImage(Looms[0].Drawing.x + 5, Looms[0].Drawing.y);

                }
                //Machines.MACDictionary.Clear();
                //for (int x = 0; x < Machines.Looms.Length; x++)
                //{
                //    MachineService.loompersonalInfo lpi = new MachineService.loompersonalInfo();
                //    lpi = Machines.Looms[x].PersonalInfo;
                //    Machines.MACDictionary.Add(Machines.Looms[x].PersonalInfo.MAC,lpi);
                //}

               
                #endregion
                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) init_AssignLooms_TypesofLooms();

                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) init_AssignLooms_LoomGroups();

                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) init_AssignWeavers_LoomGroups();

                if (Program.ss.Machines.PresentationData.PresentationSettings.OnlyAccountsMode == false) init_AssignLooms_Articles();
                meProgress.Progress = 100;
                WS.ServiceIcon = serviceIcons.TRYINGSUCCEEDED;
                ConfigurationLoaded = true;
                WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;
            }
            catch (Exception ex)
            {
                WS.svcStatus.LastErrMsg = ex.Message;
                WS.svcStatus.Status = serviceStatus.BROKEN;
                WS.ServiceIcon = serviceIcons.DISCONNECTED;
            }
        }

        public void init_AssignLooms_TypesofLooms()
        {
            try
            {
                int TypeIndex = 0;
                int ShedIndex = 0;
                for (int x = 0; x < Machines.Looms.Length; x++)
                {
                    if (TypeIndex != -1)
                    {
                        ShedIndex = Machines.PresentationData.ReturnArrayIndex_Sheds(Machines.Looms[x].PersonalInfo.ShedID.ToString());
                        TypeIndex = Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_Types(Machines.Looms[x].PersonalInfo.TypeID.ToString());
                        Array.Resize(ref Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].LoomIndexes, Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].LoomIndexes.Length + 1);
                        Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].LoomIndexes[Machines.PresentationData.Sheds[ShedIndex].TypesOfLooms[TypeIndex].LoomIndexes.Length - 1] = x;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("init_AssignedLooms_TypesofLooms:: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void init_AssignLooms_LoomGroups()
        {
            int GroupIndex = 0;
            int ShedIndex = 0;
            for (int x = 0; x < Machines.Looms.Length; x++)
            {
                ShedIndex = Machines.PresentationData.ReturnArrayIndex_Sheds(Machines.Looms[x].PersonalInfo.ShedID.ToString());
                GroupIndex = Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Machines.Looms[x].PersonalInfo.GroupNumber);
                if (GroupIndex != -1)
                {
                    Array.Resize(ref Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes, Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length + 1);
                    Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes[Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].LoomIndexes.Length - 1] = x;
                }
            }
        }
        public void init_AssignLooms_Articles()
        {
            string nArticleNumber;
            foreach (article item in Program.ss.Machines.PresentationData.Articles.Values)
            {
                Array.Resize(ref item.LoomIndexes, 0);
            }
            for (int x = 0; x < Machines.Looms.Length; x++)
            {
                nArticleNumber = Machines.Looms[x].CurrentAssignedParams.ArticleNumber;
                if (nArticleNumber != null)
                {
                    if (nArticleNumber == "")
                        nArticleNumber = "0";
                    if (nArticleNumber != "")
                    {
                        try
                        {
                            Array.Resize(ref Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes, Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes.Length + 1);
                            Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes[Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes.Length - 1] = x;
                        }
                        catch 
                        {
                            nArticleNumber = "0";
                            Array.Resize(ref Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes, Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes.Length + 1);
                            Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes[Program.ss.Machines.PresentationData.Articles[nArticleNumber].LoomIndexes.Length - 1] = x; 
                        }

                    }
                    else
                    {

                    }
                }
               
            }
        }
        public void init_AssignWeavers_LoomGroups()
        {
            try
            {
                DataSet ds = new DataSet();
                int GroupIndex = 0;
                int ShedIndex = 0;
                ds = WS.svc.Get_DataSet("Select * from Distinct_Weavers order by Groupnumber");
                if (ds != null)
                {
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        ShedIndex = Machines.PresentationData.ReturnArrayIndex_Sheds(ds.Tables[0].Rows[x]["ShedID"].ToString());
                        if (ShedIndex != -1)
                        {
                            GroupIndex = Machines.PresentationData.Sheds[ShedIndex].ReturnArrayIndex_LoomGroup(Convert.ToInt32(ds.Tables[0].Rows[x]["GroupNumber"].ToString()));
                            if (GroupIndex != -1)
                            {
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_A = ds.Tables[0].Rows[x]["WeaverID_A"].ToString();
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_B = ds.Tables[0].Rows[x]["WeaverID_B"].ToString();
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverID_C = ds.Tables[0].Rows[x]["WeaverID_C"].ToString();
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_A = ds.Tables[0].Rows[x]["WeaverName_A"].ToString();
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_B = ds.Tables[0].Rows[x]["WeaverName_B"].ToString();
                                Machines.PresentationData.Sheds[ShedIndex].LoomGroups[GroupIndex].Weavers.WeaverName_C = ds.Tables[0].Rows[x]["WeaverName_C"].ToString();
                            }
                        }
                    }
                    ds = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Assigning Weavers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region webServiceLogins
        private void CheckService(object source, ElapsedEventArgs e)
       {

            if (worker.IsBusy == false)
            {
                try
                {
                    worker.RunWorkerAsync();

                }
                catch 
                {
                   

                }
            }
        }
        public bool Login(string UserID, string Password, string Role)
        {

            try
            {
                WS.ServiceIcon = serviceIcons.TRYING;
                MachineEyes.Classes.Security.User.UserID = UserID;
                MachineEyes.Classes.Security.User.Password = Password;
                MachineEyes.Classes.Security.User.Role = Role;
                MachineEyes.Classes.Security.EncPassword = MachineEyes.Classes.Security.EncryptData(UserID, Password);

                MachineEyes.Classes.Security.SessionCode = WS.svc.AuthenticateSession(UserID, MachineEyes.Classes.Security.EncPassword, Role);
                WS.ServiceIcon = serviceIcons.TRYINGSUCCEEDED;
                if (MachineEyes.Classes.Security.SessionCode.Contains("**") == true && MachineEyes.Classes.Security.SessionCode.Contains("##") == true)
                {
                    //MessageBox.Show(MachineEyes.Classes.Security.SessionCode, "Error in Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MachineEyes.Classes.Security.User.LastMessage = "Error in Login";
                    MachineEyes.Classes.Security.User.Status = Convert.ToInt32(LoginStatus.Denied);
                    WS.svcStatus.Status = serviceStatus.DISCONNECTED;
                    WS.ServiceIcon = serviceIcons.DISCONNECTED;
                    WS.svcStatus.LastErrMsg = "Error in Login";
                    return false;
                }

                MachineEyes.Classes.Security.User.SCodes = WS.svc.get_ssSession(MachineEyes.Classes.Security.SessionCode + MachineEyes.Classes.Security.EncryptData(MachineEyes.Classes.Security.EncPassword, MachineEyes.Classes.Security.SessionCode));
                if (MachineEyes.Classes.Security.User.SCodes == null)
                {
                    
                    WS.svcStatus.Status = serviceStatus.DISCONNECTED;
                    WS.svcStatus.LastErrMsg = "Unable to Validate Session Code ";
                    WS.ServiceIcon = serviceIcons.DISCONNECTED;
                    MachineEyes.Classes.Security.User.LastMessage = "Unable to validate session code";
                    MachineEyes.Classes.Security.User.Status = Convert.ToInt32(LoginStatus.Denied);
                    
                    return false;

                }
                else
                {

                    string key = MachineEyes.Classes.Security.EncryptData(MachineEyes.Classes.Security.EncPassword, MachineEyes.Classes.Security.SessionCode);
                    WS.spAh.SessionKey = MachineEyes.Classes.Security.SessionCode + key;
                    WS.svc.AuthSoapHdValue = WS.spAh;
                }
                MachineEyes.Classes.Security.User.Status = Convert.ToInt32(LoginStatus.Normal);
                MachineEyes.Classes.Security.User.Authenticated = true;
                MachineEyes.Classes.Security.User.LastMessage = "User Logged in Successfully";
                WS.svcStatus.Status  = serviceStatus.CONNECTED;
                WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;
                WS.svcStatus.LastSuccessfullPingTime = DateTime.Now;
                return true;

            }
            catch (Exception ex)
            {
                WS.svcStatus.Status = serviceStatus.BROKEN;
                WS.svcStatus.LastErrMsg = ex.Message;
                WS.ServiceIcon = serviceIcons.DISCONNECTED;
                MachineEyes.Classes.Security.User.LastMessage = ex.Message;
                MachineEyes.Classes.Security.User.Status = Convert.ToInt32(LoginStatus.Failed);
                
                return false;
            }
        }
        public void pingSession()
        {
            if (MachineEyes.Classes.Security.User.Authenticated == false) return;
            string retKey = "";


            try
            {
                WS.ServiceIcon =serviceIcons.PING;//ping data icon
                if (MachineEyes.Classes.Security.User != null)
                    retKey = WS.svc.get_ssValidateSession(MachineEyes.Classes.Security.User.UserID, MachineEyes.Classes.Security.EncPassword, MachineEyes.Classes.Security.User.SCodes.UserRole.ToString(), MachineEyes.Classes.Security.User.SCodes.SessionCode);
                else
                    retKey = WS.svc.get_ssValidateSession(MachineEyes.Classes.Security.User.UserID, MachineEyes.Classes.Security.EncPassword, MachineEyes.Classes.Security.User.Role, "");
                WS.ServiceIcon =serviceIcons.DATA_RECEIVED;//received data icon
                if (retKey == WS.spAh.SessionKey) { WS.ServiceIcon = serviceIcons.CONNECTEDIDLE; WS.svcStatus.Status = serviceStatus.CONNECTED; WS.svcStatus.LastSuccessfullPingTime = DateTime.Now; return; }
                else
                {

                    WS.svcStatus.Status = serviceStatus.BROKEN;
                    WS.ServiceIcon = serviceIcons.DISCONNECTED;
                    WS.svcStatus.LastErrMsg = "User Disconnected or the session has been expired...";
                    Login(MachineEyes.Classes.Security.User.UserID, MachineEyes.Classes.Security.User.Password, MachineEyes.Classes.Security.User.Role);




                }
                if (WS.svcStatus.Status == serviceStatus.CONNECTED)
                    WS.ServiceIcon = serviceIcons.CONNECTEDIDLE;
            }
            catch(Exception ex)
            {
                WS.svcStatus.Status  = serviceStatus.BROKEN;
                WS.ServiceIcon = serviceIcons.DISCONNECTED;
                WS.svcStatus.LastErrMsg = ex.Message;
                Login(MachineEyes.Classes.Security.User.UserID, MachineEyes.Classes.Security.User.Password, MachineEyes.Classes.Security.User.Role);

            }

        }
        public void ReadXML_MachineEyesConfigs()
        {

            try
            {
                string path = Settings.AppPath + "\\Configurations.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                System.Xml.XmlNode node = doc.SelectSingleNode("MachineEyesConfigs");
                Array.Resize(ref Settings.ServiceIPS, 0);
                Array.Resize(ref MachineEyes.Classes.Accounting.Years,0);
                if (node != null)
                {

                    foreach (XmlNode nodex in node.ChildNodes)
                    {
                       if (nodex.Name == "UserID")
                            MachineEyes.Classes.Security.User.UserID = Convert.ToString(nodex.InnerXml);
                        else if (nodex.Name == "UserPWD")
                            MachineEyes.Classes.Security.User.Password = MachineEyes.Classes.Security.DecryptData( MachineEyes.Classes.Security.User.UserID, Convert.ToString(nodex.InnerXml));
                        else if (nodex.Name == "ServiceDir")
                            Settings.ServiceDir = Convert.ToString(nodex.InnerXml);
                        else if (nodex.Name == "AutoLogin")
                        {
                            Settings.AutoLogin = Convert.ToString(nodex.InnerXml)=="1"?true:false;
                        }
                        else if (nodex.Name == "DefaultShed")
                        {
                            Settings.DefaultShed = Convert.ToInt32(nodex.InnerXml);
                        }
                        else if (nodex.Name == "RefreshTime")
                        {
                            Settings.RefreshTime = Convert.ToInt32(nodex.InnerXml);
                        }
                        else if (nodex.Name.Contains("ServiceIP_")==true)
                        {
                            Array.Resize(ref Settings.ServiceIPS, Settings.ServiceIPS.Length + 1);
                            Settings.ServiceIPS[Settings.ServiceIPS.Length - 1] = Convert.ToString(nodex.InnerXml);
                        }
                       else if (nodex.Name.Contains("AlertSound") == true)
                       {
                           
                           Settings.AlertSound = Convert.ToString(nodex.InnerXml);
                       }
                        else if (nodex.Name.Contains("FinYear_") == true)
                        {
                            Array.Resize(ref MachineEyes.Classes.Accounting.Years, MachineEyes.Classes.Accounting.Years.Length + 1);
                            MachineEyes.Classes.Accounting.Years[MachineEyes.Classes.Accounting.Years.Length - 1] = Convert.ToString(nodex.InnerXml);
                        }

                    }
                    if (Settings.ServiceIPS.Length > 0)
                        Settings.ServiceIP = Settings.ServiceIPS[0];
                    WS.svc.Url = Settings.ServiceIP + Settings.ServiceDir;

                }
                doc = null;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:Reading XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
    public class presentationSettings
    {
        public bool DebugMode;
        public bool OnlyAccountsMode;
    }
    public class presentationData
    {
        public presentationSettings PresentationSettings = new presentationSettings();
        public MachineService.ClientListInfo[] TCPClients = new MachineService.ClientListInfo[0];
        public MachineService.ClientListInfo[] GPSTCPClients = new MachineService.ClientListInfo[0];
        public int TCPClients_DataNumber;
        public DateTime TCPClients_LastCheck;
        public int GPSTCPClients_DataNumber;
        public DateTime GPSTCPClients_LastCheck;
        public set[] Sets = new set[0];
        public beam[] Beams = new beam[0];
        public cCounts[] Counts = new cCounts[0];
        public currentShift CurrentShift = new currentShift();

        public MachineService.cpInfo CPInfo = new MachineService.cpInfo();
        public LoomShed[] Sheds = new LoomShed[0];
        public MergedLoomShed[] MergedSheds = new MergedLoomShed[0];
        public MachineService.alertinfo DesktopAlert = new MachineService.alertinfo();
        public DateTime DesktopAlertTimeLastChecked = DateTime.Now;
        public Dictionary<string, article> Articles = new Dictionary<string, article>();
   
        public presentationData()
        {
            
            CPInfo.cpID = "2.1";
        
        }
        
        public void init_Sheds()
        {
            #region Sheds
            DataSet dsSheds = new DataSet();
            try
            {
                dsSheds = WS.svc.Get_DataSet("Select * from MT_Sheds order by ShedID");
                if (dsSheds != null)
                {
                    Array.Resize(ref Sheds, dsSheds.Tables[0].Rows.Count);

                    for (int x = 0; x < dsSheds.Tables[0].Rows.Count; x++)
                    {
                        Sheds[x] = new LoomShed();
                        Sheds[x].ShedID = dsSheds.Tables[0].Rows[x]["ShedID"].ToString() == "" ? "0" : dsSheds.Tables[0].Rows[x]["ShedID"].ToString();
                        Sheds[x].ShedName = dsSheds.Tables[0].Rows[x]["ShedName"].ToString() == "" ? "Shed 1" : dsSheds.Tables[0].Rows[x]["ShedName"].ToString();
                        Sheds[x].TargetEff = dsSheds.Tables[0].Rows[x]["TargetEff"].ToString() == "" ? 90 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetEff"].ToString());
                        Sheds[x].TargetRPM = dsSheds.Tables[0].Rows[x]["TargetRPM"].ToString() == "" ? 90 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetRPM"].ToString());
                        Sheds[x].TargetWarpKnotTimeInSeconds = dsSheds.Tables[0].Rows[x]["TargetWarpKnotTime"].ToString() == "" ? 80 : Convert.ToInt32(dsSheds.Tables[0].Rows[x]["TargetWarpKnotTime"].ToString());
                        Sheds[x].TargetWeftKnotTimeInSeconds = dsSheds.Tables[0].Rows[x]["TargetWeftKnotTime"].ToString() == "" ? 60 : Convert.ToInt32(dsSheds.Tables[0].Rows[x]["TargetWeftKnotTime"].ToString());
                        Sheds[x].TargetWarpPerHour = dsSheds.Tables[0].Rows[x]["TargetWarpPerHour"].ToString() == "" ? 1.0 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetWarpPerHour"].ToString());
                        Sheds[x].TargetWeftPerHour = dsSheds.Tables[0].Rows[x]["TargetWeftPerHour"].ToString() == "" ? 1.0 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetWeftPerHour"].ToString());
                        Sheds[x].TargetRunningEff = dsSheds.Tables[0].Rows[x]["TargetRunningEff"].ToString() == "" ? 95 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetRunningEff"].ToString());
                        Sheds[x].TargetWarpLoss = dsSheds.Tables[0].Rows[x]["TargetWarpLoss"].ToString() == "" ? 1.0 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetWarpLoss"].ToString());
                        Sheds[x].TargetWeftLoss = dsSheds.Tables[0].Rows[x]["TargetWeftLoss"].ToString() == "" ? 1.0 : Convert.ToDouble(dsSheds.Tables[0].Rows[x]["TargetWeftLoss"].ToString());
                        Sheds[x].init_Colors();
                        Sheds[x].init_LoomGroups();
                        Sheds[x].init_Technicians();
                        Sheds[x].init_TypesofLooms();
                        Sheds[x].init_Sections(); 
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }
        public void init_MergedSheds()
        {
            #region MergedSheds
            DataSet dsSheds = new DataSet();
            try
            {
                dsSheds = WS.svc.Get_DataSet("Select * from MT_Sheds_MergedLayout order by LayoutIndex");
                if (dsSheds != null)
                {
                    Array.Resize(ref MergedSheds, dsSheds.Tables[0].Rows.Count);

                    for (int x = 0; x < dsSheds.Tables[0].Rows.Count; x++)
                    {
                        MergedSheds[x] = new MergedLoomShed();
                        MergedSheds[x].LayoutIndex = dsSheds.Tables[0].Rows[x]["LayoutIndex"].ToString() == "" ? 0 : Convert.ToInt32(dsSheds.Tables[0].Rows[x]["LayoutIndex"].ToString());
                        MergedSheds[x].LayoutName = dsSheds.Tables[0].Rows[x]["LayoutName"].ToString() == "" ? "Layout 1" : dsSheds.Tables[0].Rows[x]["LayoutName"].ToString();
                        MergedSheds[x].ShedID_0 = dsSheds.Tables[0].Rows[x]["ShedID_0"].ToString() == "" ? "" : dsSheds.Tables[0].Rows[x]["ShedID_0"].ToString();
                        MergedSheds[x].ShedID_1 = dsSheds.Tables[0].Rows[x]["ShedID_1"].ToString() == "" ? "" : dsSheds.Tables[0].Rows[x]["ShedID_1"].ToString();
                        MergedSheds[x].ShedID_2 = dsSheds.Tables[0].Rows[x]["ShedID_2"].ToString() == "" ? "" : dsSheds.Tables[0].Rows[x]["ShedID_2"].ToString();
                        MergedSheds[x].ShedID_3 = dsSheds.Tables[0].Rows[x]["ShedID_3"].ToString() == "" ? "" : dsSheds.Tables[0].Rows[x]["ShedID_3"].ToString();
                        MergedSheds[x].ShedID_4 = dsSheds.Tables[0].Rows[x]["ShedID_4"].ToString() == "" ? "" : dsSheds.Tables[0].Rows[x]["ShedID_4"].ToString();
                        if (MergedSheds[x].ShedID_0 != "")
                            if (MergedSheds[x].ShedIds != "")
                                MergedSheds[x].ShedIds += "," + MergedSheds[x].ShedID_0;
                            else
                                MergedSheds[x].ShedIds += MergedSheds[x].ShedID_0;
                        if (MergedSheds[x].ShedID_1 != "")
                            if (MergedSheds[x].ShedIds != "")
                                MergedSheds[x].ShedIds += "," + MergedSheds[x].ShedID_1;
                            else
                                MergedSheds[x].ShedIds += MergedSheds[x].ShedID_1;
                        if (MergedSheds[x].ShedID_2 != "")
                            if (MergedSheds[x].ShedIds != "")
                                MergedSheds[x].ShedIds += "," + MergedSheds[x].ShedID_2;
                            else
                                MergedSheds[x].ShedIds += MergedSheds[x].ShedID_2;
                        if (MergedSheds[x].ShedID_3 != "")
                            if (MergedSheds[x].ShedIds != "")
                                MergedSheds[x].ShedIds += "," + MergedSheds[x].ShedID_3;
                            else
                                MergedSheds[x].ShedIds += MergedSheds[x].ShedID_3;
                        if (MergedSheds[x].ShedID_4 != "")
                            if (MergedSheds[x].ShedIds != "")
                                MergedSheds[x].ShedIds += "," + MergedSheds[x].ShedID_4;
                            else
                                MergedSheds[x].ShedIds += MergedSheds[x].ShedID_4;
                        MergedSheds[x].init_Colors();
                        MergedSheds[x].init_LoomGroups();
                        MergedSheds[x].init_Technicians();
                        MergedSheds[x].init_TypesofLooms();
                        MergedSheds[x].init_Sections();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }
        public void init_Counts()
        {
            #region Counts
            DataSet dsCounts = new DataSet();
            try
            {
                dsCounts = WS.svc.Get_DataSet("Select * from PP_YarnCounts order by YarnCount");
                if (dsCounts != null)
                {
                    Array.Resize(ref Counts, dsCounts.Tables[0].Rows.Count);

                    for (int x = 0; x < dsCounts.Tables[0].Rows.Count; x++)
                    {
                        Counts[x] = new cCounts();
                        Counts[x].Count = dsCounts.Tables[0].Rows[x]["YarnCount"].ToString() == "" ? "" : dsCounts.Tables[0].Rows[x]["YarnCount"].ToString();
                        Counts[x].EnglishCount = dsCounts.Tables[0].Rows[x]["EnglishCount"].ToString() == "" ? 0 : Convert.ToDouble(dsCounts.Tables[0].Rows[x]["EnglishCount"].ToString());
                       
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

        }
        public void init_Articles()
        {
            try
            {
                Articles.Clear();
                DataSet dsArticles = new DataSet();
                article xArticle = new article();
                xArticle.ArticleNumber = "0";
                xArticle.ArticleName = "NO_ARTICLE_DEFINED";
                Articles.Add("0", xArticle);
                dsArticles = WS.svc.Get_DataSet("Select articlenumber,articleshortname,weightgrams,ppi,ExpectedCrimp from PP_Article order by ArticleNumber");
                if (dsArticles != null)
                {


                    for (int x = 0; x < dsArticles.Tables[0].Rows.Count; x++)
                    {
                        try
                        {
                            article nArticle = new article();

                            nArticle.ArticleNumber = dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString() == "" ? "" : dsArticles.Tables[0].Rows[x]["ArticleNumber"].ToString();
                            nArticle.ArticleName = dsArticles.Tables[0].Rows[x]["articleshortname"].ToString() == "" ? "" : dsArticles.Tables[0].Rows[x]["articleshortname"].ToString();
                            nArticle.WeightGrams = dsArticles.Tables[0].Rows[x]["weightgrams"].ToString() == "" ? "" : dsArticles.Tables[0].Rows[x]["weightgrams"].ToString();
                            nArticle.ExpectedCrimp = dsArticles.Tables[0].Rows[x]["ExpectedCrimp"].ToString() == "" ? 0 : Convert.ToDouble(dsArticles.Tables[0].Rows[x]["ExpectedCrimp"].ToString());
                            int.TryParse(dsArticles.Tables[0].Rows[x]["PPI"].ToString(), out nArticle.PPI);
                            Articles.Add(nArticle.ArticleNumber, nArticle);
                        }
                        catch
                        {
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("init_Articles:: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public article Return_Article(string ArticleNumber)
        {
            if (Articles.ContainsKey(ArticleNumber) == true)
            {
               return Articles[ArticleNumber];
            }
            return null;
        }
        public double Return_EnglishCount(string YarnCount)
        {
            for(int x=0;x<Counts.Length;x++)
            {
                if (YarnCount==Counts[x].Count)
                {
                    return Counts[x].EnglishCount;
                }
            }
            return 0;
        }
        public void init_Beams()
        {
            try
            {
                #region Sheds
                DataSet dsBeams = new DataSet();

                dsBeams = WS.svc.Get_DataSet("Select * from SW_Beams order by BeamNumber");
                if (dsBeams != null)
                {
                    Array.Resize(ref Beams, dsBeams.Tables[0].Rows.Count);

                    for (int x = 0; x < dsBeams.Tables[0].Rows.Count; x++)
                    {
                        Beams[x] = new beam();
                        Beams[x].BeamNumber = dsBeams.Tables[0].Rows[x]["BeamNumber"].ToString() == "" ? "0" : dsBeams.Tables[0].Rows[x]["BeamNumber"].ToString();
                        Beams[x].Status = (BeamStatus)Convert.ToInt16(dsBeams.Tables[0].Rows[x]["BeamStatus"].ToString() == "" ? "0" : dsBeams.Tables[0].Rows[x]["BeamStatus"].ToString());

                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("init_Beams::" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public BeamStatus Return_BeamStatus(string BeamNumber)
        {
            for (int x = 0; x < Beams.Length; x++)
            {
                if (Beams[x].BeamNumber == BeamNumber)
                    return Beams[x].Status;
            }
            return BeamStatus.BeamNotFound;
        }
        public int ReturnArrayIndex_Sheds(string ShedID)
        {
            for (int x = 0; x < Sheds.Length; x++)
            {
                if (Sheds[x].ShedID == ShedID)
                    return x;
            }
            return -1;
        }
        public int ReturnArrayIndex_MergedSheds(string ShedID)
        {
            for (int x = 0; x < MergedSheds.Length; x++)
            {
                if (MergedSheds[x].ShedID_0 == ShedID)
                    return x;
                else if (MergedSheds[x].ShedID_1 == ShedID)
                    return x;
                if (MergedSheds[x].ShedID_2 == ShedID)
                    return x;
                if (MergedSheds[x].ShedID_3 == ShedID)
                    return x;
                if (MergedSheds[x].ShedID_4 == ShedID)
                    return x;
            }
            return -1;
        }
        public int ReturnArrayIndex_MergedSheds(int LayoutIndex)
        {
            for (int x = 0; x < MergedSheds.Length; x++)
            {
                if (MergedSheds[x].LayoutIndex == LayoutIndex)
                    return x;
               
            }
            return -1;
        }       
        public void Get_Currentshift()
        {
            #region currentShift
            try
            {
                MachineService.currentShift cS = new MachineService.currentShift();
                cS = WS.svc.Get_CurrentShift();

                CurrentShift.WShift = cS.WShift;
                CurrentShift.ChangedAt = cS.ChangedAt;
                CurrentShift.ShiftStartDate = cS.ShiftStartDate;
                CurrentShift.LastChecked = DateTime.Now;
            }
            catch 
            {
            }
            #endregion
        }
        public void Get_WebServiceSettings()
        {
            
            try
            {
                Settings.CurrentSettings = WS.svc.Get_CurrentSettings();
              
               
            }
            catch
            {
            }
        }     
        public void init_Sets()
        {
            #region Sets
            DataSet dsSet = new DataSet();

            dsSet = WS.svc.Get_DataSet("Select * from SW_Sizing where SetNo in (select distinct SetNo from MT_Looms)");
            if (dsSet != null)
            {
                Array.Resize(ref Sets , dsSet.Tables[0].Rows.Count);
                for (int x = 0; x < dsSet.Tables[0].Rows.Count; x++)
                {
                    Sets[x] = new set();
                    Sets[x].SetNumber = Convert.ToString(dsSet.Tables[0].Rows[x]["SetNo"]);
                    Sets[x].SizingDate = Convert.ToDateTime(dsSet.Tables[0].Rows[x]["SizingDate"]);
                    

                }
            }
            #endregion

        }     
        public void init_CPInfo()
        {
            try
            {
                CPInfo = WS.svc.Get_CPInfo();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error init_CPinfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
       
    }
    public class LoomShed
    {
        public string ShedID;
        public string ShedName;
        public double TargetEff;
        public double TargetRPM;
        public double TargetWarpLoss;
        public double TargetWeftLoss;
        public double TargetRunningEff;
        public int TargetWarpKnotTimeInSeconds;
        public int TargetWeftKnotTimeInSeconds;
        public double TargetWarpPerHour;
        public double TargetWeftPerHour;
        #region Variables
        public loomSection[] Sections = new loomSection[0];
        public loomType[] TypesOfLooms = new loomType[0];
        public shedEff ShedEfficiency = new shedEff();
        public longStopped LongStops = new longStopped();
        public shortStopped ShortStops = new shortStopped();
        public technician[] Technicians = new technician[0];
        public range[] Range_Color = new range[0];
        public loomGroup[] LoomGroups = new loomGroup[0];
        public stoppedStats StoppedStats = new stoppedStats();
        #endregion
        #region ReturnIndex
        public int ReturnMax_EffIndex()
        {
            int maxEffindex = 0;
            for (int x = 0; x < Range_Color.Length; x++)
            {
                if (Range_Color[x].index > maxEffindex)
                    maxEffindex = Range_Color[x].index;

            }
            return maxEffindex;
        }
        public int Return_SectionIndex(string SectionID)
        {
            
            for (int x = 0; x < Sections.Length; x++)
            {
                if (Sections[x].SectionID == SectionID)
                    return x;

            }
            return -1;
        }

        public int ReturnArrayIndex_Types(string TypeID)
        {
            for (int x = 0; x < TypesOfLooms.Length; x++)
            {
                if (TypesOfLooms[x].TypeID == TypeID)
                    return x;
            }
            return 0;
        }
        public int ReturnArrayIndex_LoomGroup(int argGroupNumber)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                if (LoomGroups[x].GroupNumber == argGroupNumber)
                    return x;

            }
            return -1;
        }
        public int ReturnArrayIndex_LoomGroup_ByWeaverID(string WeaverID, string Shift)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                if (Shift == "A")
                {
                    if (LoomGroups[x].Weavers.WeaverID_A == WeaverID)
                        return x;
                }
                else if (Shift == "B")
                {
                    if (LoomGroups[x].Weavers.WeaverID_B == WeaverID)
                        return x;
                }
                else if (Shift == "C")
                {
                    if (LoomGroups[x].Weavers.WeaverID_C == WeaverID)
                        return x;
                }

               

            }
            return -1;
        }
        public int ReturnArrayIndex_LoomGroup_ByLoomIndex(int argLoomIndex)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                for (int l = 0; l < LoomGroups[x].LoomIndexes.Length; l++)
                {
                    if (LoomGroups[x].LoomIndexes[l] == argLoomIndex)
                        return x;
                }

            }
            return -1;
        }
        public Color ReturnColor(ColorCauses CC, double Val)
        {
            ColorConverter cr = new ColorConverter();
            for (int x = 0; x < Range_Color.Length; x++)
            {
                if (Val >= Range_Color[x].Minimum && Val <= Range_Color[x].Maximum && Range_Color[x].CC == (int)CC)
                {
                    if (Range_Color[x].FontColor != "")
                        return (Color)cr.ConvertFromString(Range_Color[x].FontColor);
                    else
                        return Color.Black;
                }

            }
            return Color.Black;
        }
        #endregion
        #region Inits
        public void init_Sections()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = WS.svc.Get_DataSet("Select * from MT_LoomSections where SectionID in(select Distinct SectionID from MT_Looms where ShedID='" + this.ShedID + "')");

                if (ds != null)
                {
                    Array.Resize(ref this.Sections, ds.Tables[0].Rows.Count);
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        this.Sections[x] = new loomSection();
                        this.Sections[x].SectionID = ds.Tables[0].Rows[x]["SectionID"].ToString();
                         this.Sections[x].SectionName = ds.Tables[0].Rows[x]["SectionName"].ToString();
                        int tlooms = 0;
                        for (int i = 0; i < Program.ss.Machines.Looms.Length; i++)
                        {
                            if (Program.ss.Machines.Looms[i].PersonalInfo.SectionID.ToString() == this.Sections[x].SectionID)
                                tlooms++;
                        }
                       this.Sections[x].NumberofLooms = tlooms;
                    }
                    ds = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Assigning Weavers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void init_LoomGroups()
        {
            #region Groups
            DataSet dsGroups = new DataSet();

            dsGroups = WS.svc.Get_DataSet("Select * from MT_LoomsGroups  where ShedID=" + ShedID + " order by GroupNumber ");
            if (dsGroups != null)
            {
                Array.Resize(ref LoomGroups, dsGroups.Tables[0].Rows.Count);
                for (int x = 0; x < dsGroups.Tables[0].Rows.Count; x++)
                {
                    LoomGroups[x] = new loomGroup();
                    LoomGroups[x].GroupName = dsGroups.Tables[0].Rows[x]["GroupName"].ToString();
                    LoomGroups[x].GroupNumber = Convert.ToInt32(dsGroups.Tables[0].Rows[x]["GroupNumber"]);
                    LoomGroups[x].x = dsGroups.Tables[0].Rows[x]["x"].ToString() == "" ? 0 : int.Parse(dsGroups.Tables[0].Rows[x]["x"].ToString());
                    LoomGroups[x].y = dsGroups.Tables[0].Rows[x]["y"].ToString() == "" ? 0 : int.Parse(dsGroups.Tables[0].Rows[x]["y"].ToString());
                }
            }
            #endregion

        }
        public void init_TypesofLooms()
        {
            #region Types

            DataSet dsTypes = new DataSet();
            {
                dsTypes = WS.svc.Get_DataSet("Select * from MT_Types where typeid in(select typeid from MT_looms where ShedID="+ShedID+") order by TypeID");
                if (dsTypes != null)
                {
                    Array.Resize(ref TypesOfLooms, dsTypes.Tables[0].Rows.Count);
                    for (int x = 0; x < dsTypes.Tables[0].Rows.Count; x++)
                    {
                        TypesOfLooms[x] = new loomType();
                        TypesOfLooms[x].TypeID = Convert.ToString(dsTypes.Tables[0].Rows[x]["TypeID"]);
                        TypesOfLooms[x].TypeName = Convert.ToString(dsTypes.Tables[0].Rows[x]["TypeName"]);


                    }
                }
            }
            #endregion
        }
        public void init_Colors()
        {
            #region Colors
            DataSet dsEffColors = new DataSet();
            Array.Resize(ref Range_Color, 0);
            dsEffColors = WS.svc.Get_DataSet("Select * from MT_ColorSettings where ShedID="+ShedID+" order by ColorIndex,ColorCauseID");
            if (dsEffColors != null)
            {
                Array.Resize(ref Range_Color, dsEffColors.Tables[0].Rows.Count);
                for (int x = 0; x < dsEffColors.Tables[0].Rows.Count; x++)
                {
                    Range_Color[x] = new range();
                    Range_Color[x].CC = Convert.ToInt32(dsEffColors.Tables[0].Rows[x]["ColorCauseID"]);
                    Range_Color[x].index = Convert.ToInt32(dsEffColors.Tables[0].Rows[x]["ColorIndex"]);
                    Range_Color[x].Minimum = Convert.ToDouble(dsEffColors.Tables[0].Rows[x]["Minimum"]);
                    Range_Color[x].Maximum = Convert.ToDouble(dsEffColors.Tables[0].Rows[x]["Maximum"]);
                    Range_Color[x].FontColor = Convert.ToString(dsEffColors.Tables[0].Rows[x]["FontColor"]);
                }
            }
            #endregion

        }
        public void init_Technicians()
        {
            #region Technicians
            DataSet dsTech = new DataSet();

            dsTech = WS.svc.Get_DataSet("Select employeeid,employeename from PP_Employees where EmployeeID in (select distinct technicianID from MT_Looms where ShedID="+ShedID+")");
            if (dsTech != null)
            {
                Array.Resize(ref Technicians, dsTech.Tables[0].Rows.Count);
                for (int x = 0; x < dsTech.Tables[0].Rows.Count; x++)
                {
                    Technicians[x] = new technician();
                    Technicians[x].TechnicianID = Convert.ToString(dsTech.Tables[0].Rows[x]["EmployeeID"]);
                    Technicians[x].TechnicianName = Convert.ToString(dsTech.Tables[0].Rows[x]["EmployeeName"]);


                }
            }
            #endregion

        }
        #endregion
    }
    public class MergedLoomShed
    {
        public int LayoutIndex;
        public string LayoutName;
        public string ShedID_0;
        public string ShedID_1;
        public string  ShedID_2;
        public string ShedID_3;
        public string ShedID_4;
        public string ShedIds = "";
        #region Variables
        public loomSection[] Sections = new loomSection[0];
        public loomType[] TypesOfLooms = new loomType[0];
        public shedEff ShedEfficiency = new shedEff();
        public longStopped LongStops = new longStopped();
        public shortStopped ShortStops = new shortStopped();
        public technician[] Technicians = new technician[0];
        public range[] Range_Color = new range[0];
        public loomGroup[] LoomGroups = new loomGroup[0];
        public stoppedStats StoppedStats = new stoppedStats();
        #endregion
        #region ReturnIndex
        public int ReturnMax_EffIndex()
        {
            int maxEffindex = 0;
            for (int x = 0; x < Range_Color.Length; x++)
            {
                if (Range_Color[x].index > maxEffindex)
                    maxEffindex = Range_Color[x].index;

            }
            return maxEffindex;
        }
        public int Return_SectionIndex(string SectionID)
        {

            for (int x = 0; x < Sections.Length; x++)
            {
                if (Sections[x].SectionID == SectionID)
                    return x;

            }
            return -1;
        }

        public int ReturnArrayIndex_Types(string TypeID)
        {
            for (int x = 0; x < TypesOfLooms.Length; x++)
            {
                if (TypesOfLooms[x].TypeID == TypeID)
                    return x;
            }
            return 0;
        }
        public int ReturnArrayIndex_LoomGroup(int argGroupNumber)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                if (LoomGroups[x].GroupNumber == argGroupNumber)
                    return x;

            }
            return -1;
        }
        public int ReturnArrayIndex_LoomGroup_ByWeaverID(string WeaverID, string Shift)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                if (Shift == "A")
                {
                    if (LoomGroups[x].Weavers.WeaverID_A == WeaverID)
                        return x;
                }
                else if (Shift == "B")
                {
                    if (LoomGroups[x].Weavers.WeaverID_B == WeaverID)
                        return x;
                }
                else if (Shift == "C")
                {
                    if (LoomGroups[x].Weavers.WeaverID_C == WeaverID)
                        return x;
                }



            }
            return -1;
        }
        public int ReturnArrayIndex_LoomGroup_ByLoomIndex(int argLoomIndex)
        {
            for (int x = 0; x < LoomGroups.Length; x++)
            {
                for (int l = 0; l < LoomGroups[x].LoomIndexes.Length; l++)
                {
                    if (LoomGroups[x].LoomIndexes[l] == argLoomIndex)
                        return x;
                }

            }
            return -1;
        }
        public Color ReturnColor(ColorCauses CC, double Val)
        {
            ColorConverter cr = new ColorConverter();
            for (int x = 0; x < Range_Color.Length; x++)
            {
                if (Val >= Range_Color[x].Minimum && Val <= Range_Color[x].Maximum && Range_Color[x].CC == (int)CC)
                {
                    if (Range_Color[x].FontColor != "")
                        return (Color)cr.ConvertFromString(Range_Color[x].FontColor);
                    else
                        return Color.Black;
                }

            }
            return Color.Black;
        }
        #endregion
        #region Inits
        public void init_Sections()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = WS.svc.Get_DataSet("Select * from MT_LoomSections where SectionID in(select Distinct SectionID from MT_Looms where ShedID in(" + ShedIds + "))");

                if (ds != null)
                {
                    Array.Resize(ref this.Sections, ds.Tables[0].Rows.Count);
                    for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                    {
                        this.Sections[x] = new loomSection();
                        this.Sections[x].SectionID = ds.Tables[0].Rows[x]["SectionID"].ToString();
                        this.Sections[x].SectionName = ds.Tables[0].Rows[x]["SectionName"].ToString();
                        int tlooms = 0;
                        for (int i = 0; i < Program.ss.Machines.Looms.Length; i++)
                        {
                            if (Program.ss.Machines.Looms[i].PersonalInfo.SectionID.ToString() == this.Sections[x].SectionID)
                                tlooms++;
                        }
                        this.Sections[x].NumberofLooms = tlooms;
                    }
                    ds = null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Assigning Weavers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void init_LoomGroups()
        {
            #region Groups
            DataSet dsGroups = new DataSet();

            dsGroups = WS.svc.Get_DataSet("Select * from MT_LoomsGroups  where ShedID in(" + ShedIds + ") order by GroupNumber ");
            if (dsGroups != null)
            {
                Array.Resize(ref LoomGroups, dsGroups.Tables[0].Rows.Count);
                for (int x = 0; x < dsGroups.Tables[0].Rows.Count; x++)
                {
                    LoomGroups[x] = new loomGroup();
                    LoomGroups[x].GroupName = dsGroups.Tables[0].Rows[x]["GroupName"].ToString();
                    LoomGroups[x].GroupNumber = Convert.ToInt32(dsGroups.Tables[0].Rows[x]["GroupNumber"]);
                    LoomGroups[x].x = dsGroups.Tables[0].Rows[x]["x"].ToString() == "" ? 0 : int.Parse(dsGroups.Tables[0].Rows[x]["x"].ToString());
                    LoomGroups[x].y = dsGroups.Tables[0].Rows[x]["y"].ToString() == "" ? 0 : int.Parse(dsGroups.Tables[0].Rows[x]["y"].ToString());
                }
            }
            #endregion

        }
        public void init_TypesofLooms()
        {
            #region Types

            DataSet dsTypes = new DataSet();
            {
                dsTypes = WS.svc.Get_DataSet("Select * from MT_Types where typeid in(select typeid from MT_looms where ShedID in(" + ShedIds + ")) order by TypeID");
                if (dsTypes != null)
                {
                    Array.Resize(ref TypesOfLooms, dsTypes.Tables[0].Rows.Count);
                    for (int x = 0; x < dsTypes.Tables[0].Rows.Count; x++)
                    {
                        TypesOfLooms[x] = new loomType();
                        TypesOfLooms[x].TypeID = Convert.ToString(dsTypes.Tables[0].Rows[x]["TypeID"]);
                        TypesOfLooms[x].TypeName = Convert.ToString(dsTypes.Tables[0].Rows[x]["TypeName"]);


                    }
                }
            }
            #endregion
        }
        public void init_Colors()
        {
            #region Colors
            DataSet dsEffColors = new DataSet();
            Array.Resize(ref Range_Color, 0);
            dsEffColors = WS.svc.Get_DataSet("Select * from MT_ColorSettings where ShedID in(" + ShedIds + ") order by ColorIndex,ColorCauseID");
            if (dsEffColors != null)
            {
                Array.Resize(ref Range_Color, dsEffColors.Tables[0].Rows.Count);
                for (int x = 0; x < dsEffColors.Tables[0].Rows.Count; x++)
                {
                    Range_Color[x] = new range();
                    Range_Color[x].CC = Convert.ToInt32(dsEffColors.Tables[0].Rows[x]["ColorCauseID"]);
                    Range_Color[x].index = Convert.ToInt32(dsEffColors.Tables[0].Rows[x]["ColorIndex"]);
                    Range_Color[x].Minimum = Convert.ToDouble(dsEffColors.Tables[0].Rows[x]["Minimum"]);
                    Range_Color[x].Maximum = Convert.ToDouble(dsEffColors.Tables[0].Rows[x]["Maximum"]);
                    Range_Color[x].FontColor = Convert.ToString(dsEffColors.Tables[0].Rows[x]["FontColor"]);
                }
            }
            #endregion

        }
        public void init_Technicians()
        {
            #region Technicians
            DataSet dsTech = new DataSet();

            dsTech = WS.svc.Get_DataSet("Select employeeid,employeename from PP_Employees where EmployeeID in (select distinct technicianID from MT_Looms where ShedID in(" + ShedIds + "))");
            if (dsTech != null)
            {
                Array.Resize(ref Technicians, dsTech.Tables[0].Rows.Count);
                for (int x = 0; x < dsTech.Tables[0].Rows.Count; x++)
                {
                    Technicians[x] = new technician();
                    Technicians[x].TechnicianID = Convert.ToString(dsTech.Tables[0].Rows[x]["EmployeeID"]);
                    Technicians[x].TechnicianName = Convert.ToString(dsTech.Tables[0].Rows[x]["EmployeeName"]);


                }
            }
            #endregion

        }
        #endregion
    }
}
