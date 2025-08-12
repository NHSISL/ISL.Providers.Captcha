// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using ISL.Providers.Captcha.Abstractions.Models.Exceptions;
using ISL.Providers.Captcha.Abstractions.Tests.Unit.Models.Exceptions;
using Moq;
using System.Threading.Tasks;
using Xeptions;

namespace ISL.Providers.Captcha.Abstractions.Tests.Unit
{
    public partial class CaptchaAbstractionTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionWhenTypeICaptchaValidationExceptionOnLookupByDetails()
        {
            // given
            var someException = new Xeption();

            var someCaptchaValidationException =
                new SomeCaptchaValidationException(
                    message: "Some captcha validation exception occurred",
                    innerException: someException,
                    data: someException.Data);

            CaptchaProviderValidationException expectedCaptchaValidationProviderException =
                new CaptchaProviderValidationException(
                    message: "Captcha validation errors occurred, please try again.",
                    innerException: someCaptchaValidationException);

            this.captchaMock.Setup(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(someCaptchaValidationException);

            // when
            ValueTask<bool> validateCaptchaTask =
                this.captchaAbstractionProvider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>());

            CaptchaProviderValidationException actualCaptchaValidationProviderException =
                await Assert.ThrowsAsync<CaptchaProviderValidationException>(testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaValidationProviderException.Should().BeEquivalentTo(
                expectedCaptchaValidationProviderException);

            this.captchaMock.Verify(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.captchaMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionWhenTypeICaptchaDependencyValidationExceptionOnLookupByDetails()
        {
            // given
            var someException = new Xeption();

            var someCaptchaValidationException =
                new SomeCaptchaDependencyValidationException(
                    message: "Some captcha dependency validation exception occurred",
                    innerException: someException,
                    data: someException.Data);

            CaptchaProviderValidationException expectedCaptchaValidationProviderException =
                new CaptchaProviderValidationException(
                    message: "Captcha validation errors occurred, please try again.",
                    innerException: someCaptchaValidationException);

            this.captchaMock.Setup(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(someCaptchaValidationException);

            // when
            ValueTask<bool> validateCaptchaTask =
                this.captchaAbstractionProvider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>());

            CaptchaProviderValidationException actualCaptchaValidationProviderException =
                await Assert.ThrowsAsync<CaptchaProviderValidationException>(testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaValidationProviderException.Should().BeEquivalentTo(
                expectedCaptchaValidationProviderException);

            this.captchaMock.Verify(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.captchaMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionWhenTypeICaptchaDependencyExceptionOnLookupByDetails()
        {
            // given
            var someException = new Xeption();

            var someCaptchaValidationException =
                new SomeCaptchaDependencyException(
                    message: "Some captcha dependency exception occurred",
                    innerException: someException);

            CaptchaProviderDependencyException expectedCaptchaDependencyProviderException =
                new CaptchaProviderDependencyException(
                    message: "Captcha dependency error occurred, contact support.",
                    innerException: someCaptchaValidationException);

            this.captchaMock.Setup(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(someCaptchaValidationException);

            // when
            ValueTask<bool> validateCaptchaTask =
                this.captchaAbstractionProvider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>());

            CaptchaProviderDependencyException actualCaptchaDependencyProviderException =
                await Assert.ThrowsAsync<CaptchaProviderDependencyException>(testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaDependencyProviderException.Should().BeEquivalentTo(
                expectedCaptchaDependencyProviderException);

            this.captchaMock.Verify(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.captchaMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionWhenTypeICaptchaServiceExceptionOnLookupByDetails()
        {
            // given
            var someException = new Xeption();

            var someCaptchaValidationException =
                new SomeCaptchaServiceException(
                    message: "Some captcha service exception occurred",
                    innerException: someException);

            CaptchaProviderServiceException expectedCaptchaServiceProviderException =
                new CaptchaProviderServiceException(
                    message: "Captcha service error occurred, contact support.",
                    innerException: someCaptchaValidationException);

            this.captchaMock.Setup(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(someCaptchaValidationException);

            // when
            ValueTask<bool> validateCaptchaTask =
                this.captchaAbstractionProvider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>());

            CaptchaProviderServiceException actualCaptchaServiceProviderException =
                await Assert.ThrowsAsync<CaptchaProviderServiceException>(testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaServiceProviderException.Should().BeEquivalentTo(
                expectedCaptchaServiceProviderException);

            this.captchaMock.Verify(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.captchaMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowUncatagorizedServiceExceptionWhenTypeIsNotExpectedOnLookupByDetails()
        {
            // given
            var someException = new Xeption();

            var uncatagorizedCaptchaProviderException =
                new UncatagorizedCaptchaProviderException(
                    message: "Captcha provider not properly implemented. Uncatagorized errors found, " +
                            "contact the captcha provider owner for support.",
                    innerException: someException,
                    data: someException.Data);

            CaptchaProviderServiceException expectedCaptchaServiceProviderException =
                new CaptchaProviderServiceException(
                    message: "Uncatagorized captcha service error occurred, contact support.",
                    innerException: uncatagorizedCaptchaProviderException);

            this.captchaMock.Setup(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(someException);

            // when
            ValueTask<bool> validateCaptchaTask =
                this.captchaAbstractionProvider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>());

            CaptchaProviderServiceException actualCaptchaServiceProviderException =
                await Assert.ThrowsAsync<CaptchaProviderServiceException>(testCode: validateCaptchaTask.AsTask);

            // then
            actualCaptchaServiceProviderException.Should().BeEquivalentTo(
                expectedCaptchaServiceProviderException);

            this.captchaMock.Verify(provider =>
                provider.ValidateCaptchaAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.captchaMock.VerifyNoOtherCalls();
        }
    }
}
