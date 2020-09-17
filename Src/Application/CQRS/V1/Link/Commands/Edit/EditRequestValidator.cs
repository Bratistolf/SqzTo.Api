using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Edit
{
    public class EditRequestValidator : AbstractValidator<EditRequest>
    {
        public EditRequestValidator()
        {
            RuleFor(request => request.SqzLink).MustBeSqzLink();

            RuleFor(request => request.Body.Domain).MustBeDomain();

            RuleFor(request => request.Body.Key).MustBeKey();

            RuleFor(request => request.Body.Description)
                .MaximumLength(128).WithMessage("SqzLink's description cannot be longer than 128 characters.").OverridePropertyName("description");
        }
    }
}
