using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class LeaseContractRepository
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spLeaseContract_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<LeaseContractModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<LeaseContractModel>("dbo.spLeaseContract_GetAll",
                                                     new { },
                                                     commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public LeaseContractModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<LeaseContractModel>("dbo.spLeaseContract_GetById",
                                                            new { Id = id },
                                                            commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(LeaseContractModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    LesseeId = entity.LesseeId,
                    BuildingRoomCodeId = entity.BuildingRoomCodeId,
                    ContractStartDate = entity.ContractStartDate,
                    ContractEndDate = entity.ContractEndDate,
                    Deposit = entity.Deposit,
                    MonthlyRent = entity.MonthlyRent,
                    MonthlyRentVAT = entity.MonthlyRentVAT,
                    MaintenanceFee = entity.MaintenanceFee,
                    MaintenanceFeeVAT = entity.MaintenanceFeeVAT,
                    Notes = entity.Notes,
                    InsertUserId = entity.InsertUserId,
                    UpdateUserId = entity.UpdateUserId
                });

                connection.Execute("dbo.spLeaseContract_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(LeaseContractModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spLeaseContract_Update",
                                          new
                                          {
                                              Id = entity.Id,
                                              LesseeId = entity.LesseeId,
                                              BuildingRoomCodeId = entity.BuildingRoomCodeId,
                                              ContractStartDate = entity.ContractStartDate,
                                              ContractEndDate = entity.ContractEndDate,
                                              Deposit = entity.Deposit,
                                              MonthlyRent = entity.MonthlyRent,
                                              MonthlyRentVAT = entity.MonthlyRentVAT,
                                              MaintenanceFee = entity.MaintenanceFee,
                                              MaintenanceFeeVAT = entity.MaintenanceFeeVAT,
                                              Notes = entity.Notes,
                                              UpdateUserId = entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<LeaseContractDisplayModel> GetAllDisplay(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<LeaseContractDisplayModel>("dbo.spLeaseContract_GetAllDisplay",
                                                                   new { },
                                                                   commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<LeaseContractDisplayModel> GetsDisplayByLesseeId(int lesseeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<LeaseContractDisplayModel>("dbo.spLeaseContract_GetsDisplayByLesseeId",
                                                                   new { LesseeId = lesseeId },
                                                                   commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
