using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class CreateBlogCommandHandler
    : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IBlogUpsertService _upsertService;

    public CreateBlogCommandHandler(IBlogUpsertService upsertService)
    {
        _upsertService = upsertService;
    }

    public async Task<int> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var dto = new UpsertBlogDto
        {
            Name = request.Name,
            Description = request.Description,
            Author = request.Author,
            ImageUrl = request.ImageUrl
        };

        var blog = await _upsertService.CreateAsync(dto);

        return blog.Id;
    }
}