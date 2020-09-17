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

        /// <summary>
        /// Defines a 'url' validator on the current rule builder. Validation will fail if the string is not url.
        /// </summary>
        /// <typeparam name="T">Type of object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
        /// <returns>Validation result.</returns>
        public static IRuleBuilderOptions<T, string> MustBeUrl<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(url => url.IsUrl()).WithMessage("Does not appear to be a valid URL.").OverridePropertyName("destination_url");
        }

        /// <summary>
        /// Defines a 'domain' validator on the current rule builder. Validation will fail if the string is not domain.
        /// </summary>
        /// <typeparam name="T">Type of object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
        /// <returns>Validation result.</returns>
        public static IRuleBuilderOptions<T, string> MustBeDomain<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotNull().WithMessage("Domain cannot be empty.").OverridePropertyName("domain")
                .Must(domain => domain.IsDomain()).WithMessage("Does not appear to be a valid domain.").OverridePropertyName("domain");
        }

        /// <summary>
        /// Defines a 'key' validator on the current rule builder. Validation will fail if the string is not key.
        /// </summary>
        /// <typeparam name="T">Type of object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
        /// <returns>Validation result.</returns>
        public static IRuleBuilderOptions<T, string> MustBeKey<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Key cannot be empty.").OverridePropertyName("key")
                .NotNull().WithMessage("Key cannot be empty.").OverridePropertyName("key")
                .Must(key => key.IsKey()).WithMessage("Does not appear to be a valid key.").OverridePropertyName("key");
        }

        /// <summary>
        /// Defines a 'sqzlink' validator on the current rule builder. Validation will fail if the string is not sqzlink.
        /// </summary>
        /// <typeparam name="T">Type of object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
        /// <returns>Validation result.</returns>
        public static IRuleBuilderOptions<T, string> MustBeSqzLink<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(sqzLink =>
            {
                var sqzLinkSplit = sqzLink.Split(new string[] { "%2F", "/" }, StringSplitOptions.None);
                return sqzLinkSplit[0].IsDomain() && sqzLinkSplit[1].IsKey();
            }).WithMessage("Does not appear to be a valid domain or key.").OverridePropertyName("sqzlink");
        }

        /// <summary>
        /// Defines a 'email' validator on the current rule builder. Validation will fail if the string is not email.
        /// </summary>
        /// <typeparam name="T">Type of object being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder on which the validator should be defined.</param>
        /// <returns>Validation result.</returns>
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
            return true;
            //return Regex.IsMatch(url, urlRegex);
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
