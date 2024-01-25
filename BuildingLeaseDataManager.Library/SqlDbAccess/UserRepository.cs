using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class UserRepository : IGenericRepository<UserModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spUser_Delete",
                                          new { Id = id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<UserModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<UserModel>("dbo.spUser_GetAll",
                                                   new { },
                                                   commandType: CommandType.StoredProcedure).AsList();
            }
        }
        public UserModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<UserModel>("dbo.spUser_GetById",
                                                          new { Id = id },
                                                          commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(UserModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    UserName = entity.UserName,
                    Password = entity.Password,
                    GradeTypeId = entity.GradeTypeId,
                    UseFlag = entity.UseFlag,
                    InsertUserId = entity.InsertUserId,
                    UpdateUserId = entity.UpdateUserId
                });

                connection.Execute("dbo.spUser_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(UserModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spUser_Update",
                                          new
                                          {
                                              Id = entity.Id,
                                              UserName = entity.UserName,
                                              Password = entity.Password,
                                              GradeTypeId = entity.GradeTypeId,
                                              UseFlag = entity.UseFlag,
                                              UpdateUserId = entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public UserModel GetByName(string userName, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<UserModel>("dbo.spUser_GetByName",
                                                          new { UserName = userName },
                                                          commandType: CommandType.StoredProcedure).AsList();
                return results.FirstOrDefault();
            }
        }

        public bool Exists(string userName, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spUser_Exists",
                                                      new { UserName = userName },
                                                      commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdatePassword(int id, string password, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spUser_UpdatePassword",
                                          new
                                          {
                                              Id = id,
                                              Password = password
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }
    }
}
