// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Services.Foundations.Captcha.Exceptions;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        [Fact]
        public async Task ShouldThrowServiceExceptionOnValidateCaptchaAsync()
        {
            // given
            var serviceException = new Exception();
            string someString = GetRandomString();

            var failedServiceCaptchaException =
                new FailedCaptchaServiceException(
                    message: "Failed Captcha service error occurred, please contact support.",
                    innerException: serviceException,
                    data: serviceException.Data);

            var expectedCaptchaServiceException =
                new CaptchaServiceException(
                    message: "Captcha service error occurred, please contact support.",
                    innerException: failedServiceCaptchaException);

            this.googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(someString, ""))
                    .Throws(serviceException);

            // when
            ValueTask<bool> validateCaptchaTask = captchaService.ValidateCaptchaAsync(someString, "");

            CaptchaServiceException actualCaptchaServiceException =
                await Assert.ThrowsAsync<CaptchaServiceException>(
                    testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaServiceException.Should().BeEquivalentTo(expectedCaptchaServiceException);
        }
    }
}
