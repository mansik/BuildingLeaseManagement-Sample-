using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class LesseeRepository : IGenericRepository<LesseeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spLessee_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<LesseeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<LesseeModel>("dbo.spLessee_GetAll",
                                                     new { },
                                                     commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public LesseeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<LesseeModel>("dbo.spLessee_GetById",
                                                            new { Id = id },
                                                            commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(LesseeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    Lessee = entity.Lessee,
                    Owner = entity.Owner,
                    RRN = entity.RRN,
                    BRN = entity.BRN,
                    Contact = entity.Contact,
                    UnderContractFlag = entity.UnderContractFlag,
                    BillIssueDay = entity.BillIssueDay,
                    Notes = entity.Notes,
                    InsertUserId = entity.InsertUserId,
                    UpdateUserId = entity.UpdateUserId
                });

                connection.Execute("dbo.spLessee_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(LesseeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spLessee_Update",
                                          new
                                          {
                                              Id = entity.Id,
                                              Lessee = entity.Lessee,
                                              Owner = entity.Owner,
                                              RRN = entity.RRN,
                                              BRN = entity.BRN,
                                              Contact = entity.Contact,
                                              UnderContractFlag = entity.UnderContractFlag,
                                              BillIssueDay = entity.BillIssueDay,
                                              Notes = entity.Notes,
                                              UpdateUserId = entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }
        public bool Exists(string name, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spLessee_Exists",
                                                      new { Lessee = name },
                                                      commandType: CommandType.StoredProcedure);
            }
        }

        public bool IsUsed(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spLessee_IsUsed",
                                                      new { Id = id },
                                                      commandType: CommandType.StoredProcedure);
            }
        }
    }
}
