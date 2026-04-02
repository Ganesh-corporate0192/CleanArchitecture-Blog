using Dapper;

namespace CleanArchitecture.Infrastructure.QueryHelpers
{
    public class QueryHelper : IQueryHelper
    {
        private readonly IQueryContext _queryContext;

        public QueryHelper(IQueryContext queryContext)
        {
            _queryContext = queryContext;
        }

        public async Task<List<T>> QueryAsync<T>(
            string sqlFilePath,
            object? parameters = null)
        {
            using var connection = _queryContext.GetConnection();

            var sql = SqlQueryLoader.Load(sqlFilePath);

            var result = await connection.QueryAsync<T>(sql, parameters);

            return result.ToList();
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(
            string sqlFilePath,
            object? parameters = null)
        {
            using var connection = _queryContext.GetConnection();

            var sql = SqlQueryLoader.Load(sqlFilePath);

            return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }
    }
}