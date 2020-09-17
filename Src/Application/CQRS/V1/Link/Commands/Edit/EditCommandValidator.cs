using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Edit
{
    public class EditCommandValidator : AbstractValidator<EditCommand>
    {
        public EditCommandValidator()
        {
            RuleFor(request => request.SqzLink).MustBeSqzLink();

            RuleFor(request => request.Domain).MustBeDomain();

            RuleFor(request => request.Key).MustBeKey();

            RuleFor(request => request.Description).MaximumLength(128).WithMessage("SqzLink's description cannot be longer than 128 characters.").OverridePropertyName("description");
        }
    }
}
