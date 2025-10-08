// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using ISL.Providers.Captcha.Abstractions.Models;
using Moq;
using Xunit;

namespace ISL.Providers.Captcha.Abstractions.Tests.Acceptance
{
    public partial class CaptchaAbstractionProviderTests
    {
        [Fact]
        public async Task ShouldValidateCaptchaAsync()
        {
            // given
            string randomCaptchaToken = GetRandomString();
            string randomUserIp = GetRandomString();
            string inputCaptchaToken = randomCaptchaToken.DeepClone();
            string inputUserIp = randomUserIp.DeepClone();
            CaptchaResult randomCaptchaResult = CreateRandomCaptchaResult();
            CaptchaResult outputCaptchaResult = randomCaptchaResult.DeepClone();
            CaptchaResult expectedCaptchaResult = outputCaptchaResult.DeepClone();

            this.captchaProviderMock.Setup(provider =>
                provider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp))
                    .ReturnsAsync(outputCaptchaResult);

            // when
            CaptchaResult actualCaptchaResult =
                await this.captchaAbstractionProvider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualCaptchaResult.Should().BeEquivalentTo(expectedCaptchaResult);
        }
    }
}
