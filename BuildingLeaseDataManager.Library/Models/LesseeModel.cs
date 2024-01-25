using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class LesseeModel
    {
        public int Id { get; set; }
        public string Lessee { get; set; }
        public string Owner { get; set; }
        public string RRN { get; set; }
        public string BRN { get; set; }
        public string Contact { get; set; }
        public bool UnderContractFlag { get; set; }
        public string BillIssueDay { get; set; }
        public string Notes { get; set; }
        // gridView에서 별도의 코딩없이 체크박스가 나타나도록 하기 위해서 bool형 사용함.
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
