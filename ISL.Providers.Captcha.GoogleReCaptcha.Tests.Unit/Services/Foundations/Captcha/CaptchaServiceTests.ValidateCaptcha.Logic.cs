// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Moq;
using System.Threading.Tasks;
using FluentAssertions;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using Force.DeepCloner;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // Given
            string randomString = GetRandomString();
            string inputCaptchaToken = randomString;
            GoogleReCaptchaResponse googleReCaptchaResponse = CreateGoogleReCaptchaResponse();
            GoogleReCaptchaResponse outputGoogleReCaptchaResponse = googleReCaptchaResponse.DeepClone();
            bool expectedResponse = outputGoogleReCaptchaResponse.Success;

            this.googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(inputCaptchaToken, ""))
                    .ReturnsAsync(outputGoogleReCaptchaResponse);

            // When
            bool actualResponse = await captchaService.ValidateCaptchaAsync(inputCaptchaToken, "");

            // Then
            actualResponse.Should().Be(expectedResponse);

            this.googleReCaptchaBroker.Verify(broker =>
                broker.ValidateCaptchaAsync(inputCaptchaToken, ""),
                    Times.Once());

            this.googleReCaptchaBroker.VerifyNoOtherCalls();
        }
    }
}
