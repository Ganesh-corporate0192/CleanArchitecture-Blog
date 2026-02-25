using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;
using CleanArchitecture.Application.Features.Blogs.Queries.GetAllBlogs;

var builder = WebApplication.CreateBuilder(args);

// Add SQLServer
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Mediator added
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(CreateBlogCommand).Assembly));


// Dependency Injection
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<BlogService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();