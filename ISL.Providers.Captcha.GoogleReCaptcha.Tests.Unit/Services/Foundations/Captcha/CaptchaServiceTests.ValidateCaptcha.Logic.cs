// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.Abstractions.Models;
using Moq;

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
            CaptchaResult expectedResponse = await GetCaptchaResultFromHttpResponse(outputGoogleReCaptchaResponse);

            this.googleReCaptchaBroker.Setup(broker =>
                broker.ValidateCaptchaAsync(inputFormData))
                    .ReturnsAsync(outputGoogleReCaptchaResponse);

            // When
            CaptchaResult actualResponse = await captchaService.ValidateCaptchaAsync(inputCaptchaToken, "");

            // Then
            actualResponse.Should().BeEquivalentTo(expectedResponse);

            this.googleReCaptchaBroker.Verify(broker =>
                broker.ValidateCaptchaAsync(inputFormData),
                    Times.Once());

            this.googleReCaptchaBroker.VerifyNoOtherCalls();
        }
    }
}
