using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(command => command.Domain).MustBeDomain();
            RuleFor(command => command.DestinationUrl).MustBeUrl();
        }
    }
}
