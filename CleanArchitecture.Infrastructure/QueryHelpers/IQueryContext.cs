using System.Data;

namespace CleanArchitecture.Infrastructure.QueryHelpers
{
    public interface IQueryContext
    {
        IDbConnection GetConnection();
    }
}