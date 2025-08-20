using FluentValidation;

namespace ContentManagementSystem.Blog.Features.Create
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>  
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
