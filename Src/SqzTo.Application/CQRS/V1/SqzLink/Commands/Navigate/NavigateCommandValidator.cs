using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.Navigate
{
    public class NavigateCommandValidator : AbstractValidator<NavigateRequest>
    {
        public NavigateCommandValidator()
        {
            RuleFor(command => command.SqzLink).MustBeSqzLink();
        }
    }
}
