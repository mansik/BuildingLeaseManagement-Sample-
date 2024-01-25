using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.DataAccess
{
    /// <summary>
    /// SqlDataAccess를 이용하는 예제 
    /// </summary>
    class SqlDataAccessSample
    {
        public List<UserModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.Query<UserModel, dynamic>("dbo.spUser_GetAll", new { }, commandType: CommandType.StoredProcedure).AsList();
        }

        public UserModel GetById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var results = sql.Query<UserModel, dynamic>("dbo.spUser_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
            return results.FirstOrDefault();
        }

        public int? Insert(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, user.UseFlag, user.InsertUserId });

            sql.Execute("dbo.spUser_Insert", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("@Id");
        }

        public bool Update(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.Execute("dbo.spUser_Update", user);
        }

        public bool Delete(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.Execute("dbo.spUser_Delete", new { Id = id });
        }

        public bool Exists(string name)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.ExecuteScalar<bool, dynamic>("dbo.spUser_Exists",
                                                      new { UserName = name },
                                                      commandType: CommandType.StoredProcedure);

        }
    }
}
