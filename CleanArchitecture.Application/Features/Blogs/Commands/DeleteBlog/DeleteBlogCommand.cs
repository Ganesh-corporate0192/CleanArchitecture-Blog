using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog;

public class DeleteBlogCommand : IRequest
{
    public int Id { get; set; }

    public DeleteBlogCommand(int id)
    {
        Id = id;
    }
}