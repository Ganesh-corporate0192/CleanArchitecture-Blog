using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}