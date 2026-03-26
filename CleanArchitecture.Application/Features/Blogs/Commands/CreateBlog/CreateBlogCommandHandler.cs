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
        {
            Name = request.Name,
            Description = request.Description,
            Author = request.Author,
            ImageUrl = request.ImageUrl
        };

        await _repository.AddAsync(blog);

        return blog.Id;
    }
}