// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System.Threading.Tasks;
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
            bool randomOutputBool = GetRandomBool();
            bool outputBool = randomOutputBool.DeepClone();
            bool expectedPatient = outputBool.DeepClone();

            this.captchaProviderMock.Setup(provider =>
                provider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp))
                    .ReturnsAsync(outputBool);

            // when
            bool actualPatient =
                await this.captchaAbstractionProvider.ValidateCaptchaAsync(inputCaptchaToken, inputUserIp);

            // then
            actualPatient.Should().Be(expectedPatient);
        }
    }
}
