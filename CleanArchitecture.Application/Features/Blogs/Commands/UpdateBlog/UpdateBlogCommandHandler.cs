using MediatR;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommandHandler
    : IRequestHandler<UpdateBlogCommand>
{
    private readonly IBlogRepository _repository;

    public UpdateBlogCommandHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(
        UpdateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.Id);

        if (blog is null)
            throw new NotFoundException("Blog", request.Id);

        blog.Name = request.Name;
        blog.Description = request.Description;
        blog.Author = request.Author;
        blog.ImageUrl = request.ImageUrl;

        await _repository.UpdateAsync(blog);
    }
}