using MediatR;
using CleanArchitecture.Domain.Interface;
using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryHandler
    : IRequestHandler<GetBlogByIdQuery, BlogResponseDto>
{
    private readonly IBlogRepository _repository;
    private readonly IMapper _mapper;

    public GetBlogByIdQueryHandler(
        IBlogRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BlogResponseDto> Handle(
        GetBlogByIdQuery request,
        CancellationToken cancellationToken)
    {
        var blog = await _repository.GetByIdAsync(request.Id);

        if (blog == null)
            throw new NotFoundException(nameof(Blog), request.Id);

        return _mapper.Map<BlogResponseDto>(blog);
    }
}