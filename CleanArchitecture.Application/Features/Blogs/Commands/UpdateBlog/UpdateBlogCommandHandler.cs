using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class UpdateBlogCommandHandler
    : IRequestHandler<UpdateBlogCommand>
{
    private readonly IBlogRepository _repository;
    private readonly IBlogUpsertService _upsertService;

    public UpdateBlogCommandHandler(
        IBlogRepository repository,
        IBlogUpsertService upsertService)
    {
        _repository = repository;
        _upsertService = upsertService;
    }

    public async Task Handle(
        UpdateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.Id);

        if (blog is null)
            throw new NotFoundException("Blog", request.Id);

        var dto = new UpsertBlogDto
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Author = request.Author,
            ImageUrl = request.ImageUrl
        };

        await _upsertService.UpdateAsync(blog, dto);

        await _repository.UpdateAsync(blog);
    }
}