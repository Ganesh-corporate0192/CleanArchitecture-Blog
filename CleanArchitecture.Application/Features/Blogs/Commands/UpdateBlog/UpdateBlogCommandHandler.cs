using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Interface;
using MediatR;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand,int>
{
    private readonly IBlogRepository _repository;

    public UpdateBlogCommandHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(
        UpdateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.Id);

        if (blog is null)
            throw new NotFoundException("Blog", request.Id);

        blog.Update(
           request.Name,
           request.Description,
           request.Author,
           request.ImageUrl
       );

        await _repository.UpdateAsync(blog);

        await _repository.SaveChangesAsync(cancellationToken);

        return blog.Id;
    }
}