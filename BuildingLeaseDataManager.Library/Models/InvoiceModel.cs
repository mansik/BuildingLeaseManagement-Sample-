using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int BuildingRoomCodeId { get; set; }
        public int LesseeId { get; set; }
        public string BillIssueDay { get; set; }
        public long MonthlyRent { get; set; } //decimal 에서 화면에 소수점 자리가 나와서 long으로 변경
        public long MonthlyRentVAT { get; set; }
        public long MaintenanceFee { get; set; }
        public long MaintenanceFeeVAT { get; set; }
        public long ElectricBill { get; set; }
        public long ElectricBillVAT { get; set; }
        public long WaterBill { get; set; }
        public long RoadOccupancyFee { get; set; }
        public long RoadOccupancyFeeVAT { get; set; }
        public long TrafficCausingCharge { get; set; }
        public long TrafficCausingChargeVAT { get; set; }
        public long LineTotal { get; set; }
        // gridView에서 별도의 코딩없이 체크박스가 나타나도록 하기 위해서 bool형 사용함.
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
