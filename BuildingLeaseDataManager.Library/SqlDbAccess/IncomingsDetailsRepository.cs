using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class IncomingsDetailsRepository
    {
        public List<IncomingsDetailsDisplayModel> GetsDisplayByFromToDate(DateTime searchDate, int totalCalcByYearFlag,
                                                                            string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<IncomingsDetailsDisplayModel>("dbo.spIncomingsDetails_GetsDisplayByFromToDate",
                                                                        new
                                                                        {
                                                                            SearchDate = searchDate.Date,
                                                                            TotalCalcByYearFlag = totalCalcByYearFlag
                                                                        },
                                                                        commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
