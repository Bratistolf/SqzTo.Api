using FluentValidation;
using System;

namespace SqzTo.Application.CQRS.V1.SqzLink.Commands.CreateSqzLink
{
    public class CreateSqzLinkCommandValidator : AbstractValidator<CreateSqzLinkCommand>
    {
        public CreateSqzLinkCommandValidator()
        {
            RuleFor(command => command.Domain)
                .NotEmpty().OverridePropertyName("domain");

            RuleFor(command => command.DestinationUrl)
                .Custom((destinationUrl, context) =>
                {
                    Uri uriResult;
                    var isValidUrl = Uri.TryCreate(destinationUrl, UriKind.Absolute, out uriResult);
                    if (isValidUrl)
                    {
                        var isUrlHttps = uriResult.Scheme == Uri.UriSchemeHttps;
                        var isUrlHttp = uriResult.Scheme == Uri.UriSchemeHttp;

                        if (isValidUrl && (isUrlHttps || isUrlHttp))
                        {
                            return;
                        }

                        context.AddFailure("destination_url", "Only http or https protocols are supported.");
                    }

                    context.AddFailure("destination_url", $"Field \"destination_url\" must contain a valid URL.");
                });
        }
    }
}
