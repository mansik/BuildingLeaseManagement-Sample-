using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class OutgoingsBookRepository
    {
        public List<OutgoingsBookDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                         DateTime toDate,
                                                         int accountCodeId,
                                                         string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<OutgoingsBookDisplayModel>("dbo.spOutgoingsBook_GetsDisplayByFromToDate",
                                                               new
                                                               {
                                                                   FromDate = fromDate.Date,
                                                                   ToDate = toDate.Date,
                                                                   AccountCodeId = accountCodeId
                                                               },
                                                               commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
