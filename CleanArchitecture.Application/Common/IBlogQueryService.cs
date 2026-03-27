using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common
{
    public interface IBlogQueryService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
    }
}