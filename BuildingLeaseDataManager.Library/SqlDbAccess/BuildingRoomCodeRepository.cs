using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class BuildingRoomCodeRepository : IGenericRepository<BuildingRoomCodeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spBuildingRoomCode_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<BuildingRoomCodeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<BuildingRoomCodeModel>("dbo.spBuildingRoomCode_GetAll",
                                                               new { },
                                                               commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public BuildingRoomCodeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<BuildingRoomCodeModel>("dbo.spBuildingRoomCode_GetById",
                                                                      new { Id = id },
                                                                      commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(BuildingRoomCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    BuildingCodeId = entity.BuildingCodeId,
                    Room = entity.Room,
                    Floor = entity.Floor,
                    Area = entity.Area,
                    Notes = entity.Notes,
                    DisplaySeq = entity.DisplaySeq,
                    UseFlag = entity.UseFlag,
                    InsertUserId = entity.InsertUserId,
                    UpdateUserId = entity.UpdateUserId
                });

                connection.Execute("dbo.spBuildingRoomCode_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(BuildingRoomCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spBuildingRoomCode_Update",
                                          new
                                          {
                                              Id = entity.Id,
                                              BuildingCodeId = entity.BuildingCodeId,
                                              Room = entity.Room,
                                              Floor = entity.Floor,
                                              Area = entity.Area,
                                              Notes = entity.Notes,
                                              DisplaySeq = entity.DisplaySeq,
                                              UseFlag = entity.UseFlag,
                                              UpdateUserId = entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<BuildingRoomCodeModel> GetsByBuildingCodeId(int buildingCodeid, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<BuildingRoomCodeModel>("dbo.spBuildingRoomCode_GetsByBuildingCodeId",
                                                                      new { BuildingCodeId = buildingCodeid },
                                                                      commandType: CommandType.StoredProcedure).AsList();

            }
        }

        public bool Exists(string room, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spBuildingRoomCode_Exists",
                                                      new { Room = room, BuildingCodeId = buildingCodeId },
                                                      commandType: CommandType.StoredProcedure);
            }
        }

        public bool IsUsed(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spBuildingRoomCode_IsUsed",
                                                      new { Id = id },
                                                      commandType: CommandType.StoredProcedure);
            }
        }
    }
}
