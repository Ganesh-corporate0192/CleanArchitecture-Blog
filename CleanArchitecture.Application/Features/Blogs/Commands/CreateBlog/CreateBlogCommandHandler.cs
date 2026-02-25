using AutoMapper;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using MediatR;

public class CreateBlogCommandHandler
    : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IBlogRepository _repository;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(
        IBlogRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken)
    {
        var blog = _mapper.Map<Blog>(request);

        await _repository.AddAsync(blog);

        return blog.Id;
    }
}