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
using AcsDemo.Public;
using System.Runtime.Serialization;

namespace AcsDemo.ProductAcs
{
    public partial class CaptureDataSearch : Form
    {

        public Int32 m_lUserID = -1;
        private delegate void AddListCallBack(ListView cListView, ListViewItem cListViewItem);
        private CHCNetSDK.RemoteConfigCallback g_fSearchCallback = null;

        private ISAPIRemoteConfig rConfig = null;
        private CHCNetSDK.NET_DVR_JSON_DATA_CFG m_struJsonDataCfg;
        //private byte[] m_byData = new byte[3 * 1024 * 1024];
        private int totalMaches = 1;
        private bool bFirst = true;
        private int iSearchPos = 0;
        private Control m_sourceControl;
        private Dictionary<int, string> picDic;
        private Dictionary<int, string> infraredPicDic;
        private Dictionary<int, string> featureDic;

        private bool bCaptureNo;

        public class CSearchTaskCond<T>
        {
            public T SearchTaskCond { get; set; }
        }

        public class CSearchTaskCondContent
        {
            public string searchID { get; set; }
            public int searchResultPosition { get; set; }
            public int maxResults { get; set; }
            public List<int> captureNoList { get; set; }
            public string searchType { get; set; }
        }

        public class CSearchTaskCondContentNoCaptureNo
        {
            public string searchID { get; set; }
            public int searchResultPosition { get; set; }
            public int maxResults { get; set; }
            public string searchType { get; set; }
        }

        public class CSearchTaskResponse
        {
            public CSearchTaskResponseContent SearchTaskResponse { get; set; }
        }

        public class CSearchTaskResponseContent
        {
            public string searchID { get; set; }
            public string responseStatusStrg { get; set; }
            public int numOfMatches { get; set; }
            public int totalMatches { get; set; }
            public List<CDataCollections> DataCollections { get; set; }
        }

        public class CDataCollections
        {
            public int lastCaptureNo { get; set; }
            public int captureNo { get; set; }
            public string name { get; set; }
            public string employeeNo { get; set; }
            public string IDCardNo { get; set; }
            public List<string> CardNoList { get; set; }
            public List<CFingerprintList> FingerprintList { get; set; }
            public CFaceFeature FaceFeature { get; set; }
            public bool riskDataMark { get; set; }
            public string dataType { get; set; }
        }

        //public class CCardNoList
        //{
        //    public string value { get; set; }
        //}

        public class CFingerprintList
        {
            public int fingerprintID { get; set; }
            public string fingerprint { get; set; }
        }

        public class CFaceFeatureSingle
        {
            public CFaceFeature FaceFeature { get; set; }
        }

        public class CFaceFeature
        {
            public CRegion Region { get; set; }
            public CPoint LeftEyePoint { get; set; }
            public CPoint RightEyePoint { get; set; }
            public CPoint LeftMouthPoint { get; set; }
            public CPoint RightMouthPoint { get; set; }
            public CPoint NoseTipPoint { get; set; }
        }


        public CaptureDataSearch()
        {
            InitializeComponent();

            infraredPicDic = new Dictionary<int, string>();
            picDic = new Dictionary<int, string>();
            featureDic = new Dictionary<int, string>();
            totalMaches = 1;
            bFirst = true;
            iSearchPos = 0;
        }

        private void contextMenuStripTools_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (m_sourceControl.Equals(listViewMessage))
            {
                listViewMessage.Items.Clear();
            }
            else 
            {
                listViewDataDisplay.Items.Clear();
                picDic.Clear();
                featureDic.Clear();
                infraredPicDic.Clear();
            }
        }

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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (rConfig != null)
            {
                rConfig.stop();
                bFirst = true;
                totalMaches = 1;
                iSearchPos = 0;
            }

            rConfig = new ISAPIRemoteConfig(m_lUserID, CHCNetSDK.NET_DVR_CAPTURE_DATA_SEARCH, "POST /ISAPI/AccessControl/OfflineCapture/DataCollections/searchTask?format=json");
            g_fSearchCallback = new CHCNetSDK.RemoteConfigCallback(ProcessDataSearchCallback);
            rConfig.SetListener(g_fSearchCallback);

