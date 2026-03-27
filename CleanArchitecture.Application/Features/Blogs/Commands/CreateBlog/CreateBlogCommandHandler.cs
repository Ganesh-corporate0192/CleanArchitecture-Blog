using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IBlogRepository _repository;

    public CreateBlogCommandHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = new Blog
        (
            request.Name,
            request.Description,
            request.Author,
            request.ImageUrl
        );

        await _repository.AddAsync(blog);

        await _repository.SaveChangesAsync(cancellationToken);

        return blog.Id;
    }
}