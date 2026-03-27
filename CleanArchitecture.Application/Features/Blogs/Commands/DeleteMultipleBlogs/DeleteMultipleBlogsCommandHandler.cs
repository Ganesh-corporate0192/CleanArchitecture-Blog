//using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class DeleteMultipleBlogsHandler : IRequestHandler<DeleteMultipleBlogsCommand,int>
{
    private readonly IBlogRepository _repository;

    public DeleteMultipleBlogsHandler(IBlogRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(DeleteMultipleBlogsCommand request, CancellationToken cancellationToken)
    {
        var blogs = await _repository.GetByIdsAsync(request.Ids);

        if (blogs == null || !blogs.Any())
            return 0;

        await _repository.DeleteRangeAsync(blogs);
        var affected=await _repository.SaveChangesAsync(cancellationToken);
        return affected;
    }
}