using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class GradeTypeRepository : IGenericRepository<GradeTypeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spGradeType_Delete", new { id }, commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public List<GradeTypeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<GradeTypeModel>("dbo.spGradeType_GetAll", new { }, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public GradeTypeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<GradeTypeModel>("dbo.spGradeType_GetById", new { id }, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();

            }
        }

        public int? Insert(GradeTypeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new { GradeTypeName = entity.GradeTypeName, DisplaySeq = entity.DisplaySeq, UseFlag = entity.UserFlag, InsertUserId = entity.InsertUserId });

                connection.Execute("dbo.spGradeType_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("Id");
            }
        }

        public bool Update(GradeTypeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spGradeType_Update", entity, commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
