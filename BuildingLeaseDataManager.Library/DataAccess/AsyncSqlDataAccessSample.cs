using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingLeaseDataManager.Library.DataAccess
{
    /// <summary>
    /// SqlDataAccess의 Async를 이용하는 예제 
    /// </summary>
    class AsyncSqlDataAccessSample
    {
        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.QueryAsync<UserModel, dynamic>("dbo.spUser_GetAll", new { }, commandType: CommandType.StoredProcedure);

        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var results = await sql.QueryAsync<UserModel, dynamic>("dbo.spUser_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return results.FirstOrDefault();
        }

        public async Task<int?> InsertUserAsync(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, user.UseFlag, user.InsertUserId });

            await sql.ExecuteAsync("dbo.spUser_Insert", p);
            return p.Get<int>("@Id");
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();
            await sql.ExecuteAsync("dbo.spUser_Update", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            await sql.ExecuteAsync("dbo.spUser_Delete", new { Id = id });
        }

        public async Task<bool> ExistsAsync(string name, string connectionName = "Default")
        {
            SqlDataAccess sql = new SqlDataAccess();

            return await sql.ExecuteScalarAsync<bool, dynamic>("dbo.spUser_Exists",
                                                      new { UserName = name },
                                                      commandType: CommandType.StoredProcedure);
        }
    }
}
