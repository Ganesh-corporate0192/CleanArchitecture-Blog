using CleanArchitecture.Application.Common.Models.Queries.Responses;
using CleanArchitecture.Application.Common.QueryRequestModels.Queries.Models;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common
{
    public interface IBlogQueryService
    {
        Task<List<BlogResponse>> GetAllAsync();
        Task<BlogResponse> GetByIdAsync(int id);
    }
}