using CleanArchitecture.Application.Common;
using CleanArchitecture.Application.Common.Models.Queries.Responses;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs;
using CleanArchitecture.Application.Common.QueryRequestModels.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator ;
    private readonly IBlogQueryService _queryService;

    public BlogsController(
        IMediator mediator,
        IBlogQueryService queryService)
    {
        _mediator = mediator;
        _queryService = queryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogResponse>>> GetAll()
    {
       

        var blogs = await _queryService.GetAllAsync();

        return Ok(blogs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogResponse>> GetById(int id)
    {
        if (id <= 0)
            return BadRequest("Blog Id must be greater than 0.");

        var blog = await _queryService.GetByIdAsync(id);

        if (blog == null)
            return NotFound($"Blog with Id {id} was not found.");

        return Ok(blog);
    }


    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCommand command)
        => Ok(await _mediator.Send(command));



    [HttpPut]
    public async Task<IActionResult> Update(UpdateBlogCommand command)
    {
        var updatedId=await _mediator.Send(command);
        return Ok(updatedId);
    }


    [HttpPost]
    public async Task<IActionResult> UpsertMultiple([FromBody] List<UpsertBlogDto> blogs)
    {
        var result=await _mediator.Send(new UpsertMultipleBlogsCommand(blogs));
        return Ok(new
        {
            success = true,
            blogs = result
        });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result= await _mediator.Send(new DeleteBlogCommand(id));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteMultiple([FromBody] List<int> ids)
    {
        var deletedCount=await _mediator.Send(new DeleteMultipleBlogsCommand(ids));
        return Ok(deletedCount);
    }
}