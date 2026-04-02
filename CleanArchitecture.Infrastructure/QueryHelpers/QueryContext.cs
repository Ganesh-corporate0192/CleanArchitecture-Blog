using System.Data;
using CleanArchitecture.Application.Common;

namespace CleanArchitecture.Infrastructure.QueryHelpers
{
    public class QueryContext : IQueryContext
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public QueryContext(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IDbConnection GetConnection()
        {
            return _connectionFactory.CreateConnection();
        }
    }
}