#pragma once


// CDlgUpgradeSelectDev �Ի���

class CDlgUpgradeSelectDev : public CDialog
{
	DECLARE_DYNAMIC(CDlgUpgradeSelectDev)

public:
	CDlgUpgradeSelectDev(CWnd* pParent = NULL);   // ��׼���캯��
	virtual ~CDlgUpgradeSelectDev();

// �Ի�������
	enum { IDD = IDD_DLG_UPGRADE_SELECT_DEV };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

	DECLARE_MESSAGE_MAP()
public:
    afx_msg void OnBnClickedBtnExit();
    afx_msg void OnBnClickedBtnOk();
    BOOL m_bHost;
    BOOL m_bLamp;
    BOOL m_bKey;
    BOOL m_bKeyBoard;
    BOOL m_bSwipeCard;
    BOOL m_bDisplay;
    virtual BOOL OnInitDialog();
    DWORD m_dwAcsNo;
    afx_msg void OnBnClickedChkUpgradeHost();
    afx_msg void OnBnClickedChkUpgradeDisplay();
    afx_msg void OnBnClickedChkUpgradeLamp();
    afx_msg void OnBnClickedChkUpgardeKey();
    afx_msg void OnBnClickedChkUpgradeKeyboard();
    afx_msg void OnBnClickedChkUrgradeCard();
};
