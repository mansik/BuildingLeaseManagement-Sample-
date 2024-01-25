﻿using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class BankBookCodeRepository : IGenericRepository<BankBookCodeModel>
    {
        public bool Delete(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spBankBookCode_Delete",
                                          new { id },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public List<BankBookCodeModel> GetAll(string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<BankBookCodeModel>("dbo.spBankBookCode_GetAll",
                                                           new { },
                                                           commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public BankBookCodeModel GetById(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var results = connection.Query<BankBookCodeModel>("dbo.spBankBookCode_GetById",
                                                                  new { Id = id },
                                                                  commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }
        }

        public int? Insert(BankBookCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                var p = new DynamicParameters();
                p.Add("@Id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.AddDynamicParams(new
                {
                    entity.BankBookName,
                    entity.BankName,
                    entity.AccountNumber,
                    entity.Notes,
                    entity.DisplaySeq,
                    entity.UseFlag,
                    entity.InsertUserId,
                    entity.UpdateUserId
                });

                connection.Execute("dbo.spBankBookCode_Insert", p, commandType: CommandType.StoredProcedure);
                return p.Get<int>("@Id");
            }
        }

        public bool Update(BankBookCodeModel entity, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Execute("dbo.spBankBookCode_Update",
                                          new
                                          {
                                              entity.Id,
                                              entity.BankBookName,
                                              entity.BankName,
                                              entity.AccountNumber,
                                              entity.Notes,
                                              entity.DisplaySeq,
                                              entity.UseFlag,
                                              entity.UpdateUserId
                                          },
                                          commandType: CommandType.StoredProcedure) > 0;
                // 프로지서에서 SET NOCOUNT ON 사용하지 말아야 Execute()의 반환값으로 영향받는 row수가 온다.
            }
        }

        public bool Exists(string name, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spBankBookCode_Exists",
                                                       new { BankBookName = name },
                                                       commandType: CommandType.StoredProcedure);
            }
        }

        public bool IsUsed(int id, string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.ExecuteScalar<bool>("dbo.spBankBookCode_IsUsed",
                                                      new { Id = id },
                                                      commandType: CommandType.StoredProcedure);
            }
        }
    }
}
