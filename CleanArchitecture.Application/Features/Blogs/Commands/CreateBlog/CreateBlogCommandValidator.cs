using FluentValidation;

namespace CleanArchitecture.Application.Features.Blogs.Commands.CreateBlog;

public class CreateBlogCommandValidator
    : AbstractValidator<CreateBlogCommand>
{
    public CreateBlogCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("ImageUrl is required")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("Invalid Image URL");
    }
}