            if (rConfig.start())
            {
                iSearchPos = int.Parse(textBoxSearchPos.Text);
                string strCond = BuildCondJson();
                if (strCond == null)
                {
                    addLog(false, "GenerateCondJson failed, Parameters invalid");
                    rConfig.stop();
                    return;
                }

                if (!rConfig.send(strCond))
                {
                    addLog(false, "Send Failed");
                    rConfig.stop();
                }
            }
            else 
            {
                addLog(false, "Data Search Fail");
                rConfig.stop();
            }
            return;
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                //DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }

        private string BuildCondJson()
        {
            string strDataSearchCond = null;
            // 是否包含captureNo
            bCaptureNo = (textBoxCaptureNo.Text.Equals("")) ? false : true;
            if (bCaptureNo)
            {
                CSearchTaskCond<CSearchTaskCondContent> JsonDataSearchCond = null;
                JsonDataSearchCond = new CSearchTaskCond<CSearchTaskCondContent>();
                JsonDataSearchCond.SearchTaskCond = new CSearchTaskCondContent();
                JsonDataSearchCond.SearchTaskCond.captureNoList = new List<int>();

                JsonDataSearchCond.SearchTaskCond.searchID = textBoxSearchID.Text;
                JsonDataSearchCond.SearchTaskCond.searchResultPosition = iSearchPos;
                //JsonDataSearchCond.SearchTaskCond.searchResultPosition = 0;
                // 协议只支持一个一个查询数据
                JsonDataSearchCond.SearchTaskCond.maxResults = 1;
                JsonDataSearchCond.SearchTaskCond.searchType = comboBoxSearchType.Text;

                try
                {
                    string text = textBoxCaptureNo.Text;
                    string[] separators = {" ", ","};
                    string[] units = text.Split(separators, 128, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string captureNo in units)
                    {
                        JsonDataSearchCond.SearchTaskCond.captureNoList.Add(int.Parse(captureNo));
                    }

                    strDataSearchCond = JsonConvert.SerializeObject(JsonDataSearchCond, Converter.Settings);
                }
                catch
                {
                    strDataSearchCond = null;
                }

            }
            else 
            {
                CSearchTaskCond<CSearchTaskCondContentNoCaptureNo> JsonDataSearchCond = null;
                JsonDataSearchCond = new CSearchTaskCond<CSearchTaskCondContentNoCaptureNo>();
                JsonDataSearchCond.SearchTaskCond = new CSearchTaskCondContentNoCaptureNo();

                JsonDataSearchCond.SearchTaskCond.searchID = textBoxSearchID.Text;
                // 协议只支持一个一个查询数据
                JsonDataSearchCond.SearchTaskCond.maxResults = 1;
                JsonDataSearchCond.SearchTaskCond.searchType = comboBoxSearchType.Text;

                try
                {
                    JsonDataSearchCond.SearchTaskCond.searchResultPosition = iSearchPos;
                    strDataSearchCond = JsonConvert.SerializeObject(JsonDataSearchCond, Converter.Settings);
                }
                catch
                {
                    strDataSearchCond = null;
                }
            }

            return strDataSearchCond;
        }

        private void addLog(bool status, string tmpStr)
        {
            ListViewItem listItem = new ListViewItem();
            string strTemp;
            listItem.Text = DateTime.Now.ToLocalTime().ToString();
            if (!status)
            {
                listItem.SubItems.Add("Failure");
                strTemp = string.Format("{0},error code:{1}", tmpStr ,CHCNetSDK.NET_DVR_GetLastError());
            }
            else
            {
                listItem.SubItems.Add("Success");
                strTemp = string.Format("{0}", tmpStr);
            }

            listItem.SubItems.Add(strTemp);
            this.AddList(listViewMessage, listItem);
        }

        public enum SearchMsgType
        {
            NO_DEFINE = -1,
            RECV_DATA = 1,
            RECV_FINISH = 2,
            RECV_FAILIURE = 3
        }

