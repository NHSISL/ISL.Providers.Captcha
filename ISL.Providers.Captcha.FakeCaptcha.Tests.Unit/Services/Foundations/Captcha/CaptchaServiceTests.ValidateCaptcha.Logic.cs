// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string randomString = GetRandomString();
            string inputUserIp = randomString.DeepClone();
            string inputCaptchaToken = "valid-captcha";
            bool expectedSuccess = true;
            double expectedScore = 1.0;

            CaptchaResult expectedResponse = new CaptchaResult
            {
                Success = expectedSuccess,
                Score = expectedScore
            };

            // when
            CaptchaResult actualResponse = await this.captchaService
                .ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
