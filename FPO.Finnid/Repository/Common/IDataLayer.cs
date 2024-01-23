using System.Collections.Generic;
using System.Threading.Tasks;

namespace finnit.Repository.Common
{
    public interface IDataLayer
    {
        object ExcuteNonQuery(string procedureName, object parameters);
        Task<object> ExcuteNonQueryAsync(string procedureName, object parameters);
        object Query(string procedureName, object parameters);
        Task<object> QueryAsync(string procedureName, object parameters);
        object QueryFirstOrDefault(string procedureName, object parameters);
        Task<object> QueryFirstOrDefaultAsync(string procedureName, object parameters);
        object QueryFirstOrDefaultWithDBResponse(string procedureName, object parameters);
        Task<object> QueryFirstOrDefaultAsyncWithDBResponse(string procedureName, object parameters);
        object QueryWithOutCusRes(string procedureName, object parameters);
        Task<List<T>> GetAllAsync<T>(string Procname, object param = null);
    }
}
