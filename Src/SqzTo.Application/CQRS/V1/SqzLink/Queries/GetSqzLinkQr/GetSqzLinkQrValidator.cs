using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkQr
{
    class GetSqzLinkQrValidator : AbstractValidator<GetSqzLinkQrQuery>
    {
        public GetSqzLinkQrValidator()
        {
            RuleFor(query => query.SqzLink).MustBeSqzLink();
        }
    }
}
