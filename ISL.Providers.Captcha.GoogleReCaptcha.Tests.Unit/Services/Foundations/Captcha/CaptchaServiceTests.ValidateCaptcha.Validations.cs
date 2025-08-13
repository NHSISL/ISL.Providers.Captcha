// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

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
                broker.ValidateCaptchaAsync(invalidCaptchaToken, ""))
                    .Throws(invalidArgumentCaptchaException);

            // when
            ValueTask<bool> validateCaptchaAction =
                captchaService.ValidateCaptchaAsync(invalidCaptchaToken, invalidCaptchaToken);

            CaptchaValidationException actualException =
                await Assert.ThrowsAsync<CaptchaValidationException>(validateCaptchaAction.AsTask);

            // then
            actualException.Should().BeEquivalentTo(expectedCaptchaValidationException);
        }
    }
}
