
// GDTC2022Uinty_RPGStatusDlg.h: 헤더 파일
//

#pragma once


// CGDTC2022UintyRPGStatusDlg 대화 상자
class CGDTC2022UintyRPGStatusDlg : public CDialogEx
{
// 생성입니다.
public:
	CGDTC2022UintyRPGStatusDlg(CWnd* pParent = nullptr);	// 표준 생성자입니다.

// 대화 상자 데이터입니다.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_GDTC2022UINTY_RPGSTATUS_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 지원입니다.


// 구현입니다.
protected:
	HICON m_hIcon;

	// 생성된 메시지 맵 함수
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:

	CEdit m_editHP;
	CEdit m_editName;
	CComboBox m_comboClass;
	afx_msg void OnDeltaposSpinHp(NMHDR* pNMHDR, LRESULT* pResult);

private:
	int m_nHP;
	int m_nBonus;
public:
	CStatic m_staticBonus;
};
