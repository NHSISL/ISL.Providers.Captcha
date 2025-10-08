// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.Abstractions.Models;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Acceptance
{
    public partial class GoogleReCaptchaProviderTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string randomCaptchaToken = GetRandomString();
            GoogleReCaptchaResponse randomResponse = CreateRandomGoogleReCaptchaResponse();
            GoogleReCaptchaResponse outputResponse = randomResponse.DeepClone();

            var expectedResponse = new CaptchaResult
            {
                IsCaptchaValid = outputResponse.Success,
                Score = outputResponse.Score
            };

            this.wireMockServer
                .Given(
                    Request.Create()
                        .UsingPost())
                .RespondWith(
                    Response.Create()
                        .WithSuccess()
                        .WithHeader("Content-Type", "application/json")
                        .WithBodyAsJson(outputResponse));

            // when
            CaptchaResult actualResponse =
                await this.googleReCaptchaProvider.ValidateCaptchaAsync(captchaToken: randomCaptchaToken);

            // then
            actualResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
