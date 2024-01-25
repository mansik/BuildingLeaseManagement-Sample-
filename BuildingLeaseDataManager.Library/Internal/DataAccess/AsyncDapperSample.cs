using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingLeaseDataManager.Library.Internal.DataAccess
{
    /// <summary>
    /// Dapper의 Async를 직접 사용하는 예제
    /// </summary>
    class AsyncDapperSample
    {
        public Task<IEnumerable<UserModel>> GetAllAsync(string connectionName = "Default")
        {
            //using (IDbConnection connection = new DBConnection().GetConnection(connectionName)) // sqlclient를 참조할 필요가 없다.
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.QueryAsync<UserModel>("dbo.spUser_GetAll", new { }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<UserModel> GetByIdAsync(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                var results = await connection.QueryAsync<UserModel>("dbo.spUser_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public async Task<int?> InsertAsync(UserModel user, string connectionName = "Default")
        {
            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, user.UseFlag, user.InsertUserId });

            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                await connection.ExecuteAsync("dbo.spUser_Insert", p);
                return p.Get<int>("@Id");
            }
        }

        public async Task UpdateAsync(UserModel user, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                await connection.ExecuteAsync("dbo.spUser_Update", user);
            }
        }

        public async Task DeleteAsync(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                await connection.ExecuteAsync("dbo.spUser_Delete", new { Id = id });
            }
        }
    }
}
