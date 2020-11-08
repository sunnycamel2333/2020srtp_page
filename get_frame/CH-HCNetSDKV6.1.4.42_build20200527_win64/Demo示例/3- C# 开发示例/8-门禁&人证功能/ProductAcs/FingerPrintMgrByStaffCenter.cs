using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AcsDemo.Language;
using System.Text.RegularExpressions;

namespace AcsDemo.ProductAcs
{
    public partial class FingerPrintMgrByStaffCenter : Form
    {
        //协议参考《门禁基线V2.1&低端经销型指纹门禁机与考勤机项目SDK概要设计说明书.docx》
        //调试设备门禁主机DS-K2604
        public Int32 m_lUserID = -1;
        public Int32 m_lFingerPrintDownloadHandle = -1; //指纹参数下发/设置长连接句柄
        public int m_iFingerPrintNum = 0; //表格中一共多少行
        public int m_iFingerPrintIndex = 0; //准备发这行的数据
        public Int32 m_lFingerPrintUploadHandle = -1; //指纹参数获取长连接句柄
        public int m_iFingerPrintCondNum = 0; //表格中一共多少行
        public int m_iFingerPrintCondIndex = 0; //准备发这行的数据
        public int searchID = 0;

        private delegate void AddListCallBack(ListView cListView, ListViewItem cListViewItem);
        private CHCNetSDK.RemoteConfigCallback g_fFingerPrintDownloadCallback = null;
        private CHCNetSDK.RemoteConfigCallback g_fFingerPrintUploadCallback = null;
        private CHCNetSDK.RemoteConfigCallback g_fFingerPrintSetUpCallback = null;

        private CFingerPrintInfoCfg JsonFingerPrintInfo;
        private CFingerPrintCondCfg JsonFingerPrintCond;
        private CFingerPrintStatusCfg JsonFingerPrintStatus;

        public class CFingerPrintCfgCfg
        {
            public CFingerPrintCfg FingerPrintCfg { get; set; }
        }

        public class CFingerPrintCfg
        {
            public string employeeNo { get; set; }
            public int[] enableCardReader { get; set; }
            [DefaultValue(0)]
            public int fingerPrintID { get; set; }
            [DefaultValue(false)]
            public bool deleteFingerPrint { get; set; }
            public string fingerType { get; set; }
            [DefaultValue(null)]
            public string fingerData { get; set; }
            [DefaultValue(null)]
            public int[] leaderFP { get; set; }
            [DefaultValue(null)]
            public bool checkEmployeeNo { get; set; }
        }

        public class CResponseStatus
        {
            public string requestURL { get; set; }
            public int statusCode { get; set; }
            public string statusString { get; set; }
            public string subStatusCode { get; set; }
            public int errorCode { get; set; }
            public string errorMsg { get; set; }
        }

        public class CFingerPrintCondCfg
        {
            public CFingerPrintCond FingerPrintCond { get; set; }
        }

        public class CFingerPrintCond
        {
            public string searchID { get; set; }
            public string employeeNo { get; set; }
            [DefaultValue(0)]
            public int cardReaderNo { get; set; }
            [DefaultValue(0)]
            public int fingerPrintID { get; set; }
        }

        public class CFingerPrintInfoCfg
        {
            public CFingerPrintInfo FingerPrintInfo { get; set; }
        }

        public class CFingerPrintInfo
        {
            public string searchID { get; set; }
            public string status { get; set; }
            public List<CFingerPrintList> FingerPrintList { get; set; }
        }

        public class CFingerPrintList
        {
            public int cardReaderNo { get; set; }
            public int fingerPrintID { get; set; }
            public string fingerType { get; set; }
            public string fingerData { get; set; }
            public int[] leaderFP { get; set; }
        }

        public class CFingerPrintStatusCfg
        {
            public CFingerPrintStatus FingerPrintStatus { get; set; }
        }

        public class CFingerPrintStatus
        {
            public string status { get; set; }
            public List<CStatusList> StatusList { get; set; }
            public int totalStatus { get; set; }
        }

        public class CStatusList
        {
            public int id { get; set; }
            public int cardReaderRecvStatus { get; set; }
            public string errorMsg { get; set; }
        }

        public FingerPrintMgrByStaffCenter()
        {
            InitializeComponent();
            CreateCheckListBox();
            comboBoxFingerPrintID.SelectedIndex = 0;
            comboBoxFingerType.SelectedIndex = 0;
            checkBoxEmployeeNo.Checked = true;
        }

        //创造两个checkListBox
        private void CreateCheckListBox()
        {
            string strTemp = null;
            for (int i = 0; i < 512; i++)
            {
                strTemp = string.Format("CardReader {0}", i + 1);
                checkedListBoxReaderValid.Items.Add(strTemp);
            }
            for (int i = 0; i < 256; i++)
            {
                strTemp = string.Format("DoorNo {0}", i + 1);
                checkedListBoxLeaderFP.Items.Add(strTemp);
            }
        }

