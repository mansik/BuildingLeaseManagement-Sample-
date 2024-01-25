using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class IncomingsBookTotalRepository
    {
        public List<IncomingsBookTotalDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                                            DateTime toDate,
                                                                            string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<IncomingsBookTotalDisplayModel>("dbo.spIncomingsBookTotal_GetsDisplayByFromToDate",
                                                                        new
                                                                        {
                                                                            FromDate = fromDate.Date,
                                                                            ToDate = toDate.Date
                                                                        },
                                                                        commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
