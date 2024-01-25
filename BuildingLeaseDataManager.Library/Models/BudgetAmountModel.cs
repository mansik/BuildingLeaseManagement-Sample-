using System;

namespace BuildingLeaseDataManager.Library.Models
{
    public class BudgetAmountModel
    {
        public int Id { get; set; }
        public int FiscalYear { get; set; }
        public int AccountCodeId { get; set; }
        public long BudgetAmount { get; set; }
        public int InsertUserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
