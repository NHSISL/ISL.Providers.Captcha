// ---------------------------------------------------------
// Copyright (c) North East London ICB. All rights reserved.
// ---------------------------------------------------------

using ISL.Providers.Captcha.FakeCaptcha.Providers.FakeCaptcha;
using Tynamix.ObjectFiller;

namespace ISL.Providers.Captcha.FakeCaptcha.Tests.Acceptance
{
    public partial class CaptchaServiceTests
    {
        private readonly IFakeCaptchaProvider fakeCaptchaProvider;

        public CaptchaServiceTests()
        {
            this.fakeCaptchaProvider = new FakeCaptchaProvider();
        }

        private static string GetRandomString() =>
            new MnemonicString().GetValue();
    }
}
