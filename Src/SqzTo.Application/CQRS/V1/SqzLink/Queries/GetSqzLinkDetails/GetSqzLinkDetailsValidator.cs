using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsValidator : AbstractValidator<GetSqzLinkDetailsQuery>
    {
        public GetSqzLinkDetailsValidator()
        {
            RuleFor(query => query.SqzLink).MustBeSqzLink();
        }
    }
}
