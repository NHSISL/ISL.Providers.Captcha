// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnValidateCaptchaAsync(string invalidCaptchaToken)
        {
            // given
            string someString = GetRandomString();
            string secret = googleReCaptchaConfigurations.ApiSecret;
            Dictionary<string, string> someFormData = CreateRandomFormData(secret, invalidCaptchaToken);

            var invalidArgumentCaptchaException =
                new InvalidCaptchaArgumentException(
                    "Invalid Captcha argument. Please correct the errors and try again.");

            invalidArgumentCaptchaException.AddData(
                key: "captchaToken",
                values: "Text is invalid.");

            var expectedCaptchaValidationException =
                new CaptchaValidationException(
                    message: "Captcha validation error occurred, please fix the errors and try again.",
                    innerException: invalidArgumentCaptchaException);

            googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(someFormData))
                    .Throws(invalidArgumentCaptchaException);

            // when
            ValueTask<bool> validateCaptchaAction =
                captchaService.ValidateCaptchaAsync(invalidCaptchaToken, invalidCaptchaToken);

            CaptchaValidationException actualException =
                await Assert.ThrowsAsync<CaptchaValidationException>(validateCaptchaAction.AsTask);

            // then
            actualException.Should().BeEquivalentTo(expectedCaptchaValidationException);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task ShouldThrowValidationExceptionOnValidateCaptchaWithInvalidFormDataAsync(
            string invalidFormDataValue)
        {
            // given
            string someString = GetRandomString();
            Dictionary<string, string> someFormData = CreateRandomFormData(invalidFormDataValue, someString);
            googleReCaptchaConfigurations.ApiSecret = invalidFormDataValue;

            var invalidCaptchaFormDataException =
                new InvalidCaptchaFormDataException(
                    "Invalid Captcha form data. Please correct the errors and try again.");

            invalidCaptchaFormDataException.AddData(
                key: "secret",
                values: "Text is invalid.");

            var expectedCaptchaValidationException =
                new CaptchaValidationException(
                    message: "Captcha validation error occurred, please fix the errors and try again.",
                    innerException: invalidCaptchaFormDataException);

            googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(someFormData))
                    .Throws(invalidCaptchaFormDataException);

            // when
            ValueTask<bool> validateCaptchaAction =
                captchaService.ValidateCaptchaAsync(someString, "");

            CaptchaValidationException actualException =
                await Assert.ThrowsAsync<CaptchaValidationException>(validateCaptchaAction.AsTask);

            // then
            actualException.Should().BeEquivalentTo(expectedCaptchaValidationException);
        }
    }
}