        public class MessageData
        {
            public MessageData()
            {
                searchMsg = SearchMsgType.NO_DEFINE;
                status = 0;
                errorcode = 0;
                data = null;
                dataLen = 0;
                // 最大200K数据
                picture = new byte[200 * 1024];
                pictureLen = 0;
                infraredPic = new byte[200 * 1024];
                infraredPicLen = 0;
            }

            public SearchMsgType searchMsg;
            public CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL status;
            public int errorcode;
            public string data;
            public int dataLen;
            public byte[] picture;
            public int pictureLen;
            public byte[] infraredPic;
            public int infraredPicLen;
        }

        public delegate void SearchDataProcessDelegate(MessageData m);
        public void ProcessData(MessageData mes)
        {
            if (this.InvokeRequired)
            {
                Delegate delegateProc = new SearchDataProcessDelegate(ProcessData);
                this.BeginInvoke(delegateProc, mes);
            }
            else
            {
                ProcessResult(mes);
            }
        }

        private void SearchNextData()
        {
            iSearchPos++;
            string strCond = BuildCondJson();
            if (strCond == null)
            {
                addLog(false, "GenerateCondJson failed, Parameters invalid");
                return;
            }

            if (!rConfig.send(strCond))
            {
                addLog(false, "Send Failed");
                rConfig.stop();
            }
        }

        public void ProcessResult(MessageData m)
        {
            if (m.searchMsg == SearchMsgType.RECV_DATA)
            {
                Debug.Assert(m.data != null);

                // 包含节点\"errorCode\"，则按照responsestatus状态解析
                if (m.data.Contains("\"errorCode\""))
                {
                    CResponseStatus status = JsonConvert.DeserializeObject<CResponseStatus>(m.data);
                    string strTemp = string.Format("Search data device return failure status.errorcode[{0}] errormsg[{1}]", status.errorCode, status.errorMsg);
                    addLog(false, strTemp);
                    rConfig.stop();
                    return;
                }

                // 按照查询结果解析
                CSearchTaskResponse cSearchTaskResponse = null;
                try
                {
                    cSearchTaskResponse = JsonConvert.DeserializeObject<CSearchTaskResponse>(m.data);
                }
                catch (Exception e)
                {
                    addLog(false, "Data DeserializeObject failed " + e.Message);
                }

                if (cSearchTaskResponse == null)
                {
                    addLog(false, "Data return invalid");
                    // 查询下一条数据
                    SearchNextData();
                    return;
                }

                if (cSearchTaskResponse.SearchTaskResponse.responseStatusStrg.Equals("NO MATCH"))
                {
                    addLog(true, "Response NO MATCH data, search over");
                    rConfig.stop();
                    return;
                }

                if (cSearchTaskResponse.SearchTaskResponse.numOfMatches != 1)
                {
                    addLog(true, "Warning: numOfMatches!=1!!! carptureNo: " + cSearchTaskResponse.SearchTaskResponse.DataCollections[0].captureNo);
                }

                if (bFirst)
                {
                    totalMaches = cSearchTaskResponse.SearchTaskResponse.totalMatches;
                    bFirst = false;
                }

                // 保存数据并且在UI上展现
                UpdateViewControls(ref cSearchTaskResponse);
                SavePcituresAndFP(ref cSearchTaskResponse, ref m);

                if (cSearchTaskResponse.SearchTaskResponse.responseStatusStrg.Equals("OK"))
                {
                    addLog(true, "Response OK data, search over");
                    rConfig.stop();
                    return;
                }

                if (iSearchPos >= totalMaches - 1)
                {
                    addLog(true, "search over");
                    rConfig.stop();
                    return;
                }

                // 查询下一条数据
                SearchNextData();
            }
            else if (m.searchMsg == SearchMsgType.RECV_FAILIURE)
            {
                addLog(false, "Receive failed status runtime error: " + m.errorcode);
                // 查询下一条数据
                SearchNextData();
            }
            else if (m.searchMsg == SearchMsgType.RECV_FINISH)
            {
                addLog(true, "Receive with long config status: " + m.status + " " + m.searchMsg);
                rConfig.stop();
            }

            return;
        }

