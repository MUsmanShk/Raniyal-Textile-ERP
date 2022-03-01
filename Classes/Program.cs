using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Data;
using DevExpress.XtraEditors;

namespace MachineEyes {
    public enum enVoucherType { CashPaymentVoucher = 0, CashReceiptVoucher = 1, BankPaymentVoucher = 2, BankReceiptVoucher = 3, GeneralVoucher = 4, StorePurchases=5 }
    public enum TimeFormats : int { dh = 0, HHMMSS = 3,AutoHHMMSS=1,DaysHoursMinutes=4,MMSS=5,HHMM=6 }
    public enum AlertTokens : int { SystemAlert=0,StoreRequisitionRaised = 1, StoreRequisitionApproved = 2, StoreRequisitionRejected = 3,StoreRequisitionPurchaseOrderRaised=4,StoreRequisitionDiscuss=5}
    public enum ClassicalViewType : int { EfficiencyView = 0, RPMView = 1, WarpCounterView = 2, WeftCounterView = 3, WarpKnottView = 4, WeftKnottView = 5 };
    public enum LoginStatus : int { Normal = 1, Failed = 2, Denied = 3 };
    public enum State : int { Stopped = 0, Running = 1, Unknown = 2, PowerOff = 3 }
    public enum docState : int {NotDefined=-1, Open = 0, Closed = 1, Authorized = 2, Cancelled = 3 }
    public enum viewMode : int { Zoom = 0, Move = 1, Resize = 2 }
    public enum Cause : int { Unknown = 0, Warp = 1, Weft = 2, Leno = 3, Other = 4, Pile = 5, Mechanical = 6, Electrical = 7, Knotting = 8, ArticleChange = 9, OtherLong = 10, PowerOff = 11, LongStop_5 = 12, LongStop_6 = 13, LongStop_7 = 14, LongStop_8 = 15, LongStop_9 = 16, RunningbutNoRPM = 17, DNI = 18, FDNI = 19, Running = 255 }
    public enum TermsType : int { Payment = 1, Delivery = 2, General = 3 }
    public enum PermissionState : int { Permitted = 23, NotPermitted = 24 }
    public enum BeamStatus : int {BeamNotFound=-1, Empty_AvailableForSizing = 0, Sized_AvailableForLoom = 1, Sized_OnLoom = 2, Sized_AvailableForReKnotting = 3 }
    public enum ParameterStatus:int{Cancelled=0,Added=1,Edited=2,Deleted=3,Error=4,Selected=5}
    public enum ColorCauses : int { EfficiencyColors = 1, RPMColors = 2, WeaversEfficiency = 3, AvgWarpKnotTime = 4, AvgWeftKnotTime = 5 }
    public enum SelectionMode : int { NoSelection = 0, EfficiencyFont = 1 ,MoveMachine=2}
    public enum YarnSelectionMode : int { WarpYarn = 0, WeftYarn = 1, PileYarn = 2, Fancy = 3 }
    public enum RollCodes : int { RP = 0, FP = 1, LP = 2 }
    public enum RollStatus : int { Folding = 0, Godown = 1 }
    public enum EfficiencyType:int{ShedEfficiency=0,ProductionEfficiency=1,TimeEfficiency=2,TimeProductionEfficiency=3}
    public class cCounts
    {
        public string Count;
        public double EnglishCount;
    }
    public  class frow
    {
        public int LoomNumber;
        public int RPM;
        public double Efficiency;
    }
    public static class Counters
    {
        public const int initCounter_Loom = 100, endCounter_Loom = 255, initCounter_Ping = 50, endCounter_Ping = 59, initCounter_Send = 60, endCounter_Send = 69, initCounter_Received = 70, endCounter_Received = 79, RFID_AskVerify = 19, RFID_NumberisUnknown = 20, RFID_NumberisBeam = 21, RFID_NumberisLoom = 22, RFID_NumberisOperator = 23;
        public const int RFID_ConfirmedByDevice_Unknown = 28, RFID_ConfirmedByDevice_Beam = 29, RFID_ConfirmedByDevice_Loom = 30, RFID_ConfirmedByDevice_Operator = 31;
        public const int MSG_RFID_LOG_IN_SUCCESS = 32, MSG_RFID_LOG_OUT_SUCCESS = 33, MSG_RFID_LOG_IN_DEVICECONFIRMED = 36, MSG_RFID_LOG_OUT_DEVICECONFIRMED = 37;


    }
    public class Employee
    {
        public string EmployeeID;
        public string EmployeeName;
    }
    public class ParameterReturn
    {
        public ParameterStatus Status;
        public string ParameterValue;

        
    }
    public class StopCause
    {
        public Cause sCause;
        public Color backColor;
        public Color foreColor;
        public Color borderColor;
        public string CauseName;
        public string CauseGeneric;
        //public Image image;

    }
    public static class Departments
    {
        public static string Towel_Godown;
        public static string Towel_Folding;
        public static string Weaving;
        public static string Sizing;
        public static string YarnGodown;
        public static string InOutDeptID_Sizing;
        public static string InOutDeptID_Weaving;
    }
    public static class Settings
    {
        public static ClassicalViewType CurrentClassicalView = new ClassicalViewType();
        public static EfficiencyType efficiencyType = new EfficiencyType();
        public static bool Store_BoundIssueNoteWithApproval = false;
        public static bool Store_BoundPurcahseOrderWithApproval = false;
        public static bool Store_RestrictIssueNoteAtStock = false;
        public static TimeSpan TimeZone_Add;
        public static TimeSpan TimeZone_Subtract;
        public static int InvoiceStartIndex;
        public static int InvoiceLength;
        public static bool BoundInvoiceWithPO;
        public static string ServiceIP;
        public static string AlertSound;
        public static string ServiceDir;
        public static int RefreshTime;
        public static string AppPath;
        public static bool AutoLogin;
        public static int DefaultShed;
        public static bool LoadFromCache = false;
        public static int DataWaitingSeconds;
        public static double KgToLbs = 2.20462262;
        public static bool Exit;
        public static MachineService.currentSettings CurrentSettings;
        public static string[] ServiceIPS = new string[0];
        public static string DepartmentID_YarnGodown;
        public static bool FillYarnInfoFromPO = false;
        public static string WeaversDesignationID;
        public static StopCause[] stopCauses = new StopCause[0];
        public static void Load_GetSet()
        {
            //DataSet ds = WS.svc.Get_DataSet("Select * from MT_GetSet");
            //if (ds == null) return;
            //for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            //{
            //    if (ds.Tables[0].Rows[x]["GetValue"].ToString() == "TARGETEFF")
            //    {
            //        TargetEfficiency = Convert.ToDouble(ds.Tables[0].Rows[x]["SetValue"].ToString());
            //    }
            //}
        }
        public static void Load_StopCauses()
        {
            try
            {
                DataSet ds = WS.svc.Get_DataSet("Select * from MT_Cause order by Cause");
                ColorConverter cc = new ColorConverter();
                if (ds == null) return;
                Array.Resize(ref stopCauses, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    stopCauses[x] = new StopCause();
                    stopCauses[x].sCause = (Cause)Convert.ToInt32(ds.Tables[0].Rows[x]["Cause"].ToString());
                    byte[] bimage = new byte[0];
                    if(ds.Tables[0].Rows[x]["image"].ToString()!="")
                    bimage = (byte[])ds.Tables[0].Rows[x]["image"];
                    if (bimage != null)
                        //if(bimage.Length>0)
                        //stopCauses[x].image = Program.byteArrayToImage(bimage);
                    stopCauses[x].CauseName = ds.Tables[0].Rows[x]["CauseName"].ToString();
                    stopCauses[x].CauseGeneric = ds.Tables[0].Rows[x]["CauseGeneric"].ToString();
                    if (ds.Tables[0].Rows[x]["foreColor"].ToString() != "")
                        stopCauses[x].foreColor = (Color)cc.ConvertFromString(ds.Tables[0].Rows[x]["foreColor"].ToString());
                    if (ds.Tables[0].Rows[x]["backColor"].ToString() != "")
                        stopCauses[x].backColor = (Color)cc.ConvertFromString(ds.Tables[0].Rows[x]["backColor"].ToString());
                    if (ds.Tables[0].Rows[x]["borderColor"].ToString() != "")
                        stopCauses[x].borderColor = (Color)cc.ConvertFromString(ds.Tables[0].Rows[x]["borderColor"].ToString());

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error:Load_StopCauses", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static int ReturnCauseIndex(string GenericName)
        {
            for (int x = 0; x < stopCauses.Length; x++)
            {
                if (stopCauses[x].CauseGeneric == GenericName)
                    return x;
            }
            return 0;
        }
        public static Color Get_StopCauseColor_foreColor(Cause machineCause)
        {
            if (machineCause == Cause.Running)
                return Color.White;
            for (int x = 0; x < stopCauses.Length; x++)
            {
                if (stopCauses[x].sCause == machineCause)
                {
                    return stopCauses[x].foreColor;
                }
            }
            return Color.White;

        }
        public static Color Get_StopCauseColor_backColor(Cause machineCause)
        {
           
            for (int x = 0; x < stopCauses.Length; x++)
            {
                if (stopCauses[x].sCause == machineCause)
                {
                    return stopCauses[x].backColor;
                }
            }
            return Color.Black;

        }
        public static Color Get_StopCauseColor_borderColor(Cause machineCause)
        {
            if (machineCause == Cause.Running)
                return Color.FromArgb(20, 20, 20);
            for (int x = 0; x < stopCauses.Length; x++)
            {
                if (stopCauses[x].sCause == machineCause)
                {
                    return stopCauses[x].borderColor;
                }
            }
            return Color.White;

        }
        static Settings()
        {
            AppPath = Path.GetDirectoryName(Application.ExecutablePath);
            CurrentSettings = new MachineService.currentSettings();
          
        }
        public static string FormatSeconds(double seconds)
        {
            if (Double.IsNaN(seconds) == true)
                seconds = 0;
            if (Double.IsInfinity(seconds) == true) seconds = 0;
            TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
            string s = "";
            if (ts.Days > 0)

                s = ts.Days.ToString("#,##") + " ds ";
            if (ts.Hours > 0 && ts.Days <= 0)
                s += ts.Hours.ToString("#,##") + " hr ";
            if (ts.Hours > 0 && ts.Days <= 0)
                s = ts.TotalHours.ToString("#,##0.00") + " hr";
            if (ts.Minutes > 0 && ts.Hours <= 0)
                s += ts.Minutes.ToString("#,##") + " mt ";
            if (ts.Seconds > 0 && ts.Days <= 0 && ts.Hours <= 0)
                s += ts.Seconds.ToString("#,##") + " sc ";
            return s;
        }

    }

    static class Program {
        public static Service ss = new Service();
        public static frmMain MainWindow;
        [STAThread]
        static void Main() {

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow = new frmMain();
            Application.Run(MainWindow);
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
            return returnImage;
        }
    }
}
