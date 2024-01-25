using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Data;
using System.Linq;
using static Dapper.SqlMapper;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    /// <summary>
    /// 금전출납부 - 지출번호
    /// </summary>
    public class ConfigRepository
    {
        public ConfigModel GetFirst(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<ConfigModel>("dbo.spConfig_GetFirst",
                                                          new { },
                                                          commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public bool InsertUpdate(ConfigModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spConfig_InsertUpdate",
                                          new
                                          {
                                              OfficeTel = entity.OfficeTel,
                                              OfficeEmail = entity.OfficeEmail,
                                              LastExpenseNumber = entity.LastExpenseNumber
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public int GetLastExpenseNumber(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<int>("dbo.spConfig_GetLastExpenseNumber",
                                                     new { },
                                                     commandType: CommandType.StoredProcedure);
            }
        }

        public bool LastExpenseNumber_InsertUpdate(int expenseNumber, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spConfig_LastExpenseNumber_InsertUpdate",
                                          new
                                          {
                                              LastExpenseNumber = expenseNumber
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
