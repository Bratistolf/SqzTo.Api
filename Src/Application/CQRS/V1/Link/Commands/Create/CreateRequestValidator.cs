using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Create
{
    /// <inheritdoc/>
    public class CreateRequestValidator : AbstractValidator<CreateCommand>
    {
        /// <inheritdoc/>
        public CreateRequestValidator()
        {
            RuleFor(command => command.Domain).MustBeDomain();
            RuleFor(command => command.DestinationUrl).MustBeUrl();
        }
    }
}
