using CleanArchitecture.Application.Features.Blogs.Commands.UpdateMultipleBlogs;
using FluentValidation;

public class UpsertMultipleBlogsCommandValidator
    : AbstractValidator<UpsertMultipleBlogsCommand>
{
    public UpsertMultipleBlogsCommandValidator()
    {
        // 🔹 Validate list itself
        RuleFor(x => x.Blogs)
            .NotNull().WithMessage("Blogs list cannot be null")
            .NotEmpty().WithMessage("Blogs list cannot be empty");

        // 🔹 Validate each item
        RuleForEach(x => x.Blogs).ChildRules(blog =>
        {
            blog.RuleFor(b => b.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id must be greater than or equal to 0");

            blog.RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            blog.RuleFor(b => b.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(1000).WithMessage("Description too long");

            blog.RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Author is required")
                .MaximumLength(50).WithMessage("Author too long");

            blog.RuleFor(b => b.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl is required")
                .Must(BeValidUrl).WithMessage("Invalid Image URL");
        });
    }

    private bool BeValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}