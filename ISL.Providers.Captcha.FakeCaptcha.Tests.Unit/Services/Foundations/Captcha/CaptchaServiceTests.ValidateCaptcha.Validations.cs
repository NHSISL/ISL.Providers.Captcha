// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using ISL.Providers.Captcha.FakeCaptcha.Services.Foundations;
using Moq;
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

            var captchaServiceMock = new Mock<CaptchaService>()
            {
                CallBase = true
            };

            captchaServiceMock.Setup(service =>
                service.ValidateCaptchaValidationArguments(invalidCaptchaToken))
                    .Throws(invalidArgumentCaptchaException);

            // when
            ValueTask<bool> validateCaptchaAction =
                captchaServiceMock.Object.ValidateCaptchaAsync(invalidCaptchaToken, invalidCaptchaToken);

            CaptchaValidationException actualException =
                await Assert.ThrowsAsync<CaptchaValidationException>(validateCaptchaAction.AsTask);

            // then
            actualException.Should().BeEquivalentTo(expectedCaptchaValidationException);
        }
    }
}
