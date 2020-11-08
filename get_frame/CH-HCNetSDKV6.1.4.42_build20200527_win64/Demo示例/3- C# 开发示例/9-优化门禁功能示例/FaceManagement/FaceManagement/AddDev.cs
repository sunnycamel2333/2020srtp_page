﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FaceManagement.Language;

namespace FaceManagement
{
    public partial class AddDev : Form
    {
        public AddDev()
        {
            InitializeComponent();
        }
        public int m_iUserID = -1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxDeviceAddress.Text.Length <= 0 || textBoxDeviceAddress.Text.Length > 128)
            {
                MessageBox.Show(Properties.Resources.deviceAddressTips);
                return;
            }

            int port;
            int.TryParse(textBoxPort.Text, out port);

            if (textBoxPort.Text.Length > 5 || port <= 0)
            {
                MessageBox.Show(Properties.Resources.portTips);
                return;
            }
            if (textBoxUserName.Text.Length > 32 || textBoxPassword.Text.Length > 16)
            {
                MessageBox.Show(Properties.Resources.usernameAndPasswordTips);
                return;
            }
            Login();
            if (m_iUserID >= 0)
            {
                this.Close();
            }
        }

        private void Login()
        {
            CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLoginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
            CHCNetSDK.NET_DVR_DEVICEINFO_V40 struDeviceInfoV40 = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();
            struDeviceInfoV40.struDeviceV30.sSerialNumber = new byte[CHCNetSDK.SERIALNO_LEN];

            struLoginInfo.sDeviceAddress = textBoxDeviceAddress.Text;
            struLoginInfo.sUserName = textBoxUserName.Text;
            struLoginInfo.sPassword = textBoxPassword.Text;
            ushort.TryParse(textBoxPort.Text, out struLoginInfo.wPort);

            int lUserID = -1;
            lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLoginInfo, ref struDeviceInfoV40);
            if (lUserID >= 0)
            {
                m_iUserID = lUserID;
                MessageBox.Show("Login Successful");
            }
            else
            {
                uint nErr = CHCNetSDK.NET_DVR_GetLastError();
                if (nErr == CHCNetSDK.NET_DVR_PASSWORD_ERROR)
                {
                    MessageBox.Show("user name or password error!");
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        string strTemp1 = string.Format("Left {0} try opportunity", struDeviceInfoV40.byRetryLoginTime);
                        MessageBox.Show(strTemp1);
                    }
                }
                else if (nErr == CHCNetSDK.NET_DVR_USER_LOCKED)
                {
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        string strTemp1 = string.Format("user is locked, the remaining lock time is {0}", struDeviceInfoV40.dwSurplusLockTime);
                        MessageBox.Show(strTemp1);
                    }
                }
                else
                {
                    MessageBox.Show("net error or dvr is busy!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDevice_Load(object sender, EventArgs e)
        {
            MultiLanguage.LoadLanguage(this);
        }
    }
}
