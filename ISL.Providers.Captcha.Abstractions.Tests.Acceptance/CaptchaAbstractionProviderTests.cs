// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.Abstractions.Models;
using Moq;
using Tynamix.ObjectFiller;

namespace ISL.Providers.Captcha.Abstractions.Tests.Acceptance
{
    public partial class CaptchaAbstractionProviderTests
    {
        private readonly Mock<ICaptchaProvider> captchaProviderMock;
        private readonly ICaptchaAbstractionProvider captchaAbstractionProvider;

        public CaptchaAbstractionProviderTests()
        {
            captchaProviderMock = new Mock<ICaptchaProvider>();

            this.captchaAbstractionProvider =
                new CaptchaAbstractionProvider(captchaProviderMock.Object);
        }

        private static string GetRandomString()
        {
            int length = GetRandomNumber();

            return new MnemonicString(wordCount: 1, wordMinLength: length, wordMaxLength: length).GetValue();
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static bool GetRandomBool()
        {
            int number = GetRandomNumber();

            if (number > 5)
            {
                return true;
            }

            return false;

        }

        private static double GetRandomDouble() =>
            new DoubleRange(1.0).GetValue();

        private static CaptchaResult CreateRandomCaptchaResult() =>
            new CaptchaResult
            {
                Success = GetRandomBool(),
                Score = GetRandomDouble()
            };
    }
}
