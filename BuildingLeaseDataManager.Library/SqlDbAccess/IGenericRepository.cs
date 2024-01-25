using System.Collections.Generic;

namespace BuildingLeaseDataManager.Library.SqlDbAccess
{
    public interface IGenericRepository<T>
    {
        T GetById(int id, string connectionName = "Default");
        List<T> GetAll(string connectionName = "Default");
        int? Insert(T entity, string connectionName = "Default");
        bool Update(T entity, string connectionName = "Default");
        bool Delete(int id, string connectionName = "Default");
    }
}
