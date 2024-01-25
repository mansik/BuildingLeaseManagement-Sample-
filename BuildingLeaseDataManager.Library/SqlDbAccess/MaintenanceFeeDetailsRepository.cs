using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class MaintenanceFeeDetailsRepository
    {
        public int? Insert(MaintenanceFeeDetailsModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.MaintenanceFeeDetailsDate,
                    entity.BuildingRoomCodeId,
                    entity.LesseeId,
                    entity.ReceivableAmount,
                    entity.MonthlyRent,
                    entity.MonthlyRentVAT,
                    entity.MaintenanceFee,
                    entity.MaintenanceFeeVAT,
                    entity.ElectricBill,
                    entity.ElectricBillVAT,
                    entity.WaterBill,
                    entity.RoadOccupancyFee,
                    entity.RoadOccupancyFeeVAT,
                    entity.TrafficCausingCharge,
                    entity.TrafficCausingChargeVAT,
                    entity.InsertUserId,
                    entity.UpdateUserId
                });

                connection.Execute("dbo.spMaintenanceFeeDetails_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(MaintenanceFeeDetailsModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spMaintenanceFeeDetails_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.MaintenanceFeeDetailsDate,
                                              entity.BuildingRoomCodeId,
                                              entity.LesseeId,
                                              entity.ReceivableAmount,
                                              entity.MonthlyRent,
                                              entity.MonthlyRentVAT,
                                              entity.MaintenanceFee,
                                              entity.MaintenanceFeeVAT,
                                              entity.ElectricBill,
                                              entity.ElectricBillVAT,
                                              entity.WaterBill,
                                              entity.RoadOccupancyFee,
                                              entity.RoadOccupancyFeeVAT,
                                              entity.TrafficCausingCharge,
                                              entity.TrafficCausingChargeVAT,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<MaintenanceFeeDetailsDisplayModel> GetsDisplayByDate(DateTime maintenanceFeeDetailsDate, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<MaintenanceFeeDetailsDisplayModel>("dbo.spMaintenanceFeeDetails_GetsDisplayByDate",
                                                           new
                                                           {
                                                               MaintenanceFeeDetailsDate = maintenanceFeeDetailsDate.Date,
                                                               BuildingCodeId = buildingCodeId
                                                           },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public bool InitByDate(DateTime maintenanceFeeDetailsDate, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spMaintenanceFeeDetails_InitByDate",
                                          new
                                          {
                                              MaintenanceFeeDetailsDate = maintenanceFeeDetailsDate.Date,
                                              BuildingCodeId = buildingCodeId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
