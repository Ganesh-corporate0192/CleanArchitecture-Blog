using MediatR;
using CleanArchitecture.Application.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs
{
    public class GetAllBlogsQueryHandler
        : IRequestHandler<GetAllBlogsQuery, List<Blog>>
    {
        private readonly IBlogQueryRepository _repository;

        public GetAllBlogsQueryHandler(IBlogQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Blog>> Handle(
            GetAllBlogsQuery request,
            CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}