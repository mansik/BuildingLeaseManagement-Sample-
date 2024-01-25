namespace BuildingLeaseDataManager.Library.Models
{
    /// <summary>
    /// 수입(0)/지출(1), 입금(0)/출금(1) 같이 사용
    /// </summary>
    public class InOutgoingsModel
    {
        public int Id { get; set; }
        public string InOutgoingsName { get; set; }
    }
}
