using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqzTo.Application.CQRS.V1.SqzLink.Queries.GetSqzLinkQr
{
    class GetSqzLinkQrValidator : AbstractValidator<GetSqzLinkQrQuery>
    {
        public GetSqzLinkQrValidator()
        {
            RuleFor(query => query.SqzLink)
                .NotEmpty().WithMessage($"Field \"sqzlink\" cannot be empty.")
                .NotNull().WithMessage($"Field \"sqzlink\" cannot be null.");
        }
    }
}
