using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common
{
    public interface IBlogQueryRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog?> GetByIdAsync(int id);
    }
}