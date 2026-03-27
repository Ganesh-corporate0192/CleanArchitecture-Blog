using MediatR;
using CleanArchitecture.Domain.Interface;

namespace CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog;

public class DeleteBlogCommandHandler
    : IRequestHandler<DeleteBlogCommand,bool>
{
    private readonly IBlogRepository _repository;

    public DeleteBlogCommandHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(
        DeleteBlogCommand request,
        CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}