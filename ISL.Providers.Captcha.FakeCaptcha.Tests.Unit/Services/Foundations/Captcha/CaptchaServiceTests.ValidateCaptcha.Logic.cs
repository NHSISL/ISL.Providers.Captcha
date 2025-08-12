// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using System.Threading.Tasks;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Unit.Services.Foundations.Captcha
{
    public partial class CaptchaServiceTests
    {
        [Fact]
        public async Task ShouldPatientLookupByDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string inputUserIp = randomString.DeepClone();
            string inputCaptchaToken = "valid-captcha";
            bool expectedResponse = true;

            // when
            bool actualResponse = await this.captchaService
                .ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualResponse.Should().Be(expectedResponse);
        }
    }
}
