using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Reflection;
using System.IO;

using EventByDeploy.Language;

namespace EventByDeploy
{
    public partial class EventByDeploy : Form
    {
        public static int m_UserID = -1;
        private int lFortifyHandle = -1;
        private CHCNetSDK.MSGCallBack m_falarmData = null;
        private int m_lLogNum = 0;
        private string path = null;
        private string ShowData = null;

        public EventByDeploy()
        {
            InitializeComponent();
            if (CHCNetSDK.NET_DVR_Init() == false)
            {
                MessageBox.Show("NET_DVR_Init error!");
                return;
            }
            comboBoxLanguage.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AddDevice dlg = new AddDevice();
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            if (m_UserID < 0)
            {
                MessageBox.Show("Please Login First!");
                return;
            }
            else 
            {
                CHCNetSDK.NET_DVR_SETUPALARM_PARAM struSetupAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
                struSetupAlarmParam.dwSize = (uint)Marshal.SizeOf(struSetupAlarmParam);
                struSetupAlarmParam.byLevel = 1;
                struSetupAlarmParam.byAlarmInfoType = 1;
                struSetupAlarmParam.byDeployType = (byte)cbDeployType.SelectedIndex;

                if (CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_UserID, ref struSetupAlarmParam) < 0)
                {
                    MessageBox.Show("NET_DVR_SetupAlarmChan_V41 fail error: " + CHCNetSDK.NET_DVR_GetLastError(), "Setup alarm chan failed");
                    return;
                }
                else
                {
                    MessageBox.Show("Setup alarm chan succeed");
                }

                m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
                if (CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V50(0, m_falarmData, IntPtr.Zero))
                {
                    MessageBox.Show("NET_DVR_SetDVRMessageCallBack_V50 succ", "succ", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("NET_DVR_SetDVRMessageCallBack_V50 fail", "operation fail", MessageBoxButtons.OK);
                }
            }
        }

        private void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            switch (lCommand)
            {
                case CHCNetSDK.COMM_ALARM_ACS:
                    ProcessCommAlarmACS(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                    break;
                default:
                    break;
            }
        }

        private void ProcessCommAlarmACS(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
        {
            CHCNetSDK.NET_DVR_ACS_ALARM_INFO struAcsAlarmInfo = new CHCNetSDK.NET_DVR_ACS_ALARM_INFO();
            struAcsAlarmInfo = (CHCNetSDK.NET_DVR_ACS_ALARM_INFO)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ACS_ALARM_INFO));
            CHCNetSDK.NET_DVR_LOG_V30 struFileInfo = new CHCNetSDK.NET_DVR_LOG_V30();
            struFileInfo.dwMajorType = struAcsAlarmInfo.dwMajor;
            struFileInfo.dwMinorType = struAcsAlarmInfo.dwMinor;
            char[] csTmp = new char[256];

            if (CHCNetSDK.MAJOR_ALARM == struFileInfo.dwMajorType)
            {
                TypeMap.AlarmMinorTypeMap(struFileInfo, csTmp);
            }
            else if (CHCNetSDK.MAJOR_OPERATION == struFileInfo.dwMajorType)
            {
                TypeMap.OperationMinorTypeMap(struFileInfo, csTmp);
            }
            else if (CHCNetSDK.MAJOR_EXCEPTION == struFileInfo.dwMajorType)
            {
                TypeMap.ExceptionMinorTypeMap(struFileInfo, csTmp);
            }
            else if (CHCNetSDK.MAJOR_EVENT == struFileInfo.dwMajorType)
            {
                TypeMap.EventMinorTypeMap(struFileInfo, csTmp);
            }

            String szInfo = new String(csTmp).TrimEnd('\0');
            String szInfoBuf = null;
            szInfoBuf = szInfo;
            /**************************************************/
            String name = System.Text.Encoding.UTF8.GetString(struAcsAlarmInfo.sNetUser).TrimEnd('\0');
            for (int i = 0; i < struAcsAlarmInfo.sNetUser.Length; i++)
            {
                if (struAcsAlarmInfo.sNetUser[i] == 0)
                {
                    name = name.Substring(0, i);
                    break;
                }
            }
            /**************************************************/

