using FluentValidation;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SqzTo.Application.Common.Validation
{
    public static class CustomValidationRules
    {
        private const string urlRegex = @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$";
        private const string domainRegex = @"^[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])";
        private const string keyRegex = @"[A-Za-z0-9-]{1,63}";
        private const string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public static IRuleBuilderOptions<T, string> MustBeUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(url => url.IsUrl()).WithMessage("Does not appear to be a valid URL.").OverridePropertyName("destination_url");
        }

        public static IRuleBuilderOptions<T, string> MustBeDomain<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(domain => domain.IsDomain()).WithMessage("Does not appear to be a valid domain.").OverridePropertyName("domain");
        }

        public static IRuleBuilderOptions<T, string> MustBeKey<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Key cannot be empty.").OverridePropertyName("key")
                .Must(key => key.IsKey()).WithMessage("Does not appear to be a valid key.").OverridePropertyName("key");
        }

        public static IRuleBuilderOptions<T, string> MustBeSqzLink<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(sqzLink =>
            {
                var sqzLinkSplit = sqzLink.Split(new string[] { "%2F", "/" }, StringSplitOptions.None);
                return sqzLinkSplit[0].IsDomain() && sqzLinkSplit[1].IsKey();
            }).WithMessage("Does not appear to be a valid domain or key.").OverridePropertyName("sqzlink");
        }

        public static IRuleBuilderOptions<T, string> MustBeEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var errorMessage = "";
            return ruleBuilder
                .Must(email =>
                {
                    try { MailAddress mailAddress = new MailAddress(email); }
                    catch (FormatException exception)
                    {
                        errorMessage = exception.Message;
                        return false;
                    }
                    return true;
                }).WithMessage(errorMessage).OverridePropertyName("email");
        }

        private static bool IsUrl(this string url)
        {
            return Regex.IsMatch(url, urlRegex);
        }

        private static bool IsDomain(this string domain)
        {
            return Regex.IsMatch(domain, domainRegex);
        }

        private static bool IsKey(this string key)
        {
            return Regex.IsMatch(key, keyRegex);
        }
    }
}
