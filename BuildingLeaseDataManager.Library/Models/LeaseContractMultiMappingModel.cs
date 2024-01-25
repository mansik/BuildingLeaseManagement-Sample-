namespace BuildingLeaseDataManager.Library.Models
{
    /// <summary>
    /// [MultiMapping을 사용하는 방법]
    ///   => 이방법 보다는 LeaseContractDisplayModel을 이용하는 것이 편리
    /// Procedure:
    /// CREATE PROCEDURE [dbo].[spLeaseContract_GetAllMultiMapping]
    /// BEGIN
    /// AS
    /// SET NOCOUNT ON
    /// 
    /// select c.*, r.*
    /// from dbo.[LeaseContract] c
    /// left join dbo.[BuildingRoomCode] r
    ///   on c.BuildingRoomCodeId = r.id;
    /// END
    /// 사용법:
    /// List<LeaseContractMultiMappingModel> contract =  connection.Query<LeaseContractMultiMappingModel, BuildingRoomCodeModel, LeaseContractMultiMappingModel>(
    ///                     "dbo.spLeaseContract_GetAllMultiMapping",
    ///                     (contract, room) => { contract.BuildingRoomCode = room; return contract; },
    ///                     commandType: CommandType.StoredProcedure).AsList();
    /// 접근방법: contract.BuildingRoomCode.BuildingCodeId 를 통해 접근
    /// </summary>
    public class LeaseContractMultiMappingModel : LeaseContractModel
    {
        public BuildingRoomCodeModel BuildingRoomCode { get; set; }
    }
}
