using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.Link.Commands.Navigate
{
    public class NavigateCommandValidator : AbstractValidator<NavigateRequest>
    {
        public NavigateCommandValidator()
        {
            RuleFor(command => command.SqzLink).MustBeSqzLink();
        }
    }
}
