using BuildingLeaseDataManager.Library.Internal.DataAccess;
using Dapper;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class DBBackupRepository
    {
        public string DBBackup(string backupPath, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                // ParameterDirection.Output이고 DBType.String 이면 반드시 size 를 입력해야 한다.
                var p = new DynamicParameters();
                p.Add("@BackupPath", backupPath);
                p.Add("@FullFileName", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                connection.Execute("dbo.sp_DBBackup", p, commandType: CommandType.StoredProcedure);
                return p.Get<string>("@FullFileName");
            }
        }
    }
}
