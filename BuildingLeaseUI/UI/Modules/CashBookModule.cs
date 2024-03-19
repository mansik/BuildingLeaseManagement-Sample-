
using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using BuildingLeaseUI.UI.Forms;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class CashBookModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly CashBookRepository _cashBookRepository = new CashBookRepository();
        private int _id = 0;
        /// <summary>
        /// 이월금
        /// </summary>
        private decimal _previousAmount = 0m;

        public CashBookModule()
        {
            InitializeComponent();

            //관리자가 아니면 수정 못하게
            if (!AppData.LogOn.GradeTypeID.Equals(1))
            {
                newButton.Enabled = false;
                deleteButton.Enabled = false;
                saveButton.Enabled = false;
            }
        }

        void ClearInput()
        {
            _id = 0;
            _previousAmount = 0;

            var configRepository = new ConfigRepository();
            var config = configRepository.GetFirst();
            int expenseNumber = 0;
            if (config != null)
                expenseNumber = config.LastExpenseNumber + 1;

            // 입금
            depositTransactionDateEdit.EditValue = DateTime.Today;
            depositBankBookLookUpEdit.EditValue = null;
            depositLesseeLookUpEdit.EditValue = null;
            depositTransactionDetailsTextEdit.Text = string.Empty;
            depositAccountCodeLookUpEdit.EditValue = null;
            depositAmountTextEdit.EditValue = 0m;
            depositNotesTextEdit.Text = string.Empty;
            // 출금
            withdrawalTransactionDateEdit.EditValue = DateTime.Today;
            withdrawalBankBookLookUpEdit.EditValue = null;
            withdrawalTransactionDetailsTextEdit.Text = string.Empty;
            withdrawalCreditorTextEdit.Text = string.Empty;
            withdrawalExpenseNumberSpinEdit.EditValue = expenseNumber;
            withdrawalAccountCodeLookUpEdit.EditValue = null;
            withdrawalAmountTextEdit.EditValue = 0m;
            withdrawalNotesTextEdit.EditValue = string.Empty;
            // 결손액
            lossTransactionDateEdit.EditValue = DateTime.Today;
            lossLesseeLookUpEdit.EditValue = null;
            lossTransactionDetailsTextEdit.Text = string.Empty;
            lossAccountCodeLookUpEdit.EditValue = null;
            lossAmountTextEdit.EditValue = 0m;
            lossNotesTextEdit.Text = string.Empty;
        }

        void DisplayInput()
        {
            if (gridView.GetFocusedRow() is CashBookDisplayModel cashBookDisplay)
            {
                // 모든 탭 활성화
                foreach (LayoutControlGroup tab in InputTab.TabPages.Cast<LayoutControlGroup>())
                {
                    tab.PageEnabled = true;
                }

                _id = cashBookDisplay.Id;
                // 입금
                if (cashBookDisplay.InOutgoings == 0)
                {
                    depositTransactionDateEdit.EditValue = cashBookDisplay.TransactionDate;
                    depositBankBookLookUpEdit.EditValue = cashBookDisplay.BankBookCodeId;
                    depositLesseeLookUpEdit.EditValue = cashBookDisplay.LesseeId;
                    depositTransactionDetailsTextEdit.Text = cashBookDisplay.TransactionDetails;
                    depositAccountCodeLookUpEdit.EditValue = cashBookDisplay.AccountCodeId;
                    depositAmountTextEdit.EditValue = cashBookDisplay.DepositAmount;
                    depositNotesTextEdit.Text = cashBookDisplay.Notes;

                    InputTab.SelectedTabPage = depositLayoutControlGroup;

                    // 선택안된 탭 비활성화
                    //withdrawalLayoutControlGroup.PageEnabled = false;
                    foreach (LayoutControlGroup tab in InputTab.TabPages.Cast<LayoutControlGroup>())
                    {
                        if (InputTab.SelectedTabPage != tab)
                            tab.PageEnabled = false;
                    }
                }
                // 출금
                if (cashBookDisplay.InOutgoings == 1)
                {
                    withdrawalTransactionDateEdit.EditValue = cashBookDisplay.TransactionDate;
                    withdrawalBankBookLookUpEdit.EditValue = cashBookDisplay.BankBookCodeId;
                    withdrawalTransactionDetailsTextEdit.Text = cashBookDisplay.TransactionDetails;
                    withdrawalCreditorTextEdit.Text = cashBookDisplay.Creditor;
                    withdrawalExpenseNumberSpinEdit.EditValue = cashBookDisplay.ExpenseNumber;
                    withdrawalAccountCodeLookUpEdit.EditValue = cashBookDisplay.AccountCodeId;
                    withdrawalAmountTextEdit.EditValue = cashBookDisplay.WithdrawalAmount;
                    withdrawalNotesTextEdit.EditValue = cashBookDisplay.Notes;

                    InputTab.SelectedTabPage = withdrawalLayoutControlGroup;

                    // 선택안된 탭 비활성화
                    foreach (LayoutControlGroup tab in InputTab.TabPages.Cast<LayoutControlGroup>())
                    {
                        if (InputTab.SelectedTabPage != tab)
                            tab.PageEnabled = false;
                    }
                }
                // 결손액
                if (cashBookDisplay.InOutgoings == 2)
                {
                    lossTransactionDateEdit.EditValue = cashBookDisplay.TransactionDate;
                    lossLesseeLookUpEdit.EditValue = cashBookDisplay.LesseeId;
                    lossTransactionDetailsTextEdit.Text = cashBookDisplay.TransactionDetails;
                    lossAccountCodeLookUpEdit.EditValue = cashBookDisplay.AccountCodeId;
                    lossAmountTextEdit.EditValue = cashBookDisplay.LossAmount;
                    lossNotesTextEdit.Text = cashBookDisplay.Notes;

                    InputTab.SelectedTabPage = lossLayoutControlGroup;

                    // 선택안된 탭 비활성화
                    //withdrawalLayoutControlGroup.PageEnabled = false;
                    foreach (LayoutControlGroup tab in InputTab.TabPages.Cast<LayoutControlGroup>())
                    {
                        if (InputTab.SelectedTabPage != tab)
                            tab.PageEnabled = false;
                    }
                }
            }
        }

        void LoadDataGridView(int? findId = null)
        {
            if (Convert.ToDateTime(searchFromDateEdit.EditValue).Date < Convert.ToDateTime("2024-01-01").Date
                && Convert.ToDateTime(searchToDateEdit.EditValue).Date > Convert.ToDateTime("2023-12-31").Date)
            {
                XtraMessageBox.Show("시작일자가 2024-01-01 이전일 경우 종료일자도 2024-01-01 이전으로 하여야 합니다." + Environment.NewLine +
                    "2024-01-01 이전과 이후의 이월금 및 수입금 합계, 차액 계산을 위함.", "확인");
                return;
            }

            // 이월금 계산: 2024-01-01년부터 사용시 2024-01-01이전에 입력된 "전년도 이월금(AccountCodeId: 5, 9)"은 이월금 계산에 포함하며, 수입액은 제외한다.
            // 입금액 계산: 2024-01-01이전에 입력된 수입은 입금액에서 제외요청 -> 프로그램상 안되어서 -> 조회기간을 선택할 때 2024-01-01 전과 후로 선택하도록 함.

            // 이월금
            _previousAmount = _cashBookRepository.GetPreviousAmountByDate(Convert.ToDateTime(searchFromDateEdit.EditValue));

            var getsDisplayByFromToDate = _cashBookRepository.GetsDisplayByFromToDate(
                Convert.ToDateTime(searchFromDateEdit.EditValue),
                Convert.ToDateTime(searchToDateEdit.EditValue)).Where(x => x.DelFlag == false).ToList();

            if (searchInOutgoingsLookUpEdit.Text != "전체" && searchInOutgoingsLookUpEdit.EditValue != null)
            {
                var inOutgoings = int.Parse(searchInOutgoingsLookUpEdit.EditValue.ToString());
                getsDisplayByFromToDate = getsDisplayByFromToDate.Where(x => x.InOutgoings == inOutgoings).ToList();
            }
            if (searchAccountCodeLookUpEdit.Text != "전체" && searchAccountCodeLookUpEdit.EditValue != null)
            {
                var accountCodeId = int.Parse(searchAccountCodeLookUpEdit.EditValue.ToString());
                getsDisplayByFromToDate = getsDisplayByFromToDate.Where(x => x.AccountCodeId == accountCodeId).ToList();
            }
            if (searchLesseeLookUpEdit.Text != "전체" && searchLesseeLookUpEdit.EditValue != null)
            {
                var lesseeId = int.Parse(searchLesseeLookUpEdit.EditValue.ToString());
                getsDisplayByFromToDate = getsDisplayByFromToDate.Where(x => x.LesseeId == lesseeId).ToList();
            }

            gridControl.DataSource = getsDisplayByFromToDate;
            gridView.UpdateTotalSummary();

            if (findId != null)
            {
                int rowHandle = gridView.LocateByValue("Id", findId);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                    gridView.FocusedRowHandle = rowHandle;
            }
        }

        private void CashBookModule_Load(object sender, System.EventArgs e)
        {
            InputTab.SelectedTabPage = depositLayoutControlGroup; //이것이 생성자로 가면 출금탭이 선택되어 있을 경우 오류 발생한다. 

            #region Input
            // 통장
            var bankBookCodeRepository = new BankBookCodeRepository();
            var bankBookCodes = bankBookCodeRepository.GetAll().Select(x => new { x.Id, x.BankBookName, x.BankName, x.AccountNumber }).ToList();
            depositBankBookLookUpEdit.Properties.DataSource = bankBookCodes;
            depositBankBookLookUpEdit.Properties.DisplayMember = "BankBookName";
            depositBankBookLookUpEdit.Properties.ValueMember = "Id";
            depositBankBookLookUpEdit.Properties.ForceInitialize();
            depositBankBookLookUpEdit.Properties.PopulateColumns();
            depositBankBookLookUpEdit.Properties.Columns["Id"].Visible = false;

            withdrawalBankBookLookUpEdit.Properties.DataSource = bankBookCodes;
            withdrawalBankBookLookUpEdit.Properties.DisplayMember = "BankBookName";
            withdrawalBankBookLookUpEdit.Properties.ValueMember = "Id";
            withdrawalBankBookLookUpEdit.Properties.ForceInitialize();
            withdrawalBankBookLookUpEdit.Properties.PopulateColumns();
            withdrawalBankBookLookUpEdit.Properties.Columns["Id"].Visible = false;

            // 임차인            
            var lesseeRepository = new LesseeRepository();
            depositLesseeLookUpEdit.Properties.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee }).ToList();
            depositLesseeLookUpEdit.Properties.DisplayMember = "Lessee";
            depositLesseeLookUpEdit.Properties.ValueMember = "Id";
            depositLesseeLookUpEdit.Properties.ForceInitialize();
            depositLesseeLookUpEdit.Properties.PopulateColumns();
            depositLesseeLookUpEdit.Properties.Columns["Id"].Visible = false;

            lossLesseeLookUpEdit.Properties.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee }).ToList();
            lossLesseeLookUpEdit.Properties.DisplayMember = "Lessee";
            lossLesseeLookUpEdit.Properties.ValueMember = "Id";
            lossLesseeLookUpEdit.Properties.ForceInitialize();
            lossLesseeLookUpEdit.Properties.PopulateColumns();
            lossLesseeLookUpEdit.Properties.Columns["Id"].Visible = false;

            // 계정과목
            var accountCodeRepository = new AccountCodeRepository();
            var accountCodes = accountCodeRepository.GetAllDisplay();
            depositAccountCodeLookUpEdit.Properties.DataSource = accountCodes.Where(x => x.InOutgoings == 0).ToList();
            depositAccountCodeLookUpEdit.Properties.DisplayMember = "AccountName";
            depositAccountCodeLookUpEdit.Properties.ValueMember = "Id";
            // 디자인모드에서 작업 => 컬럼명을 지정하기 위해서
            //depositAccountCodeLookUpEdit.Properties.ForceInitialize();
            //depositAccountCodeLookUpEdit.Properties.PopulateColumns();
            //depositAccountCodeLookUpEdit.Properties.Columns["Id"].Visible = false;
            //depositAccountCodeLookUpEdit.Properties.Columns["InOutgoings"].Visible = false;            

            withdrawalAccountCodeLookUpEdit.Properties.DataSource = accountCodes.Where(x => x.InOutgoings == 1).ToList();
            withdrawalAccountCodeLookUpEdit.Properties.DisplayMember = "AccountName";
            withdrawalAccountCodeLookUpEdit.Properties.ValueMember = "Id";

            // 결손액의 계정과목은 수입을 따름.
            lossAccountCodeLookUpEdit.Properties.DataSource = accountCodes.Where(x => x.InOutgoings == 0).ToList();
            lossAccountCodeLookUpEdit.Properties.DisplayMember = "AccountName";
            lossAccountCodeLookUpEdit.Properties.ValueMember = "Id";

            #endregion

            #region Search
            searchFromDateEdit.EditValue = DateTime.Today; //시간은 오전12:00:00
            searchToDateEdit.EditValue = DateTime.Today;

            // 입/출금
            searchInOutgoingsLookUpEdit.Properties.DataSource = new List<InOutgoingsModel>
            {
                new InOutgoingsModel() { Id = 3, InOutgoingsName = "전체" },
                new InOutgoingsModel() { Id = 0, InOutgoingsName = "입금" },
                new InOutgoingsModel() { Id = 1, InOutgoingsName = "출금" },
                new InOutgoingsModel() { Id = 2, InOutgoingsName = "결손액" }
            };
            //searchInOutgoingslookUpEdit.Properties.DisplayMember = nameof(InOutgoingsModel.InOutgoingsName); // 이렇게도 사용
            searchInOutgoingsLookUpEdit.Properties.DisplayMember = "InOutgoingsName";
            searchInOutgoingsLookUpEdit.Properties.ValueMember = "Id";
            searchInOutgoingsLookUpEdit.Properties.ForceInitialize();
            searchInOutgoingsLookUpEdit.Properties.PopulateColumns();
            searchInOutgoingsLookUpEdit.Properties.Columns["Id"].Visible = false;
            if ((searchInOutgoingsLookUpEdit.Properties.DataSource as List<InOutgoingsModel>).Count > 0)
            {
                searchInOutgoingsLookUpEdit.ItemIndex = 0;
            }

            //계정과목
            // searchInOutgoingsLookUpEdit_EditValueChanged() 에서 작업함.
            //accountCodes.Clear();
            //accountCodes.Add(new AccountCodeDisplayModel() { Id = 99, AccountHangName = "전체", AccountName = "전체" });
            //accountCodes.AddRange(accountCodeRepository.GetAllDisplay());
            //searchAccountCodeLookUpEdit.Properties.DataSource = accountCodes;
            //searchAccountCodeLookUpEdit.Properties.DisplayMember = "AccountName";
            //searchAccountCodeLookUpEdit.Properties.ValueMember = "Id";
            //// 디자인모드에서 작업 => 컬럼명을 지정하기 위해서
            ////searchAccountCodeLookUpEdit.Properties.ForceInitialize();
            ////searchAccountCodeLookUpEdit.Properties.PopulateColumns();
            ////searchAccountCodeLookUpEdit.Properties.Columns["Id"].Visible = false;
            ////searchAccountCodeLookUpEdit.Properties.Columns["InOutgoings"].Visible = false;
            //if (accountCodes.Count > 0)
            //{
            //    searchAccountCodeLookUpEdit.ItemIndex = 0;
            //}

            // 임차인
            var lessees = new List<object>
            {
                new { Id = 9999, Lessee = "전체" }
            };
            lessees.AddRange(lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee }).ToList());
            searchLesseeLookUpEdit.Properties.DataSource = lessees;
            searchLesseeLookUpEdit.Properties.DisplayMember = "Lessee";
            searchLesseeLookUpEdit.Properties.ValueMember = "Id";
            searchLesseeLookUpEdit.Properties.ForceInitialize();
            searchLesseeLookUpEdit.Properties.PopulateColumns();
            searchLesseeLookUpEdit.Properties.Columns["Id"].Visible = false;
            if (lessees.Count > 0)
            {
                searchLesseeLookUpEdit.ItemIndex = 0;
            }
            #endregion

            ClearInput();
            //LoadDataGridView(); // 위 searchInOutgoingslookUpEdit.ItemIndex = 0; 에서 조회가 일어남
            newButton.PerformClick();
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                ClearInput();
                DisplayInput();
            }
        }

        private void gridView_ColumnFilterChanged(object sender, System.EventArgs e)
        {
            ClearInput();
            DisplayInput();
        }

        private void gridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            ClearInput();
            DisplayInput();
        }

        private void gridView_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Value is decimal || e.Value is int)
                if (Convert.ToDecimal(e.Value) == 0)
                    e.DisplayText = string.Empty;
        }

        private void newButton_Click(object sender, System.EventArgs e)
        {
            ClearInput(); //_xxxId = 0;를 위해서 필요

            // 모든 탭 활성화
            foreach (LayoutControlGroup tab in InputTab.TabPages.Cast<LayoutControlGroup>())
            {
                tab.PageEnabled = true;
            }

            if (InputTab.SelectedTabPage == depositLayoutControlGroup)
                depositTransactionDateEdit.Focus();
            else if (InputTab.SelectedTabPage == withdrawalLayoutControlGroup)
                withdrawalTransactionDateEdit.Focus();
            else if (InputTab.SelectedTabPage == lossLayoutControlGroup)
                lossTransactionDateEdit.Focus();
        }

        private void deleteButton_Click(object sender, System.EventArgs e)
        {
            if (_id != 0)
            {
                var transactionDate = string.Empty;
                if (InputTab.SelectedTabPage == depositLayoutControlGroup)
                    transactionDate = depositTransactionDateEdit.Text;
                else if (InputTab.SelectedTabPage == withdrawalLayoutControlGroup)
                    transactionDate = withdrawalTransactionDateEdit.Text;
                else if (InputTab.SelectedTabPage == lossLayoutControlGroup)
                    transactionDate = lossTransactionDateEdit.Text;

                var amount = string.Empty;
                if (InputTab.SelectedTabPage == depositLayoutControlGroup)
                    amount = depositAmountTextEdit.Text;
                else if (InputTab.SelectedTabPage == withdrawalLayoutControlGroup)
                    amount = withdrawalAmountTextEdit.Text;
                else if (InputTab.SelectedTabPage == lossLayoutControlGroup)
                    amount = lossAmountTextEdit.Text;

                if (XtraMessageBox.Show($"거래일자 {transactionDate}의 금액 {amount}를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var isDelete = _cashBookRepository.Delete(_id);
                    if (isDelete)
                    {
                        ClearInput(); //_userId = 0;를 위해서 필요
                        LoadDataGridView();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, System.EventArgs e)
        {
            int? focuseId;

            if (InputTab.SelectedTabPage == depositLayoutControlGroup)
            {
                if (depositBankBookLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("통장을 선택해 주세요.", "확인");
                    depositBankBookLookUpEdit.ShowPopup();
                    return;
                }
                // 예금이자는 임차인 및 내용을 선택하지 않는다.
                if (depositAccountCodeLookUpEdit.Text != "예금이자")
                {
                    if (depositLesseeLookUpEdit.EditValue == null)
                    {
                        XtraMessageBox.Show("임차인을 선택해 주세요.", "확인");
                        depositLesseeLookUpEdit.ShowPopup();
                        return;
                    }
                    if (string.IsNullOrEmpty(depositTransactionDetailsTextEdit.Text))
                    {
                        XtraMessageBox.Show("내용을 입력해 주세요.", "확인");
                        depositTransactionDetailsTextEdit.Focus();
                        return;
                    }
                }
                if (depositAccountCodeLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("항목을 선택해 주세요.", "확인");
                    depositAccountCodeLookUpEdit.ShowPopup();
                    return;
                }
                if (Convert.ToDecimal(depositAmountTextEdit.EditValue) == 0)
                {
                    XtraMessageBox.Show("입금액을 입력해 주세요.", "확인");
                    depositAmountTextEdit.Focus();
                    return;
                }
            }
            else if (InputTab.SelectedTabPage == withdrawalLayoutControlGroup)
            {
                if (withdrawalBankBookLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("통장을 선택해 주세요.", "확인");
                    withdrawalBankBookLookUpEdit.ShowPopup();
                    return;
                }
                if (string.IsNullOrEmpty(withdrawalTransactionDetailsTextEdit.Text))
                {
                    XtraMessageBox.Show("적요를 입력해 주세요.", "확인");
                    withdrawalTransactionDetailsTextEdit.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(withdrawalCreditorTextEdit.Text))
                {
                    XtraMessageBox.Show("채주를 입력해 주세요.", "확인");
                    withdrawalCreditorTextEdit.Focus();
                    return;
                }
                if (withdrawalExpenseNumberSpinEdit.Value == 0)
                {
                    XtraMessageBox.Show("지출번호를 입력해 주세요.", "확인");
                    withdrawalExpenseNumberSpinEdit.Focus();
                    return;
                }
                if (withdrawalAccountCodeLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("항목을 선택해 주세요.", "확인");
                    withdrawalAccountCodeLookUpEdit.ShowPopup();
                    return;
                }
                if (Convert.ToDecimal(withdrawalAmountTextEdit.EditValue) == 0)
                {
                    XtraMessageBox.Show("출금액을 입력해 주세요.", "확인");
                    withdrawalAmountTextEdit.Focus();
                    return;
                }
            }
            else if (InputTab.SelectedTabPage == lossLayoutControlGroup)
            {
                if (lossLesseeLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("임차인을 선택해 주세요.", "확인");
                    lossLesseeLookUpEdit.ShowPopup();
                    return;
                }
                if (string.IsNullOrEmpty(lossTransactionDetailsTextEdit.Text))
                {
                    XtraMessageBox.Show("내용을 입력해 주세요.", "확인");
                    lossTransactionDetailsTextEdit.Focus();
                    return;
                }
                if (lossAccountCodeLookUpEdit.EditValue == null)
                {
                    XtraMessageBox.Show("항목을 선택해 주세요.", "확인");
                    lossAccountCodeLookUpEdit.ShowPopup();
                    return;
                }
                if (Convert.ToDecimal(lossAmountTextEdit.EditValue) == 0)
                {
                    XtraMessageBox.Show("결손액을 입력해 주세요.", "확인");
                    lossAmountTextEdit.Focus();
                    return;
                }
            }

            CashBookModel cashBook = null;
            if (InputTab.SelectedTabPage == depositLayoutControlGroup)
            {
                int? lesseeId = null;
                if (depositLesseeLookUpEdit.EditValue != null)
                    lesseeId = int.Parse(depositLesseeLookUpEdit.EditValue.ToString());

                int? accountCodeId = null;
                if (depositAccountCodeLookUpEdit.EditValue != null)
                    accountCodeId = int.Parse(depositAccountCodeLookUpEdit.EditValue.ToString());

                int? bankBookCodeId = null;
                if (depositBankBookLookUpEdit.EditValue != null)
                    bankBookCodeId = int.Parse(depositBankBookLookUpEdit.EditValue.ToString());

                cashBook = new CashBookModel()
                {
                    TransactionDate = Convert.ToDateTime(depositTransactionDateEdit.EditValue).Date, // 시간은 오전12:00:00
                    TransactionDetails = depositTransactionDetailsTextEdit.Text,
                    BankBookCodeId = bankBookCodeId,
                    LesseeId = lesseeId,
                    AccountCodeId = accountCodeId,
                    Creditor = string.Empty,
                    ExpenseNumber = 0,
                    DepositAmount = Convert.ToDecimal(depositAmountTextEdit.EditValue),
                    WithdrawalAmount = 0,
                    LossAmount = 0,
                    Notes = depositNotesTextEdit.Text,
                    InOutgoings = 0,
                    DelFlag = false,
                    InsertUserId = AppData.LogOn.UserID,
                    UpdateUserId = AppData.LogOn.UserID
                };
            }
            else if (InputTab.SelectedTabPage == withdrawalLayoutControlGroup)
            {
                int? accountCodeId = null;
                if (withdrawalAccountCodeLookUpEdit.EditValue != null)
                    accountCodeId = int.Parse(withdrawalAccountCodeLookUpEdit.EditValue.ToString());

                int? bankBookCodeId = null;
                if (withdrawalBankBookLookUpEdit.EditValue != null)
                    bankBookCodeId = int.Parse(withdrawalBankBookLookUpEdit.EditValue.ToString());

                cashBook = new CashBookModel()
                {
                    TransactionDate = Convert.ToDateTime(withdrawalTransactionDateEdit.EditValue).Date,
                    TransactionDetails = withdrawalTransactionDetailsTextEdit.Text,
                    BankBookCodeId = bankBookCodeId,
                    LesseeId = null,
                    AccountCodeId = accountCodeId,
                    Creditor = withdrawalCreditorTextEdit.Text,
                    ExpenseNumber = Convert.ToInt32(withdrawalExpenseNumberSpinEdit.EditValue), // 지출번호 입력이 안되면 0
                    DepositAmount = 0,
                    WithdrawalAmount = Convert.ToDecimal(withdrawalAmountTextEdit.EditValue),
                    LossAmount = 0,
                    Notes = withdrawalNotesTextEdit.Text,
                    InOutgoings = 1,
                    DelFlag = false,
                    InsertUserId = AppData.LogOn.UserID,
                    UpdateUserId = AppData.LogOn.UserID
                };
            }
            else if (InputTab.SelectedTabPage == lossLayoutControlGroup)
            {
                int? lesseeId = null;
                if (lossLesseeLookUpEdit.EditValue != null)
                    lesseeId = int.Parse(lossLesseeLookUpEdit.EditValue.ToString());

                int? accountCodeId = null;
                if (lossAccountCodeLookUpEdit.EditValue != null)
                    accountCodeId = int.Parse(lossAccountCodeLookUpEdit.EditValue.ToString());

                cashBook = new CashBookModel()
                {
                    TransactionDate = Convert.ToDateTime(lossTransactionDateEdit.EditValue).Date, // 시간은 오전12:00:00
                    TransactionDetails = lossTransactionDetailsTextEdit.Text,
                    BankBookCodeId = null,
                    LesseeId = lesseeId,
                    AccountCodeId = accountCodeId,
                    Creditor = string.Empty,
                    ExpenseNumber = 0,
                    DepositAmount = 0,
                    WithdrawalAmount = 0,
                    LossAmount = Convert.ToDecimal(lossAmountTextEdit.EditValue),
                    Notes = lossNotesTextEdit.Text,
                    InOutgoings = 2,
                    DelFlag = false,
                    InsertUserId = AppData.LogOn.UserID,
                    UpdateUserId = AppData.LogOn.UserID
                };
            }

            try
            {
                if (_id == 0)
                {
                    focuseId = _cashBookRepository.Insert(cashBook);
                }
                else
                {
                    cashBook.Id = _id;
                    _cashBookRepository.Update(cashBook);
                    focuseId = cashBook.Id;
                }

                // ExpenseNumber를 Config에 저장
                if (cashBook.InOutgoings == 1)
                {
                    var configRepository = new ConfigRepository();
                    configRepository.LastExpenseNumber_InsertUpdate(cashBook.ExpenseNumber);
                }
                ClearInput(); //_userId = 0;를 위해서 필요
                LoadDataGridView(focuseId);
                newButton.PerformClick();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
            }
        }

        private void searchToDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            ClearInput();
            LoadDataGridView();
        }

        private void searchFromDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            ClearInput();
            LoadDataGridView();
        }

        private void searchInOutgoingsLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (searchInOutgoingsLookUpEdit.EditValue == null)
            {
                searchAccountCodeLookUpEdit.Clear();
                searchAccountCodeLookUpEdit.Properties.DataSource = null;
                return;
            }

            //계정과목
            var accountCodeRepository = new AccountCodeRepository();
            var accountCodes = new List<AccountCodeDisplayModel>
            {
                new AccountCodeDisplayModel() { Id = 99, AccountHangName = "전체", AccountName = "전체" }
            };

            if (Convert.ToInt16(searchInOutgoingsLookUpEdit.EditValue) == 0 || Convert.ToInt16(searchInOutgoingsLookUpEdit.EditValue) == 2)
                accountCodes.AddRange(accountCodeRepository.GetAllDisplay().Where(x => x.InOutgoings == 0));
            else if (Convert.ToInt16(searchInOutgoingsLookUpEdit.EditValue) == 1)
                accountCodes.AddRange(accountCodeRepository.GetAllDisplay().Where(x => x.InOutgoings == 1));
            else
                accountCodes.AddRange(accountCodeRepository.GetAllDisplay());

            searchAccountCodeLookUpEdit.Clear(); //필수, searchAccountCodeLookUpEdit_EditValueChanged가 먹히기 위해서
            searchAccountCodeLookUpEdit.Properties.DataSource = accountCodes;
            searchAccountCodeLookUpEdit.Properties.DisplayMember = "AccountName";
            searchAccountCodeLookUpEdit.Properties.ValueMember = "Id";
            if (accountCodes.Count > 0)
            {
                searchAccountCodeLookUpEdit.ItemIndex = 0;
            }
        }

        private void searchAccountCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ClearInput();
            LoadDataGridView();
        }

        private void searchLesseeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ClearInput();
            LoadDataGridView();
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            ClearInput();
            LoadDataGridView();
        }

        private void printButton_Click(object sender, System.EventArgs e)
        {
            if (gridControl.DataSource != null)
            {
                using (var printForm = new PrintForm())
                {
                    var fromDate = Convert.ToDateTime(searchFromDateEdit.EditValue).Date;
                    var toDate = Convert.ToDateTime(searchToDateEdit.EditValue).Date;
                    var InOutgoingsName = searchInOutgoingsLookUpEdit.Text;
                    var accountName = searchAccountCodeLookUpEdit.Text;
                    var lessee = searchLesseeLookUpEdit.Text;
                    var previousMonthAmount = _previousAmount;

                    printForm.CashBookPrint(fromDate, toDate, InOutgoingsName, accountName, lessee, previousMonthAmount, gridControl.DataSource);
                    printForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 차액을 계산하기 위해서 사용 
        /// FieldName = SumDefferenceAmount (임의의 명칭을 만들었음.)
        /// SummaryType = SummaryItemType.Custom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            //GridView view = sender as GridView;
            if (e.IsTotalSummary)
            {
                GridSummaryItem item = e.Item as GridSummaryItem;
                if (item.FieldName == "SumPreviousAmount")
                {
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            break;
                        case CustomSummaryProcess.Calculate:
                            break;
                        case CustomSummaryProcess.Finalize:
                            e.TotalValue = _previousAmount;
                            break;
                    }
                }

                if (item.FieldName == "SumDefferenceAmount")
                {
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            break;
                        case CustomSummaryProcess.Calculate:
                            break;
                        case CustomSummaryProcess.Finalize:
                            decimal sumDepositAmount = 0m;
                            decimal sumWithdrawalAmount = 0m;
                            decimal sumLossAmount = 0m;
                            for (int rowIndex = 0; rowIndex < gridView.DataRowCount; rowIndex++)
                            {
                                sumDepositAmount += Convert.ToDecimal(gridView.GetRowCellValue(rowIndex, gridView.Columns["DepositAmount"]));
                                sumWithdrawalAmount += Convert.ToDecimal(gridView.GetRowCellValue(rowIndex, gridView.Columns["WithdrawalAmount"]));
                                sumLossAmount += Convert.ToDecimal(gridView.GetRowCellValue(rowIndex, gridView.Columns["LossAmount"]));
                            }
                            e.TotalValue = sumDepositAmount - sumWithdrawalAmount - sumLossAmount;
                            break;
                    }
                }
            }

        }
    }
}