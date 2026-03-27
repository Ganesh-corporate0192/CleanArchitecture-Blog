using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.DeleteBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateBlog;
using CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;
using CleanArchitecture.Application.Features.Blogs.Queries.GetBlogById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class BlogsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllBlogsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var blog = await _mediator.Send(new GetBlogByIdQuery(id));

        if (blog == null)
            return NotFound(new { Message = "Blog not found" });

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

    //[HttpPut]
    //public async Task<IActionResult> UpdateMultiple(List<UpdateBlogCommand> commands)
    //{
    //    var updatedIds = new List<int>();
    //    foreach (var command in commands)
    //    {
    //    var id = await _mediator.Send(command);
    //        updatedIds.Add(id);
    //    }

    //    return Ok(updatedIds);
    //}

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