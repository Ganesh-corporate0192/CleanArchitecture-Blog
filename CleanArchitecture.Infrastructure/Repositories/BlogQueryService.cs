using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Models.Queries.Responses;
using CleanArchitecture.Infrastructure.QueryHelpers;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogQueryService : IBlogQueryService
    {
        private readonly IQueryHelper _queryHelper;

        public BlogQueryService(IQueryHelper queryHelper)
        {
            _queryHelper = queryHelper;
        }

        public async Task<List<BlogResponse>> GetAllAsync()
        {
            return await _queryHelper.QueryAsync<BlogResponse>(
                Path.Combine("Blog", "GetAllBlogs.sql"));
        }

        public async Task<BlogResponse> GetByIdAsync(int id)
        {
            return await _queryHelper.QueryFirstOrDefaultAsync<BlogResponse>(
                Path.Combine("Blog", "GetBlogById.sql"),
                new { Id = id });
        }
    }
}