using MediatR;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;

public class GetAllBlogsQuery : IRequest<IEnumerable<BlogResponseDto>>
{
}