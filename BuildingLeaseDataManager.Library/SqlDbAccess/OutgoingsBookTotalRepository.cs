using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class OutgoingsBookTotalRepository
    {
        public List<OutgoingsBookTotalDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                                            DateTime toDate,
                                                                            string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<OutgoingsBookTotalDisplayModel>("dbo.spOutgoingsBookTotal_GetsDisplayByFromToDate",
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
