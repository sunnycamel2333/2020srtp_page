// DlgUploadHdFile.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "ClientDemo.h"
#include "DlgUploadHdFile.h"
#include "afxdialogex.h"


// CDlgUploadHdFile �Ի���

IMPLEMENT_DYNAMIC(CDlgUploadHdFile, CDialogEx)

CDlgUploadHdFile::CDlgUploadHdFile(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDlgUploadHdFile::IDD, pParent)
    , m_csUploadPath(_T(""))
    , m_csDownloadPath(_T(""))
{

    m_lUploadHandle = -1;
    m_lDownloadHandle = -1;
    m_dwFileSize = 0;
}

CDlgUploadHdFile::~CDlgUploadHdFile()
{
}

void CDlgUploadHdFile::DoDataExchange(CDataExchange* pDX)
{
    CDialogEx::DoDataExchange(pDX);
    DDX_Control(pDX, IDC_COMBO_CHANNEL, m_comChannel);
    DDX_Text(pDX, IDC_EDIT_UPLOAD_FILE_PATH, m_csUploadPath);
    DDX_Control(pDX, IDC_COMBO_UPLOAD_FILE_TYPE, m_comUploadType);
    DDX_Control(pDX, IDC_COMBO_DOWNLOAD_FILE_TYPE, m_comDownloadType);
    DDX_Text(pDX, IDC_EDIT_DOWNLOAD_FILE_PATH, m_csDownloadPath);
}


BEGIN_MESSAGE_MAP(CDlgUploadHdFile, CDialogEx)
    ON_BN_CLICKED(IDC_BTN_FILE_PATH_UPLOAD_FILE, &CDlgUploadHdFile::OnBnClickedBtnFilePathUploadFile)
    ON_BN_CLICKED(IDC_BTN_FILE_UPLOAD_3200W_FILE, &CDlgUploadHdFile::OnBnClickedBtnFileUpload3200wFile)
    ON_BN_CLICKED(IDC_BTN_FILE_PATH_DOWNLOAD_FILE, &CDlgUploadHdFile::OnBnClickedBtnFilePathDownloadFile)
    ON_BN_CLICKED(IDC_BTN_FILE_DOWNLOAD_3200W_FILE, &CDlgUploadHdFile::OnBnClickedBtnFileDownload3200wFile)
END_MESSAGE_MAP()


// CDlgUploadHdFile ��Ϣ�������

BOOL CDlgUploadHdFile::OnInitDialog()
{
    CDialogEx::OnInitDialog();

    m_comChannel.ResetContent();
    DWORD dwIndex = 0;
    int i = 0;

    for (i = 0; i < g_struDeviceInfo[m_iDevIndex].iDeviceChanNum; i++)
    {
        m_comChannel.AddString(g_struDeviceInfo[m_iDevIndex].pStruChanInfo[i].chChanName);
        m_comChannel.SetItemData(dwIndex++, g_struDeviceInfo[m_iDevIndex].pStruChanInfo[i].iChannelNO);
    }
    m_comChannel.SetCurSel(0);
    m_comUploadType.SetCurSel(0);
    m_comDownloadType.SetCurSel(0);

    return TRUE;  // return TRUE unless you set the focus to a control
    // �쳣:  OCX ����ҳӦ���� FALSE
}


void CDlgUploadHdFile::OnBnClickedBtnFilePathUploadFile()
{
    // TODO:  �ڴ���ӿؼ�֪ͨ����������
    static char szFilter[] = "All File(*.*)|*.*||";
    CFileDialog fileDlg(TRUE, "*.*", NULL, OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, szFilter);
    if (fileDlg.DoModal() == IDOK)
    {
        m_csUploadPath = fileDlg.GetPathName();
        UpdateData(FALSE);
    }
}


void CDlgUploadHdFile::OnBnClickedBtnFileUpload3200wFile()
{
    // TODO:  �ڴ���ӿؼ�֪ͨ����������
    UpdateData(TRUE);

    char szFileName[MAX_PATH];
    strcpy(szFileName, m_csUploadPath);
    CFile cFile;
    char szLan[128] = { 0 };
    if (!cFile.Open(szFileName, NULL))
    {
        g_StringLanType(szLan, "���ļ�ʧ�ܻ��޴��ļ�", "Open file failed or no this file");
        AfxMessageBox(szLan);
        return;
    }
    m_dwFileSize = (DWORD)cFile.GetLength();
    if (m_dwFileSize == 0)
    {
        g_StringLanType(szLan, "�ļ�Ϊ��", "File is empty");
        AfxMessageBox(szLan);
    }
    cFile.Close();

    m_byChannel = m_comChannel.GetItemData(m_comChannel.GetCurSel());
    if (m_comUploadType.GetCurSel() == 0)
    {
        NET_DVR_CORRECT_TABLE_3200W_PARAM struCorrectTable3200WParam = { 0 };
        struCorrectTable3200WParam.dwSize = sizeof(struCorrectTable3200WParam);
        struCorrectTable3200WParam.dwFileLen = m_dwFileSize;
        struCorrectTable3200WParam.byChannel = m_byChannel;
        m_lUploadHandle = NET_DVR_UploadFile_V40(m_lServerID, UPLOAD_HD_CAMERA_CORRECT_TABLE_3200W_FILE, &struCorrectTable3200WParam, sizeof(struCorrectTable3200WParam), szFileName, NULL, 0);
        if (-1 == m_lUploadHandle)
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_FAIL_T, "NET_DVR_UploadFile_V40 UPLOAD_HD_CAMERA_CORRECT_TABLE_3200W_FILE");
            AfxMessageBox("NET_DVR_UploadFile_V40 failed");
        }
        else
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_SUCC_T, "NET_DVR_UploadFile_V40 UPLOAD_HD_CAMERA_CORRECT_TABLE_3200W_FILE");
            Sleep(50);
        }
    }
    else if (m_comUploadType.GetCurSel() == 1)
    {
        NET_DVR_CLIENT_CALIBFILE_PARAM struClientCalibfileParam = { 0 };
        struClientCalibfileParam.dwSize = sizeof(struClientCalibfileParam);
        struClientCalibfileParam.dwFileLen = m_dwFileSize;
        struClientCalibfileParam.byChannel = m_byChannel;
        m_lUploadHandle = NET_DVR_UploadFile_V40(m_lServerID, UPLOAD_CLIENT_CALIBFILE_FILE, &struClientCalibfileParam, sizeof(struClientCalibfileParam), szFileName, NULL, 0);
        if (-1 == m_lUploadHandle)
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_FAIL_T, "NET_DVR_UploadFile_V40 UPLOAD_CLIENT_CALIBFILE_FILE");
            AfxMessageBox("NET_DVR_UploadFile_V40 failed");
        }
        else
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_SUCC_T, "NET_DVR_UploadFile_V40 UPLOAD_CLIENT_CALIBFILE_FILE");
            Sleep(50);
        }
    }
    else
    {
        ;
    }
    UpdateData(FALSE);
}


