// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using Moq;

namespace ISL.Providers.Captcha.Abstractions.Tests.Unit
{
    public partial class CaptchaAbstractionTests
    {
        private readonly Mock<ICaptchaProvider> captchaMock;
        private readonly CaptchaAbstractionProvider captchaAbstractionProvider;

        public CaptchaAbstractionTests()
        {
            this.captchaMock = new Mock<ICaptchaProvider>();

            this.captchaAbstractionProvider =
                new CaptchaAbstractionProvider(this.captchaMock.Object);
        }
    }
}
