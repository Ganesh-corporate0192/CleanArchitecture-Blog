using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.QueryHelpers
{
    public interface IQueryHelper
    {
        Task<List<T>> QueryAsync<T>(string sqlFilePath, object? parameters = null);
        Task<T?> QueryFirstOrDefaultAsync<T>(string sqlFilePath, object? parameters = null);
    }
}