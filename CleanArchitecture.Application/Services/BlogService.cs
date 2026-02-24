using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Services
{
    public class BlogService
    {
        private readonly IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        // ✅ GET ALL
        public async Task<IEnumerable<BlogResponseDto>> GetAllAsync()
        {
            var blogs = await _repository.GetAllAsync();

            return blogs.Select(blog => new BlogResponseDto
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
                ImageUrl = blog.ImageUrl
            });
        }

        // ✅ GET BY ID
        public async Task<BlogResponseDto?> GetByIdAsync(int id)
        {
            var blog = await _repository.GetByIdAsync(id);

            if (blog == null) return null;

            return new BlogResponseDto
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
                ImageUrl = blog.ImageUrl
            };
        }

        // ✅ CREATE (No Id required)
        public async Task<BlogResponseDto> AddAsync(CreateBlogDto dto)
        {
            var blog = new Blog
            {
                Name = dto.Name,
                Description = dto.Description,
                Author = dto.Author,
                ImageUrl = dto.ImageUrl
            };

            await _repository.AddAsync(blog);

            // After SaveChanges, EF auto-generates Id
            return new BlogResponseDto
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                Author = blog.Author,
                ImageUrl = blog.ImageUrl
            };
        }

        // ✅ UPDATE
        public async Task UpdateAsync(int id, CreateBlogDto dto)
        {
            var blog = await _repository.GetByIdAsync(id);

            if (blog == null)
                throw new Exception("Blog not found");

            blog.Name = dto.Name;
            blog.Description = dto.Description;
            blog.Author = dto.Author;
            blog.ImageUrl = dto.ImageUrl;

            await _repository.UpdateAsync(blog);
        }

        // ✅ DELETE
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}