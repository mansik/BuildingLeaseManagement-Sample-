using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class LeaseIncomingsRepository
    {
        public List<LeaseIncomingsDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                                DateTime toDate,
                                                                string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<LeaseIncomingsDisplayModel>("dbo.spLeaseIncomings_GetsDisplayByFromToDate",
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
