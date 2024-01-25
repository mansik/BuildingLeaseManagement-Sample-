using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BuildingLeaseDataManager.Library.Internal.DataAccess
{
    /// <summary>
    /// Dapper를 직접 사용하는 예제
    /// </summary>
    class DapperSample
    {
        public List<UserModel> GetAll(string connectionName = "Default")
        {
            //using (IDbConnection connection = new DBConnection().GetConnection(connectionName)) // sqlclient를 참조할 필요가 없다.
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Query<UserModel>("dbo.spUser_GetAll", new { }, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public UserModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                var results = connection.Query<UserModel>("dbo.spUser_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(UserModel user, string connectionName = "Default")
        {
            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, UserFlag = user.UseFlag, user.InsertUserId });

            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                connection.Execute("dbo.spUser_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(UserModel user, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Execute("dbo.spUser_Update", user, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Execute("dbo.spUser_Delete", new { Id = id }, commandType: CommandType.StoredProcedure) > 0;
            }
        }


    }
}
