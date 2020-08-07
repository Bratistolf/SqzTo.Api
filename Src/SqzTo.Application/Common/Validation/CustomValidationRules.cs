using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace SqzTo.Application.Common.Validation
{
    public static class CustomValidationRules
    {
        public static IRuleBuilderOptions<T, string> MustBeUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(url => IsUrl(url)).WithMessage("Does not appear to be a valid URL").OverridePropertyName("destination_url");
        }

        public static IRuleBuilderOptions<T, string> MustBeDomain<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(domain => IsDomain(domain)).WithMessage("Does not appear to be a valid domain").OverridePropertyName("domain");
        }

        public static IRuleBuilderOptions<T, string> MustBeSqzLink<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(sqzLink =>
            {
                var sqzLinkSplit = sqzLink.Split(new string[] { "%2F", "/" }, StringSplitOptions.None);
                return IsDomain(sqzLinkSplit[0]) && IsKey(sqzLinkSplit[1]);
            }).WithMessage("Does not appear to be a valid domain or key").OverridePropertyName("sqzlink");
        }

        private static bool IsUrl(string url)
        {
            return Regex.IsMatch(url, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_]*)?$");
        }

        private static bool IsDomain(string domain)
        {
            return Regex.IsMatch(domain, @"^[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])");
        }

        private static bool IsKey(string key)
        {
            return Regex.IsMatch(key, @"[A-Za-z0-9-]{1,63}");
        }
    }
}
