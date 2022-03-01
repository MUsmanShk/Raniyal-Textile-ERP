using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Data;
using System.IO;
using DevExpress.XtraEditors;
using System.Security.Cryptography;
namespace MachineEyes.Classes
{
    public class securityGroup
    {
        public string GroupID;
        public string GroupName;
        public string ImageIndex;
    }

    public static class Security
    {
        static private Byte[] m_Key = new Byte[8];
        static private Byte[] m_IV = new Byte[8];
        public static string SessionCode;
        public static string EncPassword;
        public static UserInfo User = new UserInfo();
        public static securityGroup[] SecurityGroups = new securityGroup[0];
        public static void LoadGroups()
        {
            try
            {
                
                DataSet ds = WS.svc.Get_DataSet("Select * from PP_SecurityGroups");
                if (ds == null) return;
                Array.Resize(ref SecurityGroups, ds.Tables[0].Rows.Count);
                for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
                {
                    SecurityGroups[x] = new securityGroup();
                    SecurityGroups[x].GroupID = ds.Tables[0].Rows[x]["SecurityGroupID"].ToString();
                    SecurityGroups[x].GroupName = ds.Tables[0].Rows[x]["SecurityGroupName"].ToString();
                    SecurityGroups[x].ImageIndex = ds.Tables[0].Rows[x]["ImageIndex"].ToString();
                    
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error Load_SecurityGroups", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static string GetGroupID(string iDescription)
        {
            for (int x = 0; x < SecurityGroups.Length; x++)
            {
                if( iDescription.Contains("[" + SecurityGroups[x].GroupName + "]")==true)
                    return SecurityGroups[x].GroupID;
            }
            return "00";
        }
        public static string GetControlID(string iDescription)
        {
            for (int x = 0; x < SecurityGroups.Length; x++)
            {
                if (iDescription.Contains("[" + SecurityGroups[x].GroupName + "]") == true)
                    return SecurityGroups[x].GroupID;
            }
            return "00";
        }
        public static int  GetGroupImageIndex(string GroupID)
        {
            for (int x = 0; x < SecurityGroups.Length; x++)
            {
                if (GroupID == SecurityGroups[x].GroupID)
                {
                    int iindex = -1;
                    Int32.TryParse(SecurityGroups[x].ImageIndex, out iindex);
                    return iindex;
                }
            }
            return -1;
        }
        public static string EncryptData(String strKey, String strData)
        {

            try
            {

                string strResult;		//Return Result

                //1. String Length cannot exceed 90Kb. Otherwise, buffer will overflow. See point 3 for reasons
                if (strData.Length > 92160)
                {
                    strResult = "";
                    return strResult;
                }

                //2. Generate the Keys
                if (!InitKey(strKey))
                {
                    strResult = "";
                    return strResult;
                }

                //3. Prepare the String
                //	The first 5 character of the string is formatted to store the actual length of the data.
                //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
                //	If anyone figure a good way to 'remember' the original length to facilite the decryption without having to use additional function parameters, pls let me know.
                strData = String.Format("{0,5:00000}" + strData, strData.Length);


                //4. Encrypt the Data
                byte[] rbData = new byte[strData.Length];
                ASCIIEncoding aEnc = new ASCIIEncoding();
                aEnc.GetBytes(strData, 0, strData.Length, rbData, 0);

                DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

                ICryptoTransform desEncrypt = descsp.CreateEncryptor(m_Key, m_IV);


                //5. Perpare the streams:
                //	mOut is the output stream. 
                //	mStream is the input stream.
                //	cs is the transformation stream.
                MemoryStream mStream = new MemoryStream(rbData);
                CryptoStream cs = new CryptoStream(mStream, desEncrypt, CryptoStreamMode.Read);
                MemoryStream mOut = new MemoryStream();

                //6. Start performing the encryption
                int bytesRead;
                byte[] output = new byte[1024];
                do
                {
                    bytesRead = cs.Read(output, 0, 1024);
                    if (bytesRead != 0)
                        mOut.Write(output, 0, bytesRead);
                } while (bytesRead > 0);

                //7. Returns the encrypted result after it is base64 encoded
                //	In this case, the actual result is converted to base64 so that it can be transported over the HTTP protocol without deformation.
                if (mOut.Length == 0)
                    strResult = "";
                else
                    strResult = Convert.ToBase64String(mOut.GetBuffer(), 0, (int)mOut.Length);

                return strResult;
            }
            catch
            {
                return "";
            }
            finally
            {

            }
        }
        public static string DecryptData(String strKey, String strData)
        {
            string strResult;

            //1. Generate the Key used for decrypting
            if (!InitKey(strKey))
            {
                strResult = "Error. Fail to generate key for decryption";
                return strResult;
            }

            //2. Initialize the service provider
            int nReturn = 0;
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();
            ICryptoTransform desDecrypt = descsp.CreateDecryptor(m_Key, m_IV);

            //3. Prepare the streams:
            //	mOut is the output stream. 
            //	cs is the transformation stream.
            MemoryStream mOut = new MemoryStream();
            CryptoStream cs = new CryptoStream(mOut, desDecrypt, CryptoStreamMode.Write);

            //4. Remember to revert the base64 encoding into a byte array to restore the original encrypted data stream
            byte[] bPlain = new byte[strData.Length];
            try
            {
                bPlain = Convert.FromBase64CharArray(strData.ToCharArray(), 0, strData.Length);
            }
            catch (Exception)
            {
                strResult = "Error. Input Data is not base64 encoded.";
                return strResult;
            }

            long lRead = 0;
            long lTotal = strData.Length;

            try
            {
                //5. Perform the actual decryption
                while (lTotal >= lRead)
                {
                    cs.Write(bPlain, 0, (int)bPlain.Length);
                    //descsp.BlockSize=64
                    lRead = mOut.Length + Convert.ToUInt32(((bPlain.Length / descsp.BlockSize) * descsp.BlockSize));
                };

                ASCIIEncoding aEnc = new ASCIIEncoding();
                strResult = aEnc.GetString(mOut.GetBuffer(), 0, (int)mOut.Length);

                //6. Trim the string to return only the meaningful data
                //	Remember that in the encrypt function, the first 5 character holds the length of the actual data
                //	This is the simplest way to remember to original length of the data, without resorting to complicated computations.
                String strLen = strResult.Substring(0, 5);
                
                int nLen;
                int.TryParse(strLen, out nLen);
                strResult = strResult.Substring(5, nLen);
                nReturn = (int)mOut.Length;

                return strResult;
            }
            catch (Exception)
            {
                strResult = "Error. Decryption Failed. Possibly due to incorrect Key or corrputed data";
                return strResult;
            }
        }
        static private bool InitKey(String strKey)
        {
            try
            {
                // Convert Key to byte array
                byte[] bp = new byte[strKey.Length];
                ASCIIEncoding aEnc = new ASCIIEncoding();
                aEnc.GetBytes(strKey, 0, strKey.Length, bp, 0);

                //Hash the key using SHA1
                SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
                byte[] bpHash = sha.ComputeHash(bp);

                int i;
                // use the low 64-bits for the key value
                for (i = 0; i < 8; i++)
                    m_Key[i] = bpHash[i];

                for (i = 8; i < 16; i++)
                    m_IV[i - 8] = bpHash[i];

                return true;
            }
            catch (Exception)
            {
                //Error Performing Operations
                return false;
            }
        }
        public static void ImplementSecurity()
        {
            try
            {
            if (User.UserID == "1")
            {
                foreach (object c in Program.MainWindow.ribbonControl1.Items)
                {

                      if (c.GetType().Name == "BarButtonItem")
              
                    {
                        DevExpress.XtraBars.BarButtonItem bbi = (DevExpress.XtraBars.BarButtonItem)c;

                        bbi.Enabled = true;
                    }

                }
                return;
            }
            DataSet ds = WS.svc.Get_DataSet("select * from PP_SecurityRights where UserID='" +MachineEyes.Classes.Security.User.UserID + "'");
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;
            for (int x = 0; x < ds.Tables[0].Rows.Count; x++)
            {
                foreach (object c in Program.MainWindow.ribbonControl1.Items)
                {
                    string s = c.GetType().Name;
                    if (c.GetType().Name == "BarButtonItem")
                    {

                       DevExpress.XtraBars.BarButtonItem bbi = (DevExpress.XtraBars.BarButtonItem)c;

                       if (bbi.Name == ds.Tables[0].Rows[x]["iUniqueName"].ToString())
                       {
                           if (User.UserID == "1")
                               bbi.Enabled = true;
                           else
                           bbi.Enabled = ds.Tables[0].Rows[x]["Permission"].ToString() == "1" ? true : false;
                       }

                    }

                }
               
            }
            }catch(Exception  ex)
                {
                    XtraMessageBox.Show(ex.Message, "Security Module Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

        }
      
	
		 
	}
    
}
