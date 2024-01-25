namespace BuildingLeaseDataManager.Library.Models
{
    public class IncomingsDetailsDisplayModel
    {
        public int BuildingCodeId { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        public int LesseeId { get; set; }
        public decimal PreviousReceivableAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal InvoiceTotalAmount { get; set; }
        public decimal IncomingsAmount { get; set; }
        public decimal IncomingsTotalAmount { get; set; }
        public decimal LossAmount { get; set; }
        public decimal LossTotalAmount { get; set; }
        public decimal ReceivableAmount { get; set; }
        public decimal ReceivableTotalAmount { get; set; }
    }
}
