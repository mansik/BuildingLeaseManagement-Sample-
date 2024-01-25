using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class MaintenanceFeeDetailsSettingModel
    {
        public int Id { get; set; }
        public DateTime MaintenanceFeeDetailsDate { get; set; }
        public int BuildingCodeId { get; set; }
        public string ElectricBillTerm { get; set; }
        public string WaterBillTerm { get; set; }
        public string RoadOccupancyFeeTerm { get; set; }
        public string TrafficCausingChargeTerm { get; set; }
        public string BankBookCodeId { get; set; }
        /// <summary>
        /// 납부기한
        /// </summary>
        public DateTime PaymentDueDate { get; set; }
        /// <summary>
        /// 발행일
        /// </summary>
        public DateTime BillIssueDate { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
