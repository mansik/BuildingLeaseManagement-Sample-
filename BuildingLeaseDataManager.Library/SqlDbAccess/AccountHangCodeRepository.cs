using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class AccountHangCodeRepository : IGenericRepository<AccountHangCodeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spAccountHangCode_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<AccountHangCodeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<AccountHangCodeModel>("dbo.spAccountHangCode_GetAll",
                                                              new { },
                                                              commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public AccountHangCodeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<AccountHangCodeModel>("dbo.spAccountHangCode_GetById",
                                                                     new { Id = id },
                                                                     commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(AccountHangCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.InOutgoings,
                    entity.AccountHangName,
                    entity.DisplaySeq,
                    entity.UseFlag,
                    entity.InsertUserId,
                    entity.UpdateUserId
                });

                connection.Execute("dbo.spAccountHangCode_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(AccountHangCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spAccountHangCode_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.InOutgoings,
                                              entity.AccountHangName,
                                              entity.DisplaySeq,
                                              entity.UseFlag,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<AccountHangCodeModel> GetsByInOutgoings(int inOutgoings, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<AccountHangCodeModel>("dbo.spAccountHangCode_GetsByInOutgoings",
                                                              new { InOutgoings = inOutgoings },
                                                              commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public bool Exists(string name, int inOutgoings, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spAccountHangCode_Exists",
                                                                     new { AccountHangName = name, InOutgoings = inOutgoings },
                                                                     commandType: CommandType.StoredProcedure);

            }
        }

        public bool IsUsed(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spAccountHangCode_IsUsed",
                                                      new { Id = id },
                                                      commandType: CommandType.StoredProcedure);
            }
        }
    }
}
