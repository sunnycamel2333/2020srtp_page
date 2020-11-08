using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FingerPrintManagement
{
    class CHCNetSDK
    {
        #region HCNetSDK.dll macro definition
        public const int SERIALNO_LEN = 48; //serial number length
        public const int NET_DVR_PASSWORD_ERROR = 1;//Username or Password error
        public const int NET_DVR_USER_LOCKED = 153;
        public const int NET_DVR_DEV_ADDRESS_MAX_LEN = 129; //device address max length
        public const int NET_DVR_LOGIN_USERNAME_MAX_LEN = 64;   //login username max length
        public const int NET_DVR_LOGIN_PASSWD_MAX_LEN = 64; //login password max length


        public const int NET_SDK_GET_NEXT_STATUS_SUCCESS = 1000;
        public const int NET_SDK_GET_NEXT_STATUS_NEED_WAIT = 1001;
        public const int NET_SDK_GET_NEXT_STATUS_FINISH = 1002;
        public const int NET_SDK_GET_NEXT_STATUS_FAILED = 1003;


        public const int NET_DVR_DEL_CARD = 2562;
        public const int ACS_CARD_NO_LEN = 32;
        public const int NET_DVR_GET_FINGERPRINT = 2563; //获取指纹
        public const int NET_SDK_EMPLOYEE_NO_LEN = 32;
        public const int MAX_CARD_READER_NUM_512 = 512;
        public const int MAX_FINGER_PRINT_NUM=10;
        public const int MAX_FINGER_PRINT_LEN = 768;
        public const int NET_DVR_DEL_FINGERPRINT = 2565;
        public const int NET_DVR_SET_FINGERPRINT = 2564;//下发指纹
        public const int NET_DVR_CAPTURE_FINGERPRINT_INFO = 2504;
        public const int ERROR_MSG_LEN=32;
        #endregion


        #region HCNetSDK.dll structure definition

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V40
        {
            public NET_DVR_DEVICEINFO_V30 struDeviceV30;
            public byte bySupportLock;        //设备支持锁定功能，该字段由SDK根据设备返回值来赋值的。bySupportLock为1时，dwSurplusLockTime和byRetryLoginTime有效
            public byte byRetryLoginTime;        //剩余可尝试登陆的次数，用户名，密码错误时，此参数有效
            public byte byPasswordLevel;      //admin密码安全等级0-无效，1-默认密码，2-有效密码,3-风险较高的密码。当用户的密码为出厂默认密码（12345）或者风险较高的密码时，上层客户端需要提示用户更改密码。      
            public byte byProxyType;  //代理类型，0-不使用代理, 1-使用socks5代理, 2-使用EHome代理
            public uint dwSurplusLockTime;    //剩余时间，单位秒，用户锁定时，此参数有效
            public byte byCharEncodeType;     //字符编码类型
            public byte bySupportDev5;//支持v50版本的设备参数获取，设备名称和设备类型名称长度扩展为64字节
            public byte bySupport;  //能力集扩展，位与结果：0- 不支持，1- 支持
            // bySupport & 0x1:  保留
            // bySupport & 0x2:  0-不支持变化上报 1-支持变化上报
            public byte byLoginMode; //登录模式 0-Private登录 1-ISAPI登录
            public uint dwOEMCode;
            public int iResidualValidity;   //该用户密码剩余有效天数，单位：天，返回负值，表示密码已经超期使用，例如“-3表示密码已经超期使用3天”
            public byte byResidualValidity; // iResidualValidity字段是否有效，0-无效，1-有效
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 243)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;    //serial number
            public byte byAlarmInPortNum;   //Number of Alarm input
            public byte byAlarmOutPortNum;  //Number of Alarm Output
            public byte byDiskNum;  //Number of Hard Disk
            public byte byDVRType;  //DVR Type, 1: DVR 2: ATM DVR 3: DVS ......
            public byte byChanNum;  //Number of Analog Channel
            public byte byStartChan;    //The first Channel No. E.g. DVS- 1, DVR- 1
            public byte byAudioChanNum; //Number of Audio Channel
            public byte byIPChanNum;    //Maximum number of IP Channel  low
            public byte byZeroChanNum;  //Zero channel encoding number//2010- 01- 16
            public byte byMainProto;    //Main stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySubProto; //Sub stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySupport;  //Ability, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1,  smart search
            //bySupport & 0x2,  backup
            //bySupport & 0x4,  get compression configuration ability
            //bySupport & 0x8,  multi network adapter
            //bySupport & 0x10, support remote SADP
            //bySupport & 0x20  support Raid card
            //bySupport & 0x40 support IPSAN directory search
            public byte bySupport1; //Ability expand, the 'AND' result by bit: 0- not support;  1- support
            //bySupport1 & 0x1, support snmp v30
            //bySupport1& 0x2,support distinguish download and playback
            //bySupport1 & 0x4, support deployment level
            //bySupport1 & 0x8, support vca alarm time extension 
            //bySupport1 & 0x10, support muti disks(more than 33)
            //bySupport1 & 0x20, support rtsp over http
            //bySupport1 & 0x40, support delay preview
            //bySuppory1 & 0x80 support NET_DVR_IPPARACFG_V40, in addition  support  License plate of the new alarm information
            public byte bySupport2; //Ability expand, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1, decoder support get stream by URL
            //bySupport2 & 0x2,  support FTPV40
            //bySupport2 & 0x4,  support ANR
            //bySupport2 & 0x20, support get single item of device status
            //bySupport2 & 0x40,  support stream encryt
            public ushort wDevType; //device type
            public byte bySupport3; //Support  epresent by bit, 0 - not support 1 - support 
            //bySupport3 & 0x1-muti stream support 
            //bySupport3 & 0x8  support use delay preview parameter when delay preview
            //bySupport3 & 0x10 support the interface of getting alarmhost main status V40
            public byte byMultiStreamProto; //support multi stream, represent by bit, 0-not support ;1- support; bit1-stream 3 ;bit2-stream 4, bit7-main stream, bit8-sub stream
            public byte byStartDChan;   //Start digital channel
            public byte byStartDTalkChan;   //Start digital talk channel
            public byte byHighDChanNum; //Digital channel number high
            public byte bySupport4; //Support  epresent by bit, 0 - not support 1 - support
            //bySupport4 & 0x4 whether support video wall unified interface
            // bySupport4 & 0x80 Support device upload center alarm enable
            public byte byLanguageType; //support language type by bit,0-support,1-not support  
            //byLanguageType 0 -old device
            //byLanguageType & 0x1 support chinese
            //byLanguageType & 0x2 support english
            public byte byVoiceInChanNum;   //voice in chan num
            public byte byStartVoiceInChanNo;   //start voice in chan num
            public byte bySupport5;  //0-no support,1-support,bit0-muti stream
            //bySupport5 &0x01support wEventTypeEx 
            //bySupport5 &0x04support sence expend
            public byte bySupport6;
            public byte byMirrorChanNum;    //mirror channel num,<it represents direct channel in the recording host
            public ushort wStartMirrorChanNo;   //start mirror chan
            public byte bySupport7;        //Support  epresent by bit, 0 - not support 1 - support 
            //bySupport7 & 0x1- supports INTER_VCA_RULECFG_V42 extension    
            // bySupport7 & 0x2  Supports HVT IPC mode expansion
            // bySupport7 & 0x04  Back lock time
            // bySupport7 & 0x08  Set the pan PTZ position, whether to support the band channel
            // bySupport7 & 0x10  Support for dual system upgrade backup
            // bySupport7 & 0x20  Support OSD character overlay V50
            // bySupport7 & 0x40  Support master slave tracking (slave camera)
            // bySupport7 & 0x80  Support message encryption 
            public byte byRes2;
        }


        public delegate void LoginResultCallBack(int lUserID, uint dwResult, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo, IntPtr pUser);
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_USER_LOGIN_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_DEV_ADDRESS_MAX_LEN)]
            public string sDeviceAddress;
            public byte byUseTransport;
            public ushort wPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_LOGIN_USERNAME_MAX_LEN)]
            public string sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_LOGIN_PASSWD_MAX_LEN)]
            public string sPassword;
            public LoginResultCallBack cbLoginResult;
            public IntPtr pUser;
            public bool bUseAsynLogin;
            public byte byProxyType;
            public byte byUseUTCTime;
            public byte byLoginMode; //登录模式 0-Private 1-ISAPI 2-自适应（默认不采用自适应是因为自适应登录时，会对性能有较大影响，自适应时要同时发起ISAPI和Private登录）
            public byte byHttps;    //ISAPI登录时，是否使用HTTPS，0-不使用HTTPS，1-使用HTTPS 2-自适应（默认不采用自适应是因为自适应登录时，会对性能有较大影响，自适应时要同时发起HTTP和HTTPS）
            public int iProxyID;
            public byte byVerifyMode;  //认证方式，0-不认证，1-双向认证，2-单向认证；认证仅在使用TLS的时候生效;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 119, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_COND
        {
            public int dwSize;
            public int dwFingerprintNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            public int dwEnableReaderNo;
            public byte byFingerPrintID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 131)]
            public byte[] byRes;

            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byRes = new byte[131];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_RECORD
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo; //指纹关联的卡号
            public int dwFingerPrintLen; //指纹数据长度
            public int dwEnableReaderNo;//需要下发指纹的读卡器编号
            public byte byFingerPrintID;//手指编号，有效值范围为1-10
            public byte byFingerType;//指纹类型  0-普通指纹，1-胁迫指纹
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.MAX_FINGER_PRINT_LEN)]
            public byte[] byFingerData;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96)]
            public byte[] byRes;
            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byRes1 = new byte[30];
                byFingerData = new byte[CHCNetSDK.MAX_FINGER_PRINT_LEN];
                byRes = new byte[96];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_V50_ByCardNo
        {
            public int dwSize;
            public byte byMode;  //删除方式，0-按卡号（人员ID）方式删除，1-按读卡器删除
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;
            public CHCNetSDK.NET_DVR_FINGER_PRINT_BYCARD_V50 struProcessMode;//处理方式
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;
            public void init()
            {
                byRes1 = new byte[3];
                byRes = new byte[64];
                struProcessMode.init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_V50_ByCardReader
        {
            public int dwSize;
            public byte byMode;  //删除方式，0-按卡号（人员ID）方式删除，1-按读卡器删除
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;
            public CHCNetSDK.NET_DVR_FINGER_PRINT_BYREADER_V50 struProcessMode;//处理方式
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYCARD_V50
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.MAX_CARD_READER_NUM_512)]
            public byte[] byEnableCardReader;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.MAX_FINGER_PRINT_NUM)]
            public byte[] byFingerPrintID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.NET_SDK_EMPLOYEE_NO_LEN)]
            public byte[] byEmployeeNo;
            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[CHCNetSDK.MAX_CARD_READER_NUM_512];
                byFingerPrintID = new byte[CHCNetSDK.MAX_FINGER_PRINT_NUM];
                byRes1 = new byte[2];
                byEmployeeNo = new byte[CHCNetSDK.NET_SDK_EMPLOYEE_NO_LEN];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYREADER_V50
        {
            public int dwCardReaderNo;
            public byte byClearAllCard;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.NET_SDK_EMPLOYEE_NO_LEN)]
            public byte[] byEmployeeNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 516)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_STATUS_V50
        {
            public int dwSize;
            public int dwCardReaderNo;
            public byte byStatus;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63)]
            public byte[] byRes;
            public void init()
            {
                byRes = new byte[63];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_STATUS
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            public byte byCardReaderRecvStatus;//指纹读卡器状态，按字节表示，0-失败，1-成功，2-该指纹模组不在线，3-重试或指纹质量差，4-内存已满，5-已存在该指纹，6-已存在该指纹ID，7-非法指纹ID，8-该指纹模组无需配置
            public byte byFingerPrintID;//手指编号，有效值范围为1-10
            public byte byFingerType;//指纹类型  0-普通指纹，1-胁迫指纹
            public byte byRecvStatus;//主机错误状态：0-成功，1-手指编号错误，2-指纹类型错误，3-卡号错误（卡号规格不符合设备要求），4-指纹未关联工号或卡号（工号或卡号字段为空），5-工号不存在，6-指纹数据长度为0，7-读卡器编号错误，8-工号错误
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ERROR_MSG_LEN)]
            public byte[] byErrorMsg;//下发错误信息，当byCardReaderRecvStatus为5时，表示已存在指纹对应的卡号
            public int dwCardReaderNo;//当byCardReaderRecvStatus为5时，表示已存在指纹对应的指纹读卡器编号，可用于下发错误返回。0时表示无错误信息
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] byRes;
            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byErrorMsg = new byte[CHCNetSDK.ERROR_MSG_LEN];

                byRes = new byte[20];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FINGERPRINT_COND
        {
            public int dwSize;
            public byte byFingerPrintPicType;    //图片类型：0-无意义
            public byte byFingerNo;              //手指编号，范围1-10
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126)]
            public byte[] byRes;

            public void init()
            {
                byRes = new byte[126];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FINGERPRINT_CFG
        {
            public int  dwSize;
            public int dwFingerPrintDataSize;    //指纹数据大小
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.MAX_FINGER_PRINT_LEN)]
            public byte[] byFingerData;        //指纹数据内容
            public int  dwFingerPrintPicSize;    //指纹图片大小，等于0时，代表无指纹图片数据
            public IntPtr pFingerPrintPicBuffer;       //指纹图片缓存
            public byte   byFingerNo;              //手指编号，范围1-10
            public byte  byFingerPrintQuality;    //指纹质量，范围1-100
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =62)]
            public byte[] byRes;

            public void init()
            {
                byFingerData = new byte[CHCNetSDK.MAX_FINGER_PRINT_LEN];
                byRes = new byte[62];
            }
        }

        #endregion


        #region HCNetSDK.dll function definition
        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern uint NET_DVR_GetLastError();

        public delegate void RemoteConfigCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_FINGERPRINT_RECORD lpOutBuff, int dwOutBuffSize);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StopRemoteConfig(int lHandle);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_FINGER_PRINT_INFO_STATUS_V50 lpOutBuff, int dwOutBuffSize);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_FINGERPRINT_RECORD lpInBuff, int dwInBuffSize, ref CHCNetSDK.NET_DVR_FINGERPRINT_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern bool  NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        [DllImport(@"..\..\..\HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_CAPTURE_FINGERPRINT_CFG lpOutBuff, int dwOutBuffSize);
        #endregion

    }
}
