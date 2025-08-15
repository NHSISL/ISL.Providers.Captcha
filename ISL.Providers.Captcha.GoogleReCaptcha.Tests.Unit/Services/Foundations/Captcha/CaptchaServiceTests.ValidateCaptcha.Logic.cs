// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Moq;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using System.Collections.Generic;
using System.Net.Http;

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
            string secret = googleReCaptchaConfigurations.ApiSecret;
            Dictionary<string, string> inputFormData = CreateRandomFormData(secret, inputCaptchaToken);
            HttpResponseMessage googleReCaptchaResponse = CreateHttpRepsonseMessage();
            HttpResponseMessage outputGoogleReCaptchaResponse = googleReCaptchaResponse.DeepClone();
            bool expectedResponse = await GetSuccessFromHttpResponse(outputGoogleReCaptchaResponse);

            this.googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(inputFormData))
                    .ReturnsAsync(outputGoogleReCaptchaResponse);

            // When
            bool actualResponse = await captchaService.ValidateCaptchaAsync(inputCaptchaToken, "");

            // Then
            actualResponse.Should().Be(expectedResponse);

            this.googleReCaptchaBroker.Verify(broker =>
                broker.ValidateCaptchaAsync(inputFormData),
                    Times.Once());

            this.googleReCaptchaBroker.VerifyNoOtherCalls();
        }
    }
}