        //记录操作
        private void AddList(ListView cListView, ListViewItem cListViewItem)
        {
            if (this.InvokeRequired)
            {
                AddListCallBack add = new AddListCallBack(AddList);
                this.Invoke(add, new object[] { cListView, cListViewItem });
            }
            else
            {
                cListView.Items.Insert(0, cListViewItem);
            }
        }

        //打开一个OpenFileDialog，选择文件路径
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//should be attention to the path is "c:\\" not "c:\"
            openFileDialog.Filter = "Fingerprint file|*.dat|All documents|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxFingerDataPath.Text = openFileDialog.FileName;
            }
        }

        //向listViewFingerPrint（上面那个最大的表）中添加数据
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxEmployeeNo.Text == "")
            {
                return;
            }
            ListViewItem listItem = new ListViewItem();
            int iItemCount = listViewFingerPrint.Items.Count;
            listItem.Text = (iItemCount + 1).ToString();
            listItem.SubItems.Add(textBoxEmployeeNo.Text.ToString());
            string sReader = null;
            for (int i = 0; i < 512; i++)
            {
                if (checkedListBoxReaderValid.GetItemChecked(i))
                {
                    sReader += (i + 1 + ",");
                }
            }
            if (sReader != null)
            {
                sReader = sReader.TrimEnd(',');
            }
            listItem.SubItems.Add(sReader);
            listItem.SubItems.Add(comboBoxFingerPrintID.Text.ToString());
            listItem.SubItems.Add(comboBoxFingerType.Text.ToString());
            listItem.SubItems.Add(textBoxFingerDataPath.Text.ToString());
            string sLeaderFp = null;
            for (int i = 0; i < 256; i++)
            {
                if (checkedListBoxLeaderFP.GetItemChecked(i))
                {
                    sLeaderFp += (i + 1 + ",");
                }
            }
            if (sLeaderFp != null)
            {
                sLeaderFp = sLeaderFp.TrimEnd(',');
            }
            listItem.SubItems.Add(sLeaderFp);
            if (checkBoxEmployeeNo.Checked)
            {
                listItem.SubItems.Add("true");
            }
            else
            {
                listItem.SubItems.Add("false");
            }
            if(checkBoxDeleteFp.Checked)
            {
                listItem.SubItems.Add("true");
            }
            else
            {
                listItem.SubItems.Add("");
            }
            this.listViewFingerPrint.Items.Add(listItem);
        }

        //选中listViewFingerPrint的某行，下面的多个框显示本行的数据
        private void listViewFingerPrint_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewFingerPrint.SelectedItems.Count > 0)
            {
                if (e.Item.SubItems[5].Text == "NoFP")
                {
                    return;
                }
                textBoxEmployeeNo.Text = e.Item.SubItems[1].Text;
                string senableCardReader = e.Item.SubItems[2].Text.ToString();
                string[] sArrayR = Regex.Split(senableCardReader, ",", RegexOptions.IgnoreCase);
                for (int i = 0; i < checkedListBoxReaderValid.Items.Count; i++)
                {
                    checkedListBoxReaderValid.SetItemChecked(i, false);
                }
                for (int i = 0; i < sArrayR.Length; i++)
                {
                    if (sArrayR[0] == "")
                    {
                        break;
                    }
                    checkedListBoxReaderValid.SetItemChecked(Convert.ToInt32(sArrayR[i]) - 1, true);
                }
                if (e.Item.SubItems[3].Text != "")
                {
                    comboBoxFingerPrintID.SelectedIndex = Convert.ToInt32(e.Item.SubItems[3].Text) - 1;
                }
                else
                {
                    comboBoxFingerPrintID.SelectedIndex = 10;//10代表空
                }

                if (e.Item.SubItems[4].Text == "normalFP")
                {
                    comboBoxFingerType.SelectedIndex = 0;
                }
                else if (e.Item.SubItems[4].Text == "hijackFP")
                {
                    comboBoxFingerType.SelectedIndex = 1;
                }
                else if (e.Item.SubItems[4].Text == "patrolFP")
                {
                    comboBoxFingerType.SelectedIndex = 2;
                }
                else if (e.Item.SubItems[4].Text == "superFP")
                {
                    comboBoxFingerType.SelectedIndex = 3;
                }
                else if (e.Item.SubItems[4].Text == "dismissingFP")
                {
                    comboBoxFingerType.SelectedIndex = 4;
                }
                else
                {
                    comboBoxFingerType.SelectedIndex = 0;
                }
                textBoxFingerDataPath.Text = e.Item.SubItems[5].Text;
                string sleaderFP = e.Item.SubItems[6].Text.ToString();
                string[] sArrayD = Regex.Split(sleaderFP, ",", RegexOptions.IgnoreCase);
                for (int i = 0; i < checkedListBoxLeaderFP.Items.Count; i++)
                {
                    checkedListBoxLeaderFP.SetItemChecked(i, false);
                }
                for (int i = 0; i < sArrayD.Length; i++)
                {
                    if (sArrayD[0] == "")
                    {
                        break;
                    }
                    checkedListBoxLeaderFP.SetItemChecked(Convert.ToInt32(sArrayD[i]) - 1, true);
                }
                if (e.Item.SubItems[7].Text.ToString() == "true")
                {
                    checkBoxEmployeeNo.Checked = true;
                }
                else
                {
                    checkBoxEmployeeNo.Checked = false;
                }
                if (e.Item.SubItems[8].Text.ToString() == "true")
                {
                    checkBoxDeleteFp.Checked = true;
                }
                else
                {
                    checkBoxDeleteFp.Checked = false;
                }
            }
        }

        //更新listViewFingerPrint当前行的数据
        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            if (listViewFingerPrint.SelectedItems.Count > 0)
            {
                if (textBoxEmployeeNo.Text == "")
                {
                    return;
                }
                listViewFingerPrint.SelectedItems[0].SubItems[1].Text = textBoxEmployeeNo.Text;

                string sReader = null;
                for (int i = 0; i < 512; i++)
                {
                    if (checkedListBoxReaderValid.GetItemChecked(i))
                    {
                        sReader += (i + 1 + ",");
                    }
                }
                if (sReader != null)
                {
                    sReader = sReader.TrimEnd(',');
                }
                listViewFingerPrint.SelectedItems[0].SubItems[2].Text = sReader;
                listViewFingerPrint.SelectedItems[0].SubItems[3].Text = comboBoxFingerPrintID.Text.ToString();
                listViewFingerPrint.SelectedItems[0].SubItems[4].Text = comboBoxFingerType.Text.ToString();
                listViewFingerPrint.SelectedItems[0].SubItems[5].Text = textBoxFingerDataPath.Text.ToString();
                string sLeaderFp = null;
                for (int i = 0; i < 256; i++)
                {
                    if (checkedListBoxLeaderFP.GetItemChecked(i))
                    {
                        sLeaderFp += (i + 1 + ",");
                    }
                }
                if (sLeaderFp != null)
                {
                    sLeaderFp = sLeaderFp.TrimEnd(',');
                }
                listViewFingerPrint.SelectedItems[0].SubItems[6].Text = sLeaderFp;
                if (checkBoxEmployeeNo.Checked)
                {
                    listViewFingerPrint.SelectedItems[0].SubItems[7].Text = "true";
                }
                else
                {
                    listViewFingerPrint.SelectedItems[0].SubItems[7].Text = "false";
                }
                if (checkBoxDeleteFp.Checked)
                {
                    listViewFingerPrint.SelectedItems[0].SubItems[8].Text = "true";
                }
                else
                {
                    listViewFingerPrint.SelectedItems[0].SubItems[8].Text = "false";
                }
            }
        }

        //清空listViewFingerPrint
        private void btnClearList_Click(object sender, EventArgs e)
        {
            listViewFingerPrint.Items.Clear();
        }

        //向listViewFpCond列表增加数据
        private void btnAddCond_Click(object sender, EventArgs e)
        {
            if (textBoxENo.Text == "")
            {
                return;
            }
            ListViewItem listItem = new ListViewItem();
            int iItemCount = listViewFpCond.Items.Count;
            listItem.Text = (iItemCount + 1).ToString();
            listItem.SubItems.Add(textBoxENo.Text.ToString());
            listItem.SubItems.Add(textBoxCRNo.Text.ToString());
            listItem.SubItems.Add(textBoxFPID.Text.ToString());
            this.listViewFpCond.Items.Add(listItem);
        }

        //选择listViewFpCond当前行
        private void listViewFpCond_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewFpCond.SelectedItems.Count > 0)
            {
                textBoxENo.Text = e.Item.SubItems[1].Text;
                textBoxCRNo.Text = e.Item.SubItems[2].Text;
                textBoxFPID.Text = e.Item.SubItems[3].Text;
            }
        }

        //更新listViewFpCond当前行的数据
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewFpCond.SelectedItems.Count > 0)
            {
                if (textBoxENo.Text == "")
                {
                    return;
                }
                listViewFpCond.SelectedItems[0].SubItems[1].Text = textBoxENo.Text;
                listViewFpCond.SelectedItems[0].SubItems[2].Text = textBoxCRNo.Text;
                listViewFpCond.SelectedItems[0].SubItems[3].Text = textBoxFPID.Text;
            }
        }

        //清空listViewFpCond中的数据
        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewFpCond.Items.Clear();
        }

        //下发指纹的回调函数
        private void ProcessFingerPrintDownloadCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData)
        {
            if (pUserData == null)
            {
                return;
            }
            if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_STATUS)
            {
                uint dwStatus = (uint)Marshal.ReadInt32(lpBuffer);
                if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_FAILED)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 1, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_EXCEPTION)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 2, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_SUCCESS)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                }
                else
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 3, 0);
                }
            }
            else if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_DATA)
            {
                string strFingerPrintStatus = Marshal.PtrToStringAnsi(lpBuffer, (int)dwBufLen);
                JsonFingerPrintStatus = new CFingerPrintStatusCfg();
                JsonFingerPrintStatus = JsonConvert.DeserializeObject<CFingerPrintStatusCfg>(strFingerPrintStatus);
                if (JsonFingerPrintStatus != null && JsonFingerPrintStatus.FingerPrintStatus != null)
                {
                    //返回了FingerPrintStatus
                    int totalStatus = JsonFingerPrintStatus.FingerPrintStatus.totalStatus;
                    if (totalStatus == 1)
                    {
                        //必须totalStatus等于1，而且表格中还有指纹才继续下发
                        CHCNetSDK.PostMessage(pUserData, 1003, 1, 0);
                    }

                    if ((totalStatus == 1) && (m_iFingerPrintIndex >= m_iFingerPrintNum))
                    {
                        CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                        return;
                    }
                }
            }
            return;
        }

        //建立长连接，下发指纹
        private void POST_FingerPrintCfg_Click(object sender, EventArgs e)
        {
            listViewMessage.Items.Clear();
            m_iFingerPrintIndex = 0;
            m_iFingerPrintNum = listViewFingerPrint.Items.Count;
            if (m_lFingerPrintDownloadHandle != -1)
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle);
                m_lFingerPrintDownloadHandle = -1;
            }

            if (m_iFingerPrintNum < 1)
            {
                MessageBox.Show("Please add some fingerprints!");
                return;
            }

            g_fFingerPrintDownloadCallback = new CHCNetSDK.RemoteConfigCallback(ProcessFingerPrintDownloadCallback);
            string sURL = "POST /ISAPI/AccessControl/FingerPrintDownload?format=json";
            IntPtr ptrURL = Marshal.StringToHGlobalAnsi(sURL);

            m_lFingerPrintDownloadHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(m_lUserID, CHCNetSDK.NET_DVR_JSON_CONFIG, ptrURL, sURL.Length, g_fFingerPrintDownloadCallback, this.Handle);
            Marshal.FreeHGlobal(ptrURL);
            if (!POSTFingerPrintCfg())
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle);
                m_lFingerPrintDownloadHandle = -1;
            }
        }

        //下发列表中这行的指纹
        private bool POSTFingerPrintCfg()
        {
            if (m_iFingerPrintIndex >= m_iFingerPrintNum)
            {
                return false;
            }
            CFingerPrintCfgCfg JsonFingerPrintCfg = new CFingerPrintCfgCfg();
            JsonFingerPrintCfg.FingerPrintCfg = new CFingerPrintCfg();
            JsonFingerPrintCfg.FingerPrintCfg.employeeNo = listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[1].Text.ToString();
            string senableCardReader = listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[2].Text.ToString();
            string[] sArrayR = Regex.Split(senableCardReader, ",", RegexOptions.IgnoreCase);
            JsonFingerPrintCfg.FingerPrintCfg.enableCardReader = new int[sArrayR.Length];
            for (int i = 0; i < sArrayR.Length; i++)
            {
                int iReadNo = 0;
                if (sArrayR[0] == "")
                {
                    JsonFingerPrintCfg.FingerPrintCfg.enableCardReader = null;
                    break;
                }
                int.TryParse(sArrayR[i], out iReadNo);
                JsonFingerPrintCfg.FingerPrintCfg.enableCardReader[i] = iReadNo;
            }
            int fingerPrintID = 0;
            int.TryParse(listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[3].Text.ToString(), out fingerPrintID);
            JsonFingerPrintCfg.FingerPrintCfg.fingerPrintID = fingerPrintID;
            JsonFingerPrintCfg.FingerPrintCfg.fingerType = listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[4].Text.ToString();
            //指纹数据需要base64加密
            string sFpPath = listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[5].Text.ToString();
            if (File.Exists(sFpPath))
            {
                FileStream fs = File.OpenRead(sFpPath); // OpenRead
                int filelen = 0;
                filelen = (int)fs.Length;
                byte[] byteFp = new byte[filelen];
                fs.Read(byteFp, 0, filelen);
                fs.Close();

                string sFpData = null;
                try
                {
                    sFpData = Convert.ToBase64String(byteFp);
                }
                catch
                {
                    sFpData = null;
                }
                JsonFingerPrintCfg.FingerPrintCfg.fingerData = sFpData;
            }
            else
            {
                JsonFingerPrintCfg.FingerPrintCfg.fingerData = "";
            }

            string sleaderFP = listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[6].Text.ToString();
            string[] sArrayD = Regex.Split(sleaderFP, ",", RegexOptions.IgnoreCase);
            JsonFingerPrintCfg.FingerPrintCfg.leaderFP = new int[sArrayD.Length];
            for (int i = 0; i < sArrayD.Length; i++)
            {
                int iDoorNo = 0;
                if (sArrayD[0] == "")
                {
                    JsonFingerPrintCfg.FingerPrintCfg.leaderFP = null;
                    break;
                }
                int.TryParse(sArrayD[i], out iDoorNo);
                JsonFingerPrintCfg.FingerPrintCfg.leaderFP[i] = iDoorNo;
            }
            if (listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[7].Text.ToString() == "true")
            {
                JsonFingerPrintCfg.FingerPrintCfg.checkEmployeeNo = true;
            }
            else
            {
                JsonFingerPrintCfg.FingerPrintCfg.checkEmployeeNo = false;
            }
            if (listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[8].Text.ToString() == "true")
            {
                JsonFingerPrintCfg.FingerPrintCfg.deleteFingerPrint = true;
            }
            else
            {
                JsonFingerPrintCfg.FingerPrintCfg.deleteFingerPrint = false;
            }

            string strFingerPrintCfg = JsonConvert.SerializeObject(JsonFingerPrintCfg, Formatting.Indented,
                                                            new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            IntPtr ptrFingerPrintCfg = Marshal.StringToHGlobalAnsi(strFingerPrintCfg);
            if (!CHCNetSDK.NET_DVR_SendRemoteConfig(m_lFingerPrintDownloadHandle, (int)CHCNetSDK.LONG_CFG_SEND_DATA_TYPE_ENUM.ENUM_SEND_JSON_DATA, ptrFingerPrintCfg, (uint)strFingerPrintCfg.Length))
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = "Fail";
                string strTemp = null;
                strTemp = string.Format("Send Fail,No:{0}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text);
                listItem.SubItems.Add(strTemp);
                this.AddList(listViewMessage, listItem);
                Marshal.FreeHGlobal(ptrFingerPrintCfg);
                return false;
            }
            ListViewItem listItemSucc = new ListViewItem();
            listItemSucc.Text = "Succ";
            string strTempSucc = null;
            strTempSucc = string.Format("Send Processing,No:{0}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text);
            listItemSucc.SubItems.Add(strTempSucc);
            this.AddList(listViewMessage, listItemSucc);
            Marshal.FreeHGlobal(ptrFingerPrintCfg);
            return true;
        }

        //指纹参数设置，回调函数
        private void ProcessFingerPrintSetUpCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData)
        {
            if (pUserData == null)
            {
                return;
            }
            if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_STATUS)
            {
                uint dwStatus = (uint)Marshal.ReadInt32(lpBuffer);
                if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_FAILED)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 1, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_EXCEPTION)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 2, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_SUCCESS)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                }
                else
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 3, 0);
                }
            }
            else if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_DATA)
            {
                string strFingerPrintStatus = Marshal.PtrToStringAnsi(lpBuffer, (int)dwBufLen);
                JsonFingerPrintStatus = new CFingerPrintStatusCfg();
                JsonFingerPrintStatus = JsonConvert.DeserializeObject<CFingerPrintStatusCfg>(strFingerPrintStatus);
                if (JsonFingerPrintStatus != null && JsonFingerPrintStatus.FingerPrintStatus != null)
                {
                    if (JsonFingerPrintStatus.FingerPrintStatus.status != null)
                    {
                        //存在FingerPrintStatus.status,说明仅是修改指纹参数，不是下发指纹
                        if (JsonFingerPrintStatus.FingerPrintStatus.status == "success")
                        {
                            CHCNetSDK.PostMessage(pUserData, 1004, 1, 0);
                        }
                        else if (JsonFingerPrintStatus.FingerPrintStatus.status == "failed")
                        {
                            CHCNetSDK.PostMessage(pUserData, 1004, 2, 0);
                        }
                    }

                    if (JsonFingerPrintStatus.FingerPrintStatus.StatusList != null)
                    {
                        //存在FingerPrintStatus.StatusList，代表是实际下发指纹数据到读卡器,不是修改指纹
                        CHCNetSDK.PostMessage(pUserData, 1004, 3, 0);
                    }

                    if (m_iFingerPrintIndex >= m_iFingerPrintNum)
                    {
                        CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                        return;
                    }
                }
            }
            return;
        }

        //指纹参数设置，建立长连接
        //和指纹参数下发用同一个长连接句柄
        private void btnSetUpFpCfg_Click(object sender, EventArgs e)
        {
            listViewMessage.Items.Clear();
            m_iFingerPrintIndex = 0;
            m_iFingerPrintNum = listViewFingerPrint.Items.Count;
            if (m_lFingerPrintDownloadHandle != -1)
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle);
                m_lFingerPrintDownloadHandle = -1;
            }

            if (m_iFingerPrintNum < 1)
            {
                MessageBox.Show("Please add some fingerprints!");
                return;
            }

            g_fFingerPrintSetUpCallback = new CHCNetSDK.RemoteConfigCallback(ProcessFingerPrintSetUpCallback);
            string sURL = "POST /ISAPI/AccessControl/FingerPrint/SetUp?format=json";
            IntPtr ptrURL = Marshal.StringToHGlobalAnsi(sURL);

            m_lFingerPrintDownloadHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(m_lUserID, CHCNetSDK.NET_DVR_JSON_CONFIG, ptrURL, sURL.Length, g_fFingerPrintSetUpCallback, this.Handle);
            Marshal.FreeHGlobal(ptrURL);
            if (!POSTFingerPrintCfg())
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle);
                m_lFingerPrintDownloadHandle = -1;
            }
        }

        //获取指纹，回调函数
        private void ProcessFingerPrintUploadCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData)
        {
            if (pUserData == null)
            {
                return;
            }
            if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_STATUS)
            {
                uint dwStatus = (uint)Marshal.ReadInt32(lpBuffer);
                if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_FAILED)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 1, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_EXCEPTION)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 2, 0);
                }
                else if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_SUCCESS)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                }
                else
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 3, 0);
                }
            }
            else if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_DATA)
            {
                string strFingerPrintInfo = Marshal.PtrToStringAnsi(lpBuffer, (int)dwBufLen);
                JsonFingerPrintInfo = new CFingerPrintInfoCfg();
                JsonFingerPrintInfo = JsonConvert.DeserializeObject<CFingerPrintInfoCfg>(strFingerPrintInfo);

                if (JsonFingerPrintInfo == null || JsonFingerPrintInfo.FingerPrintInfo == null)
                {
                    //返回的不是FingerPrintInfo直接报错，并断开长连接
                    CHCNetSDK.PostMessage(pUserData, 1001, 3, 0);
                    return;
                }

                if (JsonFingerPrintInfo.FingerPrintInfo.status == "OK")
                {
                    //收到的报文里存在指纹，需要在列表中显示
                    //OK还代表还有剩余的指纹没接收完，需要继续循环获取，出现NoFP才结束，关闭长连接
                    CHCNetSDK.PostMessage(pUserData, 1005, 1, 0);
                }
                else if (JsonFingerPrintInfo.FingerPrintInfo.status == "NoFP")
                {
                    //没有指纹
                    CHCNetSDK.PostMessage(pUserData, 1005, 2, 0);
                }

                if (m_iFingerPrintCondIndex >= m_iFingerPrintCondNum)
                {
                    CHCNetSDK.PostMessage(pUserData, 1001, 4, 0);
                    //可以结束了，正常(异常)结束
                    return;
                }
            }
            return;
        }

        //获取指纹，建立长连接
        private void btnGetFpCfg_Click(object sender, EventArgs e)
        {
            listViewMessage.Items.Clear();
            m_iFingerPrintCondIndex = 0;
            m_iFingerPrintCondNum = listViewFpCond.Items.Count;
            listViewFingerPrint.Items.Clear();
            if (-1 != m_lFingerPrintUploadHandle)
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintUploadHandle);
                m_lFingerPrintUploadHandle = -1;
            }

            g_fFingerPrintUploadCallback = new CHCNetSDK.RemoteConfigCallback(ProcessFingerPrintUploadCallback);
            string sURL = "POST /ISAPI/AccessControl/FingerPrintUpload?format=json";
            IntPtr ptrURL = Marshal.StringToHGlobalAnsi(sURL);

            m_lFingerPrintUploadHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(m_lUserID, CHCNetSDK.NET_DVR_JSON_CONFIG, ptrURL, sURL.Length, g_fFingerPrintUploadCallback, this.Handle);
            Marshal.FreeHGlobal(ptrURL);
            if (!GetFingerPrintCfg())
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle);
                m_lFingerPrintDownloadHandle = -1;
            }
        }
        
        //获取指纹函数
        private bool GetFingerPrintCfg()
        {
            if (m_iFingerPrintCondIndex >= m_iFingerPrintCondNum)
            {
                return false;
            }
            JsonFingerPrintCond = new CFingerPrintCondCfg();
            JsonFingerPrintCond.FingerPrintCond = new CFingerPrintCond();
            JsonFingerPrintCond.FingerPrintCond.searchID = searchID.ToString();
            JsonFingerPrintCond.FingerPrintCond.employeeNo = listViewFpCond.Items[m_iFingerPrintCondIndex].SubItems[1].Text.ToString();
            int icardReaderNo = 0;
            int.TryParse(listViewFpCond.Items[m_iFingerPrintCondIndex].SubItems[2].Text, out icardReaderNo);
            JsonFingerPrintCond.FingerPrintCond.cardReaderNo = icardReaderNo;
            int ifingerPrintID = 0;
            int.TryParse(listViewFpCond.Items[m_iFingerPrintCondIndex].SubItems[3].Text, out ifingerPrintID);
            JsonFingerPrintCond.FingerPrintCond.fingerPrintID = ifingerPrintID; 

            string strFingerPrintCond = JsonConvert.SerializeObject(JsonFingerPrintCond, Formatting.Indented,
                                                        new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            IntPtr ptrFingerPrintCond = Marshal.StringToHGlobalAnsi(strFingerPrintCond);
            if (!CHCNetSDK.NET_DVR_SendRemoteConfig(m_lFingerPrintUploadHandle, (int)CHCNetSDK.LONG_CFG_SEND_DATA_TYPE_ENUM.ENUM_SEND_JSON_DATA, ptrFingerPrintCond, (uint)strFingerPrintCond.Length))
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = "Fail";
                string strTemp = null;
                strTemp = string.Format("Get Fail,No:{0}", listViewFpCond.Items[m_iFingerPrintCondIndex].SubItems[0].Text);
                listItem.SubItems.Add(strTemp);
                this.AddList(listViewMessage, listItem);

                Marshal.FreeHGlobal(ptrFingerPrintCond);
                return false;
            }
            ListViewItem listItemSucc = new ListViewItem();
            listItemSucc.Text = "Succ";
            string strTempSucc = null;
            strTempSucc = string.Format("Get Processing,No:{0}", listViewFpCond.Items[m_iFingerPrintCondIndex].SubItems[0].Text);
            listItemSucc.SubItems.Add(strTempSucc);
            this.AddList(listViewMessage, listItemSucc);
            Marshal.FreeHGlobal(ptrFingerPrintCond);
            return true;
        }
        
        //处理回调函数中的PostMessage
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 1001:
                    int iErrorMsg = m.WParam.ToInt32();
                    if (iErrorMsg == 1)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Fail";
                        string strTemp = string.Format("NET_SDK_CALLBACK_STATUS_FAILED");
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    else if (iErrorMsg == 2)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Fail";
                        string strTemp = string.Format("NET_SDK_CALLBACK_STATUS_EXCEPTION");
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    else if (iErrorMsg == 3)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Fail";
                        string strTemp = string.Format("NET_SDK_CALLBACK_OTHER_ERROR");
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    else if (iErrorMsg == 4)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Succ";
                        string strTemp = string.Format("NET_SDK_CALLBACK_FINISH");
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    if (-1 != m_lFingerPrintDownloadHandle)
                    {
                        if (CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintDownloadHandle))
                        {
                            m_lFingerPrintDownloadHandle = -1;
                        }
                    }
                    if (-1 != m_lFingerPrintUploadHandle)
                    {
                        if (CHCNetSDK.NET_DVR_StopRemoteConfig(m_lFingerPrintUploadHandle))
                        {
                            m_lFingerPrintUploadHandle = -1;
                        }
                    }
                    break;
                case 1002:
                    POSTFingerPrintCfg();
                    break;
                case 1003:
                    int iError = m.WParam.ToInt32();
                    if (iError == 1)
                    {
                        for (int i = 0; i < JsonFingerPrintStatus.FingerPrintStatus.StatusList.Count; i++)
                        {
                            ListViewItem listItem = new ListViewItem();
                            listItem.Text = "Succ";
                            string strTemp = string.Format("Send Succ,No:{0},cardReaderID:{1},cardReaderRecvStatus:{2}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text, JsonFingerPrintStatus.FingerPrintStatus.StatusList[i].id, JsonFingerPrintStatus.FingerPrintStatus.StatusList[i].cardReaderRecvStatus);
                            listItem.SubItems.Add(strTemp);
                            this.AddList(listViewMessage, listItem);
                        }
                        m_iFingerPrintIndex++;
                        POSTFingerPrintCfg();
                    }
                    break;
                case 1004:
                    int iErrorMsg4 = m.WParam.ToInt32();
                    if (iErrorMsg4 == 1)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Succ";
                        string strTemp = string.Format("Setup Succ,No:{0}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text);
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    else if (iErrorMsg4 == 2)
                    {
                        ListViewItem listItem = new ListViewItem();
                        listItem.Text = "Fail";
                        string strTemp = string.Format("Setup Fail,No:{0}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text);
                        listItem.SubItems.Add(strTemp);
                        this.AddList(listViewMessage, listItem);
                    }
                    else if (iErrorMsg4 == 3)
                    {
                        for (int i = 0; i < JsonFingerPrintStatus.FingerPrintStatus.StatusList.Count; i++)
                        {
                            ListViewItem listItem = new ListViewItem();
                            listItem.Text = "Succ";
                            string strTemp = string.Format("Setup Succ,No:{0},cardReaderID:{1},cardReaderRecvStatus:{2}", listViewFingerPrint.Items[m_iFingerPrintIndex].SubItems[0].Text, JsonFingerPrintStatus.FingerPrintStatus.StatusList[i].id, JsonFingerPrintStatus.FingerPrintStatus.StatusList[i].cardReaderRecvStatus);
                            listItem.SubItems.Add(strTemp);
                            this.AddList(listViewMessage, listItem);
                        }
                    }
                    m_iFingerPrintIndex++;
                    POSTFingerPrintCfg();
                    break;
                case 1005:
                    int iErrorP = m.WParam.ToInt32();
                    if (iErrorP == 1)
                    {
                        listViewFingerPrint.BeginUpdate();
                        for (int i = 0; i < JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList.Count; i++)
                        {
                            ListViewItem listItem = new ListViewItem();
                            int iItemCount = listViewFingerPrint.Items.Count;
                            listItem.Text = (iItemCount + 1).ToString();
                            for (int j = 0; j < 8; j++)
                            {
                                listItem.SubItems.Add("");
                            }
                            this.listViewFingerPrint.Items.Add(listItem);

                            listViewFingerPrint.Items[iItemCount].SubItems[1].Text = JsonFingerPrintCond.FingerPrintCond.employeeNo;
                            listViewFingerPrint.Items[iItemCount].SubItems[2].Text = JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].cardReaderNo.ToString();
                            listViewFingerPrint.Items[iItemCount].SubItems[3].Text = JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].fingerPrintID.ToString();
                            listViewFingerPrint.Items[iItemCount].SubItems[4].Text = JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].fingerType;
                            /********保存指纹数据********/
                            byte[] bytes = Convert.FromBase64String(JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].fingerData);
                            string strPath = string.Format("{0}\\{1}_{2}_{3} fingerprint.dat", Environment.CurrentDirectory, listViewFingerPrint.Items[iItemCount].SubItems[1].Text,
                                                            listViewFingerPrint.Items[iItemCount].SubItems[2].Text, listViewFingerPrint.Items[iItemCount].SubItems[3].Text);
                            /***************************/
                            try
                            {
                                using (FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate))
                                {
                                    if (!File.Exists(strPath))
                                    {
                                        MessageBox.Show("Fingerprint storage file creat failed！");
                                    }
                                    BinaryWriter objBinaryWrite = new BinaryWriter(fs);
                                    fs.Write(bytes, 0, bytes.Length);
                                    fs.Close();
                                }
                            }
                            catch
                            {

                            }
                            listViewFingerPrint.Items[iItemCount].SubItems[5].Text = strPath;
                            if (JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].leaderFP != null)
                            {
                                string src = "";
                                for (int j = 0; j < JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].leaderFP.Length; j++)
                                {
                                    src += JsonFingerPrintInfo.FingerPrintInfo.FingerPrintList[i].leaderFP[j].ToString();
                                    src += ',';
                                }
                                src.TrimEnd(',');
                                listViewFingerPrint.Items[iItemCount].SubItems[6].Text = src;
                            }
                        }
                        listViewFingerPrint.EndUpdate();
                        GetFingerPrintCfg();
                    }
                    else if (iErrorP == 2)
                    {
                        //没有指纹
                        listViewFingerPrint.BeginUpdate();
                        ListViewItem listItem = new ListViewItem();
                        int iItemCount = listViewFingerPrint.Items.Count;
                        listItem.Text = (iItemCount + 1).ToString();
                        for (int j = 0; j < 8; j++)
                        {
                            listItem.SubItems.Add("");
                        }
                        this.listViewFingerPrint.Items.Add(listItem);

                        listViewFingerPrint.Items[iItemCount].SubItems[1].Text = JsonFingerPrintCond.FingerPrintCond.employeeNo;
                        listViewFingerPrint.Items[iItemCount].SubItems[2].Text = JsonFingerPrintCond.FingerPrintCond.cardReaderNo.ToString();
                        listViewFingerPrint.Items[iItemCount].SubItems[3].Text = JsonFingerPrintCond.FingerPrintCond.fingerPrintID.ToString();
                        listViewFingerPrint.Items[iItemCount].SubItems[5].Text = "NoFP";
                        listViewFingerPrint.EndUpdate();
                        searchID++;//收到NoFP,下次搜索searchID要改变
                        m_iFingerPrintCondIndex++;
                        GetFingerPrintCfg();
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        //双击显示信息列表中的信息
        private void listViewMessage_DoubleClick(object sender, EventArgs e)
        {
            if (listViewMessage.SelectedItems.Count > 0)
            {
                MessageBox.Show(this.listViewMessage.FocusedItem.SubItems[1].Text.ToString(), "Info");
            }
        }

        private void FingerPrintMgrByStaffCenter_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this);
        }

    }
}
