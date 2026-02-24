using MediatR;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;

public class GetAllBlogsQueryHandler
    : IRequestHandler<GetAllBlogsQuery, IEnumerable<BlogResponseDto>>
{
    private readonly IBlogRepository _repository;

    public GetAllBlogsQueryHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BlogResponseDto>> Handle(
        GetAllBlogsQuery request,
        CancellationToken cancellationToken)
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
}