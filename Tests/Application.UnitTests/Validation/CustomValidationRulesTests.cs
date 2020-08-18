using FluentValidation;
using FluentValidation.TestHelper;
using FluentValidation.Validators;
using NUnit.Framework;
using SqzTo.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.Validation
{
    [TestFixture]
    public class CustomValidationRulesTests
    {
        internal class UrlValidator : AbstractValidator<string>
        {
            public UrlValidator() => RuleFor(x => x).MustBeUrl();
        }

        [TestCase("")]
        [TestCase("string")]
        public void ShouldHaveValidationErrors(string wrongUrl)
        {
            // Arrange
            var validator = new UrlValidator();

            // Act & Assert
            validator.ShouldHaveValidationErrorFor(x => x, wrongUrl).;
        }
    }
}
