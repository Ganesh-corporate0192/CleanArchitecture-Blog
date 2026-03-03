using MediatR;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById
{
    public class GetBlogByIdQueryHandler
        : IRequestHandler<GetBlogByIdQuery, Blog>
    {
        private readonly IBlogQueryRepository _repository;

        public GetBlogByIdQueryHandler(IBlogQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Blog> Handle(
            GetBlogByIdQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}