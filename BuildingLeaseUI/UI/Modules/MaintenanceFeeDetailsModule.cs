using BuildingLease.Library;
using BuildingLeaseDataManager.Library.Models;
using BuildingLeaseDataManager.Library.SqlDbAccess;
using BuildingLeaseUI.UI.Forms;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BuildingLeaseUI.UI.Modules
{
    public partial class MaintenanceFeeDetailsModule : DevExpress.XtraEditors.XtraUserControl
    {
        private readonly MaintenanceFeeDetailsRepository _maintenanceFeeDetailsRepository = new MaintenanceFeeDetailsRepository();
        private MaintenanceFeeDetailsSettingModel _maintenanceFeeDetailsSettingModel = new MaintenanceFeeDetailsSettingModel();
        public MaintenanceFeeDetailsModule()
        {
            InitializeComponent();

            //관리자가 아니면 수정 못하게
            if (!AppData.LogOn.GradeTypeID.Equals(1))
            {
                initButton.Enabled = false;
                saveButton.Enabled = false;
            }
        }

        void LoadDataMaintenamceFeeDetailsSetting()
        {
            var maintenanceFeeDetailsDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
            maintenanceFeeDetailsDate = maintenanceFeeDetailsDate.AddDays(1 - maintenanceFeeDetailsDate.Day);

            var maintenanceFeeDetailsSettingRepository = new MaintenanceFeeDetailsSettingRepository();
            var setting = maintenanceFeeDetailsSettingRepository.GetByDate(maintenanceFeeDetailsDate, Convert.ToInt32(buildingCodeLookUpEdit.EditValue));
            _maintenanceFeeDetailsSettingModel = setting;
            if (setting != null)
            {
                electricBillTermTextEdit.EditValue = setting.ElectricBillTerm;
                waterBillTermTextEdit.EditValue = setting.WaterBillTerm;
                roadOccupancyFeeTermTextEdit.EditValue = setting.RoadOccupancyFeeTerm;
                trafficCausingChargeTermTextEdit.EditValue = setting.TrafficCausingChargeTerm;
                bankBookLookUpEdit.EditValue = setting.BankBookCodeId;
                paymentDueDateEdit.EditValue = setting.PaymentDueDate;
                billIssueDateEdit.EditValue = setting.BillIssueDate;
            }
            else
            {
                electricBillTermTextEdit.EditValue = string.Empty;
                waterBillTermTextEdit.EditValue = string.Empty;
                roadOccupancyFeeTermTextEdit.EditValue = string.Empty;
                trafficCausingChargeTermTextEdit.EditValue = string.Empty;
                bankBookLookUpEdit.EditValue = string.Empty;
                paymentDueDateEdit.EditValue = string.Empty;
                billIssueDateEdit.EditValue = string.Empty;
            }
        }

        void LoadDataGridView()
        {
            var maintenanceFeeDetailsDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
            maintenanceFeeDetailsDate = maintenanceFeeDetailsDate.AddDays(1 - maintenanceFeeDetailsDate.Day);

            gridControl.DataSource = _maintenanceFeeDetailsRepository.GetsDisplayByDate(maintenanceFeeDetailsDate, Convert.ToInt32(buildingCodeLookUpEdit.EditValue));

            // 관리비 명세서 설정
            LoadDataMaintenamceFeeDetailsSetting();
        }

        void ReSetRoomRepositoryItemLookUpEdit()
        {
            //gridView의 LookUpEdit 셋팅
            // 디자인 모드 => gridView => column => ColumnEdit에서 생성함
            var buildingRoomCodeRepository = new BuildingRoomCodeRepository();
            roomRepositoryItemLookUpEdit.DataSource = buildingRoomCodeRepository.GetsByBuildingCodeId(Convert.ToInt32(buildingCodeLookUpEdit.EditValue)).Select(x => new { x.Id, x.Room }).ToList();
            roomRepositoryItemLookUpEdit.DisplayMember = "Room";
            roomRepositoryItemLookUpEdit.ValueMember = "Id";
            roomRepositoryItemLookUpEdit.ForceInitialize();
            roomRepositoryItemLookUpEdit.PopulateColumns();
            roomRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
        }

        private void MaintenanceFeeDetailsModule_Load(object sender, System.EventArgs e)
        {
            searchDateEdit.EditValue = DateTime.Today.AddDays(1 - DateTime.Today.Day);

            var buildingCodeRepository = new BuildingCodeRepository();
            var buildingCodes = buildingCodeRepository.GetAll().Select(x => new { x.Id, x.BuildingName }).ToList();
            buildingCodeLookUpEdit.Properties.DataSource = buildingCodes;
            buildingCodeLookUpEdit.Properties.DisplayMember = "BuildingName";
            buildingCodeLookUpEdit.Properties.ValueMember = "Id";
            buildingCodeLookUpEdit.Properties.ForceInitialize();
            buildingCodeLookUpEdit.Properties.PopulateColumns();
            buildingCodeLookUpEdit.Properties.Columns["Id"].Visible = false;
            if (buildingCodes.Count() > 0)
            {
                buildingCodeLookUpEdit.ItemIndex = 0;
            }

            var bankBookCodeRepository = new BankBookCodeRepository();
            var bankBookCodes = bankBookCodeRepository.GetAll().Select(x => new { x.Id, x.BankBookName, x.BankName, x.AccountNumber }).ToList();
            bankBookLookUpEdit.Properties.DataSource = bankBookCodes;
            bankBookLookUpEdit.Properties.DisplayMember = "BankBookName";
            bankBookLookUpEdit.Properties.ValueMember = "Id";
            bankBookLookUpEdit.Properties.ForceInitialize();
            bankBookLookUpEdit.Properties.PopulateColumns();
            bankBookLookUpEdit.Properties.Columns["Id"].Visible = false;

            #region gridView의 LookUpEdit 셋팅             
            // 디자인 모드 => gridView => column => ColumnEdit에서 생성함
            var buildingRoomCodeRepository = new BuildingRoomCodeRepository();
            roomRepositoryItemLookUpEdit.DataSource = buildingRoomCodeRepository.GetsByBuildingCodeId(Convert.ToInt32(buildingCodeLookUpEdit.EditValue)).Select(x => new { x.Id, x.Room }).ToList();
            roomRepositoryItemLookUpEdit.DisplayMember = "Room";
            roomRepositoryItemLookUpEdit.ValueMember = "Id";
            roomRepositoryItemLookUpEdit.ForceInitialize();
            roomRepositoryItemLookUpEdit.PopulateColumns();
            roomRepositoryItemLookUpEdit.Columns["Id"].Visible = false;

            var lesseeRepository = new LesseeRepository();
            lesseeRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.Lessee, x.BRN, x.Owner, x.BillIssueDay }).ToList();
            lesseeRepositoryItemLookUpEdit.DisplayMember = "Lessee";
            lesseeRepositoryItemLookUpEdit.ValueMember = "Id";
            lesseeRepositoryItemLookUpEdit.ForceInitialize();
            lesseeRepositoryItemLookUpEdit.PopulateColumns();
            lesseeRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["BRN"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["Owner"].Visible = false;
            lesseeRepositoryItemLookUpEdit.Columns["BillIssueDay"].Visible = false;

            BRNRepositoryItemLookUpEdit.DataSource = lesseeRepository.GetAll().Select(x => new { x.Id, x.BRN }).ToList();
            BRNRepositoryItemLookUpEdit.DisplayMember = "BRN";
            BRNRepositoryItemLookUpEdit.ValueMember = "Id";
            BRNRepositoryItemLookUpEdit.ForceInitialize();
            BRNRepositoryItemLookUpEdit.PopulateColumns();
            BRNRepositoryItemLookUpEdit.Columns["Id"].Visible = false;
            #endregion

            OptionGridBand.Visible = false; //isEdited, Id

            LoadDataGridView();
        }

        private void buildingCodeLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ReSetRoomRepositoryItemLookUpEdit();
            LoadDataGridView();
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            // 수정된 것만 저장되게 하기 위함
            if (e.Column.FieldName != "IsEdited")
            {
                if (gridView.ActiveEditor.EditValue != gridView.ActiveEditor.OldEditValue)
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["IsEdited"], true);
            }
            // 부가세 계산, 원단위에서 반올림
            switch (e.Column.FieldName)
            {
                case "MonthlyRent":
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["MonthlyRentVAT"], Math.Round(Convert.ToInt64(e.Value) * 0.1, 0, MidpointRounding.AwayFromZero));
                    break;
                case "MaintenanceFee":
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["MaintenanceFeeVAT"], Math.Round(Convert.ToInt64(e.Value) * 0.1, 0, MidpointRounding.AwayFromZero));
                    break;
                case "ElectricBill":
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["ElectricBillVAT"], Math.Round(Convert.ToInt64(e.Value) * 0.1, 0, MidpointRounding.AwayFromZero));
                    break;
                case "RoadOccupancyFee":
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["RoadOccupancyFeeVAT"], Math.Round(Convert.ToInt64(e.Value) * 0.1, 0, MidpointRounding.AwayFromZero));
                    break;
                case "TrafficCausingCharge":
                    gridView.SetRowCellValue(e.RowHandle, gridView.Columns["TrafficCausingChargeVAT"], Math.Round(Convert.ToInt64(e.Value) * 0.1, 0, MidpointRounding.AwayFromZero));
                    break;
                default:
                    break;
            }
        }

        private void initButton_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(
                $"[{searchDateEdit.Text}, {buildingCodeLookUpEdit.Text}]의 관리비 명세서를 삭제하고, 청구서를 기준으로 다시 만듦니다. 계속하시겠습니까?",
                "삭제",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var maintenanceFeeDetailsDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
                maintenanceFeeDetailsDate = maintenanceFeeDetailsDate.AddDays(1 - maintenanceFeeDetailsDate.Day);

                _maintenanceFeeDetailsRepository.InitByDate(maintenanceFeeDetailsDate, Convert.ToInt32(buildingCodeLookUpEdit.EditValue));

                LoadDataGridView();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var maintenanceFeeDetailsDate = Convert.ToDateTime(searchDateEdit.EditValue).Date;
            maintenanceFeeDetailsDate = maintenanceFeeDetailsDate.AddDays(1 - maintenanceFeeDetailsDate.Day);

            // 관리비 명세서 설정
            var setting = new MaintenanceFeeDetailsSettingModel()
            {
                MaintenanceFeeDetailsDate = maintenanceFeeDetailsDate,
                BuildingCodeId = Convert.ToInt32(buildingCodeLookUpEdit.EditValue),
                ElectricBillTerm = electricBillTermTextEdit.EditValue.ToString(),
                WaterBillTerm = waterBillTermTextEdit.EditValue.ToString(),
                RoadOccupancyFeeTerm = roadOccupancyFeeTermTextEdit.EditValue.ToString(),
                TrafficCausingChargeTerm = trafficCausingChargeTermTextEdit.EditValue.ToString(),
                BankBookCodeId = bankBookLookUpEdit.EditValue.ToString(),
                PaymentDueDate = Convert.ToDateTime(paymentDueDateEdit.EditValue),
                BillIssueDate = Convert.ToDateTime(billIssueDateEdit.EditValue),
                InsertUserId = AppData.LogOn.UserID,
                UpdateUserId = AppData.LogOn.UserID
            };

            var maintenanceFeeDetailsSettingRepository = new MaintenanceFeeDetailsSettingRepository();
            maintenanceFeeDetailsSettingRepository.InsertUpdate(setting);


            // 관리비 명세서 리스트
            try
            {
                // DataRowCount를 갱신시키기 위해서 사용함.
                // 없으면 DataRowCount가 추가된 행을 인식하지 못하며, 포커스를 이동해야만 갱신된다.
                gridView.UpdateCurrentRow();

                for (int rowIndex = 0; rowIndex < gridView.DataRowCount; rowIndex++)
                {
                    if (gridView.GetRow(rowIndex) is MaintenanceFeeDetailsDisplayModel row)
                    {
                        // 임차인이 없으면 기본코드(LesseeId = 1, Lessee = " ")로 저장 => 조회시 호실이 모두 보이게 하기 위해서
                        if (row.LesseeId == 0)
                            row.LesseeId = 1;

                        var maintenanceFeeDetails = new MaintenanceFeeDetailsModel()
                        {
                            MaintenanceFeeDetailsDate = maintenanceFeeDetailsDate,
                            BuildingRoomCodeId = row.BuildingRoomCodeId,
                            LesseeId = row.LesseeId,
                            ReceivableAmount = row.ReceivableAmount,
                            MonthlyRent = row.MonthlyRent,
                            MonthlyRentVAT = row.MonthlyRentVAT,
                            MaintenanceFee = row.MaintenanceFee,
                            MaintenanceFeeVAT = row.MaintenanceFeeVAT,
                            ElectricBill = row.ElectricBill,
                            ElectricBillVAT = row.ElectricBillVAT,
                            WaterBill = row.WaterBill,
                            RoadOccupancyFee = row.RoadOccupancyFee,
                            RoadOccupancyFeeVAT = row.RoadOccupancyFeeVAT,
                            TrafficCausingCharge = row.TrafficCausingCharge,
                            TrafficCausingChargeVAT = row.TrafficCausingChargeVAT,
                            InsertUserId = AppData.LogOn.UserID,
                            UpdateUserId = AppData.LogOn.UserID
                        };

                        if (row.Id == 0)
                        {
                            _maintenanceFeeDetailsRepository.Insert(maintenanceFeeDetails);
                        }
                        else
                        {
                            if (row.IsEdited) //gridView_CellValueChanged 에서 셋팅
                            {
                                maintenanceFeeDetails.Id = row.Id;
                                _maintenanceFeeDetailsRepository.Update(maintenanceFeeDetails);
                            }
                        }
                    }
                }

                // 저장 후 반드시 조회를 호출해야 중복저장이 안된다.
                searchButton.PerformClick();
            }
            catch (Exception ex)
            {
                // 오류가 났을 경우 잘못 저장되는 것을 방지하기 위해서 transaction 사용하여야 한다.
                XtraMessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                Logger.WriteLogBuffer("", LogType.Data, writeNow: true);
            }
        }

        private void searchDateEdit_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // 화면과 동일한 데이터를 사용하기 위해서 먼저 저장한다.

            // Export selected rows in gridView.DataSource to newList, 선택된 것만 출력
            var gridList = gridView.DataSource as List<MaintenanceFeeDetailsDisplayModel>;
            var newList = new List<MaintenanceFeeDetailsDisplayModel>();
            foreach (int rowHandle in gridView.GetSelectedRows())
            {
                var id = Convert.ToInt32(gridView.GetRowCellValue(rowHandle, "Id"));
                if (id != 0)
                    newList.Add(gridList.Find(x => x.Id == id));
            }

            if (newList.Count == 0)
            {
                XtraMessageBox.Show("선택 후 작업해 주세요.", "확인");
                return;
            }

            if (newList.Count > 0)
            {
                using (var printForm = new PrintForm())
                {
                    var accountNumber = bankBookLookUpEdit.GetColumnValue("AccountNumber")?.ToString();
                    var BankName = bankBookLookUpEdit.GetColumnValue("BankName")?.ToString();
                    var configRepository = new ConfigRepository();
                    var config = configRepository.GetFirst();
                    var OfficeTel = config.OfficeTel;
                    var OfficeEmail = config.OfficeEmail;

                    printForm.MaintenanceFeeDatailsPrint(accountNumber, BankName, OfficeTel, OfficeEmail, _maintenanceFeeDetailsSettingModel, newList);
                    printForm.ShowDialog();
                }
            }
        }
    }
}
