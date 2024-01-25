using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class InvoiceRepository : IGenericRepository<InvoiceModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spInvoice_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<InvoiceModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<InvoiceModel>("dbo.spInvoice_GetAll",
                                                           new { },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public InvoiceModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<InvoiceModel>("dbo.spInvoice_GetById",
                                                                  new { Id = id },
                                                                  commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(InvoiceModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.InvoiceDate,
                    entity.BuildingRoomCodeId,
                    entity.LesseeId,
                    entity.BillIssueDay,
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

                connection.Execute("dbo.spInvoice_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(InvoiceModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spInvoice_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.InvoiceDate,
                                              entity.BuildingRoomCodeId,
                                              entity.LesseeId,
                                              entity.BillIssueDay,
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

        public bool Exists(DateTime invoiceDate, int buildingRoomCodeId, int lesseeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spInvoice_Exists",
                                                       new
                                                       {
                                                           InvoiceDate = invoiceDate,
                                                           BuildingRoomCodeId = buildingRoomCodeId,
                                                           LesseeId = lesseeId
                                                       },
                                                       commandType: CommandType.StoredProcedure);
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<InvoiceDisplayModel> GetsDisplayByDate(DateTime invoiceDate, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<InvoiceDisplayModel>("dbo.spInvoice_GetsDisplayByDate",
                                                           new
                                                           {
                                                               InvoiceDate = invoiceDate.Date,
                                                               BuildingCodeId = buildingCodeId
                                                           },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public bool InitByDate(DateTime invoiceDate, int buildingCodeId, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spInvoice_InitByDate",
                                          new
                                          {
                                              InvoiceDate = invoiceDate.Date,
                                              BuildingCodeId = buildingCodeId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
            }
        }

        /// <summary>
        /// BuildingCodeId 포함
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public List<InvoiceDisplayModel> GetAllDisplayByDate(DateTime invoiceDate, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<InvoiceDisplayModel>("dbo.spInvoice_GetAllDisplayByDate",
                                                           new
                                                           {
                                                               InvoiceDate = invoiceDate.Date
                                                           },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
