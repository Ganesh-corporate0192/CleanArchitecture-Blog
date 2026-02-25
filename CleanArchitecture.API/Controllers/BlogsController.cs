using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;

[ApiController]
[Route("[controller]/[action]")]
public class BlogsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllBlogsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }
}