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
    /// Query를 통한 결과 처리
    /// </summary>
    public class UserData
    {
        public List<UserModel> GetAll()
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
        }

        public Task<IEnumerable<UserModel>> GetAllAsync()
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.LoadDataAsync<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
        }

        public UserModel GetById(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var results = sql.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetById", new { Id = id }); // 명시적 파라미터 전달
            return results.FirstOrDefault();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var results = await sql.LoadDataAsync<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetById", new { id }); //암시적 파라미터 전달
            return results.FirstOrDefault();
        }

        public int? Insert(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //명시적
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, user.UseFlag, user.InsertUserId });

            sql.SaveData(storedProcedure: "dbo.spUser_Insert", p);
            return p.Get<int>("@Id");
        }

        public async Task<int?> InsertAsync(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new DynamicParameters();
            p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //암시적
            p.AddDynamicParams(new { user.UserName, user.Password, user.GradeTypeId, user.UseFlag, user.InsertUserId });

            await sql.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", p);
            return p.Get<int>("@Id");
        }

        public bool Update(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.SaveData(storedProcedure: "dbo.spUser_Update", user);
        }

        public Task UpdateAsync(UserModel user)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.SaveDataAsync(storedProcedure: "dbo.spUser_Update", user);
        }

        public bool Delete(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });
        }

        public Task DeleteAsync(int id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.SaveDataAsync(storedProcedure: "dbo.spUser_Delete", new { Id = id });
        }

        public bool Exists(string name)
        {
            SqlDataAccess sql = new SqlDataAccess();

            return sql.ExecuteScalar<bool, dynamic>("dbo.spUser_Exists",
                                                      new { UserName = name },
                                                      commandType: CommandType.StoredProcedure);

        }

        public async Task<bool> ExistsAsync(string name, string connectionName = "Default")
        {
            SqlDataAccess sql = new SqlDataAccess();

            return await sql.ExecuteScalarAsync<bool, dynamic>("dbo.spUser_Exists",
                                                      new { UserName = name },
                                                      commandType: CommandType.StoredProcedure);
        }


        // 여기까지 Default임

        // 여기부터 프로젝트별 추가
        public UserModel GetByName(string userName)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var results = sql.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetByName", new { userName });
            return results.FirstOrDefault();
        }

        // SqlDataAccess.Query() 사용 방법
        public dynamic Test()
        {
            SqlDataAccess sql = new SqlDataAccess();

            List<dynamic> tmp = sql.Query("select UserName from [User]", new { });

            // tmp의 사용
            if (tmp != null)
            {
                System.Diagnostics.Debug.WriteLine(tmp[0].UserName as string);
            }

            return tmp;
        }
    }
}