            szInfoBuf = string.Format("{0} time:{1,4}-{2:D2}-{3} {4:D2}:{5:D2}:{6:D2}, [{7}]({8})", szInfo, struAcsAlarmInfo.struTime.dwYear, struAcsAlarmInfo.struTime.dwMonth,
                struAcsAlarmInfo.struTime.dwDay, struAcsAlarmInfo.struTime.dwHour, struAcsAlarmInfo.struTime.dwMinute, struAcsAlarmInfo.struTime.dwSecond,
                struAcsAlarmInfo.struRemoteHostAddr.sIpV4, name);

            if (struAcsAlarmInfo.struAcsEventInfo.byCardNo[0] != 0)
            {
                szInfoBuf = szInfoBuf + "+Card Number:" + System.Text.Encoding.UTF8.GetString(struAcsAlarmInfo.struAcsEventInfo.byCardNo).TrimEnd('\0');
            }
            String[] szCardType = { "normal card", "disabled card", "blacklist card", "night watch card", "stress card", "super card", "guest card" };
            byte byCardType = struAcsAlarmInfo.struAcsEventInfo.byCardType;

            if (byCardType != 0 && byCardType <= szCardType.Length)
            {
                szInfoBuf = szInfoBuf + "+Card Type:" + szCardType[byCardType - 1];
            }

            if (struAcsAlarmInfo.struAcsEventInfo.dwCardReaderNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Card Reader Number:" + struAcsAlarmInfo.struAcsEventInfo.dwCardReaderNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwDoorNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Door Number:" + struAcsAlarmInfo.struAcsEventInfo.dwDoorNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwVerifyNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Multiple Card Authentication Serial Number:" + struAcsAlarmInfo.struAcsEventInfo.dwVerifyNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwAlarmInNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Alarm Input Number:" + struAcsAlarmInfo.struAcsEventInfo.dwAlarmInNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwAlarmOutNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Alarm Output Number:" + struAcsAlarmInfo.struAcsEventInfo.dwAlarmOutNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwCaseSensorNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Event Trigger Number:" + struAcsAlarmInfo.struAcsEventInfo.dwCaseSensorNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwRs485No != 0)
            {
                szInfoBuf = szInfoBuf + "+RS485 Channel Number:" + struAcsAlarmInfo.struAcsEventInfo.dwRs485No;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwMultiCardGroupNo != 0)
            {
                szInfoBuf = szInfoBuf + "+Multi Recombinant Authentication ID:" + struAcsAlarmInfo.struAcsEventInfo.dwMultiCardGroupNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.byCardReaderKind != 0)
            {
                szInfoBuf = szInfoBuf + "+CardReaderKind:" + struAcsAlarmInfo.struAcsEventInfo.byCardReaderKind.ToString();
            }
            if (struAcsAlarmInfo.struAcsEventInfo.wAccessChannel >= 0)
            {
                szInfoBuf = szInfoBuf + "+wAccessChannel:" + struAcsAlarmInfo.struAcsEventInfo.wAccessChannel;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.dwEmployeeNo != 0)
            {
                szInfoBuf = szInfoBuf + "+EmployeeNo:" + struAcsAlarmInfo.struAcsEventInfo.dwEmployeeNo;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.byDeviceNo != 0)
            {
                szInfoBuf = szInfoBuf + "+byDeviceNo:" +  struAcsAlarmInfo.struAcsEventInfo.byDeviceNo.ToString();
            }
            if (struAcsAlarmInfo.struAcsEventInfo.wLocalControllerID >= 0)
            {
                szInfoBuf = szInfoBuf + "+wLocalControllerID:" + struAcsAlarmInfo.struAcsEventInfo.wLocalControllerID;
            }
            if (struAcsAlarmInfo.struAcsEventInfo.byInternetAccess >= 0)
            {
                szInfoBuf = szInfoBuf + "+byInternetAccess:" + struAcsAlarmInfo.struAcsEventInfo.byInternetAccess.ToString();
            }
            if (struAcsAlarmInfo.struAcsEventInfo.byType >= 0)
            {
                szInfoBuf = szInfoBuf + "+byType:" + struAcsAlarmInfo.struAcsEventInfo.byType.ToString();
            }
            if (struAcsAlarmInfo.struAcsEventInfo.bySwipeCardType != 0)
            {
                szInfoBuf = szInfoBuf + "+bySwipeCardType:" + struAcsAlarmInfo.struAcsEventInfo.bySwipeCardType.ToString();
            }
            //其它消息先不罗列了......

