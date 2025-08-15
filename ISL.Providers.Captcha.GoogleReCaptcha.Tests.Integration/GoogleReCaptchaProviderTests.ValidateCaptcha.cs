// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.GoogleReCaptcha.Tests.Integration
{
    public partial class GoogleReCaptchaProviderTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string inputCaptchaToken = "valid-captcha";
            bool expectedResponse = true;

            // when
            bool actualResponse =
                await this.googleReCaptchaProvider.ValidateCaptchaAsync(inputCaptchaToken, "");

            // then
            actualResponse.Should().Be(expectedResponse);
        }
    }
}