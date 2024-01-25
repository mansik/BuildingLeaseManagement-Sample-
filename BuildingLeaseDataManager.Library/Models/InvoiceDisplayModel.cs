namespace BuildingLeaseDataManager.Library.Models
{
    public class InvoiceDisplayModel : InvoiceModel
    {
        /// <summary>
        /// 화면에서 현재 Row가 수정된 것인지를 저장 
        /// </summary>
        public bool IsEdited { get; set; }

        public int BuildingCodeId { get; set; }
    }
}
