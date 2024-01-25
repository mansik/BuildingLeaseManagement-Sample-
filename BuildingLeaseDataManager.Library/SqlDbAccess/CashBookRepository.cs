using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class CashBookRepository : IGenericRepository<CashBookModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spCashBook_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<CashBookModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<CashBookModel>("dbo.spCashBook_GetAll",
                                                               new { },
                                                               commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public CashBookModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<CashBookModel>("dbo.spCashBook_GetById",
                                                                      new { Id = id },
                                                                      commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(CashBookModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    TransactionDate = entity.TransactionDate,
                    TransactionDetails = entity.TransactionDetails,
                    BankBookCodeId = entity.BankBookCodeId,
                    LesseeId = entity.LesseeId,
                    AccountCodeId = entity.AccountCodeId,
                    Creditor = entity.Creditor,
                    ExpenseNumber = entity.ExpenseNumber,
                    DepositAmount = entity.DepositAmount,
                    WithdrawalAmount = entity.WithdrawalAmount,
                    LossAmount = entity.LossAmount,
                    Notes = entity.Notes,
                    InOutgoings = entity.InOutgoings,
                    DelFlag = entity.DelFlag,
                    InsertUserId = entity.InsertUserId,
                    UpdateUserId = entity.UpdateUserId
                });

                connection.Execute("dbo.spCashBook_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(CashBookModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spCashBook_Update",
                                          new
                                          {
                                              Id = entity.Id,
                                              TransactionDate = entity.TransactionDate,
                                              TransactionDetails = entity.TransactionDetails,
                                              BankBookCodeId = entity.BankBookCodeId,
                                              LesseeId = entity.LesseeId,
                                              AccountCodeId = entity.AccountCodeId,
                                              Creditor = entity.Creditor,
                                              ExpenseNumber = entity.ExpenseNumber,
                                              DepositAmount = entity.DepositAmount,
                                              WithdrawalAmount = entity.WithdrawalAmount,
                                              LossAmount = entity.LossAmount,
                                              Notes = entity.Notes,
                                              InOutgoings = entity.InOutgoings,
                                              DelFlag = entity.DelFlag,
                                              UpdateUserId = entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        // Display라는 이름은 별도의 DisplayModel을 반환하는 경우에 붙인다.        
        public List<CashBookDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                         DateTime toDate,
                                                         string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<CashBookDisplayModel>("dbo.spCashBook_GetsDisplayByFromToDate",
                                                               new
                                                               {
                                                                   FromDate = fromDate.Date,
                                                                   ToDate = toDate.Date
                                                               },
                                                               commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public decimal GetPreviousAmountByDate(DateTime baseDate, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<decimal>("dbo.spCashBook_GetPreviousAmountByDate",
                                                         new { BaseDate = baseDate.Date },
                                                         commandType: CommandType.StoredProcedure);
            }
        }

    }
}
