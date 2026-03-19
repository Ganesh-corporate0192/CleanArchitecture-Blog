using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class UpsertMultipleBlogsCommandHandler
    : IRequestHandler<UpsertMultipleBlogsCommand, UpsertResult>
{
    private readonly IBlogRepository _repository;
    private readonly IBlogUpsertService _upsertService;

    public UpsertMultipleBlogsCommandHandler(
        IBlogRepository repository,
        IBlogUpsertService upsertService)
    {
        _repository = repository;
        _upsertService = upsertService;
    }

    public async Task<UpsertResult> Handle(
        UpsertMultipleBlogsCommand request,
        CancellationToken cancellationToken)
    {
        var result = new UpsertResult();
        var createdBlogs = new List<Blog>();

        // 🔹 Step 1: Get IDs
        var ids = request.Blogs
            .Where(x => x.Id > 0)
            .Select(x => x.Id)
            .Distinct()
            .ToList();

        // 🔹 Step 2: Fetch existing
        var existingBlogs = await _repository.GetByIdsAsync(ids);
        var existingDict = existingBlogs.ToDictionary(b => b.Id);

        // 🔹 Step 3: Process
        foreach (var dto in request.Blogs)
        {
            // 🟢 CREATE
            if (dto.Id == 0)
            {
                var blog = await _upsertService.CreateAsync(dto);
                createdBlogs.Add(blog);
                result.Created++;
                continue;
            }

            // 🟡 UPDATE
            if (existingDict.TryGetValue(dto.Id, out var existing))
            {
                await _upsertService.UpdateAsync(existing, dto);

                result.Updated++;
                result.UpdatedIds.Add(existing.Id);
                continue;
            }

            // 🔵 FALLBACK CREATE
            var newBlog = await _upsertService.CreateAsync(dto);
            createdBlogs.Add(newBlog);
            result.Created++;
        }

        // 🔹 Save once
        await _repository.SaveChangesAsync();

        result.CreatedIds = createdBlogs.Select(b => b.Id).ToList();

        return result;
    }
}