            if (struAcsAlarmInfo.dwPicDataLen > 0)
            {
                path = null;
                Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                path = string.Format(@"C:/Picture/ACS_LocalTime{0}_{1}.bmp", szInfo, rand.Next());
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    int iLen = (int)struAcsAlarmInfo.dwPicDataLen;
                    byte[] by = new byte[iLen];
                    Marshal.Copy(struAcsAlarmInfo.pPicData, by, 0, iLen);
                    fs.Write(by, 0, iLen);
                    fs.Close();
                }
                szInfoBuf = szInfoBuf + "SavePath:" + path;
            }

            this.listViewAlarmInfo.BeginInvoke(new Action(() =>
            {
                ListViewItem Item = new ListViewItem();
                Item.Text = (++m_lLogNum).ToString();
                Item.SubItems.Add(DateTime.Now.ToString());
                Item.SubItems.Add(szInfoBuf);
                this.listViewAlarmInfo.Items.Add(Item);
            }));
        }

        private void listViewAlarmInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAlarmInfo.SelectedItems.Count > 0)
            {
                ShowData = null;
                ShowData = this.listViewAlarmInfo.FocusedItem.SubItems[2].Text.ToString();
                if (ShowData != null)
                {
                    if (ShowData.Contains("C:/Picture/ACS_LocalTime"))
                    {
                        ShowPic();
                        ShowOtherData();
                    }
                    else
                    {
                        if (pictureBoxPic.Image != null)
                        {
                            pictureBoxPic.Image.Dispose();
                            pictureBoxPic.Image = null;
                        }
                        ShowOtherData();
                    }
                }
            }
        }

        private void ShowPic()
        {
            if (pictureBoxPic.Image != null)
            {
                pictureBoxPic.Image.Dispose();
                pictureBoxPic.Image = null;
            }
            string ShowPic = ShowData.Substring(ShowData.LastIndexOf("SavePath:") + "SavePath:".Length); //截取字符串ShowData中SavePath:右边的部分
            try
            {
                pictureBoxPic.Image = Image.FromFile(ShowPic);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Fail to Get Picture", MessageBoxButtons.OK);
            }
        }

        private void ShowOtherData()
        {
            if (!ShowData.Contains("EmployeeNo:"))
            {
                textBoxEmployeeNo.Text = null;
            }
            else
            {
                textBoxEmployeeNo.Text = MidStrEx(ShowData, "EmployeeNo:", "+");
            }

            if (!ShowData.Contains("Card Number:"))
            {
                textBoxCardNo.Text = null;
            }
            else
            {
                textBoxCardNo.Text = MidStrEx(ShowData, "Card Number:", "+");
            }

            if (!ShowData.Contains("time:"))
            {
                textBoxTime.Text = null;
            }
            else
            {
                textBoxTime.Text = MidStrEx(ShowData, "time:", ",");
            }
        }

        //本函数用于截取字符串
        public string MidStrEx(string sourse, string startstr, string endstr)
        {
            string result = string.Empty;
            int startindex, endindex;
            try
            {
                startindex = sourse.IndexOf(startstr);
                if (startindex == -1)
                    return result;
                string tmpstr = sourse.Substring(startindex + startstr.Length);
                endindex = tmpstr.IndexOf(endstr);
                if (endindex == -1)
                    return result;
                result = tmpstr.Remove(endindex);
            }
            catch (Exception e)
            {
                MessageBox.Show("MidStrEx Err:" + e.Message);
            }
            return result;
        }

        private void listViewAlarmInfo_DoubleClick(object sender, EventArgs e)
        {
            if (listViewAlarmInfo.SelectedItems.Count > 0)
            {
                MessageBox.Show(this.listViewAlarmInfo.FocusedItem.SubItems[2].Text.ToString(), "Alarm Info");
            }
        }

        private void EventByDeploy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_UserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout_V30(m_UserID);
                m_UserID = -1;
            }
            CHCNetSDK.NET_DVR_Cleanup();
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLanguage.Text != null)
            {
                MultiLanguage.SetDefaultLanguage(comboBoxLanguage.Text);
                foreach (Form form in Application.OpenForms)
                {
                    MultiLanguage.LoadLanguage(form);
                }


                if (comboBoxLanguage.Text == "English")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                }
                else if (comboBoxLanguage.Text == "Chinese")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
                }
            }
        }

    }
}
