// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Unit.Services.Foundations.Captcha
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
                new InvalidArgumentCaptchaException(
                    "Invalid Captcha argument. Please correct the errors and try again.");

            invalidArgumentCaptchaException.AddData(
                key: "captchaToken",
                values: "Text is invalid.");

            var expectedCaptchaValidationException =
                new CaptchaValidationException(
                    message: "Captcha validation error occurred, please fix the errors and try again.",
                    innerException: invalidArgumentCaptchaException);

            // when
            bool validateCaptchaAction =
                captchaService.ValidateCaptcha(invalidCaptchaToken, invalidCaptchaToken);

            CaptchaValidationException actualException =
                Assert.Throws<CaptchaValidationException>(() => validateCaptchaAction);

            // then
            actualException.Should().BeEquivalentTo(expectedCaptchaValidationException);
        }
    }
}
