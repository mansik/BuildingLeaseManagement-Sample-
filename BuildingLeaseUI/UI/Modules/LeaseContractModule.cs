using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class LeaseContractModule : DevExpress.DXperience.Demos.TutorialControlBase //DevExpress.XtraEditors.XtraUserControl
    {
        private readonly LeaseContractRepository _contractRepository = new LeaseContractRepository();
        private int _lesseeId = 0;
        private int _contractId = 0;

        public LeaseContractModule()
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
        void ClearLesseeInput()
        {
            _lesseeId = 0;
            lesseeTextEdit.Text = string.Empty;
            ownerTextEdit.Text = string.Empty;
            rrnTextEdit.Text = string.Empty;
            brnTextEdit.Text = string.Empty;
            contactTextEdit.Text = string.Empty;
            underContractFlagCheckEdit.EditValue = null;
            lesseeNotesTextEdit.Text = string.Empty;

            //우측 등록화면
            lesseeTopTextEdit.Text = string.Empty;

            ClearContractInput();
            LoadDataContractGridView();
        }
        void DisplayLesseeInput()
        {
            if (lesseeGridView.GetFocusedRow() is LesseeModel lessee)
            {
                _lesseeId = lessee.Id;
                lesseeTextEdit.EditValue = lessee.Lessee;
                ownerTextEdit.EditValue = lessee.Owner;
                rrnTextEdit.EditValue = lessee.RRN;
                brnTextEdit.EditValue = lessee.BRN;
                contactTextEdit.EditValue = lessee.Contact;
                underContractFlagCheckEdit.EditValue = lessee.UnderContractFlag;
                lesseeNotesTextEdit.EditValue = lessee.Notes;

                //우측 등록화면
                lesseeTopTextEdit.EditValue = lessee.Lessee;

                ClearContractInput();
                LoadDataContractGridView();
            }
        }

        void LoadDataLesseeGridView()
        {
            var _lesseeRepository = new LesseeRepository();
            lesseeGridControl.DataSource = _lesseeRepository.GetAll();
        }

        void ClearContractInput()
        {
            _contractId = 0;
            contractStartDateEdit.EditValue = null;
            contractEndDateEdit.EditValue = null;
            buildingNameLookUpEdit.EditValue = null;
            floorLookUpEdit.EditValue = null;
            roomLookUpEdit.EditValue = null;
            depositTextEdit.EditValue = 0;
            monthlyRentTextEdit.EditValue = 0;
            monthlyRentVATTextEdit.EditValue = 0;
            monthlyRentTotalEdit.EditValue = 0;
            maintenanceFeeTextEdit.EditValue = 0;
            maintenanceFeeVATTextEdit.EditValue = 0;
            maintenanceFeeTotalTextEdit.EditValue = 0;
            notesTextEdit.Text = string.Empty;
        }

        void DisplayContractInput()
        {
            if (contractGridView.GetFocusedRow() is LeaseContractDisplayModel contractDisplay)
            {
                _contractId = contractDisplay.Id;
                contractStartDateEdit.EditValue = contractDisplay.ContractStartDate;
                contractEndDateEdit.EditValue = contractDisplay.ContractEndDate;
                buildingNameLookUpEdit.EditValue = contractDisplay.BuildingCodeId;
                floorLookUpEdit.EditValue = contractDisplay.Floor;
                roomLookUpEdit.EditValue = contractDisplay.BuildingRoomCodeId;
                depositTextEdit.EditValue = contractDisplay.Deposit;
                monthlyRentTextEdit.EditValue = contractDisplay.MonthlyRent;
                monthlyRentVATTextEdit.EditValue = contractDisplay.MonthlyRentVAT;
                monthlyRentTotalEdit.EditValue = contractDisplay.MonthlyRentTotal;
                maintenanceFeeTextEdit.EditValue = contractDisplay.MaintenanceFee;
                maintenanceFeeVATTextEdit.EditValue = contractDisplay.MaintenanceFeeVAT;
                maintenanceFeeTotalTextEdit.EditValue = contractDisplay.MaintenanceFeeTotal;
                notesTextEdit.Text = contractDisplay.Notes;
            }
        }

        void LoadDataContractGridView(int? findId = null)
        {
            contractGridControl.DataSource = _contractRepository.GetsDisplayByLesseeId(_lesseeId);
            // 위의 것으로 대체
            //contractGridControl.DataSource =_contractRepository.GetAllDisplay().Where(x => x.LesseeId == _lesseeId).ToList();
            if (findId != null)
            {
                int rowHandle = contractGridView.LocateByValue("Id", findId);
                if (rowHandle != DevExpress.Data.DataController.OperationInProgress)
                    contractGridView.FocusedRowHandle = rowHandle;
            }
        }

        private void LeaseContractModule_Load(object sender, EventArgs e)
        {
            var buildingCodeRepository = new BuildingCodeRepository();
            var buildingCodes = buildingCodeRepository.GetAll().Select(x => new { x.Id, x.BuildingName }).ToList();
            buildingNameLookUpEdit.Properties.DataSource = buildingCodes;
            buildingNameLookUpEdit.Properties.DisplayMember = "BuildingName";
            buildingNameLookUpEdit.Properties.ValueMember = "Id";
            buildingNameLookUpEdit.Properties.ForceInitialize();
            buildingNameLookUpEdit.Properties.PopulateColumns();
            buildingNameLookUpEdit.Properties.Columns["Id"].Visible = false;

            #region contractGridView의 LookUpEdit 셋팅             
            // 디자인 모드 => gridView => column => ColumnEdit에서 생성함
            buildingNameRepositoryItemLookUpEdit.DataSource = buildingCodes;
            buildingNameRepositoryItemLookUpEdit.DisplayMember = "BuildingName";
            buildingNameRepositoryItemLookUpEdit.ValueMember = "Id";
            buildingNameRepositoryItemLookUpEdit.ForceInitialize();
            buildingNameRepositoryItemLookUpEdit.PopulateColumns();
            buildingNameRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            #endregion

            ClearLesseeInput();
            LoadDataLesseeGridView();
            newButton.PerformClick();
        }

        private void lesseeGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
                DisplayLesseeInput();
        }

        private void lesseeGridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            DisplayLesseeInput();
        }

        private void lesseeGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DisplayLesseeInput();
        }

        private void buildingNameLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (buildingNameLookUpEdit.EditValue == null)
            {
                floorLookUpEdit.Clear();
                floorLookUpEdit.Properties.DataSource = null;
                roomLookUpEdit.Clear();
                roomLookUpEdit.Properties.DataSource = null;
                return;
            }

            var buildingRoomCodeRepository = new BuildingRoomCodeRepository();
            var floors = buildingRoomCodeRepository.GetsByBuildingCodeId(Convert.ToInt32(buildingNameLookUpEdit.EditValue))
                .Select(x => new { x.Floor })
                .Distinct()
                .ToList();

            floorLookUpEdit.Clear();
            floorLookUpEdit.Properties.DataSource = floors;
            floorLookUpEdit.Properties.DisplayMember = "Floor";
            floorLookUpEdit.Properties.ValueMember = "Floor";
            floorLookUpEdit.Properties.ForceInitialize();
            floorLookUpEdit.Properties.PopulateColumns();
            //floorLookUpEdit.Properties.DropDownRows = floors.Count();

            //buildingNameLookUpEdit 값이 다르고, floorLookUpEdit가 동일한 값이 선택된 경우에도 roomLookUpEdit를 갱신
            //roomLookUpEdit 초기화
            roomLookUpEdit.Clear();
            roomLookUpEdit.Properties.DataSource = null;
        }

        private void floorLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (floorLookUpEdit.EditValue == null)
            {
                roomLookUpEdit.Clear();
                roomLookUpEdit.Properties.DataSource = null;
                return;
            }

            var buildingRoomCodeRepository = new BuildingRoomCodeRepository();
            var rooms = buildingRoomCodeRepository.GetsByBuildingCodeId(Convert.ToInt32(buildingNameLookUpEdit.EditValue))
                .Where(x => x.Floor == floorLookUpEdit.EditValue.ToString())
                .Select(x => new { x.Id, x.Room })
                .ToList();

            roomLookUpEdit.Clear();
            roomLookUpEdit.Properties.DataSource = rooms;
            roomLookUpEdit.Properties.DisplayMember = "Room";
            roomLookUpEdit.Properties.ValueMember = "Id";
            roomLookUpEdit.Properties.ForceInitialize();
            roomLookUpEdit.Properties.PopulateColumns();
            roomLookUpEdit.Properties.Columns["Id"].Visible = false;
        }

        private void contractGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //직접 클릭해서 수정하도록 한다.
            // => 임차인을 클릭할때 마다 입력되었다가 없어져서(신규버튼호출) 주석처리함
            //if (e.FocusedRowHandle >= 0)
            //    DisplayContractInput();
        }

        private void contractGridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            //직접 클릭해서 수정하도록 한다.
            // => 임차인을 클릭할때 마다 입력되었다가 없어져서(신규버튼호출) 주석처리함
            //DisplayContractInput();
        }

        private void contractGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DisplayContractInput();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            ClearContractInput();
            contractStartDateEdit.Focus();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (_contractId != 0)
            {
                if (XtraMessageBox.Show($"{contractStartDateEdit.Text} ~ {contractEndDateEdit.Text}를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var isDelete = _contractRepository.Delete(_contractId);
                    if (isDelete)
                    {
                        ClearContractInput();
                        LoadDataContractGridView();
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int? focuseId;
            if (_lesseeId == 0)
            {
                XtraMessageBox.Show("임차인을 선택해 주세요.", "확인");
                lesseeGridView.Focus();
                return;
            }
            if (contractStartDateEdit.EditValue == null)
            {
                XtraMessageBox.Show("계약기간을 선택해 주세요.", "확인");
                contractStartDateEdit.ShowPopup();
                return;
            }
            if (contractEndDateEdit.EditValue == null)
            {
                XtraMessageBox.Show("계약기간을 선택해 주세요.", "확인");
                contractEndDateEdit.ShowPopup();
                return;
            }
            if (roomLookUpEdit.EditValue == null)
            {
                XtraMessageBox.Show("호실을 선택해 주세요.", "확인");
                roomLookUpEdit.Focus();
                return;
            }

            var contract = new LeaseContractModel()
            {
                LesseeId = _lesseeId,
                ContractStartDate = DateTime.Parse(contractStartDateEdit.EditValue.ToString()),
                ContractEndDate = DateTime.Parse(contractEndDateEdit.EditValue.ToString()),
                BuildingRoomCodeId = int.Parse(roomLookUpEdit.EditValue.ToString()),
                Deposit = Convert.ToDecimal(depositTextEdit.EditValue),
                MonthlyRent = Convert.ToDecimal(monthlyRentTextEdit.EditValue),
                MonthlyRentVAT = Convert.ToDecimal(monthlyRentVATTextEdit.EditValue),
                //MonthlyRentTotal = Convert.ToDecimal(monthlyRentTotalEdit.EditValue), //DB에서 계산됨
                MaintenanceFee = Convert.ToDecimal(maintenanceFeeTextEdit.EditValue),
                MaintenanceFeeVAT = Convert.ToDecimal(maintenanceFeeVATTextEdit.EditValue),
                //MaintenanceFeeTotal = Convert.ToDecimal(maintenanceFeeTotalTextEdit.EditValue), //DB에서 계산됨
                Notes = notesTextEdit.Text,
                InsertUserId = AppData.LogOn.UserID,
                UpdateUserId = AppData.LogOn.UserID
            };

            try
            {
                if (_contractId == 0)
                {
                    //var model = _contractRepository.GetByName(contract.ContractStartDate);
                    //if (model != null)
                    //{
                    //    XtraMessageBox.Show($"{model.ContractStartDate}은 이미 등록되어 있습니다.", "확인");
                    //    contractStartDateDateEdit.Focus();
                    //    return;
                    //}

                    focuseId = _contractRepository.Insert(contract);
                }
                else
                {
                    contract.Id = _contractId;

                    _contractRepository.Update(contract);
                    focuseId = contract.Id;
                }
                ClearContractInput();
                LoadDataContractGridView(focuseId);
                newButton.PerformClick();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Error");
            }
        }

        private void monthlyRentTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //부가세계산 = 10자리로 반올림
            monthlyRentVATTextEdit.EditValue = Math.Round((Convert.ToDecimal(monthlyRentTextEdit.EditValue) * Convert.ToDecimal(0.1)) / 10, 0, MidpointRounding.AwayFromZero) * 10;
            monthlyRentTotalEdit.EditValue = Convert.ToDecimal(monthlyRentTextEdit.EditValue) + Convert.ToDecimal(monthlyRentVATTextEdit.EditValue);
        }

        private void monthlyRentVATTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            monthlyRentTotalEdit.EditValue = Convert.ToDecimal(monthlyRentTextEdit.EditValue) + Convert.ToDecimal(monthlyRentVATTextEdit.EditValue);
        }

        private void maintenanceFeeTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            //부가세계산 = 10자리로 반올림
            maintenanceFeeVATTextEdit.EditValue = Math.Round((Convert.ToDecimal(maintenanceFeeTextEdit.EditValue) * Convert.ToDecimal(0.1)) / 10, 0, MidpointRounding.AwayFromZero) * 10;
            maintenanceFeeTotalTextEdit.EditValue = Convert.ToDecimal(maintenanceFeeTextEdit.EditValue) + Convert.ToDecimal(maintenanceFeeVATTextEdit.EditValue);
        }

        private void maintenanceFeeVATTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            maintenanceFeeTotalTextEdit.EditValue = Convert.ToDecimal(maintenanceFeeTextEdit.EditValue) + Convert.ToDecimal(maintenanceFeeVATTextEdit.EditValue);
        }
    }
}