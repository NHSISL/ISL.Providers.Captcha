// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.GoogleReCaptcha.Models.Brokers.GoogleReCaptcha;
using System.Threading.Tasks;
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
            bool expectedResponse = outputResponse.Success;
            var path = "/api/siteverify";

            this.wireMockServer
                .Given(
                    Request.Create()
                        .WithPath(path)
                        .UsingPost())
                .RespondWith(
                    Response.Create()
                        .WithSuccess()
                        .WithHeader("Content-Type", "application/json")
                        .WithBodyAsJson(outputResponse));

            // when
            bool actualResponse =
                await this.googleReCaptchaProvider.ValidateCaptchaAsync(captchaToken: randomCaptchaToken);

            // then
            actualResponse.Should().Be(expectedResponse);
        }
    }
}