void CDlgUploadHdFile::OnBnClickedBtnFilePathDownloadFile()
{
    // TODO:  �ڴ���ӿؼ�֪ͨ����������
    CString strFilter = _T("All Files(*.*)|*.*||");
    CFileDialog fileChose(FALSE, NULL, NULL, OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT, strFilter);
    if (fileChose.DoModal() != IDOK)
    {
        return;
    }
    m_csDownloadPath = fileChose.GetPathName();
    GetDlgItem(IDC_EDIT_DOWNLOAD_FILE_PATH)->SetWindowText(m_csDownloadPath);
}


void CDlgUploadHdFile::OnBnClickedBtnFileDownload3200wFile()
{
    // TODO:  �ڴ���ӿؼ�֪ͨ����������
    UpdateData(TRUE);

    char szLan[128] = { 0 };

    m_byChannel = m_comChannel.GetItemData(m_comChannel.GetCurSel());
    if (m_comDownloadType.GetCurSel() == 0)
    {
        NET_DVR_CORRECT_TABLE_3200W_PARAM struCorrectTable3200WParam = { 0 };
        struCorrectTable3200WParam.dwSize = sizeof(struCorrectTable3200WParam);
        struCorrectTable3200WParam.byChannel = m_byChannel;

        m_lDownloadHandle = NET_DVR_StartDownload(m_lServerID, NET_SDK_DOWNLOAD_HD_CAMERA_CORRECT_TABLE_FILE, &struCorrectTable3200WParam, sizeof(struCorrectTable3200WParam), m_csDownloadPath.GetBuffer(0));
        if (m_lDownloadHandle == -1)
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_FAIL_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_HD_CAMERA_CORRECT_TABLE_FILE");
            AfxMessageBox("NET_DVR_StartDownload failed");
        }
        else
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_SUCC_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_HD_CAMERA_CORRECT_TABLE_FILE");

        }
    }
    else if (m_comDownloadType.GetCurSel() == 1)
    {
        NET_DVR_CLIENT_CALIBFILE_PARAM struClientCalibfileParam = { 0 };
        struClientCalibfileParam.dwSize = sizeof(struClientCalibfileParam);
        struClientCalibfileParam.byChannel = m_byChannel;

        m_lDownloadHandle = NET_DVR_StartDownload(m_lServerID, NET_SDK_DOWNLOAD_CLIENT_CALIBFILE_FILE, &struClientCalibfileParam, sizeof(struClientCalibfileParam), m_csDownloadPath.GetBuffer(0));
        if (m_lDownloadHandle == -1)
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_FAIL_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_CLIENT_CALIBFILE_FILE");
            AfxMessageBox("NET_DVR_StartDownload failed");
        }
        else
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_SUCC_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_CLIENT_CALIBFILE_FILE");
        }
    }
    else if (m_comDownloadType.GetCurSel() == 2)
    {
        NET_DVR_FOUR_CAMERAS_PICTURES struFourCamerasPictures = { 0 };
        struFourCamerasPictures.dwSize = sizeof(struFourCamerasPictures);
        struFourCamerasPictures.byChannel = m_byChannel;

        m_lDownloadHandle = NET_DVR_StartDownload(m_lServerID, NET_SDK_DOWNLOAD_FOUR_CAMERAS_PICTURES_FILE, &struFourCamerasPictures, sizeof(struFourCamerasPictures), m_csDownloadPath.GetBuffer(0));
        if (m_lDownloadHandle == -1)
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_FAIL_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_FOUR_CAMERAS_PICTURES_FILE");
            AfxMessageBox("NET_DVR_StartDownload failed");
        }
        else
        {
            g_pMainDlg->AddLog(m_iDevIndex, OPERATION_SUCC_T, "NET_DVR_StartDownload NET_SDK_DOWNLOAD_FOUR_CAMERAS_PICTURES_FILE");
        }
    }
    else
    {
        ;
    }

    UpdateData(FALSE);
}



