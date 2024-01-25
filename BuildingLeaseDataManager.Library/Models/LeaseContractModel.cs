using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class LeaseContractModel
    {
        public int Id { get; set; }
        public int LesseeId { get; set; }
        public int? BuildingRoomCodeId { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public decimal Deposit { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal MonthlyRentVAT { get; set; }
        public decimal MonthlyRentTotal { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal MaintenanceFeeVAT { get; set; }
        public decimal MaintenanceFeeTotal { get; set; }
        public string Notes { get; set; }
        // gridView에서 별도의 코딩없이 체크박스가 나타나도록 하기 위해서 bool형 사용함.
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}