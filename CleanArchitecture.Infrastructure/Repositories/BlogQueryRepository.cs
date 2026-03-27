using Dapper;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;
using System.Data;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogQueryRepository : IBlogQueryService
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public BlogQueryRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM Blogs order by Id desc";

            var result = await connection.QueryAsync<Blog>(sql);

            return result.ToList();
        }

        public async Task<Blog?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = "SELECT * FROM Blogs WHERE Id = @Id";

            return await connection.QueryFirstOrDefaultAsync<Blog>(
                sql,
                new { Id = id });
        }
    }
}