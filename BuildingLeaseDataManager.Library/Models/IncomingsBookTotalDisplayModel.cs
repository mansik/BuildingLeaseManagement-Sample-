namespace BuildingLeaseDataManager.Library.Models
{
    public class IncomingsBookTotalDisplayModel
    {
        public string AccountHangName { get; set; }
        public string AccountName { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal IncomingsAmount { get; set; }
        public decimal LossAmount { get; set; }
        public decimal DifferenceAmount { get; set; }
    }
}
