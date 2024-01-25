using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class MaintenanceFeeDetailsSettingRepository
    {
        public MaintenanceFeeDetailsSettingModel GetByDate(DateTime maintenanceFeeDetailsDate, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<MaintenanceFeeDetailsSettingModel>("dbo.spMaintenanceFeeDetailsSetting_GetByDate",
                                                            new
                                                            {
                                                                MaintenanceFeeDetailsDate = maintenanceFeeDetailsDate,
                                                                BuildingCodeId = buildingCodeId
                                                            },
                                                            commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public bool InsertUpdate(MaintenanceFeeDetailsSettingModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spMaintenanceFeeDetailsSetting_InsertUpdate",
                                          new
                                          {
                                              entity.MaintenanceFeeDetailsDate,
                                              entity.BuildingCodeId,
                                              entity.ElectricBillTerm,
                                              entity.WaterBillTerm,
                                              entity.RoadOccupancyFeeTerm,
                                              entity.TrafficCausingChargeTerm,
                                              entity.BankBookCodeId,
                                              entity.PaymentDueDate,
                                              entity.BillIssueDate,
                                              entity.InsertUserId,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }
    }
}
