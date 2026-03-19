using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Domain.Entities;

public interface IBlogUpsertService
{
    Task<Blog> CreateAsync(UpsertBlogDto dto);
    Task UpdateAsync(Blog existing, UpsertBlogDto dto);
}