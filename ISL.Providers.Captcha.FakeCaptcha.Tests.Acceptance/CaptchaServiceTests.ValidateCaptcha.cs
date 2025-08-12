// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using System.Threading.Tasks;

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
            bool expectedResponse = true;

            // when
            bool actualResponse =
                await this.fakeCaptchaProvider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualResponse.Should().Be(expectedResponse);
        }
    }
}
