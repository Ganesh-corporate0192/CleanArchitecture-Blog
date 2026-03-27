using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;

        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }


        public async Task<Blog?> GetByIdAsync(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public async Task AddAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            
        }

        public  Task UpdateAsync(Blog blog)
        {
            _context.Blogs.Update(blog);
            return Task.CompletedTask;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
                return false;

            _context.Blogs.Remove(blog);

            return true;
        }

        public async Task<List<Blog>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Blogs
                .Where(b => ids.Contains(b.Id))
                .ToListAsync();
        }

        public Task DeleteRangeAsync(List<Blog> blogs)
        {
            _context.Blogs.RemoveRange(blogs);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}