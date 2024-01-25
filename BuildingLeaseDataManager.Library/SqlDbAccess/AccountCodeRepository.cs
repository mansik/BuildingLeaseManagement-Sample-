using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class AccountCodeRepository : IGenericRepository<AccountCodeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spAccountCode_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<AccountCodeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<AccountCodeModel>("dbo.spAccountCode_GetAll",
                                                              new { },
                                                              commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public List<AccountCodeModel> GetAll(int accountHangCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<AccountCodeModel>("dbo.spAccountCode_GetAll",
                                                              new
                                                              {
                                                                  AccountHangCodeId = accountHangCodeId
                                                              },
                                                              commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public AccountCodeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<AccountCodeModel>("dbo.spAccountCode_GetById",
                                                                     new { Id = id },
                                                                     commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(AccountCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.AccountHangCodeId,
                    entity.AccountName,
                    entity.DisplaySeq,
                    entity.UseFlag,
                    entity.InsertUserId,
                    entity.UpdateUserId
                });

                connection.Execute("dbo.spAccountCode_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(AccountCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spAccountCode_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.AccountHangCodeId,
                                              entity.AccountName,
                                              entity.DisplaySeq,
                                              entity.UseFlag,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public bool Exists(string name, int accountHangCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spAccountCode_Exists",
                                                      new { AccountName = name, AccountHangCodeId = accountHangCodeId },
                                                      commandType: CommandType.StoredProcedure);
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<AccountCodeDisplayModel> GetAllDisplay(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<AccountCodeDisplayModel>("dbo.spAccountCode_GetAllDisplay",
                                                                   new { },
                                                                   commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public bool IsUsed(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spAccountCode_IsUsed",
                                                      new { Id = id },
                                                      commandType: CommandType.StoredProcedure);
            }
        }
    }
}
