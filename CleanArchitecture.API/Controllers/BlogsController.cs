using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BlogsController : ControllerBase
{
    private readonly BlogService _service;

    public BlogsController(BlogService service)
    {
        _service = service;
    }

    // ✅ GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await _service.GetAllAsync();
        return Ok(blogs);
    }

    // ✅ GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var blog = await _service.GetByIdAsync(id);

        if (blog == null)
            return NotFound();

        return Ok(blog);
    }

    // ✅ CREATE (No Id Required)
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBlogDto dto)
    {
        var result = await _service.AddAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result
        );
    }

    // ✅ UPDATE (Id from route, not body)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateBlogDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    // ✅ DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}