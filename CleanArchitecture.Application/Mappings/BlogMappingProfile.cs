using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Mappings;

public class BlogMappingProfile : Profile
{
    public BlogMappingProfile()
    {
        CreateMap<CreateBlogCommand, Blog>();

        CreateMap<Blog, BlogResponseDto>();
    }
}