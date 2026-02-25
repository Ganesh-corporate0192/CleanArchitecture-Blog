using MediatR;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById;

public class GetBlogByIdQuery : IRequest<BlogResponseDto>
{
    public int Id { get; set; }

    public GetBlogByIdQuery(int id)
    {
        Id = id;
    }
}