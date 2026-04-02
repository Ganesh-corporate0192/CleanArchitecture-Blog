//using CleanArchitecture.Application.DTOs;
//using CleanArchitecture.Domain.Entities;
//using CleanArchitecture.Domain.Interface;

//public class BlogUpsertService : IBlogUpsertService
//{
//    private readonly IBlogRepository _repository;

//    public BlogUpsertService(IBlogRepository repository)
//    {
//        _repository = repository;
//    }

//    public async Task<Blog> CreateAsync(UpsertBlogDto dto)
//    {
//        var blog = new Blog
//        (
//             dto.Name,
//           dto.Description,
//             dto.Author,
//            dto.ImageUrl
//        );

//        await _repository.AddAsync(blog);
//        return blog;
//    }

//    public Task UpdateAsync(Blog existing, UpsertBlogDto dto)
//    {
//        existing.Update(
//        dto.Name,
//        dto.Description,
//        dto.Author,
//        dto.ImageUrl
//    );


//        return Task.CompletedTask;
//    }
//}