using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}