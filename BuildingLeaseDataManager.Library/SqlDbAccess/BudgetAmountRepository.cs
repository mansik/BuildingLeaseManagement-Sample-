using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class BudgetAmountRepository
    {
        public List<BudgetAmountDisplayModel> GetsDisplayByDate(int fiscalYear, int inOutgoings, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<BudgetAmountDisplayModel>("dbo.spBudgetAmount_GetsDisplayByDate",
                                                           new
                                                           {
                                                               FiscalYear = fiscalYear,
                                                               InOutgoings = inOutgoings
                                                           },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public int? Insert(BudgetAmountModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.FiscalYear,
                    entity.AccountCodeId,
                    entity.BudgetAmount,
                    entity.InsertUserId,
                    entity.UpdateUserId
                });

                connection.Execute("dbo.spBudgetAmount_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(BudgetAmountModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spBudgetAmount_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.FiscalYear,
                                              entity.AccountCodeId,
                                              entity.BudgetAmount,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }
    }
}
