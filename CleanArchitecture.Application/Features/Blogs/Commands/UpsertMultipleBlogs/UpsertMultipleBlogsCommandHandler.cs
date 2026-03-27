using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class UpsertMultipleBlogsCommandHandler
    : IRequestHandler<UpsertMultipleBlogsCommand, UpsertResult>
{
    private readonly IBlogRepository _repository;
    private readonly IMediator _mediator;

    public UpsertMultipleBlogsCommandHandler(
        IBlogRepository repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<UpsertResult> Handle(
        UpsertMultipleBlogsCommand request,
        CancellationToken cancellationToken)
    {
        var result = new UpsertResult();

        if (request.Blogs == null || !request.Blogs.Any())
            return result;

        //var ids = request.Blogs
        //    .Where(x => x.Id > 0)
        //    .Select(x => x.Id)
        //    .Distinct()
        //    .ToList();

        //var existingBlogs = await _repository.GetByIdsAsync(ids);
        //var existingIds = existingBlogs
        //    .Select(x => x.Id)
        //    .ToHashSet();

        foreach (var dto in request.Blogs)
        {
            Console.WriteLine($"DTO Id = {dto.Id}, Name = {dto.Name}");

            if (dto.Id == 0)
            {
                var createdId = await _mediator.Send(
                    new CreateBlogCommand
                    {
                        Name = dto.Name,
                        Description = dto.Description,
                        Author = dto.Author,
                        ImageUrl = dto.ImageUrl
                    },
                    cancellationToken);

                result.Created++;
               
                result.CreatedIds.Add(createdId);
                continue;
            }

            else
            {

                await _mediator.Send(
                    new UpdateBlogCommand
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        Description = dto.Description,
                        Author = dto.Author,
                        ImageUrl = dto.ImageUrl
                    },
                    cancellationToken);

                result.Updated++;
                result.UpdatedIds.Add(dto.Id);
            }
        }

        return result;
    }
}