// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.Abstractions.Models;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Acceptance
{
    public partial class CaptchaServiceTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string randomCaptchaToken = "valid-captcha";
            string randomUserIp = GetRandomString();
            string inputCaptchaToken = randomCaptchaToken.DeepClone();
            string inputUserIp = randomUserIp.DeepClone();
            bool expectedSuccess = true;
            double expectedScore = 1.0;

            CaptchaResult expectedCaptchaResult = new CaptchaResult
            {
                Success = expectedSuccess,
                Score = expectedScore
            };

            // when
            CaptchaResult actualResponse =
                await this.fakeCaptchaProvider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualResponse.Should().BeEquivalentTo(expectedCaptchaResult);
        }
    }
}
