// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Moq;
using System.Threading.Tasks;
using FluentAssertions;

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
            bool expectedResponse = true;

            this.googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(inputCaptchaToken, ""))
                    .ReturnsAsync(true);

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
