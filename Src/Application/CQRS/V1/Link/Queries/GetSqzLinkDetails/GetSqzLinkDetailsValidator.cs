using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.Link.Queries.GetSqzLinkDetails
{
    public class GetSqzLinkDetailsValidator : AbstractValidator<GetDetailsRequest>
    {
        public GetSqzLinkDetailsValidator()
        {
            RuleFor(query => query.SqzLink).MustBeSqzLink();
        }
    }
}
