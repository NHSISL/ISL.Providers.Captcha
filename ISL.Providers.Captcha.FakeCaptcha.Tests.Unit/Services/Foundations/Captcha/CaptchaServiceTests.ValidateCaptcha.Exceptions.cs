// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.FakeCaptcha.Models.Foundations.Captcha.Exceptions;
using ISL.Providers.Captcha.FakeCaptcha.Services.Foundations;
using Moq;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Unit.Services.Foundations.Captcha
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
                new FailedServiceCaptchaException(
                    message: "Failed Captcha service error occurred, please contact support.",
                    innerException: serviceException,
                    data: serviceException.Data);

            var expectedCaptchaServiceException =
                new CaptchaServiceException(
                    message: "Captcha service error occurred, please contact support.",
                    innerException: failedServiceCaptchaException);

            var captchaServiceMock = new Mock<CaptchaService>()
            {
                CallBase = true
            };

            captchaServiceMock.Setup(service =>
                service.ValidateCaptchaValidationArguments(someString))
                    .Throws(serviceException);

            // when
            ValueTask<CaptchaResult> validateCaptchaTask =
                captchaServiceMock.Object.ValidateCaptchaAsync(someString, someString);

            CaptchaServiceException actualCaptchaServiceException =
                await Assert.ThrowsAsync<CaptchaServiceException>(
                    testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaServiceException.Should().BeEquivalentTo(
                expectedCaptchaServiceException);
        }
    }
}
