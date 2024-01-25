using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BuildingLeaseDataManager.Library.Internal.DataAccess
{
    /// <summary>
    /// MS SQL Server 접근
    /// </summary>
    public class SqlDataAccess
    {
        // DB password를 암호화하지 않은 경우 사용
        public string GetConnecionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        #region "CommandType 변경가능"
        #region Sync
        public List<dynamic> Query<U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            //using (IDbConnection connection = new SqlConnection(GetConnectionString(connectionName))
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Query(sql, parameters, commandType: commandType).AsList();
            }
        }

        public List<T> Query<T, U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Query<T>(sql, parameters, commandType: commandType).AsList();
            }
        }

        public bool Execute<U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Execute(sql, parameters, commandType: commandType) > 0;
            }
        }

        public T ExecuteScalar<T, U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.ExecuteScalar<T>(sql, parameters, commandType: commandType);
            }
        }
        #endregion

        #region Async
        // Async
        public async Task<IEnumerable<dynamic>> QueryAsync<U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return await connection.QueryAsync(sql, parameters, commandType: commandType);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return await connection.QueryAsync<T>(sql, parameters, commandType: commandType);
            }
        }

        public async Task ExecuteAsync<U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                await connection.ExecuteAsync(sql, parameters, commandType: commandType);
            }
        }

        public async Task<T> ExecuteScalarAsync<T, U>(string sql, U parameters, CommandType commandType = CommandType.Text, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return await connection.ExecuteScalarAsync<T>(sql, parameters, commandType: commandType);
            }
        }
        #endregion
        #endregion

        #region "CommandType.StoredProcedure로 질의"
        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionName = "Default")
        {
            //using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString))
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public bool SaveData<T>(string storedProcedure, T parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                return connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionName = "Default")
        {
            using (IDbConnection connection = new SqlConnection(DBConnection.ConnectionStrings[connectionName]))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        #endregion
    }
}
