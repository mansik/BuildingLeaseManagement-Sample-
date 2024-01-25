using BuildingLeaseDataManager.Library.Models;

namespace BuildingLeaseUI.Report
{
    public partial class MaintenanceFeeDetailsReport : DevExpress.XtraReports.UI.XtraReport
    {
        public MaintenanceFeeDetailsReport()
        {
            InitializeComponent();
        }

        public void InitData(string accountNumber, string bankName, string officeTel, string officeEmail, object maintenanceFeeDetailsSetting, object maintenanceFeeDetailsData)
        {
            pAccountNumber.Value = accountNumber;
            pBankName.Value = bankName;
            pOfficeTel.Value = officeTel;
            pOfficeEmail.Value = officeEmail;
            objectDataSource1.DataSource = maintenanceFeeDetailsData;
            if (maintenanceFeeDetailsSetting is MaintenanceFeeDetailsSettingModel setting)
            {
                pElectricBillTerm.Value = setting.ElectricBillTerm;
                pWaterBillTerm.Value = setting.WaterBillTerm;
                pRoadOccupancyFeeTerm.Value = setting.RoadOccupancyFeeTerm;
                pTrafficCausingChargeTerm.Value = setting.TrafficCausingChargeTerm;

                pPaymentDueDate.Value = setting.PaymentDueDate;
                pBillIssueDate.Value = setting.BillIssueDate;
            }

        }
    }
}
