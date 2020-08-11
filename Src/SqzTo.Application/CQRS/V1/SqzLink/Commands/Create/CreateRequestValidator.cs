using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Create
{
    public class CreateRequestValidator : AbstractValidator<CreateRequest>
    {
        public CreateRequestValidator()
        {
            RuleFor(command => command.Domain).MustBeDomain();

            RuleFor(command => command.DestinationUrl).MustBeUrl();
        }
    }
}
