using FluentValidation;
using SqzTo.Application.Common.Validation;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetClicks
{
    public class GetClicksRequestHandlerValidator : AbstractValidator<GetClicksRequest>
    {
        public GetClicksRequestHandlerValidator()
        {
            RuleFor(query => query.SqzLink).MustBeSqzLink();
        }
    }
}
