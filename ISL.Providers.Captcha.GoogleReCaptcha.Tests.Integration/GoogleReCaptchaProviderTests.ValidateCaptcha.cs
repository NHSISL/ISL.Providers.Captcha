// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Integration
{
    public partial class GoogleReCaptchaProviderTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string inputCaptchaToken = "valid-captcha";
            bool expectedSuccess = true;
            double expectedScore = 0.0;

            CaptchaResult expectedCaptchaResult = new CaptchaResult
            {
                Success = expectedSuccess,
                Score = expectedScore
            };

            // when
            CaptchaResult actualResponse =
                await this.googleReCaptchaProvider.ValidateCaptchaAsync(inputCaptchaToken, "");

            // then
            actualResponse.Should().BeEquivalentTo(expectedCaptchaResult);
        }
    }
}