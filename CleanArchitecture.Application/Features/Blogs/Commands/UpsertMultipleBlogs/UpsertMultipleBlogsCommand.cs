using MediatR;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs
{
    using MediatR;

    public record UpsertMultipleBlogsCommand(List<UpsertBlogDto> Blogs) : IRequest<UpsertResult>;

}