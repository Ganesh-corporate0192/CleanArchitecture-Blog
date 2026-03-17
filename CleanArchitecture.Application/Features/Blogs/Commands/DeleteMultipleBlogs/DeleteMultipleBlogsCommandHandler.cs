//using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class DeleteMultipleBlogsHandler : IRequestHandler<DeleteMultipleBlogsCommand>
{
    private readonly IBlogRepository _repository;

    public DeleteMultipleBlogsHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteMultipleBlogsCommand request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.GetByIdsAsync(request.Ids);

        if (blogs == null || !blogs.Any())
            throw new Exception("No blogs found to delete");

        await _repository.DeleteRangeAsync(blogs);
    }
}