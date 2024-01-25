using BuildingLeaseDataManager.Library.Internal.DataAccess;
using BuildingLeaseDataManager.Library.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public class IncomingsBookRepository
    {
        public List<IncomingsBookDisplayModel> GetsDisplayByFromToDate(DateTime fromDate,
                                                                DateTime toDate,
                                                                int lesseeId,
                                                                string connectionName = "Default")
        {
            using (IDbConnection connection = new DBConnection().GetConnection(connectionName))
            {
                return connection.Query<IncomingsBookDisplayModel>("dbo.spIncomingsBook_GetsDisplayByFromToDate",
                                                               new
                                                               {
                                                                   FromDate = fromDate.Date,
                                                                   ToDate = toDate.Date,
                                                                   LesseeId = lesseeId
                                                               },
                                                               commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}