        private void SavePcituresAndFP(ref CSearchTaskResponse cSearchTaskResponse, ref MessageData m)
        {
            foreach (CDataCollections data in cSearchTaskResponse.SearchTaskResponse.DataCollections)
            {
                if (data.FingerprintList != null)
                {
                    foreach (CFingerprintList fp in data.FingerprintList)
                    {
                        byte[] bytes = Convert.FromBase64String(fp.fingerprint);
                        string strPath = string.Format("{0}\\{1}_{2}_{3} fingerprint{4}.dat", Environment.CurrentDirectory, data.captureNo, data.name, data.employeeNo, fp.fingerprintID);
                        AcsDemoPublic.WriteBytesToFile(bytes, bytes.Length, strPath);
                    }
                }

                if (m.pictureLen > 0)
                {
                    string strPicPath = string.Format("{0}\\{1}_{2}_{3} facePicture.jpg", Environment.CurrentDirectory, data.captureNo, data.name, data.employeeNo);
                    AcsDemoPublic.WriteBytesToFile(m.picture, m.pictureLen, strPicPath);
                    if (!picDic.ContainsKey(data.captureNo)) picDic.Add(data.captureNo, strPicPath);
                }

                if (m.infraredPicLen > 0)
                {
                    string strInfraedPicPath = string.Format("{0}\\{1}_{2}_{3} infraredFacePicture.jpg", Environment.CurrentDirectory, data.captureNo, data.name, data.employeeNo);
                    AcsDemoPublic.WriteBytesToFile(m.infraredPic, m.infraredPicLen, strInfraedPicPath);
                    if (!infraredPicDic.ContainsKey(data.captureNo)) infraredPicDic.Add(data.captureNo, strInfraedPicPath);
                }

                if (data.FaceFeature != null)
                {
                    CFaceFeatureSingle cSingle = new CFaceFeatureSingle();
                    cSingle.FaceFeature = data.FaceFeature;
                    string strSigle = JsonConvert.SerializeObject(cSingle);
                    if (!featureDic.ContainsKey(data.captureNo)) featureDic.Add(data.captureNo, strSigle);
                }
            }
        }
         private void UpdateViewControls(ref CSearchTaskResponse cSearchTaskResponse)
        {
            ListViewItem listItem = new ListViewItem();
            listViewDataDisplay.BeginUpdate();
            int iItemCount = listViewDataDisplay.Items.Count;
            listItem.Text = (iItemCount + 1).ToString();

            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].captureNo.ToString());
            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].lastCaptureNo.ToString());
            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].name);
            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].employeeNo);
            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].IDCardNo);

            string CardNos = null;
            string FpIDs = null;
            if (cSearchTaskResponse.SearchTaskResponse.DataCollections[0].CardNoList != null)
            {
                foreach (string cardNo in cSearchTaskResponse.SearchTaskResponse.DataCollections[0].CardNoList)
                {
                    string tmp = string.Format("{0};", cardNo);
                    CardNos += tmp;
                }
                listItem.SubItems.Add(CardNos);
            }
            else
            { 
                listItem.SubItems.Add(CardNos); 
            }

            if (cSearchTaskResponse.SearchTaskResponse.DataCollections[0].FingerprintList != null)
            {
                foreach (CFingerprintList fp in cSearchTaskResponse.SearchTaskResponse.DataCollections[0].FingerprintList)
                {
                    string tmp = string.Format("{0};", fp.fingerprintID);
                    FpIDs += tmp;
                }
                listItem.SubItems.Add(FpIDs);
            }
            else
            {
                listItem.SubItems.Add(FpIDs);
            }

            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].dataType);
            listItem.SubItems.Add(cSearchTaskResponse.SearchTaskResponse.DataCollections[0].riskDataMark.ToString());

            this.listViewDataDisplay.Items.Add(listItem);
            listViewDataDisplay.EndUpdate();
        }

        private void ProcessDataSearchCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData)
        {
            try
            {
                if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_STATUS)
                {
                    MessageData msg = new MessageData();
                    msg.errorcode = 0;
                    uint dwStatus = (uint)Marshal.ReadInt32(lpBuffer);
                    if (dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_FAILED ||
                        dwStatus == (uint)CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL.NET_SDK_CALLBACK_STATUS_EXCEPTION)
                    {
                        msg.searchMsg = SearchMsgType.RECV_FAILIURE;
                        msg.errorcode = (int)CHCNetSDK.NET_DVR_GetLastError();
                        msg.status = (CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL)dwStatus;
                        this.ProcessData(msg);
                    }
                    else
                    {
                        msg.searchMsg = SearchMsgType.RECV_FINISH;
                        msg.status = (CHCNetSDK.NET_SDK_CALLBACK_STATUS_NORMAL)dwStatus;
                        this.ProcessData(msg);
                    }
                }
                else if (dwType == (uint)CHCNetSDK.NET_SDK_CALLBACK_TYPE.NET_SDK_CALLBACK_TYPE_DATA)
                {
                    MessageData msg = new MessageData();
                    msg.errorcode = 0;
                    msg.searchMsg = SearchMsgType.RECV_DATA;

                    m_struJsonDataCfg = (CHCNetSDK.NET_DVR_JSON_DATA_CFG)Marshal.PtrToStructure(lpBuffer, typeof(CHCNetSDK.NET_DVR_JSON_DATA_CFG));

                    if (m_struJsonDataCfg.dwJsonDataSize > 3 * 1024 * 1024)
                    {
                        addLog(false, "ProcessData exception json data too long!");
                        MessageData msgFin = new MessageData();
                        msgFin.errorcode = 0;
                        msgFin.searchMsg = SearchMsgType.RECV_FINISH;
                        this.ProcessData(msgFin);
                        return;
                    }

                    byte[] byData = new byte[m_struJsonDataCfg.dwJsonDataSize + 1];
                    Marshal.Copy((IntPtr)m_struJsonDataCfg.lpJsonData, byData, 0, (int)m_struJsonDataCfg.dwJsonDataSize);
                    msg.data = System.Text.Encoding.UTF8.GetString(byData);
                    msg.dataLen = (int)m_struJsonDataCfg.dwJsonDataSize;
                    msg.pictureLen = (int)m_struJsonDataCfg.dwPicDataSize;
                    msg.infraredPicLen = (int)m_struJsonDataCfg.dwInfraredFacePicSize;
                    if (msg.pictureLen != 0 && m_struJsonDataCfg.lpPicData != IntPtr.Zero)
                    {
                        Marshal.Copy((IntPtr)m_struJsonDataCfg.lpPicData, msg.picture, 0, msg.pictureLen);
                    }
                    if (msg.infraredPicLen != 0 && m_struJsonDataCfg.lpInfraredFacePicBuffer != IntPtr.Zero)
                    {
                        Marshal.Copy((IntPtr)m_struJsonDataCfg.lpInfraredFacePicBuffer, msg.infraredPic, 0, msg.infraredPicLen);
                    }
                    // 处理数据并查询下一条数据
                    this.ProcessData(msg);
                }
            }
            catch // System.InvalidOperationException System.ArgumentException
            {
                addLog(false, "ProcessData exception");
                return;
            }
            return;
        }

        private void contextMenuStripTools_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = (ContextMenuStrip)sender;
            m_sourceControl = menu.SourceControl;
        }

        private void listViewDataDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDataDisplay.SelectedItems.Count == 0) return;
            if (listViewDataDisplay.SelectedItems != null)
            {
                int no = int.Parse(listViewDataDisplay.SelectedItems[0].SubItems[1].Text);

                if (pictureBoxPic.Image != null)
                {
                    pictureBoxPic.Image.Dispose();
                    pictureBoxPic.Image = null;
                }

                if (pictureBoxInfrared.Image != null)
                {
                    pictureBoxInfrared.Image.Dispose();
                    pictureBoxInfrared.Image = null;
                }

                try
                {
                    pictureBoxPic.Image = Image.FromFile(picDic[no]);
                    pictureBoxInfrared.Image = Image.FromFile(infraredPicDic[no]);
                    richTextBoxOutputJson.Text = featureDic[no];
                }
                catch (Exception exp)
                {
                    addLog(false, "Warning:Face data loading failed! Exception type:" + exp.GetType());
                }
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            rConfig.stop();
            bFirst = true;
            totalMaches = 1;
            iSearchPos = 0;
        }
    }
}
