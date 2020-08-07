using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkClicks
{
    public class GetSqzLinkDetailsValidator : AbstractValidator<GetSqzLinkClicksQuery>
    {
        public GetSqzLinkDetailsValidator()
        {
            RuleFor(query => query.SqzLink).MustBeSqzLink();
        }
    }
}
