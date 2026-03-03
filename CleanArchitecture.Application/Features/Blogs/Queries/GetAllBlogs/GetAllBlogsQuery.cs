using MediatR;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQuery : IRequest<List<Blog>>
    {
    }
}