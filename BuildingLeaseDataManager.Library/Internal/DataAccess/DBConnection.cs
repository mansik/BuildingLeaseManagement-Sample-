using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BuildingLeaseDataManager.Library.Internal.DataAccess
{
    public class DBConnection
    {
        public DBConnection()
        {
            //암호화된 connectionString을 가져오기 위해 Program으로 이동하였음
            //ConnectionStrings.Add("Default", ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            //ProvideName.Add("Default", ConfigurationManager.ConnectionStrings["Default"].ProviderName);
        }
        public static Dictionary<string, string> ConnectionStrings { get; } = new Dictionary<string, string>();
        public static Dictionary<string, string> ProvideName { get; } = new Dictionary<string, string>();

        public IDbConnection GetConnection(string connectionName = "Default")
        {
            IDbConnection connection = null;
            switch (ProvideName[connectionName])
            {
                case "System.Data.SQLite":
                    break;
                case "Oracle.ManagedDataAccess.Client":
                    break;
                default: // SqlConnection
                    connection = new SqlConnection(ConnectionStrings[connectionName]);
                    break;
            }
            return connection;
        }
    }
}
