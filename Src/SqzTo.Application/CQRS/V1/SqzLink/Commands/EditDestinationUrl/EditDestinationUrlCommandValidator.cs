using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.EditDestinationUrl
{
    public class EditDestinationUrlCommandValidator : AbstractValidator<EditDestinationUrlCommand>
    {
        public EditDestinationUrlCommandValidator()
        {
            RuleFor(command => command.DestinationUrl).MustBeUrl();
        }
    }
}
