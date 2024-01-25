namespace BuildingLeaseDataManager.Library.Models
{
    /// <summary>
    /// leaseContractGridView에 보여진다.
    /// </summary>
    public class LeaseContractDisplayModel : LeaseContractModel
    {
        // BuildingRoomCode table
        public int BuildingCodeId { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
    }
}
