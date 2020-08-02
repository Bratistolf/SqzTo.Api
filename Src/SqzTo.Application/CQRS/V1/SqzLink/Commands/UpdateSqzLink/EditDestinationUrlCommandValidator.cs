using FluentValidation;
using System;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.UpdateSqzLink
{
    public class EditDestinationUrlCommandValidator : AbstractValidator<EditDestinationUrlCommand>
    {
        public EditDestinationUrlCommandValidator()
        {
            RuleFor(command => command.DestinationUrl)
                .Custom((destinationUrl, context) =>
                {
                    Uri uriResult;
                    var isValidUrl = Uri.TryCreate(destinationUrl, UriKind.Absolute, out uriResult);
                    var isUrlHttps = uriResult.Scheme == Uri.UriSchemeHttps;
                    var isUrlHttp = uriResult.Scheme == Uri.UriSchemeHttp;

                    if (isValidUrl && (isUrlHttps || isUrlHttp))
                    {
                        return;
                    }
                    context.AddFailure("Only HTTP and HTTPS protocols are supported.");
                });
        }
    }
}
